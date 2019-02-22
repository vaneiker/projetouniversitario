using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
   public class ST_VEHICLE_MAKE
    {
       [Key]
        public int Make_Id { get; set; }
        public string Make_Desc { get; set; }
        public bool Make_Status { get; set; }
        public bool Pos_Flag { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modi_Date { get; set; }
        public int Create_UsrId { get; set; }
        public int Modi_UsrId { get; set; }
        public string Hostname { get; set; }
        public int Row_Id { get; set; }
    }
}
