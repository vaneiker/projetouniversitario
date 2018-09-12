using System;
using System.Collections.Generic;
using Entity.UnderWriting.IllusData;

namespace DI.UnderWriting.IllusData.Interfaces
{
    public interface IIllusData
    {
        int DeleteCustomerDetail(int customerNo, int userIdSystem);

        int DeleteCustomerPlanDetail(int customerPlanNo, int userIdSystem);

        IEnumerable<Illustrator.CustomerDetail> GetAllCustomerDetail();
        Illustrator.CustomerDetail GetCustomerDetailById(long? customerNo, long? rCustomerNo);

       //IEnumerable<Illustrator.CustomerPlanDetail> GetAllCustomerPlanDetail(long? customerPlanNo, long? customerNo, long? rCustomerNo, int? userId, int? companyId, DateTime? dateTo, DateTime? dateFrom);
        //Illustrator.CustomerPlanDetail GetCustomerPlanDetailById(long? customerPlanNo, long? customerNo, long? rCustomerNo, int? userId, int? companyId, DateTime? dateTo, DateTime? dateFrom);
        IEnumerable<Illustrator.CustomerPlanDetail> GetAllCustomerPlanDetail(Illustrator.CustomerPlanDetailP parameters);
        Illustrator.CustomerDetail InsertCustomerDetail(Illustrator.CustomerDetail customerDetail);
        Illustrator.CustomerDetail UpdateCustomerDetail(Illustrator.CustomerDetail customerDetail);

        Illustrator.CustomerPlanDetail InsertCustomerPlanDetail(Illustrator.CustomerPlanDetail customerPlanDetail);
        Illustrator.CustomerPlanDetail UpdateCustomerPlanDetail(Illustrator.CustomerPlanDetail customerPlanDetail);

        IEnumerable<DropDown> GetDropDownByType(DropDown.Parameter parameters);

        int DeleteCustomerEmails(long customerNo, int userIdSystem);
        int DeleteCustomerPhones(long customerNo, int userIdSystem);

        int InsertCustomerEmail(Illustrator.CustomerEmail customerEmail);
        int InsertCustomerPhone(Illustrator.CustomerPhone customerPhone);

        int DeleteCustomerOccupations(long customerNo, int userIdSystem);
        int DeleteCustomerIdentifications(long customerNo, int userIdSystem);
        int InsertPlanIdentification(Illustrator.CustomerPlanIdentification customerPlanIdentification);
        Illustrator.CustomerOccupation InsertCustomerOccupation(Illustrator.CustomerOccupation customerOccupation);
        Illustrator.CustomerOccupation UpdateCustomerOccupation(Illustrator.CustomerOccupation customerOccupation);

        Illustrator.Signature SetIllustrationSignature(Illustrator.Signature signature);
        Illustrator.User SetUser(Illustrator.User user);
        IEnumerable<Illustrator.User> GetUser(string nameId);

        IEnumerable<Illustrator.Signature> GetIllustrationSignature(long? customerPlanNo);

        long GetMaxIllustrationNo();

        IEnumerable<Illustrator.CustomerPlanBeneficiary> GetCustomerPlanBeneficiary(long customerPlanNo, string insuredTypeCode, string beneficiaryTypeCode);
        Illustrator.CustomerPlanBeneficiary SetCustomerPlanBeneficiary(Illustrator.CustomerPlanBeneficiary beneficiary);

        int DeleteCustomerPlanBeneficiary(long customerplanbeneficiaryno);

        Illustrator.CustomerPlanPartnerInsurance GetCustomerPlanPartnerInsurance(long customerPlanNo);
        Illustrator.CustomerPlanPartnerInsurance SetCustomerPlanPartnerInsurance(Illustrator.CustomerPlanPartnerInsurance partnerInsurance);
        int DeleteCustomerPlanPartnerInsurance(long customerPlanNo);

