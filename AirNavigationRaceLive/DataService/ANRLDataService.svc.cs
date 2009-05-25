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
    public class ANRLDataService : IANRLDataService
    {
        #region IANRLDataService Members

        /// <summary>
        /// Returns the flight path data as a list of t_Daten at a Given Timestamp
        /// </summary>
        /// <param name="timestamp">The Timestamp for which the Data is requested</param>
        /// <returns>List of t_Daten</returns>
        public List<t_Daten> GetPathData(DateTime timestamp)
        {
            using (DatabaseEntities dataContext = new DatabaseEntities())
            {
                DateTime end = timestamp.AddSeconds(-6);
                return dataContext.t_Daten.
                    /*Include("t_Flugzeug").
                    Include("t_Flugzeug.t_Tracker").*/
                    Where(d => d.TStart <= timestamp && d.TEnd > end).
                    ToList();
            }
        }

        /// <summary>
        /// Get All Timestamps of recorsd in the DB for Delay
        /// </summary>
        /// <returns>List of Datetime Timestamps</returns>
        public List<DateTime> GetTimestamps()
        {
            List<DateTime> timestamplist = new List<DateTime>();
            using (DatabaseEntities dataContext = new DatabaseEntities())
            {
                foreach (t_Daten row in dataContext.t_Daten)
                {
                    timestamplist.Add((DateTime)row.TStart);
                }
            }
            return timestamplist;
        }

        #endregion
    }
}
