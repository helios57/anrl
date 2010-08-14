using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IPenaltyPolygon : IID
    {
        List<IPenaltyPoint> Points { get; }
    }
}
