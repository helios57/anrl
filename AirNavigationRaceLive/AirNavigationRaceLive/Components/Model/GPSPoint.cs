using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    public class GPSPoint: MarshalByRefObject,IGPSPoint
    {
        public GPSPoint(double iLongitude, double iLatitude, double iAltitude)
        {
            _Longitude = iLongitude;
            _Latitude = iLatitude;
            _Altitude = iAltitude;
        }
        private double _Longitude;
        private double _Latitude;
        private double _Altitude;

        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude=value; }
        }

        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        public double Altitude
        {
            get { return _Altitude; }
            set { _Altitude = value; }
        }
    }
}
