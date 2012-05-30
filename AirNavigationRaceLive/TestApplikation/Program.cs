using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AnrlDB;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using ProtoBuf;
using System.Threading;
using System.ServiceModel;

namespace TestApplikation
{
    class Program
    {
        static void Main(string[] args)
        {
          
            double Latitude = ConvertCoordinates("N4753.0418");
            double Longitude = ConvertCoordinates("E00820.8429");
            double Altitude = double.Parse("1015.4");

           // Type serviceType = typeof(LiveInputService.LiveInputServiceImpl);
           // ServiceHost host = new ServiceHost(serviceType,new Uri[]{new Uri("gps")});
            //host.Open();
           // AnrlService.AnrlServiceImpl service = new AnrlService.AnrlServiceImpl();
           // service.start();
           Thread.Sleep(Int32.MaxValue);
            /*int PORT = 1337;
            TcpListener server;
            server = new TcpListener(IPAddress.Any, PORT);
            server.Start();
            server.BeginAcceptTcpClient(ClientConnected, server);
            Thread.Sleep(Int32.MaxValue);
            /*
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            db.DatabaseExists();
            db.CreateDatabase();*/

            /*
            string path = @"C:\Users\Helios6x\Downloads\flags_style1_medium";
            DirectoryInfo dir = new DirectoryInfo(path);
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            foreach (FileInfo fi in dir.GetFiles().Where(p=>p.Extension==".png"))
            {
                Image i = Image.FromFile(fi.FullName);
                t_Picture pic = new t_Picture();
                pic.Name = fi.Name.Replace(fi.Extension,"").Trim();
                pic.isFlag = true;
                
                MemoryStream ms = new MemoryStream();
                i.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                pic.Data = ms.ToArray();
                db.t_Pictures.InsertOnSubmit(pic);
            }
            db.SubmitChanges();*/
        }

        /// <summary>
        /// Converting the Coordinates from String wsg84 to Decimal
        /// </summary>
        /// <param name="wsg84Coords"></param>
        /// <returns></returns>
        private static double ConvertCoordinates(string wsg84Coords)
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
                }
                return result;
            }
            catch (Exception ex)
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
        private void CalculateTabels_Elapsed(object sender)
        {
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            try
            {
                List<t_GPS_IN> Positions = db.t_GPS_INs.Where(a => !a.Processed).OrderBy(t => t.TimestampTracker).ToList();
                List<t_Tracker> Trackers = db.t_Trackers.ToList();

                foreach (t_Tracker tr in Trackers)
                {
                    try
                    {
                        List<t_GPS_IN> Positions_Tracker = Positions.Where(a => a.IMEI.Trim() == tr.IMEI.Trim()).OrderBy(a => a.TimestampTracker).ToList();
                        foreach (t_GPS_IN GPS_IN in Positions_Tracker)
                        {
                            try
                            {
                                t_Daten InsertData = new t_Daten();
                                InsertData.t_Tracker = tr;
                                InsertData.Timestamp = GPS_IN.TimestampTracker.Ticks;
                                InsertData.Latitude = ConvertCoordinates(GPS_IN.latitude);
                                InsertData.Longitude = ConvertCoordinates(GPS_IN.longitude);
                                InsertData.Altitude = double.Parse(GPS_IN.altitude);
                                db.t_Datens.InsertOnSubmit(InsertData);
                            }
                            catch (Exception ex)
                            {
                            }
                            GPS_IN.Processed = true;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                db.Dispose();
            }
        }

        /*static void ClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                using (TcpClient client = server.EndAcceptTcpClient(result))
                {
                    server.BeginAcceptTcpClient(ClientConnected, server);
                    using (NetworkStream stream = client.GetStream())
                    {
                        RootMessage reqest = Serializer.DeserializeWithLengthPrefix<RootMessage>(stream, PrefixStyle.Fixed32BigEndian);
                        RootMessage response = new RootMessage();
                        response.response = new Response();
                        response.response.countAdded = 99;
                        Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Fixed32BigEndian);
                        stream.Close();
                        client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("Unable to recieve Connection " + ex.ToString());
            }
        }*/
    }
}
