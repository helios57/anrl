using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive
{
    class Program
    {
        static void Main(string[] args)
        {
            Metro.Logging.PacketLogger logger = new Metro.Logging.PacketLogger("log");
            Metro.Logging.ArpLogger Test = new Metro.Logging.ArpLogger(logger);
        }
    }
}
