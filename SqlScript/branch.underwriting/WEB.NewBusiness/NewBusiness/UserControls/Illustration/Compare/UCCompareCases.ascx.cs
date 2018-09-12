using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity.UnderWriting.IllusData;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare
{
    public partial class UCCompareCases : UC, IUC
    {
        public List<CustomerPlanDetail> ListIllustration
        {
            get
            {
                var data = ViewState["ListIllustration"];
                return data == null ? null : (List<CustomerPlanDetail>)ViewState["ListIllustration"];
            }
            set
            {
                ViewState["ListIllustration"] = value;
            }
        }

        public delegate void DAddIllustrationToCompare(long customerPlanNo);
        public DAddIllustrationToCompare AddIllustrationToCompare;

        public delegate void DRemoveIllustrationToCompare(long customerPlanNo);
        public DRemoveIllustrationToCompare RemoveIllustrationToCompare;

        public IEnumerable<CustomerPlanDetail> GetIllustration(IEnumerable<CustomerPlanDetail> data)
        {
            return data;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dsIllustrationAvailable_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = ListIllustration.Where(o => !o.ToCompare);
        }

        protected void dsIllustrationCompare_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = ListIllustration.Where(o => o.ToCompare);
        }

        public void Translator(string Lang)
        {
            gvIllustrationCompare.TranslateColumnsAspxGrid();
            gvIllustrationAvailable.TranslateColumnsAspxGrid();
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
            ListIllustration = null;
            ListIllustration = ObjIllustrationServices
                .oIllusDataManager
                .GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
                {
                    RCustomerNo = ObjIllustrationServices.CustomerNo.GetValueOrDefault()
                }).Where(o => o.IsApproved == "Y")
                .Select(o => new CustomerPlanDetail
                {
                    CustomerPlanNo = o.CustomerPlanNo,
                    DispIllustrationNo = o.DispIllustrationNo,
                    Product = o.Product,
                    PremiumAmount = o.PremiumAmount.ToFormatCurrency(),
                    BenefitAmount = o.BenefitAmount.GetValueOrDefault().ToFormatCurrency()
                }).ToList();
            Reload();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        private void Reload()
        {
            gvIllustrationAvailable.DataBind();
            gvIllustrationCompare.DataBind();

            var available = ListIllustration.Where(o => !o.ToCompare).Count();
            var compare = ListIllustration.Where(o => o.ToCompare).Count();

            btnAddToCompare.Visible = compare < 4 && available > 0;
            btnRemoveToCompare.Visible = compare > 0;

            hdnCheckedAvailableIllustrations.Value = hdnCheckedCompareIllustrations.Value = "";
        }

        protected void btnAddToCompare_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hdnCheckedAvailableIllustrations.Value)) return;
            var lstCustomerPlanNo = hdnCheckedAvailableIllustrations.Value.Split('|').Where(o => !String.IsNullOrEmpty(o));
            foreach (var c in lstCustomerPlanNo)
            {
                var customerPlanNo = c.ToLong();
                var illus = ListIllustration.FirstOrDefault(o => o.CustomerPlanNo.GetValueOrDefault() == customerPlanNo);
                if (illus == null) continue;
                illus.ToCompare = true;
                AddIllustrationToCompare(customerPlanNo);
            }
            Reload();
        }

        protected void btnRemoveToCompare_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(hdnCheckedCompareIllustrations.Value)) return;
            var lstCustomerPlanNo = hdnCheckedCompareIllustrations.Value.Split('|').Where(o => !String.IsNullOrEmpty(o));
            foreach (var c in lstCustomerPlanNo)
            {
                var customerPlanNo = c.ToLong();
                var illus = ListIllustration.FirstOrDefault(o => o.CustomerPlanNo.GetValueOrDefault() == customerPlanNo);
                if (illus == null) continue;
                illus.ToCompare = false;
                RemoveIllustrationToCompare(customerPlanNo);
            }
            Reload();
        }

        [Serializable]
        public class CustomerPlanDetail
        {
            public long? CustomerPlanNo { get; set; }
            public DateTime PlanDate { get; set; }
            public string ProductCode { get; set; }
            public string PClass { get; set; }
            public long? CustomerNo { get; set; }
            public string FrequencyTypeCode { get; set; }
            public int? Frequency { get; set; }
            public decimal InsuredAmount { get; set; }
            public string PremiumAmount { get; set; }
            public decimal AnnualizedPremium { get; set; }
            public DateTime? EndDate { get; set; }
            public decimal ProjectedPremium { get; set; }
            public decimal InitialContribution { get; set; }
            public decimal InitialCommission { get; set; }
            public decimal TargetPremium { get; set; }
            public string InsuranceLevelCode { get; set; }
            public string CalculateTypeCode { get; set; }
            public string ContributionTypeCode { get; set; }
            public string InvestmentProfileCode { get; set; }
            public decimal InvestmentProfilePercent { get; set; }
            public int ActivityRiskTypeNo { get; set; }
            public int HealthRiskTypeNo { get; set; }
            public int ContributionPeriod { get; set; }
            public string FinancialGoal { get; set; }
            public int FinancialGoalAge { get; set; }
            public decimal FinancialGoalAmount { get; set; }
            public string CurrencyCode { get; set; }
            public string RiderAdb { get; set; }
            public string RiderTerm { get; set; }
            public string RiderOir { get; set; }
            public int CountryNo { get; set; }
            public string PlanTypeCode { get; set; }
            public DateTime DateCreated { get; set; }
            public int CreatedBy { get; set; }
            public DateTime DateUpdated { get; set; }
            public int UpdatedBy { get; set; }
            public decimal RiderAdbAmount { get; set; }
            public decimal RiderTermAmount { get; set; }
            public int RiderTermUntilAge { get; set; }
            public string RiderCi { get; set; }
            public decimal RiderCiAmount { get; set; }
            public string RiderAcdb { get; set; }
            public long? RCustomerPlanNo { get; set; }
            public long? IllustrationNo { get; set; }
            public string DataEntryTypeCode { get; set; }
            public long? PlanCode { get; set; }
            public int UserId { get; set; }
            public int ContributionUntilAge { get; set; }
            public decimal OpeningBalance { get; set; }
            public decimal MinimumPremium { get; set; }
            public int? OpeningYear { get; set; }
            public DateTime? PlanEffectiveDate { get; set; }
            public string IllustrationVerified { get; set; }
            public decimal RiderAdbCost { get; set; }
            public decimal RiderAcdbCost { get; set; }
            public decimal RiderTermCost { get; set; }
            public decimal RiderCiCost { get; set; }
            public decimal TermPeriod { get; set; }
            public decimal RetirementPeriod { get; set; }
            public decimal DefermentPeriod { get; set; }
            public decimal AnnuityAmount { get; set; }
            public int CompanyNo { get; set; }
            public DateTime? DateSynced { get; set; }
            public long? RecordId { get; set; }
            public string OtherPlans { get; set; }
            public string DispIllustrationNo { get; set; }
            public string BenefitAmount { get; set; }
            public string DispPlanCode { get; set; }
            public string TermContributionTypeCode { get; set; }
            public string IsSpecial { get; set; }
            public string ChangeType { get; set; }
            public int? BoUpdatedBy { get; set; }
            public int? BoLastUpdatedBy { get; set; }
            public DateTime? NewStatusDate { get; set; }
            public string IsoPeningBalance { get; set; }
            public string IsApproved { get; set; }
            public string PolicyStatusCode { get; set; }
            public string IsPolicyChangesApproved { get; set; }
            public string IsDeleted { get; set; }
            public string StudentName { get; set; }
            public int? StudentAge { get; set; }
            public string IsCustomerOwner { get; set; }
            public long? OwnerCustomerNo { get; set; }
            public string IllustrationStatusCode { get; set; }
            public string PlanGroupCode { get; set; }
            public string Product { get; set; }
            public string ActivityRiskType { get; set; }
            public string Currency { get; set; }
            public string FrequencyType { get; set; }
            public string InsuranceLevel { get; set; }
            public string CalculateType { get; set; }
            public string InvestmentProfile { get; set; }
            public string HealthRiskType { get; set; }
            public string CountryName { get; set; }
            public string PlanType { get; set; }
            public string ContributionTypeDescCode { get; set; }
            public string ContributionTypeDescTerm { get; set; }
            public int UserIdSystem { get; set; }
            public bool ToCompare { get; set; }
        }
    }
}