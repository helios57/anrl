using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AirNavigationRaceLive.Components.Model
{
    class PilotEntry : MarshalByRefObject, IPilot
    {
        string _Name;
        string _Surename;
        IPicture _Picture;
        long _ID;
        public PilotEntry(long iID, string iName, string iSureName, IPicture iPicture)
        {
            _ID = iID;
            _Name = iName;
            _Surename = iSureName;
            _Picture = iPicture;
        }

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

        public long ID
        {
            get { return _ID; }
        }
    }
}
