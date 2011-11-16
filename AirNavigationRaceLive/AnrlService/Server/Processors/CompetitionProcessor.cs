using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class CompetitionProcessor : AnrlService.Server.Processors.AProcessor<t_Competition,Competition>
    {

        protected override Func<t_Competition, bool> getSingleSelection(int ID)
        {
            return p => p.ID == ID;
        }

        protected override System.Data.Linq.Table<t_Competition> getTable(AnrlDataContext db)
        {
            return db.t_Competitions;
        }

        protected override Competition getNetworkObject(t_Competition input)
        {
            Competition result = new Competition();
            result.ID = input.ID;
            result.ID_Parcour = input.ID_Parcour;
            result.Name = input.Name;
            result.ID_CompetitonSet = input.ID_CompetitionSet;

            Line l = new Line();
            l.A = new Point();
            CopyAttributes(input.t_Line.t_GPSPoint, l.A);
            l.B = new Point();
            CopyAttributes(input.t_Line.t_GPSPoint1, l.B);
            l.O = new Point();
            CopyAttributes(input.t_Line.t_GPSPoint2, l.O);
            result.TakeOffLine = l;

            foreach (t_Competition_Team d_c_t in input.t_Competition_Teams)
            {
                CompetitionTeam ct = new CompetitionTeam();
                ct.ID = d_c_t.ID;
                ct.ID_Competition = d_c_t.ID_Competition;
                ct.ID_Team = d_c_t.ID_Team;
                ct.Route = d_c_t.Route;
                ct.StartID = d_c_t.StartID;
                ct.TimeEndLine = d_c_t.TimeEnd;
                ct.TimeStartLine = d_c_t.TimeStart;
                ct.TimeTakeOff = d_c_t.TimeTakeOff;

                foreach (t_Team_Tracker tt in d_c_t.t_Team_Trackers)
                {
                    ct.ID_TrackerList.Add(tt.ID_Tracker);
                }

                result.CompetitionTeamList.Add(ct);
            }
            return result;
        }

        protected override t_Competition getDBObject(Competition input)
        {
            throw new NotImplementedException();
        }

        protected override void Save(Root request, Root r)
        {
            AnrlDataContext db = getDB();
            t_Competition t_c;
            t_Line line;

            t_GPSPoint a;
            t_GPSPoint b;
            t_GPSPoint o;

            if (request.RequestParameters.Competition.ID > 0)
            {
                lock (cached)
                {
                    cached.RemoveAll(p => p.ID == request.RequestParameters.Competition.ID);
                }
                t_c = db.t_Competitions.Single(p => p.ID == request.RequestParameters.Competition.ID);
                db.t_Team_Trackers.DeleteAllOnSubmit(db.t_Team_Trackers.Where(p => p.t_Competition_Team.ID_Competition == request.RequestParameters.Competition.ID));
                db.t_Competition_Teams.DeleteAllOnSubmit(db.t_Competition_Teams.Where(p => p.ID_Competition == request.RequestParameters.Competition.ID));
                db.SubmitChanges();
                line = t_c.t_Line;
                a = line.t_GPSPoint;
                b = line.t_GPSPoint1;
                o = line.t_GPSPoint2;
            }
            else
            {
                a = new t_GPSPoint();
                b = new t_GPSPoint();
                o = new t_GPSPoint();

                db.t_GPSPoints.InsertOnSubmit(a);
                db.t_GPSPoints.InsertOnSubmit(b);
                db.t_GPSPoints.InsertOnSubmit(o);
                db.SubmitChanges();

                line = new t_Line();
                db.t_Lines.InsertOnSubmit(line);
                line.ID_PointA = a.ID;
                line.ID_PointB = b.ID;
                line.ID_PointOrientation = o.ID;
                line.Type = (int)LineType.TakeOff;
                db.SubmitChanges();

                t_c = new t_Competition();
                db.t_Competitions.InsertOnSubmit(t_c);
                t_c.ID_TakeOffLine = line.ID;
            }
            t_c.Name = request.RequestParameters.Competition.Name;
            t_c.ID_Parcour = request.RequestParameters.Competition.ID_Parcour;
            t_c.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;

            CopyAttributesWithoutId(request.RequestParameters.Competition.TakeOffLine.A, a);

            CopyAttributesWithoutId(request.RequestParameters.Competition.TakeOffLine.B, b);

            CopyAttributesWithoutId(request.RequestParameters.Competition.TakeOffLine.O, o);


            db.SubmitChanges();

            foreach (CompetitionTeam ct in request.RequestParameters.Competition.CompetitionTeamList)
            {
                if (db.t_Competition_Teams.Count(p => p.ID_Competition == t_c.ID && p.ID == ct.ID) == 0)
                {
                    t_Competition_Team tcg = new t_Competition_Team();
                    tcg.ID_Team = ct.ID_Team;
                    tcg.ID_Competition = t_c.ID;
                    tcg.Route = ct.Route;
                    tcg.StartID = ct.StartID;
                    tcg.TimeEnd = ct.TimeEndLine;
                    tcg.TimeStart = ct.TimeStartLine;
                    tcg.TimeTakeOff = ct.TimeTakeOff;
                    tcg.ID_CompetitionSet = request.AuthInfo.ID_CompetitionSet;
                    db.t_Competition_Teams.InsertOnSubmit(tcg);
                    db.SubmitChanges();
                    foreach (int i in ct.ID_TrackerList)
                    {
                        t_Team_Tracker ttt = new t_Team_Tracker();
                        ttt.ID_Competition_Team = tcg.ID;
                        ttt.ID_Tracker = i;
                        db.t_Team_Trackers.InsertOnSubmit(ttt);
                    }
                }
            }
            db.SubmitChanges();
            lock (cached)
            {
                cached.Add(getNetworkObject(t_c));
            }
            db.Dispose();
            reloadCacheThreated();//Hack to avoid empty competitions
            r.ResponseParameters = new ResponseParameters();
            r.ResponseParameters.ID = t_c.ID;
        }

        protected override int GetID(Competition input)
        {
            return input.ID;
        }

        protected override int GetID(t_Competition input)
        {
            return input.ID;
        }

        protected override bool CheckCompetitionSet(int id_competitionSet, Competition Obj)
        {
            return id_competitionSet == Obj.ID_CompetitonSet;
        }

        protected override void AddToResponseList(Root response, Competition obj)
        {
            response.ResponseParameters.CompetitionList.Add(obj);
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
        private static void CopyAttributesWithoutId(t_GPSPoint gp, Point p)
        {
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }
        private static void CopyAttributesWithoutId(Point gp, t_GPSPoint p)
        {
            p.altitude = gp.altitude;
            p.latitude = gp.latitude;
            p.longitude = gp.longitude;
        }

    }
}
