using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AnrlDB;

namespace AnrlService.Server.Processors
{
    class GPSDataProcessor : AnrlService.Server.Processors.AProcessor
    {
        private TrackerProcessor tp;
        public GPSDataProcessor(TrackerProcessor tp)
        {
            this.tp = tp;
        }
        protected override void reloadCacheThreated()
        {
            //not cached
        }

        public override Root proccess(Root request)
        {
            Root r = new Root();
            r.ResponseParameters = new ResponseParameters();
            switch ((ERequestType)request.RequestType)
            {
                case ERequestType.Upload:
                    {

                        AnrlDataContext db = getDB();
                        t_Tracker tracker;
                        if (db.t_Trackers.Count(p => p.IMEI == request.RequestParameters.GPSDataList[0].identifier) == 1)
                        {
                            tracker = db.t_Trackers.Single(p => p.IMEI == request.RequestParameters.GPSDataList[0].identifier);
                        }
                        else
                        {
                            tracker = new t_Tracker();
                            tracker.IMEI = request.RequestParameters.GPSDataList[0].identifier;
                            tracker.Name = request.RequestParameters.GPSDataList[0].trackerName;
                            db.t_Trackers.InsertOnSubmit(tracker);
                            db.SubmitChanges();
                        }
                        List<t_Daten> toInsert = new List<t_Daten>();
                        foreach (GPSData data in request.RequestParameters.GPSDataList)
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
                            toInsert.Add(t_d);
                        }

                        db.t_Datens.InsertAllOnSubmit(toInsert);
                        db.SubmitChanges();
                        r.ResponseParameters.ID = tracker.ID;
                        db.Dispose();
                        tp.reloadCache();
                        break;
                    }
                case ERequestType.GetAll:
                    {

                        AnrlDataContext db = getDB();
                        if (request.RequestParameters.GPSDataRequest.ID_Tracker.Count > 0)
                        {
                            List<int> trackers = request.RequestParameters.GPSDataRequest.ID_Tracker;
                            IQueryable<t_Daten> selected;
                            if (request.RequestParameters.GPSDataRequest.LastId != 0)
                            {
                                selected = db.t_Datens.Where(p => p.ID > request.RequestParameters.GPSDataRequest.LastId &&
                                trackers.Contains(p.ID_Tracker) &&
                                p.Timestamp <= request.RequestParameters.GPSDataRequest.TimestampTo &&
                                p.Timestamp >= request.RequestParameters.GPSDataRequest.TimestampFrom);
                            }
                            else
                            {
                                selected = db.t_Datens.Where(p =>
                                trackers.Contains(p.ID_Tracker) &&
                                p.Timestamp <= request.RequestParameters.GPSDataRequest.TimestampTo &&
                                p.Timestamp >= request.RequestParameters.GPSDataRequest.TimestampFrom);
                            }

                            foreach (t_Daten db_daten in selected)
                            {
                                GPSData data = new GPSData();
                                data.accuracy = db_daten.Accuracy.HasValue ? db_daten.Accuracy.Value : 0;
                                data.altitude = db_daten.Altitude;
                                data.bearing = db_daten.Bearing.HasValue ? db_daten.Bearing.Value : 0;
                                data.latitude = db_daten.Latitude;
                                data.longitude = db_daten.Longitude;
                                data.speed = db_daten.Speed;
                                data.timestampGPS = db_daten.Timestamp;
                                data.trackerID = db_daten.ID_Tracker;
                                data.ID = db_daten.ID;
                                r.ResponseParameters.GPSDataList.Add(data);
                            }
                        }
                        db.Dispose();
                        break;
                    }
            }
            return r;
        }
    }
}
