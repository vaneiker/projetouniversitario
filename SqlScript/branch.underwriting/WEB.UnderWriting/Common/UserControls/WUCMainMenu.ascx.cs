using System;

namespace WEB.UnderWriting.Common
{
    public partial class WUCMainMenu : UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //try
            //{
            //    var hdnLang = this.FindControl("STFCUserProfile1").FindControl("hdnLang") as System.Web.UI.WebControls.HiddenField;
            //}
            //catch { }

            if (Service.LanguageId == 1)
            {
                //wcastro 04-05-2017
                //lblSystem.InnerText = "UNDERWRITING";
                lblSystem.InnerText = "Underwriting";
                //fin wcastro 04-05-2017

            }
            else if (Service.LanguageId == 2)
            {
                //wcastro 04-05-2017
                //lblSystem.InnerText = "UNDERWRITING";
                lblSystem.InnerText = "Underwriting";
                //fin wcastro 04-05-2017
            }
        }

        public void ChangeLogo()
        {
            lnkCompanyLogo.CssClass = Service.CompanyId == 2 ? "logo_atl" : "logo_stl";
            //wcastro 04-05-2017
            lblSystem.Attributes.Add("class", "lblsystem2");
            //fin wcastro 04-05-2017
        }

    }
}