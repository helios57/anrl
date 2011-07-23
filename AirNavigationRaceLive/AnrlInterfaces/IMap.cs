using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AnrlInterfaces
{
    public interface IMap : IID
    {
        String Name { get; }
        IPicture Picture { get; }
        Double XSize { get; }
        Double YSize { get; }
        Double XRot { get; }
        Double YRot { get; }
        Double XTopLeft { get; }
        Double YTopLeft { get; }
    }
}
