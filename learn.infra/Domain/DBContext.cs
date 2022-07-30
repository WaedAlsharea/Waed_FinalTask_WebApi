using learn.core.Domain;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace learn.infra.Domain
{
    public class DBContext : IDBContext
    {
        private DbConnection connection;
        private IConfiguration configuration;


        /*when execute project we will inialize value by constructor */
        public DBContext(IConfiguration configuration)
        {

            this.configuration = configuration; // Appsetting.Json value

        }

        public DbConnection dbConnection
        {
            get
            {
                if (connection == null)
                {

                    connection = new OracleConnection(configuration["ConnectionStrings:DefaultConnection"]);

                    connection.Open();
                }
                else if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                return connection;
            }
        }
    }

}
