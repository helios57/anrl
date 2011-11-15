using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class PenaltyProcessor : AnrlService.Server.Processors.AProcessor<t_Penalty,Penalty>
    {

        protected override Func<t_Penalty, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }
        protected override void Save(Root request, Root response)
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
                db_penalty.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;
                db.t_Penalties.InsertOnSubmit(db_penalty);
                db.SubmitChanges();
                lock (cached)
                {
                    cached.Add(getNetworkObject(db_penalty));
                }
                if (request.RequestParameters.PenaltyList.Count == 1)
                {
                    response.ResponseParameters.ID = db_penalty.ID;
                }
            }
            db.Dispose();
        }


        protected override System.Data.Linq.Table<t_Penalty> getTable(AnrlDataContext db)
        {
            return db.t_Penalties;
        }

        protected override Penalty getNetworkObject(t_Penalty input)
        {
            Penalty result = new Penalty();
            result.ID_CompetitonSet = input.ID_CompetitionSet;
            result.ID = input.ID;
            result.ID_Competition_Team = input.ID_Competition_Team;
            result.Reason = input.Reason;
            result.Points = input.Points;
            return result;
        }

        protected override t_Penalty getDBObject(Penalty input)
        {
            throw new NotImplementedException();
        }

        protected override int GetID(Penalty input)
        {
            return input.ID;
        }

        protected override int GetID(t_Penalty input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Penalty Obj)
        {
            return id_competitionSet == Obj.ID;
        }

        protected override void AddToResponseList(Root response, Penalty obj)
        {
            response.ResponseParameters.PenaltyList.Add(obj);
        }
    }
}
