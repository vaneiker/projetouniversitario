using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using KSI.Cobranza.LogicLayer;
using KSI.Cobranza.EntityLayer;
using System.IO;
using TH = KSI.Cobranza.Web.Common.Thunderhead;
using System.Text;
using System.Globalization;
using WEB.NewBusiness.Common;
using Cardnet = WebServices.CardNet;
using EasyBank = WebServices.EasyBank;

namespace KSI.Cobranza.Web.Models
{
    /// <summary>
    /// Author        : Lic. Carlos Ml. Lebron B
    /// Created Date  : 08/09/2018
    /// </summary>
    public class ProcessModel : BaseModel
    {
        private ProcessViewModels @Model { get; set; }
        private IEnumerable<Phone> CustomerPhones { get; set; }
        private IEnumerable<EmailAddress> CustomerEmails { get; set; }

        private Cardnet.CardNetProxy CardNetProxy
        {
            get
            {
                return new Lazy<Cardnet.CardNetProxy>().Value;
            }

        }

        private EasyBank.EasyBankProxy EasyProxy
        {
            get
            {
                return new Lazy<EasyBank.EasyBankProxy>().Value;
            }
        }

        private WebServices.CallRex.CallRexProxy CallRexProy
        {
            get
            {

                return new Lazy<WebServices.CallRex.CallRexProxy>().Value;
            }
        }

        public ProcessModel()
        {
            @Model = new Lazy<ProcessViewModels>().Value;
        }

