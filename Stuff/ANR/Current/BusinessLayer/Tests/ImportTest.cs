using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace PFA.ANR.BusinessLayer
{
    class ImportTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Import Test, testparcours.dxf");
            Race r = new Race();
            r.Location = "Birrfeld";
            r.Date = DateTime.Now;
            r.Name = "Schweizermeisterschaft";
            r.TargetFlightDuration = new TimeSpan(0);

            Parcours p = new Parcours(@"..\..\testparcours2.dxf");

            Competitor comp = new Competitor();
            comp.AcCallsign = "gibb";
            comp.Country = "Switzerland";
            comp.PilotFirstName = "Quack";
            comp.PilotName = "Crashpilot";
            comp.NavigatorFirstName = "Christopher";
            comp.NavigatorName = "Columbus";
            r.Competitors.Add(comp);

            Competitor newComp = new Competitor();
            comp.AcCallsign = "HellouHellou";
            comp.Country = "Switzerland";
            comp.PilotFirstName = "Emilio";
            comp.PilotName = "Sigrist";
            comp.NavigatorFirstName = "Gartenzwerg";
            comp.NavigatorName = "Mutzli";
            r.Competitors.Add(newComp);

            CompetitorGroup group = new CompetitorGroup();
            group.Competitors.Add(comp);

            r.ImportFlight(group, comp, @"..\..\Track1_c172.GAC");
            Flight f = r.Flights.GetFlightByGroupAndCompetitorId(group.Id, comp.Id);
            Console.WriteLine(f.Track[0].ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));
            Console.WriteLine(f.Track[0].ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));

            Map m = new Map(new Bitmap(Image.FromFile(@"..\..\635320_251980_668600_230020.jpg")),
                new GpsPoint(251980, 635320, GpsPointFormatImport.Swiss),
                new GpsPoint(230020, 668600, GpsPointFormatImport.Swiss));
            r.Map = m;

            r.SetMap(@"..\..\635320_251980_668600_230020.jpg");
            
            Image img = Common.drawParcours(m,p);
            img.Save(@"C:\p.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            Process.Start(@"C:\p.bmp");

            Flight flight = r.Flights.GetFlightByGroupAndCompetitorId(group.Id, comp.Id);
            Image img2 = Common.drawFlight(m, p, flight);

            #region

            ////img.Save(@"C:\test.bmp", System.Drawing.Imaging.ImageFormat.Bmp); 

            //// Save object to a file named CarData.dat in binary.
            //BinaryFormatter binFormat = new BinaryFormatter();
            //Stream fStream = new FileStream(@"C:\tRace.anrx", FileMode.Create, FileAccess.Write, FileShare.None);
            //binFormat.Serialize(fStream, r);

            //Stream fStream2 = new FileStream(@"C:\tParcours.anrx", FileMode.Create, FileAccess.Write, FileShare.None);
            //binFormat.Serialize(fStream2, p);
            
            //Stream fStream3 = new FileStream(@"C:\tGroup.anrx", FileMode.Create, FileAccess.Write, FileShare.None);
            //binFormat.Serialize(fStream3, group);
            
            


            //Console.WriteLine("Number of forbidden Zones" + p.ForbiddenZones.Count);
            //foreach(ForbiddenZone f in p.ForbiddenZones)
            //{
            //    Console.WriteLine("Zone: \n");
            //    foreach (GpsPoint pt in f.GpsPoints)
            //    {
            //        Console.WriteLine("\t Point: " + pt.Longitude + " / " + pt.Latitude + "\n");
            //    }
            //}

            //for(int i =0;i<p.Gates.Length / 2; i++)
            //{
            //    Console.WriteLine("Track: \n");
            //    Console.WriteLine("Starting Gate: \n");
            //    Console.WriteLine("\t Point: " + p.Gates[i,0].LeftPoint.Longitude + " / " + p.Gates[i,0].LeftPoint.Latitude + "\n");
            //    Console.WriteLine("\t Point: " + p.Gates[i,0].RightPoint.Longitude + " / " + p.Gates[i,0].RightPoint.Latitude + "\n");
            //    Console.WriteLine("Finishing Gate:");
            //    Console.WriteLine("\t Point: " + p.Gates[i, 1].LeftPoint.Longitude + " / " + p.Gates[i, 1].LeftPoint.Latitude + "\n");
            //    Console.WriteLine("\t Point: " + p.Gates[i, 1].RightPoint.Longitude + " / " + p.Gates[i, 1].RightPoint.Latitude + "\n");

            //    Console.WriteLine("\t Point in CH Coord " + m.TopLeftPoint.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Longitude));
            //    Console.WriteLine("\t Point in CH Coord " + m.TopLeftPoint.ToString(GpsPointFormatString.Swiss, GpsPointComponent.Latitude));

            //}

            //Console.WriteLine("NbLine: \n");
            //try
            //{
            //    Console.WriteLine("\t Point: " + p.NbLine.LeftPoint.Longitude + " / " + p.NbLine.LeftPoint.Latitude + "\n");
            //    Console.WriteLine("\t Point: " + p.NbLine.RightPoint.Longitude + " / " + p.NbLine.RightPoint.Latitude + "\n");
            //}
            //catch
            //{
            //    Console.WriteLine("No NbLine defined!");
            //}

            //Console.Write("Total Forbidden Zones: \t" + p.ForbiddenZones.Count + " \n");
            //Console.Write("Total Gates : \t\t" + p.Gates.Length / 2 + " \n");

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

            #endregion

            foreach (Penalty penalty in flight.Penalties)
            {
                Console.WriteLine(penalty.PenaltyPoints.ToString() + " " + penalty.PenaltyType.ToString() + " " + penalty.Comment.ToString());
            }

            for (int i = 0; i < flight.Track.Count - 2; i++)
            {
                for(int j = 0; j<4;j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        //Gate gate = p.Gates[j, k];
                        // ToDo: get flights
                        //if (Common.gatePassed(gate, comp.getFlight(group).Track[i], comp.getFlight(group).Track[i + 1]))
                        //{
                        //    if (k == 0)
                        //    {
                        //        Console.WriteLine("passed Start Gate " + j + " at :" + comp.getFlight(group).Track[i].TimeStamp.ToString());
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("passed finishing Gate " + j + " at :" +comp.getFlight(group).Track[i].TimeStamp.ToString());
                        //    }
                        //}
                    }
                }
            }

            // ToDo: get flight
            //comp.getFlight(group).Penalties.AddRange(list);
            //PdfSharp.Pdf.PdfDocument doc = Common.createPdf(comp, comp.getFlight(group), r, p);
            //doc.Save("C:\\test.pdf");
            Process.Start("C:\\test.pdf");
            Console.ReadLine();
        }
    }
}
