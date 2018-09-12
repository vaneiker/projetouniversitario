using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Permissions;
using System.Threading;


namespace WEB.UnderWriting.Common
{

    /// <summary>
    /// Clase clsMailBuilder
    /// Se encarga de construir  y enviar un correo para que sea recibido de manera embebida en
    /// cualquier cliente de correo.
    /// Author> Juan Coronado
    /// Date> 04.10.2012
    /// 
    /// </summary>
    public class clsMailBuilder
    {
        #region Constructor
        public clsMailBuilder() { }
        #endregion
        #region Definiciones
        private string folderTempPath { get; set; }
        #endregion
        #region Métodos
        #region Métodos Privados


        /// <summary>
        /// Se encarga de manejar la conversión del template a html a un .png
        /// </summary>
        /// <param name="varDataPath">Path del template a convertir</param>
        /// <param name="varBody">Cuerpo del correo a convertir</param>
        /// <returns>string</returns>
        string mtCreateEmailImage(string varDataPath, string varBody)
        {
            #region Definiciones
            string fData = string.Empty;
            bool bDone = false;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            #endregion
            #region Proceso
            var staThread = new Thread(delegate()
            {
                fData = mtCreateFinalImage(varDataPath, varBody);
                bDone = true;
            });


            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();


            while (!bDone)
            {
                endDate = DateTime.Now;
                TimeSpan tsp = endDate.Subtract(startDate);

                System.Windows.Forms.Application.DoEvents();

                if (tsp.Seconds > 50)
                {
                    break;
                }
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
        ImageCodecInfo GetEncoder(ImageFormat format)
        {
            try
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.FormatID == format.Guid)
                    {
                        return codec;
                    }
                }
            }
            catch { }
            return null;
        }

