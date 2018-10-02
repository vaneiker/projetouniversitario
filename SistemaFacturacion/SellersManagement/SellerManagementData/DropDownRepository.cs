using SellersManagement.Data;
using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerManagementData
{
    public class DropDownRepository : BaseRepository
    {
        public DropDownRepository() { }

        public IEnumerable<Generic> GetDropDown(string DropDownType)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_FILL_DROPDOWN_Result> temp;
            temp = SellersManagementContex.SP_FILL_DROPDOWN(DropDownType);
            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Name
            }).ToArray();

            return
                 result;
        }


        public IEnumerable<Generic> GetManagementResults(int? managementResultId)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_MANAGEMENT_RESULTS_Result> temp;
            temp = SellersManagementContex.SP_GET_MANAGEMENT_RESULTS(managementResultId);
            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Name
            }).ToArray();

            return
                 result;
        }

        public IEnumerable<Generic> GetManagementType(int? managementTypetId)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_MANAGEMENT_TYPES_Result> temp;
            temp = SellersManagementContex.SP_GET_MANAGEMENT_TYPES(managementTypetId);
            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Name
            }).ToArray();

            return
                 result;
        }
    }
}
