using System;
using System.Collections.Generic;
using System.Linq;
using Entity.UnderWriting.Entities;
using Entity.UnderWriting.IllusData;
using LOGIC.UnderWriting.Common;
using ServicesApi.UnderWriting.Common;
using ServicesApi.UnderWriting.Common.Model;

namespace ServicesApi.UnderWriting.PolicyIllustration
{
    public class PolicyIllustrationService : CommonService, IPolicyIllustrationService
    {
        #region Private Properties
        private bool _usingTest = System.Configuration.ConfigurationManager.AppSettings["UsingTest"] == "true";
        private long _customerPlanNo;
        private int _corpId;
        private int _regionId;
        private int _countryId;
        private int _domesticregId;
        private int _stateProvId;
        private int _cityId;
        private int _officeId;
        private int _caseSeqNo;
        private int _histSeqNo;
        private int _userId;
        private int _companyId;
        private int _projectId;
        #endregion

        #region private Methods
        private Entity.UnderWriting.Entities.DropDown.Parameter GetGlobalParameterWithBasicValues(string product = null)
        {
            return new Entity.UnderWriting.Entities.DropDown.Parameter
                {
                    CorpId = _corpId,
                    RegionId = _regionId,
                    CountryId = _countryId,
                    DomesticregId = _domesticregId,
                    StateProvId = _stateProvId,
                    CityId = _cityId,
                    OfficeId = _officeId,
                    NameKey = product,
                    CompanyId = _companyId,
                    ProjectId = _projectId
                };
        }

