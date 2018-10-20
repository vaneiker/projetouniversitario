using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    [Table("BUSINESS_LINE")]
    public class BusinessLine
    {

        public int  Id { get; set; }

        public int CoreId { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public ICollection<ProductTypeFamilyBrochure> ProducTypeFamiliesBrochure { get; set; }


    }
}
