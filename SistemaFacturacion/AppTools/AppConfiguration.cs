using System;

namespace SistemaFacturacion.AppTools
{
    public static class AppConfiguration
    {
        public static String GetApplicationConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["dbventasEntity"].ConnectionString;
        }

        public static String GetServerNameFromConfiguration()
        {
            String path = GetApplicationConnectionString();
            String[] pathParts = path.Split(';');
            String serverName = null;
            foreach(String s in pathParts)
            {
                if(s.Contains("data source="))
                {
                    Int32 index = s.LastIndexOf('=') + 1;
                    serverName = s.Substring(index).Trim();
                    break;
                }
            }

            return serverName;
        }

        public static String GetDatabaseNameFromConfiguration()
        {
            String path = GetApplicationConnectionString();
            String[] pathParts = path.Split(';');
            String databaseName = null;
            foreach (String s in pathParts)
            {
                if (s.Contains("initial catalog="))
                {
                    databaseName = s.Substring((s.LastIndexOf('=') + 1)).Trim();
                    break;
                }
            }

            return databaseName;
        }
    }
}
