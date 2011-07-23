///////////////////////////////////////////////////////////
//  TrackPointCollection.cs
//  Implementation of the Class TrackPointCollection
//  Created on:      25-Apr-2008 11:30:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class TrackPointCollection : GpsPointCollection
    {
        #region Constructors
        public TrackPointCollection()
            : base()
        {
        }
        #endregion Constructors

        #region Public Properties
        public new TrackPoint this[int index]
        {
            get
            {
                return (TrackPoint)base[index];
            }
        }
        #endregion Public Properties

        #region Public Methods
        public void Add(TrackPoint item)
        {
            base.Add(item);
        }

        public void AddRange(TrackPointCollection itemCollection)
        {
            foreach (TrackPoint item in itemCollection)
            {
                base.Add(item);
            }
        }

        public void Remove(TrackPoint item)
        {
            base.Remove(item);
        }

        public bool Contains(TrackPoint item)
        {
            return base.Contains(item);
        }
        #endregion Public Methods
    }
}