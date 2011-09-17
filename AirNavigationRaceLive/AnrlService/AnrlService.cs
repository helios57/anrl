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
using AnrlDB;
namespace AnrlService
{
    public partial class AnrlService : ServiceBase
    {
        private const int PORT = 1337;
        private const int PORTGPS = 1338;
        private TCPReciever.Server Reciever;
        private static RequestProcessor processor;
        private static GPSRequestProcessor GPSprocessor;
        private Socket listener;
        private Socket listenerGPS;
        public AnrlService()
        {
            InitializeComponent();
        }

        public void start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, PORT);
            listener = new Socket(localEP.Address.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEP);
            listener.Listen(100);

            IPEndPoint localEPGPS = new IPEndPoint(IPAddress.Any, PORTGPS);
            listenerGPS = new Socket(localEP.Address.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            listenerGPS.Bind(localEPGPS);
            listenerGPS.Listen(100);

            try
            {
                listener.BeginAccept(new AsyncCallback(ClientConnected), listener);
                listenerGPS.BeginAccept(new AsyncCallback(GPSClientConnected), listenerGPS);

            }
            catch (Exception ex)
            {
#if !DEBUG
                Logger.Log("Unable to start Service " + ex.InnerException.Message, 0);
#else
                System.Console.WriteLine("Unable to start Service " + ex.InnerException.Message);
#endif
            }
            try
            {
                Reciever = new TCPReciever.Server();
            }
            catch (Exception ex)
            {
#if !DEBUG

                Logger.Log("Unable to start Service " + ex.InnerException.Message, 0);
#else
                System.Console.WriteLine("Unable to start Service " + ex.InnerException.Message);
#endif
            }

        }
        private void ClientConnected(IAsyncResult result)
        {
            try
            {
                Socket listener = (Socket)result.AsyncState;
                Socket handler = listener.EndAccept(result);
                listener.BeginAccept(new AsyncCallback(ClientConnected), listener);

                try
                {
                    processConnection(handler);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }

            }
            catch (Exception ex)
            {
#if !DEBUG

                Logger.Log("Unable to recieve Connection " + ex.InnerException.Message, 0);
#else
                System.Console.WriteLine("Unable to recieve Connection " + ex.InnerException.Message);
#endif
            }
        }

        private void processConnection(Socket handler)
        {

            NetworkStream stream = new NetworkStream(handler);
            Root reqest = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
            if (reqest == null)
            {
                reqest = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
            }
            if (processor == null || !processor.isUseable())
            {
                processor = new RequestProcessor();
            }
            Root response = processor.proccessRequest(reqest);
            Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Base128);
            stream.Flush();
            stream.Close();
            handler.Close();
        }

        static void GPSClientConnected(IAsyncResult result)
        {
            try
            {
                Socket listener = (Socket)result.AsyncState;
                Socket handler = listener.EndAccept(result);
                listener.BeginAccept(new AsyncCallback(GPSClientConnected), listener);
                try
                {
                    NetworkStream stream = new NetworkStream(handler);
                    RootMessage reqest = Serializer.DeserializeWithLengthPrefix<RootMessage>(stream, PrefixStyle.Fixed32BigEndian);

                    if (GPSprocessor == null || !GPSprocessor.isUseable())
                    {
                        GPSprocessor = new GPSRequestProcessor();
                    }
                    RootMessage response = GPSprocessor.proccessRequest(reqest);
                    Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Fixed32BigEndian);
                    stream.Flush();
                    stream.Close();
                    handler.Close();
                }
                catch (Exception ex)
                {
                    Logger.Log("Unable to recieve Connection " + ex.InnerException.Message, 0);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Unable to recieve Connection " + ex.InnerException.Message, 0);
            }
        }

        protected override void OnStop()
        {
            try
            {
                listener.Close();
            }
            catch
            {
            }
            try
            {
                listenerGPS.Close();
            }
            catch
            {
            }
            if (Reciever != null)
            {
                try
                {
                    Reciever.Stop();
                }
                catch (Exception ex)
                {
                    Logger.Log("Unable to stop Service " + ex.InnerException.Message, 0);
                }
            }
        }
    }
}
