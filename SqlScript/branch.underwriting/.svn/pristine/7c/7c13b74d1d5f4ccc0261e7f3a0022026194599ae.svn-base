using DevExpress.Web;
using Entity.UnderWriting.IllusData;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.Common.Illustration;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration
{
    public partial class UCIllustrationsLifeList : UC,IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var lstIllustrationInformation = ObjIllustrationServices
                       .oIllusDataManager
                       .GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
                       {
                           UserId = 3424,
                           CompanyId = 2,
                           DateFrom = null,
                           DateTo = null,
                           CorpId = 1,
                           RegionId = 24,
                           CountryId = 129,
                           DomesticregId = 1,
                           StateProvId = 817,
                           CityId = 4442381,
                           OfficeId = 1,
                           LanguageId = ObjServices.Language.ToInt(),
                           GetHistorical = false,
                           IllustrationStatusCode = "ISU",
                           TabFilter = "Subscriptions",
                           AgentNameId = null,
                           AgentType = "Agent",
                           AssignedSubscriberNameId = "10321JOEL"
                       }).Select(o => new IllustrationInformation
                          {
                              CustomerPlanNo = o.CustomerPlanNo.GetValueOrDefault(),
                              InsuredId = o.InsuredId.GetValueOrDefault(),
                              CorpId = o.CorpId,
                              RegionId = o.RegionId,
                              CountryId = o.CountryId,
                              DomesticregId = o.DomesticregId,
                              StateProvId = o.StateProvId,
                              CityId = o.CityId,
                              OfficeId = o.OfficeId,
                              CaseSeqNo = o.CaseSeqNo,
                              HistSeqNo = o.HistSeqNo,
                              Company = o.CompanyDesc,
                              Identification = o.Identification,
                              Country = o.CountryName,
                              FamilyProduct = o.PlanGroup.Translate(),
                              PlanGroupCode = o.PlanGroupCode,
                              PlanType = o.Product,
                              IllustrationNo = o.DispIllustrationNo,
                              //IllustrationDate = String.Format(CultureInfo.InvariantCulture, "{0:dd-MMM-yyyy hh:mm tt}", o.DateCreated),
                              //ExpirationDate = String.Format(CultureInfo.InvariantCulture, "{0:dd-MMM-yyyy hh:mm tt}", o.DateCreated.AddDays(1)),
                              IllustrationDate = o.DateCreated,
                              ExpirationDate = o.DateCreated.AddDays(1),
                              IllustrationStatusCode = o.IllustrationStatusCode,
                              AvailableDays = 1,
                              InsuredName = o.InsuredName,
                              Frequency = o.FrequencyType.Translate(),
                              InsuredAmount = 1,
                              InsuredAmountF = "NA1",
                              TotalPremium = 1,
                              TotalPremiumF = "NA2",
                              InitialPremium = o.InitialContribution,
                              InitialPremiumF = o.InitialContribution.ToFormatNumeric(),
                              Status = ("Illustration_" + o.IllustrationStatusCode).Translate(),
                              Office = o.OfficeDesc,
                              AgentName = o.Agent,
                              Channel = o.Channel,
                              Priority = o.Priority,
                              //NewStatusDate = ((DateTime)o.NewStatusDate).ToString("dd-MMM-yyyy hh:mm tt"),
                              NewStatusDate = ((o.NewStatusDate != null) ? (o.NewStatusDate) : null),
                              MissingDocuments = o.PendingDocumentsNo,
                              AgentId = o.AgentId,
                              AssignedSubscriber = o.AssignedSubscriber,
                              AssignedSubscriberId = o.AssignedSubscriberId,
                              isExpired = false,
                              FinancialClearance = string.Empty
                          }).ToList();
                gvIllustrationLife.DataSource = lstIllustrationInformation;
                gvIllustrationLife.DataBind();
            }
          
        }

        public void Translator(string Lang)
        {
            
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
            ChangeVisibilityHeaderTextColumn();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        protected void gvIllustrationLife_PreRender(object sender, EventArgs e)
        {
            gvIllustrationLife.TranslateColumnsAspxGrid();
        }

        private void ChangeVisibilityHeaderTextColumn()
        {
            var TabSelected = Utility.Tabs.lnkSubscriptions;
            
            var paidPremium = gvIllustrationLife.Columns["PaidPremium"];
            var literalStatus = gvIllustrationLife.Columns["LiteralStatus"];
            var newStatusDate = gvIllustrationLife.Columns["NewStatusDate"];
            var expirationDate = gvIllustrationLife.Columns["ExpirationDate"];
            var missingDays = gvIllustrationLife.Columns["Days"];
            var missingDocuments = gvIllustrationLife.Columns["MissingDocuments"];
            var assignedSubscriber = gvIllustrationLife.Columns["AssignedSubscriber"];

            paidPremium.Visible =
            newStatusDate.Visible =
            expirationDate.Visible =
            missingDocuments.Visible =
            assignedSubscriber.Visible = false;

            literalStatus.Visible =
            missingDays.Visible = true;

            //missingDays.Caption = Resources.MissingDays.ToUpper();
            missingDays.Caption = Resources.Days.ToUpper();

            #region Porcentajes Columnas
            var LineofBusinessLabelWidth = gvIllustrationLife.Columns["LineofBusinessLabel"];
            var PlanTypeLabelWidth = gvIllustrationLife.Columns["PlanTypeLabel"];
            var IllustrationLabelWidth = gvIllustrationLife.Columns["ILLUSTRATIONLABEL"];
            var LiteralStatusWidth = gvIllustrationLife.Columns["LiteralStatus"];
            var OfficeWidth = gvIllustrationLife.Columns["Office"];
            var ChannelWidth = gvIllustrationLife.Columns["Channel"];
            var VendorWidth = gvIllustrationLife.Columns["Vendor"];
            var InsuredWidth = gvIllustrationLife.Columns["INSURED"];
            var IdWidth = gvIllustrationLife.Columns["ID"];
            var PremiumWithoutTaxWidth = gvIllustrationLife.Columns["PremiumWithoutTax"];
            var PaidPremiumWidth = gvIllustrationLife.Columns["PaidPremium"];
            var InsuredAmountWidth = gvIllustrationLife.Columns["InsuredAmount"];
            var Illustration_DateWidth = gvIllustrationLife.Columns["Illustration_Date"];
            var Expiration_DateWidth = gvIllustrationLife.Columns["Expiration_Date"];
            var NewStatusDateWidth = gvIllustrationLife.Columns["NewStatusDate"];
            var SubscriberWidth = gvIllustrationLife.Columns["Subscriber"];
            var DaysWidth = gvIllustrationLife.Columns["Days"];
            var MissingDocumentsWidth = gvIllustrationLife.Columns["MissingDocuments"];
            #endregion

            switch (TabSelected)
            {
                case Utility.Tabs.lnkIllustrationsToWork:
                    newStatusDate.Visible = false;

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("11%");
                    PaidPremiumWidth.Width = new Unit("11%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkIncompleteIllustration:
                    newStatusDate.Visible =
                    literalStatus.Visible = false;

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("11%");
                    PaidPremiumWidth.Width = new Unit("11%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkCompleteIllustrations:
                    newStatusDate.Visible =
                    literalStatus.Visible = false;

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("11%");
                    PaidPremiumWidth.Width = new Unit("11%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkDeclinedByClient:
                    //paidPremium.Visible =
                    missingDays.Visible =
                    expirationDate.Visible =
                    literalStatus.Visible = false;

                    newStatusDate.Visible = true;
                    newStatusDate.Caption = Resources.DeclinedDate.ToUpper();

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("11%");
                    PaidPremiumWidth.Width = new Unit("11%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkExpired:
                    missingDays.Visible =
                    newStatusDate.Visible =
                    literalStatus.Visible = false;

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("11%");
                    PaidPremiumWidth.Width = new Unit("11%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkExpiring:
                    newStatusDate.Visible = false;

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("11%");
                    PaidPremiumWidth.Width = new Unit("11%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkApprovedByClient:
                    expirationDate.Visible =
                    missingDays.Visible =
                    newStatusDate.Visible =
                    literalStatus.Visible = false;
                    break;
                case Utility.Tabs.lnkSubscriptions:
                    expirationDate.Visible =
                    literalStatus.Visible = false;
                    assignedSubscriber.Visible = true;

                    //missingDays.Caption = Resources.DaysInSubscription.ToUpper();
                    missingDays.Caption = Resources.Days.ToUpper();
                    //newStatusDate.Caption = Resources.EntryDate.ToUpper();

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("10%");
                    IllustrationLabelWidth.Width = new Unit("10%");
                    LiteralStatusWidth.Width = new Unit("7%");
                    OfficeWidth.Width = new Unit("10%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("9%");
                    PremiumWithoutTaxWidth.Width = new Unit("9%");
                    PaidPremiumWidth.Width = new Unit("9%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkDeclinedBySubscription:
                    //paidPremium.Visible =
                    expirationDate.Visible =
                    missingDays.Visible =
                    literalStatus.Visible = false;

                    //newStatusDate.Caption = Resources.EntryDate.ToUpper();

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("10%");
                    IllustrationLabelWidth.Width = new Unit("10%");
                    LiteralStatusWidth.Width = new Unit("7%");
                    OfficeWidth.Width = new Unit("10%");
                    ChannelWidth.Width = new Unit("15%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("9%");
                    PremiumWithoutTaxWidth.Width = new Unit("9%");
                    PaidPremiumWidth.Width = new Unit("9%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkMissingDocuments:
                    expirationDate.Visible =
                    literalStatus.Visible = false;

                    missingDocuments.Visible = true;
                    //newStatusDate.Caption = Resources.EntryDate.ToUpper();

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("10%");
                    IllustrationLabelWidth.Width = new Unit("10%");
                    LiteralStatusWidth.Width = new Unit("7%");
                    OfficeWidth.Width = new Unit("10%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("9%");
                    PremiumWithoutTaxWidth.Width = new Unit("9%");
                    PaidPremiumWidth.Width = new Unit("9%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkMissingInspections:
                    newStatusDate.Visible = true;
                    newStatusDate.Caption = Resources.InspectionDate.ToUpper();

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("10%");
                    IllustrationLabelWidth.Width = new Unit("10%");
                    LiteralStatusWidth.Width = new Unit("7%");
                    OfficeWidth.Width = new Unit("10%");
                    ChannelWidth.Width = new Unit("15%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("9%");
                    PremiumWithoutTaxWidth.Width = new Unit("9%");
                    PaidPremiumWidth.Width = new Unit("9%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkApprovedBySubscription:
                    missingDays.Visible =
                    newStatusDate.Visible =
                    expirationDate.Visible = false;

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("12%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("7%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("15%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("9%");
                    PremiumWithoutTaxWidth.Width = new Unit("9%");
                    PaidPremiumWidth.Width = new Unit("9%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                case Utility.Tabs.lnkHistoricalIllustrations:
                    //newStatusDate.Caption = Resources.EntryDate.ToUpper();

                    #region pocentajes columnas
                    LineofBusinessLabelWidth.Width = new Unit("7%");
                    PlanTypeLabelWidth.Width = new Unit("11%");
                    IllustrationLabelWidth.Width = new Unit("12%");
                    LiteralStatusWidth.Width = new Unit("12%");
                    OfficeWidth.Width = new Unit("12%");
                    ChannelWidth.Width = new Unit("12%");
                    VendorWidth.Width = new Unit("15%");
                    InsuredWidth.Width = new Unit("15%");
                    IdWidth.Width = new Unit("11%");
                    PremiumWithoutTaxWidth.Width = new Unit("9%");
                    PaidPremiumWidth.Width = new Unit("9%");
                    InsuredAmountWidth.Width = new Unit("9%");
                    Illustration_DateWidth.Width = new Unit("9%");
                    Expiration_DateWidth.Width = new Unit("9%");
                    NewStatusDateWidth.Width = new Unit("9%");
                    SubscriberWidth.Width = new Unit("12%");
                    DaysWidth.Width = new Unit("4%");
                    #endregion

                    break;
                default:
                    break;
            }
        }

        protected void btnPrintListToExcellLife_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsxToResponse("IllustrationLifeList");
        }

    }
}