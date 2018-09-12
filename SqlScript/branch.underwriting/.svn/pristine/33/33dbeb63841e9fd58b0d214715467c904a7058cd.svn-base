using System;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class Contact : WEB.NewBusiness.Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContactContainer.FillDataContact += FilldataContacts;
            var hdnCurrentMenuSelectedMenuLeft = this.Master.FindControl("hdnCurrentMenuSelectedMenuLeft");

            if (!IsPostBack)
            {
                if (hdnCurrentMenuSelectedMenuLeft != null)
                {
                    ((HiddenField)hdnCurrentMenuSelectedMenuLeft).Value = ObjServices.PagerSize == 12 ? "MenulnkAddNewContact" : "MenulnkContactList";
                    hdnShowFormAddNewContact.Value = ObjServices.PagerSize == 12 ? "true" : "false";
                }

                LinkButton BotonTab = null;

                if (!string.IsNullOrEmpty(ObjServices.TabRedirect))
                    hdnCurrentTabContact.Value = ObjServices.TabRedirect;

                switch (hdnCurrentTabContact.Value)
                {
                    case "lnkContactInformation":
                        BotonTab = lnkContactInformation;
                        break;

                    case "lnkCallAndVisits":
                        BotonTab = lnkCallAndVisits;
                        break;

                    case "lnkIllustrations":
                        ((HiddenField)hdnCurrentMenuSelectedMenuLeft).Value = "MenulnkIllustrationsTab";
                        BotonTab = lnkIllustrations;
                        break;
                }

                if (string.IsNullOrEmpty(ObjServices.TabRedirect))
                    ManageTabs(BotonTab, null);
                else
                    ManageTabs(ObjServices.TabRedirect);
            }

            udpHiddenFields.Update();
        }

        protected void FilldataContacts()
        {
            WUCContactList.FillData();
        }

        public void ManageTabs(string Tab, bool isChangingTab = false)
        {
            Session["CallFromSaveIllustration"] = false;
            switch (Tab)
            {
                case "lnkContactInformation":
                    if (ObjServices.PagerSize == 40)
                    {
                        hfMenuAccordeonContact.Value = "acc1|0";
                        hdnShowFormAddNewContact.Value = "false";
                    }
                    else
                    {
                        hfMenuAccordeonContact.Value = "acc1|1";
                        hdnShowFormAddNewContact.Value = "true";
                    }

                    WUCContactList.Initialize();
                    ContactContainer.Initialize();
                    mtMasterView.SetActiveView(vContactInfo);
                    break;
                case "lnkCallAndVisits":
                    mtMasterView.SetActiveView(vCallsAndVisits);
                    break;
                case "lnkIllustrations":
                    //Salvar el tab de Contactos
                    if (hdnShowFormAddNewContact.Value == "true" && !(ObjServices.TabRedirect == "lnkIllustrations"))
                        Save(Tab);

                    if (isChangingTab)
                        ObjIllustrationServices.CustomerNo =
                    ObjIllustrationServices.CustomerPlanNo =
                    ObjServices.ContactEntityID = null;

                    UCIllustrationContainer.Initialize();
                    UCIllustrationContainer.FillData();
                    mtMasterView.SetActiveView(vIllustration);
                    break;
            }

            hdnCurrentTabContact.Value = Tab;
            udpHiddenFields.Update();
        }
        public void Save(String TabActual)
        {
            ObjServices.TabRedirect = string.Empty;
            Session["CallFromSaveIllustration"] = false;
            switch (TabActual)
            {
                case "lnkIllustrations":
                    if (hdnShowFormAddNewContact.Value == "true")
                    {
                        Session["CallFromSaveIllustration"] = true;
                        ContactContainer.save();
                    }
                    break;
            }
        }

        protected void ManageTabs(object sender, EventArgs e)
        {
            var TabActual = hdnCurrentTabContact.Value;
            var Tab = ((LinkButton)sender).ClientID;
            //ObjIllustrationServices.CustomerPlanNo = 92806;
            //ObjIllustrationServices.CustomerNo = 10700075935;
            //ObjServices.ContactEntityID = 193232;
            ManageTabs(Tab, true);
        }
    }
}