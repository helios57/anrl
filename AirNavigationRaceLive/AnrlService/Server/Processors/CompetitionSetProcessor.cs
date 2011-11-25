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
            r.ResponseParameters.CompetitionSetList.Add(getNetworkObject(t_d));
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
            result.ID_Owner = input.ID_Owner;
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

        protected override void GetAll(Root request, Root response)
        {
            List<int> ids = new List<int>(request.RequestParameters != null ? request.RequestParameters.IDS : new List<int>());
            int id_owner = request.AuthInfo.ID_User;
            lock (cached)
            {
                foreach (CompetitionSet obj in cached.Where(p => CheckCompetitionSet(id_owner, p)))
                {
                    if (!ids.Contains(GetID(obj)))
                    {
                        AddToResponseList(response, obj);
                    }
                    else
                    {
                        ids.Remove(GetID(obj));
                    }
                }
            }
            response.ResponseParameters.DeletedIDList.AddRange(ids);
        }

        protected override void Get(Root request, Root response)
        {
            if (request.RequestParameters != null && request.RequestParameters.ID != 0)
            {
                int id_owner = request.AuthInfo.ID_User;
                lock (cached)
                {
                    foreach (CompetitionSet obj in cached.Where(p => GetID(p) == request.RequestParameters.ID && CheckCompetitionSet(id_owner, p)))
                    {
                        AddToResponseList(response, obj);
                    }
                }
            }
        }

        protected override bool CheckCompetitionSet(int id_owner, CompetitionSet Obj)
        {
            return Obj.ID_Owner == id_owner;
        }

        protected override void AddToResponseList(Root response, CompetitionSet obj)
        {
            response.ResponseParameters.CompetitionSetList.Add(obj);
        }
    }
}
