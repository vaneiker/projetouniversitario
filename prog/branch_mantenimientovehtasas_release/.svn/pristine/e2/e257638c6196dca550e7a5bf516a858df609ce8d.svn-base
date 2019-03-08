using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Permissions;
using System.Threading;
using System.Net.Mail;
using System.Text;


namespace StateTrustGlobal.ViewModels//STL.VirtualOffice.Infrastructure.Mail
{
    /// <summary>
    /// Clase clsMailBuilder
    /// Se encarga de construir  y enviar un correo para que sea recibido de manera embebida en
    /// cualquier cliente de correo.
    /// Author> Juan Coronado
    /// Date> 04.10.2012
    /// </summary>
    public class ClsMailBuilder
    {
        #region Definiciones
        private string FolderTempPath { get; set; }
        private int WidthImage { get; set; }
        private int HeightImage { get; set; }
        #endregion

        #region Métodos
        #region Métodos Privados

        /// <summary>
        /// Se encarga de manejar la conversión del template a html a un .png
        /// </summary>
        /// <param name="varDataPath">Path del template a convertir</param>
        /// <returns>string</returns>
        string MtCreateEmailImage(string varDataPath)
        {
            #region Definiciones
            string fData = string.Empty;
            bool bDone = false;
            DateTime startDate = DateTime.Now;
            #endregion

            #region Proceso
            var staThread = new Thread((ThreadStart)delegate
            {
                fData = MtCreateFinalImage(varDataPath);
                bDone = true;
            });


            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();

            while (!bDone)
            {
                DateTime endDate = DateTime.Now;
                TimeSpan tsp = endDate.Subtract(startDate);

                System.Windows.Forms.Application.DoEvents();

                if (tsp.Seconds > 50)
                    break;
            }
            staThread.Abort();
            #endregion

            #region Salida
            return fData;
            #endregion
        }
        /// <summary>
        /// Retorna el encoding de una imagen
        /// </summary>
        /// <param name="format">Formato de la imagen a evaluar</param>
        /// <returns>ImageCodecInfo</returns>
        static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            try
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs.Where(codec => codec.FormatID == format.Guid))
                    return codec;

            }
            catch
            { }
            return null;
        }

        /// <summary>
        /// Convierte el body a enviar en una imagen
        /// </summary>
        /// <param name="varDataPath"></param>
        /// <exception cref="Exception"></exception>
        /// <returns>string</returns>
        string MtCreateFinalImage(string varDataPath)
        {
            #region Definiciones
            string fImagenFinal = String.Format(@"{1}{0}.png", Guid.NewGuid(), FolderTempPath);
            string fResult;
            #endregion

            #region Proceso
            try
            {
                var wb = new System.Windows.Forms.WebBrowser
                    {
                        ScrollBarsEnabled = false,
                        ScriptErrorsSuppressed = true
                    };
                var fUri = new Uri(varDataPath);
                wb.Navigate(fUri.AbsoluteUri, false);

                while (wb.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                    System.Windows.Forms.Application.DoEvents();

                Thread.Sleep(1500);

                if (wb.Document != null)
                    if (wb.Document.Body != null)
                    {
                        int width = wb.Document.Body.ScrollRectangle.Width + 25;
                        int height = wb.Document.Body.ScrollRectangle.Height + 25;
                        WidthImage = width;
                        HeightImage = height;
                        wb.Width = width;
                        wb.Height = height;

                        //Le indico la calidad que quiero que tenga la imagen
                        ImageCodecInfo fImgEncoder = GetEncoder(ImageFormat.Png);
                        System.Drawing.Imaging.Encoder fEncoder = System.Drawing.Imaging.Encoder.Quality;

                        var fEncoderParameters = new EncoderParameters(1);
                        var fEncoderParameter = new EncoderParameter(fEncoder, "500L");
                        fEncoderParameters.Param[0] = fEncoderParameter;

                        //Creo la nueva imagen
                        var bmp = new System.Drawing.Bitmap(width, height);
                        wb.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, width, height));

                        bmp.Save(fImagenFinal, fImgEncoder, fEncoderParameters);
                    }
                fResult = fImagenFinal;

            }
            catch (Exception jc) { throw new Exception(String.Format("Ha ocurrido un error generando la imagen a enviar,por favor verifique. Error> {0}", jc)); }

            #endregion
            #region Salida
            return fResult;
            #endregion
        }
        #endregion
        #region Métodos Públicos

        /// <summary>
        /// Se encarga de procesar la plantilla a enviar.
        /// </summary>
        /// <param name="varSmtpClient">Cliente Smtp (debe estar instanciado)</param>
        /// <param name="varTemplateData"></param>
        /// <param name="varTemplatePath">Path del template a procesar (debe de tener todos los campos requeridos llenos)</param>
        /// <param name="areaLink">Usado para poner algún link en la imagen.</param>
        /// <param name="varTemplateFinalPath">HTML del template final (en este template se agrega la imagen final embebida)</param>
        /// <param name="varSubject">Subject que se le colocará al correo</param>
        /// <param name="varEmailFrom">Dirección de correo que representa a quien envia</param>
        /// <param name="varLstEmailTo">Dirección(es) de correo que representa a quien recibe</param>
        /// <param name="varLstEmailCc">Dirección(es) de correo que representa a quien recibe copia</param>
        /// <param name="varLstEmailBcc">Dirección(es) de correo que representa a quien recibe copia ciega</param>
        /// <param name="varEmailName">Friendly Name con el que se recibirá  el correo</param>
        /// <param name="varMailPriority">Prioridad que se le asignará al correo</param>
        /// <param name="varIsHtml">Indica si el correo se enviará en formato html o no</param>
        /// <param name="tempPath">Ruta temporal donde se guardan los archivos.</param>
        /// <param name="lstAttached">Lista de los documentos que se van a enviar.</param>
        public void SendMails(ref SmtpClient varSmtpClient, string varTemplateData, string varTemplatePath, string tempPath, string areaLink, string varTemplateFinalPath, string varSubject, string varEmailFrom, string varLstEmailTo, string varLstEmailCc, string varLstEmailBcc, string varEmailName, MailPriority varMailPriority, bool varIsHtml, List<AttachedFiles> lstAttached)
        {
            try
            {
                #region Definiciones

                Attachment att;
                string fTemplatePath = varTemplatePath;
                FolderTempPath = tempPath;
                string fTemplateDataFinal = varTemplateFinalPath;
                string fImageFinalPath;
                var mail = new MailMessage();
                var rand = new Random();

                #endregion

                #region Validaciones Iniciales
                if (string.IsNullOrEmpty(fTemplatePath))
                    throw new Exception("El path del template a procesar no puede estar en blanco, por favor verifique.");

                if (varSmtpClient == null)
                    throw new Exception("El cliente de smtp no puede estar nulo, por favor verifique.");

                #endregion

                #region Lógica

                //creo la imagen a enviar
                fImageFinalPath = MtCreateEmailImage(fTemplatePath);
                if (!string.IsNullOrEmpty(fImageFinalPath))
                {
                    using (FileStream fs = File.Open(fImageFinalPath, FileMode.Open))
                    {
                        att = new Attachment(fs, rand.Next(100000, 9999999).ToString(CultureInfo.InvariantCulture));

                        att.ContentId = rand.Next(100000, 9999999).ToString(CultureInfo.InvariantCulture);
                        FileIOPermission permisoFinal = new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write, fTemplateDataFinal);
                        permisoFinal.Demand();

                        //escribo el archivo temporal
                        using (FileStream fs2 = File.OpenRead(fTemplateDataFinal))
                        {
                            StreamReader sr = new StreamReader(fs2);
                            fTemplateDataFinal = sr.ReadToEnd();
                            sr.Close();
                        }
                        mail.Attachments.Add(att);
                        fTemplateDataFinal = fTemplateDataFinal.Replace("#Imagen#", String.Format("<img src='cid:{0}' usemap='#m_03'/>", att.ContentId));

                        fTemplateDataFinal = fTemplateDataFinal.Replace("#maps#", String.Format("{0}", areaLink));
                        mail.BodyEncoding = Encoding.UTF8;
                        mail.Subject = varSubject;
                        mail.Priority = varMailPriority;
                        mail.IsBodyHtml = varIsHtml;
                        mail.From = new MailAddress(varEmailFrom, varEmailName);

                        if (!String.IsNullOrEmpty(varLstEmailTo))
                            if (varLstEmailTo.Split(',').Count() > 1)
                                mail.To.Add(varLstEmailTo);
                            else
                                mail.To.Add(new MailAddress(varLstEmailTo));

                        if (!String.IsNullOrEmpty(varLstEmailCc))
                            if (varLstEmailCc.Split(',').Count() > 1)
                                mail.CC.Add(varLstEmailCc);
                            else
                                mail.CC.Add(new MailAddress(varLstEmailCc));

                        if (!String.IsNullOrEmpty(varLstEmailBcc))
                            if (varLstEmailBcc.Split(',').Count() > 1)
                                mail.Bcc.Add(varLstEmailBcc);
                            else
                                mail.Bcc.Add(new MailAddress(varLstEmailBcc));

                        mail.Body = fTemplateDataFinal;

                        if (lstAttached != null)
                            foreach (var attach in from document in lstAttached
                                                   let stream = new MemoryStream(document.DocumentBin)
                                                   select new Attachment(stream, document.FileName, MediaTypeNames.Application.Octet)
                                                       {
                                                           ContentId = new Random().Next(100000, 9999999).ToString()
                                                       })
                                mail.Attachments.Add(attach);


                        //envio el correo
                        varSmtpClient.Send(mail);
                        //varSmtpClient.Dispose();
                    }
                }
                else
                    return;

                try
                {
                    File.Delete(fImageFinalPath);
                    File.Delete(fTemplatePath);
                }
                catch (Exception)
                {

                }

                #endregion

            }
            catch (Exception e)
            {
                throw (new Exception(String.Format("Ha ocurrido un error intentando enviar el correo, por favor verifique. Detalle del error> {0}", e)));
            }

        }
        #endregion
        #endregion
    }
}
