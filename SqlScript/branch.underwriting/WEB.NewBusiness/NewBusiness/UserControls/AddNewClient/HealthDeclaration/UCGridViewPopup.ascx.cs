using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration
{
    public partial class UCGridViewPopup : UC
    {

        [Serializable]
        public class GridData
        {
            public string ID { get; set; }
            public bool Exists { get; set; }
            public string Razon { get; set; }
            public string Motivo { get; set; }
            public string Medico { get; set; }
            public string Institucionn { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string DiseaseDesc { get; set; }
            public int? Disease_Id { get; set; }

            public DateTime Fecha { get; set; }
            public int OptionId { get; set; }
            public int AnswerSeq { get; set; }
            public int QuestionnaireSeq { get; set; }
            public int QuestionnaireLanguageId { get; set; }
        }

        public Button btnSave
        {
            get
            {
                return btnGuardar;
            }
        }
        public Button Refreshbtn
        {
            get
            {
                return bntRefresh;
            }
        }
        public List<GridData> Datos
        {
            get
            {
                if (!(ViewState["DatosGrid"] is List<GridData>))
                {
                    // need to fix the memory and added to GridData
                    ViewState["DatosGrid"] = new List<GridData>();
                }

                return (List<GridData>)ViewState["DatosGrid"];
            }
            set
            {
                ViewState["DatosGrid"] = value;
            }
        }

        public Questionnaire.Option OptionSelect
        {
            get
            {
                if (!(ViewState["OptionSelect"] is Questionnaire.Option))
                {
                    // need to fix the memory and added to GridData
                    ViewState["OptionSelect"] = new Questionnaire.Option();
                }

                return (Questionnaire.Option)ViewState["OptionSelect"];
            }
            set
            {
                ViewState["OptionSelect"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gvPadecimiento.RenderTableHeaderOrTableFooterOnGridView();
        }

        public void GetData()
        {

        }
        public void filldata()
        {
            Datos.Clear();
            clearData();
            hfISEdit.Value = "false";
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
            if (i.OptionId > 0)
            {
                var dt = ObjServices.oHealthDeclarationManager.GetGridAnswer(i);
                if (dt != null)
                {
                    foreach (var item in dt)
                    {
                        GridData d = new GridData();
                        d.Exists = true;
                        d.OptionId = item.OptionId;
                        d.ID = System.Guid.NewGuid().ToString();
                        d.Direccion = item.MedicalCenterAddress;

                        if (item.DateAnswer.HasValue)
                            d.Fecha = item.DateAnswer.Value;

                        d.Disease_Id = item.DiseaseId;
                        d.DiseaseDesc = item.DiseaseDesc;

                        d.Institucionn = item.MedicalCenter;
                        d.Medico = item.MedicalDoctor;
                        d.Motivo = item.ReasonDetail;
                        d.Razon = item.ReasonDesc;
                        d.Telefono = item.MedicalCenterPhone;
                        d.AnswerSeq = item.AnswerSeq.Value;
                        d.QuestionnaireSeq = item.QuestionnaireSeq.Value;
                        d.QuestionnaireLanguageId = item.QuestionnaireLanguageId;
                        Datos.Add(d);
                    }
                }
            }

            Entity.UnderWriting.Entities.DropDown.Parameter valores = new DropDown.Parameter();

            valores.DropDownType = Enum.GetName(typeof(WEB.NewBusiness.Common.Utility.DropDownType), WEB.NewBusiness.Common.Utility.DropDownType.QuestionDisease);

            valores.CorpId = OptionSelect.CorpId;

            valores.QuestionnaireId = OptionSelect.QuestionnaireId;

            valores.QuestionId = OptionSelect.QuestionId;

            ObjServices.GettingAllDrops(ref ddlPadecimiento, valores, "DiseaseDesc", "DiseaseId", false);

            pnPadecimientosTextBox.Visible = false;
            pnPadecimientos.Visible = false;
            if (ddlPadecimiento.Items.Count > 0)
                pnPadecimientos.Visible = true;
            else
                pnPadecimientosTextBox.Visible = true;
            gvPadecimiento.DataSource = Datos;
            gvPadecimiento.DataBind();
            udpPopupGridView.Update();
        }

        public void RefreshGrid()
        {
            gvPadecimiento.DataSource = Datos;
            gvPadecimiento.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            var item = new GridData();
            if (hfISEdit.Value == "false")
            {
                item.Exists = false;
                item.ID = System.Guid.NewGuid().ToString();

                item.Direccion = txtDireccion.Text;
                item.Fecha = txtFecha.Text.ParseFormat().Value;
                item.Institucionn = txtInstitucion.Text;
                item.Medico = txtMedico.Text;
                item.Motivo = txtMotivo.Text;
                item.Razon = txtRazon.Text;
                item.Telefono = txtTelefono.Text;
                if (pnPadecimientos.Visible == true)
                {
                    item.DiseaseDesc = ddlPadecimiento.SelectedItem.Text;
                    item.Disease_Id = Utility.IsIntReturnNull(ddlPadecimiento.SelectedItem.Value);
                }
                else
                {
                    item.DiseaseDesc = txtPadecimiento.Text;
                }
                Datos.Add(item);
            }
            else
            {
                item = Datos.Where(q => q.ID == hfSelect.Value).FirstOrDefault();
                item.Direccion = txtDireccion.Text;
                item.Fecha = txtFecha.Text.ParseFormat().Value;
                item.Institucionn = txtInstitucion.Text;
                item.Medico = txtMedico.Text;
                item.Motivo = txtMotivo.Text;
                item.Razon = txtRazon.Text;
                item.Telefono = txtTelefono.Text;
                if (pnPadecimientos.Visible == true)
                {
                    item.DiseaseDesc = ddlPadecimiento.SelectedItem.Text;
                    item.Disease_Id = Utility.IsIntReturnNull(ddlPadecimiento.SelectedItem.Value);
                }
                else
                {
                    item.DiseaseDesc = txtPadecimiento.Text;
                }
                Datos.Remove(item);
                Datos.Add(item);

            }
            
            btnAgregar.Text = Resources.Add.Capitalize();
            hfISEdit.Value = "false";
            RefreshGrid();
            Utility.ClearAll(this.Controls, gvPadecimiento);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           
                for (int i = 0; i < Datos.Count; i++)
                {
                    Entity.UnderWriting.Entities.Questionnaire.GridAnswer dt = new Questionnaire.GridAnswer();
                    dt.CorpId = OptionSelect.CorpId;
                    dt.RegionId = OptionSelect.RegionId;
                    dt.CountryId = OptionSelect.CountryId;
                    dt.DomesticregId = OptionSelect.DomesticregId;
                    dt.StateProvId = OptionSelect.StateProvId;
                    dt.CityId = OptionSelect.CityId;
                    dt.OfficeId = OptionSelect.OfficeId;
                    dt.CaseSeqNo = OptionSelect.CaseSeqNo;
                    dt.HistSeqNo = OptionSelect.HistSeqNo;
                    dt.ContactId = OptionSelect.ContactId;
                    dt.ContactRoleTypeId = OptionSelect.ContactRoleTypeId;
                    dt.QuestionnaireId = OptionSelect.QuestionnaireId;
                    dt.UserId = ObjServices.UserID.Value;

                    dt.QuestionId = OptionSelect.QuestionId.Value;
                    dt.OptionId = OptionSelect.OptionId.Value;
                    dt.DiseaseDesc = Datos[i].DiseaseDesc;
                    dt.DiseaseId = Datos[i].Disease_Id;

                    dt.MedicalCenterAddress = Datos[i].Direccion;
                    dt.DateAnswer = Datos[i].Fecha;
                    dt.MedicalCenter = Datos[i].Institucionn;
                    dt.MedicalDoctor = Datos[i].Medico;
                    dt.ReasonDetail = Datos[i].Motivo;
                    dt.ReasonDesc = Datos[i].Razon;
                    dt.MedicalCenterPhone = Datos[i].Telefono;
                    dt.QuestionnaireLanguageId = ObjServices.getCurrentLanguage();

                    if (OptionSelect.QuestionnaireSeq.HasValue)
                        dt.QuestionnaireSeq = OptionSelect.QuestionnaireSeq.Value;

                    if (Datos[i].Exists)
                    {
                        dt.AnswerSeq = Datos[i].AnswerSeq;
                        ObjServices.oHealthDeclarationManager.UpdateGridAnswer(dt);
                    }
                    else
                        ObjServices.oHealthDeclarationManager.InsertGridAnswer(dt);
                }

                filldata();
                hfISEdit.Value = "false";

                var jsScript = "(function(){ $('#hdnPopAnswerPadecimiento').val('false'); $('#btnDummy').click(); })();  ";
                this.ExcecuteJScript(jsScript);
                      
        }

        public void clearData()
        {
            ClearControls();
        }

        protected void gvPadecimiento_DataBound(object sender, EventArgs e)
        {
            gvPadecimiento.RenderTableHeaderOrTableFooterOnGridView();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((Button)sender).NamingContainer;


            var t = Datos.Where(q => q.ID == gvPadecimiento.DataKeys[grdrow.RowIndex]["ID"].ToString()).FirstOrDefault();
            if (t != null)
            {
                txtDireccion.Text = t.Direccion;
                txtFecha.Text = t.Fecha.ToShortDateString();
                txtInstitucion.Text = t.Institucionn;
                txtMedico.Text = t.Medico;
                txtMotivo.Text = t.Motivo;
                txtRazon.Text = t.Razon;
                txtTelefono.Text = t.Telefono;
                btnAgregar.Text = "Edit";


                if (pnPadecimientos.Visible == true)
                {
                    ddlPadecimiento.SelectIndexByValue(t.Disease_Id.ToString());
                }
                else
                {
                    txtPadecimiento.Text = t.DiseaseDesc;
                }
                hfISEdit.Value = "true";

                hfSelect.Value = gvPadecimiento.DataKeys[grdrow.RowIndex]["ID"].ToString();
            }


            RefreshGrid();
            this.ExcecuteJScript("$('#bntRefresh').click();");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((Button)sender).NamingContainer;
            if (bool.Parse(gvPadecimiento.DataKeys[grdrow.RowIndex]["Exists"].ToString()))
            {
                Entity.UnderWriting.Entities.Questionnaire.GridAnswer dt = new Questionnaire.GridAnswer();
                dt.CorpId = OptionSelect.CorpId;
                dt.RegionId = OptionSelect.RegionId;
                dt.CountryId = OptionSelect.CountryId;
                dt.DomesticregId = OptionSelect.DomesticregId;
                dt.StateProvId = OptionSelect.StateProvId;
                dt.CityId = OptionSelect.CityId;
                dt.OfficeId = OptionSelect.OfficeId;
                dt.CaseSeqNo = OptionSelect.CaseSeqNo;
                dt.HistSeqNo = OptionSelect.HistSeqNo;
                dt.ContactId = OptionSelect.ContactId;
                dt.ContactRoleTypeId = OptionSelect.ContactRoleTypeId;
                dt.QuestionnaireId = OptionSelect.QuestionnaireId;
                dt.QuestionId = OptionSelect.QuestionId.Value;
                dt.OptionId = OptionSelect.OptionId.Value;
                dt.UserId = ObjServices.UserID.Value;
                dt.QuestionnaireSeq = int.Parse(gvPadecimiento.DataKeys[grdrow.RowIndex]["QuestionnaireSeq"].ToString());
                dt.QuestionnaireLanguageId = int.Parse(gvPadecimiento.DataKeys[grdrow.RowIndex]["QuestionnaireLanguageId"].ToString());
                dt.AnswerSeq = int.Parse(gvPadecimiento.DataKeys[grdrow.RowIndex]["AnswerSeq"].ToString());

                ObjServices.oHealthDeclarationManager.DeleteGridAnswer(dt);
            }
            var t = Datos.Where(q => q.ID == gvPadecimiento.DataKeys[grdrow.RowIndex]["ID"].ToString()).FirstOrDefault();
            if (t != null)
                Datos.Remove(t);

            RefreshGrid();
            this.ExcecuteJScript("$('#bntRefresh').click();");
        }

        protected void bntRefresh_Click(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            Condition.InnerHtml = Resources.Condition;
            Reason.InnerHtml = Resources.REASON.Capitalize();
            Date.InnerHtml = (OptionSelect.QuestionListId == 23 || OptionSelect.QuestionListId == 63) ? Resources.ExamStudyDate : Resources.Date;
            Motive.InnerHtml = (OptionSelect.QuestionListId == 23 || OptionSelect.QuestionListId == 63) ? Resources.Motive : Resources.Treatment;
            Doctor.InnerHtml = Resources.Doctor;
            Institution.InnerHtml = Resources.Institution;
            Phone.InnerHtml = Resources.PhoneNumberLabel;
            StreetAddress.InnerHtml = Resources.StreetAddress;
            btnGuardar.Text = Resources.Save;
            btnAgregar.Text = Resources.Add;
            ltPadecimiento.Text = Resources.ADDCONDITION;                 
        }

        protected void gvPadecimiento_PreRender(object sender, EventArgs e)
        {
            ((GridView)sender).TranslateColumnsGridView();
        }
    }
}