using SellerManagementData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Data
{
    public class BaseRepository
    {
        private SellerManagerDataContext DataContext;
        protected SellersManagementEntities SellersManagementContex;

        public BaseRepository()
        {
            DataContext = new SellerManagerDataContext();
            SellersManagementContex = DataContext.SellersManagementContex;
        }
    }
}
