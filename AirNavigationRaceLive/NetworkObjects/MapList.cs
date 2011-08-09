using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class MapList
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        private List<Map> list = new List<Map>();
        [ProtoMember(2)]
        public List<Map> Maps { get { return list; } }
    }
}
