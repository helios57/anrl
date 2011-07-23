///////////////////////////////////////////////////////////
//  CompetitorGroup.cs
//  Implementation of the Class CompetitorGroup
//  Created on:      25-Apr-2008 11:40:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace ANR.Core
{
    [Serializable]
    public class CompetitorGroup : AnrObject
    {
        #region Private Members
        private CompetitorRouteAssignmentCollection competitorRouteAssignmentCollection;
        private Guid id;
        private string name;
        private CompetitorCollection competitors;
        
        private DateTime startingTime;
        private TimeSpan interval;
        private TimeSpan takeoffToStartGateTime;

       
        private TimeSpan parcoursTime;
     
        private Parcours parcours;

        #endregion Private Members

        #region constructors
        public CompetitorGroup()
            : base()
        {
            id = Guid.NewGuid();
            competitors = new CompetitorCollection();
            startingTime = new DateTime();
            parcoursTime = new TimeSpan();
            competitorRouteAssignmentCollection = new CompetitorRouteAssignmentCollection();
        }
        #endregion constructors

        #region Public Properties
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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

        public DateTime StartingTime
        {
            get
            {
                return startingTime;
            }
            set
            {
                startingTime = value;
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
        public TimeSpan ParcoursTime
        {
            get
            {
                return parcoursTime;
            }
            set
            {
                parcoursTime = value;
            }
        }
        public TimeSpan Interval
        {
            get 
            {
                return interval; 
            }
            set 
            { 
                interval = value; 
            }
        }
        public TimeSpan TakeoffToStartGateTime
        {
            get { return takeoffToStartGateTime; }
            set { takeoffToStartGateTime = value; }
        }

        public CompetitorRouteAssignmentCollection CompetitorRouteAssignmentCollection
        {
            get 
            { 
                return competitorRouteAssignmentCollection; 
            }
            set 
            { 
                competitorRouteAssignmentCollection = value; 
            }
        }
        #endregion Public Properties

        #region Public Methods
    
        public void moveDown(int index)
        {
            if (index < this.competitors.Count - 1)
            {
                CompetitorCollection tempList = new CompetitorCollection();
                for (int i = 0; i < competitors.Count - 1; i++)
                {
                    if (i == index)
                    {
                        tempList.Add(this.competitors[i+1]);
                        tempList.Add(this.competitors[i]);
                        i += 2;
                    }
                    else
                    {
                        tempList.Add(this.competitors[i]);
                        i++;
                    }
                }
                this.competitors = tempList;
            }
        }

        public void moveUp(int index)
        {
            if (index > 0 - 1)
            {
                CompetitorCollection tempList = new CompetitorCollection();
                for (int i = competitors.Count - 1; i > 1; i--)
                {
                    if (i == index)
                    {
                        tempList.Add(this.competitors[i-1]);
                        tempList.Add(this.competitors[i]);
                        i -= 2;
                    }
                    else
                    {
                        tempList.Add(this.competitors[i]);
                        i--;
                    }
                }
                this.competitors = tempList;
            }
        }

        #endregion methods
    }
}