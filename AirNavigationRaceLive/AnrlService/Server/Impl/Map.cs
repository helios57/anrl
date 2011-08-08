using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Map:IDImpl,IMap
    {
        private String _Name;
        private IPicture _Picture;
        private Double _XSize;
        private Double _YSize;
        private Double _XRot;
        private Double _YRot;
        private Double _XTopLeft;
        private Double _YTopLeft;

        internal Map(t_Map map)
            : base(map.ID)
        {
            _Name = map.Name;
           /* _Picture = new Picture(map.t_Picture);
            _XSize = Decimal.ToDouble(map.XSize);
            _YSize = Decimal.ToDouble(map.YSize);
            _XRot = Decimal.ToDouble(map.XRot);
            _YRot = Decimal.ToDouble(map.YRot);
            _XTopLeft = Decimal.ToDouble(map.XTopLeft);
            _YTopLeft = Decimal.ToDouble(map.YTopLeft);*/
        }
        public string Name
        {
            get { return _Name; }
        }

        public IPicture Picture
        {
            get { return _Picture; }
        }

        public double XSize
        {
            get { return _XSize; }
        }

        public double YSize
        {
            get { return _YSize; }
        }

        public double XRot
        {
            get { return _XRot; }
        }

        public double YRot
        {
            get { return _YRot; }
        }

        public double XTopLeft
        {
            get { return _XTopLeft; }
        }

        public double YTopLeft
        {
            get { return _YTopLeft; }
        }
    }
}
