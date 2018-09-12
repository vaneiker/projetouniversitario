using PdfViewer4AspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Payments
{
    public partial class UCPaymentInformation : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        string policy
        {
            get { return hfPolicy.Value; }
            set { hfPolicy.Value = value; }
        }

        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        Entity.UnderWriting.Entities.Payment ContactPayment = new Entity.UnderWriting.Entities.Payment();

        DropDownManager DropDowns = new DropDownManager();

        WEB.UnderWriting.Common.SessionList datos = new WEB.UnderWriting.Common.SessionList();

        //IPayment PaymentManager
        //{
        //    get { return diManager.PaymentManager; }
        //}


        protected void Page_PreRender(object sender, EventArgs e)
        {
            divPreAut.Visible = divfreMet.Visible = Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {

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

            ContactPayment = Services.PaymentManager.GetPaymentHeader(Service.Corp_Id,
                                                                      Service.Region_Id,
                                                                      Service.Country_Id,
                                                                      Service.Domesticreg_Id,
                                                                      Service.State_Prov_Id,
                                                                      Service.City_Id,
                                                                      Service.Office_Id,
                                                                      Service.Case_Seq_No,
                                                                      Service.Hist_Seq_No);

            DropDowns.GetDropDown(ref OwnerOtherPolicuesDDL,
                                  "All",
                                  Language.English,
                                  DropDownType.OwnerPolicy,
                                  corpId: Service.Corp_Id,
                                  regionId: Service.Region_Id,
                                  countryId: Service.Country_Id,
                                  domesticregId: Service.Domesticreg_Id,
                                  stateProvId: Service.State_Prov_Id,
                                  cityId: Service.City_Id,
                                  officeId: Service.Office_Id,
                                  caseSeqNo: Service.Case_Seq_No,
                                  histSeqNo: Service.Hist_Seq_No,
                                  contactId: Service.Contact_Id,
                                  projectId: Service.ProjectId,
                                  companyId: Service.CompanyId);

            DropDowns.GetDropDown(ref ViewDDL,
                                  "All Payments",
                                  Language.English,
                                  DropDownType.PaymentStatus,
                                  Service.Corp_Id,
                                  projectId: Service.ProjectId,
                                  companyId: Service.CompanyId);

            if (ContactPayment == null)
            {
                Block1MonthsRepeater.DataSource = null;
                Block1MonthsRepeater.DataBind();

                Block2MonthsRepeater.DataSource = null;
                Block2MonthsRepeater.DataBind();
            }
            else
            {
                AnnualPremiumTxt.Text = Convert.ToDecimal(ContactPayment.AnnualPremium).ToString("#,##0.00");
                PeriodicPremiumTxt.Text = Convert.ToDecimal(ContactPayment.PeriodicPremium).ToString("#,##0.00"); ;
                MinMonthlyPremiumTxt.Text = Convert.ToDecimal(ContactPayment.MinimunPremiunAmountMonth).ToString("#,##0.00");
                PaymentFrequencyTxt.Text = ContactPayment.PaymentFreqTypeDesc;
                MinAnnualPremiumTxt.Text = Convert.ToDecimal(ContactPayment.MinimunPremiunAmountAnnual).ToString("#,##0.00");
                PolicyYearTxt.Text = ContactPayment.PolicyYear.ToString();
                PremiumReceivedTxt.Text = Convert.ToDecimal(ContactPayment.PremiumRecieved).ToString("#,##0.00");
                InitialContributionTxt.Text = Convert.ToDecimal(ContactPayment.InitialContribution).ToString("#,##0.00");
                AccountValueTxt.Text = Convert.ToDecimal(ContactPayment.AccountAmount).ToString("#,##0.00");
                EfectiveDateTxt.Text = ContactPayment.PolicyEffectiveDate == null ? "" : Convert.ToDateTime(ContactPayment.PolicyEffectiveDate).ToString("MM/dd/yyyy");

                PaymentPlan.Text = ContactPayment.PaymentPlan;
                AmountTxt.Text = Convert.ToDecimal(ContactPayment.PaymentAmount).ToString("#,##0.00");
                StartDateTxt.Text = Convert.ToDateTime(ContactPayment.PaymentPlanStartDate).ToString("MM/dd/yyyy");
                EndDate.Text = Convert.ToDateTime(ContactPayment.PaymentPlanEndDate).ToString("MM/dd/yyyy");
                PaymentFrequencyPlanTxt.Text = ContactPayment.PaymentFreqTypeDesc;

                Tools.SelectIndexByValue(ref OwnerOtherPolicuesDDL,
                                         ContactPayment.CorpId + "|" +
                                         ContactPayment.RegionId + "|" +
                                         ContactPayment.CountryId + "|" +
                                         ContactPayment.DomesticregId + "|" +
                                         ContactPayment.StateProvId + "|" +
                                         ContactPayment.CityId + "|" +
                                         ContactPayment.OfficeId + "|" +
                                         ContactPayment.CaseSeqNo + "|" +
                                         ContactPayment.HistSeqNo,
                                         false);

                Block1MonthsRepeater.DataSource = ContactPayment.Periods.Take(6).ToList();
                Block1MonthsRepeater.DataBind();

                Block2MonthsRepeater.DataSource = ContactPayment.Periods.Skip(6).Take(6).ToList();
                Block2MonthsRepeater.DataBind();
            }

            FillPaymentInformationData();
            OwnerOtherPolicuesDDL.SelectedIndex = -1;
        }

        protected void OwnerOtherPolicuesDDL_SelectedIndexChanged(Object sender, EventArgs e)
        {
            hfPolicy.Value = (OwnerOtherPolicuesDDL.SelectedValue == "-1") ? hfPolicy.Value = "" : OwnerOtherPolicuesDDL.SelectedValue;
            FillPaymentInformationData();
        }

        protected void ViewDDL_SelectedIndexChanged(Object sender, EventArgs e)
        {

            FillPaymentInformationData();
        }

        public void clearData()
        {
            //gvPaymentInfo = null;
            AnnualPremiumTxt.Text = string.Empty;
            PeriodicPremiumTxt.Text = string.Empty;
            MinMonthlyPremiumTxt.Text = string.Empty;
            PaymentFrequencyTxt.Text = string.Empty;
            MinAnnualPremiumTxt.Text = string.Empty;
            PolicyYearTxt.Text = string.Empty;
            PremiumReceivedTxt.Text = string.Empty;
            InitialContributionTxt.Text = string.Empty;
            AccountValueTxt.Text = string.Empty;
            EfectiveDateTxt.Text = string.Empty;
            PaymentPlan.Text = string.Empty;
            AmountTxt.Text = string.Empty;
            StartDateTxt.Text = string.Empty;
            EndDate.Text = string.Empty;
            PaymentFrequencyPlanTxt.Text = string.Empty;
            OwnerOtherPolicuesDDL.Items.Clear();
            ViewDDL.Items.Clear();
            UCPdfViewer.LoadPdf(null);
        }

        private void FillPaymentInformationData()
        {
            bool display = Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance;
            this.ExcecuteJScript("$('#liPaymentHistory, #liCurrentPremium, #liPremiumHistory').css('display', '" + (display ? "block" : "none") + "');");

            IEnumerable<Entity.UnderWriting.Entities.Payment.Detail> Result;
            if (Service.Contact_Id != 0)
            {
                int Corp_Id = Service.Corp_Id;
                int Region_Id = Service.Region_Id;
                int Country_Id = Service.Country_Id;
                int Domesticreg_Id = Service.Domesticreg_Id;
                int State_Prov_Id = Service.State_Prov_Id;
                int City_Id = Service.City_Id;
                int Office_Id = Service.Office_Id;
                int Case_Seq_No = Service.Case_Seq_No;
                int Hist_Seq_No = Service.Hist_Seq_No;

                if (!String.IsNullOrEmpty(policy))
                {
                    string[] values = policy.Split('|');
                    Corp_Id = int.Parse(values[0]);
                    Region_Id = int.Parse(values[1]);
                    Country_Id = int.Parse(values[2]);
                    Domesticreg_Id = int.Parse(values[3]);
                    State_Prov_Id = int.Parse(values[4]);
                    City_Id = int.Parse(values[5]);
                    Office_Id = int.Parse(values[6]);
                    Case_Seq_No = int.Parse(values[7]);
                    Hist_Seq_No = int.Parse(values[8]);
                }

                Result = Services.PaymentManager.GetAllPaymentDetail(Corp_Id,
                                                                     Region_Id,
                                                                     Country_Id,
                                                                     Domesticreg_Id,
                                                                     State_Prov_Id,
                                                                     City_Id,
                                                                     Office_Id,
                                                                     Case_Seq_No,
                                                                     Hist_Seq_No,
                                                                     OwnerOtherPolicuesDDL.SelectedValue == "-1" ? (int?)null : Service.Contact_Id,
                                                                     ViewDDL.SelectedValue != "-1" ? Convert.ToInt32(ViewDDL.SelectedValue.Split('|')[1]) : (int?)null);
            }
            else
            {
                Result = new List<Entity.UnderWriting.Entities.Payment.Detail>();
            }

            gvPaymentInfo.DataSource = Result;
            gvPaymentInfo.DataBind();

            setPagerIndex(gvPaymentInfo);

            if (gvPaymentInfo.BottomPagerRow != null)
            {
                var totalItems = (Literal)gvPaymentInfo.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = Result.ToList().Count + "";
            }

            UCPdfViewer.LoadPdf(null);
        }

        protected void gvPaymentInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentInfo.PageIndex = e.NewPageIndex;
            gvPaymentInfo.DataBind();
            FillPaymentInformationData();
            setPagerIndex(gvPaymentInfo);
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

        protected void LoadPdfFileBTN_Click(object sender, EventArgs e)
        {
            var lnk = (Button)sender;
            var dataRow = (GridViewRow)lnk.NamingContainer;

            int DocumentCategoryId = 0;
            int.TryParse(gvPaymentInfo.DataKeys[dataRow.RowIndex]["DocumentCategoryId"].ToString(), out DocumentCategoryId);
            int DocumentTypeId = 0;
            int.TryParse(gvPaymentInfo.DataKeys[dataRow.RowIndex]["DocumentTypeId"].ToString(), out DocumentTypeId);
            var DocumentId = 0;
            int.TryParse(gvPaymentInfo.DataKeys[dataRow.RowIndex]["DocumentId"].ToString(), out DocumentId);
                         
            string documentType = "D";
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
                HistSeqNo = Service.Hist_Seq_No
            };
            byte[] pdfOnBase = ServicesOn.ViewFileFromOnBase(Add,documentType, DocumentCategoryId, DocumentTypeId);

            if (pdfOnBase == null)
            {  
                Entity.UnderWriting.Entities.Payment.DocumentInfomation Document = Services.PaymentManager.GetDocument(
                                                        Service.Corp_Id,
                                                        Service.Region_Id,
                                                        Service.Country_Id,
                                                        Service.Domesticreg_Id,
                                                        Service.State_Prov_Id,
                                                        Service.City_Id,
                                                        Service.Office_Id,
                                                        Service.Case_Seq_No,
                                                        Service.Hist_Seq_No,
                                                        DocumentCategoryId,
                                                        DocumentTypeId,
                                                        DocumentId
                                                        );

                if (Document != null)
                {
                    ViewPdfFile(Document.DocumentBinary);
                }
                else
                {
                    string message = "This document has no attachment.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'FILE NOT FOUND');", true);
                }
            }
            else
            {
                ViewPdfFile(pdfOnBase);
            }

            bool display = Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance;
            this.ExcecuteJScript("$('#liPaymentHistory, #liCurrentPremium, #liPremiumHistory').css('display', '" + (display ? "block" : "none") + "');");
        }

        public void ViewPdfFile(byte[] pdfFile)
        {
            PdfViewer pdfViewerControl = (PdfViewer)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPdfViewer").FindControl("Viewer");
            pdfViewerControl.PdfSourceBytes = pdfFile;
            pdfViewerControl.DataBind();
            ((HiddenField)Page.Master.FindControl("Right").FindControl("Right").FindControl("hfMenuCasesRight")).Value = "pdfViewer";
        }
    }
}