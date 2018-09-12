using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCPopPerzonalizedProfile : WEB.UnderWriting.Common.UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FillData(IEnumerable<Entity.UnderWriting.Entities.Policy.InvestProfilePersonalized> data)
        {
            //Personalized Profile Data
            txtIPPolicy.Text = "";
            txtIPPlanName.Text = "";
            txtIPInvestmentProfile.Text = "";
            txtIPCurrency.Text = "";
            txtIPPlanType.Text = "";
            txtIPProfileType.Text = "";
            txtPPTotalPercent.Text = "0%";

            //FillGrid
            gvPopProfileDistribution.DataSource = data;
            gvPopProfileDistribution.DataBind();

            //Personalized Profile Data
            if (!data.Any()) return;
            var dataFirst = data.First();

            txtIPPolicy.Text = dataFirst.PolicyNo;
            txtIPPlanName.Text = dataFirst.ProductDesc;
            txtIPInvestmentProfile.Text = dataFirst.ProfileTypeDesc;
            txtIPCurrency.Text = dataFirst.CurrencyDesc;
            txtIPPlanType.Text = dataFirst.SerieDesc;
            txtIPProfileType.Text = dataFirst.ProfileType;
            hdnPIPProfTypeId.Value = dataFirst.ProfileTypeId.ToString();
            txtPPTotalPercent.Text = data.Sum(r => r.InvstProfilePercent ?? 0).ToString("N2") + "%";
        }

        protected void btPerPronCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btPerPronSave_Click(object sender, EventArgs e)
        {
            //Profile Item List
            var investProfileList = new List<Entity.UnderWriting.Entities.Policy.InvestProfilePersonalized>();
            bool isUpdate;
            DateTime dateNow;

            if (gvPopProfileDistribution.Rows.Count > 0)
            {
                dateNow = DateTime.Now;
                isUpdate = true;

                var investDate = gvPopProfileDistribution.DataKeys[1]["InvstProductDate"];
                DateTime investDateValue = investDate == null ? dateNow : DateTime.Parse(investDate.ToString());
                var investProductDateIdNull = gvPopProfileDistribution.DataKeys[1]["InvestProductDateId"];
                int investProductDateId = investProductDateIdNull != null ? int.Parse(investProductDateIdNull.ToString()) : int.Parse(investDateValue.ToString("yyyyMMdd"));

                if (investProductDateIdNull == null)
                    isUpdate = false;

                if (investProductDateIdNull != null && investProductDateId.ToString() != dateNow.ToString("yyyyMMdd"))
                {
                    investProductDateId = int.Parse(dateNow.ToString("yyyyMMdd"));
                    investDateValue = dateNow;
                    isUpdate = false;
                }

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

                    //Profile Item
                    var investProfile = new Entity.UnderWriting.Entities.Policy.InvestProfilePersonalized
                    {
                        //Profile Data
                        InvestProductDateId = investProductDateId,
                        ProfileTypeId = int.Parse(hdnPIPProfTypeId.Value),
                        SymbolId = int.Parse(gvPopProfileDistribution.DataKeys[i]["SymbolId"].ToString()),
                        InvstProductDate = investDateValue,
                        InvestmentProfileDate = DateTime.Parse(gvPopProfileDistribution.DataKeys[i]["InvestmentProfileDate"].ToString()),
                        InvstProfilePercent = Decimal.Parse(String.IsNullOrEmpty(txtPercent.Text) ? "0" : txtPercent.Text),
                        StockExchangeId = stockExchangeId != null ? int.Parse(stockExchangeId.ToString()) : (int?)null,
                        ProjectionRate = Decimal.Parse(gvPopProfileDistribution.DataKeys[i]["ProjectionRate"].ToString()),
                        InvestmentCurrency = investmentCurrency != null ? int.Parse(investmentCurrency.ToString()) : (int?)null,
                        MinPercentAllowed = Decimal.Parse(gvPopProfileDistribution.DataKeys[i]["MinPercentAllowed"].ToString()),
                        MaxPercentAllowed = Decimal.Parse(gvPopProfileDistribution.DataKeys[i]["MaxPercentAllowed"].ToString()),
                        InitialValidDate = DateTime.Parse(gvPopProfileDistribution.DataKeys[i]["InitialValidDate"].ToString()),
                        EndValidDate = DateTime.Parse(gvPopProfileDistribution.DataKeys[i]["EndValidDate"].ToString()),
                        PolicyNo = txtIPPolicy.Text,
                        SerieDesc = txtIPPlanType.Text,
                        ProductDesc = txtIPPlanName.Text,
                        ProfileTypeDesc = txtIPInvestmentProfile.Text,
                        CurrencyDesc = txtIPCurrency.Text,
                        ProfileType = txtIPProfileType.Text,
                    };

                    investProfileList.Add(investProfile);
                }

                Service.SavePPInvestmentProfile(invtpro, isUpdate);
                Service.SavePPPersonalizedProfile(investProfileList);

                this.ExcecuteJScript("CloseJqueryPops('#dvPopCustomProfile');");

            }
        }
    }
}