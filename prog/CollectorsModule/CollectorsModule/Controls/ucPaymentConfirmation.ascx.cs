using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CollectorsModule.ell;
using CollectorsModule.bll.Services;
using Collectors.Helpers;
using DevExpress.Web;
using CollectorsModule.Commons;
using System.Configuration;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Web.Script.Serialization;
using System.Globalization;

namespace CollectorsModule.Controls
{
    public partial class ucPaymentConfirmation : System.Web.UI.UserControl
    {
        private string ActiveView
        {
            get
            {
                return (string)Session["ActiveView"];
            }

            set
            {
                Session["ActiveView"] = value;
            }
        }
        public string paymentForm
        {
            get
            {
                return (this.lblPaymentForm.Text).ToString();
            }
            set
            {
                this.lblPaymentForm.Text = value;
            }
        }
        private Collectors.Helpers.Enums.SystemData SystemData
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["SystemData"]) ? Collectors.Helpers.Enums.SystemData.GP : (Collectors.Helpers.Enums.SystemData)Enum.Parse(typeof(Collectors.Helpers.Enums.SystemData), ConfigurationManager.AppSettings["SystemData"].ToString().ToUpper());
            }
        }
        public IEnumerable<Payment> paymentsList
        {
            get
            {
                return (List<Payment>)(Session["PaymentsList"] ?? new List<Payment>());
            }
            set
            {
                Session["PaymentsList"] = value;
            }
        }
        public String UserName
        {
            get
            {
                Statetrust.Framework.Security.Bll.Usuarios User = (Statetrust.Framework.Security.Bll.Usuarios)Session["userData"];
                return User.UserLogin;
            }
        }
        public string ProductDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Product_Desc";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "Product_Desc";
                }
            }
        }
        public string BusinessLineIdField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Bussiness_Line_Id";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "LINE_OF_BUSINESS";
                }
            }
        }
        public string BusinessLineDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Bl_Desc";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "Bl_Desc";
                }
            }
        }
        public string PolicyStatusDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Policy_Status_Desc";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "POLICY_STATUS";
                }
            }
        }
        public bool backStep
        {
            get
            {
                this.paymentsList = null;
                this.paymentForm = lblPaymentForm.Text = string.Empty;
                return true;
            }
        }
        public bool setGrid
        {
            get {
                gvPaymentsProcessed.DataBind();
                return true;
            }
        }
        Lazy<ProviderServices> PTS = new Lazy<ProviderServices>();
        Lazy<PaymentsService> PS = new Lazy<PaymentsService>();
        Lazy<UtilitiesServices> UTS = new Lazy<UtilitiesServices>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsCallback && !IsPostBack)
            {

            }
            if ((this.Page as Pages.ProcessPayments).ActiveView == "4" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwPaymentConfirmation")
            {
                (this.Page as Pages.ProcessPayments).setStep3 = true;
                this.lblPaymentForm.Text = (this.Page as Pages.ProcessPayments).paymentForm;
                this.gvPaymentsProcessed.DataBind();
            }
            if ((this.Page as Pages.ProcessPayments).ActiveView == "3" && ((this.Page as Pages.ProcessPayments).getActiveView() == "vwSearchClient" || (this.Page as Pages.ProcessPayments).getActiveView() == "vwPoliciesPayments"))
            {
                changeView(1);
            }
        }

        protected void txtTotalAmount_Init(object sender, EventArgs e)
        {
            if (paymentsList != null)
            {
                ASPxLabel label = sender as ASPxLabel;
                GridViewFooterCellTemplateContainer container = label.NamingContainer as GridViewFooterCellTemplateContainer;
                if ((container.Column as GridViewDataColumn).Caption == "Poliza")
                {
                    label.Text = "Total";
                }
                if ((container.Column as GridViewDataColumn).Caption == "Valor pagado")
                {
                    var grid = (ASPxGridView)this.gvPaymentsProcessed;
                    if (string.IsNullOrEmpty(label.Text))
                        label.Text = paymentsList.Sum(r => r.PaidAmount).Value.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }

        private void changeView(int view)
        {
            ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = view.ToString();
            (this.Page as Pages.ProcessPayments).setActiveView(view);
        }

        protected void gvPaymentsProcessed_DataBinding(object sender, EventArgs e)
        {
            this.gvPaymentsProcessed.DataSource = this.paymentsList.ToArray();
        }

        protected void gvPaymentsProcessed_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                int LangID = int.Parse(ConfigurationManager.AppSettings["Language"].ToString());
                LangID = (LangID == 0) ? 1 : LangID;
                if (e.Column.FieldName == "ResponseCode")
                    e.DisplayText = (e.Value.ToString() == "1001" ? "Efectiva" : "Fallida");
                if (e.Column.FieldName == "PaidAmount")
                    e.DisplayText = Decimal.Parse((e.Value ?? "0").ToString()).ToString("c2");
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        if (e.Column.FieldName == BusinessLineDescriptionField || e.Column.FieldName == ProductDescriptionField || e.Column.FieldName == PolicyStatusDescriptionField)
                            e.DisplayText = UTS.Value.getTranslatedTextByLiteralDesc((e.Value ?? string.Empty).ToString(), LangID);
                        break;
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        if (e.Column.FieldName == BusinessLineDescriptionField)
                            e.DisplayText = PS.Value.getBusinessLineByLineCodeGP(int.Parse((e.Value ?? "0").ToString())).Bl_Desc;
                        if (e.Column.FieldName == ProductDescriptionField)
                            e.DisplayText = PS.Value.getProductDescriptionByPlanTypeCodeGP((e.Value ?? "0").ToString());

                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void lnkCloseTransaction_Click(object sender, EventArgs e)
        {
            this.paymentsList = null;
            this.paymentForm = lblPaymentForm.Text = string.Empty;
            changeView(1);
            (this.Page as Pages.ProcessPayments).clearUCClients();
        }

        protected void lnkPrintInvoice_Click(object sender, EventArgs e)
        {
            if (this.paymentsList != null)
            {
                var lstInvoice = PS.Value.generateInvoiceList(paymentsList, new Invoice {
                                                                                    Company = ConfigurationManager.AppSettings["CompanyName"].ToString(),
                                                                                    Rnc = ConfigurationManager.AppSettings["RNC"].ToString(),
                                                                                    Address = ConfigurationManager.AppSettings["MainAddress"].ToString(),
                                                                                    Fax = ConfigurationManager.AppSettings["Fax"].ToString(),
                                                                                    Telephone = ConfigurationManager.AppSettings["Tel"].ToString(),
                                                                                 }, UserName, paymentForm);

                ///First we need to generate the HTML
                //string ParentFolder = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/")).FullName;
                //string templatePath = Path.Combine(ParentFolder, string.Format("{0}{1}", "Content/resources/", ConfigurationManager.AppSettings["InvoiceTemplate"].ToString()));
                //var doc = new HtmlDocument();
                //doc.Load(templatePath);
                //var html = PS.Value.generateInvoiceHTML(lstInvoice, doc);
                ///Then now, we can call JS function to print this HTML generated.
                //string cssURI = Path.Combine(ParentFolder, string.Format("{0}{1}", "Content/css/", ConfigurationManager.AppSettings["InvoiceStyleCSS"].ToString()));
                //Utils.JSExec(this, string.Format("PrintElem(\"{0}\", \"{1}\", \"{2}\");", "#contentInvoice", html.ToString().Replace("\r\n", string.Empty), (cssURI).ToString().Replace("\\", @"/")).ToString());
                //Utils.JSExec(this, string.Format(ResolveUrl("~/Controls/oInvoice.ashx?html=\"{0}\""), html.ToString().Replace("\r\n", string.Empty)));
                //Utils.JSExec(this, string.Format(ResolveUrl("~/Controls/oInvoice.ashx?lstInvoice=\"{0}\""), (new JavaScriptSerializer().Serialize(lstInvoice)).Replace("\"", "'")));
                HttpContext.Current.Session.Add("lstInvoice", null);
                HttpContext.Current.Session["lstInvoice"] = lstInvoice;
                ResponseHelper.Redirect(Response, ResolveUrl("~/Controls/oInvoice.ashx"), "_blank", "menubar=0,titlebar=0, toolbar=0, scrollbars=1,width=1200,height=800,top=10");
            }
            else
                Utils.JSExec(this, "SendAlert('La lista de pagos esta vacía, la factura no puede ser generada, deberá generarla a través del reporte dedicado para tales fines, acceder a: " + ConfigurationManager.AppSettings["URLInvoiceGenerator"].ToString()+"');");
        }
        
    }
}