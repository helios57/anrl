using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class TeamProcessor : AnrlService.Server.Processors.AProcessor<t_Team,Team>
    {

        protected override Func<t_Team, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }
        protected override void Save(Root request, Root r)
        {
            AnrlDataContext db = getDB();
            t_Team t_d;
            if (request.RequestParameters.Team.ID > 0)
            {
                t_d = db.t_Teams.Single(p => p.ID == request.RequestParameters.Team.ID);
                db.SubmitChanges();
            }
            else
            {
                t_d = new t_Team();
                db.t_Teams.InsertOnSubmit(t_d);
            }
            t_d.Name = request.RequestParameters.Team.Name;

            if (request.RequestParameters.Team.ID_Flag == 0)
            {
                t_d.ID_Flag = null;
            }
            else
            {
                t_d.ID_Flag = request.RequestParameters.Team.ID_Flag;
            }

            if (request.RequestParameters.Team.ID_Navigator == 0)
            {
                t_d.ID_Navigator = null;
            }
            else
            {
                t_d.ID_Navigator = request.RequestParameters.Team.ID_Navigator;
            }

            t_d.ID_Pilot = request.RequestParameters.Team.ID_Pilot;
            t_d.Color = request.RequestParameters.Team.Color;
            t_d.Description = request.RequestParameters.Team.Description;
            t_d.StartID = request.RequestParameters.Team.StartID;
            t_d.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_d.ID;
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == t_d.ID);
                cached.Add(getNetworkObject(t_d));
            }
            db.Dispose();
        }



        protected override System.Data.Linq.Table<t_Team> getTable(AnrlDataContext db)
        {
            return db.t_Teams;
        }

        protected override Team getNetworkObject(t_Team input)
        {
            Team result = new Team();
            result.ID_CompetitonSet = input.ID_CompetitionSet;
            result.ID = input.ID;
            result.Color = input.Color;
            result.Description = input.Description;
            result.ID_Flag = input.ID_Flag.HasValue ? input.ID_Flag.Value : -1;
            result.ID_Pilot = input.ID_Pilot;
            result.ID_Navigator = input.ID_Navigator.HasValue ? input.ID_Navigator.Value : -1;
            result.Name = input.Name;
            result.StartID = input.StartID;
            return result;
        }

        protected override t_Team getDBObject(Team input)
        {
            throw new NotImplementedException();
        }

        protected override int GetID(Team input)
        {
            return input.ID;
        }

        protected override int GetID(t_Team input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Team Obj)
        {
            return id_competitionSet == Obj.ID_CompetitonSet;
        }

        protected override void AddToResponseList(Root response, Team obj)
        {
            response.ResponseParameters.TeamList.Add(obj);
        }
    }
}
