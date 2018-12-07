using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models
{
    public class SearchModel : BaseModel
    {
        public SearchModel() { }

        public SearchViewModels GetLoanInformation(string clienteName, string identificationNumber, Nullable<long> quotationId, Nullable<long> accountId, string collateralReference, string ChasisNumber)
        {
            var result = new SearchViewModels
            {
                searchResult = new List<SearchResult>(0)
            };

            var data = base.oApiService.loanManager.GetLoanInformation(clienteName, identificationNumber, quotationId, accountId, collateralReference, ChasisNumber);
            var recordList = data.dataResult;

            if (recordList != null)
            {
                result = new SearchViewModels
                {
                    searchResult = recordList.Select(r => new SearchResult
                    {
                        Name = r.FullName,
                        Identification = r.IdentificationNumber,
                        LoanNumber = r.accountId.ToString(),
                        RequestNumber = r.quotationId.ToString(),
                        account = r.account,
                        _dataRequest = Utility.URLEncrypt(KSI.Cobranza.Web.Common.Utility.serializeToJSON(new dataRequest
                        {
                            account = r.account.Replace(" ","").Trim().TrimEnd().TrimStart(),
                            accountId = r.accountId,
                            CustomerId = r.relatedContactId,
                            RequestId = r.quotationId
                        })),
                        PhoneNumber = !string.IsNullOrEmpty(r.AreaCode) && !string.IsNullOrEmpty(r.Phone) ? string.Format("({0}) {1}", r.AreaCode.Replace(" ", ""), r.Phone.Replace(" ", "")) : string.Empty
                    })
                };
            }

            return
               result;
        }
    }
}