using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDBAccessors;

namespace AnrlService.Server.Impl
{
    class Race:IDImpl,IRace
    {
        List<ITeam> _Teams;
        DateTime _TakeOff;
        DateTime _Start;
        DateTime _End;
        IPenaltyZone _PenaltyZone;

        internal Race(t_Race race)
            : base(race.ID)
        {
            _Teams = new List<ITeam>();
            foreach (t_Race_Team raceTeam in race.t_Race_Team)
            {
                _Teams.Add(new Team(raceTeam.t_Team));
            }
            _TakeOff = race.TakeOff;
            _Start = race.TimeStart;
            _End = race.TimeEnd;
            _PenaltyZone = new PenaltyZone(race.t_PenaltyZone);
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

        #endregion
    }
}
