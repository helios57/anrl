﻿using System;
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
        public Picture Picture { get; set; }

        [ProtoMember(3)]
        public Map Map { get; set; }

        [ProtoMember(4)]
        public Parcour Parcour { get; set; }

        [ProtoMember(5)]
        public Tracker Tracker { get; set; }

    }
}
