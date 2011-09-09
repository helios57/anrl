using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkObjects
{
    public static class Helper
    {
        public static Point Point(double longitude, double latitude, double altitude)
        {
            Point p = new Point();
            p.longitude = longitude;
            p.latitude = latitude;
            p.altitude = altitude;
            return p;
        }
    }
}
