using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CollectorsModule.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInterface" in both code and config file together.
    [ServiceContract]
    public interface IInterface
    {
        [OperationContract]
        string BanksInfo(string bankName);
        string DepositAccountInfo(string checkbookName);
    }
}