        IEnumerable<Illustrator.CustomerPlanOtherInsurance> GetCustomerPlanOtherInsurance(long customerPlanNo, string insuredTypeCode);
        Illustrator.CustomerPlanOtherInsurance SetCustomerPlanOtherInsurance(Illustrator.CustomerPlanOtherInsurance customerPlanOtherInsurance);
        int DeleteCustomerPlanOtherInsurance(long customerPlanOtherInsuranceNo);

        IEnumerable<Illustrator.CustomerPlanExam> GetCustomerPlanExam(long customerPlanNo, string insuredTypeCode);
        IEnumerable<Illustrator.CustomerPlanExamCondition> GetCustomerExamCondition(string productCode, int age, string genderCode, string maritalStatusCode, decimal insuredAmount);
        Illustrator.CustomerPlanExam UpdateCustomerPlanExam(Illustrator.CustomerPlanExam examCondition);
        int DeleteCustomerPlanExam(long customerPlanNo, string insuredTypeCode, int userIdSystem);
        decimal GetTotalInsuredAmount(long customerPlanNo, string insuredTypeCode);

        IEnumerable<Illustrator.RuleParameter> GetAllRuleParameter(int? ruleParameterNo, string productCode);

        IEnumerable<Illustrator.CustomerPlaNopBal> GetCustomerPlaNopBal(long customerNo, long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanVarPremium> GetCustomerPlanVarPremium(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanVarInsured> GetCustomerPlanVarInsured(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanLoan> GetCustomerPlanLoan(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanVarSurrender> GetCustomerPlanVarSurrender(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanLoanRepay> GetCustomerPlanLoanRepay(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanVarProfile> GetCustomerPlanVarProfile(long customerPlanNo);
        IEnumerable<Illustrator.InvProfileCompareRates> GetInvProfileCompareRates(string classCode, string productCode, string investmentProfileCode);

        Illustrator.CustomerPlaNopBal SetCustomerPlaNopBal(Illustrator.CustomerPlaNopBal plaNopBal);
        Illustrator.CustomerPlanVarPremium SetCustomerPlanVarPremium(Illustrator.CustomerPlanVarPremium planVarPremium);
        Illustrator.CustomerPlanVarInsured SetCustomerPlanVarInsured(Illustrator.CustomerPlanVarInsured planVarInsured);
        Illustrator.CustomerPlanLoan SetCustomerPlanLoan(Illustrator.CustomerPlanLoan planLoan);
        Illustrator.CustomerPlanVarSurrender SetCustomerPlanVarSurrender(Illustrator.CustomerPlanVarSurrender planVarSurrender);
        Illustrator.CustomerPlanLoanRepay SetCustomerPlanLoanRepay(Illustrator.CustomerPlanLoanRepay planLoanRepay);
        Illustrator.CustomerPlanVarProfile SetCustomerPlanVarProfile(Illustrator.CustomerPlanVarProfile compareRates);

        int DeleteCustomerPlaNopBal(long customerPlanNo);
        int DeleteCustomerPlanVarPremium(long customerPlanNo);
        int DeleteCustomerPlanVarInsured(long customerPlanNo);
        int DeleteCustomerPlanLoan(long customerPlanNo);
        int DeleteCustomerPlanVarSurrender(long customerPlanNo);
        int DeleteCustomerPlanLoanRepay(long customerPlanNo);
        int DeleteCustomerPlanVarProfile(long customerPlanNo);

        IEnumerable<Illustrator.ProductCancel> GetProductCancel(string productCode, int retirementPeriod);
        IEnumerable<Illustrator.ProductCancelDetail> GetProductCancelDetail(int productCancelNo);

        IEnumerable<Illustrator.FrequencyCostDetail> GetFrequencyCost(string productCode, string frequencyTypeCode);

        int DeleteCustomerPlanTerm(long customerPlanNo);
        int DeleteCustomerPlanAnnuity(long customerPlanNo);
        int DeleteCustomerPlanLife(long customerPlanNo);

        IEnumerable<Illustrator.CustomerPlanTerm> GetCustomerPlanTerm(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanAnnuity> GetCustomerPlanAnnuity(long customerPlanNo);
        IEnumerable<Illustrator.CustomerPlanLife> GetCustomerPlanLife(long customerPlanNo);

        Illustrator.CustomerPlanTerm InsertCustomerPlanTerm(Illustrator.CustomerPlanTerm planTerm);
        Illustrator.CustomerPlanAnnuity InsertCustomerPlanAnnuity(Illustrator.CustomerPlanAnnuity planAnnuity);
        Illustrator.CustomerPlanLife InsertCustomerPlanLife(Illustrator.CustomerPlanLife planLife);

        IEnumerable<Illustrator.InvestmentsInflacion> GetRptInvestmentsInflacion();

        IEnumerable<Illustrator.InvestmentsType> GetRptInvestmentsType(string fundType, string fundCategory, string region);
        IEnumerable<Illustrator.InvestmentsCompass> GetRptInvestmentsCompass(int ReturnTypeid);
        IEnumerable<Illustrator.InvestmentsSlide3> GetRptInvestmentsSlide3();
        IEnumerable<Illustrator.InvestmentsSlide4> GetRptInvestmentsSlide4();
        IEnumerable<Illustrator.InvestmentsSlide5Chart1> GetRptInvestmentsSlide5Chart1();
        IEnumerable<Illustrator.InvestmentsSlide5Chart2> GetRptInvestmentsSlide5Chart2();
        IEnumerable<Illustrator.InvestmentsSlide6> GetRptInvestmentsSlide6();
        IEnumerable<Illustrator.InvestmentsReturns> GetRptInvestmentsReturns();

        IEnumerable<Illustrator.InvestmentsProfile> GetInvestmentsProfile();
        IEnumerable<Illustrator.InvestmentsProfileEuro> GetInvestmentsProfileEuro();

        IEnumerable<Illustrator.RptAxysFixedinComeSlide12> GetRptAxysFixedinComeSlide12();
        IEnumerable<Illustrator.RptAxysHighperFormSlide12> GetRptAxysHighperFormSlide12();
        IEnumerable<Illustrator.RptAxysLowRiskSlide12> GetRptAxysLowRiskSlide12();
        IEnumerable<Illustrator.RptAxysSlide10> GetRptAxysSlide10();
        IEnumerable<Illustrator.RptAxysSlide11> GetRptAxysSlide11();
        IEnumerable<Illustrator.RptAxysSlide5> GetRptAxysSlide5();
        IEnumerable<Illustrator.RptAxysSlide6> GetRptAxysSlide6();
        IEnumerable<Illustrator.RptAxysSlide8> GetRptAxysSlide8();

        IEnumerable<Illustrator.EgrAge> GetEgrAge();
        IEnumerable<Illustrator.EgrSlide7> GetEgrSlide7();
        IEnumerable<Illustrator.EgrSlide8> GetEgrSlide8();
        IEnumerable<Illustrator.EgrSlide9> GetEgrSlide9();
        IEnumerable<Illustrator.EgrSlide10> GetEgrSlide10();

        IEnumerable<Illustrator.RptLegacy10Priciple> GetRptLegacy10Priciple();
        IEnumerable<Illustrator.RptCompassSlide5> GetRptCompassSlide5();
        IEnumerable<Illustrator.RptLifeExpectancy> GetRptLifeExpectancy();

        IEnumerable<Illustrator.RptInvestmentsCompassMaster> GetRptInvestmentsCompassMaster();

        IEnumerable<Illustrator.RptCompassSlide7> RptCompassSlide7();

        int InsertCustomerPlanDetGlobalPolicy(Illustrator.CustomerPlanDetGlobalPolicy planGlobal);
        Illustrator.Company GetCompany(int companyNo);
        Illustrator.CustomerPlanDetGlobalPolicy GetCustomerPlanDetGlobalPolicy(Illustrator.CustomerPlanDetGlobalPolicy planGlobal);        

        // Lgonzalez 23-02-2017
        double GetGoalSeek(double InsuredAmmount);
    }
}
