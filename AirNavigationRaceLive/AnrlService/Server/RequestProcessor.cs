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
            processorMap.Add((int)EObjectType.CompetitionSet, new CompetitionSetProcesor());
            
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
                else if (request.RequestType == (int)ERequestType.Register)
                {
                    answer = proccessRegister(request);
                }
                else
                {
                    if (request.AuthInfo.Token == null || Int32.Parse(request.AuthInfo.Token) <= 0)
                    {
                        answer.ResponseParameters = new ResponseParameters();
                        answer.ResponseParameters.Exception = "Operation " + System.Enum.GetName(ERequestType.Get.GetType(), (ERequestType)(request.RequestType)) + " on ObjectType " +
                            System.Enum.GetName(EObjectType.Login.GetType(), (EObjectType)(request.ObjectType)) + " not permitted without login";
                    }
                    else if (processorMap.Keys.Contains(request.ObjectType))
                    {
                        request.AuthInfo.ID_User = Int32.Parse(request.AuthInfo.Token);
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
            r.ResponseParameters = new ResponseParameters();
            AnrlDataContext db = new AnrlDataContext();
            if (db.t_Users.Count(p => p.Name == request.AuthInfo.Username && p.Password == request.AuthInfo.Password) == 1)
            {
                r.AuthInfo.Token = db.t_Users.Single(p => p.Name == request.AuthInfo.Username && p.Password == request.AuthInfo.Password).ID.ToString();
            }
            else
            {
                r.ResponseParameters.Exception = "Username / Password wrong";
            }
            return r;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private Root proccessRegister(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();

            AnrlDataContext db = new AnrlDataContext();
            if (db.t_Users.Count(p => p.Name == request.AuthInfo.Username) == 0)
            {
                t_User user = new t_User();
                user.Name = request.AuthInfo.Username;
                user.Password = request.AuthInfo.Password;
                user.ID_Role = 0;
                db.t_Users.InsertOnSubmit(user);
                db.SubmitChanges();
                r.AuthInfo = new AuthenticationInfo();
            }
            else
            {
                r.ResponseParameters.Exception = "Username already in use";
            }
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
