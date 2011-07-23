///////////////////////////////////////////////////////////
//  CompetitorCollection.cs
//  Implementation of the Class CompetitorCollection
//  Created on:      12-May-2008 14:20:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace ANR.Core
{
    [Serializable]
    public class CompetitorCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Competitor> items;
        private int nextCompetitionNumber = 0;
        #endregion Private Members

        #region Constructors
        public CompetitorCollection()
            : base()
        {
            items = new List<Competitor>();
        }
        #endregion Constructors

        #region Public Properties
        public int NextCompetitionNumber
        {
            get
            {
                nextCompetitionNumber++;
                return nextCompetitionNumber;
            }
        }

        public Competitor this[Guid competitorId]
        {
            get
            {
                foreach (Competitor competitor in items)
                {
                    if (competitor.Id == competitorId)
                    {
                        return competitor;
                    }
                }
                return null;
            }
        }

        public Competitor this[int competitorNumber]
        {
            get
            {
                foreach (Competitor competitor in items)
                {
                    if (competitor.CompetitionNumber == competitorNumber)
                    {
                        return competitor;
                    }
                }
                return null;
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void Add(Competitor item)
        {
            items.Add(item);
        }

        public void AddRange(CompetitorCollection itemCollection)
        {
            foreach (Competitor item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(Competitor item)
        {
            items.Remove(item);
        }

        public bool Contains(Competitor item)
        {
            return items.Contains(item);
        }
        public bool Contains(int competitionNumber)
        {
            foreach (Competitor c in items)
            {
                if (c.CompetitionNumber == competitionNumber)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// returns a csv String of the CompetitorList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string getCsvCompetitorList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0};{1};{2};{3};{4};{5};{6};",
                   "Competition Number", "AC-Callsign", "Pilot Name", "Pilot Firstname",
                   "Navigator Name", "Navigator Firstname", "Country"));
            foreach (Competitor competitor in this)
            {
                sb.AppendLine(String.Format("{0};{1};{2};{3};{4};{5};{6};",
                    competitor.CompetitionNumber, competitor.AcCallsign, competitor.PilotName, competitor.PilotFirstName,
                    competitor.NavigatorName, competitor.NavigatorFirstName, competitor.Country));
            }
            return sb.ToString();
        }


        #endregion Public Methods

        #region ICollection Members
        public void  CopyTo(Array array, int index)
        {
 	        throw new NotImplementedException();
        }

        public int  Count
        {
	        get
            {
                return items.Count;
            }
        }

        public bool  IsSynchronized
        {
	        get
            {
                return false;
            }
        }

        public object  SyncRoot
        {
	        get
            {
                return this;
            }
        }
        #endregion

        #region IEnumerable Members
        public IEnumerator  GetEnumerator()
        {
 	        return items.GetEnumerator();
        }
        #endregion

    }
}
