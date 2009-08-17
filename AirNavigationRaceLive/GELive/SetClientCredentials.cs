using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GELive.ANRLDataService;

namespace GELive
{
    static class SetClientCredentials
    {
        static public void SetCredentials(ANRLDataServiceClient Client)
        {
            Client.ClientCredentials.UserName.UserName = "anrl";
            Client.ClientCredentials.UserName.Password = "anrl";
            Client.ClientCredentials.Windows.ClientCredential.UserName = "anrl";
            Client.ClientCredentials.Windows.ClientCredential.Password = "anrl";
        }
    }
}
