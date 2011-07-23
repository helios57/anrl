///////////////////////////////////////////////////////////
//  ForbiddenZoneCollection.cs
//  Implementation of the Class ForbiddenZoneCollection
//  Created on:      29-Aug-2008 20:30:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class ForbiddenZoneCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<ForbiddenZone> items;
        #endregion Private Members

        #region Constructors
        public ForbiddenZoneCollection()
            : base()
        {
            items = new List<ForbiddenZone>();
        }
        #endregion Constructors

        #region Public Properties
        public ForbiddenZone this[int index]
        {
            get
            {
                return items[index];
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void Add(ForbiddenZone item)
        {
            items.Add(item);
        }

        public void AddRange(ForbiddenZoneCollection itemCollection)
        {
            foreach (ForbiddenZone item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(ForbiddenZone item)
        {
            items.Remove(item);
        }

        public bool Contains(ForbiddenZone item)
        {
            return items.Contains(item);
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