        public Customer GetCustomerInfo(long? EntityId)
        {
            var dataFindByIdCustomer = base.oApiService.customerManager.FindById(EntityId);
            var data = dataFindByIdCustomer.entity;
            return
                data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EntityId"></param>
        /// <returns></returns>
        public PersonalInformationViewModels GetPersonalInformation(long? EntityId)
        {
            var dataFindByIdCustomer = base.oApiService.customerManager.FindById(EntityId);
            var data = dataFindByIdCustomer.entity;
            //Phones
            CustomerPhones = GetPhones(EntityId);
            //Emails
            CustomerEmails = GetEmails(EntityId);

            var result = new PersonalInformationViewModels
            {
                CustomerId = data.clientId,
                FirstName = data.FirstName,
                SurName = data.MiddleName,
                FirstLastName = data.Lastname,
                SecondLastName = data.SecondLastname,
                MarriedLastName = data.MarriedName,
                MaritalStatus = data.MaritalStatusName,
                SexDesc = (data.Sex == "M") ? "Masculino" : "Femenino",
                NoDepend = data.numberDependents.GetValueOrDefault(),
                Dob = data.BirthDate.GetValueOrDefault(),
                CustomerType = data.clientTypeBySIBName,
                PersonType = data.personTypeName,
                contact = new Contact
                {
                    Code = data.IdentificationNumber,
                    Position = data.ProfessionName,
                    Email = data.email,
                    PhoneNumber = !string.IsNullOrEmpty(data.AreaCode) && !string.IsNullOrEmpty(data.Phone) ? string.Format("({0}) {1}", data.AreaCode.Replace(" ", ""), data.Phone.Replace(" ", "")) : string.Empty
                },
                address = new Address
                {
                    CustomerId = data.clientId,
                    address = string.Concat(data.AddressCountryName, " ", data.addressAdditional),
                    addressType = data.addressType,
                    Country = data.CountryName,
                    Street = data.streetName,
                    Number = data.streetNumber,
                    Urbanization = string.Empty,
                    Sector = data.physicalSectorName,
                    City = data.cityName,
                    Province = data.provinceName,
                    location = string.Empty
                },
                phones = CustomerPhones,
                emails = CustomerEmails
            };

            return
               result;
        }

        /// <summary>
        ///  Get Process Model
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public ProcessViewModels GetProcessModel(dataRequest dataRequest)
        {
            var dataFindByIdCustomer = base.oApiService.customerManager.FindById(dataRequest.CustomerId);
            var isLoaddata = (!dataFindByIdCustomer.result.HasError && dataFindByIdCustomer.result != null);

            if (isLoaddata)
            {
                var data = dataFindByIdCustomer.entity;
                //Phones
                CustomerPhones = GetPhones(data.clientId);
                //Emails
                CustomerEmails = GetEmails(data.clientId);

                @Model.personalInformationViewModels = new PersonalInformationViewModels
                {
                    CustomerId = data.clientId,
                    FirstName = data.FirstName,
                    SurName = data.MiddleName,
                    FirstLastName = data.Lastname,
                    SecondLastName = data.SecondLastname,
                    MarriedLastName = data.MarriedName,
                    MaritalStatus = data.MaritalStatusName,
                    SexDesc = (data.Sex == "M") ? "Masculino" : "Femenino",
                    NoDepend = data.numberDependents.GetValueOrDefault(),
                    Dob = data.BirthDate.GetValueOrDefault(),
                    CustomerType = data.clientTypeBySIBName,
                    PersonType = data.personTypeName,
                    contact = new Contact
                    {
                        Code = data.IdentificationNumber,
                        Position = data.ProfessionName,
                        Email = data.email,
                        PhoneNumber = !string.IsNullOrEmpty(data.AreaCode) && !string.IsNullOrEmpty(data.Phone) ? string.Format("({0}) {1}", data.AreaCode.Replace(" ", ""), data.Phone.Replace(" ", "")) : string.Empty
                    },
                    address = new Address
                    {
                        CustomerId = data.clientId,
                        address = string.Concat(data.AddressCountryName, " ", data.addressAdditional),
                        addressType = data.addressType,
                        Country = data.CountryName,
                        Street = data.streetName,
                        Number = data.streetNumber,
                        Urbanization = string.Empty,
                        Sector = data.physicalSectorName,
                        City = data.cityName,
                        Province = data.provinceName,
                        location = string.Empty
                    },
                    phones = CustomerPhones,
                    emails = CustomerEmails
                };

                @Model.LoanInformationViewModels = new LoanInformationViewModels
                {
                    AccountId = dataRequest.accountId,
                    Account = dataRequest.account,
                    quotationId = dataRequest.RequestId,
                    LoanNumber = (int?)dataRequest.accountId.GetValueOrDefault(),
                    codeudor = new List<codeudor>(0),
                    paymentPlan = new List<PaymentPlan>(0),
                    receipOfPayment = new List<QuotaInformation>(0)

                };

                @Model.ProjectedStatementViewModels = new ProjectedStatementViewModels
                {
                    paymentProjection = new List<paymentProjection>(0)
                };

                @Model.GuaranteeViewModels = new GuaranteeViewModels
                {
                    GuaranteeList = new List<Guarantee>(0),
                    vehicleInformationDetail = new List<BaseViewModels.KeyValue>(0)
                };

                var endorsements = base.oApiService.loanManager.GetPolicyInformation(dataRequest.accountId);
                var DataEndorsements = new List<Endoses>();
                if (endorsements != null && endorsements.dataResult != null)
                {
                    DataEndorsements = endorsements.dataResult.Select(r => new Endoses
                    {
                        policyTypeName = r.policyTypeName,
                        FullName = r.FullName,
                        policyNo = r.policyNo,
                        isActive = r.isActive,
                        policyCollateralName = r.policyCollateralName,
                        Date = r.Date,
                        EffectiveDate = r.EffectiveDate,
                        endorseNo = r.endorseNo,
                        endorseAmount = r.endorseAmount,
                        endorseInicialDate = r.endorseInicialDate,
                        endorseDate = r.endorseDate,
                        endorseEffectiveDate = r.endorseEffectiveDate,
                        collateralId = r.collateralId,
                        companyId = r.companyId,
                        policyTypeId = r.policyTypeId,
                        relatedContactId = r.relatedContactId,
                        policyCollateralComment = r.policyCollateralComment,
                        notificationDate = r.notificationDate,
                        CreateDate = r.CreateDate,
                        ModiDate = r.ModiDate,
                        CreateUsrId = r.CreateUsrId,
                        ModiUsrId = r.ModiUsrId,
                        hostName = r.hostName,
                    }).ToList();
                }

                @Model.PolicyInformationViewModels = new PolicyInformationViewModels
                {
                    Endoses = DataEndorsements,
                    InsuranceCarrier = new InsuranceCarrier(),
                    PolicyEstado = new PolicyEstado(),
                    PolicyType = new PolicyType()
                };

                // Cobranza
                @Model.CollectionViewModels = new CollectionViewModels()
                {
                    CardDomitiliationViewModel = new CardDomitiliationViewModel() { AffiliateCards = new List<CardDomitiliationViewModel>() },
                    CollectionHistoryPaymentViewModels = new List<CollectionHistoryPaymentViewModels>(),
                    CollectionPaymentViewModels = new List<CollectionPaymentViewModels>(),
                    accountId = dataRequest.accountId
                };

                @Model.CorrespondenceViewModels = new CorrespondenceViewModels
                {
                    accountId = dataRequest.accountId,
                    CustomerId = data.clientId,
                    DocumentsTypes = new List<BaseViewModels.KeyValue>(0),
                    DocumentsGroup = new List<BaseViewModels.KeyValue>(0),
                    TemplateDocuments = new List<TemplateDocument>(0),
                    Departments = new List<BaseViewModels.KeyValue>(0),
                    Subjects = new List<BaseViewModels.KeyValue>(0),
                    TracingTypes = new List<BaseViewModels.KeyValue>(0),
                    AttachedFiles = new List<AttachedFiles>(0),
                };

                var objDataReqeuest = string.Empty;
            }

            return
                @Model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Phone GetPhoneModel(long? Id)
        {
            var model = new Phone();
            model.Type = "";
            var countries = base.GetDropDown(Enums.DropDownType.countries);
            var phoneTypes = base.GetDropDown(Enums.DropDownType.phonetype);
            model.Countries = countries;
            model.phoneTypes = phoneTypes;

            if (Id != null)
                model.CustomerId = Id;

            return
                model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmailAddress GetEmailModel(long? Id)
        {
            var model = new EmailAddress { };
            var emailTypes = base.GetDropDown(Enums.DropDownType.emailtype);
            model.emailTypes = emailTypes;

            if (Id != null)
                model.CustomerId = Id;

            return
                model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public IEnumerable<Guarantee> GetLoanGuarantee(long? accountId)
        {
            var Guarantee = base.oApiService.loanManager.GetLoanGuarantee(accountId)
                .dataResult
                .Select(r => new Guarantee
                {
                    GuaranteeNumber = r.collateralId,
                    GuaranteeName = r.collateralName,
                    GuaranteeType = r.collateralTypeName,
                    GuaranteePercentage = r.percent,
                    GuaranteeAmount = r.amount,
                    GuaranteeContract = r.contractNumber,
                    GuaranteeStatus = r.codeDesc
                });

            return
                Guarantee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CollateralId"></param>
        /// <returns></returns>
        public IEnumerable<BaseViewModels.KeyValue> GetVehicleDetail(long? CollateralId)
        {
            var model = new List<BaseViewModels.KeyValue>(0);
            if (CollateralId.HasValue)
            {
                model = base.oApiService.loanManager.GetVehicleDetail(CollateralId).dataResult.Select(c => new BaseViewModels.KeyValue
                {
                    Key = c.collateralFieldName,
                    Value = c.collateralFieldValue
                }).ToList();
            }

            return
                model;
        }

        public LoanInformationViewModels GetLoanDetail(long? quotationId = null, int? loanNumber = null, long? accountId = null)
        {
            var result = base.oApiService.loanManager.GetLoanDetail(quotationId, loanNumber, accountId).entity;
            var model = new LoanInformationViewModels();

            if (result != null)
            {
                model = new LoanInformationViewModels
                {
                    quotationId = result.quotationId,
                    LoanNumber = result.LoanNumber,
                    fullName = result.fullName,
                    clientid = result.clientid,
                    identificationNumber = result.identificationNumber,
                    LoanStatusName = result.LoanStatusName,
                    quotationPaymentTypeName = result.quotationPaymentTypeName,
                    frequency = result.frequency,
                    frequencyName = result.frequencyName,
                    loanTerm = result.loanTerm,
                    LoanDillingDay = result.LoanDillingDay,
                    CurrencyName = result.CurrencyName,
                    AmountRequested = result.AmountRequested,
                    amountApproved = result.amountApproved,
                    financedAmount = result.financedAmount,
                    DisbursedAmount = result.DisbursedAmount,
                    OutstandingBalance = result.OutstandingBalance,
                    QuotaAmount = result.QuotaAmount,
                    RateAnnual = result.RateAnnual,
                    RateMonth = result.RateMonth,
                    RateCommissionAnnual = result.RateCommissionAnnual,
                    RateCommissionMonth = result.RateCommissionMonth,
                    RateLatenAnnual = result.RateLatenAnnual,
                    RateLateMonth = result.RateLateMonth,
                    qoutationDate = result.qoutationDate,
                    ApprovedDate = result.ApprovedDate,
                    disbursementDate = result.disbursementDate,
                    expirationDate = result.expirationDate,
                    ClosedDate = result.ClosedDate,
                    LastClosedDate = result.LastClosedDate,
                    LastQuotaDate = result.LastQuotaDate,
                    lastPaidDate = result.lastPaidDate,
                    fullNameExecutive = result.fullNameExecutive,
                    fullNamePromoter = result.fullNamePromoter
                };
            }

            return
                model;
        }

        /// <summary>
        /// Set Phone Primary
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="Id"></param>
        public void SetCustomerPrimaryPhone(long? CustomerId, long? Id)
        {
            var Phones = base.oApiService.contactPhoneManager.GetAll(CustomerId).dataResult;
            var ActualPrincipal = Phones.FirstOrDefault(r => r.IsPrimary.GetValueOrDefault());
            if (ActualPrincipal != null)
            {
                ActualPrincipal.IsPrimary = false;
                base.oApiService.contactPhoneManager.Edit(ActualPrincipal);
            }

            var record = Phones.FirstOrDefault(x => x.contactPhoneId == Id);
            record.IsPrimary = true;
            base.oApiService.contactPhoneManager.Edit(record);
        }

        /// <summary>
        /// Set Email Primary
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="Id"></param>
        public void SetCustomerPrimaryEmail(long? CustomerId, long? Id)
        {
            var Emails = base.oApiService.contactEmailAddressManager.GetAll(CustomerId).dataResult;
            var ActualPrincipal = Emails.FirstOrDefault(r => r.IsPrimary.GetValueOrDefault());
            if (ActualPrincipal != null)
            {
                ActualPrincipal.IsPrimary = false;
                base.oApiService.contactEmailAddressManager.Edit(ActualPrincipal);
            }

            var record = Emails.FirstOrDefault(x => x.contactEmailId == Id);
            record.IsPrimary = true;
            base.oApiService.contactEmailAddressManager.Edit(record);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public IEnumerable<codeudor> GetCodeudor(long? accountId)
        {
            var CodeudorData = base.oApiService.loanManager.GetCodeudor(accountId).dataResult.Select(r => new codeudor
            {
                account = r.account,
                accountId = r.accountId,
                accountStatusName = r.accountStatusName,
                accountName = r.accountName,
                Fullname = r.Fullname,
                codebtorFullname = r.codebtorFullname,
                codebtorIdentificationNumber = r.codebtorIdentificationNumber,
                codebtorClientId = r.codebtorClientId,
                codebtorrelatedContactId = r.codebtorrelatedContactId,
                codebtorTypeName = r.codebtorTypeName,
                companyId = r.companyId,
                clientId = r.clientId,
                codebtorTypeId = r.codebtorTypeId,
                canDeposit = r.canDeposit,
                canWithdraw = r.canWithdraw,
                canCancel = r.canCancel,
                IsJointY = r.IsJointY,
                IsJointO = r.IsJointO,
                isActive = r.isActive,
                CreateDate = r.CreateDate,
                ModiDate = r.ModiDate,
                CreateUsrId = r.CreateUsrId,
                ModiUsrId = r.ModiUsrId,
                hostName = r.hostName
            });

            return
                 CodeudorData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public IEnumerable<PolicyInformation> GetPolicyInfomation(long? accountId)
        {
            var PolicyData = base.oApiService.loanManager.GetPolicyInformation(accountId).dataResult.Select(r => new PolicyInformation
            {
                policyTypeName = r.policyTypeName,
                FullName = r.FullName,
                policyNo = r.policyNo,
                Amount = r.Amount,
                isActive = r.isActive,
                policyCollateralName = r.policyCollateralName,
                Date = r.Date,
                EffectiveDate = r.EffectiveDate,
                endorseNo = r.endorseNo,
                endorseAmount = r.endorseAmount,
                endorseInicialDate = r.endorseInicialDate,
                endorseDate = r.endorseDate,
                endorseEffectiveDate = r.endorseEffectiveDate,
                collateralId = r.collateralId,
                companyId = r.companyId,
                policyTypeId = r.policyTypeId,
                relatedContactId = r.relatedContactId,
                policyCollateralComment = r.policyCollateralComment,
                notificationDate = r.notificationDate,
                CreateDate = r.CreateDate,
                ModiDate = r.ModiDate,
                CreateUsrId = r.CreateUsrId,
                ModiUsrId = r.ModiUsrId,
                hostName = r.hostName
            });

            return
                 PolicyData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public IEnumerable<QuotaInformation> GetReceipOfPayment(long? accountId)
        {
            var PolicyData = base.oApiService.loanManager.GetReceipOfPayment(accountId).dataResult.Select(r => new QuotaInformation
            {
                transactionPaymentPlanId = r.transactionPaymentPlanId,
                quotaNumber = r.quotaNumber,
                emisionQuotaDate = r.emisionQuotaDate,
                endQuotaDate = r.endQuotaDate,
                validationTotal = r.validationTotal,
                validationBalance = r.validationBalance,
                ISLastQuota = r.ISLastQuota,
                IsPrepayment = r.IsPrepayment,
                transactionReasonName = r.transactionReasonName,
                LoanStatusName = r.LoanStatusName,
                fullName = r.fullName,
                accountId = r.accountId,
                loanNumber = r.loanNumber,
                transactionReasonId = r.transactionReasonId,
                capitalAmount = r.capitalAmount,
                interestAmoint = r.interestAmoint,
                commissionAmount = r.commissionAmount,
                expenseAmount = r.expenseAmount,
                rateLateAmount = r.rateLateAmount,
                chargesPrepayment = r.chargesPrepayment,
                capitalBalance = r.capitalBalance,
                interestBalance = r.interestBalance,
                commissionBalance = r.commissionBalance,
                expenseBalance = r.expenseBalance,
                rateLateBalance = r.rateLateBalance,
                chargesPrepaymentBalance = r.chargesPrepaymentBalance,
                dCapital = r.dCapital,
                dInterestAmoint = r.dInterestAmoint,
                dCommissionAmoun = r.dCommissionAmoun,
                dExpenseAmount = r.dExpenseAmount,
                dRateLateAmount = r.dRateLateAmount,
                dChargeAmount = r.dChargeAmount,
                dDiscountAmount = r.dDiscountAmount,
                DataJson = JsonConvert.SerializeObject(r),
                ClassPagoAdel = !r.ISLastQuota.GetValueOrDefault() ? "equisGrid danger" : "checkGrid success",
                ClassLastPayment = !r.IsPrepayment.GetValueOrDefault() ? "equisGrid danger" : "checkGrid success",
                ClassIconAdel = !r.ISLastQuota.GetValueOrDefault() ? "fa fa-times" : "fa fa-check",
                ClassIconPayment = !r.IsPrepayment.GetValueOrDefault() ? "fa fa-times" : "fa fa-check",
            }).ToList();

            return
                 PolicyData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public IEnumerable<PaymentPlan> GetPaymentPlan(long? accountId)
        {
            var data = base.oApiService.loanManager.GetPaymentPlan(accountId).dataResult.Select(r => new PaymentPlan
            {
                Quota = r.Quota,
                QuotaDate = r.QuotaDate,
                CapitalBalance = r.CapitalBalance,
                Capital = r.Capital,
                Rate = r.Rate,
                LoanRate = r.LoanRate,
                Commision = r.Commision,
                FinancialQuota = r.FinancialQuota,
                Expense = r.Expense,
                TotalPayment = r.TotalPayment
            });

            return
                 data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="dateStatement"></param>
        /// <param name="idTipo"></param>
        /// <returns></returns>
        public IEnumerable<paymentProjection> GetProjectStatement(Nullable<long> accountId, Nullable<System.DateTime> dateStatement, Nullable<int> idTipo, Nullable<decimal> montoPago)
        {
            var data = base.oApiService.loanManager.GetProjectedStatement(accountId, dateStatement, idTipo, montoPago).dataResult.Select(r => new paymentProjection
            {
                Description = r.Description,
                Value = r.Value,
                TipoSaldo = r.TipoSaldo,
                NameKey = r.NameKey
            });

            return
                 data;
        }

        /// <summary>
        /// Get All Phones
        /// </summary>
        /// <param name="CustomerId"></param>
        public IEnumerable<Phone> GetPhones(long? CustomerId)
        {
            CustomerPhones = base.oApiService.contactPhoneManager.GetAll(CustomerId).dataResult.Select(p => new Phone
            {
                CustomerId = CustomerId,
                contactPhoneId = p.contactPhoneId.GetValueOrDefault(),
                Number = !string.IsNullOrEmpty(p.AreaCode) && !string.IsNullOrEmpty(p.Phone) ? string.Format("({0}) {1}", p.AreaCode.Replace(" ", ""), p.Phone.Replace(" ", "")) : string.Empty,
                Type = p.PhoneType,
                Country = p.CountryName,
                IsPrimary = p.IsPrimary.GetValueOrDefault()
            });

            return
                CustomerPhones;
        }

        /// <summary>
        /// Get All Emails
        /// </summary>
        /// <param name="CustomerId"></param>
        public IEnumerable<EmailAddress> GetEmails(long? CustomerId)
        {
            CustomerEmails = base.oApiService.contactEmailAddressManager.GetAll(CustomerId).dataResult.Select(p => new EmailAddress
            {
                CustomerId = CustomerId,
                contactEmailId = p.contactEmailId.GetValueOrDefault(),
                address = p.email,
                Type = p.emailType,
                IsPrimary = p.IsPrimary.GetValueOrDefault()
            });

            return
                CustomerEmails;
        }

        /// <summary>
        /// Set Phone
        /// </summary>
        /// <param name="Phone"></param>
        public Result SetPhone(Phone phone)
        {
            var parameter = new KSI.Cobranza.EntityLayer.ContactPhone
            {
                contactPhoneId = phone.contactPhoneId < 1 ? (long?)null : phone.contactPhoneId,
                CountryID = phone.countryID,
                AreaCode = phone.AreaCoede,
                Comments = phone.Comments,
                isActive = phone.IsActive,
                IsPrimary = phone.IsPrimary,
                Phone = phone.Number,
                PhoneType = phone.Type,
                relatedContactId = phone.CustomerId.GetValueOrDefault(),
                userId = phone.Usuario.UserID
            };

            var result = base.oApiService.contactPhoneManager.Edit(parameter);
            return
                result;
        }

        /// <summary>
        /// Set Phone
        /// </summary>
        /// <param name="Email"></param>
        public Result SetEmail(EmailAddress emailAddress)
        {
            var parameter = new KSI.Cobranza.EntityLayer.ContactEmail
            {
                contactEmailId = emailAddress.contactEmailId < 1 ? (long?)null : emailAddress.contactEmailId,
                email = emailAddress.address,
                emailType = emailAddress.Type,
                isActive = emailAddress.IsActive,
                IsPrimary = emailAddress.IsPrimary,
                relatedContactId = emailAddress.CustomerId.GetValueOrDefault(),
                comments = emailAddress.Comments,
                userId = emailAddress.Usuario.UserID
            };

            var result = base.oApiService.contactEmailAddressManager.Edit(parameter);
            return
                result;
        }

        public ResultLogic<Loan.Correspondence.RelatedDocuments.ResultHeader> SetTemplate(Nullable<long> templateSentId, Nullable<short> templateId, Nullable<long> accountId, Nullable<long> clienteId, Nullable<System.DateTime> sendDate, string clientName, string documentPath, string documentName, string emails, string comments, Nullable<bool> isActive, Nullable<bool> isSendToClient, Nullable<bool> isSendToOffice, Nullable<bool> isSendToAgent, Nullable<int> caseDepartmentID, Nullable<System.DateTime> caseDate, Nullable<System.TimeSpan> caseHour, string caseComment, Nullable<long> caseNo, Nullable<int> userId, string userName)
        {
            return
                base.oApiService.loanManager.SetTemplate(templateSentId, templateId, accountId, clienteId, sendDate, clientName, documentPath, documentName, emails, comments, isActive, isSendToClient, isSendToOffice, isSendToAgent, caseDepartmentID, caseDate, caseHour, caseComment, caseNo, userId, userName);
        }

        public ResultLogic<Loan.Correspondence.RelatedDocuments.ResultDetail> SetTemplateRelatedFile(Nullable<long> templateSentRelatedFileId, Nullable<long> templateSentId, Nullable<int> documentTypeGroupId, string documentPath, string documentName, string comments, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<decimal> sizeFile)
        {
            return
                base.oApiService.loanManager.SetTemplateRelatedFile(templateSentRelatedFileId, templateSentId, documentTypeGroupId, documentPath, documentName, comments, isActive, userId, userName, sizeFile);
        }

        public IEnumerable<AttachedFiles> GeAttachedFiles(Nullable<long> templateId, Nullable<long> accountId, Nullable<long> templateSentId)
        {
            var model = new List<AttachedFiles>(0);
            var data = base.oApiService.loanManager.GetTemplateRelatedFile(templateId, accountId, templateSentId).dataResult
            .Select(f => new AttachedFiles
            {
                accountId = f.AccountId,
                templateSentRelatedFileId = f.TemplateSentRelatedFileId,
                templateSentId = f.TemplateSentId,
                documentGroupName = f.documentGroupName,
                DocumentTypeId = f.documentTypeGroupId.GetValueOrDefault(),
                DocumentTypeDesc = f.documentTypeGroupName,
                FileName = f.RelatedDocumentName,
                DocumentPath = System.Web.HttpUtility.UrlEncode(f.RelatedDocumentPath),
                sizeFile = f.sizeFile
            }).ToList();

            return
                data;
        }

        public ResultLogic<Loan.Correspondence.RelatedDocuments.DeleteResult> DeleteRelateFile(Nullable<long> templateSentId, Nullable<long> Id)
        {
            return
                base.oApiService.loanManager.DeleteRelateFile(templateSentId, Id);
        }

        public void DeleteRelatedFileFromDisk(string Path)
        {
            try
            {
                File.Delete(Path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic ValidateAttachment(Nullable<long> templateId, Nullable<long> accountId, Nullable<long> templateSentId, string QuantityUploadDocs, string LimitUploadDocsInMb)
        {
            var msgList = new List<string>(0);
            int QFilesUpload = 5;
            int QSizeFilesUpload = 5;
            int.TryParse(QuantityUploadDocs, out QFilesUpload);
            int.TryParse(LimitUploadDocsInMb, out QSizeFilesUpload);

            var dataAttachedment = GeAttachedFiles(templateId, accountId, templateSentId);
            var ComplyWithTheQuantity = dataAttachedment.Count() < 5;
            var TotalMb = dataAttachedment.Sum(x => x.sizeFile);

            var ComplyWithTheTotalSize = (TotalMb > 0) ? !(TotalMb > decimal.Parse(LimitUploadDocsInMb)) : true;

            var CanUpload = true;
            if (!ComplyWithTheQuantity)
            {
                CanUpload = false;
                msgList.Add(string.Format("Solo es posible adjuntar {0} Archivos.", QFilesUpload));
            }

            if (!ComplyWithTheTotalSize)
            {
                CanUpload = false;
                msgList.Add(string.Format("La cantidad total en megas de los archivos adjuntos es de \"{0} Megabytes\", no debe sobrepasar los \"{1} Megabytes\".", TotalMb, LimitUploadDocsInMb));
            }

            return new { TotalFilesUpload = QFilesUpload, CanUpload = CanUpload, Messages = msgList };

        }

        public NotesViewModels GetCasesViewModel(Nullable<long> relatedContactId, Nullable<long> accountId, long? caseNumber, Nullable<int> meetingStatusId, string CustomerName = "", string LoanNumber = "")
        {
            var Vm = new NotesViewModels
            {
                CustomerId = relatedContactId,
                CustomerName = CustomerName,
                LoanNumber = LoanNumber,
                accountId = accountId,
                Cases = base.oApiService.loanManager.GetMeetingCase(relatedContactId, accountId, caseNumber, meetingStatusId).dataResult.Select(r => new Cases
                {                   
                    ColorStatus = r.MeetingStatusDesc=="Cerrado"?"red":"black",
                    CaseKey = Utility.serializeToJSON(new { relatedContactId = r.relatedContactId, meetingTypeId = r.MeetingTypeId, meetingSubTypeId = r.MeetingSubTypeId, meetingCaseId = r.MeetingCaseId }),
                    CaseNumber = r.CaseNumber,
                    CaseNumberF = r.CaseNumber.ToString(),
                    CaseDate = r.MeetingDate,
                    OpeningCase = r.CreateDate,
                    ClosingCase = r.MeetingClosedDate.ToString(),
                    CaseType = r.MeetingDesc,
                    CaseSubType = r.MeetingSubDesc,
                    CategoryCase = r.CategoryDesc,
                    AboutCase = string.Empty,
                    User = r.CreatedUserName,
                    CaseStatusId = r.MeetingStatusId,
                    Status = r.MeetingStatusDesc,
                    Recording = r.CallCount,
                    NoteNumber = r.NotesCount,
                    Priority = r.PriorityDesc,
                }).ToList(),
                CasesDetailViewModels = new CasesDetailViewModels
                {
                    Notes = new List<string>(0),
                    attachedFiles = new List<CasesAttachedFiles>(0),
                    attachedCalls = new List<PhoneCallViewModels>(0)
                }
            };

            return Vm;
        }


        public IEnumerable<PhoneCallViewModels> GetPhoneCall(string CallRexPath, bool IsDebug, int? UserId, DateTime CallRexDate)
        {
            IEnumerable<PhoneCallViewModels> result = null;
            var ResultCallUser = oApiService.loanManager.GetUsersCall(UserId);
            if (ResultCallUser.SingleResult != null)
            {
                //"876994a5-1ced-4977-97f2-50e654f2baca"
                var userId = ResultCallUser.SingleResult.UserIdForCallsRecording;
                var date = CallRexDate;
                var dataCallRex = CallRexProy.GetRecordedCallsByUserid(userId, date);
                result = dataCallRex.Select(x => new PhoneCallViewModels
                {
                    KeyCall = Utility.serializeToJSON(new
                    {
                        CallDuration = x.CallDuration.ToString(),
                        CallerIDName = x.CallerIDName,
                        CallerIDNo = x.CallerIDNo,
                        CallID = x.CallID,
                        CallLogID = x.CallLogID.ToString(),
                        CallStart = x.CallStart,
                        CallStop = x.CallStop,
                        Department = x.Department,
                        DialedNumber = x.DialedNumber,
                        DNIS = x.DNIS,
                        Extension = x.Extension,
                        FileHash = x.FileHash,
                        FileLocation = x.FileLocation,
                        FullName = string.Concat(x.FirstName, " ", x.LastName),
                        FileName = x.FileName,
                        CreateDate = DateTime.Parse(x.FileName.Substring(0, 10), CultureInfo.InvariantCulture),
                        FirstName = x.FirstName,
                        FromCallLogID = x.FromCallLogID.ToString(),
                        IsRecordingChainSegment = x.IsRecordingChainSegment,
                        IsStereo = x.IsStereo,
                        LastName = x.LastName,
                        Location = x.Location,
                        RecordedBy = x.RecordedBy,
                        RecorderUtcOffset = x.RecorderUtcOffset.ToString(),
                        Rejected = x.Rejected,
                        ToCallLogID = x.ToCallLogID.ToString(),
                        UserID = x.UserID.ToString(),
                        XferFrom = x.XferFrom
                    }),
                    CallDuration = x.CallDuration.ToString(),
                    CallerIDName = x.CallerIDName,
                    CallerIDNo = x.CallerIDNo,
                    CallID = x.CallID,
                    CallLogID = x.CallLogID.ToString(),
                    CallStart = x.CallStart,
                    CallStop = x.CallStop,
                    Department = x.Department,
                    DialedNumber = x.DialedNumber,
                    DNIS = x.DNIS,
                    Extension = x.Extension,
                    FileHash = x.FileHash,
                    FileLocation = x.FileLocation,
                    RealPathCallToPlay = CallRexPath,
                    FullName = string.Concat(x.FirstName, " ", x.LastName),
                    FileName = x.FileName,
                    CreateDate = DateTime.Parse(x.FileName.Substring(0, 10), CultureInfo.InvariantCulture),
                    FirstName = x.FirstName,
                    FromCallLogID = x.FromCallLogID.ToString(),
                    IsRecordingChainSegment = x.IsRecordingChainSegment,
                    IsStereo = x.IsStereo,
                    LastName = x.LastName,
                    Location = x.Location,
                    RecordedBy = x.RecordedBy,
                    RecorderUtcOffset = x.RecorderUtcOffset.ToString(),
                    Rejected = x.Rejected,
                    ToCallLogID = x.ToCallLogID.ToString(),
                    UserID = x.UserID.ToString(),
                    XferFrom = x.XferFrom
                });

            }

            return
                result;
        }

        public NotesViewModels GetCasesDetailViewModel(long? relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, string URLBase, string LoanNumber, Func<string, string> EncodingUrl)
        {
            var notes = new List<string>(0);
            var NoteString = "<strong> Caso: </strong> {0} | Nota No: {1} <br>" +
                             "Canal de Servicio : {2} <br>" +
                             "Categoria : {3} <br>" +
                             "Tipo Contacto : {4} <br>" +
                             "Razón Contacto : {5} <br>" +
                             "<font color='green'> Nota </font> : {6} <hr>";
            var ord = 0;
            var FileOrd = 0;
            IEnumerable<CasesAttachedFiles> AttFiles = null;
            IEnumerable<PhoneCallViewModels> AttCalls = null;

            base.oApiService.loanManager.GetMeetingCaseNote(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId).dataResult.ToList().ForEach(x =>
            {
                ord++;
                notes.Add(string.Format(NoteString, x.CaseNumber, ord, x.ServiceChannelDesc, x.CategoryDesc, "", x.ReasonDesc, x.Note));
            });

            var oAttachedFile = base.oApiService.loanManager.GetMeetingCaseFile(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId).dataResult;
            if (oAttachedFile != null)
            {
                AttFiles = oAttachedFile.Select(p => new CasesAttachedFiles
                {
                    UrlFilePath = string.Format(URLBase, "/UploadsFiles/" + LoanNumber, p.documentName),
                    MeetingCaseNoteFileId = p.MeetingCaseNoteFileId,
                    FileName = p.documentName
                }).ToList();

                AttFiles.ToList().ForEach(g => { FileOrd++; g.FileNumber = FileOrd; });
            }

            var oAttachedCalls = base.oApiService.loanManager.GetMeetingCaseNoteCall(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, meetingCaseNoteId).dataResult;
            if (oAttachedCalls != null)
            {
                AttCalls = oAttachedCalls.Select(x => new PhoneCallViewModels
                      {
                          CallDuration = x.CallDuration.ToString(),
                          CallStart = x.CallStart.GetValueOrDefault(),
                          CallStop = x.CallStop.GetValueOrDefault(),
                          DialedNumber = x.DialedNumber,
                          Extension = x.Extension,
                          FileName = x.FileName,
                          FileLocation = x.FullPathFile,
                          CallLogID = x.CallLogId,
                          UserID = x.CallRexUserId,
                          UserName = string.Concat(x.UserFirstName, "", x.UserLastName)
                      }).ToList();
            }

            var Vm = new NotesViewModels
            {
                Cases = new List<Cases>(0),
                CasesDetailViewModels = new CasesDetailViewModels
                {
                    Notes = notes,
                    attachedFiles = AttFiles,
                    attachedCalls = AttCalls
                }
            };

            return
                Vm;
        }

        public AttachedFilesViewModels GetAttachedFilesViewModels()
        {
            var vm = new AttachedFilesViewModels();
            var dataDocumentType = base.GetDropDown(Enums.DropDownType.THDocumentTypeGroup)
              .Select(c => new BaseViewModels.KeyValue
              {
                  Value = c.Value,
                  Key = c.Key
              });

            var dataDocumentsGroup = base.GetDropDown(Enums.DropDownType.THDocumentGroup)
                .Select(c => new BaseViewModels.KeyValue
                {
                    Value = c.Value,
                    Key = c.Key
                });

            vm = new AttachedFilesViewModels
            {
                DocumentsTypes = dataDocumentType,
                DocumentsGroup = dataDocumentsGroup
            };

            return
                vm;
        }

        public MeetingNoteViewModels GetMeetingModel(long? CustomerId, string CustomerName, string LoanNumber, long? accountId, bool IsNewcase)
        {
            long? caseNumber = null;
            int? meetingStatusId = null;
            var Cases = base.oApiService.loanManager.GetMeetingCase(CustomerId, accountId, caseNumber, meetingStatusId).dataResult
                .Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.CaseNumber.ToString(),
                    Value = x.CaseNumber.ToString()
                });

            var Departments = base.GetDropDown(Enums.DropDownType.Department).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }).Where(o => o.Key == "3");

            var vm = new MeetingNoteViewModels
            {
                IsNewCase = IsNewcase,
                CasesStatusId = IsNewcase ? 1 : 0,
                relatedContactId = CustomerId,
                CustomerName = CustomerName,
                LoanNumber = LoanNumber,
                accountId = accountId,
                QueueType = new List<BaseViewModels.KeyValue>(0),
                Priority = base.GetDropDown(Enums.DropDownType.CallPriority).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                Cases = Cases,
                Services = base.GetDropDown(Enums.DropDownType.CallMeetingType).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                ChannelServices = base.GetDropDown(Enums.DropDownType.CallServiceChannel).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                SubServices = new List<BaseViewModels.KeyValue>(0),
                Categories = base.GetDropDown(Enums.DropDownType.CallCategory).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                ContactReason = base.GetDropDown(Enums.DropDownType.CallReason).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                ContactType = base.GetDropDown(Enums.DropDownType.CallReasonType).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                StatusCases = base.GetDropDown(Enums.DropDownType.CallMeetingStatus).Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.Key,
                    Value = x.Value
                }),
                Departments = Departments
            };

            return
                vm;
        }

        public int SetMeetingCase(Nullable<long> relatedContactId,
                                  Nullable<int> meetingTypeId,
                                  Nullable<int> meetingSubTypeId,
                                  Nullable<int> meetingCaseId,
                                  Nullable<long> accountId,
                                  Nullable<int> meetingStatusId,
                                  Nullable<int> reasonId,
                                  Nullable<int> departmentId,
                                  Nullable<int> categoryId,
                                  Nullable<long> caseNumber,
                                  Nullable<System.DateTime> meetingDate,
                                  string meetingShortNote,
                                  Nullable<int> callAssignedId,
                                  string notifiedToEmail,
                                  Nullable<bool> notified,
                                  Nullable<int> attemptNo,
                                  Nullable<bool> isActive,
                                  Nullable<int> userId,
                                  string userName,
                                  Nullable<System.DateTime> meetingClosedDate,
                                  Nullable<int> queueId
            )
        {
            var result = oApiService.loanManager.SetMeetingCase(relatedContactId,
                                                                meetingTypeId,
                                                                meetingSubTypeId,
                                                                meetingCaseId,
                                                                accountId,
                                                                meetingStatusId,
                                                                reasonId,
                                                                departmentId,
                                                                categoryId,
                                                                caseNumber,
                                                                meetingDate,
                                                                meetingShortNote,
                                                                callAssignedId,
                                                                notifiedToEmail,
                                                                notified,
                                                                attemptNo,
                                                                isActive,
                                                                userId,
                                                                userName,
                                                                meetingClosedDate,
                                                                queueId
                                                                ).SingleResult;


            return
                result.MeetingCaseId;
        }


        public long? SetMeetingNote(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> priorityId, Nullable<int> serviceChannelId, Nullable<int> originatedById, string note, Nullable<bool> isActive, Nullable<int> userId, string userName)
        {
            var result = oApiService.loanManager.SetMeetingNote(relatedContactId,
                                                                meetingTypeId,
                                                                meetingSubTypeId,
                                                                meetingCaseId,
                                                                meetingCaseNoteId,
                                                                priorityId,
                                                                serviceChannelId,
                                                                originatedById,
                                                                note,
                                                                isActive,
                                                                userId,
                                                                userName
                                                                )
                                                                .SingleResult;

            return
                result.MeetingCaseNoteId;
        }


        public long? SetMettingCaseFile(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId, Nullable<int> meetingCaseNoteFileId, Nullable<int> documentTypeGroupId, string documentPath, string documentName, string comments, Nullable<bool> isActive, Nullable<int> userId, string userName, Nullable<decimal> sizeFile)
        {
            var result = oApiService.loanManager.SetMeetingCaseFile(relatedContactId,
                                                                    meetingTypeId,
                                                                    meetingSubTypeId,
                                                                    meetingCaseId,
                                                                    meetingCaseNoteId,
                                                                    meetingCaseNoteFileId,
                                                                    documentTypeGroupId,
                                                                    documentPath,
                                                                    documentName,
                                                                    comments,
                                                                    isActive,
                                                                    userId,
                                                                    userName,
                                                                    sizeFile
                                                                    )
                                                                    .SingleResult;


            return
                  result.MeetingCaseNoteFileId;
        }


        public IEnumerable<AttachedFilesViewModels> GetMeetingCaseFile(Nullable<long> relatedContactId, Nullable<int> meetingTypeId, Nullable<int> meetingSubTypeId, Nullable<int> meetingCaseId, Nullable<int> meetingCaseNoteId)
        {
            var result = oApiService.loanManager.GetMeetingCaseFile(relatedContactId,
                                                                    meetingTypeId,
                                                                    meetingSubTypeId,
                                                                    meetingCaseId,
                                                                    meetingCaseNoteId
                                                                    ).dataResult
                                                                     .Select(x => new AttachedFilesViewModels
                                                                     {
                                                                         DocumentTypeDesc = "",
                                                                         FileName = x.documentName,
                                                                         DocumentPath = x.DocumentPath,
                                                                         documentGroupName = "",
                                                                         sizeFile = x.SizeFile
                                                                     });


            return
                 result;

        }

        public long SetMeetingCall(Nullable<long> relatedContactId,
                                   Nullable<int> meetingTypeId,
                                   Nullable<int> meetingSubTypeId,
                                   Nullable<int> meetingCaseId,
                                   Nullable<int> meetingCaseNoteId,
                                   Nullable<int> meetingCaseNoteCallId,
                                   Nullable<System.TimeSpan> callDuration,
                                   Nullable<System.DateTime> callStart,
                                   Nullable<System.DateTime> callStop,
                                   string dialedNumber, string extension,
                                   string fileName,
                                   string fullPathFile,
                                   string callLogId,
                                   string callRexUserId,
                                   string userFirstName,
                                   string userLastName,
                                   Nullable<bool> isActive,
                                   Nullable<int> userId,
                                   string userName
                                  )
        {

            var result = oApiService.loanManager.SetMeetingCall(relatedContactId,
                                                                meetingTypeId,
                                                                meetingSubTypeId,
                                                                meetingCaseId,
                                                                meetingCaseNoteId,
                                                                meetingCaseNoteCallId,
                                                                callDuration,
                                                                callStart,
                                                                callStop,
                                                                dialedNumber,
                                                                extension,
                                                                fileName,
                                                                fullPathFile,
                                                                callLogId,
                                                                callRexUserId,
                                                                userFirstName,
                                                                userLastName,
                                                                isActive,
                                                                userId,
                                                                userName
                                                                ).SingleResult;

            return
                 result.MeetingCaseNoteCallId;

        }



        public void SetMeeting(MeetingNoteViewModels model, List<AttachedFilesViewModels> oTemDataNoteAttachedFiles)
        {
            long? relatedContactId = model.relatedContactId;
            int? meetingTypeId = model.ServiceId;
            int? meetingSubTypeId = model.SubServiceId;
            int? meetingCaseId = model.meetingCaseId;
            long? accountId = model.accountId;
            int? meetingStatusId = model.IsNewCase ? 1 : model.CasesStatusId;
            int? reasonId = model.ContactReasonId;
            int? departmentId = null;
            int? categoryId = model.CategoryId;
            long? caseNumber = model.CaseId;
            DateTime? meetingDate = DateTime.Now;
            string meetingShortNote = "";
            int? callAssignedId = null;
            string notifiedToEmail = null;
            bool? notified = null;
            int? attemptNo = null;
            bool? isActive = true;
            int? userId = model.UserId;
            Nullable<System.DateTime> meetingClosedDate = (model.CasesStatusId == 2) ? DateTime.Now : (DateTime?)null;
            Nullable<int> queueId = null;
            string userName = model.UserName;

            //1.- Crear el caso
            var MeetingCaseId = SetMeetingCase(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, accountId, meetingStatusId, reasonId, departmentId, categoryId,
                                                              caseNumber, meetingDate, meetingShortNote, callAssignedId, notifiedToEmail, notified, attemptNo, isActive, userId,
                                                              userName, meetingClosedDate, queueId);


            //2.- Crear la nota
            var CaseNoteId = SetMeetingNote(relatedContactId,
                                                           meetingTypeId,
                                                           meetingSubTypeId,
                                                           (meetingCaseId.HasValue) ? meetingCaseId : MeetingCaseId,
                                                           model.meetingCaseNoteId,
                                                           model.PriorityId,
                                                           model.ChannelServiceId,
                                                           model.originatedById,
                                                           model.Note,
                                                           isActive,
                                                           userId,
                                                           userName);



            switch (model.ChannelServiceId)
            {
                case 2:
                    //Guardar la llamada seleccionada
                    //var KeyCalls = Utility.deserializeJSON<List<Utility.ItemCalls>>(model.CallsSelected);
                    var KeyCalls = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Utility.ItemCalls>>(model.CallsSelected);
                    foreach (var KeyCall in KeyCalls)
                    {
                        var ResultSetMeetinsCaseCall = SetMeetingCall(relatedContactId,
                                                                                     meetingTypeId,
                                                                                     meetingSubTypeId,
                                                                                     MeetingCaseId,
                                                                                     (int)CaseNoteId,
                                                                                     null,
                                                                                     TimeSpan.Parse(KeyCall.CallDuration),
                                                                                     KeyCall.CallStart,
                                                                                     KeyCall.CallStop,
                                                                                     KeyCall.DialedNumber,
                                                                                     KeyCall.Extension,
                                                                                     KeyCall.FileName,
                                                                                     KeyCall.FileLocation,
                                                                                     KeyCall.CallLogID.ToString(),
                                                                                     KeyCall.UserID.ToString(),
                                                                                     KeyCall.FirstName,
                                                                                     KeyCall.LastName,
                                                                                     isActive,
                                                                                     userId,
                                                                                     userName
                                                                                     );
                    }

                    break;
                case 1:
                case 3:
                case 4:
                case 5:
                case 6:
                    //Guardar los archivos adjuntos
                    if (oTemDataNoteAttachedFiles != null)
                    {
                        string comments = "";
                        foreach (var item in oTemDataNoteAttachedFiles)
                        {
                            //Guardar en la base de datos
                            var ResultSetMettingCaseFile = SetMettingCaseFile(relatedContactId,
                                                                              meetingTypeId,
                                                                              meetingSubTypeId,
                                                                              MeetingCaseId,
                                                                              (int?)CaseNoteId,
                                                                              null,
                                                                              item.DocumentGroupId,
                                                                              item.DocumentPath,
                                                                              item.FileName,
                                                                              comments,
                                                                              isActive,
                                                                              userId,
                                                                              userName,
                                                                              item.sizeFile
                                                                             );
                        }

                        oTemDataNoteAttachedFiles = null;
                    }
                    break;
            }


            //Guardar el seguimiento en caso de que tenga uno
            if (model.HasSelectedTracing)
            {
                Nullable<System.DateTime> actionDate = model.Automatictracing;

                SetQueue(0,
                         model.accountId,
                         1,//queueTypeId,
                         2,//distributionId,
                         model.DepartmentId,
                         model.DepartmentId,
                         1,//queueStatusId,
                         null,//vendorId,
                         null,//assingToId,
                         null,//transactionPaymentPlanId,
                         1,//queueSourceId,
                         model.LoanNumber,
                         0,//daysLate,
                         actionDate,
                         null,//endDate,
                         true,//isActive,
                         model.Comments,
                         model.UserId,
                         model.UserName
                       );
            }
        }


        public long? SetQueue(Nullable<long> queueId, Nullable<long> accountId, Nullable<int> queueTypeId, Nullable<int> distributionId, Nullable<int> submittedByDepartmentId, Nullable<int> transferredFromDepartmentId, Nullable<int> queueStatusId, Nullable<long> vendorId, Nullable<long> assingToId, Nullable<long> transactionPaymentPlanId, Nullable<int> queueSourceId, string accountReference, Nullable<int> daysLate, Nullable<System.DateTime> actionDate, Nullable<System.DateTime> endDate, Nullable<bool> isActive, string cOMMENTS, Nullable<int> userId, string userName)
        {
            var result = oApiService.loanManager.SetQueue(queueId,
                                             accountId,
                                             queueTypeId,
                                             distributionId,
                                             submittedByDepartmentId,
                                             transferredFromDepartmentId,
                                             queueStatusId,
                                             vendorId,
                                             assingToId,
                                             transactionPaymentPlanId,
                                             queueSourceId,
                                             accountReference,
                                             daysLate,
                                             actionDate,
                                             endDate,
                                             isActive,
                                             cOMMENTS,
                                             userId,
                                             userName
                                             )
                                             .SingleResult;

            return
                result.QueueId;
        }


        #region Thunderhead
        public Tuple<string, byte[], int?> GetDocumentFromTH(string TemplateType,
                                                             string ServerMapPath,
                                                             double MontoApagar,
                                                             long AccountId,
                                                             DateTime StartDate,
                                                             string LoanType,
                                                             string NumeroCuota,
                                                             bool IsPreview,
                                                             string Emails = "",
                                                             string PathAttachmentTHKSI = "",
                                                             IEnumerable<AttachedFiles> oAttachedFiles = null
                                                             )
        {
            try
            {
                byte[] Pdf = null;
                int? BachId = null;
                Tuple<string, byte[], int?> result = new Tuple<string, byte[], int?>("", null, null);
                var DocumentId = string.Empty;
                var objService = new ThunderheadWrap.Service();
                var templateType = (Enums.TemplateType)Enum.Parse(typeof(Enums.TemplateType), TemplateType);
                byte[] xmlData = null;
                var outputFileName = string.Empty;

                var oTransaction = new TH.Transaction();
                var oRecipients = new TH.Recipient();
                var oFinancing = new TH.Financing();
                var oLoan = new TH.Loan();
                var oClient = new TH.Client();
                var oAttachment = new List<TH.Attachment>(0);

                var dataLoanDetail = oApiService.loanManager.GetLoanDetail(null, null, AccountId).entity;
                outputFileName = string.Concat(@"\TmpFiles\", Enums.TemplateType.COBBalanceDeSaldo.ToString(), ".pdf");
                switch (templateType)
                {
                    case Enums.TemplateType.COBCartaDeSaldoCuotas:
                        DocumentId = "1648501050";
                        break;
                    case Enums.TemplateType.COBBalanceDeSaldo:
                        DocumentId = "1648501049";
                        break;
                }

                oTransaction.DocumentId = DocumentId;
                oLoan.LoanType = LoanType;
                oClient.Name = dataLoanDetail.fullName;
                oLoan.Client = oClient;
                oLoan.LoanNo = dataLoanDetail.account;
                oLoan.StartDate = string.Format(CultureInfo.InvariantCulture, "{0:dd/MM/yyyy}", StartDate);
                oLoan.LoanAmount = MontoApagar.ToString(CultureInfo.InvariantCulture);
                oLoan.LoanAmountString = Numalet.ToCardinal(MontoApagar).ToUpper();

                var oFeeList = new List<Common.Thunderhead.Fee>(){new Common.Thunderhead.Fee 
                {
                    Number= NumeroCuota,
                    Amount = MontoApagar.ToString(CultureInfo.InvariantCulture),
                    FeeAmountString = Numalet.ToCardinal(MontoApagar).ToUpper()
                }};

                oLoan.Fee = oFeeList;
                oFinancing.Loan = oLoan;

                if (oAttachedFiles != null && oAttachedFiles.Any())
                {
                    foreach (var item in oAttachedFiles)
                    {
                        var PathKSI = string.Concat(PathAttachmentTHKSI, @"\", item.FileName);
                        oAttachment.Add(new TH.Attachment
                        {
                            Path = PathKSI,
                            Description = item.FileName
                        });

                        //copiar en ruta
                        var PathTarget = string.Concat(ServerMapPath, @"UploadsFiles\", System.Web.HttpUtility.UrlDecode(item.DocumentPath));
                        var PDFApp = File.ReadAllBytes(PathTarget);
                        File.WriteAllBytes(PathKSI, PDFApp);
                    }

                }

                var oDataset = new TH.Dataset();
                oDataset.Transaction = oTransaction;
                oRecipients.UserEmail = Emails;
                oDataset.Recipients = oRecipients;
                oDataset.Financing = oFinancing;
                oDataset.Attachment = oAttachment;

                var XML = Utility.SerializeToXMLString(oDataset);
                xmlData = Encoding.UTF8.GetBytes(XML);
                if (IsPreview)
                {
                    Pdf = objService.sendRequest(xmlData);
                    //File.WriteAllBytes(ServerMapPath + outputFileName, Pdf);
                }
                else
                    BachId = objService.sendRequestSubmitBatch(xmlData);

                result = new Tuple<string, byte[], int?>(outputFileName, Pdf, BachId);

                return
                    result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion


        #region Cobranza
        public CollectionViewModels GetCollection(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            CollectionViewModels colec = new CollectionViewModels();
            colec.CardDomitiliationViewModel = GetCardDomitiliation(accountId);
            colec.CollectionHistoryPaymentViewModels = GetCollectionHistoryPayment(accountId, null, null, null, null);
            colec.CollectionPaymentViewModels = GetCollectionsPayments(accountId);
            colec.accountId = accountId;

            if (colec.CollectionHistoryPaymentViewModels != null && colec.CollectionHistoryPaymentViewModels.Count() > 0)
                colec.PaidTotal = colec.CollectionHistoryPaymentViewModels.Sum(a => a.PaidAmount);

            if (colec.CardDomitiliationViewModel != null)
                colec._dataRequest = colec.CardDomitiliationViewModel._dataRequest;

            return colec;
        }

        public List<CollectionHistoryPaymentViewModels> GetCollectionHistoryPayment(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            var dataObj = new List<CollectionHistoryPaymentViewModels>();

            var data = base.oApiService.loanManager.GetPaymentAndDebt(accountId, DebtF, DebtT, PaidF, PaidT);
            if (data != null && data.dataResult != null)
            {

                if (data.dataResult != null)
                    dataObj = data.dataResult.Where(r => r.QuotaAmountBalance == 0 /*solo las cuotas pagadas completa*/).Select(r => new CollectionHistoryPaymentViewModels
                     {
                         DatePaid = r.PaidDate,
                         DueDate = r.DueDate,
                         PaidAmount = r.PaidAmount,
                         QuotaAmount = r.QuotaAmount,
                         QuotaNumber = r.QuotaNumber
                     }).ToList();
            }
            return dataObj;
        }
        public List<CollectionPaymentViewModels> GetCollectionPendingPayment(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            var dataObj = new List<CollectionPaymentViewModels>();

            var data = base.oApiService.loanManager.GetPaymentAndDebt(accountId, DebtF, DebtT, PaidF, PaidT);
            if (data != null)
            {
                dataObj = data.dataResult.Where(r => r.QuotaAmountBalance != 0 /*solo las cuotas pagadas completa*/).Select(r => new CollectionPaymentViewModels
                {
                    DatePaid = r.PaidDate,
                    DueDate = r.DueDate,
                    PaidAmount = r.PaidAmount,
                    QuotaAmount = r.QuotaAmount,
                    QuotaNumber = r.QuotaNumber,
                    QuotaAmountBalance = r.QuotaAmountBalance
                }).ToList();
            }
            return dataObj;
        }

        public CardDomitiliationViewModel GetCardDomitiliation(long? accountId)
        {
            CardDomitiliationViewModel model = new CardDomitiliationViewModel
            {
                CardTypes = base.GetDropDown(Enums.DropDownType.cardtype).ToList(),
                StatusTypes = new List<BaseViewModels.KeyValue>
                {
                    new  BaseViewModels.KeyValue {Key="1",Value="Activo"},
                    new  BaseViewModels.KeyValue {Key="2",Value="Inactivo"}
                },
                Years = GetYears().Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.ToString(),
                    Value = x.ToString()
                }).ToList(),
                AffiliateCards = base.oApiService.loanManager.GetLoanDomiciliationCard(accountId, null).dataResult.Select(r => new CardDomitiliationViewModel
                {
                    CardTypeId = r.CardTypeId,
                    StatusId = r.isActive.GetValueOrDefault() ? 1 : 2,
                    CardNumber = r.CardNumber,
                    CardHolder = r.CardHolder,
                    CardExpirationYear = int.Parse(r.ExpirationDateYYMM.Substring(0, 2)),
                    CardExpirationMonth = int.Parse(r.ExpirationDateYYMM.Substring(2, 2)),
                    ExpirationDate = r.ExpirationDateYYMM,
                    CardTypeDesc = r.CardTypeDesc,
                    LastFourDigits = r.LastFourDigits,
                    StatusDesc = r.StatusDesc,

                    _dataRequest = Utility.URLEncrypt(Utility.serializeToJSON(new dataRequestCard
                    {
                        accountId = r.accountId,
                        CardTypeId = r.CardTypeId,
                        clientId = r.clientId,
                        LastFourDigits = r.LastFourDigits
                    })),

                })
                ,
                _dataRequest = Utility.URLEncrypt(Utility.serializeToJSON(new dataRequest
              {
                  accountId = accountId,
                  CustomerId = null,
                  RequestId = null
              })),
            };
            model.IsEditMode = "";
            return
                model;
        }

        public Loan.CardDomitiliation SetCardDomiciliation(Nullable<long> clientId, Nullable<int> cardTypeId, string lastFourDigits, string cardNumber, Nullable<System.DateTime> expirationDate, string cVV2, string cardHolder, string expirationDateMMYYYY, Nullable<bool> isActive, Nullable<int> userId, Nullable<long> accountId, Nullable<bool> isMain, Nullable<bool> applyRange, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo, Nullable<bool> isActiveLoan)
        {
            var result = base.oApiService.loanManager.SetDomitiliatonCard(clientId,
                                                                          cardTypeId,
                                                                          lastFourDigits,
                                                                          cardNumber,
                                                                          expirationDate,
                                                                          cVV2,
                                                                          cardHolder,
                                                                          expirationDateMMYYYY,
                                                                          isActive,
                                                                          userId,
                                                                          accountId,
                                                                          isMain,
                                                                          applyRange,
                                                                          dateFrom,
                                                                          dateTo,
                                                                          isActiveLoan
                                                                          );
            return
                result.SingleResult;
        }

        public CardDomitiliationViewModel GetEditCardDomitiliationViewModel(Nullable<long> accountId, Nullable<long> clientId, Nullable<long> CardTypeId, String LastFourDigits)
        {
            CardDomitiliationViewModel model = new CardDomitiliationViewModel
            {
                CardTypes = base.GetDropDown(Enums.DropDownType.cardtype).ToList(),
                StatusTypes = new List<BaseViewModels.KeyValue>
                {
                    new  BaseViewModels.KeyValue {Key="1",Value="Activo"},
                    new  BaseViewModels.KeyValue {Key="2",Value="Inactivo"}
                },
                Years = GetYears().Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.ToString(),
                    Value = x.ToString()
                }).ToList(),
                AffiliateCards = base.oApiService.loanManager.GetLoanDomiciliationCard(accountId, clientId).dataResult.Select(r => new CardDomitiliationViewModel
                {
                    CardTypeId = r.CardTypeId,
                    StatusId = r.isActive.GetValueOrDefault() ? 1 : 2,
                    CardNumber = r.CardNumber,
                    CardHolder = r.CardHolder,
                    CardExpirationYear = int.Parse(r.ExpirationDateYYMM.Substring(0, 2)),
                    CardExpirationMonth = int.Parse(r.ExpirationDateYYMM.Substring(2, 2)),
                    ExpirationDate = r.ExpirationDateYYMM,
                    CardTypeDesc = r.CardTypeDesc,
                    AccountId = r.accountId.Value,
                    LastFourDigits = r.LastFourDigits,
                    StatusDesc = r.StatusDesc,
                    _dataRequest = Utility.URLEncrypt(Utility.serializeToJSON(new dataRequestCard
                    {
                        accountId = r.accountId,
                        CardTypeId = r.CardTypeId,
                        clientId = r.clientId,
                        LastFourDigits = r.LastFourDigits
                    })),

                })
            };

            var d = model.AffiliateCards.Where(w => w.LastFourDigits.ToLower().Trim() == LastFourDigits.ToLower().Trim() && w.CardTypeId == CardTypeId).FirstOrDefault();

            if (d != null)
            {
                model.AccountId = d.AccountId;
                model.CardExpirationMonth = d.CardExpirationMonth;
                model.CardExpirationYear = Int32.Parse((DateTime.Now.Year.ToString().Substring(0, 2) + d.CardExpirationYear.ToString()));
                model.CardHolder = d.CardHolder;
                model.CardNumber = d.CardNumber;
                model.CardTypeDesc = d.CardTypeDesc;
                model.CardTypeId = d.CardTypeId;
                model.CustomerId = d.CustomerId;
                model.StatusId = d.StatusId;
                model.ExpirationDate = d.ExpirationDate;
                model._dataRequest = d._dataRequest;
                model.LastFourDigits = d.LastFourDigits;
                model.StatusDesc = d.StatusDesc;
            }

            model.IsEditMode = "disabled";
            return
                model;

        }

        private IEnumerable<int> GetYears()
        {
            var result = new List<int>(0);

            var YearFrom = DateTime.Now.Year;
            var YearTo = DateTime.Now.AddYears(20).Year;
            for (int i = YearFrom; i < YearTo; i++)
                result.Add(i);

            return
                result;
        }

        public IEnumerable<BaseViewModels.KeyValue> GetMonhts(int Year)
        {
            var result = new List<BaseViewModels.KeyValue>(0);

            var YearSelected = Year;
            var InitialMonth = DateTime.Now.Month;

            //Si el año es el año en curso cargar el dropdown de los meses a partir del mes actual
            InitialMonth = (YearSelected == DateTime.Now.Year) ? DateTime.Now.Month : 1;

            for (int i = InitialMonth; i <= 12; i++)
                result.Add(new BaseViewModels.KeyValue { Key = i.ToString(), Value = i.ToString() });

            result.Insert(0, new BaseViewModels.KeyValue { Key = "--", Value = "" });

            return
                 result;
        }

        public List<CollectionPaymentViewModels> GetCollectionsPayments(long? accountId)
        {
            var dataObj = new List<CollectionPaymentViewModels>();
            var data = base.oApiService.loanManager.GetPaymentAndDebt(accountId, null, null, null, null);
            if (data != null && data.dataResult != null)
            {
                dataObj = data.dataResult.Where(r => r.QuotaAmountBalance != 0 /*solo las cuotas pagadas completa*/).Select(r => new CollectionPaymentViewModels
                {
                    DatePaid = r.PaidDate,
                    DueDate = r.DueDate,
                    PaidAmount = r.PaidAmount,
                    QuotaAmount = r.QuotaAmount,
                    QuotaNumber = r.QuotaNumber,
                    QuotaAmountBalance = r.QuotaAmountBalance,
                    Balance = r.Balance,
                    LatePay = r.LatePay,
                    AmountToPay = r.AmountToPay
                }).ToList();
            }

            return
                dataObj;
        }

        public PaymentProcessViewModels GetPaymentProcessModel(long? AccountId)
        {
            var dataLoan = GetCollectionsPayments(AccountId);
            var HasRecord = dataLoan.Any();

            var model = new PaymentProcessViewModels
            {
                AccountId = AccountId.GetValueOrDefault(),
                Balance = HasRecord ? dataLoan.FirstOrDefault().Balance : 0,
                AmountReceivable = HasRecord ? dataLoan.FirstOrDefault().AmountToPay : 0,
                share = HasRecord ? dataLoan.FirstOrDefault().LatePay : 0,
                CardTypes = base.GetDropDown(Enums.DropDownType.cardtype).ToList(),
                Years = GetYears().Select(x => new BaseViewModels.KeyValue
                {
                    Key = x.ToString(),
                    Value = x.ToString()
                }).ToList(),
            };

            return
                model;
        }

        public Loan.CreditDebitDirectPayment SetPaymentProcess(Nullable<long> creditDebitDirectPaymentId, Nullable<long> accountId, Nullable<int> cardTypeId, Nullable<int> directPaymentStatusId, string cardNumber, string lastFourDigits, string cardName, Nullable<int> yearExpiration, Nullable<int> monthExpiration, Nullable<decimal> quotaAmount, Nullable<decimal> balance, Nullable<decimal> amountPaid, Nullable<System.DateTime> datePaid, Nullable<System.DateTime> dateProcessedCard, Nullable<System.DateTime> dateProcessedEasybank, string authorizationNumber, string receiptNumberEasybank, Nullable<int> userId, string userName)
        {
            var result = base.oApiService.loanManager.SetCreditDebitDirectPayment(creditDebitDirectPaymentId, accountId, cardTypeId, directPaymentStatusId, cardNumber, lastFourDigits, cardName, yearExpiration, monthExpiration, quotaAmount, balance, amountPaid, datePaid, dateProcessedCard, dateProcessedEasybank, authorizationNumber, receiptNumberEasybank, userId, userName).SingleResult;

            return
                result;
        }

        public CorrespondenceViewModels GetLoanCorrespondence(Nullable<long> accountId)
        {
            var dataDocumentType = base.GetDropDown(Enums.DropDownType.THDocumentTypeGroup)
                .Select(c => new BaseViewModels.KeyValue
                {
                    Value = c.Value,
                    Key = c.Key
                });

            var dataDocumentsGroup = base.GetDropDown(Enums.DropDownType.THDocumentGroup)
                .Select(c => new BaseViewModels.KeyValue
                {
                    Value = c.Value,
                    Key = c.Key
                });

            var Departments = base.GetDropDown(Enums.DropDownType.Department)
                .Select(c => new BaseViewModels.KeyValue
                {
                    Value = c.Value,
                    Key = c.Key
                });

            var DepartmentsWithEmail = base.GetDropDown(Enums.DropDownType.DepartmentWithEmail)
                .Select(c => new BaseViewModels.KeyValue
                {
                    Value = c.Value,
                    Key = c.Key
                });

            var Subjects = base.GetDropDown(Enums.DropDownType.Subjects)
                .Select(c => new BaseViewModels.KeyValue
                {
                    Value = c.Value,
                    Key = c.Key
                });

            var RelatedDocs = new List<AttachedFiles>(0);

            var data = base.oApiService.loanManager.GetLoanCorrespondence(accountId).SingleResult;
            var Templates = GetTemplate().Select(t => new TemplateDocument
            {
                TemplateId = t.TemplateId,
                TemplateName = t.TemplateName,
                TemplateCode = t.TemplateCode,
                PartialViewName = t.PartialViewName,
                Description = t.Description,
                DocumentNameKey = t.DocumentNameKey
            }).
              ToList();

            var model = new CorrespondenceViewModels
            {
                CaseNumber = data.CaseNo,
                LoanNumber = data.accountID,
                ProductType = data.ConceptTypeName,
                CaseType = data.CanseTypeName,
                Department = data.DepartmentName,
                PrincipalCustomer = data.clientName,
                PrincipalAgent = data.AgentFullName,
                PrincipalOffice = data.OficinaFullName,
                TemplateDocuments = Templates,
                DocumentsTypes = dataDocumentType,
                DocumentsGroup = dataDocumentsGroup,
                PrimaryCustomer = data.EmailMainClient,
                SecundaryCustomer = data.EmailAddClient,
                PrimaryAgent = data.EmailAgent,
                Office = data.EmailOffice,
                Provider = data.EmailProvider,
                Extra = data.EmailAdd,
                Departments = DepartmentsWithEmail,
                Subjects = Subjects,
                TracingTypes = Departments,
                TracingDate = DateTime.Now,
                Tracinghour = DateTime.Now.ToString("HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                AttachedFiles = new List<AttachedFiles>(0)
            };

            return
                model;
        }

        public IEnumerable<Loan.Template> GetTemplate(Nullable<long> templateId = null)
        {
            var result = base.oApiService.loanManager.GetTemplate(templateId).dataResult;

            return
                result;
        }

        #endregion


        #region CardNet
        /// <summary>
        /// Aplicar pago por CardNet
        /// </summary>
        /// <param name="CredicardNumber"></param>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="CreditVerificationValue"></param>
        /// <param name="Amount"></param>
        /// <param name="Tax"></param>
        /// <param name="userName"></param>
        /// <param name="SourceApp"></param>
        /// <returns></returns>
        public CardNetViewModels ApplyPaymentCardNet(string CredicardNumber,
                                                     string Year,
                                                     string Month,
                                                     string CreditVerificationValue,
                                                     decimal Amount,
                                                     decimal Tax,
                                                     string userName,
                                                     string SourceApp
            )
        {

            var result = new CardNetViewModels();

            try
            {
                var resultApplyPayment = CardNetProxy.ApplyPayment(CredicardNumber,
                                                                   Year,
                                                                   Month,
                                                                   CreditVerificationValue,
                                                                   Amount,
                                                                   Tax,
                                                                   userName,
                                                                   SourceApp
                                                                   );


                return new CardNetViewModels
                {
                    AuthorizationCode = resultApplyPayment.AuthorizationCode,
                    CreditCardNumber = resultApplyPayment.CreditCardNumber,
                    JSonResult = resultApplyPayment.JSonResult,
                    OrdenId = resultApplyPayment.OrdenId,
                    ResponseCode = resultApplyPayment.ResponseCode,
                    Result = resultApplyPayment.Result,
                    ResultMessager = resultApplyPayment.ResultMessager,
                    RetrivalReferenceNumber = resultApplyPayment.RetrivalReferenceNumber,
                    TransactionId = resultApplyPayment.TransactionId,
                    _jsonResult = Utility.deserializeJSON<JsnResult>(resultApplyPayment.JSonResult)
                };
            }
            catch (Exception e)
            {
                var msg = string.Format("ExceptionMessage {0} InnerException {1} TraceStack {2}", e.Message, e.InnerException != null ? e.InnerException.Message : "", e.StackTrace);
                return new CardNetViewModels
                {
                    hasError = true,
                    ModelErrorList = new List<string>() { msg }
                };
            }
        }
        #endregion


        #region EasyBank
        public EasyBankViewModels ApplyPaymentEasyBank(string Account, decimal MontoAplicadoEasybank, int Canal)
        {
            var result = new EasyBankViewModels();

            try
            {
                var resultApply = EasyProxy.ApplyPayToEasyBank(Account, MontoAplicadoEasybank, Canal);

                return new EasyBankViewModels
                {
                    DetalleCuota = resultApply.DetalleCuota,
                    NoRecibo = resultApply.NoRecibo,
                    SaldoPrestamo = resultApply.SaldoPrestamo,
                    ErrorCode = resultApply.ErrorCode,
                    ErrorMessage = resultApply.ErrorMessage
                };
            }
            catch (Exception e)
            {
                var msg = string.Format("ExceptionMessage {0} InnerException {1} TraceStack {2}", e.Message, e.InnerException != null ? e.InnerException.Message : "", e.StackTrace);
                return new EasyBankViewModels
                {
                    hasError = true,
                    ModelErrorList = new List<string>() { msg }
                };
            }
        }
        #endregion
    }
}