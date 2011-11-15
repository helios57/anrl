using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class MapProcessor : AnrlService.Server.Processors.AProcessor<t_Map,Map>
    {

        protected override Func<t_Map, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }
        protected override void Save(Root request, Root r)
        {
            AnrlDataContext db = getDB();
            t_Map dbMap = getDBObject(request.RequestParameters.Map);
            dbMap.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;
            db.t_Maps.InsertOnSubmit(dbMap);
            db.SubmitChanges();
            lock (cached)
            {
                cached.Add(getNetworkObject(dbMap));
                r.ResponseParameters = new ResponseParameters();
                r.ResponseParameters.ID = dbMap.ID;
            }
            db.Dispose();
        }


        protected override System.Data.Linq.Table<t_Map> getTable(AnrlDataContext db)
        {
            return db.t_Maps;
        }

        protected override Map getNetworkObject(t_Map input)
        {
            Map result = new Map();
            result.ID_CompetitonSet = input.ID_CompetitionSet;
            result.ID = input.ID;
            result.ID_Picture = input.ID_Picture;
            result.Name = input.Name;
            result.XRot = input.XRot;
            result.XSize = input.XSize;
            result.XTopLeft = input.XTopLeft;
            result.YRot = input.YRot;
            result.YSize = input.YSize;
            result.YTopLeft = input.YTopLeft;
            return result;
        }

        protected override t_Map getDBObject(Map input)
        {
            t_Map result = new t_Map();
            result.ID_Picture = input.ID_Picture;
            result.Name = input.Name;
            result.XRot = input.XRot;
            result.XSize = input.XSize;
            result.XTopLeft = input.XTopLeft;
            result.YRot = input.YRot;
            result.YSize = input.YSize;
            result.YTopLeft = input.YTopLeft;
            return result;
        }

        protected override int GetID(Map input)
        {
            return input.ID;
        }

        protected override int GetID(t_Map input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Map Obj)
        {
            return id_competitionSet == Obj.ID_CompetitonSet;
        }

        protected override void AddToResponseList(Root response, Map obj)
        {
            response.ResponseParameters.MapList.Add(obj);
        }
    }
}
