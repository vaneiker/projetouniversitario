using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LOGIC.UnderWriting.Common;
using ServicesApi.UnderWriting.Common;
using ServicesApi.UnderWriting.Common.Model;
using Entity.UnderWriting.Entities;

namespace ServicesApi.UnderWriting.Contact
{
    public class ContactService : CommonService, IContactService
    {
        #region Private Properties
        private bool _usingTest = System.Configuration.ConfigurationManager.AppSettings["UsingTest"] == "true";
        private int _corpId;
        private int _contactId;
        private int _companyId;
        private long? _customerNo;
        private int _language = 1;
        #endregion

        #region private Methods
        private void SetCustomerDetail(ref Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customerDetail, Entity.UnderWriting.Entities.Contact contact)
        {
            var countryIllus = new Entity.UnderWriting.IllusData.DropDown();

            var lstCountriesIllus = CommonService.GetIllusDropDownByType(DropDownType.Country);

            #region Personal Information
            customerDetail.ClientId = "000001";
            customerDetail.FirstName = contact.FirstName;
            customerDetail.MiddleName = contact.MiddleName;
            customerDetail.LastName = contact.FirstLastName;
            customerDetail.LastName2 = contact.SecondLastName;
            customerDetail.BirthDate = contact.Dob;
            customerDetail.Age = contact.Age.GetValueOrDefault().ToString();
            customerDetail.GenderCode = contact.Gender;
            customerDetail.RCustomerNo = contact.ContactId;
            customerDetail.Smoker = contact.Smoker.GetValueOrDefault() ? "Y" : "N";
            customerDetail.IsDeleted = "N";
            customerDetail.BirthDate = contact.Dob;
            customerDetail.UserId = 3031;

            var countryGlobal = contact.CountryOfResidenceDesc;
            if (countryGlobal != null)
            {
                countryIllus = lstCountriesIllus.FirstOrDefault(o => o.CountryName.ToLower() == contact.CountryOfResidenceDesc.ToLower());
                customerDetail.ResCountryNo = countryIllus == null ? null : countryIllus.CountryNo;
            }

            var maritalStatusGlobal = CommonService.GetDropDownByType(DropDownType.MaritalStatus, new DropDown.Parameter { CorpId = _corpId }).FirstOrDefault(o => o.MaritalStatId == contact.MaritalStatId);
            if (maritalStatusGlobal != null)
            {
                var maritalStatusIllus = CommonService.GetIllusDropDownByType(DropDownType.MaritalStatus).FirstOrDefault(o => o.MaritalStatus.ToLower() == maritalStatusGlobal.MaritalStatusDesc.ToLower());
                customerDetail.MaritalStatusCode = maritalStatusIllus == null ? null : maritalStatusIllus.MaritalStatusCode;
            }
            #endregion

            #region Address
            var address = contact.Addresses.Where(o => o.DirectoryTypeId == 5).OrderBy(r => r.DirectoryId).FirstOrDefault(); //Home Address
            if (address != null)
            {
                customerDetail.Address1 = address.StreetAddress.Length > 150 ? address.StreetAddress.Substring(0, 150) : address.StreetAddress;
                customerDetail.Address2 = address.StreetAddress.Length > 150 ? address.StreetAddress.Substring(150) : null;
                customerDetail.City = address.CityDesc;
                customerDetail.Dtate = address.StateProvDesc;
                customerDetail.ZipCode = address.ZipCode;

                countryIllus = lstCountriesIllus.FirstOrDefault(o => o.CountryName.ToLower() == address.CountryDesc.ToLower());
                customerDetail.CountryNo = countryIllus == null ? null : countryIllus.CountryNo;
            }

            address = contact.Addresses.Where(o => o.DirectoryTypeId == 4).OrderBy(r => r.DirectoryId).FirstOrDefault(); //Business Address
            if (address != null)
            {
                customerDetail.BusAddress1 = address.StreetAddress.Length > 150 ? address.StreetAddress.Substring(0, 150) : address.StreetAddress;
                customerDetail.BusAddress2 = address.StreetAddress.Length > 150 ? address.StreetAddress.Substring(150) : null;
                customerDetail.BusCity = address.CityDesc;
                customerDetail.BusState = address.StateProvDesc;
                customerDetail.BusZipCode = address.ZipCode;

                countryIllus = lstCountriesIllus.FirstOrDefault(o => o.CountryName.ToLower() == address.CountryDesc.ToLower());
                customerDetail.BusCountryNo = countryIllus == null ? null : countryIllus.CountryNo;
            }
            #endregion

            #region Save
            if (!customerDetail.CustomerNo.HasValue || customerDetail.CustomerNo.Value <= 0)
            {
                customerDetail.CreatedBy = customerDetail.UserId;
                customerDetail.DateCreated = DateTime.Now;
                var company = _uManager.IIllusDataManager.GetCompany(_companyId);
                customerDetail.CompanyId = company.BrandName;
                customerDetail = _uManager.IIllusDataManager.InsertCustomerDetail(customerDetail);
            }
            else
            {
                customerDetail.UpdatedBy = customerDetail.UserId;
                customerDetail.DateUpdated = DateTime.Now;
                customerDetail = _uManager.IIllusDataManager.UpdateCustomerDetail(customerDetail);
            }
            #endregion
        }

