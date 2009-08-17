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

namespace GELive
{
    /// <summary>
    /// Webservice-Client Manager
    /// </summary>
    public class WSManager
    {
        List<t_Daten> DatenListe = new List<t_Daten>();
        List<t_PolygonPoint> PolygonPoints;
        System.Timers.Timer UpdateData = new System.Timers.Timer(5000);
        ANRLDataServiceClient Client;
        anrl_gui gui;
        bool ListLocked = false;
        /// <summary>
        /// The Timestamp of the Selected Entrie used as reference for delaying
        /// </summary>
        public DateTime delaytimestamp;
        /// <summary>
        /// The Delay to be used when whowing Data
        /// </summary>
        public TimeSpan Delay;
        private GEWebBrowser gweb;
        private GEFeatureContainerCoClass Container;
        private IGEPlugin ge;

        /// <summary>
        /// Creates a new Instance of the Webservice-Client Object
        /// Respondable for Updateing, getting the local Data-Cache and generating the KML-File with the lines
        /// </summary>
        public WSManager(GEWebBrowser gweb,anrl_gui gui)
        {
            this.gweb = gweb;
            this.gui = gui;
            ge = gweb.GetPlugin();
            Container = ge.getFeatures();
            Container.appendChild(ge.parseKml(GetKml()));

            UpdateData.Elapsed += new ElapsedEventHandler(UpdateData_Elapsed);
            UpdateData.Start();

            Client = new ANRLDataServiceClient();
            SetClientCredentials.SetCredentials(Client);
            PolygonPoints = Client.GetPolygons();
            PolygonPoints.OrderBy(p => p.ID_Polygon);
            Container.appendChild(ge.parseKml(GetPolygonKml()));
        }

        /// <summary>
        /// Event-Handler for Updating the local Cache of Data to be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateData_Elapsed(object sender, ElapsedEventArgs e)
        {
            while (ListLocked)
            {
                System.Threading.Thread.Sleep(20); 
            }
            ListLocked = true;
            DateTime DisplayTime = DateTime.Now.AddMinutes(0); //Set to 1 for Delayed Display
            if (Delay != null)
            {
                DisplayTime = DisplayTime.Add(-Delay);
            }

            List<t_Daten> Data = Client.GetPathData(DisplayTime);
            DatenListe.AddRange(Data);
            ListLocked = false;
            UpdateGWebBrowser();
            if (gui.rankingForm != null && gui.rankingForm.Visible)
            {
                AddRankingData();
            }
        }

        private void AddRankingData()
        {
            if (gui.rankingForm != null && gui.rankingForm.Visible)
            {
                List<RankingEntry> RList = new List<RankingEntry>();

                gui.rankingForm.SetData(RList);
            }
        }

        private void UpdateGWebBrowser()
        {
            String kml = GetKml();
            Container.replaceChild(ge.parseKml(GetKml()), Container.getFirstChild());
            gweb.Invalidate();
            
            gweb.Invoke(new MethodInvoker(gweb.Update));
            //gweb.Update();
        }

        /// <summary>
        /// Generates a KML-File with alle needed Points and Lines to be displayed on the Gui
        /// </summary>
        /// <returns>KML as String</returns>
        public string GetKml()
        {
            //kml file loaded by resource file instead of webservice
            //change this when webservice is implemented
            //return GELive.Properties.Resources.track;
            string result = "";
            result += GetKMLTemplateContent("header");
            List<Tracker> TrackList = new List<Tracker>();

            while (ListLocked)
            {
                System.Threading.Thread.Sleep(20);
            }
            ListLocked = true;

            //Get all Trackers in the Datacache
            int Trackercount = 0;
            foreach (t_Daten d in DatenListe)
            {
                if (TrackList.Count(p => p.id == d.ID_Flugzeug) == 0)
                {
                    TrackList.Add(new Tracker(d.ID_Flugzeug));
                    Trackercount++;
                    if (Trackercount >= 4) break;
                }
            }

            foreach (t_Daten d in DatenListe)
            {
                Points pStart = new Points((decimal) d.XStart, (decimal)d.YStart, (decimal)d.ZStart);
                Points pEnd = new Points((decimal)d.XEnd, (decimal)d.YEnd, (decimal)d.ZEnd);
                Tracker t = TrackList.Find(p => p.id == d.ID_Flugzeug);
                t.Pointlist.Add(pStart);
                t.Pointlist.Add(pEnd);
            }
            ListLocked = false;

            int ColorId = 1;
            TrackList.OrderBy(p=>p.id);
            foreach (Tracker t in TrackList)
            {
                result += AddLine(t.Pointlist, (Colors)ColorId++);
            }

            result += GetKMLTemplateContent("footer");

            return result;
        }

