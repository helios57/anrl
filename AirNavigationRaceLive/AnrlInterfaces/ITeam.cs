﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnrlInterfaces
{
    public interface ITeam : IID
    {
        IPilot Pilot { get; }
        IPilot Navigator { get; }
        IPicture FlagPicture { get; }
        ITracker Tracker { get; }
        String Color { get; }
    }
}
