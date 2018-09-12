using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class ContactBll : IContact
    {
        private ContactManager _contactManager;

        public ContactBll()
        {
            _contactManager = new ContactManager();
        }

        Contact IContact.GetContact(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? contactRoleTypeId, int languageId)
        {
            return
                _contactManager.GetContact(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId, languageId);
        }
        Contact IContact.GetContact(int coprId, int contactId, int languageId)
        {
            return
                _contactManager.GetContact(coprId, contactId, languageId);
        }
        Contact IContact.GetContactSummary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? contactRoleTypeId)
        {
            return
                _contactManager.GetContactSummary(coprId, regionId, countryId, domesticRegId, stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, contactRoleTypeId);
        }

        int IContact.UpdateContact(Contact contact)
        {
            return
                _contactManager.UpdateContact(contact);
        }

        IEnumerable<Contact.Citizenship> IContact.GetContactCitizenshipByContact(int contactId)
        {
            return
                _contactManager.GetContactCitizenshipByContact(contactId);
        }

        IEnumerable<Contact.CitizenQuestion> IContact.GetContactCitizenQuestionByContact(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int languageId)
        {
            return
                _contactManager.GetContactCitizenQuestionByContact(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, languageId);
        }

        IEnumerable<Contact.CitizenQuestion> IContact.GetContactCitizenQuestionByContactJuridico(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? Agent_Legal, int languageId)
        {
            return
                _contactManager.GetContactCitizenQuestionByContactJuridico(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, Agent_Legal, languageId);
        }

        IEnumerable<Contact.SocialExposure> IContact.GetContactSocialExposureByContact(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int languageId)
        {
            return
                _contactManager.GetContactSocialExposureByContact(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, languageId);
        }

        IEnumerable<Contact.SocialExposure> IContact.GetContactSocialExposureByContactJuridico(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? Agent_Legal, int languageId)
        {
            return
                _contactManager.GetContactSocialExposureByContactJuridico(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, Agent_Legal, languageId);
        }

        IEnumerable<Contact.SocialExposureRelationship> IContact.GetContactSocialExposureRelationshipByContact(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int languageId)
        {
            return
                _contactManager.GetContactSocialExposureRelationshipByContact(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, contactId, languageId);
        }

        IEnumerable<Contact.SocialExposureRelationship> IContact.GetContactSocialExposureRelationshipByContactJuridico(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? Agent_Legal, int languageId)
        {
            return
                _contactManager.GetContactSocialExposureRelationshipByContact(coprId, regionId, countryId, domesticRegId
                , stateProvId, cityId, officeId, caseSeqNo, histSeqNo, Agent_Legal, languageId);
        }

        int IContact.InsertContactCitizenship(Contact.Citizenship citizenship)
        {
            return
               _contactManager.InsertContactCitizenship(citizenship);
        }

        int IContact.DeleteContactCitizenship(Contact.Citizenship citizenship)
        {
            return
                _contactManager.DeleteContactCitizenship(citizenship);
        }

        int IContact.UpdateContactCitizenQuestionByContact(Contact.CitizenQuestion question)
        {
            return
                 _contactManager.UpdateContactCitizenQuestionByContact(question);
        }

        int IContact.UpdateContactCitizenQuestionByContactJuridico(Contact.CitizenQuestion question)
        {
            return
                 _contactManager.UpdateContactCitizenQuestionByContactJuridico(question);
        }

        int IContact.UpdateContactSocialExposureByContact(Contact.SocialExposure socialExposure)
        {
            return
                _contactManager.UpdateContactSocialExposureByContact(socialExposure);
        }

        int IContact.UpdateContactSocialExposureByContactJuridico(Contact.SocialExposure socialExposure)
        {
            return
                _contactManager.UpdateContactSocialExposureByContactJuridico(socialExposure);
        }

        int IContact.UpdateContactSocialExposureRelationshipByContact(Contact.SocialExposureRelationship socialExposureRelationship)
        {
            return
                _contactManager.UpdateContactSocialExposureRelationshipByContact(socialExposureRelationship);
        }

        int IContact.UpdateContactSocialExposureRelationshipByContactJuridico(Contact.SocialExposureRelationship socialExposureRelationship)
        {
            return
                _contactManager.UpdateContactSocialExposureRelationshipByContactJuridico(socialExposureRelationship);
        }

        void IContact.GetCommunicatonAll(int corpId, int contactId, int languageId, out IEnumerable<Contact.Address> adresses, out IEnumerable<Contact.Phone> phones, out IEnumerable<Contact.Email> emails)
        {
            _contactManager.GetCommunicatonAll(corpId, contactId, languageId, out  adresses, out  phones, out emails);
        }

        void IContact.GetCommunicatonAllJuridico(int corpId, int contactId, int languageId, out IEnumerable<Contact.Address> adresses, out IEnumerable<Contact.Phone> phones, out IEnumerable<Contact.Email> emails)
        {
            _contactManager.GetCommunicatonAllJuridico(corpId, contactId, languageId, out adresses, out phones, out emails);
        }

        IEnumerable<Contact.Address> IContact.GetCommunicatonAdress(int corpId, int contactId, int languageId)
        {
            return
               _contactManager.GetCommunicatonAdress(corpId, contactId, languageId);
        }

        IEnumerable<Contact.Phone> IContact.GetCommunicatonPhone(int corpId, int contactId, int languageId)
        {
            return
                _contactManager.GetCommunicatonPhone(corpId, contactId, languageId);
        }

        IEnumerable<Contact.CitizenContact> IContact.GetAllCitizenContact(Contact.CitizenContact Contact)
        {
            return
                _contactManager.GetAllCitizenContact(Contact);
        }

        IEnumerable<Contact.Email> IContact.GetCommunicatonEmail(int corpId, int contactId, int languageId)
        {
            return
                _contactManager.GetCommunicatonEmail(corpId, contactId, languageId);
        }

        IEnumerable<Contact.Email> IContact.GetCommunicatonEmailJuridico(int corpId, int Agent_Legal, int languageId)
        {
            return
                _contactManager.GetCommunicatonEmailJuridico(corpId, Agent_Legal, languageId);
        }

        IEnumerable<Contact.IdDocument> IContact.GetAllIdDocumentInformation(int contactId, int languageId)
        {
            return
                _contactManager.GetAllIdDocumentInformation(contactId, languageId);
        }

        IEnumerable<Contact.IdDocument> IContact.GetAllIdDocumentInformationJuridico(int Agent_Legal, int languageId)
        {
            return
                _contactManager.GetAllIdDocumentInformationJuridico(Agent_Legal, languageId);
        }

        IEnumerable<Contact.IdDocument> IContact.GetAllIdDocumentBenefitary(int contactId, int languageId)
        {
            return
                _contactManager.GetAllIdDocumentBenefitary(contactId, languageId);
        }

        IEnumerable<Contact.SecurityQuestion> IContact.GetAllSecurityQuestion(int corpId, int contactId, int languageId)
        {
            return
                _contactManager.GetAllSecurityQuestion(corpId, contactId, languageId);
        }


        Contact.IdDocument IContact.GetIdDocument(int contactId, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                _contactManager.GetIdDocument(contactId, documentCategoryId, documentTypeId, documentId);
        }

        int IContact.SetAddress(Contact.Address address)
        {
            return
                 _contactManager.SetAddress(address);
        }

        int IContact.SetPhone(Contact.Phone phone)
        {
            return
                _contactManager.SetPhone(phone);
        }

        int IContact.SetEmail(Contact.Email email)
        {
            return
                _contactManager.SetEmail(email);
        }

        int IContact.DeleteCommunicaton(int corpId, int directoryId, int directoryDetailId, int modifyUser)
        {
            return
                _contactManager.DeleteCommunicaton(corpId, directoryId, directoryDetailId, modifyUser);
        }

        int IContact.DeleteCommunicatonJuridico(int corpId, int directoryId, int directoryDetailId, int modifyUser)
        {
            return
                _contactManager.DeleteCommunicatonJuridico(corpId, directoryId, directoryDetailId, modifyUser);
        }

        Contact.BackGroundCheck IContact.GetBackGroundCheck(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId)
        {
            return
                _contactManager.GetBackGroundCheck(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo, contactId);
        }

        IEnumerable<Contact.BackGroundCheckDocumentInfomation> IContact.GetAllBackGroundCheckDocumentInformation(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            return
                _contactManager.GetAllBackGroundCheckDocumentInformation(coprId, regionId, countryId, domesticRegId, stateProvId
                , cityId, officeId, caseSeqNo, histSeqNo);
        }

        Contact.BackGroundCheckDocumentInfomation IContact.GetBackGroundCheckDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            return
                _contactManager.GetBackGroundCheckDocument(coprId, regionId, countryId, domesticRegId, stateProvId
                        , cityId, officeId, caseSeqNo, histSeqNo, documentCategoryId, documentTypeId, documentId);
        }

        IEnumerable<Contact.Search> IContact.ContactSearchByAgent(int coprId, int agentId, int? contactTypeId)
        {
            return
                _contactManager.ContactSearchByAgent(coprId, agentId, contactTypeId);
        }

        int IContact.SetIdDocument(Contact.IdDocument document)
        {
            return
                 _contactManager.SetIdDocument(document);
        }

        int IContact.SetCitizenContact(Contact.CitizenContact Contact)
        {
            return
                 _contactManager.UpdateCitizenContact(Contact);
        }

        int IContact.DeleteCitizenContact(Contact.CitizenContact Contact)
        {
            return
                 _contactManager.DeleteCitizenContact(Contact);
        }

        int IContact.SetIdDocumentJuridico(Contact.IdDocument documentJuridico)
        {
            return
                 _contactManager.SetIdDocumentJuridico(documentJuridico);
        }

        int IContact.DeleteIdDocument(int contactId, int seqNo, int userId)
        {
            return
                  _contactManager.DeleteIdDocument(contactId, seqNo, userId);
        }

        int IContact.DeleteIdDocumentJuridico(int Agent_Legal, int seqNo, int userId)
        {
            return
                  _contactManager.DeleteIdDocumentJuridico(Agent_Legal, seqNo, userId);
        }

        bool IContact.CheckIdDocument(int contactId, int contactIdType, int countryIssuedBy, string id)
        {
            return
                _contactManager.CheckIdDocument(contactId, contactIdType, countryIssuedBy, id);
        }

        int IContact.InsertContact(Contact contact)
        {
            return
                _contactManager.InsertContact(contact);
        }

        int IContact.SetSecurityQuestion(Contact.SecurityQuestion securityQuestion)
        {
            return
                _contactManager.SetSecurityQuestion(securityQuestion);
        }

        #region Agent
        void IContact.GetAgentCommunicationAll(int corpId, int agentId, int languageId, out IEnumerable<Contact.Address> addresses, out IEnumerable<Contact.Phone> phones, out IEnumerable<Contact.Email> emails)
        {
            _contactManager.GetAgentCommunicationAll(corpId, agentId, languageId, out addresses, out phones, out emails);
        }

        IEnumerable<Contact.Address> IContact.GetAgentCommunicationAdress(int corpId, int agentId, int languageId)
        {
            return
                _contactManager.GetAgentCommunicationAdress(corpId, agentId, languageId);
        }

        IEnumerable<Contact.Phone> IContact.GetAgentCommunicationPhone(int corpId, int agentId, int languageId)
        {
            return
                 _contactManager.GetAgentCommunicationPhone(corpId, agentId, languageId);
        }

        IEnumerable<Contact.Email> IContact.GetAgentCommunicationEmail(int corpId, int agentId, int languageId)
        {
            return
                _contactManager.GetAgentCommunicationEmail(corpId, agentId, languageId);
        }

        int IContact.UpdateAgentAppointment(Contact.AgentAppointment agentAppointment)
        {
            return
                _contactManager.UpdateAgentAppointment(agentAppointment);
        }

        int IContact.InsertAgentAppointment(Contact.AgentAppointment agentAppointment)
        {
            return
                _contactManager.InsertAgentAppointment(agentAppointment);
        }

        IEnumerable<Contact.AgentAppointment> IContact.GetAgentAppointment(int corpId, int agentId)
        {
            return
                _contactManager.GetAgentAppointment(corpId, agentId);
        }

        int IContact.SetAgentContact(Contact.AgentContact parameter)
        {
            return
                _contactManager.SetAgentContact(parameter);
        }
        IEnumerable<Contact.AgentTree> IContact.GetAgentTree(Contact.AgentTreeParameter parameter)
        {
            return
                _contactManager.GetAgentTree(parameter);
        }
        #endregion

        Contact.Directory IContact.GetDirectoryId(int corpId, int contactId)
        {
            return
                _contactManager.GetDirectoryId(corpId, contactId);
        }

        Contact.ValidateDocumentCedula IContact.GetResultCedula(string DocumentCedula)
        {
            return
                _contactManager.GetResultCedula(DocumentCedula);
        }
        Contact.ValidateDocumentRNC IContact.GetResultRNC(string DocumentRNC)
        {
            return
                _contactManager.GetResultRNC(DocumentRNC);
        }

        IEnumerable<Contact.ValidateDocumentIDS> IContact.GetAllDocumentIDs(string IDs)
        {
            return
                _contactManager.GetAllDocumentIDs(IDs);
        }

        Contact.FinalBeneficiary IContact.SetContactFinalBeneficiary(int? contactId, int? finalBeneficiaryId, string name, decimal? percentageParticipation, bool? finalBeneficiaryStatus, int? userId, bool? IsPEP, int? PepFormularyOptionsId,int? identificationTypeId, string identificationNumber, int? nationalityCountryId)
        {
            return
                _contactManager.SetContactFinalBeneficiary(contactId, finalBeneficiaryId, name, percentageParticipation, finalBeneficiaryStatus, userId, IsPEP, PepFormularyOptionsId,identificationTypeId,identificationNumber, nationalityCountryId);
        }

        Contact.PepFormulary IContact.SetContactPepFormulary(int? contactId, int? pepFormularyId, string name, int? relationshipId, string position, int? fromYear, int? toYear, bool? pepFormularyStatus, int? userId, int? BeneficiaryId, bool? IsPepManagerCompany)
        {
            return
                _contactManager.SetContactPepFormulary(contactId, pepFormularyId, name, relationshipId, position, fromYear, toYear, pepFormularyStatus, userId, BeneficiaryId, IsPepManagerCompany);
        }

        IEnumerable<Contact.PepFormulary.PEPFormResult> IContact.GetContactPEPFormulary(int? ContactId, string Source)
        {
            return
                  _contactManager.GetContactPEPFormulary(ContactId, Source);
        }

        IEnumerable<Contact.FinalBeneficiary.FinalBenResult> IContact.GetContactFinalBeneficiary(int? ContactId)
        {
            return
                  _contactManager.GetContactFinalBeneficiary(ContactId);
        }
    }
    public class ContacttWS : IContact
    {
        Contact IContact.GetContact(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? contactRoleTypeId, int languageId)
        {
            throw new NotImplementedException();
        }

        Contact IContact.GetContact(int coprId, int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        Contact IContact.GetContactSummary(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int? contactId, int? contactRoleTypeId)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        int IContact.InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Citizenship> IContact.GetContactCitizenshipByContact(int contactId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.CitizenQuestion> IContact.GetContactCitizenQuestionByContact(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.CitizenQuestion> IContact.GetContactCitizenQuestionByContactJuridico(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? Agent_Legal, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.SocialExposure> IContact.GetContactSocialExposureByContact(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.SocialExposure> IContact.GetContactSocialExposureByContactJuridico(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? Agent_Legal, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.SocialExposureRelationship> IContact.GetContactSocialExposureRelationshipByContact(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.SocialExposureRelationship> IContact.GetContactSocialExposureRelationshipByContactJuridico(int? coprId, int? regionId, int? countryId, int? domesticRegId, int? stateProvId, int? cityId, int? officeId, int? caseSeqNo, int? histSeqNo, int? Agent_Legal, int languageId)
        {
            throw new NotImplementedException();
        }

        int IContact.InsertContactCitizenship(Contact.Citizenship citizenship)
        {
            throw new NotImplementedException();
        }

        int IContact.DeleteContactCitizenship(Contact.Citizenship citizenship)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContactCitizenQuestionByContact(Contact.CitizenQuestion question)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContactCitizenQuestionByContactJuridico(Contact.CitizenQuestion question)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContactSocialExposureByContact(Contact.SocialExposure socialExposure)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContactSocialExposureByContactJuridico(Contact.SocialExposure socialExposure)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContactSocialExposureRelationshipByContact(Contact.SocialExposureRelationship socialExposureRelationship)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateContactSocialExposureRelationshipByContactJuridico(Contact.SocialExposureRelationship socialExposureRelationship)
        {
            throw new NotImplementedException();
        }

        void IContact.GetCommunicatonAll(int corpId, int contactId, int languageId, out IEnumerable<Contact.Address> adresses, out IEnumerable<Contact.Phone> phones, out IEnumerable<Contact.Email> emails)
        {
            throw new NotImplementedException();
        }

        void IContact.GetCommunicatonAllJuridico(int corpId, int Agent_Legal, int languageId, out IEnumerable<Contact.Address> adresses, out IEnumerable<Contact.Phone> phones, out IEnumerable<Contact.Email> emails)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Address> IContact.GetCommunicatonAdress(int corpId, int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Phone> IContact.GetCommunicatonPhone(int corpId, int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Email> IContact.GetCommunicatonEmail(int corpId, int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.CitizenContact> IContact.GetAllCitizenContact(Contact.CitizenContact Contact)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Email> IContact.GetCommunicatonEmailJuridico(int corpId, int Agente_Legal, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.IdDocument> IContact.GetAllIdDocumentInformation(int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.IdDocument> IContact.GetAllIdDocumentInformationJuridico(int Agent_Legal, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.IdDocument> IContact.GetAllIdDocumentBenefitary(int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        Contact.IdDocument IContact.GetIdDocument(int contactId, int documentCategoryId, int documentTypeId, int documentId)
        {
            throw new NotImplementedException();
        }

        int IContact.SetAddress(Contact.Address address)
        {
            throw new NotImplementedException();
        }

        int IContact.SetPhone(Contact.Phone phone)
        {
            throw new NotImplementedException();
        }

        int IContact.SetEmail(Contact.Email email)
        {
            throw new NotImplementedException();
        }

        int IContact.DeleteCommunicaton(int corpId, int directoryId, int directoryDetailId, int modifyUser)
        {
            throw new NotImplementedException();
        }

        int IContact.DeleteCommunicatonJuridico(int corpId, int directoryId, int directoryDetailId, int modifyUser)
        {
            throw new NotImplementedException();
        }

        Contact.BackGroundCheck IContact.GetBackGroundCheck(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int contactId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.BackGroundCheckDocumentInfomation> IContact.GetAllBackGroundCheckDocumentInformation(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo)
        {
            throw new NotImplementedException();
        }

        Contact.BackGroundCheckDocumentInfomation IContact.GetBackGroundCheckDocument(int coprId, int regionId, int countryId, int domesticRegId, int stateProvId, int cityId, int officeId, int caseSeqNo, int histSeqNo, int documentCategoryId, int documentTypeId, int documentId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Search> IContact.ContactSearchByAgent(int coprId, int agentId, int? contactTypeId)
        {
            throw new NotImplementedException();
        }

        int IContact.SetIdDocument(Contact.IdDocument document)
        {
            throw new NotImplementedException();
        }

        int IContact.SetCitizenContact(Contact.CitizenContact Contact)
        {
            throw new NotImplementedException();
        }

        int IContact.DeleteCitizenContact(Contact.CitizenContact Contact)
        {
            throw new NotImplementedException();
        }

        int IContact.SetIdDocumentJuridico(Contact.IdDocument documentJuridico)
        {
            throw new NotImplementedException();
        }

        int IContact.DeleteIdDocument(int contactId, int seqNo, int userId)
        {
            throw new NotImplementedException();
        }

        int IContact.DeleteIdDocumentJuridico(int contactId, int seqNo, int userId)
        {
            throw new NotImplementedException();
        }

        bool IContact.CheckIdDocument(int contactId, int contactIdType, int countryIssuedBy, string id)
        {
            throw new NotImplementedException();
        }

        int IContact.SetSecurityQuestion(Contact.SecurityQuestion securityQuestion)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.SecurityQuestion> IContact.GetAllSecurityQuestion(int corpId, int contactId, int languageId)
        {
            throw new NotImplementedException();
        }

        Contact.Directory IContact.GetDirectoryId(int corpId, int contactId)
        {
            throw new NotImplementedException();
        }

        void IContact.GetAgentCommunicationAll(int corpId, int agentId, int languageId, out IEnumerable<Contact.Address> addresses, out IEnumerable<Contact.Phone> phones, out IEnumerable<Contact.Email> emails)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Address> IContact.GetAgentCommunicationAdress(int corpId, int agentId, int languageId)
        {
            throw new NotImplementedException();
        }

        Contact.ValidateDocumentCedula IContact.GetResultCedula(string DocumentCedula)
        {
            throw new NotImplementedException();
        }
        Contact.ValidateDocumentRNC IContact.GetResultRNC(string DocumentRNC)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.ValidateDocumentIDS> IContact.GetAllDocumentIDs(string IDs)
        {

            throw new NotImplementedException();
        }

        IEnumerable<Contact.Phone> IContact.GetAgentCommunicationPhone(int corpId, int agentId, int languageId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.Email> IContact.GetAgentCommunicationEmail(int corpId, int agentId, int languageId)
        {
            throw new NotImplementedException();
        }

        int IContact.UpdateAgentAppointment(Contact.AgentAppointment agentAppointment)
        {
            throw new NotImplementedException();
        }

        int IContact.InsertAgentAppointment(Contact.AgentAppointment agentAppointment)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.AgentAppointment> IContact.GetAgentAppointment(int corpId, int agentId)
        {
            throw new NotImplementedException();
        }

        int IContact.SetAgentContact(Contact.AgentContact parameter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.AgentTree> IContact.GetAgentTree(Contact.AgentTreeParameter parameter)
        {
            throw new NotImplementedException();
        }

        Contact.FinalBeneficiary IContact.SetContactFinalBeneficiary(int? contactId, int? finalBeneficiaryId, string name, decimal? percentageParticipation, bool? finalBeneficiaryStatus, int? userId, bool? IsPEP, int? PepFormularyOptionsId, int? identificationTypeId, string identificationNumber, int? nationalityCountryId)
        {
            throw new NotImplementedException();
        }

        Contact.PepFormulary IContact.SetContactPepFormulary(int? contactId, int? pepFormularyId, string name, int? relationshipId, string position, int? fromYear, int? toYear, bool? pepFormularyStatus, int? userId, int? BeneficiaryId, bool? IsPepManagerCompany)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.PepFormulary.PEPFormResult> IContact.GetContactPEPFormulary(int? ContactId, string Source)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contact.FinalBeneficiary.FinalBenResult> IContact.GetContactFinalBeneficiary(int? ContactId)
        {
            throw new NotImplementedException();
        }
    }
}
