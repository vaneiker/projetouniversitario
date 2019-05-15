using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace STL.POS.Data
{
    [Table("PERSONS_HEALTH")]
    public class PersonHealth:Person
    {
        public string Relationship { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public bool? IsStudent { get; set; }
        public decimal? Prime { get; set; }       
        public string Income { get; set; }

        //Aditional information
        public string WorkAddress { get; set; }
        public string PartnerName { get; set; }

        //Preconditions
        public bool? IsSmoker { get; set; }
        public bool? IsHighPressure { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public bool IsExtremeAthlete { get; set; }

        public string Condition1 { get; set; }
        public string Condition1Description { get; set; }
        public string Condition2 { get; set; }
        public string Condition2Description { get; set; }
        public string Condition3 { get; set; }
        public string Condition3Description { get; set; }

        //ADITIONALS
        public bool Complication { get; set; }
        public bool Transplant { get; set; }

        public ST_GLOBAL_CITY WorkCity { get; set; }
        public ST_GLOBAL_COUNTRY WorkNationality { get; set; }
    }
}