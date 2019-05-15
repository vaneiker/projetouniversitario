using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class IdentificationFinalBeneficiaryOptions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Allowed { get; set; }
        public Nullable<bool> Includeforcompanyornot { get; set; }
    }
}