        private string GetPolygonKml()
        {
            String result = "";
            result += GetKMLTemplateContent("headerPolygon");
            List<int> PolygonIdList = new List<int>();
            foreach (t_PolygonPoint poly in PolygonPoints)
            {
                if (!PolygonIdList.Contains(poly.ID_Polygon))
                {
                    PolygonIdList.Add(poly.ID_Polygon);
                }
            }
            foreach (int i in PolygonIdList)
            {
                result += @"<Placemark><name>Polygon" + i + @"</name><styleUrl>#sn_ylw-pushpin</styleUrl><Polygon><extrude>1</extrude><altitudeMode>relativeToGround</altitudeMode><outerBoundaryIs><LinearRing><coordinates>";
                foreach (t_PolygonPoint tp in PolygonPoints.Where(p => p.ID_Polygon == i))
                {
                    result += tp.longitude+","+tp.latitude+","+/*tp.altitude+"*/ "300 " ;
                }
                result += @"</coordinates></LinearRing></outerBoundaryIs></Polygon></Placemark>";
            }

            result += GetKMLTemplateContent("footerPolygon");
            return result;
        }

        /// <summary>
        /// Returns the KML of an Airplane
        /// </summary>
        /// <param name="index">Index needed for color</param>
        /// <returns>KML-String</returns>
        public string getAriplane(int index)
        {
            return GetKMLTemplateContent("blue");
        }
        /// <summary>
        /// Reads the filecontent of a template for generating the KML-File
        /// </summary>
        /// <param name="Filename">Name of the Template in the Folder Resources\KMLTemplates</param>
        /// <returns></returns>
        internal string GetKMLTemplateContent(string Filename)
        {
            FileStream file = new FileStream("Resources\\KMLTemplates\\"+Filename+".kml",FileMode.Open, FileAccess.Read);
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
        private string AddLine(List<Points> Points, Colors Color)
        {
            string result = "<Placemark>";
            switch (Color)
            {
                case Colors.Red:
                    result += "<styleUrl>#msn_red</styleUrl>";
                    break;
                case Colors.Blue:
                    result += "<styleUrl>#msn_blue</styleUrl>";
                    break;
                case Colors.Green:
                    result += "<styleUrl>#msn_green</styleUrl>";
                    break;
                case Colors.Yellow:
                    result += "<styleUrl>#msn_yellow</styleUrl>";
                    break;

            }
            result += "<LineString><extrude>1</extrude><tessellate>0</tessellate>";
            result += "<altitudeMode>absolute</altitudeMode>";
            result += "<coordinates>";
            foreach (Points p in Points)
            {
                result += p.Y + "," + p.X + "," + p.Z + " ";
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
            public Points(decimal X, decimal Y, decimal Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
            public decimal X;
            public decimal Y;
            public decimal Z;
        }
        /// <summary>
        /// Enum of Colors which are supported by AddLine-Function
        /// </summary>
        enum Colors:int
        {
            Red = 1,
            Blue = 2,
            Green = 3,
            Yellow = 4
        }
        /// <summary>
        /// Tracker vor displaying
        /// </summary>
        class Tracker
        {
            public List<Points> Pointlist = new List<Points>();
            public int id;
            public Tracker(int id)
            {
                this.id = id;
            }
        }
    }
}
