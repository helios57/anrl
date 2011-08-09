using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Map
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        [ProtoMember(2)]
        public int ID_Picture { get; set; }

        [ProtoMember(3)]
        public String Name { get; set; }

        [ProtoMember(4)]
        public Double XSize { get; set; }

        [ProtoMember(5)]
        public Double YSize { get; set; }

        [ProtoMember(6)]
        public Double XRot { get; set; }

        [ProtoMember(7)]
        public Double YRot { get; set; }

        [ProtoMember(8)]
        public Double XTopLeft { get; set; }

        [ProtoMember(9)]
        public Double YTopLeft { get; set; }
    }
}
