using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class Pais
    {
        public int Global_Country_Id { get; set; }
        public string Global_Country_Desc { get; set; }
        public string Global_Country_Desc_EN { get; set; }
        public int Domesticreg_Id { get; set; }
    }
    public class PaisSysFlex
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
