using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class NetObject
    {
        [ProtoMember(1)]
        public int ID { get; set; }
    }
}
