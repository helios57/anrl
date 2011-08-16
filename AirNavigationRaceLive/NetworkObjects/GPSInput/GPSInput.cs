using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects.GPSInput
{
    [ProtoContract]
    public class GPSData
    {
        [ProtoMember(1)]
        public long timestampSender { get; set; }
        [ProtoMember(2)]
        public long timestampGPS { get; set; }
        [ProtoMember(3)]
        public double altitude { get; set; }
        [ProtoMember(4)]
        public double latitude { get; set; }
        [ProtoMember(5)]
        public double longitude { get; set; }
        [ProtoMember(6)]
        public double accuracy { get; set; }
        [ProtoMember(7)]
        public double speed { get; set; }
        [ProtoMember(8)]
        public double bearing { get; set; }
        [ProtoMember(9)]
        public string identifier { get; set; }
    }
}
