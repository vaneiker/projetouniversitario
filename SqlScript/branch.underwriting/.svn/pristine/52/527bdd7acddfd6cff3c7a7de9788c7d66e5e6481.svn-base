using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SubmittedPolicies.Bll.Poco
{
    public class PolicyData
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
        public string OwnerFullName { get; set; }
        public Nullable<int> Country_Of_Residence_Id_Owner { get; set; }
        public string Country_Of_Residence_Desc_Owner { get; set; }
        public Nullable<int> Country_Of_Birth_Id_Owner { get; set; }
        public string Country_Of_Birth_Desc_Owner { get; set; }
        public Nullable<decimal> Annual_Personal_Income { get; set; }
        public string InsuredFullName { get; set; }
        public Nullable<int> Country_Of_Residence_Id_Insured { get; set; }
        public string Country_Of_Residence_Desc_Insured { get; set; }
        public Nullable<bool> Smoker_Insured { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public string Product_Desc { get; set; }
        public Nullable<decimal> Initial_Premium { get; set; }
        public Nullable<decimal> Insured_Amount { get; set; }
        public Nullable<decimal> Periodic_Premium { get; set; }
        public int Underwriter_Id { get; set; }
        public string Underwriter_Name { get; set; }
        public Nullable<int> Contribution_Years { get; set; }
        public Nullable<decimal> Annual_premiun { get; set; }
        public Nullable<bool> BackgroundCheckResult { get; set; }
        public string Smoker_Insured_Desc { get; set; }
        public string BackgroundCheckResult_Desc { get; set; }

        public String Annual_Personal_Income_F
        {
            get { return Annual_Personal_Income.HasValue ? Annual_Personal_Income.Value.ToString("C2") : "-"; }
        }
        public String ApplicationDate_F
        {
            get { return ApplicationDate.ToString("MM/dd/yyyy"); }
        }
        public String Initial_Premium_F
        {
            get { return Initial_Premium.HasValue ? Initial_Premium.Value.ToString("C2") : "-"; }
        }
        public String Insured_Amount_F
        {
            get { return Insured_Amount.HasValue ? Insured_Amount.Value.ToString("C2") : "-"; }
        }
        public String Periodic_Premium_F
        {
            get { return Periodic_Premium.HasValue ? Periodic_Premium.Value.ToString("C2") : "-"; }
        }
        public String Annual_premiun_F
        {
            get { return Annual_premiun.HasValue ? Annual_premiun.Value.ToString("C2") : "-"; }
        }
        public String Contribution_Years_F
        {
            get { return Contribution_Years.HasValue ? Contribution_Years.Value.ToString("N0") : "-"; }
        }
        
    }
}