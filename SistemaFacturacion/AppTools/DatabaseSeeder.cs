using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;

namespace SistemaFacturacion.AppTools
{
    public static class DatabaseSeeder
    {
        public static string GetProjectPath()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SqlScript\DatabaseScript.sql");
            return path;
        }

        public static bool IsDatabaseExists()
        {
            string serverName = AppConfiguration.GetServerNameFromConfiguration();
            string databaseName = AppConfiguration.GetDatabaseNameFromConfiguration();
            string connectionString = "data source=" + serverName + ";initial catalog=master;integrated security=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Unable to Connect to Server: " + ex.Message);
                    Console.WriteLine("Server Name: " + serverName);
                    return false;
                }

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from master.dbo.sysdatabases where name = \'" + databaseName + "\'";

                if (!command.ExecuteReader().HasRows)
                {
                    return false;
                }



            }

            return true;
        }

        internal static void CreateDatabase()
        {
            List<StringBuilder> views = new List<StringBuilder>();
            List<StringBuilder> procs = new List<StringBuilder>();
            try
            {
                using (StreamReader reader = new StreamReader(GetProjectPath()))
                {
                    StringBuilder script = new StringBuilder();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if(line.StartsWith("CREATE VIEW", StringComparison.CurrentCultureIgnoreCase))
                        {
                            StringBuilder v = new StringBuilder();
                            v.Append(line);
                            string subLine = "";
                            while (!subLine.Equals("GO", StringComparison.CurrentCultureIgnoreCase))
                                v.Append(reader.ReadLine());

                            views.Add(v);
                            
                        }else if(line.StartsWith("CREATE PROC", StringComparison.CurrentCultureIgnoreCase))
                        {
                            StringBuilder p = new StringBuilder();
                            p.Append(line);
                            string subLine = "";
                            while (!subLine.Equals("GO", StringComparison.CurrentCultureIgnoreCase))
                                p.Append(reader.ReadLine());
                        }else
                        {
                            if (line.Equals("GO", StringComparison.CurrentCultureIgnoreCase))
                                continue;
                            else
                            {
                                script.Append(line);
                            }
                        }
                        
                        
                    }

                    string serverName = AppConfiguration.GetServerNameFromConfiguration();
                    string databaseName = AppConfiguration.GetDatabaseNameFromConfiguration();
                    string connectionString = "data source=" + serverName + ";initial catalog=master;integrated security=True;";

                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("create database " + databaseName, connection);
                    command.CommandType = System.Data.CommandType.Text;
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.ChangeDatabase(databaseName);
                    Console.WriteLine("Database Created");
                        command = new SqlCommand(script.ToString(), connection);
                        command.CommandType = System.Data.CommandType.Text;
                        command.ExecuteNonQuery();

                    Console.WriteLine("Tables Created");

                    foreach(StringBuilder sb in views)
                    {
                        command = new SqlCommand(sb.ToString(), connection);
                        command.ExecuteNonQuery();
                    }

                    foreach(StringBuilder sb in procs)
                    {
                        command = new SqlCommand(sb.ToString(), connection);
                        command.ExecuteNonQuery();
                    }
                
                    connection.Close();

                }
            }catch(FileNotFoundException ex)
            {
                throw new FileNotFoundException("Script Not found");
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}

