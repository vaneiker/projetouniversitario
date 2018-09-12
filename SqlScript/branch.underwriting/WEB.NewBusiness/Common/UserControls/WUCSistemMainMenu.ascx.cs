using RESOURCE.UnderWriting.NewBussiness;
using Statetrust.Framework.Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.Common.UserControls
{
    public partial class WUCSistemMainMenu : UC, IUC
    {
        public void Translator(string Lang) { }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }

        private void FillDrop()
        {
            var isTest = System.Configuration.ConfigurationManager.AppSettings["isTestingQuotDebug"] == "true" || ObjServices.isUserCot;

            try
            {
                if (isTest)
                {
                    var dataAgent = ObjServices.GettingDropData(Utility.DropDownType.AgentQuotation,
                                                                 corpId: ObjServices.Corp_Id,
                                                                 regionId: ObjServices.Region_Id,
                                                                 countryId: ObjServices.Country_Id,
                                                                 domesticregId: ObjServices.Domesticreg_Id,
                                                                 stateProvId: ObjServices.State_Prov_Id,
                                                                 cityId: ObjServices.City_Id,
                                                                 officeId: ObjServices.Office_Id,
                                                                 caseSeqNo: ObjServices.Case_Seq_No,
                                                                 histSeqNo: ObjServices.Hist_Seq_No
                                                                 ).Select(i =>
                                                                 {
                                                                     i.CodeName = string.Concat(i.CodeName.ToUpper(), "|", i.DrugDesc);
                                                                     i.AgentName = i.AgentName.ToUpper();
                                                                     i.AgentName = string.Format("{0} / {1}", i.AgentName, i.RoleDesc.Replace("Cot", ""));
                                                                     return i;
                                                                 }).Distinct().OrderBy(x => x.AgentName);

                    cbkUsers.DataSource = dataAgent;
                    cbkUsers.DataTextField = "AgentName";
                    cbkUsers.DataValueField = "CodeName";
                    cbkUsers.DataBind();
                    cbkUsers.Items.Insert(0, new ListItem { Text = Resources.Select, Value = "-1" });        
                }
            }
            catch (Exception)
            {


            }

        }


        public void FillData()
        {

        }

        public void Initialize()
        {
            ClearData();
            FillDrop();
            FillData();
        }

        public void ClearData()
        {
            cbkUsers.Items.Clear();
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            var AddNewCase = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["AddNewCase"]);
            var CasesInProcess = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["CasesInProcess"]);
            var ReadyToReview = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["ReadyToReview"]);
            var SubmittedPolicies = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["SubmittedPolicies"]);
            var ContactList = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["ContactList"]);
            var AddNewContact = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["AddNewContact"]);
            var IllustrationTab = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IllustrationTab"]);
            var Illustrations = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Illustrations"]);
            var Reports = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Reports"]);
            var Application = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Application"]);
            var Updates = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Updates"]);
            var Exceptions = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Exceptions"]);
            var isTest = System.Configuration.ConfigurationManager.AppSettings["isTestingQuotDebug"] == "true" || ObjServices.isUserCot; 

            if (!AddNewCase)
            {
                MenulnkClientInfo.Click -= ManageLinkTabs;
                MenulnkClientInfo.Attributes.Add("alt", "Disabled");
            }

            if (!CasesInProcess)
            {
                MenulnkCasesInProcess.Click -= ManageLinkTabs;
                MenulnkCasesInProcess.Attributes.Add("alt", "Disabled");
            }

            if (!ReadyToReview)
            {
                MenulnkReadyToReview.Click -= ManageLinkTabs;
                MenulnkReadyToReview.Attributes.Add("alt", "Disabled");
            }

            if (!SubmittedPolicies)
            {
                MenulnkSubmitted.Click -= ManageLinkTabs;
                MenulnkSubmitted.Attributes.Add("alt", "Disabled");
            }

            if (!ContactList)
            {
                MenulnkContactList.Click -= ManageLinkTabs;
                MenulnkContactList.Attributes.Add("alt", "Disabled");
            }

            if (!AddNewContact)
            {
                MenulnkAddNewContact.Click -= ManageLinkTabs;
                MenulnkAddNewContact.Attributes.Add("alt", "Disabled");
            }

            if (!IllustrationTab)
            {
                MenulnkIllustrationsTab.Click -= ManageLinkTabs;
                MenulnkIllustrationsTab.Attributes.Add("alt", "Disabled");
            }

            if (!Illustrations)
            {
                MenulnkIllustrations.Click -= ManageLinkTabs;
                MenulnkIllustrations.Attributes.Add("alt", "Disabled");
            }

            if (!Reports)
            {
                MenulnkReports.Click -= ManageLinkTabs;
                MenulnkReports.Attributes.Add("alt", "Disabled");
            }

            if (!IsPostBack)
            {
                MenulnkReadyToReview.Visible = (ObjServices.UserType != Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent);
                var isVisible = !(ObjServices.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent || ObjServices.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Assistant);
                HeaderAdminAgent.Visible = isVisible;
                MenuNewAgent.Visible = isVisible;
                MenuAgentList.Visible = isVisible;
                Initialize();
            }

            pnUserTest.Visible = isTest;

        }

        protected void lnkRedirectModule_Click(object sender, EventArgs e)
        {
            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, (LinkButton)sender);

            if (data.Status)
                Response.Redirect(data.UrlPath, true);
            else
                this.MessageBox(data.errormessage);
        }

        protected void ManageLinkTabs(object sender, EventArgs e)
        {
            var LnkButton = ((LinkButton)sender).ClientID;

            switch (LnkButton)
            {
                case "MenulnkClientInfo":
                    ObjServices.isNewCase = true;
                    ObjServices.TabRedirect = "lnkClientInfo";
                    Response.Redirect("~/NewBusiness/Pages/AddNewClient.aspx");
                    break;
                case "MenulnkSubmitted":
                    Response.Redirect("~/NewBusiness/Pages/SubmittedPolicies.aspx");
                    break;
                case "MenulnkReadyToReview":
                    if (ObjServices.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.Agent)
                    {
                        var Title = (ObjServices.Language == Utility.Language.en) ? "'Warning'" : "'Advertencia'";
                        this.ExcecuteJScript("CustomDialogMessageEx(null, null, null, true," + Title + " , 'TabAgentDisabledMessage');");
                        return;
                    }
                    Response.Redirect("~/NewBusiness/Pages/ReadyToReview.aspx");
                    break;
                case "MenulnkCasesInProcess":
                    Response.Redirect("~/NewBusiness/Pages/CasesInProcess.aspx");
                    break;
                case "MenulnkContactList":
                    ObjServices.TabRedirect = "lnkContactInformation";
                    ObjServices.PagerSize = 40;
                    Response.Redirect("~/NewBusiness/Pages/Contact.aspx");
                    break;
                case "MenulnkAddNewContact":
                    ObjServices.TabRedirect = "lnkContactInformation";
                    ObjServices.ContactEntityID = -1;
                    ObjServices.PagerSize = 12;
                    Response.Redirect("~/NewBusiness/Pages/Contact.aspx");
                    break;
                case "MenulnkIllustrationsTab":
                    ObjServices.TabRedirect = "lnkIllustrations";
                    ObjServices.ContactEntityID = -1;
                    ObjIllustrationServices.CustomerNo = -1;
                    ObjIllustrationServices.CustomerPlanNo = -1;
                    ObjIllustrationServices.CustomerPlanOwnerNo = -1;
                    Response.Redirect("~/NewBusiness/Pages/Contact.aspx");
                    break;
                case "MenulnkIllustrations":
                    ObjServices.TabRedirect = string.Empty;
                    Response.Redirect("~/NewBusiness/Pages/Illustrations.aspx");
                    break;
                case "MenulnkIllustrationsLife":
                    ObjServices.TabRedirect = "MenulnkIllustrationsLife";
                    Response.Redirect("~/NewBusiness/Pages/IllustrationsLife.aspx");
                    break;
            }
        }

        protected void cbkUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/NewBusiness/Pages/Login.aspx?UserName=" +  HttpUtility.UrlEncode(cbkUsers.SelectedValue));
        }
    }
}