using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.Common
{
    public partial class WUCSaveTab : UC, IUC
    {
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }
        public void FillData() { }
        public void ClearData() { }
        protected void Page_Load(object sender, EventArgs e) { }

        public class ValidationCedula
        {
            public Boolean ValidCedula { get; set; }
            public Boolean InvalidCedula { get; set; }
        }
        public class ValidationRNC
        {
            public Boolean ValidRNC { get; set; }
            public Boolean InvalidRNC { get; set; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            btnSave.Text = Resources.Save;
        }

        private ValidationRNC ValidationRNCValid(string IDRNC)
        {
            var ExistsItem = new ValidationRNC { ValidRNC = false, InvalidRNC = false };

            var y = ObjServices.oContactManager.GetResultRNC(IDRNC);

            if (y.RNC == 0)
            {
                ExistsItem.InvalidRNC = true;
                ExistsItem.ValidRNC = false;
                return ExistsItem;
            }
            else if (y.RNC == 1)
            {
                ExistsItem.InvalidRNC = false;
                ExistsItem.ValidRNC = true;
                return ExistsItem;
            }
            return ExistsItem;
        }

        /// <summary>
        /// Metodos para validar un Cedula RNC Real
        private ValidationCedula ValidationCedulaValid(string IDCedula)
        {
            var ExistsItem = new ValidationCedula { ValidCedula = false, InvalidCedula = false };

            var x = ObjServices.oContactManager.GetResultCedula(IDCedula);

            if ((x.Cedula == 0))
            {
                ExistsItem.InvalidCedula = true;
                return ExistsItem;
            }
            else if (x.Cedula == 1)
            {
                ExistsItem.InvalidCedula = false;
                return ExistsItem;
            }

            return ExistsItem;
        }
		
        protected void btnSave_Click(object sender, EventArgs e)
        {
			var bodyContent = this.Page.Master.FindControl("bodyContent");
            
            Control WUCCompanyInfo = null;
            var Container = (!ObjServices.IsDataReviewMode) ? "ContactsInfoContainer" : "DReviewContainer";
            WUCCompanyInfo = this.Page.Master.FindControl("bodyContent").FindControl(Container).FindControl("WUCCompanyInfo");
            var txtDocument = (WUCCompanyInfo.FindControl("txtCompanyRNC") as TextBox).Text.Replace("-", "");
            var ddlIDType = (WUCCompanyInfo.FindControl("ddlIDType") as DropDownList).SelectedValue;
            if ((txtDocument != ""))
            {
                if (int.Parse(ddlIDType) == 5)
                {
                    var ValidationRNC = ValidationRNCValid(txtDocument);
                    if (ValidationRNC.InvalidRNC)
                    {
                        var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Documento Invalido";
                        string message = "El RNC de la empresa no es valido";
                        this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                        return;
                    }
                }
                else
                {
                    var ValidationCedula = ValidationCedulaValid(txtDocument);

                    if (ValidationCedula.InvalidCedula)
                    {
                        var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Documento Invalido";
                        string message = "El ID de la empresa no es valido";
                        this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                        return;
                    }
                }               
            }
			
            if (!bodyContent.isNullReferenceControl())
            {
                ((WEB.NewBusiness.NewBusiness.Pages.AddNewClient)bodyContent.Page).Save("lnk" + currentTab);
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully, Title: ObjServices.Language == Utility.Language.en ? "INFORMATION" : "INFORMACIÓN");
            }
        }

        public void Initialize()
        {
            btnSave.Attributes.Add("alt", currentTab == "ClientInfo" ? "1" : "2");
        }
    }
}