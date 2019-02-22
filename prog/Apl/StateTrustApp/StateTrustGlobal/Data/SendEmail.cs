using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StateTrustGlobal.Data
{
    public class SendEmail
    {
        public void SendVirtualOfficeMail(string emailto, string FromEmail, string emailsubject, string msg, string CopiaEmail, string CopiaOcultaEmail)
        {
            StateTrustGlobal.ViewModels.MailManager.SendMessage
                (
                emailto,
                FromEmail,
                //"statetrustlife-com.mail.protection.outlook.com",
                //"smtpdev.statetrustlife.com",
                System.Configuration.ConfigurationManager.AppSettings["STFEmailHost"],
                CopiaEmail,
                CopiaOcultaEmail,
                msg,
                emailsubject,
                true,
                "",
                "",
                "",
                null
                );
            return;
        }
    }
}
