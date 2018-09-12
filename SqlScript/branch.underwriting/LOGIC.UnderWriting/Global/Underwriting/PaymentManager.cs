using System;
using System.Collections.Generic;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Common;

namespace LOGIC.UnderWriting.Global
{
    public class PaymentManager
    {
        private PaymentRepository _paymentRepository;
        private PolicyManager _policyManager;
        private string _msg;

        public PaymentManager()
        {
            _paymentRepository = SingletonUnitOfWork.Instance.PaymentRepository;
            _policyManager = new PolicyManager();
            _msg = "This property can't be under 0.";

        }

        public virtual Payment GetPaymentHeader(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo)
        {
            Payment pay;

            pay = _paymentRepository.GetHeader(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo);

            if (pay.MinimunPremiunAmountAnnual.HasValue)
                pay.MinimunPremiunAmountMonth = pay.MinimunPremiunAmountAnnual / 12;

            return
                pay;
        }

        public virtual IEnumerable<Payment.Detail> GetAllPaymentDetail(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId
            , int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int? paymentStatusId)
        {
            return
                 _paymentRepository.GetAllDetail(coprId, regionId, countryId, domesticRegId
                 , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, paymentStatusId);
        }

        public virtual Payment.DocumentInfomation GetDocument(int coprId, int regionId, int countryId
         , int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                 _paymentRepository.GetDocument(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);
        }

        public virtual IEnumerable<Payment.ApplyPaymentDetail> GetAllApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int paymentId, int languageId)
        {
            return
                 _paymentRepository.GetAllApplyPaymentDetail(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, paymentId, null, languageId);
        }

        public virtual IEnumerable<Payment.ApplyPaymentDetail> GetApplyPaymentDetail(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
           , int officeId, int caseSeqNo, int histSeqNo, int paymentId, int paymentDetId, int languageId)
        {
            return
                 _paymentRepository.GetAllApplyPaymentDetail(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, paymentId, paymentDetId, languageId);
        }

        public virtual Payment.ApplyPayment UpdatePayment(Payment.ApplyPayment payment)
        {
            this.IsValid(payment, Utility.DataBaseActionType.Update);

            return
                _paymentRepository.SetPayment(payment);
        }
        public virtual Payment.ApplyPayment InsertPayment(Payment.ApplyPayment payment)
        {
            this.IsValid(payment, Utility.DataBaseActionType.Insert);
            payment.PaymentId = -1;

            return
                _paymentRepository.SetPayment(payment);
        }

        public virtual int SetPaymentStatus(Payment.ApplyPayment payment)
        {
            this.IsValid(payment, Utility.DataBaseActionType.Update);

            return
                _paymentRepository.SetPaymentStatus(payment);
        }

        public virtual Payment.ApplyPaymentDetail UpdatePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            this.IsValid(paymentDetail, Utility.DataBaseActionType.Update);

