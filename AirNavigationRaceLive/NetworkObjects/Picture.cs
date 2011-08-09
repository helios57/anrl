using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Picture
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        [ProtoMember(2)]
        public byte[] Image { get; set; }

        [ProtoMember(3)]
        public string Name { get; set; }
    }
}
