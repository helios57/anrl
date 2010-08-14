using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDBAccessors;

namespace AnrlService.Server.Impl
{
    class Team:IDImpl,ITeam
    {
        private IPilot _Pilot;
        private IPilot _Navigator;
        private IPicture _Picture;
        private ITracker _Tracker;
        private String _Color;

        internal Team(t_Team team)
            : base(team.ID)
        {
            _Pilot = new Pilot(team.t_Pilot);
            _Navigator = new Pilot(team.t_Navigator);
            _Picture = new Picture(team.t_Picture);
            _Tracker = new Tracker(team.t_Tracker);
            _Color = team.Color;
        }

        #region ITeam Members

        public IPilot Pilot
        {
            get { return _Pilot; }
        }

        public IPilot Navigator
        {
            get {return _Navigator; }
        }

        public IPicture Picture
        {
            get { return _Picture; }
        }
        
        public ITracker Tracker
        {
            get { return _Tracker; }
        }

        public String Color
        {
            get { return _Color; }
        }

        #endregion
    }
}
