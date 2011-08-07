using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IParcour : IID
    {
        List<ILine> Lines { get; }
    }
}
