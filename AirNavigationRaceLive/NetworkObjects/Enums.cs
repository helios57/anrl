using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkObjects
{
    public enum ERequestType : int
    {
        Login = 0,
        Get = 1,
        Save = 2,
        Delete = 3,
        GetAll = 4
    }

    public enum EObjectType : int
    {
        Login = 0,
        Map = 1,
        Picture = 2,
        Parcour = 3,
        Tracker = 4,
        Pilot = 5,
        Team = 6
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
