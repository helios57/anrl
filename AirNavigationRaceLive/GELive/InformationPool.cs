﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEPlugin;
using System.IO;
using System.Threading;
using ANRL.ANRLDataService;
using System.Globalization;

namespace ANRLClient
{
    static class InformationPool
    {
        static public String RemoteAddress = "http://127.0.0.1:5555/";
        static public String ConnectionConfig = "WSHttpBinding_IANRLDataService";
        static public String Username;
        static public String Password;

        static public ANRLDataServiceClient Client = null;

        static public event EventHandler GuiLoaded;

        static public anrl_gui gui = null;
        static public WSManager manager = null;

        static public GEWebBrowser gweb = null;
        static public GEFeatureContainerCoClass Container = null;
        static public IGEPlugin ge = null;

        static public TimeSpan Delay = new TimeSpan();
        static public List<t_Daten> DatenListe = new List<t_Daten>();
        static public PolygonGroup PolygonGroupToDraw = new PolygonGroup();
        static public List<PilotEntry> PilotsToBeDrawn = new List<PilotEntry>();
        static public List<t_Pilot> PilotList = new List<t_Pilot>();

        static public DateTime Oldest = DateTime.Now.ToUniversalTime();
        static public DateTime Newest = DateTime.Now.ToUniversalTime();
        static public DateTime Next = DateTime.Now.ToUniversalTime();
        static public DateTime CurrentStart = DateTime.Now.ToUniversalTime();
        static public DateTime CurrentEnd = DateTime.Now.ToUniversalTime();
        static public RankForm rankform;

        static public List<t_Picture> Flags = new List<t_Picture>();


        static public int PlaySpeed = 1;
        static public int LineWidth = 1;
        static public int HeightPenalty = 300;
        static public int HeightTracker = 0;


        static public List<t_Daten> GetCurrentData()
        {
            return DatenListe.Where(p => p.Timestamp >= CurrentStart && p.Timestamp <= CurrentEnd).ToList();
        }
        static public List<t_Daten> GetCurrentDataOnly()
        {
            return DatenListe.Where(p => p.Timestamp >= Newest && p.Timestamp <= Next).ToList();
        }

        static public bool Connect()
        {
            Client = new ANRL.ANRLDataService.ANRLDataServiceClient(ConnectionConfig, RemoteAddress);
            if (!RemoteAddress.Contains("127.0.0.1"))
            {
                Client.ClientCredentials.UserName.UserName = Username;
                Client.ClientCredentials.UserName.Password = Password;
                Client.ClientCredentials.Windows.ClientCredential.UserName = Username;
                Client.ClientCredentials.Windows.ClientCredential.Password = Password;
            }
            return Client.State == System.ServiceModel.CommunicationState.Created;
        }

        static public void StartVisualisation()
        {
            gui = new anrl_gui();
            gui.PluginReady += new EventHandler(gui_PluginReady);
            gui.Show();
            gui.FormClosing += new System.Windows.Forms.FormClosingEventHandler(gui_FormClosing);
        }
        static void gui_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            manager.close();
        }
        static void gui_PluginReady(object sender, EventArgs e)
        {
            manager = new WSManager();
            GuiLoaded.Invoke(null, null);
        }

