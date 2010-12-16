using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnrlInterfaces;
using System.Data.EntityClient;
using System.Data.SqlClient;

namespace AnrlService.Server
{
    class Server : MarshalByRefObject ,IServer
    {
        private AnrlServerControl ServerControl = null;
        private AnrlClient Client = null;
        private String ConnectionString;
        private TCPReciever.Server Reciever;

        public Server()
        {
            ConnectionString = generateConnectionString();
        }

        public AnrlInterfaces.IAnrlClient getAnrlClient(string username, string password)
        {
            IAnrlClient Result = null;
            if (authenticate(username,password))
            {
                if (Client == null)
                {
                   // Client = new AnrlClient(ConnectionString);
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
        private String generateConnectionString()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "AnrlDB";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/AnrlDBModel.csdl|res://*/AnrlDBModel.ssdl|res://*/AnrlDBModel.msl";

            return entityBuilder.ToString();
        }
       
        public override object InitializeLifetimeService()
        {
            return null;
        }

        internal String getConnectionString()
        {
            return ConnectionString;
        }
        internal void SetReciever(TCPReciever.Server Reciever)
        {
            this.Reciever = Reciever;
        }
    }
}
