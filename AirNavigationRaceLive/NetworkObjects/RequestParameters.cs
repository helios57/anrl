using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class RequestParameters
    {
        [ProtoMember(1)]
        public int ID { get; set; }

        [ProtoMember(2)]
        public Map NetObject { get; set; }
    }
}
