using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class MapCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Map> items;
        #endregion Private Members

        #region Constructors
        public MapCollection()
            : base()
        {
            items = new List<Map>();
        }
        #endregion Constructors

        #region Public Properties
        public Map this[int index]
        {
            get
            {
                return items[index];
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void Add(Map item)
        {
            items.Add(item);
        }

        public void AddRange(MapCollection itemCollection)
        {
            foreach (Map item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(Map item)
        {
            items.Remove(item);
        }

        public bool Contains(Map item)
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
