using System;
namespace AnrlService.Server.Processors
{
    interface IProcessor
    {
        NetworkObjects.Root proccess(NetworkObjects.Root request);
        void reloadCache();
    }
}