        /// <summary>
        /// Convierte el body a enviar en una imagen
        /// </summary>
        /// <param name="varImgPath">Path de la nueva imagen</param>
        /// <param name="varBody">Cuerpo del correo a convertir</param>
        /// <param name="varPathFinal">Path final</param>
        /// <returns>string</returns>
        string mtCreateFinalImage(string varDataPath, string varBody)
        {
            #region Definiciones
            string fImagenFinal = String.Format(@"{1}{0}.png", Guid.NewGuid(), folderTempPath);
            string fResult = string.Empty;

            #endregion
            #region Proceso

            try
            {

                System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser();
                wb.ScrollBarsEnabled = false;
                wb.ScriptErrorsSuppressed = true;
                var fUri = new Uri(varDataPath);
                wb.Navigate(fUri.AbsoluteUri, false);



                while (wb.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                    System.Windows.Forms.Application.DoEvents();

                System.Threading.Thread.Sleep(1500);

                int width = wb.Document.Body.ScrollRectangle.Width + 25;
                int height = wb.Document.Body.ScrollRectangle.Height + 25;
                wb.Width = width;
                wb.Height = height;

                //Le indico la calidad que quiero que tenga la imagen
                ImageCodecInfo fImgEncoder = GetEncoder(ImageFormat.Png);
                System.Drawing.Imaging.Encoder fEncoder = System.Drawing.Imaging.Encoder.Quality;

                EncoderParameters fEncoderParameters = new EncoderParameters(1);
                EncoderParameter fEncoderParameter = new EncoderParameter(fEncoder, "500L");
                fEncoderParameters.Param[0] = fEncoderParameter;

                //Creo la nueva imagen
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(width, height);
                wb.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, width, height));

                bmp.Save(fImagenFinal, fImgEncoder, fEncoderParameters);
                fResult = fImagenFinal;

            }
            catch (System.Threading.ThreadAbortException lException)
            {


            }
            //catch (Exception jc) { new Exception(String.Format("Ha ocurrido un error generando la imagen a enviar,por favor verifique. Error> {0}", jc.ToString())); }

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
        /// <param name="varTemplatePath">Path del template a procesar (debe de tener todos los campos requeridos llenos)</param>
        /// <param name="varTemplateFinalPath">Path del template final (en este template se agrega la imagen final embebida)</param>
        /// <param name="varSubject">Subject que se le colocará al correo</param>
        /// <param name="varEmailFrom">Dirección de correo que representa a quien envia</param>
        /// <param name="varLstEmailTo">Dirección(es) de correo que representa a quien recibe</param>
        /// <param name="varLstEmailCc">Dirección(es) de correo que representa a quien recibe copia</param>
        /// <param name="varLstEmailBcc">Dirección(es) de correo que representa a quien recibe copia ciega</param>
        /// <param name="varEmailName">Friendly Name con el que se recibirá  el correo</param>
        /// <param name="varMailPriority">Prioridad que se le asignará al correo</param>
        /// <param name="varIsHtml">Indica si el correo se enviará en formato html o no</param>
        public void SendMails(ref SmtpClient varSmtpClient, string varTemplateData, string varTemplatePath, string tempPath, string areaLink, string varTemplateFinalPath, string varSubject, string varEmailFrom, string varLstEmailTo, string varLstEmailCc, string varLstEmailBcc, string varEmailName, MailPriority varMailPriority, bool varIsHtml, string varAttachments)
        {
            try
            {
                #region Definiciones

                Attachment att = null;
                string fTemplatePath = varTemplatePath;
                string fTemplateFinalPath = varTemplateFinalPath;
                folderTempPath = tempPath;
                string fTemplateData = string.Empty;
                string fTemplateDataFinal = string.Empty;
                string fImageFinalPath = string.Empty;
                MailMessage mail = new MailMessage();
                Random rand = new Random();

                #endregion
                #region Validaciones Iniciales
                if (string.IsNullOrEmpty(fTemplatePath))
                    throw new Exception("El path del template a procesar no puede estar en blanco, por favor verifique.");

                if (string.IsNullOrEmpty(fTemplateFinalPath))
                    throw new Exception("El path del template final a procesar no puede estar en blanco, por favor verifique.");

                if (varSmtpClient == null)
                    throw new Exception("El cliente de smtp no puede estar nulo, por favor verifique.");

                #endregion
                #region Lógica

                fTemplateData = varTemplateData;
                //creo la imagen a enviar
                fImageFinalPath = mtCreateEmailImage(fTemplatePath, fTemplateData);
                if (!string.IsNullOrEmpty(fImageFinalPath))
                {
                    System.Net.Mime.ContentType fContentType = new System.Net.Mime.ContentType();

                    using (FileStream fs = File.Open(fImageFinalPath, FileMode.Open))
                    {


                        att = new Attachment(fs, rand.Next(100000, 9999999).ToString());
                        //si se creó la imagen correctamente, procedo a enviarla por correo

                        FileIOPermission permisoFinal = new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write, fTemplateFinalPath);
                        permisoFinal.Demand();

                        //escribo el archivo temporal
                        using (FileStream fs2 = File.OpenRead(fTemplateFinalPath))
                        {
                            StreamReader sr = new StreamReader(fs2);
                            fTemplateDataFinal = sr.ReadToEnd();
                            sr.Close();
                        }

                        //Attachments

                        //if (att != null)

                        //    foreach (var r in varAttachments)
                        //    {

                        //        FileIOPermission permiso = new FileIOPermission(FileIOPermissionAccess.AllAccess, r.FilePath);
                        //        permiso.Demand();

                        //        FileStream PDFfs = File.OpenRead(r.FilePath);

                        //        //PDFfs = new FileStream(r.FilePath, FileMode.Open);
                        //        //PDFfs = File.Open(, FileMode.Open);
                        //        //File.SetAttributes(r.FilePath, FileAttributes.Normal);
                        //        Attachment PDFAttachment = new Attachment(PDFfs, r.FileName, MediaTypeNames.Application.Pdf);
                        //        PDFAttachment.ContentId = rand.Next(100000, 9999999).ToString();

                        //        mail.Attachments.Add(PDFAttachment);
                        //        //PDFfs.Close();
                        //    }

                        //Attachments

                        if (!String.IsNullOrEmpty(varAttachments) && att != null)
                        {
                            FileIOPermission permiso = new FileIOPermission(FileIOPermissionAccess.AllAccess, varAttachments);
                            permiso.Demand();

                            FileStream PDFfs = File.OpenRead(varAttachments);

                            FileInfo ft = new FileInfo(varAttachments);
                            var docName = ft.Name;

                            //PDFfs = new FileStream(r.FilePath, FileMode.Open);
                            //PDFfs = File.Open(, FileMode.Open);
                            //File.SetAttributes(r.FilePath, FileAttributes.Normal);
                            Attachment PDFAttachment = new Attachment(PDFfs, docName, MediaTypeNames.Application.Pdf);
                            PDFAttachment.ContentId = rand.Next(100000, 9999999).ToString();

                            mail.Attachments.Add(PDFAttachment);
                            //PDFfs.Close();
                        }


                        att.ContentId = rand.Next(100000, 9999999).ToString();


                        mail.Attachments.Add(att);

                        fTemplateDataFinal = fTemplateDataFinal.Replace("#Imagen#", String.Format("<img src='cid:{0}' usemap='#m_03'/>", att.ContentId));

                        fTemplateDataFinal = fTemplateDataFinal.Replace("#maps#", String.Format("{0}", areaLink));
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.Subject = varSubject;
                        mail.Priority = varMailPriority;
                        mail.IsBodyHtml = varIsHtml;
                        mail.From = new MailAddress(varEmailFrom, varEmailName);

                        if (!String.IsNullOrEmpty(varLstEmailTo))
                        {
                            if (varLstEmailTo.Split(',').Count() > 1)
                                mail.To.Add(varLstEmailTo);
                            else
                                mail.To.Add(new MailAddress(varLstEmailTo));
                        }

                        if (!String.IsNullOrEmpty(varLstEmailBcc))
                        {
                            if (varLstEmailBcc.Split(',').Count() > 1)
                                mail.Bcc.Add(varLstEmailBcc);
                            else
                                mail.Bcc.Add(new MailAddress(varLstEmailBcc));
                        }

                        if (!String.IsNullOrEmpty(varLstEmailCc))
                        {
                            if (varLstEmailCc.Split(',').Count() > 1)
                                mail.CC.Add(varLstEmailBcc);
                            else
                                mail.CC.Add(new MailAddress(varLstEmailCc));
                        }

                        mail.Body = fTemplateDataFinal;

                        //envio el correo

                        varSmtpClient.Send(mail);
                        mail.Dispose();
                        varSmtpClient.Dispose();
                    }
                }
                else
                    return;

               
                    System.IO.File.Delete(fImageFinalPath);
                    System.IO.File.Delete(fTemplatePath);

                #endregion

            }
            catch (Exception e)
            {
                throw (new Exception(String.Format("Ha ocurrido un error intentando enviar el correo, por favor verifique. Detalle del error> {0}", e.ToString())));
            }
        }

        public void SendMails(ref SmtpClient varSmtpClient, string varTemplateData, string varTemplatePath, string tempPath, string areaLink, string varTemplateFinalPath, string varSubject, string varEmailFrom, string varLstEmailTo, string varLstEmailCc, string varLstEmailBcc, string varEmailName, MailPriority varMailPriority, bool varIsHtml, List<Tools.EmailAttachmentItem> varAttachments)
        {
            try
            {
                #region Definiciones

                Attachment att = null;
                string fTemplatePath = varTemplatePath;
                string fTemplateFinalPath = varTemplateFinalPath;
                folderTempPath = tempPath;
                string fTemplateData = string.Empty;
                string fTemplateDataFinal = string.Empty;
                string fImageFinalPath = string.Empty;
                MailMessage mail = new MailMessage();
                Random rand = new Random();

                #endregion
                #region Validaciones Iniciales
                if (string.IsNullOrEmpty(fTemplatePath))
                    throw new Exception("El path del template a procesar no puede estar en blanco, por favor verifique.");

                if (string.IsNullOrEmpty(fTemplateFinalPath))
                    throw new Exception("El path del template final a procesar no puede estar en blanco, por favor verifique.");

                if (varSmtpClient == null)
                    throw new Exception("El cliente de smtp no puede estar nulo, por favor verifique.");

                #endregion
                #region Lógica

                fTemplateData = varTemplateData;
                //creo la imagen a enviar
                fImageFinalPath = mtCreateEmailImage(fTemplatePath, fTemplateData);
                if (!string.IsNullOrEmpty(fImageFinalPath))
                {
                    System.Net.Mime.ContentType fContentType = new System.Net.Mime.ContentType();

                    using (FileStream fs = File.Open(fImageFinalPath, FileMode.Open))
                    {


                        att = new Attachment(fs, rand.Next(100000, 9999999).ToString());
                        //si se creó la imagen correctamente, procedo a enviarla por correo

                        FileIOPermission permisoFinal = new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write, fTemplateFinalPath);
                        permisoFinal.Demand();

                        //escribo el archivo temporal
                        using (FileStream fs2 = File.OpenRead(fTemplateFinalPath))
                        {
                            StreamReader sr = new StreamReader(fs2);
                            fTemplateDataFinal = sr.ReadToEnd();
                            sr.Close();
                        }

                        //Attachments

                        if (att != null)

                            foreach (var r in varAttachments)
                            {

                                FileIOPermission permiso = new FileIOPermission(FileIOPermissionAccess.AllAccess, r.FilePath);
                                permiso.Demand();

                                FileStream PDFfs = File.OpenRead(r.FilePath);

                                //PDFfs = new FileStream(r.FilePath, FileMode.Open);
                                //PDFfs = File.Open(, FileMode.Open);
                                //File.SetAttributes(r.FilePath, FileAttributes.Normal);
                                Attachment PDFAttachment = new Attachment(PDFfs, r.DocName, MediaTypeNames.Application.Pdf);
                                PDFAttachment.ContentId = rand.Next(100000, 9999999).ToString();

                                mail.Attachments.Add(PDFAttachment);
                                //PDFfs.Close();
                            }


                        att.ContentId = rand.Next(100000, 9999999).ToString();

                        mail.Attachments.Add(att);

                        fTemplateDataFinal = fTemplateDataFinal.Replace("#Imagen#", String.Format("<img src='cid:{0}' usemap='#m_03'/>", att.ContentId));

                        fTemplateDataFinal = fTemplateDataFinal.Replace("#maps#", String.Format("{0}", areaLink));
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.Subject = varSubject;
                        mail.Priority = varMailPriority;
                        mail.IsBodyHtml = varIsHtml;
                        mail.From = new MailAddress(varEmailFrom, varEmailName);

                        if (!String.IsNullOrEmpty(varLstEmailTo))
                        {
                            if (varLstEmailTo.Split(',').Count() > 1)
                                mail.To.Add(varLstEmailTo);
                            else
                                mail.To.Add(new MailAddress(varLstEmailTo));
                        }

                        if (!String.IsNullOrEmpty(varLstEmailBcc))
                        {
                            if (varLstEmailBcc.Split(',').Count() > 1)
                                mail.Bcc.Add(varLstEmailBcc);
                            else
                                mail.Bcc.Add(new MailAddress(varLstEmailBcc));
                        }

                        if (!String.IsNullOrEmpty(varLstEmailCc))
                        {
                            if (varLstEmailCc.Split(',').Count() > 1)
                                mail.CC.Add(varLstEmailBcc);
                            else
                                mail.CC.Add(new MailAddress(varLstEmailCc));
                        }

                        mail.Body = fTemplateDataFinal;

                        //envio el correo

                        varSmtpClient.Send(mail);
                        mail.Dispose();
                        varSmtpClient.Dispose();
                    }
                }
                else
                    return;

                    System.IO.File.Delete(fImageFinalPath);
                    System.IO.File.Delete(fTemplatePath);
                #endregion

            }
            catch (Exception e)
            {
                throw (new Exception(String.Format("Ha ocurrido un error intentando enviar el correo, por favor verifique. Detalle del error> {0}", e.ToString())));
            }
        }
        #endregion
        #endregion
    }
}
