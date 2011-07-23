using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Data;


namespace ANR.Core
{
    public static class Common
    {
        /// <summary>
        /// Creates a Flight Data Sheet for the specified Flight in the PdfSharp.PdfDocument Format.
        /// </summary>
        /// <param name="competitor"></param>
        /// <param name="flight"></param>
        /// <param name="race"></param>
        /// <param name="parcours"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static PdfDocument createPdf(Competition competition, Competitor competitor, Flight flight, Race race, Parcours parcours)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            
            // Create a font
            XFont font = new XFont("Verdana", 14, XFontStyle.Bold);
            XFont font2 = new XFont("Verdana", 10, XFontStyle.Regular);
            XFont font3 = new XFont("Verdana", 10, XFontStyle.Regular);

            // Draw the text
            string headingText = "Results for " + race.Name + ", " + competition.Date.ToString("dd.MM.yyyy") + " in " + competition.Location;
            gfx.DrawString(headingText, font, XBrushes.DarkMagenta, new XPoint(50, 50), XStringFormat.TopLeft);

            string pilotLine = "Pilot: " + competitor.PilotName + ", " + competitor.PilotFirstName;
            gfx.DrawString(pilotLine, font2, XBrushes.Black, new XPoint(50, 90), XStringFormat.TopLeft);

            string copilotLine = "Navigator: " + competitor.NavigatorName + ", " + competitor.NavigatorFirstName;
            gfx.DrawString(copilotLine, font2, XBrushes.Black, new XPoint(50, 110), XStringFormat.TopLeft);

            string takeoffTime = "Takeoff time: " + flight.TakeOffTime.ToString("HH.mm.ss");
            gfx.DrawString(takeoffTime, font2, XBrushes.Black, new XPoint(50, 130), XStringFormat.TopLeft);

            string startTime = "Start Time: " + flight.StartGateTime.ToString("HH.mm.ss");
            gfx.DrawString(startTime, font2, XBrushes.Black, new XPoint(50, 150), XStringFormat.TopLeft);
            
            string finishTime = "Finish Time: " + flight.FinishGateTime.ToString("HH.mm.ss");
            gfx.DrawString(finishTime, font2, XBrushes.Black, new XPoint(250, 150), XStringFormat.TopLeft);

            Image image = Common.drawFlight(parcours.ParentMap, parcours, flight);
            int originalHeight = image.Height;
            int originalWidth = image.Width;
            XImage xImage = XImage.FromGdiPlusImage(image);
            double ratio = (double)image.Height / (double)image.Width;
            int height = (int)Math.Ceiling((page.Width.Point - 100) * ratio);
            gfx.DrawImage(xImage, 50, 180, page.Width.Point - 100, height);

            gfx.DrawString("Penalties", font2, XBrushes.Black, 50, height + 200);
            int position = height + 220;
            int i = 0;

