using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IPicture : IID
    {
        System.Drawing.Image Image {get;}
    }
}
