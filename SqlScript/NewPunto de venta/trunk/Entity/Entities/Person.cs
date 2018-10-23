﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Person : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool IsPrincipal { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public string WorkPhone { get; set; }
        public string MaritalStatus { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public Nullable<int> YearsInCompany { get; set; }
        public string Sex { get; set; }
        public int City_Country_Id { get; set; }
        public int City_Domesticreg_Id { get; set; }
        public int City_State_Prov_Id { get; set; }
        public int City_City_Id { get; set; }
        public Nullable<int> Nationality_Global_Country_Id { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public Nullable<bool> ForeignLicense { get; set; }
        public Nullable<System.DateTime> IdentificationNumberValidDate { get; set; }
        public Nullable<int> InvoiceTypeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> Modi_Date { get; set; }
        public string PostalCode { get; set; }
        public Nullable<decimal> AnnualIncome { get; set; }
        public Nullable<int> SocialReasonId { get; set; }
        public Nullable<int> OwnershipStructureId { get; set; }
        public Nullable<int> IdentificationFinalBeneficiaryOptionsId { get; set; }
        public Nullable<int> PepFormularyOptionsId { get; set; }
        public Nullable<bool> Home_Owner { get; set; }
        public Nullable<int> QtyPersonsDepend { get; set; }
        public Nullable<int> QtyEmployees { get; set; }
        public string Linked { get; set; }
        public string Segment { get; set; }
        public string Fax { get; set; }
        public string URL { get; set; }
        public string CityDesc { get; set; }
        public string MunicipioDesc { get; set; }
        public string GlobalCountryDesc { get; set; }
        public string GlobalCountryDescEN { get; set; }
        public string StateProvDesc { get; set; }
        public string SocialReasonDesc { get; set; }
        public string PepFormularyOptionsDesc { get; set; }
        public string OwnershipStructureDesc { get; set; }
        public string IdentificationFinalBeneficiaryOptionsDesc { get; set; }
        public string strForeignLicense { get; set; }
        public Nullable<int> municipality_Id { get; set; }
        public string NationalityGlobalCountryDesc { get; set; }
        public string WorkAddress { get; set; }
        public string PlaceOfBirth { get; set; }
        public Nullable<int> TypeOfPerson { get; set; }
        public string ManagerName { get; set; }

        public Nullable<int> ManagerPepOptionId { get; set; }

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

        public class PersonParameters
        {
            public Nullable<int> id { get; set; }
            public string firstName { get; set; }
            public string secondName { get; set; }
            public string firstSurname { get; set; }
            public string secondSurname { get; set; }
            public Nullable<System.DateTime> dateOfBirth { get; set; }
            public Nullable<bool> isPrincipal { get; set; }
            public string address { get; set; }
            public string phoneNumber { get; set; }
            public string mobile { get; set; }
            public string workPhone { get; set; }
            public string maritalStatus { get; set; }
            public string job { get; set; }
            public string company { get; set; }
            public Nullable<int> yearsInCompany { get; set; }
            public string sex { get; set; }
            public Nullable<int> country_Id { get; set; }
            public Nullable<int> domesticreg_Id { get; set; }
            public Nullable<int> state_Prov_Id { get; set; }
            public Nullable<int> city_Id { get; set; }
            public Nullable<int> nationalityGlobalCountry_Id { get; set; }
            public string email { get; set; }
            public string identificationType { get; set; }
            public string identificationNumber { get; set; }
            public Nullable<bool> foreignLicense { get; set; }
            public Nullable<System.DateTime> identificationNumberValidDate { get; set; }
            public Nullable<int> invoiceTypeId { get; set; }
            public string postalCode { get; set; }
            public Nullable<decimal> annualIncome { get; set; }
            public Nullable<int> socialReasonId { get; set; }
            public Nullable<int> ownershipStructureId { get; set; }
            public Nullable<int> identificationFinalBeneficiaryOptionsId { get; set; }
            public Nullable<int> pepFormularyOptionsId { get; set; }
            public Nullable<bool> home_Owner { get; set; }
            public Nullable<int> qtyPersonsDepend { get; set; }
            public Nullable<int> qtyEmployees { get; set; }
            public string linked { get; set; }
            public string segment { get; set; }
            public string fax { get; set; }
            public string uRL { get; set; }
            public Nullable<int> userId { get; set; }
            public string WorkAddress { get; set; }
            public string PlaceOfBirth { get; set; }
            public Nullable<int> TypeOfPerson { get; set; }
            public string ManagerName { get; set; }
            public Nullable<int> ManagerPepOptionId { get; set; }
        }


        public class PersonUbication
        {
            public int Corp_Id { get; set; }
            public int Region_Id { get; set; }
            public int Country_Id { get; set; }
            public int Domesticreg_Id { get; set; }
            public int State_Prov_Id { get; set; }
            public int City_Id { get; set; }
            public string Region_Desc { get; set; }
            public string Country_Desc { get; set; }
            public string Country_Desc_ES { get; set; }
            public string Domesticreg_Desc { get; set; }
            public string State_Prov_Desc { get; set; }
            public string City_Desc { get; set; }
            public int UbicacionId { get; set; }

        }


        public class DefaultClient
        {
            public string TypeClient { get; set; }
            public string Name { get; set; }
            public string DateOfBirth { get; set; }
            public string Sex { get; set; }
            public string IdentificationType { get; set; }
        }
    }
}