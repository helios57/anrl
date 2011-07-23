///////////////////////////////////////////////////////////
//  CompetitorGroupCollection.cs
//  Implementation of the Class CompetitorGroupCollection
//  Created on:      12-May-2008 14:20:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class CompetitorGroupCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<CompetitorGroup> items;
        private int nextGroupNumber = 0;
        #endregion Private Members

        #region Constructors
        public CompetitorGroupCollection()
        {
            items = new List<CompetitorGroup>();
        }
        #endregion Constructors

        #region Public Properties
        public int NextGroupNumber
        {
            get
            {
                nextGroupNumber++;
                return nextGroupNumber;
            }
        }

        public CompetitorGroup this[int i]
        {
            get
            {
                return items[i];
            }
        }

        #endregion Public Properties

        #region Public Methods
        public void Add(CompetitorGroup item)
        {
            items.Add(item);
        }

        public void AddRange(CompetitorGroupCollection itemCollection)
        {
            foreach (CompetitorGroup item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(CompetitorGroup item)
        {
            items.Remove(item);
        }

        public bool Contains(CompetitorGroup item)
        {
            return items.Contains(item);
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
