using System;
using System.Collections.Generic;
using System.Data;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class HealthDeclarationBll : IHealthDeclaration
    {
        private HealthDeclarationManager _healthDeclarationManager;

        public HealthDeclarationBll()
        {
            _healthDeclarationManager = new HealthDeclarationManager();
        }

        int IHealthDeclaration.SetQuestionAnswer(Questionnaire.Answer answer)
        {
            return
                _healthDeclarationManager.SetQuestionAnswer(answer);
        }

        IEnumerable<Questionnaire.Question> IHealthDeclaration.GetAllQuestion(int corpId, int questionnaireId, int languageId, string forSex)
        {
            return
                _healthDeclarationManager.GetAllQuestion(corpId, questionnaireId, languageId, forSex);
        }

        IEnumerable<Questionnaire.Option> IHealthDeclaration.GetAllQuestionOption(Questionnaire.Option option)
        {
            return
               _healthDeclarationManager.GetAllQuestionOption(option);
        }

        void IHealthDeclaration.SetQuestionAnswer(DataTable answer)
        {
            _healthDeclarationManager.SetQuestionAnswer(answer);
        }

        DataTable IHealthDeclaration.GetQuestionAnswerTemplate()
        {
            return
               _healthDeclarationManager.GetQuestionAnswerTemplate();
        }

        Questionnaire.GridAnswer IHealthDeclaration.InsertGridAnswer(Questionnaire.GridAnswer answer)
        {
            return
               _healthDeclarationManager.InsertGridAnswer(answer);
        }

        Questionnaire.GridAnswer IHealthDeclaration.UpdateGridAnswer(Questionnaire.GridAnswer answer)
        {
            return
                _healthDeclarationManager.UpdateGridAnswer(answer);
        }

        int IHealthDeclaration.DeleteGridAnswer(Questionnaire.GridAnswer answer)
        {
            return
                _healthDeclarationManager.DeleteGridAnswer(answer);
        }

        int IHealthDeclaration.DeleteAllQuestionnaire(Questionnaire questionnaire)
        {
            return
                _healthDeclarationManager.DeleteAllQuestionnaire(questionnaire);
        }

        IEnumerable<Questionnaire.GridAnswer> IHealthDeclaration.GetGridAnswer(Questionnaire.GridAnswer option)
        {
            return
                _healthDeclarationManager.GetGridAnswer(option);
        }

        Questionnaire IHealthDeclaration.UpdateQuestionnaire(Questionnaire questionnaire)
        {
            return
                _healthDeclarationManager.UpdateQuestionnaire(questionnaire);
        }

        Questionnaire IHealthDeclaration.InsertQuestionnaire(Questionnaire questionnaire)
        {
            return
                _healthDeclarationManager.InsertQuestionnaire(questionnaire);
        }

        Questionnaire IHealthDeclaration.GetQuestionnaire(Questionnaire questionnaire)
        {
            return
                _healthDeclarationManager.GetQuestionnaire(questionnaire);
        }

        bool IHealthDeclaration.GetQuestionValidation(Questionnaire.Option option)
        {
            return
                _healthDeclarationManager.GetQuestionValidation(option);
        }
    }

    public class HealthDeclarationWS : IHealthDeclaration
    {
        int IHealthDeclaration.SetQuestionAnswer(Questionnaire.Answer answer)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Questionnaire.Question> IHealthDeclaration.GetAllQuestion(int corpId, int questionnaireId, int languageId, string forSex)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Questionnaire.Option> IHealthDeclaration.GetAllQuestionOption(Questionnaire.Option option)
        {
            throw new NotImplementedException();
        }

        void IHealthDeclaration.SetQuestionAnswer(DataTable answer)
        {
            throw new NotImplementedException();
        }

        DataTable IHealthDeclaration.GetQuestionAnswerTemplate()
        {
            throw new NotImplementedException();
        }

        Questionnaire.GridAnswer IHealthDeclaration.InsertGridAnswer(Questionnaire.GridAnswer answer)
        {
            throw new NotImplementedException();
        }

        Questionnaire.GridAnswer IHealthDeclaration.UpdateGridAnswer(Questionnaire.GridAnswer answer)
        {
            throw new NotImplementedException();
        }

        int IHealthDeclaration.DeleteGridAnswer(Questionnaire.GridAnswer answer)
        {
            throw new NotImplementedException();
        }

        int IHealthDeclaration.DeleteAllQuestionnaire(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Questionnaire.GridAnswer> IHealthDeclaration.GetGridAnswer(Questionnaire.GridAnswer option)
        {
            throw new NotImplementedException();
        }

        Questionnaire IHealthDeclaration.UpdateQuestionnaire(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        Questionnaire IHealthDeclaration.InsertQuestionnaire(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        Questionnaire IHealthDeclaration.GetQuestionnaire(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        bool IHealthDeclaration.GetQuestionValidation(Questionnaire.Option option)
        {
            throw new NotImplementedException();
        }
    }
}
