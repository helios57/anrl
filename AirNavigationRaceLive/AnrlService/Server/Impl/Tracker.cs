using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Tracker:IDImpl,ITracker
    {
        private String _Name;
        private String _IMEI;

        internal Tracker(t_Tracker tracker):base(tracker.ID)
        {
            _Name = tracker.Name.Trim();
            _IMEI = tracker.IMEI.Trim();
        }

        #region ITracker Members

        public string Name
        {
            get { return _Name; }
        }

        public string IMEI
        {
            get { return _IMEI; }
        }

        #endregion
    }
}
