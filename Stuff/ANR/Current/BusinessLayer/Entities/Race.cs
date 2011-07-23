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
using System.Runtime.Serialization.Formatters.Binary;

namespace ANR.Core
{
    [Serializable]
	public class Race : AnrObject
    {
        #region Private Members
        private CompetitorCollection competitors;
        private CompetitorGroupCollection competitorGroups;
        private FlightCollection flights;
        private Map map;
        private Parcours parcours;

		private string raceName;
        #endregion Private Members

        #region Constructors
        public Race()
            : base()
        {
            competitors = new CompetitorCollection();
            competitorGroups = new CompetitorGroupCollection();
            flights = new FlightCollection();
        }

        public Race(string filename)
            : base()
        {
            competitors = new CompetitorCollection();
            competitorGroups = new CompetitorGroupCollection();
            flights = new FlightCollection();
            map = new Map();
            this.loadRace(filename);
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
        public Parcours Parcours
        {
            get 
            { 
                return parcours; 
            }
            set 
            { 
                parcours = value; 
            }
        }

		public string Name
        {
			get
            {
				return raceName;
			}
			set
            {
				raceName = value;
			}
        }

        #endregion Public Properties

        #region Public Methods
        
        public void saveRace(string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            binaryFormatter.Serialize(fStream, this);
        }
        public void loadRace(string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Stream fStream = File.OpenRead(filename);
            Race r = (Race)binaryFormatter.Deserialize(fStream);
            this.competitors = r.Competitors;
            this.competitorGroups = r.CompetitorGroups;
            this.flights = r.Flights;
            this.map = r.map;
        }

        #endregion Public Methods
    }
}