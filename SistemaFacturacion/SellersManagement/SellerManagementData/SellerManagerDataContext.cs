using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerManagementData
{
    public class SellerManagerDataContext
    {
        private SellersManagementEntities _SellersManagementContex;

        public SellersManagementEntities SellersManagementContex
        {
            get
            {
                return _SellersManagementContex ?? new SellersManagementEntities();
            }
        }

        public SellerManagerDataContext(string ConnStr = "")
        {
        }
    }
}
