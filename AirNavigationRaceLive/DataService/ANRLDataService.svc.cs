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
        /// Returns the flight path data as a list of t_Daten at a Given Timestamp
        /// </summary>
        /// <param name="timestamp">The Timestamp for which the Data is requested</param>
        /// <returns>List of t_Daten</returns>
        public List<t_Daten> GetPathData(DateTime timestamp)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetPathData", timestamp.ToString() + " " + timestamp.CompareTo(dataContext.t_Datens.Max(p => p.Timestamp)));
       //     if ()
            {

            }

            DateTime end = timestamp.AddSeconds(1);

            List<t_Daten> tmp = new List<t_Daten>();

            t_Daten tmp_t_Daten = new t_Daten();
            foreach (t_Daten t in dataContext.t_Datens.Where(d => d.Timestamp >= timestamp && d.Timestamp < end))
            {
                tmp_t_Daten.ID = t.ID;
                tmp_t_Daten.Timestamp = t.Timestamp;
                tmp_t_Daten.Latitude = t.Latitude;
                tmp_t_Daten.Longitude= t.Longitude;
                tmp_t_Daten.Altitude= t.Altitude;
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
        public List<String[]> GetTrackers()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetTrackers", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<String[]> lstTrackers = new List<String[]>();
            foreach (t_Tracker t in dataContext.t_Trackers)
            {
                String[] tle = new String[5];
                tle[0] = t.ID.ToString();
                tle[1] = t.IMEI.Trim();
                #region Check airplanes attached ?
                //Remove GPS-Trackers if added to may Airplanes
                if (dataContext.t_Pilots.Count(p => p.ID_Tracker == t.ID) == 1)
                {
                    t_Pilot f = dataContext.t_Pilots.Single(p => p.ID_Tracker == t.ID);
                    tle[2] = f.ID.ToString().Trim();
                    tle[3] = f.LastName.Trim();
                    tle[4] = f.SureName.Trim();
                }
                #endregion
                lstTrackers.Add(tle);
            }
            return lstTrackers;
        }
        /// <summary>
        /// Return a list of all Airplanes
        /// </summary>
        /// <returns>List of Airplanes</returns>
        public List<String[]> GetPilots()
        {

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetAirplanes", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<String[]> tmp = new List<string[]>();
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == 0))
            {
                tmp.Add(new String[] { f.ID.ToString().Trim(), f.LastName.Trim(), f.SureName.Trim(), f.Color.Trim() });
            }
            return tmp;
        }

        /// <summary>
        /// Return a list of all Racecs
        /// </summary>
        /// <returns>List of Racecs</returns>
        public List<String[]> GetRaces()
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetRaces", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<String[]> tmp = new List<string[]>();
            foreach (t_Race r in dataContext.t_Races)
            {
                tmp.Add(new String[] {
                    r.ID.ToString().Trim(),
                    r.Name.Trim(),
                    r.ID_Pilot_0.ToString().Trim(),
                    r.ID_Pilot_1.ToString().Trim(),
                    r.ID_Pilot_2.ToString().Trim(),
                    r.ID_Pilot_3.ToString().Trim(),
                    r.ID_PolygonGroup.ToString().Trim(),
                    r.TimeEnd.ToString(),
                    r.TimeStart.ToString()});
            }
            return tmp;
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
