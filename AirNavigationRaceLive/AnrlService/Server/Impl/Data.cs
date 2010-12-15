using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Data:GPSPoint,IData
    {
        private DateTime _Timestamp;
        private ITracker _Tracker; 
        internal Data(t_Daten daten)
            : base(daten.ID, daten.Longitude, daten.Latitude, daten.Altitude)
        {
            _Timestamp = daten.Timestamp;
            _Tracker = new Tracker(daten.t_Tracker);
        }
        #region IData Members

        public DateTime Timestamp
        {
            get {return _Timestamp; }
        }

        public ITracker Tracker
        {
            get { return _Tracker; }
        }

        #endregion
    }
}
