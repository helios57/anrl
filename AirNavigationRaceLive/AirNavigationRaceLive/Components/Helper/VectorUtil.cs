using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Components.Helper
{
    public static class VectorUtil
    {
        public static Vector getSchnittpunkt(Vector LineA_A, Vector LineA_B, Vector LineB_A, Vector LineB_B)
        {
            try
            {
                Vector va = getVector(LineA_A, LineA_B);
                Vector vb = getVector(LineB_A, LineB_B);
                double lambda = (LineA_A.Y * vb.X - LineB_A.Y * vb.X - LineA_A.X * vb.Y + LineB_A.X * vb.Y) / (va.Y * vb.X - va.X * vb.Y);
                return getAddedVector(LineA_A, getMultipliedVector(va, lambda));
            }
            catch { }
            return null;
        }
        public static Vector getLot(Vector Start, Vector End, Vector Point)
        {
            Vector StartEnd = getVector(Start, End);
            double lambda = (StartEnd.X * Point.X - StartEnd.X*Start.X + StartEnd.Y * Point.Y - StartEnd.Y*Start.Y + StartEnd.Z * Point.Z - StartEnd.Z*Start.Z)/
                (StartEnd.X*StartEnd.X+StartEnd.Y*StartEnd.Y+StartEnd.Z*StartEnd.Z);
            //only on the vector, not the whole line
            lambda = Math.Min(lambda, 1);
            lambda = Math.Max(lambda, 0);
            Vector SchnittPunkt = new Vector(Start.X + lambda * StartEnd.X, Start.Y + lambda * StartEnd.Y, Start.Z + lambda * StartEnd.Z);
            Vector lot = getVector(SchnittPunkt, Point);
            return lot;
        }
        public static Vector getVector(Vector startPoint, Vector endPoint)
        {
            return new Vector(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y, endPoint.Z- startPoint.Z);
        }
        public static double getDistance(Vector Vec)
        {
            return Math.Sqrt(Vec.X * Vec.X + Vec.Y * Vec.Y + Vec.Z * Vec.Z);
        }
        public static Vector getMultipliedVector(Vector v, double skalar)
        {
            return new Vector(v.X * skalar, v.Y * skalar, v.Z * skalar);
        }
        public static Vector getAddedVector(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        /// <summary>
        /// returns the Ortsvektor of the middle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector getMiddle(Vector a, Vector b)
        {
            return new Vector(a.X + (b.X - a.X) / 2, a.Y + (b.Y - a.Y) / 2, a.Z + (b.Z - a.Z) / 2);
        }
        /// <summary>
        /// Only works for 2D (z=0)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector getOrthogonal(Vector a)
        {
            return new Vector(1, (-a.X)/a.Y, 0);
        }
    }
}
