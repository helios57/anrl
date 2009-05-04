using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GELive.anrlWebService;

namespace GELive
{
    public class WSManager
    {
        public string GetKml()
        {
            // kml file loaded by resource file instead of webservice
            // change this when webservice is implemented
            return GELive.Properties.Resources.track;
        }
        
    }
}
