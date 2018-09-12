using System.Collections.Generic;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IPayment
    {
        Payment GetPaymentHeader(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo);
        IEnumerable<Payment.Detail> GetAllPaymentDetail(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId
            , int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int? paymentStatusId);
        Payment.DocumentInfomation GetDocument(int coprId, int regionId, int countryId
         , int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId);
        Payment.ApplyPayment UpdatePayment(Payment.ApplyPayment payment);
        Payment.ApplyPayment InsertPayment(Payment.ApplyPayment payment);
        int SetPaymentStatus(Payment.ApplyPayment payment);
        IEnumerable<Payment.ApplyPaymentDetail> GetAllApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
          , int officeId, int caseSeqNo, int histSeqNo, int paymentId, int languageId);
        IEnumerable<Payment.ApplyPaymentDetail> GetApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int paymentId, int paymentDetId, int languageId);

        int DeletePaymentDetail(Payment.ApplyPaymentDetail paymentDetail);

        Payment.ApplyPaymentDetail UpdatePaymentDetail(Payment.ApplyPaymentDetail paymentDetail);
        Payment.ApplyPaymentDetail InsertPaymentDetail(Payment.ApplyPaymentDetail paymentDetail);

        Payment.ApplyPayment GetPayment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int paymentId);

        int InsertPaymentDetailDocument(Payment.Document doc);
        int UpdatePaymentDetailDocument(Payment.Document doc);

        int InsertPaymentLog(Payment.Provider.Log log);
        Payment.Provider.Log GetPaymentLog(Payment.Provider.Log log);
        IEnumerable<Payment.Provider.Parameter> GetProviderParameter(Payment.Provider.Parameter parameter);
        Payment.Provider.Transaction SetProviderTransaction(Payment.Provider.Transaction transaction);
        Payment.Provider.Transaction GetProviderTransactionInfoKey(Payment.Provider.Transaction transaction);
        Payment.Provider.Transaction GetProviderTransactionByOrderId(Payment.Provider.Transaction transaction);
        int UpdatePaymentDetailOrderId(Payment.ApplyPaymentDetail paymentDetail);
        int SetPaymentDetailStatusByOrderId(Payment.ApplyPaymentDetail paymentDetail);
        Payment.Agreement SetPaymentAgreement(Payment.Agreement parameter);
        Payment.Agreement GetPaymentAgreement(Payment.Agreement parameter);
        IEnumerable<Payment.Agreement.Quot> GetPaymentAgreementQuots(Payment.Agreement parameter);
    }
}
