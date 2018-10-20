using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class CountryBusinessLine
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int CoreId { get; set; }
        public string bl_name { get; set; }
        public int Global_Country_Id { get; set; }
        public string Global_Country_Desc { get; set; }

    }
}
