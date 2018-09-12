using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using Entity.UnderWriting.IllusData;
namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare
{
    public partial class UCAxysSummary : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FillData(long customerPlanNo)
        {
            string familyProductName = null;
            string productName = null;
            string currency = null;
            string insuredName = null;
            string ownerName = null;
            string ownerAge = null;
            string retireeStudentAdditionalName = null;
            string investmentProfile = null;
            string risk = null;
            string perThousand = null;
            string age = null;
            string insuredBenefitRetirementAmount = null;
            string TotalInsuredBenefitRetirementAmount = null;
            string annualPremium = null;
            string periodicPremium = null;
            string paymentFrequency = null;
            string minimumPremium = null;
            string TargetPremium = null;
            string contributionPeriod = null;
            string defermentPeriod = null;
            string educationRetirementPeriod = null;
            bool riderAdb;
            string riderAdbAmount = null;
            bool riderTerm;
            string riderTermYear = null;
            string riderTermAmount = null;
            bool riderOir;
            string riderOirYear = null;
            string riderOirAmount = null;
            bool riderCi;
            string riderCiAmount = null;
            bool finantialGoal;
            string finantialGoalAge = null;
            string finantialGoalAmount = null;
            string returnOfPremium = null;
            string planType = null;
            int maxAge = 0;
            bool initialContribution;
            string initialContributionAmount = null;

            var customerPlan = ObjIllustrationServices.oIllusDataManager.GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
                {
                    CustomerPlanNo = customerPlanNo
                }).First();
            var customer = ObjIllustrationServices.oIllusDataManager.GetCustomerDetailById(customerPlan.CustomerNo, null);
            if (customerPlan == null)
            {
                CleanControls(this);
                return;
            }

            ltrPlanTitle.Text = customerPlan.DispIllustrationNo;
            productName = customerPlan.Product;
            familyProductName = Utility.GetIllusDropDownByType(Utility.DropDownType.FamilyProduct, companyId: ObjIllustrationServices.IllusCompanyId).Single(o => o.PlanGroupCode == customerPlan.PlanGroupCode).PlanGroup;
            ownerName = "{0} {1}".SFormat(customer.FirstName.NTrim(), customer.LastName.NTrim());
            ownerAge = customer.Age.ToString();
            retireeStudentAdditionalName = customerPlan.StudentName;
            age = customerPlan.StudentAge.ToString();
            currency = customerPlan.Currency;
            planType = customerPlan.PlanType;
            investmentProfile = customerPlan.InvestmentProfile;
            contributionPeriod = (customerPlan.ContributionUntilAge == 0 ? customerPlan.ContributionPeriod : customerPlan.ContributionUntilAge).ToString();
            paymentFrequency = customerPlan.FrequencyType;
            periodicPremium = customerPlan.PremiumAmount.ToFormatCurrency();
            TargetPremium = customerPlan.TargetPremium.ToFormatCurrency();
            TotalInsuredBenefitRetirementAmount =
              Math.Round(
              familyProductName == Utility.EFamilyProductType.Education.Code() || familyProductName == Utility.EFamilyProductType.Retirement.Code() ?
              customerPlan.AnnuityAmount * customerPlan.RetirementPeriod :
              customerPlan.InsuredAmount + customerPlan.RiderTermAmount).ToFormatCurrency();
            minimumPremium = Math.Round(customerPlan.MinimumPremium).ToFormatCurrency();
            annualPremium = Math.Round(customerPlan.AnnualizedPremium).ToFormatCurrency();

            returnOfPremium = Math.Round(customerPlan.PremiumAmount * customerPlan.Frequency.GetValueOrDefault() * customerPlan.ContributionPeriod).ToFormatCurrency();

            if (customerPlan.RiderTerm == "Y" || customerPlan.RiderOir == "Y")
            {
                var rule = ObjIllustrationServices.oIllusDataManager.GetAllRuleParameter(WEB.NewBusiness.Common.Illustration.RulesService.Rules.MAX_AGE.ToInt(), customerPlan.ProductCode).FirstOrDefault();
                maxAge = rule == null ? 0 : rule.RuleParameterValue.ToInt();
            }
            riderAdb = customerPlan.RiderAdb == "Y";
            if (riderAdb)
                riderAdbAmount = customerPlan.RiderAdbAmount.ToFormatCurrency();

            riderTerm = customerPlan.RiderTerm == "Y";
            if (riderTerm)
            {
                riderTermAmount = customerPlan.RiderTermAmount.ToFormatCurrency();
                if (customerPlan.TermContributionTypeCode == Utility.EContributionType.UntilAge.Code())
                    riderTermYear = customerPlan.RiderTermUntilAge.ToString();
                else if (customerPlan.TermContributionTypeCode == Utility.EContributionType.NumberOfYears.Code())
                    riderTermYear = (customerPlan.RiderTermUntilAge + customer.Age.ToInt() - 1).ToString();
                else
                    riderTermYear = (maxAge - customer.Age.ToInt()).ToString();
            }

            riderCi = customerPlan.RiderCi == "Y";
            if (riderCi)
                riderCiAmount = customerPlan.RiderCiAmount.ToFormatCurrency();

            riderOir = customerPlan.RiderOir == "Y";
            if (riderOir)
            {
                var CustomerPlanOI = ObjIllustrationServices.oIllusDataManager.GetCustomerPlanPartnerInsurance(customerPlan.CustomerPlanNo.Value);
                if (CustomerPlanOI != null)
                {
                    riderOirAmount = CustomerPlanOI.InsuredAmount.ToFormatCurrency();
                    if (CustomerPlanOI.ContributionTypeCode == Utility.EContributionType.UntilAge.Code())
                        riderOirYear = CustomerPlanOI.UntilAge.ToString();
                    else if (CustomerPlanOI.ContributionTypeCode == Utility.EContributionType.NumberOfYears.Code())
                        riderOirYear = (CustomerPlanOI.UntilAge + CustomerPlanOI.Age.ToInt() - 1).ToString();
                    else
                        riderOirYear = (maxAge - CustomerPlanOI.Age.ToInt()).ToString();
                }
            }

            if (familyProductName == Utility.EFamilyProductType.Education.Code() || familyProductName == Utility.EFamilyProductType.Retirement.Code())
                insuredBenefitRetirementAmount = customerPlan.AnnuityAmount.ToFormatCurrency();
            else
                insuredBenefitRetirementAmount = customerPlan.BenefitAmount.GetValueOrDefault().ToFormatCurrency();

            finantialGoal = customerPlan.FinancialGoal == "Y";

            if (finantialGoal)
            {
                finantialGoalAge = customerPlan.FinancialGoalAge.ToString();
                finantialGoalAmount = customerPlan.FinancialGoalAmount.ToFormatCurrency();
            }

            initialContribution = customerPlan.InitialContribution > 0;
            if (initialContribution)
                initialContributionAmount = customerPlan.InitialContribution.ToFormatCurrency();

            var data = new List<Tuple<string, string>>
            {
                    Tuple.Create<string,string>(Resources.ProductName , productName),
                    Tuple.Create<string,string>(Resources.Currency , currency),
                    Tuple.Create<string,string>(Resources.OwnerName , ownerName),
                    Tuple.Create<string,string>(Resources.Age , ownerAge),
                    Tuple.Create<string,string>(Resources.InsuredName , insuredName)
            };

            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(productName.Replace("Básico", "").Replace(" ", ""), typeof(Utility.ProductBehavior));

            data.Add(Tuple.Create<string, string>(Resources.PlanTypeLabel, planType));

            var familyProduct = (Utility.EFamilyProductType)Utility.getvalueFromEnumType(familyProductName.Replace(" ", ""), typeof(Utility.EFamilyProductType));
            switch (familyProduct)
            {
                case Utility.EFamilyProductType.Education:
                    data.Add(Tuple.Create<string, string>(Resources.TotalStudyAmount, TotalInsuredBenefitRetirementAmount));
                    data.Add(Tuple.Create<string, string>(Resources.PlanTypeLabel, planType));
                    data.Add(Tuple.Create<string, string>(Resources.AnnualStudyAmount, insuredBenefitRetirementAmount));
                    data.Add(Tuple.Create<string, string>(Resources.DefermentPeriodLabel, defermentPeriod));
                    data.Add(Tuple.Create<string, string>(Resources.StudentPeriod, educationRetirementPeriod));
                    data.Add(Tuple.Create<string, string>(Resources.StudentNameLabel, retireeStudentAdditionalName));
                    data.Add(Tuple.Create<string, string>(Resources.Age, age));
                    break;
                case Utility.EFamilyProductType.Retirement:
                    data.Add(Tuple.Create<string, string>(Resources.TotalRetirementAmount, TotalInsuredBenefitRetirementAmount));
                    data.Add(Tuple.Create<string, string>(Resources.PlanTypeLabel, planType));
                    data.Add(Tuple.Create<string, string>(Resources.AnnualRetirementAmount, insuredBenefitRetirementAmount));
                    data.Add(Tuple.Create<string, string>(Resources.DefermentPeriodLabel, defermentPeriod));
                    data.Add(Tuple.Create<string, string>(Resources.RetirementPeriod, educationRetirementPeriod));
                    break;
                case Utility.EFamilyProductType.LifeInsurance:
                    data.Add(Tuple.Create<string, string>(Resources.InsuredAmountLabel, insuredBenefitRetirementAmount));
                    break;
                case Utility.EFamilyProductType.TermInsurance:
                    data.Add(Tuple.Create<string, string>(Resources.InsuredAmountLabel, insuredBenefitRetirementAmount));
                    break;
                default:
                    break;
            }

            data.Add(Tuple.Create<string, string>(Resources.AnnualPremium, annualPremium));
            data.Add(Tuple.Create<string, string>(Resources.PeriodicPremium, periodicPremium));
            data.Add(Tuple.Create<string, string>(Resources.PaymentFrequency, paymentFrequency));
            data.Add(Tuple.Create<string, string>(Resources.MinimumPremium, minimumPremium));
            data.Add(Tuple.Create<string, string>(Resources.TargetPremium, TargetPremium));

            if (!String.IsNullOrEmpty(contributionPeriod))
                data.Add(Tuple.Create<string, string>(Resources.ContributionPeriodLabel, contributionPeriod));

            if (initialContribution)
                data.Add(Tuple.Create<string, string>(Resources.InitialContributionLabel, initialContributionAmount));

            if (finantialGoal)
            {
                data.Add(Tuple.Create<string, string>(Resources.FinancialGoalAtLabel, finantialGoalAge));
                data.Add(Tuple.Create<string, string>(Resources.FinancialGoalLabel, finantialGoalAmount));
            }

            if (productBehavior == Utility.ProductBehavior.Sentinel)
                data.Add(Tuple.Create<string, string>(Resources.ReturnofPremium, returnOfPremium));

            if (!String.IsNullOrEmpty(investmentProfile))
                data.Add(Tuple.Create<string, string>(Resources.InvestmentProfile, investmentProfile));

            if (riderTerm)
            {
                data.Add(Tuple.Create<string, string>(Resources.RiderInfo, Resources.AdditionalTermInsuranceLabel));
                data.Add(Tuple.Create<string, string>(Resources.Years, riderTermYear));
                data.Add(Tuple.Create<string, string>(Resources.AmountLabel, riderTermAmount));
            }

            if (riderAdb)
            {
                data.Add(Tuple.Create<string, string>(Resources.RiderInfo, Resources.AccidentalDeathBenefitsLabel));
                data.Add(Tuple.Create<string, string>(Resources.AmountLabel, riderAdbAmount));
            }

            if (riderOir)
            {
                data.Add(Tuple.Create<string, string>(Resources.RiderInfo, Resources.SpouseOtherInsuredLabel));
                data.Add(Tuple.Create<string, string>(Resources.Years, riderOirYear));
                data.Add(Tuple.Create<string, string>(Resources.AmountLabel, riderOirAmount));
            }

            if (riderCi)
            {
                data.Add(Tuple.Create<string, string>(Resources.RiderInfo, Resources.CriticalIllnessLabel));
                data.Add(Tuple.Create<string, string>(Resources.AmountLabel, riderCiAmount));
            }

            rpPlanSummary.DataSource = data;
            rpPlanSummary.DataBind();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}