using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Tracker
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        [ProtoMember(2)]
        public String IMEI { get; set; }

        [ProtoMember(3)]
        public String Name { get; set; }
    }
}
