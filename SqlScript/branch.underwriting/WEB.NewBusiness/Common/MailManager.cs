using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Permissions;
using System.Net.Mime;

namespace WEB.NewBusiness.Common
{
    public static class MailManager
    {

        /// <summary>
        /// Metodo para enviar los Correos 
        /// </summary>
        /// <param name="to">A quien va Dirijido puede contener varias personas separadas por ,</param>
        /// <param name="Body">Cuerpo del Mensaje</param>
        /// <param name="Sender">Correo por el Cual Saldra el Mensaje</param>
        /// <param name="Header">Subject del Mensaje </param>
        public static void SendMessage(String to, String Copia, String BCC, String Body, String From, String Subject, string Attachments, bool ishtml, string templatePath = "", string templateFinalPath = "", string areaLink = "")
        {

            try
            {
                SmtpClient Client = new SmtpClient();
                Client.Host = System.Configuration.ConfigurationSettings.AppSettings["SMTPServer"];
                Client.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Port"]);

                if (String.IsNullOrEmpty(templatePath))
                {
                    MailMessage Mensaje = new MailMessage();
                    if (!String.IsNullOrEmpty(to))
                    {
                        if (to.Split(',').Count() > 1)
                            Mensaje.To.Add(to);
                        else
                            Mensaje.To.Add(new MailAddress(to));
                    }

                    if (!String.IsNullOrEmpty(BCC))
                    {
                        if (BCC.Split(',').Count() > 1)
                            Mensaje.Bcc.Add(BCC);
                        else
                            Mensaje.Bcc.Add(new MailAddress(BCC));
                    }

                    if (!String.IsNullOrEmpty(Copia))
                    {
                        if (Copia.Split(',').Count() > 1)
                            Mensaje.CC.Add(Copia);
                        else
                            Mensaje.CC.Add(new MailAddress(Copia));
                    }

                    Mensaje.IsBodyHtml = ishtml;
                    Mensaje.Priority = MailPriority.High;
                    Mensaje.Body = Body;
                    Mensaje.Subject = Subject;
                    Mensaje.From = new MailAddress(From);
                    Client.Send(Mensaje);
                }
                else
                {
                    Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> <html><body> " + Body + " </body></html>";
                    string fPathTempFile = String.Format(@"{0}{1}.html", templatePath, Guid.NewGuid());
                    try
                    {
                        using (FileStream fs = File.Create(fPathTempFile))
                        {
                            using (StreamWriter wr = new StreamWriter(fs, System.Text.ASCIIEncoding.UTF8))
                            {
                                wr.Write(Body);
                                wr.Flush();
                            }
                        }
                    }
                    catch (Exception jc)
                    {
                        throw new Exception(String.Format("No se ha podido crear el archivo temporal, por favor verifique. Error> {0}", jc.ToString()));
                    }
                    clsMailBuilder cs = new clsMailBuilder();

                    cs.SendMails(ref Client, Body, fPathTempFile, templatePath, areaLink, templateFinalPath, Subject, From, to, Copia, BCC, From, MailPriority.High, true, Attachments);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SendMessage(String to, String Copia, String BCC, String Body, string style, String From, String Subject, List<AttachedFiles> Attachments, bool ishtml, string templatePath = "", string templateFinalPath = "", string areaLink = "")
        {

            try
            {
                var client = new SmtpClient {Host = ConfigurationSettings.AppSettings["SMTPServer"]};
                client.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["Port"]);
                
                if (String.IsNullOrEmpty(templatePath))
                {
                    var mensaje = new MailMessage();
                    if (!String.IsNullOrEmpty(to))
                    {
                        if (to.Split(',').Count() > 1)
                            mensaje.To.Add(to);
                        else
                            mensaje.To.Add(new MailAddress(to));
                    }

                    if (!String.IsNullOrEmpty(BCC))
                    {
                        if (BCC.Split(',').Count() > 1)
                            mensaje.Bcc.Add(BCC);
                        else
                            mensaje.Bcc.Add(new MailAddress(BCC));
                    }

                    if (!String.IsNullOrEmpty(Copia))
                    {
                        if (Copia.Split(',').Count() > 1)
                            mensaje.CC.Add(Copia);
                        else
                            mensaje.CC.Add(new MailAddress(Copia));
                    }

                    mensaje.IsBodyHtml = ishtml;
                    mensaje.Priority = MailPriority.High;
                    mensaje.Body = Body;
                    mensaje.Subject = Subject;
                    mensaje.From = new MailAddress(From);
                    if (Attachments != null && Attachments.Any())
                    {
                        Random rand = new Random();
                        foreach (var r in Attachments)
                        {

                            FileIOPermission permiso = new FileIOPermission(FileIOPermissionAccess.AllAccess, r.FilePath);
                            permiso.Demand();

                            FileStream PDFfs = File.OpenRead(r.FilePath);

                            //PDFfs = new FileStream(r.FilePath, FileMode.Open);
                            //PDFfs = File.Open(, FileMode.Open);
                            //File.SetAttributes(r.FilePath, FileAttributes.Normal);
                            Attachment PDFAttachment = new Attachment(PDFfs, r.FileName, MediaTypeNames.Application.Pdf);
                            PDFAttachment.ContentId = rand.Next(100000, 9999999).ToString();

                            mensaje.Attachments.Add(PDFAttachment);
                            //PDFfs.Close();
                        }
                    }
                    client.Send(mensaje);
                }
                else
                {
                    Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> <html><head><style  type=\"text/css\">" + style + "</style></head><body> " + Body + " </body></html>";
                    string fPathTempFile = String.Format(@"{0}{1}.html", templatePath, Guid.NewGuid());
                    try
                    {
                        using (FileStream fs = File.Create(fPathTempFile))
                        {
                            using (StreamWriter wr = new StreamWriter(fs, System.Text.ASCIIEncoding.UTF8))
                            {
                                wr.Write(Body);
                                wr.Flush();
                            }
                        }
                    }
                    catch (Exception jc)
                    {
                        throw new Exception(String.Format("No se ha podido crear el archivo temporal, por favor verifique. Error> {0}", jc.ToString()));
                    }
                    clsMailBuilder cs = new clsMailBuilder();

                    cs.SendMails(ref client, Body, fPathTempFile, templatePath, areaLink, templateFinalPath, Subject, From, to, Copia, BCC, From, MailPriority.High, true, Attachments);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

