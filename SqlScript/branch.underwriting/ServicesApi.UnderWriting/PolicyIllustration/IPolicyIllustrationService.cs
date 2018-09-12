using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServicesApi.UnderWriting.Common;
using ServicesApi.UnderWriting.Common.Model;

namespace ServicesApi.UnderWriting.PolicyIllustration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPolicyIllustrationService
    {
        [OperationContract]
        ReturnMessageData SetPolicyInformation(
            string customerPlanNo,
            string corpId,
            string regionId,
            string countryId,
            string domesticregId,
            string stateProvId,
            string cityId,
            string officeId,
            string userId,
            string companyId,
            string projectId);
    }
}
