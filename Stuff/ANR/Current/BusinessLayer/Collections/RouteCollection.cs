///////////////////////////////////////////////////////////
//  RouteCollection.cs
//  Implementation of the Class RouteCollection
//  Created on:      31-Aug-2008 17:00:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class RouteCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Route> items;
        #endregion Private Members

        #region Constructors
        public RouteCollection()
            : base()
        {
            items = new List<Route>();
        }
        #endregion Constructors

        #region Public Properties
        public Route this[int index]
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

        public Route this[string routeName]
        {
            get
            {
                Route returnRoute = null;
                foreach (Route route in items)
                {
                    if (route.RouteName == routeName)
                    {
                        returnRoute = route;
                    }
                }
                return returnRoute;
            }
            set
            {
                foreach (Route route in items)
                {
                    if (route.RouteName == routeName)
                    {
                        int index = items.IndexOf(route);
                        items[index] = value;
                        return;
                    }
                }
                throw new ArgumentOutOfRangeException("routeName", "Value does not fall within expected range.");
            }
        }
        #endregion Public Properites

        #region Public Methods
        public void Add(Route item)
        {
            items.Add(item); // ToDo: key unique?!
        }

        public void AddRange(RouteCollection itemCollection)
        {
            foreach (Route item in itemCollection)
            {
                items.Add(item); // ToDo: key unique?!
            }
        }

        public void Remove(Route item)
        {
            items.Remove(item);
        }

        public bool Contains(Route item)
        {
            return items.Contains(item);
        }

        public bool Contains(string routeName)
        {
            bool containsRouteName = false;
            foreach (Route route in items)
            {
                if (route.RouteName == routeName)
                {
                    containsRouteName = true;
                }
            }
            return containsRouteName;
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