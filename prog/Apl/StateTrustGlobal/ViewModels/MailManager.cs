using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.IO;
using System.Net.Mime;

namespace StateTrustGlobal.ViewModels//STL.VirtualOffice.Infrastructure.Mail
{
    public static class MailManager
    {
        /// <summary>
        /// Método para enviar los Correos.
        /// </summary>
        /// <param name="to">A quien va dirigido, puede contener varias personas separadas por (,).</param>
        /// <param name="copia">A quien va dirigida una copia del mensaje, puede contener varias personas separadas por (,).</param>
        /// <param name="copiaOculta">A quien va dirigida una copia oculta del mensaje, puede contener varias personas separadas por (,).</param>
        /// <param name="body">Cuerpo del Mensaje.</param>
        /// <param name="from">De donde sale el mensaje.</param>
        /// <param name="subject">Asunto del mensaje.</param>
        /// <param name="ishtml">Si el mensaje es HTML.</param>
        /// <param name="host">Host para los mensajes.</param>
        /// <param name="templatePath">Ruta donde se guardan los archivos creados temporalmente.</param>
        /// <param name="templateFinalPath">HTML del template para los mensajes.</param>
        /// <param name="areaLink">Usado para poner algún link en la imagen.</param>
        /// <param name="lstAttached">Lista de los documentos que se van a enviar.</param>
        public static void SendMessage(string to, string @from, string host, string copia = null, string copiaOculta = null, string body = null, string subject = null, bool ishtml = false, string templatePath = "", string templateFinalPath = "", string areaLink = "", List<AttachedFiles> lstAttached = null)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = System.Configuration.ConfigurationSettings.AppSettings["STFEmailHost"];
                client.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["STFEmailPort"]);

                if (String.IsNullOrEmpty(templatePath))
                {
                    MailMessage mail = new MailMessage();
                    if (!String.IsNullOrEmpty(to))
                        if (to.Split(',').Count() > 1)
                            mail.To.Add(to);
                        else
                            mail.To.Add(new MailAddress(to));

                    if (!String.IsNullOrEmpty(copia))
                        if (copia.Split(',').Count() > 1)
                            mail.CC.Add(copia);
                        else
                            mail.CC.Add(new MailAddress(copia));

                    if (!String.IsNullOrEmpty(copiaOculta))
                        if (copiaOculta.Split(',').Count() > 1)
                            mail.Bcc.Add(copiaOculta);
                        else
                            mail.Bcc.Add(new MailAddress(copiaOculta));

                    mail.IsBodyHtml = ishtml;
                    var viewBody = AlternateView.CreateAlternateViewFromString(body, null, "text/" + (ishtml ? "html" : "plain"));
                    mail.Priority = MailPriority.High;
                    mail.AlternateViews.Add(viewBody);
                    mail.Subject = subject;
                    mail.From = new MailAddress(@from);


                    if (lstAttached != null)
                        foreach (var attach in from document in lstAttached
                                               let stream = new MemoryStream(document.DocumentBin)
                                               select new Attachment(stream, document.FileName, MediaTypeNames.Application.Octet)
                                               {
                                                   ContentId = new Random().Next(100000, 9999999).ToString()
                                               })
                        {
                            if (lstAttached.First(o => o.FileName == attach.Name).IsEmbedded)
                            {
                                LinkedResource img = new LinkedResource(attach.ContentStream);
                                img.ContentId = attach.ContentId;
                                var viewImg = AlternateView.CreateAlternateViewFromString("<img src=cid:" + attach.ContentId + "/>", null, "text/html");
                                mail.AlternateViews.Add(viewImg);
                            }
                            else
                                mail.Attachments.Add(attach);
                        }

                    client.Send(mail);
                }
                else
                {
                    string fPathTempFile = String.Format(@"{0}{1}.html", templatePath, Guid.NewGuid());
                    try
                    {
                        using (FileStream fs = File.Create(fPathTempFile))
                        using (var wr = new StreamWriter(fs, System.Text.Encoding.UTF8))
                        {
                            wr.Write(body);
                            wr.Flush();
                        }

                    }
                    catch (Exception jc)
                    {
                        throw new Exception(String.Format("No se ha podido crear el archivo temporal, por favor verifique. Error> {0}", jc));
                    }
                    ClsMailBuilder cs = new ClsMailBuilder();
                    cs.SendMails(ref client, body, fPathTempFile, templatePath, areaLink, templateFinalPath, subject, @from, to, copia, copiaOculta, @from, MailPriority.High, true, lstAttached);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }
        }
    }
}
