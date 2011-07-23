using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IGPSPoint
    {
        Double Longitude { get; }
        Double Latitude { get; }
        Double Altitude { get; }
    }
}
