using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.RepocitoryDbVentas;
using CapaEntidad.DbVentas;

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
