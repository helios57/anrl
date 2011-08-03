using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Components.Helper
{
    class Utils
    {
        private static Random r = new Random();
        public static double getNextDouble()
        {
            return r.NextDouble();
        }
    }
}
