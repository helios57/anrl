using System;
using System.IO;
using System.Text;
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
    /// <summary>
    /// Generate the KML File for the Gui
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="Flugzeug_ID"></param>
    /// <param name="Timestamp"></param>
    /// <param name="Xstart"></param>
    /// <param name="Xend"></param>
    /// <param name="Ystart"></param>
    /// <param name="Yend"></param>
    /// <param name="Zstart"></param>
    /// <param name="Zend"></param>
    /// <param name="Tstart"></param>
    /// <param name="Tend"></param>
    /// <param name="Speed"></param>
    /// <param name="Pentalty"></param>
    /// <returns></returns>
    public XmlDocument BuildKml(string ID, string Flugzeug_ID, string Timestamp, string Xstart, string Xend, string Ystart, string Yend, string Zstart, string Zend, string Tstart, string Tend, string Speed, string Pentalty)
    {
        // checking of parameters needed?

        XmlDocument kml = new XmlDocument();
        try
        {
            kml.Load("track.xml");

            // maybe a dynamic possibility to add each parameter-value to its appropriate xmlNode
            kml.GetElementsByTagName("ID").Item(0).Value = ID;
            kml.GetElementsByTagName("Flugzeug_ID").Item(0).Value = Flugzeug_ID;
            kml.GetElementsByTagName("Timestamp").Item(0).Value = Timestamp;
            kml.GetElementsByTagName("Tstart").Item(0).Value = Tstart;
            kml.GetElementsByTagName("Tend").Item(0).Value = Tend;
            kml.GetElementsByTagName("Speed").Item(0).Value = Speed;
            kml.GetElementsByTagName("Pentalty").Item(0).Value = Pentalty;
            string Coordinates = Xstart + "," + Xend + "," + Zstart + "\r\n" + Ystart + "," + Yend + "," + Zend;
            kml.GetElementsByTagName("coordinates").Item(0).Value = Coordinates;
        }
        catch (Exception err)
        {
            // here should be some intelligent error-handling
        }
        return kml;
    }
}
