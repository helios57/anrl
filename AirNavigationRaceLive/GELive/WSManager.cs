using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GELive
{
    public class WSManager
    {
        public string GetKml()
        {
            //XmlDocument kml = new XmlDocument();
            //return kml.ToString();
            // kml file loaded by resource file instead of webservice
            // change this when webservice is implemented
            return GELive.Properties.Resources.track;

        }
        
    }
}
