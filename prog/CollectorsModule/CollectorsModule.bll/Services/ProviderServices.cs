using Collectors.Helpers;
using CollectorsModule.dal.Singleton;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.bll.Services
{
    public class ProviderServices
    {
        /// <summary>
        /// Get OrderId and Transaction Id [SP_SET_PM_PROVIDER_TRANSACTION_INFO_KEY]
        /// </summary>
        /// <param name="key">Object ProviderTransactionKey</param>
        /// <param name="userId">Int Code User</param>
        /// <returns>object ProviderTransaction_Resutl</returns>
        public ProviderTransactionResult SetProviderTransactionInfoKey(ProviderTransactionKey key, Int32 userId)
        {
            try
            {
                ProviderTransactionResult result = Singleton.Instance.UnitOfWork.ProviderServicesRepository.SetProviderTransactionInfoKey(key, userId);                   
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get Parameter for set CardNet Request
        /// </summary>
        /// <param name="Provider_Id">Int32</param>
        /// <param name="Transaction_Type_Catalog_Id">Int32</param>
        /// <param name="Provider_Transaction_Type_Id">Int32</param>
        /// <returns>Object CardNetSetting</returns>
        public ProviderSettings GetProviderParameters(Int32? Provider_Id = 1, Int32? Transaction_Type_Catalog_Id = 1, Int32? Provider_Transaction_Type_Id = 1)
        {
            ProviderSettings settings = Singleton.Instance.UnitOfWork.ProviderServicesRepository.GetProviderParameters(Provider_Id, Transaction_Type_Catalog_Id, Provider_Transaction_Type_Id);
            return settings;
        }

        /// <summary>
        /// Insert and update Transaction in [PM_PROVIDER_TRANSACTION]
        /// </summary>
        /// <param name="Prov_Trans">Object</param>
        /// <returns>List Provider_Parammeters_Results</returns>
        public List<Provider_Parammeters_Results> SetProviderTransaction(ProviderTransaction providerTransaction)
        {
            List<Provider_Parammeters_Results> result = Singleton.Instance.UnitOfWork.ProviderServicesRepository.SetProviderTransaction(providerTransaction);
            return result;
        }

        /// <summary>
        /// Insert Into PM_PROVIDER_LOG (Request-Response-Exception)
        /// </summary>
        /// <param name="log">Object ProviderLog</param>
        /// <returns>Int Nullable (-1)</returns>
        public Int32? SetProviderLog(ProviderLogs log)
        {
            Int32? result = Singleton.Instance.UnitOfWork.ProviderServicesRepository.SetProviderLogs(log);
            return result;
        }

        /// <summary>
        /// Get a provider transaction by Order_Id
        /// </summary>
        /// <param name="Order_Id">String</param>
        /// <returns>Object ProviderTransaction</returns>
        public ProviderTransaction GetProviderTransactionByOrderID(String Order_Id)
        {
            ProviderTransaction result = Singleton.Instance.UnitOfWork.ProviderServicesRepository.GetProviderTransactionByOrderID(Order_Id);
            return result;
        }
    }
}