        private void SetCustomerPlanDetail(Illustrator.CustomerPlanDetail customerPlanDetail)
        {
            var planGlobal = _uManager.IIllusDataManager.GetCustomerPlanDetGlobalPolicy(new Illustrator.CustomerPlanDetGlobalPolicy
            {
                CustomerPlanNo = _customerPlanNo
            });

            var policy = new Policy();

            if (planGlobal == null)
            {
                planGlobal = new Illustrator.CustomerPlanDetGlobalPolicy();
                planGlobal.CorpId = _corpId;
                planGlobal.RegionId = _regionId;
                planGlobal.CountryId = _countryId;
                planGlobal.DomesticRegId = _domesticregId;
                planGlobal.StateProvId = _stateProvId;
                planGlobal.CityId = _cityId;
                planGlobal.OfficeId = _officeId;
                planGlobal.CustomerPlanNo = _customerPlanNo;

                var customerDetail =
                    _uManager.IIllusDataManager.GetCustomerDetailById(customerPlanDetail.CustomerNo, null);

                policy = _uManager.PolicyManager.NewPolicyWithoutAgent(new Case.NewCase
                {
                    CorpId = _corpId,
                    RegionId = _regionId,
                    CountryId = _countryId,
                    DomesticregId = _domesticregId,
                    StateProvId = _stateProvId,
                    CityId = _cityId,
                    OfficeId = _officeId,
                    ContactId = Convert.ToInt32(customerDetail.RCustomerNo.GetValueOrDefault()),
                    UserId = _userId,
                    IsIllustration = true,
                    IllustrationNo = customerPlanDetail.DispIllustrationNo
                });

                _caseSeqNo = planGlobal.CaseSeqNo = policy.CaseSeqNo;
                _histSeqNo = planGlobal.HistSeqNo = policy.HistSeqNo;

                _uManager.IIllusDataManager.InsertCustomerPlanDetGlobalPolicy(planGlobal);
            }
            else
            {
                _histSeqNo = planGlobal.HistSeqNo;
                _caseSeqNo = planGlobal.CaseSeqNo;
                policy = _uManager.PolicyManager.GetPolicy(
                    _corpId,
                    _regionId,
                     _countryId,
                     _domesticregId,
                   _stateProvId,
                    _cityId,
                    _officeId,
                    _caseSeqNo,
                    _histSeqNo
                    );
            }

            var gParameters = GetGlobalParameterWithBasicValues();

            var product = customerPlanDetail.Product.Replace(" Básico", "");
            var gProductType = CommonService.GetDropDownByType(CommonService.DropDownType.Product, gParameters).Single(o => o.ProductDesc.ToLower() == product.ToLower());
            policy.BussinessLineType = gProductType.BlTypeId;
            policy.BussinessLineId = gProductType.BlId;
            policy.ProductId = gProductType.ProductId;

            gParameters.ProductTypeId = gProductType.ProductTypeId;
            var gSerie = CommonService.GetDropDownByType(CommonService.DropDownType.Serie, gParameters).FirstOrDefault(o => o.SerieDesc == customerPlanDetail.PlanType);
            if (gSerie != null)
                policy.PolicySerieId = gSerie.PolicySerieId;

            gParameters = GetGlobalParameterWithBasicValues(product);
            var gCurrency = CommonService.GetDropDownByType(CommonService.DropDownType.Currency, gParameters).FirstOrDefault(o => o.CurrencyDesc == customerPlanDetail.CurrencyCode);
            if (gCurrency != null)
                policy.CurrencyId = gCurrency.CurrencyId;

            policy.SubmitDate = DateTime.Now;

            var gContributionType = CommonService.GetDropDownByType(CommonService.DropDownType.ContributionType, gParameters).FirstOrDefault(o => (o.ContributionTypeDesc ?? "").ToLower() == (customerPlanDetail.ContributionTypeDescCode ?? "").ToLower());
            if (gContributionType != null)
            {
                policy.ContributionTypeId = gContributionType.ContributionTypeId;
                policy.ContributionYears = customerPlanDetail.ContributionUntilAge <= 0 ? customerPlanDetail.ContributionPeriod : customerPlanDetail.ContributionUntilAge;
            }

            policy.GoalAmount = customerPlanDetail.FinancialGoalAmount;
            policy.GoalAtAge = (decimal)customerPlanDetail.FinancialGoalAge;

            policy.ModalPremium = policy.PeriodicPremium = customerPlanDetail.PremiumAmount;
            policy.MinimunPremiunAmount = customerPlanDetail.MinimumPremium;

            if (customerPlanDetail.PlanGroupCode == "E" || customerPlanDetail.PlanGroupCode == "R")
                policy.InsurancePremium = policy.InsuredAmount = customerPlanDetail.AnnuityAmount;
            else
                policy.InsurancePremium = policy.InsuredAmount = customerPlanDetail.BenefitAmount;

            policy.TargetPremium = customerPlanDetail.TargetPremium;
            policy.InitialContribution = customerPlanDetail.InitialContribution;
            policy.BenefitAmount = customerPlanDetail.BenefitAmount;
            policy.AnnualPremium = customerPlanDetail.AnnualizedPremium;
            policy.InitialPremium = policy.InitialContribution = customerPlanDetail.InitialContribution;
            policy.MinimunPremiunAmount = customerPlanDetail.MinimumPremium;
            policy.DefermentPeriod = (int)customerPlanDetail.DefermentPeriod;
            policy.RetirementPeriod = (int)customerPlanDetail.RetirementPeriod;

            if (customerPlanDetail.ProductCode.Equals("SNT") ||
                customerPlanDetail.ProductCode.Equals("GRD") ||
                customerPlanDetail.ProductCode.Equals("GRP") ||
                customerPlanDetail.ProductCode.Equals("EXV") ||
                customerPlanDetail.ProductCode.Equals("EXE"))
                policy.ReturnAmount = customerPlanDetail.InitialContribution + (customerPlanDetail.Frequency * customerPlanDetail.ContributionPeriod * Math.Floor(customerPlanDetail.PremiumAmount));

            var gInvestmentProfile = CommonService.GetDropDownByType(CommonService.DropDownType.ProfileType_NewBusiness, gParameters).FirstOrDefault(o => (o.ProfileTypeDesc ?? "").ToLower() == (customerPlanDetail.InvestmentProfile ?? "").ToLower());
            if (gInvestmentProfile != null)
                policy.InvestmentProfile = gInvestmentProfile.ProfileTypeId;

            _uManager.PolicyManager.UpdatePolicy(policy);
            _uManager.IIllusDataManager.UpdateCustomerPlanDetail(customerPlanDetail);
        }

