using Entity.Entities;
using STL.POS.Data.NewVersion.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    public class ProductLimitsManager
    {
        private readonly ProductLimitsRepository productLimitsRepository;
        public ProductLimitsManager()
        {
            productLimitsRepository = new ProductLimitsRepository();
        }

        public BaseEntity SetProudctLimits(ProductLimits.Parameter parameter)
        {
            return
                productLimitsRepository.SetProudctLimits(parameter);
        }

        public IEnumerable<ProductsDataFromSysflex> GetProductsSysflex(int codRamo, int vehicleTypeCoreId, int? productID, int vehicleYear)
        {
            return
                productLimitsRepository.GetProductsSysflex(codRamo, vehicleTypeCoreId, productID, vehicleYear);
        }
    }
}
