using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using AjaxControlToolkit;
using System.IO;
using WEB.NewBusiness.NewBusiness.UserControls.Payment;
using System.Web.Script.Serialization;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    public partial class UCUploadPaymentDocumentPopUp : UC
    {

        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator();
        }

        public void Translator()
        {
           DocumentView.InnerHtml = Resources.DocumentView;
           fuRequirementFile.BrowseButton.Text = Resources.Browse;
           CancelBtn.Text = Resources.Cancel;
           SaveBtn.Text = Resources.Save;
           CloseBtn.Text = Resources.Close;
        }

        public delegate void RefreshDocumentPath(string Path);
        public event RefreshDocumentPath RefreshDocumentPathEvent;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.pdfViewerPdfPopUp.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
            this.pdfViewerPdfPopUp.PdfSourceBytes = null;
            this.pdfViewerPdfPopUp.DataBind();

        }

        protected void fuRequirementFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
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
                Session["pdfPath"] = message;
                RefreshDocumentPathEvent(message);
            }
            catch (Exception ex)
            {
                pdfPath = message;
                Session["pdfPath"] = null;
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }

            e.CallbackData = message;
        }

        protected void btnRequirementPreviewPDF_Click(object sender, EventArgs e)
        {
            var Path = Session["pdfPath"].ToString();
            if (File.Exists(Path))
            {
                byte[] fileBytes = File.ReadAllBytes(Path);

                this.pdfViewerPdfPopUp.PdfSourceBytes = fileBytes;
                this.pdfViewerPdfPopUp.DataBind();
                ModalPopupExtender ext = (ModalPopupExtender)this.Parent.FindControl("ModalPopupExtender1");
                if (ext != null)
                {
                    this.SaveBtn.Enabled = true;
                    ext.Show();
                }
            }

        }

        public void PFDView(byte[] fileBytes)
        {

            pnUpdateDocument.Visible = false;
            pnUploadDocumentButtons.Visible = false;
            pnCloseButton.Visible = true;
            this.pdfViewerPdfPopUp.PdfSourceBytes = fileBytes;
            this.pdfViewerPdfPopUp.DataBind();

        }

        public void UploadFileView()
        {
            pnUpdateDocument.Visible = true;
            pnUploadDocumentButtons.Visible = true;
            pnCloseButton.Visible = false;
        }

        public void saveDocument(int PaymentDetId)
        {
            if (this.fuRequirementFile.UploadedFiles.Count() > 0)
            {
                if (!Session["pdfPath"].isNullReferenceObject())
                {
                    var Path = Session["pdfPath"].ToString();
                    byte[] fileBytes = File.ReadAllBytes(Path);
                    Entity.UnderWriting.Entities.Payment.Document doc = new Entity.UnderWriting.Entities.Payment.Document();

                    doc.DocumentBinary = fileBytes;
                    doc.FileCreationDate = DateTime.Now;
                    doc.PaymentDetId = PaymentDetId;
                    doc.UserId = (int)ObjServices.UserID;

                    var dt = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                              (
                                    ObjServices.Corp_Id
                                  , ObjServices.Region_Id
                                  , ObjServices.Country_Id
                                  , ObjServices.Domesticreg_Id
                                  , ObjServices.State_Prov_Id
                                  , ObjServices.City_Id
                                  , ObjServices.Office_Id
                                  , ObjServices.Case_Seq_No
                                  , ObjServices.Hist_Seq_No
                                  , ObjServices.PaymentId.Value
                                  , ObjServices.Language.ToInt()
                              ).Where(det => det.PaymentDetId == PaymentDetId).FirstOrDefault();
                    if (dt != null)
                    {
                        doc.DocumentTypeId = dt.DocumentTypeId;
                        doc.DocumentCategoryId = dt.DocumentCategoryId;
                        doc.DocumentId = dt.DocumentId;

                        if (dt.DocumentTypeId.HasValue && dt.DocumentCategoryId.HasValue && dt.DocumentId.HasValue)
                            ObjServices.oPaymentManager.UpdatePaymentDetailDocument(doc);                              
                        else
                            ObjServices.oPaymentManager.InsertPaymentDetailDocument(doc);
                    } 
                    var container2 = (UCUploadDocumentOfPayments)this.Parent.Parent;
                    container2.FillData();

                    try
                    {
                        string TemplateIndexFile = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LifeOnBaseTemplatePath"]);
                        string documentType = "D";
                        Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                        {
                            Contact_ID = ObjServices.Contact_Id
                        };
                        ObjServices.SendFileToOnBase(Add,TemplateIndexFile,
                                                     documentType,
                                                     130,
                                                     1,
                                                     Session["pdfPath"].ToString());
                    }
                    catch (Exception ex)
                    {
                        ObjServices.oPolicyManager.InsertLog(new Entity.UnderWriting.Entities.Policy.LogParameter
                        {
                            LogTypeId = WEB.NewBusiness.Common.Utility.LogTypeId.Exception.ToInt(),
                            CorpId = ObjServices.Corp_Id,
                            CompanyId = ObjServices.CompanyId,
                            ProjectId = ObjServices.ProjectId,
                            Identifier = Guid.NewGuid(),
                            LogValue = "Se encontro un problema con el proceso OnBaseTranfer payment, Detalle: " + ex.Message.ToString()
                        });
                    }

                    Session["pdfPath"] = null;
                }              
            }
        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "$(\".ui-button\").click();", true);
            if (Session["pdfPath"] != null)
                RefreshDocumentPathEvent(Session["pdfPath"].ToString().Split('~')[2]);
            else
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.BrowseFile); //"Please browser for a file before saving."
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Session["pdfPath"] = null;
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "$(\".ui-button\").click();", true);
            RefreshDocumentPathEvent("");
        }
    }
}
