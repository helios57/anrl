using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlService.Server.Impl;
using System.IO;
using System.Data.EntityClient;
using System.Data.SqlClient;
using AnrlDB;

namespace AnrlService.Server
{
    class AnrlClient : MarshalByRefObject, IAnrlClient
    {
        private string ConnectionString;
        AnrlDB.AnrlDataContext db;

        public AnrlClient()
        {
            db = new AnrlDB.AnrlDataContext();
        }
        public AnrlClient(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            db = new AnrlDB.AnrlDataContext(ConnectionString);
        }

        #region IAnrlClient Members

        public List<ITracker> getTrackers()
        {
            List<ITracker> result = new List<ITracker>();
            foreach (t_Tracker tracker in db.t_Trackers)
            {
                result.Add(new Tracker(tracker));
            }
            return result;
        }

        public List<IPilot> getPilots()
        {
            List<IPilot> result = new List<IPilot>();
            foreach (t_Pilot pilot in db.t_Pilots)
            {
                result.Add(new Pilot(pilot));
            }
            return result;
        }

        public List<ITeam> getTeams()
        {
            List<ITeam> result = new List<ITeam>();
            foreach (t_Team team in db.t_Teams)
            {
                result.Add(new Team(team));
            }
            return result;
        }

        public List<IRace> getRaces()
        {
            List<IRace> result = new List<IRace>();
            foreach (t_Race race in db.t_Races)
            {
                result.Add(new Race(race));
            }
            return result;
        }

        public List<IPenaltyZone> getPenaltyzones()
        {
            List<IPenaltyZone> result = new List<IPenaltyZone>();
            foreach (t_PenaltyZone penaltyZone in db.t_PenaltyZones)
            {
                result.Add(new PenaltyZone(penaltyZone));
            }
            return result;
        }

        public List<IData> getData(List<ITracker> trackers, DateTime from, DateTime to)
        {
            List<IData> result = new List<IData>();
            foreach (t_Daten data in db.t_Datens.Where(p => p.Timestamp >= from && p.Timestamp <= to))
            {
                result.Add(new Data(data));
            }
            return result;
        }

