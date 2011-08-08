using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server
{
    public class RequestProcessor
    {
        AnrlDataContext db;
        public RequestProcessor()
        {
            db = new AnrlDataContext();
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
        }
        public Root proccessRequest(Root request)
        {
            Root answer = new Root();
            try
            {
                switch ((RequestType)request.RequestType)
                {
                    case RequestType.Login:
                        {
                            answer = proccessLogin(request);
                            break;
                        }
                    case RequestType.GetMaps:
                        {
                            answer = proccessGetMaps(request);
                            break;
                        }
                    case RequestType.SaveMap:
                        {
                            answer = proccessSaveMap(request);
                            break;
                        }
                    case RequestType.DeleteMap:
                        {
                            proccessDeleteMap(request);
                            break;
                        }
                    case RequestType.GetPicture:
                        {
                            answer = proccessGetPicture(request);
                            break;
                        }
                    case RequestType.SavePicture:
                        {
                            answer = proccessSavePicture(request);
                            break;
                        }
                    case RequestType.DeletePicture:
                        {
                            proccessDeletePicture(request);
                            break;
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
            }
            return answer;
        }

        private void proccessDeletePicture(Root request)
        {
            db.t_Pictures.DeleteOnSubmit(db.t_Pictures.Single(p => p.ID == request.RequestParameters.ID));
            db.SubmitChanges();
        }

        private Root proccessSavePicture(Root request)
        {
            Root r = new Root();

            t_Picture pp;
            bool neww = true;
            if (request.RequestParameters != null && request.RequestParameters.ID <= 0)
            {
                pp = new t_Picture();
            }
            else
            {
                neww = false;
                pp = db.t_Pictures.Single(p => p.ID == request.RequestParameters.ID);
            }
            Picture pic = request.RequestParameters.Picture;
            pp.ID = pic.ID;
            pp.Data = new System.Data.Linq.Binary(pic.Image);
            pp.Name = pic.Name;
            if (neww)
            {
                db.t_Pictures.InsertOnSubmit(pp);
            }
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = pp.ID;
            return r;
        }

        private Root proccessGetPicture(Root request)
        {
            Root result = new Root();
            result.ResponseParameters = new ResponseParameters();
            t_Picture pic = db.t_Pictures.SingleOrDefault(p => p.ID == request.RequestParameters.ID);
            Picture pp = new Picture();
            pp.ID = pic.ID;
            pp.Image = pic.Data.ToArray();
            pp.Name = pic.Name;
            result.ResponseParameters.Picture = pp;
            return result;
        }

        private void proccessDeleteMap(Root request)
        {
            db.t_Maps.DeleteOnSubmit(db.t_Maps.Single(p => p.ID == request.RequestParameters.ID));
            db.SubmitChanges();
        }

        private Root proccessSaveMap(Root request)
        {
            Root r = new Root();
            Map newMap = request.RequestParameters.Map;
            t_Map dbMap;
            bool neww = true;
            if (request.RequestParameters != null && request.RequestParameters.ID <= 0)
            {
                dbMap = new t_Map();
            }
            else
            {
                neww = false;
                dbMap = db.t_Maps.Single(p => p.ID == request.RequestParameters.ID);
            }
            dbMap.ID = newMap.ID;
            dbMap.Name = newMap.Name;
            dbMap.ID_Picture = newMap.ID_Picture;
            dbMap.XRot = newMap.XRot;
            dbMap.XSize = newMap.XSize;
            dbMap.XTopLeft = newMap.XTopLeft;
            dbMap.YRot = newMap.YRot;
            dbMap.YSize = newMap.YSize;
            dbMap.YTopLeft = newMap.YTopLeft;
            if (neww)
            {
                db.t_Maps.InsertOnSubmit(dbMap);
            }
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = dbMap.ID;
            return r;
        }

        private Root proccessGetMaps(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.MapList = new MapList();
            foreach (t_Map dbMap in db.t_Maps)
            {
                Map m = new Map();
                m.ID = dbMap.ID;
                m.Name = dbMap.Name;
                m.ID_Picture = dbMap.ID_Picture;
                m.XRot = dbMap.XRot;
                m.XSize = dbMap.XSize;
                m.XTopLeft = dbMap.XTopLeft;
                m.YRot = dbMap.YRot;
                m.YSize = dbMap.YSize;
                m.YTopLeft = dbMap.YTopLeft;
                r.ResponseParameters.MapList.Maps.Add(m);
            }
            return r;
        }

        private Root proccessLogin(Root request)
        {
            Root r = new Root();
            r.AuthInfo = new AuthenticationInfo();
            r.AuthInfo.Token = "Test";
            return r;
        }

        public bool isUseable()
        {
            return db.Connection.State == System.Data.ConnectionState.Open;
        }
    }
}
