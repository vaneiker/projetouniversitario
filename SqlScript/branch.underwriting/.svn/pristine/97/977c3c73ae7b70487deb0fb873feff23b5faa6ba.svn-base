using AjaxControlToolkit;
using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Case.UserControls.Beneficiaries;
using WEB.UnderWriting.Case.UserControls.PersonalData;
using WEB.UnderWriting.Case.UserControls.Summary;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Common
{
    public partial class Left : UC, IUC
    {
        //IContact ContactManager
        //{
        //    get { return diManager.ContactManager; }
        //}

        //IPolicy PolicyManager
        //{
        //    get { return diManager.PolicyManager; }
        //}

        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        Contact _contact = new Contact();
        readonly DropDownManager DropDowns = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            //End deshabilitar tabs 
            pdfViewerSummary.LicenseKey = Service.PdfViewerKey;

            //Setting Beneficiaries UserControls
            UCMainBeneficiaries.UcContingentBeneficiarie = UCContingentBeneficiaries;
            UCAddtionalInsuranceMainBeneficies.UcContingentBeneficiarie = UCAddtionalContingentBeneficies;
           
        }

        /// <summary>
        /// Marcar el Tab Seleccionado el metodo recibe un Objeto de tipo LinkButton
        /// y toma de el el id y el text ademas de el nombre del tab
        /// Author: Lic. Carlos Ml. Lebron
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SelectCurrentTab(object sender, EventArgs e)
        {
            if (Tools.IsSessionExpired())
                return;

            
            //Obtener el Current Tab
            var selectTab = ((LinkButton)sender);


            if (selectTab.ID.ToLower().Trim() != "lnkbeneficiaries")
            {
                //Si esta en el tab de "Beneficiaries" valido que todos los tipos de beneficiarios tengan 100% para poder cambiar de Tab
                var currentTabName = hfMenuCasesLeft.Value.Split('|').Any() ? hfMenuCasesLeft.Value.Split('|')[0] : "";
                if (currentTabName.ToLower() == "beneficiaries" || currentTabName.ToLower() == "beneficiarios")
                {
                    var message = "";

                    if (!UCMainBeneficiaries.CompletedData())
                    {
                        message = "Please complete the list of Insured Main Beneficiaries, please verify and try again.";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Incomplete Beneficiaries Data');", true);
                        return;
                    }
                    if (!UCAddtionalInsuranceMainBeneficies.CompletedData() && liAddBInsuredMain.Attributes["style"] != "display: none;")
                    {
                        message = "Please complete the list of Additional Insured Main Beneficiaries, please verify and try again.";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Incomplete Beneficiaries Data');", true);
                        return;
                    }
                }
            }
            //Fin Validación

            var Tab = string.Empty;

            switch (selectTab.ID)
            {
                case "lnkPersonalData":
                    Tab = "PersonalData";
                    hfPolicyPlanDataAccordeon.Value = "";
                    break;
                case "lnkPolicyPlanData": Tab = "PolicyPlanData"; break;
                case "lnkPayments": 
					Tab = "Payments";
					bool display = Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance;
					this.ExcecuteJScript("$('#liPaymentHistory, #liCurrentPremium, #liPremiumHistory').css('display', '" + (display ? "block" : "none") + "');");
					break;
                case "lnkRayders": Tab = "Rayders"; break;
                case "lnkBeneficiaries": Tab = "Beneficiaries"; break;
                case "lnkRequirements": Tab = "Requirements"; break;
                case "lnkMedicalInfo": Tab = "MedicalInfo"; break;
                case "lnkActivitiesFinancial": Tab = "ActivitiesFinancial"; break;
                case "lnkSummary": Tab = "Summary"; break;
                case "lnkExceptions": Tab = "Exceptions"; break;
            }

            hfMenuCasesLeft.Value = Tab + "|" + selectTab.ID + "|" + selectTab.Text.Trim();

            clearData();
            FillData();
        }

        void IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            var selectedTab = hfMenuCasesLeft.Value.Split('|');

            if (!selectedTab.Any()) return;
            switch (selectedTab[0])
            {
                case "PersonalData":
                    UCPersonalDataContainer.save();
                    break;
                case "PolicyPlanData":
                    UCPolicyPlanDataContainer.save();
                    break;
                case "Payments":
                    UCPaymentInformation.save();
                    break;
                case "Rayders":
                    UCRiderInformation.save();
                    break;
                case "Beneficiaries":
                    UCMainBeneficiaries.save();
                    UCContingentBeneficiaries.save();
                    UCAddtionalInsuranceMainBeneficies.save();
                    UCAddtionalContingentBeneficies.save();
                    //UCBAddresses.save(); not implemented yet
                    //UCBEmailPhone.save(); not implemented yet
                    break;
                case "Requirements":
                    UCRequimentInformation.save();
                    break;
                case "MedicalInfo":
                    UCHealtDeclaration.save();
                    break;
                case "ActivitiesFinancial":
                    UCFinancialInfo.save();
                    break;
                case "Summary":
                    UCSummary.save();
                    break;
            }
        }

        void IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void IUC.edit()
        {
            throw new NotImplementedException();
        }
        public void FillData()
        {
            var productFamily = Service.GetProductFamily();			
			lnkBeneficiaries.Text = productFamily == Tools.EFamilyProductType.Funeral ? "CLAIMANTS" : 
									productFamily == Tools.EFamilyProductType.HealthInsurance ? "DEPENDENT" : "BENEFICIARIES";

            var selectedTab = hfMenuCasesLeft.Value.Split('|');
            pnBtnSave.Visible = true;
            if (!selectedTab.Any()) return;
            switch (selectedTab[0])
            {
                case "Beneficiaries":

                    var hasAdditional = Service.AddInsuredContactId.HasValue;
                    var productIsFuneral = productFamily == Tools.EFamilyProductType.Funeral;
                    var productIsHealth = productFamily == Tools.EFamilyProductType.HealthInsurance;
                    var productIsLife = productFamily == Tools.EFamilyProductType.LifeInsurance;
                    liAddBInsuredMain.Attributes["style"] = !productIsFuneral ? (hasAdditional ? "display: block;" : "display: none;") : "display: none;";
                    liAddBInsuredContingent.Attributes["style"] = !productIsFuneral ? (hasAdditional ? "display: block;" : "display: none;") : "display: none;";
                    liAddInsuredContingent.Attributes["style"] = !productIsFuneral ? "display: block;" : "display: none;";
                    lblMainBenef.Text = productIsFuneral ? "CLAIMANTS" : "INSURED MAIN BENEFICIARIES";
                    if (productIsFuneral)
                    {
                        lblMainBenef.Text = "INSURED MAIN CLAIMANTS";
                        InsContBenef.Text = "INSURED CONTINGENT CLAIMANTS";
                        AddMainBenef.Text = "ADDITIONAL INSURED MAIN CLAIMANTS";
                        AddContBenefi.Text = "ADDITIONAL INSURED CONTINGENT CLAIMANTS";
                        EmailsPhones.Text = "EMAILS & PHONES FOR CLAIMANTS";
                        AddressesBenef.Text = "ADDRESSES FOR CLAIMANTS";
                 
                        
                    }

                    if (productIsHealth)
                    {
                        lblMainBenef.Text = "INSURED MAIN DEPENDENTS";
                        InsContBenef.Text = "INSURED CONTINGENT DEPENDENTS";
                        AddMainBenef.Text = "ADDITIONAL INSURED MAIN DEPENDENTS";
                        AddContBenefi.Text = "ADDITIONAL INSURED CONTINGENT DEPENDENTS";
                        EmailsPhones.Text = "EMAILS & PHONES FOR DEPENDENTS";
                        AddressesBenef.Text = "ADDRESSES FOR DEPENDENTS";
                    
                    }
   

                    //1 - Insured Main
                    UCMainBeneficiaries.FillData("1");

                    if (!productIsFuneral)
                        //3 - Additional Insured Main
                        UCAddtionalInsuranceMainBeneficies.FillData("3");
                    break;

                case "Rayders":
                    UCRiderInformation.FillData();
                    pnBtnSave.Visible = false;
                    break;

                case "Summary":
                    var comments = Services.PolicyManager.GetCommentSummary(Service.Corp_Id,
																		    Service.Region_Id,
																			Service.Country_Id,
																			Service.Domesticreg_Id,
																			Service.State_Prov_Id,
																			Service.City_Id,
																			Service.Office_Id,
																			Service.Case_Seq_No,
																			Service.Hist_Seq_No);

                    UCSummary.fillDdl();
                    UCSummary.fillData();
                    rptComments.DataSource = comments;
                    rptComments.DataBind();
                    pnBtnSave.Visible = false;
                    break;

                case "MedicalInfo":
                    UCHealtDeclaration.fillDdl();
                    UCHealtDeclaration.fillData();
                    break;
                case "PolicyPlanData":
                    UCPolicyPlanDataContainer.FillData();
                    break;
                case "Payments":
                    UCPaymentInformation.FillData();

					if (Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance)
					{						
						UCPaymentHistory.FillPayments();
						UCPaymentCurrentPremium.FillData();
						UCPaymentPremiumHistory.FillData();
					}

                    pnBtnSave.Visible = false;
                    break;
                case "Requirements":
                    UCRequimentInformation.FillData();
                    break;
                case "PersonalData":
                    UCPersonalDataContainer.FillData(null, true);
                    UCLeftbtnPreviewId.Visible = pdfViewerSummary.PdfSourceBytes != null;
                    break;

                case "Exceptions":
                    UCOtherExceptions.FillData();
                    UCExceptions.FillData();
                    break;
                case "ActivitiesFinancial":
                    UCFinancialInfo.FillData();
                    UCAllFinancialInformationReceived.FillData();
                    UCActivities.FillData();
					UCActivities.FillAvocations();
                    break;

                default:
                    break;
            }
        }

        protected void BTNSaveTabs_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void SummaryRoleDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SummaryRoleDDL.SelectedValue == "-1") return;
            FillSummaryData(Convert.ToInt32(this.SummaryRoleDDL.SelectedValue.Split('|')[0]));
        }

        protected void LoadPdf_Click(object sender, EventArgs e)
        {
            var pdfButton = (Button)sender;

            var key = pdfButton.Attributes["data-PdfKey"].Split('|');
            UCPersonalDataContainer.GetPdf(Convert.ToInt32(key[0]), Convert.ToInt32(key[1]), Convert.ToInt32(key[2]));
        }

        public void FillSummaryData(int contactId)
        {
            _contact = Services.ContactManager.GetContactSummary(Service.Corp_Id, 
																 Service.Region_Id, 
																 Service.Country_Id, 
																 Service.Domesticreg_Id,
																 Service.State_Prov_Id, 
																 Service.City_Id, 
																 Service.Office_Id, 
																 Service.Case_Seq_No,
               Service.Hist_Seq_No, contactId, null);

            if (_contact != null)
            {
                SummaryFirstNameTxt.Text = _contact.FirstName;
                SummaryLastNameTxt.Text = _contact.FirstLastName;
                SummaryMiddleNameTxt.Text = _contact.MiddleName;
                SummarySecondLastNameTxt.Text = _contact.SecondLastName;
                SummaryDOBTxt.Text = _contact.Dob.HasValue ? _contact.Dob.Value.ToString("MM/dd/yyyy") : "";
                SummaryAgeTxt.Text = _contact.Age.ToString();
                SummaryNearAgeTxt.Text = _contact.NearAge.ToString();
                SummaryType.Text = _contact.ContactTypeDescription;
            }

            ((UCPersonalData)UCPersonalDataContainer.FindControl("UCPersonalData1")).GetPdfDocumentList(true, contactId, 0);
        }

        public void FillSummaryDdl()
        {
            var summaryRoleData = DropDowns.GetDropDown(DropDownType.Summary, 
														Service.Corp_Id, 
														Service.Region_Id, 
														Service.Country_Id,
														Service.Domesticreg_Id, 
														Service.State_Prov_Id, 
														Service.City_Id, 
														Service.Office_Id, 
														Service.Case_Seq_No,
														Service.Hist_Seq_No, 
														Service.Contact_Id, 
														null, 
														projectId: Service.ProjectId, 
														companyId: Service.CompanyId, 
														languageId: Service.LanguageId
													   ).OrderBy(r => int.Parse(r.Value.Split('|')[1]));

            SummaryRoleDDL.DataSource = summaryRoleData;
            SummaryRoleDDL.DataBind();

            SummaryRoleDDL_SelectedIndexChanged(null, null);
        }

        public void clearData()
        {
            // --- Beneficiaries Tab ---
            //Insured Main
            UCMainBeneficiaries.clearData();

            //Insured Contingent
            UCContingentBeneficiaries.clearData();

            //Additional Insured Main
            UCAddtionalInsuranceMainBeneficies.clearData();

            //Additional Insured Contingent)
            UCAddtionalContingentBeneficies.clearData();

            UCRiderInformation.clearData();
            UCPersonalDataContainer.clearData();
            //UCPolicyPlanDataContainer.clearData();
            //UCRiderInformation.clearData();
            UCPaymentInformation.clearData();
        }

        public void SelectPersonalData()
        {
            hfMenuCasesLeft.Value = "PersonalData|lnkPersonalData|PERSONAL DATA";

            clearData();
            FillData();
        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null) return;
            var comment = (Policy.PolicyCommentSummary)e.Item.DataItem;
            var userControl = (UCUnderwritingComments)e.Item.FindControl("UCUnderwritingComments");
            userControl.FillData(comment.NoteDesc);
        }

        protected void lnkAddNewNote_Click(object sender, EventArgs e)
        {
            var rightControl = this.Page.Master.FindControl("Right").FindControl("Right");
            var currentTab = rightControl.FindControl("hfMenuCasesRight") as HiddenField;
            var hdnFromLeft = rightControl.FindControl("hdnNoteFromLeft") as HiddenField;
            currentTab.Value = "notes|lnkNoteComments|NOTES";
            hdnFromLeft.Value = "true";
            ((Right)rightControl).FillData();
        }

        protected void btnTeamCommunicationPop_Click(object sender, EventArgs e)
        {

            UCPopTeamCommunication.FillData();
            UCPopTeamCommunication.FillDrop();
        }

        protected void UCLeftbtnPreviewId_Click(object sender, EventArgs e)
        {
            var modalPopUp = (ModalPopupExtender)this.Page.Master.FindControl("mpPdfViewer");
            var popUp = ((UCShowPDFPopup)Page.Master.FindControl("UCShowPDFPopup"));

            if (modalPopUp == null || popUp == null) return;
            popUp.LoadPDFPreview(pdfViewerSummary.PdfSourceBytes);
            modalPopUp.Show();
            this.ExcecuteJScript("$(\"#UCShowPDFPopup_upPaymentPdfViewer\").append(CreateNewPopFrame())");
        }
    }
}