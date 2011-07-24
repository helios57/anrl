using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    class MapImpl : MarshalByRefObject, IMap
    {
        internal String _Name;
        internal IPicture _Picture;
        internal Double _XSize;
        internal Double _YSize;
        internal Double _XRot;
        internal Double _YRot;
        internal Double _XTopLeft;
        internal Double _YTopLeft;
        internal long _ID = 0;

        public long ID
        {
            get { return _ID; }
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
