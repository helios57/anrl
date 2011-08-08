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
        }
        public Root proccessRequest(Root request)
        {
            Root answer = new Root();
            switch ((RequestType) request.RequestType)
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
                        answer = proccessDeleteMap(request);
                        break;
                    }
                case RequestType.GetPicture:
                    {
                        answer = proccessGetPicture(request);
                        break;
                    }
            }
            return answer;
        }

        private Root proccessGetPicture(Root request)
        {
            Root result = new Root();
            result.ResponseParameters = new ResponseParameters();
            try
            {
                t_Picture pic = db.t_Pictures.SingleOrDefault(p => p.ID == request.RequestParameters.ID);
                Picture pp = new Picture();
                pp.ID = pic.ID;
                pp.Image = pic.Data.ToArray();
                pp.Name = pic.Name;
                result.ResponseParameters.Picture = pp;
            }
            catch (Exception ex)
            {
                result.ResponseParameters.Exception = ex;
            }
            return result;
        }

        private Root proccessDeleteMap(Root request)
        {
            return new Root();
        }

        private Root proccessSaveMap(Root request)
        {
            return new Root();
        }

        private Root proccessGetMaps(Root request)
        {
            return new Root();
        }

        private Root proccessLogin(Root request)
        {
            return new Root();
        }

        public bool isUseable()
        {
            return db.Connection.State == System.Data.ConnectionState.Open;
        }
    }
}
