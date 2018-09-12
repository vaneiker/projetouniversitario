using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.DReview.UserControl.HistoricalCases
{
    public partial class WUCRejectedCases : UC, IUC
    {
        public delegate void setViewPrincipalHandler(int index, string TitleView);
        public event setViewPrincipalHandler setViewPrincipal;

        public void ClearData(){}
        public void save(){}
        public void edit(){}
        public void ReadOnlyControls(bool isReadOnly){}
        protected void Page_Load(object sender, EventArgs e){

            if (!IsPostBack) {

                gvRejectedCases.SetFilterSettings();
            }
        
        }
        public void Translator(string Lang){}
        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjServices.oDataReviewManager.GetAllRejected(ObjServices.CompanyId, ObjServices.Agent_LoginId);
            e.KeyExpression = "CorpId ;RegionId ;CountryId ;DomesticregId ;ProductNameKey;StateProvId ;CityId ;OfficeId ;CaseSeqNo ;HistSeqNo ;InsuredContactId ;AgentId ;CompanyDesc ;PolicyNo ;ProductDesc ;UserName ;InsuredFullName ;CountryDesc ;OfficeDesc ;AgentFullName ;Exception ;SubmitDate ;ChangeDate ;TimeChange ;OwnerContactId ;InsuredAddContactId ;DesignatedPensionerContactId ;StudentContactId ;PaymentId";
            e.QueryableSource = data.AsQueryable();             
        }      

        public void FillData()
        {
            gvRejectedCases.DataBind();
        }

        public void Initialize()
        {
            FillData();
        }      

        protected void SetVariables(int RowIndex)
        {

            ObjServices.Corp_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());         
            ObjServices.Region_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id =  int.Parse(gvRejectedCases.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
            ObjServices.Office_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
            ObjServices.Owner_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
            ObjServices.Hist_Seq_No = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
            ObjServices.Contact_Id = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
            ObjServices.Policy_Id =  gvRejectedCases.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            ObjServices.Agent_Id =  int.Parse(gvRejectedCases.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
            ObjServices.DesignatedPensionerContactId = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());
            ObjServices.StudentContactId = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("StudentNameContactId", RowIndex).ToString());
            ObjServices.InsuredAddContactId = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("AddInsuredContactId", RowIndex).ToString());
            ObjServices.PaymentId = int.Parse(gvRejectedCases.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            ObjServices.KeyNameProduct = gvRejectedCases.GetKeyFromAspxGridView("ProductNameKey", RowIndex,string.Empty).ToString();
            (this.Page as BasePage).setIsFuneral();
            ObjServices.isSavePlan = !string.IsNullOrEmpty(ObjServices.KeyNameProduct);


            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            if (productBehavior.ToInt() == -1)
                productBehavior = Utility.ProductBehavior.None;

            ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
        }

        protected void gvRejectedCases_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Comando = e.CommandArgs.CommandName;
            SetVariables(e.VisibleIndex);

            switch (Comando)
            {
                case "view":
                    setViewPrincipal(1, "&nbsp;&nbsp;Viewing the business from rejected cases.");
                    ObjServices.IsReadyToReview = true;
                    break;
                case "comment":
                    UCNotesComments.AllowAddComment = false;
                    UCNotesComments.FillData();
                    hdnShowAddNewNoteRejectedCases.Value = "true";
                    break;
            }

        }
        
        public void ExportarAExcel()
        {  
            var LstRecordChecks = new List<DataReview.Change>();

            for (int i = gvRejectedCases.VisibleStartIndex; i < gvRejectedCases.VisibleRowCount; i++)
            {
                var chk = gvRejectedCases.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var vCompanyDesc = gvRejectedCases.GetKeyFromAspxGridView("CompanyDesc", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("CompanyDesc", i).ToString() : "";
                    var vPolicyNo = gvRejectedCases.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                    var vProductDesc = gvRejectedCases.GetKeyFromAspxGridView("ProductDesc", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                    var vInsuredFullName = gvRejectedCases.GetKeyFromAspxGridView("InsuredFullName", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("InsuredFullName", i).ToString() : "";
                    var vCountryDesc = gvRejectedCases.GetKeyFromAspxGridView("CountryDesc", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("CountryDesc", i).ToString() : "";
                    var vOfficeDesc = gvRejectedCases.GetKeyFromAspxGridView("OfficeDesc", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("OfficeDesc", i).ToString() : "";
                    var vAgentFullName = gvRejectedCases.GetKeyFromAspxGridView("AgentFullName", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                    var vException = gvRejectedCases.GetKeyFromAspxGridView("Exception", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("Exception", i).ToString() : "";
                    var vSubmitDate = gvRejectedCases.GetKeyFromAspxGridView("SubmitDate", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("SubmitDate", i).ToString().ParseFormat() : (DateTime?)null;
                    var vRejectedDate = gvRejectedCases.GetKeyFromAspxGridView("ChangeDate", i) != null ? gvRejectedCases.GetKeyFromAspxGridView("ChangeDate", i).ToString().ParseFormat() : (DateTime?)null;
                    var vDaysPending = gvRejectedCases.GetKeyFromAspxGridView("DaysPending", i) != null ? int.Parse(gvRejectedCases.GetKeyFromAspxGridView("DaysPending", i).ToString()) : (int?)null;
                    var vUserName =  gvRejectedCases.GetKeyFromAspxGridView("UserName", i).ToString();

                    LstRecordChecks.Add(new DataReview.Change
                    {
                        CompanyDesc = vCompanyDesc,
                        PolicyNo = vPolicyNo,
                        ProductDesc = vProductDesc,
                        InsuredFullName = vInsuredFullName,
                        CountryDesc = vCountryDesc,
                        OfficeDesc = vOfficeDesc,
                        AgentFullName = vAgentFullName,
                        Exception = vException,
                        SubmitDate = vSubmitDate,
                        ChangeDate = vRejectedDate, //Bmarroquin para que no truene al realizar un vRejectedDate.Value
                        UserName = vUserName
                    });
                }
            }
            gvFakeGridView.DataSource = LstRecordChecks;
            gvFakeGridView.DataBind();
            ASPxGridViewExporter1.WriteXlsxToResponse("RejectedCases");
        }

        protected void gvRejectedCases_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}