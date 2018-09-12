using Statetrust.Framework.Web.WebParts.Masters;
using System;
using System.Web;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall
{
    public partial class Master : STFMainMaster
    {
        public bool IsChangingPage
        {
            get
            {
                return hdnIsChangingPage.Value == "true";
            }
        }

        public bool ApplyPreviousTab
        {
            get
            {
                var applyPreviousTab = Session["ApplyPreviousTab"];
                return applyPreviousTab != null && (bool)applyPreviousTab;
            }

            set
            {
                Session["ApplyPreviousTab"] = value;
            }
        }

        public string Lang
        {
            get
            {
                return ((HiddenField)STFCUserProfile1.FindControl("hdnLang")).Value;
            }
            set
            {
                ((HiddenField)STFCUserProfile1.FindControl("hdnLang")).Value = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SessionProvider.InvalidateAllContains("Removable_");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //lnkDashboard.Attributes.Remove("class");
            
            //lnkConfirmationCall.Attributes.Remove("class");
            //lnkHistory.Attributes.Remove("class");
            
            //lnkAdministration.Attributes.Remove("class");
            //MessageToolTipCountTasks.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.MessageToolTipCountTasks;

            //var CurrentMenu = HttpContext.Current.Request.Url.AbsolutePath.Replace(HttpContext.Current.Request.ApplicationPath+"/", "");
            switch (HttpContext.Current.Request.Url.AbsolutePath.Replace("/Pages/", ""))
            {
                case "Dashboard.aspx":
                  //  lnkDashboard.Attributes.Add("class", "active");
                    break;
                case "ConfirmationCall.aspx":
                   // lnkConfirmationCall.Attributes.Add("class", "active");
                    break;
                case "History.aspx":
                    //lnkHistory.Attributes.Add("class", "active");
                    break;
                case "Administration.aspx":
                   // lnkAdministration.Attributes.Add("class", "active");
                    break;
            }
            STFCUserProfile1.ChangeCompany += ChangeCompany;
            if (!IsPostBack)
                Lang = UserDataProvider.Language;

            VerifyLanguage();

            //Debe venir del resource  RESOURCE.UnderWriting.ConfirmationCall.Resources.MessageToolTipCountTasks;
            hdnNoDataToPaginate.Value = RESOURCE.UnderWriting.ConfirmationCall.Resources.NoDataToPaginate.ToString();
            if (Lang == "es"){
                hdnMensajeToolTipCountTasks.Value = "Número de Tareas para el día de hoy";
                
            }
            else {
                hdnMensajeToolTipCountTasks.Value = "Number of Tasks for Today";
            }

        }
        //
        void VerifyLanguage()
        {
            UserDataProvider.IsChangingLanguage = UserDataProvider.Language != Lang;
            if (UserDataProvider.IsChangingLanguage || !IsPostBack)
                UserDataProvider.Language = Lang;

            ResourcesProvider.ChangeLanguage(UserDataProvider.Language);
        }
        //
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (UserDataProvider.IsChangingLanguage || !IsPostBack)
                Translate();
            hdnIsChangingPage.Value = "";

            if (String.IsNullOrEmpty(UserDataProvider.ViewNameId))
            {
                ilViewAgent.Visible = false;
                btnViewAgentLogOut.Text = "";
            }
            else
            {
                //ilViewAgent.Visible = true;
                //using (var _gEntities = new GlobalEntities())
                //{
                //    var lstAgentId = _gEntities.FunctionAgentTree(UserDataProvider.CorpId, UserDataProvider.NameId, UserDataProvider.Role.ToString(), 1).Where(o => o.nameid == UserDataProvider.ViewNameId).Select(o => o.Agentid).FirstOrDefault();
                //    using (var service = new AdminAgentService())
                //    {
                //        var data = service.GetAgentData(lstAgentId.ToInt());
                //        btnViewAgentLogOut.Text = (data.FirstName + " " + data.MiddleName + " " + data.LastName + " " + data.SecondLastName + " (" + STL.VirtualOffice.UIResources.Resources.CloseView + ")").Replace("  ", " ").Trim();
                //    }
                //}
            }
        }
        
        void Translate()
        {
           //btnLoadProfile.CssClass = "show_profile";
           //btnLoadHomeTools.CssClass = "toolbar_btn";

            if (UserDataProvider.Language != "en")
            {
                //btnLoadProfile.CssClass += " show_profile_" + UserDataProvider.Language;
                //btnLoadHomeTools.CssClass += " toolbar_btn_" + UserDataProvider.Language;
                
            }
            
            STFCUserProfile1.Translate();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        protected void btnChangeLang_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnViewAgentLogOut_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UserDataProvider.ViewNameId))
            {
                UserDataProvider.NameId = UserDataProvider.RealNameId;
                UserDataProvider.Role = UserDataProvider.RealRole;
                HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["DefaultPage"], true);
            }
        }

        public void ChangeCompany(int companyId)
        {
            UserDataProvider.CompanyId = companyId;
            // Change_Logo();
            //Response.Redirect(Request.RawUrl, true);
        }
        protected void callbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
           // LblObservacion.Text = Convert.ToString(e.Parameter);
        }
    }
}