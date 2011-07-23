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


namespace PFA.ANR.BusinessLayer
{
    public class Common
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
        public static PdfDocument createPdf(Competitor competitor, Flight flight, Race race, Parcours parcours)
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
            string headingText = "Results for " + race.Name + ", " + race.Date.ToString("dd.MM.yyyy") + " in " + race.Location;
            gfx.DrawString(headingText, font, XBrushes.DarkMagenta, new XPoint(50, 50), XStringFormat.TopLeft);

            string pilotLine = "Pilot: " + competitor.PilotName + ", " + competitor.PilotFirstName;
            gfx.DrawString(pilotLine, font2, XBrushes.Black, new XPoint(50, 90), XStringFormat.TopLeft);

            string copilotLine = "Navigator: " + competitor.NavigatorName + ", " + competitor.NavigatorFirstName;
            gfx.DrawString(copilotLine, font2, XBrushes.Black, new XPoint(50, 110), XStringFormat.TopLeft);

            string takeoffTime = "Takeoff time: " + Common.startingGatePassingTime(parcours, flight).ToString("HH.mm.ss");
            gfx.DrawString(takeoffTime, font2, XBrushes.Black, new XPoint(50, 130), XStringFormat.TopLeft);

            string startTime = "Start Time: " + Common.startingGatePassingTime(parcours, flight).ToString("HH.mm.ss");
            gfx.DrawString(startTime, font2, XBrushes.Black, new XPoint(50, 150), XStringFormat.TopLeft);
            
            string finishTime = "Finish Time: " + Common.finishingGatePassingTime(parcours, flight).ToString("HH.mm.ss");
            gfx.DrawString(finishTime, font2, XBrushes.Black, new XPoint(250, 150), XStringFormat.TopLeft);

            Image image = Common.drawFlight(race.Map, parcours, flight);
            int originalHeight = image.Height;
            int originalWidth = image.Width;
            XImage xImage = XImage.FromGdiPlusImage(image);
            double ratio = (double)image.Height / (double)image.Width;
            int height = (int)Math.Ceiling((page.Width.Point - 100) * ratio);
            gfx.DrawImage(xImage, 50, 180, page.Width.Point - 100, height);

            gfx.DrawString("Penalties", font2, XBrushes.Black, 50, height + 200);
            int position = height + 220;
            int i = 0;

