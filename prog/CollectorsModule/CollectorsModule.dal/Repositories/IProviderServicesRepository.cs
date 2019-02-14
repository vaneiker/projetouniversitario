using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Repositories
{
    public interface IProviderServicesRepository : IDisposable
    {
        ProviderTransactionResult SetProviderTransactionInfoKey(ProviderTransactionKey key, Int32 userId);
        ProviderSettings GetProviderParameters(Int32? Provider_Id = 1, Int32? Transaction_Type_Catalog_Id = 1, Int32? Provider_Transaction_Type_Id = 1);
        List<Provider_Parammeters_Results> SetProviderTransaction(ProviderTransaction providerTransaction);
        Int32? SetProviderLogs(ProviderLogs log);
        ProviderTransaction GetProviderTransactionByOrderID(String Order_Id);
    }
}
