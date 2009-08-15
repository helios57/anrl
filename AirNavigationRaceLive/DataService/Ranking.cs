using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace DataService
{
    public class Ranking
    {
        string DB_PATH;
        List<RankingEntry> Result = new List<RankingEntry>();
        public Ranking(String DB_PATH)
        {
            this.DB_PATH = DB_PATH;
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            //initialize ranking
            foreach (t_Flugzeug flug in dataContext.t_Flugzeugs)
            {
                RankingEntry rank = new RankingEntry();
                rank.Flugzeug = flug.Flugzeug;
                rank.Pilot = flug.Pilot;
                rank.Punkte = 0;
                Result.Add(rank);
            }
        }
        public List<RankingEntry> getRanking()
        {
            List<Polygon> Penaltyzones = new List<Polygon>();
            List<PolygonPoint> points = new List<PolygonPoint>();
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);

            //Get Penalty Zones
            foreach (t_Polygon pPolygon in dataContext.t_Polygons)
            {
                foreach (t_PolygonPoint ppPolygon in dataContext.t_PolygonPoints.Where(p => p.ID_Polygon== pPolygon.ID))
                {
                    points.Add(new PolygonPoint(Convert.ToDouble(ppPolygon.latitude), Convert.ToDouble(ppPolygon.longitude)));
                }
                Penaltyzones.Add(new Polygon(points.ToArray()));
                points.Clear();
                
            }

            //Check wether a polygon contains any of the planes and adds 6 penalty points (for 6 seconds in penalty zone approximately)
            foreach(t_Daten tData in dataContext.t_Datens.Where(p => p.Penalty == null))
            {
                foreach (Polygon poly in Penaltyzones)
                {
                    if (poly.contains(Convert.ToDouble(tData.XEnd), Convert.ToDouble(tData.YEnd)))
                    {
                        t_Flugzeug flugi = (t_Flugzeug)dataContext.t_Flugzeugs.Where(p => p.ID == tData.ID_Flugzeug);
                        foreach (RankingEntry ran in Result)
                        {
                            if (ran.Pilot == flugi.Pilot)
                            {
                                ran.Punkte += 6;
                            }
                        }

                    }
                }
                
            }
            //dataContext.t_Polygons Polygons mit id's
            //dataContext.t_PolygonPoints alle punkte kannst du nach polygon-id aufteilen
            //dataContext.t_Trackers tracker-id's
            //dataContext.t_Flugzeugs flugzeuge mit tracker-id
            //dataContext.t_Datens alle geloggten daten mit flugzeug-id

            //@todo berechungen ;-)
            return Result;
        }

    public class RankingEntry
    {
        public String Flugzeug;
        public String Pilot;
        public int Punkte;
    }
    public class PolygonPoint
    {
        public double laltitude;
        public double longitude;

        public PolygonPoint(double laltitude, double longitude)
        {
            this.laltitude = laltitude;
            this.longitude = longitude;
        }

    }

    public class Polygon
    {
        public PolygonPoint[] polygonpoints;

        public Polygon(PolygonPoint[] polygonpoints)
        {
            this.polygonpoints = polygonpoints;
        }

        public bool contains(double x, double y)
        {
            bool inside = false;

            //int x1 = xpoints[npoints - 1];
            double x1 = polygonpoints[polygonpoints.Length - 1].longitude;
            //int y1 = ypoints[npoints - 1];
            double y1 = polygonpoints[polygonpoints.Length - 1].laltitude;
            //int x2 = xpoints[0];
            double x2 = polygonpoints[0].longitude;
            //int y2 = ypoints[0];
            double y2 = polygonpoints[0].laltitude;

            bool startUeber = y1 >= y ? true : false;
            for (int i = 1; i < polygonpoints.Length; i++)
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
                x2 = polygonpoints[i].longitude;
                //y2 = ypoints[i];
                y2 = polygonpoints[i].laltitude;
            }
            return inside;
        }

    }
    }

}
