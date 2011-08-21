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
using NetworkObjects.GPSInput;

namespace AnrlService
{
    public partial class AnrlService : ServiceBase
    {
        private const int PORT = 1337;
        private const int PORTGPS = 1338;
        private TcpListener server;
        private TcpListener serverGPS;
        private TCPReciever.Server Reciever;
        private static RequestProcessor processor;
        private static GPSRequestProcessor GPSprocessor;

        public AnrlService()
        {
            InitializeComponent();
            if (!EventLog.SourceExists(ServiceName))
                EventLog.CreateEventSource(ServiceName, "Application");
        }

        public void start()
        {
            OnStart(null);
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

                    serverGPS = new TcpListener(IPAddress.Any, PORTGPS);
                    serverGPS.Start();
                    serverGPS.BeginAcceptTcpClient(GPSClientConnected, server);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(ServiceName, "Unable to start Service " + ex.InnerException.Message, EventLogEntryType.Error, 1);
                }
                try
                {
                    Reciever = new TCPReciever.Server();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(ServiceName, "Unable to start Service " + ex.InnerException.Message, EventLogEntryType.Error, 2);
                }
            }
        }
        static void ClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                using (TcpClient client = server.EndAcceptTcpClient(result))
                {
                    server.BeginAcceptTcpClient(ClientConnected, server);
                    using (NetworkStream stream = client.GetStream())
                    {
                        Root reqest = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);

                        if (processor == null || !processor.isUseable())
                        {
                            processor = new RequestProcessor();
                        }
                        Root response = processor.proccessRequest(reqest);
                        Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Base128);
                        stream.Close();
                        client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Anrl-Service", "Unable to recieve Connection " + ex.InnerException.Message, EventLogEntryType.Error, 4);
            }
        }

        static void GPSClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                using (TcpClient client = server.EndAcceptTcpClient(result))
                {
                    server.BeginAcceptTcpClient(GPSClientConnected, server);
                    using (NetworkStream stream = client.GetStream())
                    {
                        try
                        {
                            RootMessage reqest = Serializer.DeserializeWithLengthPrefix<RootMessage>(stream, PrefixStyle.Fixed32BigEndian);
                            if (GPSprocessor == null || !GPSprocessor.isUseable())
                            {
                                GPSprocessor = new GPSRequestProcessor();
                            }
                            RootMessage response = GPSprocessor.proccessRequest(reqest);
                            Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Fixed32BigEndian);
                            stream.Flush();
                        }
                        catch (Exception ex)
                        {
                            EventLog.WriteEntry("Anrl-Service", "Unable to recieve Connection " + ex.InnerException.Message, EventLogEntryType.Error, 5);
                        }
                        finally
                        {
                            stream.Close();
                            client.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Anrl-Service", "Unable to recieve Connection " + ex.InnerException.Message, EventLogEntryType.Error, 5);
            }
        }

        protected override void OnStop()
        {
            try
            {
                server.Stop();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Anrl-Service", "Unable to stop Service " + ex.InnerException.Message, EventLogEntryType.Error, 6);
            }
            try
            {
                serverGPS.Stop();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Anrl-Service", "Unable to stop Service " + ex.InnerException.Message, EventLogEntryType.Error, 7);
            }
            if (Reciever != null)
            {
                try
                {
                    Reciever.Stop();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("Anrl-Service", "Unable to stop Service " + ex.InnerException.Message, EventLogEntryType.Error, 8);
                }
            }
        }
    }
}
