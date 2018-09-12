using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy
{
    public partial class UCPopPerzonalizedProfile : UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            PolicyNo.InnerHtml = Resources.PolicyNoLabel;
            PlanName.InnerHtml = Resources.PlanName;
            InvestmentProfile.InnerHtml = Resources.InvestmentProfile;
            Currency.InnerHtml = Resources.CurrencyLabel;
            PlanType.InnerHtml = Resources.PlanTypeLabel;
            ProfileType.InnerHtml = Resources.ProfileType;
            ProfileDistribution.InnerHtml = Resources.ProfileDistribution;
            btPerPronSave.Text = Resources.Save;
            gvPopProfileDistribution.Columns[0].HeaderText = Resources.Symbol;
            gvPopProfileDistribution.Columns[1].HeaderText = Resources.NameLabel;
            gvPopProfileDistribution.Columns[2].HeaderText = Resources.PercentageLabel;
            TOTALDISTRIBUTION.InnerHtml = Resources.TOTALDISTRIBUTION.ToUpper();
        }

        public void FillData(IEnumerable<Entity.UnderWriting.Entities.Policy.InvestProfilePersonalized> data,List<DropDownList> drops)
        {
            //Personalized Profile Data
            txtIPPolicy.Text = "";
            txtIPInvestmentProfile.Text = "";
            txtIPCurrency.Text = "";            
            txtIPProfileType.Text = "";
            txtPPTotalPercent.Text = "0%";
            txtIPPlanName.Text = "";
            txtIPPlanType.Text = "";

            //FillGrid
            gvPopProfileDistribution.DataSource = data;
            gvPopProfileDistribution.DataBind();

            //Personalized Profile Data
            if (data.Any())
            {                    
                var dataFirst = data.First();

                txtIPPolicy.Text = dataFirst.PolicyNo;
                txtIPPlanName.Text = string.IsNullOrEmpty(dataFirst.ProductDesc)?drops[0].SelectedItem.Text:dataFirst.ProductDesc;
                txtIPInvestmentProfile.Text = dataFirst.ProfileTypeDesc;
                txtIPCurrency.Text = dataFirst.CurrencyDesc;
                txtIPPlanType.Text = string.IsNullOrEmpty(dataFirst.SerieDesc)?drops[1].SelectedItem.Text:dataFirst.SerieDesc;
                txtIPProfileType.Text = dataFirst.ProfileType;
                hdnPIPProfTypeId.Value = dataFirst.ProfileTypeId.ToString();
                txtPPTotalPercent.Text = data.Sum(r => r.InvstProfilePercent.HasValue ? r.InvstProfilePercent.Value : 0).ToString("N2") + "%";
            }
        }

        protected void btPerPronCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btPerPronSave_Click(object sender, EventArgs e)
        {
            //Profile Item List
            var investProfileList = new List<Entity.UnderWriting.Entities.Policy.InvestProfilePersonalized>();

            if (gvPopProfileDistribution.Rows.Count > 0)
            {
                var investDate = gvPopProfileDistribution.DataKeys[1]["InvstProductDate"];
                DateTime investDateValue = investDate == null ? DateTime.Now : investDate.ToString().ParseFormat().Value;
                var investProductDateIdNull = gvPopProfileDistribution.DataKeys[1]["InvestProductDateId"];
                int investProductDateId = investProductDateIdNull != null ? int.Parse(investProductDateIdNull.ToString()) : int.Parse(investDateValue.ToString("yyyyMMdd"));

                var invtpro = new Policy.InvestProfile
                {
                    ProfileTypeId = int.Parse(hdnPIPProfTypeId.Value),
                    InvestProductDateId = investProductDateId,
                    InvestmentProductDate = investDateValue,
                    InvstProfileDesc = txtIPInvestmentProfile.Text.Trim(),
                };

                for (int i = 0; i < gvPopProfileDistribution.Rows.Count; i++)
                {
                    var stockExchangeId = gvPopProfileDistribution.DataKeys[i]["StockExchangeId"];
                    var investmentCurrency = gvPopProfileDistribution.DataKeys[i]["InvestmentCurrency"];

                    //Percentage Amount TextBox
                    var txtPercent = ((TextBox)gvPopProfileDistribution.Rows[i].FindControl("txtPDPercentage"));

                    if (!(decimal.Parse(string.IsNullOrWhiteSpace(txtPercent.Text) ? "0" : txtPercent.Text) <= 0))
                    {
                        //Profile Item
                        var investProfile = new Entity.UnderWriting.Entities.Policy.InvestProfilePersonalized
                        {
                            //Profile Data
                            InvestProductDateId = investProductDateId,
                            ProfileTypeId = int.Parse(hdnPIPProfTypeId.Value),
                            SymbolId = int.Parse(gvPopProfileDistribution.DataKeys[i]["SymbolId"].ToString()),
                            InvstProductDate = investDateValue,
                            InvestmentProfileDate = gvPopProfileDistribution.DataKeys[i]["InvestmentProfileDate"].ToString().ParseFormat().Value,
                            InvstProfilePercent = Decimal.Parse(String.IsNullOrEmpty(txtPercent.Text) ? "0" : txtPercent.Text),
                            StockExchangeId = stockExchangeId != null ? int.Parse(stockExchangeId.ToString()) : (int?)null,
                            ProjectionRate = Decimal.Parse(gvPopProfileDistribution.DataKeys[i]["ProjectionRate"].ToString()),
                            InvestmentCurrency = investmentCurrency != null ? int.Parse(investmentCurrency.ToString()) : (int?)null,
                            MinPercentAllowed = Decimal.Parse(gvPopProfileDistribution.DataKeys[i]["MinPercentAllowed"].ToString()),
                            MaxPercentAllowed = Decimal.Parse(gvPopProfileDistribution.DataKeys[i]["MaxPercentAllowed"].ToString()),
                            InitialValidDate = gvPopProfileDistribution.DataKeys[i]["InitialValidDate"].ToString().ParseFormat().Value,
                            EndValidDate = gvPopProfileDistribution.DataKeys[i]["EndValidDate"].ToString().ParseFormat().Value,
                            PolicyNo = txtIPPolicy.Text,
                            SerieDesc = txtIPPlanType.Text,
                            ProductDesc = txtIPPlanName.Text,
                            ProfileTypeDesc = txtIPInvestmentProfile.Text,
                            CurrencyDesc = txtIPCurrency.Text,
                            ProfileType = txtIPProfileType.Text,
                        };

                        investProfileList.Add(investProfile);
                    }
                }

                ObjServices.SavePPInvestmentProfile(invtpro, true);
                ObjServices.SavePPPersonalizedProfile(investProfileList);

                Control hdnShowPopPersonalizeInvstProf = null;

                var bodyContent = this.Page.Master.FindControl("bodyContent");

                if (!ObjServices.IsDataReviewMode)
                    hdnShowPopPersonalizeInvstProf = bodyContent.FindControl("PlanPolicyContainer").FindControl("WUCPlanInformation").FindControl("hdnShowPopPersonalizeInvstProf");
                else
                    hdnShowPopPersonalizeInvstProf = bodyContent.FindControl("DReviewContainer").FindControl("PlanPolicyContainer").FindControl("WUCPlanInformation").FindControl("hdnShowPopPersonalizeInvstProf");

                if (!hdnShowPopPersonalizeInvstProf.isNullReferenceControl())
                    (hdnShowPopPersonalizeInvstProf as HiddenField).Value = "false";

                this.ExcecuteJScript("$('#popPersonalizeInvestProf').dialog('close');");
            }
        }
    }
}