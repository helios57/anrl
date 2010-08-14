using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDBAccessors;
using AnrlService.Server.Impl;
using System.IO;

namespace AnrlService.Server
{
    class AnrlClient : IAnrlClient
    {
        private string ConnectionString;
        AnrlDBAccessors.AnrlDBEntities db;

        public AnrlClient(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            db = new AnrlDBAccessors.AnrlDBEntities(ConnectionString);
        }

        #region IAnrlClient Members

        public List<ITracker> getTrackers()
        {
            List<ITracker> result = new List<ITracker>();
            foreach (t_Tracker tracker in db.t_Tracker)
            {
                result.Add(new Tracker(tracker));
            }
            return result;
        }

        public List<IPilot> getPilots()
        {
            List<IPilot> result = new List<IPilot>();
            foreach (t_Pilot pilot in db.t_Pilot)
            {
                result.Add(new Pilot(pilot));
            }
            return result;
        }

        public List<ITeam> getTeams()
        {
            List<ITeam> result = new List<ITeam>();
            foreach (t_Team team in db.t_Team)
            {
                result.Add(new Team(team));
            }
            return result;
        }

        public List<IRace> getRaces()
        {
            List<IRace> result = new List<IRace>();
            foreach (t_Race race in db.t_Race)
            {
                result.Add(new Race(race));
            }
            return result;
        }

        public List<IPenaltyZone> getPenaltyzones()
        {
            List<IPenaltyZone> result = new List<IPenaltyZone>();
            foreach (t_PenaltyZone penaltyZone in db.t_PenaltyZone)
            {
                result.Add(new PenaltyZone(penaltyZone));
            }
            return result;
        }

        public List<IData> getData(List<ITracker> trackers, DateTime from, DateTime to)
        {
            List<IData> result = new List<IData>();
            foreach (t_Daten data in db.t_Daten.Where(p => p.Timestamp >= from && p.Timestamp <= to))
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
                    pilot.ID < 0 && 
                    pilot.Name.Length > 2 && 
                    pilot.Surename.Length > 2 && 
                    pilot.Picture != null && 
                    pilot.Picture.Image != null)
                {
                    t_Pilot p = new t_Pilot();
                    p.LastName = pilot.Name;
                    p.SureName = pilot.Surename;
                    t_Picture picture;
                    if (pilot.Picture.ID < 0)
                    {
                        MemoryStream ms = new MemoryStream();
                        pilot.Picture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        picture = new t_Picture();
                        picture.Data = ms.ToArray();
                        ms.Close();
                        db.AddTot_Picture(picture);
                        db.SaveChanges();
                    }
                    else
                    {
                        picture = db.t_Picture.Single(pp => pp.ID == pilot.Picture.ID);
                    }
                    p.t_Picture = picture;
                    db.AddTot_Pilot(p);
                    db.SaveChanges();
                    result = p.ID;
                }
            }
            catch { result = -2; }
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
                    t_Pilot pilot = db.t_Pilot.Single(p => p.ID == team.Pilot.ID);
                    if (pilot != null)
                    {
                        t_Pilot navigator = null;
                        if (team.Navigator != null && team.Navigator.ID > 0)
                        {
                            navigator = db.t_Pilot.Single(p => p.ID == team.Navigator.ID);
                        }
                        t_Picture flag = db.t_Picture.Single(p => p.ID == team.FlagPicture.ID && p.isFlag);

                        t_Tracker tracker = null;
                        if (team.Tracker != null && team.Tracker.ID > 0)
                        {
                            tracker = db.t_Tracker.Single(p=>p.ID == team.Tracker.ID);
                        }
                        t_Team dbTeam = new t_Team();
                        dbTeam.t_Pilot = pilot;
                        dbTeam.t_Navigator = navigator;
                        dbTeam.t_Picture = flag;
                        dbTeam.t_Tracker = tracker;
                        dbTeam.Color = team.Color;
                        db.AddTot_Team(dbTeam);
                        db.SaveChanges();
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
                            teams.Add(db.t_Team.Single(p => p.ID == team.ID));
                        }
                        else
                        {
                            teamsOk = false;
                            break;
                        }
                    }
                    if (teamsOk)
                    {
                        t_PenaltyZone penaltyZone = db.t_PenaltyZone.Single(p => p.ID == race.PenaltyZone.ID);
                        if (penaltyZone != null)
                        {
                            t_Race dbRace = new t_Race();
                            dbRace.Name = race.Name;
                            dbRace.t_PenaltyZone = penaltyZone;
                            dbRace.TakeOff = race.TakeOff;
                            dbRace.TimeEnd = race.End;
                            dbRace.TimeStart = race.Start;
                            db.AddTot_Race(dbRace);
                            db.SaveChanges();
                            foreach (t_Team team in teams)
                            {
                                t_Race_Team rt = new t_Race_Team();
                                rt.t_Race = dbRace;
                                rt.t_Team = team;
                                db.AddTot_Race_Team(rt);
                            }
                            db.SaveChanges();
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
                        db.AddTot_PenaltyZone(dbZone);
                        db.SaveChanges();
                        foreach (t_PenaltyZonePolygon poly in polygons)
                        {
                            poly.t_PenaltyZone = dbZone;
                            db.AddTot_PenaltyZonePolygon(poly);
                        }
                        db.SaveChanges();
                        foreach (t_PenaltyZonePoint point in points)
                        {
                            db.AddTot_PenaltyZonePoint(point);
                        }
                        db.SaveChanges();
                        result = dbZone.ID;
                    }
                }
            }
            catch { result = -2; }
            return result;
        }

        public long addPicture(IPicture picture)
        {      
            long result = -1;
            try
            {
                if (picture != null &&
                    picture.ID < 0 &&
                    picture.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    picture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    t_Picture dbPicture = new t_Picture();
                    dbPicture.Data = ms.ToArray();
                    dbPicture.isFlag = false;
                    ms.Close();
                    db.AddTot_Picture(dbPicture);
                    db.SaveChanges();
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
                db.DeleteObject(db.t_Pilot.Single(p => p.ID == id));
                db.SaveChanges();
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
                db.DeleteObject(db.t_Team.Single(p => p.ID == id));
                db.SaveChanges();
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
                db.DeleteObject(db.t_Race.Single(p => p.ID == id));
                db.SaveChanges();
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
                t_PenaltyZone zone = db.t_PenaltyZone.Single(p => p.ID == id);
                foreach (t_PenaltyZonePolygon poly in zone.t_PenaltyZonePolygon)
                {
                    foreach (t_PenaltyZonePoint point in poly.t_PenaltyZonePoint)
                    {
                        db.DeleteObject(point);
                    }
                    db.DeleteObject(poly);
                }
                db.DeleteObject(zone);
                db.SaveChanges();
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
                db.DeleteObject(db.t_Picture.Single(p => p.ID == id));
                db.SaveChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        #endregion
    }
}
