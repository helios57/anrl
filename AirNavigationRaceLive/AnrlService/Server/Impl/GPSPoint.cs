using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AnrlService.Server.Impl
{
    class GPSPoint:IDImpl,IGPSPoint
    {
        private decimal _Longitude;
        private decimal _Latitude;
        private decimal _Altitude;
        internal GPSPoint(long id, decimal longitude, decimal latitude, decimal altitude)
            : base(id)
        {
            _Longitude = longitude;
            _Latitude = latitude;
            _Altitude = altitude;
        }
        #region IGPSPoint Members

        public decimal Longitude
        {
            get { return _Longitude; }
        }

        public decimal Latitude
        {
            get { return _Latitude; }
        }

        public decimal Altitude
        {
            get {return _Altitude; }
        }

        #endregion
    }
}
