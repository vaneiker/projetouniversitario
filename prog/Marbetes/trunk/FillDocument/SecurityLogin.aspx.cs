using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Globalization;
using System.Web.Configuration;
using Statetrust.Framework.Web.WebParts.Pages;
using System.IO;
using Keys = System.Configuration.ConfigurationManager;
using System.Drawing.Printing;
public partial class SecurityLogin : STFMainPage
{

    protected override void Page_PreInit(object sender, EventArgs e)
    {
      
        isLoginPage = true;
        SecurityMenuBar = false;
        if (IsPostBack) return;
        if (Keys.AppSettings["ApplySecurity"].ToString(CultureInfo.InvariantCulture) == "false")
        {   var userId = 0;
            var result = Login("pveneiker", "outiiz/77lQ=", ref userId);
            if (!result) return;
            SetSessionValues();
            Response.Redirect("~/MarbeteWeb.aspx");
        }
        else
        {
            if (Request.QueryString.Count > 0)
            {
                var userId = 0;
                var aplicationId = 0;
                if (!Login(Request.QueryString[0], ref userId, ref aplicationId)) return;
                var url = GetDefaultPageByUserID(userId, aplicationId);
                if (url.Trim() != "")
                {
                    SetSessionValues();
                    //Response.Redirect(url, false);
                    Response.Redirect("~/MarbeteWeb.aspx");
                }
                else return;
            }
            else
                Response.Redirect(WebConfigurationManager.AppSettings["SecurityLogin"]);
        }
    }

    private void SetSessionValues()
    {
        // Usuario.CurrentLanguageId = 2;
        Session["UserID"] = Usuario.UserID;
        Session["UserName"] = Usuario.FullName;
        Session["UserLogin"] = Usuario.UserLogin;
        var user = Session["UserLogin"].ToString();
        Session["IsSharpPrinter"] = IsSharpPrinter(user);
        //Esto va en el login, luego que la persona se loguea                                    
        CreateTempDirectory();
        Session["Chasis"] = string.Empty;
        var jsonAdditionalInfo = Request.QueryString["additionalinfo"];
        if (!String.IsNullOrEmpty(jsonAdditionalInfo) || jsonAdditionalInfo != null)
        {
            var additionalInfo = GetAdditionalInfo(jsonAdditionalInfo);
            if (additionalInfo.RedirectUrl.Contains("MarbeteWeb"))
                Session["Chasis"] = additionalInfo.Action;
        }
    }
    /// <summary>
    /// Creates a temp directory by user.
    /// </summary>
    private void CreateTempDirectory()
    {
        var directoryByUser = Keys.AppSettings["DirectoryByUser"].ToString();
        Session["TempDirectory"] = Server.MapPath(string.Concat(directoryByUser, "-", Session["UserLogin"]));
        var directory = Session["TempDirectory"].ToString();
        if (!Directory.Exists(directory)) 
            Directory.CreateDirectory(directory);
        var files = Directory.GetFiles(directory).ToList();
        if (files.Any())
        {
            try
            {
                files.ForEach(o => File.Delete(o));
            }
            catch (IOException)
            {
                return;
            }
        }
    }
    private bool IsSharpPrinter(string _user)
    {
        bool result = false;
        var user = GetUserWithSharp().Where(o => o == _user);
        if (user.Any())
            result = true;
        return result;
    }
    private string[] GetUserWithSharp()
    {
        string[] users = { };
        if (Keys.AppSettings["SharpPrinterUser"] != null)
            users = Keys.AppSettings["SharpPrinterUser"].Split(',');
        return users;
    }
}