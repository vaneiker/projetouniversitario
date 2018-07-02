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
            public ClienteEntitis GetClienteFromDataTable(DataTable source)
        {
            ClienteEntitis cliente = new ClienteEntitis();
            foreach(DataRow row in source.Rows)
            {
                cliente.idcliente = Convert.ToInt32(row["idcliente"].ToString());
                cliente.CodigoCliente = row["CodigoCliente"].ToString();
                cliente.NombreCompleto = row["Nombre_Completo_Empleado"].ToString();
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
                cliente.fecha_nacimiento = Convert.ToDateTime(row["Fecha Nacimiento"].ToString());
                cliente.tipo_documento = row["Tipo_de_Documento"].ToString();
                cliente.direccion = row["Direccion"].ToString();
                cliente.telefono = row["Telefono"].ToString();
                cliente.email = row["Correo_electronico"].ToString();
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
        public void Registrar_Articulos(articulosEntitis art)
            {
            _metodos.Registrar_Articulos(art);

            }
        public bool Eliminar_Articulo(articulosEntitis art)
        {
            try
            {
                _metodos.EliminarArticulo(art);
            }catch(Exception ex)
            {
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
    }

}
