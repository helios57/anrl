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
    /// <summary>
    /// Ranking Class
    /// </summary>
    public class Ranking
    {
        string DB_PATH;
        List<RankingEntry> Result = new List<RankingEntry>();
        List<Polygon> Penaltyzones = new List<Polygon>();
        List<PolygonPoint> points = new List<PolygonPoint>();

        /// <summary>
        /// Constructor for ranking
        /// </summary>
        /// <param name="DB_PATH"></param>
        public Ranking(String DB_PATH)
        {
            this.DB_PATH = DB_PATH;

            LogManager.AddLog(DB_PATH, 4, "Ranking.cs:Ranking", DB_PATH);

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

            //Get Penalty Zones
            foreach (t_Polygon pPolygon in dataContext.t_Polygons)
            {
                foreach (t_PolygonPoint ppPolygon in dataContext.t_PolygonPoints.Where(p => p.ID_Polygon == pPolygon.ID))
                {
                    points.Add(new PolygonPoint(Convert.ToDouble(ppPolygon.latitude), Convert.ToDouble(ppPolygon.longitude)));
                }
                Penaltyzones.Add(new Polygon(points.ToArray()));
                //points.Clear();// Funktioniert nicht, weil die Liste dann bei allen Penalty-zones diesebe ist und leer !
                points = new List<PolygonPoint>();
            }

            LogManager.AddLog(DB_PATH, 4, "Ranking.cs:Ranking", 
                "PolygonCount="+Penaltyzones.Count + 
                " FlugzeugCount="+Result.Count);
        }
        /// <summary>
        /// Returns the current Ranking
        /// </summary>
        /// <returns>Result</returns>
        public List<RankingEntry> getRanking()
        {

            LogManager.AddLog(DB_PATH, 4, "Ranking.cs:getRanking", "Started");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);

            //Check wether a polygon contains any of the planes and adds 6 penalty points (for 6 seconds in penalty zone approximately)
            foreach(t_Daten tData in dataContext.t_Datens.Where(p => p.Penalty == -1))//überprüft immer alle datenpunkte die nicht in einer Penalty-Zone sind ?? performance ?
            {
                foreach (Polygon poly in Penaltyzones)
                {
                    if (poly.contains(Convert.ToDouble(tData.LongitudeEnd), Convert.ToDouble(tData.LatitudeEnd)))
                    {
                        tData.Penalty = 1;
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
                if (tData.Penalty == -1)
                {
                    tData.Penalty = 0;
                }
                
            }
            //dataContext.t_Polygons Polygons mit id's
            //dataContext.t_PolygonPoints alle punkte kannst du nach polygon-id aufteilen
            //dataContext.t_Trackers tracker-id's
            //dataContext.t_Flugzeugs flugzeuge mit tracker-id
            //dataContext.t_Datens alle geloggten daten mit flugzeug-id

            //@todo berechungen ;-)

            LogManager.AddLog(DB_PATH, 4, "Ranking.cs:getRanking", "Ended");
            return Result;
        }

        /// <summary>
        /// Ranking Entry class
        /// </summary>
    public class RankingEntry
    {
        /// <summary>
        /// Resembles a plane
        /// </summary>
        public String Flugzeug;
        /// <summary>
        /// The Pilot flying the plane
        /// </summary>
        public String Pilot;
        /// <summary>
        /// The count of points
        /// </summary>
        public int Punkte;
    }

        /// <summary>
        /// A single Point of a Polygon
        /// </summary>
    public class PolygonPoint
    {
        /// <summary>
        /// the latitude
        /// </summary>
        public double laltitude;
        /// <summary>
        /// the longitude
        /// </summary>
        public double longitude;

        /// <summary>
        /// Constructor for PolygonPoint
        /// </summary>
        /// <param name="laltitude"></param>
        /// <param name="longitude"></param>
        public PolygonPoint(double laltitude, double longitude)
        {
            this.laltitude = laltitude;
            this.longitude = longitude;
        }

    }

        /// <summary>
        /// Resembles a Polygon containing an array of polygonpoints
        /// </summary>
    public class Polygon
    {
        /// <summary>
        /// Polygonpoints array
        /// </summary>
        public PolygonPoint[] polygonpoints;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="polygonpoints"></param>
        public Polygon(PolygonPoint[] polygonpoints)
        {
            this.polygonpoints = polygonpoints;
        }

        /// <summary>
        /// Checks wether polygon contains the given params
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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



            //Der Algorithmus ist mir zu kompliziert, den müsstest du mir mal erklären ^^
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
