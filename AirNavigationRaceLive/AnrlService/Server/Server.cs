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
        //original String ConnectionString = "metadata=res://*/AnrlDBModel.csdl|res://*/AnrlDBModel.ssdl|res://*/AnrlDBModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=HELIOS6X-PC;Initial Catalog=AnrlDB;Integrated Security=True;MultipleActiveResultSets=True&quot;\" providerName=\"System.Data.EntityClient";
        String ConnectionString = "metadata=res://*/AnrlDBModel.csdl|res://*/AnrlDBModel.ssdl|res://*/AnrlDBModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=localhost;Initial Catalog=AnrlDB;Integrated Security=True;MultipleActiveResultSets=True&quot;\" providerName=\"System.Data.EntityClient";

        public AnrlInterfaces.IAnrlClient getAnrlClient(string username, string password)
        {
            IAnrlClient Result = null;
            if (authenticate(username,password))
            {
                if (Client == null)
                {
                    Client = new AnrlClient(ConnectionString);
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
