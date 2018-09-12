using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using WEB.UnderWriting.Common;
namespace WEB.UnderWriting.Case.UserControls.UnderwritingCall
{
    public partial class UCUnderwritingCall : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        int LanguageId
        {
            get { return string.IsNullOrWhiteSpace(hdnProtocolLanguage.Value) ? 0 : int.Parse(hdnProtocolLanguage.Value); }
            set { hdnProtocolLanguage.Value = value.ToString(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData(int languageId)
        {
            LanguageId = languageId;

            if (languageId == 2)
            {
                btnUCSolicitud.Text = "Solicitud";
                btnUCCorridas.Text = "Corrida";
                btnUCAttachCallOrig.Text = "Adjuntar Llamada y Finalizar";
            }
            else
            {
                btnUCSolicitud.Text = "Application";
                btnUCCorridas.Text = "Illustration";
                btnUCAttachCallOrig.Text = "Attach Call and Finish";
            }


            var pKeyItem = new Tools.PolicyKeyItem()
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                ContactId = Service.Contact_Id,
                UnderwriterId = Service.Underwriter_Id
            };

            hdnPKeyJson.Value = Tools.serializeToJSON(pKeyItem);
            hdnUCStepId.Value = string.Empty;
            hdnUCStepTypeId.Value = string.Empty;
            hdnUCStepCaseNo.Value = string.Empty;
            hdnUCIsClosed.Value = string.Empty;
            ltlUnderwritingCall.Text = string.Empty;
            txtUCComments.Text = string.Empty;
            txtUCComments.Enabled = false;

            var ltFullTemplate = string.Empty;

            var data = Services.PolicyManager.GetUnderwritingCallTemplate(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
                Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, Service.Contact_Id, languageId);

            if (data == null)
                return;
            if (!data.Any())
                return;

            ltFullTemplate = data.Aggregate(ltFullTemplate, (current, item) => current + item.Html);

            ltlUnderwritingCall.Text = ltFullTemplate;
            hdnUCStepId.Value = data.First().StepId.ToString();
            hdnUCStepTypeId.Value = data.First().StepTypeId.ToString();
            hdnUCStepCaseNo.Value = data.First().StepCaseNo.ToString();
            hdnUCIsClosed.Value = data.First().IsClose.ToString();
            txtUCComments.Enabled = true;  
        }

        protected void btnUCAttachCallOrig_Click(object sender, EventArgs e)
        {
            FillData(LanguageId);
            UCAttachCall.FillData();
            hdnShowPopAttachCall.Value = "true";
        }

        protected void btnUCSolicitud_Click(object sender, EventArgs e)
        {
            var docTypeId = (int)Tools.UCSpecialDocuments.Solicitud;

            var docData = Services.RequirementManager.GetSpecialDocument(
                Service.Corp_Id,
                 Service.Region_Id,
                 Service.Country_Id,
                 Service.Domesticreg_Id,
                 Service.State_Prov_Id,
                 Service.City_Id,
                 Service.Office_Id,
                 Service.Case_Seq_No,
                 Service.Hist_Seq_No,
                 docTypeId);

            ShowPDFControl(docData != null ? docData.DocumentBinary : null);
        }

        protected void btnUCCorridas_Click(object sender, EventArgs e)
        {
            var docTypeId = (int)Tools.UCSpecialDocuments.Corrida;

            var docData = Services.RequirementManager.GetSpecialDocument(
                Service.Corp_Id,
                 Service.Region_Id,
                 Service.Country_Id,
                 Service.Domesticreg_Id,
                 Service.State_Prov_Id,
                 Service.City_Id,
                 Service.Office_Id,
                 Service.Case_Seq_No,
                 Service.Hist_Seq_No,
                 docTypeId);

            ShowPDFControl(docData != null ? docData.DocumentBinary : null);
        }

        private void ShowPDFControl(byte[] pdfFile)
        {
            if (pdfFile == null)
            {
                const string message = "This document has no attachment.";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'FILE NOT FOUND');", true);
            }
            else
            {
                var modalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("mpPdfViewer");
                var popUp = ((Common.UCShowPDFPopup)Page.Master.FindControl("UCShowPDFPopup"));

                if (modalPopUp == null || popUp == null) return;
                popUp.LoadPDFPreview(pdfFile);
                modalPopUp.Show();
            }
        }

        public void SendAppointment()
        {
            var date = DateTime.Parse(hdnProtocolNoDate.Value);
            Tools.SendOutlookAppointment(date, date, true, 5, "Underwriting Call Reminder", hdnProtocolNoPhone.Value, "", Service.UnderwriterEmail);
            this.MessageBox("Reminder created successfully.", 500, 150, true, "Underwriting Call Reminder");
        }

        public void SendEmail()
        {
            var date = DateTime.Parse(hdnProtocolNoDate.Value);

            var textInfo = new CultureInfo(LanguageId == 1 ? "en-US" : "es-ES", false).TextInfo;

            var formatedDate = (LanguageId == 1 ?
                textInfo.ToTitleCase(date.ToString("dddd, MMMM dd", CultureInfo.CreateSpecificCulture("en-US"))) + " at " :
                 textInfo.ToTitleCase(date.ToString("dddd dd", CultureInfo.CreateSpecificCulture("es-ES"))) + " de " + textInfo.ToTitleCase(date.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))) + " a las ") + date.ToString("hh:mm tt") + " ET";

            var templates = Service.GetUCTemplateByCategory(Tools.UCTemplates.UCClientEmail, LanguageId);
            var msg = "";

            if (templates.Any())
                msg = templates.First().Html.Replace("{ClientName}", Service.GetOwnerName()).Replace("{DateAndTime}", formatedDate);

            MailManager.SendMessage(hdnProtocolEmail.Value, "", "", msg, Service.FromEmail, "", "", true, Service.SmtpServer, "", "", "");
            this.MessageBox("Appointment created successfully.", 500, 150, true, "Call Appointment");
        }

        public void FillData()
        {
            FillData(LanguageId);
        }
    }
}