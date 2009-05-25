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
    }
}
