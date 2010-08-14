using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IPenaltyZone : IID
    {
        List<IPenaltyPolygon> Polygons { get; }
    }
}
