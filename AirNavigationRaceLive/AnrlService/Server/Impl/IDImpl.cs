using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AnrlService.Server.Impl
{
    class IDImpl:IID
    {
        private long _ID;
        internal IDImpl(long ID)
        {
            _ID = ID;
        }
        #region IID Members

        public long ID
        {
            get { return _ID; }
        }

        #endregion
    }
}
