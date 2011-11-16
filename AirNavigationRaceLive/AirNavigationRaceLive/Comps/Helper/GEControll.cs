using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEPlugin;
using System.Drawing;
using System.IO;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps.Helper
{
    class GEControll
    {
        private IGEPlugin plugin = null;
        private GEFeatureContainerCoClass Container = null;
        private int TrackerHeightAdjustment = 0;
        private int HeightPenalty = 300;
        private int LineWidth = 2;

        private static double averageLongitude(List<NetworkObjects.Line> lines)
        {
            if (lines.Count == 0)
            {
                return 0;
            }
            double sum = 0;
            int counter = 0;
            foreach (Line l in lines)
            {
                sum += l.A.longitude;
                counter++;
            }

            return sum / counter;
        }
        private static double averageLatitude(List<NetworkObjects.Line> lines)
        {
            if (lines.Count == 0)
            {
                return 0;
            }
            double sum = 0;
            int counter = 0;
            foreach (Line l in lines)
            {
                sum += l.A.latitude;
                counter++;
            }

            return sum / counter;
        }

        public void SetParcour(NetworkObjects.Parcour parcour)
        {
            try
            {
                if (Container != null)
                {
                    Container.replaceChild(plugin.parseKml(GetPolygonKml(parcour)), Container.getLastChild());
                    KmlLookAtCoClass lookAt = plugin.createLookAt("");
                    lookAt.set(averageLatitude(parcour.LineList), averageLongitude(parcour.LineList), 15000, plugin.ALTITUDE_RELATIVE_TO_GROUND, 0, 0, 10000);
                    plugin.getView().setAbstractView(lookAt);
                }
            }
            catch { }
        }

        public void SetDaten(List<NetworkObjects.GPSData> gpsDatenListe, List<NetworkObjects.Team> teams,List<NetworkObjects.CompetitionTeam> CompetitionTeams)
        {
            try
            {
                if (Container != null)
                {
                    Container.replaceChild(plugin.parseKml(GetKml(gpsDatenListe, teams, CompetitionTeams)), Container.getFirstChild());

                }
            }
            catch { }
        }

        public void SetPlugin(IGEPlugin plugin)
        {
            this.plugin = plugin;
            Container = plugin.getFeatures();
            Container.appendChild(plugin.parseKml(GetKml(new List<GPSData>(), new List<NetworkObjects.Team>(), new List<NetworkObjects.CompetitionTeam>())));
            Container.appendChild(plugin.parseKml(GetPolygonKml(new NetworkObjects.Parcour())));
        }

        public void SetTrackerHeightAdjustment(int i)
        {
            TrackerHeightAdjustment = i;
        }

        public void SetHeightPenalty(int i)
        {
            HeightPenalty = i;
        }

        public void SetLineWidth(int i)
        {
            LineWidth = i;
        }
        /// <summary>
        /// Generates a KML-File with alle needed Points and Lines to be displayed on the Gui
        /// </summary>
        /// <returns>KML as String</returns>
        private string GetKml(List<GPSData> gpsList, List<NetworkObjects.Team> teams,List<NetworkObjects.CompetitionTeam> competitionTeams)
        {
            string result = "";
            List<Tracker> TrackList = new List<Tracker>();

            foreach (NetworkObjects.CompetitionTeam Team in competitionTeams)
            {
                Tracker t = new Tracker(Team.ID);
                t.Color = Color.FromName(teams.First(p=>p.ID == Team.ID_Team).Color);
                foreach (GPSData data in gpsList.Where(p => Team.ID_TrackerList.Contains(p.trackerID)))
                {
                    t.Pointlist.Add(new Points((decimal)data.longitude, (decimal)data.latitude, (decimal)data.altitude));
                }
                TrackList.Add(t);
            }
            result += GenerateKMLHeader(TrackList);

            foreach (Tracker t in TrackList)
            {
                result += AddLine(t);
            }

            result += GetKMLTemplateContent("footer");

            return result;
        }

        private string GenerateKMLHeader(List<Tracker> TrackList)
        {
            string result = @"<?xml version=""1.0"" encoding=""UTF-8""?><kml xmlns=""http://www.opengis.net/kml/2.2""><Document><name>ANRL KML Generated</name><Folder>";
            int i = 0;
            foreach (Tracker t in TrackList)
            {
                t.ColorTag_1 = "sh_" + i;
                t.ColorTag_2 = "sn_" + i;
                t.ColorTag_3 = "msn_" + i;
                result += "<Style id=\"" + t.ColorTag_1 + "\"><IconStyle><scale>1.2</scale></IconStyle><LineStyle>";
                result += @"<color>cc" + t.Color.B.ToString("X2") + t.Color.G.ToString("X2") + t.Color.R.ToString("X2") + @"</color><width>" + LineWidth + "</width></LineStyle><PolyStyle>";
                result += @"<color>7f" + t.Color.B.ToString("X2") + t.Color.G.ToString("X2") + t.Color.R.ToString("X2") + @"</color></PolyStyle></Style>";
                result += "<Style id=\"" + t.ColorTag_2 + "\"><LineStyle>";
                result += @"<color>cc" + t.Color.B.ToString("X2") + t.Color.G.ToString("X2") + t.Color.R.ToString("X2") + @"</color><width>" + LineWidth + "</width></LineStyle><PolyStyle>";
                result += @"<color>7f" + t.Color.B.ToString("X2") + t.Color.G.ToString("X2") + t.Color.R.ToString("X2") + @"</color></PolyStyle></Style>";
                result += "<StyleMap id=\"" + t.ColorTag_3 + "\"><Pair><key>normal</key>";
                result += @"<styleUrl>#" + t.ColorTag_2 + @"</styleUrl></Pair><Pair><key>highlight</key>";
                result += @"<styleUrl>#" + t.ColorTag_1 + @"</styleUrl></Pair></StyleMap>";
                i++;
            }
            return result;
        }

        private string GetPolygonKml(NetworkObjects.Parcour parcour)
        {
            String result = "";
            result += GetKMLTemplateContent("headerPolygon");
            int i = 0;
            foreach (Line n in parcour.LineList.Where(p => p.Type == (int)LineType.PENALTYZONE))
            {
                result += @"<Placemark><name>Polygon" + i++ + @"</name><styleUrl>#sn_ylw-pushpin</styleUrl><Polygon><extrude>1</extrude><altitudeMode>relativeToGround</altitudeMode><outerBoundaryIs><LinearRing><coordinates>";
                result += n.A.longitude + "," + n.A.latitude + "," + HeightPenalty + " ";
                result += n.O.longitude + "," + n.O.latitude + "," + HeightPenalty + " ";
                result += n.B.longitude + "," + n.B.latitude + "," + HeightPenalty + " ";
                result += n.A.longitude + "," + n.A.latitude + "," + HeightPenalty + " ";
                result += @"</coordinates></LinearRing></outerBoundaryIs></Polygon></Placemark>";
            }
            foreach (Line n in parcour.LineList.Where(p => p.Type >= 3 && p.Type <= 10))
            {
                result += @"<Placemark><name>Polygon" + i++ + @"</name><styleUrl>#sn_ylw-pushpin</styleUrl><Polygon><extrude>1</extrude><altitudeMode>relativeToGround</altitudeMode><outerBoundaryIs><LinearRing><coordinates>";
                result += n.B.longitude + "," + n.B.latitude + "," + HeightPenalty + " ";
                result += n.A.longitude + "," + n.A.latitude + "," + HeightPenalty + " ";
                result += n.B.longitude + "," + n.B.latitude + "," + HeightPenalty + " ";
                result += @"</coordinates></LinearRing></outerBoundaryIs></Polygon></Placemark>";
            }
            result += GetKMLTemplateContent("footerPolygon");
            return result;
        }

        /// <summary>
        /// Reads the filecontent of a template for generating the KML-File
        /// </summary>
        /// <param name="Filename">Name of the Template in the Folder Resources\KMLTemplates</param>
        /// <returns></returns>
        internal string GetKMLTemplateContent(string Filename)
        {
            return File.ReadAllText(@"Resources\KMLTemplates\" + Filename + ".kml");
        }
        /// <summary>
        /// Add a line with the given Points to the KML-File
        /// </summary>
        /// <param name="Points">List of Points</param>
        /// <param name="Color">Color</param>
        /// <returns></returns>
        private string AddLine(Tracker t)
        {
            string result = "<Placemark>";
            result += "<styleUrl>#" + t.ColorTag_3 + "</styleUrl>";
            result += "<LineString><extrude>1</extrude><tessellate>0</tessellate>";
            result += "<altitudeMode>absolute</altitudeMode>";
            result += "<coordinates>";
            foreach (Points p in t.Pointlist)
            {
                result += p.longitude + "," + p.latitude + "," + (p.altitude + TrackerHeightAdjustment) + " ";
            }
            result += "</coordinates>";
            result += "</LineString></Placemark>";
            return result;
        }
    }
    /// <summary>
    /// Class for Points in decimal, to be used for AddLine 
    /// </summary>
    class Points
    {
        public Points(decimal longitude, decimal latitude, decimal altitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.altitude = altitude;
        }
        public decimal longitude;
        public decimal latitude;
        public decimal altitude;
    }
    /// <summary>
    /// Tracker vor displaying
    /// </summary>
    class Tracker
    {
        public List<Points> Pointlist = new List<Points>();
        public int id;
        public Color Color;
        public String ColorTag_1;
        public String ColorTag_2;
        public String ColorTag_3;
        public Tracker(int id)
        {
            this.id = id;
        }
    }
}
