using System;
using System.Collections.Generic;
using System.Text;

namespace PFA.ANR.BusinessLayer
{
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            CompetitorGroup group = new CompetitorGroup();
            Competitor comp = new Competitor();
            Race race = new Race();
            race.ImportFlight(group, comp, @"..\..\Tests\Track1_c172.GAC");
            int i = 0;

            foreach (TrackPoint trackpoint in race.Flights.GetFlightByGroupAndCompetitorId(group.Id, comp.Id).Track)
            {
                i++;
                Console.WriteLine(i.ToString("0000") + " " + trackpoint.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude) + " / " + trackpoint.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
                if (i == 280)
                {
                    Console.ReadLine();
                }
            }
            Console.WriteLine();

            GpsPoint point = new GpsPoint(165758.87, 31429.79, GpsPointFormatImport.WGS84);
            Console.WriteLine("Breite: " + point.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge: " + point.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dezimal: " + point.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge dezimal: " + point.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Longitude));
            Console.WriteLine("Breite CH: " + point.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge CH: " + point.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dbl: " + point.Latitude);
            Console.WriteLine("Laenge dbl: " + point.Longitude);
            Console.WriteLine();
            GpsPoint pointCh = new GpsPoint(100000, 700000, GpsPointFormatImport.Swiss);
            Console.WriteLine("Breite: " + pointCh.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge: " + pointCh.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dezimal: " + pointCh.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge dezimal: " + pointCh.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Longitude));
            Console.WriteLine("Breite CH: " + pointCh.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge CH: " + pointCh.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dbl: " + pointCh.Latitude);
            Console.WriteLine("Laenge dbl: " + pointCh.Longitude);
            Console.WriteLine();

            GpsPoint point2 = new GpsPoint(183778.87641427779, 7826.5683202841356, GpsPointFormatImport.WGS84);
            Console.WriteLine("Breite: " + point2.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge: " + point2.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dezimal: " + point2.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge dezimal: " + point2.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Longitude));
            Console.WriteLine("Breite CH: " + point2.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge CH: " + point2.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dbl: " + point2.Latitude);
            Console.WriteLine("Laenge dbl: " + point2.Longitude);
            Console.WriteLine();
            GpsPoint pointCh2 = new GpsPoint(239089, 637231, GpsPointFormatImport.Swiss);
            Console.WriteLine("Breite: " + pointCh2.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge: " + pointCh2.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dezimal: " + pointCh2.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge dezimal: " + pointCh2.ToString(GpsPointFormatString.DegreesDecimal, GpsPointComponent.Longitude));
            Console.WriteLine("Breite CH: " + pointCh2.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));
            Console.WriteLine("Laenge CH: " + pointCh2.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));
            Console.WriteLine("Breite dbl: " + pointCh2.Latitude);
            Console.WriteLine("Laenge dbl: " + pointCh2.Longitude);
            Console.WriteLine();

            Race testRace = new Race();
            testRace.Maps.Add(new Map(@"..\..\635320_251980_668600_230020.jpg"));
            Console.WriteLine(testRace.Map.TopLeftPoint.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude));
            Console.WriteLine(testRace.Map.TopLeftPoint.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
            Console.WriteLine(testRace.Map.BottomRightPoint.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Latitude));
            Console.WriteLine(testRace.Map.BottomRightPoint.ToString(GpsPointFormatString.Degrees, GpsPointComponent.Longitude));
            Console.WriteLine();

            CompetitorGroup testGroup = new CompetitorGroup();
            testGroup.addCompetitor(comp);
            Competitor comp2 = new Competitor();
            Competitor comp3 = new Competitor();
            Competitor comp4 = new Competitor();
            Competitor comp5 = new Competitor();
            testGroup.addCompetitor(comp2);
            testGroup.addCompetitor(comp3);
            testGroup.addCompetitor(comp4);
            testGroup.removeCompetitor(comp3);
            testGroup.addCompetitor(comp5);
            testGroup.moveUp(2);
            testGroup.moveDown(0);

            Console.ReadLine();
        }
    }
}
