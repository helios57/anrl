using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PictureProcessor : AnrlService.Server.Processors.AProcessor<t_Picture, Picture>
    {
        protected override Func<t_Picture, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }
        protected override void Save(Root request, Root r)
        {
            t_Picture pp = getDBObject(request.RequestParameters.Picture);
            pp.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;

            AnrlDataContext db = getDB();
            db.t_Pictures.InsertOnSubmit(pp);
            db.SubmitChanges();
            db.Dispose();

            r.ResponseParameters.ID = pp.ID;
        }

        protected virtual void reloadCacheThreated()
        {
            //No cache
        }

        protected override System.Data.Linq.Table<t_Picture> getTable(AnrlDataContext db)
        {
            return db.t_Pictures;
        }

        protected override Picture getNetworkObject(t_Picture input)
        {
            Picture result = new Picture();
            result.ID = input.ID;
            result.Image = input.Data.ToArray();
            result.Name = input.Name;
            result.ID_CompetitonSet = input.ID_CompetitionSet;
            return result;
        }

        protected override t_Picture getDBObject(Picture input)
        {
            t_Picture result = new t_Picture();
            result.Data = new System.Data.Linq.Binary(input.Image);
            result.Name = input.Name;
            result.ID_CompetitionSet = input.ID_CompetitonSet;
            return result;
        }

        protected override int GetID(Picture input)
        {
            return input.ID;
        }

        protected override int GetID(t_Picture input)
        {
            return input.ID;
        }

        protected override void AddToResponseList(Root response, Picture obj)
        {
            response.ResponseParameters.PictureList.Add(obj);
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Picture Obj)
        {
            return Obj.ID_CompetitonSet == id_competitionSet;
        }

        protected override void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            getTable(db).DeleteOnSubmit(getTable(db).Single(getSingleSelection(request.RequestParameters.ID)));
            db.SubmitChanges();
            db.Dispose();
        }

        protected override void GetAll(Root request, Root response)
        {
            List<int> ids = new List<int>(request.RequestParameters != null ? request.RequestParameters.IDS : new List<int>());
            using (AnrlDataContext db = getDB())
            {
                int competitionSet = request.AuthInfo.ID_CompetitionSet;
                foreach (t_Picture obj in getTable(db).Where(p => p.ID_CompetitionSet == competitionSet))
                {
                    if (!ids.Contains(GetID(obj)))
                    {
                        AddToResponseList(response, getNetworkObject(obj));
                    }
                    else
                    {
                        ids.Remove(GetID(obj));
                    }
                }
                db.Dispose();
            }
            response.ResponseParameters.DeletedIDList.AddRange(ids);
        }

        protected override void Get(Root request, Root response)
        {
            AnrlDataContext db = getDB();
            if (request.RequestParameters != null && request.RequestParameters.ID != 0)
            {
                int competitionSet = request.AuthInfo.ID_CompetitionSet;
                foreach (t_Picture obj in getTable(db).Where(p => p.ID == request.RequestParameters.ID && p.ID_CompetitionSet == competitionSet))
                {
                    AddToResponseList(response, getNetworkObject(obj));
                }
            }
            db.Dispose();
        }
    }
}
