using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellersManagement.Entities
{
    public class ProspectData
    {
        public int Id { get; set; }
        public string ProspectCode { get; set; }
        public string ProspectFullName { get; set; }
        public string ProspectChannel { get; set; }
        public string ProspectOffices { get; set; }
        public string ProspectPhones { get; set; }

        public class parameters
        {
            public int? Id { get; set; }
            public string ProspectCode { get; set; }
            public string ProspectFullName { get; set; }
            public string ProspectChannel { get; set; }
            public string ProspectOffices { get; set; }
            public string ProspectPhones { get; set; }
            public int CreateUserId { get; set; }
        }
    }
}
