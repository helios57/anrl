using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AnrlService.Server
{
    class AnrlServerControl : MarshalByRefObject, IAnrlServerControl
    {
        public bool StartTCPListener()
        {
            return false;
        }

        public bool StopTCPListener()
        {
            return false;
        }
    }
}