        private void SetBeneficiaries(Illustrator.CustomerPlanDetail customerPlanDetail)
        {
            var lstOldBeneficiaries = new List<Beneficiary>();
            lstOldBeneficiaries.AddRange(
                _uManager.BeneficiaryManager
                .GetAllBeneficiary(_corpId, _regionId, _countryId, _domesticregId, _stateProvId, _cityId, _officeId, _caseSeqNo, _histSeqNo, true, 1, null, 1)
                );
            lstOldBeneficiaries.AddRange(
                _uManager.BeneficiaryManager
                .GetAllBeneficiary(_corpId, _regionId, _countryId, _domesticregId, _stateProvId, _cityId, _officeId, _caseSeqNo, _histSeqNo, false, 1, null, 1)
                );
            lstOldBeneficiaries.AddRange(
                _uManager.BeneficiaryManager
                .GetAllBeneficiary(_corpId, _regionId, _countryId, _domesticregId, _stateProvId, _cityId, _officeId, _caseSeqNo, _histSeqNo, true, 2, null, 1)
                );
            lstOldBeneficiaries.AddRange(
                _uManager.BeneficiaryManager
                .GetAllBeneficiary(_corpId, _regionId, _countryId, _domesticregId, _stateProvId, _cityId, _officeId, _caseSeqNo, _histSeqNo, false, 2, null, 1)
                );

            foreach (var b in lstOldBeneficiaries)
                _uManager.BeneficiaryManager
               .DeleteBeneficiary(_corpId, _regionId, _countryId, _domesticregId, _stateProvId, _cityId, _officeId, _caseSeqNo, _histSeqNo, b.ContactId.GetValueOrDefault(), b.ContactRoleTypeId);

            var beneficiary = new Beneficiary
            {
                CorpId = _corpId,
                RegionId = _regionId,
                CountryId = _countryId,
                DomesticregId = _domesticregId,
                StateProvId = _stateProvId,
                CityId = _cityId,
                OfficeId = _officeId,
                CaseSeqNo = _caseSeqNo,
                HistSeqNo = _histSeqNo
            };

            var lstBeneficiaries = _uManager.IIllusDataManager.GetCustomerPlanBeneficiary(_customerPlanNo, null, null);
            if (!lstBeneficiaries.Any()) return;
            var gParameters = GetGlobalParameterWithBasicValues();
            var ilstRelationship = CommonService.GetIllusDropDownByType(DropDownType.Relationship);
            var glstRelationship = CommonService.GetDropDownByType(CommonService.DropDownType.Relationship, gParameters);

            foreach (var b in lstBeneficiaries)
            {
                beneficiary.FirstName = b.FirstName;
                beneficiary.MiddleName = b.MiddleName;
                beneficiary.FirstLastName = b.LastName;
                beneficiary.SecondLastName = b.SecondLastName;
                beneficiary.Dob = b.Dob;
                var iRelationship = ilstRelationship.FirstOrDefault(o => o.RelationshipTypeCode == b.RelationshipTypeCode);
                if (iRelationship != null)
                {
                    var oRelationship = glstRelationship.FirstOrDefault(o => o.RelationshipDesc.ToLower() == iRelationship.RelationshipType.ToLower());
                    if (oRelationship != null)
                        beneficiary.RelationshipToOwnerId = oRelationship.RelationshipId;
                }
                beneficiary.BenefitsPercent = b.PercentValue;
                beneficiary.BeneficiaryTypeId = b.BeneficiaryTypeCode == "P" ? 1 : 2;
                beneficiary.PrimaryBeneficiary = b.InsuredTypeCode == "P";
                _uManager.BeneficiaryManager.InsertBeneficiary(beneficiary);
            }
        }

