using System.ComponentModel.DataAnnotations.Schema;

namespace STL.POS.Data
{
    [Table("CHANGE_RATES")]
    public class ChangeRate
    {

        public int Id { get; set; }

        public decimal Rate { get; set; }

    }
}