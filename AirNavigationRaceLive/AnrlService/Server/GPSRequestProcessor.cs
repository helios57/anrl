using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;
using System.Diagnostics;

namespace AnrlService.Server
{
    public class GPSRequestProcessor
    {
        public GPSRequestProcessor()
        {
            AnrlDataContext db = new AnrlDataContext();
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            db.Dispose();
        }
        public RootMessage proccessRequest(RootMessage request)
        {

            AnrlDataContext db = new AnrlDataContext();
            RootMessage response = new RootMessage();
            response.response = new Response();
            response.response.countAdded = 0;
            try
            {
                if (request != null && request.gpsdata.Count > 0)
                {
                    t_Tracker tracker;
                    if (db.t_Trackers.Count(p => p.IMEI == request.gpsdata[0].identifier) == 1)
                    {
                        tracker = db.t_Trackers.Single(p => p.IMEI == request.gpsdata[0].identifier);
                    }
                    else
                    {
                        tracker = new t_Tracker();
                        tracker.IMEI = request.gpsdata[0].identifier;
                        db.t_Trackers.InsertOnSubmit(tracker);
                        db.SubmitChanges();
                    }
                    foreach (GPSData data in request.gpsdata)
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
                Logger.Log("Exception in GPSRequestProcessor.proccessRequest" + ex.ToString(), 9);
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
    }
}
