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

        #endregion
    }
}
