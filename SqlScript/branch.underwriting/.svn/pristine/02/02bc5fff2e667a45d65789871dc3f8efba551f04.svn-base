using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.IO;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies
{
    public partial class WUCUploadReceiptPopup : UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfReceipt.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
            pdfAmendment.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
            if (!IsPostBack)
                mtViewPdf.SetActiveView(vReceipt);
        }

        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }



        public void FillData(String FirstName, String MiddleName, String LastName, String SecondLastName, int RequirementCatId, int RequirementTypeId, int RequirementId, int AmmendmentId, bool? IsAmmendReq)
        {
            txtFirtName.Text = FirstName;
            txtMiddleName.Text = MiddleName;
            txtLastName.Text = LastName;
            txtSecondLastName.Text = SecondLastName;

            ViewState["RequirementCatId"] = RequirementCatId;
            ViewState["RequirementTypeId"] = RequirementTypeId;
            ViewState["RequirementId"] = RequirementId;
            ViewState["AmmendmentId"] = AmmendmentId;

            fuPendingAmedmentFile.Enabled = true;
            chkUploadAmmedment.Enabled = true;
            chkUploadAmmedment.Checked = true;
            txtClienSignatureDateReceipt.Enabled = true;
            fuPendingReceiptFile.Enabled = true;
            chkUploadReceipt.Enabled = true;
            chkUploadReceipt.Checked = true;
            txtClienSignatureDateAmmedment.Enabled = true;

            if (IsAmmendReq.HasValue)
            {
                if (IsAmmendReq.Value)
                {

                    fuPendingReceiptFile.Enabled = false;
                    chkUploadReceipt.Enabled = false;
                    chkUploadReceipt.Checked = false;
                    txtClienSignatureDateReceipt.Enabled = false;

                }
                else  
                {

                    fuPendingAmedmentFile.Enabled = false;
                    chkUploadAmmedment.Enabled = false;
                    chkUploadAmmedment.Checked = false;
                    txtClienSignatureDateAmmedment.Enabled = false;
                }
            }
           

        }

        protected void ManageView(object sender, EventArgs e)
        {
            var Tab = sender as LinkButton;
            switch (Tab.ID)
            {
                case "lnkReceipt":
                    mtViewPdf.SetActiveView(vReceipt);
                    break;
                case "lnkAmendment":
                    mtViewPdf.SetActiveView(vAmendment);
                    break;
            }
        }


        protected void fuPendingReceiptFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            var message = "";
            string pdfPath = string.Empty;

            try
            {
                var file = e.UploadedFile;
                if (file.IsValid)
                {
                    var fileName = WEB.NewBusiness.Common.Utility.GetSerialId() + "~~" + file.FileName;
                    var savePath = TempFilePath + "\\" + fileName;
                    file.SaveAs(savePath);
                    message = savePath;
                }
                else
                {
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
                }
                pdfPath = message;
                Session["pdfPathReceipt"] = message;
            }
            catch (Exception ex)
            {
                pdfPath = message;
                Session["pdfPathReceipt"] = null;
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }

            e.CallbackData = message;
        }



        protected void fuPendingAmedmentFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {

            var message = "";
            string pdfPath = string.Empty;

            try
            {
                var file = e.UploadedFile;
                if (file.IsValid)
                {
                    var fileName = WEB.NewBusiness.Common.Utility.GetSerialId() + "~~" + file.FileName;
                    var savePath = TempFilePath + "\\" + fileName;
                    file.SaveAs(savePath);
                    message = savePath;
                }
                else
                {
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
                }
                pdfPath = message;
                Session["pdfPathAmedment"] = message;
            }
            catch (Exception ex)
            {
                pdfPath = message;
                Session["pdfPathAmedment"] = null;
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }

            e.CallbackData = message;

        }


        protected void btnPendingReceiptPreviewPDF_Click(object sender, EventArgs e)
        {
            var Path = Session["pdfPathReceipt"].ToString();
            if (File.Exists(Path))
            {
                byte[] fileBytes = File.ReadAllBytes(Path);

                this.pdfReceipt.PdfSourceBytes = fileBytes;
                this.pdfReceipt.DataBind();


                mtViewPdf.SetActiveView(vReceipt);

                ModalPopupExtender ext = (ModalPopupExtender)this.Parent.FindControl("ModalPopupExtender2");
                if (ext != null)
                {
                    ext.Show();
                }
            }

        }

        protected void btnPendingAmedmentFilePDF_Click(object sender, EventArgs e)
        {

            var Path = Session["pdfPathAmedment"].ToString();
            if (File.Exists(Path))
            {

                byte[] fileBytes = File.ReadAllBytes(Path);

                this.pdfAmendment.PdfSourceBytes = fileBytes;
                this.pdfAmendment.DataBind();

                mtViewPdf.SetActiveView(vAmendment);

                ModalPopupExtender ext = (ModalPopupExtender)this.Parent.FindControl("ModalPopupExtender2");
                if (ext != null)
                {
                    ext.Show();
                }
            }

        }


        private void clearPdfView() {
            pdfAmendment.PdfSourceBytes = null;
            pdfReceipt.PdfSourceBytes = null;

            pdfAmendment.DataBind();
            pdfReceipt.DataBind();
            txtClienSignatureDateAmmedment.Text = "";
            txtClienSignatureDateReceipt.Text = "";
        
        }

        protected void btnClearPdf_Click(object sender, EventArgs e)
        {

            clearPdfView();

        }

        protected void submitCase_Click(object sender, EventArgs e)
        {

            //Aqui se inserta la informacion de Receipt
          if (chkUploadReceipt.Checked)
          {

          int RequirementCatId =int.Parse(ViewState["RequirementCatId"].ToString()) ;
           int RequirementTypeId = int.Parse(ViewState["RequirementTypeId"].ToString());
          int RequirementId = int.Parse(ViewState["RequirementId"].ToString());
          var ReceiptPath = Session["pdfPathReceipt"] == null ? String.Empty : Session["pdfPathReceipt"].ToString();

          if (ReceiptPath != String.Empty)
          {
                  var ReceiptDocumentName = ReceiptPath.Split(new char[] { '~', '~' }, StringSplitOptions.RemoveEmptyEntries)[1].Replace(".pdf", "");
                  Entity.UnderWriting.Entities.Requirement.Document document = new Entity.UnderWriting.Entities.Requirement.Document();

                  document.CorpId = ObjServices.Corp_Id;
                  document.RegionId = ObjServices.Region_Id;
                  document.CountryId = ObjServices.Country_Id;
                  document.DomesticregId = ObjServices.Domesticreg_Id;
                  document.StateProvId = ObjServices.State_Prov_Id;
                  document.CityId = ObjServices.City_Id;
                  document.OfficeId = ObjServices.Office_Id;
                  document.CaseSeqNo = ObjServices.Case_Seq_No;
                  document.HistSeqNo = ObjServices.Hist_Seq_No;
                  document.ContactId = (int)ObjServices.Contact_Id;
                  document.RequirementCatId = RequirementCatId;
                  document.RequirementTypeId = RequirementTypeId;
                  document.RequirementId = RequirementId;
                  document.DocumentStatusId = 1;
                  document.DocumentBinary = pdfReceipt.PdfSourceBytes;
                  document.DocumentName = ReceiptDocumentName;
                  document.ClientSignatureDate = Convert.ToDateTime(txtClienSignatureDateReceipt.Text);
                  document.UserId = 1;

                  ObjServices.oRequirementManager.InsertDocument(document);

              }
          }

            //Aqui se inserta la informacion de Ammedment

            if (chkUploadAmmedment.Checked)
            {
                int AmmendmentId = int.Parse(ViewState["AmmendmentId"].ToString());
                var AmmedmentPath = Session["pdfPathAmedment"] == null ? String.Empty : Session["pdfPathAmedment"].ToString();

                if (AmmedmentPath != String.Empty)
                {

                    var AmmedmentDocumentName = AmmedmentPath.Split(new char[] { '~', '~' }, StringSplitOptions.RemoveEmptyEntries)[1].Replace(".pdf", "");
                    Entity.UnderWriting.Entities.Ammendment.Detail ammeDet = new Entity.UnderWriting.Entities.Ammendment.Detail();

                    ammeDet.CorpId = ObjServices.Corp_Id;
                    ammeDet.RegionId = ObjServices.Region_Id;
                    ammeDet.CountryId = ObjServices.Country_Id;
                    ammeDet.DomesticregId = ObjServices.Domesticreg_Id;
                    ammeDet.StateProvId = ObjServices.State_Prov_Id;
                    ammeDet.CityId = ObjServices.City_Id;
                    ammeDet.OfficeId = ObjServices.Office_Id;
                    ammeDet.CaseSeqNo = ObjServices.Case_Seq_No;
                    ammeDet.HistSeqNo = ObjServices.Hist_Seq_No;
                    ammeDet.AmmendmentId = AmmendmentId;
                    ammeDet.DocTypeId = 1;
                    ammeDet.DocCategoryId = 44;
                    ammeDet.UserId = 1;
                    ammeDet.DocumentName = AmmedmentDocumentName;
                    ammeDet.DocumentBinary = pdfAmendment.PdfSourceBytes;
                    ammeDet.ClientSignatureDate = Convert.ToDateTime(txtClienSignatureDateAmmedment.Text);
                    ObjServices.oAmmedmentManager.InsertAmmendmentDetail(ammeDet);

                }


            }


            var container = (WUCEffectivePendingReceipt)this.Parent.Parent;
            container.FillData();
            ModalPopupExtender modal = (ModalPopupExtender)container.FindControl("ModalPopupExtender2");
            modal.Hide();
            clearPdfView();
        }


    }
}