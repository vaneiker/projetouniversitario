﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Global_Entity
{
   public class EN_AGENT_ENTITY
    {

        public int Corp_Id { get; set; }
        public int Agent_Id { get; set; }
        public int Agent_Type_Id { get; set; }
        public Nullable<int> Identity_Type_Id { get; set; }
        public int Agent_Sub_Type_Id { get; set; }
        public string ID { get; set; }
        public string Agent_Code { get; set; }
        public string Name_Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string First_Lastname { get; set; }
        public string Second_Lastname { get; set; }
        public string Full_Name { get; set; }
        public string Nickname { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public Nullable<int> Payment_Type_Id { get; set; }
        public string Aba_Number { get; set; }
        public Nullable<int> Bank_Account_Type_Id { get; set; }
        public string Bank_Account_Number { get; set; }
        public Nullable<decimal> Allocation { get; set; }
        public Nullable<int> Allocation_Type_Id { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Marital_Stat_Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> Residence_Country_Id { get; set; }
        public Nullable<int> Birth_Country_Id { get; set; }
        public Nullable<int> Citizenship_Country_Id { get; set; }
        public int Directory_Id { get; set; }
        public int Agent_Status_Id { get; set; }
        public Nullable<System.DateTime> Active_Date { get; set; }
        public Nullable<System.DateTime> Inactive_Date { get; set; }
        public string Referenced_By { get; set; }
        public Nullable<bool> Practice_Sports { get; set; }
        public string Sports_practiced { get; set; }
        public string Contact_Notes { get; set; }
        public string History_Notes { get; set; }
        public Nullable<int> Ubicacion { get; set; }
        public Nullable<int> Commission_Behavior_Id { get; set; }
        public Nullable<System.DateTime> Id_Expiration_Date { get; set; }
        public Nullable<int> Automatic_Cancellation_Days { get; set; }
        public Nullable<int> Expedient_Id { get; set; }
        public Nullable<int> Penalty_Qty { get; set; }
        public Nullable<decimal> Penalty_Amount { get; set; }
        public System.DateTime Create_Date { get; set; }
        public Nullable<System.DateTime> Modi_Date { get; set; }
        public int Create_UsrId { get; set; }
        public Nullable<int> Modi_UsrId { get; set; }
        public string Hostname { get; set; }
        public string Source_ID { get; set; }
        public string Kco_Unique_Id { get; set; }
    }
}
