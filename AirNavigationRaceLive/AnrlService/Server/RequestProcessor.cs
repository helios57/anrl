using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AnrlService.Server.Processors;

namespace AnrlService.Server
{
    public class RequestProcessor : IProcessor
    {
        Dictionary<int, IProcessor> processorMap;
        public RequestProcessor()
        {
            //Make sure DB is existent
            AnrlDataContext db = new AnrlDataContext();
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            db.Dispose();

            processorMap = new Dictionary<int, IProcessor>();
            processorMap.Add((int)EObjectType.Picture, new PictureProcessor());
            processorMap.Add((int)EObjectType.Penalty, new PenaltyProcessor());
            processorMap.Add((int)EObjectType.Map, new MapProcessor());
            processorMap.Add((int)EObjectType.Parcour, new ParcourProcessor());
            processorMap.Add((int)EObjectType.Pilot, new PilotProcessor());
            processorMap.Add((int)EObjectType.Tracker, new TrackerProcessor());
            processorMap.Add((int)EObjectType.Team, new TeamProcessor());
            processorMap.Add((int)EObjectType.GPSData, new GPSDataProcessor((TrackerProcessor)processorMap[(int)EObjectType.Tracker]));
            processorMap.Add((int)EObjectType.Competition, new CompetitionProcessor());
        }
        public Root proccess(Root request)
        {
            Root answer = new Root();
            if (request == null)
            {
                answer.ResponseParameters = new ResponseParameters();
                answer.ResponseParameters.Exception = "request was null, network Error";
                return answer;
            }
            try
            {
                if (request.RequestType == (int)ERequestType.Login)
                {
                    answer = proccessLogin(request);
                }
                else
                {
                    if (processorMap.Keys.Contains(request.ObjectType))
                    {
                        answer = processorMap[request.ObjectType].proccess(request);
                    }
                }
            }
            catch (Exception ex)
            {
                if (answer.ResponseParameters == null)
                {
                    answer.ResponseParameters = new ResponseParameters();
                }
                answer.ResponseParameters.Exception = ex.ToString();
#if !DEBUG

                //Logger.Log(db, "Exception in RequestProcessor.proccessRequest" + ex.ToString(), 0);
#else
                //System.Console.WriteLine("Exception in RequestProcessor.proccessRequest " + ex.ToString());
#endif
            }
            return answer;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private Root proccessLogin(Root request)
        {
            Root r = new Root();
            r.AuthInfo = new AuthenticationInfo();
            r.AuthInfo.Token = "Test";
            return r;
        }

        public void reloadCache()
        {
            foreach (IProcessor processor in processorMap.Values)
            {
                processor.reloadCache();
            }
        }
    }
}
