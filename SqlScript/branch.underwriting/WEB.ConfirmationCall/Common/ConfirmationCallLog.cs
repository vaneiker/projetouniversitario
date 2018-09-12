using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEB.ConfirmationCall.Common
{
    public class ConfirmationCallLog
    {
        /// <summary>
        /// Log Metodo Creado por Jose Encarnacion para guardar log confimationcall
        /// </summary>
        /// <param name="Metodo">Metodo que genera el log</param>
        /// <param name="Descripcion">Descripcion de la exepcion</param>
        /// <param name="Paramter">Parametros utilizados</param>
        /// <param name="UsrId">Usuario que utiliza el metodo</param>
        /// <param name="HostName">Pc desde donde se ejecuta a la app</param>
        public static void Log(string Metodo, string Descripcion, string Paramter, int UsrId, string HostName)
        {
            try
            {

                using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionLog"].ConnectionString))
                {
                    if (oConnection.State != ConnectionState.Open)
                    {
                        oConnection.Open();
                    }

                    using (SqlCommand oCommand = new SqlCommand())
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                        oCommand.Connection = oConnection;
                        oCommand.CommandText = "reportes.SP_SET_CONFIMATIONCALLLOG";

                        oCommand.Parameters.Add(new SqlParameter("@Metodo", Metodo));
                        oCommand.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                        oCommand.Parameters.Add(new SqlParameter("@Paramter", Paramter));
                        oCommand.Parameters.Add(new SqlParameter("@UsrId", UsrId));
                        oCommand.Parameters.Add(new SqlParameter("@HostName", HostName));

                        oCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    
    }
}