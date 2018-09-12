using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall.UserControls.History
{
    public partial class UCPolicyDetails : UC
    {

        #region Methods

        public DataTable DataAmountsAndPeriods
        {
            get
            {
                var data = Session["UCPolicyDetails.DataAmountsAndPeriods"];
                return data != null ? (DataTable)Session["UCPolicyDetails.DataAmountsAndPeriods"] : null;
            }
            set
            {
                Session["UCPolicyDetails.DataAmountsAndPeriods"] = value;
            }
        }

        public string ToTitleCase(string strX)
        {
            string[] aryWords = strX.Trim().Split(' ');

            List<string> lstLetters = new List<string>();
            List<string> lstWords = new List<string>();

            foreach (string strWord in aryWords)
            {
                int iLCount = 0;
                foreach (char chrLetter in strWord.Trim())
                {
                    if (iLCount == 0)
                    {
                        lstLetters.Add(chrLetter.ToString().ToUpper());
                    }
                    else
                    {
                        lstLetters.Add(chrLetter.ToString().ToLower());
                    }
                    iLCount++;
                }
                lstWords.Add(string.Join("", lstLetters));
                lstLetters.Clear();
            }

            string strNewString = string.Join(" ", lstWords);

            return strNewString;
        }

        public static string GetAge(DateTime? birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Value.Year;
            if (now < birthday.Value.AddYears(age)) age--;

            return age.ToString();
        }

        public string ChangeMethodPayment(string args)
        {
            string rs = string.Empty;
            if (string.IsNullOrEmpty(args)) return rs;

            string[] datos = args.Split(',');
            if (datos.Length > 0)
            {
                foreach (string dt in datos)
                {
                    rs += ResourcesProvider.GetString(dt.Replace(" ", "")) + ",";
                }
            }
            else
            {
                rs = args;
            }

            return rs.Trim(',');
        }
        //

        public object GetAmountsAndPeriods(DataTable data)
        {
            return data;
        }

        public void FillPolicyDetail()
        {
            llenaPoliciesPersonal();
            FillBeneficiarios();
            FillRiders();
            FillAdditionalFamilyInsurance();
            grdOtherProduct.DataBind();
        }

        public IEnumerable<Policy.ProductByContact> GetOtherProduct(WEB.ConfirmationCall.Common.ContactType contactType, int contactId)
        {
            int? contactTypeId = contactType == WEB.ConfirmationCall.Common.ContactType.None ? null : (int?)contactType;
            return _services.oPolicyManager.GetProductByContactAndRole(contactTypeId, contactId, UserDataProvider.LanguageId).Distinct();

        }

        static String FillNA(String StringData)
        {
            return !String.IsNullOrWhiteSpace(StringData) ? StringData : "N/A";
        }


        void llenaPoliciesPersonal()
        {
            try
            {
                var lstPolicies = _services.oPolicyManager.GetPlanData(_services.Corp_Id, _services.Region_Id, _services.Country_Id, _services.Domesticreg_Id,
                    _services.State_Prov_Id, _services.City_Id, _services.Office_Id, _services.Case_Seq_No, _services.Hist_Seq_No);

                tbPolicy.Text = lstPolicies.PolicyNo;

                //age insurend
                tbAgeInsure.Text = (lstPolicies.InsuredDob != null ? GetAge(lstPolicies.InsuredDob.Value) : "");
                tbOwnerAge.Text = (lstPolicies.OwnerDob != null ? GetAge(lstPolicies.OwnerDob.Value) : "");
                tbAgeInsureAdd.Text = (lstPolicies.InsuredAddDob != null ? GetAge(lstPolicies.InsuredAddDob.Value) : "");

                int age = 0;

                if (tbAgeInsure.Text.Length > 0)
                {
                    age = Convert.ToInt32(tbAgeInsure.Text);

                    if (age <= 18)
                    {
                        txtMessageAgeInsure.Visible = true;
                        txtMessageAgeInsure.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.InsuredAgeAlert;
                    }
                    else
                    {
                        txtMessageAgeInsure.Visible = false;
                    }

                }


                tbOwner.Text = lstPolicies.OwnerName;
                tbInsuredNade.Text = lstPolicies.InsuredName;
                tbPlanName.Text = lstPolicies.PlanName;
                //tbPlanType.Text = lstPolicies.PlanType;
                tbPlanType.Text = ResourcesProvider.GetString(lstPolicies.PlanType.Replace(" ", ""));

                tbAdditionalIInsured.Text = FillNA(lstPolicies.AdditionalInsured);
                tbPolicyStatus.Text = ResourcesProvider.GetString(ToTitleCase(lstPolicies.PolicyStatus));
                tbOffice.Text = lstPolicies.OfficeDesc;
                tbAgents.Text = lstPolicies.AgentFullName;
                tbCountry.Text = lstPolicies.CountryOfficeDesc;
                decimal primaItebis = 0;
                if (lstPolicies.AnnualPremium != null)
                {
                    decimal itebis = Utility.GetItbis();
                    decimal monto = lstPolicies.AnnualPremium.GetValueOrDefault();
                    decimal totalItebis = (monto * itebis);
                    primaItebis = monto + totalItebis;
                }

                //tbAbual.Text = lstPolicies.AnnualPremium.GetValueOrDefault().ToFormatCurrency();                
                tbAbual.Text = primaItebis.ToFormatCurrency();


                tbMinimum.Text = lstPolicies.AnnualPremium.GetValueOrDefault().ToFormatCurrency();
                //tbMinimum.Text = lstPolicies.MinAnnualPremium.GetValueOrDefault().ToFormatCurrency();
                tbTrget.Text = lstPolicies.TargetPremium.GetValueOrDefault().ToFormatCurrency();
                tbInitialContribution.Text = lstPolicies.InitialContribution.GetValueOrDefault().ToFormatCurrency();
                tbFrecuncy.Text = ResourcesProvider.GetString(lstPolicies.PaymentFreqTypeDesc);
                tbFuturePayment.Text = lstPolicies.FuturePayment.GetValueOrDefault().ToFormatCurrency();

                tbMethodPayment.Text = ChangeMethodPayment(lstPolicies.PaymentMethod);
                tbMethoDetail.Text = ChangeMethodPayment(lstPolicies.DetailMethod);

                tbPaymentEstatus.Text = ResourcesProvider.GetString(lstPolicies.PaymentStatusDesc);
                tbExpiration.Text = lstPolicies.ExpiredDate.HasValue ? lstPolicies.ExpiredDate.ToString() : "N/A";
                tbCurrecny.Text = lstPolicies.Currency;


                /*primaItebis = 0;
                if (lstPolicies.PeriodicPremium != null)
                {
                    decimal itebis = Utility.GetItbis();
                    decimal monto = lstPolicies.PeriodicPremium.GetValueOrDefault();
                    decimal totalItebis = (monto * itebis);
                    primaItebis = monto + totalItebis;
                }
                tbModalPremium.Text = primaItebis.ToFormatCurrency();*/
                tbModalPremium.Text = lstPolicies.PeriodicPremium.GetValueOrDefault().ToFormatCurrency();

                tbInvesment.Text = FillNA(lstPolicies.ProfileTypeDesc);
                tbPensioner.Text = FillNA(lstPolicies.DesignatedPensionerName);

                DataTable AmountAndPeriods = new DataTable("AmountAndPeriods");
                AmountAndPeriods.Columns.Add("InsuredPeriod");
                AmountAndPeriods.Columns.Add("InsuredAmount");
                AmountAndPeriods.Columns.Add("DefermentPeriod");
                AmountAndPeriods.Columns.Add("ContributionPeriod");
                AmountAndPeriods.Columns.Add("RetirementPeriod");
                AmountAndPeriods.Columns.Add("RetirementAmount");
                AmountAndPeriods.Columns.Add("RopAmount");
                DataRow tempRow = AmountAndPeriods.NewRow();
                tempRow["InsuredPeriod"] = lstPolicies.InsuredPeriod != null ? lstPolicies.InsuredPeriod.ToString() : "N/A";
                tempRow["InsuredAmount"] = lstPolicies.InsuredAmount != null ? lstPolicies.InsuredAmount.GetValueOrDefault().ToFormatCurrency() : "N/A";
                tempRow["DefermentPeriod"] = lstPolicies.DefermentPeriod != null ? lstPolicies.DefermentPeriod.ToString() : "N/A";
                tempRow["ContributionPeriod"] = lstPolicies.ContributionPeriod != null ? lstPolicies.ContributionPeriod.ToString() : "N/A";
                tempRow["RetirementPeriod"] = lstPolicies.RetirementPeriod != null ? lstPolicies.RetirementPeriod.ToString() : "N/A";
                tempRow["RetirementAmount"] = lstPolicies.RetirementAmount != null ? lstPolicies.RetirementAmount.GetValueOrDefault().ToFormatCurrency() : "N/A";
                tempRow["RopAmount"] = lstPolicies.RopAmount != null ? lstPolicies.RopAmount.GetValueOrDefault().ToFormatCurrency() : "N/A";
                AmountAndPeriods.Rows.Add(tempRow);
                //GrdAmountPeriods.DataSource.AddRow()
                DataAmountsAndPeriods = AmountAndPeriods;
                GrdAmountsAndPeriods.DataBind();

                FillIdPersonal();
            }
            catch (Exception ex)
            {
                string parameter = "";

                ConfirmationCallLog.Log("llenaPoliciesPersonal", ex.Message, parameter, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());

            }
        }

        void FillAdditionalFamilyInsurance()
        {

            var lstAdditionalFamilyInsurance = _services.oPolicyManager.GetPolicyAddInsured(new Policy.Parameter()
            {
                CorpId = _services.Corp_Id,
                RegionId = _services.Region_Id,
                CountryId = _services.Country_Id,
                DomesticregId = _services.Domesticreg_Id,
                StateProvId = _services.State_Prov_Id,
                CityId = _services.City_Id,
                OfficeId = _services.Office_Id,
                CaseSeqNo = _services.Case_Seq_No,
                HistSeqNo = _services.Hist_Seq_No,
                LanguageId = UserDataProvider.LanguageId
            });

            rptAdditionalFamilyInsurance.DataSource = lstAdditionalFamilyInsurance.ToList();
            rptAdditionalFamilyInsurance.DataBind();
        }

        void FillBeneficiarios()
        {
            var isInsured = _services.Current_Contact_Type_Id == WEB.ConfirmationCall.Common.ContactType.Insured;

            var lista = _services.oBeneficiaryManager.GetAllBeneficiary(_services.Corp_Id, _services.Region_Id, _services.Country_Id, _services.Domesticreg_Id, _services.State_Prov_Id, _services.City_Id, _services.Office_Id, _services.Case_Seq_No, _services.Hist_Seq_No, isInsured, 1, null, UserDataProvider.LanguageId).ToList();
            lista.AddRange(_services.oBeneficiaryManager.GetAllBeneficiary(_services.Corp_Id, _services.Region_Id, _services.Country_Id, _services.Domesticreg_Id, _services.State_Prov_Id, _services.City_Id, _services.Office_Id, _services.Case_Seq_No, _services.Hist_Seq_No, isInsured, 2, null, UserDataProvider.LanguageId).ToList());
            //dgBeneficiarios.DataSource = Benificiario.GetAllBeneficiary(service.Corp_Id, service.Region_Id, service.Country_Id, service.Domesticreg_Id, service.State_Prov_Id, service.City_Id, service.Office_Id, service.Case_Seq_No, service.Hist_Seq_No, paran_InsuredContactId, 1, 155538);

            gvBeneficiaries.DataSource = lista;
            gvBeneficiaries.DataBind();

        }

        void FillRiders()
        {

            gvRiders.DataSource = _services.oRiderManager.GetAllRider(
                new Policy.Parameter()
                {
                    CorpId = _services.Corp_Id,
                    RegionId = _services.Region_Id,
                    CountryId = _services.Country_Id,
                    DomesticregId = _services.Domesticreg_Id,
                    StateProvId = _services.State_Prov_Id,
                    CityId = _services.City_Id,
                    OfficeId = _services.Office_Id,
                    CaseSeqNo = _services.Case_Seq_No,
                    HistSeqNo = _services.Hist_Seq_No,
                    LanguageId = UserDataProvider.LanguageId
                });
            gvRiders.DataBind();
        }

        void FillIdPersonal()
        {
            try
            {

                var document = _services.oPolicyManager.GetIdCopyRequirement(new Entity.UnderWriting.Entities.Requirement
                {
                    CorpId = _services.Corp_Id,
                    RegionId = _services.Region_Id,
                    CountryId = _services.Country_Id,
                    DomesticregId = _services.Domesticreg_Id,
                    StateProvId = _services.State_Prov_Id,
                    CityId = _services.City_Id,
                    OfficeId = _services.Office_Id,
                    CaseSeqNo = _services.Case_Seq_No,
                    HistSeqNo = _services.Hist_Seq_No,
                    ContactId = (int)_services.Current_Contact_Id
                });

                if (document == null) return;

                var contactIdentficationDocument = _services.oRequirementManager.GetDocument(
                document.CorpId, document.RegionId, document.CountryId, document.DomesticregId, document.StateProvId, document.CityId, document.OfficeId,
                document.CaseSeqNo, document.HistSeqNo, document.ContactId, document.RequirementCatId, document.RequirementTypeId, document.RequirementId, document.RequirementDocId);

                if (contactIdentficationDocument.DocumentBinary != null)
                {
                    pdfViewerPersonalData.PdfSourceBytes = contactIdentficationDocument.DocumentBinary;
                    pdfViewerPersonalData.DataBind();
                }

            }
            catch (Exception ex)
            {

                string parameter = "";

                ConfirmationCallLog.Log("FillIdPersonal", ex.Message, parameter, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());

            }

        }



        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerPersonalData.LicenseKey = ConfigurationManager.AppSettings["PDFViewer"];
            if (!IsPostBack)
            {
            }
        }

        protected void dsOtherProduct_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["contactType"] = WEB.ConfirmationCall.Common.ContactType.None;
            e.InputParameters["contactId"] = _services.Current_Contact_Id;
        }

        protected void dsAmountsAndPeriods_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataAmountsAndPeriods;
        }

        #endregion


        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {

            Utility.TranslateColumnsAspxGrid(this.GrdAmountsAndPeriods);
            //
            Utility.TranslateColumnsAspxGrid(this.gvBeneficiaries);
            //
            Utility.TranslateColumnsAspxGrid(grdOtherProduct);



            //BtnAddAddress.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Add;
            //BtnCancelAddress.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Cancel;
        }

        protected void UCPersonalDataPreviewBtn_Click(object sender, EventArgs e)
        {
            var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("mpPdfViewer");
            var popUp = ((Common.UCPDFPopup)Page.Master.FindControl("UCPDFPopup"));

            if (ModalPopUp != null && popUp != null)
            {
                popUp.LoadPDFPreview(pdfViewerPersonalData.PdfSourceBytes);
                ModalPopUp.Show();
                this.ExcecuteJScript("$(\"#UCShowPDFPopup_upPaymentPdfViewer\").append(CreateNewPopFrame())");
            }
        }


    }
}