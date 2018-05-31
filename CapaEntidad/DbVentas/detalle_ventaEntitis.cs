﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DbVentas
    {
  public  class detalle_ventaEntitis
        {

        public int iddetalle_venta { get; set; }

        public int idventa { get; set; }

        public int iddetalle_ingreso { get; set; }

        public int cantidad { get; set; }

        public decimal precio_venta { get; set; }

        public decimal descuento { get; set; }



        public virtual detalle_ingresoEntitis detalle_ingreso { get; set; }

        public virtual ventasEntitis venta { get; set; }
        }
    }
