using System.Collections.Generic;
using System.Data;
using Entity.UnderWriting.Entities;

namespace DI.UnderWriting.Interfaces
{
    public interface IHealthDeclaration
    {
        int SetQuestionAnswer(Questionnaire.Answer answer);
        
        IEnumerable<Questionnaire.Question> GetAllQuestion(int corpId, int questionnaireId, int languageId, string forSex);
        
        IEnumerable<Questionnaire.Option> GetAllQuestionOption(Questionnaire.Option option);
        
        void SetQuestionAnswer(DataTable answer);
        
        DataTable GetQuestionAnswerTemplate();
        
        Questionnaire.GridAnswer InsertGridAnswer(Questionnaire.GridAnswer answer);
        
        Questionnaire.GridAnswer UpdateGridAnswer(Questionnaire.GridAnswer answer);
        
        int DeleteGridAnswer(Questionnaire.GridAnswer answer);
        
        int DeleteAllQuestionnaire(Questionnaire questionnaire);
        
        IEnumerable<Questionnaire.GridAnswer> GetGridAnswer(Questionnaire.GridAnswer option);
        
        Questionnaire UpdateQuestionnaire(Questionnaire questionnaire);
        
        Questionnaire InsertQuestionnaire(Questionnaire questionnaire);
        
        Questionnaire GetQuestionnaire(Questionnaire questionnaire);
        
        bool GetQuestionValidation(Questionnaire.Option option);
    }
}
