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
        public List<String[]> GetAirplanes()
        {

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:GetAirplanes", "");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<String[]> tmp = new List<string[]>();
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == 0))
            {
                tmp.Add(new String[] {f.ID.ToString().Trim(),f.LastName.Trim(),f.SureName.Trim()});
            }
            return tmp;
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
        /// Add a new Airplane to a tracker
        /// </summary>
        /// <param name="Flugzeug">Airplane Type/Name</param>
        /// <param name="Pilot">Pilot Name</param>
        /// <param name="TrackerID">ID of the Tracker to bee added to this Airplane</param>
        public void AddNewAirplane(String LastName, String SureName, int TrackerID)
        {
            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:AddNewAirplane", LastName + SureName + TrackerID.ToString());
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            t_Pilot f = new t_Pilot();
            f.ID_Tracker = TrackerID;
            f.LastName = LastName;
            f.SureName = SureName;
            dataContext.t_Pilots.InsertOnSubmit(f);
            dataContext.SubmitChanges();
        }
        /// <summary>
        /// Add an existing Airplane to a Tracker
        /// </summary>
        /// <param name="FlugzeugID">Id of the Airplane</param>
        /// <param name="TrackerID">ID of the Tracker</param>
        public void AddAirplane(int FlugzeugID, int TrackerID)
        {

            LogManager.AddLog(DB_PATH, 4, "ANRLDataService.svc.cs:AddAirplane", FlugzeugID.ToString() + " " + TrackerID.ToString());
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == TrackerID))
            {
                f.ID_Tracker = 0;
            }
            t_Pilot fl = dataContext.t_Pilots.Single(p => p.ID == FlugzeugID);
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
