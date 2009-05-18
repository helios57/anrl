using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using DataService;

namespace TCPReciever
{
    /// <summary>
    /// Service of the GPSReciever, which wil be Installed as Systemservice (in future) 
    /// Now it will be started from the Programm.cs
    /// </summary>
    partial class GPSReciever : ServiceBase
    {
        #region Variablen und Deklarationen
        Server GPS;
        Timer CalculateTabels;
        #endregion

        /// <summary>
        /// Creates a new GPS-Reciever Service Object
        /// </summary>
        public GPSReciever()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts the GPS-Reciever Service
        /// </summary>
        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            GPS = new Server();
            CalculateTabels = new Timer(5000);
            CalculateTabels.Elapsed += new ElapsedEventHandler(CalculateTabels_Elapsed);
            CalculateTabels.Start();
        }

        private decimal ConvertCoordinates(string wsg84Coords)
        {
            decimal result = 0;
            string SingChar = wsg84Coords.Substring(0,1);
            if (SingChar =="E" || SingChar =="W")
            {
                double sign = SingChar == "E" ? 1.0 : -1.0;
                decimal degree = decimal.Parse(wsg84Coords.Substring(1, 3));
                degree += decimal.Parse(wsg84Coords.Substring(4, 6)) / 60;
                degree *= (decimal)sign;
                result = degree;
            }
            else if (SingChar =="N" || SingChar =="S")
            {
                double sign = SingChar == "N" ? 1.0 : -1.0;
                decimal degree = decimal.Parse(wsg84Coords.Substring(1, 2));
                degree += decimal.Parse(wsg84Coords.Substring(3, 6)) / 60;
                degree *= (decimal)sign;
                result = degree;
            }
            else
            {
                throw new Exception("Wrong Coordinate format") ;
            }
            return result;
        }

        void CalculateTabels_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataService.DatabaseEntities dataContext = new DataService.DatabaseEntities(GPS.DB_PATH);
            List<t_GPS_IN> Positions = dataContext.t_GPS_IN.Where(a => !a.Processed 
                                        ).OrderBy(t=>t.Timestamp).ToList();
            List<t_Tracker> Trackers = dataContext.t_Tracker.ToList();
            List<t_Flugzeug> Flugzeuge = dataContext.t_Flugzeug.ToList();

            foreach (t_Tracker tr in Trackers)
            {
                List<t_GPS_IN> Positions_Tracker = Positions.Where(a => a.IMEI == tr.IMEI).OrderBy(a=> a.Timestamp).ToList();
                t_Daten InsertData = new t_Daten();
                InsertData.Timestamp = DateTime.Now;
                InsertData.t_Flugzeug = Flugzeuge.Where(a => a.t_Tracker.ID == tr.ID).OrderByDescending(a=>a.ID).ToArray()[0];
                //InsertData.ID_Flugzeug = InsertData.t_Flugzeug.ID;
                InsertData.TStart = Positions_Tracker.First().Timestamp;
                InsertData.TEnd = Positions_Tracker.Last().Timestamp;
                
                InsertData.XStart = ConvertCoordinates(Positions_Tracker.First().latitude);
                InsertData.XEnd = ConvertCoordinates(Positions_Tracker.Last().latitude);
                InsertData.YStart = ConvertCoordinates(Positions_Tracker.First().longitude);
                InsertData.YEnd = ConvertCoordinates(Positions_Tracker.Last().longitude);
                InsertData.ZStart = ConvertCoordinates(Positions_Tracker.First().altitude);
                InsertData.ZEnd = ConvertCoordinates(Positions_Tracker.Last().altitude);

                dataContext.AddTot_Daten(InsertData);

            }
            dataContext.SaveChanges();
        }

        protected override void OnStop()
        {
            GPS.Stop();
        }
    }
}
