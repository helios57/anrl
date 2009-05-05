using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace DataService
{
    public class ANRLDataService : IANRLDataService
    {
        #region IANRLDataService Members

        /// <summary>
        /// Returns an KML-string containing the latest position of the GPS-Tracker
        /// </summary>
        /// <param name="trackerID">Tracker ID</param>
        /// <returns>KML-string</returns>
        public t_Daten[] GetPathData(DateTime timestamp)
        {
            using (DBModelDataContext dataContext = new DBModelDataContext())
            {
                KmlBuilder kb = new KmlBuilder();
                return dataContext.t_Datens.
                                Where(d => d.TStart >= timestamp && d.TEnd < timestamp).ToArray();
            }
        }

        #endregion
    }
}
