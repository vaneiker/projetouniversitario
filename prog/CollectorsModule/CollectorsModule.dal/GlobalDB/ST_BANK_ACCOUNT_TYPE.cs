//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollectorsModule.dal.GlobalDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ST_BANK_ACCOUNT_TYPE
    {
        public int Corp_Id { get; set; }
        public int Bank_Account_Type_Id { get; set; }
        public string Bnk_Accnt_Type_Desc { get; set; }
        public bool Bnk_Accnt_Type_Status { get; set; }
        public System.DateTime Create_Date { get; set; }
        public Nullable<System.DateTime> Modi_Date { get; set; }
        public int Create_UsrId { get; set; }
        public Nullable<int> Modi_UsrId { get; set; }
        public string Hostname { get; set; }
    }
}
