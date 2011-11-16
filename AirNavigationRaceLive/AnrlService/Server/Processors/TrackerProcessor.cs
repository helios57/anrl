using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class TrackerProcessor : AnrlService.Server.Processors.AProcessor<t_Tracker,Tracker>
    {

        protected override Func<t_Tracker, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }
        protected override void Save(Root request, Root r)
        {
            AnrlDataContext db = getDB();
            t_Tracker t_d = db.t_Trackers.Single(p => p.ID == request.RequestParameters.Tracker.ID);
            t_d.Name = request.RequestParameters.Tracker.Name;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_d.ID;
            lock (cached)
            {
                cached.RemoveAll(p => p.ID == t_d.ID);
                cached.Add(getNetworkObject(t_d));
            }
            db.Dispose();
            reloadCacheThreated();//Hack to avoid empty competitions
        }

        protected override System.Data.Linq.Table<t_Tracker> getTable(AnrlDataContext db)
        {
            return db.t_Trackers;
        }

        protected override Tracker getNetworkObject(t_Tracker input)
        {
            Tracker result = new Tracker();
            result.ID = input.ID;
            result.IMEI = input.IMEI;
            result.Name = input.Name;
            return result;
        }

        protected override t_Tracker getDBObject(Tracker input)
        {
            throw new NotImplementedException();
        }

        protected override int GetID(Tracker input)
        {
            return input.ID;
        }

        protected override int GetID(t_Tracker input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Tracker Obj)
        {
            return true;
        }

        protected override void AddToResponseList(Root response, Tracker obj)
        {
            response.ResponseParameters.TrackerList.Add(obj);
        }
    }
}
