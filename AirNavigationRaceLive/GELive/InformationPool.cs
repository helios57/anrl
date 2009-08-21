using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEPlugin;
using GELive.ANRLDataService;

namespace GELive
{
    static class InformationPool
    {
        static public String RemoteAddress = "http://127.0.0.1:5555/";
        static public String ConnectionConfig = "WSHttpBinding_IANRLDataService";
        static public String Username;
        static public String Password;

        static public ANRLDataServiceClient Client = null;

        static public anrl_gui gui = null;
        static public WSManager manager = null;

        static public GEWebBrowser gweb = null;
        static public GEFeatureContainerCoClass Container = null;
        static public IGEPlugin ge = null;

        static public TimeSpan Delay = new TimeSpan();
        static public int PlaySpeed=1;

    }
}
