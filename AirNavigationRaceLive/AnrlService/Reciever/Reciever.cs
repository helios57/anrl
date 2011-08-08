using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Timers;
using AnrlDB;

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
        private bool running;
        private List<Thread> ThreadList = new List<Thread>();
        private System.Timers.Timer CalculateTabels;
        private AnrlDB.AnrlDataContext db;
        
        #endregion
        /// <summary>
        /// Create an new Instance of the TCP-Listener on Port 5000
        /// </summary>
        internal Server()
        {
            try
            {
                db = new AnrlDB.AnrlDataContext(); 
                if (!db.DatabaseExists())
                {
                    db.CreateDatabase();
                }
                
                CalculateTabels = new System.Timers.Timer(1000);
                CalculateTabels.Elapsed += new ElapsedEventHandler(CalculateTabels_Elapsed);
                CalculateTabels.Start();

                running = true;
                this.tcpListener = new TcpListener(IPAddress.Any, 5000);
                this.listenThread = new Thread(new ThreadStart(ListenForClients));
                this.listenThread.Start();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Handels recieved Messages
        /// </summary>
        /// <param name="message">The Message recieved from TCP</param>
        private void Message_Received_Processor(string message)
        {
            Thread t = new Thread(new ParameterizedThreadStart(ProcessRecievedGPSData));
            t.Start(message);
        }
        /// <summary>
        /// Handels the Data recieved and processed in the Message_Received_Processor
        /// Adds the Data to the Database
        /// For Threat-Security
        /// </summary>
        /// <param name="GPSData">THe Data</param>
        private void ProcessRecievedGPSData(object GPSData)
        {
            String incomingData = GPSData as String;
            if (incomingData != null)
            {
                try
                {
                    String trimedGPSData = incomingData.Trim(new char[] { '!', '$' });
                    String[] GPScoords = trimedGPSData.Split(new char[] { ',', '*' });

                    if (db.t_Trackers.Count(p => p.IMEI == GPScoords[0]) == 0)
                    {
                        t_Tracker t = new t_Tracker();
                        t.IMEI = GPScoords[0];
                        db.t_Trackers.InsertOnSubmit(t);
                        db.SubmitChanges();
                    }
                    string yy = GPScoords[3].Substring(4, 2);
                    string mm = GPScoords[3].Substring(2, 2);
                    string dd = GPScoords[3].Substring(0, 2);
                    if (yy != "00" && mm != "00" && dd != "00") //Only save sensefull data
                    {
                        t_GPS_IN new_position = new t_GPS_IN();
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

                        db.t_GPS_INs.InsertOnSubmit(new_position);
                        db.SubmitChanges();
                    }
                }
                catch
                {
                }
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
                    //blocks until a client has connected to the server
                    TcpClient client = this.tcpListener.AcceptTcpClient();

                    //create a thread to handle communication
                    //with connected client
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    ThreadList.Add(clientThread);
                    clientThread.Start(client);
                }
                catch
                {
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
                    Message_Received_Processor(messageString);
                }
                tcpClient.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Tries to shut down each Connection and Free the connections
        /// </summary>
        public void Stop()
        {
            try
            {
                running = false;
                this.tcpListener.Stop();
                this.CalculateTabels.Stop();
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
            }
        }

        /// <summary>
        /// Converting the Coordinates from String wsg84 to Decimal
        /// </summary>
        /// <param name="wsg84Coords"></param>
        /// <returns></returns>
        private double ConvertCoordinates(string wsg84Coords)
        {
            try
            {
                double result = 0;
                string SingChar = wsg84Coords.Substring(0, 1);
                if (SingChar == "E" || SingChar == "W")
                {
                    double sign = SingChar == "E" ? 1.0 : -1.0;
                    double degree = double.Parse(wsg84Coords.Substring(1, 3));
                    degree += double.Parse(wsg84Coords.Substring(4, 6)) / 60;
                    degree *= (double)sign;
                    result = degree;
                }
                else if (SingChar == "N" || SingChar == "S")
                {
                    double sign = SingChar == "N" ? 1.0 : -1.0;
                    double degree = double.Parse(wsg84Coords.Substring(1, 2));
                    degree += double.Parse(wsg84Coords.Substring(3, 6)) / 60;
                    degree *= (double)sign;
                    result = degree;
                }
                else
                {
                    throw new Exception("Wrong Coordinate format");
                }
                return result;
            }
            catch
            {
            }
            return 0;
        }



        /// <summary>
        /// Calculate the Tables of t_Data and Insert all needed Entries
        /// Will be trigered form a 1 sec-Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateTabels_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                List<t_GPS_IN> Positions = db.t_GPS_INs.Where(a => !a.Processed).OrderBy(t => t.TimestampTracker).ToList();
                List<t_Tracker> Trackers = db.t_Trackers.ToList();

                foreach (t_Tracker tr in Trackers)
                {
                    try
                    {
                        List<t_GPS_IN> Positions_Tracker = Positions.Where(a => a.IMEI == tr.IMEI).OrderBy(a => a.TimestampTracker).ToList();
                        foreach (t_GPS_IN GPS_IN in Positions_Tracker)
                        {
                            try
                            {
                                t_Daten InsertData = new t_Daten();
                                InsertData.t_Tracker = tr;
                                InsertData.Timestamp = GPS_IN.TimestampTracker;
                                InsertData.Latitude = ConvertCoordinates(GPS_IN.latitude);
                                InsertData.Longitude = ConvertCoordinates(GPS_IN.longitude);
                                InsertData.Altitude = double.Parse(GPS_IN.altitude);
                                db.t_Datens.InsertOnSubmit(InsertData);
                                GPS_IN.Processed = true;
                            }
                            catch { }
                        }
                    }
                    catch
                    {
                    }
                }
                db.SubmitChanges();
            }
            catch
            {
            }
        }

    }
}