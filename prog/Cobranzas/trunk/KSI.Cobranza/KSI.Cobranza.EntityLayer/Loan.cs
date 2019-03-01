﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.EntityLayer
{
    public class Loan
    {
        public long accountId { get; set; }
        public Nullable<long> quotationId { get; set; }
        public long relatedContactId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string SecondLastname { get; set; }
        public string FullName { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationName { get; set; }
        public string account { get; set; }
        public string AreaCode { get; set; }
        public string Phone { get; set; }


        public class CallUser
        {
            public int SecurityUserId { get; set; }
            public System.Guid UserIdForCallsRecording { get; set; }
            public string UserName { get; set; }
            public System.DateTime CreateDate { get; set; }
            public int CreateUsr { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public Nullable<int> ModiUsr { get; set; }
            public bool Active { get; set; }
            public bool IsDeleted { get; set; }

        }

        public class Queue
        {
            public Nullable<long> QueueId { get; set; }
            public string Action { get; set; }
        }

        public class BaseCases
        {
            public string Action { get; set; }
            public long relatedContactId { get; set; }
            public int MeetingTypeId { get; set; }
            public int MeetingSubTypeId { get; set; }
            public int MeetingCaseId { get; set; }
            public Nullable<long> accountId { get; set; }
            public int MeetingStatusId { get; set; }
            public Nullable<int> ReasonId { get; set; }
            public Nullable<int> DepartmentId { get; set; }
            public Nullable<int> CategoryId { get; set; }
            public Nullable<long> MeetingCaseNoteId { get; set; }
            public Nullable<int> PriorityId { get; set; }
            public string ServiceChannelDesc { get; set; }
            public Nullable<int> ServiceChannelId { get; set; }
            public Nullable<int> OriginatedById { get; set; }
            public Nullable<long> CaseNumber { get; set; }
            public Nullable<System.DateTime> MeetingDate { get; set; }
            public string MeetingShortNote { get; set; }
            public Nullable<int> CallAssignedId { get; set; }
            public string NotifiedToEmail { get; set; }
            public Nullable<bool> Notified { get; set; }
            public Nullable<int> AttemptNo { get; set; }
            public string MeetingDesc { get; set; }
            public string MeetingSubDesc { get; set; }
            public string ReasonDesc { get; set; }
            public string DepartamentDesc { get; set; }
            public string CategoryDesc { get; set; }
            public string PriorityDesc { get; set; }
            public string CallAssingName { get; set; }
            public string CreatedUserName { get; set; }
            public string ModifiedUserName { get; set; }
            public string FullName { get; set; }
            public string account { get; set; }
            public Nullable<int> CallCount { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public string Note { get; set; }
            public string MeetingStatusDesc { get; set; }
            public Nullable<System.DateTime> MeetingClosedDate { get; set; }
            public Nullable<long> QueueId { get; set; }
            public System.DateTime CreateDate { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public int CreateUsrId { get; set; }
            public Nullable<int> ModiUsrId { get; set; }
            public string hostName { get; set; }
        }

        public class Cases : BaseCases
        {
            public Nullable<int> NotesCount { get; set; }

            public class Detail : BaseCases
            {
                public class Calls : BaseCases
                {
                    public long MeetingCaseNoteCallId { get; set; }
                    public Nullable<System.TimeSpan> CallDuration { get; set; }
                    public Nullable<System.DateTime> CallStart { get; set; }
                    public Nullable<System.DateTime> CallStop { get; set; }
                    public string DialedNumber { get; set; }
                    public string Extension { get; set; }
                    public string FileName { get; set; }
                    public string FullPathFile { get; set; }
                    public string CallLogId { get; set; }
                    public string CallRexUserId { get; set; }
                    public string UserFirstName { get; set; }
                    public string UserLastName { get; set; }
                }

                public class File : BaseCases
                {
                    public Nullable<int> MeetingCaseNoteFileId { get; set; }                  
                    public Nullable<int> documentTypeGroupId { get; set; }
                    public string DocumentPath { get; set; }
                    public Nullable<decimal> SizeFile { get; set; }
                    public string documentName { get; set; }
                    public string MeetingCaseNoteFilecomments { get; set; }
                }
            }
        }

        public class Template
        {
            public short TemplateId { get; set; }
            public string TemplateName { get; set; }
            public string TemplateCode { get; set; }
            public string PartialViewName { get; set; }
            public string Description { get; set; }
            public string DocumentNameKey { get; set; }
            public Nullable<bool> isActive { get; set; }
            public System.DateTime CreateDate { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public int CreateUsrId { get; set; }
            public Nullable<int> ModiUsrId { get; set; }
            public string hostName { get; set; }
        }

        public class Correspondence
        {
            public Nullable<long> CaseNo { get; set; }
            public Nullable<short> CaseTypeId { get; set; }
            public string CanseTypeName { get; set; }
            public Nullable<short> DepartmentId { get; set; }
            public string DepartmentName { get; set; }
            public long accountID { get; set; }
            public string ConceptTypeName { get; set; }
            public string account { get; set; }
            public string EmailMainClient { get; set; }
            public string EmailAddClient { get; set; }
            public string EmailAgent { get; set; }
            public string EmailOffice { get; set; }
            public string EmailProvider { get; set; }
            public string EmailAdd { get; set; }
            public string clientName { get; set; }
            public string AgentFullName { get; set; }
            public string OficinaFullName { get; set; }

            public class RelatedDocuments
            {
                public class ResultHeader
                {
                    public Nullable<long> TemplateSentId { get; set; }
                    public string Action { get; set; }
                }

                public class ResultDetail
                {
                    public Nullable<long> TemplateSentRelatedFileId { get; set; }
                    public string Action { get; set; }
                }

                public class DeleteResult
                {
                    public long TemplateSentRelatedFileId { get; set; }
                    public Nullable<long> TemplateSentId { get; set; }
                    public string DocumentPath { get; set; }
                }

                public short TemplateId { get; set; }
                public long TemplateSentId { get; set; }
                public long AccountId { get; set; }
                public long ClienteId { get; set; }
                public Nullable<int> documentTypeGroupId { get; set; }
                public Nullable<int> documentGroupId { get; set; }
                public string TemplateName { get; set; }
                public string TemplateCode { get; set; }
                public string PartialViewName { get; set; }
                public string Description { get; set; }
                public string DocumentNameKey { get; set; }
                public Nullable<System.DateTime> SendDate { get; set; }
                public string ClientName { get; set; }
                public string DocumentPath { get; set; }
                public string documentName { get; set; }
                public string emails { get; set; }
                public string comments { get; set; }
                public string RelatedDocumentPath { get; set; }
                public string RelatedDocumentName { get; set; }
                public string RelatedComments { get; set; }
                public Nullable<bool> RelatedIsActive { get; set; }
                public string documentTypeGroupCode { get; set; }
                public string documentTypeGroupName { get; set; }
                public string documentGroupName { get; set; }
                public string documentGroupCode { get; set; }
                public Nullable<bool> isActive { get; set; }
                public System.DateTime CreateDate { get; set; }
                public Nullable<System.DateTime> ModiDate { get; set; }
                public int CreateUsrId { get; set; }
                public Nullable<int> ModiUsrId { get; set; }
                public string hostName { get; set; }
                public long TemplateSentRelatedFileId { get; set; }
                public Nullable<decimal> sizeFile { get; set; }
            }
        }

        public class CreditDebitDirectPayment
        {
            public Nullable<long> DirectPaymentId { get; set; }
            public string Action { get; set; }
        }

        public class Detail
        {
            public Nullable<long> quotationId { get; set; }
            public Nullable<int> LoanNumber { get; set; }
            public string fullName { get; set; }
            public long clientid { get; set; }
            public string identificationNumber { get; set; }
            public string LoanStatusName { get; set; }
            public string quotationPaymentTypeName { get; set; }
            public Nullable<int> frequency { get; set; }
            public string frequencyName { get; set; }
            public Nullable<int> loanTerm { get; set; }
            public Nullable<int> LoanDillingDay { get; set; }
            public string CurrencyName { get; set; }
            public Nullable<decimal> AmountRequested { get; set; }
            public Nullable<decimal> amountApproved { get; set; }
            public Nullable<decimal> financedAmount { get; set; }
            public Nullable<decimal> DisbursedAmount { get; set; }
            public Nullable<decimal> OutstandingBalance { get; set; }
            public Nullable<decimal> QuotaAmount { get; set; }
            public Nullable<decimal> RateAnnual { get; set; }
            public Nullable<decimal> RateMonth { get; set; }
            public Nullable<decimal> RateCommissionAnnual { get; set; }
            public Nullable<decimal> RateCommissionMonth { get; set; }
            public Nullable<decimal> RateLatenAnnual { get; set; }
            public Nullable<decimal> RateLateMonth { get; set; }
            public Nullable<System.DateTime> qoutationDate { get; set; }
            public Nullable<System.DateTime> ApprovedDate { get; set; }
            public Nullable<System.DateTime> disbursementDate { get; set; }
            public Nullable<System.DateTime> expirationDate { get; set; }
            public Nullable<System.DateTime> ClosedDate { get; set; }
            public Nullable<System.DateTime> LastClosedDate { get; set; }
            public Nullable<System.DateTime> LastQuotaDate { get; set; }
            public Nullable<System.DateTime> lastPaidDate { get; set; }
            public string fullNameExecutive { get; set; }
            public string fullNamePromoter { get; set; }
            public string account { get; set; }
            public long accountId { get; set; }
        }

        public class Vehicle
        {
            public int collateralFieldId { get; set; }
            public long collateralId { get; set; }
            public string collateralFieldName { get; set; }
            public string collateralFieldValue { get; set; }
            public Nullable<bool> ISRequired { get; set; }
            public string collateralFieldComment { get; set; }
        }
        public class Guarantee
        {
            public long accountId { get; set; }
            public long collateralId { get; set; }
            public string collateralName { get; set; }
            public string collateralTypeName { get; set; }
            public string collateralTypeSIBName { get; set; }
            public Nullable<decimal> percent { get; set; }
            public Nullable<decimal> amount { get; set; }
            public Nullable<long> contractNumber { get; set; }
            public string codeDesc { get; set; }
        }
        public class codeudor
        {
            public string account { get; set; }
            public long accountId { get; set; }
            public string accountStatusName { get; set; }
            public string accountName { get; set; }
            public string Fullname { get; set; }
            public string codebtorFullname { get; set; }
            public string codebtorIdentificationNumber { get; set; }
            public long codebtorClientId { get; set; }
            public long codebtorrelatedContactId { get; set; }
            public string codebtorTypeName { get; set; }
            public int companyId { get; set; }
            public long clientId { get; set; }
            public Nullable<int> codebtorTypeId { get; set; }
            public Nullable<bool> canDeposit { get; set; }
            public Nullable<bool> canWithdraw { get; set; }
            public Nullable<bool> canCancel { get; set; }
            public Nullable<bool> IsJointY { get; set; }
            public Nullable<bool> IsJointO { get; set; }
            public Nullable<bool> isActive { get; set; }
            public System.DateTime CreateDate { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public int CreateUsrId { get; set; }
            public Nullable<int> ModiUsrId { get; set; }
            public string hostName { get; set; }
        }
        public class PaymentPlan
        {
            public Nullable<int> Quota { get; set; }
            public Nullable<System.DateTime> QuotaDate { get; set; }
            public Nullable<decimal> CapitalBalance { get; set; }
            public Nullable<decimal> Capital { get; set; }
            public Nullable<decimal> Rate { get; set; }
            public Nullable<decimal> LoanRate { get; set; }
            public Nullable<decimal> FinancialQuota { get; set; }
            public Nullable<decimal> Commision { get; set; }
            public Nullable<decimal> Expense { get; set; }
            public Nullable<decimal> TotalPayment { get; set; }

        }

        public class LoanQueue
        {
            public long QueueId { get; set; }
            public Nullable<int> loanNumber { get; set; }
            public Nullable<long> AccountId { get; set; }
            public string ClientName { get; set; }
            public Nullable<decimal> amountApproved { get; set; }
            public Nullable<decimal> Rate { get; set; }
            public string ExecutiveFullName { get; set; }
            public string PromoterFullName { get; set; }
            public Nullable<int> LoanTerm { get; set; }
            public string LoanStatusName { get; set; }
            public string officeName { get; set; }
            public string ConceptTypeName { get; set; }
            public Nullable<decimal> monto { get; set; }
            public string QueueSourceDesc { get; set; }
            public string QueueTypeDesc { get; set; }
            public string QueueStatusDesc { get; set; }
            public string DistributionDesc { get; set; }
            public string DepartamentSubmitted { get; set; }
            public string DepartamentTransferred { get; set; }
            public string AssingTo { get; set; }
            public string TypeofTracking { get; set; }
            public int QueueTypeId { get; set; }
            public Nullable<int> DistributionId { get; set; }
            public Nullable<int> SubmittedByDepartmentId { get; set; }
            public Nullable<int> TransferredFromDepartmentId { get; set; }
            public Nullable<int> QueueStatusId { get; set; }
            public Nullable<long> VendorId { get; set; }
            public Nullable<long> AssingToId { get; set; }
            public Nullable<long> transactionPaymentPlanId { get; set; }
            public Nullable<int> QueueSourceId { get; set; }
            public string AccountReference { get; set; }
            public Nullable<int> DaysLate { get; set; }
            public Nullable<System.DateTime> ActionDate { get; set; }
            public Nullable<System.DateTime> EndDate { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public System.DateTime CreateDate { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public int CreateUsrId { get; set; }
            public Nullable<int> ModiUsrId { get; set; }
            public string hostName { get; set; }   
            public long quotationId { get; set; }    
            public long relatedContactId { get; set; }
            public string COMMENTS { get; set; }
        }
        public class PolicyInformation
        {
            public string policyTypeName { get; set; }
            public string FullName { get; set; }
            public string policyNo { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public Nullable<bool> isActive { get; set; }
            public string policyCollateralName { get; set; }
            public Nullable<System.DateTime> Date { get; set; }
            public Nullable<System.DateTime> EffectiveDate { get; set; }
            public string endorseNo { get; set; }
            public Nullable<decimal> endorseAmount { get; set; }
            public Nullable<System.DateTime> endorseInicialDate { get; set; }
            public Nullable<System.DateTime> endorseDate { get; set; }
            public Nullable<System.DateTime> endorseEffectiveDate { get; set; }
            public int collateralId { get; set; }
            public int companyId { get; set; }
            public Nullable<int> policyTypeId { get; set; }
            public Nullable<long> relatedContactId { get; set; }
            public string policyCollateralComment { get; set; }
            public Nullable<System.DateTime> notificationDate { get; set; }
            public System.DateTime CreateDate { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public int CreateUsrId { get; set; }
            public Nullable<int> ModiUsrId { get; set; }
            public string hostName { get; set; }
        }
        public class QuotaInformation
        {
            public long transactionPaymentPlanId { get; set; }
            public Nullable<int> quotaNumber { get; set; }
            public Nullable<System.DateTime> emisionQuotaDate { get; set; }
            public Nullable<System.DateTime> endQuotaDate { get; set; }
            public Nullable<decimal> validationTotal { get; set; }
            public Nullable<decimal> validationBalance { get; set; }
            public Nullable<bool> ISLastQuota { get; set; }
            public Nullable<bool> IsPrepayment { get; set; }
            public string transactionReasonName { get; set; }
            public string LoanStatusName { get; set; }
            public string fullName { get; set; }
            public Nullable<long> accountId { get; set; }
            public Nullable<int> loanNumber { get; set; }
            public Nullable<int> transactionReasonId { get; set; }
            public Nullable<decimal> capitalAmount { get; set; }
            public Nullable<decimal> interestAmoint { get; set; }
            public Nullable<decimal> commissionAmount { get; set; }
            public Nullable<decimal> expenseAmount { get; set; }
            public Nullable<decimal> rateLateAmount { get; set; }
            public Nullable<decimal> chargesPrepayment { get; set; }
            public Nullable<decimal> capitalBalance { get; set; }
            public Nullable<decimal> interestBalance { get; set; }
            public Nullable<decimal> commissionBalance { get; set; }
            public Nullable<decimal> expenseBalance { get; set; }
            public Nullable<decimal> rateLateBalance { get; set; }
            public int chargesPrepaymentBalance { get; set; }
            public Nullable<System.DateTime> dCapital { get; set; }
            public Nullable<System.DateTime> dInterestAmoint { get; set; }
            public Nullable<System.DateTime> dCommissionAmoun { get; set; }
            public Nullable<System.DateTime> dExpenseAmount { get; set; }
            public Nullable<System.DateTime> dRateLateAmount { get; set; }
            public Nullable<System.DateTime> dChargeAmount { get; set; }
            public Nullable<System.DateTime> dDiscountAmount { get; set; }
        }
        public class paymentProjection
        {
            public string Description { get; set; }
            public string Value { get; set; }
            public Nullable<int> TipoSaldo { get; set; }
            public string NameKey { get; set; }
        }
        public class PaymentAndDebts
        {
            public Nullable<int> QuotaNumber { get; set; }
            public Nullable<decimal> QuotaAmount { get; set; }
            public Nullable<decimal> QuotaAmountBalance { get; set; }
            public Nullable<System.DateTime> DueDate { get; set; }
            public Nullable<decimal> PaidAmount { get; set; }
            public decimal validationTotal { get; set; }
            public decimal capitalAmount { get; set; }
            public decimal interestAmoint { get; set; }
            public decimal commissionAmount { get; set; }
            public decimal expenseAmount { get; set; }
            public decimal rateLateAmount { get; set; }
            public Nullable<decimal> chargesPrepayment { get; set; }
            public Nullable<System.DateTime> emisionQuotaDate { get; set; }
            public Nullable<System.DateTime> PaidDate { get; set; }
            public Nullable<long> accountId { get; set; }
            public decimal AmountToPay { get; set; }
            public decimal LatePay { get; set; }
            public Nullable<decimal> Balance { get; set; }
        }
        public class CardDomitiliation
        {
            public long clientId { get; set; }
            public Nullable<long> accountId { get; set; }
            public int CardTypeId { get; set; }
            public string LastFourDigits { get; set; }
            public string CardNumber { get; set; }
            public Nullable<System.DateTime> ExpirationDate { get; set; }
            public string CVV2 { get; set; }
            public string CardHolder { get; set; }
            public string ExpirationDateYYMM { get; set; }
            public Nullable<bool> IsMain { get; set; }
            public Nullable<bool> ApplyRange { get; set; }
            public Nullable<System.DateTime> DateFrom { get; set; }
            public Nullable<System.DateTime> DateTo { get; set; }
            public Nullable<bool> isActive { get; set; }
            public Nullable<System.DateTime> CreateDate { get; set; }
            public Nullable<System.DateTime> ModiDate { get; set; }
            public Nullable<int> CreateUsrId { get; set; }
            public Nullable<int> ModiUsrId { get; set; }
            public string hostName { get; set; }
            public Nullable<bool> HasLoan { get; set; }
            public string CardTypeDesc { get; set; }


            public string StatusDesc { get; set; }
        }
        public partial class Document
        {
            public long accountId { get; set; }
            public int IdRequirement { get; set; }
            public int Sequence { get; set; }
            public int IdRequirementCategory { get; set; }
            public string RequirementCategory { get; set; }
            public int IdFormType { get; set; }
            public string FormType { get; set; }
            public int IdContractType { get; set; }
            public string ContractType { get; set; }
            public int IdDocumentType { get; set; }
            public string DocumentType { get; set; }
            public string RequireName { get; set; }
            public string Description { get; set; }
            public bool IsMandatory { get; set; }
            public string NameKey { get; set; }
            public string DocumentId { get; set; }
            public bool IsGeneratedBySystem { get; set; }
            public bool IsUploadedBySystem { get; set; }
            public int OrderGrid { get; set; }
            public string ModelNameForGeneration { get; set; }
            public string ModelNameForDownload { get; set; }
            public string DocumentName { get; set; }
            public string Extension { get; set; }
            public string Path { get; set; }
            public bool Validated { get; set; }
            public int ValidateUsr { get; set; }
            public bool IsValid { get; set; }
            public string Comment { get; set; }
            public int IdShortAnswer { get; set; }
            public string Observation { get; set; }
        }
    }
}