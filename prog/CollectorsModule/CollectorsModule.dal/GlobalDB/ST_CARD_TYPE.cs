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
    
    public partial class ST_CARD_TYPE
    {
        public int Corp_Id { get; set; }
        public int Card_Type_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public string Card_Type_Desc { get; set; }
        public Nullable<bool> Credit { get; set; }
        public Nullable<bool> Card_Type_Status { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public Nullable<System.DateTime> Modi_Date { get; set; }
        public Nullable<int> Create_UsrId { get; set; }
        public Nullable<int> Modi_UsrId { get; set; }
        public string Hostname { get; set; }
    }
}
