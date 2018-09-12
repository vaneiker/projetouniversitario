using System;
using System.Collections.Generic;
using System.Linq;
using DATA.UnderWriting.Repositories.IllusData;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.IllusData;

namespace LOGIC.UnderWriting.IllusData
{
    public class IllusDataManager
    {
        private IllustratorRepository _illustratorRepository;

        public IllusDataManager()
        {
           
            _illustratorRepository = SingletonUnitOfWork.Instance.IllustratorRepository;
        }

        public virtual int DeleteCustomerDetail(int customerNo, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerDetail(customerNo, userIdSystem);
        }

        public virtual int DeleteCustomerPlanDetail(int customerPlanNo, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerPlanDetail(customerPlanNo, userIdSystem);
        }

        public virtual IEnumerable<Illustrator.CustomerDetail> GetAllCustomerDetail()
        {
            return
                this.GetAllCustomerDetailOrById(null, null);
        }
        public virtual Illustrator.CustomerDetail GetCustomerDetailById(long? customerNo, long? rCustomerNo)
        {
            IEnumerable<Illustrator.CustomerDetail> temp;
            Illustrator.CustomerDetail result;
            bool throwEx;

            throwEx = (customerNo.HasValue && customerNo.Value > 0);

            if (!throwEx)
                throwEx = (rCustomerNo.HasValue && rCustomerNo.Value > 0);

            if (!throwEx)
                throw new ArgumentException("One of the two properties must be greater than 0.");

            temp = this.GetAllCustomerDetailOrById(customerNo, rCustomerNo);

            result = temp != null && temp.Any()
                     ? temp.First()
                     : null;

            return
                result;
        }

        //public virtual IEnumerable<Illustrator.CustomerPlanDetail> GetAllCustomerPlanDetail(long? customerPlanNo, long? customerNo, long? rCustomerNo, int? userId
        //    , int? companyId, DateTime? dateTo, DateTime? dateFrom)
        //{
        //    Illustrator.CustomerPlanDetailP parameters;

        //    parameters = new Illustrator.CustomerPlanDetailP
        //    {
        //        CustomerPlanNo = customerPlanNo,
        //        CustomerNo = customerNo,
        //        RCustomerNo = rCustomerNo,
        //        UserId = userId,
        //        CompanyId = companyId,
        //        DateTo = dateTo,
        //        DateFrom = dateFrom
        //    };

        //    return
        //        this.GetAllCustomerPlanDetailOrById(parameters);
        //}
        //public virtual Illustrator.CustomerPlanDetail GetCustomerPlanDetailById(long? customerPlanNo, long? customerNo, long? rCustomerNo, int? userId
        //    , int? companyId, DateTime? dateTo, DateTime? dateFrom)
        //{
        //    IEnumerable<Illustrator.CustomerPlanDetail> temp;
        //    Illustrator.CustomerPlanDetail result;
        //    Illustrator.CustomerPlanDetailP parameters;

        //    parameters = new Illustrator.CustomerPlanDetailP
        //    {
        //        CustomerPlanNo = customerPlanNo,
        //        CustomerNo = customerNo,
        //        RCustomerNo = rCustomerNo,
        //        UserId = userId,
        //        CompanyId = companyId,
        //        DateTo = dateTo,
        //        DateFrom = dateFrom
        //    };

        //    temp = this.GetAllCustomerPlanDetailOrById(parameters);

        //    result = temp != null && temp.Any()
        //             ? temp.First()
        //             : null;

        //    return
        //        result;
        //}

        public virtual Illustrator.CustomerDetail InsertCustomerDetail(Illustrator.CustomerDetail customerDetail)
        {
            customerDetail.CustomerNo = -1;

            return
                this.SetCustomerDetail(customerDetail);
        }
        public virtual Illustrator.CustomerDetail UpdateCustomerDetail(Illustrator.CustomerDetail customerDetail)
        {
            if (!customerDetail.CustomerNo.HasValue || customerDetail.CustomerNo.Value <= 0)
                throw new ArgumentException("This property can't be null or under 0.", "CustomerNo");

            return
                this.SetCustomerDetail(customerDetail);
        }

