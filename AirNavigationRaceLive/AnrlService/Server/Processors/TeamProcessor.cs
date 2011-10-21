using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class TeamProcessor : AnrlService.Server.Processors.AProcessor
    {
        private readonly List<Team> cached = new List<Team>();

        protected override void reloadCacheThreated()
        {
            AnrlDataContext db = getDB();
            lock (cached)
            {
                cached.Clear();
                foreach (t_Team t in db.t_Teams)
                {
                    cached.Add(getTeam(t));
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

        private void Save(Root request, Root r)
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
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_d.ID;
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == t_d.ID);
                cached.Add(getTeam(t_d));
            }
            db.Dispose();
        }

        private void GetAll(Root request, Root r)
        {
            List<int> ids = new List<int>(request.RequestParameters.IDS);
            lock (cached)
            {
                foreach (Team t_d in cached)
                {
                    if (!ids.Contains(t_d.ID))
                    {
                        r.ResponseParameters.TeamList.Add(t_d);
                    }
                    else
                    {
                        ids.Remove(t_d.ID);
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
                    foreach (Team t_d in cached.Where(p => p.ID == request.RequestParameters.ID))
                    {
                        r.ResponseParameters.TeamList.Add(t_d);
                    }
                }
            }
        }

        private void Delete(Root request)
        {
            AnrlDataContext db = getDB();
            db.t_Teams.DeleteAllOnSubmit(db.t_Teams.Where(p => p.ID == request.RequestParameters.ID));
            db.SubmitChanges();
            db.Dispose();

            lock (cached)
            {
                cached.RemoveAll(p => p.ID == request.RequestParameters.ID);
            }
        }

        private Team getTeam(t_Team input)
        {
            Team result = new Team();
            result.ID = input.ID;
            result.Color = input.Color;
            result.Description = input.Description;
            result.ID_Flag = input.ID_Flag.HasValue ? input.ID_Flag.Value : -1;
            result.ID_Pilot = input.ID_Pilot;
            result.ID_Navigator = input.ID_Navigator.HasValue ? input.ID_Navigator.Value : -1;
            result.Name = input.Name;
            return result;
        }
    }
}