        private void SetAllCustomerDetailInformation(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customerDetail, Entity.UnderWriting.Entities.Contact contact)
        {
            var isNew = !customerDetail.CustomerNo.HasValue;
            SetCustomerDetail(ref customerDetail, contact);
            SetCustomerEmail(customerDetail, contact);
            SetCustomerPhone(customerDetail, contact);
            SetCustomerIdentification(customerDetail, contact);
            SetCustomerOccupation(customerDetail, contact, isNew);
        }

        private void SetCustomerEmail(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customerDetail, Entity.UnderWriting.Entities.Contact contact)
        {
            var lstEmailTypeIllus = CommonService.GetIllusDropDownByType(DropDownType.EmailType);

            _uManager.IIllusDataManager.DeleteCustomerEmails(customerDetail.CustomerNo.Value, 1);
            foreach (var item in contact.Emails)
            {
                var emailType = lstEmailTypeIllus.FirstOrDefault(o => o.EmailType.ToLower() == item.DirectoryTypeDesc.ToLower());
                var customerEmail = new Entity.UnderWriting.IllusData.Illustrator.CustomerEmail
                {
                    Additional = "Y",
                    CustomerNo = customerDetail.CustomerNo,
                    EmailId = item.EmailAdress,
                    EmailTypeCode = emailType == null ? null : emailType.EmailTypeCode
                };

                _uManager.IIllusDataManager.InsertCustomerEmail(customerEmail);
            }
        }

        private void SetCustomerPhone(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customerDetail, Entity.UnderWriting.Entities.Contact contact)
        {
            var lstPhoneTypeIllus = CommonService.GetIllusDropDownByType(DropDownType.PhoneType);

            _uManager.IIllusDataManager.DeleteCustomerPhones(customerDetail.CustomerNo.Value, 1);
            foreach (var item in contact.Phones)
            {
                var phoneType = lstPhoneTypeIllus.FirstOrDefault(o => o.PhoneType.ToLower() == item.DirectoryTypeDesc.ToLower());
                var customerPhone = new Entity.UnderWriting.IllusData.Illustrator.CustomerPhone
                {
                    Additional = "Y",
                    CustomerNo = customerDetail.CustomerNo,
                    IntCode = item.CountryCode,
                    AreaCode = item.AreaCode,
                    PhoneNo = item.PhoneNumber,
                    Ext = item.PhoneExt,
                    PhoneTypeCode = phoneType == null ? "O" : phoneType.PhoneTypeCode
                };

                _uManager.IIllusDataManager.InsertCustomerPhone(customerPhone);
            }
        }

