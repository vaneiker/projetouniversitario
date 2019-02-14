using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class BanksType
    {
        public int DEX_ROW_ID { get; set; }
        public string BANKID { get; set; }
        public string BANKNAME { get; set; }

        public class Checkbook
        {
            //BEFORE CHECKBOOK IMPLEMENTATION
            public int Checkbook_Id { get; set; }
            public string Checkbook_Name { get; set; }
            public string Bank_Account { get; set; }
            public string Bank_Name_Desc { get; set; }
            public string Currency_ISO { get; set; }
            public int Checkbook_Status { get; set; }
            public DateTime Create_Date { get; set; }
            public string CHECKBOOK_INFO { get; set; }
        }
    }
}
