using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Point:NetObject
    {
        [ProtoMember(2)]
        public double altitude { get; set; }
        [ProtoMember(3)]
        public double longitude { get; set; }
        [ProtoMember(4)]
        public double latitude { get; set; }
    }
}
