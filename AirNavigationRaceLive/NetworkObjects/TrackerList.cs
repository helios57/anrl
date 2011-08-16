using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class TrackerList
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        private List<Tracker> list = new List<Tracker>();
        [ProtoMember(2)]
        public List<Tracker> Trackers { get { return list; } }
    }
}
