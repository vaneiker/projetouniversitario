using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
    public partial class UCAmendments : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerID.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"];
        }

        public void FillData()
        {
            FillGrid();
            UCRequestAmendments.fillDdl();
        }

        public void FillGrid()
        {
            var Corp_Id = Service.Corp_Id;
            var Region_Id = Service.Region_Id;
            var Country_Id = Service.Country_Id;
            var Domesticreg_Id = Service.Domesticreg_Id;
            var State_Prov_Id = Service.State_Prov_Id;
            var City_Id = Service.City_Id;
            var Office_Id = Service.Office_Id;
            var Case_Seq_No = Service.Case_Seq_No;
            var Hist_Seq_No = Service.Hist_Seq_No;

            var ammendments = Services.AmmendmentManager.GetAllAmmendmentInformation(Corp_Id, Region_Id, Country_Id, Domesticreg_Id, State_Prov_Id, City_Id, Office_Id, Case_Seq_No, Hist_Seq_No);
            gvAmendments.DataSource = ammendments;
            gvAmendments.DataBind();


            if (gvAmendments.BottomPagerRow != null)
            {
                var totalItems = (Literal)gvAmendments.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = ammendments.ToList().Count + "";
            }
            setPagerIndex(gvAmendments);
        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.save()
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

        protected void btnRequestAmendments_Click(object sender, EventArgs e)
        {
            hfRequestAmendments.Value = "true";
        }

        protected void lnkPdfButton_Click(object sender, EventArgs e)
        {

            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var CorpId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["CorpId"].ToString());
            var RegionId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["RegionId"].ToString());
            var CountryId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["CountryId"].ToString());
            var DomesticregId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["DomesticregId"].ToString());
            var StateProvId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["StateProvId"].ToString());
            var CityId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["CityId"].ToString());
            var OfficeId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["OfficeId"].ToString());
            var CaseSeqNo = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["CaseSeqNo"].ToString());
            var HistSeqNo = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["HistSeqNo"].ToString());
            var DocCategoryId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["DocCategoryId"].ToString());
            var DocTypeId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["DocTypeId"].ToString());
            var DocumentId = int.Parse(gvAmendments.DataKeys[gridRow.RowIndex]["DocumentId"].ToString());

            pdfViewerID.Visible = true;

            var document = Services.AmmendmentManager.GetAmmendment(
                CorpId,
                RegionId,
                CountryId,
                DomesticregId,
                StateProvId,
                CityId,
                OfficeId,
                CaseSeqNo,
                HistSeqNo,
                DocCategoryId,
                DocTypeId,
                DocumentId
               );

            byte[] documentBinary = document.DocumentBinary.ToArray();

            pdfViewerID.PdfSourceBytes = documentBinary;
            pdfViewerID.DataBind();


        }


        public void DisableLinkButton(LinkButton linkButton, string disable_class)
        {
            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }

        void setPagerIndex(GridView gv)
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
            }
        }


        public void clearData()
        {
            throw new NotImplementedException();
        }

        protected void gvAmendments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAmendments.PageIndex = e.NewPageIndex;
            gvAmendments.DataBind();
            FillGrid();
        }


    }
}