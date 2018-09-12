using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.Common.Interfaces;

namespace Web.SubmittedPolicies.Life.UserControls.Issue.Popups
{
    public partial class UCDocuments : Uc, IUc
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfDocuments.LicenseKey = Common.Classes.Common.PDFViewerKey;
        }

        protected void btnPdf_OnClick(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            var keyItem = PolicyKey;

            var docTypeId = int.Parse(gvPopDocuments.DataKeys[gridRow.RowIndex]["Doc_Type_Id"].ToString());
            var docCategoryId = int.Parse(gvPopDocuments.DataKeys[gridRow.RowIndex]["Doc_Category_Id"].ToString());
            var documentId = int.Parse(gvPopDocuments.DataKeys[gridRow.RowIndex]["Document_Id"].ToString());

            var document = Common.Classes.Common.DataService.GetPolicyDocument(keyItem, docCategoryId, docTypeId, documentId);

            ShowPdf(document.Document_Binary);

            gvPopDocuments.SelectedIndex = gridRow.RowIndex;
        }

        protected void gvPopDocuments_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            throw new NotImplementedException();
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

        public void FillData()
        {

        }

        public void FillData(bool cleanPdf)
        {
            if (PolicyKey == null) return;
            if (cleanPdf)
            {
                CleanFields();
                ShowPdf(null);
            }

            var documentInfo = Common.Classes.Common.DataService.GetPolicyDocumentInfo(PolicyKey).First();

            FillDocInfo(documentInfo);
            /*  var documentsCount = documentsData.Count();
              gvPopDocuments.DataSource = documentsData;
              gvPopDocuments.DataBind();*/

            //SetPagerIndex(gvPopDocuments, documentsCount);


        }

        private void FillDocInfo(Bll.Poco.PolicyDocumentInfo documentInfo = null)
        {
            if (documentInfo == null)
                CleanFields();
            else
            {
                //First Column
                txtDPPolicyNo.Text = documentInfo.Policy_No;
                txtDBPlanName.Text = documentInfo.Product_Desc;
                txtDPCurrency.Text = documentInfo.Currency_Desc;
                txtDPInitialPremium.Text = documentInfo.Initial_Premium_F;
                txtDPPeriodicPremium.Text = "";
                txtDPInsuredInitialPremium.Text = documentInfo.Insured_Amount_F;

                //Second Column
                txtDPRider.Text = documentInfo.Rider;
                txtDPDeadRider.Text = documentInfo.RiderADB;
                txtDPTempAditional.Text = documentInfo.RiderSEGTEMAD;
                txtDPAdditionalIsured.Text = documentInfo.RiderSPINS;
                txtDPOwnerAddress.Text = documentInfo.Owner_Address;
                txtDPOwnerIdNo.Text = documentInfo.Owner_Id;
                txtDPInsuredAddress.Text = documentInfo.Insured_Address;
                txtDPInsuredIdNo.Text = documentInfo.Insured_Id;
                txtDPBeneficiaries.Text = documentInfo.Beneficiary;

                //Third Column
                txtDPContingentBeneficiary.Text = documentInfo.BeneficiaryContingent;
                txtDPPlanOwner.Text = documentInfo.Owner_FullName;
                txtDPInsured.Text = documentInfo.Insured_FullName;
                txtDPInsuredAge.Text = documentInfo.Insured_Age_F;
                txtDPSex.Text = documentInfo.Insured_Gender;
                txtDPSmoker.Text = documentInfo.Insured_Smoker_F;
                txtDPContributionPeriod.Text = documentInfo.Contribution_Years_F;
                txtDPContributionFrequency.Text = documentInfo.Payment_Freq_Type_Desc;
                txtDPReturnRate.Text = documentInfo.Rate_Return_F;
            }
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

        private void CleanFields()
        {
            txtDPAdditionalIsured.Text = "-";
            txtDPBeneficiaries.Text = "-";
            txtDPContingentBeneficiary.Text = "-";
            txtDPContributionFrequency.Text = "-";
            txtDPContributionPeriod.Text = "-";
            txtDPCurrency.Text = "-";
            txtDPDeadRider.Text = "-";
            txtDPInsuredInitialPremium.Text = "-";
            txtDPInitialPremium.Text = "-";
            txtDPInsured.Text = "-";
            txtDPInsuredAddress.Text = "-";
            txtDPInsuredAge.Text = "-";
            txtDPInsuredIdNo.Text = "-";
            txtDPOwnerAddress.Text = "-";
            txtDPOwnerIdNo.Text = "-";
            txtDPPeriodicPremium.Text = "-";
            txtDBPlanName.Text = "-";
            txtDPPlanOwner.Text = "-";
            txtDPPolicyNo.Text = "-";
            txtDPReturnRate.Text = "-";
            txtDPRider.Text = "-";
            txtDPSex.Text = "-";
            txtDPSmoker.Text = "-";
            txtDPTempAditional.Text = "-";
        }

        private void ShowPdf(byte[] docFile)
        {
            pdfDocuments.PdfSourceBytes = docFile;
            pdfDocuments.DataBind();
        }

        protected void fuPopDocuments_OnFileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}