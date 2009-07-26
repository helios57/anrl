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
        /// <param name="timestamp">The Timestamp for which the Data is requested</param>
        /// <returns>List of t_Daten</returns>
        [OperationContract]
        List<t_Daten> GetPathData(DateTime timestamp);

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
        List<TrackerListEntry> GetTrackers();

        /// <summary>
        /// Return a list of all Airplanes
        /// </summary>
        /// <returns>List of Airplanes</returns>
        [OperationContract]
        List<AirplaneListEntry> GetAirplanes();

        /// <summary>
        /// Remove this Tracker from any Airplane
        /// </summary>
        /// <param name="TrackerID"> ID of the Tracker</param>
        [OperationContract]
        void CleanTracker(int TrackerID);

        /// <summary>
        /// Add a new Airplane to a tracker
        /// </summary>
        /// <param name="Flugzeug">Airplane Type/Name</param>
        /// <param name="Pilot">Pilot Name</param>
        /// <param name="TrackerID">ID of the Tracker to bee added to this Airplane</param>
        [OperationContract]
        void AddAirplane(String Flugzeug, String Pilot, int TrackerID);

        /// <summary>
        /// Add an existing Airplane to a Tracker
        /// </summary>
        /// <param name="FlugzeugID">Id of the Airplane</param>
        /// <param name="TrackerID">ID of the Tracker</param>
        [OperationContract]
        void AddAirplane(int FlugzeugID, int TrackerID);

    }
}
