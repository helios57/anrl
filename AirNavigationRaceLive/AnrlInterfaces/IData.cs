using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IData:IID, IGPSPoint
    {
        DateTime Timestamp{get;}
        ITracker Tracker { get; }
    }
}
