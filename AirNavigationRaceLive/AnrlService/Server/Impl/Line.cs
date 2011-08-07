using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Line: IDImpl, ILine
    {
        private IGPSPoint _PointA;
        private IGPSPoint _PointB;
        private IGPSPoint _PointOrientation;
        private LineType _LineType;
        public Line(t_Line line): base(line.ID)
        {
            _PointA = new GPSPoint(line.t_GPSPoint);
            _PointB = new GPSPoint(line.t_GPSPoint1);
            _PointOrientation = new GPSPoint(line.t_GPSPoint2);
            _LineType = (LineType) line.Type;
        }

        public IGPSPoint PointA
        {
            get { return _PointA; }
        }

        public IGPSPoint PointB
        {
            get { return _PointB; }
        }

        public IGPSPoint PointOrientation
        {
            get { return _PointOrientation; }
        }

        public LineType LineType
        {
            get { return _LineType; }
        }
    }
}
