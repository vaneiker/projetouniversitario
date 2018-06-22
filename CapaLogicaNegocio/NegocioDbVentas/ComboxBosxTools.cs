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
   public class ComboxBosxTools
        {
        ComboBoxTools _cbo = new ComboBoxTools();
        
        public DataTable ListaProve()
            {
            return _cbo.GetProveedor();
            }

        public DataTable GetCategotia()
            {
            return _cbo.GetCategotia();
            }
       public DataTable TipoDeFactura()
            {
            return _cbo.TipoDeFactura();
            }
      public DataTable GetRollD()
            {
            return _cbo.GetRollD();
            }
        }
    }
