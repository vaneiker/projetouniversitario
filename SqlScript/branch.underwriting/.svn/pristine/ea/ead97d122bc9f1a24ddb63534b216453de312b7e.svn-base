using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web.ASPxPivotGrid;
using RESOURCE.UnderWriting.NewBussiness;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.Common.Illustration;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration
{
    public partial class UCIllustrationsPivot : UC, IUC
    {
        private GlobalVOEntities _voEntities = new GlobalVOEntities();
        private bool IsGerencialRole
        {
            get
            {
                return ((WEB.NewBusiness.NewBusiness.Pages.Illustrations)Page).Usuario.Propiedades.Any(o => o.Contains("SubscriptionManagerAutoAdmin"));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindingDropDown();

            ConfigureGrid(pgIllustrations);
        }

        private void BindingDropDown()
        {
            var lstPeriods = new Dictionary<int, string>{
            {(int) Period.Periods.Last3Month, Resources.LastNMonth.SFormat(3) },
            {(int) Period.Periods.Last6Month, Resources.LastNMonth.SFormat(6) }
        };
            foreach (var period in Utility.GetListPeriods())
                lstPeriods.Add(period.Key, period.Value);

            drpPeriod.DataSource = lstPeriods;
            drpPeriod.DataBind();
        }

        private void ConfigureGrid(ASPxPivotGrid grd)
        {
            if (drpPeriod.SelectedIndex == -1) return;
            grd.ClientSideEvents.EndCallback = Utility.GetJSPivotEndCallbackClickHandler(grd.ClientID);
            grd.CustomCellDisplayText += pivotGrid_CustomCellDisplayText;

            var period = (Period.Periods)drpPeriod.SelectedValue.ToInt();
            if (grd.Fields["PivotMonth"] != null)
                grd.Fields.Remove(grd.Fields["PivotMonth"]);
            if (grd.Fields["PivotQuarter"] != null)
                grd.Fields.Remove(grd.Fields["PivotQuarter"]);
            if (grd.Fields["Year"] != null)
                grd.Fields.Remove(grd.Fields["Year"]);

            MonthTemplate.AddYearToPivot(grd);

            if ((period == Period.Periods.Quarterly || period == Period.Periods.SeasonalQuarter) && grd.Fields["PivotQuarter"] == null)
            {
                MonthTemplate.AddQuarterToPivot(grd);
                if (grd.Fields["PivotMonth"] != null)
                    grd.Fields.Remove(grd.Fields["PivotMonth"]);
            }
            else if ((new[] { 
                Period.Periods.Monthly, 
                Period.Periods.SeasonalMonth, 
                Period.Periods.Last3Month, 
                Period.Periods.Last6Month }).Contains(period)
                && grd.Fields["PivotMonth"] == null)
            {
                MonthTemplate.AddMonthToPivot(grd);
                if (grd.Fields["PivotQuarter"] != null)
                    grd.Fields.Remove(grd.Fields["PivotQuarter"]);
            }

            foreach (var field in grd.Fields)
            {
                var item = (PivotGridField)field;
                if (item.Area == DevExpress.XtraPivotGrid.PivotArea.FilterArea ||
                    item.Area == DevExpress.XtraPivotGrid.PivotArea.RowArea)
                    item.Caption = Resources.ResourceManager.GetString(item.ID.IsNullOrEmptyReturnValue(item.FieldName)).ToUpper();
            }
        }

        private void ConfigurePeriodData(string periodData, Dictionary<int, string> data, string selectValue)
        {
            lblPeriodData.Text = periodData;
            lblPeriodData.Visible = true;
            drpPeriodData.Visible = true;
            drpPeriodData.DataSource = data;
            drpPeriodData.DataBind();
            drpPeriodData.SelectedValue = selectValue;
        }

        private void ChangePeriodData()
        {
            var currentPeriod = (Period.Periods)int.Parse(drpPeriod.SelectedValue);
            if (currentPeriod == Period.Periods.SeasonalMonth)
                ConfigurePeriodData(Resources.Month, Utility.GetListMonths(), DateTime.Now.Month.ToString());
            else if (currentPeriod == Period.Periods.SeasonalQuarter)
                ConfigurePeriodData(Resources.Quarter, Utility.GetListQuarters(), DateTime.Now.StartQuarterDate().Month.ToString());

            if (currentPeriod != Period.Periods.Monthly && currentPeriod != Period.Periods.Last3Month && currentPeriod != Period.Periods.Last6Month)
            {
                lblPeriodYears.Visible = true;
                drpPeriodYears.Visible = true;
                drpPeriodYears.DataSource = Utility.GetListYears();
                drpPeriodYears.DataBind();
                drpPeriodYears.SelectedValue = currentPeriod != Period.Periods.Quarterly ? "3" : "2";
            }
            else
            {
                lblPeriodYears.Visible =
                drpPeriodYears.Visible =
                lblPeriodData.Visible =
                drpPeriodData.Visible = false;
                drpPeriodYears.DataSource =
                drpPeriodData.DataSource = null;
                drpPeriodData.DataBind();
            }
        }  

        protected void dsIllustrations_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = "Id";

            var currentPeriod = (Period.Periods)byte.Parse(drpPeriod.SelectedValue);
            var currentPeriodData = drpPeriodData.SelectedIndex == -1 ? (byte)0 : byte.Parse(drpPeriodData.SelectedValue);
            var currentPeriodYear = drpPeriodYears.SelectedIndex == -1 ? 0 : drpPeriodYears.SelectedValue.ToInt();

            e.QueryableSource = GetIllustrations(currentPeriod, currentPeriodData, currentPeriodYear);
        }

        public IQueryable GetIllustrations(Period.Periods currentPeriod, byte currentPeriodData, int Years = 0)
        {
            var periodQuantity = 13;

            var from = DateTime.Now;
            if ((currentPeriod == Period.Periods.SeasonalMonth ||
                currentPeriod == Period.Periods.SeasonalQuarter)
                && currentPeriodData != 0)
                from = new DateTime(DateTime.Now.Year, currentPeriodData, 1);

            if (currentPeriod == Period.Periods.Last3Month)
                periodQuantity = 3;
            else if (currentPeriod == Period.Periods.Last6Month)
                periodQuantity = 6;

            var lstPeriods = from.GetPeriodsDate(currentPeriod, periodQuantity);
            from = lstPeriods.Min(o => o.StartDate);
            var to = lstPeriods.Max(o => o.EndDate);
            var pivotQuarter = currentPeriodData.ToString().PadLeft(2, '0') + "-" + Utility.GetQuarterFromMonth(currentPeriodData);

            if ((Years > 0) && !(new[] { 
                Period.Periods.Monthly, 
                Period.Periods.Last3Month, 
                Period.Periods.Last6Month }).Contains(currentPeriod))
                from = new DateTime(to.Year - (Years - 1), 1, 1);

            switch (ObjServices.Language)
            {
                case Utility.Language.es:
                    {
                        var query = _voEntities.VwPivotIllustration_es.Where(o =>
                            o.Corp_Id == ObjServices.Corp_Id &&
                            (o.StatusDate >= from && o.StatusDate <= to));

                        if (ObjServices.UserType != Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                        {
                            var lstAgentId = GetTreeAgentId();
                            query = query.Where(o => o.AgentId.HasValue && lstAgentId.Contains(o.AgentId.Value));
                        }
                        if (currentPeriod == Period.Periods.SeasonalMonth)
                            query = query.Where(o => o.Month == currentPeriodData);
                        if (currentPeriod == Period.Periods.SeasonalQuarter)
                            query = query.Where(o => o.PivotQuarter == pivotQuarter);                         
                        return query;
                    }
                case Utility.Language.en:
                default:
                    {
                        var query = _voEntities.VwPivotIllustration_es.Where(o =>
                            o.Corp_Id == ObjServices.Corp_Id &&
                            (o.StatusDate >= from && o.StatusDate <= to));

                        if (ObjServices.UserType != Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User)
                        {
                            var lstAgentId = GetTreeAgentId();
                            query = query.Where(o => o.AgentId.HasValue && lstAgentId.Contains(o.AgentId.Value));
                        }
                        if (currentPeriod == Period.Periods.SeasonalMonth)
                            query = query.Where(o => o.Month == currentPeriodData);
                        if (currentPeriod == Period.Periods.SeasonalQuarter)
                            query = query.Where(o => o.PivotQuarter == pivotQuarter);                        
                        return query;
                    }
            }
        }

        private List<int> GetTreeAgentId()
        {
            return ObjServices.oContactManager.GetAgentTree(new Entity.UnderWriting.Entities.Contact.AgentTreeParameter
            {
                CorpId = ObjServices.Corp_Id,
                AgentId = ObjServices.Agent_Id,
                AgentStatusId = 1,
                AgentType = ObjServices.UserType.ToString()
            }).Select(o => o.AgentId.GetValueOrDefault()).ToList();
        }

        private List<int> GetTreeSubscriberId()
        {
            return ObjServices.GettingDropData(
                                    Utility.DropDownType.Subscriber,
                                    corpId: ObjServices.Corp_Id,
                                    regionId: ObjServices.Region_Id,
                                    countryId: ObjServices.Country_Id,
                                    domesticregId: ObjServices.Domesticreg_Id,
                                    stateProvId: ObjServices.State_Prov_Id,
                                    cityId: ObjServices.City_Id,
                                    officeId: ObjServices.Office_Id,
                                    agentId: ObjServices.Agent_Id
                                   ).Select(o => o.AgentId.GetValueOrDefault()).ToList();
        }

        protected void btnExportExcelIllustrations_Click(object sender, EventArgs e)
        {
            ExportExcelIllustrations.ExportXlsToResponse("Illustrations", true);
            UpdatePanelIllustrations.Update();
        }

        protected void drpPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePeriodData();
            pgIllustrations.DataBind();
            UpdatePanelIllustrations.Update();
        }

        protected void drpPeriodData_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgIllustrations.DataBind();
            UpdatePanelIllustrations.Update();
        }

        protected void drpPeriodYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgIllustrations.DataBind();
            UpdatePanelIllustrations.Update();
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

        protected void pivotGrid_CustomCellDisplayText(object sender, DevExpress.Web.ASPxPivotGrid.PivotCellDisplayTextEventArgs e)
        {
            if (string.IsNullOrEmpty(e.DisplayText))
            {
                e.DisplayText = "0";
            }
        }
    }
}