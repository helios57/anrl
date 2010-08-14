using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AnrlService.Server
{
    class AnrlClient:IAnrlClient
    {
        #region IAnrlClient Members

        public List<ITracker> getTrackers()
        {
            AnrlDBAccessors.AnrlDBEntities db = new AnrlDBAccessors.AnrlDBEntities();
            throw new NotImplementedException();
        }

        public List<IPilot> getPilots()
        {
            throw new NotImplementedException();
        }

        public List<ITeam> getTeams()
        {
            throw new NotImplementedException();
        }

        public List<IRace> getRaces()
        {
            throw new NotImplementedException();
        }

        public List<IPenaltyZone> getPenaltyzones()
        {
            throw new NotImplementedException();
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
