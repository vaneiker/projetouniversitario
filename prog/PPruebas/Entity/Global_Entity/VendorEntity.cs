using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Global_Entity
{
    public partial class VendorEntity
    {
        public int CorpId { get; set; }
        public int AgentId { get; set; }
        public bool NoCommission { get; set; }
        public bool TakeVendorId { get; set; }
        public string VendorId { get; set; }
        public bool AgentStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }
        public int CreateUsrId { get; set; }
        public int? ModiUsrId { get; set; }    
        public string Hostname { get; set; }
        public string Full_Name { get; set; }

       public class vendorEn
        {
            public int Corp_Id { get; set; }
            public int Agent_Id { get; set; }
            public bool No_Commission { get; set; }
            public bool Take_Vendor_Id { get; set; }
            public string Vendor_Id { get; set; }
            public bool Agent_Status { get; set; }
            public System.DateTime Create_Date { get; set; }
            public Nullable<System.DateTime> Modi_Date { get; set; }
            public int Create_UsrId { get; set; }
            public Nullable<int> Modi_UsrId { get; set; }
            public string Hostname { get; set; }
       
        }

    }
}
