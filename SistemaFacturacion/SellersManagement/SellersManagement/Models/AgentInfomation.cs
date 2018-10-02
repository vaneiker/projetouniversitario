using SellersManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellersManagement.Models
{
    public class AgentInfomation
    {
        public string FullName { get; set; }
        public string AgentCode { get; set; }
        public string AgentOffices { get; set; }
        public string AgentChannel { get; set; }
        public string Comment { get; set; }
        public string SuggestedImprovement { get; set; }
        public string ManagementDate { get; set; }

        public string Phones { get; set; }

        public string TypeManagement { get; set; }
        public string ResultManagement { get; set; }

        //public List<Generic> TypeManagement { get; set; }
        //public List<Generic> ResultManagement { get; set; }
    }
}