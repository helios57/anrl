using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PFA.ANR.BusinessLayer
{
    class DeserializeTester
    {
        public static void Main(string[] args)
        {
        BinaryFormatter binFormat = new BinaryFormatter();
        Stream fStream = File.OpenRead(@"C:\tRace.anrx");
        Race r =(Race)binFormat.Deserialize(fStream);

        Stream fStream2 = File.OpenRead(@"C:\tParcours.anrx");
        Parcours p  =(Parcours)binFormat.Deserialize(fStream2);

        Map m = r.Map;
        //Competitor comp = r.Competitors[0];

        Stream fStream3 = File.OpenRead(@"C:\tGroup.anrx");
        CompetitorGroup group = (CompetitorGroup)binFormat.Deserialize(fStream3);

        //Console.WriteLine("Number of forbidden Zones" + p.ForbiddenZones.Count);
        //    foreach(ForbiddenZone f in p.ForbiddenZones)
        //    {
        //        Console.WriteLine("Zone: \n");
        //        foreach (GpsPoint pt in f.GpsPoints)
        //        {
        //            Console.WriteLine("\t Point: " + pt.Longitude + " / " + pt.Latitude + "\n");
        //        }
        //    }

        //    for(int i =0;i<p.Gates.Length / 2; i++)
        //    {
        //        Console.WriteLine("Track: \n");
        //        Console.WriteLine("Starting Gate: \n");
        //        Console.WriteLine("\t Point: " + p.Gates[i,0].LeftPoint.Longitude + " / " + p.Gates[i,0].LeftPoint.Latitude + "\n");
        //        Console.WriteLine("\t Point: " + p.Gates[i,0].RightPoint.Longitude + " / " + p.Gates[i,0].RightPoint.Latitude + "\n");
        //        Console.WriteLine("Finishing Gate:");
        //        Console.WriteLine("\t Point: " + p.Gates[i, 1].LeftPoint.Longitude + " / " + p.Gates[i, 1].LeftPoint.Latitude + "\n");
        //        Console.WriteLine("\t Point: " + p.Gates[i, 1].RightPoint.Longitude + " / " + p.Gates[i, 1].RightPoint.Latitude + "\n");

        //        Console.WriteLine("\t Point in CH Coord " + m.TopLeftPoint.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));
        //        Console.WriteLine("\t Point in CH Coord " + m.TopLeftPoint.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));

        //    }

        //    Console.WriteLine("NbLine: \n");
        //    try
        //    {
        //        Console.WriteLine("\t Point: " + p.NbLine.LeftPoint.Longitude + " / " + p.NbLine.LeftPoint.Latitude + "\n");
        //        Console.WriteLine("\t Point: " + p.NbLine.RightPoint.Longitude + " / " + p.NbLine.RightPoint.Latitude + "\n");
        //    }
        //    catch
        //    {
        //        Console.WriteLine("No NbLine defined!");
        //    }

        //    Console.Write("Total Forbidden Zones: \t" + p.ForbiddenZones.Count + " \n");
        //    Console.Write("Total Gates : \t\t" + p.Gates.Length / 2 + " \n");

            //int v = 0;
            //int w = 0;
            //foreach (TrackPoint point in comp.getFlight(group).Track)
            //{
            //    if (p.isPointOffTrack(point))
            //    {
            //        Console.WriteLine("Point was off Track: " + point.Latitude.ToString() + " / " + point.Longitude.ToString() + " Timestamp: " + point.TimeStamp.ToString());
            //        v++;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Point was NOT off Track: " + point.Latitude.ToString() + " / " + point.Longitude.ToString() + " Timestamp: " + point.TimeStamp.ToString());
            //        w++;
            //    }
            //}
            //Console.WriteLine("Total Points: " + comp.getFlight(group).Track.Count + "off track: " + v.ToString() + "in track: " + w.ToString());

            //Console.WriteLine("Passed Gate at: " + comp.getFlight(group).PassedGate(p).ToString());

            Console.ReadLine();

        }
    }
}