        private void SetCustomerIdentification(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customerDetail, Entity.UnderWriting.Entities.Contact contact)
        {
            var lstIdentificationTypeIllus = CommonService.GetIllusDropDownByType(DropDownType.IdentificationType);
            var lstIdentification = _uManager.ContactManager.GetAllIdDocumentInformation(contact.ContactId, 1);
            var lstCountriesIllus = CommonService.GetIllusDropDownByType(DropDownType.Country);

            _uManager.IIllusDataManager.DeleteCustomerIdentifications(customerDetail.CustomerNo.Value, 1);
            foreach (var item in lstIdentification)
            {
                var identificationType = lstIdentificationTypeIllus.FirstOrDefault(o => o.IdentificationType.ToLower() == item.ContentType.ToLower());
                var country = lstCountriesIllus.FirstOrDefault(o => o.CountryName.ToLower() == item.CountryIssuedByDesc.ToLower());
                var customerIdentification = new Entity.UnderWriting.IllusData.Illustrator.CustomerPlanIdentification
                {
                    InsuredTypeCode = "P",
                    IdentificationTypeCode = identificationType == null ? null : identificationType.IdentificationTypeCode,
                    IdentificationCode = item.Id,
                    ExpiryDate = item.ExpireDate,
                    CountryNo = country == null ? null : country.CountryNo,
                    CustomerNo = customerDetail.CustomerNo.GetValueOrDefault()
                };

                _uManager.IIllusDataManager.InsertPlanIdentification(customerIdentification);
            }
        }

        private void SetCustomerOccupation(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customerDetail, Entity.UnderWriting.Entities.Contact contact, bool Insert = false)
        {
            var professionType =CommonService.GetDropDownByType(DropDownType.OccupationType, new DropDown.Parameter { CorpId = _corpId })
                .FirstOrDefault(o => o.OccupGroupTypeId == contact.OccupGroupTypeId);
            var occupationType =CommonService.GetDropDownByType(DropDownType.Occupation, new DropDown.Parameter { CorpId = _corpId })
                .FirstOrDefault(o => o.OccupationId == contact.OccupationId);

            var professionIllus = new Entity.UnderWriting.IllusData.DropDown();
            var occupationIllus = new Entity.UnderWriting.IllusData.DropDown();

            if (professionType != null)
                professionIllus =CommonService.GetIllusDropDownByType(DropDownType.ProfessionType)
                    .FirstOrDefault(o => o.ProfessionType == professionType.OccupationGroupDesc);
            if (occupationType != null)
                occupationIllus = CommonService.GetIllusDropDownByType(DropDownType.OccupationType)
                .FirstOrDefault(o => o.OccupationType == occupationType.OccupationDesc);

            var occupationInformation = new Entity.UnderWriting.IllusData.Illustrator.CustomerOccupation
            {
                CustomerNo = customerDetail.CustomerNo,
                CompanyName = contact.CompanyName,
                BusinessType = contact.LineOfBusiness + " - " + contact.LineOfBusiness2,
                WorkYears = contact.LengthWorkYear,
                WorkMonths = contact.LengthWorkMonth,
                OccupationTypeCode = occupationIllus == null ? null : occupationIllus.OccupationTypeCode,
                ProfessionTypeCode = professionIllus == null ? null : professionIllus.ProfessionTypeCode,
                Tasks = contact.LaborTasks,
                AnnualFamilyIncome = contact.AnnualFamilyIncome,
                CustomerOccupationNo = customerDetail.CustomerNo
            };

            if (Insert)
                _uManager.IIllusDataManager.InsertCustomerOccupation(occupationInformation);
            else
                _uManager.IIllusDataManager.UpdateCustomerOccupation(occupationInformation);
        }

        private List<string> ValidateAndAsignParameters(string corpId, string contactId, string companyId = null, string customerNo = null)
        {
            var lstMessage = new List<string>();
            var decryptCorpId = _usingTest ? corpId : Encryption.Decrypt(corpId);
            var decryptContactId = _usingTest ? contactId : Encryption.Decrypt(contactId);
            var decryptCompanyId = _usingTest ? companyId : Encryption.Decrypt(companyId);
            var decryptCustomerNo = _usingTest || String.IsNullOrEmpty(customerNo) ? customerNo : Encryption.Decrypt(customerNo);

            if (!decryptCorpId.IsInt()) lstMessage.Add("Parameter corpId isnt integer.");
            if (!decryptContactId.IsInt()) lstMessage.Add("Parameter contactId isnt integer.");
            if (!String.IsNullOrEmpty(companyId) && !decryptCompanyId.IsInt()) lstMessage.Add("Parameter companyId isnt integer.");
            if (!String.IsNullOrEmpty(customerNo) && !decryptCustomerNo.IsLong()) lstMessage.Add("Parameter customerNo isnt long.");

            if (!lstMessage.Any())
            {
                _corpId = decryptCorpId.ToInt();
                _contactId = decryptContactId.ToInt();
                _companyId = decryptCompanyId.ToInt();
                _customerNo = decryptCustomerNo.ToLong();
            }
            return lstMessage;
        }
        #endregion

