using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using ProtoBuf;
using NetworkObjects;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace AirNavigationRaceLive.Comps.Client
{
    class ClientCacheGPSDaten
    {
        private Client c;
        private List<GPSData> chache = new List<GPSData>();
        private volatile bool requesting = false;
        public ClientCacheGPSDaten(Client c)
        {
            this.c = c;
        }

        public void requestGPSData(List<int> trackersID, long from, long to, AsyncCallback finished)
        {
            if (c.isAuthenticated() && !requesting)
            {
                requesting = true;
                ParameterClass pc = new ParameterClass();
                pc.finished = finished;
                pc.from = from;
                pc.to = to;
                pc.trackersID = trackersID;
                Thread tread = new Thread(new ParameterizedThreadStart(doRequest));
                tread.Start(pc);
            }
        }

        private void doRequest(object o)
        {
            ParameterClass pc = o as ParameterClass;
            int maxId = 0;
            if (chache.Count > 0 && chache.Count(p => p.timestampGPS >= pc.from && p.timestampGPS <= pc.to && pc.trackersID.Contains(p.trackerID)) > 1)
            {
                maxId = chache.Where(p => p.timestampGPS >= pc.from && p.timestampGPS <= pc.to && pc.trackersID.Contains(p.trackerID)).Max(p => p.ID);
            }
            Root req = new Root();
            req.RequestParameters = new RequestParameters();
            req.RequestType = (int)ERequestType.GetAll;
            req.ObjectType = (int)EObjectType.GPSData;
            req.RequestParameters.GPSDataRequest = new GPSDataRequest();
            req.RequestParameters.GPSDataRequest.ID_Tracker.AddRange(pc.trackersID);
            req.RequestParameters.GPSDataRequest.LastId = maxId;
            req.RequestParameters.GPSDataRequest.TimestampFrom = pc.from;
            req.RequestParameters.GPSDataRequest.TimestampTo = pc.to;

            Root resp = c.process(req);
            chache.AddRange(resp.ResponseParameters.GPSDataList);

            List<GPSData> result = chache.Where(p => p.timestampGPS >= pc.from && p.timestampGPS <= pc.to && pc.trackersID.Contains(p.trackerID)).ToList();
            //result.Sort(new DateComparer());
            pc.finished.Invoke(new GPSDataAsyncResult(result));
            requesting = false;
        }
    }
    class ParameterClass
    {
        public List<int> trackersID;public  long from; public long to; public AsyncCallback finished;

    }
    class DateComparer : Comparer<GPSData>
    {
        public override int Compare(GPSData x, GPSData y)
        {
            return (int)(x.timestampGPS - y.timestampGPS);
        }
    }
    class GPSDataAsyncResult : IAsyncResult
    {
        private List<GPSData> list;
        public GPSDataAsyncResult(List<GPSData> list)
        {
            this.list = list;
        }

        public object AsyncState
        {
            get { return list; }
        }

        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get { return null; }
        }

        public bool CompletedSynchronously
        {
            get { return true; }
        }

        public bool IsCompleted
        {
            get { return true; }
        }
    }
}
