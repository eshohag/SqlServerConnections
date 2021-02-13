# Sql Connections Information [![Build status](https://ci.appveyor.com/api/projects/status/67ubhtmijuhyhq6q?svg=true)](https://ci.appveyor.com/project/eshohag/SqlServerConnections) [![NuGet Badge](https://buildstats.info/nuget/SqlConnection)](https://www.nuget.org/packages/SqlConnection)

### Namespace 
using SqlConnections

### Code Syntax-
        using SqlConnections;
        using System;
        using System.Data.SqlClient;

        namespace ConsoleApp
        {
            class Program
            {
                static void Main(string[] args)
                {
                    //***************SQL Database Connections******************
                    int rowAffected = SqlServer.Connection("YourLocalServerName", "Database", "Your Query here...");
                    Console.WriteLine("Your Row Affect Message-" + rowAffected);

                    SqlConnection connection = SqlServer.Connection("YourLocalServerName", "Database");
                    string query = "Your Query here...";
                    SqlCommand aCommand = new SqlCommand(query, connection);
                    connection.Open();
                    int rowAffecte = aCommand.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Your Row Affect Message-" + rowAffecte);


                    //***************Azure Connections******************
                    int rowAffect = SqlServer.AzureSqlConnection(
                                "YourServerName.database.windows.net", "Database", "UserID", "Password", "Your Query here...");
                    Console.WriteLine("Your Row Affect Message-" + rowAffect);

                    SqlConnection _connection = SqlServer.AzureSqlConnection("YourServerName.database.windows.net", "Database", "UserID", "Password");
                    SqlCommand command = new SqlCommand("Your Query Here...", _connection);
                    connection.Open();
                    int rowAzureAffect = command.ExecuteNonQuery();
                    Console.WriteLine("Your Row Affect Message-" + rowAzureAffect);

                    Console.ReadKey();
                }
            }
        }
