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



        public static SqlConnection AzureSqlConnection(string azureServerName, string databaseName, string userID, string password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = " tcp:'" + azureServerName + "',1433";
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



      
# Test to run this package on Console app -

        using SqlServerConnections;
        using System;
        using System.Data.SqlClient;
        namespace Test
        {
            class Program
            {
                static void Main(string[] args)
                {
                    //First Methods, First Way to create connection & query after excute on a single methods. 
                    int rowAffected = SqlServer.Connection("DESKTOP-TKNUD75", "TestDB", "INSERT INTO Name Values('Steve Jobs')");
                    
                    Console.WriteLine("Numbe of Row Affecte is " + rowAffected);


                    //Second Methods, second Way to create only connection
                    SqlConnection connection = SqlServer.Connection("DESKTOP-TKNUD75", "TestDB");
                    
                    string query = "INSERT INTO Name Values('Steve Jobs')";
                    SqlCommand aCommand = new SqlCommand(query, connection);
                    connection.Open();
                    int rowAffecte = aCommand.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Numbe of Row Affecte is " + rowAffecte);


                    Console.ReadKey();
                }
            }
        }
