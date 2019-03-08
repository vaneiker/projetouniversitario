using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class MovimientoCartera
    {
        [Display(Name = "Fecha final de supervisor actual")]
        public DateTime DateOut { get; set; }
        [Display(Name = "Fecha inicial de nuevo supervisor")]
        public DateTime DateIn { get; set; }
        [Display(Name = "Nota a colocar")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
          [DataType(DataType.MultilineText)]
        public string Agentes { get; set; }
        public string User { get; set; }

        [Display(Name = "Nuevo supervisor")]
        public int New_Supervisor_Agent_Id { get; set; }
        
        [Display(Name = "Nuevo Supervisor")]
        public int New_Supervisor_Agent_Code { get; set; }
        
        [Display(Name = "Agent id")]
        public int Agent_Ids { get; set; }
        public int Agent_id { get; set; }
        [Display(Name = "ID Core")]
        public int Agent_Codes { get; set; }

        [Display(Name = "Agent id")]
        public int Agent_id_M { get; set; }
        [Display(Name = "Agent Code")]
        public string Agent_Code_M { get; set; }
        [Display(Name = "Full Name")]
        public string Name_M { get; set; }

        public List<Agentes> ListAgentes { get; set; }
  

    }
}
