using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace STL.POS.Data
{
    [Table("DRIVERS")]
    public class Driver : Person
    {

        //Aditional information
        public int? YearsDriving { get; set; }
        public string AccidentsLast3Years { get; set; }

        //public int? UserId { get; set; }
        //public DateTime? Modi_Date { get; set; }

    }
}