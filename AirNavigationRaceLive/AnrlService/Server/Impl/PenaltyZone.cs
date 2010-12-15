using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class PenaltyZone:IDImpl,IPenaltyZone
    {
        private String _Name;
        private List<IPenaltyPolygon> _Polygons;

        internal PenaltyZone(t_PenaltyZone penaltyZone):base(penaltyZone.ID)
        {
            _Name = penaltyZone.Name;
            _Polygons = new List<IPenaltyPolygon>();
            foreach (t_PenaltyZonePolygon polygon in penaltyZone.t_PenaltyZonePolygons)
            {
                _Polygons.Add(new PenaltyPolygon(polygon));
            }
        }
        #region IPenaltyZone Members

        public string Name
        {
            get {return _Name; }
        }

        public List<IPenaltyPolygon> Polygons
        {
            get { return _Polygons; }
        }

        #endregion
    }
}
