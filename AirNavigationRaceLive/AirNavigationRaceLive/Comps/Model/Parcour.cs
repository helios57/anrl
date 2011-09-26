using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Comps.Model
{
    public class Parcour : NetworkObjects.Parcour
    {
        public Parcour()
        {
        }
        public Parcour(NetworkObjects.Parcour p)
        {
            this.ID = p.ID;
            this.ID_Map = p.ID_Map;
            this.LineList.AddRange(p.LineList);
            this.Name = p.Name;
        }
        public volatile bool finished;
        public double best;
        private readonly List<NetworkObjects.Line> Modified = new List<NetworkObjects.Line>();
        public void addModifiedLine(NetworkObjects.Line l)
        {
            if (!Modified.Contains(l))
            {
                Modified.Add(l);
            }
        }
        public List<NetworkObjects.Line> getModifiedLines()
        {
            return Modified.ToList();
        }
    }
}
