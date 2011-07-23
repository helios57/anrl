///////////////////////////////////////////////////////////
//  Flight.cs
//  Implementation of the Class Flight
//  Created on:      15-Apr-2008 21:38:39
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class Flight : AnrObject
    {
        #region Private Members
        private Guid flightId;
        private Guid competitorGroupId;
        private Guid competitorId;
        private DateTime takeOffTime;
        private DateTime finishTime;
        private DateTime startTime;
        private PenaltyCollection penalties;
        private TrackPointCollection track;
        #endregion Private Members

        #region Constructors
        public Flight()
            : base()
        {
            track = new TrackPointCollection();
            penalties = new PenaltyCollection();
        }
        #endregion Constructors

        #region Public Properties
        public Guid FlightId
        {
            get
            {
                return flightId;
            }
            set
            {
                flightId = value;
            }
        }

        public Guid CompetitorGroupId
        {
            get
            {
                return competitorGroupId;
            }
            set
            {
                competitorGroupId = value; 
            }
        }

        public Guid CompetitorId
        {
            get
            {
                return competitorId;
            }
            set
            {
                competitorId = value;
            }
        }

        public DateTime FinishTime
        {
            get
            {
                return finishTime;
            }
            set
            {
                finishTime = value;
            }
        }

        public PenaltyCollection Penalties
        {
            get
            {
                return penalties;
            }
        }

        public DateTime TakeOffTime
        {
            get
            {
                return takeOffTime;
            }
            set
            {
                takeOffTime = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }

        public TrackPointCollection Track
        {
            get
            {
                return track;
            }
        }
        #endregion Public Properties
    }
}