using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;

namespace AnrlService.Server
{
    class Server : MarshalByRefObject ,IServer
    {
        AnrlServerControl ServerControl = null;
        AnrlClient Client = null;

        public AnrlInterfaces.IAnrlClient getAnrlClient(string username, string password)
        {
            IAnrlClient Result = null;
            if (authenticate(username,password))
            {
                if (Client == null)
                {
                    Client = new AnrlClient();
                }
                Result = Client;
            }
            return Result;
        }

        public AnrlInterfaces.IAnrlServerControl getAnrlServerControl(string username, string password)
        {
            IAnrlServerControl Result = null;
            if (authenticate(username, password))
            {
                if (ServerControl == null)
                {
                    ServerControl = new AnrlServerControl();
                }
                Result = ServerControl;
            }
            return Result;
        }

        private Boolean authenticate(String username, String password)
        {
            return true;
        }
    }
}
