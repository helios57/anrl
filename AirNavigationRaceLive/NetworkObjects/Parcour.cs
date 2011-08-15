using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Parcour
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        private List<Line> list = new List<Line>();

        [ProtoMember(2)]
        public List<Line> Lines { get { return list; } }

        [ProtoMember(3)]
        public String Name { get; set; }

        [ProtoMember(4)]
        public int ID_Map { get; set; }
    }
}