        private void SetRiders(Illustrator.CustomerPlanDetail customerPlanDetail)
        {
            var lstRiders = _uManager.RiderManager.GetAllRider(
                new Policy.Parameter
                {
                    CorpId = _corpId,
                    RegionId = _regionId,
                    CountryId = _countryId,
                    DomesticregId = _domesticregId,
                    StateProvId = _stateProvId,
                    CityId = _cityId,
                    OfficeId = _officeId,
                    CaseSeqNo = _caseSeqNo,
                    HistSeqNo = _histSeqNo
                });
            foreach (var r in lstRiders)
                _uManager.RiderManager.DeleteRider(_corpId, _regionId, _countryId, _domesticregId, _stateProvId, _cityId, _officeId, _caseSeqNo, _histSeqNo, r.RiderTypeId, r.RiderId);

            var rider = new Rider
                 {
                     CorpId = _corpId,
                     RegionId = _regionId,
                     CountryId = _countryId,
                     DomesticregId = _domesticregId,
                     StateProvId = _stateProvId,
                     CityId = _cityId,
                     OfficeId = _officeId,
                     CaseSeqNo = _caseSeqNo,
                     HistSeqNo = _histSeqNo
                 };

            if (customerPlanDetail.RiderAcdb == "Y")
            {
                rider.RiderId = 0;
                rider.RiderTypeId = 2;
                rider.BeneficiaryAmount = customerPlanDetail.RiderAcdbCost;
                _uManager.RiderManager.SetRider(rider);
            }

            if (customerPlanDetail.RiderAdb == "Y")
            {
                rider.RiderId = 0;
                rider.RiderTypeId = 1;
                rider.BeneficiaryAmount = customerPlanDetail.RiderAdbAmount;
                rider.RiderStatusId = 1;
                _uManager.RiderManager.SetRider(rider);
            }
            /* Lgonzalez 01-02-2017 - inicio */
            if (customerPlanDetail.RiderTerm == "Y")
            {
                rider.RiderId = 0;
                rider.RiderTypeId = 9;
                rider.BeneficiaryAmount = customerPlanDetail.RiderTermAmount;
                rider.RiderStatusId = 1;
                _uManager.RiderManager.SetRider(rider);
            }
            if (customerPlanDetail.RiderCi == "Y")
            {
                rider.RiderId = 0;
                rider.RiderTypeId = 8;
                rider.BeneficiaryAmount = customerPlanDetail.RiderCiAmount;
                rider.RiderStatusId = 1;
                _uManager.RiderManager.SetRider(rider);
            }
            /* Lgonzalez 01-02-2017 - fin */
            if (customerPlanDetail.RiderOir == "Y")
            {
                rider.RiderId = 0;
                rider.RiderTypeId = 3;

                var oir = _uManager.IIllusDataManager.GetCustomerPlanPartnerInsurance(_customerPlanNo);

                if (oir.ContributionTypeCode == "Y")
                    rider.NumberOfYear = oir.UntilAge;
                else if (oir.ContributionTypeCode == "U")
                    rider.UntilAge = oir.UntilAge;
                rider.BeneficiaryAmount = oir.RideroirAmount;

                _uManager.RiderManager.SetRider(rider);

                var gParameters = GetGlobalParameterWithBasicValues();

                int? maritalStatusId = null;
                int? relationshipId = null;

                var iMaritalStatus = CommonService.GetIllusDropDownByType(CommonService.DropDownType.MaritalStatus).FirstOrDefault(o => o.MaritalStatusCode == oir.MaritalStatusCode);
                if (iMaritalStatus != null)
                {
                    var gMaritalStatus = CommonService.GetDropDownByType(CommonService.DropDownType.MaritalStatus, gParameters).FirstOrDefault(o => o.MaritalStatusDesc.ToLower() == iMaritalStatus.MaritalStatus.ToLower());
                    if (gMaritalStatus != null)
                        maritalStatusId = gMaritalStatus.MaritalStatId;
                }
                var iRelationship = CommonService.GetIllusDropDownByType(DropDownType.Relationship).FirstOrDefault(o => o.RelationshipTypeCode == oir.RelationshipTypeCode);
                if (iRelationship != null)
                {
                    var gRelationship = CommonService.GetDropDownByType(customerPlanDetail.PlanGroupCode == "F" ? CommonService.DropDownType.RelationshipFuneral : CommonService.DropDownType.Relationship, gParameters).FirstOrDefault(o => o.RelationshipDesc.ToLower() == iRelationship.RelationshipType.ToLower());
                    if (gRelationship != null)
                        relationshipId = gRelationship.RelationshipId;
                }
                _uManager.ContactManager.InsertContact(new Entity.UnderWriting.Entities.Contact
                {
                    CorpId = _corpId,
                    FirstName = oir.FirstName,
                    MiddleName = oir.MiddleName,
                    FirstLastName = oir.LastName,
                    SecondLastName = oir.LastName2,
                    Dob = oir.BirthDate,
                    Age = oir.Age,
                    Gender = oir.GenderCode,
                    Smoker = oir.Smoker == "Y",
                    MaritalStatId = maritalStatusId,
                    RelationshiptoOwner = relationshipId,
                    ContactIdType = 1,
                    ContactRoleTypeId = 3
                });
                _uManager.RiderManager.SetRider(rider);
            }
        }

