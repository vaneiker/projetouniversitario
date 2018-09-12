using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DATA.UnderWriting.Data;
using DATA.UnderWriting.Repositories.Base;
using Entity.UnderWriting.Entities;

namespace DATA.UnderWriting.Repositories.Global
{
    public class HealthDeclarationRepository : GlobalRepository
    {
        public HealthDeclarationRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended, string globalconexionStringForAdo) : base(globalModel, globalModelExtended, globalconexionStringForAdo) { }

        public virtual int SetQuestionAnswer(Questionnaire.Answer answer)
        {
            int result;
            IEnumerable<SP_SET_QS_QUESTION_ANSWERS_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_QS_QUESTION_ANSWERS(
                answer.CorpId,
                answer.RegionId,
                answer.CountryId,
                answer.DomesticregId,
                answer.StateProvId,
                answer.CityId,
                answer.OfficeId,
                answer.CaseSeqNo,
                answer.HistSeqNo,
                answer.ContactId,
                answer.ContactRoleTypeId,
                answer.QuestionnaireId,
                answer.QuestionnaireSeq,
                answer.QuestionId,
                answer.OptionId,
                answer.TextualAnswer,
                answer.DateAnswer,
                answer.UserId
                );

            return
                result;
        }

        public virtual IEnumerable<Questionnaire.Question> GetAllQuestion(int corpId, int questionnaireId, int languageId, string forSex)
        {
            IEnumerable<Questionnaire.Question> result;
            IEnumerable<SP_GET_QS_QUESTION_Result> temp;

            temp = globalModel.SP_GET_QS_QUESTION(corpId, questionnaireId, languageId, forSex);

            result = temp
                .Select(q => new Questionnaire.Question
                {
                    CorpId = q.Corp_Id,
                    QuestionnaireId = q.Questionnaire_Id,
                    QuestionId = q.Question_Id,
                    RowNumber = q.RowNumber.ConvertToNoNullable(),
                    QuestionListId = q.Question_List_Id,
                    LanguageId = q.Language_Id,
                    QuestionnaireDesc = q.Questionnaire_Desc,
                    QuestionListDesc = q.Question_List_Desc,
                    KeyFiledName = q.KeyFiledName
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Questionnaire.Option> GetAllQuestionOption(Questionnaire.Option option)
        {
            IEnumerable<Questionnaire.Option> result;
            IEnumerable<SP_GET_QS_QUESTION_OPTION_Result> temp;

            temp = globalModel.SP_GET_QS_QUESTION_OPTION(
                        option.CorpId,
                        option.RegionId,
                        option.CountryId,
                        option.DomesticregId,
                        option.StateProvId,
                        option.CityId,
                        option.OfficeId,
                        option.CaseSeqNo,
                        option.HistSeqNo,
                        option.ContactId,
                        option.ContactRoleTypeId,
                        option.QuestionnaireId,
                        option.LanguageId,
                        option.QuestionId,
                        option.OptionId,
                        option.OptionListId,
                        option.OptionTypeId,
                        option.ParentOptionId,
                        option.SubOption
                );

            result = temp
                .Select(o => new Questionnaire.Option
                {
                    CorpId = o.Corp_Id.ConvertToNoNullable(),
                    RegionId = o.Region_Id.ConvertToNoNullable(),
                    CountryId = o.Country_Id.ConvertToNoNullable(),
                    DomesticregId = o.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = o.State_Prov_Id.ConvertToNoNullable(),
                    CityId = o.City_Id.ConvertToNoNullable(),
                    OfficeId = o.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = o.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = o.Hist_Seq_No.ConvertToNoNullable(),
                    ContactId = o.Contact_Id.ConvertToNoNullable(),
                    ContactRoleTypeId = o.Contact_Role_Type_Id.ConvertToNoNullable(),
                    QuestionnaireId = o.Questionnaire_Id,
                    QuestionId = o.Question_Id,
                    LanguageId = o.Language_Id,
                    QuestionListId = o.Question_List_Id,
                    OptionId = o.Option_Id,
                    ParentOptionId = o.Parent_Option_Id,
                    OptionTypeId = o.Option_Type_Id,
                    OptionListId = o.Option_List_Id,
                    SubOption = o.SubOption,
                    OptionTypeDesc = o.Option_Type_Desc,
                    OptionLabel = o.Option_Label,
                    QuestionListDesc = o.Question_List_Desc,
                    QuestionnaireDesc = o.Questionnaire_Desc,
                    TextualAnswer = o.Textual_Answer,
                    AnswerStatus = o.Answer_Status,
                    DateAnswer = o.Date_Answer,
                    HasAnswer = o.HasAnswer.ConvertToNoNullable(),
                    OptionKeyName = o.OptionKeyName,
                    QuestionnaireSeq = o.Questionnaire_Seq,
                    IsWidth100 = o.IsWidth100.ConvertToNoNullable()
                })
                .ToArray();

            return
                result;
        }

        public virtual void SetQuestionAnswer(DataTable answer)
        {
            string query;
            SqlCommand command;
            SqlConnection connection;
            SqlParameter parameter;

            query = "[Questionnaires].[SP_SET_QS_QUESTION_ANSWERS_BATH]";
            //connection = new SqlConnection(globalModel.Database.Connection.ConnectionString);
            connection = new SqlConnection(base.globalconexionStringForAdo);
            command = new SqlCommand(query, connection);

            parameter = command.Parameters.AddWithValue("@ANSWERS", answer);
            command.CommandType = CommandType.StoredProcedure;
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "[Questionnaires].[UDDT_QUESTION_ANSWERS]";

            try
            {
                if (connection != null && connection.State != ConnectionState.Open)
                    connection.Open();

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public virtual DataTable GetQuestionAnswerTemplate()
        {
            string query;
            SqlDataAdapter dataAdapter;
            DataTable dT;
            SqlCommand command;
            SqlConnection connection;
        
            query = "exec [Questionnaires].[SP_GET_QS_QUESTION_UDDT_ANSWERS]";
           // connection = new SqlConnection(globalModel.Database.Connection.ConnectionString); 
            connection = new SqlConnection(base.globalconexionStringForAdo);
            command = new SqlCommand(query, connection);

            dT = new DataTable();

            try
            {
                dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(dT);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return
                dT;
        }

        public virtual Questionnaire.GridAnswer SetGridAnswer(Questionnaire.GridAnswer answer)
        {
            Questionnaire.GridAnswer result;
            IEnumerable<SP_INSERT_QS_QUESTION_GRID_ANSWER_VALUES_Result> temp;

            temp = globalModel.SP_INSERT_QS_QUESTION_GRID_ANSWER_VALUES(
                answer.CorpId,
                answer.RegionId,
                answer.CountryId,
                answer.DomesticregId,
                answer.StateProvId,
                answer.CityId,
                answer.OfficeId,
                answer.CaseSeqNo,
                answer.HistSeqNo,
                answer.ContactId,
                answer.ContactRoleTypeId,
                answer.QuestionnaireId,
                answer.QuestionnaireSeq,
                answer.QuestionId,
                answer.OptionId,
                answer.AnswerSeq,
                answer.DiseaseId,
                answer.DiseaseDesc,
                answer.ReasonDesc,
                answer.ReasonDate,
                answer.ReasonDetail,
                answer.MedicalDoctor,
                answer.MedicalCenter,
                answer.MedicalCenterPhone,
                answer.MedicalCenterAddress,
                answer.TextualAnswer,
                answer.DateAnswer,
                answer.QuestionnaireLanguageId,
                answer.UserId
                );

            result = temp
                .Select(ga => new Questionnaire.GridAnswer
                {
                    CorpId = ga.Corp_Id.ConvertToNoNullable(),
                    RegionId = ga.Region_Id.ConvertToNoNullable(),
                    CountryId = ga.Country_Id.ConvertToNoNullable(),
                    DomesticregId = ga.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = ga.State_Prov_Id.ConvertToNoNullable(),
                    CityId = ga.City_Id.ConvertToNoNullable(),
                    OfficeId = ga.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = ga.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = ga.Hist_Seq_No.ConvertToNoNullable(),
                    ContactId = ga.Contact_Id.ConvertToNoNullable(),
                    ContactRoleTypeId = ga.Contact_Role_Type_Id.ConvertToNoNullable(),
                    QuestionnaireId = ga.Questionnaire_Id.ConvertToNoNullable(),
                    QuestionnaireSeq = ga.Questionnaire_Seq.ConvertToNoNullable(),
                    QuestionId = ga.Question_Id.ConvertToNoNullable(),
                    OptionId = ga.Option_Id.ConvertToNoNullable(),
                    AnswerSeq = ga.Answer_Seq
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual Questionnaire SetQuestionnaire(Questionnaire questionnaire)
        {
            Questionnaire result;
            IEnumerable<SP_SET_QS_CONTACT_QUESTIONNAIRE_Result> temp;

            temp = globalModel.SP_SET_QS_CONTACT_QUESTIONNAIRE(
                questionnaire.CorpId,
                questionnaire.RegionId,
                questionnaire.CountryId,
                questionnaire.DomesticregId,
                questionnaire.StateProvId,
                questionnaire.CityId,
                questionnaire.OfficeId,
                questionnaire.CaseSeqNo,
                questionnaire.HistSeqNo,
                questionnaire.ContactId,
                questionnaire.ContactRoleTypeId,
                questionnaire.QuestionnaireId,
                questionnaire.QuestionnaireSeq,
                questionnaire.MDName,
                questionnaire.MDCorpId,
                questionnaire.MDRegionId,
                questionnaire.MDDomesticregId,
                questionnaire.MDCountryId,
                questionnaire.MDStateProvId,
                questionnaire.MDCityId,
                questionnaire.MDAddress,
                questionnaire.MDPhoneNumber,
                questionnaire.LastMedicalVisit,
                questionnaire.Reason,
                questionnaire.Result,
                questionnaire.LanguageId,
                questionnaire.UserId
                );

            result = temp
                .Select(q => new Questionnaire
                {
                    CorpId = q.Corp_Id.ConvertToNoNullable(),
                    RegionId = q.Region_Id.ConvertToNoNullable(),
                    CountryId = q.Country_Id.ConvertToNoNullable(),
                    DomesticregId = q.Domesticreg_Id.ConvertToNoNullable(),
                    StateProvId = q.State_Prov_Id.ConvertToNoNullable(),
                    CityId = q.City_Id.ConvertToNoNullable(),
                    OfficeId = q.Office_Id.ConvertToNoNullable(),
                    CaseSeqNo = q.Case_Seq_No.ConvertToNoNullable(),
                    HistSeqNo = q.Hist_Seq_No.ConvertToNoNullable(),
                    ContactId = q.Contact_Id.ConvertToNoNullable(),
                    ContactRoleTypeId = q.Contact_Role_Type_Id.ConvertToNoNullable(),
                    QuestionnaireId = q.Questionnaire_Id.ConvertToNoNullable(),
                    QuestionnaireSeq = q.Questionnaire_Seq.ConvertToNoNullable(),
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual Questionnaire GetQuestionnaire(Questionnaire questionnaire)
        {
            Questionnaire result;
            IEnumerable<SP_GET_QS_CONTACT_QUESTIONNAIRE_Result> temp;

            temp = globalModel.SP_GET_QS_CONTACT_QUESTIONNAIRE(
                questionnaire.CorpId,
                questionnaire.RegionId,
                questionnaire.CountryId,
                questionnaire.DomesticregId,
                questionnaire.StateProvId,
                questionnaire.CityId,
                questionnaire.OfficeId,
                questionnaire.CaseSeqNo,
                questionnaire.HistSeqNo,
                questionnaire.ContactId,
                questionnaire.ContactRoleTypeId,
                questionnaire.QuestionnaireId,
                questionnaire.QuestionnaireSeq
                );

            result = temp
                .Select(q => new Questionnaire
                {
                    CorpId = q.Corp_Id,
                    RegionId = q.Region_Id,
                    CountryId = q.Country_Id,
                    DomesticregId = q.Domesticreg_Id,
                    StateProvId = q.State_Prov_Id,
                    CityId = q.City_Id,
                    OfficeId = q.Office_Id,
                    CaseSeqNo = q.Case_Seq_No,
                    HistSeqNo = q.Hist_Seq_No,
                    ContactId = q.Contact_Id,
                    ContactRoleTypeId = q.Contact_Role_Type_Id,
                    QuestionnaireId = q.Questionnaire_Id,
                    QuestionnaireSeq = q.Questionnaire_Seq,
                    MDName = q.MD_Name,
                    MDCorpId = q.MD_Corp_Id,
                    MDRegionId = q.MD_Region_Id,
                    MDDomesticregId = q.MD_Domesticreg_Id,
                    MDCountryId = q.MD_Country_Id,
                    MDStateProvId = q.MD_State_Prov_Id,
                    MDCityId = q.MD_City_Id,
                    MDAddress = q.MD_Address,
                    MDPhoneNumber = q.MD_Phone_Number,
                    LastMedicalVisit = q.Last_Medical_Visit,
                    Reason = q.Reason,
                    Result = q.Result,
                    LanguageId = q.Language_Id
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual int DeleteGridAnswer(Questionnaire.GridAnswer answer)
        {
            int result;
            IEnumerable<SP_DELETE_QS_QUESTION_GRID_ANSWER_VALUES_AND_OPTION_Result> temp;

            result = -1;

            temp = globalModel.SP_DELETE_QS_QUESTION_GRID_ANSWER_VALUES_AND_OPTION(
                answer.CorpId,
                answer.RegionId,
                answer.CountryId,
                answer.DomesticregId,
                answer.StateProvId,
                answer.CityId,
                answer.OfficeId,
                answer.CaseSeqNo,
                answer.HistSeqNo,
                answer.ContactId,
                answer.ContactRoleTypeId,
                answer.QuestionnaireId,
                answer.QuestionnaireSeq,
                answer.QuestionId,
                answer.OptionId,
                answer.AnswerSeq,
                answer.UserId
                );

            return
                result;
        }

        public virtual int DeleteAllQuestionnaire(Questionnaire questionnaire)
        {
            int result;
            IEnumerable<SP_DELETE_QS_CONTACT_QUESTIONNAIRE_Result> temp;

            result = -1;

            temp = globalModel.SP_DELETE_QS_CONTACT_QUESTIONNAIRE(
                questionnaire.CorpId,
                questionnaire.RegionId,
                questionnaire.CountryId,
                questionnaire.DomesticregId,
                questionnaire.StateProvId,
                questionnaire.CityId,
                questionnaire.OfficeId,
                questionnaire.CaseSeqNo,
                questionnaire.HistSeqNo,
                questionnaire.ContactId,
                questionnaire.ContactRoleTypeId,
                questionnaire.UserId
                );

            return
                result;
        }

        public virtual IEnumerable<Questionnaire.GridAnswer> GetGridAnswer(Questionnaire.GridAnswer option)
        {
            IEnumerable<Questionnaire.GridAnswer> result;
            IEnumerable<SP_GET_QS_QUESTION_GRID_ANSWER_VALUES_Result> temp;

            temp = globalModel.SP_GET_QS_QUESTION_GRID_ANSWER_VALUES(
                        option.CorpId,
                        option.RegionId,
                        option.CountryId,
                        option.DomesticregId,
                        option.StateProvId,
                        option.CityId,
                        option.OfficeId,
                        option.CaseSeqNo,
                        option.HistSeqNo,
                        option.ContactId,
                        option.ContactRoleTypeId,
                        option.QuestionnaireId,
                        option.QuestionnaireSeq,
                        option.QuestionId,
                        option.OptionId,
                        option.AnswerSeq
                );

            result = temp
                .Select(opg => new Questionnaire.GridAnswer
                {
                    CorpId = opg.Corp_Id,
                    RegionId = opg.Region_Id,
                    CountryId = opg.Country_Id,
                    DomesticregId = opg.Domesticreg_Id,
                    StateProvId = opg.State_Prov_Id,
                    CityId = opg.City_Id,
                    OfficeId = opg.Office_Id,
                    CaseSeqNo = opg.Case_Seq_No,
                    HistSeqNo = opg.Hist_Seq_No,
                    ContactId = opg.Contact_Id,
                    ContactRoleTypeId = opg.Contact_Role_Type_Id,
                    QuestionnaireId = opg.Questionnaire_Id,
                    QuestionnaireSeq = opg.Questionnaire_Seq,
                    QuestionId = opg.Question_Id,
                    OptionId = opg.Option_Id,
                    AnswerSeq = opg.Answer_Seq,
                    DiseaseDesc = opg.Disease_Desc,
                    ReasonDesc = opg.Reason_Desc,
                    ReasonDate = opg.Reason_Date,
                    ReasonDetail = opg.Reason_Detail,
                    MedicalDoctor = opg.Medical_Doctor,
                    MedicalCenter = opg.Medical_Center,
                    MedicalCenterPhone = opg.Medical_Center_Phone,
                    MedicalCenterAddress = opg.Medical_Center_Address,
                    TextualAnswer = opg.Textual_Answer,
                    DateAnswer = opg.Date_Answer,
                    DiseaseId = opg.Disease_Id

                })
                .ToArray();

            return
                result;
        }

        public virtual bool GetQuestionValidation(Questionnaire.Option option)
        {
            bool result;
            IEnumerable<SP_GET_QS_QUESTION_VALIDATION_Result> temp;

            temp = globalModel.SP_GET_QS_QUESTION_VALIDATION(
                option.CorpId,
                option.RegionId,
                option.CountryId,
                option.DomesticregId,
                option.StateProvId,
                option.CityId,
                option.OfficeId,
                option.CaseSeqNo,
                option.HistSeqNo,
                option.ContactId,
                option.ContactRoleTypeId,
                option.LanguageId,
                option.ForSex
                );

            result = temp
                .Select(ga => ga.IsValid.HasValue ? ga.IsValid.Value == 1 : false)
                .FirstOrDefault();

            return
                result;
        }
    }
}
