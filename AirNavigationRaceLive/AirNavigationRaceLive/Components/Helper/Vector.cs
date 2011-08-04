﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Components.Helper
{
    public class Vector
    {
        public Vector(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y; 
            this.Z = Z;
        }

        public Vector(Vector v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }
        public double X = 0;
        public double Y = 0;
        public double Z = 0;

        public static Vector operator / (Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }
        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }
        public static double operator *(Vector a, Vector b)
        {
            return a.X*b.X + a.Y*b.Y+a.Z*b.Z;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector Cross(Vector a, Vector b)
        {
            return new Vector(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
        }
        public static double Spat(Vector a, Vector b, Vector c)
        {
            return a.X * b.Y * c.Z + b.X * c.Y * a.Z + c.X * a.Y * b.Z - a.X * c.Y * b.Z - b.X * a.Y * c.Z - c.X * b.Y * a.Z;
        }
        public static double Abs(Vector a)
        {
            return Math.Sqrt(a.X*a.X + a.Y*a.Y+a.Z*a.Z);
        }        
        
        /// <summary>
        /// Only works for 2D (z=0)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector Orthogonal(Vector a)
        {
            return new Vector(-a.Y,  a.X, 0);
        }

        /// <summary>
        /// returns the Ortsvektor of the middle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector Middle(Vector a, Vector b)
        {
            return new Vector(a.X + (b.X - a.X) / 2, a.Y + (b.Y - a.Y) / 2, a.Z + (b.Z - a.Z) / 2);
        }

        public static Vector Direction(Vector startPoint, Vector endPoint)
        {
            return new Vector(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y, endPoint.Z - startPoint.Z);
        }

        public static Vector Interception(Vector LineA_A, Vector LineA_B, Vector LineB_A, Vector LineB_B)
        {
            try
            {
                Vector va = Vector.Direction(LineA_A, LineA_B);
                Vector vb = Vector.Direction(LineB_A, LineB_B);
                double lambda = (LineA_A.Y * vb.X - LineB_A.Y * vb.X - LineA_A.X * vb.Y + LineB_A.X * vb.Y) / (va.Y * vb.X - va.X * vb.Y);
                return LineA_A + (va * lambda);
            }
            catch { }
            return null;
        }

        public static Vector MinDistance(Vector Start, Vector End, Vector Point)
        {
            Vector StartEnd = Direction(Start, End);
            double lambda = (StartEnd.X * Point.X - StartEnd.X * Start.X + StartEnd.Y * Point.Y - StartEnd.Y * Start.Y + StartEnd.Z * Point.Z - StartEnd.Z * Start.Z) /
                (StartEnd.X * StartEnd.X + StartEnd.Y * StartEnd.Y + StartEnd.Z * StartEnd.Z);
            //only on the vector, not the whole line
            lambda = Math.Min(lambda, 1);
            lambda = Math.Max(lambda, 0);
            Vector SchnittPunkt = new Vector(Start.X + lambda * StartEnd.X, Start.Y + lambda * StartEnd.Y, Start.Z + lambda * StartEnd.Z);
            Vector lot = Direction(SchnittPunkt, Point);
            return lot;
        }

        public static Vector LotInterception(Vector Start, Vector End, Vector Point)
        {
            Vector StartEnd = Direction(Start, End);
            double lambda = (StartEnd.X * Point.X - StartEnd.X * Start.X + StartEnd.Y * Point.Y - StartEnd.Y * Start.Y + StartEnd.Z * Point.Z - StartEnd.Z * Start.Z) /
                (StartEnd.X * StartEnd.X + StartEnd.Y * StartEnd.Y + StartEnd.Z * StartEnd.Z);
            Vector SchnittPunkt = new Vector(Start.X + lambda * StartEnd.X, Start.Y + lambda * StartEnd.Y, Start.Z + lambda * StartEnd.Z);
            return SchnittPunkt;
        }
    }
}