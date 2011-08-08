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
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
        }
        public AnrlClient(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            db = new AnrlDB.AnrlDataContext(ConnectionString);
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
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

        public List<IPicture> getPictures(bool flag)
        {
            List<IPicture> result = new List<IPicture>();
            foreach (t_Picture pic in db.t_Pictures.Where(p=>p.isFlag==flag))
            {
                result.Add(new Picture(pic));
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

        public List<IParcour> getParcours()
        {
            List<IParcour> result = new List<IParcour>();
            foreach (t_Parcour parcour in db.t_Parcours)
            {
                result.Add(new Parcour(parcour));
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

                        t_Team dbTeam;
                        if (team.ID < 0)
                        {
                            dbTeam = new t_Team();
                        }
                        else
                        {
                            dbTeam = db.t_Teams.Single(p => p.ID == team.ID);
                        }
                        dbTeam.t_Pilot = pilot;
                        dbTeam.t_Pilot1 = navigator;
                        dbTeam.t_Picture = flag;
                        dbTeam.t_Tracker = tracker;
                        dbTeam.Color = team.Color;
                        if (team.ID < 0)
                        {
                            db.t_Teams.InsertOnSubmit(dbTeam);
                        }
                        db.SubmitChanges();
                        result = dbTeam.ID;
                    }
                }
            }
            catch (Exception ex) { 
                result = -2; 
                System.Console.Out.WriteLine(ex.ToString()); 
            }
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



        public long addParcour(IParcour parcour)
        {
            long result = -1;
            try
            {
                if (parcour != null &&
                    parcour.ID < 0 )
                {
                    t_Parcour dbParcour = new t_Parcour();
                    db.t_Parcours.InsertOnSubmit(dbParcour);
                    db.SubmitChanges();
                    result = dbParcour.ID;
                    foreach (ILine line in parcour.Lines)
                    {
                        t_Line dbLine = new t_Line();
                        t_GPSPoint a = getDBPoint(line.PointA);
                        db.t_GPSPoints.InsertOnSubmit(a);
                        t_GPSPoint b = getDBPoint(line.PointB);
                        db.t_GPSPoints.InsertOnSubmit(b);
                        t_GPSPoint o = getDBPoint(line.PointOrientation);
                        db.t_GPSPoints.InsertOnSubmit(o);
                        db.SubmitChanges();
                        dbLine.ID_PointA = a.ID;
                        dbLine.ID_PointB = b.ID;
                        dbLine.ID_PointOrientation = o.ID;
                        dbLine.Type = (int)line.LineType;
                        db.t_Lines.InsertOnSubmit(dbLine);
                        db.SubmitChanges();
                        t_Parcour_Line pl = new t_Parcour_Line();
                        pl.ID_Line = dbLine.ID;
                        pl.ID_Parcour = dbParcour.ID;
                        db.t_Parcour_Lines.InsertOnSubmit(pl);
                        db.SubmitChanges();
                    }
                }
            }
            catch { result = -2; }
            return result;
        }

        private static t_GPSPoint getDBPoint(IGPSPoint pointA)
        {
            t_GPSPoint a = new t_GPSPoint();
            a.altitude = pointA.Altitude;
            a.latitude = pointA.Latitude;
            a.longitude = pointA.Longitude;
            return a;
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

        public List<IMap> getMaps()
        {
            List<IMap> result = new List<IMap>();
            foreach (t_Map map in db.t_Maps)
            {
                result.Add(new Map(map));
            }
            return result;
        }

        public long addMap(IMap map)
        {
            long result = -1;
            try
            {
                if (map != null &&
                    map.Name.Length > 2 &&
                    map.Picture != null)
                {
                    if (map.ID <= 0)
                    {
                        t_Map m = new t_Map();
                        m.Name = map.Name;
                       /* m.XRot = new Decimal(map.XRot);
                        m.YRot = new Decimal(map.YRot);
                        m.XSize = new Decimal(map.XSize);
                        m.YSize = new Decimal(map.YSize);
                        m.XTopLeft= new Decimal(map.XTopLeft);
                        m.YTopLeft = new Decimal(map.YTopLeft);*/
                        t_Picture picture;
                        if (map.Picture.ID <= 0)
                        {
                            picture = new t_Picture();
                            picture.Data = new System.Data.Linq.Binary(map.Picture.Image);
                            db.t_Pictures.InsertOnSubmit(picture);
                            db.SubmitChanges();
                        }
                        else
                        {
                            picture = db.t_Pictures.Single(pp => pp.ID == map.Picture.ID);
                        }
                        m.t_Picture = picture;
                        db.t_Maps.InsertOnSubmit(m);
                        db.SubmitChanges();
                        result = m.ID;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine(ex.StackTrace);
                result = -2;
            }
            return result;
        }

        public bool removeMap(long id)
        {
            bool result = false;
            try
            {
                db.t_Maps.DeleteOnSubmit(db.t_Maps.Single(p => p.ID == id));
                db.SubmitChanges();
                result = true;
            }
            catch
            {
            }
            return result;
        }

        public bool removeParcour(long id)
        {
            bool result = false;
            try
            {
                // TODO remove lines
                db.t_Parcours.DeleteOnSubmit(db.t_Parcours.Single(p => p.ID == id));
                db.SubmitChanges();
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
