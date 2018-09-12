using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Web.SubmittedPolicies.Bll.Poco;
using Web.SubmittedPolicies.Common.Interfaces;
using Statetrust.Framework.Core.Util;
using System.IO;
using Statetrust.Framework.Core.Extensions;
using Web.SubmittedPolicies.Common.Classes;

namespace Web.SubmittedPolicies.Life.UserControls.Issue.Popups
{
    public partial class UCAmmendments : Uc, IUc
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfAmmendments.LicenseKey = Common.Classes.Common.PDFViewerKey;
        }

        public void Translator(Enums.Languages lang)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        public void FillData(bool cleanPdf )
        {
            var AmmendmentData = Common.Classes.Common.DataService.GetPolicyAmmendments(Common.Classes.Common.ProjectId, PolicyKey).ToList();

            var AmmendmentsCount = AmmendmentData.Count();
            gvPopAmmendments.DataSource = AmmendmentData;
            gvPopAmmendments.DataBind();

            SetPagerIndex(gvPopAmmendments, AmmendmentsCount);

            if (!cleanPdf) return;
            txtAmmendmentComment.Clear();
            ShowPdf(null);
        }

        public void FillData()
        {

        }

        protected void btnPDF_OnClick(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            var keyItem = PolicyKey;

            var docTypeId = int.Parse(gvPopAmmendments.DataKeys[gridRow.RowIndex]["Doc_Type_Id"].ToString());
            var docCategoryId = int.Parse(gvPopAmmendments.DataKeys[gridRow.RowIndex]["Doc_Category_Id"].ToString());
            var documentId = int.Parse(gvPopAmmendments.DataKeys[gridRow.RowIndex]["Document_Id"].ToString());

            var document = Common.Classes.Common.DataService.GetPolicyDocument(keyItem, docCategoryId, docTypeId, documentId);

            ShowPdf(document.Document_Binary);

            hdnAmmendmentIndex.Value = gridRow.RowIndex.ToString();
            txtAmmendmentComment.Text = gvPopAmmendments.DataKeys[gridRow.RowIndex]["Comments"].ToString();

            gvPopAmmendments.SelectedIndex = gridRow.RowIndex;
        }

        private void ShowPdf(byte[] docFile)
        {
            pdfAmmendments.PdfSourceBytes = docFile;
            pdfAmmendments.DataBind();
        }

        protected void fuPopAmmendments_OnFileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            var message = "";
            try
            {
                var file = e.UploadedFile;
                if (file.IsValid)
                {
                    var fileName = Utility.GetSerialId(6) + "~~" + file.FileName;
                    var savePath = Common.Classes.Common.TempFilePath + "\\" + fileName;
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

        protected void btnUploadAmmendment_OnClick(object sender, EventArgs e)
        {
            #region ShowPDF
            var fileBytes = File.ReadAllBytes(hdnAmmendmentPath.Value);
            var fileName = hdnAmmendmentPath.Value.Split('~')[2];
            pdfAmmendments.PdfSourceBytes = fileBytes;
            pdfAmmendments.DataBind();
            #endregion

            #region Save Ammendment
            var rowIndex = String.IsNullOrEmpty(hdnAmmendmentIndex.Value) ? -1 : int.Parse(hdnAmmendmentIndex.Value);
            if (rowIndex < 0) return;

            var keyItem = new Common.Classes.Common.PolicyKeyItem
            {
                CorpId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Corp_Id"].ToString()),
                RegionId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Region_Id"].ToString()),
                CountryId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Country_Id"].ToString()),
                DomesticregId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Domesticreg_Id"].ToString()),
                StateProvId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["State_Prov_Id"].ToString()),
                CityId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["City_Id"].ToString()),
                OfficeId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Office_Id"].ToString()),
                CaseSeqNo = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Case_Seq_No"].ToString()),
                HistSeqNo = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Hist_Seq_No"].ToString())
            };
            var ammendmentId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Ammendment_Id"].ToString());

            Common.Classes.Common.DataService.SetAmmendmentDocument(keyItem, ammendmentId, fileBytes, fileName, DateTime.Now, Common.Classes.Common.CurrentUserId);
            #endregion

            #region Refresh Grid
            FillData(false);
            #endregion
        }

        protected void lnkReemplazarAmmendment_OnClick(object sender, EventArgs e)
        {
            #region Replace Document
            var rowIndex = String.IsNullOrEmpty(hdnAmmendmentIndex.Value) ? -1 : int.Parse(hdnAmmendmentIndex.Value);
            if (rowIndex < 0) return;

            var keyItem = new Common.Classes.Common.PolicyKeyItem
            {
                CorpId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Corp_Id"].ToString()),
                RegionId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Region_Id"].ToString()),
                CountryId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Country_Id"].ToString()),
                DomesticregId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Domesticreg_Id"].ToString()),
                StateProvId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["State_Prov_Id"].ToString()),
                CityId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["City_Id"].ToString()),
                OfficeId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Office_Id"].ToString()),
                CaseSeqNo = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Case_Seq_No"].ToString()),
                HistSeqNo = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Hist_Seq_No"].ToString())
            };
            var ammendmentId = int.Parse(gvPopAmmendments.DataKeys[rowIndex]["Ammendment_Id"].ToString());

            Common.Classes.Common.DataService.ReplaceAmmendmentDocument(keyItem, ammendmentId, 1);
            #endregion

            #region Refresh Grid
            FillData(false);
            #endregion

            #region Clean PDF
            ShowPdf(null);
            #endregion
        }

        protected void gvPopAmmendments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPopAmmendments.PageIndex = e.NewPageIndex;
            gvPopAmmendments.DataBind();

            FillData(false);
        }

        void SetPagerIndex(GridView gv, int count)
        {
            if (gv.BottomPagerRow == null) return;
            var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
            var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
            var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
            var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
            var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
            var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");

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
            totalItems.Text = count.ToString();
        }

        public void DisableLinkButton(LinkButton linkButton, string disableClass)
        {
            linkButton.CssClass = disableClass;
            linkButton.Enabled = false;
        }
    }
}