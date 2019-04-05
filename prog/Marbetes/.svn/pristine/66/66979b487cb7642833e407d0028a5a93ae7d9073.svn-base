using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text.pdf;

public partial class ListFormFields : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            var pdfs = Directory.GetFiles(Server.MapPath("~/PDFTemplates"), "*.pdf");
            foreach (var pdf in pdfs)
                ddlPDFs.Items.Add(Path.GetFileName(pdf));
        }
    }

    protected void btnShowFields_Click(object sender, EventArgs e)
    {
        var pdfPath = Path.Combine(Server.MapPath("~/PDFTemplates"), ddlPDFs.SelectedValue);

        var fieldInfo = new List<string>();

        var reader = new PdfReader(pdfPath);
        var formFields = reader.AcroFields;
        foreach (DictionaryEntry entry in formFields.Fields)
        {
            var formFieldType = PDFFieldType.GetPDFFieldType(formFields.GetFieldType(entry.Key.ToString()));

            if (formFieldType is PDFCheckBoxFieldType)
                fieldInfo.Add(string.Format("{0} - {1} - Export Value: {2}", 
                                            entry.Key, 
                                            formFieldType, 
                                            PDFHelper.GetExportValue(entry.Value as AcroFields.Item)));
            else
                fieldInfo.Add(string.Format("{0} - {1}", entry.Key, formFieldType));
        }
        reader.Close();

        // Get the form fields for this PDF and bind them to the BulletedList control
        blFields.DataSource = fieldInfo.OrderBy(x => x);
        blFields.DataBind();
    }

    protected void btnGeneratePDF_Click(object sender, EventArgs e)
    {
        var pdfPath = Path.Combine(Server.MapPath("~/PDFTemplates"), ddlPDFs.SelectedValue);
        
        // Get the form fields for this PDF and give them increasing values
        var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);

        var counter = 1;
        foreach (var key in new List<string>(formFieldMap.Keys))
        {
            //formFieldMap[key] = counter.ToString();
            
            if (key[0] != 'c')
                formFieldMap[key] = key;
            else
                formFieldMap[key] = "Yes";
            counter++;
        }
        var pdfContents = PDFHelper.GeneratePDF(pdfPath, formFieldMap);

        PDFHelper.ReturnPDF(pdfContents, ddlPDFs.SelectedValue + "-Sample.pdf");
        //File.WriteAllBytes("C:\\Manuales\\W8.pdf", pdfContents);
    }
}