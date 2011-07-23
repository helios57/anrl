using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    
    [Serializable]
    public class CompetitorRouteAssignmentCollection: AnrObject, ICollection
    {
        #region Private Members
        private List<CompetitorRouteAssignment> items;
        #endregion Private Members

        #region Constructors
        public CompetitorRouteAssignmentCollection()
        {
            items = new List<CompetitorRouteAssignment>();
        }
        #endregion Constructors

        #region Public Properties

        public CompetitorRouteAssignment this[Competitor competitor]
        {
            get
            {
                foreach(CompetitorRouteAssignment competitorRouteAssignment in items)
                {
                    if (competitor == competitorRouteAssignment.Competitor)
                    {
                        return competitorRouteAssignment;
                    }
                }
                return null;
            }
        }

        public CompetitorRouteAssignment this[Route route]
        {
            get
            {
                foreach (CompetitorRouteAssignment competitorRouteAssignment in items)
                {
                    if (route == competitorRouteAssignment.Route)
                    {
                        return competitorRouteAssignment;
                    }
                }
                return null;
            }
        }
           
        #endregion Public Properties

        #region Public Methods
        public void Add(CompetitorRouteAssignment item)
        {
            items.Add(item);
        }

        public void AddRange(CompetitorRouteAssignmentCollection itemCollection)
        {
            foreach (CompetitorRouteAssignment item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(CompetitorRouteAssignment item)
        {
            items.Remove(item);
        }

        public bool Contains(CompetitorRouteAssignment item)
        {
            return items.Contains(item);
        }
        public bool Contains(Route item)
        {
            foreach (CompetitorRouteAssignment competitorRouteAssignment in items)
            {
                if (competitorRouteAssignment.Route == item)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Contains(Competitor item)
        {
            foreach (CompetitorRouteAssignment competitorRouteAssignment in items)
            {
                if (competitorRouteAssignment.Competitor == item)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion Public Methods

        #region ICollection Members
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region IEnumerable Members
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion
    }
}
