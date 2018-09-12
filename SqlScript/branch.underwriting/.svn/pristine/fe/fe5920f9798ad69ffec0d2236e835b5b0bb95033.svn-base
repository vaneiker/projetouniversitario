using AjaxControlToolkit;
using PdfViewer4AspNet;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Requirements
{
    public partial class UCRequirementTable : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //IRequirement RequirementManager
        //{
        //    get { return diManager.RequirementManager; }
        //}

        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        WEB.UnderWriting.Common.SessionList datos = new WEB.UnderWriting.Common.SessionList();




        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }
        }

        public void FillData(List<Entity.UnderWriting.Entities.Requirement> RequirementData)
        {
            gvRequeriment.DataSource = RequirementData;
            gvRequeriment.DataBind();
        }

        public void FillData()
        {
        }

        public void SentToReinsurance()
        {
            SaveSentToReinsurance(gvRequeriment);
        }
        private void SaveSentToReinsurance(GridView Grid)
        {
            foreach (GridViewRow item in Grid.Rows)
            {
                var SentToReinsuranceChk = (CheckBox)item.FindControl("ReinsuranceChk");

                string[] Key = SentToReinsuranceChk.Attributes["data-key"].Split('|');
                Services.RequirementManager.SendToReinsurance(new Entity.UnderWriting.Entities.Requirement
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
                                        ContactId = Convert.ToInt32(Key[0]),
                                        RequirementCatId = Convert.ToInt32(Key[1]),
                                        RequirementTypeId = Convert.ToInt32(Key[2]),
                                        RequirementId = Convert.ToInt32(Key[3]),
                                        SendToReinsurance = SentToReinsuranceChk.Checked,
                                        UserId = Service.Underwriter_Id
                                    });
            }
        }
        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }
        public void save()
        {

        }
        public void clearData()
        {

        }
        public void readOnly(bool x)
        {
            throw new NotImplementedException();
        }
        public void edit()
        {
            throw new NotImplementedException();
        }
        public void LoadPdfPopUp(object sender, EventArgs e)
        {
            int RowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            if (((LinkButton)sender).CssClass == "pulse pdf_ico")
            {  
                string documentType = "R";
                Services ServicesOn = new Services();
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
                    Contact_ID = Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["ContactId"])
                };
                byte[] pdfOnBase = ServicesOn.ViewFileFromOnBase(Add,documentType, Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["RequirementCatId"]), Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["RequirementTypeId"]));

                if (pdfOnBase == null)
                { 
                    Entity.UnderWriting.Entities.Requirement.Document Document = Services.RequirementManager.GetDocument(
                       Service.Corp_Id,
                       Service.Region_Id,
                       Service.Country_Id,
                       Service.Domesticreg_Id,
                       Service.State_Prov_Id,
                       Service.City_Id,
                       Service.Office_Id,
                       Service.Case_Seq_No,
                       Service.Hist_Seq_No,
                       Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["ContactId"]),
                       Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["RequirementCatId"]),
                       Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["RequirementTypeId"]),
                       Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["RequirementId"]),
                       Convert.ToInt32(gvRequeriment.DataKeys[RowIndex]["RequirementDocId"]));

                    ViewPDF(Document.DocumentBinary);
                }
                else
                {
                    ViewPDF(pdfOnBase);
                }
            }
            else
            {
                string ContainerName = ((GridView)((GridViewRow)((LinkButton)sender).NamingContainer).NamingContainer).ClientID.Split('_')[3].ToString();

                GridView Grid = (GridView)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")
                            .FindControl(ContainerName).FindControl("gvRequeriment");

                hfRequirementPdfPopUp.Value = "true";
                PreserveRequirementKey(Grid, RowIndex);
                ShowPDFControl();
            }
        }

        public void ViewPDF(byte[] PdfFile)
        {
            PdfViewer pdfViewerControl = (PdfViewer)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPdfViewer").FindControl("Viewer");
            pdfViewerControl.PdfSourceBytes = PdfFile;
            pdfViewerControl.DataBind();
            ((HiddenField)Page.Master.FindControl("Right").FindControl("Right").FindControl("hfMenuCasesRight")).Value = "pdfViewer";
        }

        public void RequirementComunicationBTN_Click(object sender, EventArgs e)
        {
            ((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hfRequirementComunication")).Value = "true";
            var RowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            var ContainerName = ((GridView)((GridViewRow)((LinkButton)sender).NamingContainer).NamingContainer).ClientID.Split('_')[3].ToString();

            var Grid = (GridView)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")
                        .FindControl(ContainerName).FindControl("gvRequeriment");
            PreserveRequirementKey(Grid, RowIndex);
            var ucRequirementComunication = (UCRequirementComunication)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("UCRequirementComunication");
            ucRequirementComunication.clearData();
            ucRequirementComunication.FillData();
            ((ModalPopupExtender)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("mpRequirementComunication")).Show();
        }
        private void ShowPDFControl()
        {
            var ModalPopUp = (ModalPopupExtender)this.Page.Master.FindControl("ModalPopupPDFViewer");
            var popUp = ((UCRequirementPdfPopUp)Page.Master.FindControl("UCRequirementPdfPopUp1"));


            if (ModalPopUp == null) return;
            popUp.clearData();
            ModalPopUp.EnableClientState = false;
            ModalPopUp.EnableViewState = false;
            ModalPopUp.Show();
        }
        private void PreserveRequirementKey(GridView Grid, int RowIndex)
        {
            HiddenField hfRequirementKey = ((HiddenField)Page.Master.FindControl("Left").FindControl("Left")
                .FindControl("UCRequimentInformation").FindControl("hfRequirementKey"));

            hfRequirementKey.Value = (Grid.DataKeys[RowIndex]["RequirementCatId"] != null ? Grid.DataKeys[RowIndex]["RequirementCatId"].ToString() : null)
            + "|" + (Grid.DataKeys[RowIndex]["RequirementTypeId"] != null ? Grid.DataKeys[RowIndex]["RequirementTypeId"].ToString() : null)
            + "|" + (Grid.DataKeys[RowIndex]["RequirementDocId"] != null ? Grid.DataKeys[RowIndex]["RequirementDocId"].ToString() : null)
            + "|" + (Grid.DataKeys[RowIndex]["ContactId"] != null ? Grid.DataKeys[RowIndex]["ContactId"].ToString() : null)
            + "|" + (Grid.DataKeys[RowIndex]["RequirementId"] != null ? Grid.DataKeys[RowIndex]["RequirementId"].ToString() : null);

        }
    }
}

