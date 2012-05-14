using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using AnrlDB;

namespace LiveInputService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class LiveInputServiceImpl : ILiveInputService
    {
        public Root PostData(Root root)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Max-Age", "1728000");

            AnrlDataContext db = new AnrlDataContext();
            Root response = new Root();
            response.response = new Response();
            response.response.countAdded = 0;
            try
            {
                if (root != null && root.gpsdata.Count > 0)
                {
                    t_Tracker tracker;
                    if (db.t_Trackers.Count(p => p.IMEI == root.gpsdata[0].identifier) == 1)
                    {
                        tracker = db.t_Trackers.Single(p => p.IMEI == root.gpsdata[0].identifier);
                    }
                    else
                    {
                        tracker = new t_Tracker();
                        tracker.IMEI = root.gpsdata[0].identifier;
                        db.t_Trackers.InsertOnSubmit(tracker);
                        db.SubmitChanges();
                    }
                    foreach (GPSData data in root.gpsdata)
                    {
                        t_Daten t_d = new t_Daten();
                        t_d.Accuracy = data.accuracy;
                        t_d.Altitude = data.altitude;
                        t_d.Bearing = data.bearing;
                        t_d.Latitude = data.latitude;
                        t_d.Longitude = data.longitude;
                        t_d.Speed = data.speed;
                        t_d.Timestamp = data.timestampGPS;
                        t_d.ID_Tracker = tracker.ID;
                        db.t_Datens.InsertOnSubmit(t_d);
                        response.response.countAdded++;
                    }
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
#if !DEBUG
                //Logger.Log("Exception in GPSRequestProcessor.proccessRequest" + ex.ToString(), 9);
#else
                //System.Console.WriteLine("Exception in GPSRequestProcessor.proccessRequest " + ex.ToString());
#endif
                response.exception = ex.ToString();
            }
            finally
            {
                db.Dispose();
            }
            return response;
        }

        public void Options()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Max-Age", "1728000");
        }


        public Root PostDataXML(Root root)
        {
            return PostData(root);
        }
    }
}
