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
        public string GetKml(int trackerID)
        {
            using (DBModelDataContext dataContext = new DBModelDataContext())
            {
                KmlBuilder kb = new KmlBuilder();
                t_Daten data = dataContext.t_Datens.
                                Where(d => d.t_Flugzeug.ID_GPS_Tracker == trackerID).
                                OrderByDescending(t => t.Timestamp).
                                First();

                return kb.BuildKml(
                                        data.ID.ToString(),
                                        data.ID_Flugzeug.ToString(),
                                        data.Timestamp.ToString(),
                                        data.XStart.Value.ToString(),
                                        data.XEnd.Value.ToString(),
                                        data.YStart.Value.ToString(),
                                        data.YEnd.Value.ToString(),
                                        data.ZStart.Value.ToString(),
                                        data.ZEnd.Value.ToString(),
                                        data.TStart.Value.ToString(),
                                        data.TEnd.Value.ToString(),
                                        data.Speed,
                                        data.Penalty.Value.ToString()
                                    ).OuterXml;
            }
        }

        #endregion
    }
}
