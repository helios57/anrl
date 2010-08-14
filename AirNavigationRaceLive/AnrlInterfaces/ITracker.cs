using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface ITracker : IID
    {
        String Name { get; }
        String IMEI { get; }
    }
}
