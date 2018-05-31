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
        ComboxVentasUtility cbx = new ComboxVentasUtility();
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


        public List<ClienteEntitis>GetClienteCombo()
            {
            ClienteEntitis c = new ClienteEntitis();
            
            
            return cbx.GetAllCliente();

            }

     

        }
    }