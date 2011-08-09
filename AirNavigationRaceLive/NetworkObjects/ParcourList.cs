using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class ParcourList
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        private List<Parcour> list = new List<Parcour>();
        [ProtoMember(2)]
        public List<Parcour> Parcours { get { return list; } }
    }
}
