using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANR.Core
{
    [Serializable]
    public class CompetitorRouteAssignment
    {
        Competitor competitor;
        Route route;

        public Competitor Competitor
        {
            get 
            { 
                return competitor; 
            }
            set 
            { 
                competitor = value; 
            }
        }

        public Route Route
        {
            get 
            { 
                return route; 
            }
            set 
            { 
                route = value; 
            }
        }

        private DateTime takeoffTime;

        public DateTime TakeoffTime
        {
            get { return takeoffTime; }
            set { takeoffTime = value; }
        }

        public CompetitorRouteAssignment(Competitor competitor, Route route, DateTime takeOffTime)
        {
            this.competitor = competitor;
            this.route = route;
        }
    }
}
