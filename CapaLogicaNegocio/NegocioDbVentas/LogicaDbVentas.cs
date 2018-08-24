using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.RepocitoryDbVentas;
using CapaEntidad.DbVentas;
using CapaLogicaNegocio.ModeloVista;

namespace CapaLogicaNegocio.NegocioDbVentas
    {
    public class LogicaDbVentas
        {
        DventasData _metodos = new DventasData();
        public DataTable Listap()
        {
            return _metodos.Listproveedor();

        }
        public DataTable ListCategoria()
            {
            return _metodos.ListCategoria();

            }
        public void Registrar_Categoria(categoriaEntitis categoria)
            {
            _metodos.Registrar_Categoria(categoria);
            
            }
        public DataTable ListaClientes()
            {
            
            return _metodos.ListaCliente();

            }
        public DataTable BuscarCliente(string NombreCompleto, string cedula, string codigo, string telefono)
            {
            cedula.Replace("-","");
            return (_metodos.BuscarCliente(NombreCompleto,cedula,codigo,telefono));
            }
        public bool Registrar_Clientes(ClienteEntitis cliente)
            {
           
            if (cliente.idcliente > 0)
            {
                
            }

            //return  /* _metodos.Registrar_Clientes(cliente);*/
            var r = _metodos.Registrar_Clientes(cliente);
            if (r == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public bool BorrarArticulo(int id ,bool estatus)
        {
            articulosEntitis en = new articulosEntitis();
            if (id <= 0)
            {
                return false;
            }
            else
            {
                en.idarticulo = id;
                en.estado = estatus;
                var r = _metodos.EliminarArticulo(en);
                if (r == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public ClienteEntitis GetClienteFromDataTable(DataTable source)
        {
            ClienteEntitis cliente = new ClienteEntitis();
            foreach(DataRow row in source.Rows)
            {
                cliente.idcliente = Convert.ToInt32(row["idcliente"].ToString());
                cliente.CodigoCliente = row["CodigoCliente"].ToString();
                cliente.NombreCompleto = row["nombre"].ToString() + " " + row["apellidos"].ToString();
                switch(row["Sexo"].ToString()[0])
                {
                    case 'M':
                        cliente.sexo = "Masculino";
                        break;
                    case 'F':
                        cliente.sexo = "Femenino";
                        break;
                    default:
                        cliente.sexo = "Otros";
                        break;
                }
                cliente.fecha_nacimiento = Convert.ToDateTime(row["fecha_nacimiento"].ToString());
                cliente.tipo_documento = row["tipo_documento"].ToString();
                cliente.direccion = row["direccion"].ToString();
                cliente.telefono = row["telefono"].ToString();
                cliente.email = row["email"].ToString();
            }
            return cliente;
        }
        public void Borrar_Clientes(ClienteEntitis cliente)
            {
            _metodos.EliminarClientes(cliente);


            }
        public DataTable ListaArticulos()
            {
            return _metodos.ListArticulos();

            }
        public DataTable CriterioBusquedaArticulo(string codigo , string nombre)
            {
            nombre.Trim();
            return (_metodos.BuscarArticulo(codigo,nombre));
            }
        public articulosEntitis BuscarArticulosPorCodigo(string codigo)
        {
            codigo = codigo.ToUpper();
            return _metodos.BuscarArticuloXCodigo(codigo);
        }
        public DataTable CriterioBusquedaProveedor(string doc, string tel, string nom)
            {
            nom.Trim();
            return (_metodos.Buscarproveedor(doc,tel,nom));
            }
        public bool Registrar_Proveedor(ProveedorEntity proveedor)
            {
            if (proveedor.idproveedor==0)
            {
                proveedor.UsuarioModifica = "0";
            }

          proveedor.telefono=proveedor.telefono.Replace("-","");
          proveedor.num_documento=proveedor.num_documento.Replace("-", "");

             var r= _metodos.Registrar_Proveedor(proveedor);

            if (r == 1)
            {
                return true;
            } else
            {
                return false;
            }

            }
        
          public bool Registrar_Articulos(
                                  string  idarticulo
                                , string  codigo
                                , string  nombre
                                , int     idcategoria
                                , string  Imag_Url
                                , string  descripcion
                                , decimal precioVenta
                                , decimal precioCompra
                                , decimal cantidad
                                , bool    estado
                                , int     idProveedor
    )
        {
            articulosEntitis art = new articulosEntitis();
            if(idarticulo=="" || idarticulo == null)
            {
                idarticulo = "0";
            }
            art.idarticulo =int.Parse(idarticulo);
            art.codigo = codigo;
            art.nombre = nombre;
            art.idcategoria = idcategoria;
            art.Imag_Url = Imag_Url;
            art.descripcion = descripcion;
            art.precioVenta = precioVenta;
            art.precioCompra = precioCompra;
            art.cantidad = cantidad;
            art.estado = estado;
            art.idProveedor = idProveedor;


           var repuesta= _metodos.Registrar_Articulos(art);
            if(repuesta==1)
            {
                return true;
            } else

            {
                return false;
            }
           
            }
        /// <summary>
        /// Metodo que elimina los articulos 
        /// </summary>
        /// <param name="art">Parametro de entrada esto resive un Ojeto</param>
        /// <returns></returns>
        public bool Eliminar_Articulo(articulosEntitis art)
        {
            try
            {
                _metodos.EliminarArticulo(art);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
           

        public int IngresarVenta(ventasEntitis venta, ICollection<detalle_ventaEntitis> detalles)
        {
            return _metodos.IngresarVenta(venta, detalles);
        }

        //buscar factura
        public FacturaEntity BuscarFactura(int idVenta, int idFactura = 0)
        {
            return _metodos.BuscarFactura(idVenta, idFactura);
        }

        //ingresar factura
        public int IngresarFactura(FacturaEntity nuevaFactura)
        {
            int id_factura = 0;
            _metodos.IngresarFactura(nuevaFactura);
            id_factura = _metodos.BuscarIdFactura(nuevaFactura.id_venta);
            return id_factura;
        }

        public int IngresarVentaModelo(VentaViewModel modeloVenta, List<DetalleVentaViewModel> detalles)
        {
            ventasEntitis domainVenta = new ventasEntitis();
            List<detalle_ventaEntitis> domainDetalles = new List<detalle_ventaEntitis>();

            domainVenta.fecha = modeloVenta.fecha;
            domainVenta.idcliente = modeloVenta.idcliente;
            domainVenta.idtrabajador = modeloVenta.idtrabajador;
            domainVenta.itbis = modeloVenta.itbis;
            domainVenta.subtotal = modeloVenta.subtotal;
            domainVenta.tipo_cliente = modeloVenta.tipo_cliente;
            domainVenta.tipo_comprobante = modeloVenta.tipo_comprobante;
            domainVenta.tipo_venta = modeloVenta.tipo_venta;
            domainVenta.total = modeloVenta.total;

            foreach(DetalleVentaViewModel vmDetalle in detalles)
            {
                domainDetalles.Add(new detalle_ventaEntitis
                {
                    iddetalle_venta = vmDetalle.iddetalle_venta,
                    idventa = vmDetalle.idventa,
                    producto = vmDetalle.producto,
                    cantidad = vmDetalle.cantidad,
                    precio_venta = vmDetalle.precio_venta,
                    descuento = vmDetalle.descuento,
                    itbis = vmDetalle.itbis
                });
            }

            return IngresarVenta(domainVenta, domainDetalles);

        }

        public void AgregarCuentaACobrar(int id_cliente, int id_venta, decimal valor, string usuario)
        {
            cuentas_x_cobrarEntitis entity = new cuentas_x_cobrarEntitis();
            entity.id_cliente = id_cliente;
            entity.valor = valor;
            entity.usuario = usuario;
            entity.id_venta = id_venta;
            _metodos.AgregarCuentaACobrar(entity);
        }

        public void ReducirArticulo(int idarticulo, int cantidad)
        {
            articulosEntitis entity = new articulosEntitis();
            entity.idarticulo = idarticulo;
            entity.cantidad = cantidad;
            _metodos.ReducirCantidadArticulo(entity);

        }

        public ICollection<CuadreViewModel> MostrarVentasDelDia()
        {
            List<CuadreViewModel> ventas = new List<CuadreViewModel>();

            DataTable datos = _metodos.BuscarVentasDelDia();
            if (datos == null)
                return null;
            if(datos.Rows.Count > 0)
            {
                foreach (DataRow fila in datos.Rows)
                    ventas.Add(new CuadreViewModel
                    {
                        Fecha = Convert.ToDateTime(fila["fecha"].ToString()),
                        IdVenta = Convert.ToInt32(fila["idventa"].ToString()),
                        NombreCliente = fila["cliente"].ToString(),
                        IdTrabajador = Convert.ToInt32(fila["idtrabajador"].ToString()),
                        TipoFactura = fila["tipo"].ToString(),
                        TipoVenta = fila["venta"].ToString(),
                        Categoria = fila["categoria"].ToString(),
                        ITBIS = Convert.ToDecimal(fila["itbis"].ToString()),
                        SubTotal = Convert.ToDecimal(fila["subtotal"].ToString()),
                        Total = Convert.ToDecimal(fila["total"].ToString())
                    });
            }
            return ventas;

        }
        /// <summary>
        /// Busca en la Base de Datos las Ventas del Mes.
        /// </summary>
        /// <param name="dia1">Dia 1ro. del Mes</param>
        /// <param name="ultimoDia">Ultimo dia del Mes. 30 o 31</param>
        /// <returns>Collection De CuadreViewModel Devuelta</returns>
        public ICollection<CuadreViewModel> MostrarVentasDelMes(DateTime dia1, DateTime ultimoDia)
        {
            List<CuadreViewModel> ventas = new List<CuadreViewModel>();

            DataTable datos = _metodos.BuscarVentasDelMes(dia1, ultimoDia);
            if (datos.Rows.Count > 0)
            {
                foreach (DataRow fila in datos.Rows)
                    ventas.Add(new CuadreViewModel
                    {
                        Fecha = Convert.ToDateTime(fila["fecha"].ToString()),
                        IdVenta = Convert.ToInt32(fila["idventa"].ToString()),
                        NombreCliente = fila["cliente"].ToString(),
                        IdTrabajador = Convert.ToInt32(fila["idtrabajador"].ToString()),
                        TipoFactura = fila["tipo"].ToString(),
                        TipoVenta = fila["venta"].ToString(),
                        Categoria = fila["categoria"].ToString(),
                        ITBIS = Convert.ToDecimal(fila["itbis"].ToString()),
                        SubTotal = Convert.ToDecimal(fila["subtotal"].ToString()),
                        Total = Convert.ToDecimal(fila["total"].ToString())
                    });
            }
            return ventas;

        }
        #region Metodos Proveedores

        //Apartir de esta Linea Empieso con las Buenas Practivas
        /// <summary>
        /// Metodo que Guarda o Actualiza el Proveedor
        /// </summary>
        /// <param name="idproveedor"></param>
        /// <param name="razonsocial"></param>
        /// <param name="NombreProveedor"></param>
        /// <param name="tipodocumento"></param>
        /// <param name="numdocumento"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="url"></param>
        /// <param name="statu"></param>
        /// <param name="FechaAdiciona"></param>
        /// <param name="FechaModifica"></param>
        /// <param name="UsuarioAdiciona"></param>
        /// <param name="UsuarioModifica"></param>
        /// <returns></returns>
        public bool Registrar_Proveedor(int idproveedor
                                       , string razonsocial
                                       , string NombreProveedor
                                       , string tipodocumento
                                       , string numdocumento
                                       , string direccion
                                       , string telefono
                                       , string email
                                       , string url
                                       , bool statu
                                       , DateTime FechaAdiciona
                                       , DateTime FechaModifica
                                       , string UsuarioAdiciona
                                       , string UsuarioModifica)
            {
            ProveedorEntity p = new ProveedorEntity();
            if (String.IsNullOrWhiteSpace(tipodocumento) || String.IsNullOrWhiteSpace(numdocumento)) return false;
            if (String.IsNullOrWhiteSpace(NombreProveedor) || String.IsNullOrWhiteSpace(telefono)) return false;
            p.idproveedor = idproveedor;
            p.razon_social = razonsocial;
            p.NombreProveedor = NombreProveedor;
            p.tipo_documento = tipodocumento;
            p.num_documento = numdocumento;
            p.direccion = direccion;
            p.telefono = telefono;
            p.email = email;
            p.url = url;
            p.statu = statu;
            p.FechaAdiciona = FechaAdiciona;
            p.FechaModifica = FechaModifica;
            p.UsuarioAdiciona = UsuarioAdiciona;
            p.UsuarioModifica = UsuarioModifica;
            int filasAfectadas = _metodos.Registrar_Proveedor(p);
            return filasAfectadas > 0 ? true : false;
            }


        public DataTable ListArticuloXcodigo(string codigo,int copia=1)
        {
            return _metodos.ListarticulosX_Codigo(codigo,copia);
        }



        #endregion

        #region Metodos Trabajador

        public bool Add_employee(
                                  int       idtrabajador
                                 ,string    nombre
                                 ,string    apellidos
                                 ,string    sexo
                                 ,DateTime  Fecha_nac
                                 ,string    num_documento
                                 ,string    direccion
                                 ,string    telefono
                                 ,string    email
                                 ,bool      StatusE
                                ,string     UsuarioAdiciona
                                 ,string    UsuarioModifica
                                 )
        {
            int respuesta;
            trabajadorEntitis tt = new trabajadorEntitis();
            if (idtrabajador == 0)
            {
                UsuarioModifica = "0";
            }
          
            tt.idtrabajador     = idtrabajador;

            tt.nombre           = nombre;
            tt.apellidos        = apellidos;
            tt.sexo             = sexo;           
            tt.Fecha_nac        = Fecha_nac;
            tt.num_documento    = num_documento.Replace("-","");
            tt.direccion        = direccion.Trim();
            tt.telefono         = telefono.Replace("-", "");  
            tt.email            = email;
            tt.StatusE          = StatusE;

            tt.nombre           =nombre;
            tt.apellidos        =apellidos;
            tt.sexo             = sexo[0].ToString();           
            tt.Fecha_nac        =Fecha_nac;
            tt.num_documento    =num_documento;
            tt.direccion        = direccion;
            tt.telefono         = telefono.Substring(1).Replace("-","");  
            tt.email            =email;
            tt.StatusE          =StatusE;

            tt.UsuarioAdiciona  = UsuarioAdiciona;
            tt.UsuarioModifica  = UsuarioModifica;
           

            respuesta = _metodos.Registrar_Empleado(tt);
            if (respuesta == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


        #endregion

        #region Metodos Cotizador
        /// <summary>
        /// Registra la Cotizacion.
        /// Debe tener los detalles de los productos dentro como colleccion.
        /// </summary>
        /// <param name="cotizacion">Venta Actual Registrada con todos sus atributos con datos</param>
        /// <returns>Devuelve el Id de la Cotizacion Registrada</returns>
        public int IngresarCotizacion(VentaViewModel cotizacion)
        {
            CotizacionEntity nuevaCotizacion = new CotizacionEntity();
            nuevaCotizacion.cantidad = cotizacion.cantidad;
            nuevaCotizacion.estatus = true;
            nuevaCotizacion.fecha = DateTime.Now;
            nuevaCotizacion.idcliente = cotizacion.idcliente;
            nuevaCotizacion.idtrabajador = cotizacion.idtrabajador;
            nuevaCotizacion.itbis = cotizacion.itbis;
            nuevaCotizacion.subtotal = cotizacion.subtotal;
            nuevaCotizacion.total = cotizacion.total;

            return _metodos.IngresarCotizacion(nuevaCotizacion);
        }
        /// <summary>
        /// Registra la colecion de los detalles de la cotizacion.
        /// </summary>
        /// <param name="idCotizacion">Id De la Cotizacion Registrada</param>
        /// <param name="detalles">Colecion de Detalles de la Cotizacion</param>
        public void IngresarDetallesCotizacion(int idCotizacion, List<DetalleVentaViewModel> detalles)
        {
            foreach(DetalleVentaViewModel entrada in detalles)
            {
                detalle_cotizacion_productos producto = new detalle_cotizacion_productos
                {
                    idcotizacion = idCotizacion,
                    producto = entrada.producto,
                    cantidad = entrada.cantidad,
                    precioVenta = entrada.precio_venta,
                    itbis = entrada.itbis * entrada.cantidad,
                    subtotal = (entrada.precio_venta * entrada.cantidad),
                    total = ((entrada.cantidad * entrada.precio_venta) + (entrada.itbis * entrada.cantidad))
                };
                _metodos.IngresarDetallesCotizacion(producto);
            }
        }
        #endregion

        public bool RegistrarUsuarios(string usuario, string clave, int role, bool status, int id_trabajador, int id=0)
        {
            UsersEntitis u = new UsersEntitis();
          
            u.Usuario = usuario;
            u.Clave = clave;
            u.RolID = role;
            u.Statud = status;
            u.id_trabajador = id_trabajador;
            u.id = id;

            var repuesta = _metodos.RegistrarUsuario(u);
           
            if(repuesta==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable ListadoCxC()
        {
            return _metodos.ListCuentasXcobrar();
        }


        public DataTable BuscarCxC(string num_documento,string codigoCliente,string NombComp) 
            {
            cuentas_x_cobrarEntitis cxc = new cuentas_x_cobrarEntitis();
            cxc.num_documento = num_documento;
            cxc.codigoCliente = codigoCliente;
            cxc.NombComp = NombComp;
            return _metodos.ListCuentasXcobrar();
        }



        public bool PagarCuentaCxc(int id, int id_cliente, int id_factura, DateTime fecha, decimal valor, bool pago, string usuario, decimal cantidadP, bool estado)
        {
            if (valor == cantidadP)
            {
                valor = cantidadP;
                pago = true;
            }

            cuentas_x_cobrarEntitis cxc = new cuentas_x_cobrarEntitis();
            cxc.id = id;
            cxc.id_cliente = id_cliente;
            cxc.fecha = fecha;
            cxc.valor = valor;
            cxc.pagado = pago;
            cxc.usuario = usuario;
            cxc.idFactura = id_factura;
            cxc.CantidadPagada = cantidadP;
            cxc.statud = estado;

            var respuesta = _metodos.PagarCuentaCxc(cxc);
            if (respuesta == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}



      

   



