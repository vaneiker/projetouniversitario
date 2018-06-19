using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.RepocitoryDbVentas;
using CapaEntidad.DbVentas;

namespace CapaLogicaNegocio.NegocioDbVentas
{
    public class LogicaArticuloIngreso
    {
        DventasData _metodos = new DventasData();

        public bool Add_Articulos(
                                    
                                   string  nombre
                                 , int     idcategoria
                                 , string  Codigo
                                 , string  mag_Url
                                 , string  descripcion
                                 , decimal precioVenta
                                 , decimal precioCompra
                                 , decimal cantidad
                                 , bool    estado
                                 , int     idProveedor
                                 , int     idingreso
                                 , DateTime fecha
                                 , string tipo_comprobante
                                 , decimal igv
                                 , string UsuarioAdiciona
                                 , decimal stock_inicial
                                 , DateTime fecha_produccion
                                 , DateTime fecha_vencimiento)
        {

            ArticulosCompuestoEntity e = new ArticulosCompuestoEntity();
            e.nombre = nombre;
            e.idcategoria = idcategoria;
            e.Codigo = Codigo;
            e.Imag_Url = mag_Url;
            e.descripcion = descripcion;
            e.precioVenta = precioVenta;
            e.precioCompra = precioCompra;
            e.cantidad = cantidad;
            e.estado = estado;
            e.idProveedor = idProveedor;
            e.idingreso = idingreso;
            e.fecha = fecha;
            e.tipo_comprobante = tipo_comprobante;
            e.igv = igv;
            e.UsuarioAdiciona = UsuarioAdiciona;
            e.stock_inicial = stock_inicial;
            e.fecha_produccion = fecha_produccion;
            e.fecha_vencimiento = fecha_vencimiento;
            var d = _metodos.IngresdoDeDatos(e);
            if (d == 1)
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
 
