using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    [Table("PERSONS")]
    public abstract class Person
    {

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string WorkPhone { get; set; }
        public string Mobile { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string MaritalStatus { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public int? YearsInCompany { get; set; }

        public Nullable<bool> ForeignLicense { get; set; }

        public Nullable<DateTime> IdentificationNumberValidDate { get; set; }

        public ST_GLOBAL_CITY City { get; set; }
        public ST_GLOBAL_COUNTRY Nationality { get; set; }

        public int? UserId { get; set; }
        public DateTime? Modi_Date { get; set; }


        public string PostalCode { get; set; }
        public decimal? AnnualIncome { get; set; }
        
        public SOCIAL_REASON SOCIALREASON { get; set; }
        public OWNERSHIP_STRUCTURE OWNERSHIPSTRUCTURE { get; set; }
        public IDENTIFICATION_FINAL_BENEFICIARY_OPTIONS IDENTIFICATIONFINALBENEFICIARYOPTIONS { get; set; }
        public PEP_FORMULARY_OPTIONS PEPFORMULARYOPTIONS { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + FirstSurname;
        }

        public string GetSexOneLetter()
        {
            return Sex == "Femenino" ? "F" : "M";
        }

        public int GetAge()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - DateOfBirth.Year;
            if (now < DateOfBirth.AddYears(age)) age--;
            return age;
        }
        /// <summary>
        /// I keep this property for helper purposes only. Is not mapped to DB.
        /// </summary>
        public bool IsPrincipal { get; set; }

        public int? InvoiceTypeId { get; set; }

        public bool? Home_Owner { get; set; }
        public int? QtyPersonsDepend { get; set; }
        public int? QtyEmployees { get; set; }
        public string Linked { get; set; }
        public string Segment { get; set; }
        public string Fax { get; set; }
        public string URL { get; set; }
    }
}
