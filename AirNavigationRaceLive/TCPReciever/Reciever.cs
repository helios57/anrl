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
        public String DB_PATH;

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
                DB_PATH = executableDirectoryName + "\\DataService\\App_Data\\Database.mdf";
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
           // try
           // {
                String trimedGPSData = GPSData.Trim(new char[] { '!', '$' });
                String[] GPScoords = trimedGPSData.Split(new char[] { ',', '*' });

                //DataContext db = new DataContext(DB_PATH);

                DataService.t_GPS_IN new_position = new DataService.t_GPS_IN();
                new_position.IMEI = GPScoords[0];
                new_position.Status = Int32.Parse(GPScoords[1]);
                new_position.GPS_fix = Int32.Parse(GPScoords[2]);
                string yy = GPScoords[3].Substring(4, 2);
                string mm = GPScoords[3].Substring(2, 2);
                string dd = GPScoords[3].Substring(0, 2);
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


                DataService.DBModelDataContext dataContext = new DataService.DBModelDataContext(DB_PATH);
                dataContext.t_GPS_INs.InsertOnSubmit(new_position);
                dataContext.SubmitChanges();
         //   }
          //  catch
          //  {
                //Write some log ?
          //  }

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