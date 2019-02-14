using CollectorsModule.bll.Services;
using CollectorsModule.ell;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CollectorsModule.Commons
{
    /// <summary>
    /// Summary description for oInvoice
    /// </summary>
    public class oInvoice : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var lstInvoice = context.Session["lstInvoice"];
                var rePrint = context.Request.QueryString["rePrint"];
                Lazy<PaymentsService> PS = new Lazy<PaymentsService>();
                if (rePrint != null)
                {
                    string barcode = context.Request.QueryString["Barcode"]; ;
                    if (!string.IsNullOrEmpty(barcode))
                    {
                        string batch = PS.Value.getPaymentBatchByBarcode(barcode);
                        var paymentsList = PS.Value.getPaymentsByBatch(batch);
                        var paymentsListFst = paymentsList.FirstOrDefault();
                        var lstInvoice_rp = PS.Value.generateInvoiceList(paymentsList, new Invoice
                        {
                            Company = ConfigurationManager.AppSettings["CompanyName"].ToString(),
                            Rnc = ConfigurationManager.AppSettings["RNC"].ToString(),
                            Address = ConfigurationManager.AppSettings["MainAddress"].ToString(),
                            Fax = ConfigurationManager.AppSettings["Fax"].ToString(),
                            Telephone = ConfigurationManager.AppSettings["Tel"].ToString(),
                        }, paymentsListFst.Cashier, paymentsListFst.Payment_Form);

                        HttpContext.Current.Session.Add("lstInvoice", null);
                        lstInvoice = lstInvoice_rp;
                    }
                    else
                        context.Response.Write("La lista de pagos esta vacía, la factura no puede ser generada, deberá generarla a través del reporte dedicado para tales fines, acceder a: " + ConfigurationManager.AppSettings["URLInvoiceGenerator"].ToString() + "");
                }
                if (lstInvoice == null) { return; }
                var invoices = (IEnumerable<Invoice>)lstInvoice;

                string ParentFolder = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/")).FullName;
                string templatePath = Path.Combine(ParentFolder, string.Format("{0}{1}", "Content/resources/", ConfigurationManager.AppSettings["InvoiceTemplate"].ToString()));
                var doc = new HtmlDocument();
                doc.OptionDefaultStreamEncoding = System.Text.Encoding.UTF8;
                doc.Load(templatePath);
                var oHtml = PS.Value.generateInvoiceHTML(invoices, doc);
                if (!string.IsNullOrEmpty(rePrint) && rePrint == "Yes")
                    oHtml = oHtml.Replace("<!-- {0} -->", "rePrint();");
                string fileName = string.Empty, contentType = "text/html";
                fileName = ("Factura") + ".html";
                context.Response.Buffer = true;
                context.Response.Charset = "";
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = contentType;
                context.Response.Write(oHtml);
                context.Session.Remove("lstInvoice");
                context.Response.Flush();
                context.Response.End();
            }
            catch (Exception ex)
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}