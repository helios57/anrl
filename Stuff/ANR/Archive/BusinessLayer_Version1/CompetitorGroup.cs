///////////////////////////////////////////////////////////
//  CompetitorGroup.cs
//  Implementation of the Class CompetitorGroup
//  Created on:      25-Apr-2008 11:40:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class CompetitorGroup : AnrObject
    {
        #region Private Members
        private const int groupSize = 4; // todo: config?!

        private Guid id;
        private int groupNumber;
        private string groupName;
        private CompetitorCollection competitors;
        private DateTime[] takeOffTime;
        private DateTime startingTime;
        private bool defaultRunway;
        private string parcoursPath;
        private Parcours parcours;
        private TimeSpan parcoursTime;
        #endregion Private Members

        #region constructors
        public CompetitorGroup()
            : base()
        {
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

        public int GroupNumber
        {
            get
            {
                return groupNumber;
            }
            set
            {
                groupNumber = value;
            }
        }

        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }

        public CompetitorCollection Competitors
        {
            get
            {
                return competitors;
            }
        }

        public DateTime[] TakeOffTime
        {
            get
            {
                return takeOffTime;
            }
        }

        public DateTime FirstTakeOffTime
        {
            get
            {
                return takeOffTime[0];
            }
        }

        public DateTime StartingTime
        {
            get
            {
                return startingTime;
            }
        }

        public bool DefaultRunway
        {
            get
            {
                return defaultRunway;
            }
            set
            {
                defaultRunway = value;
            }
        }

        public string ParcoursPath// todo: --> method (property = readonly) / path --> property of parcours
        {
            get
            {
                return parcoursPath;
            }
            set
            {
                parcoursPath = value;
                parcours = Common.importFromDxf(value);
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
        #endregion Public Properties

        #region Public Methods
        public void changeCompetitorGroup(string groupName, DateTime takeOffTime,
                                            TimeSpan takeOffToStartGateTime, bool runwayEighteen,
                                            string parcoursPath, TimeSpan parcoursTime, CompetitorCollection competitors)
        {
            this.groupName = groupName;
            this.setTakeOffTime(takeOffTime);
            this.startingTime = takeOffTime.Add(takeOffToStartGateTime).Add(new TimeSpan(0, 3, 0));
            this.defaultRunway = runwayEighteen;
            this.parcoursPath = parcoursPath;
            this.parcoursTime = parcoursTime;
            this.competitors = competitors;
        }

        public void addCompetitor(Competitor competitor)
        {

            if (this.competitors.Count < groupSize)
            {
                this.competitors.Add(competitor);
            }
            else
            {
                throw new Exception("CompetitorGroup is full.");
            }
        }

        public void removeCompetitor(Competitor competitors)
        {
            this.competitors.Remove(competitors);
        }
    
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

        private void setTakeOffTime(DateTime takeOffTime)
        {
            this.takeOffTime[0] = takeOffTime;
            this.takeOffTime[1] = takeOffTime.Add(new TimeSpan(0, 1, 0));
            this.takeOffTime[2] = takeOffTime.Add(new TimeSpan(0, 2, 0));
            this.takeOffTime[3] = takeOffTime.Add(new TimeSpan(0, 3, 0));
        }
        #endregion methods
    }//end CompetitorGroup
}//end namespace PFA.ANR.BusinessLayer
