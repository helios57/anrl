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
            //XmlDocument kml = new XmlDocument();
            //return kml.ToString();
            // kml file loaded by resource file instead of webservice
            // change this when webservice is implemented
            GELive.anrlWebService.ANRLDataServiceClient client = new ANRLDataServiceClient();
            
            // trackerId as paramater
            string kml = client.GetKml(1);

            
            return GELive.Properties.Resources.track;

        }
        
    }
}
