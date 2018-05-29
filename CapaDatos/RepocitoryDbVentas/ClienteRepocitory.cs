using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad.DbVentas;

namespace CapaDatos.RepocitoryDbVentas
    {
   public class ClienteRepocitory
        {
        
        public DataTable ListaCliente()
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_CLIENTES_LOAD]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }      
        public DataTable BuscarCliente(string NombreCompleto,string cedula, string codigo,string telefono)
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                 using (connection)
                    {
                    connection.Open();
                    string Qry = "SP_GET_CLIENTES_BUSCAR";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoCliente"  , NombreCompleto);
                    cmd.Parameters.AddWithValue("@Identificacion" , cedula);
                    cmd.Parameters.AddWithValue("@Nombre_Completo", codigo);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }
        public void Registrar_Clientes(ClienteEntitis cliente)
            {

                try
                {
                using (dbventasEntities context = new dbventasEntities())
                    {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                        {
                        connection.Open();
                        string Qry = "[dbo].[SP_SET_CLIENTE_INSERT_UPDATE]";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idcliente", cliente.idcliente));
                        cmd.Parameters.Add(new SqlParameter("@nombre", cliente.nombre));
                        cmd.Parameters.Add(new SqlParameter("@apellidos", cliente.apellidos));
                        cmd.Parameters.Add(new SqlParameter("@sexo", cliente.sexo));
                        cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", cliente.fecha_nacimiento));
                        cmd.Parameters.Add(new SqlParameter("@tipo_documento", cliente.tipo_documento));
                        cmd.Parameters.Add(new SqlParameter("@num_documento", cliente.num_documento));
                        cmd.Parameters.Add(new SqlParameter("@direccion", cliente.direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono", cliente.telefono));
                        cmd.Parameters.Add(new SqlParameter("@email", cliente.email));
                        cmd.Parameters.Add(new SqlParameter("@status", 1));
                        cmd.Parameters.Add(new SqlParameter("@FechaAdiciona", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@FechaModifica", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@UsuarioAdiciona", 3348));
                        //cmd.Parameters.Add(new SqlParameter("@UsuarioModifica", null));
                        cmd.ExecuteNonQuery();

                        }
                    }

                }
                catch (Exception ex)
                {

                throw ex;
                } 

            }

        public void EliminarCliente(ClienteEntitis cliente)
            {
            try
                {
                using (dbventasEntities context = new dbventasEntities())
                    {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                        {
                        connection.Open();
                        string Qry = "[dbo].[SP_SET_CLIENTE_DELETE]";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idcliente", cliente.idcliente));
                        //cmd.Parameters.Add(new SqlParameter("@status", 0));
                      //cmd.Parameters.Add(new SqlParameter("@FechaModifica", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@UsuarioModifica", 3348));
                        cmd.ExecuteNonQuery();

                        }
                    }

                }
            catch (Exception ex)
                {

                throw ex;
                }
            }
        }
    }
