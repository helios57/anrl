using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class GPSPoint:IDImpl,IGPSPoint
    {
        private double _Longitude;
        private double _Latitude;
        private double _Altitude;
        internal GPSPoint(t_GPSPoint point)
            : base(point.ID)
        {
            _Longitude = point.longitude;
            _Latitude = point.latitude;
            _Altitude = point.altitude;
        }
        internal GPSPoint(long id, double longitude, double latitude, double altitude)
            : base(id)
        {
            _Longitude = longitude;
            _Latitude = latitude;
            _Altitude = altitude;
        }
        #region IGPSPoint Members

        public double Longitude
        {
            get { return _Longitude; }
        }

        public double Latitude
        {
            get { return _Latitude; }
        }

        public double Altitude
        {
            get {return _Altitude; }
        }

        #endregion
    }
}
