///////////////////////////////////////////////////////////
//  Flight.cs
//  Implementation of the Class Flight
//  Created on:      15-Apr-2008 21:38:39
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;

namespace ANR.Core
{
    [Serializable]
    public class Flight : AnrObject 
    {
        #region Private Members
        private Guid flightId;
        
        private CompetitorGroup competitorGroup;
        private Competitor competitor;
        private Map map;                                
        private Parcours parcours;
        private Route route;


        PenaltyCollection penalties = null;

        private PenaltyCollection customPenalties;
        private PenaltyCollection automaticPenalties;
        
        private TrackPointCollection track;
        private string filename;


        private DateTime plannedTakeOffTime;
        private DateTime plannedFinishGateTime;
        private DateTime plannedStartGateTime;
        
        private Guid competitorGroupId;
        private Guid competitorId;
        #endregion Private Members

        #region Constructors
        public Flight()
            : base()
        {
            this.track = new TrackPointCollection();
            customPenalties = new PenaltyCollection();
            automaticPenalties = new PenaltyCollection();
        }
        //public Flight(string filename, Route route, Parcours parcours)
        //    : base()
        //{
        //    this.track = this.dataFromGAC(filename);
        //    this.Route = route;
        //    this.parcours = parcours;
        //    //penalties = this.calculateForbiddenZonePenalties();
        //}


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
        public Route Route
        {
            get 
            { 
                return route; 
            }
            set 
            { 
                route = value; 
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
        public Competitor Competitor
        {
            get 
            { 
                return competitor; 
            }
            set 
            { 
                competitor = value; 
            }
        }
        public CompetitorGroup CompetitorGroup
        {
            get 
            { 
                return competitorGroup; 
            }
            set 
            { 
                competitorGroup = value; 
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
        public PenaltyCollection Penalties
        {
            get
            {
                if (penalties == null)
                {
                    PenaltyCollection pc = new PenaltyCollection();
                    pc.AddRange(CustomPenalties);
                    pc.AddRange(AutomaticPenalties);
                    return pc;
                }
                else
                {
                    return penalties;
                }
            }
        }
        public PenaltyCollection CustomPenalties
        {
            get 
            { 
                return customPenalties; 
            }
            set 
            { 
                customPenalties = value; 
            }
        }
        public PenaltyCollection AutomaticPenalties
        {
            get 
            {
                PenaltyCollection pc = new PenaltyCollection();
                pc.AddRange(calculateForbiddenZonePenalties());
                pc.AddRange(calculateGatePenalties());
                return pc;
            }
        }
        public TrackPointCollection Track
        {
            get
            {
                return track;
            }
            set
            {
                track = value;
            }
        }
       
        public DateTime PlannedTakeOffTime
        {
            get { return plannedTakeOffTime; }
            set { plannedTakeOffTime = value; }
        }
        public DateTime TakeOffTime
        {
            get 
            {
                for (int i = 0; i < this.Track.Count - 2; i++)
                {
                    if (route.TakeOffGate.gatePassed(this.Track[i], this.Track[i + 1]))
                    {
                        return this.Track[i + 1].TimeStamp;
                    }
                }
                return new DateTime(0);
            }
        }
        public DateTime PlannedFinishGateTime
        {
            get { return plannedFinishGateTime; }
            set { plannedFinishGateTime = value; }
        }
        public DateTime FinishGateTime
        {
            get
            {
                for (int i = 0; i < this.Track.Count - 2; i++)
                {
                    if (this.Route.EndGate.gatePassed(this.Track[i], this.Track[i + 1]))
                    {
                        return this.Track[i + 1].TimeStamp;
                    }
                }
                return DateTime.MinValue;
            }
        }
        public DateTime PlannedStartGateTime
        {
            get { return plannedStartGateTime; }
            set { plannedStartGateTime = value; }
        }
        public DateTime StartGateTime
        {
            get
            {
                for (int i = 0; i < this.Track.Count - 2; i++)
                {
                    if (this.Route.StartGate.gatePassed(this.Track[i], this.Track[i + 1]))
                    {
                        return this.Track[i + 1].TimeStamp;
                    }
                }
                return DateTime.MinValue;
            }
        }
      
        public string Filename
        {
            get 
            { 
                return filename; 
            }
            set 
            { 
                filename = value; 
            }
        }

        #endregion Public Properties

        #region Methods

        public void resetPenalties()
        {
            this.penalties = null;
        }

        /// <summary>
        /// Imports a GAC File of a Flight.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>The created Flight object</returns>
        public void dataFromGAC(string filename)
        {
            TrackPointCollection trackpoints = new TrackPointCollection();
            StreamReader gacFileStreamReader = new StreamReader(filename);
            string line = string.Empty;
            DateTime newPointTimeStamp = DateTime.Now;
            double newPointLatitude = 0;
            double newPointLongitude = 0;
            line = gacFileStreamReader.ReadLine();
            while (!line.Substring(0, 1).Equals("I") && !gacFileStreamReader.EndOfStream)
            {
                line = gacFileStreamReader.ReadLine();
            }
            {
                while (!gacFileStreamReader.EndOfStream)
                {
                    line = gacFileStreamReader.ReadLine();
                    if (line.Substring(0, 1).Equals("B"))
                    {
                        // timestamp
                        newPointTimeStamp = new DateTime(1, 1, 1, Convert.ToInt32(line.Substring(1, 2)), Convert.ToInt32(line.Substring(3, 2)), Convert.ToInt32(line.Substring(5, 2)));
                        // latitude
                        newPointLatitude = Convert.ToDouble(line.Substring(7, 2)) * 3600 + Convert.ToDouble(line.Substring(9, 2)) * 60 + Convert.ToDouble(line.Substring(11, 3)) * 60 / 1000;
                        switch (line.Substring(14, 1))
                        {
                            case "N":
                                break;
                            case "S":
                                newPointLatitude *= (-1);
                                break;
                            default:
                                // TODO: Error
                                break;
                        }
                        // longitude
                        newPointLongitude = Convert.ToDouble(line.Substring(15, 3)) * 3600 + Convert.ToDouble(line.Substring(18, 2)) * 60 + Convert.ToDouble(line.Substring(20, 3)) * 60 / 1000;
                        switch (line.Substring(23, 1))
                        {
                            case "E":
                                break;
                            case "W":
                                newPointLongitude *= (-1);
                                break;
                            default:
                                // ToDo: Error
                                break;
                        }
                        TrackPoint newTrackPoint = new TrackPoint(newPointLatitude, newPointLongitude, newPointTimeStamp, GpsPointFormatImport.WGS84);

                        trackpoints.Add(newTrackPoint);
                    }
                }
            }
            this.track = trackpoints;
        }
    
        public Gate getExtendedGate(Gate gate)
        {
            double k = 200; //distance to middle point
            GpsPoint m = new GpsPoint((gate.LeftPoint.Latitude + gate.RightPoint.Latitude) / 2, (gate.LeftPoint.Longitude + gate.RightPoint.Longitude) / 2, GpsPointFormatImport.WGS84);
            double alpha = Math.Atan((gate.LeftPoint.Latitude - gate.RightPoint.Latitude) / (gate.LeftPoint.Longitude + gate.RightPoint.Longitude));
            GpsPoint p1 = new GpsPoint(m.Latitude - (k * Math.Cos(alpha - (Math.PI / 2))), m.Longitude - (k * Math.Sin(alpha - (Math.PI / 2))), GpsPointFormatImport.WGS84);
            GpsPoint p2 = new GpsPoint(m.Latitude + (k * Math.Cos((Math.PI / 2) - alpha)), m.Longitude + (k * Math.Sin((Math.PI / 2) - alpha)), GpsPointFormatImport.WGS84);
            return new Gate(p1, p2);
        }

        private PenaltyCollection calculateForbiddenZonePenalties()
        {
            bool lastPointWasOffTrack = false;
            bool finishingGatePassed = false;

            List<TrackPoint> penaltyPoints = new List<TrackPoint>();

            PenaltyCollection penalties = new PenaltyCollection();
            List<List<TrackPoint>> penaltyPointsList = new List<List<TrackPoint>>();

            for (int i = 0; i < this.Track.Count - 1; i++)
            {
                if (!finishingGatePassed)
                {
                    TrackPoint trackpoint = this.Track[i];
                    
                    if(route.EndGate.gatePassed(trackpoint, this.Track[i+1]))
                    {
                        break;
                    }
                    if(trackpoint.TimeStamp > PlannedFinishGateTime.AddSeconds(120))
                    { 
                        break;
                    }
                    if (this.Parcours.IsPointOffTrack(trackpoint))
                    {
                        lastPointWasOffTrack = true;
                        penaltyPoints.Add(trackpoint);
                    }
                    else
                    {
                        if (lastPointWasOffTrack)
                        {
                            penaltyPointsList.Add(penaltyPoints);
                            penaltyPoints = new List<TrackPoint>();
                        }
                        lastPointWasOffTrack = false;
                    }
                }
            }

            foreach (List<TrackPoint> penaltySequence in penaltyPointsList)
            {
                int durance = penaltySequence.Count;
                Penalty penalty = new Penalty();
                penalty.PenaltyType = PenaltyType.Navigation;
                if(durance > 5 && durance*3 < 200)
                {
                    penalty.PenaltyPoints = durance * 3;
                }
                else if(durance * 3 > 200)
                {
                    penalty.PenaltyPoints = 200;
                }
                penalty.Comment = "Entering Restricted Area (" + penaltySequence[0].TimeStamp.ToString("HH:mm:ss") + " until " +
                        penaltySequence[penaltySequence.Count - 1].TimeStamp.ToString("HH:mm:ss") + "), total " + Math.Floor((penaltySequence[penaltySequence.Count - 1].TimeStamp.Subtract(penaltySequence[0].TimeStamp)).TotalSeconds + 1).ToString() + " seconds";
                penalties.Add(penalty);
            }
            return penalties;
        }

        private PenaltyCollection calculateGatePenalties()
        {
            PenaltyCollection pc = new PenaltyCollection();
            pc.Add(getTakeOffGatePenaltyPoints(PlannedTakeOffTime, TakeOffTime));
            pc.Add(getGatePenaltyPoints("Start Gate", PlannedStartGateTime, StartGateTime));
            pc.Add(getGatePenaltyPoints("Finishing Gate", PlannedFinishGateTime, FinishGateTime));
            return pc;
        }

        private Penalty getGatePenaltyPoints(string gatename, DateTime expected, DateTime effective)
        {
            double seconds = Math.Abs(expected.TimeOfDay.Subtract(effective.TimeOfDay).TotalSeconds);
            int points = 0;
            string message = "Passed " + gatename + " right on time";
            if (seconds > 1 && seconds * 3 < 200)
            {
                message = "Failed to pass " + gatename + " by " + seconds + " seconds. (Plan: " +
                    expected.ToString("HH:mm:ss") + ", effective: " + effective.ToString("HH:mm:ss") + ").";
                points = Convert.ToInt32((seconds-1) * 3);
            }
            else if (seconds * 3 >= 200)
            {
                message = "Failed to pass "+ gatename + " within time slot. (Maximum Penalty, Plan: " +
                    expected.ToString("HH:mm:ss") + ", effective: " + effective.ToString("HH:mm:ss") + ").";;
                points = 200;
            }
            return new Penalty(points, PenaltyType.Navigation, message);
        }
        
        private Penalty getTakeOffGatePenaltyPoints(DateTime expected, DateTime effective)
        {
            double seconds = effective.TimeOfDay.Subtract(expected.TimeOfDay).TotalSeconds;
            string message = "Passed Takeoff gate within time slot";
            int points = 0;
            if (seconds > 60 || seconds < 0 )
            {
                message = "Failed to take off within time slot. (Maximum Penalty, Plan: " +
                    expected.ToString("HH:mm:ss") + ", effective: " + effective.ToString("HH:mm:ss") + ")."; ;
                points = 200;
            }
            return new Penalty(points, PenaltyType.Navigation, message);
        }

        #endregion
    }
}