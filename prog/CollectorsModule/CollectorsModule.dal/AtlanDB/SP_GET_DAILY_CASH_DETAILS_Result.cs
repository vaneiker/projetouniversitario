//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollectorsModule.dal.AtlanDB
{
    using System;
    
    public partial class SP_GET_DAILY_CASH_DETAILS_Result
    {
        public string GP_PAYMENT_NUMBER { get; set; }
        public string POLICY_NUMBER { get; set; }
        public string CUSTNAME { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATETIME { get; set; }
        public string PAYMENT_DATE { get; set; }
        public string PAYMENT_HOUR { get; set; }
        public Nullable<decimal> PAYMENT_AMOUNT { get; set; }
        public string CHECKBOOK_ID { get; set; }
        public string GP_STATUS { get; set; }
    }
}