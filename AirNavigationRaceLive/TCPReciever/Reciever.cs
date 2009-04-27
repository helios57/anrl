using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Linq;
using DataService.LINQ_Tables;
using System.Windows.Forms;
using System.IO;
//http://www.switchonthecode.com/tutorials/csharp-tutorial-simple-threaded-tcp-server
namespace TCPReciever
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;

        public delegate void RecievedGPS(string message);
        public RecievedGPS MyDelegate;

        public bool running;
        List<Thread> ThreadList = new List<Thread>();
        DataContext db;

        public Server()
        {
            running = true;
            this.tcpListener = new TcpListener(IPAddress.Any, 5000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();

            #region Get DB - Path
                string executableName = Application.ExecutablePath;
                FileInfo executableFileInfo = new FileInfo(executableName);
                string executableDirectoryName = executableFileInfo.Directory.Parent.Parent.Parent.FullName;
                String DB_PATH = executableDirectoryName + "\\DataService\\App_Data\\Database.mdf";
            #endregion

            DataContext db = new DataContext(DB_PATH);
            this.MessageReceived += new TCPReciever.Server.MessageReceivedHandler(Message_Received_Processor);
        }

        public void Message_Received_Processor(string message)
        {
            MyDelegate = new RecievedGPS(ProcessRecievedGPSData);
            // this.invoke (MyDelegate, new string[] { message });
            MyDelegate.Invoke(message);
        }

        public void ProcessRecievedGPSData(string GPSData)
        {
            String trimedGPSData = GPSData.Trim(new char[] { '!', '$' });
            String[] GPScoords = trimedGPSData.Split(new char[] { ',', '*' });

            Table<t_GPS_IN> GPS_IN = db.GetTable<t_GPS_IN>();
            t_GPS_IN test = new t_GPS_IN();
            test.IMEI = GPScoords[1];
            test.Status =Int32.Parse(GPScoords[2]);
            test.GPS_fix =Int32.Parse(GPScoords[3]);
            test.TimestampTracker = new DateTime(
                                    Int32.Parse("20" + GPScoords[4].Substring(4, 2)),
                                    Int32.Parse(GPScoords[4].Substring(2, 2)),
                                    Int32.Parse(GPScoords[4].Substring(0, 2)),
                                    Int32.Parse(GPScoords[5].Substring(0, 2)),
                                    Int32.Parse(GPScoords[5].Substring(2, 2)),
                                    Int32.Parse(GPScoords[5].Substring(4, 2)));
            test.longitude = GPScoords[6];
            test.latitude = GPScoords[7];
            test.altitude = GPScoords[8];
            test.speed = GPScoords[9];
            test.heading = GPScoords[10];
            test.nr_used_sat = Int32.Parse(GPScoords[11]);
            test.HDOP = GPScoords[12];
            test.Timestamp = DateTime.Now;

            GPS_IN.InsertOnSubmit(test);
            db.SubmitChanges();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (running)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();

                //create a thread to handle communication
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                ThreadList.Add(clientThread);
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
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

        public void Stop()
        {
            this.tcpListener.Stop();
            running = false;
            listenThread.Abort();
            foreach (Thread t in ThreadList)
            {
                t.Abort();
            }
        }
    }
}