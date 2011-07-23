///////////////////////////////////////////////////////////
//  ForbiddenZone.cs
//  Implementation of the Class ForbiddenZone
//  Created on:      15-Apr-2008 21:38:39
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System;
namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class ForbiddenZone
    {
        #region Private Members
        private Guid forbiddenZoneId;
        private GpsPointCollection gpsPoints = new GpsPointCollection();
        #endregion Private Members

        #region Constructors
        public ForbiddenZone()
            : base()
        {
        }

        public ForbiddenZone(GpsPointCollection gpsPointCollection)
        {
            foreach (GpsPoint gpsPoint in gpsPointCollection)
            {
                AddGpsPoint(gpsPoint);
            }
        }
        #endregion Constructors

        #region Public Properties
        public Guid ForbiddenZoneId
        {
            get
            {
                return forbiddenZoneId;
            }
            set
            {
                forbiddenZoneId = value;
            }
        }

        public GpsPointCollection GpsPoints
        {
            get
            {
                return gpsPoints;
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void AddGpsPoint(GpsPoint gpsPoint)
        {
            gpsPoints.Add(gpsPoint);
        }

        public bool IsPointInZone(TrackPoint currentTrackPoint)
        {
            // ToDo: move strange things from Common class here
            throw new NotImplementedException();
        }
        #endregion Public Methods
    }
}