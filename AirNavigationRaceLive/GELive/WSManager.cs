using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GELive.ANRLDataService ;
using System.Timers;
using System.IO;

namespace GELive
{
    /// <summary>
    /// Webservice-Client Manager
    /// </summary>
    public class WSManager
    {
        List<t_Daten> DatenListe = new List<t_Daten>();
        Timer UpdateData = new Timer(5000);
        ANRLDataServiceClient Client;
        bool ListLocked = false;
        public DateTime delaytimestamp;
        public TimeSpan Delay;

        /// <summary>
        /// Creates a new Instance of the Webservice-Client Object
        /// Respondable for Updateing, getting the local Data-Cache and generating the KML-File with the lines
        /// </summary>
        public WSManager()
        {
            UpdateData.Elapsed += new ElapsedEventHandler(UpdateData_Elapsed);
            UpdateData.Start();
            Client = new ANRLDataServiceClient();
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
            //Debug
            if (Data.Count > 0)
            {
                Console.WriteLine("Got Data");
            }
            ListLocked = false;
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
            List<Points> test = new List<Points>();
            while (ListLocked)
            {
                System.Threading.Thread.Sleep(20);
            }
            ListLocked = true;
            foreach (t_Daten d in DatenListe)
            {
                Points pStart = new Points((decimal)d.XStart, (decimal)d.YStart, (decimal)d.ZStart);
                Points pEnd = new Points((decimal)d.XEnd, (decimal)d.YEnd, (decimal)d.ZEnd);
                test.Add(pStart);
                test.Add(pEnd);
            }
            ListLocked = false;

           // test.Add(new Points((decimal)(7 + (23.7066) / 60), (decimal)(46 + (56.2789) / 60), (decimal)(570.1)));
            //test.Add(new Points((decimal)(7 + (23.4459) / 60), (decimal)(46 + (56.1450) / 60), (decimal)(690.5)));   
            
            result += AddLine(test, Colors.Red);
            result += GetKMLTemplateContent("footer");

            return result;
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
    }
}
