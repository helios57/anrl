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
                    switch ((EObjectType)request.ObjectType)
                    {
                        case EObjectType.Map:
                            {
                                answer = proccessMap(request);
                                break;
                            }
                        case EObjectType.Parcour:
                            {
                                answer = proccessParcour(request);
                                break;
                            }
                        case EObjectType.Picture:
                            {
                                answer = proccessPicture(request);
                                break;
                            }
                        case EObjectType.Pilot:
                            {
                                answer = proccessPilot(request);
                                break;
                            }
                        case EObjectType.Tracker:
                            {
                                answer = proccessTracker(request);
                                break;
                            }
                        case EObjectType.Team:
                            {
                                answer = proccessTeam(request);
                                break;
                            }
                        case EObjectType.Group:
                            {
                                answer = proccessGroup(request);
                                break;
                            }
                        case EObjectType.Competition:
                            {
                                answer = proccessCompetition(request);
                                break;
                            }
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

                //Logger.Log(db, "Exception in RequestProcessor.proccessRequest" + ex.InnerException.Message, 0);
#else
                System.Console.WriteLine("Exception in RequestProcessor.proccessRequest " + ex.InnerException.Message);
#endif
            }
            return answer;
        }

        #region Map
        private Root proccessMap(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        db.t_Maps.DeleteOnSubmit(db.t_Maps.Single(p => p.ID == request.RequestParameters.ID));
                        db.SubmitChanges();
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Map dbMap in db.t_Maps.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                addMapToRoot(r, dbMap);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Map dbMap in db.t_Maps)
                        {
                            if (!ids.Contains(dbMap.ID))
                            {
                                addMapToRoot(r, dbMap);
                            }
                            else
                            {
                                ids.Remove(dbMap.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
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
                        break;
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
            r.ResponseParameters.MapList.Add(m);
        }
        #endregion

        private Root proccessParcour(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        foreach (t_Parcour dbParcour in db.t_Parcours.Where(p => p.ID == request.RequestParameters.ID))
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
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Parcour dbParcour in db.t_Parcours.Where(p => p.ID == request.RequestParameters.ID))
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
                                    p.LineList.Add(l);
                                }
                                r.ResponseParameters.ParcourList.Add(p);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Parcour dbParcour in db.t_Parcours)
                        {
                            if (!ids.Contains(dbParcour.ID))
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
                                    p.LineList.Add(l);
                                }
                                r.ResponseParameters.ParcourList.Add(p);
                            }
                            else
                            {
                                ids.Remove(dbParcour.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
                        Parcour p = request.RequestParameters.Parcour;
                        t_Parcour dbParcour = new t_Parcour();
                        dbParcour.Name = p.Name;
                        dbParcour.ID_Map = p.ID_Map;
                        db.t_Parcours.InsertOnSubmit(dbParcour);
                        db.SubmitChanges();
                        foreach (Line l in p.LineList)
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
                        r.ResponseParameters.ID = dbParcour.ID;
                        break;
                    }
            }
            return r;
        }


        private Root proccessPicture(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        db.t_Pictures.DeleteOnSubmit(db.t_Pictures.Single(p => p.ID == request.RequestParameters.ID));
                        db.SubmitChanges();
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Picture pic in db.t_Pictures.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                Picture pp = new Picture();
                                pp.ID = pic.ID;
                                pp.Image = pic.Data.ToArray();
                                pp.Name = pic.Name;
                                r.ResponseParameters.PictureList.Add(pp);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Picture pic in db.t_Pictures)
                        {
                            if (!ids.Contains(pic.ID))
                            {
                                Picture pp = new Picture();
                                pp.ID = pic.ID;
                                pp.Image = pic.Data.ToArray();
                                pp.Name = pic.Name;
                                r.ResponseParameters.PictureList.Add(pp);
                            }
                            else
                            {
                                ids.Remove(pic.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
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
                        break;
                    }
            }
            return r;
        }

        private Root proccessPilot(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        if (db.t_Pilots.Count(p => p.ID == request.RequestParameters.ID) == 1)
                        {
                            t_Pilot p_d;
                            p_d = db.t_Pilots.Single(p => p.ID == request.RequestParameters.ID);
                            db.t_Pilots.DeleteOnSubmit(p_d);
                            db.SubmitChanges();
                        }
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Pilot p_d in db.t_Pilots.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                Pilot p = new Pilot();
                                p.ID = p_d.ID;
                                p.Surename = p_d.SureName;
                                p.Name = p_d.LastName;
                                p.ID_Picture = p_d.ID_Picture.HasValue ? p_d.ID_Picture.Value : -1;
                                r.ResponseParameters.PilotList.Add(p);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Pilot p_d in db.t_Pilots)
                        {
                            if (!ids.Contains(p_d.ID))
                            {
                                Pilot p = new Pilot();
                                p.ID = p_d.ID;
                                p.Surename = p_d.SureName;
                                p.Name = p_d.LastName;
                                p.ID_Picture = p_d.ID_Picture.HasValue ? p_d.ID_Picture.Value : -1;
                                r.ResponseParameters.PilotList.Add(p);
                            }
                            else
                            {
                                ids.Remove(p_d.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
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
                            p_d.ID_Picture = null;
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
                        break;
                    }
            }
            return r;
        }
        private Root proccessTracker(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        db.t_Datens.DeleteAllOnSubmit(db.t_Datens.Where(p => p.ID_Tracker == request.RequestParameters.ID));
                        db.t_Team_Trackers.DeleteAllOnSubmit(db.t_Team_Trackers.Where(p => p.ID_Tracker == request.RequestParameters.ID));
                        db.t_Trackers.DeleteAllOnSubmit(db.t_Trackers.Where(p => p.ID == request.RequestParameters.ID));
                        db.SubmitChanges();
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Tracker t_d in db.t_Trackers.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                Tracker t = new Tracker();
                                t.ID = t_d.ID;
                                t.Name = t_d.Name;
                                t.IMEI = t_d.IMEI;
                                r.ResponseParameters.TrackerList.Add(t);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Tracker t_d in db.t_Trackers)
                        {
                            if (!ids.Contains(t_d.ID))
                            {
                                Tracker t = new Tracker();
                                t.ID = t_d.ID;
                                t.Name = t_d.Name;
                                t.IMEI = t_d.IMEI;
                                r.ResponseParameters.TrackerList.Add(t);
                            }
                            else
                            {
                                ids.Remove(t_d.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
                        t_Tracker t_d = db.t_Trackers.Single(p => p.ID == request.RequestParameters.Tracker.ID);
                        t_d.Name = request.RequestParameters.Tracker.Name;
                        db.SubmitChanges();
                        r.ResponseParameters = new ResponseParameters();
                        r.ResponseParameters.ID = t_d.ID;
                        break;
                    }
            }
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


        private Root proccessTeam(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        db.t_Team_Trackers.DeleteAllOnSubmit(db.t_Team_Trackers.Where(p => p.ID_Team == request.RequestParameters.ID));
                        db.t_Teams.DeleteAllOnSubmit(db.t_Teams.Where(p => p.ID == request.RequestParameters.ID));
                        db.SubmitChanges();
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Team t_d in db.t_Teams.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                Team t = new Team();
                                t.ID = t_d.ID;
                                t.Name = t_d.Name;
                                t.ID_Pilot = t_d.ID_Pilot;
                                t.ID_Navigator = t_d.ID_Navigator != null ? (int)t_d.ID_Navigator : 0;
                                t.ID_Flag = t_d.ID_Flag != null ? (int)t_d.ID_Flag : 0;
                                t.Color = t_d.Color;
                                t.Description = t_d.Description;
                                foreach (t_Team_Tracker d_t_t in t_d.t_Team_Trackers)
                                {
                                    t.ID_Tracker.Add(d_t_t.ID_Tracker);
                                }
                                r.ResponseParameters.TeamList.Add(t);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Team t_d in db.t_Teams)
                        {
                            if (!ids.Contains(t_d.ID))
                            {
                                Team t = new Team();
                                t.ID = t_d.ID;
                                t.Name = t_d.Name;
                                t.ID_Pilot = t_d.ID_Pilot;
                                t.ID_Navigator = t_d.ID_Navigator != null ? (int)t_d.ID_Navigator : 0;
                                t.ID_Flag = t_d.ID_Flag != null ? (int)t_d.ID_Flag : 0;
                                t.Color = t_d.Color;
                                t.Description = t_d.Description;
                                foreach (t_Team_Tracker d_t_t in t_d.t_Team_Trackers)
                                {
                                    t.ID_Tracker.Add(d_t_t.ID_Tracker);
                                }
                                r.ResponseParameters.TeamList.Add(t);
                            }
                            else
                            {
                                ids.Remove(t_d.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
                        t_Team t_d;
                        if (request.RequestParameters.Team.ID > 0)
                        {
                            t_d = db.t_Teams.Single(p => p.ID == request.RequestParameters.Team.ID);
                            db.t_Team_Trackers.DeleteAllOnSubmit(db.t_Team_Trackers.Where(p => p.ID_Team == request.RequestParameters.Team.ID));
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
                        foreach (int i in request.RequestParameters.Team.ID_Tracker)
                        {
                            t_Team_Tracker ttt = new t_Team_Tracker();
                            ttt.ID_Team = t_d.ID;
                            ttt.ID_Tracker = i;
                            db.t_Team_Trackers.InsertOnSubmit(ttt);
                        }
                        db.SubmitChanges();
                        r.ResponseParameters = new ResponseParameters();
                        r.ResponseParameters.ID = t_d.ID;
                        break;
                    }
            }
            return r;
        }


        private Root proccessGroup(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        db.t_Group_Teams.DeleteAllOnSubmit(db.t_Group_Teams.Where(p => p.ID_Group == request.RequestParameters.ID));
                        db.t_Groups.DeleteAllOnSubmit(db.t_Groups.Where(p => p.ID == request.RequestParameters.ID));
                        db.SubmitChanges();
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Group t_g in db.t_Groups.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                Group g = new Group();
                                g.ID = t_g.ID;
                                g.Name = t_g.Name;
                                foreach (t_Group_Team d_g_t in t_g.t_Group_Teams)
                                {
                                    GroupTeam gt = new GroupTeam();
                                    gt.ID_Team = d_g_t.ID_Team;
                                    gt.Pos = d_g_t.Pos;
                                    g.GroupTeamList.Add(gt);
                                }
                                r.ResponseParameters.GroupList.Add(g);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Group t_g in db.t_Groups)
                        {
                            if (!ids.Contains(t_g.ID))
                            {
                                Group g = new Group();
                                g.ID = t_g.ID;
                                g.Name = t_g.Name;
                                foreach (t_Group_Team d_g_t in t_g.t_Group_Teams)
                                {
                                    GroupTeam gt = new GroupTeam();
                                    gt.ID_Team = d_g_t.ID_Team;
                                    gt.Pos = d_g_t.Pos;
                                    g.GroupTeamList.Add(gt);
                                }
                                r.ResponseParameters.GroupList.Add(g);
                            }
                            else
                            {
                                ids.Remove(t_g.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
                        t_Group t_g;
                        if (request.RequestParameters.Group.ID > 0)
                        {
                            t_g = db.t_Groups.Single(p => p.ID == request.RequestParameters.Group.ID);
                            db.t_Group_Teams.DeleteAllOnSubmit(db.t_Group_Teams.Where(p => p.ID_Group == request.RequestParameters.Group.ID));
                            db.SubmitChanges();
                        }
                        else
                        {
                            t_g = new t_Group();
                            db.t_Groups.InsertOnSubmit(t_g);
                        }
                        t_g.Name = request.RequestParameters.Group.Name;

                        db.SubmitChanges();
                        foreach (GroupTeam gt in request.RequestParameters.Group.GroupTeamList)
                        {
                            if (db.t_Group_Teams.Count(p => p.ID_Group == t_g.ID && p.ID_Team == gt.ID_Team) == 0)
                            {
                                t_Group_Team tgt = new t_Group_Team();
                                tgt.ID_Team = gt.ID_Team;
                                tgt.ID_Group = t_g.ID;
                                tgt.Pos = gt.Pos;
                                db.t_Group_Teams.InsertOnSubmit(tgt);
                            }
                        }
                        db.SubmitChanges();
                        r.ResponseParameters.ID = t_g.ID;
                        break;
                    }
            }
            return r;
        }



        private Root proccessCompetition(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Delete:
                    {
                        db.t_Competition_Groups.DeleteAllOnSubmit(db.t_Competition_Groups.Where(p => p.ID_Competition == request.RequestParameters.ID));
                        db.t_Competitions.DeleteAllOnSubmit(db.t_Competitions.Where(p => p.ID == request.RequestParameters.ID));
                        db.SubmitChanges();
                        break;
                    }
                case ERequestType.Get:
                    {
                        if (request.RequestParameters != null && request.RequestParameters.ID != 0)
                        {
                            foreach (t_Competition t_c in db.t_Competitions.Where(p => p.ID == request.RequestParameters.ID))
                            {
                                Competition c = new Competition();
                                c.ID = t_c.ID;
                                c.Name = t_c.Name;
                                c.ID_Parcour = t_c.ID_Parcour;
                                c.ID_TakeOffLine = t_c.ID_TakeOffLine;
                                c.TimeEndLine = t_c.TimeEndLine;
                                c.TimeStartLine = t_c.TimeStartLine;
                                c.TimeTakeOff = t_c.TimeTakeOff;

                                foreach (t_Competition_Group d_c_g in t_c.t_Competition_Groups)
                                {
                                    CompetitionGroup cg = new CompetitionGroup();
                                    cg.ID_Group = d_c_g.ID_Group;
                                    cg.Pos = d_c_g.Pos;
                                    c.CompetitionGroupList.Add(cg);
                                }
                                r.ResponseParameters.CompetitionList.Add(c);
                            }
                        }
                        break;
                    }
                case ERequestType.GetAll:
                    {
                        List<int> ids = new List<int>(request.RequestParameters.IDS);
                        foreach (t_Competition t_c in db.t_Competitions)
                        {
                            if (!ids.Contains(t_c.ID))
                            {
                                Competition c = new Competition();
                                c.ID = t_c.ID;
                                c.Name = t_c.Name;
                                c.ID_Parcour = t_c.ID_Parcour;
                                c.ID_TakeOffLine = t_c.ID_TakeOffLine;
                                c.TimeEndLine = t_c.TimeEndLine;
                                c.TimeStartLine = t_c.TimeStartLine;
                                c.TimeTakeOff = t_c.TimeTakeOff;

                                foreach (t_Competition_Group d_c_g in t_c.t_Competition_Groups)
                                {
                                    CompetitionGroup cg = new CompetitionGroup();
                                    cg.ID_Group = d_c_g.ID_Group;
                                    cg.Pos = d_c_g.Pos;
                                    c.CompetitionGroupList.Add(cg);
                                }
                                r.ResponseParameters.CompetitionList.Add(c);
                            }
                            else
                            {
                                ids.Remove(t_c.ID);
                            }
                        }
                        r.ResponseParameters.DeletedIDList.AddRange(ids);
                        break;
                    }
                case ERequestType.Save:
                    {
                        t_Competition t_c;
                        if (request.RequestParameters.Competition.ID > 0)
                        {
                            t_c = db.t_Competitions.Single(p => p.ID == request.RequestParameters.Competition.ID);
                            db.t_Competition_Groups.DeleteAllOnSubmit(db.t_Competition_Groups.Where(p => p.ID_Competition == request.RequestParameters.Competition.ID));
                            db.SubmitChanges();
                        }
                        else
                        {
                            t_c = new t_Competition();
                            db.t_Competitions.InsertOnSubmit(t_c);
                        }
                        t_c.Name = request.RequestParameters.Competition.Name;
                        t_c.ID_Parcour = request.RequestParameters.Competition.ID_Parcour;
                        t_c.ID_TakeOffLine = request.RequestParameters.Competition.ID_TakeOffLine;
                        t_c.TimeEndLine = request.RequestParameters.Competition.TimeEndLine;
                        t_c.TimeStartLine = request.RequestParameters.Competition.TimeStartLine;
                        t_c.TimeTakeOff = request.RequestParameters.Competition.TimeTakeOff;
                        db.SubmitChanges();

                        foreach (CompetitionGroup cg in request.RequestParameters.Competition.CompetitionGroupList)
                        {
                            if (db.t_Competition_Groups.Count(p => p.ID_Competition == t_c.ID && p.ID_Group == cg.ID_Group) == 0)
                            {
                                t_Competition_Group tcg = new t_Competition_Group();
                                tcg.ID_Group = cg.ID_Group;
                                tcg.ID_Competition = t_c.ID;
                                tcg.Pos = cg.Pos;
                                db.t_Competition_Groups.InsertOnSubmit(tcg);
                            }
                        }
                        db.SubmitChanges();
                        r.ResponseParameters = new ResponseParameters();
                        r.ResponseParameters.ID = t_c.ID;
                        break;
                    }
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
