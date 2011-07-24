using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Components.Helper
{
    public static class VectorUtil
    {
        public static double getDistance(Vector Start, Vector End, Vector Point)
        {
            Vector StartEnd = getVector(Start, End);
            double lambda = (StartEnd.X * Point.X - StartEnd.X*Start.X + StartEnd.Y * Point.Y - StartEnd.Y*Start.Y + StartEnd.Z * Point.Z - StartEnd.Z*Start.Z)/
                (StartEnd.X*StartEnd.X+StartEnd.Y*StartEnd.Y+StartEnd.Z*StartEnd.Z);
            //only on the vector, not the whole line
            lambda = Math.Min(lambda, 1);
            lambda = Math.Max(lambda, 0);
            Vector SchnittPunkt = new Vector(Start.X + lambda * StartEnd.X, Start.Y + lambda * StartEnd.Y, Start.Z + lambda * StartEnd.Z);
            Vector distVect = getVector(SchnittPunkt, Point);
            double dist = getDistance(distVect);
            return dist;
        }
        public static Vector getVector(Vector startPoint, Vector endPoint)
        {
            return new Vector(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y, endPoint.Z- startPoint.Z);
        }
        public static double getDistance(Vector Vec)
        {
            return Math.Sqrt(Vec.X * Vec.X + Vec.Y * Vec.Y + Vec.Z * Vec.Z);
        }
    }
}
