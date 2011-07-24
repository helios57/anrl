using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface IAnrlClient
    {
        List<ITracker> getTrackers();
        List<IPilot> getPilots();
        List<IPicture> getPictures(Boolean flag);
        List<ITeam> getTeams();
        List<IMap> getMaps();
        List<IData> getData(List<ITracker> trackers,DateTime from, DateTime to);
        Boolean addName(ITracker tracker);
        long addPilot(IPilot pilot);
        long addTeam(ITeam team);
        long addPicture(IPicture picture, Boolean isFlag);
        long addMap(IMap map);
        Boolean removePilot(long id);
        Boolean removeTeam(long id);
        Boolean removePicture(long id);
        Boolean removeMap(long id);
    }
}
