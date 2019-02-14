using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class Provider_Parammeters
    {
        public int Provider_Id { get; set; }
        public int Transaction_Type_Catalog_Id { get; set; }
        public int Provider_Transaction_Type_Id { get; set; }
        public int Parameter_Id { get; set; }
        public int Parameter_Type_Value_Id { get; set; }
        public string Parameter_Name { get; set; }
        public string Parameter_Value { get; set; }
        public string Parameter_Type_Value_Desc { get; set; }
        public decimal Order_By { get; set; }
    }

    public class Provider_Parammeters_Results
    {
        public string Action { get; set; }
        public Nullable<int> Provider_Id { get; set; }
        public Nullable<int> Transaction_Key_Id { get; set; }
    }
}
