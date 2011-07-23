///////////////////////////////////////////////////////////
//  TrackPoint.cs
//  Implementation of the Class trackPoint
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System;
namespace ANR.Core
{
    [Serializable]
    public class TrackPoint : GpsPoint
    {
        #region Private Members
        private DateTime timeStamp;
        #endregion Private Members

        #region Constructors
        public TrackPoint(double latitude, double longitude, DateTime timeStamp, GpsPointFormatImport format)
            : base(latitude, longitude, format)
        {
           this.TimeStamp = timeStamp;
        }
        #endregion Constructors

        #region Public Methods
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
        #endregion Public Methods
    }
}