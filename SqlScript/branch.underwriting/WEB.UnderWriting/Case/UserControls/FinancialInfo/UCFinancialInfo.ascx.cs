using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.FinancialInfo
{
    public partial class UCFinancialInfo : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {
        //IContact ContactManager
        //{
        //    get { return diManager.ContactManager; }
        //}
        //UnderWritingDIManager diManager = new UnderWritingDIManager();
        DropDownManager DropDowns = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void clearData()
        {
            txtFIOcupation.Text = "";
            txtFIPersonalIncome.Text = "";
            txtFIFamilyIncome.Text = "";

            txtFILineofBusiness.Text = "";
            txtFICompany.Text = "";
            txtFITaskPerformed.Text = "";
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            var saveContact = new Entity.UnderWriting.Entities.Policy.Contact();

            //Key
            saveContact.CorpId = Service.Corp_Id;
            saveContact.RegionId = Service.Region_Id;
            saveContact.CountryId = Service.Country_Id;
            saveContact.DomesticregId = Service.Domesticreg_Id;
            saveContact.StateProvId = Service.State_Prov_Id;
            saveContact.CityId = Service.City_Id;
            saveContact.OfficeId = Service.Office_Id;
            saveContact.CaseSeqNo = Service.Case_Seq_No;
            saveContact.HistSeqNo = Service.Hist_Seq_No;
            saveContact.ContactId = Service.Contact_Id;
            saveContact.ContactRoleTypeId = 1;//Role del Owner
            saveContact.UserId =  Service.Underwriter_Id;

            //Assets
            saveContact.AsstTotalAssets = decimal.Parse(String.IsNullOrWhiteSpace(txtFITotalAssets.Text) ? "0" : txtFITotalAssets.Text);
            saveContact.AsstRealEstate = decimal.Parse(String.IsNullOrWhiteSpace(txtFIRealEstate.Text) ? "0" : txtFIRealEstate.Text);
            saveContact.AsstPersonalEffects = decimal.Parse(String.IsNullOrWhiteSpace(txtFIPersonEffects.Text) ? "0" : txtFIPersonEffects.Text);
            saveContact.AsstVehicle = decimal.Parse(String.IsNullOrWhiteSpace(txtFIVehicle.Text) ? "0" : txtFIVehicle.Text);
            saveContact.AsstMachineryEqpmnt = decimal.Parse(String.IsNullOrWhiteSpace(txtFIMachineryEquip.Text) ? "0" : txtFIMachineryEquip.Text);
            saveContact.AsstStockBonds = decimal.Parse(String.IsNullOrWhiteSpace(txtFIStockAndBonds.Text) ? "0" : txtFIStockAndBonds.Text);
            saveContact.AsstOtherAssets = decimal.Parse(String.IsNullOrWhiteSpace(txtFIOtherAssets.Text) ? "0" : txtFIOtherAssets.Text);

            //Liabilities
            saveContact.LblTotalLiabilities = decimal.Parse(String.IsNullOrWhiteSpace(txtFITotalLiabilities.Text) ? "0" : txtFITotalLiabilities.Text);
            saveContact.LblMachineryEqpmnt = decimal.Parse(String.IsNullOrWhiteSpace(txtFIMachineryEquipLI.Text) ? "0" : txtFIMachineryEquipLI.Text);
            saveContact.LblNotePayable = decimal.Parse(String.IsNullOrWhiteSpace(txtFINotePlayable.Text) ? "0" : txtFINotePlayable.Text);
            saveContact.LblBankDebts = decimal.Parse(String.IsNullOrWhiteSpace(txtFIBankDebts.Text) ? "0" : txtFIBankDebts.Text);
            saveContact.LblPersonalDebts = decimal.Parse(String.IsNullOrWhiteSpace(txtFIPersonalDebts.Text) ? "0" : txtFIPersonalDebts.Text);
            saveContact.LblMortgageDebts = decimal.Parse(String.IsNullOrWhiteSpace(txtFIMortageDebts.Text) ? "0" : txtFIMortageDebts.Text);
            saveContact.LblOutstandingTaxes = decimal.Parse(String.IsNullOrWhiteSpace(txtFIOutstandingTaxes.Text) ? "0" : txtFIOutstandingTaxes.Text);
            saveContact.LblShortTermsLoans = decimal.Parse(String.IsNullOrWhiteSpace(txtFIShortTermLoans.Text) ? "0" : txtFIShortTermLoans.Text);
            saveContact.LblOtherLiabilities = decimal.Parse(String.IsNullOrWhiteSpace(txtFIOtherLiabilities.Text) ? "0" : txtFIOtherLiabilities.Text);

            //Financial Statements
            saveContact.FncTotalEstateAmnt = decimal.Parse(String.IsNullOrWhiteSpace(txtFITotalEstateAmount.Text) ? "0" : txtFITotalEstateAmount.Text);
            saveContact.FncAnnualRevMainActvt = decimal.Parse(String.IsNullOrWhiteSpace(txtFIAnnualRevMainAct.Text) ? "0" : txtFIAnnualRevMainAct.Text);
            saveContact.FncAnnualIncomeOtherJobs = decimal.Parse(String.IsNullOrWhiteSpace(txtFIAnnualInOtherJobs.Text) ? "0" : txtFIAnnualInOtherJobs.Text);
            saveContact.FncAnnualIncomeInvst = decimal.Parse(String.IsNullOrWhiteSpace(txtFIAnnualInInvestment.Text) ? "0" : txtFIAnnualInInvestment.Text);
            saveContact.FncAnnualIncomeTrade = decimal.Parse(String.IsNullOrWhiteSpace(txtFIAnnualInTrade.Text) ? "0" : txtFIAnnualInTrade.Text);

            saveContact.LaborPlayedId = int.Parse(rbtLaborPlayed.SelectedValue);
            saveContact.HomeStatusId = int.Parse(rbtHomeStatus.SelectedValue);

            Services.PolicyManager.UpdateActivitiesFinancial(saveContact);
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

            var contact = Services.PolicyManager.GetContactPolicy(Service.Corp_Id, 
                                                                  Service.Region_Id, 
                                                                  Service.Country_Id, 
                                                                  Service.Domesticreg_Id,
                                                                  Service.State_Prov_Id, 
                                                                  Service.City_Id, 
                                                                  Service.Office_Id, 
                                                                  Service.Case_Seq_No,
                                                                  Service.Hist_Seq_No, 
                                                                  null, 
                                                                  1).FirstOrDefault();

            clearData();

            IEnumerable<Entity.UnderWriting.Entities.Contact.Email> emailData;
            IEnumerable<Entity.UnderWriting.Entities.Contact.Address> addressData;
            IEnumerable<Entity.UnderWriting.Entities.Contact.Phone> phoneData;

            Services.ContactManager.GetCommunicatonAll(Service.Corp_Id, 
                                                       Service.Contact_Id,
                                                       Service.LanguageId, 
                                                       out addressData, 
                                                       out phoneData, 
                                                       out emailData);
            FillEmail(emailData.ToList());
            FillPhones(phoneData.ToList());
            FillAddress(addressData.ToList());

            txtFIPersonalIncome.Text = contact.AnnualPersonalIncome.GetValueOrDefault().ToString("#,##0.00");
            txtFIFamilyIncome.Text = contact.AnnualFamilyIncome.GetValueOrDefault().ToString("#,##0.00");
            txtFIFamilyIncomeM.Text = Math.Round((contact.AnnualFamilyIncome.GetValueOrDefault() / 12), 2).ToString("#,##0.00");
            txtFIPersonalIncomeM.Text = Math.Round((contact.AnnualPersonalIncome.GetValueOrDefault() / 12), 2).ToString("#,##0.00");

            txtFILineofBusiness.Text = contact.LineOfBusiness;
            txtFICompany.Text = contact.CompanyName;
            txtFITaskPerformed.Text = contact.Labortasks;

            //Financial Statement
            txtFITotalEstateAmount.Text = contact.FncTotalEstateAmnt.HasValue ? contact.FncTotalEstateAmnt.Value.ToString("N2") : "0.00";
            txtFIAnnualInOtherJobs.Text = contact.FncAnnualIncomeOtherJobs.HasValue ? contact.FncAnnualIncomeOtherJobs.Value.ToString("N2") : "0.00";
            txtFIAnnualInTrade.Text = contact.FncAnnualIncomeTrade.HasValue ? contact.FncAnnualIncomeTrade.Value.ToString("N2") : "0.00";
            txtFIAnnualRevMainAct.Text = contact.FncAnnualRevMainActvt.HasValue ? contact.FncAnnualRevMainActvt.Value.ToString("N2") : "0.00";
            txtFIAnnualInInvestment.Text = contact.FncAnnualIncomeInvst.HasValue ? contact.FncAnnualIncomeInvst.Value.ToString("N2") : "0.00";

            //Total Assets
            txtFITotalAssets.Text = contact.AsstTotalAssets.HasValue ? contact.AsstTotalAssets.Value.ToString("N2") : "0.00";
            txtFIPersonEffects.Text = contact.AsstPersonalEffects.HasValue ? contact.AsstPersonalEffects.Value.ToString("N2") : "0.00";
            txtFIMachineryEquip.Text = contact.AsstMachineryEqpmnt.HasValue ? contact.AsstMachineryEqpmnt.Value.ToString("N2") : "0.00";
            txtFIOtherAssets.Text = contact.AsstOtherAssets.HasValue ? contact.AsstOtherAssets.Value.ToString("N2") : "0.00";
            txtFIRealEstate.Text = contact.AsstRealEstate.HasValue ? contact.AsstRealEstate.Value.ToString("N2") : "0.00";
            txtFIVehicle.Text = contact.AsstVehicle.HasValue ? contact.AsstVehicle.Value.ToString("N2") : "0.00";
            txtFIStockAndBonds.Text = contact.AsstStockBonds.HasValue ? contact.AsstStockBonds.Value.ToString("N2") : "0.00";

            //Liabilities
            txtFITotalLiabilities.Text = contact.LblTotalLiabilities.HasValue ? contact.LblTotalLiabilities.Value.ToString("N2") : "0.00";
            txtFINotePlayable.Text = contact.LblNotePayable.HasValue ? contact.LblNotePayable.Value.ToString("N2") : "0.00";
            txtFIPersonalDebts.Text = contact.LblPersonalDebts.HasValue ? contact.LblPersonalDebts.Value.ToString("N2") : "0.00";
            txtFIOutstandingTaxes.Text = contact.LblOutstandingTaxes.HasValue ? contact.LblOutstandingTaxes.Value.ToString("N2") : "0.00";
            txtFIOtherLiabilities.Text = contact.LblOtherLiabilities.HasValue ? contact.LblOtherLiabilities.Value.ToString("N2") : "0.00";
            txtFIMachineryEquipLI.Text = contact.LblMachineryEqpmnt.HasValue ? contact.LblMachineryEqpmnt.Value.ToString("N2") : "0.00";
            txtFIBankDebts.Text = contact.LblBankDebts.HasValue ? contact.LblBankDebts.Value.ToString("N2") : "0.00";
            txtFIMortageDebts.Text = contact.LblMortgageDebts.HasValue ? contact.LblMortgageDebts.Value.ToString("N2") : "0.00";
            txtFIShortTermLoans.Text = contact.LblShortTermsLoans.HasValue ? contact.LblShortTermsLoans.Value.ToString("N2") : "0.00";

            //Fill Drops
            rbtHomeStatus.DataSource = DropDowns.GetDropDown(DropDownType.HomeStatus, 
                                                             Service.Corp_Id, 
                                                             projectId: Service.ProjectId, 
                                                             companyId: Service.CompanyId);
            rbtHomeStatus.DataBind();
            if (contact.HomeStatusId.HasValue)
            {
                rbtHomeStatus.SelectedValue = contact.HomeStatusId.ToString();
            }

            rbtLaborPlayed.DataSource = DropDowns.GetDropDown(DropDownType.LaborPlayed, 
                                                              corpId:Service.Corp_Id, 
                                                              projectId: Service.ProjectId, 
                                                              companyId: Service.CompanyId);
            rbtLaborPlayed.DataBind();
            if (contact.LaborPlayedId.HasValue)
            {
                rbtLaborPlayed.SelectedValue = contact.LaborPlayedId.ToString();
            }

			var occupations = DropDowns.GetDropDown(DropDownType.Occupation, 
                                                    corpId: Service.Corp_Id, 
                                                    projectId: Service.ProjectId, 
                                                    companyId: Service.CompanyId, 
                                                    languageId: Service.LanguageId);
            if (occupations != null && contact.OccupationId.HasValue)
            {
                txtFIOcupation.Text = occupations.First(r => r.Value == ((!contact.OccupGroupTypeId.HasValue ? "0" : contact.OccupGroupTypeId.ToString()) + "|" + contact.OccupationId.Value.ToString())).Text;
            }
        }

        void SetPagerIndex(GridView gv, int Count)
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

        private void FillEmail(IEnumerable<Entity.UnderWriting.Entities.Contact.Email> emailList, bool newContact = false)
        {
            if (newContact)
                emailList = Services.ContactManager.GetCommunicatonEmail(Service.Corp_Id, Service.Contact_Id, Service.LanguageId);

            emailList = emailList.Where(r => r.DirectoryTypeId == 9).ToList();
            gvEmail.DataSource = emailList;
            gvEmail.DataBind();
            SetPagerIndex(gvEmail, emailList.Count());
        }

        private void FillPhones(IEnumerable<Entity.UnderWriting.Entities.Contact.Phone> phoneList, bool newContact = false)
        {
            if (newContact)
                phoneList = Services.ContactManager.GetCommunicatonPhone(Service.Corp_Id, Service.Contact_Id, Service.LanguageId);

            phoneList = phoneList.Where(r => r.DirectoryTypeId == 7).ToList();
            gvPhone.DataSource = phoneList;
            gvPhone.DataBind();
            SetPagerIndex(gvPhone, phoneList.Count());
        }

        private void FillAddress(IEnumerable<Entity.UnderWriting.Entities.Contact.Address> addressList, bool newContact = false)
        {
            if (newContact)
                addressList = Services.ContactManager.GetCommunicatonAdress(Service.Corp_Id, Service.Contact_Id, Service.LanguageId);

            addressList = addressList.Where(r => r.DirectoryTypeId == 4).ToList();
            gvAddress.DataSource = addressList;
            gvAddress.DataBind();
            SetPagerIndex(gvAddress, addressList.Count());
        }

        protected void gvEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmail.PageIndex = e.NewPageIndex;
            FillEmail(new List<Entity.UnderWriting.Entities.Contact.Email>(), true);
        }

        protected void gvPhone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPhone.PageIndex = e.NewPageIndex;
            FillPhones(new List<Entity.UnderWriting.Entities.Contact.Phone>(), true);
        }

        protected void gvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddress.PageIndex = e.NewPageIndex;
            FillAddress(new List<Entity.UnderWriting.Entities.Contact.Address>(), true);
        }
    }
}