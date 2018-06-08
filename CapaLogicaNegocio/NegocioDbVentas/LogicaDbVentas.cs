using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.RepocitoryDbVentas;
using CapaEntidad.DbVentas;

namespace CapaLogicaNegocio.NegocioDbVentas
    {
    public class LogicaDbVentas
        {
        DventasData _metodos = new DventasData();
      
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

        public void Registrar_Clientes(ClienteEntitis cliente)
            {
            _metodos.Registrar_Clientes(cliente);
            
            }


        public void Borrar_Clientes(ClienteEntitis cliente)
            {
            _metodos.EliminarClientes(cliente);


            }


       public void IngresdoDeDatos(IngresoMasterEntity ingreso)
            {
            _metodos.IngresdoDeDatos(ingreso);
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
        public DataTable CriterioBusquedaProveedor(string doc, string tel, string nom)
            {
            nom.Trim();
            return (_metodos.Buscarproveedor(doc,tel,nom));
            }
        public void Registrar_Proveedor(ProveedorEntity proveedor)
            {
            _metodos.Registrar_Proveedor(proveedor);

            }

        public void Registrar_Articulos(articulosEntitis art)
            {
            _metodos.Registrar_Articulos(art);

            }



        }
    }