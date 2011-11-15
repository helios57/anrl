using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class CompetitionSetProcesor : AnrlService.Server.Processors.AProcessor<t_CompetitionSet,CompetitionSet>
    {
        protected override Func<t_CompetitionSet, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }

        protected override void Save(Root request, Root r)
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
                cached.Add(getNetworkObject(t_d));
            }
            db.Dispose();
        }

        protected override System.Data.Linq.Table<t_CompetitionSet> getTable(AnrlDataContext db)
        {
            return db.t_CompetitionSets;
        }

        protected override CompetitionSet getNetworkObject(t_CompetitionSet input)
        {
            CompetitionSet result = new CompetitionSet();
            result.ID = input.ID;
            result.Name = input.Name;
            result.Owner = input.t_User.Name;
            result.PublicRole = input.PublicRole;
            return result;
        }

        protected override t_CompetitionSet getDBObject(CompetitionSet input)
        {
            throw new NotImplementedException();
        }

        protected override int GetID(CompetitionSet input)
        {
           return input.ID;
        }

        protected override int GetID(t_CompetitionSet input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, CompetitionSet Obj)
        {
            return true;
        }

        protected override void AddToResponseList(Root response, CompetitionSet obj)
        {
            response.ResponseParameters.CompetitionSetList.Add(obj);
        }
    }
}
