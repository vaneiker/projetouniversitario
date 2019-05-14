using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    [Table("[Global].ST_USAGE")]
    public class STUSAGE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Usage_Id { get; set; }

        public string Usage_Desc { get; set; }

        public string Usage_Message { get; set; }

        public int Allowed { get; set; }

        public string Name_Key { get; set; }

        public bool Usage_Status { get; set; }

        public DateTime Create_Date { get; set; }

        public DateTime? Modi_Date { get; set; }

        public int Create_UsrId { get; set; }

        public int? Modi_UsrId { get; set; }

        public string Hostname { get; set; }

        public Guid? ROW_ID { get; set; }
    }
}
