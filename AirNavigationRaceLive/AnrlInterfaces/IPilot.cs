using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IPilot : IID
    {
        String Name { get; }
        String Surename { get; }
        IPicture Picture { get; }
    }
}
