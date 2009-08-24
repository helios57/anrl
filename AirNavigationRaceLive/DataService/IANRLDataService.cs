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
    /// Interface for the WCF-Communication
    /// </summary>
    [ServiceContract]
    public interface IANRLDataService
    {
        /// <summary>
        /// Returns the flight path data as a list of t_Daten at a Given Timestamp
        /// </summary>
        /// <param name="IntervallStart"></param>
        /// <param name="IntervallEnd"></param>
        /// <returns></returns>
        [OperationContract]
        List<t_Daten> GetPathData(DateTime IntervallStart, DateTime IntervallEnd);

        /// <summary>
        /// List of timestamps with Data available for Delay
        /// </summary>
        /// <returns>List of Timestamps</returns>
        [OperationContract]
        List<DateTime> GetTimestamps();

        /// <summary>
        /// List of all PolygonPoints
        /// </summary>
        /// <returns>List of PolygonPoints</returns>
        [OperationContract]
        List<t_PolygonPoint> GetPolygons();

        /// <summary>
        /// Return a list of all Trackers
        /// </summary>
        /// <returns>List of Trackers</returns>
        [OperationContract]
        List<t_Tracker> GetTrackers();

        /// <summary>
        /// Return a list of all Pilotes
        /// </summary>
        /// <returns>List of Pilotes</returns>
        [OperationContract]
        List<t_Pilot> GetPilots();

        /// <summary>
        /// Return a list of all Pilotes
        /// </summary>
        /// <returns>List of Pilotes</returns>
        [OperationContract]
        List<t_Race> GetRaces();

        /// <summary>
        /// Adds or modifies a Race
        /// </summary>
        /// <param name="Race"></param>
        [OperationContract]
        void AddRace(t_Race Race);

        /// <summary>
        /// Return a list of all Pilotes
        /// </summary>
        /// <returns>List of Pilotes</returns>
        [OperationContract]
        List<t_PolygonGroup> GetPolygonGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID_PolygonGroup"></param>
        /// <returns></returns>
        [OperationContract]
        List<t_Polygon> GetPolygonsByGroup(int ID_PolygonGroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID_Polygon"></param>
        /// <returns></returns>
        [OperationContract]
        List<t_PolygonPoint> GetPolygonPoints(int ID_Polygon);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Race_ID"></param>
        [OperationContract]
        void RemoveRace(int Race_ID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TrackerID"></param>
        [OperationContract]
        void CleanTracker(int TrackerID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TrackerID"></param>
        /// <param name="LastName"></param>
        /// <param name="SureName"></param>
        /// <param name="Color"></param>
        [OperationContract]
        int AddNewPilot(String LastName, String SureName, String Color);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PilotID"></param>
        /// <param name="TrackerID"></param>
        /// <param name="LastName"></param>
        /// <param name="SureName"></param>
        /// <param name="Color"></param>
        [OperationContract]
        void AddPilot(int PilotID, int TrackerID, String LastName, String SureName, String Color);

        /// <summary>
        /// Add the forbidden Zones to the DB
        /// </summary>
        /// <param name="PolygonList">A List of Polygons saved as a List of Polygon-Points saved in an Array {longitude, latitude}</param>
        [OperationContract]
        void AddPolygons(List<List<List<double>>> PolygonList);

    }
}
