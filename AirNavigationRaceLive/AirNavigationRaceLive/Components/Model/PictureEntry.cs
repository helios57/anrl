using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    class PictureEntry : MarshalByRefObject, IPicture
    {
        long _ID;
        byte[] _Image;

        public PictureEntry(long iID, byte[] iImage)
        {
            _ID = iID;
            _Image = iImage;
        }
        public byte[] Image
        {
            get { return _Image; }
        }
        public long ID
        {
            get { return _ID; }
        }

        #region IPicture Members


        public string Name
        {
            get { return ""; }
        }

        #endregion
    }
}
