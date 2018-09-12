using System;
using System.Collections.Generic;

namespace Entity.UnderWriting.Entities
{
    public class Payment
    {
        public string PolicyNo { get; set; }
        public int CorpId { get; set; }
        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public int DomesticregId { get; set; }
        public int StateProvId { get; set; }
        public int CityId { get; set; }
        public int OfficeId { get; set; }
        public int CaseSeqNo { get; set; }
        public int HistSeqNo { get; set; }
        public int PaymentFreqTypeId { get; set; }
        public int PaymentFreqId { get; set; }
        public decimal? AnnualPremium { get; set; }
        public string PaymentFreqTypeDesc { get; set; }
        public decimal? PremiumRecieved { get; set; }
        public decimal? AccountAmount { get; set; }
        public decimal? PeriodicPremium { get; set; }
        public decimal? MinimunPremiunAmount { get; set; }
        public decimal? InitialContribution { get; set; }
        public DateTime? PolicyEffectiveDate { get; set; }
        public decimal? MinimunPremiunAmountAnnual { get; set; }
        public int? PolicyYear { get; set; }
        public string PaymentPlan { get; set; }
        public DateTime PaymentPlanEndDate { get; set; }
        public DateTime PaymentPlanStartDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool? PaymentStatus { get; set; }
        public decimal? PaymentAmount { get; set; }
        public decimal? MinimunPremiunAmountMonth { get; set; }
        public IEnumerable<Period> Periods { get; set; }

        public class Period
        {
            public string PayMonth { get; set; }
            public string PayDate { get; set; }
        }

        public class Detail
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int PaymentId { get; set; }
            public int PaymentStatusId { get; set; }
            public int? DocumentTypeId { get; set; }
            public int? DocumentCategoryId { get; set; }
            public int? DocumentId { get; set; }
            public DateTime? DueDate { get; set; }
            public DateTime? PaidDate { get; set; }
            public decimal? DueAmount { get; set; }
            public decimal? PaidAmount { get; set; }
            public string PaymentSourceDesc { get; set; }
            public string PaymentStatusDesc { get; set; }
            public string PolicyNo { get; set; }
            public bool HasDocument { get; set; }
        }

