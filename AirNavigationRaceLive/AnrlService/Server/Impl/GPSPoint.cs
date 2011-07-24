﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AnrlService.Server.Impl
{
    class GPSPoint:IDImpl,IGPSPoint
    {
        private double _Longitude;
        private double _Latitude;
        private double _Altitude;
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
