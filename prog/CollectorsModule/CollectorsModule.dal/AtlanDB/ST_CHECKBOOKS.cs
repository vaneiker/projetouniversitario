//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollectorsModule.dal.AtlanDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ST_CHECKBOOKS
    {
        public int Checkbook_Id { get; set; }
        public string Checkbook_Name { get; set; }
        public string Bank_Account { get; set; }
        public string Bank_Name_Desc { get; set; }
        public string Currency_ISO { get; set; }
        public int Checkbook_Status { get; set; }
        public System.DateTime Create_Date { get; set; }
    }
}
