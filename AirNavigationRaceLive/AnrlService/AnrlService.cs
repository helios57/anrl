using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net.Sockets;
using System.Net;
using NetworkObjects;
using ProtoBuf;
using System.Threading;
using AnrlService.Server;

namespace AnrlService
{
    public partial class AnrlService : ServiceBase
    {
        private const int PORT = 1337;
        private TcpListener server;
        private TCPReciever.Server Reciever;
        private static RequestProcessor processor;
        public AnrlService()
        {
            InitializeComponent();
            OnStart(null);//Remove
        }

        protected override void OnStart(string[] args)
        {
            if (server == null)
            {
                try
                {
                    server = new TcpListener(IPAddress.Any, PORT);
                    server.Start();
                    server.BeginAcceptTcpClient(ClientConnected, server);
                }
                catch (Exception ex)
                {
                    System.Console.Out.WriteLine("Unable to start Service " + ex.InnerException.Message);
                }
                try
                {
                    Reciever = new TCPReciever.Server();
                }
                catch (Exception ex)
                {
                    System.Console.Out.WriteLine("Unable to start Service " + ex.InnerException.Message);
                }
            }
        }
        static void ClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                using (TcpClient client = server.EndAcceptTcpClient(result))
                using (NetworkStream stream = client.GetStream())
                {
                    while (true)
                    {
                        Root reqest = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
                        if (reqest.RequestType == (int)RequestType.Close)
                        {
                            stream.Close();
                            client.Close();
                            return;
                        }
                        if (processor == null || !processor.isUseable())
                        {
                            processor = new RequestProcessor();
                        }
                        Root response = processor.proccessRequest(reqest);
                        Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Base128);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("Unable to recieve Connection " + ex.InnerException.Message);
            }
        }

        protected override void OnStop()
        {
            if (Reciever != null)
            {
                try
                {
                    Reciever.Stop();
                }
                catch (Exception ex)
                {
                    System.Console.Out.WriteLine("Unable to stop Service " + ex.InnerException.Message);
                }
            }
        }
    }
}
