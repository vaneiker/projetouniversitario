using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.RepocitoryDbVentas;

using CapaEntidad.DbVentas;

namespace CapaDatos.RepocitoryDbVentas
{
    public class DventasData
    {

        #region articulo Datos
        public DataTable ListArticulos()
        {

            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "SP_GET_ARTICULO_LOAD";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }

        public DataTable ListarticulosX_Codigo(string codigo, int copia)
        {
            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "[dbo].[LIST_ARTICULOS_X_CODIGO]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    cmd.Parameters.AddWithValue("@COPIAS", copia);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public DataTable BuscarArticulo(string codigo, string nombre)
        {

            using (dbventasEntity context = new dbventasEntity())
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
                using (dbventasEntity context = new dbventasEntity())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "SP_SET_INSERT_UPDATE_ARTICULO";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idarticulo", articulo.@idarticulo));
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
                using (dbventasEntity context = new dbventasEntity())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "[DBO].[SP_SET_DELETE_ARTICULO]";
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
        public articulosEntitis BuscarArticuloXCodigo(string codigo)
        {
            articulosEntitis entity = null;
            try
            {
                using (dbventasEntity db = new dbventasEntity())
                {
                    var connection = db.Database.Connection as SqlConnection;
                    using (connection)
                    {
                        connection.Open();
                        string command = "[DBO].[SP_GET_ARTICULOS_BUSCAR_X_CODIGO]";
                        SqlCommand sqlCommand = new SqlCommand(command);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@codigo", codigo.ToUpper());
                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            entity = new articulosEntitis();
                            foreach (DataRow row in dt.Rows)
                            {
                                entity.idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                                entity.codigo = row["codigo"].ToString();
                                entity.nombre = row["nombre"].ToString();
                                entity.idcategoria = Convert.ToInt32(row["idcategoria"].ToString());
                                entity.Imag_Url = row["Imag_Url"].ToString();
                                entity.descripcion = row["descripcion"].ToString();
                                entity.precioVenta = Convert.ToDecimal(row["precioVenta"].ToString());
                                entity.precioCompra = Convert.ToDecimal(row["precioCompra"].ToString());
                            }
                            return entity;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return entity;
            }
            return entity;
        }


        #endregion

        #region categoria Datos
        public DataTable ListCategoria()
        {

            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "SP_GET_Categoria_LOAD";
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

            using (dbventasEntity context = new dbventasEntity())
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
        public int Registrar_Categoria(categoriaEntitis categoria)
        {
            try
            {
                using (dbventasEntity context = new dbventasEntity())
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

                        return 1;

                    }
                }

            }
            catch (Exception)
            {
                return 0;

            }

        }
        //public void EliminarCategoria(categoriaEntitis categoria)
        //    {
        //    try
        //        {
        //        using (dbventasEntity context = new dbventasEntity())
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

            using (dbventasEntity context = new dbventasEntity())
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

            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "SP_GET_CLIENTES_BUSCAR";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodigoCliente", codigo);
                    cmd.Parameters.AddWithValue("@Identificacion", cedula);
                    cmd.Parameters.AddWithValue("@Nombre_Completo", NombreCompleto);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public int Registrar_Clientes(ClienteEntitis cliente)
        {
          
            try
            {
                using (dbventasEntity context = new dbventasEntity())
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
                        cmd.Parameters.Add(new SqlParameter("@UsuarioAdiciona", cliente.UsuarioAdiciona));
                        cmd.Parameters.Add(new SqlParameter("@UsuarioModifica", cliente.UsuarioModifica));
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                }

            }
            catch (Exception ex)
            {
                return 0; 
                throw ex;
            }

        }

        public void EliminarClientes(ClienteEntitis cliente)
        {
            try
            {
                using (dbventasEntity context = new dbventasEntity())
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
                        cmd.Parameters.Add(new SqlParameter("@UsuarioModifica", cliente.UsuarioModifica));
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
            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "sp_get_clientes_deudores";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }

        public DataTable BuscarClientesDeuda(cuentas_x_cobrarEntitis cxc)
        {

            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "[dbo].[sp_get_searche_client_pagos]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@num_documento", cxc.num_documento);
                    cmd.Parameters.AddWithValue("@codigoCliente", cxc.codigoCliente);
                    cmd.Parameters.AddWithValue("@NombComp", cxc.NombComp);

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
        public int IngresdoDeDatos(ArticulosCompuestoEntity ingreso)
        {

            int Estado;
            try
            {
                using (dbventasEntity context = new dbventasEntity())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "SP_SET_INSERTAR_ARTICULOS_INGRESO";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@nombre", ingreso.nombre));
                        cmd.Parameters.Add(new SqlParameter("@idcategoria", ingreso.idcategoria));
                        cmd.Parameters.Add(new SqlParameter("@Codigo", ingreso.Codigo));
                        cmd.Parameters.Add(new SqlParameter("@Imag_Url", ingreso.Imag_Url));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", ingreso.descripcion));
                        cmd.Parameters.Add(new SqlParameter("@precioVenta", ingreso.precioVenta));
                        cmd.Parameters.Add(new SqlParameter("@precioCompra", ingreso.precioCompra));
                        cmd.Parameters.Add(new SqlParameter("@cantidad", ingreso.cantidad));
                        cmd.Parameters.Add(new SqlParameter("@estado", ingreso.estado));
                        cmd.Parameters.Add(new SqlParameter("@idProveedor", ingreso.idProveedor));
                        cmd.Parameters.Add(new SqlParameter("@idingreso", ingreso.idingreso));
                        cmd.Parameters.Add(new SqlParameter("@fecha", ingreso.fecha));
                        cmd.Parameters.Add(new SqlParameter("@tipo_comprobante", ingreso.tipo_comprobante));
                        cmd.Parameters.Add(new SqlParameter("@igv", ingreso.igv));
                        cmd.Parameters.Add(new SqlParameter("@UsuarioAdiciona", ingreso.UsuarioAdiciona));
                        cmd.Parameters.Add(new SqlParameter("@stock_inicial", ingreso.stock_inicial));
                        cmd.Parameters.Add(new SqlParameter("@fecha_produccion", ingreso.fecha_produccion));
                        cmd.Parameters.Add(new SqlParameter("@fecha_vencimiento", ingreso.fecha_vencimiento));

                        cmd.ExecuteNonQuery();

                        return Estado = 1;
                    }
                }

            }
            catch (Exception ex)
            {

                return Estado = 0;
                throw ex;
            }

        }

        #endregion

        #region proveedor Datos
        public DataTable Listproveedor()
        {

            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "[dbo].[SP_GET_PROVEEDOR_LOAD]";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public DataTable Buscarproveedor(string doc, string tel, string nom)
        {

            using (dbventasEntity context = new dbventasEntity())
            {

                var connection = context.Database.Connection as SqlConnection;

                using (connection)
                {
                    connection.Open();
                    string Qry = "SP_GET_BUSCAR_PROVEEDOR";
                    SqlCommand cmd = new SqlCommand(Qry, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@documento", doc);
                    cmd.Parameters.AddWithValue("@telefono", tel);
                    cmd.Parameters.AddWithValue("@nombre", nom);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public int Registrar_Proveedor(ProveedorEntity proveedor)
        {
            try
            {
                using (dbventasEntity context = new dbventasEntity())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "SP_SET_UDATE_INSERT_PROVEEDOR";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@idproveedor", proveedor.idproveedor));
                        cmd.Parameters.Add(new SqlParameter("@razon_social", proveedor.razon_social));
                        cmd.Parameters.Add(new SqlParameter("@NombreProveedor", proveedor.NombreProveedor));
                        cmd.Parameters.Add(new SqlParameter("@tipo_documento", proveedor.tipo_documento));
                        cmd.Parameters.Add(new SqlParameter("@num_documento", proveedor.num_documento));
                        cmd.Parameters.Add(new SqlParameter("@direccion", proveedor.direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono", proveedor.telefono));
                        cmd.Parameters.Add(new SqlParameter("@email", proveedor.email));
                        cmd.Parameters.Add(new SqlParameter("@url", proveedor.url));
                        cmd.Parameters.Add(new SqlParameter("@statu", proveedor.statu));
                        cmd.Parameters.Add(new SqlParameter("@UsuarioAdiciona", proveedor.UsuarioAdiciona));
                        cmd.Parameters.Add(new SqlParameter("@UsuarioModifica", proveedor.UsuarioModifica));
                        cmd.ExecuteNonQuery();
                        return 1;

                    }
                }

            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }

        }
        public void EliminarProveedor(ProveedorEntity proveedor)
        {
            try
            {
                using (dbventasEntity context = new dbventasEntity())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "SP_SET_DELETE_PROVEEDOR";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@codigo", proveedor.idproveedor));
                        cmd.Parameters.Add(new SqlParameter("@estado", proveedor.statu));
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ProveedorEntity ListaProveedores(int idproveedor)
        {
            ProveedorEntity p;

            //if (string.IsNullOrWhiteSpace(usuario))
            //    return null;
            try {
                using (dbventasEntity db = new dbventasEntity())
                {
                    using (var connection = db.Database.Connection as SqlConnection)
                    {
                        connection.Open();
                        string procedure = "[dbo].[ListaProveedores]";
                        SqlCommand cmd = new SqlCommand(procedure, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", idproveedor);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count <= 0)
                        {
                            connection.Close();
                            return null;
                        }
                        p = new ProveedorEntity();
                        foreach (DataRow row in dt.Rows)
                        {
                            p.idproveedor = Convert.ToInt32(row["idproveedor"].ToString());
                            p.razon_social = row["razon_social"].ToString();
                            p.NombreProveedor = row["NombreProveedor"].ToString();
                            p.tipo_documento = row["tipo_documento"].ToString();
                            p.num_documento = row["num_documento"].ToString();
                            p.direccion = row["direccion"].ToString();
                            p.telefono = row["telefono"].ToString();
                            p.email = row["email"].ToString();
                            p.url = row["url"].ToString();
                            p.statu = Convert.ToBoolean(row["statu"].ToString());
                            p.FechaAdiciona = Convert.ToDateTime(row["FechaAdiciona"].ToString());
                            p.UsuarioAdiciona = row["UsuarioAdiciona"].ToString();
                        }
                    }
                }

                return p;

            } catch(Exception)
            {

                throw;
            }
                                                                             
        }
        #endregion

        #region Roles Datos
        #endregion

        #region trabajador Datos


        public int Registrar_Empleado(trabajadorEntitis trabajador)
        {
            try
            {
                using (dbventasEntity context = new dbventasEntity())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "[SP_SET_EMPLEADO]";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idtrabajador", trabajador.idtrabajador));
                        cmd.Parameters.Add(new SqlParameter("@nombre", trabajador.nombre));
                        cmd.Parameters.Add(new SqlParameter("@apellidos", trabajador.apellidos));
                        cmd.Parameters.Add(new SqlParameter("@sexo", trabajador.sexo));
                        cmd.Parameters.Add(new SqlParameter("@Fecha_nac", trabajador.Fecha_nac));
                        cmd.Parameters.Add(new SqlParameter("@num_documento", trabajador.num_documento));
                        cmd.Parameters.Add(new SqlParameter("@direccion", trabajador.direccion));
                        cmd.Parameters.Add(new SqlParameter("@telefono", trabajador.telefono));
                        cmd.Parameters.Add(new SqlParameter("@email", trabajador.email));
                        cmd.Parameters.Add(new SqlParameter("@StatusE", trabajador.StatusE));
                        cmd.Parameters.Add(new SqlParameter("UsuarioAdiciona", trabajador.UsuarioAdiciona));
                        cmd.Parameters.Add(new SqlParameter("UsuarioModifica", trabajador.UsuarioModifica));
                        cmd.ExecuteNonQuery();
                        return 1;
                    }
                }

            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }

        }

        public trabajadorEntitis ListaTrabajador(string NombCompleto, string cedula, string telefono)
        {
            trabajadorEntitis trab;

            using (dbventasEntity db = new dbventasEntity())
            {
                using (var connection = db.Database.Connection as SqlConnection)
                {
                    connection.Open();
                    string procedure = "[dbo].[SP_GET_EMPLOYEES]";
                    SqlCommand cmd = new SqlCommand(procedure, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NombreC", NombCompleto);
                    cmd.Parameters.AddWithValue("@num_cedula", cedula);
                    cmd.Parameters.AddWithValue("@telefono", telefono);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count <= 0)
                    {
                        connection.Close();
                        return null;
                    }
                    trab = new trabajadorEntitis();
                    foreach (DataRow row in dt.Rows)
                    {
                        trab.idtrabajador = Convert.ToInt32(row["idtrabajador"].ToString());
                        trab.NombreCompleto = row["NombreCompleto"].ToString();
                        trab.sexo = row["sexo"].ToString();
                        trab.num_documento = row["num_documento"].ToString();
                        trab.direccion = row["direccion"].ToString();
                        trab.telefono = row["telefono"].ToString();
                        trab.email = row["email"].ToString();
                        trab.estatus = row["Estado"].ToString();

                    }

                }
            }

            return trab;
        }


        #endregion

        #region users Datos
        public string[]LoginUser(string user, string pass)
        {
            int rolId = 0;
            string NombreC="";
             string[] arreglo = new string[2];

            try
            {
                using (dbventasEntity db = new dbventasEntity())
                {
                    using (var connection = db.Database.Connection as SqlConnection)
                    {
                        connection.Open();
                        string query = "SP_LOGIN";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        //parameters. @usuario
                        SqlParameter usuario = new SqlParameter("@usuario", user);
                        usuario.SqlDbType = SqlDbType.VarChar;
                        usuario.Size = 50;

                        //parameter. @contrasena
                        SqlParameter contrasena = new SqlParameter("@contrasena", pass);
                        contrasena.SqlDbType = SqlDbType.VarChar;
                        contrasena.Size = 50;

                        //parameter. @rolid
                        SqlParameter rolid = new SqlParameter("@rolid", rolId);
                        rolid.SqlDbType = SqlDbType.Int;
                        rolid.Direction = ParameterDirection.Output;

                        //parameter.@NombreC
                        SqlParameter nombreC = new SqlParameter("@NombreC",NombreC);
                        nombreC.SqlDbType = SqlDbType.VarChar;
                        nombreC.Size = 80;
                        nombreC.Direction = ParameterDirection.Output;
                        //add parameters to cmd
                        cmd.Parameters.Add(usuario);
                        cmd.Parameters.Add(contrasena);
                        cmd.Parameters.Add(rolid);
                        cmd.Parameters.Add(nombreC);
                        //exec procedure
                        cmd.ExecuteNonQuery();
                        if (cmd.Parameters["@rolid"].Value == DBNull.Value)
                        {
                            rolId = 0;
                        }
                        else
                        {
                            rolId   = System.Convert.ToInt32(cmd.Parameters["@rolid"].Value);
                            NombreC = System.Convert.ToString(cmd.Parameters["@NombreC"].Value);
                        }

                        arreglo[0] = rolId.ToString();
                        arreglo[1] = NombreC;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return arreglo;
        }

        public UsersEntitis GetUserByName(string usuario)
        {
            UsersEntitis user;

            if (string.IsNullOrWhiteSpace(usuario))
                return null;

            using (dbventasEntity db = new dbventasEntity())
            {
                using (var connection = db.Database.Connection as SqlConnection)
                {
                    connection.Open();
                    string procedure = "[dbo].[SP_GET_USER_BY_NAME]";
                    SqlCommand cmd = new SqlCommand(procedure, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@USERNAME", usuario);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count <= 0)
                    {
                        connection.Close();
                        return null;
                    }
                    user = new UsersEntitis();
                    foreach (DataRow row in dt.Rows)
                    {
                        user.id = Convert.ToInt32(row["id"].ToString());
                        user.Usuario = row["Usuario"].ToString();
                        user.Clave = row["Clave"].ToString();
                        user.RolID = Convert.ToInt32(row["RolID"].ToString());
                        user.Statud = Convert.ToBoolean(row["Statud"].ToString());
                    }

                }
            }

            return user;
        }

        public void RegistrarUsuario(UsersEntitis entity)
        {
            using (dbventasEntity db = new CapaDatos.dbventasEntity())
            {
                using (var connection = db.Database.Connection as SqlConnection)
                {
                    try
                    {
                        connection.Open();
                        string procedure = "[dbo].[REGISTRAR_USUARIO]";
                        SqlCommand cmd = new SqlCommand(procedure, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", entity.id);
                        cmd.Parameters.AddWithValue("@Usuario", entity.Usuario);
                        cmd.Parameters.AddWithValue("@Clave", entity.Clave);
                        cmd.Parameters.AddWithValue("@RolID", entity.RolID);
                        cmd.Parameters.AddWithValue("@Statud", entity.Statud);

                        cmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
        #endregion

        #region ventas Datos    
        public articulosEntitis BuscarArticuloFaturar(string codigo, string nom)
        {
            articulosEntitis vent;

            using (dbventasEntity db = new dbventasEntity())
            {
                using (var connection = db.Database.Connection as SqlConnection)
                {
                    connection.Open();
                    string procedure = "[dbo].[SP_GET_ARTICULO]";
                    SqlCommand cmd = new SqlCommand(procedure, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nom", nom);



                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count <= 0)
                    {
                        connection.Close();
                        return null;
                    }
                    vent = new articulosEntitis();
                    foreach (DataRow row in dt.Rows)
                    {
                        vent.idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                        vent.nombre = row["nombre"].ToString(); 
                        vent.idcategoria = Convert.ToInt32(row["idcategoria"].ToString());
                        vent.codigo = row["Codigo"].ToString(); ;
                        vent.Imag_Url = row["Imag_Url"].ToString(); ;
                        vent.descripcion = row["descripcion"].ToString(); ;
                        vent.precioVenta = Convert.ToDecimal(row["precioVenta"].ToString());
                        vent.precioCompra = Convert.ToDecimal(row["precioCompra"].ToString());
                        vent.cantidad = Convert.ToDecimal(row["cantidad"].ToString());
                        vent.estado = Convert.ToBoolean(row["estado"]);
                        vent.idProveedor = Convert.ToInt32(row["idProveedor"].ToString());
                        vent.CodigoBarra = row["CodigoBarra"].ToString();

                    }
                }

                return vent;
            }
            #endregion

        }


    }
}