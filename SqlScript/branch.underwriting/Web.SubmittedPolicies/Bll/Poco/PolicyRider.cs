using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SubmittedPolicies.Bll.Poco
{
    public class PolicyRider
    {
        public int Corp_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public int Domesticreg_Id { get; set; }
        public int State_Prov_Id { get; set; }
        public int City_Id { get; set; }
        public int Office_Id { get; set; }
        public int Case_seq_No { get; set; }
        public int Hist_Seq_No { get; set; }
        public int Rider_Type_Id { get; set; }
        public int Rider_id { get; set; }
        public string Ryder_Type_Desc { get; set; }
        public Nullable<decimal> Beneficiary_Amount { get; set; }
        public Nullable<System.DateTime> Effective_Date { get; set; }
        public Nullable<System.DateTime> Expire_Date { get; set; }
        public Nullable<int> Number_Of_Year { get; set; }
        public decimal? Extra_Premium { get; set; }
        public string Extra_Premium_Comments { get; set; }
        public int Rider_Status_Id { get; set; }
        public string Rider_Status_Desc { get; set; }

        public String Beneficiary_Amount_F
        {
            get { return Beneficiary_Amount.HasValue ? Beneficiary_Amount.Value.ToString("C2") : ""; }
        }
        public String Effective_Date_F
        {
            get { return Effective_Date.HasValue ? Effective_Date.Value.ToString("MM/dd/yyyy") : ""; }
        }

        public String Expire_Date_F
        {
            get { return Expire_Date.HasValue ? Expire_Date.Value.ToString("MM/dd/yyyy") : ""; }
        }

        public String Extra_Premium_F
        {
            get { return Extra_Premium.HasValue ? Extra_Premium.Value.ToString("C2") : ""; }
        }
    }
}