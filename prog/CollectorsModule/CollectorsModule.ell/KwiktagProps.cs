using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class KwiktagProps
    {
        public class Parameters
        {
            public string apiURL { get; set; }
            public string callingID { get; set; }
            public string userName { get; set; }
            public string password { get; set; }
            public string drawer { get; set; }
            public string companyID { get; set; }
            public string siteName { get; set; }
            public string barcode { get; set; }
        }
        public class Tags
        {
            public string Property { get; set; }
            public string Value { get; set; }
        }
    }
}
