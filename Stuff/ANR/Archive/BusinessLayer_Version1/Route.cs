///////////////////////////////////////////////////////////
//  Route.cs
//  Implementation of the Class Route
//  Created on:      31-Aug-2008 17:00:00
///////////////////////////////////////////////////////////

using System;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
	public class Route
    {
        #region Private Members
        private string routeName;
		private Gate startGate;
		private Gate endGate;
        #endregion Private Members

        #region Constructors
        public Route()
            : base()
        {
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
        #endregion Public Properties
    }

}