using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class Payment
    {
        public int Corp_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public int Domesticreg_Id { get; set; }
        public int State_Prov_Id { get; set; }
        public int City_Id { get; set; }
        public int Office_Id { get; set; }
        public int Case_Seq_No { get; set; }
        public int Hist_Seq_No { get; set; }
        public string Policy_No { get; set; }
        public int? Bussiness_Line_Id { get; set; }
        public int? Bussiness_Line_Type { get; set; }
        public string Bl_Desc { get; set; }
        public string Product_Desc { get; set; }
        public int? Product_Id { get; set; }
        public int? Currency_Id { get; set; }

        public Decimal? PendingAmount { get; set; }
        public Decimal? TotalDueAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Annual_Premium { get; set; }

        public Nullable<int> Payment_Id { get; set; }
        public string AuthorizationCode { get; set; }
        public string CreditCardLast4 { get; set; }
        public string ResponseCode { get; set; }
        public Decimal? DueAmount { get; set; }
        public Decimal? Periodic_Premium_Amount { get; set; }
        public Decimal? Base_Premium { get; set; }
        public Decimal? Exceptional_premium { get; set; }
        public Decimal? Exceptional_premium2 { get; set; }
        public Decimal? Base_Commision { get; set; }
        public Decimal? Base_Commision2 { get; set; }
        public Decimal? Exceptional_Commisions { get; set; }
        public Decimal? Exceptional_Commisions2 { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public Int32? Payment_Status_Id { get; set; }
        public string PaymentNumber { get; set; }
        public string Full_Name { get; set; }
        public decimal CustomerBalance { get; set; }
        public Int32? UserId { get; set; }
        public string KwikTag { get; set; }
        public string Cashier { get; set; }
        public string Payment_Form { get; set; }
        public string Comments { get; set; }
    }

    public class PaymentsResult
    {
        public string Action { get; set; }
        public int Corp_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public int Domesticreg_Id { get; set; }
        public int State_Prov_Id { get; set; }
        public int City_Id { get; set; }
        public int Office_Id { get; set; }
        public int Case_Seq_No { get; set; }
        public int Hist_Seq_No { get; set; }
        public string Policy_No { get; set; }
        public Nullable<int> Payment_Id { get; set; }
        public string PaymentNumber { get; set; }
        public decimal CustomerBalance { get; set; }
        public bool result { get; set; }
        public string KwikTag { get; set; }
    }

    public class ktPayment
    {
        public string Additional_Info { get; set; }
        public string PaymentNumber { get; set; }
        public string Barcode { get; set; }
        public string Batch { get; set; }
    }

    public class DailyCashDetails
    {
        public string GP_PAYMENT_NUMBER { get; set; }
        public string POLICY_NUMBER { get; set; }
        public string CUSTNAME { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public string PAYMENT_DATE { get; set; }
        public string PAYMENT_HOUR { get; set; }
        public DateTime PAYMENT_DATETIME { get; set; }
        public decimal PAYMENT_AMOUNT { get; set; }
        public string CHECKBOOK_ID { get; set; }
        public string GP_STATUS { get; set; }
    }
}
