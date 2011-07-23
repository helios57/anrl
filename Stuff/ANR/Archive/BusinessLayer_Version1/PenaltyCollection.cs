///////////////////////////////////////////////////////////
//  PenaltyCollection.cs
//  Implementation of the Class PenaltyCollection
//  Created on:      25-Apr-2008 11:40:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class PenaltyCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Penalty> items;
        #endregion Private Members

        #region Constructors
        public PenaltyCollection()
            : base()
        {
        }
        #endregion Constructors

        #region Public Properties
        public Penalty this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }
        #endregion Public Properites

        #region Public Methods
        public void Add(Penalty item)
        {
            items.Add(item);
        }

        public void AddRange(PenaltyCollection itemCollection)
        {
            foreach (Penalty item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(Penalty item)
        {
            items.Remove(item);
        }

        public bool Contains(Penalty item)
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
        #endregion ICollection Members

        #region IEnumerable Members
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion IEnumerable Members
    }
}