using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Windows.Forms;
using System.IO;
using DataService;
using System.Linq;

namespace TCPReciever
{
    /// <summary>
    /// Class of the TCP-Reciever Server
    /// </summary>
    class Server
    {
        #region Variablen Deklaration
        private TcpListener tcpListener;
        private Thread listenThread;

        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        public delegate void RecievedGPS(string message);
        public RecievedGPS MyDelegate;

        public bool running;
        List<Thread> ThreadList = new List<Thread>();
        public String DB_PATH;

        public event EventHandler OnTrackerAddded;

        #endregion
        /// <summary>
        /// Create an new Instance of the TCP-Listener on Port 5000
        /// </summary>
        public Server(String DB_Path)
        {
            LogManager.AddLog(DB_Path, 4, "Reciever.cs", "Server Started");
            try
            {
                this.DB_PATH = DB_Path;
                running = true;
                this.tcpListener = new TcpListener(IPAddress.Any, 5000);
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.Start();
                this.MessageReceived += new TCPReciever.Server.MessageReceivedHandler(Message_Received_Processor);
            }
            catch
            {
                LogManager.AddLog(DB_Path,0, "Reciever.cs", "Constructor threw Error");
            }
        }

        /// <summary>
        /// Handels recieved Messages
        /// </summary>
        /// <param name="message">The Message recieved from TCP</param>
        public void Message_Received_Processor(string message)
        {
            MyDelegate = new RecievedGPS(ProcessRecievedGPSData);
            MyDelegate.Invoke(message);
        }
        /// <summary>
        /// Handels the Data recieved and processed in the Message_Received_Processor
        /// Adds the Data to the Database
        /// For Threat-Security
        /// </summary>
        /// <param name="GPSData">THe Data</param>
        public void ProcessRecievedGPSData(string GPSData)
        {
            LogManager.AddLog(DB_PATH, 4, "Reciever.cs:ProcessRecievedGPSData:Start", GPSData);
            try
            {
                String trimedGPSData = GPSData.Trim(new char[] { '!', '$' });
                String[] GPScoords = trimedGPSData.Split(new char[] { ',', '*' });
                DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
                if (dataContext.t_Trackers.Count(p => p.IMEI == GPScoords[0]) == 0)
                {
                    t_Tracker t = new t_Tracker();
                    t.IMEI = GPScoords[0];
                    dataContext.t_Trackers.InsertOnSubmit(t);
                    dataContext.SubmitChanges();
                    OnTrackerAddded.Invoke(null, null);
                }
                string yy = GPScoords[3].Substring(4, 2);
                string mm = GPScoords[3].Substring(2, 2);
                string dd = GPScoords[3].Substring(0, 2);
                if (yy != "00" && mm != "00" && dd != "00") //Only save sensefull data
                {
                    DataService.t_GPS_IN new_position = new DataService.t_GPS_IN();
                    new_position.IMEI = GPScoords[0];
                    new_position.Status = Int32.Parse(GPScoords[1]);
                    new_position.GPS_fix = Int32.Parse(GPScoords[2]);
                    new_position.TimestampTracker = new DateTime(
                                            Int32.Parse("20" + yy),
                                            Int32.Parse(mm),
                                            Int32.Parse(dd),
                                            Int32.Parse(GPScoords[4].Substring(0, 2)),
                                            Int32.Parse(GPScoords[4].Substring(2, 2)),
                                            Int32.Parse(GPScoords[4].Substring(4, 2)));
                    new_position.longitude = GPScoords[5];
                    new_position.latitude = GPScoords[6];
                    new_position.altitude = GPScoords[7];
                    new_position.speed = GPScoords[8];
                    new_position.heading = GPScoords[9];
                    new_position.nr_used_sat = Int32.Parse(GPScoords[10]);
                    new_position.HDOP = GPScoords[11];
                    new_position.Timestamp = DateTime.Now;
                    new_position.Processed = false;

                    dataContext.t_GPS_INs.InsertOnSubmit(new_position);
                    dataContext.SubmitChanges();
                }
            }
            catch
            {
                LogManager.AddLog(DB_PATH, 0, "Reciever.cs:ProcessRecievedGPSData:Error", GPSData);
            }
        }

        /// <summary>
        /// Start the Thread for listening for Clients
        /// For every Client a ne Thread is started
        /// </summary>
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (running)
            {
                try
                {
                    LogManager.AddLog(DB_PATH, 4, "Reciever.cs:ListenForClients", "Waiting for Clients");
                    //blocks until a client has connected to the server
                    TcpClient client = this.tcpListener.AcceptTcpClient();
                    LogManager.AddLog(DB_PATH, 4, "Reciever.cs:ListenForClients", "Client Connected");

                    //create a thread to handle communication
                    //with connected client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    ThreadList.Add(clientThread);
                    clientThread.Start(client);
                    LogManager.AddLog(DB_PATH, 4, "Reciever.cs:ListenForClients", "Client Thread Started");
                }
                catch
                {
                    LogManager.AddLog(DB_PATH, 0, "Reciever.cs:ListenForClients", "Error while Client is connecting");
                }
            }
        }

        /// <summary>
        /// Handels when an new Client Connected, in an new Thread
        /// </summary>
        /// <param name="client"></param>
        private void HandleClientComm(object client)
        {
            try
            {
                LogManager.AddLog(DB_PATH, 4, "Reciever.cs:HandleClientComm", "GetClientStream");

                TcpClient tcpClient = (TcpClient)client;
                NetworkStream clientStream = tcpClient.GetStream();

                byte[] message = new byte[4096];
                int bytesRead;

                while (true)
                {
                    bytesRead = 0;

                    try
                    {
                        //blocks until a client sends a message
                        bytesRead = clientStream.Read(message, 0, 4096);
                    }
                    catch
                    {
                        //a socket error has occured
                        break;
                    }

                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        break;
                    }

                    //message has successfully been received
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string messageString = encoder.GetString(message, 0, bytesRead);
                    if (this.MessageReceived != null)
                        this.MessageReceived(messageString);
                }
                tcpClient.Close();
            }
            catch
            {
                LogManager.AddLog(DB_PATH, 0, "Reciever.cs:HandleClientComm", "Error while recieving Client Stream");
            }
        }

        /// <summary>
        /// Tries to shut down each Connection and Free the connections
        /// </summary>
        public void Stop()
        {

            LogManager.AddLog(DB_PATH, 4, "Reciever.cs:Stop", "Try to Stop all client threads");
            try
            {
                this.tcpListener.Stop();
                running = false;
                listenThread.Abort();
                foreach (Thread t in ThreadList)
                {
                    try
                    {
                        t.Abort();
                    }
                    catch { }
                }
            }
            catch 
            {
                LogManager.AddLog(DB_PATH, 0, "Reciever.cs:Stop", "Error while stopping listenThreads");
            }
        }
    }
}