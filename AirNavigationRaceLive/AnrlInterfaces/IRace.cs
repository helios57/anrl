using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IRace : IID
    {
        List<ITeam> Teams { get; }
        String Name { get; }
        DateTime TakeOff { get; }
        DateTime Start { get; }
        DateTime End { get; }
        IPenaltyZone PenaltyZone {get;}
    }
}
