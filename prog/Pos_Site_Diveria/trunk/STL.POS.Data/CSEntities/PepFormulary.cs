using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    
    public class PepFormulary
    {
        public int Id { get; set; }
        public int Persons_Pep { get; set; }
        public string Name { get; set; }
        public int? RelationshipId { get; set; }
        public string Position { get; set; }
        public int? FromYear { get; set; }
        public int? ToYear { get; set; }
        public Nullable<int> BeneficiaryId { get; set; }
        public bool IsPepManagerCompany { get; set; }
        public Nullable<int> PepFormularyOptionsId { get; set; }
    }
}
