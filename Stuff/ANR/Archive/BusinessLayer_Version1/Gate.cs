///////////////////////////////////////////////////////////
//  Gate.cs
//  Implementation of the Class Gate
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////




using System;
namespace PFA.ANR.BusinessLayer
{
    [Serializable]
	public class Gate
    {
        private Guid gateId;
        public Guid GateId
        {
            get { return gateId; }
            set { gateId = value; }
        }

		private GpsPoint leftPoint;
		private GpsPoint rightPoint;

		public Gate()
            : base()
        {
		}

        public Gate(GpsPoint leftPoint, GpsPoint rightPoint)
        {
            this.LeftPoint = leftPoint;
            this.RightPoint = rightPoint;
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
	}//end Gate

}//end namespace PFA.ANR.BusinessLayer