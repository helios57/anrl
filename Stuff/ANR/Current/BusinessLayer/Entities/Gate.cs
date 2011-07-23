///////////////////////////////////////////////////////////
//  Gate.cs
//  Implementation of the Class Gate
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////




using System;
namespace ANR.Core
{
    [Serializable]
	public class Gate : AnrObject
    {
        #region Private Members
        private Guid gateId;
		private GpsPoint leftPoint;
		private GpsPoint rightPoint;
        #endregion Private Members

        #region Constructors
        public Gate()
            : base()
        {
		}

        public Gate(GpsPoint leftPoint, GpsPoint rightPoint)
            : base()
        {
            this.LeftPoint = leftPoint;
            this.RightPoint = rightPoint;
        }
        #endregion Constructors

        #region Public Properties
        public Guid GateId
        {
            get
            {
                return gateId;
            }
            set
            {
                gateId = value;
            }
        }

		public GpsPoint LeftPoint
        {
			get
            {
				return leftPoint;
			}
			set
            {
				leftPoint = value;
			}
		}

        public GpsPoint RightPoint
        {
			get
            {
				return rightPoint;
            }
            set
            {
                rightPoint = value;
            }
        }
        #endregion Public Properties

        #region Public Methods
        public bool MissedGate( GpsPoint p1, GpsPoint p2)
        {
            Gate extendedGate = new Gate();
            double m = (p1.Latitude - p2.Latitude) / (p1.Longitude - p2.Longitude);
            extendedGate.LeftPoint.Longitude += 10000;
            extendedGate.LeftPoint.Latitude += 10000* m;

            extendedGate.RightPoint.Longitude += 10000;
            extendedGate.rightPoint.Latitude += 10000 * m;

            return gatePassed(p1, p2);
        }


        /// <summary>
        /// Returns true if the specified Gate was passed between the GPSPoints p1, p2
        /// </summary>
        /// <param name="gate"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public bool gatePassed(GpsPoint p1, GpsPoint p2)
        {
            double Ax = this.LeftPoint.Longitude;
            double Ay = this.LeftPoint.Latitude;
            double Bx = this.RightPoint.Longitude;
            double By = this.RightPoint.Latitude;
            double Cx = p1.Longitude;
            double Cy = p1.Latitude;
            double Dx = p2.Longitude;
            double Dy = p2.Latitude;
            //double* X, double* Y

            double distAB, theCos, theSin, newX, ABpos;

            //  Fail if either line segment is zero-length.
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy) return false;

            //  Fail if the segments share an end-point.
            if (Ax == Cx && Ay == Cy || Bx == Cx && By == Cy
                || Ax == Dx && Ay == Dy || Bx == Dx && By == Dy)
            {
                return false;
            }

            //  (1) Translate the system so that point A is on the origin.
            Bx -= Ax;
            By -= Ay;
            Cx -= Ax;
            Cy -= Ay;
            Dx -= Ax;
            Dy -= Ay;

            //  Discover the length of segment A-B.
            distAB = Math.Sqrt(Bx * Bx + By * By);

            //  (2) Rotate the system so that point B is on the positive X axis.
            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = Cx * theCos + Cy * theSin;
            Cy = Cy * theCos - Cx * theSin;
            Cx = newX;
            newX = Dx * theCos + Dy * theSin;
            Dy = Dy * theCos - Dx * theSin;
            Dx = newX;

            //  Fail if segment C-D doesn't cross line A-B.
            if (Cy < 0.0 && Dy < 0.0 || Cy >= 0.0 && Dy >= 0.0)
                return false;

            //  (3) Discover the position of the intersection point along line A-B.
            ABpos = Dx + (Cx - Dx) * Dy / (Dy - Cy);

            //  Fail if segment C-D crosses line A-B outside of segment A-B.
            if (ABpos < 0.0 || ABpos > distAB)
                return false;
            else
            {
                return true;
            }
        }
        #endregion Public Methods
    }
}