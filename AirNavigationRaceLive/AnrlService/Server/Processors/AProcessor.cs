using System;
using System.Threading;
using AnrlDB;
using NetworkObjects;
using System.Collections.Generic;
using System.Linq;

namespace AnrlService.Server.Processors
{
    abstract class AProcessor<D, N> : IProcessor where D : class
    {
        protected readonly List<N> cached = new List<N>();
        public AProcessor()
        {
            reloadCache();
        }
        public void reloadCache()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(start));
        }
        private void start(object o)
        {
            reloadCacheThreated();
        }

        protected virtual void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (D p in getTable(db))
                {
                    cached.Add(getNetworkObject(p));
                }
            }
            db.Dispose();
        }

        protected abstract System.Data.Linq.Table<D> getTable(AnrlDataContext db);
        protected abstract N getNetworkObject(D input);
        protected abstract D getDBObject(N input);
        protected abstract void Save(Root request, Root r);
        protected abstract int GetID(N input);
        protected abstract int GetID(D input);
        protected abstract bool CheckCompetitionSet(int id_competitionSet, N Obj);
        protected abstract void AddToResponseList(Root response, N obj);
        protected abstract Func<D, bool> getSingleSelection(int ID);

        public virtual Root proccess(Root request)
        {
            Root response = new Root();
            response.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        Delete(request);
                        break;
                    }
                case ERequestType.Get:
                    {
                        Get(request, response);
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        GetAll(request, response);
                        break;
                    }
                case ERequestType.Save:
                    {
                        Save(request, response);
                        break;
                    }
            }
            return response;
        }

        protected virtual void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            getTable(db).DeleteOnSubmit(getTable(db).Single(getSingleSelection(request.RequestParameters.ID)));
            db.SubmitChanges();
            db.Dispose();
            lock (cached)
            {
                cached.RemoveAll(p => GetID(p) == request.RequestParameters.ID);
            }
        }

        protected virtual void GetAll(Root request, Root response)
        {
            List<int> ids = new List<int>(request.RequestParameters != null? request.RequestParameters.IDS:new List<int>());
            int competitionSet = request.AuthInfo.ID_CompetitionSet;
            lock (cached)
            {
                foreach (N obj in cached.Where(p=>CheckCompetitionSet(competitionSet,p)))
                {
                    if (!ids.Contains(GetID(obj)))
                    {
                        AddToResponseList(response,obj);
                    }
                    else
                    {
                        ids.Remove(GetID(obj));
                    }
                }
            }
            response.ResponseParameters.DeletedIDList.AddRange(ids);
        }

        protected virtual void Get(Root request, Root response)
        {
            if (request.RequestParameters != null && request.RequestParameters.ID != 0)
            {
                int competitionSet = request.AuthInfo.ID_CompetitionSet;
                lock (cached)
                {
                    foreach (N obj in cached.Where(p => GetID(p) == request.RequestParameters.ID && CheckCompetitionSet(competitionSet,p)))
                    {
                        AddToResponseList(response,obj);
                    }
                }
            }
        }

        protected AnrlDataContext getDB()
        {
            return new AnrlDataContext();
        }
    }
}
