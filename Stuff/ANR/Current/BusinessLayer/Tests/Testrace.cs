using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PFA.ANR.BusinessLayer.Tests
{
    public static class Testrace
    {
        public static Race getTestRace()
        {
            Competition comp = new Competition();
            comp.Location = "Birrfeld";

            Race r = new Race();
            r.Date = DateTime.Now;
            r.Name = "Schweizermeisterschaft";


            string localPath = System.IO.Directory.GetCurrentDirectory();
            
            Parcours p = new Parcours(localPath + @"\Tests\testparcours2.dxf");
            r.ParcoursCollection.Add(p);
            r.TargetFlightDuration = new TimeSpan(0);

            Competitor comp = new Competitor();
            comp.AcCallsign = "gibb";
            comp.Country = "Switzerland";
            comp.PilotFirstName = "Quack";
            comp.PilotName = "Crashpilot";
            comp.NavigatorFirstName = "Christopher";
            comp.NavigatorName = "Columbus";
            r.Competitors.Add(comp);

            CompetitorGroup group = new CompetitorGroup();
            group.Competitors.Add(comp);
            r.CompetitorGroups.Add(group);

            Flight f = new Flight(localPath + @"\Tests\Track1_c172.GAC", p.Routes[0], p);
            f.CompetitorGroup = group;
            f.Competitor = comp;
            r.Flights = new FlightCollection();
            r.Flights.Add(f);

            //r.ImportFlight(group, comp, localPath + @"\Tests\Track1_c172.GAC");
            //Flight f = r.Flights.GetFlightByGroupAndCompetitorId(group.Id, comp.Id);

            Map m = new Map(new Bitmap(Image.FromFile(localPath + @"\Tests\635320_251980_668600_230020.jpg")),
                new GpsPoint(251980, 635320, GpsPointFormatImport.Swiss),
                new GpsPoint(230020, 668600, GpsPointFormatImport.Swiss));
            r.Map = m;

            //r.SetMap(@"..\..\635320_251980_668600_230020.jpg");
            return r;
        }
    }
}
