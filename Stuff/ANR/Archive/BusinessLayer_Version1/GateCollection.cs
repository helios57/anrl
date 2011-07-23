///////////////////////////////////////////////////////////
//  GateCollection.cs
//  Implementation of the Class GateCollection
//  Created on:      29-Aug-2008 20:30:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class GateCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Gate> items;
        #endregion Private Members

        #region Constructors
        public GateCollection()
            : base()
        {
            items = new List<Gate>();
        }
        #endregion Constructors

        #region Public Properties
        public Gate this[int index]
        {
            get
            {
                return items[index];
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void Add(Gate item)
        {
            items.Add(item);
        }

        public void AddRange(GateCollection itemCollection)
        {
            foreach (Gate item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(Gate item)
        {
            items.Remove(item);
        }

        public bool Contains(Gate item)
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
