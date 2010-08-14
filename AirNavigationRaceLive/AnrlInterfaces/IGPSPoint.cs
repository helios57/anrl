using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IGPSPoint
    {
        Decimal Longitude { get; }
        Decimal Latitude { get; }
        Decimal Altitude { get; }
    }
}
