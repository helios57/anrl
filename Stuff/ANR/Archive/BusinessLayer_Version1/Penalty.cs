///////////////////////////////////////////////////////////
//  Penalty.cs
//  Implementation of the Class Penalty
//  Created on:      15-Apr-2008 21:38:40
///////////////////////////////////////////////////////////

using System;

public enum PenaltyType
{
    Navigation,
    Landing,
    Custom
}

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
	public class Penalty
    {
        #region Private Members
		private string comment;
		private int penaltyPoints;
        private PenaltyType type;
        #endregion Private Members

        #region Constructors
        public Penalty()
            : base()
        {
        }
        #endregion Constructors

        #region Public Properties
		public string Comment
        {
			get
            {
				return comment;
			}
			set
            {
				comment = value;
			}
		}

		public int PenaltyPoints
        {
			get
            {
				return penaltyPoints;
			}
			set
            {
				penaltyPoints = value;
			}
		}

        public PenaltyType PenaltyType
        {
			get
            {
				return type;
			}
			set
            {
				type = value;
			}
        }
        #endregion Public Properties
    }

}