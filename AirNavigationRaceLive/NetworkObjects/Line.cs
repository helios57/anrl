using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace NetworkObjects
{
    [ProtoContract]
    public class Line:NetObject
    {
        [ProtoMember(2)]
        public Point A { get; set; }

        [ProtoMember(3)]
        public Point B { get; set; }

        [ProtoMember(4)]
        public Point O { get; set; }

        [ProtoMember(4)]
        public int Type { get; set; }


    }
    public enum LineType : int
    {
        START = 1,
        END = 2,
        START_A = 3,
        START_B = 4,
        START_C = 5,
        START_D = 6,
        END_A = 7,
        END_B = 8,
        END_C = 9,
        END_D = 10,
        LINEOFNORETURN = 11,
        PENALTYZONE = 12,
        Point = 13
    }
}
