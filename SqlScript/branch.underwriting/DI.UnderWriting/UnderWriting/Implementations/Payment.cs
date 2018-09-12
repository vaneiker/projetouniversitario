using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class PaymentBll : IPayment
    {
        private PaymentManager _paymentManager;

        public PaymentBll()
        {
            _paymentManager = new PaymentManager();
        }

        Payment IPayment.GetPaymentHeader(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                _paymentManager.GetPaymentHeader(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo);
        }

        IEnumerable<Payment.Detail> IPayment.GetAllPaymentDetail(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId
            , int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int? paymentStatusId)
        {
            return
                _paymentManager.GetAllPaymentDetail(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, paymentStatusId);
        }

        Payment.DocumentInfomation IPayment.GetDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                 _paymentManager.GetDocument(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);
        }

        int IPayment.SetPaymentStatus(Payment.ApplyPayment payment)
        {
            return
                  _paymentManager.SetPaymentStatus(payment);
        }

        Payment.ApplyPayment IPayment.UpdatePayment(Payment.ApplyPayment payment)
        {
            return
                  _paymentManager.UpdatePayment(payment);
        }

        IEnumerable<Payment.ApplyPaymentDetail> IPayment.GetAllApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int paymentId, int languageId)
        {
            return
                 _paymentManager.GetAllApplyPaymentDetail(coprId, regionId, countryId, domesticRegId
                 , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, paymentId, languageId);
        }

        Payment.ApplyPayment IPayment.InsertPayment(Payment.ApplyPayment payment)
        {
            return
                  _paymentManager.InsertPayment(payment);
        }

        IEnumerable<Payment.ApplyPaymentDetail> IPayment.GetApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int paymentId, int paymentDetId, int languageId)
        {
            return
                _paymentManager.GetApplyPaymentDetail(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, paymentId, paymentDetId, languageId);
        }

        int IPayment.DeletePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            return
                  _paymentManager.DeletePaymentDetail(paymentDetail);
        }

        Payment.ApplyPaymentDetail IPayment.UpdatePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            return
                  _paymentManager.UpdatePaymentDetail(paymentDetail);
        }

        Payment.ApplyPaymentDetail IPayment.InsertPaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            return
                  _paymentManager.InsertPaymentDetail(paymentDetail);
        }

        Payment.ApplyPayment IPayment.GetPayment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int paymentId)
        {
            return
                 _paymentManager.GetPayment(coprId, regionId, countryId, domesticRegId
                 , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, paymentId);
        }

        int IPayment.InsertPaymentDetailDocument(Payment.Document doc)
        {
            return
                  _paymentManager.InsertPaymentDetailDocument(doc);
        }

        int IPayment.UpdatePaymentDetailDocument(Payment.Document doc)
        {
            return
                  _paymentManager.UpdatePaymentDetailDocument(doc);
        }

        int IPayment.InsertPaymentLog(Payment.Provider.Log log)
        {
            return
                _paymentManager.InsertPaymentLog(log);
        }

        IEnumerable<Payment.Provider.Parameter> IPayment.GetProviderParameter(Payment.Provider.Parameter parameter)
        {
            return
                 _paymentManager.GetProviderParameter(parameter);
        }

        Payment.Provider.Transaction IPayment.SetProviderTransaction(Payment.Provider.Transaction transaction)
        {
            return
                _paymentManager.SetProviderTransaction(transaction);
        }

        Payment.Provider.Transaction IPayment.GetProviderTransactionInfoKey(Payment.Provider.Transaction transaction)
        {
            return
                _paymentManager.GetProviderTransactionInfoKey(transaction);
        }

        Payment.Provider.Transaction IPayment.GetProviderTransactionByOrderId(Payment.Provider.Transaction transaction)
        {
            return
                _paymentManager.GetProviderTransactionByOrderId(transaction);
        } 

        int IPayment.UpdatePaymentDetailOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            return
                _paymentManager.UpdatePaymentDetailOrderId(paymentDetail);
        }

        Payment.Provider.Log IPayment.GetPaymentLog(Payment.Provider.Log log)
        {
            return
                _paymentManager.GetPaymentLog(log);
        }   

        int IPayment.SetPaymentDetailStatusByOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            return
                _paymentManager.SetPaymentDetailStatusByOrderId(paymentDetail);
        }

        Payment.Agreement IPayment.SetPaymentAgreement(Payment.Agreement parameter)
        {
            return
                _paymentManager.SetPaymentAgreement(parameter);
        }

        Payment.Agreement IPayment.GetPaymentAgreement(Payment.Agreement parameter)
        {
            return
                _paymentManager.GetPaymentAgreement(parameter);
        }


        IEnumerable<Payment.Agreement.Quot> IPayment.GetPaymentAgreementQuots(Payment.Agreement parameter)
        {
            return
                 _paymentManager.GetPaymentAgreementQuots(parameter);
        }
    }

    public class PaymentWS : IPayment
    {
        Payment IPayment.GetPaymentHeader(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Payment.Detail> IPayment.GetAllPaymentDetail(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int? paymentStatusId)
        {
            throw new NotImplementedException();
        }

        Payment.DocumentInfomation IPayment.GetDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            throw new NotImplementedException();
        }

        Payment.ApplyPayment IPayment.UpdatePayment(Payment.ApplyPayment payment)
        {
            throw new NotImplementedException();
        }

        Payment.ApplyPayment IPayment.InsertPayment(Payment.ApplyPayment payment)
        {
            throw new NotImplementedException();
        }

        int IPayment.SetPaymentStatus(Payment.ApplyPayment payment)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Payment.ApplyPaymentDetail> IPayment.GetAllApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int paymentId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Payment.ApplyPaymentDetail> IPayment.GetApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int paymentId, int paymentDetId, int languageId)
        {
            throw new NotImplementedException();
        }

        int IPayment.DeletePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            throw new NotImplementedException();
        }

        Payment.ApplyPaymentDetail IPayment.UpdatePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            throw new NotImplementedException();
        }

        Payment.ApplyPaymentDetail IPayment.InsertPaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            throw new NotImplementedException();
        }

        Payment.ApplyPayment IPayment.GetPayment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int paymentId)
        {
            throw new NotImplementedException();
        }

        int IPayment.InsertPaymentDetailDocument(Payment.Document doc)
        {
            throw new NotImplementedException();
        }

        int IPayment.UpdatePaymentDetailDocument(Payment.Document doc)
        {
            throw new NotImplementedException();
        }

        int IPayment.InsertPaymentLog(Payment.Provider.Log log)
        {
            throw new NotImplementedException();
        }

        Payment.Provider.Log IPayment.GetPaymentLog(Payment.Provider.Log log)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Payment.Provider.Parameter> IPayment.GetProviderParameter(Payment.Provider.Parameter parameter)
        {
            throw new NotImplementedException();
        }

        Payment.Provider.Transaction IPayment.SetProviderTransaction(Payment.Provider.Transaction transaction)
        {
            throw new NotImplementedException();
        }

        Payment.Provider.Transaction IPayment.GetProviderTransactionInfoKey(Payment.Provider.Transaction transaction)
        {
            throw new NotImplementedException();
        }

        Payment.Provider.Transaction IPayment.GetProviderTransactionByOrderId(Payment.Provider.Transaction transaction)
        {
            throw new NotImplementedException();
        }

        int IPayment.UpdatePaymentDetailOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            throw new NotImplementedException();
        }

        int IPayment.SetPaymentDetailStatusByOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            throw new NotImplementedException();
        }

        Payment.Agreement IPayment.SetPaymentAgreement(Payment.Agreement parameter)
        {
            throw new NotImplementedException();
        }

        Payment.Agreement IPayment.GetPaymentAgreement(Payment.Agreement parameter)
        {
            throw new NotImplementedException();
        }


        IEnumerable<Payment.Agreement.Quot> IPayment.GetPaymentAgreementQuots(Payment.Agreement parameter)
        {
            throw new NotImplementedException();
        }
    }
}
