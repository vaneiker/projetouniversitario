using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServicesApi.UnderWriting.Common;
using ServicesApi.UnderWriting.Common.Model;

namespace ServicesApi.UnderWriting.Contact
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IContactService
    {
        [OperationContract]
        ReturnMessageData SetContactInformation(string corpId, string contactId, string companyId);

        [OperationContract]
        ReturnMessageData SetContactAllInformation(string corpId, string contactId, string companyId);

        [OperationContract]
        ReturnMessageData SetContactEmail(string corpId, string contactId);

        [OperationContract]
        ReturnMessageData SetContactPhone(string corpId, string contactId);

        [OperationContract]
        ReturnMessageData SetContactIdentification(string corpId, string contactId);

        [OperationContract(Name = "SetContactInformationWithCustomerNo")]
        ReturnMessageData SetContactInformation(string corpId, string contactId, string companyId, string customerNo);

        [OperationContract(Name = "SetContactAllInformationWithCustomerNo")]
        ReturnMessageData SetContactAllInformation(string corpId, string contactId, string companyId, string customerNo);

        [OperationContract(Name = "SetContactEmailWithCustomerNo")]
        ReturnMessageData SetContactEmail(string corpId, string contactId, string customerNo);

        [OperationContract(Name = "SetContactPhoneWithCustomerNo")]
        ReturnMessageData SetContactPhone(string corpId, string contactId, string customerNo);

        [OperationContract(Name = "SetContactIdentificationWithCustomerNo")]
        ReturnMessageData SetContactIdentification(string corpId, string contactId, string customerNo);

        //Mavelar-BM

        [OperationContract]
        ReturnMessageData SetContactEmailJuridico(string corpId, string Agent_Legal);

        [OperationContract]
        ReturnMessageData SetContactIdentificationJuridico(string corpId, string Agent_Legal);

        [OperationContract(Name = "SetContactIdentificationJuridicoWithCustomerNo")]
        ReturnMessageData SetContactIdentificationJuridico(string corpId, string Agent_Legal, string customerNo);

        [OperationContract(Name = "SetContactEmailJuridicoWithCustomerNo")]
        ReturnMessageData SetContactEmailJuridico(string corpId, string Agent_Legal, string customerNo);
    }
}
