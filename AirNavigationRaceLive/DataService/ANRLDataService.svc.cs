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
        /// Returns the most actual flight path data as a list of t_Daten
        /// </summary>
        /// <param name="timestamp">The timestamp associated with the datas</param>
        /// <returns>List of t_Daten</returns>
        public List<t_Daten> GetPathData(DateTime timestamp)
        {
            using (DBModelDataContext dataContext = new DBModelDataContext())
            {
                return dataContext.t_Datens.
                                Where(d => d.TStart >= timestamp && d.TEnd < timestamp).ToList();
            }
        }

        #endregion
    }
}
