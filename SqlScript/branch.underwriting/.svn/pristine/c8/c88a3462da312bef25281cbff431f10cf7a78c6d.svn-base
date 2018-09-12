using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSVirtualOffice.Models.wsdata;
using WSVirtualOffice.Models.codes;

namespace WSVirtualOffice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IQuotesService" in both code and config file together.
    [ServiceContract]
    public interface IQuotesService
    {
        //[OperationContract]
        //void DoWork();
        [OperationContract]
        WSCompareIllusResult getCompareIllustration(List<WSCompareCustomer> custplans);

        [OperationContract]
        WSTermResult getTermModel(WSCustomer customer, WSCustomerPlan plan, List<WSRider> riders, WSCustomerPlanPartner partner);
        [OperationContract]
        WSTermResult getTermModelIllustration(WSCustomer customer, WSCustomerPlan plan, List<WSRider> riders, WSCustomerPlanPartner partner);

        [OperationContract]
        WSFuneralResult getFuneralModel(WSCustomer customer, WSCustomerPlanFuneral plan);
        [OperationContract]
        WSFuneralResult getFuneralModelIllustration(WSCustomer customer, WSCustomerPlanFuneral plan);

        [OperationContract]
        WSLifeResult getLifeModel(WSCustomer customer, WSCustomerPlan plan, List<WSRider> riders, WSCustomerPlanPartner partner);

        [OperationContract]
        WSLifeResult getLifeModelIllustration(WSCustomer customer, WSCustomerPlan plan, List<WSRider> riders, WSCustomerPlanPartner partner);


        [OperationContract]
        WSAnnuityResult getAnnuityModel(WSCustomer customer, WSCustomerPlan plan);
        [OperationContract]
        WSAnnuityResult getAnnuityModelIllustration(WSCustomer customer, WSCustomerPlan plan);
        /*
        [OperationContract]
        WSAnnuityGrowthResult getAnnuityGrowthModel(WSCustomer customer, WSCustomerPlanAnnuity plan);

        [OperationContract]
        WSAnnuityFixedResult getAnnuityFixedModel(WSCustomer customer, WSCustomerPlanAnnuity plan);
        */

        [OperationContract]
        List<WSYesNo> getYesNoList();

        [OperationContract]
        List<WSPlantype> getPlanTypeList();


        [OperationContract]
        List<WSCalculatetype> getCalculateTypeList();

        [OperationContract]
        List<WSContributionType> getContributionTypeList();

        [OperationContract]
        List<WSRidertype> getRiderTypeList();
        [OperationContract]
        List<WSPlanGroup> getPlangroupList();

        [OperationContract]
        List<WSActivityrisktype> getActivityRiskTypeList();

        [OperationContract]
        List<WSDefermentPeriod> getDefermentPeriodList();
        [OperationContract]
        List<WSAnnuityPeriod> getAnnuityPeriodList();

        [OperationContract]
        List<WSClasscodeData> getClasscodeList();

        [OperationContract]
        List<WSCompany> getCompanyList();

        [OperationContract]
        List<WSCountry> getCountryList();

        [OperationContract]
        List<WSFrequencytype> getFrequencyTypeList();

        [OperationContract]
        List<WSGender> getGenderList();

        [OperationContract]
        List<WSHealthrisktype> getHealthRiskTypeList();

        [OperationContract]
        List<WSInvestmentprofile> getInvestmentprofileList();

        [OperationContract]
        List<WSMaritalStatus> getMaritalstatusList();

        [OperationContract]
        List<WSProduct> getProductList();

        [OperationContract]
        double GetGoalSeek(double InitialContribution, int Frequency, int ContributionPeriod, double PremiumAmount);
        /*
                public static List<WSActivityrisktype> wsactivityrisktypelist { get; set; }
                public static List<WSClasscodeData> wscountrieslist { get; set; }
                public static List<WSCompany> wscompanylist { get; set; }
                public static List<WSCountry> wscountrylist { get; set; }
                public static List<WSFrequencytype> wsfrequncytypelist { get; set; }
                public static List<WSGender> wsgenderlist { get; set; }
                public static List<WSHealthrisktype> wshealthrisktypelist { get; set; }        
                public static List<WSMaritalStatus> wsmaritalstatuslist { get; set; }
                public static List<WSInvestmentprofile> wsinvestmentprofilelist { get; set; }
                public static List<WSProduct> wsproductlist { get; set; }
                */

    }
}
