﻿using KSI.Cobranza.Web.Common;
using KSI.Cobranza.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using KSI.Cobranza.LogicLayer;
using KSI.Cobranza.EntityLayer;

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

        public ProcessModel()
        {
            @Model = new Lazy<ProcessViewModels>().Value;
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

        public LoanInformationViewModels GetLoanDetail(long? quotationId, int? loanNumber, long? accountId)
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
                TipoSaldo = r.TipoSaldo
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


        #region Cobranza
        public CollectionViewModels GetCollection(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            CollectionViewModels colec = new CollectionViewModels();
            colec.CardDomitiliationViewModel = GetCardDomitiliation(accountId);
            colec.CollectionHistoryPaymentViewModels = GetCollectionHistoryPayment(accountId, null, null, null, null);
            colec.CollectionPaymentViewModels = GetCollectionsPayments(accountId);
            colec.accountId = accountId;

            if (colec.CollectionHistoryPaymentViewModels != null && colec.CollectionHistoryPaymentViewModels.Count() > 0)
            {
                colec.PaidTotal = colec.CollectionHistoryPaymentViewModels.Sum(a => a.PaidAmount);
            }

            if (colec.CardDomitiliationViewModel != null)
            {
                colec._dataRequest = colec.CardDomitiliationViewModel._dataRequest;
            }


            return colec;
        }

        public List<CollectionHistoryPaymentViewModels> GetCollectionHistoryPayment(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            var dataObj = new List<CollectionHistoryPaymentViewModels>();

            var data = base.oApiService.loanManager.GetPaymentAndDebt(accountId, DebtF, DebtT, PaidF, PaidT);
            if (data != null)
            {
                dataObj = data.dataResult.Where(r => r.QuotaAmountBalance == 0 /*solo las cuotas pagadas completa*/).Select(r => new CollectionHistoryPaymentViewModels
                {
                    DatePaid = r.PaidDate
                    ,
                    DueDate = r.DueDate
                    ,
                    PaidAmount = r.PaidAmount
                    ,
                    QuotaAmount = r.QuotaAmount
                    ,
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
                    DatePaid = r.PaidDate
                      ,
                    DueDate = r.DueDate
                      ,
                    PaidAmount = r.PaidAmount
                      ,
                    QuotaAmount = r.QuotaAmount
                      ,
                    QuotaNumber = r.QuotaNumber
                    ,
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
                        accountId = r.accountId
                        ,
                        CardTypeId = r.CardTypeId
                        ,
                        clientId = r.clientId
                        ,
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
                        accountId = r.accountId
                        ,
                        CardTypeId = r.CardTypeId
                        ,
                        clientId = r.clientId
                        ,
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
            if (data != null)
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

            var model = new PaymentProcessViewModels
            {
                AccountId = AccountId.GetValueOrDefault(),
                Balance = dataLoan.FirstOrDefault().Balance,
                AmountReceivable = dataLoan.FirstOrDefault().AmountToPay,
                share = dataLoan.FirstOrDefault().LatePay,
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

        #endregion
    }
}