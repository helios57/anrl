using System;
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
        public double X = 0;
        public double Y = 0;
        public double Z = 0;
    }
}
