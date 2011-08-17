using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class PilotList
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        private List<Pilot> list = new List<Pilot>();
        [ProtoMember(2)]
        public List<Pilot> Pilots { get { return list; } }
    }
}
