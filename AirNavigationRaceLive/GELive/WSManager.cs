using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GELive.anrlWebService;
using System.Timers;
using System.IO;

namespace GELive
{
    public class WSManager
    {
        List<t_Daten> DatenListe = new List<t_Daten>();
        Timer UpdateData = new Timer(5000);
        anrlWebService.ANRLDataServiceClient Client;

        public WSManager()
        {
            UpdateData.Elapsed += new ElapsedEventHandler(UpdateData_Elapsed);
            UpdateData.Start();
            Client = new ANRLDataServiceClient();
        }

        void UpdateData_Elapsed(object sender, ElapsedEventArgs e)
        {
            t_Daten[] Data = Client.GetPathData(DateTime.Now.AddMinutes(-1));
            DatenListe.AddRange(Data);
        }

        public string GetKml()
        {
            //kml file loaded by resource file instead of webservice
            //change this when webservice is implemented
            //return GELive.Properties.Resources.track;
            string result = "";
            result += GetKMLTemplateContent("header");
            List<Points> test = new List<Points>();
            test.Add(new Points((decimal)(7 + (23.7066) / 60), (decimal)(46 + (56.2789) / 60), (decimal)(570.1)));
            test.Add(new Points((decimal)(7 + (23.4459) / 60), (decimal)(46 + (56.1450) / 60), (decimal)(690.5)));   
            result += AddLine(test, Colors.Blue);
            result += GetKMLTemplateContent("footer");




            return result;//GELive.Properties.Resources.track;
        }

        internal string GetKMLTemplateContent(string Filename)
        {
            FileStream file = new FileStream("Resources\\KMLTemplates\\"+Filename+".kml",FileMode.Open, FileAccess.Read);
            StreamReader SR = new StreamReader(file);
            string result = SR.ReadToEnd();
            SR.Close();
            file.Close();
            return result;
        }
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
                result += p.X + "," + p.Y + "," + p.Z + " ";
            }
            result += "</coordinates>";
            result += "</LineString></Placemark>";
            return result;
        }

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
        enum Colors:int
        {
            Red = 1,
            Blue = 2,
            Green = 3,
            Yellow = 4
        }
    }
}
