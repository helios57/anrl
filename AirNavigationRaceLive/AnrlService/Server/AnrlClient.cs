using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDBAccessors;
using AnrlService.Server.Impl;

namespace AnrlService.Server
{
    class AnrlClient:IAnrlClient
    {
        private string ConnectionString;
        AnrlDBAccessors.AnrlDBEntities db;

        public AnrlClient(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            db = new AnrlDBAccessors.AnrlDBEntities(ConnectionString);
        }

        #region IAnrlClient Members

        public List<ITracker> getTrackers()
        {
            List<ITracker> result = new List<ITracker>();
            foreach (t_Tracker tracker in db.t_Tracker)
            {
                result.Add(new Tracker(tracker));
            }
            return result;
        }

        public List<IPilot> getPilots()
        {
            List<IPilot> result = new List<IPilot>();
            foreach (t_Pilot pilot in db.t_Pilot)
            {
                result.Add(new Pilot(pilot));
            }
            return result;
        }

        public List<ITeam> getTeams()
        {
            List<ITeam> result = new List<ITeam>();
            foreach (t_Team team in db.t_Team)
            {
                result.Add(new Team(team));
            }
            return result;
        }

        public List<IRace> getRaces()
        {
            List<IRace> result = new List<IRace>();
            foreach (t_Race race in db.t_Race)
            {
                result.Add(new Race(race));
            }
            return result;
        }

        public List<IPenaltyZone> getPenaltyzones()
        {
            List<IPenaltyZone> result = new List<IPenaltyZone>();
            foreach (t_PenaltyZone penaltyZone in db.t_PenaltyZone)
            {
                result.Add(new PenaltyZone(penaltyZone));
            }
            return result;
        }

        public List<IData> getData(List<ITracker> trackers, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public long addPilot(IPilot pilot)
        {
            throw new NotImplementedException();
        }

        public long addTeam(ITeam team)
        {
            throw new NotImplementedException();
        }

        public long addRace(IRace race)
        {
            throw new NotImplementedException();
        }

        public long addPenaltyZone(IPenaltyZone penaltyzone)
        {
            throw new NotImplementedException();
        }

        public long addPicture(IPicture picture)
        {
            throw new NotImplementedException();
        }

        public bool removePilot(long id)
        {
            throw new NotImplementedException();
        }

        public bool removeTeam(long id)
        {
            throw new NotImplementedException();
        }

        public bool removeRace(long id)
        {
            throw new NotImplementedException();
        }

        public bool removePenaltyZone(long id)
        {
            throw new NotImplementedException();
        }

        public bool removePicture(long id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
