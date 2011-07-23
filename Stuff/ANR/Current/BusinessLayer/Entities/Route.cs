///////////////////////////////////////////////////////////
//  Route.cs
//  Implementation of the Class Route
//  Created on:      31-Aug-2008 17:00:00
///////////////////////////////////////////////////////////

using System;

namespace ANR.Core
{
    [Serializable]
	public class Route : AnrObject
    {
        #region Private Members
        private string routeName;
		private Gate startGate;
		private Gate endGate;
        private Parcours parentParcours;

        #endregion Private Members

        #region Constructors
        public Route(Parcours parentParcours)
            : base()
        {
            this.parentParcours = parentParcours;
        }
        #endregion Constructors

        #region Public Properties
		public string RouteName
        {
			get
            {
				return routeName;
			}
			set
            {
				routeName = value;
			}
		}

        public Gate StartGate
        {
			get
            {
                return startGate;
			}
			set
            {
                startGate = value;
			}
		}

        public Gate EndGate
        {
			get
            {
                return endGate;
			}
			set
            {
                endGate = value;
			}
        }
        public Gate TakeOffGate
        {
            get { return this.parentParcours.ParentMap.ParentCompetition.TakeOffGate; }
        }
        public Parcours ParentParcours
        {
            get 
            { 
                return parentParcours; 
            }
            set 
            { 
                parentParcours = value; 
            }
        }
        #endregion Public Properties
    }

}