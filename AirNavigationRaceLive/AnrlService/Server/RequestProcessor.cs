using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;
using System.Diagnostics;

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
                    case RequestType.GetParcours:
                        {
                            answer = proccessGetParcours(request);
                            break;
                        }
                    case RequestType.SaveParcour:
                        {
                            answer = proccessSaveParcour(request);
                            break;
                        }
                    case RequestType.DeleteParcour:
                        {
                            proccessDeleteParcour(request);
                            break;
                        }
                    case RequestType.GetTrackers:
                        {
                            answer = proccessGetTrackers(request);
                            break;
                        }
                    case RequestType.SaveTracker:
                        {
                            answer = proccessSaveTracker(request);
                            break;
                        }
                    case RequestType.DeleteTracker:
                        {
                            proccessDeleteTracker(request);
                            break;
                        }
                    case RequestType.GetPilots:
                        {
                            answer = proccessGetPilots(request);
                            break;
                        }
                    case RequestType.SavePilot:
                        {
                            answer = proccessSavePilot(request);
                            break;
                        }
                    case RequestType.DeletePilot:
                        {
                            proccessDeletePilot(request);
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

                EventLog.WriteEntry("Anrl-Service", "Exception in RequestProcessor.proccessRequest" + ex.InnerException.Message, EventLogEntryType.Error, 10);
            }
            return answer;
        }

        private void proccessDeletePilot(Root request)
        {
            if (db.t_Pilots.Count(p => p.ID == request.RequestParameters.ID) == 1)
            {
                t_Pilot p_d;
                p_d = db.t_Pilots.Single(p => p.ID == request.RequestParameters.ID);
                db.t_Pilots.DeleteOnSubmit(p_d);
                db.SubmitChanges();
            }
        }

        private Root proccessSavePilot(Root request)
        {
            Root r = new Root();
            t_Pilot p_d;
            if (db.t_Pilots.Count(p => p.ID == request.RequestParameters.Pilot.ID) == 1)
            {
                p_d = db.t_Pilots.Single(p => p.ID == request.RequestParameters.Pilot.ID);
            }
            else
            {
                p_d = new t_Pilot();
                db.t_Pilots.InsertOnSubmit(p_d);
            }
            if (request.RequestParameters.Pilot.ID_Picture == 0)
            {
                p_d.ID_Picture=null;
            }
            else
            {
                p_d.ID_Picture = request.RequestParameters.Pilot.ID_Picture;
            }
            p_d.SureName = request.RequestParameters.Pilot.Surename;
            p_d.LastName = request.RequestParameters.Pilot.Name;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = p_d.ID;
            return r;
        }

        private Root proccessGetPilots(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.PilotList = new PilotList();
            foreach (t_Pilot p_d in db.t_Pilots)
            {
                Pilot p = new Pilot();
                p.ID = p_d.ID;
                p.Surename = p_d.SureName;
                p.Name = p_d.LastName;
                p.ID_Picture = p_d.ID_Picture.HasValue ? p_d.ID_Picture.Value : -1;
                r.ResponseParameters.PilotList.Pilots.Add(p);
            }
            return r;
        }

        private Root proccessSaveTracker(Root request)
        {
            Root r = new Root();
            t_Tracker t_d = db.t_Trackers.Single(p => p.ID == request.RequestParameters.Tracker.ID);
            t_d.Name = request.RequestParameters.Tracker.Name;
            db.SubmitChanges();
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_d.ID;
            return r;
        }

        private Root proccessGetTrackers(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            TrackerList tl = new TrackerList();
            foreach(t_Tracker t_d in db.t_Trackers)
            {
                Tracker t = new Tracker();
                t.ID = t_d.ID;
                t.Name = t_d.Name;
                t.IMEI = t_d.IMEI;
                tl.Trackers.Add(t);
            }
            r.ResponseParameters.TrackerList = tl;
            return r;
        }

        private void proccessDeleteTracker(Root request)
        {
            db.t_Datens.DeleteAllOnSubmit(db.t_Datens.Where(p=>p.ID_Tracker==request.RequestParameters.ID));
            db.SubmitChanges();
        }

        private void proccessDeleteParcour(Root request)
        {
            foreach (t_Parcour dbParcour in db.t_Parcours.Where(p=>p.ID == request.RequestParameters.ID))
            {
                foreach (t_Parcour_Line t_p_l in dbParcour.t_Parcour_Lines)
                {
                    t_Line t_l = t_p_l.t_Line;
                    db.t_GPSPoints.DeleteOnSubmit(t_l.t_GPSPoint);
                    db.t_GPSPoints.DeleteOnSubmit(t_l.t_GPSPoint1);
                    db.t_GPSPoints.DeleteOnSubmit(t_l.t_GPSPoint2);
                    db.t_Lines.DeleteOnSubmit(t_l);
                    db.t_Parcour_Lines.DeleteOnSubmit(t_p_l);
                }
                db.t_Parcours.DeleteOnSubmit(dbParcour);
            }
            db.SubmitChanges();
        }

        private Root proccessSaveParcour(Root request)
        {
            Root r = new Root();
            Parcour p = request.RequestParameters.Parcour;
            t_Parcour dbParcour = new t_Parcour();
            dbParcour.Name = p.Name;
            dbParcour.ID_Map = p.ID_Map;
            db.t_Parcours.InsertOnSubmit(dbParcour);
            db.SubmitChanges();
            foreach (Line l in p.Lines)
            {
                t_Line line = new t_Line();
                t_GPSPoint a = new t_GPSPoint();
                CopyAttributes(l.A, a);
                db.t_GPSPoints.InsertOnSubmit(a);

                t_GPSPoint b = new t_GPSPoint();
                CopyAttributes(l.B, b);
                db.t_GPSPoints.InsertOnSubmit(b);

                t_GPSPoint o = new t_GPSPoint();
                CopyAttributes(l.O, o);
                db.t_GPSPoints.InsertOnSubmit(o);
                db.SubmitChanges();

                line.ID_PointA = a.ID;
                line.ID_PointB = b.ID;
                line.ID_PointOrientation = o.ID;
                line.Type = l.Type;
                db.t_Lines.InsertOnSubmit(line);
                db.SubmitChanges();
                t_Parcour_Line pl = new t_Parcour_Line();
                pl.ID_Line = line.ID;
                pl.ID_Parcour = dbParcour.ID;
                db.t_Parcour_Lines.InsertOnSubmit(pl);
                db.SubmitChanges();
            }
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = p.ID;
            return r;
        }

        private Root proccessGetParcours(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            ParcourList pl = new ParcourList();
            foreach (t_Parcour dbParcour in db.t_Parcours)
            {
                Parcour p = new Parcour();
                p.ID = dbParcour.ID;
                p.Name = dbParcour.Name;
                p.ID_Map = dbParcour.ID_Map;
                foreach (t_Parcour_Line t_p_l in dbParcour.t_Parcour_Lines)
                {
                    t_Line t_l = t_p_l.t_Line;
                    Line l = new Line();
                    l.A = new Point();
                    CopyAttributes(t_l.t_GPSPoint, l.A);
                    l.B = new Point();
                    CopyAttributes(t_l.t_GPSPoint1, l.B);
                    l.O = new Point();
                    CopyAttributes(t_l.t_GPSPoint2, l.O);
                    l.Type = t_l.Type;
                    p.Lines.Add(l);
                }
                pl.Parcours.Add(p);
            }
            r.ResponseParameters.ParcourList = pl;
            return r;
        }

        private static void CopyAttributes(t_GPSPoint gp, Point p)
        {
            p.ID = gp.ID;
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }
        private static void CopyAttributes(Point gp, t_GPSPoint p)
        {
            p.ID = gp.ID;
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
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
            pp = new t_Picture();
            Picture pic = request.RequestParameters.Picture;
            pp.ID = pic.ID;
            pp.Data = new System.Data.Linq.Binary(pic.Image);
            pp.Name = pic.Name;
            db.t_Pictures.InsertOnSubmit(pp);
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
            if (r.RequestParameters != null && r.RequestParameters.ID != 0)
            {
                foreach (t_Map dbMap in db.t_Maps.Where(p=>p.ID==r.RequestParameters.ID))
                {
                    addMapToRoot(r, dbMap);
                }

            }
            else
            {
                foreach (t_Map dbMap in db.t_Maps)
                {
                    addMapToRoot(r, dbMap);
                }
            }
            return r;
        }

        private static void addMapToRoot(Root r, t_Map dbMap)
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
