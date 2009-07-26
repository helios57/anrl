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

            DateTime end = timestamp.AddSeconds(-6);

            List<t_Daten> tmp = new List<t_Daten>();

            t_Daten tmp_t_Daten = new t_Daten();
            foreach (t_Daten t in dataContext.t_Datens.Where(d => d.TStart <= timestamp && d.TEnd > end))
            {
                tmp_t_Daten.ID = t.ID;
                tmp_t_Daten.Timestamp = t.Timestamp;
                tmp_t_Daten.TStart = t.TStart;
                tmp_t_Daten.TEnd = t.TEnd;
                tmp_t_Daten.XStart = t.XStart;
                tmp_t_Daten.XEnd = t.XEnd;
                tmp_t_Daten.YStart = t.YStart;
                tmp_t_Daten.YEnd = t.YEnd;
                tmp_t_Daten.ZStart = t.ZStart;
                tmp_t_Daten.ZEnd = t.ZEnd;
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
            List<DateTime> timestamplist = new List<DateTime>();
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Daten row in dataContext.t_Datens)
            {
                timestamplist.Add((DateTime)row.TStart);
            }
            return timestamplist;
        }


        /// <summary>
        /// List of all PolygonPoints
        /// </summary>
        /// <returns>List of PolygonPoints</returns>
        public List<t_PolygonPoint> GetPolygons()
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);

            List<t_PolygonPoint> tmp = new List<t_PolygonPoint>();

            t_PolygonPoint tmp_t_PolygonPoint = new t_PolygonPoint();

            foreach (t_PolygonPoint t in dataContext.t_PolygonPoints)
            {
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
        public List<TrackerListEntry> GetTrackers()
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<TrackerListEntry> lstTrackers = new List<TrackerListEntry>();
            foreach (t_Tracker t in dataContext.t_Trackers)
            {
                TrackerListEntry tle = new TrackerListEntry(t.ID, t.IMEI);
                #region Check airplanes attached ?
                //Remove GPS-Trackers if added to may Airplanes
                if (dataContext.t_Flugzeugs.Count(p => p.ID_GPS_Tracker == t.ID) == 1)
                {
                    t_Flugzeug f = dataContext.t_Flugzeugs.Single(p => p.ID_GPS_Tracker == t.ID);
                    tle.ID_Flugzeug = f.ID;
                    tle.Pilot = f.Pilot;
                    tle.Flugzeug = f.Flugzeug;
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
        public List<AirplaneListEntry> GetAirplanes()
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            List<AirplaneListEntry> tmp = new List<AirplaneListEntry>();
            foreach (t_Flugzeug f in dataContext.t_Flugzeugs.Where(p => p.ID_GPS_Tracker == 0 || p.ID_GPS_Tracker == null))
            {
                tmp.Add(new AirplaneListEntry(f));
            }
            return tmp;
        }
        /// <summary>
        /// Remove this Tracker from any Airplane
        /// </summary>
        /// <param name="TrackerID"> ID of the Tracker</param>
        public void CleanTracker(int TrackerID)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Flugzeug f in dataContext.t_Flugzeugs.Where(p => p.ID_GPS_Tracker == TrackerID))
            {
                f.ID_GPS_Tracker = 0;
            }
            dataContext.SubmitChanges();
        }
        /// <summary>
        /// Add a new Airplane to a tracker
        /// </summary>
        /// <param name="Flugzeug">Airplane Type/Name</param>
        /// <param name="Pilot">Pilot Name</param>
        /// <param name="TrackerID">ID of the Tracker to bee added to this Airplane</param>
        public void AddAirplane(String Flugzeug, String Pilot, int TrackerID)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            t_Flugzeug f = new t_Flugzeug();
            f.ID_GPS_Tracker = TrackerID;
            f.Pilot = Pilot;
            f.Flugzeug = Flugzeug;
            dataContext.t_Flugzeugs.InsertOnSubmit(f);
            dataContext.SubmitChanges();
        }
        /// <summary>
        /// Add an existing Airplane to a Tracker
        /// </summary>
        /// <param name="FlugzeugID">Id of the Airplane</param>
        /// <param name="TrackerID">ID of the Tracker</param>
        public void AddAirplane(int FlugzeugID, int TrackerID)
        {
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Flugzeug f in dataContext.t_Flugzeugs.Where(p => p.ID_GPS_Tracker == TrackerID))
            {
                f.ID_GPS_Tracker = 0;
            }
            t_Flugzeug fl = dataContext.t_Flugzeugs.Single(p => p.ID == FlugzeugID);
            fl.ID_GPS_Tracker = TrackerID;
            dataContext.SubmitChanges();
        }
        #endregion
    }
}
