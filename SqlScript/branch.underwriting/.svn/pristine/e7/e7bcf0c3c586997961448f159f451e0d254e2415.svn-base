using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration
{
    public partial class UCPrintingInvoice : UC, IUC
    {
        public class Invoice
        {
            public DateTime InvoiceDate { get; set; }
            public string InvoiceNumber { get; set; }
            public string Concept { get; set; }
        }

        public IEnumerable<Utility.InvoiceData> dataSysFlexInvoce
        {
            get
            {
                return ViewState["dataSysFlexInvoce"] as IEnumerable<Utility.InvoiceData>;
            }
            set
            {
                ViewState["dataSysFlexInvoce"] = value;
            }
        }


        public string SelectedPolicy
        {
            get
            {
                return ViewState["SelectedPolicy"].ToString();
            }
            set
            {
                ViewState["SelectedPolicy"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewerMyPreviewPDF.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"];
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            if (string.IsNullOrEmpty(txtPolicyNumber.Text))
            {
                this.MessageBox("Debe indicar el numero de poliza a buscar");
                return;
            }

            var policyNumber = txtPolicyNumber.Text;
            var datajsonInvoices = ObjServices.oSFPolicyServiceClient.GetInvoices(policyNumber);
            var hasError = ObjServices.ErrorCode.Contains(datajsonInvoices.Code);

            if (hasError)
            {
                this.MessageBox(string.Format("Error :  {0}", datajsonInvoices.Message));
                return;
            }

            if (string.IsNullOrEmpty(datajsonInvoices.JSONResult) || datajsonInvoices.JSONResult == "[]")
            {
                this.MessageBox("La busqueda no arrojo nigun resultado");
                return;
            }

            var dInvoices = Utility.deserializeJSON<List<Utility.InvoiceData>>(datajsonInvoices.JSONResult);
            dataSysFlexInvoce = dInvoices;
            var data = dInvoices.Select(x => new Invoice
            {
                InvoiceDate = x.Fecha.GetValueOrDefault(),
                InvoiceNumber = x.FacturaNumero,
                Concept = x.Concepto
            });

            gvInvoices.DataSource = data;
            gvInvoices.DataBind();
        }

        public void Initialize()
        {
            gvInvoices.DataSource = null;
            gvInvoices.DataBind();
            txtPolicyNumber.Text = SelectedPolicy;
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillData();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            var InvoiceNumber = "";

            for (int i = gvInvoices.VisibleStartIndex; i < gvInvoices.VisibleRowCount; i++)
            {
                var chk = gvInvoices.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;
                if (chk != null && chk.Checked)
                {
                    InvoiceNumber = gvInvoices.GetKeyFromAspxGridView("InvoiceNumber", i).ToString();
                    break;
                }
            }

            if (!string.IsNullOrEmpty(InvoiceNumber))
            {
                //Imprimir factura
                var record = dataSysFlexInvoce.FirstOrDefault(r => r.FacturaNumero == InvoiceNumber);

                if (record != null)
                {
                    var xml = ObjServices.GenerateXMLInvoiceToThunderhead(record);
                    var PDFByteArray = ObjServices.SendToThunderHead(xml, ThunderheadWrap.Service.TemplateType.FacturaSysFlex);

                    pdfViewerMyPreviewPDF.PdfSourceBytes = PDFByteArray;
                    pdfViewerMyPreviewPDF.DataBind();
                    mpeFactura.Show();
                    hdnPopFactura.Value = "true";
                }
                else
                    this.MessageBox("No se pudo, mostrar la factura ya que no se encontraron datos para mostrar");
            }
        }
    }
}