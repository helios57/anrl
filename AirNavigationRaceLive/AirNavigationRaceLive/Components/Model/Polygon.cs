using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    public class Polygon: MarshalByRefObject,IPolygon
    {
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
    }
}
