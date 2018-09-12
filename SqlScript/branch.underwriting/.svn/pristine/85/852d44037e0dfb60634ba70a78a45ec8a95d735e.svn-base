using AjaxControlToolkit;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Requirements
{
    public partial class UCRequirementPdfPopUp : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //IRequirement RequirementManager
        //{
        //    get { return diManager.RequirementManager; }
        //}
        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }
        
        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.pdfViewerPdfPopUp.LicenseKey = Service.PdfViewerKey;
            //this.pdfViewerPdfPopUp.PdfSourceBytes = null;
            //this.pdfViewerPdfPopUp.DataBind();
        }
        public void FillData()
        {

        }
        public void Translator(string Lang)
        {

        }
        public void clearData() {
            txtDocumentRequirementComment.Text = "";
            this.pdfViewerPdfPopUp.PdfSourceBytes = null;
            this.pdfViewerPdfPopUp.DataBind();

        }
        public void readOnly(bool x) { }
        public void edit() { }
        public void fuRequirementFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {

            var message = "";
            try
            {
                var file = e.UploadedFile;
                if (file.IsValid)
                {
                    var fileName = Tools.GetSerialId() + "~~" + file.FileName;
                    var savePath = TempFilePath + "\\" + fileName;
                    file.SaveAs(savePath);
                    message = savePath;
                }
                else
                {
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
                }
            }
            catch (Exception ex)
            {
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }
            e.CallbackData = message;
        }

        protected void btnRequirementPreviewPDF_Click(object sender, EventArgs e)
        {
            var Path = ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hdnRequirementUploadedPDFPath")).Value;
            byte[] fileBytes = File.ReadAllBytes(Path);

            this.pdfViewerPdfPopUp.PdfSourceBytes = fileBytes;
            this.pdfViewerPdfPopUp.DataBind();
        
        }

        public void savePdf(object sender, EventArgs e)
        {

            string[] Values = ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hfRequirementKey")).Value.Split('|');
            if (Values.Length > 0)
            {
                var Path = ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hdnRequirementUploadedPDFPath")).Value;
                
                Services.RequirementManager.InsertDocument(new Entity.UnderWriting.Entities.Requirement.Document
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
                    ContactId = Convert.ToInt32(Values[3]),
                    RequirementCatId = Convert.ToInt32(Values[0]),
                    RequirementTypeId = Convert.ToInt32(Values[1]),
                    RequirementId = Convert.ToInt32(Values[4]),
                    DocumentStatusId = 1,
                    DocumentBinary = File.ReadAllBytes(Path),
                    DocumentName = Path.Split('~')[2].ToString(),
                    UserId = Service.Underwriter_Id
                });

                Services.RequirementManager.InsertComunication(new Entity.UnderWriting.Entities.Requirement.Comunication
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
                    ContactId = Convert.ToInt32(Values[3]),
                    RequirementCatId = Convert.ToInt32(Values[0]),
                    RequirementTypeId = Convert.ToInt32(Values[1]),
                    RequirementId = Convert.ToInt32(Values[4]),
                    Comment = txtDocumentRequirementComment.Text,
                    CommentBy = Service.Underwriter_Id,
                    UserId = Service.Underwriter_Id
                });

                try
                {
                    string TemplateIndexFile = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["LifeOnBaseTemplatePath"]);
                    string documentType = "R";

                    Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation Add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
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
                        Contact_ID = Convert.ToInt32(Values[3])
                    };
                   
                    Services ServicesOn = new Services();

                    ServicesOn.SendFileToOnBase(Add,
                                                 TemplateIndexFile,
                                                 documentType,
                                                 Convert.ToInt32(Values[0]),
                                                 Convert.ToInt32(Values[1]),
                                                 Path);
                }
                catch (Exception ex)
                {
                    Services.PolicyManager.InsertLog(new Entity.UnderWriting.Entities.Policy.LogParameter
                    {
                        LogTypeId =3,
                        CorpId = Service.Corp_Id,
                        CompanyId = Service.CompanyId,
                        ProjectId = Service.ProjectId,
                        Identifier = Guid.NewGuid(),
                        LogValue = "Se encontro un problema con el proceso OnBaseTranfer, Detalle: " + ex.Message.ToString()
                    });
                }

                
                ((UCRequimentInformation)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")).FillData();
                ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hdnRequirementUploadedPDFPath")).Value = String.Empty;
                ClosePopUp();
                
            }

        }
        public void save()
        {

        }

        private void ClosePopUp()
        {
            this.pdfViewerPdfPopUp.PdfSourceBytes = null;
            this.pdfViewerPdfPopUp.DataBind();
            ((ModalPopupExtender)Page.Master.FindControl("ModalPopupPDFViewer")).Hide();
        }
    }
}