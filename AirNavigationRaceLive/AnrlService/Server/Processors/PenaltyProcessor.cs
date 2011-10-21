using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PenaltyProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Penalty> cached = new List<Penalty>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_Penalty p in db.t_Penalties)
                {
                    cached.Add(getPenalty(p));
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
                case ERequestType.Save:
                    {
                        Save(request,r);
                        break;
                    }
                case ERequestType.Delete:
                    {
                        Delete(request);
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        GetAll(request, r);
                        break;
                    }
            }
            return r;
        }

        private void Save(Root request,Root response)
        {
            AnrlDataContext db = getDB();
            foreach (Penalty p in request.RequestParameters.PenaltyList)
            {
                if (p.ID > 0)
                {
                    db.t_Penalties.DeleteOnSubmit(db.t_Penalties.First(pp => pp.ID == p.ID));
                }
                db.SubmitChanges();
                t_Penalty db_penalty = new t_Penalty();
                db_penalty.ID_Competition_Team = p.ID_Competition_Team;
                db_penalty.Points = p.Points;
                db_penalty.Reason = p.Reason;
                db.t_Penalties.InsertOnSubmit(db_penalty);
                db.SubmitChanges();
                lock (cached)
                {
                    cached.Add(getPenalty(db_penalty));
                }
                if (request.RequestParameters.PenaltyList.Count == 1)
                {
                    response.ResponseParameters.ID = db_penalty.ID;
                }
            }
            db.Dispose();
        }

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            if (db.t_Penalties.Count(p => p.ID == request.RequestParameters.ID) > 0)
            {
                db.t_Penalties.DeleteOnSubmit(db.t_Penalties.First(p => p.ID == request.RequestParameters.ID));
                db.SubmitChanges();
                lock (cached)
                {
                    cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
                }
            }
            db.Dispose();
        }


        private void GetAll(Root request, Root r)
        {
            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Penalty p in cached)
                {
                    if (!ids.Contains(p.ID))
                    {
                        r.ResponseParameters.PenaltyList.Add(p);
                    }
                    else
                    {
                        ids.Remove(p.ID);
                    }
                }
            }
            r.ResponseParameters.DeletedIDList.AddRange(ids);
        }

        private Penalty getPenalty(t_Penalty penalty)
        {
            Penalty result = new Penalty();
            result.ID = penalty.ID;
            result.ID_Competition_Team = penalty.ID_Competition_Team;
            result.Reason = penalty.Reason;
            result.Points = penalty.Points;
            return result;
        }
    }
}
