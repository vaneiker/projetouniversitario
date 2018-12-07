using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.DataLayer.Interfaces;
using System.Data.Entity;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class CustomerRepository : BaseRepository, IBaseRepository<Customer>, IDBOperation<Customer>
    {
        public CustomerRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<Customer> GetAll(long? entityId = null)
        {
            throw new NotImplementedException();
        }

        public Customer FindById(long? Id)
        {
            IEnumerable<Customer> Result;
            var temp = base._dbContext.SP_GET_CLIENT_INFORMATIONS(Id, null);
            Result = temp.Select(r => new Customer
            {
                clientId = r.clientId,
                relatedContactId = r.relatedContactId,
                countryID = r.countryID,
                entityRolId = r.entityRolId,
                identificationTypeId = r.identificationTypeId,
                entityClassId = r.entityClassId,
                personTypeId = r.personTypeId,
                maritalStatusId = r.maritalStatusId,
                professionId = r.professionId,
                companyId = r.companyId,
                linkedTypeId = r.linkedTypeId,
                clientTypeByCompanyId = r.clientTypeByCompanyId,
                reasonId = r.reasonId,
                clientTypeBySIBId = r.clientTypeBySIBId,
                Sex = r.Sex,
                FirstName = r.FirstName,
                MiddleName = r.MiddleName,
                Lastname = r.Lastname,
                SecondLastname = r.SecondLastname,
                FullName = r.FullName,
                Nickname = r.Nickname,
                MarriedName = r.MarriedName,
                Title = r.Title,
                IdentificationNumber = r.IdentificationNumber,
                BirthDate = r.BirthDate,
                admissionDate = r.admissionDate,
                creditInformation = r.creditInformation,
                ClientReference = r.ClientReference,
                InactiveComment = r.InactiveComment,
                numberDependents = r.numberDependents,
                numberEmployees = r.numberEmployees,
                AnnualSales = r.AnnualSales,
                AssetValue = r.AssetValue,
                dateIncorporation = r.dateIncorporation,
                ownHouse = r.ownHouse,
                IsClientSentCollection = r.IsClientSentCollection,
                depositType = r.depositType,
                TypeNCF = r.TypeNCF,
                CountryName = r.CountryName,
                rolName = r.rolName,
                IdentificationName = r.IdentificationName,
                ClassName = r.ClassName,
                personTypeName = r.personTypeName,
                MaritalStatusName = r.MaritalStatusName,
                ProfessionName = r.ProfessionName,
                companyName = r.companyName,
                linkedTypeName = r.linkedTypeName,
                clientTypeByCompanyName = r.clientTypeByCompanyName,
                clientTypeBySIBName = r.clientTypeBySIBName,
                isActive = r.isActive,
                CreateDate = r.CreateDate,
                ModiDate = r.ModiDate,
                CreateUsrId = r.CreateUsrId,
                ModiUsrId = r.ModiUsrId,
                hostName = r.hostName,
                addressId = r.addressId,
                addressCountryID = r.addressCountryID,
                addressprovinceId = r.addressprovinceId,
                addresscityId = r.addresscityId,
                addressphysicalSectorId = r.addressphysicalSectorId,
                contactPhoneId = r.contactPhoneId,
                contactEmailId = r.contactEmailId,
                AddressIsPrimary = r.AddressIsPrimary,
                addressType = r.addressType,
                streetName = r.streetName,
                streetNumber = r.streetNumber,
                buildingName = r.buildingName,
                postalCode = r.postalCode,
                postalZone = r.postalZone,
                address = r.address,
                addressAdditional = r.addressAdditional,
                AddressCountryName = r.AddressCountryName,
                provinceName = r.provinceName,
                cityName = r.cityName,
                physicalSectorName = r.physicalSectorName,
                AreaCode = r.AreaCode,
                Phone = r.Phone,
                PhoneType = r.PhoneType,
                PhoneComments = r.PhoneComments,
                PhoneIsPrimary = r.PhoneIsPrimary,
                PhoneCountryName = r.PhoneCountryName,
                email = r.email,
                emailType = r.emailType,
                emailComments = r.emailComments,
                emailIsPrimary = r.emailIsPrimary
            })
            .ToArray();

            return
                Result
                .FirstOrDefault();
        }

        public ResultRepository Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Edit(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
