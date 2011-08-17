using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Pilot
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        [ProtoMember(2)]
        public String Name { get; set; }

        [ProtoMember(3)]
        public String Surename { get; set; }

        [ProtoMember(4)]
        public int ID_Picture { get; set; }
    }
}
