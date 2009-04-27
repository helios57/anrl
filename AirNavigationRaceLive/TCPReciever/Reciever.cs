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
//http://www.switchonthecode.com/tutorials/csharp-tutorial-simple-threaded-tcp-server
namespace TCPReciever
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public delegate void MessageReceivedHandler(string message);
        public event MessageReceivedHandler MessageReceived;
        public bool running;
        private System.Data.SqlClient.SqlCommand cmd;
        List<Thread> ThreadList = new List<Thread>();
        SqlConnection SQL;

        public Server()
        {
            running = true;
            this.tcpListener = new TcpListener(IPAddress.Any, 5000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            DataContext db = new DataContext("C:\\daten\\gibb.ch\\306\\AirNavigationRaceLiveC#\\AirNavigationRaceLive\\DataService\\App_Data\\Database.mdf");
            Table<t_GPS_IN> Customers = db.GetTable<t_GPS_IN>();
            t_GPS_IN test = new t_GPS_IN();
            test.IMEI = "32R342";
            test.Status = 1;
            test.GPS_fix = 1;
            test.TimestampTracker = DateTime.Now;
            test.longitude = "longi";
            test.latitude = "Lati";
            test.altitude = "alti";
            test.speed = "speed";
            test.heading = "head";
            test.nr_used_sat = 2;
            test.HDOP = "hd";
            test.Timestamp = DateTime.Now;

            //Customers.Attach(test);
            Customers.InsertOnSubmit(test);
            db.SubmitChanges();
            Customers = db.GetTable<t_GPS_IN>();
            foreach (t_GPS_IN a in Customers)
            {
                MessageBox.Show(a.ToString());
            }
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

    /*    How to use ...    
     *  public delegate void AddText(string message);
        Server server;
        public AddText MyDelegate;
        public Form1()
        {
            InitializeComponent();
            server = new Server();
            server.MessageReceived += new TCPServerTutorial.Server.MessageReceivedHandler(Message_Received);
        }
        void Message_Received(string message)
        {
            MyDelegate = new AddText(AddTextDelegate);
            this.Invoke(MyDelegate, new string[]{message});
            //MyDelegate = new AddText(AddTextDelegate);
            //MyDelegate.Method.
            //this.Invoke(MyDelegate);
        }

        public void AddTextDelegate(string s)
        {
            String[] GPScoords= s.Split(',');
            textBox1.Text+= "\r\n";
            foreach (String ss in GPScoords){
            textBox1.Text += ss+"  ";
            }
        }
     */
}