using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KSI.Cobranza.Web.Models.ViewModels
{
    public class PersonalInformationViewModels : BaseViewModels
    {
        public long? CustomerId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string MarriedLastName { get; set; }
        public int IdMaritalStatus { get; set; }
        public string MaritalStatus { get; set; }
        public string SexDesc { get; set; }
        public int IdSex { get; set; }
        public int NoDepend { get; set; }
        public DateTime Dob { get; set; }
        public string CustomerType { get; set; }
        public string PersonType { get; set; }
        public Contact contact { get; set; }
        public Address address { get; set; }
        public IEnumerable<Phone> phones { get; set; }
        public IEnumerable<EmailAddress> emails { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(this.FirstName, " ", this.SurName, " ", this.FirstLastName, " ", this.SecondLastName);
            }
        }
    }

    public class Communication
    {
        public long? CustomerId { get; set; }
        [Required(ErrorMessage = "El campo Tipo es requerido")]
        public string Type { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class EmailAddress : Communication
    {
        public long contactEmailId { get; set; }
        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string address { get; set; }
        public bool IsActive { get; set; }
        public string Comments { get; set; }
        //public string EmailType { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> emailTypes { get; set; }
        public Statetrust.Framework.Security.Bll.Usuarios Usuario { get; set; }
    }

    public class Phone : Communication
    {
        public long contactPhoneId { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public string Number { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "El campo País es requerido")]
        public int countryID { get; set; }

        public string Comments { get; set; }
        public string AreaCoede { get; set; }
        public bool IsActive { get; set; }
        public Statetrust.Framework.Security.Bll.Usuarios Usuario { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> Countries { get; set; }
        public IEnumerable<BaseViewModels.KeyValue> phoneTypes { get; set; }
    }

    public class Address
    {
        public long? CustomerId { get; set; }
        public string address { get; set; }
        public string addressType { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Urbanization { get; set; }
        public string Sector { get; set; }
        public string location { get; set; }
    }

    public class Contact
    {
        public long? CustomerId { get; set; }
        public string Code { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}