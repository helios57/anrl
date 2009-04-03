using System;
using System.IO;
using System.Xml;

/// <summary>
/// KmlBuilder class is used to convert data from database to a kml-structured xml file.
/// The generated xml file will be used at the air nagivation race live client to visualize the containing track informationen.
/// KmlBuilder class requires the track.xml file to be located in the same directory as the executable or dll of this class.
/// This can be achived by setting the file property 'Copy to output directory' to 'copy if newer'.
/// The project has first to be built bevor rist time using.
/// </summary>
public class KmlBuilder
{    
    public XmlDocument BuildKml(int ID, int Flugzeug_ID, DateTime Timestamp, double Xstart, double Xend, double Ystart, double Yend, double Zstart, double Zend, DateTime Tstart, DateTime Tend, double Speed, int Pentalty)
    {
        // checking of parameters needed?

        XmlDocument kml = new XmlDocument();
        try
        {
            kml.Load("track.xml");
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
        return kml;
    }
}
