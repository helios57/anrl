using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDBAccessors;

namespace AnrlService.Server.Impl
{
    class Pilot:IDImpl,IPilot
    {
        private String _Name;
        private String _Surename;
        private IPicture _Picture;

        internal Pilot(t_Pilot pilot):base(pilot.ID)
        {
            _Name = pilot.LastName;
            _Surename =pilot.SureName;
            _Picture = new Picture(pilot.t_Picture);
        }
        #region IPilot Members

        public string Name
        {
            get { return _Name; }
        }

        public string Surename
        {
            get { return _Surename; }
        }

        public IPicture Picture
        {
            get { return _Picture; }
        }

        #endregion
    }
}
