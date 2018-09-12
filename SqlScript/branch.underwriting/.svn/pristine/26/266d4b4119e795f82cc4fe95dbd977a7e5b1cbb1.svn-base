using DevExpress.Web;
using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.Common;
using System.Text;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.ReadyToReview
{
    public partial class WUCReadyToReview : UC, IUC
    {
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
            ObjServices.GettingAllDrops(ref ddlBusinessLine,
                                        Utility.DropDownType.ProductType, "BlDesc",
                                        DataValueField: "ProductTypeId",
                                        corpId: ObjServices.Corp_Id,
                                        regionId: ObjServices.Region_Id,
                                        countryId: ObjServices.Country_Id,
                                        domesticregId: ObjServices.Domesticreg_Id,
                                        stateProvId: ObjServices.State_Prov_Id,
                                        cityId: ObjServices.City_Id,
                                        officeId: ObjServices.isUser ? (int?)null : ObjServices.Office_Id,
                                        GenerateItemSelect: true
                                       );

            ObjServices.GettingAllDropsJSON(ref ddlPlan,
                                        Utility.DropDownType.Product,
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

        public void FillData()
        {
            var cases = ObjServices.oCaseManager.GetAllInReview(new Entity.UnderWriting.Entities.Policy.NBParameter
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                AgentId = ObjServices.isUser ? -1 : ObjServices.Agent_LoginId
            });

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
            ObjServices.KeyNameProduct = gvReadyToReview.GetKeyFromAspxGridView("ProductNameKey", RowIndex, string.Empty).ToString();
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

            var TabConfig = ObjServices.getTabConfig();

            var TabsIdNotCompleted = TabConfig.Where(x => !x.IsValid);

            var TabNext = "lnk" + (TabsIdNotCompleted.Any() ? ((Utility.Tab)TabsIdNotCompleted.First().TabId).ToString() : "Payment");

            ObjServices.TabRedirect = TabNext;

            switch (Commando)
            {
                case "View": ObjServices.IsReadyToReview = true; RedirectToAddNewCases(true); break;
                case "Modify": ObjServices.IsReadyToReview = true; RedirectToAddNewCases(false); break;
                case "Comment":
                    {
                        hdnShowPopComment.Value = "true";
                        UCNotesComments.FillData();
                    }
                    break;
                case "Delete":
                    ObjServices.DeletePolicy();
                    FillData(); break;
                case "Reject":
                    {
                        WUCAddComment1.Initialize();
                        hdnShowPopReject.Value = "true";
                    }
                    break;
                case "Payment":
                    hdnPaymentIsCompleted.Value = gvReadyToReview.GetKeyFromAspxGridView("IsPaymentCompleted", RowIndex).ToString();

                    ObjServices.IsReadyToReview = true;
                    ObjServices.TabRedirect = "lnkPayment";
                    RedirectToAddNewCases(false);
                    break;
            }
        }

        public void Initialize()
        {
            FillDrop();
            FillData();
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
            var filteredCases = ObjServices.oCaseManager.GetAllInReview(new Entity.UnderWriting.Entities.Policy.NBParameter
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                AgentId = ObjServices.isUser ? -1 : ObjServices.Agent_LoginId
            })
                .Where(
                        c =>
                        (!string.IsNullOrEmpty(txtPolicy.Text) ? c.PolicyNo.Contains(txtPolicy.Text) : c.PolicyNo == c.PolicyNo) &&
                        (!string.IsNullOrEmpty(FromTxt.Text) && c.LastUpdate.HasValue ? c.LastUpdate.Value.Date >= FromTxt.Text.ParseFormat() : c.LastUpdate.Value.Date == c.LastUpdate.Value.Date) &&
                        (!string.IsNullOrEmpty(ToTxt.Text) && c.LastUpdate.HasValue ? c.LastUpdate.Value.Date <= ToTxt.Text.ParseFormat() : c.LastUpdate.Value.Date == c.LastUpdate.Value.Date) &&
                        ((ddlAgents.SelectedValue != "-1") ? c.AgentFullName == ddlAgents.SelectedItem.Text : c.AgentFullName == c.AgentFullName) &&
                        ((ddlPlan.SelectedValue != "-1") && !string.IsNullOrEmpty(c.ProductDesc) ? c.ProductDesc == ddlPlan.SelectedItem.Text : c.ProductDesc == c.ProductDesc) &&
                        (!string.IsNullOrEmpty(InsuredNameTxt.Text) ? c.InsuranceFullName.ToUpper().Contains(InsuredNameTxt.Text.ToUpper()) : c.InsuranceFullName == c.InsuranceFullName) &&
                        (!string.IsNullOrEmpty(OwnerNameTxt.Text) ? c.OwnerFullName.ToUpper().Contains(OwnerNameTxt.Text.ToUpper()) : c.OwnerFullName == c.OwnerFullName) &&
                        ((ddlBusinessLine.SelectedValue != "-1") ? c.ProductTypeId == ddlBusinessLine.SelectedValue.ToInt() : c.ProductTypeId == c.ProductTypeId)
                     ).ToList();

            gvReadyToReview.DataSource = filteredCases;
            gvReadyToReview.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Initialize();
            ClearData();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");

            if (isChangingLang)
                FillDrop();
        }

        public void Translator(string Lang)
        {
            Search.InnerHtml = Resources.Search;
            PolicyNo.InnerHtml = Resources.PolicyLabel;
            Plan.InnerHtml = Resources.PlanLabel;
            From.InnerHtml = Resources.From;
            To.InnerHtml = Resources.To;
            ReadyToReview.InnerHtml = Resources.ReadyToReviewLabel;
            Agent.InnerHtml = Resources.AgentNameLabel;
            InsuredName.InnerHtml = Resources.InsuredName;
            OwnerName.InnerHtml = Resources.OwnerName;
            SelectionGridMessage.InnerHtml = Resources.SelectionGridMessage;
            btnSearch.Text = Resources.Search.Capitalize();
            btnClear.Text = Resources.Clear;
            btnPrintList.Text = Resources.Export.ToUpper();
            btnSubmitSTL.Text = Resources.SubmitToDataReview.ToUpper();
            ProductType.InnerText = Resources.ProductTypeLabel;
        }

        public void save()
        {

        }

        public void readOnly(bool x)
        {

        }

        public void edit()
        {

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
            var Message = new StringBuilder();

            var CountCases = 0;
            var CountCasesError = 0;

            for (int i = gvReadyToReview.VisibleStartIndex; i < gvReadyToReview.VisibleRowCount; i++)
            {
                var chk = gvReadyToReview.FindRowCellTemplateControl(i, null, "chkSelectedPolicy") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var PolicyNo = gvReadyToReview.GetKeyFromAspxGridView("PolicyNo", i).ToString();

                    var vCorpId = (gvReadyToReview.GetKeyFromAspxGridView("CorpId", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CorpId", i).ToString());
                    var vRegionId = (gvReadyToReview.GetKeyFromAspxGridView("RegionId", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("RegionId", i).ToString());
                    var vCountryId = (gvReadyToReview.GetKeyFromAspxGridView("CountryId", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CountryId", i).ToString());
                    var vDomesticregId = (gvReadyToReview.GetKeyFromAspxGridView("DomesticregId", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("DomesticregId", i).ToString());
                    var vStateProvId = (gvReadyToReview.GetKeyFromAspxGridView("StateProvId", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("StateProvId", i).ToString());
                    var vCityId = (gvReadyToReview.GetKeyFromAspxGridView("CityId", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CityId", i).ToString());
                    var vOfficeId = (gvReadyToReview.GetKeyFromAspxGridView("OfficeId", i) == null) ? -1 :
                                    int.Parse(gvReadyToReview.GetKeyFromAspxGridView("OfficeId", i).ToString());

                    var vCaseSeqNo = (gvReadyToReview.GetKeyFromAspxGridView("CaseSeqNo", i) == null) ? -1 :
                                                       int.Parse(gvReadyToReview.GetKeyFromAspxGridView("CaseSeqNo", i).ToString());
                    var vHistSeqNo = (gvReadyToReview.GetKeyFromAspxGridView("HistSeqNo", i) == null) ? -1 :
                                                                int.Parse(gvReadyToReview.GetKeyFromAspxGridView("HistSeqNo", i).ToString());


                    if (vCaseSeqNo != -1 && vHistSeqNo != -1)
                    {
                        var Result = ObjServices.oCaseManager.SendToStl(new Case()
                        {
                            CorpId = vCorpId,
                            RegionId = vRegionId,
                            CountryId = vCountryId,
                            DomesticregId = vDomesticregId,
                            StateProvId = vStateProvId,
                            CityId = vCityId,
                            OfficeId = vOfficeId,
                            CaseSeqNo = vCaseSeqNo,
                            HistSeqNo = vHistSeqNo,
                            UserId = ObjIllustrationServices.IllusUserID.Value
                        });

                        if (!Result.Result)
                        {
                            CountCasesError++;

                            var item = new Utility.Errors();
                            item.Policy = PolicyNo;
                            var vErrors = Result.ResultMessage.Split(',');
                            /*
                             1-Owner Info Tab no se ha completado
                             2-Plan/Policy Tab no se ha completado
                             3-Beneficiaries Tab no se ha completado
                             4-Requirements Tab no se ha completado
                             5-Health Declaration Tab no se ha completado
                           */

                            for (int x = 0; x < vErrors.Length; x++)
                            {
                                switch (vErrors[x])
                                {
                                    case "Client Info":
                                        vErrors[x] = Resources.ClientInfoLabel;
                                        break;
                                    case "Owner Info":
                                        vErrors[x] = Resources.OwnerInfoLabel;
                                        break;
                                    case "Plan/Policy":
                                        vErrors[x] = Resources.PlanPolicyLabel;
                                        break;
                                    case "Beneficiaries":
                                        vErrors[x] = Resources.BeneficiariesLabel;
                                        break;
                                    case "Requirements":
                                        vErrors[x] = Resources.RequirementsLabel;
                                        break;
                                    case "Health Declaration":
                                        vErrors[x] = Resources.HealthDeclarationLabel;
                                        break;
                                    case "Payment":
                                        vErrors[x] = Resources.PaymentsLabel.Capitalize();
                                        break;
                                }

                                item.MessageErrorList.Add((ObjServices.Language == Utility.Language.en) ? string.Concat((x + 1).ToString(), "-", vErrors[x], " ", RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted)
                                                                                                        : string.Concat((x + 1).ToString(), "-", "El Tab de ", vErrors[x], " ", RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted2));

                            }

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
                    temp.Policy = RESOURCE.UnderWriting.NewBussiness.Resources.ErrorPolicyNumber + " \"" + item.Policy + ":\"" + "<br/>";
                    temp.Errors = string.Join("<br/>", item.MessageErrorList.ToArray());
                    ListMessage.Add(temp);
                }

                Message.Append(CountCasesError.ToString("#,0") + " " + RESOURCE.UnderWriting.NewBussiness.Resources.CasesError);
                Message.Append("<br/>");

                foreach (var item in ListMessage)
                {
                    Message.Append("<br/>");
                    Message.Append(item.Policy);
                    Message.Append("<br/>");
                    Message.Append(item.Errors);
                    Message.Append("<br/>");
                }
                this.MessageBox(Message.ToString(), Width: 500, Height: 350, Title: RESOURCE.UnderWriting.NewBussiness.Resources.ErrorInCase);
            }
            else
            {
                if (CountCases > 0)
                    this.MessageBox(CountCases.ToString("#,0") + " " + RESOURCE.UnderWriting.NewBussiness.Resources.CaseSentDataReview, Title: ObjServices.Language == Utility.Language.en ? "Information" : "Información");
            }

            //Refrescar el listado independientemente de que se envien o no las polizas
            FillData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {

        }

        protected void gvReadyToReview_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}