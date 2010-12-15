using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class Race:IDImpl,IRace
    {
        private List<ITeam> _Teams;
        private String _Name;
        private DateTime _TakeOff;
        private DateTime _Start;
        private DateTime _End;
        private IPenaltyZone _PenaltyZone;

        internal Race(t_Race race)
            : base(race.ID)
        {
            _Teams = new List<ITeam>();
            foreach (t_Race_Team raceTeam in race.t_Race_Teams)
            {
                _Teams.Add(new Team(raceTeam.t_Team));
            }
            _TakeOff = race.TakeOff;
            _Start = race.TimeStart;
            _End = race.TimeEnd;
            _PenaltyZone = new PenaltyZone(race.t_PenaltyZone);
            _Name = race.Name;
        }
        #region IRace Members

        public List<ITeam> Teams
        {
            get {return _Teams; }
        }

        public DateTime TakeOff
        {
            get { return _TakeOff; }
        }

        public DateTime Start
        {
            get {return _Start; }
        }

        public DateTime End
        {
            get { return _End; }
        }

        public IPenaltyZone PenaltyZone
        {
            get { return _PenaltyZone; }
        }

        public string Name
        {
            get { return _Name; }
        }

        #endregion
    }
}
