using SellerManagementData;
using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Logic
{
    public class ManagementManager : BaseManager
    {
        private readonly ManagementRepository managementRepository;

        public ManagementManager()
        {
            managementRepository = new ManagementRepository();
        }

        public IEnumerable<Generic> SetManagement(ManagementData.parameters parameters)
        {
            return
                managementRepository.SetManagement(parameters);
        }

        public IEnumerable<ManagementData> GetManagement(ManagementData.parameters parameters)
        {
            return
                managementRepository.GetManagement(parameters);
        }
       

    }
}
