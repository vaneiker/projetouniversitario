using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using WEB.NewBusiness.Common;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.html.simpleparser;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class Transunion : System.Web.UI.Page
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
                    WUCTransunion.pCedulaOrDriverLicense = IDNumber;
                    WUCTransunion.Initialize(KeyRiesgo);
                }
            }
            catch (Exception ex)
            {
                this.MessageBox(string.Format("ExceptionMessage {0} TraceStack {1}", ex.Message, ex.StackTrace).MyRemoveInvalidCharacters(), Title: "Error", Width: 800);
            }
        }
    }
}