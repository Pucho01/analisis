using System;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public abstract class ConnectionToMySql
    {
        private readonly string connectionString;
        public ConnectionToMySql()
        {
            connectionString = "server = localhost; port = 3306; uid = root; pwd = ''; database = camaleon3;";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
