﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataService
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class ANRLDataService : IANRLDataService
    {
        #region IANRLDataService Members

        public string GetKmlString()
        {
            return "Foobar";
        }

        #endregion
    }
}