using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    public class Line: MarshalByRefObject,ILine
    {
        private IGPSPoint _PointA;
        private IGPSPoint _PointB;
        private IGPSPoint _PointOrientation;
        private LineType _LineType;
        private long _ID;

        public IGPSPoint PointA
        {
            get { return _PointA; }
            set { _PointA = value; }
        }

        public IGPSPoint PointB
        {
            get { return _PointB; }
            set { _PointB = value; }
        }

        public IGPSPoint PointOrientation
        {
            get { return _PointOrientation; }
            set { _PointOrientation = value; }
        }

        public LineType LineType
        {
            get { return _LineType; }
            set { _LineType = value; }
        }

        public long ID
        {
            get { return _ID; }
            set {_ID  = value; }
        }
    }
}
