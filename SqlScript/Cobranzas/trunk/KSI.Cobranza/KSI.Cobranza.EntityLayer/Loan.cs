using System;
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
        }
    }
}
