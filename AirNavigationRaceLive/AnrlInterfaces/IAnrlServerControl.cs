﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IAnrlServerControl
    {
        Boolean StartTCPListener();
        Boolean StopTCPListener();
    }
}
