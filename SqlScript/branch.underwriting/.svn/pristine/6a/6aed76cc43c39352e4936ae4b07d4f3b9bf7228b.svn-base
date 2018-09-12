using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.Configuration;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.Pages
{
    public partial class LoginPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SetLoginInformation()
        {

            Session["UserID"] = Usuario.UserID;
            Session["UserId"] = Usuario.UserID.ToString();
            Session["User Name"] = "RESTER";

            //SET ATLANTICA POR DEFAULT
            var companyId = !Usuario.AgentOffices.Any() || Usuario.CurrentCompanyId <= 0 ? 2 : Usuario.CurrentCompanyId;
            
            UserDataProvider.CorpId = 1;
            Usuario.CurrentCompanyId = UserDataProvider.CompanyId = companyId;
            UserDataProvider.UserId = Usuario.UserID;

            //using (var service = new UserService())
            //    service.AssignUserData(Usuario);
            //var jsonAdditionalInfo = Request.QueryString["additionalinfo"];
            //if (!String.IsNullOrEmpty(jsonAdditionalInfo))
            //{
            //    var additionalInfo = GetAdditionalInfo(jsonAdditionalInfo);
            //    Response.Redirect(additionalInfo.RedirectUrl, true);
            //}
        }

        protected override void Page_PreInit(object sender, EventArgs e)
        {
            isLoginPage = true;
            SecurityMenuBar = false;
            if (IsPostBack) return;
            if (ConfigurationManager.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "false")
            {
                int UserID = 0;
                //if (Login("ggarcia", "Sktpdf3V8OoHrX1tquZZxA==", ref UserID))
                if (Login("PEREFABI", "outiiz/77lQ=", ref UserID))
                {
                    SetLoginInformation();
                    Response.Redirect("~/Pages/ConfirmationCall.aspx", true);
                }
            }
            else
            {
                if (Request.QueryString.Count > 0)
                {
                    int UserID = 0;
                    int AplicationID = 0;
                    if (Login(Request.QueryString[0], ref UserID, ref  AplicationID))
                    {
                        var URL = GetDefaultPageByUserID(UserID, AplicationID);
                        if (URL.Trim() != "")
                        {
                            SetLoginInformation();
                            Response.Redirect(URL, true);
                        }
                    }
                }
                else
                    Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"], true);
            }
        }


    }
}