        public virtual Illustrator.CustomerPlanDetail InsertCustomerPlanDetail(Illustrator.CustomerPlanDetail customerPlanDetail)
        {
            customerPlanDetail.CustomerPlanNo = -1;

            return
                this.SetCustomerPlanDetail(customerPlanDetail);
        }
        public virtual Illustrator.CustomerPlanDetail UpdateCustomerPlanDetail(Illustrator.CustomerPlanDetail customerPlanDetail)
        {
            if (!customerPlanDetail.CustomerPlanNo.HasValue || customerPlanDetail.CustomerPlanNo.Value <= 0)
                throw new ArgumentException("This property can't be null or under 0.", "CustomerPlanNo");

            return
                this.SetCustomerPlanDetail(customerPlanDetail);
        }

        private IEnumerable<Illustrator.CustomerDetail> GetAllCustomerDetailOrById(long? customerNo, long? rCustomerNo)
        {
            return
                _illustratorRepository.GetAllCustomerDetailOrById(customerNo, rCustomerNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanDetail> GetAllCustomerPlanDetailOrById(Illustrator.CustomerPlanDetailP parameters)
        {
            return
                _illustratorRepository.GetAllCustomerPlanDetailOrById(parameters);
        }
        private Illustrator.CustomerDetail SetCustomerDetail(Illustrator.CustomerDetail customerDetail)
        {
            return
                _illustratorRepository.SetCustomerDetail(customerDetail);
        }
        private Illustrator.CustomerPlanDetail SetCustomerPlanDetail(Illustrator.CustomerPlanDetail customerPlanDetail)
        {
            return
                _illustratorRepository.SetCustomerPlanDetail(customerPlanDetail);
        }

        public virtual IEnumerable<DropDown> GetDropDownByType(DropDown.Parameter parameters)
        {
            return
                _illustratorRepository.GetDropDownByType(parameters);
        }

        public virtual int DeleteCustomerEmails(long customerNo, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerEmails(customerNo, userIdSystem);
        }
        public virtual int DeleteCustomerPhones(long customerNo, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerPhones(customerNo, userIdSystem);
        }

        public virtual int InsertCustomerEmail(Illustrator.CustomerEmail customerEmail)
        {
            return
                _illustratorRepository.InsertCustomerEmail(customerEmail);
        }
        public virtual int InsertCustomerPhone(Illustrator.CustomerPhone customerPhone)
        {
            return
                _illustratorRepository.InsertCustomerPhone(customerPhone);
        }

        public virtual int DeleteCustomerOccupations(long customerNo, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerOccupations(customerNo, userIdSystem);
        }
        public virtual int DeleteCustomerIdentifications(long customerNo, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerIdentifications(customerNo, userIdSystem);
        }

        public virtual int InsertPlanIdentification(Illustrator.CustomerPlanIdentification customerPlanIdentification)
        {
            return
                _illustratorRepository.InsertPlanIdentification(customerPlanIdentification);
        }

        public virtual Illustrator.CustomerOccupation InsertCustomerOccupation(Illustrator.CustomerOccupation customerOccupation)
        {
            customerOccupation.CustomerOccupationNo = -1;

            return
                this.SetCustomerOccupation(customerOccupation);
        }
        public virtual Illustrator.CustomerOccupation UpdateCustomerOccupation(Illustrator.CustomerOccupation customerOccupation)
        {
            if (!customerOccupation.CustomerOccupationNo.HasValue || customerOccupation.CustomerOccupationNo.Value <= 0)
                throw new ArgumentException("This property can't be null or under 0.", "CustomerOccupationNo");

            return
                this.SetCustomerOccupation(customerOccupation);
        }

        private Illustrator.CustomerOccupation SetCustomerOccupation(Illustrator.CustomerOccupation customerOccupation)
        {
            return
                _illustratorRepository.SetCustomerOccupation(customerOccupation);
        }

        public virtual Illustrator.Signature SetIllustrationSignature(Illustrator.Signature signature)
        {
            return
                 _illustratorRepository.SetIllustrationSignature(signature);
        }
        public virtual Illustrator.User SetUser(Illustrator.User user)
        {
            return
                 _illustratorRepository.SetUser(user);
        }
        public virtual IEnumerable<Illustrator.User> GetUser(string nameId)
        {
            return
                 _illustratorRepository.GetUser(nameId);
        }

        public virtual IEnumerable<Illustrator.Signature> GetIllustrationSignature(long? customerPlanNo)
        {
            return
                _illustratorRepository.GetIllustrationSignature(customerPlanNo);
        }

        public virtual long GetMaxIllustrationNo()
        {
            return
                _illustratorRepository.GetMaxIllustrationNo();
        }

        public virtual IEnumerable<Illustrator.CustomerPlanBeneficiary> GetCustomerPlanBeneficiary(long customerPlanNo, string insuredTypeCode, string beneficiaryTypeCode)
        {
            return
                _illustratorRepository.GetCustomerPlanBeneficiary(customerPlanNo, insuredTypeCode, beneficiaryTypeCode);
        }
        public virtual Illustrator.CustomerPlanBeneficiary SetCustomerPlanBeneficiary(Illustrator.CustomerPlanBeneficiary beneficiary)
        {
            return
                _illustratorRepository.SetCustomerPlanBeneficiary(beneficiary);
        }
        public virtual int DeleteCustomerPlanBeneficiary(long customerplanbeneficiaryno)
        {
            return
               _illustratorRepository.DeleteCustomerPlanBeneficiary(customerplanbeneficiaryno);
        }

        public virtual Illustrator.CustomerPlanPartnerInsurance GetCustomerPlanPartnerInsurance(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanPartnerInsurance(customerPlanNo);
        }
        public virtual Illustrator.CustomerPlanPartnerInsurance SetCustomerPlanPartnerInsurance(Illustrator.CustomerPlanPartnerInsurance partnerInsurance)
        {
            return
                _illustratorRepository.SetCustomerPlanPartnerInsurance(partnerInsurance);
        }
        public virtual int DeleteCustomerPlanPartnerInsurance(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanPartnerInsurance(customerPlanNo);
        }

        public virtual IEnumerable<Illustrator.CustomerPlanOtherInsurance> GetCustomerPlanOtherInsurance(long customerPlanNo, string insuredTypeCode)
        {
            return
                _illustratorRepository.GetCustomerPlanOtherInsurance(customerPlanNo, insuredTypeCode);
        }
        public virtual Illustrator.CustomerPlanOtherInsurance SetCustomerPlanOtherInsurance(Illustrator.CustomerPlanOtherInsurance customerPlanOtherInsurance)
        {
            return
                _illustratorRepository.SetCustomerPlanOtherInsurance(customerPlanOtherInsurance);
        }
        public virtual int DeleteCustomerPlanOtherInsurance(long customerPlanOtherInsuranceNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanOtherInsurance(customerPlanOtherInsuranceNo);
        }

        public virtual IEnumerable<Illustrator.CustomerPlanExam> GetCustomerPlanExam(long customerPlanNo, string insuredTypeCode)
        {
            return
                _illustratorRepository.GetCustomerPlanExam(customerPlanNo, insuredTypeCode);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanExamCondition> GetCustomerExamCondition(string productCode, int age, string genderCode, string maritalStatusCode, decimal insuredAmount)
        {
            return
                _illustratorRepository.GetCustomerExamCondition(productCode, age, genderCode, maritalStatusCode, insuredAmount);
        }
        public virtual Illustrator.CustomerPlanExam UpdateCustomerPlanExam(Illustrator.CustomerPlanExam examCondition)
        {
            examCondition.CustomerExamNo = null;

            return
                this.SetCustomerPlanExam(examCondition);
        }
        public virtual int DeleteCustomerPlanExam(long customerPlanNo, string insuredTypeCode, int userIdSystem)
        {
            return
                _illustratorRepository.DeleteCustomerPlanExam(customerPlanNo, insuredTypeCode, userIdSystem);
        }

        private Illustrator.CustomerPlanExam SetCustomerPlanExam(Illustrator.CustomerPlanExam examCondition)
        {
            return
                _illustratorRepository.SetCustomerPlanExam(examCondition);
        }

        public virtual decimal GetTotalInsuredAmount(long customerPlanNo, string insuredTypeCode)
        {
            return
                 _illustratorRepository.GetTotalInsuredAmount(customerPlanNo, insuredTypeCode);
        }

        public virtual IEnumerable<Illustrator.RuleParameter> GetAllRuleParameter(int? ruleParameterNo, string productCode)
        {
            return
                _illustratorRepository.GetAllRuleParameter(ruleParameterNo, productCode);
        }

        public virtual IEnumerable<Illustrator.CustomerPlaNopBal> GetCustomerPlaNopBal(long customerNo, long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlaNopBal(customerNo, customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanVarPremium> GetCustomerPlanVarPremium(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanVarPremium(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanVarInsured> GetCustomerPlanVarInsured(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanVarInsured(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanLoan> GetCustomerPlanLoan(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanLoan(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanVarSurrender> GetCustomerPlanVarSurrender(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanVarSurrender(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanLoanRepay> GetCustomerPlanLoanRepay(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanLoanRepay(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanVarProfile> GetCustomerPlanVarProfile(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanVarProfile(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.InvProfileCompareRates> GetInvProfileCompareRates(string classCode, string productCode, string investmentProfileCode)
        {
            return
                _illustratorRepository.GetInvProfileCompareRates(classCode, productCode, investmentProfileCode);
        }

        public virtual Illustrator.CustomerPlaNopBal SetCustomerPlaNopBal(Illustrator.CustomerPlaNopBal plaNopBal)
        {
            return
                _illustratorRepository.SetCustomerPlaNopBal(plaNopBal);
        }
        public virtual Illustrator.CustomerPlanVarPremium SetCustomerPlanVarPremium(Illustrator.CustomerPlanVarPremium planVarPremium)
        {
            return
                _illustratorRepository.SetCustomerPlanVarPremium(planVarPremium);
        }
        public virtual Illustrator.CustomerPlanVarInsured SetCustomerPlanVarInsured(Illustrator.CustomerPlanVarInsured planVarInsured)
        {
            return
                _illustratorRepository.SetCustomerPlanVarInsured(planVarInsured);
        }
        public virtual Illustrator.CustomerPlanLoan SetCustomerPlanLoan(Illustrator.CustomerPlanLoan planLoan)
        {
            return
                _illustratorRepository.SetCustomerPlanLoan(planLoan);
        }
        public virtual Illustrator.CustomerPlanVarSurrender SetCustomerPlanVarSurrender(Illustrator.CustomerPlanVarSurrender planVarSurrender)
        {
            return
                _illustratorRepository.SetCustomerPlanVarSurrender(planVarSurrender);
        }
        public virtual Illustrator.CustomerPlanLoanRepay SetCustomerPlanLoanRepay(Illustrator.CustomerPlanLoanRepay planLoanRepay)
        {
            return
                _illustratorRepository.SetCustomerPlanLoanRepay(planLoanRepay);
        }
        public virtual Illustrator.CustomerPlanVarProfile SetCustomerPlanVarProfile(Illustrator.CustomerPlanVarProfile compareRates)
        {
            return
                _illustratorRepository.SetCustomerPlanVarProfile(compareRates);
        }

        public virtual int DeleteCustomerPlaNopBal(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlaNopBal(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanVarPremium(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanVarPremium(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanVarInsured(long customerPlanNo)
        {
            return
                 _illustratorRepository.DeleteCustomerPlanVarInsured(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanLoan(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanLoan(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanVarSurrender(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanVarSurrender(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanLoanRepay(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanLoanRepay(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanVarProfile(long customerPlanNo)
        {
            return
                 _illustratorRepository.DeleteCustomerPlanVarProfile(customerPlanNo);
        }

        public virtual IEnumerable<Illustrator.ProductCancel> GetProductCancel(string productCode, int retirementPeriod)
        {
            return
                _illustratorRepository.GetProductCancel(productCode, retirementPeriod);
        }
        public virtual IEnumerable<Illustrator.ProductCancelDetail> GetProductCancelDetail(int productCancelNo)
        {
            return
                _illustratorRepository.GetProductCancelDetail(productCancelNo);
        }

        public virtual IEnumerable<Illustrator.FrequencyCostDetail> GetFrequencyCost(string productCode, string frequencyTypeCode)
        {
            return
                _illustratorRepository.GetFrequencyCost(productCode, frequencyTypeCode);
        }

        public virtual int DeleteCustomerPlanTerm(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanTerm(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanAnnuity(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanAnnuity(customerPlanNo);
        }
        public virtual int DeleteCustomerPlanLife(long customerPlanNo)
        {
            return
                _illustratorRepository.DeleteCustomerPlanLife(customerPlanNo);
        }

        public virtual IEnumerable<Illustrator.CustomerPlanTerm> GetCustomerPlanTerm(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanTerm(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanAnnuity> GetCustomerPlanAnnuity(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanAnnuity(customerPlanNo);
        }
        public virtual IEnumerable<Illustrator.CustomerPlanLife> GetCustomerPlanLife(long customerPlanNo)
        {
            return
                _illustratorRepository.GetCustomerPlanLife(customerPlanNo);
        }

        public virtual Illustrator.CustomerPlanTerm InsertCustomerPlanTerm(Illustrator.CustomerPlanTerm planTerm)
        {
            planTerm.CustomerPlanTermNo = -1;

            return
                this.SetCustomerPlanTerm(planTerm);
        }
        public virtual Illustrator.CustomerPlanAnnuity InsertCustomerPlanAnnuity(Illustrator.CustomerPlanAnnuity planAnnuity)
        {
            planAnnuity.CustomerPlanAnnuityNo = -1;

            return
                this.SetCustomerPlanAnnuity(planAnnuity);
        }
        public virtual Illustrator.CustomerPlanLife InsertCustomerPlanLife(Illustrator.CustomerPlanLife planLife)
        {
            planLife.CustomerPlanLifeNo = -1;

            return
                this.SetCustomerPlanLife(planLife);
        }

        public virtual IEnumerable<Illustrator.InvestmentsInflacion> GetRptInvestmentsInflacion()
        {
            return
                _illustratorRepository.GetRptInvestmentsInflacion();
        }

        private Illustrator.CustomerPlanTerm SetCustomerPlanTerm(Illustrator.CustomerPlanTerm planTerm)
        {
            return
                _illustratorRepository.SetCustomerPlanTerm(planTerm);
        }
        private Illustrator.CustomerPlanAnnuity SetCustomerPlanAnnuity(Illustrator.CustomerPlanAnnuity planAnnuity)
        {
            return
                _illustratorRepository.SetCustomerPlanAnnuity(planAnnuity);
        }
        private Illustrator.CustomerPlanLife SetCustomerPlanLife(Illustrator.CustomerPlanLife planLife)
        {
            return
                _illustratorRepository.SetCustomerPlanLife(planLife);
        }

        public virtual IEnumerable<Illustrator.InvestmentsType> GetRptInvestmentsType(string fundType, string fundCategory, string region)
        {
            return
                _illustratorRepository.GetRptInvestmentsType(fundType, fundCategory, region);
        }
        public virtual IEnumerable<Illustrator.InvestmentsCompass> GetRptInvestmentsCompass(int ReturnTypeid)
        {
            return
                _illustratorRepository.GetRptInvestmentsCompass(ReturnTypeid);
        }
        public virtual IEnumerable<Illustrator.InvestmentsSlide3> GetRptInvestmentsSlide3()
        {
            return
                _illustratorRepository.GetRptInvestmentsSlide3();
        }
        public virtual IEnumerable<Illustrator.InvestmentsSlide4> GetRptInvestmentsSlide4()
        {
            return
                _illustratorRepository.GetRptInvestmentsSlide4();
        }
        public virtual IEnumerable<Illustrator.InvestmentsSlide5Chart1> GetRptInvestmentsSlide5Chart1()
        {
            return
                _illustratorRepository.GetRptInvestmentsSlide5Chart1();
        }
        public virtual IEnumerable<Illustrator.InvestmentsSlide5Chart2> GetRptInvestmentsSlide5Chart2()
        {
            return
                _illustratorRepository.GetRptInvestmentsSlide5Chart2();
        }
        public virtual IEnumerable<Illustrator.InvestmentsSlide6> GetRptInvestmentsSlide6()
        {
            return
                _illustratorRepository.GetRptInvestmentsSlide6();
        }
        public virtual IEnumerable<Illustrator.InvestmentsReturns> GetRptInvestmentsReturns()
        {
            return
                _illustratorRepository.GetRptInvestmentsReturns();
        }

        public virtual IEnumerable<Illustrator.InvestmentsProfile> GetInvestmentsProfile()
        {
            return
                _illustratorRepository.GetInvestmentsProfile();
        }
        public virtual IEnumerable<Illustrator.InvestmentsProfileEuro> GetInvestmentsProfileEuro()
        {
            return
                _illustratorRepository.GetInvestmentsProfileEuro();
        }

        public virtual IEnumerable<Illustrator.RptAxysFixedinComeSlide12> GetRptAxysFixedinComeSlide12()
        {
            return
                _illustratorRepository.GetRptAxysFixedinComeSlide12();
        }
        public virtual IEnumerable<Illustrator.RptAxysHighperFormSlide12> GetRptAxysHighperFormSlide12()
        {
            return
                _illustratorRepository.GetRptAxysHighperFormSlide12();
        }
        public virtual IEnumerable<Illustrator.RptAxysLowRiskSlide12> GetRptAxysLowRiskSlide12()
        {
            return
                _illustratorRepository.GetRptAxysLowRiskSlide12();
        }
        public virtual IEnumerable<Illustrator.RptAxysSlide10> GetRptAxysSlide10()
        {
            return
                _illustratorRepository.GetRptAxysSlide10();
        }
        public virtual IEnumerable<Illustrator.RptAxysSlide11> GetRptAxysSlide11()
        {
            return
                _illustratorRepository.GetRptAxysSlide11();
        }
        public virtual IEnumerable<Illustrator.RptAxysSlide5> GetRptAxysSlide5()
        {
            return
                _illustratorRepository.GetRptAxysSlide5();
        }
        public virtual IEnumerable<Illustrator.RptAxysSlide6> GetRptAxysSlide6()
        {
            return
                _illustratorRepository.GetRptAxysSlide6();
        }
        public virtual IEnumerable<Illustrator.RptAxysSlide8> GetRptAxysSlide8()
        {
            return
                _illustratorRepository.GetRptAxysSlide8();
        }

        public virtual IEnumerable<Illustrator.EgrAge> GetEgrAge()
        {
            return
                _illustratorRepository.GetEgrAge();
        }
        public virtual IEnumerable<Illustrator.EgrSlide7> GetEgrSlide7()
        {
            return
                _illustratorRepository.GetEgrSlide7();
        }
        public virtual IEnumerable<Illustrator.EgrSlide8> GetEgrSlide8()
        {
            return
                _illustratorRepository.GetEgrSlide8();
        }
        public virtual IEnumerable<Illustrator.EgrSlide9> GetEgrSlide9()
        {
            return
                _illustratorRepository.GetEgrSlide9();
        }
        public virtual IEnumerable<Illustrator.EgrSlide10> GetEgrSlide10()
        {
            return
                _illustratorRepository.GetEgrSlide10();
        }

        public virtual IEnumerable<Illustrator.RptLegacy10Priciple> GetRptLegacy10Priciple()
        {
            return
                _illustratorRepository.GetRptLegacy10Priciple();
        }
        public virtual IEnumerable<Illustrator.RptCompassSlide5> GetRptCompassSlide5()
        {
            return
                _illustratorRepository.GetRptCompassSlide5();
        }
        public virtual IEnumerable<Illustrator.RptLifeExpectancy> GetRptLifeExpectancy()
        {
            return
                _illustratorRepository.GetRptLifeExpectancy();
        }

        public virtual IEnumerable<Illustrator.RptInvestmentsCompassMaster> GetRptInvestmentsCompassMaster()
        {
            return
                _illustratorRepository.GetRptInvestmentsCompassMaster();
        }

        public virtual IEnumerable<Illustrator.RptCompassSlide7> RptCompassSlide7()
        {
            return
                _illustratorRepository.GetRptCompassSlide7();
        }

        public virtual int InsertCustomerPlanDetGlobalPolicy(Illustrator.CustomerPlanDetGlobalPolicy planGlobal)
        {
            return
                _illustratorRepository.InsertCustomerPlanDetGlobalPolicy(planGlobal);
        }
        public virtual Illustrator.Company GetCompany(int companyNo)
        {
            return
                _illustratorRepository.GetCompany(companyNo);
        }
        public virtual Illustrator.CustomerPlanDetGlobalPolicy GetCustomerPlanDetGlobalPolicy(Illustrator.CustomerPlanDetGlobalPolicy planGlobal)
        {
            return
                _illustratorRepository.GetCustomerPlanDetGlobalPolicy(planGlobal);
        }
       
        //Lgonzalez 23-02-2017
        public virtual double GetGoalSeek(double InsuredAmmount)
        {
            return 0;
        }
    }
}
