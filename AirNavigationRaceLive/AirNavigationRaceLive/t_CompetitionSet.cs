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
    
    public partial class t_CompetitionSet
    {
        public t_CompetitionSet()
        {
            this.t_Competition = new HashSet<t_Competition>();
            this.t_Map = new HashSet<t_Map>();
            this.t_Parcour = new HashSet<t_Parcour>();
            this.t_Penalty = new HashSet<t_Penalty>();
            this.t_Pilot = new HashSet<t_Pilot>();
            this.t_Team = new HashSet<t_Team>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<t_Competition> t_Competition { get; set; }
        public virtual ICollection<t_Map> t_Map { get; set; }
        public virtual ICollection<t_Parcour> t_Parcour { get; set; }
        public virtual ICollection<t_Penalty> t_Penalty { get; set; }
        public virtual ICollection<t_Pilot> t_Pilot { get; set; }
        public virtual ICollection<t_Team> t_Team { get; set; }
    }
}
