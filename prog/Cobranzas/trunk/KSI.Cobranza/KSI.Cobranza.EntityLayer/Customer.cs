using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.EntityLayer
{
    public class Customer
    {
        public long? clientId { get; set; }
        public long relatedContactId { get; set; }
        public Nullable<int> countryID { get; set; }
        public Nullable<int> entityRolId { get; set; }
        public Nullable<int> identificationTypeId { get; set; }
        public Nullable<int> entityClassId { get; set; }
        public Nullable<int> personTypeId { get; set; }
        public Nullable<int> maritalStatusId { get; set; }
        public Nullable<int> professionId { get; set; }
        public int companyId { get; set; }
        public Nullable<int> linkedTypeId { get; set; }
        public Nullable<int> clientTypeByCompanyId { get; set; }
        public Nullable<int> reasonId { get; set; }
        public Nullable<int> clientTypeBySIBId { get; set; }
        public string Sex { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string SecondLastname { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string MarriedName { get; set; }
        public string Title { get; set; }
        public string IdentificationNumber { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> admissionDate { get; set; }
        public Nullable<bool> creditInformation { get; set; }
        public string ClientReference { get; set; }
        public string InactiveComment { get; set; }
        public Nullable<int> numberDependents { get; set; }
        public Nullable<int> numberEmployees { get; set; }
        public Nullable<decimal> AnnualSales { get; set; }
        public Nullable<decimal> AssetValue { get; set; }
        public Nullable<System.DateTime> dateIncorporation { get; set; }
        public Nullable<bool> ownHouse { get; set; }
        public Nullable<bool> IsClientSentCollection { get; set; }
        public string depositType { get; set; }
        public string TypeNCF { get; set; }
        public string CountryName { get; set; }
        public string rolName { get; set; }
        public string IdentificationName { get; set; }
        public string ClassName { get; set; }
        public string personTypeName { get; set; }
        public string MaritalStatusName { get; set; }
        public string ProfessionName { get; set; }
        public string companyName { get; set; }
        public string linkedTypeName { get; set; }
        public string clientTypeByCompanyName { get; set; }
        public string clientTypeBySIBName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> ModiDate { get; set; }
        public int CreateUsrId { get; set; }
        public Nullable<int> ModiUsrId { get; set; }
        public string hostName { get; set; }
        public Nullable<long> addressId { get; set; }
        public Nullable<int> addressCountryID { get; set; }
        public Nullable<int> addressprovinceId { get; set; }
        public Nullable<int> addresscityId { get; set; }
        public Nullable<int> addressphysicalSectorId { get; set; }
        public Nullable<long> contactPhoneId { get; set; }
        public Nullable<long> contactEmailId { get; set; }
        public Nullable<bool> AddressIsPrimary { get; set; }
        public string addressType { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string buildingName { get; set; }
        public string postalCode { get; set; }
        public string postalZone { get; set; }
        public string address { get; set; }
        public string addressAdditional { get; set; }
        public string AddressCountryName { get; set; }
        public string provinceName { get; set; }
        public string cityName { get; set; }
        public string physicalSectorName { get; set; }
        public string AreaCode { get; set; }
        public string Phone { get; set; }
        public string PhoneType { get; set; }
        public string PhoneComments { get; set; }
        public Nullable<bool> PhoneIsPrimary { get; set; }
        public string PhoneCountryName { get; set; }
        public string email { get; set; }
        public string emailType { get; set; }
        public string emailComments { get; set; }
        public Nullable<bool> emailIsPrimary { get; set; }
    }
}
