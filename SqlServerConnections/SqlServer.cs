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
            SqlConnection connection = Connection(serverName, databaseName);
            SqlCommand command = new SqlCommand(insertOrUpdateQuery, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }





        public static SqlConnection AzureSqlConnection(string azureServerName, string databaseName, string userID, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = azureServerName;
            builder.InitialCatalog = databaseName;
            builder.UserID = userID;
            builder.Password = password;
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            return connection;
        }
        public static int AzureSqlConnection(string azureServerName, string databaseName, string userID, string password, string insertOrUpdateQuery)
        {
            SqlConnection connection = AzureSqlConnection(azureServerName, databaseName, userID, password);
            SqlCommand command = new SqlCommand(insertOrUpdateQuery, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

    }
}
