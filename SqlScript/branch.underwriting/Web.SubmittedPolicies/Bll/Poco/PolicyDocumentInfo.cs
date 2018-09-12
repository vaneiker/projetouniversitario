using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SubmittedPolicies.Bll.Poco
{
    public class  PolicyDocumentInfo
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
        public System.DateTime Effective_Date { get; set; }
        public string Product_Desc { get; set; }
        public string Currency_Desc { get; set; }
        public string Monthly_Anniversary { get; set; }
        public System.DateTime Expiration_Date { get; set; }
        public Nullable<decimal> Initial_Premium { get; set; }
        public Nullable<decimal> Periodic_Premium { get; set; }
        public Nullable<decimal> Insured_Amount { get; set; }
        public string Rider { get; set; }
        public string RiderADB { get; set; }
        public string RiderSEGTEMAD { get; set; }
        public string RiderSPINS { get; set; }
        public string Owner_Address { get; set; }
        public string Owner_Id { get; set; }
        public string Insured_Address { get; set; }
        public string Insured_Id { get; set; }
        public string Beneficiary { get; set; }
        public string BeneficiaryContingent { get; set; }
        public string Owner_FullName { get; set; }
        public string Insured_FullName { get; set; }
        public Nullable<int> Insured_Age { get; set; }
        public Nullable<bool> Insured_Smoker { get; set; }
        public Nullable<int> Contribution_Years { get; set; }
        public int Insured_Periodic { get; set; }
        public string Payment_Freq_Type_Desc { get; set; }
        public int Rate_Return { get; set; }
        public string Insured_Gender { get; set; }
        

        #region Formatted Fields
        public String Initial_Premium_F
        {
            get { return Initial_Premium.HasValue ? Initial_Premium.Value.ToString("C2") : "-"; }
        }
        public String Periodic_Premium_F
        {
            get { return Periodic_Premium.HasValue ? Periodic_Premium.Value.ToString("C2") : "-"; }
        }
        public String Insured_Amount_F
        {
            get { return Insured_Amount.HasValue ? Insured_Amount.Value.ToString("C2") : "-"; }
        }
        public String Insured_Age_F
        {
            get { return Insured_Age.HasValue ? Insured_Age.Value.ToString("N0") : "-"; }
        }
        public String Insured_Smoker_F
        {
            get { return Insured_Smoker.HasValue ? (Insured_Smoker.Value ? "Si" : "No") : "No"; }
        }
        public String Contribution_Years_F
        {
            get { return Contribution_Years.HasValue ? Contribution_Years.Value.ToString("N0") : "-"; }
        }
        public String Effective_Date_F
        {
            get { return Effective_Date.ToString("MM/dd/yyyy"); }
        }
        public String Expiration_Date_F
        {
            get { return Expiration_Date.ToString("MM/dd/yyyy"); }
        }
        public String Insured_Periodic_F
        {
            get { return Insured_Periodic.ToString("N0"); }
        }
        public String Rate_Return_F
        {
            get { return Rate_Return.ToString("N2"); }
        }
        #endregion
    }
}