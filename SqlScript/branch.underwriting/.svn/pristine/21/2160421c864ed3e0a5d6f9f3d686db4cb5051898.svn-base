using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text.pdf;

namespace WSVirtualOffice.Models.businesslogic
{
    public class GeneratePDF
    {
        public static string SOURCE_DOCUMENT = "1. Source Document";
        public static string APPLICATION_AXYS_Y_SCHOLAR = "2. Aplicacion Axys y Scholar";
        public static string APLICACION_LEGACY = "3. Aplicacion Legacy";
        public static string DESIGNACION_PERFIL_PERSONALIZADO= "4. Designacion Perfil Personalizado";
        public static string PLANILLA_PAGOS_AUTOMATICOS= "5. Planilla Pagos Automaticos";
        public static string PLANILLA_PAGOS_ONE_TIME= "6. Planilla Pagos One Time";
        public static string INSTRUCCIONES_TRANSFERENCIA_EN_USD = "7. Instrucciones de Transferencia de STL en USD";
        public static string INSTRUCCIONES_TRANSFERENCIA_EN_EUROS = "8. Instrucciones de Transferencia de STL en EUROS";
        public static string CUESTIONARIO_PARA_DIABETICOS= "10. Cuestionario para Diabeticos";
        public static string CUESTIONARIO_PARA_HIPERTENSOS= "11. Cuestionario para Hipertensos";
        public static string CUESTIONARIO_AVIACION_REC= "12. Cuestionario Aviacion_rec";
        public static string CUESTIONARIO_CACERIA_Y_TIRO= "13. Cuestionario Caceria y Tiro";
        public static string CUESTIONARIO_DEPORTES_PELIGROSOS_PELIGROSOS= "14. Cuestionario Deportes Peligrosos Peligrosos";
        public static string CUESTIONARIO_DEFENSA_PERSONAL= "15. Cuestionario Defensa Personal";
        public static string CUESTIONARIO_ESTADO_FINANCIERO= "16. Cuestionario Estado Financiero";
        public static string CUESTIONARIO_MARINA_MERCANTE= "17. Cuestionario Marina Mercante";
        public static string PLANILLA_CAMBIO_CONDICIONES_DE_POLIZA= "18. Planilla Cambio Condiciones de Poliza";
        public static string PLANILLA_CAMBIOS_PERSONALES= "19. Planilla Cambios Personales";
        public static string SOLICITUD_REHABILITACIÓN_REC= "20. Solicitud Rehabilitación_rec";
        public static string SOLICITUD_CANCELACION_POLIZA = "23. Solicitud Cancelacion Poliza";
        public static string AUTORIZACION_PAGO_CLIENTE = "9. Autorizacion Pago Cliente";
        public static string RECLAMO_DE_SINIESTRO = "22. Reclamo de Siniestro";

        //public static string RECLAMODESINIESTRO = "23. Solicitud Cancelacion Poliza";

        //public static string CUESTIONARIO_PARA_HIPERTENSOS = "21. Cuestionario para Hipertensos";

        //public static string = "22. ";
        //public static string = "23. ";

        public static string CreatePDF(HtmlGenericControl panel1, int userId, bool print, string fileName)
        {
            // Grab each of the values from our windows form
            string outputFileName = "";
            string inputFileName = "";
            if (print == false)
            {
                outputFileName = fileName + "_" + userId + ".pdf";
                inputFileName = fileName + ".pdf";
            }
            else
            {
                outputFileName = fileName + "_print_" + userId + ".pdf";
                inputFileName = fileName + "_print.pdf";
            }
            string outputFilePath = HttpContext.Current.Server.MapPath(".") + @"\pdfs\temp\" + outputFileName;

            // Get pdf from project directory
            PdfReader reader = null;
            try
            {
                reader = new PdfReader(HttpContext.Current.Server.MapPath(".") + @"\pdfs\" + inputFileName);

                // Create the form filler
                using (FileStream pdfOutputFile = new FileStream(outputFilePath, FileMode.Create))
                {
                    PdfStamper formFiller = null;
                    try
                    {
                        formFiller = new PdfStamper(reader, pdfOutputFile);

                        // Get the form fields
                        AcroFields addressChangeForm = formFiller.AcroFields;

                        FillData(panel1, addressChangeForm);

                        formFiller.FormFlattening = true;
                    }
                    finally
                    {
                        if (formFiller != null)
                        {
                            formFiller.Close();
                        }
                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return outputFilePath;
            // Open the created/filled pdf
            //System.Diagnostics.Process.Start(outputFilePath);
        }

        public static void SavePDF(string urlToConvert, string pdfFullPath)
        {
            try
            {
                //Pdf file name
                string downloadName = "E-Forms";
                byte[] bytes = null;

                downloadName += ".pdf";
                //PdfConverter pdfConverter = GetPdfConverter();
                //bytes = pdfConverter.GetPdfBytesFromUrl(urlToConvert);

                //string pdfName = "E-Forms-" + Sessionclass.getSessiondata(session).userid + ".pdf";
                //string pdfFullPath = pdfPath + "\\" + pdfName;

                FileStream fs = new FileStream(pdfFullPath, FileMode.Create);

                byte[] data = new byte[fs.Length];
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletePDF(string pdfFullPath)
        {
            try
            {
                FileInfo pdf = new FileInfo(pdfFullPath);
                if (pdf.Exists)
                    pdf.Delete();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private static void FillData(HtmlGenericControl panel, AcroFields addressChangeForm)
        {
            ControlCollection coll = panel.Controls;
            foreach (Control c in coll)
            {
                // Fill the form
                if (c.GetType().ToString().Substring(c.GetType().ToString().LastIndexOf(".") + 1) == "CheckBox")
                {
                    System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)c;
                    if (cb.Checked == true)
                        addressChangeForm.SetField(cb.ID, "Yes");
                    else
                        addressChangeForm.SetField(cb.ID, "0");
                }
                else if (c.GetType().ToString().Substring(c.GetType().ToString().LastIndexOf(".") + 1) == "RadioButton")
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Checked == true)
                        addressChangeForm.SetField(rb.ID, "Yes");
                    else
                        addressChangeForm.SetField(rb.ID, "0");
                }
                else if (c.GetType().ToString().Substring(c.GetType().ToString().LastIndexOf(".") + 1) == "HtmlGenericControl")
                {
                    HtmlGenericControl p = (HtmlGenericControl)c;
                    FillData(p, addressChangeForm);
                }
                else if (c.GetType().ToString().Substring(c.GetType().ToString().LastIndexOf(".") + 1) == "TextBox")
                {
                    TextBox tb = (TextBox)c;
                    addressChangeForm.SetField(tb.ID, tb.Text);
                    addressChangeForm.SetExtraMargin(0f, 1.5f);
                }
            }
        }
    }
}
