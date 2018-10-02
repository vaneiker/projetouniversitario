using SellersManagement.Data;
using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellerManagementData
{
    public class ManagementRepository : BaseRepository
    {
        public ManagementRepository() { }

        public IEnumerable<Generic> SetManagement(ManagementData.parameters parameters)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_SET_MANAGEMENT_Result> temp;

            temp = SellersManagementContex.SP_SET_MANAGEMENT(parameters.managementId,
                parameters.managementSupervisorCode,
                parameters.managementSellerCode,
                parameters.managementTypeId,
                parameters.managementResultsId,
                parameters.comment,
                parameters.suggestedImprovement,
                parameters.createUserId);

            result = temp.Select(d => new Generic
            {
                value = d.Id.ToString(),
                name = d.Action
            }).ToArray();

            return
                 result;
        }


        public IEnumerable<ManagementData> GetManagement(ManagementData.parameters parameters)
        {
            IEnumerable<ManagementData> result;
            IEnumerable<SP_GET_MANAGEMENT_Result> temp;

            temp = SellersManagementContex.SP_GET_MANAGEMENT(parameters.managementId,
                parameters.managementSupervisorCode,
                parameters.managementSellerCode);

            result = temp.Select(d => new ManagementData
            {
                Comment = d.Comment,
                ManagementDate = d.Management_Date,
                ManagementId = d.Management_Id,
                ManagementResultsIdSelected = d.ManagementResultsIdSelected,
                ManagementSellerCode = d.Management_Seller_Code,
                ManagementSupervisorCode = d.Management_Supervisor_Code,
                ManagementTypeIdSelected = d.ManagementTypeIdSelected,
                SuggestedImprovement = d.Suggested_Improvement,
            }).ToArray();

            return
                 result;
        }
    }
}
