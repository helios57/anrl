using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using AnrlDB;

namespace AnrlService.Server.Impl
{
    class PenaltyPoint:GPSPoint,IPenaltyPoint
    {
        internal PenaltyPoint(t_PenaltyZonePoint penaltyPoint)
            : base(penaltyPoint.ID, penaltyPoint.longitude, penaltyPoint.latitude, penaltyPoint.altitude)
        {
        }
    }
}
