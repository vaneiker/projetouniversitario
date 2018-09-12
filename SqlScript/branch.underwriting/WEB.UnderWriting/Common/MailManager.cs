using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;


namespace WEB.UnderWriting.Common
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
        public static void SendMessage(String to, String Copia, String BCC, String Body, String From, String Subject, string Attachments, bool ishtml, String SmtpServer, string templatePath = "", string templateFinalPath = "", string areaLink = "")
        {

            try
            {
                SmtpClient Client = new SmtpClient();
                Client.Host = SmtpServer;

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

        public static void SendMessage(String to, String Copia, String BCC, String Body, string style, String From, String Subject, List<Tools.EmailAttachmentItem> Attachments, bool ishtml, String SmtpServer, string templatePath = "", string templateFinalPath = "", string areaLink = "")
        {

            try
            {
                SmtpClient Client = new SmtpClient();
                Client.Host = SmtpServer;

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


                    foreach (var item in Attachments)
                    {
                        var document = File.OpenRead(item.FilePath);
                        var newAttachment = new Attachment(document, (item.DocName + item.DocExtension));

                        Mensaje.Attachments.Add(newAttachment);
                    }

                    Client.Send(Mensaje);
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

                    cs.SendMails(ref Client, Body, fPathTempFile, templatePath, areaLink, templateFinalPath, Subject, From, to, Copia, BCC, From, MailPriority.High, true, Attachments);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //wcastro 16-05-2017
        public static void SendMessage(String to, String Copia, String BCC, String Body, string style, String From, String Subject, bool ishtml, String SmtpServer, string templatePath = "", string templateFinalPath = "", string areaLink = "", List<Attachment> ata=null)
        {

            try
            {
                SmtpClient Client = new SmtpClient();
                Client.Host = SmtpServer;

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


                    foreach (var item in ata)
                    {
                        Mensaje.Attachments.Add(item);
                    }

                    Client.Send(Mensaje);
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

                    //cs.SendMails(ref Client, Body, fPathTempFile, templatePath, areaLink, templateFinalPath, Subject, From, to, Copia, BCC, From, MailPriority.High, true, Attachments);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //fin wcastro 16-05-2017
    }
}

