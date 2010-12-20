using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IPicture : IID
    {
        byte[] Image {get;}
    }
}
