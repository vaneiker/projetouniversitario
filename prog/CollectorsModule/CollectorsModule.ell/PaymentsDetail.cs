using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class PaymentsDetail
    {
        public PolicyID PolicyId { get; set; }
        public Int32 Payment_Id { get; set; }
        public Int32 Relationship_To_Owner_Or_Insured { get; set; }
        public Int32 PaymentDet_Id { get; set; }
        public Int32? Receipt_Type_Id { get; set; }
        public Int32 Payment_Source_Type_Id { get; set; }
        public Int32 Payment_Source_Id { get; set; }
        public Int32 Account_Type_Id { get; set; }
        public Int32 Payment_Control_Id { get; set; }
        public String Payment_Detail_Source_Id { get; set; }
        public Int32 Currency_Id { get; set; }
        public Int32? Doc_Type_Id { get; set; }
        public Int32? Doc_Category_Id { get; set; }
        public Int32? Document_Id { get; set; }
        public Decimal Origin_Credit_Amount { get; set; }
        public Decimal Origin_Debit_Amount { get; set; }
        public Decimal Usd_Credit_Amount { get; set; }
        public Decimal Usd_Debit_Amount { get; set; }
        public Decimal Rate { get; set; }
        public DateTime? Transaction_Date { get; set; }
        public DateTime? Due_Date { get; set; }
        public Decimal? Posted_Amount { get; set; }
        public DateTime? Posted_Date { get; set; }
        public DateTime? Receipt_Date { get; set; }
        public String Transaction_Description { get; set; }
        public String Transaction_Reference { get; set; }
        public DateTime? EFT_Date { get; set; }
        public String EFT_ABA_Number { get; set; }
        public String EFT_Account_Number { get; set; }
        public String EFT_Account_Holder { get; set; }
        public String EFT_Account_Holder_Source { get; set; }
        public String Other_Description { get; set; }
        public String Result_Code { get; set; }
        public Int32 Payment_Status_Id { get; set; }
        public Boolean Payment_Status { get; set; }
        public Int32? Seq_No { get; set; }
        public Int32? Type_Id { get; set; }
        public DateTime? Effective_Date { get; set; }
        public DateTime? Expire_Date { get; set; }
        public String Number { get; set; }
        public String Control_Digit { get; set; }
        public String Name { get; set; }
        public Boolean Status { get; set; }
        public Int32 UserId { get; set; }
        public String OrderId { get; set; }
    }

    public class PaymentsDetailResult
    {
        public PolicyID PolicyId { get; set; }
        public Nullable<int> Payment_Id { get; set; }
        public Nullable<int> PaymentDet_Id { get; set; }
        public Nullable<int> Seq_No { get; set; }
    }
}