        #region Services
        /// <summary>
        /// Save Contact, Address, Occupation and Additional Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactInformation(string corpId, string contactId, string companyId)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, companyId);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) ??
                    new Entity.UnderWriting.IllusData.Illustrator.CustomerDetail();

                SetCustomerDetail(ref customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact, Address, Phone, Email, Identification, Occupation, Additional Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactAllInformation(string corpId, string contactId, string companyId)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, companyId);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) ??
                    new Entity.UnderWriting.IllusData.Illustrator.CustomerDetail();

                SetAllCustomerDetailInformation(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Email Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactEmail(string corpId, string contactId)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerEmail(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Phone Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactPhone(string corpId, string contactId)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerPhone(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Identification Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactIdentification(string corpId, string contactId)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerIdentification(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact, Address, Occupation and Additional Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactInformation(string corpId, string contactId, string companyId, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, companyId, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                     (_customerNo.GetValueOrDefault() <= 0 ?
                     _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                     _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null)) ??
                     new Entity.UnderWriting.IllusData.Illustrator.CustomerDetail();

                SetCustomerDetail(ref customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact, Address, Phone, Email, Identification, Occupation, Additional Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactAllInformation(string corpId, string contactId, string companyId, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, companyId, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                     (_customerNo.GetValueOrDefault() <= 0 ?
                     _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                     _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null)) ??
                     new Entity.UnderWriting.IllusData.Illustrator.CustomerDetail();

                SetAllCustomerDetailInformation(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Email Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactEmail(string corpId, string contactId, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                     _customerNo.GetValueOrDefault() <= 0 ?
                     _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                     _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerEmail(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Phone Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactPhone(string corpId, string contactId, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _customerNo.GetValueOrDefault() <= 0 ?
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                    _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerPhone(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Identification Information
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactIdentification(string corpId, string contactId, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, contactId, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _customerNo.GetValueOrDefault() <= 0 ?
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                    _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerIdentification(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Email Information Legal 
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="Agent_Legal"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactEmailJuridico(string corpId, string Agent_Legal)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, Agent_Legal);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerEmail(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Identification Information Legal 
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="Agent_Legal"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactIdentificationJuridico(string corpId, string Agent_Legal)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, Agent_Legal);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerIdentification(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Identification Information Legal 
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="Agent_Legal"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactIdentificationJuridico(string corpId, string Agent_Legal, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, Agent_Legal, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                    _customerNo.GetValueOrDefault() <= 0 ?
                    _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                    _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerIdentification(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        /// <summary>
        /// Save Contact Email Information Legal 
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="Agent_Legal"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetContactEmailJuridico(string corpId, string Agent_Legal, string customerNo)
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(corpId, Agent_Legal, customerNo);

                if (returnData.ListMessage.Any())
                    return returnData;

                var contact = _uManager.ContactManager.GetContact(_corpId, _contactId, _language);
                if (contact == null) throw new Exception("Contact don't exist.");

                var customerDetail =
                     _customerNo.GetValueOrDefault() <= 0 ?
                     _uManager.IIllusDataManager.GetCustomerDetailById(null, contact.ContactId) :
                     _uManager.IIllusDataManager.GetCustomerDetailById(_customerNo.GetValueOrDefault(), null);
                if (customerDetail == null) throw new Exception("Contact don't exist in Illusdata.");

                SetCustomerEmail(customerDetail, contact);
                returnData.Status = ReturnMessageData.StatusProcess.Success;
            }
            catch (Exception ex)
            {
                returnData.Status = ReturnMessageData.StatusProcess.Error;
                returnData.ListMessage.Add(ex.FindInnerException().Message);
            }
            return returnData;
        }

        #endregion
    }
}
