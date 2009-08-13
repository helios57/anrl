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
        public Ranking(String DB_PATH)
        {
            this.DB_PATH = DB_PATH;
        }
        public List<RankingEntry> getRanking()
        {
            List<RankingEntry> Result = new List<RankingEntry>();

            List<PolygonPoint> points = new List<PolygonPoint>();
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_PATH);
            foreach (t_Polygon pPolygon in dataContext.t_Polygons)
            {
                foreach (t_PolygonPoint ppPolygon in dataContext.t_PolygonPoints.Where(p => p.ID_Polygon== pPolygon.ID))
                {
                    points.Add(new PolygonPoint(ppPolygon.latitude, ppPolygon.longitude));
                }
                //@todo implement check for penalty zones here
            }
            //dataContext.t_Polygons Polygons mit id's
            //dataContext.t_PolygonPoints alle punkte kannst du nach polygon-id aufteilen
            //dataContext.t_Trackers tracker-id's
            //dataContext.t_Flugzeugs flugzeuge mit tracker-id
            //dataContext.t_Datens alle geloggten daten mit flugzeug-id

            //@todo berechungen ;-)
            return Result;
        }
    }
    public class RankingEntry
    {
        public String Flugzeug;
        public String Pilot;
        public int Punkte;
    }
    public class PolygonPoint
    {
        public int laltitude;
        public int longitude;

        public PolygonPoint(int laltitude, int longitude)
        {
            this.laltitude = laltitude;
            this.longitude = longitude;
        }

    }
}
