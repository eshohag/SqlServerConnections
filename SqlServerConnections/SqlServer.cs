using System;
using System.Data.SqlClient;

namespace SqlServerConnections
{
    public abstract class SqlServer
    {
        public static SqlConnection Connection(string serverName, string databaseName)
        {
            String connectionString = @"server='" + serverName + "';database='" + databaseName + "';Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public static int Connection(string serverName, string databaseName, string insertOrUpdateQuery)
        {
            String connectionString = @"server='" + serverName + "';database='" + databaseName + "';Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(insertOrUpdateQuery, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }


    }


}
