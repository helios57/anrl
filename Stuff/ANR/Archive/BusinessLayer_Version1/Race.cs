///////////////////////////////////////////////////////////
//  Race.cs
//  Implementation of the Class Race
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System;
using System.IO;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
	public class Race
    {
        #region Private Members
        private CompetitorCollection competitors;
        private CompetitorGroupCollection competitorGroups;
        private FlightCollection flights;
		private DateTime date;
        private Map map;
        private Gate takeOffGate;
        private bool defaultRunway;
        private string defaultParcoursFilePath;
		private string location;
		private string name;
        private TimeSpan defaultTargetFlightDuration;
        private TimeSpan timeToStartGateDefault;
        private TimeSpan timeToStartGateAlternative; // ToDo: Naming?! ;)
        #endregion Private Members

        #region Constructors
        public Race()
            : base()
        {
            competitors = new CompetitorCollection();
            competitorGroups = new CompetitorGroupCollection();
            flights = new FlightCollection();
            date = new DateTime();
            map = new Map();
            takeOffGate = new Gate();
            defaultRunway = true;
            defaultTargetFlightDuration = new TimeSpan(0);
            timeToStartGateDefault = new TimeSpan(0);
            timeToStartGateAlternative = new TimeSpan(0);
        }
        #endregion Constructors

        #region Public Properties
        public CompetitorCollection Competitors
        {
            get
            {
                return competitors;
            }
            set
            {
                competitors = value;
            }
        }

        public CompetitorGroupCollection CompetitorGroups
        {
            get
            {
                return competitorGroups;
            }
            set
            {
                competitorGroups = value;
            }
        }

        public FlightCollection Flights
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

        public DateTime Date
        {
			get
            {
				return date;
			}
			set
            {
				date = value;
			}
        }

        public Map Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

		public Gate TakeOffGate
        {
			get
            {
				return takeOffGate;
			}
			set
            {
				takeOffGate = value;
			}
        }

        public bool DefaultRunway
        {
            get
            {
                return defaultRunway;
            }
            set
            {
                defaultRunway = value;
            }
        }

        public string DefaultParcoursFilePath
        {
            get
            {
                return defaultParcoursFilePath;
            }
            set
            {
                defaultParcoursFilePath = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

		public string Name
        {
			get
            {
				return name;
			}
			set
            {
				name = value;
			}
        }

        public TimeSpan TargetFlightDuration
        {
            get
            {
                return defaultTargetFlightDuration;
            }
            set
            {
                defaultTargetFlightDuration = value;
            }
        }

        public TimeSpan TimeToStartGateDefault
        {
            get
            {
                return timeToStartGateDefault;
            }
            set
            {
                timeToStartGateDefault = value;
            }
        }

        public TimeSpan TimeToStartGateAlternative
        {
            get
            {
                return timeToStartGateAlternative;
            }
            set
            {
                timeToStartGateAlternative = value;
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void ImportFlight(CompetitorGroup competitorGroup, Competitor competitor, string filename)
        {
            Flight newFlight = Common.importFromGAC(filename); // ToDo: move code here
            newFlight.Penalties.AddRange(Common.calculateForbiddenZonePenalties(competitorGroup.Parcours, newFlight));
            newFlight.CompetitorId = competitor.Id;
            newFlight.CompetitorGroupId = competitorGroup.Id;
            flights.Add(newFlight);
        }

        public void SetMap(string path)
        {
            Bitmap image = new Bitmap(path);
            GpsPoint topLeftPoint;
            GpsPoint bottomRightPoint;
            double topLeftLatitude;
            double topLeftLongitude;
            double bottomRightLatitude;
            double bottomRightLongitude;
            string[] coordinatesFromPath = path.Remove(path.LastIndexOf(".")).Substring(path.LastIndexOf(@"\") + 1).Split("_".ToCharArray());
            foreach (string coordinate in coordinatesFromPath)
            {
                if (coordinate.Length != 6 || coordinate == null || coordinate == string.Empty)
                {
                    throw (new FormatException("Coordinates in image name not in correct format!"));
                }
            }
            topLeftLongitude = Convert.ToDouble(coordinatesFromPath[0]);
            topLeftLatitude = Convert.ToDouble(coordinatesFromPath[1]);
            bottomRightLongitude = Convert.ToDouble(coordinatesFromPath[2]);
            bottomRightLatitude = Convert.ToDouble(coordinatesFromPath[3]);
            topLeftPoint = new GpsPoint(topLeftLatitude, topLeftLongitude, GpsPointFormatImport.Swiss);
            bottomRightPoint = new GpsPoint(bottomRightLatitude, bottomRightLongitude, GpsPointFormatImport.Swiss);
            map = new Map(image, topLeftPoint, bottomRightPoint);
		}

		public void setParcours(string path)
        {
            // ToDo: ;)
        }

        public void SetTakeOffGate(GpsPoint leftPoint, GpsPoint rightPoint)
        {
            takeOffGate = new Gate(leftPoint, rightPoint);
        }
        #endregion Public Methods
    }
}