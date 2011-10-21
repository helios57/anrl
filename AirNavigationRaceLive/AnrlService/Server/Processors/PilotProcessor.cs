using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PilotProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Pilot> cached = new List<Pilot>();

        protected override void reloadCacheThreated()
        {
            lock (cached)
            {
                cached.Clear();
                AnrlDataContext db = getDB();
                foreach (t_Pilot p in db.t_Pilots)
                {
                    cached.Add(getPilot(p));
                }
                db.Dispose();
            }
        }

        public override Root proccess(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        Delete(request);
                        break;
                    }
                case ERequestType.Get:
                    {
                        Get(request, r);
                        break;
                    }
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
            t_Pilot p_d;
            if (db.t_Pilots.Count(p => p.ID == request.RequestParameters.Pilot.ID) == 1)
            {
                p_d = db.t_Pilots.Single(p => p.ID == request.RequestParameters.Pilot.ID);
            }
            else
            {
                p_d = new t_Pilot();
                db.t_Pilots.InsertOnSubmit(p_d);
            }
            if (request.RequestParameters.Pilot.ID_Picture == 0)
            {
                p_d.ID_Picture = null;
            }
            else
            {
                p_d.ID_Picture = request.RequestParameters.Pilot.ID_Picture;
            }
            p_d.SureName = request.RequestParameters.Pilot.Surename;
            p_d.LastName = request.RequestParameters.Pilot.Name;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = p_d.ID;
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == p_d.ID);
                cached.Add(getPilot(p_d));
            }
            db.Dispose();
        }

        private void GetAll(Root request, Root r)
        {
            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Pilot p_d in cached)
                {
                    if (!ids.Contains(p_d.ID))
                    {
                        r.ResponseParameters.PilotList.Add(p_d);
                    }
                    else
                    {
                        ids.Remove(p_d.ID);
                    }
                }
            }
            r.ResponseParameters.DeletedIDList.AddRange(ids);
        }

        private void Get(Root request, Root r)
        {
            if (request.RequestParameters != null && request.RequestParameters.ID != 0)
            {
                lock (cached)
                {
                    foreach (Pilot p_d in cached.Where(p => p.ID == request.RequestParameters.ID))
                    {
                        r.ResponseParameters.PilotList.Add(p_d);
                    }
                }
            }
        }

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            if (db.t_Pilots.Count(p => p.ID == request.RequestParameters.ID) == 1)
            {
                t_Pilot p_d;
                p_d = db.t_Pilots.Single(p => p.ID == request.RequestParameters.ID);
                db.t_Pilots.DeleteOnSubmit(p_d);
                db.SubmitChanges();
            }
            db.Dispose();
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
            }
        }

        private Pilot getPilot(t_Pilot input)
        {
            Pilot result = new Pilot();
            result.ID = input.ID;
            result.ID_Picture = input.ID_Picture.HasValue ? input.ID_Picture.Value : -1;
            result.Name = input.LastName;
            result.Surename = input.SureName;
            return result;
        }
    }
}
