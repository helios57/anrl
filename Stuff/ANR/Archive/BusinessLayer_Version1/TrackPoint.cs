///////////////////////////////////////////////////////////
//  TrackPoint.cs
//  Implementation of the Class trackPoint
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////




using System;
namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class TrackPoint : GpsPoint
    {

		private DateTime timeStamp;

        public TrackPoint(double latitude, double longitude, DateTime timeStamp, GpsPointFormatImport format)
            : base(latitude, longitude, format)
        {
           this.TimeStamp = timeStamp;
        }

        public DateTime TimeStamp
        {
			get
            {
				return timeStamp;
			}
			set
            {
				timeStamp = value;
			}
		}

	}//end TrackPoint

}//end namespace PFA.ANR.BusinessLayer