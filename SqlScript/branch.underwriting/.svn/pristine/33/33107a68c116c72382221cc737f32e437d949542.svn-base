using Entity.UnderWriting.Entities;
using PdfViewer4AspNet;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class UCBackgroundCheck : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public void FillData()
        {
            var contactBackGroundCheck = Services.ContactManager.GetBackGroundCheck(Service.Corp_Id, 
																					Service.Region_Id, 
																					Service.Country_Id, 
																					Service.Domesticreg_Id,
																					Service.State_Prov_Id, 
																					Service.City_Id, 
																					Service.Office_Id, 
																					Service.Case_Seq_No,
																					Service.Hist_Seq_No, 
																					Service.Contact_Id);

            //Get BGC Documents
            var backGroundCheckInfo = Services.StepManager.GetStepExtraInfo(new Policy.Parameter()
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No
            }).ToList();

            //Fill Urls Grid
            FillLinks();

            //Fill Docs Grid
            FillDocuments();

            CommentsTxt.Text = "";
            if (contactBackGroundCheck != null)
            {
                ReasonTxt.Text = contactBackGroundCheck.Reason;
                UserTxt.Text = contactBackGroundCheck.BackgroundCheckUserName;
                DateTxt.Text = contactBackGroundCheck.Date.ToString("MM/dd/yyyy");
               // CommentsTxt.Text = contactBackGroundCheck.Comments;
                if (contactBackGroundCheck.Results)
                {
                    ResultsTxt.Text = "Matched";
                    ResultsTxt.CssClass = "bgRJ txtBL ReadOnly";
                }
                else
                {
                    ResultsTxt.Text = "Not Matched";
                    ResultsTxt.CssClass = "bgVD2 txtBL ReadOnly";
                }
            }
            else
            {
                ResultsTxt.Text = "Pending";
                ResultsTxt.CssClass = "bgAM txtBL ReadOnly";
            }

            var step = new Entity.UnderWriting.Entities.Step
            {
                StepId = 102,
                StepTypeId = 1,
                StepCaseNo = null, //Index de la cantidad de backgroundcheck que se ha colocado
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No,
                Voidable = false,
                Closable = false,
                ProcessStatus = 1
            };

            var data = from d in Services.StepManager.GetAllNotes(step)
                       select new
                       {
                           d.StepId,
                           d.StepCaseNo,
                           d.StepTypeId,
                           d.OriginatedByName,
                           d.NoteDesc,
                           Date = (d.DateAdded.HasValue ? d.DateAdded.Value.ToString("MM/dd/yyyy") : (d.DateModified.HasValue ? d.DateModified.Value.ToString("MM/dd/yyyy") : "")),
                           Time = (d.DateAdded.HasValue ? d.DateAdded.Value.ToShortTimeString() : (d.DateModified.HasValue ? d.DateModified.Value.ToShortTimeString() : ""))
                       };

            foreach (var item in data)
            {
                CommentsTxt.Text += "\n\n" + "USER: " + item.OriginatedByName + " | DATE: " + item.Date + " | TIME:" + item.Time + "\n\n Note Desc: " + item.NoteDesc;

            }

            int contactid = Service.Contact_Id;
            var SummaryRoleDDL = (DropDownList)Page.Master.FindControl("Left").FindControl("Left").FindControl("SummaryRoleDDL");

            if (SummaryRoleDDL.Items.Count > 0)
            {
                contactid = int.Parse(SummaryRoleDDL.SelectedValue.Split('|')[0]);
            }

            BackgroundCheckLink.FillGrid(contactid);
        }

        private void FillDocuments()
        {
            var backGroundCheckInfo = Services.StepManager.GetStepExtraInfo(new Policy.Parameter()
            {
                CorpId = Service.Corp_Id,
                RegionId = Service.Region_Id,
                CountryId = Service.Country_Id,
                DomesticregId = Service.Domesticreg_Id,
                StateProvId = Service.State_Prov_Id,
                CityId = Service.City_Id,
                OfficeId = Service.Office_Id,
                CaseSeqNo = Service.Case_Seq_No,
                HistSeqNo = Service.Hist_Seq_No
            }).ToList();

            //Fill Docs Grid
            var documents = backGroundCheckInfo.Where(r => r.StepExtraInfoTypeId == 1).ToList();
            var documentsCount = documents.Count();


            //gvBackGroundCheck.DataSource = documents;
            //gvBackGroundCheck.DataBind();
            //setPagerIndex(gvBGCLinks, documentsCount);
        }

        private void FillLinks()
        {
            //var backGroundCheckInfo = Services.StepManager.GetStepExtraInfo(new Policy.Parameter()
            //{
            //    CorpId = Service.Corp_Id,
            //    RegionId = Service.Region_Id,
            //    CountryId = Service.Country_Id,
            //    DomesticregId = Service.Domesticreg_Id,
            //    StateProvId = Service.State_Prov_Id,
            //    CityId = Service.City_Id,
            //    OfficeId = Service.Office_Id,
            //    CaseSeqNo = Service.Case_Seq_No,
            //    HistSeqNo = Service.Hist_Seq_No
            //}).ToList();

            ////Fill Urls Grid
            //var urls = backGroundCheckInfo.Where(r => r.StepExtraInfoTypeId == 2).ToList();
            //var urlsCount = urls.Count();

            //gvBGCLinks.DataSource = (from d in urls
            //                         select new
            //                         {
            //                             d.StepExtraInfoDesc,
            //                             Match = d.StepExtraInfoStatusId == 1
            //                         }).ToList();
            //gvBGCLinks.DataBind();
            //setPagerIndex(gvBGCLinks, urlsCount);
        }

        protected void BackgroundCheckPdfBTN_Click(object sender, EventArgs e)
        {
            //var rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            //var DocCategoryId = Convert.ToInt32(gvBackGroundCheck.DataKeys[rowIndex]["DocCategoryId"]);
            //var DocTypeId = Convert.ToInt32(gvBackGroundCheck.DataKeys[rowIndex]["DocTypeId"]);
            //var DocumentId = Convert.ToInt32(gvBackGroundCheck.DataKeys[rowIndex]["DocumentId"]);

            //var backGraundCheckDoc = Services.PaymentManager.GetDocument(Service.Corp_Id, 
            //                                                             Service.Region_Id, 
            //                                                             Service.Country_Id,
            //                                                             Service.Domesticreg_Id, 
            //                                                             Service.State_Prov_Id, 
            //                                                             Service.City_Id, 
            //                                                             Service.Office_Id,
            //                                                             Service.Case_Seq_No, 
            //                                                             Service.Hist_Seq_No, 
            //                                                             DocCategoryId, 
            //                                                             DocTypeId, 
            //                                                             DocumentId);

            //var pdfViewerControl = (PdfViewer)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPdfViewer").FindControl("Viewer");
            //pdfViewerControl.PdfSourceBytes = backGraundCheckDoc.DocumentBinary;
            //pdfViewerControl.DataBind();
            //((HiddenField)Page.Master.FindControl("Right").FindControl("Right").FindControl("hfMenuCasesRight")).Value = "pdfViewer";
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        protected void gvBackGroundCheck_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvBackGroundCheck.PageIndex = e.NewPageIndex;
            //gvBackGroundCheck.DataBind();
            //FillDocuments();
        }

        protected void gvBGCLinks_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvBGCLinks.PageIndex = e.NewPageIndex;
            //gvBGCLinks.DataBind();
            //FillLinks();
        }

        void setPagerIndex(GridView gv, int Count)
        {
            if (gv.BottomPagerRow == null) return;
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
        public void DisableLinkButton(LinkButton linkButton, string disable_class)
        {

            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }
    }
}