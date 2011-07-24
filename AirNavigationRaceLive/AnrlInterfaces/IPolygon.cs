using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IPolygon : IID
    {
        List<long> IDS { get; }
    }
}
