///////////////////////////////////////////////////////////
//  Competitor.cs
//  Implementation of the Class Competitor
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Collections.Generic;

namespace ANR.Core
{
    [Serializable]
	public class Competitor : AnrObject
    {
        #region Private Members
        private Guid id;
        private string acCallsign;
        private int competitionNumber;
        private string country;
        private SortedList<CompetitorGroup, Flight> flights; // ToDo: does not matter what, but do something!
        private string navigatorFirstName;
        private string navigatorName;
        private string pilotFirstName;
        private string pilotName;
        #endregion Private Members

        #region Constructors
        public Competitor()
            : base()
        {
            this.id = new Guid();
            this.flights = new SortedList<CompetitorGroup, Flight>();
        }
        #endregion Constructors

        #region Public Properties
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string AcCallsign
        {
            get
            {
                return acCallsign;
            }
            set
            {
                acCallsign = value;
            }
        }

        public int CompetitionNumber
        {
            get
            {
                return competitionNumber;
            }
            set
            {
                competitionNumber = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public SortedList<CompetitorGroup, Flight> Flights
        {
            get
            {
                return flights;
            }
            set
            {
                flights = value;
            }
        }

        public string NavigatorFirstName
        {
            get
            {
                return navigatorFirstName;
            }
            set
            {
                navigatorFirstName = value;
            }
        }

        public string NavigatorName
        {
            get
            {
                return navigatorName;
            }
            set
            {
                navigatorName = value;
            }
        }

        public string PilotFirstName
        {
            get
            {
                return pilotFirstName;
            }
            set
            {
                pilotFirstName = value;
            }
        }

        public string PilotName
        {
            get
            {
                return pilotName;
            }
            set
            {
                pilotName = value;
            }
        }
        #endregion Public Properties
    }
}