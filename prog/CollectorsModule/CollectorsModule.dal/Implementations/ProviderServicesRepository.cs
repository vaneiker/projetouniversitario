using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.Base;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Repositories;
using CollectorsModule.ell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Implementations
{
    public class ProviderServicesRepository : GlobalRepository, IProviderServicesRepository
    {
        public ProviderServicesRepository(GlobalEntities globalEntities)
            : base(globalEntities)
        {

        }

        public ProviderServicesRepository(ATLANEntities atlanEntities)
            : base(null)
        {
            initAtlanRepository(atlanEntities);
        }

        public ProviderTransactionResult SetProviderTransactionInfoKey(ProviderTransactionKey key, int userId)
        {
            var results = globalModel.SP_SET_PM_PROVIDER_TRANSACTION_INFO_KEY(key.Provider_Id,
                                                                              key.Transaction_Type_Catalog_Id,
                                                                              key.Provider_Transaction_Type_Id, userId)
                                     .Select(s => new ProviderTransactionResult()
                                     {
                                         Order_Id = s.Order_Id,
                                         Transaction_Date = DateTime.Parse((s.Transaction_Date ?? new DateTime()).ToString()),
                                         ProviderKey = new ProviderTransactionKey()
                                         {
                                             Provider_Id = s.Provider_Id.HasValue ? s.Provider_Id.Value : default(int),
                                             Provider_Transaction_Type_Id = s.Provider_Transaction_Type_Id.HasValue ? s.Provider_Transaction_Type_Id : default(int),
                                             Transaction_Id = (s.Transaction_Id ?? "0").ToString(),
                                             Transaction_Key_Id = s.Transaction_Key_Id.HasValue ? s.Transaction_Key_Id.Value : default(int),
                                             Transaction_Type_Catalog_Id = s.Transaction_Type_Catalog_Id.HasValue ? s.Provider_Transaction_Type_Id.Value : default(int),
                                         },
                                     }).FirstOrDefault();
            return results;
        }

        public ProviderSettings GetProviderParameters(int? Provider_Id = 1, int? Transaction_Type_Catalog_Id = 1, int? Provider_Transaction_Type_Id = 1)
        {
            ProviderSettings settings = new ProviderSettings();
            var results = globalModel.SP_GET_PM_PROVIDER_PARAMETER(Provider_Id, Transaction_Type_Catalog_Id, Provider_Transaction_Type_Id)
                                     .Select(x => new Provider_Parammeters()
                                     {
                                         Parameter_Name = x.Parameter_Name.ToString(),
                                         Parameter_Value = x.Parameter_Value.ToString(),
                                         Provider_Id = Int32.Parse(x.Provider_Id.ToString()),
                                         Provider_Transaction_Type_Id = Int32.Parse(x.Provider_Transaction_Type_Id.ToString()),
                                         Transaction_Type_Catalog_Id = Int32.Parse(x.Transaction_Type_Catalog_Id.ToString())
                                     }).ToList();
            if (results.Count > 0)
            {
                settings.Acquiring_Institution_Code = results.Where(x => x.Parameter_Name == "AcquiringInstitutionCode").FirstOrDefault().Parameter_Value.ToString();
                settings.Merchant_Number = results.Where(x => x.Parameter_Name == "MerchantNumber").FirstOrDefault().Parameter_Value.ToString();
                settings.Merchant_Number_Amex = results.Where(x => x.Parameter_Name == "MerchantNumber_amex").FirstOrDefault().Parameter_Value.ToString();
                settings.Merchant_Terminal = results.Where(x => x.Parameter_Name == "MerchantTerminal").FirstOrDefault().Parameter_Value.ToString();
                settings.Merchant_Terminal_Amex = results.Where(x => x.Parameter_Name == "MerchantTerminal_amex").FirstOrDefault().Parameter_Value.ToString();
                settings.Merchant_Type = results.Where(x => x.Parameter_Name == "MerchantType").FirstOrDefault().Parameter_Value.ToString();
                settings.Url = results.Where(x => x.Parameter_Name == "Url").FirstOrDefault().Parameter_Value.ToString();
                settings.Currency_Code = results.Where(x => x.Parameter_Name == "CurrencyCode").FirstOrDefault().Parameter_Value.ToString();
                settings.MerchantName = results.Where(x => x.Parameter_Name == "MerchantName").FirstOrDefault().Parameter_Value.ToString();
                settings.TransactionType = results.Where(x => x.Parameter_Name == "TransactionType").FirstOrDefault().Parameter_Value.ToString();
                settings.ProviderId = 1;
                settings.TransactionTypeId = 1;
                settings.TransactionTypeCatalogId = 1;
            }
            return settings;
        }

        public List<Provider_Parammeters_Results> SetProviderTransaction(ProviderTransaction providerTransaction)
        {
            var results = globalModel.SP_SET_PM_PROVIDER_TRANSACTION(
                                                                     providerTransaction.ProviderKey.Provider_Id,
                                                                     providerTransaction.ProviderKey.Transaction_Key_Id,
                                                                     providerTransaction.ProviderKey.Transaction_Type_Catalog_Id,
                                                                     providerTransaction.ProviderKey.Provider_Transaction_Type_Id,
                                                                     providerTransaction.ProviderKey.Transaction_Id,
                                                                     providerTransaction.Transaction_Date,
                                                                     providerTransaction.Credit_Card_Number,
                                                                     providerTransaction.Credit_Card_Expiration_Date,
                                                                     providerTransaction.Amount,
                                                                     providerTransaction.Tax,
                                                                     providerTransaction.Response_Code,
                                                                     providerTransaction.Authorization_Code,
                                                                     providerTransaction.Retrieval_Reference_Number,
                                                                     providerTransaction.Order_Id,
                                                                     providerTransaction.Transaction_Extra_Data,
                                                                     providerTransaction.UserId
                                                                    ).AsEnumerable()
                                                                    .Select(s => new Provider_Parammeters_Results()
                                                                    {
                                                                        Action = s.Action.ToString(),
                                                                        Provider_Id = s.Provider_Id.HasValue ? s.Provider_Id.Value : default(int),
                                                                        Transaction_Key_Id = s.Transaction_Key_Id.HasValue ? s.Transaction_Key_Id.Value : default(int),

                                                                    }).ToList();
            return results;
        }

        public Int32? SetProviderLogs(ProviderLogs log)
        {
            Int32 results = 0;
            int.TryParse(globalModel.SP_INSERT_PM_PROVIDER_LOG(log.Log_Type_Id,
                                                               log.Corp_Id,
                                                               log.Company_Id,
                                                               log.Project_Id,
                                                               log.Order_Id,
                                                               log.Log_Desc
                                                              ).AsEnumerable()
                                    .Select(s => s.Value.ToString())
                                    .FirstOrDefault(), out results);
            return results;
        }
        
        public ProviderTransaction GetProviderTransactionByOrderID(string Order_Id)
        {
            ProviderTransaction result = globalModel.SP_GET_PM_PROVIDER_TRANSACTION_BY_ORDERID(Order_Id)
                                                    .Select(s => new ProviderTransaction()
                                                    {
                                                        Amount = s.Amount.HasValue?s.Amount.Value:default(decimal),
                                                        Authorization_Code = (s.Authorization_Code??string.Empty).ToString(),
                                                        Credit_Card_Expiration_Date = s.Credit_Card_Expiration_Date,
                                                        Credit_Card_Number = s.Credit_Card_Number,
                                                        Order_Id = s.Order_Id,
                                                        ProviderKey = new ProviderTransactionKey()
                                                        {
                                                            Provider_Id = s.Provider_Id,
                                                            Provider_Transaction_Type_Id = s.Provider_Transaction_Type_Id.HasValue?s.Provider_Transaction_Type_Id.Value:default(int),
                                                            Transaction_Id = s.Transaction_Id,
                                                            Transaction_Key_Id = unchecked((int)s.Transaction_Key_Id),
                                                            Transaction_Type_Catalog_Id = s.Transaction_Type_Catalog_Id.HasValue?s.Provider_Transaction_Type_Id.Value:default(int),
                                                        },
                                                        Response_Code = s.Response_Code,
                                                        Retrieval_Reference_Number = s.Retrieval_Reference_Number,
                                                        Tax = s.Tax.HasValue?s.Tax.Value:default(int),
                                                        Transaction_Date = s.Transaction_Date,
                                                        Transaction_Extra_Data = s.Transaction_Extra_Data
                                                    }).FirstOrDefault();
            return result;
        }
    }
}
