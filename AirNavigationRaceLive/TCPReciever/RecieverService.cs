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
    public partial class GPSReciever : ServiceBase
    {
        #region Variablen und Deklarationen
        Server GPS;
        Timer CalculateTabels;
        String DB_PATH;
        #endregion

        /// <summary>
        /// Creates a new GPS-Reciever Service Object
        /// </summary>
        public GPSReciever(String DB_Path)
        {
            this.DB_PATH = DB_Path;
            LogManager.AddLog(DB_Path, 4, "RecieverService.cs:GPSReciever", DB_Path);
            InitializeComponent();
        }
        /// <summary>
        /// Fires when a new Tracker has connected
        /// </summary>
        public event EventHandler OnTrackerAddded;

        /// <summary>
        /// Starts the GPS-Reciever Service
        /// </summary>
        public void Start()
        {
            LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:Start", "");
            OnStart();
        }

        /// <summary>
        /// The Start Event of the Server
        /// </summary>
        protected void OnStart()
        {
            LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:OnStart:Start", "");
            GPS = new Server(DB_PATH);
            GPS.OnTrackerAddded += new EventHandler(GPS_OnTrackerAddded);
            CalculateTabels = new Timer(1000);
            CalculateTabels.Elapsed += new ElapsedEventHandler(CalculateTabels_Elapsed);
            CalculateTabels.Start();
            LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:OnStart:Ende", "");
        }

        void GPS_OnTrackerAddded(object sender, EventArgs e)
        {
            LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:GPS_OnTrackerAddded", "");
            OnTrackerAddded.Invoke(null, null);
        }

        /// <summary>
        /// Converting the Coordinates from String wsg84 to Decimal
        /// </summary>
        /// <param name="wsg84Coords"></param>
        /// <returns></returns>
        private decimal ConvertCoordinates(string wsg84Coords)
        {
            LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:ConvertCoordinates:Start", wsg84Coords);
            try
            {
                decimal result = 0;
                string SingChar = wsg84Coords.Substring(0, 1);
                if (SingChar == "E" || SingChar == "W")
                {
                    double sign = SingChar == "E" ? 1.0 : -1.0;
                    decimal degree = decimal.Parse(wsg84Coords.Substring(1, 3));
                    degree += decimal.Parse(wsg84Coords.Substring(4, 6)) / 60;
                    degree *= (decimal)sign;
                    result = degree;
                }
                else if (SingChar == "N" || SingChar == "S")
                {
                    double sign = SingChar == "N" ? 1.0 : -1.0;
                    decimal degree = decimal.Parse(wsg84Coords.Substring(1, 2));
                    degree += decimal.Parse(wsg84Coords.Substring(3, 6)) / 60;
                    degree *= (decimal)sign;
                    result = degree;
                }
                else
                {
                    throw new Exception("Wrong Coordinate format");
                }

                LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:ConvertCoordinates:Result", result.ToString());
                return decimal.Round(result, 18);
            }
            catch 
            {
                LogManager.AddLog(DB_PATH, 0, "RecieverService.cs:ConvertCoordinates:Error", wsg84Coords);
            }
            return 0;
        }

        /// <summary>
        /// Calculate the Tables of t_Data and Insert all needed Entries
        /// Will be trigered form a 1 sec-Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CalculateTabels_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                DataService.DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
                List<t_GPS_IN> Positions = dataContext.t_GPS_INs.Where(a => !a.Processed).OrderBy(t => t.Timestamp).ToList();
                List<t_Tracker> Trackers = dataContext.t_Trackers.ToList();

                if (Positions.Count > 0)LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:CalculateTabels_Elapsed:Lists","Positions.Count=" + Positions.Count + " Trackers.count=" + Trackers.Count);

                foreach (t_Tracker tr in Trackers)
                {
                    List<t_GPS_IN> Positions_Tracker = Positions.Where(a => a.IMEI == tr.IMEI).OrderBy(a => a.Timestamp).ToList();
                    foreach (t_GPS_IN GPS_IN in Positions_Tracker)
                    {
                        t_Daten InsertData = new t_Daten();
                        InsertData.ID_Tracker = tr.ID;
                        InsertData.Timestamp = GPS_IN.Timestamp;
                        InsertData.Latitude = decimal.Round(ConvertCoordinates(GPS_IN.latitude), 16);
                        InsertData.Longitude = decimal.Round(ConvertCoordinates(GPS_IN.longitude), 16);
                        InsertData.Altitude = decimal.Round(ConvertCoordinates(GPS_IN.altitude), 16);
                        dataContext.t_Datens.InsertOnSubmit(InsertData);
                        GPS_IN.Processed = true;
                    }
                }
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                LogManager.AddLog(DB_PATH, 0, "RecieverService.cs:CalculateTabels_Elapsed:Error", ex.ToString());
            }
        }

        /// <summary>
        /// Stop The Service
        /// </summary>
        protected override void OnStop()
        {

            LogManager.AddLog(DB_PATH, 4, "RecieverService.cs:OnStop", "");
            GPS.Stop();
        }
    }
}
