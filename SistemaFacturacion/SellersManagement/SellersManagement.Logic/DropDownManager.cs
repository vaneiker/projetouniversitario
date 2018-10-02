using SellerManagementData;
using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Logic
{
    public class DropDownManager : BaseManager
    {
        private readonly DropDownRepository dropDownRepository;
        public DropDownManager()
        {
            dropDownRepository = new DropDownRepository();
        }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            return
                dropDownRepository.GetDropDown(DropDownType);
        }

        public IEnumerable<Generic> GetManagementResults(int? managementResultId)
        {
            return
                dropDownRepository.GetManagementResults(managementResultId);
        }

        public IEnumerable<Generic> GetManagementType(int? managementTypetId)
        {
            return
                dropDownRepository.GetManagementType(managementTypetId);
        }
    }
}
