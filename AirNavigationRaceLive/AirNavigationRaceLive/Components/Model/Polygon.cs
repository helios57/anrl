using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AirNavigationRaceLive.Components.Helper;

namespace AirNavigationRaceLive.Components.Model
{
    public class Polygon: MarshalByRefObject,IPolygon
    {
        public Polygon(List<Vector> points, Vector middle)
        {

        }
        private List<long> _IDS = new List<long>();
        private long _ID;
        public List<long> IDS
        {
            get { return _IDS; }
        }
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

     /*   private bool ordered(List<Vector> list)
        {
                if (Vector.Intersect(list[i % count], list[(i + 1) % count]))

        }*/
    }
}
