using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class PenaltyPolygon:IDImpl, IPenaltyPolygon
    {
        List<IPenaltyPoint> _Points;
        internal PenaltyPolygon(t_PenaltyZonePolygon penaltyPolygon)
            : base(penaltyPolygon.ID)
        {
            _Points = new List<IPenaltyPoint>();
            foreach (t_PenaltyZonePoint point in penaltyPolygon.t_PenaltyZonePoints)
            {
                _Points.Add(new PenaltyPoint(point));
            }
        }
        #region IPenaltyPolygon Members

        public List<IPenaltyPoint> Points
        {
            get { return _Points; }
        }

        #endregion
    }
}