            return
                _paymentRepository.SetPaymentDetail(paymentDetail);
        }
        public virtual Payment.ApplyPaymentDetail InsertPaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            Policy.PlanData policyData;
            this.IsValid(paymentDetail, Utility.DataBaseActionType.Insert);

            paymentDetail.PaymentDetId = -1;
            paymentDetail.SeqNo = null;
            policyData = _policyManager.GetPlanData(paymentDetail.CorpId, paymentDetail.RegionId, paymentDetail.CountryId, paymentDetail.DomesticregId, paymentDetail.StateProvId, paymentDetail.CityId, paymentDetail.OfficeId, paymentDetail.CaseSeqNo, paymentDetail.HistSeqNo);
            paymentDetail.CurrencyId = policyData.CurrencyId.GetValueOrDefault();

            return
                _paymentRepository.SetPaymentDetail(paymentDetail);
        }
        public virtual int DeletePaymentDetail(Payment.ApplyPaymentDetail paymentDetail)
        {
            this.IsValid(paymentDetail, Utility.DataBaseActionType.Delete);

            return
                _paymentRepository.DeletePaymentDetail(paymentDetail);
        }

        public virtual Payment.ApplyPayment GetPayment(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId
            , int officeId, int caseSeqNo, int histSeqNo, int paymentId)
        {
            return
                 _paymentRepository.GetPayment(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, paymentId);
        }

        public virtual int InsertPaymentDetailDocument(Payment.Document doc)
        {
            if (doc.PaymentDetId <= 0)
                throw new ArgumentException(_msg, "PaymentDetId");

            doc.DocumentId = null;

            return
                 _paymentRepository.SetPaymentDetailDocument(doc);
        }

        public virtual int UpdatePaymentDetailDocument(Payment.Document doc)
        {
            if (doc.PaymentDetId <= 0)
                throw new ArgumentException(_msg, "PaymentDetId");
            if (!doc.DocumentTypeId.HasValue || doc.DocumentTypeId.Value <= 0)
                throw new ArgumentException(_msg, "DocumentTypeId");
            if (!doc.DocumentCategoryId.HasValue || doc.DocumentCategoryId.Value <= 0)
                throw new ArgumentException(_msg, "DocumentCategoryId");
            if (!doc.DocumentId.HasValue || doc.DocumentId.Value <= 0)
                throw new ArgumentException(_msg, "DocumentId");

            return
                 _paymentRepository.SetPaymentDetailDocument(doc);
        }

        public virtual int SetPaymentDetailStatusByOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            paymentDetail.SeqNo = paymentDetail.UserId <= 0
                                    ? null
                                    : (int?)paymentDetail.UserId;

            return
                _paymentRepository.SetPaymentDetailStatusByOrderId(paymentDetail);
        }

        public virtual Payment.Agreement SetPaymentAgreement(Payment.Agreement parameter)
        {
            if (parameter.PaymentAgreementId <= 0)
                this.IsValid(parameter, Utility.DataBaseActionType.Insert);
            else
                this.IsValid(parameter, Utility.DataBaseActionType.Update);

            return
                _paymentRepository.SetPaymentAgreement(parameter);
        }

        public virtual Payment.Agreement GetPaymentAgreement(Payment.Agreement parameter)
        {
            this.IsValid(parameter, Utility.DataBaseActionType.Select);

            return
                _paymentRepository.GetPaymentAgreement(parameter);
        }


        public virtual IEnumerable<Payment.Agreement.Quot> GetPaymentAgreementQuots(Payment.Agreement parameter)
        {
            return
                 _paymentRepository.GetPaymentAgreementQuots(parameter);
        }

        #region Provider
        public virtual int InsertPaymentLog(Payment.Provider.Log log)
        {
            return
                 _paymentRepository.InsertPaymentLog(log);
        }
        public virtual Payment.Provider.Log GetPaymentLog(Payment.Provider.Log log)
        {
            if (string.IsNullOrWhiteSpace(log.OrderId))
                throw new ArgumentException(_msg, "OrderId");

            return
                _paymentRepository.GetPaymentLog(log);
        }
        public virtual IEnumerable<Payment.Provider.Parameter> GetProviderParameter(Payment.Provider.Parameter parameter)
        {
            if (parameter.ProviderId <= 0)
                throw new ArgumentException(_msg, "ProviderId");
            if (parameter.TransactionTypeCatalogId <= 0)
                throw new ArgumentException(_msg, "TransactionTypeCatalogId");
            if (parameter.ProviderTransactionTypeId <= 0)
                throw new ArgumentException(_msg, "ProviderTransactionTypeId");

            return
                 _paymentRepository.GetProviderParameter(parameter);
        }
        public virtual Payment.Provider.Transaction SetProviderTransaction(Payment.Provider.Transaction transaction)
        {
            if (transaction.ProviderId <= 0)
                throw new ArgumentException(_msg, "ProviderId");
            if (string.IsNullOrWhiteSpace(transaction.OrderId))
                throw new ArgumentException(_msg, "OrderId");
            //if (transaction.UserId <= 0)
            //    throw new ArgumentException(_msg, "UserId");

            return
                 _paymentRepository.SetProviderTransaction(transaction);
        }
        public virtual Payment.Provider.Transaction GetProviderTransactionInfoKey(Payment.Provider.Transaction transaction)
        {
            return
                _paymentRepository.GetProviderTransactionInfoKey(transaction);
        }
        public virtual Payment.Provider.Transaction GetProviderTransactionByOrderId(Payment.Provider.Transaction transaction)
        {
            if (string.IsNullOrWhiteSpace(transaction.OrderId))
                throw new ArgumentException(_msg, "OrderId");

            return
                 _paymentRepository.GetProviderTransactionByOrderId(transaction);
        }
        public virtual int UpdatePaymentDetailOrderId(Payment.ApplyPaymentDetail paymentDetail)
        {
            if (paymentDetail.PaymentDetId <= 0)
                throw new ArgumentException(_msg, "PaymentDetId");
            if (paymentDetail.UserId <= 0)
                throw new ArgumentException(_msg, "UserId");
            if (string.IsNullOrWhiteSpace(paymentDetail.OrderId))
                throw new ArgumentException(_msg, "OrderId");

            return
                _paymentRepository.UpdatePaymentDetailOrderId(paymentDetail);
        }
        #endregion

        private void IsValid(Payment.ApplyPaymentDetail paymentDetail, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (paymentDetail.CorpId <= 0)
                throw new ArgumentException(_msg, "CorpId");
            if (paymentDetail.RegionId <= 0)
                throw new ArgumentException(_msg, "RegionId");
            if (paymentDetail.CountryId <= 0)
                throw new ArgumentException(_msg, "CountryId");
            if (paymentDetail.DomesticregId <= 0)
                throw new ArgumentException(_msg, "DomesticregId");
            if (paymentDetail.StateProvId <= 0)
                throw new ArgumentException(_msg, "StateProvId");
            if (paymentDetail.CityId <= 0)
                throw new ArgumentException(_msg, "CityId");
            if (paymentDetail.OfficeId <= 0)
                throw new ArgumentException(_msg, "OfficeId");
            if (paymentDetail.CaseSeqNo <= 0)
                throw new ArgumentException(_msg, "CaseSeqNo");
            if (paymentDetail.HistSeqNo <= 0)
                throw new ArgumentException(_msg, "HistSeqNo");
            if (paymentDetail.PaymentId <= 0)
                throw new ArgumentException(_msg, "PaymentId");

            checkUserId = false;

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    if (paymentDetail.PaymentDetId <= 0)
                        throw new ArgumentException(_msg, "PaymentDetId");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    break;
            }

            if (checkUserId && paymentDetail.UserId <= 0)
                throw new ArgumentException(_msg, "UserId");
        }
        private void IsValid(Payment.ApplyPayment payment, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (payment.CorpId <= 0)
                throw new ArgumentException(_msg, "CorpId");
            if (payment.RegionId <= 0)
                throw new ArgumentException(_msg, "RegionId");
            if (payment.CountryId <= 0)
                throw new ArgumentException(_msg, "CountryId");
            if (payment.DomesticregId <= 0)
                throw new ArgumentException(_msg, "DomesticregId");
            if (payment.StateProvId <= 0)
                throw new ArgumentException(_msg, "StateProvId");
            if (payment.CityId <= 0)
                throw new ArgumentException(_msg, "CityId");
            if (payment.OfficeId <= 0)
                throw new ArgumentException(_msg, "OfficeId");
            if (payment.CaseSeqNo <= 0)
                throw new ArgumentException(_msg, "CaseSeqNo");
            if (payment.HistSeqNo <= 0)
                throw new ArgumentException(_msg, "HistSeqNo");

            checkUserId = false;

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    if (payment.PaymentId <= 0)
                        throw new ArgumentException(_msg, "PaymentId");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    break;
            }

            if (checkUserId && payment.UserId <= 0)
                throw new ArgumentException(_msg, "UserId");
        }

        private void IsValid(Payment.Agreement parameter, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (parameter.CorpId <= 0)
                throw new ArgumentException(_msg, "CorpId");
            if (parameter.RegionId <= 0)
                throw new ArgumentException(_msg, "RegionId");
            if (parameter.CountryId <= 0)
                throw new ArgumentException(_msg, "CountryId");
            if (parameter.DomesticregId <= 0)
                throw new ArgumentException(_msg, "DomesticregId");
            if (parameter.StateProvId <= 0)
                throw new ArgumentException(_msg, "StateProvId");
            if (parameter.CityId <= 0)
                throw new ArgumentException(_msg, "CityId");
            if (parameter.OfficeId <= 0)
                throw new ArgumentException(_msg, "OfficeId");
            if (parameter.CaseSeqNo <= 0)
                throw new ArgumentException(_msg, "CaseSeqNo");
            if (parameter.HistSeqNo <= 0)
                throw new ArgumentException(_msg, "HistSeqNo");

            checkUserId = false;

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    if (parameter.PaymentAgreementId <= 0)
                        throw new ArgumentException(_msg, "PaymentAgreementId");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    break;
            }

            if (checkUserId && parameter.UserId <= 0)
                throw new ArgumentException(_msg, "UserId");
        }
    }
}
