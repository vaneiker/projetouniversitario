﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    /// <summary>
    /// ProductTypes
    /// </summary>
    public class VehicleTypeWS
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ProductWS> Products { get; set; }

        public IList<STL.POS.Data.POSEntities.WSEntities.UsageByProductWS> NewUsages { get; set; }

        public IList<STL.POS.Data.POSEntities.WSEntities.ProductByUsageWS> ProductByUsages { get; set; }

        public IList<CoveragesByUsageWS> CoveragesByUsages { get; set; }


    }
}