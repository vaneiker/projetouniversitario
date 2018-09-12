using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.DReview.UserControl.Common
{
    public partial class WUCView : UC, IUC
    {
        public void ClearData(){}
        public void ReadOnlyControls(bool isReadOnly){}
        protected void Page_Load(object sender, EventArgs e){}
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            PolicyNo.InnerHtml = Resources.PolicyNoLabel;
            FirstName.InnerHtml = Resources.FirstNameLabel;
            MiddleName.InnerHtml = Resources.MiddleNameLabel;
            LastName.InnerHtml = Resources.LastNameLabel;
            SecondLastName.InnerHtml = Resources.SecondLastNameLabel;
            btnBackToTheList.Text = Resources.BackToTheList;
        }

        public void save(){}
        public void edit(){}

        protected void btnBackToTheList_Click(object sender, EventArgs e)
        {
            ((WEB.NewBusiness.DReview.Pages.DReview)this.Page).setViewPrincipal(-1);
        }
       
        protected void ManageTabs(object sender, EventArgs e)
        {
            ObjServices.IsReadOnly = true;
            var TabActual = hdnCurrentTabView.Value;
            var Tab = ((LinkButton)sender).ClientID;
            hdnCurrentTabView.Value = Tab;

            switch (Tab)
            {
                case "lnkClientInfo":
                case "lnkOwnerInfo":
                    this.ObjServices.ContactEntityID = (Tab == "lnkClientInfo") ? this.ObjServices.Contact_Id :
                                                                                  this.ObjServices.Owner_Id;

                    if (Tab == "lnkOwnerInfo")
                    {
                        var oOwner = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Owner);
                        ObjServices.isCompanyOwner = (oOwner != null && oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt());
                        hdnIsCompanyOwnerView.Value = ObjServices.isCompanyOwner.ToString().ToLower();
                        ContactsInfoContainer.ShowFormOwnerInfo(null, false, (ObjServices.isCompanyOwner) ? 1 : 0, false);
                    }
                    else
                    {
                        ContactsInfoContainer.Initialize();
                        ContactsInfoContainer.ChangeView(0);
                    }
                    mtvTabs.SetActiveView(vContactsInfo);
                    break;
                case "lnkPlanPolicy":
                    this.ObjServices.ContactEntityID = -1;

                    this.ObjServices.ContactEntityID = (this.ObjServices.DesignatedPensionerContactId > 0) ?
                                                this.ObjServices.DesignatedPensionerContactId :
                                                this.ObjServices.InsuredAddContactId;
                    PlanPolicyContainer.Initialize();
                    mtvTabs.SetActiveView(vPlanPolicy);
                    break;
                case "lnkBeneficiaries":
                    BeneficiariesContainer.Initialize();
                    mtvTabs.SetActiveView(vBeneficiaries);
                    break;
                case "lnkHealthDeclaration":
                    HealthDeclarationContainer.ChangeColumnSizeQuestionaire();
                    HealthDeclarationContainer.Initialize();
                    mtvTabs.SetActiveView(vHealthDeclaration);
                    break;
                case "lnkRequirements":
                    RequirementsContainer.Initialize();
                    mtvTabs.SetActiveView(vRequirements);
                    break;
                case "lnkPayment":
                    if (!ObjServices.IsReadyToReview)
                    {
                        this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.PaymentsTabDisabled, Title: "Error");
                        RedirectTab(TabActual);
                        return;
                    }
                    PaymentContainer.Initialize();
                    mtvTabs.SetActiveView(vPayments);
                    break;
            }
            
            ((WEB.NewBusiness.DReview.Pages.DReview)this.Page).updateView();
       
        }

        private void RedirectTab(string TabActual)
        {
            hdnCurrentTabView.Value = TabActual;

            switch (TabActual)
            {
                case "lnkClientInfo":
                case "lnkOwnerInfo":
                    mtvTabs.SetActiveView(vContactsInfo);
                    break;
                case "lnkPlanPolicy":
                    mtvTabs.SetActiveView(vPlanPolicy);
                    break;
                case "lnkBeneficiaries":
                    mtvTabs.SetActiveView(vBeneficiaries);
                    break;
                case "lnkHealthDeclaration":
                    mtvTabs.SetActiveView(vHealthDeclaration);
                    break;
                case "lnkRequirements":
                    mtvTabs.SetActiveView(vRequirements);
                    break;
                case "lnkPayment":
                    mtvTabs.SetActiveView(vPayments);
                    break;
            }
        }

        public void FillData()
        {
            int CorpId = ObjServices.Corp_Id;
            int RegionId = ObjServices.Region_Id;
            int CountryId = ObjServices.Country_Id;
            int DomesticregId = ObjServices.Domesticreg_Id;
            int StateProvId = ObjServices.State_Prov_Id;
            int CityId = ObjServices.City_Id;
            int OfficeId = ObjServices.Office_Id;
            int CaseSeqNo = ObjServices.Case_Seq_No;
            int HistSeqNo = ObjServices.Hist_Seq_No;

            var datos = ObjServices.oPolicyManager.GetPlanData(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo);

            if (datos != null)
            {
                txtPolicy.Text = datos.PolicyNo;
                txtFirstName.Text = datos.InsuredFirstName;
                txtMiddleName.Text = datos.InsuredMiddleName;
                txtLastName.Text = datos.InsuredLastName;
                txtSecondLastName.Text = datos.InsuredSecondLastName;
            }

        }

        public void Initialize(string TitleView)
        {
            ltViewLabel.Text = TitleView;
            Initialize();
        }
        public void Initialize()
        {
            ObjServices.ContactEntityID = ObjServices.Contact_Id;
            FillData();
            ManageTabs(lnkClientInfo, null);
        }       
    }
}