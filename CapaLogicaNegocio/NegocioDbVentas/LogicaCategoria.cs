using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;
using CapaDatos.RepocitoryDbVentas;

namespace CapaLogicaNegocio.NegocioDbVentas
{
    public class LogicaCategoria
    {
        private categoriaEntitis _categoria;
        
        public LogicaCategoria()
        {
            this._categoria = new categoriaEntitis();
        }

        public bool Insertar(string nombre, string descripcion, int id)
        {
            // si no entras valores no atentara a insertar
            if (String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(descripcion))
                return false;
            // Obtenemos los Datos de los parametros
            _categoria.idcategoria = id;
            _categoria.nombre = nombre;
            _categoria.descripcion = descripcion;
            //Instanciamos el context
            DventasData db = new DventasData();

            //si hay fila afectada entonces devolvemos true de lo contrario false
            return Convert.ToBoolean(db.Registrar_Categoria(_categoria));
        }
    }
}
