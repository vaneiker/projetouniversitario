﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Configuration;

namespace STL.POS.Frontend.Web.Helpers
{
    public static class SendEmailHelper
    {

        public static string ReplaceTokens(string body, Dictionary<string, string> tokens)
        {
            var outText = body;

            foreach (var key in tokens.Keys)
            {
                outText = outText.Replace(key, tokens[key]);
            }

            return outText;
        }

        public static void SendMail(string fromAddress, List<string> destinationAddresses, string subject, string body, string attachmentFilename)
        {
            if (SendEmail())
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = System.Configuration.ConfigurationSettings.AppSettings["STFEmailHost"];
                smtpClient.Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["STFEmailPort"]);

                MailMessage message = new MailMessage();
                MailAddress fromAddressObj = new MailAddress(fromAddress);

                message.From = fromAddressObj;
                message.Sender = fromAddressObj;
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                foreach (var recipient in destinationAddresses)
                    message.To.Add(recipient);

                if (attachmentFilename != null)
                    message.Attachments.Add(new Attachment(attachmentFilename));

                try
                {
                    smtpClient.Send(message);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Log(Data.Categories.Error, "smtpError", -1, "Error Smtp", "Error", ex);
                }

            }
        }

        public static bool ValidAddresses(List<string> addresses)
        {
            try
            {
                MailAddress m;
                foreach (string adr in addresses)
                    m = new MailAddress(adr);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool SendEmail()
        {
            bool result;
            string value;

            try
            {
                value = ConfigurationManager.AppSettings["SendEmail"].ToString();
            }
            catch (Exception)
            {
                value = string.Empty;
            }

            if (!bool.TryParse(value, out result))
                result = true;

            return
                result;
        }

    }
}