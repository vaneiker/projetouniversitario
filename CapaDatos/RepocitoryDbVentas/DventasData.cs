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
  public  class DventasData
        {

        #region articulo Datos
        public DataTable ListArticulos()
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_articulos_LOAD]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }
        public DataTable BuscarArticulo(string codigo, string nombre)
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_ARTICULOS_BUSCAR]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }
        public void Registrar_Articulos(articulosEntitis articulo)
            {
            try
                {
                using (dbventasEntities context = new dbventasEntities())
                    {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                        {
                        connection.Open();
                        string Qry = "SP_SET_INSERT_UPDATE_ARTICULO";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@codigo", articulo.codigo));
                        cmd.Parameters.Add(new SqlParameter("@nombre", articulo.nombre));
                        cmd.Parameters.Add(new SqlParameter("@idcategoria", articulo.idcategoria));
                        cmd.Parameters.Add(new SqlParameter("@Imag_Url", articulo.Imag_Url));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", articulo.descripcion));
                        cmd.Parameters.Add(new SqlParameter("@precioVenta", articulo.precioVenta));
                        cmd.Parameters.Add(new SqlParameter("@precioCompra", articulo.precioCompra));
                        cmd.Parameters.Add(new SqlParameter("@cantidad", articulo.cantidad));
                        cmd.Parameters.Add(new SqlParameter("@estado", articulo.estado));
                        cmd.Parameters.Add(new SqlParameter("@idProveedor", articulo.idProveedor));

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
        public void EliminarArticulo(articulosEntitis articulo)
            {
            try
                {
                using (dbventasEntities context = new dbventasEntities())
                    {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                        {
                        connection.Open();
                        string Qry = "SP_SET_DELETE_ARTICULO";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@codigo", articulo.codigo));
                        cmd.Parameters.Add(new SqlParameter("@estado", articulo.estado));
                        cmd.ExecuteNonQuery();

                        }
                    }
                }
            catch (Exception ex)
                {

                throw ex;
                }
            }

      
        #endregion

        #region categoria Datos
        public DataTable ListCategoria()
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_articulos_LOAD]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }
        public DataTable BuscarCategoria(categoriaEntitis categoria)
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_CATEGORIA_BUSCAR]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;               
                    cmd.Parameters.AddWithValue("@nombre", categoria.nombre);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }
        public void Registrar_Categoria(categoriaEntitis categoria)
            {
            try
                {
                using (dbventasEntities context = new dbventasEntities())
                    {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                        {
                        connection.Open();
                        string Qry = "[dbo].[SP_SET_CATEGORIA]";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idCat", categoria.idcategoria));
                        cmd.Parameters.Add(new SqlParameter("@nom", categoria.nombre));
                        cmd.Parameters.Add(new SqlParameter("@Desc", categoria.descripcion));  
                        cmd.ExecuteNonQuery();

                        }
                    }

                }
            catch (Exception ex)
                {

                throw ex;
                }

            }
        //public void EliminarCategoria(categoriaEntitis categoria)
        //    {
        //    try
        //        {
        //        using (dbventasEntities context = new dbventasEntities())
        //            {

        //            var connection = context.Database.Connection as SqlConnection;

        //            using (connection)
        //                {
        //                connection.Open();
        //                string Qry = "SP_SET_DELETE_ARTICULO";
        //                SqlCommand cmd = new SqlCommand(Qry, connection);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add(new SqlParameter("@codigo",categoria.idcategoria));
        //                cmd.Parameters.Add(new SqlParameter("@estado",categoria.nombre));
        //                cmd.ExecuteNonQuery();

        //                }
        //            }
        //        }
        //    catch (Exception ex)
        //        {

        //        throw ex;
        //        }            
        #endregion

        #region clientes Datos
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
        public DataTable BuscarCliente(string NombreCompleto, string cedula, string codigo, string telefono)
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
                    cmd.Parameters.AddWithValue("@CodigoCliente", NombreCompleto);
                    cmd.Parameters.AddWithValue("@Identificacion", cedula);
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

        public void EliminarClientes(ClienteEntitis cliente)
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
        #endregion

        #region cuenta_x_cobrar Datos
        public DataTable ListCuentasXcobrar()
            {

            using (dbventasEntities context = new dbventasEntities())
                {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                    {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_articulos_LOAD]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                    }
                }

            }
        #endregion

        #region cuenta_x_pagar Datos
        #endregion

        #region detalle_ingreso Datos
        #endregion

        #region detalles_ventas Datos
        #endregion

        #region ingreso Datos
        #endregion

        #region proveedor Datos
        #endregion

        #region Roles Datos
        #endregion

        #region trabajador Datos
        #endregion

        #region users Datos
        #endregion

        #region ventas Datos
        #endregion

        }
    }
