using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace DataService
{
    /// <summary>
    /// Interface implementation for the WCF-Communication
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single )]   
    public class ANRLDataService : IANRLDataService
    {
        /// <summary>
        /// Starting an new Instance of the Webservice 
        /// </summary>
        /// <param name="DB_Path">path to the current DB</param>
        public ANRLDataService(String DB_Path)
        {
            this.DB_PATH = DB_Path;
        }
        String DB_PATH;
        #region IANRLDataService Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IntervallStart"></param>
        /// <param name="IntervallEnd"></param>
        /// <returns></returns>
        public List<t_Daten> GetPathData(DateTime IntervallStart, DateTime IntervallEnd)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetPathData", IntervallStart.ToString() + " " + IntervallEnd.CompareTo(dataContext.t_Datens.Max(p => p.Timestamp)));
            //     if ()
            {

            }

            List<t_Daten> tmp = new List<t_Daten>();

            t_Daten tmp_t_Daten = new t_Daten();
            foreach (t_Daten t in dataContext.t_Datens.Where(d => d.Timestamp >= IntervallStart && d.Timestamp < IntervallEnd))
            {
                tmp_t_Daten.ID = t.ID;
                tmp_t_Daten.Timestamp = t.Timestamp;
                tmp_t_Daten.Latitude = t.Latitude;
                tmp_t_Daten.Longitude = t.Longitude;
                tmp_t_Daten.Altitude = t.Altitude;
                tmp_t_Daten.Speed = t.Speed;
                tmp_t_Daten.Penalty = t.Penalty;
                tmp_t_Daten.ID_Polygon = t.ID_Polygon;
                tmp_t_Daten.ID_Tracker = t.ID_Tracker;
                tmp.Add(tmp_t_Daten);
            }
            return tmp;
        }

        /// <summary>
        /// Get All Timestamps of recorsd in the DB for Delay
        /// </summary>
        /// <returns>List of Datetime Timestamps</returns>
        public List<DateTime> GetTimestamps()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetTimestamps", "");
            List<DateTime> timestamplist = new List<DateTime>();
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Daten row in dataContext.t_Datens)
            {
                timestamplist.Add((DateTime)row.Timestamp);
            }
            return timestamplist;
        }


        /// <summary>
        /// List of all PolygonPoints
        /// </summary>
        /// <returns>List of PolygonPoints</returns>
        public List<t_PolygonPoint> GetPolygons()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetPolygons", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);

            List<t_PolygonPoint> tmp = new List<t_PolygonPoint>();

            t_PolygonPoint tmp_t_PolygonPoint;

            foreach (t_PolygonPoint t in dataContext.t_PolygonPoints)
            {
                tmp_t_PolygonPoint = new t_PolygonPoint();
                tmp_t_PolygonPoint.ID = t.ID;
                tmp_t_PolygonPoint.latitude = t.latitude;
                tmp_t_PolygonPoint.altitude = t.altitude;
                tmp_t_PolygonPoint.longitude = t.longitude;
                tmp_t_PolygonPoint.ID_Polygon = t.ID_Polygon;
                tmp.Add(tmp_t_PolygonPoint);
            }
            return tmp;
        }
        /// <summary>
        /// Return a list of all Trackers
        /// </summary>
        /// <returns>List of Trackers</returns>
        public List<t_Tracker> GetTrackers()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetTrackers", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_Tracker> lstTrackers = new List<t_Tracker>();
            foreach (t_Tracker t in dataContext.t_Trackers)
            {
                t_Tracker tle = new t_Tracker();
                tle.ID = t.ID;
                tle.IMEI = t.IMEI.Trim();
                lstTrackers.Add(tle);
            }
            return lstTrackers;
        }
        /// <summary>
        /// Return a list of all Airplanes
        /// </summary>
        /// <returns>List of Airplanes</returns>
        public List<t_Pilot> GetPilots()
        {

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetAirplanes", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_Pilot> tmp = new List<t_Pilot>();
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == 0))
            {
                t_Pilot pilo = new t_Pilot();
                pilo.ID = f.ID;
                pilo.ID_Tracker = f.ID_Tracker;
                pilo.LastName = f.LastName;
                pilo.SureName = f.SureName;
                pilo.Color = f.Color;
                tmp.Add(pilo);
            }
            return tmp;
        }

        /// <summary>
        /// Return a list of all Racecs
        /// </summary>
        /// <returns>List of Racecs</returns>
        public List<t_Race> GetRaces()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetRaces", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_Race> tmp = new List<t_Race>();
            foreach (t_Race r in dataContext.t_Races)
            {
                t_Race race = new t_Race();
                race.ID = r.ID;
                race.ID_Pilot_0 = r.ID_Pilot_0;
                race.ID_Pilot_1 = r.ID_Pilot_1;
                race.ID_Pilot_2 = r.ID_Pilot_2;
                race.ID_Pilot_3 = r.ID_Pilot_3;
                race.ID_PolygonGroup = r.ID_PolygonGroup;
                race.Name = r.Name;
                race.TimeEnd = r.TimeEnd;
                race.TimeStart = r.TimeStart;
                race.t_PolygonGroup = new t_PolygonGroup();
                race.t_PolygonGroup.ID = r.t_PolygonGroup.ID;
                race.t_PolygonGroup.Name = r.t_PolygonGroup.Name;
                tmp.Add(race);
            }
            return tmp;
        }

        /// <summary>
        /// Return a list of all Racecs
        /// </summary>
        /// <returns>List of Racecs</returns>
        public List<t_PolygonGroup> GetPolygonGroup()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetParcours", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_PolygonGroup> tmp = new List<t_PolygonGroup>();
            foreach (t_PolygonGroup pg in dataContext.t_PolygonGroups)
            {
                t_PolygonGroup tmppg = new t_PolygonGroup();
                tmppg.ID = pg.ID;
                tmppg.Name = pg.Name;
                tmp.Add(tmppg);
            }
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID_PolygonGroup"></param>
        /// <returns></returns>
        public List<t_Polygon> GetPolygonsByGroup(int ID_PolygonGroup)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_Polygon> Result = new List<t_Polygon>();
            foreach (t_Polygon p in dataContext.t_Polygons.Where(p => p.ID_PolygonGroup == ID_PolygonGroup))
            {
                t_Polygon tmp = new t_Polygon();
                tmp.ID = p.ID;
                tmp.ID_PolygonGroup = p.ID_PolygonGroup;
                tmp.Type = p.Type;
                Result.Add(tmp);
            }
            return Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID_Polygon"></param>
        /// <returns></returns>
        public List<t_PolygonPoint> GetPolygonPoints(int ID_Polygon)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_PolygonPoint> Result = new List<t_PolygonPoint>();
            foreach (t_PolygonPoint p in dataContext.t_PolygonPoints.Where(p => p.ID_Polygon == ID_Polygon))
            {
                t_PolygonPoint tmp = new t_PolygonPoint();
                tmp.ID = p.ID;
                tmp.ID_Polygon = p.ID_Polygon;
                tmp.latitude = p.latitude;
                tmp.longitude = p.longitude;
                tmp.altitude = p.altitude;
                Result.Add(tmp);
            }
            return Result;
        }

        /// <summary>
        /// Remove the Race
        /// </summary>
        /// <param name="Race_ID">Remove Race</param>
        /// <returns></returns>
        public void RemoveRace(int Race_ID)
        {
            try
            {
                LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:RemoveRace", Race_ID.ToString());
                DatabaseDataContext context = new DatabaseDataContext(DB_PATH);
                context.t_Races.DeleteOnSubmit(context.t_Races.Single(p => p.ID == Race_ID));
                context.SubmitChanges();
            }
            catch
            {
                LogManager.AddLog(DB_PATH, 0, "ANRLDataService.svc.cs:RemoveRace", Race_ID.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Race"></param>
        public void AddRace(t_Race Race)
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:AddRace", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<t_PolygonPoint> Points = new List<t_PolygonPoint>();
            List<t_Polygon> Polygons = new List<t_Polygon>();
            t_PolygonGroup PolygonGroup = new t_PolygonGroup();
            try
            {
                #region Polygongroup & Polygons & PolygonPoints
                if (Race.t_PolygonGroup != null)
                {
                    PolygonGroup.Name = Race.t_PolygonGroup.Name;
                    dataContext.t_PolygonGroups.InsertOnSubmit(PolygonGroup);
                    dataContext.SubmitChanges();
                    PolygonGroup = dataContext.t_PolygonGroups.Where(p=>p.Name == PolygonGroup.Name).Last();
                    
                    if (Race.t_PolygonGroup.t_Polygons.Count > 0)
                    {
                        foreach (t_Polygon poly in Race.t_PolygonGroup.t_Polygons)
                        {
                            t_Polygon tmp_poly = new t_Polygon();
                            tmp_poly.Type = poly.Type;
                            tmp_poly.ID_PolygonGroup = PolygonGroup.ID;
                            dataContext.t_Polygons.InsertOnSubmit(tmp_poly);
                            dataContext.SubmitChanges();
                            Polygons.Add(dataContext.t_Polygons.Last());
                            foreach (t_PolygonPoint pp in poly.t_PolygonPoints)
                            {
                                t_PolygonPoint tmpPoint = new t_PolygonPoint();
                                tmpPoint.ID_Polygon = Polygons.Last().ID;
                                tmpPoint.longitude = pp.longitude;
                                tmpPoint.latitude = pp.latitude;
                                tmpPoint.altitude = pp.altitude;
                                dataContext.t_PolygonPoints.InsertOnSubmit(tmpPoint);
                            }
                        }
                    }
                    dataContext.SubmitChanges();
                }
                #endregion
                t_Race r = new t_Race();
                r.ID_Pilot_0 = Race.ID_Pilot_0;
                r.ID_Pilot_1 = Race.ID_Pilot_1;
                r.ID_Pilot_2 = Race.ID_Pilot_2;
                r.ID_Pilot_3 = Race.ID_Pilot_3;
                r.ID_PolygonGroup = PolygonGroup.ID;
                r.Name = Race.Name;
                r.TimeEnd = Race.TimeEnd;
                r.TimeStart = Race.TimeStart;
                dataContext.t_Races.InsertOnSubmit(r);
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                LogManager.AddLog(DB_PATH, 0, "ANRLDataService.svc.cs:AddRace", ex.ToString());
            }
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:AddRace", "Sucessfull Added");
        }

        /// <summary>
        /// Remove this Tracker from any Airplane
        /// </summary>
        /// <param name="TrackerID"> ID of the Tracker</param>
        public void CleanTracker(int TrackerID)
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:CleanTracker", TrackerID.ToString());
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == TrackerID))
            {
                f.ID_Tracker = 0;
            }
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Add New Pilot
        /// </summary>
        /// <param name="TrackerID"></param>
        /// <param name="LastName"></param>
        /// <param name="SureName"></param>
        /// <param name="Color"></param>
        public void AddNewPilot(int TrackerID, String LastName, String SureName, String Color)
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:AddNewAirplane", LastName + SureName + TrackerID.ToString());
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            t_Pilot f = new t_Pilot();
            f.ID_Tracker = TrackerID;
            f.LastName = LastName;
            f.SureName = SureName;
            f.Color = Color;
            dataContext.t_Pilots.InsertOnSubmit(f);
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Add Existim Pilot, may be modified
        /// </summary>
        /// <param name="PilotID"></param>
        /// <param name="TrackerID"></param>
        /// <param name="LastName"></param>
        /// <param name="SureName"></param>
        /// <param name="Color"></param>
        public void AddPilot(int PilotID, int TrackerID, String LastName, String SureName, String Color)
        {

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:AddAirplane", PilotID.ToString() + " " + TrackerID.ToString());
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == TrackerID))
            {
                f.ID_Tracker = 0;
            }
            t_Pilot fl = dataContext.t_Pilots.Single(p => p.ID == PilotID);
            fl.LastName = LastName;
            fl.SureName = SureName;
            fl.Color = Color;
            fl.ID_Tracker = TrackerID;
            dataContext.SubmitChanges();
           
        }

        /// <summary>
        /// Add the forbidden Zones to the DB
        /// </summary>
        /// <param name="PolygonList">A List of Polygons saved as a List of Polygon-Points saved in an Array {longitude, latitude}</param>
        public void AddPolygons(List<List<List<double>>> PolygonList)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            dataContext.t_PolygonPoints.DeleteAllOnSubmit(dataContext.t_PolygonPoints);
            dataContext.t_Polygons.DeleteAllOnSubmit(dataContext.t_Polygons);
            dataContext.SubmitChanges();
            int i = 1;
            foreach (List<List<double>> Polygonlist in PolygonList)
            {
                t_Polygon p = new t_Polygon();
                p.ID = i++;
    
                foreach (List<double> Point in Polygonlist)
                {
                    t_PolygonPoint point = new t_PolygonPoint();
                    point.longitude =(decimal) Point[0];
                    point.latitude =(decimal) Point[1];
                    point.ID_Polygon = p.ID;
                    dataContext.t_PolygonPoints.InsertOnSubmit(point);
                }
                dataContext.t_Polygons.InsertOnSubmit(p);
            }
            dataContext.SubmitChanges();
        }
        #endregion
    }
}
