using System;
using System.Collections.Generic;
using System.Linq;
using ActiveUp.Net.Mail;
using ReinsuranceComm.UnderWriting.Properties;

namespace ReinsuranceComm.UnderWriting.Model
{
    public class EmailManager
    {
        private UtilityModel _utility;
        public EmailManager()
        {
            _utility = new UtilityModel();
        }

        public void StartProcess()
        {
            IEnumerable<Message> unseenEmails;
            IEnumerable<MessageEntity> bdEmails;

            Console.WriteLine("\tStart - Downloading emails.");
            unseenEmails = this.GetEmailsUnseen();
            Console.WriteLine("\tEnd - Downloading emails.");
            
            Console.WriteLine();

            Console.WriteLine("\tStart - Convert emails.");
            bdEmails = ConvertInboxToBD(unseenEmails);
            Console.WriteLine("\tEnd - Convert emails.");

            Console.WriteLine();

            Console.WriteLine("\tStart - Insert emails.");
            _utility.InsertEmailUnseen(bdEmails);
            Console.WriteLine("\tEnd - Insert emails.");           
        }

        public IEnumerable<MessageEntity> ConvertInboxToBD(IEnumerable<Message> unseenEmails)
        {
            List<MessageEntity> bdEmails;
            List<MessageEntity.Attachment> bdEmailAttchs;
            MessageEntity bdEmail;
            MessageEntity.Attachment bdEmailAttch;
            string stepSeqReference;
            bool hasAttachment;
            DateTime date;
            int docTypeId;

            if (unseenEmails != null && unseenEmails.Any())
            {
                bdEmails = new List<MessageEntity>(1);

                foreach (Message msg in unseenEmails)
                {
                    stepSeqReference = _utility.CheckSuject(msg.Subject);

                    if (!string.IsNullOrWhiteSpace(stepSeqReference))
                    {
                        hasAttachment = msg.Attachments != null && msg.Attachments.Count > 0;

                        if (!DateTime.TryParse(msg.DateString, out date))
                            date = default(DateTime);

                        if (hasAttachment)
                        {
                            bdEmailAttchs = new List<MessageEntity.Attachment>(1);

                            for (int i = 0; i < msg.Attachments.Count; i++)
                            {
                                docTypeId = this.GetDocTypeIdByMimeType(msg.Attachments[i].MimeType);

                                if (docTypeId != -1)
                                {
                                    bdEmailAttch = new MessageEntity.Attachment
                                    {
                                        Filename = this.TakeOffExtensionFileName(msg.Attachments[i].Filename),
                                        Binary = msg.Attachments[i].BinaryContent,
                                        DocTypeId = docTypeId,
                                        DocCategoryId = 172 //ReinsuranceEmailAttachment
                                    };

                                    bdEmailAttchs.Add(bdEmailAttch);
                                }
                            }
                        }
                        else
                            bdEmailAttchs = null;

                        bdEmail = new MessageEntity
                        {
                            StepSeqReference = stepSeqReference,
                            Html = msg.BodyHtml.Text,
                            From = msg.From.Email,
                            Subject = msg.Subject,
                            Date = date,
                            HasAttachment = hasAttachment,
                            Attachments = bdEmailAttchs
                        };

                        bdEmails.Add(bdEmail);
                    }
                }

            }
            else
                bdEmails = null;

            return
                bdEmails.AsEnumerable();
        }

        private IEnumerable<Message> GetEmailsUnseen()
        {
            Imap4Client eClient;
            Mailbox inbox;
            int[] aUnseen;
            Message unseenEmail;
            List<Message> result;

            eClient = new Imap4Client();
            result = new List<Message>(1);

            try
            {
                eClient.ConnectSsl(Settings.Default.HostName, Settings.Default.Port);
                eClient.Login(Settings.Default.UserName, Settings.Default.Password);

                inbox = eClient.SelectMailbox("inbox");
                //This method return an array of ints that represent the emails that are unseen.
                aUnseen = inbox.Search("UNSEEN");

                for (int i = 0; i < aUnseen.Length; i++)
                {
                    unseenEmail = inbox.Fetch.MessageObject(aUnseen[i]);
                    result.Add(unseenEmail);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (eClient != null)
                {
                    eClient.Close();
                    eClient.Disconnect();
                }
            }

            return
                result.AsEnumerable();

        }
        private int GetDocTypeIdByMimeType(string mimeType)
        {
            int result, index;

            if (!string.IsNullOrWhiteSpace(mimeType))
            {
                mimeType = mimeType.Trim();

                index = Settings.Default.MimeTypeList.IndexOf(mimeType);

                result = index >= 0
                    ? int.Parse(Settings.Default.DocCatIdList[index])
                    : -1;
            }
            else
                result = -1;

            return
                result;
        }
        private string TakeOffExtensionFileName(string fileName)
        {
            string result;
            int index;

            result = string.Empty;

            if (!string.IsNullOrWhiteSpace(fileName))
            {
                fileName = fileName.Trim();
                index = fileName.LastIndexOf(".");

                if (index >= 0)
                    result = fileName.Substring(0, index);
            }

            return
                result;
        }
    }
}
