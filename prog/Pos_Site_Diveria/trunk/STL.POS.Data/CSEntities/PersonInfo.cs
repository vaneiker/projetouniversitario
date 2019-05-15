using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    public class PersonInfo
    {
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

        public string PostalCode { get; set; }
        public decimal? AnnualIncome { get; set; }

        public int? SocialReasonId { get; set; }
        public int? OwnershipStructureId { get; set; }
        public int? IdentificationFinalBeneficiaryOptionsId { get; set; }
        public int? PepFormularyOptionsId { get; set; }

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

    }
}
