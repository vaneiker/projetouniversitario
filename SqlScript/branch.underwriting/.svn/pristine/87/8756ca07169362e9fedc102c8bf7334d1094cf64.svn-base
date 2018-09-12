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

namespace WEB.NewBusiness.DReview.UserControl.CasesNotSubmitted.CasesInProcess
{
    public partial class WUCCasesInProcess : UC
    {
        public delegate void setViewPrincipalHandler(int index, string TitleView);
        public event setViewPrincipalHandler setViewPrincipal;

        public void ClearData() { }
        public void Translator(string Lang) { }
        public void save() { }
        public void edit() { }
        protected void Page_Load(object sender, EventArgs e){}

        public void FillData()
        {
            gvCasesInProcess.DataBind();
            gvCasesInProcess.FocusedRowIndex = -1;
        }

        public void Initialize()
        {
            FillData();
        }

        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjServices.oDataReviewManager.GetAllInProcessNB(ObjServices.CompanyId,ObjServices.Agent_LoginId);
            e.KeyExpression = "OwnerContactId;CaseSeqNo; CorpId; RegionId; ProductNameKey; CountryId; DomesticregId;PaymentId;StateProvId; CityId; OfficeId; HistSeqNo; PolicyNo; AgentId; DesignatedPensionerContactId;InsuredContactId;StudentNameContactId;ProductDesc;OwnerFullName;InsuranceFullName;AgentFullName;UserFullName;LastUpdate;AddInsuredContactId";
            e.QueryableSource = data.AsQueryable();
        }

        protected void SetVariables(int RowIndex)
        {
            ObjServices.Corp_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());                 
            ObjServices.Region_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
            ObjServices.Office_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
            ObjServices.Owner_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
            ObjServices.Hist_Seq_No = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
            ObjServices.Contact_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
            ObjServices.Policy_Id = gvCasesInProcess.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            ObjServices.Agent_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
            ObjServices.DesignatedPensionerContactId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());
            ObjServices.StudentContactId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("StudentNameContactId", RowIndex).ToString());
            ObjServices.InsuredAddContactId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("AddInsuredContactId", RowIndex).ToString());
            ObjServices.PaymentId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            ObjServices.KeyNameProduct = gvCasesInProcess.GetKeyFromAspxGridView("ProductNameKey", RowIndex,string.Empty).ToString();
            (this.Page as BasePage).setIsFuneral();
            ObjServices.isSavePlan = !string.IsNullOrEmpty(ObjServices.KeyNameProduct);

            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            if (productBehavior.ToInt() == -1)
                productBehavior = Utility.ProductBehavior.None;

            ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
        }

        protected void gvCasesInProcess_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;
            SetVariables(e.VisibleIndex);
            setViewPrincipal(1, "&nbsp;&nbsp;Viewing the business from cases in process.");
            ObjServices.IsReadyToReview = false;
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            var LstRecordChecks = new List<Case.Process>();

            for (int i = gvCasesInProcess.VisibleStartIndex; i < gvCasesInProcess.VisibleRowCount; i++)
            {
                var chk = gvCasesInProcess.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var vPolicyNo = gvCasesInProcess.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                    var vProductDesc = !gvCasesInProcess.GetKeyFromAspxGridView("ProductDesc", i).isNullReferenceObject() ? gvCasesInProcess.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                    var vOwnerFullName = !gvCasesInProcess.GetKeyFromAspxGridView("OwnerFullName", i).isNullReferenceObject() ? gvCasesInProcess.GetKeyFromAspxGridView("OwnerFullName", i).ToString() : "";
                    var vInsuranceFullName = !gvCasesInProcess.GetKeyFromAspxGridView("InsuranceFullName", i).isNullReferenceObject() ? gvCasesInProcess.GetKeyFromAspxGridView("InsuranceFullName", i).ToString() : "";
                    var vAgentFullName = !gvCasesInProcess.GetKeyFromAspxGridView("AgentFullName", i).isNullReferenceObject() ? gvCasesInProcess.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                    var vUserFullName = !gvCasesInProcess.GetKeyFromAspxGridView("UserFullName", i).isNullReferenceObject() ? gvCasesInProcess.GetKeyFromAspxGridView("UserFullName", i).ToString() : "";
                    var vLastUpdate = !gvCasesInProcess.GetKeyFromAspxGridView("LastUpdate", i).isNullReferenceObject() ? gvCasesInProcess.GetKeyFromAspxGridView("LastUpdate", i).ToString().ParseFormat() : (DateTime?)null;

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
            ASPxGridViewExporter1.WriteXlsxToResponse("CasesInProcess");
        }         

        protected void gvCasesInProcess_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            if (e.CallbackName == "APPLYFILTER")
                gvCasesInProcess.SetFilterSettings();
        }

        protected void gvCasesInProcess_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}