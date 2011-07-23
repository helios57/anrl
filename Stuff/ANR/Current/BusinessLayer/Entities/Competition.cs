using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANR.Core
{
    [Serializable]
    public class Competition
    {
        #region Private Fields
        private MapCollection mapCollection;
        private CompetitorCollection competitorCollection;
        private RaceCollection raceCollection;

        private GpsPoint startPoint;

        private Gate takeOffGate;
        private int runway;

        private string competitionName;
        private string location;
        private string organizer;
        private DateTime date;

        private TimeSpan intervalBetweenGroupTakeoffs;

        public TimeSpan IntervalBetweenGroupTakeoffs
        {
            get { return intervalBetweenGroupTakeoffs; }
            set { intervalBetweenGroupTakeoffs = value; }
        }
        private TimeSpan intervalBetweenGroupCompetitorTakeoffs;

        public TimeSpan IntervalBetweenGroupCompetitorTakeoffs
        {
            get { return intervalBetweenGroupCompetitorTakeoffs; }
            set { intervalBetweenGroupCompetitorTakeoffs = value; }
        }
        
        #endregion

        #region Public Properties
        public MapCollection MapCollection
        {
            get { return mapCollection; }
            set { mapCollection = value; }
        }

        public RaceCollection RaceCollection
        {
            get { return raceCollection; }
            set { raceCollection = value; }
        }
        
        public CompetitorCollection CompetitorCollection
        {
            get { return competitorCollection; }
            set { competitorCollection = value; }
        }
        public GpsPoint StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        public int Runway
        {
            get { return runway; }
            set { runway = value; }
        }
        public Gate TakeOffGate
        {
            get
            {
                takeOffGate = null;
                if (startPoint != null)
                {
                    double k = 200; //distance to middle point
                    double alpha = Math.PI * runway / 18.0; //angle
                    GpsPoint p1 = new GpsPoint(startPoint.Latitude - (k * Math.Cos(alpha - (Math.PI / 2))), startPoint.Longitude - (k * Math.Sin(alpha - (Math.PI / 2))), GpsPointFormatImport.WGS84);
                    GpsPoint p2 = new GpsPoint(startPoint.Latitude + (k * Math.Cos((Math.PI / 2) - alpha)), startPoint.Longitude + (k * Math.Sin((Math.PI / 2) - alpha)), GpsPointFormatImport.WGS84);
                    return new Gate(p1, p2);
                }
                return takeOffGate; 
            }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string CompetitionName
        {
            get { return competitionName; }
            set { competitionName = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Organizer
        {
            get { return organizer; }
            set { organizer = value; }
        }
        #endregion
        
        #region Constructors
        public Competition()
            : base()
        {
            this.mapCollection = new MapCollection();
            this.competitorCollection = new CompetitorCollection();
            this.raceCollection = new RaceCollection();
            date = new DateTime();
        }


        #endregion
    }
}
