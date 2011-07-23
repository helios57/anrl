///////////////////////////////////////////////////////////
//  Parcours.cs
//  Implementation of the Class Parcours
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.IO;
using System;
namespace PFA.ANR.BusinessLayer
{
    [Serializable]
	public class Parcours
    {
        #region Private Members
        private string parcoursPath;
        private ForbiddenZoneCollection forbiddenZones;
        private RouteCollection routes;
		private Gate nbLine;
        #endregion Private Members

        #region Constructors
        public Parcours()
            : base()
        {
            forbiddenZones = new ForbiddenZoneCollection();
            routes = new RouteCollection();
            nbLine = new Gate();
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
        #endregion Public Methods
    }
}