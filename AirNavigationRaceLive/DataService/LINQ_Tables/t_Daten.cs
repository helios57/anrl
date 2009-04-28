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
using System.Data.Linq.Mapping;

namespace DataService.LINQ_Tables
{
    [Table(Name = "t_Daten")]
    public class t_Daten
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public int ID_Flugzeug;
        [Column]
        public DateTime Timestamp;
        [Column]
        public String XStart;
        [Column]
        public String XEnd;
        [Column]
        public String YStart;
        [Column]
        public String YEnd;
        [Column]
        public String ZStart;
        [Column]
        public String ZEnd;
        [Column]
        public DateTime TStart;
        [Column]
        public DateTime TEnd;
        [Column]
        public int Speed;
        [Column]
        public int Penalty;
        [Column]
        public int ID_Polygon;

    }
}