            foreach (Penalty penalty in flight.AutomaticPenalties)
            {
                if ((position + i * 20) <= page.Height.Point - 50)
                {
                    gfx.DrawString(penalty.PenaltyPoints.ToString(), font3, XBrushes.Gray, 60, (position + i * 20));
                    gfx.DrawString(penalty.PenaltyType.ToString() + ", " + penalty.Comment, font2, XBrushes.Gray, 120, (position + i * 20));
                    i++;
                }
                else
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    i = 0;
                    position = 50;
                }
            }
            return document;
        }
        /// <summary>
        /// Creates an Image of the specified Parcours, including all ForbiddenZones, Gates and the NoBackLine
        /// </summary>
        /// <param name="map"></param>
        /// <param name="parcours"></param>
        /// <returns></returns>
        public static Image drawParcours(Parcours parcours)
        {
            Map map = parcours.ParentMap;

            // create a canvas for painting on
            Image img = (Image)map.Image.Clone();
            Bitmap pg = new Bitmap(img.Width, img.Height);
            Graphics gr = Graphics.FromImage(pg);

            // clear the canvas to white
            Rectangle pgRect = new Rectangle(0, 0, pg.Width, pg.Height);
            SolidBrush solidWhite = new SolidBrush(Color.White);
            gr.FillRectangle(solidWhite, pgRect);
            // load a new image and draw it centered on our canvas

            Rectangle rc = new Rectangle(0, 0, img.Width, img.Height);
            gr.DrawImage(img, rc);
            img.Dispose();
            
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(150, 250, 00, 20)), 5.0f);
            SolidBrush sb = new SolidBrush(Color.FromArgb(50, 250, 00, 20));
            double imagePointsLongitudeDifference = map.BottomRightPoint.Longitude - map.TopLeftPoint.Longitude;
            double imagePointsLatitudeDifference = map.TopLeftPoint.Latitude - map.BottomRightPoint.Latitude;

            foreach (ForbiddenZone fz in parcours.ForbiddenZones)
            {
                Point[] points = new Point[fz.GpsPoints.Count];
                int i = 0;

                foreach (GpsPoint gpsPoint in fz.GpsPoints)
                {
                    double currentPointLongitudeDifference = gpsPoint.Longitude - map.TopLeftPoint.Longitude;
                    double currentPointLatitudeDifference = map.TopLeftPoint.Latitude - gpsPoint.Latitude;
                    double currentPointImageX = (currentPointLongitudeDifference / imagePointsLongitudeDifference) * pg.Width;
                    double currentPointImageY = (currentPointLatitudeDifference / imagePointsLatitudeDifference) * pg.Height;

                    int mapPointX = int.Parse(Math.Ceiling(currentPointImageX).ToString());
                    int mapPointY = int.Parse(Math.Ceiling(currentPointImageY).ToString());
                    points[i] = new Point(mapPointX, mapPointY);
                    i++;
                }
                gr.FillPolygon(sb, points);
                gr.DrawPolygon(pen, points);
            }
            //Draw Gates..
            Pen pen2 = new Pen(Brushes.Black, 10.0f);

            foreach (Route route in parcours.Routes)
            {
                if (route.StartGate != null && route.EndGate != null)
                {
                    List<Gate> gates = new List<Gate>();
                    gates.Add(route.StartGate);
                    gates.Add(route.EndGate);
                    foreach (Gate gate in gates)
                    {
                        double currentPoint1LongitudeDifference = gate.LeftPoint.Longitude - map.TopLeftPoint.Longitude;
                        double currentPoint1LatitudeDifference = map.TopLeftPoint.Latitude - gate.LeftPoint.Latitude;

                        double currentPoint2LongitudeDifference = gate.RightPoint.Longitude - map.TopLeftPoint.Longitude;
                        double currentPoint2LatitudeDifference = map.TopLeftPoint.Latitude - gate.RightPoint.Latitude;

                        double currentPoint1ImageY = (currentPoint1LatitudeDifference / imagePointsLatitudeDifference) * pg.Height;
                        double currentPoint1ImageX = (currentPoint1LongitudeDifference / imagePointsLongitudeDifference) * pg.Width;

                        double currentPoint2ImageY = (currentPoint2LatitudeDifference / imagePointsLatitudeDifference) * pg.Height;
                        double currentPoint2ImageX = (currentPoint2LongitudeDifference / imagePointsLongitudeDifference) * pg.Width;

                        int mapPoint1X = int.Parse(Math.Ceiling(currentPoint1ImageX).ToString());
                        int mapPoint1Y = int.Parse(Math.Ceiling(currentPoint1ImageY).ToString());
                        int mapPoint2X = int.Parse(Math.Ceiling(currentPoint2ImageX).ToString());
                        int mapPoint2Y = int.Parse(Math.Ceiling(currentPoint2ImageY).ToString());
                        gr.DrawLine(pen2, new Point(mapPoint1X, mapPoint1Y), new Point(mapPoint2X, mapPoint2Y));
                    }
                }
            }
            if (parcours.NbLine.LeftPoint != null && parcours.NbLine.RightPoint != null)
            {
                double currentNbLinePoint1LatitudeDifference = map.TopLeftPoint.Latitude - parcours.NbLine.LeftPoint.Latitude;
                double currentNbLinePoint1LongitudeDifference = parcours.NbLine.LeftPoint.Longitude - map.TopLeftPoint.Longitude;

                double currentNbLinePoint2LatitudeDifference = parcours.NbLine.RightPoint.Latitude - map.TopLeftPoint.Latitude;
                double currentNbLinePoint2LongitudeDifference = parcours.NbLine.RightPoint.Longitude - map.TopLeftPoint.Longitude;

                double currentNbLinePoint1ImageX = (currentNbLinePoint1LatitudeDifference / imagePointsLatitudeDifference) * pg.Width;
                double currentNbLinePoint1ImageY = (currentNbLinePoint1LongitudeDifference / imagePointsLongitudeDifference) * pg.Height;

                double currentNbLinePoint2ImageX = (currentNbLinePoint2LatitudeDifference / imagePointsLatitudeDifference) * pg.Width;
                double currentNbLinePoint2ImageY = (currentNbLinePoint2LongitudeDifference / imagePointsLongitudeDifference) * pg.Height;


                int mapNbLinePoint1X = int.Parse(Math.Ceiling(currentNbLinePoint1ImageX).ToString());
                int mapNbLinePoint1Y = int.Parse(Math.Ceiling(currentNbLinePoint1ImageY).ToString());
                int mapNbLinePoint2X = int.Parse(Math.Ceiling(currentNbLinePoint2ImageX).ToString());
                int mapNbLinePoint2Y = int.Parse(Math.Ceiling(currentNbLinePoint2ImageY).ToString());

                gr.DrawLine(new Pen(Brushes.DarkBlue), new Point(mapNbLinePoint1X, mapNbLinePoint1Y), new Point(mapNbLinePoint2X, mapNbLinePoint2Y));
            }
            return pg;
        }
        /// <summary>
        /// Draw the Image of the flights of a Group
        /// </summary>
        /// <param name="map"></param>
        /// <param name="parcours"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static Image drawGroupFlights(Race race, Map map, Parcours parcours, CompetitorGroup group)
        {
            int competitorCounter = 0;
            
            Image img = drawParcours(parcours);
            Bitmap pg = new Bitmap(img.Width, img.Height);
            Graphics gr = Graphics.FromImage(pg);

            // clear the canvas to white
            Rectangle pgRect = new Rectangle(0, 0, pg.Width, pg.Height);
            SolidBrush solidWhite = new SolidBrush(Color.White);
            gr.FillRectangle(solidWhite, pgRect);
            // load a new image and draw it centered on our canvas

            Rectangle rc = new Rectangle(0, 0, img.Width, img.Height);
            gr.DrawImage(img, rc);
            img.Dispose();

            foreach (CompetitorRouteAssignment cra in group.CompetitorRouteAssignmentCollection)
            {
                Competitor competitor = cra.Competitor;

                Flight flight = race.Flights.GetFlightByGroupAndCompetitorId(group, competitor);
                Pen[] pens = new Pen[] { new Pen(Brushes.Blue, 3.0f), new Pen(Brushes.Aquamarine, 3.0f), new Pen(Brushes.BlueViolet, 3.0f), new Pen(Brushes.DeepSkyBlue, 3.0f) };
                Pen penInZone = new Pen(Brushes.LawnGreen, 5.0f);
                SolidBrush sb = new SolidBrush(Color.FromArgb(50, 250, 00, 20));
                double imagePointsLongitudeDifference = map.BottomRightPoint.Longitude - map.TopLeftPoint.Longitude;
                double imagePointsLatitudeDifference = map.TopLeftPoint.Latitude - map.BottomRightPoint.Latitude;


                Point[] points = new Point[flight.Track.Count];
                DateTime expectedFinishingTime = flight.StartGateTime.AddMinutes(parcours.DefaultTargetFlightDuration.TotalMinutes + 1);

                int i = 0;
                bool lastPointWasOffTrack = false;
                bool passedFinishingGate = false;
                List<Point> penaltyPoints = new List<Point>();
                List<List<Point>> penaltyPointsList = new List<List<Point>>();
                foreach (TrackPoint trackPoint in flight.Track)
                {

                    double currentPointLongitudeDifference = trackPoint.Longitude - map.TopLeftPoint.Longitude;
                    double currentPointLatitudeDifference = map.TopLeftPoint.Latitude - trackPoint.Latitude;
                    double currentPointImageX = (currentPointLongitudeDifference / imagePointsLongitudeDifference) * pg.Width;
                    double currentPointImageY = (currentPointLatitudeDifference / imagePointsLatitudeDifference) * pg.Height;

                    int mapPointX = int.Parse(Math.Ceiling(currentPointImageX).ToString());
                    int mapPointY = int.Parse(Math.Ceiling(currentPointImageY).ToString());

                    
                    GraphicsPath p = new GraphicsPath();
                    foreach (Route route in parcours.Routes)
                    {
                        if (route.EndGate.gatePassed(trackPoint, flight.Track[i + 1]) || trackPoint.TimeStamp > expectedFinishingTime)
                        {
                            passedFinishingGate = true;
                        }
                    }
                    if (!passedFinishingGate && parcours.IsPointOffTrack(trackPoint))
                    {
                        lastPointWasOffTrack = true;
                        penaltyPoints.Add(new Point(mapPointX, mapPointY));
                    }
                    else
                    {
                        if (lastPointWasOffTrack)
                        {
                            penaltyPointsList.Add(penaltyPoints);
                            penaltyPoints = new List<Point>();
                        }
                        lastPointWasOffTrack = false;
                    }

                    points[i] = new Point(mapPointX, mapPointY);
                    if (i < flight.Track.Count - 2)
                    {
                        i++;
                    }
                }
                gr.DrawLines(pens[competitorCounter], points);

                foreach (List<Point> penaltyPts in penaltyPointsList)
                {
                    Point[] pointarray = penaltyPts.ToArray();
                    gr.DrawLines(penInZone, pointarray);
                }
                competitorCounter++;
            }
            return pg;
        }
        /// <summary>
        /// Creates an Image of the specified Flight of a Competitor of a Group in the specified Parcours 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="parcours"></param>
        /// <param name="competitor"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static Image drawFlight(Map map, Parcours parcours, Flight flight)
        {
            Image img = drawParcours(parcours);
            Bitmap pg = new Bitmap(img.Width, img.Height);
            Graphics gr = Graphics.FromImage(pg);

            // clear the canvas to white
            Rectangle pgRect = new Rectangle(0, 0, pg.Width, pg.Height);
            SolidBrush solidWhite = new SolidBrush(Color.White);
            gr.FillRectangle(solidWhite, pgRect);
            // load a new image and draw it centered on our canvas

            Rectangle rc = new Rectangle(0, 0, img.Width, img.Height);
            gr.DrawImage(img, rc);
            img.Dispose();

            Pen pen = new Pen(Brushes.Blue, 3.0f);
            Pen penInZone = new Pen(Brushes.LawnGreen, 5.0f);
            SolidBrush sb = new SolidBrush(Color.FromArgb(50, 250, 00, 20));
            double imagePointsLongitudeDifference = map.BottomRightPoint.Longitude - map.TopLeftPoint.Longitude;
            double imagePointsLatitudeDifference = map.TopLeftPoint.Latitude - map.BottomRightPoint.Latitude;


            Point[] points = new Point[flight.Track.Count];

            int i = 0;
            bool lastPointWasOffTrack = false;
            bool passedFinishingGate = false;
            DateTime expectedFinishingTime = flight.StartGateTime.AddMinutes(parcours.DefaultTargetFlightDuration.TotalMinutes + 1);
            List<Point> penaltyPoints = new List<Point>();
            List<List<Point>> penaltyPointsList = new List<List<Point>>();
            foreach (TrackPoint trackPoint in flight.Track)
            {
                
                double currentPointLongitudeDifference = trackPoint.Longitude - map.TopLeftPoint.Longitude;
                double currentPointLatitudeDifference = map.TopLeftPoint.Latitude - trackPoint.Latitude;
                double currentPointImageX = (currentPointLongitudeDifference / imagePointsLongitudeDifference) * pg.Width;
                double currentPointImageY = (currentPointLatitudeDifference / imagePointsLatitudeDifference) * pg.Height;

                int mapPointX = int.Parse(Math.Ceiling(currentPointImageX).ToString());
                int mapPointY = int.Parse(Math.Ceiling(currentPointImageY).ToString());

                GraphicsPath p = new GraphicsPath();
                
                if (flight.Route.EndGate.gatePassed(trackPoint, flight.Track[i + 1]))
                {
                    passedFinishingGate = true;
                }
                if (trackPoint.TimeStamp > expectedFinishingTime)
                {
                    passedFinishingGate = true;
                }
                if (!passedFinishingGate && parcours.IsPointOffTrack(trackPoint))
                {
                    lastPointWasOffTrack = true;
                    penaltyPoints.Add(new Point(mapPointX, mapPointY));
                }
                else
                {
                    if (lastPointWasOffTrack)
                    {
                        penaltyPointsList.Add(penaltyPoints);
                        penaltyPoints = new List<Point>();
                    }
                    lastPointWasOffTrack = false;
                }
            
                points[i] = new Point(mapPointX, mapPointY);
                if (i < flight.Track.Count-2)
                {
                    i++;
                }
            }
                gr.DrawLines(pen, points);

            foreach (List<Point> penaltyPts in penaltyPointsList)
            {
                Point[] pointarray = penaltyPts.ToArray();
                gr.DrawLines(penInZone, pointarray);
            }

            return pg;
       }
        /// <summary>
        /// Saves the specified PdfDocument to a specified Location.
        /// </summary>
        /// <param name="doc">PfdDocument to save</param>
        /// <param name="filename">Filepath (e.g. C:\flight.pdf). String must contain file Ending</param>
        public static void savePdf(Competition competition, Competitor competitor, Flight flight, Race race, Parcours parcours, string filename)
        {
            createPdf(competition, competitor, flight, race, parcours).Save(filename);
        }
        /// <summary>
        /// Saves the specified Image to a specified Location using the .bmp Format
        /// </summary>
        /// <param name="image">Image to save</param>
        /// <param name="filename">Filepath (e.g. C:\image.bmp)</param>
        public static void saveImage(Image image, string filename)
        {
            image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
       
        
        public class TotalResult
        {
            Competitor competitor;
            double result;
            int rank;

            public double Result
            {
                get { return result; }
                set { result = value; }
            }
            public Competitor Competitor
            {
              get { return competitor; }
              set { competitor = value; }
            }

            public TotalResult(Competitor competitor, double result)
            {
                this.Competitor = competitor; 
                this.Result = result;
            }

            public int Rank
            {
                get { return rank; }
                set { rank = value; }
            }
            
        }           

        public static List<TotalResult> calculateRankingList(Race race)
        {
            List<TotalResult> rankingList = new List<TotalResult>();
            foreach (CompetitorGroup group in race.CompetitorGroups)
            {
                foreach(CompetitorRouteAssignment cra in group.CompetitorRouteAssignmentCollection)
                {
                    List<int> flightPenalties = new List<int>();
                    foreach (Flight flight in race.Flights.GetFlightsByCompetitor(cra.Competitor))
                    {
                        flight.resetPenalties();
                        int sumOfPenaltiesPerFlight = 0;
                        foreach (Penalty penalty in flight.Penalties)
                        {
                            sumOfPenaltiesPerFlight += penalty.PenaltyPoints;
                        }
                        flightPenalties.Add(sumOfPenaltiesPerFlight);
                    }
                    double average = 0;
                    if (flightPenalties.Count > 0)
                    {
                        average = flightPenalties.Average();
                    }
                    rankingList.Add(new TotalResult(cra.Competitor, average));
                }
            }
            rankingList.Sort(delegate(TotalResult x, TotalResult y) { return x.Result.CompareTo(y.Result); });
            int rank = 1;
            foreach (TotalResult totalResult in rankingList)
            {
                totalResult.Rank = rank;
                rank++;
            }
           // stuffsList.Sort(delegate(MyStuff x, MyStuff y) { return Decimal.Compare(x.TheValue, y.TheValue); });
            return rankingList;
        }
        
        /// <summary>
        /// saves the ranking List to the specified location
        /// </summary>
        /// <param name="race"></param>
        /// <param name="filename"></param>
        public static void saveRankingList(Race race, string filename)
        {
            List<TotalResult> rankList  = Common.calculateRankingList(race);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};",
                   "Rank", "Result (Total Penalties)", "Start No", "AC-Callsign", "Pilot Firstname",
                   "Pilot Name", "Navigator Firstname", "Navigator Name", "Country"));
            foreach (TotalResult res in rankList)
            {
                Competitor competitor = res.Competitor;
                sb.AppendLine(String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};",
                    res.Rank, res.Result, competitor.CompetitionNumber, competitor.AcCallsign, competitor.PilotFirstName, 
                    competitor.PilotName, competitor.NavigatorFirstName, competitor.NavigatorName, competitor.Country ));
            }
            StreamWriter sw = new StreamWriter(filename);
            sw.Write(sb.ToString());
            sw.Close();
        }

        public static void saveRaceStartlist(Race r, string filename)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};", 
                   "Start Time", "Start No", "AC-Callsign", "Pilot Firstname",
                   "Pilot Name", "Navigator Firstname", "Navigator Name", "Country"));
            SortedList<DateTime, Competitor> startlist = new SortedList<DateTime, Competitor>();
            foreach(CompetitorGroup cg in r.CompetitorGroups)
            {       
                foreach(CompetitorRouteAssignment cra in cg.CompetitorRouteAssignmentCollection)
                {
                    startlist.Add(cra.TakeoffTime, cra.Competitor);
                }
            }
            foreach (KeyValuePair<DateTime,Competitor> c in startlist)
            {
                sb.AppendLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};",
                    c.Key.ToString("HH:mm:ss"), c.Value.CompetitionNumber, c.Value.AcCallsign, c.Value.PilotFirstName, 
                    c.Value.PilotName, c.Value.NavigatorFirstName, c.Value.NavigatorName, c.Value.Country));
            }
            StreamWriter sw = new StreamWriter(filename);
            sw.Write(sb.ToString());
            sw.Close();
        }

        
        ///// <summary>
        ///// Returns a Sorted List (by Penalties) of Competitors for the specified Group
        ///// </summary>
        ///// <param name="competitorGroup"></param>
        ///// <returns></returns>
        //public static SortedList<Competitor, int> calculateGroupRankingList(CompetitorGroup competitorGroup)
        //{
        //    SortedList<Competitor, int> competitorsFlightPenalties = new SortedList<Competitor, int>();
        //    foreach (Competitor competitor in competitorGroup.Competitors)
        //    {
        //        int sumOfPenaltiesPerFlight = 0;
        //         //ToDo: get competitors flight and penalties
        //        foreach (Penalty penalty in competiti)
        //        {
        //            sumOfPenaltiesPerFlight += penalty.PenaltyPoints;
        //        }
        //        competitorsFlightPenalties.Add(competitor, sumOfPenaltiesPerFlight);
        //    }
        //    return competitorsFlightPenalties;
        //}

    }
}