            foreach (Penalty penalty in flight.Penalties)
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
        public static Image drawParcours(Map map, Parcours parcours)
        {
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
            Pen pen2 = new Pen(Brushes.Black, 10.0f);
            for (int i = 0; i < parcours.Gates.Count / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    double currentPoint1LongitudeDifference = parcours.Gates[i, j].LeftPoint.Longitude - map.TopLeftPoint.Longitude;
                    double currentPoint1LatitudeDifference = map.TopLeftPoint.Latitude - parcours.Gates[i, j].LeftPoint.Latitude;

                    double currentPoint2LongitudeDifference = parcours.Gates[i, j].RightPoint.Longitude - map.TopLeftPoint.Longitude;
                    double currentPoint2LatitudeDifference = map.TopLeftPoint.Latitude - parcours.Gates[i, j].RightPoint.Latitude;

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

            try
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
            catch { }
            return pg;
        }

        public static Image drawGroupFlights(Map map, Parcours parcours, CompetitorGroup group)
        {
           
            int competitorCounter = 0;
            
            Image img = drawParcours(map, parcours);
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
            foreach (Competitor competitor in group.Competitors)
            {
                //Flight flight = competitor.getFlight(group);
                // ToDo: get flight
                Flight flight = null;
                Pen[] pens = new Pen[]{new Pen(Brushes.Blue, 3.0f), new Pen(Brushes.Aquamarine, 3.0f), new Pen(Brushes.BlueViolet, 3.0f), new Pen(Brushes.DeepSkyBlue, 3.0f)};
                Pen penInZone = new Pen(Brushes.LawnGreen, 5.0f);
                SolidBrush sb = new SolidBrush(Color.FromArgb(50, 250, 00, 20));
                double imagePointsLongitudeDifference = map.BottomRightPoint.Longitude - map.TopLeftPoint.Longitude;
                double imagePointsLatitudeDifference = map.TopLeftPoint.Latitude - map.BottomRightPoint.Latitude;


                Point[] points = new Point[flight.Track.Count];

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
                    for (int j = 0; j < 4; j++)
                    {
                        if (Common.gatePassed(parcours.Gates[j, 1], trackPoint, flight.Track[i + 1]))
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
            Image img = drawParcours(map, parcours);
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
                for (int j = 0; j < 4; j++)
                {
                    if (Common.gatePassed(parcours.Gates[j, 1], trackPoint, flight.Track[i + 1]))
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
        /// Saves the Race to the specified Location on the local Computer using a BinaryFormatter. The File contains the binary representation of a Race Object, including all Child-Objects (= all collected data)
        /// </summary>
        /// <param name="filename">Filename for the File. The Ending must be .anrx, elsewise the file will not work!</param>
        /// <param name="race">Race Object to save.</param>
        public static void saveRace(string filename, Race race)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            binaryFormatter.Serialize(fStream, race);
        }
        /// <summary>
        /// Loads a saved .anrx File and tries to Parse it to a Race object.
        /// </summary>
        /// <param name="filename">filename of a saved race.</param>
        /// <returns></returns>
        public static Race loadRace(string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream fStream = File.OpenRead(filename);
            return (Race)binaryFormatter.Deserialize(fStream);
        }
        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public static Parcours importFromDxf(string filepath)
        {
            Parcours parcours = new Parcours();

            StreamReader sr = new StreamReader(filepath);
            List<string> lineList = new List<string>();
            while (!sr.EndOfStream)
            {
                lineList.Add(sr.ReadLine());
            }
            string[] lines = lineList.ToArray();
            for (int i = 1; i < lines.Length; i++) //Looping through Array, starting with 1 (lines[0] is "0")
            {
                //Find Lines Containing a new Element Definition
                if (lines[i] == "LWPOLYLINE" && lines[i - 1] == "  0") //
                {
                    //Reading out Layer ( "8" [\n] layerName) = Type of Element
                    if (lines[i + 5] == "  8" && lines[i + 6].Contains("PROH")) // "Prohibited Zone" = ForbiddenZone
                    {
                        if (lines[i + 9] == " 90")
                        {
                            int numberOfVertexes = int.Parse(lines[i + 10]);
                            ForbiddenZone forbiddenZone = new ForbiddenZone();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {
                                forbiddenZone.AddGpsPoint(new GpsPoint(double.Parse(lines[i + (j * 4) + 18]) * 1000, double.Parse(lines[i + (j * 4) + 16]) * 1000, GpsPointFormatImport.Swiss));
                            }
                            parcours.ForbiddenZones.Add(forbiddenZone);
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        Gate g = new Gate(new GpsPoint(double.Parse(lines[i + 18]) * 1000, double.Parse(lines[i + 16]) * 1000, GpsPointFormatImport.Swiss),
                                     new GpsPoint(double.Parse(lines[i + 22]) * 1000, double.Parse(lines[i + 20]) * 1000, GpsPointFormatImport.Swiss));

                        int gatenr = int.Parse(lines[i + 6].Substring(11, 1)) - 1;
                        // ToDo: add gate
                        //parcours.addGate(g, gatenr, 0);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        Gate g = new Gate(new GpsPoint(double.Parse(lines[i + 18]) * 1000, double.Parse(lines[i + 16]) * 1000, GpsPointFormatImport.Swiss),
                                     new GpsPoint(double.Parse(lines[i + 22]) * 1000, double.Parse(lines[i + 20]) * 1000, GpsPointFormatImport.Swiss));

                        int gatenr = int.Parse(lines[i + 6].Substring(9, 1)) - 1;
                        // ToDo: add gate
                        //parcours.addGate(g, gatenr, 1);
                        //parcours.gates[gatenr, 1] = g;
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if (lines[i + 9] == " 90" && double.Parse(lines[10]) == 2)
                        {
                            parcours.NbLine = new Gate(new GpsPoint(double.Parse(lines[i + 18]) * 1000, double.Parse(lines[i + 16]) * 1000, GpsPointFormatImport.Swiss),
                                new GpsPoint(double.Parse(lines[i + 22]) * 1000, double.Parse(lines[i + 20]) * 1000, GpsPointFormatImport.Swiss));
                        }
                    }
                }
            }
            return parcours;
        }
        /// <summary>
        /// Imports a GAC File of a Flight.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>The created Flight object</returns>
        public static Flight importFromGAC(string filename)
        {
            Flight newFlight = new Flight();
            StreamReader gacFileStreamReader = new StreamReader(filename);
            string line = string.Empty;
            DateTime newPointTimeStamp = DateTime.Now;
            double newPointLatitude = 0;
            double newPointLongitude = 0;
            line = gacFileStreamReader.ReadLine();
            while (!line.Substring(0, 1).Equals("I") && !gacFileStreamReader.EndOfStream)
            {
                line = gacFileStreamReader.ReadLine();
            }
            {
                while (!gacFileStreamReader.EndOfStream)
                {
                    line = gacFileStreamReader.ReadLine();
                    if (line.Substring(0, 1).Equals("B"))
                    {
                        // timestamp
                        newPointTimeStamp = new DateTime(1, 1, 1, Convert.ToInt32(line.Substring(1, 2)), Convert.ToInt32(line.Substring(3, 2)), Convert.ToInt32(line.Substring(5, 2)));
                        // latitude
                        newPointLatitude = Convert.ToDouble(line.Substring(7, 2)) * 3600 + Convert.ToDouble(line.Substring(9, 2)) * 60 + Convert.ToDouble(line.Substring(11, 3)) * 60 / 1000;
                        switch (line.Substring(14, 1))
                        {
                            case "N":
                                break;
                            case "S":
                                newPointLatitude *= (-1);
                                break;
                            default:
                                // TODO: Error
                                break;
                        }
                        // longitude
                        newPointLongitude = Convert.ToDouble(line.Substring(15, 3)) * 3600 + Convert.ToDouble(line.Substring(18, 2)) * 60 + Convert.ToDouble(line.Substring(20, 3)) * 60 / 1000;
                        switch (line.Substring(23, 1))
                        {
                            case "E":
                                break;
                            case "W":
                                newPointLongitude *= (-1);
                                break;
                            default:
                                // ToDo: Error
                                break;
                        }
                        TrackPoint newTrackPoint = new TrackPoint(newPointLongitude, newPointLatitude, newPointTimeStamp, GpsPointFormatImport.WGS84);
                        newFlight.Track.Add(newTrackPoint);
                    }
                }
            }
            return newFlight;
        }
        /// <summary>
        /// Saves the specified PdfDocument to a specified Location.
        /// </summary>
        /// <param name="doc">PfdDocument to save</param>
        /// <param name="filename">Filepath (e.g. C:\flight.pdf). String must contain file Ending</param>
        public static void savePdf(Competitor competitor, Flight flight, Race race, Parcours parcours, string filename)
        {
            createPdf(competitor, flight, race, parcours).Save(filename);
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
        /// <summary>
        /// Returns the Penalties for a flight on a Parcours (Forbidden Zones only)
        /// </summary>
        /// <param name="parcours"></param>
        /// <param name="flight"></param>
        /// <returns></returns>
        public static PenaltyCollection calculateForbiddenZonePenalties(Parcours parcours, Flight flight)
        {
            bool lastPointWasOffTrack = false;
            bool finishingGatePassed = false;
            List<GpsPoint> penaltyPoints = new List<GpsPoint>();

            List<List<GpsPoint>> penaltyPointsList = new List<List<GpsPoint>>();
 
            for (int i = 0; i< flight.Track.Count-1; i++)
            {
                if(!finishingGatePassed)
                {
                    TrackPoint trackpoint = flight.Track[i];
                    for(int j = 0; j<4;j++)
                    {
                        // ToDo: get gate
                        //if(Common.gatePassed(parcours.Gates[j,1] ,trackpoint, flight.Track[i+1]))
                        //{     
                        //    finishingGatePassed = true;
                        //    break;
                        //}
                        if (parcours.IsPointOffTrack(trackpoint))
                        {
                            lastPointWasOffTrack = true;
                            penaltyPoints.Add(trackpoint);
                        }
                        else
                        {
                            if (lastPointWasOffTrack)
                            {
                                penaltyPointsList.Add(penaltyPoints);
                                penaltyPoints = new List<GpsPoint>();
                            }
                            lastPointWasOffTrack = false;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            PenaltyCollection penalties = new PenaltyCollection();
            foreach (List<GpsPoint> penaltySequence in penaltyPointsList)
            {
                int durance = penaltySequence.Count;
                Rules.RestrictedAreaDuration restrictedAreaDuration;
                
                if(durance <= 2)
                    restrictedAreaDuration = Rules.RestrictedAreaDuration.ZeroToTwo;
                else if(durance >=3 && durance <= 4)
                    restrictedAreaDuration = Rules.RestrictedAreaDuration.ThreeToFour;
                else if(durance >=5 && durance <= 6)
                    restrictedAreaDuration = Rules.RestrictedAreaDuration.FiveToSix;
                else if(durance >=7 && durance <= 8)
                    restrictedAreaDuration = Rules.RestrictedAreaDuration.SevenToEight;
                else if(durance >=9 && durance <=10)
                    restrictedAreaDuration = Rules.RestrictedAreaDuration.NineToTen;
                else
                    restrictedAreaDuration = Rules.RestrictedAreaDuration.MoreOrEqEleven;

                Penalty newPenalty = new Penalty();
                // ToDo: assign penalty point, comment, etc.
                penalties.Add(newPenalty);
            }
            return penalties;
        }
        /// <summary>
        /// Returns true if the specified Gate was passed between the GPSPoints p1, p2
        /// </summary>
        /// <param name="gate"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool gatePassed(Gate gate, GpsPoint p1, GpsPoint p2)
        {
            double Ax = gate.LeftPoint.Longitude;
            double Ay = gate.LeftPoint.Latitude;
            double Bx = gate.RightPoint.Longitude;
            double By = gate.RightPoint.Latitude;
            double Cx = p1.Longitude;
            double Cy = p1.Latitude;
            double Dx = p2.Longitude;
            double Dy = p2.Latitude;
            //double* X, double* Y

            double distAB, theCos, theSin, newX, ABpos;

            //  Fail if either line segment is zero-length.
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy) return false;

            //  Fail if the segments share an end-point.
            if (Ax == Cx && Ay == Cy || Bx == Cx && By == Cy
                || Ax == Dx && Ay == Dy || Bx == Dx && By == Dy)
            {
                return false;
            }

            //  (1) Translate the system so that point A is on the origin.
            Bx -= Ax;
            By -= Ay;
            Cx -= Ax;
            Cy -= Ay;
            Dx -= Ax;
            Dy -= Ay;

            //  Discover the length of segment A-B.
            distAB = Math.Sqrt(Bx * Bx + By * By);

            //  (2) Rotate the system so that point B is on the positive X axis.
            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = Cx * theCos + Cy * theSin;
            Cy = Cy * theCos - Cx * theSin;
            Cx = newX;
            newX = Dx * theCos + Dy * theSin;
            Dy = Dy * theCos - Dx * theSin;
            Dx = newX;

            //  Fail if segment C-D doesn't cross line A-B.
            if (Cy < 0.0 && Dy < 0.0 || Cy >= 0.0 && Dy >= 0.0)
                return false;

            //  (3) Discover the position of the intersection point along line A-B.
            ABpos = Dx + (Cx - Dx) * Dy / (Dy - Cy);

            //  Fail if segment C-D crosses line A-B outside of segment A-B.
            if (ABpos < 0.0 || ABpos > distAB)
                return false;
            else
            {
                return true;
            }
        }
        /// <summary>
        /// returns the DateTime a Starting Gate was passed
        /// </summary>
        /// <param name="parcours"></param>
        /// <param name="flight"></param>
        /// <returns></returns>
        public static DateTime startingGatePassingTime(Parcours parcours, Flight flight)
        {
            for ( int i = 0; i< flight.Track.Count-2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(Common.gatePassed(parcours.Gates[j, 0], flight.Track[i], flight.Track[i+1]))
                    {
                        return flight.Track[i+1].TimeStamp;
                    }
                }
            }
            return new DateTime(0);
        }
        /// <summary>
        /// returns the DateTime when a finishing Gate was passed
        /// </summary>
        /// <param name="parcours"></param>
        /// <param name="flight"></param>
        /// <returns></returns>
        public static DateTime finishingGatePassingTime(Parcours parcours, Flight flight)
        {
            for (int i = 0; i < flight.Track.Count - 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Common.gatePassed(parcours.Gates[j, 1], flight.Track[i], flight.Track[i + 1]))
                    {
                        return flight.Track[i + 1].TimeStamp;
                    }
                }
            }
            return new DateTime(0);
        }
        /// <summary>
        /// returns the DateTime when a TakeOffGate was passed
        /// </summary>
        /// <param name="race"></param>
        /// <param name="flight"></param>
        /// <returns></returns>
        public static DateTime takeoffGatePassingTime(Race race, Flight flight)
        {
            for (int i = 0; i < flight.Track.Count - 2; i++)
            {
                if (Common.gatePassed(race.TakeOffGate, flight.Track[i], flight.Track[i + 1]))
                {
                    return flight.Track[i + 1].TimeStamp;
                }
            }
            return new DateTime(0);
        }
        /// <summary>
        /// returns a csv String of the CompetitorList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string createCsvCompetitorList(CompetitorCollection list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Competitor competitor in list)
            {
                sb.AppendLine(String.Format("{0};{1};{2};{3};{4};{5};{6};", 
                    competitor.CompetitionNumber, competitor.AcCallsign, competitor.PilotName, competitor.PilotFirstName,
                    competitor.NavigatorName, competitor.NavigatorFirstName, competitor.Country));
            }
            return sb.ToString();
        }
        /// <summary>
        /// Saves the Competitor List to the specified Location
        /// </summary>
        /// <param name="competitorList"></param>
        /// <param name="filename"></param>
        public static void saveCsvCompetitorList(CompetitorCollection competitorList, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.Write(createCsvCompetitorList(competitorList));
            sw.Close();
        }
        /// <summary>
        /// returns a SortedList of all Competitors and their average Penalties of a race
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public class TotalResult
        {
            Competitor competitor;
            double result;

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
        }           

        public static List<TotalResult> calculateRankingList(Race race)
        {
            List<TotalResult> rankingList = new List<TotalResult>();
            foreach (Competitor competitor in race.Competitors)
            {
                //int[] flightPenalties = new int[competitor.Flights.Count];
                List<int> flightPenalties = new List<int>();
                foreach (Flight flight in competitor.Flights.Values)
                {
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
                rankingList.Add(new TotalResult(competitor,average));
            }
            rankingList.Sort(delegate(TotalResult x, TotalResult y) { return x.Result.CompareTo(y.Result); });
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
            foreach (TotalResult res in rankList)
            {
                Competitor competitor = res.Competitor;
                sb.AppendLine(String.Format("{0};{1};{2};{3};{4};{5};{6};{7};",
                    res.Result, competitor.CompetitionNumber, competitor.AcCallsign, competitor.PilotFirstName, 
                    competitor.PilotName, competitor.NavigatorFirstName, competitor.NavigatorName, competitor.Country ));
            }
            StreamWriter sw = new StreamWriter(filename);
            sw.Write(sb.ToString());
            sw.Close();
        }
        /// <summary>
        /// Returns a Sorted List (by Penalties) of Competitors for the specified Group
        /// </summary>
        /// <param name="competitorGroup"></param>
        /// <returns></returns>
        public static SortedList<Competitor, int> calculateGroupRankingList(CompetitorGroup competitorGroup)
        {
            SortedList<Competitor, int> competitorsFlightPenalties = new SortedList<Competitor, int>();
            foreach (Competitor competitor in competitorGroup.Competitors)
            {
                int sumOfPenaltiesPerFlight = 0;
                // ToDo: get competitors flight and penalties
                //foreach (Penalty penalty in competitor.getFlight(competitorGroup).Penalties)
                //{
                //    sumOfPenaltiesPerFlight += penalty.PenaltyPoints;
                //}
                //competitorsFlightPenalties.Add(competitor, sumOfPenaltiesPerFlight);
            }
            return competitorsFlightPenalties;
        }
    }
}
