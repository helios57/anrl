using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using System.IO;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Picture:IDImpl,IPicture
    {
        private byte[] _Picture;
        internal Picture(t_Picture picture):base(picture.ID)
        {
            _Picture = picture.Data.ToArray();
        }
        #region IPicture Members

        public byte[] Image
        {
            get { return _Picture; }
        }

        #endregion
    }
}
