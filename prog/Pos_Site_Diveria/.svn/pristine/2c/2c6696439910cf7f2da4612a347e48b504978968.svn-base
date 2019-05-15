using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace STL.POS.Data
{
    [Table("CURRENCIES")]
    public class Currency
    {

        public const int ID_PESO_REP_DOMINICANA = 1;


        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string CardnetCode { get; set; }

        public string IsoCode { get; set; }

        public ICollection<ChangeRate> ChangeRates { get; set; }

    }
}