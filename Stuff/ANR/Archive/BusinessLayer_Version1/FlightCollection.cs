﻿///////////////////////////////////////////////////////////
//  FlightCollection.cs
//  Implementation of the Class FlightCollection
//  Created on:      27-Aug-2008 20:00:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PFA.ANR.BusinessLayer
{
    [Serializable]
    public class FlightCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Flight> items;
        #endregion Private Members

        #region Constructors
        public FlightCollection()
            : base()
        {
        }
        #endregion Constructors

        #region Public Properties
        #endregion Public Properites

        #region Public Methods
        public void Add(Flight item)
        {
            items.Add(item);
        }

        public void AddRange(FlightCollection itemCollection)
        {
            foreach (Flight item in itemCollection)
            {
                items.Add(item);
            }
        }

        public void Remove(Flight item)
        {
            items.Remove(item);
        }

        public bool Contains(Flight item)
        {
            return items.Contains(item);
        }

        public FlightCollection GetFlightsByCompetitorId(Guid competitorId)
        {
            FlightCollection flightsForCurrentCompetitor = new FlightCollection();
            foreach (Flight flight in items)
            {
                if (flight.CompetitorId == competitorId)
                {
                    flightsForCurrentCompetitor.Add(flight);
                }
            }
            return flightsForCurrentCompetitor;
        }

        public FlightCollection GetFlightsByGroupId(Guid groupId)
        {
            FlightCollection flightsForCurrentGroup = new FlightCollection();
            foreach (Flight flight in items)
            {
                if (flight.CompetitorGroupId == groupId)
                {
                    flightsForCurrentGroup.Add(flight);
                }
            }
            return flightsForCurrentGroup;
        }

        public Flight GetFlightByGroupAndCompetitorId(Guid groupId, Guid competitorId)
        {
            foreach (Flight flight in items)
            {
                if (flight.CompetitorGroupId == groupId)
                {
                    if (flight.CompetitorId == competitorId)
                    {
                        return flight;
                    }
                }
            }
            return null;
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