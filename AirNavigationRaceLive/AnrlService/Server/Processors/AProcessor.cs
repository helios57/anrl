using System;
using System.Threading;
using AnrlDB;
using NetworkObjects;
namespace AnrlService.Server.Processors
{
    abstract class AProcessor:IProcessor
    {

        public AProcessor()
        {
            reloadCache();
        }
        public void reloadCache()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(start));
        }
        private void start(object o)
        {
            reloadCacheThreated();
        }
        protected abstract void reloadCacheThreated();
        public abstract Root proccess(Root r);

        public AnrlDataContext getDB()
        {
            return new AnrlDataContext();
        }
    }
}
