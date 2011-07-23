///////////////////////////////////////////////////////////
//  Parcours.cs
//  Implementation of the Class Parcours
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.IO;
using System;
namespace ANR.Core
{
    [Serializable]
	public class Parcours : AnrObject
    {
        #region Private Members
        private ForbiddenZoneCollection forbiddenZones;
        private RouteCollection routes;
		private Gate nbLine;
        private string parcoursName;
        private Map parentMap;
        private TimeSpan defaultTargetFlightDuration;
        private TimeSpan timeToStartGateDefaultRunway;

        
        #endregion Private Members

        #region Constructors
        public Parcours(Map parentMap)
            : base()
        {
            this.forbiddenZones = new ForbiddenZoneCollection();
            this.routes = new RouteCollection();
            this.nbLine = new Gate();
            this.parentMap = parentMap;
        }

        public Parcours(string filepath, Map parentMap)
            : base()
        {
            this.forbiddenZones = new ForbiddenZoneCollection();
            this.routes = new RouteCollection();
            this.nbLine = new Gate();
            this.parentMap = parentMap;
            this.importFromDxf(filepath);
        }
        #endregion Constructors

        #region Public Properties
        public ForbiddenZoneCollection ForbiddenZones
        {
			get
            {
				return forbiddenZones;
			}
        }
        public string ParcoursName
        {
            get 
            {
                return parcoursName; 
            }
            set 
            {
                parcoursName = value; 
            }
        }
        public RouteCollection Routes
        {
            get
            {
                return routes;
            }
            set
            {
                routes = value;
            }
        }

        public Gate NbLine
        {
            get
            {
                return nbLine;
            }
            set
            {
                nbLine = value;
            }
        }

        public Map ParentMap
        {
            get 
            { 
                return parentMap; 
            }
            set 
            { 
                parentMap = value; 
            }
        }

        public TimeSpan DefaultTargetFlightDuration
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

        public TimeSpan TimeToStartGateDefaultRunway
        {
            get 
            { 
                return timeToStartGateDefaultRunway; 
            }
            set 
            { 
                timeToStartGateDefaultRunway = value; 
            }
        }

        #endregion Public Properties

        #region Public Methods
        public bool IsPointOffTrack(TrackPoint pointToTest)
        {
            double y = pointToTest.Latitude;
            double x = pointToTest.Longitude;
            bool isOffTrack = false;

            foreach (ForbiddenZone forbiddenZone in this.forbiddenZones)
            {
                int polySides = forbiddenZone.GpsPoints.Count - 1;
                double[] polyY = new double[forbiddenZone.GpsPoints.Count];
                double[] polyX = new double[forbiddenZone.GpsPoints.Count];

                int k = 0;
                foreach (GpsPoint gpsPoint in forbiddenZone.GpsPoints)
                {
                    polyY[k] = gpsPoint.Latitude;
                    polyX[k] = gpsPoint.Longitude;
                    k++;
                }

                int i, j = polySides - 1;
                bool oddNodes = false;

                for (i = 0; i < polySides; i++)
                {
                    if (polyY[i] < y && polyY[j] >= y || polyY[j] < y && polyY[i] >= y)
                    {
                        if (polyX[i] + (y - polyY[i]) / (polyY[j] - polyY[i]) * (polyX[j] - polyX[i]) < x)
                        {
                            oddNodes = !oddNodes;
                        }
                    }
                    j = i;
                }
                isOffTrack = oddNodes;
                if (isOffTrack)
                    return isOffTrack;

            }
            return isOffTrack;
        }

        /// <summary> 
        /// Imports a DxfFile that is in the specified Format. Any changes on the import schema may cause Errors!
        /// </summary>
        /// <param name="filepath"></param>
        public void importFromDxf(string filepath)
        {

            StreamReader sr = new StreamReader(filepath);
            List<string> lineList = new List<string>();
            while (!sr.EndOfStream)
            {
                lineList.Add(sr.ReadLine());
            }
            string[] lines = lineList.ToArray();
            for (int i = 1; i < lines.Length; i++) //Looping through Array, starting with 1 (lines[0] is "0")
            {
                //Find Lines Containing a new Element Definition
                if (lines[i] == "LWPOLYLINE" && lines[i - 1] == "  0") //
                {
                    //Reading out Layer ( "8" [\n] layerName) = Type of Element
                    if (lines[i + 5] == "  8" && lines[i + 6].Contains("PROH")) // "Prohibited Zone" = ForbiddenZone
                    {
                        if (lines[i + 9] == " 90")
                        {
                            int numberOfVertexes = int.Parse(lines[i + 10]);
                            ForbiddenZone forbiddenZone = new ForbiddenZone();
                            for (int j = 0; j < numberOfVertexes; j++)
                            {
                                forbiddenZone.AddGpsPoint(new GpsPoint(double.Parse(lines[i + (j * 4) + 18]) * 1000, double.Parse(lines[i + (j * 4) + 16]) * 1000, GpsPointFormatImport.Swiss));
                            }
                            this.ForbiddenZones.Add(forbiddenZone);
                        }
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("STARTPOINT-"))
                    {
                        Gate g = new Gate(new GpsPoint(double.Parse(lines[i + 18]) * 1000, double.Parse(lines[i + 16]) * 1000, GpsPointFormatImport.Swiss),
                                     new GpsPoint(double.Parse(lines[i + 22]) * 1000, double.Parse(lines[i + 20]) * 1000, GpsPointFormatImport.Swiss));

                        string gatename = lines[i + 6].Substring(11, 1);
                        if (!this.Routes.Contains(gatename))
                        {
                            Route newRoute = new Route(this);
                            newRoute.RouteName = gatename;
                            this.Routes.Add(newRoute);
                        }
                        this.Routes[gatename].StartGate = g;
                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("ENDPOINT-"))
                    {
                        Gate g = new Gate(new GpsPoint(double.Parse(lines[i + 18]) * 1000, double.Parse(lines[i + 16]) * 1000, GpsPointFormatImport.Swiss),
                                     new GpsPoint(double.Parse(lines[i + 22]) * 1000, double.Parse(lines[i + 20]) * 1000, GpsPointFormatImport.Swiss));

                        string gatename = lines[i + 6].Substring(9, 1);
                        if (!this.Routes.Contains(gatename))
                        {
                            Route newRoute = new Route(this);
                            newRoute.RouteName = gatename;
                            this.Routes.Add(newRoute);
                        }
                        this.Routes[gatename].EndGate = g;

                    }
                    else if (lines[i + 5] == "  8" && lines[i + 6].Contains("NBLINE"))
                    {
                        if (lines[i + 9] == " 90" && double.Parse(lines[10]) == 2)
                        {
                            this.NbLine = new Gate(new GpsPoint(double.Parse(lines[i + 18]) * 1000, double.Parse(lines[i + 16]) * 1000, GpsPointFormatImport.Swiss),
                                new GpsPoint(double.Parse(lines[i + 22]) * 1000, double.Parse(lines[i + 20]) * 1000, GpsPointFormatImport.Swiss));
                        }
                    }
                }
            }
        }

        #endregion Public Methods
    }
}