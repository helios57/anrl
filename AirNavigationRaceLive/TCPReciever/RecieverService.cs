﻿using System;
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

        /// <summary>
        /// The Start Event of the Server
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            GPS = new Server();
            CalculateTabels = new Timer(5000);
            CalculateTabels.Elapsed += new ElapsedEventHandler(CalculateTabels_Elapsed);
            CalculateTabels.Start();
        }

        /// <summary>
        /// Converting the Coordinates from String wsg84 to Decimal
        /// </summary>
        /// <param name="wsg84Coords"></param>
        /// <returns></returns>
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
            return decimal.Round(result,18);
        }

        /// <summary>
        /// Calculate the Tables of t_Data and Insert all needed Entries
        /// Will be trigered form a 5 sec-Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CalculateTabels_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataService.DatabaseEntities dataContext = new DataService.DatabaseEntities(/* GPS.DB_PATH*/);
            List<t_GPS_IN> Positions = dataContext.t_GPS_IN.Where(a => !a.Processed 
                                        ).OrderBy(t=>t.Timestamp).ToList();
            List<t_Tracker> Trackers = dataContext.t_Tracker.ToList();
            List<t_Flugzeug> Flugzeuge = dataContext.t_Flugzeug.ToList();


            foreach (t_Tracker tr in Trackers)
            {
                List<t_GPS_IN> Positions_Tracker = Positions.Where(a => a.IMEI == tr.IMEI).OrderBy(a => a.Timestamp).ToList();
                if (Positions_Tracker.Count > 0)
                {
                    t_Daten InsertData = new t_Daten();
                    InsertData.Timestamp = DateTime.Now;
                    InsertData.t_Flugzeug = Flugzeuge.Where(a => a.t_Tracker.ID == tr.ID).OrderByDescending(a => a.ID).ToArray()[0];
                    //InsertData.ID_Flugzeug = InsertData.t_Flugzeug.ID;
                    InsertData.TStart = Positions_Tracker.First().Timestamp;
                    InsertData.TEnd = Positions_Tracker.Last().Timestamp;

                    InsertData.XStart = decimal.Round(ConvertCoordinates(Positions_Tracker.First().latitude),16);
                    InsertData.XEnd = decimal.Round(ConvertCoordinates(Positions_Tracker.Last().latitude),16);
                    InsertData.YStart = decimal.Round(ConvertCoordinates(Positions_Tracker.First().longitude),16);
                    InsertData.YEnd = decimal.Round(ConvertCoordinates(Positions_Tracker.Last().longitude),16);
                    InsertData.ZStart = decimal.Round(decimal.Parse(Positions_Tracker.First().altitude),16);
                    InsertData.ZEnd = decimal.Round(decimal.Parse(Positions_Tracker.Last().altitude),16);

                    dataContext.AddTot_Daten(InsertData);
                    Positions_Tracker.First().Processed = true;
                    Positions_Tracker.Last().Processed = true;
                }

            }

            dataContext.SaveChanges();
        }

        /// <summary>
        /// Stop The Service
        /// </summary>
        protected override void OnStop()
        {
            GPS.Stop();
        }
    }
}
