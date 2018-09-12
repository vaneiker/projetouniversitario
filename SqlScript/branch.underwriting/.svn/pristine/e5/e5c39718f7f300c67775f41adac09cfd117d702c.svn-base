using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{
    public partial class UCGridView : UC
    {
        public class item
        {
            public string tratamientoEnfermedad { get; set; }
        }

        UCGridViewPopup oUCGridViewPopup;

        public HiddenField Value
        {
            get
            {
                HiddenField txt = null;

                var ListControls = this.Controls;

                foreach (Control ctrl in ListControls)
                {
                    if (ctrl is HiddenField)
                    {
                        txt = ctrl as HiddenField;
                        break;
                    }
                }

                return txt;
            }

        }

        public Questionnaire.Option OptionSelect
        {
            get
            {
                return (Questionnaire.Option)ViewState["DatosGridSelect"];
            }
            set
            {
                ViewState["DatosGridSelect"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            oUCGridViewPopup = this.Page.Master.FindControl("bodyContent").FindControl("UCGridViewPopup") as UCGridViewPopup;
            oUCGridViewPopup.btnSave.Click += btnGuardar_Click;
            oUCGridViewPopup.Refreshbtn.Click += btnGuardar_Click;

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            fillGrid();
        }
        public void fillGrid()
        {
            Questionnaire.GridAnswer i = new Questionnaire.GridAnswer();
            i.CorpId = ObjServices.Corp_Id;
            i.RegionId = ObjServices.Region_Id;
            i.CountryId = ObjServices.Country_Id;
            i.DomesticregId = ObjServices.Domesticreg_Id;
            i.StateProvId = ObjServices.State_Prov_Id;
            i.CityId = ObjServices.City_Id;
            i.OfficeId = ObjServices.Office_Id;
            i.CaseSeqNo = ObjServices.Case_Seq_No;
            i.HistSeqNo = ObjServices.Hist_Seq_No;

            i.ContactId = OptionSelect.ContactId;
            i.ContactRoleTypeId = OptionSelect.ContactRoleTypeId;
            i.QuestionnaireId = OptionSelect.QuestionnaireId;
            if (OptionSelect.QuestionnaireSeq.HasValue)
                i.QuestionnaireSeq = OptionSelect.QuestionnaireSeq.Value;
            else
                i.QuestionnaireSeq = 0;
            i.QuestionnaireId = OptionSelect.QuestionnaireId;

            if (OptionSelect.QuestionId.HasValue)
                i.QuestionId = OptionSelect.QuestionId.Value;
            else
                i.QuestionId = 0;
            if (OptionSelect.OptionId.HasValue)
                i.OptionId = OptionSelect.OptionId.Value;
            else
                i.OptionId = 0;

            Value.Value = "0";
            if (i.OptionId > 0)
            {
                var dt = ObjServices.oHealthDeclarationManager.GetGridAnswer(i);
                if (dt != null)
                {
                    gvTratamientoEnfermedad.DataSource = dt;
                    gvTratamientoEnfermedad.DataBind();
                    Value.Value = dt.Count().ToString();
                }
            }

        }
        public void fillData(Questionnaire.Option Options)
        {
            OptionSelect = Options;
            fillGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            oUCGridViewPopup.OptionSelect = OptionSelect;
            oUCGridViewPopup.filldata();
            var body = this.Page.Master.FindControl("bodyContent");
            var ModalPopupPadecimiento = body.FindControl("ModalPopupPadecimiento");
            (ModalPopupPadecimiento as AjaxControlToolkit.ModalPopupExtender).Show();          
        }

        public void DELETE()
        {
            Questionnaire.GridAnswer i = new Questionnaire.GridAnswer();
            i.CorpId = ObjServices.Corp_Id;
            i.RegionId = ObjServices.Region_Id;
            i.CountryId = ObjServices.Country_Id;
            i.DomesticregId = ObjServices.Domesticreg_Id;
            i.StateProvId = ObjServices.State_Prov_Id;
            i.CityId = ObjServices.City_Id;
            i.OfficeId = ObjServices.Office_Id;
            i.CaseSeqNo = ObjServices.Case_Seq_No;
            i.HistSeqNo = ObjServices.Hist_Seq_No;

            i.ContactId = OptionSelect.ContactId;
            i.ContactRoleTypeId = OptionSelect.ContactRoleTypeId;
            i.QuestionnaireId = OptionSelect.QuestionnaireId;

            i.UserId = ObjServices.UserID.Value;

            if (OptionSelect.QuestionnaireSeq.HasValue)
                i.QuestionnaireSeq = OptionSelect.QuestionnaireSeq.Value;
            else
                i.QuestionnaireSeq = 0;
            i.QuestionnaireId = OptionSelect.QuestionnaireId;

            if (OptionSelect.QuestionId.HasValue)
                i.QuestionId = OptionSelect.QuestionId.Value;
            else
                i.QuestionId = 0;
            if (OptionSelect.OptionId.HasValue)
                i.OptionId = OptionSelect.OptionId.Value;
            else
                i.OptionId = 0;
            if (i.OptionId > 0)
            {
                ObjServices.oHealthDeclarationManager.DeleteGridAnswer(i);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator();
        }

        public void Translator()
        {
            btnAdd.Text = Resources.AddOrEditTreatmentDisease;

        }

        protected void gvTratamientoEnfermedad_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}