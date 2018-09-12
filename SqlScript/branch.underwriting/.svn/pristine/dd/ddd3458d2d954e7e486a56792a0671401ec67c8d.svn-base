using System;
using WEB.ConfirmationCall.Common;

namespace WEB.ConfirmationCall.UserControls.Common
{
    public partial class UCLeftMenu : UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }


        protected void Page_PreRender(object sender, EventArgs e)
        {                      
            Change_Logo();          
        }



        protected void Change_Logo()
        {
            //System.Web.UI.HtmlControls.HtmlGenericControl  profile_menu_logo = (this.Parent as System.Web.UI.UserControl).FindControl("profile_menu_logo") as System.Web.UI.HtmlControls.HtmlGenericControl;
            //profile_menu_logo.Attributes.Remove("class");
            //profile_menu_logo.Attributes.Add("class", drpCompanyProfile.SelectedValue.ToInt()== 1 ? "logo" : "logo_atl");
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {

            //if (UserDataProvider.ViewNameId == "")
            //{
            Session.Abandon();
            Response.Redirect("http://atlanticasecurity.qa.atlantica.local/Index.aspx", true);
            //}
            //else
            //{
            //    UserDataProvider.NameId = UserDataProvider.RealNameId;
            //    UserDataProvider.Role = UserDataProvider.RealRole;
            //    HttpContext.Current.Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["DefaultPage"], true);
            //}
        }

        protected void drpCompanyProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UserDataProvider.CompanyId = drpCompanyProfile.SelectedValue.ToInt();
           // UCHeader.FillConfirmationCall();
        }
    }
}