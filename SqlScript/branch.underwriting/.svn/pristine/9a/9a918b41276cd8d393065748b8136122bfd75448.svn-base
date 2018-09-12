using DevExpress.Web;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.DReview.UserControl.CasesNotSubmitted.ReadyToreview
{
    public partial class WUCReadyToReview : UC
    {
        public delegate void setViewPrincipalHandler(int index, string TitleView);
        public event setViewPrincipalHandler setViewPrincipal;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            Search.InnerHtml = Resources.Search;
            Policy.InnerHtml = Resources.PolicyLabel;
            Plan.InnerHtml = Resources.PlanLabel;
            From.InnerHtml = Resources.From;
            To.InnerHtml = Resources.To;
            ReadyToReview.InnerHtml = Resources.ReadyToReviewLabel;
            AgentName.InnerHtml = Resources.AgentNameLabel;
            InsuredName.InnerHtml = Resources.InsuredName;
            OwnerName.InnerHtml = Resources.OwnerName;
            btnClear.Text = Resources.Clear;
            btnSearch.Text = Resources.Search.Capitalize();
        }

        public void save() { }
        public void readOnly(bool x) { }
        public void edit() { }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initialize();
                gvReadyToReview.SetFilterSettings();
            }
        }

        private void FillDrop()
        {

            var dataDrops = ObjServices.oDataReviewManager.GetAllInReviewNB(ObjServices.CompanyId, ObjServices.Agent_LoginId);
            
            //Llenar el dropDrown del Plan
            ddlPlan.DataSource = dataDrops.Select(x => new{x.ProductDesc,x.ProductId}).Distinct();
            ddlPlan.DataTextField = "ProductDesc";
            ddlPlan.DataValueField = "ProductId";
            ddlPlan.DataBind();
            ddlPlan.Items.Insert(0, new ListItem { Text = "-----",Value="-1"});

            //Llenar el dropdown de los agentes
            ddlAgents.DataSource = dataDrops.Select(x => new { x.AgentFullName, x.AgentId }).Distinct();
            ddlAgents.DataTextField = "AgentFullName";
            ddlAgents.DataValueField = "AgentId";
            ddlAgents.DataBind();
            ddlAgents.Items.Insert(0, new ListItem { Text = "-----", Value = "-1" });      
        }

        public void FillData()
        {
            var cases = ObjServices.oDataReviewManager.GetAllInReviewNB(ObjServices.CompanyId, ObjServices.Agent_LoginId);
            gvReadyToReview.DataSource = cases;
            gvReadyToReview.DataBind();
        }

        private void RejectCase()
        {
            ObjServices.oCaseManager.SendToReject(ObjServices.GetCurrentCase());
            FillData();
        }

        protected void RedirectToAddNewCases(bool isReadOnly)
        {
            var oContact = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Client);

            ObjServices.Relationship_With_Insured_Id = oContact.RelationshiptoAgent;

            ObjServices.isNewCase = false;
            ObjServices.IsReadOnly = isReadOnly;
            Response.Redirect("~/NewBusiness/Pages/AddNewClient.aspx");

        }

        protected void SetVariables(int RowIndex)
        {
            ObjServices.Corp_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());             
            ObjServices.Region_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
            ObjServices.Office_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
            ObjServices.Owner_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
            ObjServices.Hist_Seq_No = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
            ObjServices.Contact_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
            ObjServices.Policy_Id = gvReadyToReview.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            ObjServices.Agent_Id = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
            ObjServices.DesignatedPensionerContactId = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());
            ObjServices.StudentContactId = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("StudentNameContactId", RowIndex).ToString());
            ObjServices.InsuredAddContactId = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("AddInsuredContactId", RowIndex).ToString());
            ObjServices.PaymentId = int.Parse(gvReadyToReview.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            ObjServices.KeyNameProduct = gvReadyToReview.GetKeyFromAspxGridView("ProductNameKey", RowIndex,string.Empty).ToString();
            (this.Page as BasePage).setIsFuneral();
            ObjServices.isSavePlan = !string.IsNullOrEmpty(ObjServices.KeyNameProduct);       

            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            if (productBehavior.ToInt() == -1)
                productBehavior = Utility.ProductBehavior.None;

            ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
        }

        protected void gvReadyToReview_RowCommand1(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            var RowIndex = e.VisibleIndex;

            SetVariables(RowIndex);

            ObjServices.TabRedirect = "lnkClientInfo";

            switch (Commando)
            {
                case "View":
                    setViewPrincipal(1, "&nbsp;&nbsp;Viewing the business from ready to review.");
                    ObjServices.IsReadyToReview = true;
                    break;
                case "Comment":
                    {
                        hdnShowPopComment.Value = "true|ReadOnly";
                        UCNotesComments.FillData();
                    }
                    break;
            }
        }

        public void Initialize()
        {
            FillData();
            FillDrop();
            udpReadyToReview.Update();
        }

        public void ClearData()
        {
            Utility.ClearAll(this.Controls, gvReadyToReview);
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            var LstRecordChecks = new List<Case.Process>();

            for (int i = gvReadyToReview.VisibleStartIndex; i < gvReadyToReview.VisibleRowCount; i++)
            {
                var chk = gvReadyToReview.FindRowCellTemplateControl(i, null, "chkSelectedPolicy") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var vPolicyNo = gvReadyToReview.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                    var vProductDesc = gvReadyToReview.GetKeyFromAspxGridView("ProductDesc", i) != null ? gvReadyToReview.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                    var vOwnerFullName = gvReadyToReview.GetKeyFromAspxGridView("OwnerFullName", i) != null ? gvReadyToReview.GetKeyFromAspxGridView("OwnerFullName", i).ToString() : "";
                    var vInsuranceFullName = gvReadyToReview.GetKeyFromAspxGridView("InsuranceFullName", i) != null ? gvReadyToReview.GetKeyFromAspxGridView("InsuranceFullName", i).ToString() : "";
                    var vAgentFullName = gvReadyToReview.GetKeyFromAspxGridView("AgentFullName", i) != null ? gvReadyToReview.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                    var vUserFullName = gvReadyToReview.GetKeyFromAspxGridView("UserFullName", i) != null ? gvReadyToReview.GetKeyFromAspxGridView("UserFullName", i).ToString() : "";
                    var vLastUpdate = gvReadyToReview.GetKeyFromAspxGridView("LastUpdate", i) != null ? gvReadyToReview.GetKeyFromAspxGridView("LastUpdate", i).ToString().ParseFormat()
                        : (DateTime?)null;

                    LstRecordChecks.Add(new Case.Process()
                    {
                        PolicyNo = vPolicyNo,
                        ProductDesc = vProductDesc,
                        OwnerFullName = vOwnerFullName,
                        InsuranceFullName = vInsuranceFullName,
                        AgentFullName = vAgentFullName,
                        UserFullName = vUserFullName,
                        LastUpdate = vLastUpdate
                    });
                }
            }
            gvFakeGridView.DataSource = LstRecordChecks;
            gvFakeGridView.DataBind();
            ASPxGridViewExporter1.WriteXlsxToResponse("ReadyToReview");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var filteredCases = ObjServices.oDataReviewManager.GetAllInReviewNB(ObjServices.CompanyId, ObjServices.Agent_LoginId)
                .Where(
                        c =>
                        (!string.IsNullOrEmpty(txtPolicy.Text) ? c.PolicyNo.Contains(txtPolicy.Text) : c.PolicyNo == c.PolicyNo) &&
                        (!string.IsNullOrEmpty(FromTxt.Text) && c.LastUpdate.HasValue ? c.LastUpdate.Value.Date >= FromTxt.Text.ParseFormat() : c.LastUpdate.Value.Date == c.LastUpdate.Value.Date) &&
                        (!string.IsNullOrEmpty(ToTxt.Text) && c.LastUpdate.HasValue ? c.LastUpdate.Value.Date <= ToTxt.Text.ParseFormat() : c.LastUpdate.Value.Date == c.LastUpdate.Value.Date) &&
                        ((ddlAgents.SelectedValue != "-1") ? c.AgentFullName == ddlAgents.SelectedItem.Text : c.AgentFullName == c.AgentFullName) &&
                        ((ddlPlan.SelectedValue != "-1") && !string.IsNullOrEmpty(c.ProductDesc) ? c.ProductDesc == ddlPlan.SelectedItem.Text : c.ProductDesc == c.ProductDesc) &&
                        (!string.IsNullOrEmpty(InsuredNameTxt.Text) ? c.InsuranceFullName.ToUpper().Contains(InsuredNameTxt.Text.ToUpper()) : c.InsuranceFullName == c.InsuranceFullName) &&
                        (!string.IsNullOrEmpty(OwnerNameTxt.Text) ? c.OwnerFullName.ToUpper().Contains(OwnerNameTxt.Text.ToUpper()) : c.OwnerFullName == c.OwnerFullName)
                     ).ToList();

            gvReadyToReview.DataSource = filteredCases;
            gvReadyToReview.DataBind();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Initialize();
            ClearData();
        }

        protected void gvReadyToReview_PageSizeChanged(object sender, EventArgs e)
        {
            FillData();
        }

        protected void gvReadyToReview_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        protected void gvReadyToReview_BeforeColumnSortingGrouping(object sender, ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            btnSearch_Click(btnSearch, null);
        }

        protected void btnSubmitSTL_Click(object sender, EventArgs e)
        {
            var ListError = new List<Utility.Errors>();
            var ListMessage = new List<Utility.ListTabError>();

            var CountCases = 0;
            var CountCasesError = 0;

            for (int i = gvReadyToReview.VisibleStartIndex; i < gvReadyToReview.VisibleRowCount; i++)
            {
                var chk = gvReadyToReview.FindRowCellTemplateControl(i, null, "chkSelectedPolicy") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var PolicyNo = gvReadyToReview.GetKeyFromAspxGridView("PolicyNo", i).ToString();

                    var vCaseSeqNo = (gvReadyToReview.GetKeyFromAspxGridView("CaseSeqNo", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CaseSeqNo", i).ToString());
                    var vHistSeqNo = (gvReadyToReview.GetKeyFromAspxGridView("HistSeqNo", i) == null) ? -1 :
                                                                int.Parse(gvReadyToReview.GetKeyFromAspxGridView("HistSeqNo", i).ToString());

                    if (vCaseSeqNo != -1 && vHistSeqNo != -1)
                    {
                        var Result = ObjServices.oCaseManager.SendToStl(new Case()
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            DomesticregId = ObjServices.Domesticreg_Id,
                            StateProvId = ObjServices.State_Prov_Id,
                            CityId = ObjServices.City_Id,
                            OfficeId = ObjServices.Office_Id,
                            CaseSeqNo = vCaseSeqNo,
                            HistSeqNo = vHistSeqNo,
                            UserId = ObjServices.UserID.Value
                        });

                        if (!Result.Result)
                        {
                            CountCasesError++;

                            var item = new Utility.Errors();
                            item.Policy = PolicyNo;
                            var vErrors = Result.ResultMessage.Split(',');
                            for (int x = 0; x < vErrors.Length; x++)
                                item.MessageErrorList.Add((x + 1).ToString() + "-" + vErrors[x] + " Tab is not completed ");

                            ListError.Add(item);
                        }
                        else
                            CountCases++;
                    }
                }
            }

            if (ListError.Any())
            {
                foreach (var item in ListError)
                {
                    var temp = new Utility.ListTabError();
                    temp.Policy = "Errors in policy number \"" + item.Policy + ":\"" + "<br/>";
                    temp.Errors = string.Join("<br/>", item.MessageErrorList.ToArray());
                    ListMessage.Add(temp);
                }

                var Message = new StringBuilder();

                Message.Append(CountCasesError.ToString("#,0") + " cases with error");
                Message.Append("<br/>");

                foreach (var item in ListMessage)
                {
                    Message.Append("<br/>");
                    Message.Append(item.Policy);
                    Message.Append("<br/>");
                    Message.Append(item.Errors);
                    Message.Append("<br/>");
                }
                this.MessageBox(Message.ToString(), Width: 500, Height: 350, Title: "Errors in case");
            }
            else
            {
                FillData();

                if (CountCases > 0)
                    this.MessageBox(CountCases.ToString("#,0") + " cases have been sent to the tail Ready to Review", Title: "Information");
            }
        }

        protected void gvReadyToReview_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}