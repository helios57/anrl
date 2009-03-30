using System;
using System.IO;
using System.Xml;

public class KmlBuilder
{    
    public XmlDocument BuildKml(int ID, int Flugzeug_ID, DateTime Timestamp, double Xstart, double Xend, double Ystart, double Yend, double Zstart, double Zend, DateTime Tstart, DateTime Tend, double Speed, int Pentalty)
    {
        // checking of parameters needed?

        XmlDocument kml = new XmlDocument();
        try
        {
            kml.Load("../../track.xml");
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
        return kml;
    }
}
