using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GELive.ANRLDataService;
using System.Timers;
using System.IO;
using GEPlugin;
using System.Windows.Forms;
using System.Drawing;

namespace GELive
{
    /// <summary>
    /// Webservice-Client Manager
    /// </summary>
    public class WSManager
    {
        System.Timers.Timer UpdateData = new System.Timers.Timer(1000);   
        private GEFeatureContainerCoClass Container;
        public event EventHandler DataUpdated;

        /// <summary>
        /// Creates a new Instance of the Webservice-Client Object
        /// Respondable for Updateing, getting the local Data-Cache and generating the KML-File with the lines
        /// </summary>
        public WSManager()
        {
            Container = InformationPool.ge.getFeatures();
            String KML = GetKml();
            Container.appendChild(InformationPool.ge.parseKml(GetKml()));
            Container.appendChild(InformationPool.ge.parseKml(GetPolygonKml()));
            UpdateData.Elapsed += new ElapsedEventHandler(UpdateData_Elapsed);
            UpdateData.Start();
        }

        /// <summary>
        /// Event-Handler for Updating the local Cache of Data to be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateData_Elapsed(object sender, ElapsedEventArgs e)
        {
            InformationPool.Newest = InformationPool.Next; 
            InformationPool.Next = InformationPool.Next.AddSeconds((UpdateData.Interval / 1000) * InformationPool.PlaySpeed);

            List<t_Daten> tempList = InformationPool.Client.GetPathData(
                    InformationPool.Newest, 
                    InformationPool.Next);

            InformationPool.DatenListe.AddRange(tempList);

            UpdateGWebBrowser();
            if (DataUpdated != null) DataUpdated.Invoke(sender, e);
        }

        private void UpdateGWebBrowser()
        {
            String kml = GetKml();
            String PolyKML = GetPolygonKml();
            try
            {
                Container.replaceChild(InformationPool.ge.parseKml(kml), Container.getFirstChild());
                InformationPool.gweb.Invalidate();
                InformationPool.gweb.Invoke(new MethodInvoker(InformationPool.gweb.Update));

                Container.replaceChild(InformationPool.ge.parseKml(PolyKML), Container.getLastChild());
                InformationPool.gweb.Invalidate();
                InformationPool.gweb.Invoke(new MethodInvoker(InformationPool.gweb.Update));
            }
            catch
            {

            }
        }

        /// <summary>
        /// Generates a KML-File with alle needed Points and Lines to be displayed on the Gui
        /// </summary>
        /// <returns>KML as String</returns>
        private string GetKml()
        {
            string result = "";
            List<Tracker> TrackList = new List<Tracker>();

            foreach (PilotEntry Pilot in InformationPool.PilotsToBeDrawn.Where(p=>p.ID_Tracker > 0))
            {
                Tracker t = new Tracker(Pilot.ID_Tracker);
                t.Color = Color.FromArgb(int.Parse(Pilot.PilotColor));
                TrackList.Add(t);
            }
            result += GenerateKMLHeader(TrackList);
            List<t_Daten> DataToDraw = InformationPool.GetCurrentData();
            DataToDraw.Sort(new CompareData());
            List<t_Daten> DataNewToDraw = InformationPool.GetCurrentDataOnly();
            foreach (Tracker t in TrackList)
            {
                foreach (t_Daten d in DataToDraw.Where(p => p.ID_Tracker == t.id))
                {
                    t.Pointlist.Add(new Points((decimal)d.Longitude, (decimal)d.Latitude, (decimal)d.Altitude));
                    

                }
                foreach (t_Daten d in DataNewToDraw.Where(p => p.ID_Tracker == t.id))
                {
                    if (InformationPool.rankform != null)
                    {
                        InformationPool.rankform.doranking(d.Longitude, d.Latitude, d.ID_Tracker);
                    }
                }
            }

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
                t.ColorTag_1 = "sh_" + i ;
                t.ColorTag_2 = "sn_" + i;
                t.ColorTag_3 = "msn_" + i;
                result += "<Style id=\"" + t.ColorTag_1+ "\"><IconStyle><scale>1.2</scale></IconStyle><LineStyle>";
                result += @"<color>cc" + t.Color.B.ToString("X2")+ t.Color.G.ToString("X2")+ t.Color.R.ToString("X2")+ @"</color><width>"+InformationPool.LineWidth+"</width></LineStyle><PolyStyle>";
                result += @"<color>7f"+ t.Color.B.ToString("X2")+ t.Color.G.ToString("X2")+ t.Color.R.ToString("X2")+ @"</color></PolyStyle></Style>";
                result += "<Style id=\"" + t.ColorTag_2 + "\"><LineStyle>";
                result += @"<color>cc" + t.Color.B.ToString("X2") + t.Color.G.ToString("X2") + t.Color.R.ToString("X2") + @"</color><width>" + InformationPool.LineWidth + "</width></LineStyle><PolyStyle>";
                result += @"<color>7f" + t.Color.B.ToString("X2")+ t.Color.G.ToString("X2")+ t.Color.R.ToString("X2")+ @"</color></PolyStyle></Style>";
                result += "<StyleMap id=\"" + t.ColorTag_3 + "\"><Pair><key>normal</key>";
                result += @"<styleUrl>#"+ t.ColorTag_2 +@"</styleUrl></Pair><Pair><key>highlight</key>";
                result += @"<styleUrl>#" + t.ColorTag_1 + @"</styleUrl></Pair></StyleMap>";
                i++;
            }
            return result;
        }
        
        private string GetPolygonKml()
        {
            String result = "";
            result += GetKMLTemplateContent("headerPolygon");
            int i = 0;
            foreach (Polygon p in InformationPool.PolygonGroupToDraw.Polygons)
            {
                result += @"<Placemark><name>Polygon" + i++ + @"</name><styleUrl>#sn_ylw-pushpin</styleUrl><Polygon><extrude>1</extrude><altitudeMode>relativeToGround</altitudeMode><outerBoundaryIs><LinearRing><coordinates>";

                foreach (PolygonPoint tp in p.Points)
                {
                    result += tp.Longitude + "," + tp.Latitude + "," + InformationPool.HeightPenalty + " ";
                }
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
            FileStream file = new FileStream("Resources\\KMLTemplates\\" + Filename + ".kml", FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(file);
            string result = SR.ReadToEnd();
            SR.Close();
            file.Close();
            return result;
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
            result += "<styleUrl>#"+t.ColorTag_3+"</styleUrl>";
            result += "<LineString><extrude>1</extrude><tessellate>0</tessellate>";
            result += "<altitudeMode>absolute</altitudeMode>";
            result += "<coordinates>";
            foreach (Points p in t.Pointlist)
            {
                result += p.longitude + "," + p.latitude + "," + (p.altitude + InformationPool.HeightTracker) + " ";
            }
            result += "</coordinates>";
            result += "</LineString></Placemark>";
            return result;
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

        internal void close()
        {
            UpdateData.Stop();
        }
    }
    public class CompareData : IComparer<t_Daten>
    {
        #region IComparer<t_Daten> Members

        public int Compare(t_Daten x, t_Daten y)
        {
            if (x.Timestamp > y.Timestamp) return 1;
            if (x.Timestamp < y.Timestamp) return -1;
            else return 0;
        }

        #endregion
    }
}