        private List<string> ValidateAndAsignParameters(
            string customerPlanNo,
            string corpId,
            string regionId,
            string countryId,
            string domesticregId,
            string stateProvId,
            string cityId,
            string officeId,
            string userId,
            string companyId,
            string projectId
            )
        {
            var lstMessage = new List<string>();
            var decryptCustomerPlanNo = _usingTest ? customerPlanNo : Encryption.Decrypt(customerPlanNo);
            var decryptcorpId = _usingTest ? corpId : Encryption.Decrypt(corpId);
            var decryptregionId = _usingTest ? regionId : Encryption.Decrypt(regionId);
            var decryptcountryId = _usingTest ? countryId : Encryption.Decrypt(countryId);
            var decryptdomesticregId = _usingTest ? domesticregId : Encryption.Decrypt(domesticregId);
            var decryptstateProvId = _usingTest ? stateProvId : Encryption.Decrypt(stateProvId);
            var decryptcityId = _usingTest ? cityId : Encryption.Decrypt(cityId);
            var decryptofficeId = _usingTest ? officeId : Encryption.Decrypt(officeId);
            var decryptuserId = _usingTest ? userId : Encryption.Decrypt(userId);
            var decryptcompanyId = _usingTest ? companyId : Encryption.Decrypt(companyId);
            var decryptprojectId = _usingTest ? projectId : Encryption.Decrypt(projectId);

            if (!decryptCustomerPlanNo.IsLong()) lstMessage.Add("Parameter customerPlanNo isnt long.");
            if (!decryptcorpId.IsInt()) lstMessage.Add("Parameter corpId isnt int.");
            if (!decryptregionId.IsInt()) lstMessage.Add("Parameter regionId isnt int.");
            if (!decryptcountryId.IsInt()) lstMessage.Add("Parameter countryId isnt int.");
            if (!decryptdomesticregId.IsInt()) lstMessage.Add("Parameter domesticregId isnt int.");
            if (!decryptstateProvId.IsInt()) lstMessage.Add("Parameter stateProvId isnt int.");
            if (!decryptcityId.IsInt()) lstMessage.Add("Parameter cityId isnt int.");
            if (!decryptofficeId.IsInt()) lstMessage.Add("Parameter officeId isnt int.");
            if (!decryptuserId.IsInt()) lstMessage.Add("Parameter userId isnt int.");
            if (!decryptcompanyId.IsInt()) lstMessage.Add("Parameter companyId isnt int.");
            if (!decryptprojectId.IsInt()) lstMessage.Add("Parameter projectId isnt int.");
            if (!lstMessage.Any())
            {
                _customerPlanNo = decryptCustomerPlanNo.ToLong();
                _corpId = decryptcorpId.ToInt();
                _regionId = decryptregionId.ToInt();
                _countryId = decryptcountryId.ToInt();
                _domesticregId = decryptdomesticregId.ToInt();
                _stateProvId = decryptstateProvId.ToInt();
                _cityId = decryptcityId.ToInt();
                _officeId = decryptofficeId.ToInt();
                _userId = decryptuserId.ToInt();
                _companyId = decryptcompanyId.ToInt();
                _projectId = decryptprojectId.ToInt();
            }
            return lstMessage;
        }
        #endregion

        #region Services
        /// <summary>
        /// Save Policy, Beneficiaries and riders to Global
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="contactId"></param>
        /// <returns>ReturnMessageData has status and list of errors</returns>
        public ReturnMessageData SetPolicyInformation(
            string customerPlanNo,
            string corpId,
            string regionId,
            string countryId,
            string domesticregId,
            string stateProvId,
            string cityId,
            string officeId,
            string userId,
            string companyId,
            string projectId
            )
        {
            var returnData = new ReturnMessageData();
            try
            {
                returnData.ListMessage = ValidateAndAsignParameters(
                    customerPlanNo,
                    corpId,
                    regionId,
                    countryId,
                    domesticregId,
                    stateProvId,
                    cityId,
                    officeId,
                    userId,
                    companyId,
                    projectId
                    );

                if (returnData.ListMessage.Any())
                    return returnData;

                var customerPlanDetail =
                    _uManager.IIllusDataManager.GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
            {
                CustomerPlanNo = _customerPlanNo
            }).FirstOrDefault();
                if (customerPlanDetail == null) throw new Exception(RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationDontExist);
                if (customerPlanDetail.IllustrationStatusCode == "SBT") throw new Exception(RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationIsSubmitted);
                if (customerPlanDetail.IllustrationStatusCode == "DEL") throw new Exception(RESOURCE.UnderWriting.NewBussiness.Resources.DeleteLabel);

                SetCustomerPlanDetail(customerPlanDetail);
                SetRiders(customerPlanDetail);
                SetBeneficiaries(customerPlanDetail);
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
