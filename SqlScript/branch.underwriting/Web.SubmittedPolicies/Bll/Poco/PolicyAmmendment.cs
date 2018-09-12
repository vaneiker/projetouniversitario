using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.SubmittedPolicies.Bll.Poco
{
    public class PolicyAmmendment
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
        public int Ammendment_Id { get; set; }
        public int Ammendment_Type_Id { get; set; }
        public string Ammend_Type_Desc { get; set; }
        public int Insured_Scope_Id { get; set; }
        public string Insured_Scope_Desc { get; set; }
        public string Comments { get; set; }
        public Nullable<int> Ammendment_Det_Id { get; set; }
        public Nullable<int> Doc_Type_Id { get; set; }
        public Nullable<int> Doc_Category_Id { get; set; }
        public Nullable<int> Document_Id { get; set; }
        public Nullable<System.DateTime> Uploaded_On { get; set; }
        public Nullable<bool> Is_Completed { get; set; }
        public string Status_Desc { get; set; }
        public string Uploaded_On_F
        {
            get{return Uploaded_On.HasValue ? Uploaded_On.Value.ToString("MM/dd/yyy") : "";}
        }
    }
}