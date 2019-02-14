using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class CreditCardType
    {
        public int Corp_Id { get; set; }
        public int Card_Type_Id { get; set; }
        public int Region_Id { get; set; }
        public int Country_Id { get; set; }
        public string Card_Type_Desc { get; set; }
        public bool Card_Type_Status { get; set; }

    }
}
