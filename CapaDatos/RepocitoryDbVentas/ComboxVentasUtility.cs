using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;
namespace CapaDatos.RepocitoryDbVentas
    {
    public class ComboxVentasUtility
        {
        private object cmd;

        public List<ClienteEntitis> GetAllCliente()
            {

            List<ClienteEntitis> Cliente = new List<ClienteEntitis>();
            using (dbventasEntity context = new dbventasEntity())
                {
                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "SP_GET_COMBOBOX_CLIENTE";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        {
                        ClienteEntitis item = new ClienteEntitis()
                            {
                            idcliente = Convert.ToInt32(reader["idcliente"]),
                            NombreCompleto = Convert.ToString(reader["NombreCompleto"])
                            };
                        Cliente.Add(item);

                        }

                       return Cliente;


                    }
                }
            }



        //public List<ClienteEntitis> GetAllClientes()
        //    {
        //    List<ClienteEntitis> npuesto = new List<ClienteEntitis>();
        //    SqlConnection con = new SqlConnection();
        //    //con.ConnectionString = conexion.con;
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "spllenar_puesto";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //        {
        //        ClienteEntitis Cliente = new ClienteEntitis();
        //        Cliente.idcliente = dr.GetInt32(0);
        //        Cliente.NombreCompleto = dr.GetString(1);


        //        npuesto.Add(Cliente);
        //        }
        //    return npuesto;
        //    }

        }
    }