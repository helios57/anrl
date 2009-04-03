using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DomeTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            KmlBuilder kmlBuilder = new KmlBuilder();
            XmlDocument xml = kmlBuilder.BuildKml("1", "4", "13/11/1986 12:00:59", "-112.2595218489022", "36.08584355239394", "-112.2608216347552", "36.08612634548589", "2357", "2100", "13/11/1986 10:00:59", "13/11/1986 10:01:59", "200", "10");
            Console.WriteLine(xml.InnerXml);
            Console.ReadKey();
        }        
    }
}
