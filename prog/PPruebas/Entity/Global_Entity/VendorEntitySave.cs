using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Global_Entity
{
    public class VendorEntitySave
    {
        public int CorpId { get; set; }
        public int AgentId { get; set; }
        public bool NoCommission { get; set; }
        public bool TakeVendorId { get; set; }
        public string VendorId { get; set; }
        public bool AgentStatus { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> ModiDate { get; set; }
        public int CreateUsrId { get; set; }
        public Nullable<int> ModiUsrId { get; set; }
        public string Hostname { get; set; }
        
    }
}
