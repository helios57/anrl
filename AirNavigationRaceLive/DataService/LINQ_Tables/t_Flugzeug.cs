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
    [Table(Name = "t_Flugzeug")]
    public class t_Flugzeug
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Flugzeug;
        [Column]
        public string Pilot;
        [Column]
        public int ID_GPS_Tracker;
    }
}
