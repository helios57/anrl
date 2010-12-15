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
        private System.Drawing.Image _Picture;
        internal Picture(t_Picture picture):base(picture.ID)
        {
            MemoryStream ms = new MemoryStream(picture.Data.ToArray());
            _Picture = System.Drawing.Image.FromStream(ms);
            ms.Close();
        }
        #region IPicture Members

        public System.Drawing.Image Image
        {
            get { return _Picture; }
        }

        #endregion
    }
}
