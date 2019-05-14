using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class ProductTypeBrochure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductTypeFamilyBrochure_Id { get; set; }
        public string Elegibilidad { get; set; }
        public string Deducible { get; set; }
        public string Coberturas { get; set; }
    }
}
