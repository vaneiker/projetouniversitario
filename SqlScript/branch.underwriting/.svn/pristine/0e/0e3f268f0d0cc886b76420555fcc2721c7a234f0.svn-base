using RESOURCE.UnderWriting.NewBussiness;
using Statetrust.Framework.Security.Bll.Item;
using Statetrust.Framework.Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB.NewBusiness.Common.UserControls
{
    public partial class WUCTopMenu : UC
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnVersion.Value = "v" + Utility.GetSystemVersionInfo();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translate();
        }

        public void changeLogo(int company)
        {
            lnkLogo.CssClass = (company == 1) ?
                               "logoLife" : "logoAtl";
        }

        private void Translate()
        {

            lnkTrainingCenter_M2.HRef = System.Configuration.ConfigurationManager.AppSettings["TrainingCenterUrl"].ToString();
            Dashboard.InnerHtml = Resources.DASHBOARD.ToUpper();
            ClientsAndPolicies.InnerHtml = Resources.CLIENTSPOLICIES;
            Sales.InnerHtml = Resources.SALES;
            //SalesSubMenu.InnerHtml = Resources.PointofSale;
            Payments.InnerHtml = Resources.PaymentsLabel.ToUpper();
            Cancelations.InnerHtml = Resources.CANCELLATIONS;
            Pending.InnerHtml = Resources.PENDING.Capitalize();
            formsAndCommunications.InnerHtml = Resources.FORMS;
            Communications.InnerHtml = Resources.COMUNICATION.Capitalize();
            Commisions.InnerHtml = Resources.Commissions.ToUpper();
            CommissionsMobile.InnerHtml = Resources.Commissions.ToUpper();
            TrainingCenter.InnerHtml = Resources.TRAININGCENTER;
            Forms.InnerHtml = Resources.FORMS.Capitalize();
            Investments.InnerHtml = Resources.INVESTMENTS.Capitalize();
            Returns.InnerHtml = Resources.RETURNS.Capitalize();
            Contacts.InnerHtml = Resources.CONTACT;
            Illustrations.InnerHtml = Resources.IllustrationAuto;
            IllustrationGeneral.InnerHtml = Resources.IllustrationGeneral;
            Brochure.InnerHtml = Resources.BROCHURE.Capitalize();
            spSytemName.InnerText = Resources.Inbox;
            Illustrationslife.InnerHtml = Resources.Illustrationlife;
        }

        //protected void lnkRedirectModule_Click(object sender, EventArgs e)
        //{
        //    var addInfo = new AdditionalInfo
        //    {
        //        CompanyId = ObjServices.CompanyId,
        //        Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
        //    };

        //    var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, (LinkButton)sender, addInfo);

        //    if (data.Status){
        //        Response.Redirect(data.UrlPath, true);
        //    }
        //    //abrir un nuevo tab
        //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('"+ data.UrlPath + "');", true);

        //    else {
        //        string msjerrr = data.errormessage;
        //        if (msjerrr == "This user does not have access to this page or App")
        //        {
        //            msjerrr = Resources.UserNoAccess;
        //        }

        //        this.MessageBox(msjerrr);
        //        return;
        //    }
        //}    

        protected void lnkContacts_Click(object sender, EventArgs e)
        {
            ObjServices.TabRedirect = "lnkContactInformation";
            ObjServices.PagerSize = 40;
            Response.Redirect("~/NewBusiness/Pages/Contact.aspx");
        }

        protected void lnkRedirectModule_Click(object sender, EventArgs e)
        {
            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, (LinkButton)sender, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
                //abrir un nuevo tab
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('"+ data.UrlPath + "');", true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lnkIllustration_Click(object sender, EventArgs e)
        {
            var control = (LinkButton)sender;
            if (control.CommandArgument == "Auto")
            {
                if (!ObjServices.UsuarioPropiedades.Any(o => o.Contains("AutoCot")))
                {
                    this.MessageBox(Resources.WithoutInformationAccess);
                    return;
                }
                ObjServices.Bandeja = control.CommandArgument;
            }
            else if (control.CommandArgument == "Propiedad")
            {
                if (!ObjServices.UsuarioPropiedades.Any(o => o.Contains("PropiedadCot")))
                {
                    this.MessageBox(Resources.WithoutInformationAccess);
                    return;
                }
                ObjServices.Bandeja = control.CommandArgument;
            }

            ObjServices.TabRedirect = string.Empty;
            Response.Redirect(string.Concat("~/NewBusiness/Pages/Illustrations.aspx?vBandeja=", control.CommandArgument));
        }

        protected void lnkAuto_Click(object sender, EventArgs e)
        {
            string PvAutoPath = System.Configuration.ConfigurationManager.AppSettings["PvAutoPath"].ToString();
            string PvAutoApp_Name = System.Configuration.ConfigurationManager.AppSettings["PvAutoApp_Name"].ToString();

            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            System.Web.UI.WebControls.LinkButton bntDrop = new System.Web.UI.WebControls.LinkButton();
            bntDrop.Attributes["path"] = PvAutoPath;
            bntDrop.Attributes["appname"] = PvAutoApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lnkHealth_Click(object sender, EventArgs e)
        {
            string PvSaludPath = System.Configuration.ConfigurationManager.AppSettings["PvSaludPath"].ToString();
            string PvSaludApp_Name = System.Configuration.ConfigurationManager.AppSettings["PvSaludApp_Name"].ToString();

            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            System.Web.UI.WebControls.LinkButton bntDrop = new System.Web.UI.WebControls.LinkButton();
            bntDrop.Attributes["path"] = PvSaludPath;
            bntDrop.Attributes["appname"] = PvSaludApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lnkLineaAleada_Click(object sender, EventArgs e)
        {
            string PVLineasAliadasApp_Name = System.Configuration.ConfigurationManager.AppSettings["PVLineasAliadasApp_Name"].ToString();

            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            System.Web.UI.WebControls.LinkButton bntDrop = new System.Web.UI.WebControls.LinkButton();

            bntDrop.Attributes["path"] = "PropiedaCotizacion.aspx?IDQuotationBusiness=0&GlobalRamo=3&Pais=129";
            bntDrop.Attributes["appname"] = PVLineasAliadasApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lnkVivienda_Click(object sender, EventArgs e)
        {
            string PVLineasAliadasApp_Name = System.Configuration.ConfigurationManager.AppSettings["PVLineasAliadasApp_Name"].ToString();

            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            System.Web.UI.WebControls.LinkButton bntDrop = new System.Web.UI.WebControls.LinkButton();

            bntDrop.Attributes["path"] = "PropiedaCotizacion.aspx?IDQuotationBusiness=0&GlobalRamo=2&Pais=129";
            bntDrop.Attributes["appname"] = PVLineasAliadasApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lnkillustationlife_Click(object sender, EventArgs e)
        {
            ObjServices.TabRedirect = string.Empty;
            Response.Redirect("~/NewBusiness/Pages/CasesInProcess.aspx");
        }

    }
}