using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class TrackerProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Tracker> cached = new List<Tracker>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_Tracker t in db.t_Trackers)
                {
                    cached.Add(getTracker(t));
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
            t_Tracker t_d = db.t_Trackers.Single(p => p.ID == request.RequestParameters.Tracker.ID);
            t_d.Name = request.RequestParameters.Tracker.Name;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_d.ID;
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == t_d.ID);
                cached.Add(getTracker(t_d));
            }
            db.Dispose();
        }

        private void GetAll(Root request, Root r)
        {

            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Tracker t_d in cached)
                {
                    if (!ids.Contains(t_d.ID))
                    {
                        r.ResponseParameters.TrackerList.Add(t_d);
                    }
                    else
                    {
                        ids.Remove(t_d.ID);
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
                    foreach (Tracker t_d in cached.Where(p => p.ID == request.RequestParameters.ID))
                    {
                        r.ResponseParameters.TrackerList.Add(t_d);
                    }
                }
            }
        }

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            db.t_Trackers.DeleteAllOnSubmit(db.t_Trackers.Where(p => p.ID == request.RequestParameters.ID));
            db.SubmitChanges();
            db.Dispose();

            lock (cached)
            {
                cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
            }
        }

        private Tracker getTracker(t_Tracker input)
        {
            Tracker result = new Tracker();
            result.ID = input.ID;
            result.IMEI = input.IMEI;
            result.Name = input.Name;
            return result;
        }
    }
}
