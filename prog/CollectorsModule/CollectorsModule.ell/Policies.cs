﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class Policies
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
        public DateTime? DueDate { get; set; }
        public Decimal? PendingAmount { get; set; }
        public Decimal? TotalDueAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? Annual_Premium { get; set; }
        public DateTime? Expiration_Date { get; set; }
        public string Policy_Status_Desc { get; set; }
    }

    public class PolicyID
    {
        public int? Corp_Id { get; set; }
        public int? Region_Id { get; set; }
        public int? Country_Id { get; set; }
        public int? Domesticreg_Id { get; set; }
        public int? State_Prov_Id { get; set; }
        public int? City_Id { get; set; }
        public int? Office_Id { get; set; }
        public int? Case_Seq_No { get; set; }
        public int? Hist_Seq_No { get; set; }
    }
}
