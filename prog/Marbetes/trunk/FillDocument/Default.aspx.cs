using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Statetrust.Framework.Core.Util;
using Statetrust.Framework.Security.Core;
using System.Diagnostics;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            
    }
    protected void btnLoginService_Click(object sender, EventArgs e)
    {
        RedirectToService("SALLMAMC46A220682");
    }
    
    public void RedirectToMarbeteWeb(string Policy)
    {
        
        try
        {
            LinkButton bntDrop = new LinkButton();
            //bntDrop.Attributes["path"] = "MarbeteWeb";
            //bntDrop.Attributes["appname"] = "MarbeteApp";
            bntDrop.Attributes["path"] = "MarbeteWeb";
            bntDrop.Attributes["appname"] ="MarbeteApp";
            /*Enviar Poliza Como parametro*/
            bntDrop.Attributes.Add("Action", Policy) ;
            var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
            {
                CompanyId = 2,
                Language = "es"
            };
            var data = SecurityPage.GenerateToken(59, bntDrop, addInfo);

            if (data.Status)
            {
                //Response.Redirect(data.UrlPath, true);
               Response.Redirect(data.UrlPath.Replace("http://devmarbetesapp.dev.atlantica.local", "http://localhost:54720/FillDocument"), true);
            }
            else
            {
               // this.MessageBox(data.errormessage);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void RedirectToService(string chasis)
    {

        try
        {
            LinkButton bntDrop = new LinkButton();
            //bntDrop.Attributes["path"] = "MarbeteWeb";
            //bntDrop.Attributes["appname"] = "MarbeteApp";
            //http://vovehiculos.qa.atlantica.local/Autos/Pages/ContactList.aspx 
            bntDrop.Attributes["path"] = "ContactList.aspx";
            bntDrop.Attributes["appname"] = "VOVehiculos";
            /*Enviar Poliza Como parametro*/
            bntDrop.Attributes.Add("Action", chasis);

            var addInfo = new Statetrust.Framework.Security.Bll.Item.AdditionalInfo
            {
                CompanyId = 2,
                Language = "es"
            };
            var data = SecurityPage.GenerateToken(202, bntDrop, addInfo);
            if (data.Status)
            {
                http://vovehiculos.qa.atlantica.local/Autos/Pages/ContactList.aspx 
                Response.Redirect(data.UrlPath, true);
                //Response.Redirect(data.UrlPath.Replace("http://devmarbetesapp.dev.atlantica.local", "http://localhost:54720/FillDocument"), true);
                //Response.Redirect(data.UrlPath.Replace(""), true);
            }
            else
            {
                // this.MessageBox(data.errormessage);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}