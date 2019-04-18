using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Entities
{
    public class AgentData
    {
        public int AgentId { get; set; }
        public string AgentCode { get; set; }
        public string NameId { get; set; }
        public string SourceID { get; set; }
        public string FullName { get; set; }
        public string Office { get; set; }
        public string Channel { get; set; }
        public int BlId { get; set; }
        public string BlDesc { get; set; }
        public string Phones { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorAgentCode { get; set; }
        public Nullable<int> Management_Supervisor_Code { get; set; }
        public string Management_Seller_Code { get; set; }
        public string Comment { get; set; }
        public string Suggested_Improvement { get; set; }
        public Nullable<System.DateTime> Management_Date { get; set; }
        public Nullable<int> ManagementResultsIdSelected { get; set; }
        public Nullable<int> ManagementTypeIdSelected { get; set; }
        public Nullable<bool> ShowToSupervisor { get; set; }
        public Nullable<int> Management_Id { get; set; }
        public Nullable<bool> isProspect { get; set; }
        public class parameters
        {
            public Nullable<int> AgentId { get; set; }
            public Nullable<int> BL { get; set; }
            public string AgentCode { get; set; }
            public string NameId { get; set; }
            public Nullable<bool> isExecutiveRol { get; set; }
        }
    }
}
