using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceReference
{
    public  class serviceReference
    {
        public WebServices.GlobalService.PolicyServiceClient policyServiceClient
        {
            get { return new WebServices.GlobalService.PolicyServiceClient(); }
        }
    }
}