        public static void showRanking(List<RaceEntry> Races)
        {
            if ((rankform == null || !rankform.Visible) && Races.First()!=null)
            {
                rankform = new RankForm(Races.First());
                rankform.Show();
            }
            else
            {
                try
                {
                    rankform.Hide();
                    rankform.Dispose();
                    rankform = null;
                }
                catch { }
            }
        }
       

        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        static public PolygonGroup importFromDxf(string filepath)
        {
            PolygonGroup g=new PolygonGroup();

            StreamReader sr = new StreamReader(filepath);
            List<string> lineList = new List<string>();
            while (!sr.EndOfStream){lineList.Add(sr.ReadLine());}
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
                            Polygon p = new Polygon();
                            p.ID = g.PolygonIdGen++;
                            p.Type = PolygonType.PenaltyZone;

                            for (int j = 0; j < numberOfVertexes; j++)
                            {
                                PolygonPoint point = new PolygonPoint();
                                point.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + (j * 4) + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + (j * 4) + 18], NumberFormatInfo.InvariantInfo) * 1000);
                                point.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + (j * 4) + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + (j * 4) + 18], NumberFormatInfo.InvariantInfo) * 1000);
                                point.ID = p.ID;
                                p.Points.Add(point);
                            }
                            g.Polygons.Add(p);
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        Polygon p = new Polygon();
                        p.ID = g.PolygonIdGen++;
                        p.Type = PolygonType.GateStartA;

                        PolygonPoint point = new PolygonPoint();
                        PolygonPoint point2 = new PolygonPoint();

                        point.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18], NumberFormatInfo.InvariantInfo) * 1000);
                        point.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18], NumberFormatInfo.InvariantInfo) * 1000);
                        point.ID = p.ID;
                        p.Points.Add(point);

                        point2.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + 20], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22], NumberFormatInfo.InvariantInfo) * 1000);
                        point2.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + 20], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22], NumberFormatInfo.InvariantInfo) * 1000);
                        point2.ID = p.ID;
                        p.Points.Add(point2);

                        string gatename = lines[i + 6].Substring(11, 1);
                        g.Polygons.Add(p);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        Polygon p = new Polygon();
                        p.ID = g.PolygonIdGen++;
                        p.Type = PolygonType.GateEndA;

                        PolygonPoint point = new PolygonPoint();
                        PolygonPoint point2 = new PolygonPoint();

                        point.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18], NumberFormatInfo.InvariantInfo) * 1000);
                        point.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18], NumberFormatInfo.InvariantInfo) * 1000);
                        point.ID = p.ID;
                        p.Points.Add(point);

                        point2.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + 20], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22], NumberFormatInfo.InvariantInfo) * 1000);
                        point2.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + 20], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22], NumberFormatInfo.InvariantInfo) * 1000);
                        point2.ID = p.ID;
                        p.Points.Add(point2);

                        string gatename = lines[i + 6].Substring(9, 1);
                        g.Polygons.Add(p);
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if (lines[i + 9] == " 90" && double.Parse(lines[10], NumberFormatInfo.InvariantInfo) == 2)
                        {
                            Polygon p = new Polygon();
                            p.ID = g.PolygonIdGen++;
                            p.Type = PolygonType.EndLine;

                            PolygonPoint point = new PolygonPoint();
                            PolygonPoint point2 = new PolygonPoint();

                            point.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18], NumberFormatInfo.InvariantInfo) * 1000);
                            point.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + 16], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 18], NumberFormatInfo.InvariantInfo) * 1000);
                            point.ID = p.ID;
                            p.Points.Add(point);

                            point2.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + 20], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22], NumberFormatInfo.InvariantInfo) * 1000);
                            point2.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + 20], NumberFormatInfo.InvariantInfo) * 1000, double.Parse(lines[i + 22], NumberFormatInfo.InvariantInfo) * 1000);
                            point2.ID = p.ID;
                            p.Points.Add(point2);

                            g.Polygons.Add(p);
                        }
                    }
                }
            }
            PolygonGroupToDraw = g;
            return g;
        }
        // Convert CH y/x to WGS lat
        private static double CHtoWGSlat(double y, double x)
        {
            // Converts militar to civil and  to unit = 1000km
            // Axiliary values (% Bern)
            double y_aux = (y - 600000) / 1000000;
            double x_aux = (x - 200000) / 1000000;

            // Process lat
            double lat = 16.9023892
                + 3.238272 * x_aux
                - 0.270978 * Math.Pow(y_aux, 2)
                - 0.002528 * Math.Pow(x_aux, 2)
                - 0.0447 * Math.Pow(y_aux, 2) * x_aux
                - 0.0140 * Math.Pow(x_aux, 3);

            // Unit 10000" to 1 " and converts seconds to degrees (dec)
            lat = lat * 100 / 36;

            return lat;
        }

        // Convert CH y/x to WGS long
        private static double CHtoWGSlng(double y, double x)
        {
            // Converts militar to civil and  to unit = 1000km
            // Axiliary values (% Bern)
            double y_aux = (y - 600000) / 1000000;
            double x_aux = (x - 200000) / 1000000;

            // Process long
            double lng = 2.6779094
                + 4.728982 * y_aux
                + 0.791484 * y_aux * x_aux
                + 0.1306 * y_aux * Math.Pow(x_aux, 2)
                - 0.0436 * Math.Pow(y_aux, 3);

            // Unit 10000" to 1 " and converts seconds to degrees (dec)
            lng = lng * 100 / 36;

            return lng;
        }
    }

    public class PilotEntry
    {
        public PilotEntry() { }
        public PilotEntry(t_Pilot Pilot)
        {
            this.ID = Pilot.ID.ToString();
            this.LastName = Pilot.LastName;
            this.SureName = Pilot.SureName;
            this.PilotColor = Pilot.Color.ToString();
            this.Picture =Pilot.Picture;
            this.Flag = null;
            this.FlagId = (int)Pilot.ID_Flag;
        }
        public String ID;
        public int ID_Tracker;
        public String LastName;
        public String SureName;
        public String PilotColor;
        public Binary Picture;
        public Binary Flag;
        public int FlagId;

        public override string ToString()
        {
            return ID + " " + LastName + " " + SureName + " " + PilotColor;
        }
    }
    public class PolygonGroup
    {
        public PolygonGroup() { }
        public PolygonGroup(t_PolygonGroup pg)
        {
            this.ID = pg.ID;
            this.Name = pg.Name;
        }
        public int ID;
        public String Name;
        public List<Polygon> Polygons = new List<Polygon>();
        public int PolygonIdGen=1;
        public override string ToString()
        {
            return ID.ToString() + " " + Name + " " + Polygons.Count;
        }
    }
    public class Polygon
    {
        public int ID;
        public List<PolygonPoint> Points = new List<PolygonPoint>();
        public PolygonType Type;
        public bool contains2(decimal x, decimal y)
        {
            bool isOffTrack = false;

                int polySides = Points.Count - 1;
                decimal[] polyY = new decimal[Points.Count];
                decimal[] polyX = new decimal[Points.Count];

                int k = 0;
                foreach (PolygonPoint gpsPoint in Points)
                {
                    polyY[k] = gpsPoint.Latitude;
                    polyX[k] = gpsPoint.Longitude;
                    k++;
                }

                int i, j = polySides - 1;
                bool oddNodes = false;

                for (i = 0; i < polySides; i++)
                {
                    if (polyY[i] < y && polyY[j] >= y || polyY[j] < y && polyY[i] >= y)
                    {
                        if (polyX[i] + (y - polyY[i]) / (polyY[j] - polyY[i]) * (polyX[j] - polyX[i]) < x)
                        {
                            oddNodes = !oddNodes;
                        }
                    }
                    j = i;
                }
                isOffTrack = oddNodes;
                if (isOffTrack)
                {
                    return isOffTrack;
                }         
            return isOffTrack;
        }
        public bool contains(decimal x, decimal y)
        {
            bool inside = false;

            //int x1 = xpoints[npoints - 1];
            decimal x1 = Points[Points.Count - 1].Longitude;
            //int y1 = ypoints[npoints - 1];
            decimal y1 = Points[Points.Count - 1].Latitude;
            //int x2 = xpoints[0];
            decimal x2 = Points[0].Longitude;
            //int y2 = ypoints[0];
            decimal y2 = Points[0].Latitude;



            //Der Algorithmus ist mir zu kompliziert, den müsstest du mir mal erklären ^^
            bool startUeber = y1 >= y ? true : false;
            for (int i = 1; i < Points.Count; i++)
            {
                bool endUeber = y2 >= y ? true : false;
                if (startUeber != endUeber)
                {
                    if ((y2 - y) * (x2 - x1) <= (y2 - y1) * (x2 - x))
                    {
                        if (endUeber)
                        {
                            inside = !inside;
                        }
                    }
                    else
                    {
                        if (!endUeber)
                        {
                            inside = !inside;
                        }
                    }
                }

                startUeber = endUeber;
                y1 = y2;
                x1 = x2;
                //x2 = xpoints[i];
                x2 = Points[i].Longitude;
                //y2 = ypoints[i];
                y2 = Points[i].Latitude;
            }
            return inside;
        }

    }
    public class PolygonPoint
    {
        public int ID;
        public decimal Longitude;
        public decimal Latitude;
        public decimal Altitude;
    }
    public class RaceEntry
    {
        public int ID;
        public String Name;
        public PolygonGroup Polygons;
        public DateTime StartTime;
        public decimal Duration = 12;
        public int PilotA;
        public int PilotB;
        public int PilotC;
        public int PilotD;

        public RaceEntry()
        {
            StartTime = DateTime.Now;
            Polygons = new PolygonGroup();
        }
        public RaceEntry(String[] Values)
        {
            this.ID = int.Parse(Values[0]);
            this.Name = Values[1];
            this.PilotA = int.Parse(Values[2]);
            this.PilotB = int.Parse(Values[3]);
            this.PilotC = int.Parse(Values[4]);
            this.PilotD = int.Parse(Values[5]);
            this.Polygons = new PolygonGroup();
            Polygons.Polygons.Add(new Polygon());
            Polygons.Polygons.First().ID = int.Parse(Values[6]);
            this.StartTime = DateTime.Parse(Values[8]);
            DateTime EndTime = DateTime.Parse(Values[7]);
            this.Duration = (decimal)(EndTime - StartTime).TotalMilliseconds;
        }
        public RaceEntry(t_Race Race)
        {
            
            InformationPool.PilotList.Clear();
            foreach (t_Pilot p in InformationPool.Client.GetPilots())
            {
                InformationPool.PilotList.Add(p);
            }
            this.ID = Race.ID;
            this.Name = Race.Name;
            if (Race.ID_Pilot_0 > 0) this.PilotA = (int)Race.ID_Pilot_0;
            if (Race.ID_Pilot_1 > 0) this.PilotB = (int)Race.ID_Pilot_1;
            if (Race.ID_Pilot_2 > 0) this.PilotC = (int)Race.ID_Pilot_2;
            if (Race.ID_Pilot_3 > 0) this.PilotD = (int)Race.ID_Pilot_3;

            this.Polygons = new PolygonGroup();
            Polygons.ID = (int)Race.ID_PolygonGroup;
            Polygons.Name = Race.ID_PolygonGroup.ToString();
            this.StartTime = (DateTime)Race.TimeStart;
            DateTime EndTime = (DateTime)Race.TimeEnd;
            this.Duration = (decimal)(EndTime - StartTime).TotalMinutes;
        }
    }
    public enum PolygonType : int
    {
        PenaltyZone = 0,
        GateStartA = 1,
        GateStartB = 2,
        GateStartC = 3,
        GateStartD = 4,
        GateEndA = 5,
        GateEndB = 6,
        GateEndC = 7,
        GateEndD = 8,
        EndLine = 9
    }
    public class RankingEntry
    {
        public String LastName;
        public String SureName;
        public int Punkte;
        public int TrackerID;
        public int Color;
        public bool passedstartinggate = false;
        public bool passedfinishgate = false;
        public decimal lastlongitude = -1;
        public decimal lastlatitude = -1;
    }
    public class PilotLst :t_Pilot
    {
        public t_Pilot p;
        public PilotLst(t_Pilot p)
        {
            this.p = p;
        }
        public override string ToString()
        {
            return p.ID + " " + p.LastName + " " + p.SureName;
        }
    }
    public class RaceLst : t_Race
    {
        public t_Race r;
        public RaceEntry re;
        public RaceLst(t_Race r)
        {
            this.r = r;
        }
        public override string ToString()
        {
            return r.ID + " " + r.Name + " " + r.TimeStart.ToString();
        }
    }

}
