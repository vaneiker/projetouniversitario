using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class Agentes
    {
        [Display(Name = "Agent id")]
        public int Agent_id { get; set; }
        [Display(Name = "Agent Code")]
        public string Agent_Code { get; set; }
        [Display(Name = "Full Name")]
        public string Name { get; set; }

   
     }
}
