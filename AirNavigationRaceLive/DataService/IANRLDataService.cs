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
        /// Returns the most actual flight path data as a list of t_Daten
        /// </summary>
        /// <param name="timestamp">The timestamp associated with the data</param>
        /// <returns>List of t_Daten</returns>
        [OperationContract]
        List<t_Daten> GetPathData(DateTime timestamp);
    }
}
