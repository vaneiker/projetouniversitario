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
        public Nullable<bool> ShowToSupervisor { get; set; }
        public Nullable<int> Management_Supervisor_Code { get; set; }
        public string Management_Seller_Code { get; set; }
        
        public string Suggested_Improvement { get; set; }
        public Nullable<System.DateTime> Management_Date { get; set; }
             
        public Nullable<int> Management_Id { get; set; }
        public Nullable<bool> isProspect { get; set; }

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
            public Nullable<int> ManagedBy { get; set; }
            public Nullable<bool> ShowToSupervisor { get; set; }
        }
    }
}
