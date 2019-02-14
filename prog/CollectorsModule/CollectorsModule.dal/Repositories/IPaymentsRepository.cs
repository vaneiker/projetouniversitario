using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectorsModule.ell;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.AtlanDB;

namespace CollectorsModule.dal.Repositories
{
    public interface IPaymentsRepository : IDisposable
    {
        IQueryable<VW_GET_PAYMENT_HISTORY> getAllPaymentsHistory();
        IQueryable<VW_GET_PAYMENT_HISTORY> getPaymentsByFilter(PaymentHistory filters);
        bool processTransaction(Payment payment);
        IEnumerable<PaymentsResult> SetPayments(Payment payment);
        IEnumerable<AccountType> getListAccountType();
        IEnumerable<CreditCardType> getCardTypeList();
        List<PaymentsDetailResult> SetPaymentsDetails(PaymentsDetail detail, PolicyID policy);
        Currency getCurrencyByCurrencyID(int Currency_Id);
        BussinessLine getBusinessLineByLine_Id(int Business_Line_Id);
        ///GP Methods
        BussinessLine getBusinessLineByLineCodeGP(int BusinessLineCode);
        string getProductDescriptionByPlanTypeCodeGP(string PlanTypeCode);
        string getOfficeDescriptionByOfficeNumberCodeGP(int OFFICE_NUMBER);
        IQueryable<VW_ST_PMT_HISTORY> getAllPaymentHistoryGP();
        string getPaymentBatchByBarcode(string barcode);
        IEnumerable<ktPayment> getPaymentsByBatch(string batch);
        bool getHaveRecentPayments(string policy_no);
        IEnumerable<DailyCashDetails> getDailyCashPayments(string Collector, DateTime PaymentDate, int? PaymentType, DateTime PaymentDateTo);
    }
}
