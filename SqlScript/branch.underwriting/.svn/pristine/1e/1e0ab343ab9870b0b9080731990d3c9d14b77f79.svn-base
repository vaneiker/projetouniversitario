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
using System.Net.Mail;
namespace WSVirtualOffice.Models.businesslogic
{
    public class Mail
    {
        public static string SendMail(string emailid, string subject, string body, string attachment)
        {
            MailMessage mail = new MailMessage();

            try
            {
                mail.To.Add(emailid);
                //mail.To.Add("sriharsha2410@gmail.com");

                mail.From = new MailAddress("webmaster@webillustrator.com");
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                mail.Attachments.Add(new Attachment(attachment));

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("snigdhatechnoservices@gmail.com", "snigdha12345");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                mail.Dispose();
                
                return null;
            }
            catch (Exception ex)
            {
                mail.Dispose();
                throw ex;
            }
        }
    }
}