        public long addPilot(IPilot pilot)
        {
            long result = -1;
            try
            {
                if (pilot != null && 
                    pilot.Name.Length > 2 && 
                    pilot.Surename.Length > 2 && 
                    pilot.Picture != null && 
                    pilot.Picture.Image != null)
                {
                    if (pilot.ID <= 0)
                    {
                        t_Pilot p = new t_Pilot();
                        p.LastName = pilot.Name;
                        p.SureName = pilot.Surename;
                        t_Picture picture;
                        if (pilot.Picture.ID <= 0)
                        {
                            picture = new t_Picture(); 
                            picture.Data = new System.Data.Linq.Binary(pilot.Picture.Image);
                            db.t_Pictures.InsertOnSubmit(picture);
                            db.SubmitChanges();
                        }
                        else
                        {
                            picture = db.t_Pictures.Single(pp => pp.ID == pilot.Picture.ID);
                        }
                        p.t_Picture = picture;
                        db.t_Pilots.InsertOnSubmit(p);
                        db.SubmitChanges();
                        result = p.ID;
                    }
                    else
                    {
                        t_Pilot p = db.t_Pilots.Single(pp => pp.ID == pilot.ID);
                        p.LastName = pilot.Name;
                        p.SureName = pilot.Surename;
                        t_Picture picture;
                        if (pilot.Picture.ID <= 0)
                        {
                            picture = new t_Picture();
                            picture.Data = new System.Data.Linq.Binary(pilot.Picture.Image);
                            db.t_Pictures.InsertOnSubmit(picture);
                            db.SubmitChanges();
                        }
                        else
                        {
                            picture = db.t_Pictures.Single(pp => pp.ID == pilot.Picture.ID);
                        }
                        p.t_Picture = picture;
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex) { 
                System.Console.Out.WriteLine(ex.StackTrace);
                result = -2;
            }
            return result;
        }

        public long addTeam(ITeam team)
        {
            long result = -1;
            try
            {
                if (team != null && 
                    team.ID < 0 && 
                    team.Pilot != null && 
                    team.Pilot.ID > 0 &&
                    team.Color != null && 
                    team.FlagPicture != null && 
                    team.FlagPicture.ID >0)
                {
                    t_Pilot pilot = db.t_Pilots.Single(p => p.ID == team.Pilot.ID);
                    if (pilot != null)
                    {
                        t_Pilot navigator = null;
                        if (team.Navigator != null && team.Navigator.ID > 0)
                        {
                            navigator = db.t_Pilots.Single(p => p.ID == team.Navigator.ID);
                        }
                        t_Picture flag = db.t_Pictures.Single(p => p.ID == team.FlagPicture.ID && p.isFlag);

                        t_Tracker tracker = null;
                        if (team.Tracker != null && team.Tracker.ID > 0)
                        {
                            tracker = db.t_Trackers.Single(p=>p.ID == team.Tracker.ID);
                        }
                        t_Team dbTeam = new t_Team();
                        dbTeam.t_Pilot = pilot;
                        dbTeam.t_Pilot1 = navigator;
                        dbTeam.t_Picture = flag;
                        dbTeam.t_Tracker = tracker;
                        dbTeam.Color = team.Color;
                        db.t_Teams.InsertOnSubmit(dbTeam);
                        db.SubmitChanges();
                        result = dbTeam.ID;
                    }
                }
            }
            catch { result = -2; }
            return result;
        }

        public long addRace(IRace race)
        {
            long result = -1;
            try
            {
                if( race != null && 
                    race.ID < 0 && 
                    race.Teams != null && 
                    race.Start != null &&
                    race.End != null && 
                    race.TakeOff != null &&
                    race.PenaltyZone != null &&
                    race.PenaltyZone.ID > 0)
                {
                    List<t_Team> teams = new List<t_Team>();
                    bool teamsOk = true;
                    foreach (ITeam team in race.Teams)
                    {
                        if (team.ID > 0)
                        {
                            teams.Add(db.t_Teams.Single(p => p.ID == team.ID));
                        }
                        else
                        {
                            teamsOk = false;
                            break;
                        }
                    }
                    if (teamsOk)
                    {
                        t_PenaltyZone penaltyZone = db.t_PenaltyZones.Single(p => p.ID == race.PenaltyZone.ID);
                        if (penaltyZone != null)
                        {
                            t_Race dbRace = new t_Race();
                            dbRace.Name = race.Name;
                            dbRace.t_PenaltyZone = penaltyZone;
                            dbRace.TakeOff = race.TakeOff;
                            dbRace.TimeEnd = race.End;
                            dbRace.TimeStart = race.Start;
                            db.t_Races.InsertOnSubmit(dbRace);
                            db.SubmitChanges();
                            foreach (t_Team team in teams)
                            {
                                t_Race_Team rt = new t_Race_Team();
                                rt.t_Race = dbRace;
                                rt.t_Team = team;
                                db.t_Race_Teams.InsertOnSubmit(rt);
                            }
                            db.SubmitChanges();
                            result = dbRace.ID;
                        }
                    }
                }
            }
            catch { result = -2; }
            return result;
        }

        public long addPenaltyZone(IPenaltyZone penaltyzone)
        {
            long result = -1;
            try
            {
                if (penaltyzone != null &&
                    penaltyzone.ID < 0 &&
                    penaltyzone.Name.Length > 2 &&
                    penaltyzone.Polygons != null &&
                    penaltyzone.Polygons.Count > 0)
                {
                    List<t_PenaltyZonePolygon> polygons = new List<t_PenaltyZonePolygon>();
                    List<t_PenaltyZonePoint> points = new List<t_PenaltyZonePoint>();

                    bool allOk = true;
                    foreach (IPenaltyPolygon polygon in penaltyzone.Polygons)
                    {
                        if (polygon.ID < 0 && polygon.Points != null)
                        {
                            t_PenaltyZonePolygon dbPoly = new t_PenaltyZonePolygon();
                            foreach (IPenaltyPoint point in polygon.Points)
                            {
                                if (point.ID < 0)
                                {
                                    t_PenaltyZonePoint dbPoint = new t_PenaltyZonePoint();
                                    dbPoint.longitude = point.Longitude;
                                    dbPoint.latitude = point.Latitude;
                                    dbPoint.altitude = point.Altitude;
                                    dbPoint.t_PenaltyZonePolygon = dbPoly;
                                    points.Add(dbPoint);
                                }
                                else
                                {
                                    allOk = false;
                                    break;
                                }
                            }
                            polygons.Add(dbPoly);
                        }
                        else
                        {
                            allOk = false;
                            break;
                        }
                    }
                    if (allOk)
                    {
                        t_PenaltyZone dbZone = new t_PenaltyZone();
                        dbZone.Name = penaltyzone.Name;
                        db.t_PenaltyZones.InsertOnSubmit(dbZone);
                        db.SubmitChanges();
                        foreach (t_PenaltyZonePolygon poly in polygons)
                        {
                            poly.t_PenaltyZone = dbZone;
                            db.t_PenaltyZonePolygons.InsertOnSubmit(poly);
                        }
                        db.SubmitChanges();
                        foreach (t_PenaltyZonePoint point in points)
                        {
                            db.t_PenaltyZonePoints.InsertOnSubmit(point);
                        }
                        db.SubmitChanges();
                        result = dbZone.ID;
                    }
                }
            }
            catch { result = -2; }
            return result;
        }

        public long addPicture(IPicture picture, Boolean isFlag)
        {      
            long result = -1;
            try
            {
                if (picture != null &&
                    picture.ID < 0 &&
                    picture.Image != null)
                {
                    t_Picture dbPicture = new t_Picture();
                    dbPicture.Data = new System.Data.Linq.Binary(picture.Image);
                    dbPicture.isFlag = isFlag;
                    db.t_Pictures.InsertOnSubmit(dbPicture);
                    db.SubmitChanges();
                    result = dbPicture.ID;
                }
            }
            catch { result = -2; }
            return result;
        }

        public bool removePilot(long id)
        {
            bool result = false;
            try
            {
                db.t_Pilots.DeleteOnSubmit(db.t_Pilots.Single(p => p.ID == id));
                db.SubmitChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool removeTeam(long id)
        {
            bool result = false;
            try
            {
                db.t_Teams.DeleteOnSubmit(db.t_Teams.Single(p => p.ID == id));
                db.SubmitChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool removeRace(long id)
        {
            bool result = false;
            try
            {
                db.t_Races.DeleteOnSubmit(db.t_Races.Single(p => p.ID == id));
                db.SubmitChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool removePenaltyZone(long id)
        {
            bool result = false;
            try
            {
                t_PenaltyZone zone = db.t_PenaltyZones.Single(p => p.ID == id);
                foreach (t_PenaltyZonePolygon poly in zone.t_PenaltyZonePolygons)
                {
                    foreach (t_PenaltyZonePoint point in poly.t_PenaltyZonePoints)
                    {
                        db.t_PenaltyZonePoints.DeleteOnSubmit(point);
                    }
                    db.t_PenaltyZonePolygons.DeleteOnSubmit(poly);
                }
                db.t_PenaltyZones.DeleteOnSubmit(zone);
                db.SubmitChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool removePicture(long id)
        {
            bool result = false;
            try
            {
                db.t_Pictures.DeleteOnSubmit(db.t_Pictures.Single(p => p.ID == id));
                db.SubmitChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool addName(ITracker tracker)
        {
            bool result = false;
            try
            {
                t_Tracker t = db.t_Trackers.Single(p => p.ID == tracker.ID);
                if (t != null)
                {
                    t.Name = tracker.Name;
                    db.SubmitChanges();
                    result = true;
                }
            }
            catch { }

            return result;
        }

        #endregion
    }
}
