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
            DateTime TimeStamp = new DateTime(2009, 03, 30, 23, 38, 50);
            DateTime Tstart = new DateTime(2009, 03, 30, 23, 38, 00);
            DateTime Tend = new DateTime(2009, 03, 30, 23, 38, 10);
            
            
            KmlBuilder kmlBuilder = new KmlBuilder();
            XmlDocument xml = kmlBuilder.BuildKml(1, 4, TimeStamp, -112.2595218489022, 36.08584355239394, -112.2608216347552, 36.08612634548589, 2357, 2100, Tstart, Tend, 200, 10);
            Console.ReadKey();
        }        
    }
}
