///////////////////////////////////////////////////////////
//  GpsPointCollection.cs
//  Implementation of the Class GpsPointCollection
//  Created on:      25-Apr-2008 11:30:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class GpsPointCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<GpsPoint> items;
        #endregion Private Members

        #region Constructors
        public GpsPointCollection()
            : base()
        {
            items = new List<GpsPoint>();
        }
        #endregion Constructors

        #region Public Properties
        public GpsPoint this[int index]
        {
            get
            {
                return items[index];
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void Add(GpsPoint item)
        {
            items.Add(item);
        }

        public void AddRange(GpsPointCollection itemCollection)
        {
            foreach (GpsPoint item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(GpsPoint item)
        {
            items.Remove(item);
        }

        public bool Contains(GpsPoint item)
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