using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class MapProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Map> cached = new List<Map>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_Map m in db.t_Maps)
                {
                    cached.Add(getMap(m));
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

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            db.t_Maps.DeleteOnSubmit(db.t_Maps.Single(p => p.ID == request.RequestParameters.ID));
            db.SubmitChanges();
            db.Dispose();

            lock (cached)
            {
                cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
            }
        }

        private void Save(Root request, Root r)
        {
            AnrlDataContext db = getDB();
            t_Map dbMap = getMap(request.RequestParameters.Map);
            db.t_Maps.InsertOnSubmit(dbMap);
            db.SubmitChanges();
            lock (cached)
            {
                cached.Add(getMap(dbMap));
                r.ResponseParameters = new ResponseParameters();
                r.ResponseParameters.ID = dbMap.ID;
            }
            db.Dispose();
        }

        private void GetAll(Root request, Root r)
        {
            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Map dbMap in cached)
                {
                    if (!ids.Contains(dbMap.ID))
                    {
                        r.ResponseParameters.MapList.Add(dbMap);
                    }
                    else
                    {
                        ids.Remove(dbMap.ID);
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
                    foreach (Map dbMap in cached.Where(p => p.ID == request.RequestParameters.ID))
                    {
                        r.ResponseParameters.MapList.Add(dbMap);
                    }
                }
            }
        }


        private Map getMap(t_Map input)
        {
            Map result = new Map();
            result.ID = input.ID;
            result.ID_Picture = input.ID_Picture;
            result.Name = input.Name;
            result.XRot = input.XRot;
            result.XSize = input.XSize;
            result.XTopLeft = input.XTopLeft;
            result.YRot = input.YRot;
            result.YSize = input.YSize;
            result.YTopLeft = input.YTopLeft;
            return result;
        }

        private t_Map getMap(Map input)
        {
            t_Map result = new t_Map();
            result.ID_Picture = input.ID_Picture;
            result.Name = input.Name;
            result.XRot = input.XRot;
            result.XSize = input.XSize;
            result.XTopLeft = input.XTopLeft;
            result.YRot = input.YRot;
            result.YSize = input.YSize;
            result.YTopLeft = input.YTopLeft;
            return result;
        }
    }
}
