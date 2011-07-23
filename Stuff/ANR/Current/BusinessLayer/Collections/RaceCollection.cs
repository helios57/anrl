using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ANR.Core
{
    [Serializable]
    public class RaceCollection : AnrObject, ICollection
    {
        #region Private Members
        private List<Race> items;
        #endregion Private Members

        #region Constructors
        public RaceCollection()
            : base()
        {
            items = new List<Race>();
        }
        #endregion Constructors

        #region Public Properties
        public Race this[int index]
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

        public Race this[string raceName]
        {
            get
            {
                Race returnRace = null;
                foreach (Race race in items)
                {
                    if (race.Name == raceName)
                    {
                        returnRace = race;
                    }
                }
                return returnRace;
            }
            set
            {
                foreach (Race race in items)
                {
                    if (race.Name == raceName)
                    {
                        int index = items.IndexOf(race);
                        items[index] = value;
                        return;
                    }
                }
                throw new ArgumentOutOfRangeException("routeName", "Value does not fall within expected range.");
            }
        }
        #endregion Public Properites

        #region Public Methods
        public void Add(Race item)
        {
            items.Add(item); // ToDo: key unique?!
        }

        public void AddRange(RaceCollection itemCollection)
        {
            foreach (Race item in itemCollection)
            {
                items.Add(item); // ToDo: key unique?!
            }
        }

        public void Remove(Race item)
        {
            items.Remove(item);
        }

        public bool Contains(Race item)
        {
            return items.Contains(item);
        }

        public bool Contains(string raceName)
        {
            bool containsRaceName = false;
            foreach (Race race in items)
            {
                if (race.Name == raceName)
                {
                    containsRaceName = true;
                }
            }
            return containsRaceName;
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
