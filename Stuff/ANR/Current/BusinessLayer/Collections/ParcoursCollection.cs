///////////////////////////////////////////////////////////
//  ParcoursCollection.cs
//  Implementation of the Class ParcoursCollection
//  Created on:      31-Aug-2008 22:00:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class ParcoursCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Parcours> items;
        #endregion Private Members

        #region Constructors
        public ParcoursCollection()
            : base()
        {
            items = new List<Parcours>();
        }
        #endregion Constructors

        #region Public Properties
        public Parcours this[int index]
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
        public void Add(Parcours item)
        {
            items.Add(item);
        }

        public void AddRange(ParcoursCollection itemCollection)
        {
            foreach (Parcours item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(Parcours item)
        {
            items.Remove(item);
        }

        public bool Contains(Parcours item)
        {
            return items.Contains(item);
        }

        public bool Contains(string parcoursName)
        {
            foreach(Parcours p in items)
            {
                if (p.ParcoursName == parcoursName)
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
        #endregion ICollection Members

        #region IEnumerable Members
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion IEnumerable Members
    }
}