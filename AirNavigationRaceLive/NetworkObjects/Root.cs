﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Root
    {
        [ProtoMember(1)]
        public AuthenticationInfo AuthInfo { get; set; }

        [ProtoMember(2)]
        public int RequestType { get; set; }

        [ProtoMember(3)]
        public RequestParameters RequestParameters { get; set; }

        [ProtoMember(4)]
        public ResponseParameters ResponseParameters { get; set; }



    }

    public enum RequestType : int
    {
        Login = 0,
        GetMaps = 1,
        SaveMap = 2,
        DeleteMap = 3,
        GetPicture = 4,
        SavePicture = 5,
        DeletePicture = 6,
        GetParcours = 7,
        SaveParcour = 8,
        DeleteParcour = 9,
        GetTrackers = 10,
        SaveTracker = 11,
        DeleteTracker = 12,
        GetPilots = 13,
        SavePilot = 14,
        DeletePilot = 15
    }
}
