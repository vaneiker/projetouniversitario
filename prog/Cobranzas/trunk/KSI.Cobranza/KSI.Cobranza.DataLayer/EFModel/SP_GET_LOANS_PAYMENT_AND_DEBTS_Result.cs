//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KSI.Cobranza.DataLayer.EFModel
{
    using System;
    
    public partial class SP_GET_LOANS_PAYMENT_AND_DEBTS_Result
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
}