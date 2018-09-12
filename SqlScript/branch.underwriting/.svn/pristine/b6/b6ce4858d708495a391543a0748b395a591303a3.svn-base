using System;
using System.Web;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class Equifax : System.Web.UI.Page
    {
        public string IDNumber
        {
            get { return ViewState["IDNumber"].ToString(); }
            set { ViewState["IDNumber"] = value; }
        }

        public string KeyRiesgo
        {
            get { return ViewState["KeyRiesgo"].ToString(); }
            set { ViewState["KeyRiesgo"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString.Count > 0)
                {
                    var data = Common.Utility.Decrypt_Query(Request.QueryString["data"]);
                    IDNumber = data.Split('|')[0];
                    KeyRiesgo = data.Split('|')[1];

                    WUCEquifax.pCedulaOrDriverLicense = IDNumber;
                    WUCEquifax.Initialize(KeyRiesgo);
                }
            }
            catch (Exception ex)
            {
                //WEB.NewBusiness.Common.Log_Error.RegistrarError(ex, HttpContext.Current.Request.Url.AbsoluteUri, System.Reflection.MethodBase.GetCurrentMethod().Name); //Joel Solis 09/03/2017
                this.MessageBox(string.Format("ExceptionMessage {0} TraceStack {1}", ex.Message, ex.StackTrace).MyRemoveInvalidCharacters(), Title: "Error", Width: 800);
            }
        }
    }
}