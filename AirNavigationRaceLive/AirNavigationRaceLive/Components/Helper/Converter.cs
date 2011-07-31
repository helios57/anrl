using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Helper
{
    public class Converter
    {
        double topleftX;
        double topleftY;
        double sizeX;
        double sizeY;
        public Converter(IMap map)
        {
            topleftX  = map.XTopLeft;
            topleftY = map.YTopLeft;
            sizeX = map.XSize;
            sizeY = map.YSize;
        }
        public double XtoDeg(double x)
        {
            return topleftX + x * sizeX;
        }
        public int DegToX(double longitude)
        {
            return (int)((longitude - topleftX) / sizeX);
        }
        public double YtoDeg(double y)
        {
            return topleftY + y * sizeY;
        }
        public int DegToY(double latitdude)
        {
            return (int)((latitdude - topleftY) / sizeY);
        }

        public int getStartX(ILine l)
        {
            return DegToX(l.PointA.Longitude);
        }
        public int getStartY(ILine l)
        {
            return DegToY(l.PointA.Latitude);
        }
        public int getEndX(ILine l)
        {
            return DegToX(l.PointB.Longitude);
        }
        public int getEndY(ILine l)
        {
            return DegToY(l.PointB.Latitude);
        }
        public int getOrientationX(ILine l)
        {
            return DegToX(l.PointOrientation.Longitude);
        }
        public int getOrientationY(ILine l)
        {
            return DegToY(l.PointOrientation.Latitude);
        }
        public static double Distance(IGPSPoint point1,IGPSPoint point2)
        {
            return Distance(point1.Longitude, point1.Latitude, point2.Longitude, point2.Latitude);
        }

        public static double Distance(double long1, double lat1, double long2, double lat2)
        {
            //The haversine formula
            //a = sin²(Δlat/2) + cos(lat1)*cos(lat2)*sin²(Δlong/2)
            //c = 2.atan2(√a, √(1−a))
            //d = R*c
            double deltaLong = DegreeToRadian(long2 - long1);
            double deltaLat = DegreeToRadian(lat2 - lat1);
            double lat1Rad = DegreeToRadian(lat1);
            double lat2Rad = DegreeToRadian(lat2);
            double a_1 = Math.Sin(deltaLat / 2);
            double a_2 = a_1 * a_1;
            double a_3 = Math.Cos(lat1Rad) * Math.Cos(lat2Rad);
            double a_4 = Math.Sin(deltaLong / 2);
            double a_5 = a_4 * a_4;
            double a = a_2 + a_3 * a_5;
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double R = 6371; //Earth Radius
            double distance = R * c;
            return distance;
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double MtoNM(double meter)
        {
            return meter/1.852;
        }
        public static double NMtoM(double nauticMiles)
        {
            return nauticMiles * 1.852;
        }
    }
}