        public class DocumentInfomation
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int DocumentCategoryId { get; set; }
            public int DocumentTypeId { get; set; }
            public int DocumentId { get; set; }
            public string DocumentName { get; set; }
            public byte[] DocumentBinary { get; set; }
            public DateTime? FileCreationDate { get; set; }
            public string DocumentTypeDescription { get; set; }
            public string ContentType { get; set; }
            public string Extension { get; set; }
        }

        public class ApplyPayment
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int PaymentId { get; set; }
            public decimal? DueAmount { get; set; }
            public decimal? PeriodicPremiumAmount { get; set; }
            public decimal? BasePremium { get; set; }
            public decimal? ExceptionalPremiun { get; set; }
            public decimal? ExceptionalPremiun2 { get; set; }
            public decimal? BaseCommision { get; set; }
            public decimal? BaseCommision2 { get; set; }
            public decimal? ExceptionalCommisions { get; set; }
            public decimal? ExceptionalCommisions2 { get; set; }
            public DateTime? DueDate { get; set; }
            public DateTime? PaidDate { get; set; }
            public decimal? PaidAmount { get; set; }
            //public int PaymentStatus { get; set; }
            public int PaymentStatusId { get; set; }
            public int UserId { get; set; }
        }

        public class Agreement
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int PaymentAgreementId { get; set; }
            public int PaymentsAgreementQty { get; set; }
            public decimal DiscountPercentage { get; set; }
            public decimal DiscountAmount { get; set; }
            public string DiscountNameKey { get; set; }
            public decimal SurchargePercentage { get; set; }
            public decimal SurchargeAmount { get; set; }
            public string SurchargeNameKey { get; set; }
            public decimal InitialPayment { get; set; }
            public decimal TotalAgreementPayment { get; set; }
            public int ExternalId { get; set; }
            public int UserId { get; set; }

            public class Quot
            {
                public string TypeQty { get; set; }
                public int NumberOfQTy { get; set; }
                public decimal? ValueQty { get; set; }
            }
        }

        public class ApplyPaymentDetail
        {
            public int CorpId { get; set; }
            public int RegionId { get; set; }
            public int CountryId { get; set; }
            public int DomesticregId { get; set; }
            public int StateProvId { get; set; }
            public int CityId { get; set; }
            public int OfficeId { get; set; }
            public int CaseSeqNo { get; set; }
            public int HistSeqNo { get; set; }
            public int PaymentId { get; set; }
            public int RelationshipToOwnerOrInsured { get; set; }
            public int PaymentDetId { get; set; }
            public int? ReceiptTypeId { get; set; }
            public int? PaymentSourceId { get; set; }
            public string PaymentDetailSourceId { get; set; }
            public int CurrencyId { get; set; }
            public int? DocumentTypeId { get; set; }
            public int? DocumentCategoryId { get; set; }
            public int? DocumentId { get; set; }
            public decimal? OriginCreditAmount { get; set; }
            public decimal? OriginDebitAmount { get; set; }
            public decimal? UsdCreditAmount { get; set; }
            public decimal? UsdDebitAmount { get; set; }
            public decimal? Rate { get; set; }
            public DateTime? TransactionDate { get; set; }
            public DateTime? DueDate { get; set; }
            public decimal? PostedAmount { get; set; }
            public DateTime? PaidDate { get; set; }
            public DateTime? PostedDate { get; set; }
            public DateTime? ReceiptDate { get; set; }
            public string TransactionDescription { get; set; }
            public string TransactionReference { get; set; }
            public string EFTAccountNumber { get; set; }
            public string EFTAccountHolder { get; set; }
            public string EFTAccountHolderSource { get; set; }
            public string OtherDescription { get; set; }
            public string ResultCode { get; set; }
            public bool PaymentStatus { get; set; }
            public bool HasDocument { get; set; }
            public string ReceiptTypeDesc { get; set; }
            public string PaymentStatusDesc { get; set; }
            public string PaymentSourceDesc { get; set; }
            public string DocumentCategoryDesc { get; set; }
            public int? SeqNo { get; set; }
            public int? TypeId { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public DateTime? ExpireDate { get; set; }
            public string Number { get; set; }
            public string ControlDigit { get; set; }
            public string Name { get; set; }
            public bool? Status { get; set; }
            public string AccountDesc { get; set; }
            public string CardTypeDesc { get; set; }
            public int PaymentSourceTypeId { get; set; }
            public int AccountTypeId { get; set; }
            public int PaymentControlId { get; set; }
            public DateTime? EFTDate { get; set; }
            public string EFTABANumber { get; set; }
            public string PaymentDocumentation { get; set; }
            public int PaymentStatusId { get; set; }
            public int UserId { get; set; }
            public string OrderId { get; set; }            
        }

        public class Document
        {
            public int PaymentDetId { get; set; }
            public int? DocumentTypeId { get; set; }
            public int? DocumentCategoryId { get; set; }
            public int? DocumentId { get; set; }
            public byte[] DocumentBinary { get; set; }
            public string DocumentName { get; set; }
            public DateTime? FileCreationDate { get; set; }
            public DateTime? FileExpireDate { get; set; }
            public int UserId { get; set; }
        }        

        public class Provider
        {
            public class Parameter
            {
                public int ProviderId { get; set; }
                public int TransactionTypeCatalogId { get; set; }
                public int ProviderTransactionTypeId { get; set; }
                public int ParameterId { get; set; }
                public int ParameterTypeValueId { get; set; }
                public string ParameterName { get; set; }
                public string ParameterValue { get; set; }
                public string ParameterTypeValueDesc { get; set; }
                public decimal OrderBy { get; set; }                
            }

            public class Transaction
            {
                public int ProviderId { get; set; }
                public long? TransactionKeyId { get; set; }
                public int? TransactionTypeCatalogId { get; set; }
                public int? ProviderTransactionTypeId { get; set; }
                public string TransactionId { get; set; }
                public DateTime TransactionDate { get; set; }
                public string CreditCardNumber { get; set; }
                public string CreditCardExpirationDate { get; set; }
                public decimal? Amount { get; set; }
                public decimal? Tax { get; set; }
                public string ResponseCode { get; set; }
                public string AuthorizationCode { get; set; }
                public string RetrievalReferenceNumber { get; set; }
                public string OrderId { get; set; }
                public string TransactionExtraData { get; set; }
                public int? UserId { get; set; }
                public string Action { get; set; }
            }

            public class Log
            {
                public int LogTypeId { get; set; }
                public int? CorpId { get; set; }
                public int? CompanyId { get; set; }
                public int? ProjectId { get; set; }
                public string OrderId { get; set; }
                public string LogDesc { get; set; }
            }
        }
    }
}
