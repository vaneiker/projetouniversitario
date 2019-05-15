using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    /// <summary>
    /// Product
    /// </summary>
    public class ProductWS
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public int? IdCapacidad { get; set; }
        public string DescCapacidad { get; set; }

        public int? IdUso { get; set; }
        public string DescUso { get; set; }

        public IList<CoverageWS> Coverages { get; set; }

    }
}
