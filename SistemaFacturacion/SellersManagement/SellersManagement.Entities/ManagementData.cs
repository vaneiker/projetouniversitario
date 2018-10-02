using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Entities
{
    public class ManagementData
    {
        public int ManagementId { get; set; }
        public int ManagementSupervisorCode { get; set; }
        public int ManagementSellerCode { get; set; }
        public string Comment { get; set; }
        public string SuggestedImprovement { get; set; }
        public System.DateTime ManagementDate { get; set; }
        public int ManagementResultsIdSelected { get; set; }
        public int ManagementTypeIdSelected { get; set; }


        public class parameters
        {
            public Nullable<int> managementId { get; set; }
            public Nullable<int> managementSupervisorCode { get; set; }
            public Nullable<int> managementSellerCode { get; set; }
            public Nullable<int> managementTypeId { get; set; }
            public Nullable<int> managementResultsId { get; set; }
            public string comment { get; set; }
            public string suggestedImprovement { get; set; }
            public Nullable<int> createUserId { get; set; }
        }
    }
}
