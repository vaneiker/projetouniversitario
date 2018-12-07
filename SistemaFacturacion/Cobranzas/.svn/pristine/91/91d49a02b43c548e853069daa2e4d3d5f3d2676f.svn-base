using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models
{
    public class QueueModel : BaseModel
    {
        public QueueModel() { }


        public List<ViewModels.QueueViewModels> GetLoansInQueue(Nullable<int> QueueTypeId =null, Nullable<int> AssingToId = null, Nullable<int> VendorId = null)
        {
            var result = new List<QueueViewModels>();


            var data = base.oApiService.loanManager.GetLoansInQueue(QueueTypeId, AssingToId, VendorId);

            var recordList = data.dataResult;

            if (recordList != null)
            {
                result = (from n in recordList
                          select new QueueViewModels
                          {
                                 ActionDate=n.ActionDate.HasValue? n.ActionDate.Value: DateTime.Now
                               , AmountFinanced=n.amountApproved.Value
                               , AmountOwed= n.monto.HasValue ? n.monto.Value : 0
                               , AssignTo=n.AssingTo
                               , Charge= n.Rate.HasValue ? n.Rate.Value : 0 
                               , CreditState =n.LoanStatusName
                               , CustomerFullName=n.ClientName
                               , ExecutiveName=n.ExecutiveFullName
                               , Id=n.AccountId.Value.ToString()
                               , InterestRate = n.Rate.HasValue ? n.Rate.Value : 0
                               , LoanNumber=n.loanNumber.Value.ToString()
                               , Office=n.officeName
                               , KindOfFollowup=""
                               , Product=n.ConceptTypeName
                               , QueuePosition=0
                               , ReferrerDepartment=n.DepartamentTransferred
                               , SponsorName=n.PromoterFullName
                               , Term=n.LoanTerm.Value
                               , Typeoftracking=""
                               , queueTypeId=n.QueueTypeId
                              , quotationId=n.quotationId
                              , relatedContactId=n.relatedContactId
                               , _dataRequest = Utility.URLEncrypt(KSI.Cobranza.Web.Common.Utility.serializeToJSON(new dataRequest
                                {
                                    account = n.AccountReference.Replace(" ", "").Trim().TrimEnd().TrimStart(),
                                    accountId = n.AccountId.Value,
                                    CustomerId =n.relatedContactId,
                                    RequestId = n.quotationId,
                                    QueueId=n.QueueId
                                })),
                          }).ToList();
            }

            return result;
        }
    }
}