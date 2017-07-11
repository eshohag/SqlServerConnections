# SqlConnections


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
                
                public static SqlConnection AzureSqlConnection(
                string azureServerName, string databaseName, string userID, string password)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = " tcp:'" + azureServerName + "',1433";
                    builder.InitialCatalog = databaseName;
                    builder.UserID = userID;
                    builder.Password = password;
                    SqlConnection connection = new SqlConnection(builder.ConnectionString);
                    return connection;
                }
                public static int AzureSqlConnection(
                string azureServerName, string databaseName, string userID, string password, string insertOrUpdateQuery)
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



      
# Test to run this package on Console app -

using SqlServerConnections;
using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int rowAffected = SqlServer.Connection("YourLocalServerName", "Database", "Your Query here...");
            Console.WriteLine("Your Row Affect Message-" + rowAffected);



            SqlConnection connection = SqlServer.Connection("YourLocalServerName", "Database");
            string query = "Your Query here...";
            SqlCommand aCommand = new SqlCommand(query, connection);
            connection.Open();
            int rowAffecte = aCommand.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("Your Row Affect Message-" + rowAffecte);




            int rowAffect = SqlServer.AzureSqlConnection(
                                        "YourServerName.database.windows.net", "Database", "UserID", "Password", "Your Query here...");
            Console.WriteLine("Your Row Affect Message-" + rowAffect);



            SqlConnection _connection = SqlServer.AzureSqlConnection(
                                         "YourServerName.database.windows.net", "Database", "UserID", "Password");
            SqlCommand command = new SqlCommand("Your Query Here...", _connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            Console.WriteLine("Your Row Affect Message-" + rowAffect);




            Console.ReadKey();
        }
    }
}
