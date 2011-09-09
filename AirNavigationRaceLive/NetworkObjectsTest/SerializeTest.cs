using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using NetworkObjects;
using ProtoBuf;

namespace NetworkObjectsTest
{
    [TestClass]
    public class SerializeTest
    {
        const int PORT = 12345;
        [TestMethod]
        public void TestMethod1()
        {

            TcpListener server = new TcpListener(IPAddress.Loopback, PORT);
            server.Start();
            server.BeginAcceptTcpClient(ClientConnected, server);
            Console.WriteLine("SERVER: Waiting for client...");

            ThreadPool.QueueUserWorkItem(RunClient);
            allDone.WaitOne();
            Console.WriteLine("SERVER: Exiting...");
            server.Stop();

        }
        static ManualResetEvent allDone = new ManualResetEvent(false);

        static void ClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                using (TcpClient client = server.EndAcceptTcpClient(result))
                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("SERVER: Client connected; reading customer");
                    Root root = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
                    Console.WriteLine("SERVER: Got customer:");
                    Console.WriteLine(root.AuthInfo.Username);
                    switch ((ERequestType)root.RequestType)
                    {
                        case ERequestType.Login:
                            {
                                root.AuthInfo.Token = "Token " + Environment.MachineName;
                                break;
                            }
                    }
                    Console.WriteLine("SERVER: Returning updated customer:");
                    Serializer.SerializeWithLengthPrefix(stream, root, PrefixStyle.Base128);

                    int final = stream.ReadByte();
                    if (final == 123)
                    {
                        Console.WriteLine("SERVER: Got client-happy marker");
                    }
                    else
                    {
                        Console.WriteLine("SERVER: OOPS! Something went wrong");
                    }
                    Console.WriteLine("SERVER: Closing connection...");
                    stream.Close();
                    client.Close();
                }
            }
            finally
            {
                allDone.Set();
            }

        }

        static void RunClient(object state)
        {
            Root root = new Root();
            root.AuthInfo = new AuthenticationInfo();
            root.AuthInfo.Username = "Testtt ";
            root.RequestType = (int)ERequestType.Login;
            Console.WriteLine("CLIENT: Opening connection...");
            using (TcpClient client = new TcpClient())
            {
                client.Connect(new IPEndPoint(IPAddress.Loopback, PORT));
                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine("CLIENT: Got connection; sending data...");
                    Serializer.SerializeWithLengthPrefix(stream, root, PrefixStyle.Base128);

                    Console.WriteLine("CLIENT: Attempting to read data...");
                    Root rootAnswer = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
                    Console.WriteLine("CLIENT: Got customer: "+ root.AuthInfo.Token);


                    Console.WriteLine("CLIENT: Sending happy...");
                    stream.WriteByte(123); // just to show all bidirectional comms are OK
                    Console.WriteLine("CLIENT: Closing...");
                    stream.Close();
                }
                client.Close();
            }
        }
    }
}
