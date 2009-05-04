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
    partial class GPSReciever : ServiceBase
    {
        Server GPS;
        Timer CalculateTabels;
        public GPSReciever()
        {
            InitializeComponent();
        }

        public void Start()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            GPS = new Server();
            CalculateTabels = new Timer(10000);
            CalculateTabels.Elapsed += new ElapsedEventHandler(CalculateTabels_Elapsed);
            CalculateTabels.Start();
        }

        void CalculateTabels_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataService.DBModelDataContext dataContext = new DataService.DBModelDataContext(GPS.DB_PATH);
            t_GPS_IN[] Positions = dataContext.t_GPS_INs.Where(a=> a.Timestamp < DateTime.Now && a.Timestamp.AddSeconds(20)> DateTime.Now).ToArray();
                /*new_position.IMEI = GPScoords[0];
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


                dataContext.t_GPS_INs.InsertOnSubmit(new_position);
                dataContext.SubmitChanges();*/
        }

        protected override void OnStop()
        {
            GPS.Stop();
        }
    }
}
