using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects.GPSInput
{
    [ProtoContract]
    public class RootMessage
    {
        private List<GPSData> GPSDataList = new List<GPSData>();
        [ProtoMember(1)]
        public List<GPSData> gpsdata { get { return GPSDataList; } }
        [ProtoMember(2)]
        public Response response { get; set; }
    }
    [ProtoContract]
    public class Response
    {
        [ProtoMember(1)]
        public int countAdded = 1;
    }
}
