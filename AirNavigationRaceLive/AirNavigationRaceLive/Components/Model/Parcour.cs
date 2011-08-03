using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    public class Parcour : MarshalByRefObject,IParcour
    {
        private List<ILine> _Lines = new List<ILine>();
        private List<IPolygon> _Polygons = new List<IPolygon>();
        private long _ID = 0;
        public volatile bool finished;
        public double best;

        public List<ILine> Lines
        {
            get { return _Lines; }
        }

        public List<IPolygon> Polygons
        {
            get {return _Polygons; }
        }

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
