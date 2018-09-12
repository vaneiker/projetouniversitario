using PdfViewer4AspNet;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Case.UserControls.Requirements;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.FinancialInfo
{
    public partial class UCAllFinancialInformationReceived : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //IRequirement RequirementManager
        //{
        //    get { return diManager.RequirementManager; }
        //}

        //UnderWritingDIManager diManager = new UnderWritingDIManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
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

        public void FillData()
        {
            if (Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance)
            {

                //SALUD
                var data = Services.RequirementManager.GetAll(Service.Corp_Id
                            , Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id
                            , Service.Case_Seq_No, Service.Hist_Seq_No, Service.LanguageId).Where(r => r.RequirementCatId == 3).ToList();

                gvFinancialDocuments.DataSource = data;
                gvFinancialDocuments.DataBind();

                setPagerIndex(gvFinancialDocuments, data.Count());

            }
            else
            {
                var data = Services.RequirementManager.GetAll(Service.Corp_Id
                             , Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id
                             , Service.Case_Seq_No, Service.Hist_Seq_No, Service.LanguageId).Where(r => r.RequirementCatId == 3).ToList();

                gvFinancialDocuments.DataSource = data;
                gvFinancialDocuments.DataBind();

                setPagerIndex(gvFinancialDocuments, data.Count());
            }
        }

        protected void gvFinancialDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFinancialDocuments.PageIndex = e.NewPageIndex;
            FillData();
        }

        void setPagerIndex(GridView gv, int Count)
        {
            if (gv.BottomPagerRow != null)
            {
                var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
                var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
                var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
                var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
                var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
                var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


                var count = gv.PageCount;
                var index = gv.PageIndex + 1;

                indexText.Text = index.ToString();
                totalText.Text = count.ToString();

                if (index == 1)
                {
                    DisableLinkButton(lnkPrev, "prev_dis");
                    DisableLinkButton(lnkFirst, "rewd_dis");
                }
                else if (index == count)
                {
                    DisableLinkButton(lnkNext, "next_dis");
                    DisableLinkButton(lnkLast, "fwrd_dis");
                }

                var totalItems = (Literal)gv.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = Count.ToString();
            }
        }

        public void DisableLinkButton(LinkButton linkButton, string disable_class)
        {

            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }

        protected void lnkViewPdf_Click(object sender, EventArgs e)
        {

            int RowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            if (((LinkButton)sender).CssClass == "pulse pdf_ico")
            {
                var Document = Services.RequirementManager.GetDocument(Service.Corp_Id,
                   Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
                   Service.State_Prov_Id, Service.City_Id, Service.Office_Id,
                   Service.Case_Seq_No, Service.Hist_Seq_No,
                    Convert.ToInt32(gvFinancialDocuments.DataKeys[RowIndex]["ContactId"]),
                    Convert.ToInt32(gvFinancialDocuments.DataKeys[RowIndex]["RequirementCatId"]),
                    Convert.ToInt32(gvFinancialDocuments.DataKeys[RowIndex]["RequirementTypeId"]),
                     Convert.ToInt32(gvFinancialDocuments.DataKeys[RowIndex]["RequirementId"]),
                    Convert.ToInt32(gvFinancialDocuments.DataKeys[RowIndex]["RequirementDocId"]));

                var pdfViewerControl = (PdfViewer)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPdfViewer").FindControl("Viewer");
                pdfViewerControl.PdfSourceBytes = Document.DocumentBinary;
                pdfViewerControl.DataBind();
                ((HiddenField)Page.Master.FindControl("Right").FindControl("Right").FindControl("hfMenuCasesRight")).Value = "pdfViewer";
            }
            else
            {
                string ContainerName = ((GridView)((GridViewRow)((LinkButton)sender).NamingContainer).NamingContainer).ClientID.Split('_')[3].ToString();

                GridView Grid = (GridView)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")
                            .FindControl(ContainerName).FindControl("gvRequeriment");

                hdnFinancialPDF.Value = "true";
                ShowPDFControl();
            }
        }

        private void ShowPDFControl()
        {
            var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("ModalPopupPDFViewer");
            var popUp = ((UCRequirementPdfPopUp)Page.Master.FindControl("UCRequirementPdfPopUp1"));

            if (ModalPopUp != null)
            {
                popUp.clearData();
                ModalPopUp.EnableClientState = false;
                ModalPopUp.EnableViewState = false;
                ModalPopUp.Show();
            }
        }

    }
}