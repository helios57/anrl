using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Comps.Model
{
    public class Parcour : NetworkObjects.Parcour
    {
        public volatile bool finished;
        public double best;
    }
}
