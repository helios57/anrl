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
    [Table(Name="t_GPS_IN")]
    public class t_GPS_IN
    {
        [Column(IsPrimaryKey = true)]
        public int ID;
        [Column]
        public string IMEI;
        [Column]
        public int Status;
        [Column]
        public int GPS_fix;
        [Column]
        public DateTime TimestampTracker;
        [Column]
        public string longitude;
        [Column]
        public string latitude;
        [Column]
        public string altitude;
        [Column]
        public string speed;
        [Column]
        public string heading;
        [Column]
        public int nr_used_sat;
        [Column]
        public string HDOP;
        [Column]
        public DateTime Timestamp;
    }
}
