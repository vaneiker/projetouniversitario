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
    public partial class WUCRejectedCompliance : UC, IUC
    {
        public delegate void setViewPrincipalHandler(int index, string TitleView);
        public event setViewPrincipalHandler setViewPrincipal;

        public void ClearData(){}
        public void save(){}
        public void edit(){}
        public void ReadOnlyControls(bool isReadOnly){}
        protected void Page_Load(object sender, EventArgs e){

            if (!IsPostBack) {

                gvRejectedByCompliance.SetFilterSettings();
            }
        
        }
        public void Translator(string Lang){}
        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjServices.oDataReviewManager.GetAllRejected(ObjServices.CompanyId,-99); //Al mandarle -99 el SP entiende que debe devolverme el listado de casos rechazados By Compliance
            e.KeyExpression = "CorpId ;RegionId ;CountryId ;DomesticregId ;ProductNameKey;StateProvId ;CityId ;OfficeId ;CaseSeqNo ;HistSeqNo ;InsuredContactId ;AgentId ;CompanyDesc ;PolicyNo ;ProductDesc ;UserName ;InsuredFullName ;CountryDesc ;OfficeDesc ;AgentFullName ;Exception ;SubmitDate ;ChangeDate ;TimeChange ;OwnerContactId ;InsuredAddContactId ;DesignatedPensionerContactId ;StudentContactId ;PaymentId";
            e.QueryableSource = data.AsQueryable();             
        }      

        public void FillData()
        {
            gvRejectedByCompliance.DataBind();
        }

        public void Initialize()
        {
            FillData();
        }      

        protected void SetVariables(int RowIndex)
        {

            ObjServices.Corp_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());         
            ObjServices.Region_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id =  int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
            ObjServices.Office_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
            ObjServices.Owner_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
            ObjServices.Hist_Seq_No = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
            ObjServices.Contact_Id = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
            ObjServices.Policy_Id =  gvRejectedByCompliance.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            ObjServices.Agent_Id =  int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
            ObjServices.DesignatedPensionerContactId = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());
            ObjServices.StudentContactId = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("StudentNameContactId", RowIndex).ToString());
            ObjServices.InsuredAddContactId = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("AddInsuredContactId", RowIndex).ToString());
            ObjServices.PaymentId = int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            ObjServices.KeyNameProduct = gvRejectedByCompliance.GetKeyFromAspxGridView("ProductNameKey", RowIndex,string.Empty).ToString();
            (this.Page as BasePage).setIsFuneral();
            ObjServices.isSavePlan = !string.IsNullOrEmpty(ObjServices.KeyNameProduct);


            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            if (productBehavior.ToInt() == -1)
                productBehavior = Utility.ProductBehavior.None;

            ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
        }

        protected void gvRejectedByCompliance_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
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
                case "regresar":
                    //Primero Validar si el usuario Logueado tiene el Rol permitido para Regresar el caso a Revision de datos.
                    if (Session["RolCompliance"] != null)
                    {
                        if (Session["RolCompliance"].ToString() == "OkReenviar")
                        {
                            ObjServices.oPolicyManager.SetPolicyStatus(new Entity.UnderWriting.Entities.Policy.Parameter()
                            {
                                CorpId = ObjServices.Corp_Id,
                                CountryId = ObjServices.Country_Id,
                                RegionId = ObjServices.Region_Id,
                                DomesticregId = ObjServices.Domesticreg_Id,
                                StateProvId = ObjServices.State_Prov_Id,
                                CityId = ObjServices.City_Id,
                                OfficeId = ObjServices.Office_Id,
                                CaseSeqNo = ObjServices.Case_Seq_No,
                                HistSeqNo = ObjServices.Hist_Seq_No,
                                StatusChangeTypeId = 3,
                                StatusId = 17, //PendingApproval - DATAREVIEW
                                UserId = ObjServices.UserID
                            });

                            //Recargar el grid nuevamente
                            FillData();
                        }
                        else
                        {
                            this.MessageBox("No tiene permisos para ejecutar esta accion", Title: "Advertencia");
                        }
                    }
                    else
                    {
                        this.MessageBox("No tiene permisos para ejecutar esta accion", Title: "Advertencia");
                    }
                    break;
            }


        }
        
        public void ExportarAExcel()
        {  
            var LstRecordChecks = new List<DataReview.Change>();

            for (int i = gvRejectedByCompliance.VisibleStartIndex; i < gvRejectedByCompliance.VisibleRowCount; i++)
            {
                var chk = gvRejectedByCompliance.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var vCompanyDesc = gvRejectedByCompliance.GetKeyFromAspxGridView("CompanyDesc", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("CompanyDesc", i).ToString() : "";
                    var vPolicyNo = gvRejectedByCompliance.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                    var vProductDesc = gvRejectedByCompliance.GetKeyFromAspxGridView("ProductDesc", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                    var vInsuredFullName = gvRejectedByCompliance.GetKeyFromAspxGridView("InsuredFullName", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("InsuredFullName", i).ToString() : "";
                    var vCountryDesc = gvRejectedByCompliance.GetKeyFromAspxGridView("CountryDesc", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("CountryDesc", i).ToString() : "";
                    var vOfficeDesc = gvRejectedByCompliance.GetKeyFromAspxGridView("OfficeDesc", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("OfficeDesc", i).ToString() : "";
                    var vAgentFullName = gvRejectedByCompliance.GetKeyFromAspxGridView("AgentFullName", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                    var vException = gvRejectedByCompliance.GetKeyFromAspxGridView("Exception", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("Exception", i).ToString() : "";
                    var vSubmitDate = gvRejectedByCompliance.GetKeyFromAspxGridView("SubmitDate", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("SubmitDate", i).ToString().ParseFormat() : (DateTime?)null;
                    var vRejectedDate = gvRejectedByCompliance.GetKeyFromAspxGridView("ChangeDate", i) != null ? gvRejectedByCompliance.GetKeyFromAspxGridView("ChangeDate", i).ToString().ParseFormat() : (DateTime?)null;
                    var vDaysPending = gvRejectedByCompliance.GetKeyFromAspxGridView("DaysPending", i) != null ? int.Parse(gvRejectedByCompliance.GetKeyFromAspxGridView("DaysPending", i).ToString()) : (int?)null;
                    var vUserName =  gvRejectedByCompliance.GetKeyFromAspxGridView("UserName", i).ToString();

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
                        ChangeDate = vRejectedDate,
                        UserName = vUserName
                    });
                }
            }
            gvFakeGridView.DataSource = LstRecordChecks;
            gvFakeGridView.DataBind();
            ASPxGridViewExporter1.WriteXlsxToResponse("CasosRechazadosCumplimiento");
        }

        protected void gvRejectedByCompliance_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}