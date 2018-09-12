using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using ReinsuranceComm.UnderWriting.Properties;

namespace ReinsuranceComm.UnderWriting.Model
{
    public class UtilityModel
    {
        public UtilityModel() { }

        /// <summary>
        /// Check on base of a regular expression if the subject has a StepSeqReference and return it.
        /// </summary>
        /// <param name="input">Suject of the email.</param>
        /// <returns>StepSeqReference</returns>
        public string CheckSuject(string input)
        {
            string result;
            Match match;

            match = Regex.Match(input, Settings.Default.Pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                result = match.Groups[1].Value;
            else
                result = string.Empty;

            return
                result;
        }

        public void InsertEmailUnseen(IEnumerable<MessageEntity> emails)
        {
            UnderWritingDIManager diManager;
            IPolicy policyManager;
            Reinsurance.StepAvailable stepAvailable;
            Reinsurance.Communication comm;
            int documentId;

            if (emails != null && emails.Any())
            {
                diManager = new UnderWritingDIManager();
                policyManager = diManager.PolicyManager;

                foreach (MessageEntity mgs in emails)
                {
                    stepAvailable = policyManager.GetStepAvailable(mgs.StepSeqReference);

                    if (stepAvailable != null)
                    {
                        comm = new Reinsurance.Communication
                        {
                            CorpId = stepAvailable.CorpId,
                            RegionId = stepAvailable.RegionId,
                            CountryId = stepAvailable.CountryId,
                            DomesticRegId = stepAvailable.DomesticRegId,
                            StateProvId = stepAvailable.StateProvId,
                            CityId = stepAvailable.CityId,
                            OfficeId = stepAvailable.OfficeId,
                            CaseSeqNo = stepAvailable.CaseSeqNo,
                            HistSeqNo = stepAvailable.HistSeqNo,
                            StepTypeId = stepAvailable.StepTypeId,
                            StepId = stepAvailable.StepId,
                            StepCaseNo = stepAvailable.StepCaseNo,
                            CommunicationId = -1,
                            ReinsurerId = stepAvailable.ReinsurerId,
                            CommTypeId = stepAvailable.CommTypeId,
                            CommText = mgs.Html,
                            CommFrom = mgs.From,
                            CommSubject = mgs.Subject,
                            CommDate = mgs.Date,
                            CommAttachment = mgs.HasAttachment,
                            UserId = Settings.Default.UserId,
                        };

                        comm = policyManager.InsertReinsuranceCommunication(comm);

                        if (mgs.HasAttachment)
                        {
                            comm.UserId = Settings.Default.UserId;

                            foreach (MessageEntity.Attachment att in mgs.Attachments)
                            {
                                documentId = policyManager.SetDocument(att.DocTypeId, att.DocCategoryId, -1, att.Binary, att.Filename, DateTime.Now, null, Settings.Default.UserId);

                                if (documentId > 0)
                                {
                                    comm.DocTypeId = att.DocTypeId;
                                    comm.DocCategoryId = att.DocCategoryId;
                                    comm.DocumentId = documentId;

                                    policyManager.SetReinsuranceCommunicationAttachment(comm);
                                } 
                            }
                        }
                    }
                }
            }
        }
    }
}
