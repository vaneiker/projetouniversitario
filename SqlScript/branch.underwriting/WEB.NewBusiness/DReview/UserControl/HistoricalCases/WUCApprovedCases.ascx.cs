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
    public partial class WUCApprovedCases : UC, IUC
    {
        public delegate void setViewPrincipalHandler(int index, string TitleView);
        public event setViewPrincipalHandler setViewPrincipal;

        public void ClearData(){}
        public void ReadOnlyControls(bool isReadOnly){}
        public void Translator(string Lang){}
        public void save(){}
        public void edit(){}
        protected void Page_Load(object sender, EventArgs e){
            if (!IsPostBack) {

                gvApprovedCases.SetFilterSettings();
            
            }
        }

        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjServices.oDataReviewManager.GetAllApproved(ObjServices.CompanyId, ObjServices.Agent_LoginId);
            e.KeyExpression = "CorpId ;RegionId ;CountryId ;ProductNameKey;DomesticregId ;StateProvId ;CityId ;OfficeId ;CaseSeqNo ;" +
                              "HistSeqNo ;InsuredContactId;InsuredAddContactId ;AgentId ;CompanyDesc ;PolicyNo ;ProductDesc ;UserName ;" +
                              "InsuredFullName ;CountryDesc ;OfficeDesc ;AgentFullName ;Exception ;SubmitDate ;ChangeDate ;"+
                              "TimeChange ;OwnerContactId ;DesignatedPensionerContactId ;StudentContactId ;PaymentId";
            e.QueryableSource = data.AsQueryable();
        }

        protected void gvApprovedCases_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Comando = e.CommandArgs.CommandName;
            SetVariables(e.VisibleIndex);

            switch (Comando)
            {
                case "view":
                    setViewPrincipal(1, "&nbsp;&nbsp;Viewing the business from approved cases.");
                    ObjServices.IsReadyToReview = true;
                    break;
                case "comment":
                    UCNotesComments.AllowAddComment = false;
                    UCNotesComments.FillData();
                    hdnShowAddNewNoteApprovedCases.Value = "true";
                    break;
            }
        }

        protected void SetVariables(int RowIndex)
        {
            ObjServices.Corp_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());        
            ObjServices.Region_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());  
            ObjServices.Country_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());  
            ObjServices.Domesticreg_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("CityId", RowIndex).ToString()); 
            ObjServices.Office_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString()); 
            ObjServices.Owner_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString()); 
            ObjServices.Hist_Seq_No = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString()); 
            ObjServices.Contact_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
            ObjServices.Policy_Id = gvApprovedCases.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();  
            ObjServices.Agent_Id = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("AgentId", RowIndex).ToString()); 
            ObjServices.DesignatedPensionerContactId = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());  
            ObjServices.StudentContactId = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("StudentContactId", RowIndex).ToString());   
            ObjServices.InsuredAddContactId = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("InsuredAddContactId", RowIndex).ToString()); 
            ObjServices.PaymentId = int.Parse(gvApprovedCases.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            ObjServices.KeyNameProduct = gvApprovedCases.GetKeyFromAspxGridView("ProductNameKey", RowIndex,string.Empty).ToString();
            (this.Page as BasePage).setIsFuneral();
            ObjServices.isSavePlan = !string.IsNullOrEmpty(ObjServices.KeyNameProduct);


            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            if (productBehavior.ToInt() == -1)
                productBehavior = Utility.ProductBehavior.None;

            ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
        }
        
        public void FillData()
        {
            gvApprovedCases.DataBind();
        }

        public void Initialize()
        {
            FillData();
        }        

        public void ExportarAExcel()
        {
            var LstRecordChecks = new List<DataReview.Change>();

            for (int i = gvApprovedCases.VisibleStartIndex; i < gvApprovedCases.VisibleRowCount; i++)
            {
                var chk = gvApprovedCases.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var vCompanyDesc = gvApprovedCases.GetKeyFromAspxGridView("CompanyDesc", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("CompanyDesc", i).ToString() : "";
                    var vPolicyNo = gvApprovedCases.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                    var vProductDesc = gvApprovedCases.GetKeyFromAspxGridView("ProductDesc", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                    var vInsuredFullName = gvApprovedCases.GetKeyFromAspxGridView("InsuredFullName", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("InsuredFullName", i).ToString() : "";
                    var vCountryDesc = gvApprovedCases.GetKeyFromAspxGridView("CountryDesc", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("CountryDesc", i).ToString() : "";
                    var vOfficeDesc = gvApprovedCases.GetKeyFromAspxGridView("OfficeDesc", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("OfficeDesc", i).ToString() : "";
                    var vAgentFullName = gvApprovedCases.GetKeyFromAspxGridView("AgentFullName", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                    var vException = gvApprovedCases.GetKeyFromAspxGridView("Exception", i) != null ? gvApprovedCases.GetKeyFromAspxGridView("Exception", i).ToString() : "";
                    var vSubmitDate = gvApprovedCases.GetKeyFromAspxGridView("SubmitDate", i) != null ? DateTime.Parse(gvApprovedCases.GetKeyFromAspxGridView("SubmitDate", i).ToString()) : (DateTime?)null;
                    var vApprovedDate = gvApprovedCases.GetKeyFromAspxGridView("ChangeDate", i) != null ? DateTime.Parse(gvApprovedCases.GetKeyFromAspxGridView("ChangeDate", i).ToString()) : (DateTime?)null;                    
                    var vUserName = gvApprovedCases.GetKeyFromAspxGridView("UserName", i).ToString();

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
                        ChangeDate = vApprovedDate.Value,
                        UserName = vUserName
                    });
                }
            }

            var records = LstRecordChecks.Select(x => new
            {
                x.CompanyDesc,
                x.PolicyNo,
                x.ProductDesc,
                x.InsuredFullName,
                x.CountryDesc,
                x.OfficeDesc,
                x.AgentFullName,
                x.Exception ,
                SubmitDate = String.Format("{0:MM/dd/yyyy}", x.SubmitDate),
                ChangeDate = String.Format("{0:MM/dd/yyyy}", x.ChangeDate),
                x.UserName 
            });

            gvFakeGridView.DataSource = records;
            gvFakeGridView.DataBind();
            ASPxGridViewExporter2.WriteXlsxToResponse("ApprovedCases");
        }

        protected void gvApprovedCases_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}