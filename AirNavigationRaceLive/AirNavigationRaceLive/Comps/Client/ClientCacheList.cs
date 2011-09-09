using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Comps.Client
{
    class ClientCacheList<T>
    {
        private ClientCacheLoader<T> loader;
        public ClientCacheList(ClientCacheLoader<T> loader)
        {
            this.loader = loader;
        }
        private Dictionary<int, ClientCacheEntry<T>> cache = new Dictionary<int, ClientCacheEntry<T>>();
        public EventHandler<ClientCacheDirtyEvent> DirtyChanged;
        private bool _Dirty = true;
        public bool Dirty
        {
            get
            {
                return _Dirty;
            }
        }

        public int add(T entry)
        {
            lock (this)
            {
                ClientCacheEntry<T> e;
                e = new ClientCacheEntry<T>(entry);
                e.DirtyChanged += new EventHandler<ClientCacheDirtyEvent>(dirtyChanged);
                e.Dirty = true;
                int ID = loader.Add(entry);
                dynamic d = entry;
                d.ID = ID;
                cache.Remove(ID);
                cache.Add(ID, e);
                return ID;
            }
        }
        public void delete(int ID)
        {
            lock (this)
            {
                loader.Delete(ID);
                cache.Remove(ID);
            }
        }

        public void setDirty(int ID, bool dirty)
        {
            lock (this)
            {
                if (cache.ContainsKey(ID))
                {
                    cache[ID].Dirty = dirty;
                }
            }
        }

        public T get(int ID)
        {
            lock (this)
            {
                if (cache.ContainsKey(ID))
                {
                    return cache[ID].getEntry();
                }
                else
                {
                     T result = loader.Load(ID);
                     if (result != null)
                     {                         
                         cache.Add(ID, new ClientCacheEntry<T>(result));
                     }
                     return result;
                }
            }
        }

        public List<T> getAll()
        {
            lock (this)
            {
                List<T> result = new List<T>();
                foreach (ClientCacheEntry<T> entry in cache.Values)
                {
                    result.Add(entry.getEntry());
                }
                return result;
            }
        }

        public void dirtyChanged(object o, ClientCacheDirtyEvent e)
        {
            lock (this)
            {
                _Dirty = cache.Count(p => p.Value.Dirty) != 0;
            }
        }
        public void update(bool partial)
        {
            if (partial && loader.IsUnmodifiable())
            {
                List<int> deleted = new List<int>();
                List<T> list = loader.LoadAll(cache.Keys.ToList(), deleted);
                lock (this)
                {
                    foreach (int i in deleted)
                    {
                        cache.Remove(i);
                    }
                    foreach (T t in list)
                    {
                        ClientCacheEntry<T> e;
                        e = new ClientCacheEntry<T>(t);
                        dynamic d = t;
                        cache.Add(d.ID, e);
                    }
                }
            }
            else
            {
                List<T> list = loader.LoadAll(0);
                cache.Clear();
                lock (this)
                {
                    foreach (T t in list)
                    {
                        ClientCacheEntry<T> e;
                        e = new ClientCacheEntry<T>(t);
                        dynamic d = t;
                        cache.Add(d.ID, e);
                    }
                }
            }
        }
    }
}
