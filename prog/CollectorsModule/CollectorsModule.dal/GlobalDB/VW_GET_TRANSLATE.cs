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
    
    public partial class VW_GET_TRANSLATE
    {
        public int Language_Id { get; set; }
        public int Literal_Id { get; set; }
        public string Literal_Desc { get; set; }
        public int Destiny_Language_Id { get; set; }
        public string Translated_Literal { get; set; }
    }
}
