using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PictureProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Picture> cached = new List<Picture>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_Picture p in db.t_Pictures)
                {
                    cached.Add(getPicture(p));
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
                        Save(request, r); break;
                    }
            }
            return r;
        }

        private void Save(Root request, Root r)
        {
            t_Picture pp = getPicture(request.RequestParameters.Picture);

            AnrlDataContext db = getDB();
            db.t_Pictures.InsertOnSubmit(pp);
            db.SubmitChanges();
            db.Dispose();

            lock (cached)
            {
                cached.Add(getPicture(pp));
            }
            r.ResponseParameters.ID = pp.ID;
        }

        private void GetAll(Root request, Root r)
        {
            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Picture pic in cached)
                {
                    if (!ids.Contains(pic.ID))
                    {
                        r.ResponseParameters.PictureList.Add(pic);
                    }
                    else
                    {
                        ids.Remove(pic.ID);
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
                    foreach (Picture pic in cached.Where(p => p.ID == request.RequestParameters.ID))
                    {
                        r.ResponseParameters.PictureList.Add(pic);
                    }
                }
            }
        }

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            db.t_Pictures.DeleteOnSubmit(db.t_Pictures.Single(p => p.ID == request.RequestParameters.ID));
            db.SubmitChanges();
            db.Dispose();

            lock (cached)
            {
                cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
            }
        }


        private Picture getPicture(t_Picture input)
        {
            Picture result = new Picture();
            result.ID = input.ID;
            result.Image = input.Data.ToArray();
            result.Name = input.Name;
            return result;
        }

        private t_Picture getPicture(Picture input)
        {
            t_Picture result = new t_Picture();
            result.Data = new System.Data.Linq.Binary(input.Image);
            result.Name = input.Name;
            return result;
        }
    }
}
