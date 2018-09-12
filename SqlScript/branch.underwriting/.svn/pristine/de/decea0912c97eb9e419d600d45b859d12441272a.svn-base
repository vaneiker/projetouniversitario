using AjaxControlToolkit;
using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using iTextSharp.text.pdf;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using WEB.NewBusiness.NewBusiness.UserControls.Requirements;

namespace WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle
{
    public partial class UCRequirementPdfPopUp : UC
    {
        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }

        private int RequiredFileSize
        {
            get
            {
                return ConfigurationManager.AppSettings["RequiredFileSize"].ToInt();
            }
        }


        public void SetTitle(string title)
        {
            uploadDocument.InnerText = title;
        }

        public void clearData() { }
        public void readOnly(bool x) { }
        public void edit() { }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pdfViewerPdfPopUp.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
            this.pdfViewerPdfPopUp.PdfSourceBytes = null;
            this.pdfViewerPdfPopUp.DataBind();
        }

        public void FillData()
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            fuRequirementFile.BrowseButton.Text = Resources.Browse.Capitalize();
            btnSave.Text = Resources.Save;
            CancelBtn.Text = Resources.Cancel;
        }

        public void fuRequirementFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            string message = string.Empty,
                   pdfPath = string.Empty;

            try
            {
                var file = e.UploadedFile;

                string fileName = WEB.NewBusiness.Common.Utility.GetSerialId() + "~~" + file.FileName,
                       savePath = TempFilePath + "\\" + fileName;

                byte[] ImgBytes = new byte[] { };

                if (file.IsValid)
                {
                    ImgBytes = file.FileBytes;

                    if (file.ContentType.IndexOf("image") != -1)
                    {
                        //verificar el tipo de imagen que se esta capturando para si no es un png entonces convertirla a png
                        if (file.ContentType.IndexOf("png") == -1)
                            //No es un png entonces convertirlo a png
                            //ImgBytes = ITextSharpService.ConvertImageAsPng(ImgBytes, TempFilePath);                            
                            ImgBytes = ITextSharpService.ConvertImageAsPng(file.FileContent);

                        //Convertir imagen a pdf                        
                        var pdf = ITextSharpService.ConvertImageToPdf(ImgBytes);

                        byte[] compress = WEB.NewBusiness.Common.Utility.CompressPDF(pdf);

                        var AlterfileName = file.FileName.Split('.')[0] + ".pdf";
                        var AlternativeSavePath = TempFilePath + "\\" + WEB.NewBusiness.Common.Utility.GetSerialId() + "~~" + AlterfileName;
                        WEB.NewBusiness.Common.Utility.ByteArrayToFile(AlternativeSavePath, compress);
                        message = AlternativeSavePath;
                    }
                    else
                    {   
                        file.SaveAs(savePath);
                        message = savePath;
                    }
                }
                else
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
            }
            catch (Exception ex)
            {
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }

            txtPath.Text = message;
            
            pdfPath = message;
            Session["pdfUploadedPath"] = message;
            e.CallbackData = message;
        }

        protected void btnRequirementPreviewPDF_Click(object sender, EventArgs e)
        {
            if (Session["pdfUploadedPath"] != null)
            {
                var Path = Session["pdfUploadedPath"].ToString();

                if (File.Exists(Path))
                {
                    byte[] fileBytes = File.ReadAllBytes(Path);

                    this.pdfViewerPdfPopUp.PdfSourceBytes = fileBytes;
                    this.pdfViewerPdfPopUp.DataBind();
                    ModalPopupExtender ext = (ModalPopupExtender)this.Parent.FindControl("ModalPopupExtender1");
                    if (ext != null)
                    {
                        this.btnSave.Enabled = true;
                        ext.Show();
                    }
                }
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string pdfUploadedPath = Session["pdfUploadedPath"] != null ? Convert.ToString(Session["pdfUploadedPath"]) : string.Empty;

            if (!string.IsNullOrWhiteSpace(pdfUploadedPath))
            {
                var UCDocument = ((UCDocuments)(this.Parent.Parent.Parent.Parent.Parent.Parent));
                UCDocument.save(pdfUploadedPath);
            }
            else
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.BrowseFile);
        }

        private void ClosePopUp()
        {

        }
    }
}