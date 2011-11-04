using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class CompetitionSetProcesor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<CompetitionSet> cached = new List<CompetitionSet>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_CompetitionSet t in db.t_CompetitionSets)
                {
                    cached.Add(getCompetitionSet(t));
                }
            }
            db.Dispose();
        }

        public override Root proccess(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.GetAll:
                    {
                        GetAll(request, r);
                        break;
                    }
                case ERequestType.Save:
                    {
                        Save(request, r);
                        break;
                    }
            }
            return r;
        }

        private void Save(Root request, Root r)
        {
            AnrlDataContext db = getDB();
            t_CompetitionSet t_d = new t_CompetitionSet();
            t_d.Name = request.RequestParameters.CompetitionSet.Name;
            t_d.PublicRole = request.RequestParameters.CompetitionSet.PublicRole;
            t_d.ID_Owner = request.AuthInfo.ID_User;
            db.t_CompetitionSets.InsertOnSubmit(t_d);
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_d.ID;
            lock (cached)
            {
                cached.Add(getCompetitionSet(t_d));
            }
            db.Dispose();
        }

        private void GetAll(Root request, Root r)
        {
            lock (cached)
            {
                r.ResponseParameters.CompetitionSetList.AddRange(cached);
            }
        }


        private CompetitionSet getCompetitionSet(t_CompetitionSet input)
        {
            CompetitionSet result = new CompetitionSet();
            result.ID = input.ID;
            result.Name = input.Name;
            result.Owner = input.t_User.Name;
            result.PublicRole = input.PublicRole;
            return result;
        }
    }
}
