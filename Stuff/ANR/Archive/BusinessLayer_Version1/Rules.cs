///////////////////////////////////////////////////////////
//  Rules.cs
//  Implementation of the Class Rules
//  Created on:      29-Apr-2008 20:00:00
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFA.ANR.BusinessLayer
{
    public static class Rules
    {
        #region Enums
        public enum RestrictedAreaDuration
        {
            ZeroToTwo,
            ThreeToFour,
            FiveToSix,
            SevenToEight,
            NineToTen,
            MoreOrEqEleven
        }
        #endregion Enums
    }
}
