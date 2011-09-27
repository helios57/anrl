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
        public static Point Point(Point p)
        {
            Point result = new Point();
            result.altitude = p.altitude;
            result.ID = p.ID;
            result.latitude = p.latitude;
            result.longitude = p.longitude;
            return result;
        }
        public static Line Line(Line l)
        {
            Line result = new Line();
            result.A = Point(l.A);
            result.B = Point(l.B);
            result.O = Point(l.O);
            result.ID = l.ID;
            result.Type = l.Type;
            return result;
        }
    }
}
