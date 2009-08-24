using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEPlugin;
using GELive.ANRLDataService;
using System.IO;

namespace GELive
{
    static class InformationPool
    {
        static public String RemoteAddress = "http://127.0.0.1:5555/";
        static public String ConnectionConfig = "WSHttpBinding_IANRLDataService";
        static public String Username;
        static public String Password;

        static public ANRLDataServiceClient Client = null;

        static public anrl_gui gui = null;
        static public WSManager manager = null;

        static public GEWebBrowser gweb = null;
        static public GEFeatureContainerCoClass Container = null;
        static public IGEPlugin ge = null;

        static public TimeSpan Delay = new TimeSpan();
        static public int PlaySpeed=1;

        static public bool Connect()
        {
            Client = new GELive.ANRLDataService.ANRLDataServiceClient(ConnectionConfig, RemoteAddress);
            Client.ClientCredentials.UserName.UserName = Username;
            Client.ClientCredentials.UserName.Password = Password;
            Client.ClientCredentials.Windows.ClientCredential.UserName = Username;
            Client.ClientCredentials.Windows.ClientCredential.Password = Password;
            return Client.State == System.ServiceModel.CommunicationState.Created;
        }

        static public void StartVisualisation()
        {
            gui = new anrl_gui();
        }

        static public void ShowDelay()
        {

        }
        static public void ShowRanking(RaceEntry Race)
        {

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

                            for (int j = 0; j < numberOfVertexes; j++)
                            {
                                PolygonPoint point = new PolygonPoint();
                                point.Longitude = (decimal)CHtoWGSlng(double.Parse(lines[i + (j * 4) + 18]) * 1000, double.Parse(lines[i + (j * 4) + 16]) * 1000);
                                point.Latitude = (decimal)CHtoWGSlat(double.Parse(lines[i + (j * 4) + 18]) * 1000, double.Parse(lines[i + (j * 4) + 16]) * 1000);
                                point.ID = p.ID;
                                p.Points.Add(point);
                            }
                            g.Polygons.Add(p);
                        }
                    }
                }
            }
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
        }
        public String ID;
        public String LastName;
        public String SureName;
        public String PilotColor;

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
        public RaceEntry()
        {
            StartTime = DateTime.Now;
            Polygons = new PolygonGroup();
        }
        public RaceEntry(String[] Values)
        {
            this.ID = int.Parse(Values[0]);
            this.Name = Values[1];
            this.PilotA = new PilotEntry();
            this.PilotA.ID = Values[2];
            this.PilotB = new PilotEntry();
            this.PilotB.ID = Values[3];
            this.PilotC = new PilotEntry();
            this.PilotC.ID = Values[4];
            this.PilotD = new PilotEntry();
            this.PilotD.ID = Values[5];
            this.Polygons = new PolygonGroup();
            Polygons.Polygons.Add(new Polygon());
            Polygons.Polygons.First().ID = int.Parse(Values[6]);
            this.StartTime = DateTime.Parse(Values[8]);
            DateTime EndTime = DateTime.Parse(Values[7]);
            this.Duration = (decimal)(EndTime - StartTime).TotalMilliseconds;
        }
        public RaceEntry(t_Race Race)
        {
            List<t_Pilot> pilots = InformationPool.Client.GetPilots();
            this.ID = Race.ID;
            this.Name = Race.Name;
            if (Race.ID_Pilot_0 > 0) this.PilotA = new PilotEntry(pilots.Single(p => p.ID == Race.ID_Pilot_0));
            if (Race.ID_Pilot_1 > 0) this.PilotB = new PilotEntry(pilots.Single(p => p.ID == Race.ID_Pilot_1));
            if (Race.ID_Pilot_2 > 0) this.PilotC = new PilotEntry(pilots.Single(p => p.ID == Race.ID_Pilot_2));
            if (Race.ID_Pilot_3 > 0) this.PilotD = new PilotEntry(pilots.Single(p => p.ID == Race.ID_Pilot_3));

            this.Polygons = new PolygonGroup();
            Polygons.ID = (int)Race.ID_PolygonGroup;
            Polygons.Name = Race.ID_PolygonGroup.ToString();
            this.StartTime = (DateTime)Race.TimeStart;
            DateTime EndTime = (DateTime)Race.TimeEnd;
            this.Duration = (decimal)(EndTime - StartTime).TotalMinutes;
        }
        public int ID;
        public String Name;
        public PolygonGroup Polygons;
        public DateTime StartTime;
        public decimal Duration;
        public PilotEntry PilotA;
        public PilotEntry PilotB;
        public PilotEntry PilotC;
        public PilotEntry PilotD;
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
    }

}
