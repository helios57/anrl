using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PictureProcessor : AnrlService.Server.Processors.AProcessor<t_Picture,Picture>
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

            lock (cached)
            {
                cached.Add(getNetworkObject(pp));
            }
            r.ResponseParameters.ID = pp.ID;
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
    }
}
