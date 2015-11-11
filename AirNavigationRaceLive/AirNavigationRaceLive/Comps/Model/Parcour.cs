using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using AirNavigationRaceLive.Comps.Helper;

namespace AirNavigationRaceLive.Comps.Model
{
    public class Parcour : t_Parcour
    {
        public Parcour()
        {
        }
        public Parcour(t_Parcour p)
        {
            this.ID = p.ID;
            this.ID_Map = p.ID_Map;
            foreach (t_Line l in p.t_Line)
            {
                this.t_Line.Add(Factory.t_Line(l));
            }
            this.Name = p.Name;
        }
        public volatile bool finished;
        public double best;
        private readonly List<t_Line> Modified = new List<t_Line>();
        public void addModifiedLine(t_Line l)
        {
            if (!Modified.Contains(l))
            {
                Modified.Add(l);
            }
        }
        public List<t_Line> getModifiedLines()
        {
            return Modified.ToList();
        }
    }
}
