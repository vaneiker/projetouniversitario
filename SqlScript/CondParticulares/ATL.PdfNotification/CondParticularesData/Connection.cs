using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
  

namespace ATL.PdfNotification.CondParticularesData
{
   public class Connection
    {
       
        
   public static SqlConnection ObtenerConexion()
           {
           try
           {
               SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GlobalConnectionString"].ConnectionString);
                conn.Open();
                return conn;

           }
           catch (Exception ex)
           {
               throw new ArgumentException("Error al conectar", ex);
           }
           
          }

   public static SqlConnection CerrarConexion()
   {
       try
       {
           SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GlobalConnectionString"].ConnectionString);
           conn.Close();
           return conn;

       }
       catch (Exception ex)
       {
           throw new ArgumentException("Error al conectar", ex);
       }

   }

    }
}
