//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirNavigationRaceLive
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_GPS_IN
    {
        public int ID { get; set; }
        public string IMEI { get; set; }
        public int Status { get; set; }
        public int GPS_fix { get; set; }
        public System.DateTime TimestampTracker { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string altitude { get; set; }
        public string speed { get; set; }
        public string heading { get; set; }
        public int nr_used_sat { get; set; }
        public string HDOP { get; set; }
        public System.DateTime Timestamp { get; set; }
        public bool Processed { get; set; }
    }
}
