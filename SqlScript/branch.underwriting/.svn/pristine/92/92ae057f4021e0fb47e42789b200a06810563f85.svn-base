using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Requirements
{
    public partial class UCRequirementComunication : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        

        //IRequirement RequirementManager
        //{
        //    get { return diManager.RequirementManager; }
        //}
        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        WEB.UnderWriting.Common.SessionList datos = new WEB.UnderWriting.Common.SessionList();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pdfViewerComunication.LicenseKey = Service.PdfViewerKey;
            //pdfViewerComunication.PdfSourceBytes = null;
            //pdfViewerComunication.DataBind();
        }

        public void clearData() {
            pdfViewerComunication.PdfSourceBytes = null;
            pdfViewerComunication.DataBind();
        
        }

        public void FillData()
        {

            var values = ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hfRequirementKey")).Value.Split('|');
            var comunicationList = Services.RequirementManager.GetAllComunications(Service.Corp_Id, Service.Region_Id, Service.Country_Id,
                Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id,
                Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No, Convert.ToInt32(values[3]), Convert.ToInt32(values[0]),
                Convert.ToInt32(values[1]), Convert.ToInt32(values[4]));
            CommentsRepeater.DataSource = comunicationList.OrderByDescending(x=>x.CommentDate);
            CommentsRepeater.DataBind();

            var documents = Services.RequirementManager.GetAllDocuments(Service.Corp_Id, Service.Region_Id, Service.Country_Id,
                Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id,
                Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No,
                Convert.ToInt32(values[3]), Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), Convert.ToInt32(values[4]));

            gvComunicationPopUp.DataSource = documents;
            gvComunicationPopUp.DataBind();

            AddCommentBtn.Enabled = true;
            pnAddCommentBtn.CssClass = "boton_wrapper gradient_AM_btn bdrAM txtNG-f fr";
            RequirementCommunicationNewCommentsTxt.Enabled = true;
            pnStatusButtons.Visible = false;
            if (documents.Where(d=>d.DocumentStatusId ==1).ToArray().Length>0)
            {
                AddCommentBtn.Enabled = false;
                pnAddCommentBtn.CssClass = "boton_wrapper btn-disabled fr";
                RequirementCommunicationNewCommentsTxt.Enabled = false;
            }

            RequirementCommunicationNewCommentsTxt.Text = string.Empty;
        }
        protected void ComunicationLoadPdfBtn_Click(object sender, EventArgs e)
        {
            var rownIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            var document = Services.RequirementManager.GetDocument(Service.Corp_Id, Service.Region_Id, Service.Country_Id,
               Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id,
               Service.Case_Seq_No, Service.Hist_Seq_No, Convert.ToInt32(gvComunicationPopUp.DataKeys[rownIndex]["ContactId"]),
               Convert.ToInt32(gvComunicationPopUp.DataKeys[rownIndex]["RequirementCatId"]), Convert.ToInt32(gvComunicationPopUp.DataKeys[rownIndex]["RequirementTypeId"]),
               Convert.ToInt32(gvComunicationPopUp.DataKeys[rownIndex]["RequirementId"]), Convert.ToInt32(gvComunicationPopUp.DataKeys[rownIndex]["RequirementDocId"]));

            hfRequirementDocumentKey.Value = gvComunicationPopUp.DataKeys[rownIndex]["ContactId"]+"|"+
                gvComunicationPopUp.DataKeys[rownIndex]["RequirementCatId"] + "|" +
                gvComunicationPopUp.DataKeys[rownIndex]["RequirementTypeId"] + "|" +
                gvComunicationPopUp.DataKeys[rownIndex]["RequirementId"] + "|" +
                gvComunicationPopUp.DataKeys[rownIndex]["RequirementDocId"];

            pdfViewerComunication.PdfSourceBytes = document.DocumentBinary;
            pdfViewerComunication.DataBind();

            pnStatusButtons.Visible = AddCommentBtn.Enabled;

        }
        protected void ComunicationAddComment_Click(object sender, EventArgs e)
        {
            string[] Values = ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hfRequirementKey")).Value.Split('|');
            if (Values.Length > 0)
            {
                Services.RequirementManager.InsertComunication(new Requirement.Comunication
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
                    Comment = RequirementCommunicationNewCommentsTxt.Text,
                    CommentBy = Service.Underwriter_Id,
                    UserId = Service.Underwriter_Id
                });
                FillData();
            }
        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }


        protected void DeclineBtn_Click(object sender, EventArgs e)
        {
            string[] Values = hfRequirementDocumentKey.Value.Split('|');
           
            //
            Services.RequirementManager.SetDocumentStatus(new Requirement.Document
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
                ContactId = Convert.ToInt32(Values[0]),
                RequirementCatId = Convert.ToInt32(Values[1]),
                RequirementTypeId = Convert.ToInt32(Values[2]),
                RequirementId = Convert.ToInt32(Values[3]),
                RequirementDocId = Convert.ToInt32(Values[4]),
                DocumentStatusId = 2,
                UserId=1
            });

            FillData();
            ((UCRequimentInformation)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")).FillData();
            
        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {

            string[] Values = hfRequirementDocumentKey.Value.Split('|');

            //
            Services.RequirementManager.SetDocumentStatus(new Requirement.Document
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
                ContactId = Convert.ToInt32(Values[0]),
                RequirementCatId = Convert.ToInt32(Values[1]),
                RequirementTypeId = Convert.ToInt32(Values[2]),
                RequirementId = Convert.ToInt32(Values[3]),
                RequirementDocId = Convert.ToInt32(Values[4]),
                DocumentStatusId = 1,
                UserId = Service.Underwriter_Id
            });

            FillData();
            ((UCRequimentInformation)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")).FillData();
            

        }
    }
}