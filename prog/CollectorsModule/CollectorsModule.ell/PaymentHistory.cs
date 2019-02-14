﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class PaymentHistory
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
        public int Payment_Id { get; set; }
        public Nullable<int> PaymentDet_Id { get; set; }
        public string Policy_No { get; set; }
        public string Bl_Desc { get; set; }
        public string Currency_Desc { get; set; }
        public string Office_Desc { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public Nullable<System.DateTime> Due_Date { get; set; }
        public Nullable<decimal> Due_Amount { get; set; }
        public Nullable<System.DateTime> Paid_Date { get; set; }
        public Nullable<decimal> Paid_Amount { get; set; }
        public Nullable<decimal> Usd_Credit_Amount { get; set; }
        public Nullable<System.DateTime> Transaction_Date { get; set; }
        public string Other_Description { get; set; }
        public string Order_Id { get; set; }
        public string Payment_Source_Type_Desc { get; set; }
        public int Payment_Status_Id { get; set; }
        public string Payment_Status_Desc { get; set; }
        public Nullable<int> Payment_Detail_Status_Id { get; set; }
        public string Payment_Detail_Status_Desc { get; set; }

        //Date Filters
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Office_Code { get; set; }
        public string Module {get; set;}
        public int Bl_Id { get; set; }
        public int Currency_Id { get; set; }
    }
}
