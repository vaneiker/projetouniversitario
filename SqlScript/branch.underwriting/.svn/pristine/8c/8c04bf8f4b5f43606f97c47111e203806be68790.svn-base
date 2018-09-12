using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.Common
{
    public partial class WUCSearch : UC
    {
        public DevExpress.Web.ASPxGridView GridView = null;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            ltTitle.Text = Resources.SubmittedPoliciesOnDataReview.ToUpper();
            Policy.InnerHtml = Resources.PolicyLabel;
            Plan.InnerHtml = Resources.PlanLabel;
            From.InnerHtml = Resources.From;
            To.InnerHtml = Resources.To;
            AgentName.InnerHtml = Resources.AgentNameLabel;
            InsuredName.InnerHtml = Resources.InsuredName;
            OwnerName.InnerHtml = Resources.OwnerName;
            btnClear.Text = Resources.Clear;
            btnSearch.Text = Resources.Search.Capitalize();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");

            (bodyContent.FindControl("WUCEffectivePendingReceipt") as WUCEffectivePendingReceipt).btnSearch += btnSearch_Click;
            (bodyContent.FindControl("WUCSubmittedPolicies") as WUCSubmittedPolicies).btnSearch += btnSearch_Click;

            if (!IsPostBack)
                FillDrop();
        }

        public void CleanControl()
        {
            ClearControls();
        }

        public void FillDrop()
        {
            ObjServices.GettingAllDropsJSON(ref ddlPlan,
                                            WEB.NewBusiness.Common.Utility.DropDownType.Product,
                                            "ProductDesc",
                                            corpId: ObjServices.Corp_Id,
                                            regionId: ObjServices.Region_Id,
                                            countryId: ObjServices.Country_Id,
                                            domesticregId: ObjServices.Domesticreg_Id,
                                            stateProvId: ObjServices.State_Prov_Id,
                                            cityId: ObjServices.City_Id,
                                            officeId: ObjServices.Office_Id,
                                            GenerateItemSelect: true 
                                       );

            ObjServices.GettingAllDrops(ref ddlAgents,
                                    Utility.DropDownType.Agent,
                                    "AgentName", "AgentId",
                                     corpId: ObjServices.Corp_Id,
                                     regionId: ObjServices.Region_Id,
                                     countryId: ObjServices.Country_Id,
                                     domesticregId: ObjServices.Domesticreg_Id,
                                     stateProvId: ObjServices.State_Prov_Id,
                                     cityId: ObjServices.City_Id,
                                     officeId: ObjServices.Office_Id,
                                     GenerateItemSelect: true,
                                     agentId: ObjServices.Agent_Id.Value
                                    );
        }

        public void setControls()
        {

            var bodyContent = this.Page.Master.FindControl("bodyContent");
            var ohdnCurrentTabSubmittedPolicies = bodyContent.FindControl("hdnCurrentTabSubmittedPolicies");

            if (ohdnCurrentTabSubmittedPolicies != null)
            {
                var oTab = (ohdnCurrentTabSubmittedPolicies as HiddenField).Value;

                switch (oTab)
                {
                    case "lnkSubmittedPolicies":
                        GridView = bodyContent.FindControl("WUCSubmittedPolicies").FindControl("gvSubmittedPolcies") as DevExpress.Web.ASPxGridView;
                        break;
                    case "lnkEffectivePendingReceipt":
                        GridView = bodyContent.FindControl("WUCEffectivePendingReceipt").FindControl("gvEffectivePendingReceipt") as DevExpress.Web.ASPxGridView;
                        break;
                }
            }
        }

        public void search(DevExpress.Web.ASPxGridView GridView)
        {
            if (GridView.ID == "gvSubmittedPolcies")
            {
                var ofilteredCases1 = ObjServices.oDataReviewManager.GetAll(new Entity.UnderWriting.Entities.Parameter.Case
                {
                    CompanyId = ObjServices.CompanyId,
                    UserId = ObjServices.Agent_LoginId,
                    LanguageId = ObjServices.Language.ToInt()
                }).Where(
                            c =>
                            (!string.IsNullOrEmpty(txtPolicy.Text) ? c.PolicyNo.Contains(txtPolicy.Text) : c.PolicyNo == c.PolicyNo) &&
                            (!string.IsNullOrEmpty(FromTxt.Text) && c.SubmitDate.HasValue ? c.SubmitDate.Value.Date >= FromTxt.Text.ParseFormat() : c.SubmitDate.Value.Date == c.SubmitDate.Value.Date) &&
                            (!string.IsNullOrEmpty(ToTxt.Text) && c.SubmitDate.HasValue ? c.SubmitDate.Value.Date <= ToTxt.Text.ParseFormat() : c.SubmitDate.Value.Date == c.SubmitDate.Value.Date) &&
                            ((ddlAgents.SelectedValue != "-1") ? c.AgentFullName == ddlAgents.SelectedItem.Text : c.AgentFullName == c.AgentFullName) &&
                            ((ddlPlan.SelectedValue != "-1") && !string.IsNullOrEmpty(c.ProductDesc) ? c.ProductDesc == ddlPlan.SelectedItem.Text : c.ProductDesc == c.ProductDesc) &&
                            (!string.IsNullOrEmpty(InsuredNameTxt.Text) ? c.InsuredFullName.ToUpper().Contains(InsuredNameTxt.Text.ToUpper()) : c.InsuredFullName == c.InsuredFullName) &&
                            (!string.IsNullOrEmpty(OwnerNameTxt.Text) ? c.OwnerFullName.ToUpper().Contains(OwnerNameTxt.Text.ToUpper()) : c.OwnerFullName == c.OwnerFullName)
                            ).ToList();
                GridView.DataSource = ofilteredCases1;
            }
            else if (GridView.ID == "gvEffectivePendingReceipt")
            {
                var ofilteredCases2 = ObjServices.oCaseManager.GetAllEffectivePendingReceipt(new Entity.UnderWriting.Entities.Policy.NBParameter()
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    AgentId = ObjServices.Agent_LoginId
                })
                     .Where(
                             c =>
                             (!string.IsNullOrEmpty(txtPolicy.Text) ? c.PolicyNo.Contains(txtPolicy.Text) : c.PolicyNo == c.PolicyNo) &&
                             (!string.IsNullOrEmpty(FromTxt.Text) && c.EffectiveDate.HasValue ? c.EffectiveDate.Value.Date >= FromTxt.Text.ParseFormat() : c.EffectiveDate == c.EffectiveDate) &&
                             (!string.IsNullOrEmpty(ToTxt.Text) && c.EffectiveDate.HasValue ? c.EffectiveDate.Value.Date <= ToTxt.Text.ParseFormat() : c.EffectiveDate == c.EffectiveDate) &&
                             ((ddlAgents.SelectedValue != "-1") ? c.AgentFullName == ddlAgents.SelectedItem.Text : c.AgentFullName == c.AgentFullName) &&
                             ((ddlPlan.SelectedValue != "-1") && !string.IsNullOrEmpty(c.ProductDesc) ? c.ProductDesc == ddlPlan.SelectedItem.Text : c.ProductDesc == c.ProductDesc) &&
                             (!string.IsNullOrEmpty(InsuredNameTxt.Text) ? c.InsuranceFullName.ToUpper().Contains(InsuredNameTxt.Text.ToUpper()) : c.InsuranceFullName == c.InsuranceFullName) &&
                             (!string.IsNullOrEmpty(OwnerNameTxt.Text) ? c.OwnerFullName.ToUpper().Contains(OwnerNameTxt.Text.ToUpper()) : c.OwnerFullName == c.OwnerFullName)
                             ).ToList();
                GridView.DataSource = ofilteredCases2;
            }

            GridView.DataBind();
        }

        public void search()
        {
            setControls();
            if (!GridView.isNullReferenceControl())
                search(GridView);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Utility.ClearAll(pnSearch.Controls);
            setControls();
            if (GridView != null)
                search(GridView);
        }

    }
}