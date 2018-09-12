using System;
using System.Collections.Generic;
using System.Data;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Common;

namespace LOGIC.UnderWriting.Global
{
    public class HealthDeclarationManager
    {
        private HealthDeclarationRepository _healthDeclarationRepository;

        public HealthDeclarationManager()
        {
            _healthDeclarationRepository = SingletonUnitOfWork.Instance.HealthDeclarationRepository;
        }

        public virtual int SetQuestionAnswer(Questionnaire.Answer answer)
        {
            if (answer.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (answer.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (answer.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (answer.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (answer.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (answer.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (answer.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (answer.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (answer.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (answer.ContactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactId");
            if (answer.ContactRoleTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactRoleTypeId");
            if (answer.QuestionnaireId <= 0)
                throw new ArgumentException("This property can't be under 0.", "QuestionnaireId");
            if (answer.QuestionnaireSeq <= 0)
                throw new ArgumentException("This property can't be under 0.", "QuestionnaireSeq");
            if (answer.QuestionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "QuestionId");
            if (answer.OptionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OptionId");

            return
                _healthDeclarationRepository.SetQuestionAnswer(answer);
        }

        public virtual IEnumerable<Questionnaire.Question> GetAllQuestion(int corpId, int questionnaireId, int languageId, string forSex)
        {
            return
                _healthDeclarationRepository.GetAllQuestion(corpId, questionnaireId, languageId, forSex);
        }

        public virtual IEnumerable<Questionnaire.Option> GetAllQuestionOption(Questionnaire.Option option)
        {
            return
                _healthDeclarationRepository.GetAllQuestionOption(option);
        }

        public virtual void SetQuestionAnswer(DataTable answer)
        {
            _healthDeclarationRepository.SetQuestionAnswer(answer);
        }

        public virtual DataTable GetQuestionAnswerTemplate()
        {
            return
                _healthDeclarationRepository.GetQuestionAnswerTemplate();
        }

        public virtual Questionnaire.GridAnswer InsertGridAnswer(Questionnaire.GridAnswer answer)
        {
            this.IsValid(answer, Utility.DataBaseActionType.Insert);

            return
                this.SetGridAnswer(answer);
        }
        public virtual Questionnaire.GridAnswer UpdateGridAnswer(Questionnaire.GridAnswer answer)
        {
            this.IsValid(answer, Utility.DataBaseActionType.Update);

            return
                this.SetGridAnswer(answer);
        }

        public virtual int DeleteGridAnswer(Questionnaire.GridAnswer answer)
        {
            this.IsValid(answer, Utility.DataBaseActionType.Delete);

            return
                _healthDeclarationRepository.DeleteGridAnswer(answer);
        }
        public virtual int DeleteAllQuestionnaire(Questionnaire questionnaire)
        {
            if (questionnaire.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (questionnaire.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (questionnaire.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (questionnaire.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (questionnaire.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (questionnaire.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (questionnaire.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (questionnaire.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (questionnaire.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (questionnaire.ContactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactId");
            if (questionnaire.ContactRoleTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactRoleTypeId");
            if (questionnaire.UserId <= 0)
                throw new ArgumentException("This property can't be under 0.", "UserId");

            return
                _healthDeclarationRepository.DeleteAllQuestionnaire(questionnaire);
        }

        public virtual IEnumerable<Questionnaire.GridAnswer> GetGridAnswer(Questionnaire.GridAnswer option)
        {
            this.IsValid(option, Utility.DataBaseActionType.Select);

            return
                _healthDeclarationRepository.GetGridAnswer(option);
        }

        public virtual Questionnaire UpdateQuestionnaire(Questionnaire questionnaire)
        {
            this.IsValid(questionnaire, Utility.DataBaseActionType.Update);

            return
                this.SetQuestionnaire(questionnaire);
        }
        public virtual Questionnaire InsertQuestionnaire(Questionnaire questionnaire)
        {
            this.IsValid(questionnaire, Utility.DataBaseActionType.Insert);

            questionnaire.QuestionnaireSeq = -1;

            return
                this.SetQuestionnaire(questionnaire);
        }

        public virtual Questionnaire GetQuestionnaire(Questionnaire questionnaire)
        {
            return
                _healthDeclarationRepository.GetQuestionnaire(questionnaire);
        }

        public virtual bool GetQuestionValidation(Questionnaire.Option option)
        {
            return
                _healthDeclarationRepository.GetQuestionValidation(option);
        }

        private Questionnaire.GridAnswer SetGridAnswer(Questionnaire.GridAnswer answer)
        {
            return
                _healthDeclarationRepository.SetGridAnswer(answer);
        }
        private Questionnaire SetQuestionnaire(Questionnaire questionnaire)
        {
            return
                _healthDeclarationRepository.SetQuestionnaire(questionnaire);
        }
        private void IsValid(Questionnaire.GridAnswer answer, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (answer.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (answer.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (answer.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (answer.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (answer.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (answer.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (answer.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (answer.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (answer.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (answer.ContactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactId");
            if (answer.ContactRoleTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactRoleTypeId");
            if (answer.QuestionnaireId <= 0)
                throw new ArgumentException("This property can't be under 0.", "QuestionnaireId");
            if (answer.QuestionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "QuestionId");
            if (answer.OptionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OptionId");

            checkUserId = false;

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    //if (!answer.AnswerSeq.HasValue || answer.AnswerSeq.Value <= 0)
                    //    throw new ArgumentException("This property can't be null or under 0.", "AnswerSeq");
                    //if (answer.QuestionnaireSeq.HasValue && answer.QuestionnaireSeq.Value <= 0)
                    //    throw new ArgumentException("This property can't be under 0.", "QuestionnaireSeq");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    break;
            }

            if (checkUserId && answer.UserId <= 0)
                throw new ArgumentException("This property can't be under 0.", "UserId");
        }
        private void IsValid(Questionnaire questionnaire, Utility.DataBaseActionType action)
        {
            bool checkUserId;

            if (questionnaire.CorpId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CorpId");
            if (questionnaire.RegionId <= 0)
                throw new ArgumentException("This property can't be under 0.", "RegionId");
            if (questionnaire.CountryId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CountryId");
            if (questionnaire.DomesticregId <= 0)
                throw new ArgumentException("This property can't be under 0.", "DomesticregId");
            if (questionnaire.StateProvId <= 0)
                throw new ArgumentException("This property can't be under 0.", "StateProvId");
            if (questionnaire.CityId <= 0)
                throw new ArgumentException("This property can't be under 0.", "CityId");
            if (questionnaire.OfficeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "OfficeId");
            if (questionnaire.CaseSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "CaseSeqNo");
            if (questionnaire.HistSeqNo <= 0)
                throw new ArgumentException("This property can't be under 0.", "HistSeqNo");
            if (questionnaire.ContactId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactId");
            if (questionnaire.ContactRoleTypeId <= 0)
                throw new ArgumentException("This property can't be under 0.", "ContactRoleTypeId");
            if (questionnaire.QuestionnaireId <= 0)
                throw new ArgumentException("This property can't be under 0.", "QuestionnaireId");

            checkUserId = false;

            switch (action)
            {
                case Utility.DataBaseActionType.Update:
                case Utility.DataBaseActionType.Delete:
                    checkUserId = true;
                    if (questionnaire.QuestionnaireSeq.HasValue && questionnaire.QuestionnaireSeq.Value <= 0)
                        throw new ArgumentException("This property can't be under 0.", "QuestionnaireSeq");
                    break;
                case Utility.DataBaseActionType.Insert:
                    checkUserId = true;
                    break;
                case Utility.DataBaseActionType.Select:
                default:
                    break;
            }

            if (checkUserId && questionnaire.UserId <= 0)
                throw new ArgumentException("This property can't be under 0.", "UserId");
        }        
    }
}
