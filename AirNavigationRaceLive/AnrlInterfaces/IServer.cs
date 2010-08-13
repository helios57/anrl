using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IServer
    {
        IAnrlClient getAnrlClient(String username, String password);
        IAnrlServerControl getAnrlServerControl(String username, String password);
    }
}
