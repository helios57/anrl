using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PilotProcessor : AnrlService.Server.Processors.AProcessor<t_Pilot,Pilot>
    {

        protected override Func<t_Pilot, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }
        protected override void Save(Root request, Root r)
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
            p_d.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = p_d.ID;
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == p_d.ID);
                cached.Add(getNetworkObject(p_d));
            }
            db.Dispose();
            reloadCacheThreated();//Hack to avoid empty competitions
        }

      

        protected override System.Data.Linq.Table<t_Pilot> getTable(AnrlDataContext db)
        {
            return db.t_Pilots;
        }

        protected override Pilot getNetworkObject(t_Pilot input)
        {
            Pilot result = new Pilot();
            result.ID_CompetitonSet = input.ID_CompetitionSet;
            result.ID = input.ID;
            result.ID_Picture = input.ID_Picture.HasValue ? input.ID_Picture.Value : -1;
            result.Name = input.LastName;
            result.Surename = input.SureName;
            return result;
        }

        protected override t_Pilot getDBObject(Pilot input)
        {
            throw new NotImplementedException();
        }

        protected override int GetID(Pilot input)
        {
            return input.ID;
        }

        protected override int GetID(t_Pilot input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Pilot Obj)
        {
            return id_competitionSet == Obj.ID_CompetitonSet;
        }

        protected override void AddToResponseList(Root response, Pilot obj)
        {
            response.ResponseParameters.PilotList.Add(obj);
        }
    }
}
