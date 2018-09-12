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
    public class FormRepository : GlobalRepository
    {
        public FormRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended, string globalconexionStringForAdo) : base(globalModel, globalModelExtended, globalconexionStringForAdo) { }

        public virtual IEnumerable<Form.FieldValue> GetFormFieldValues(Form.FieldValue.Parameter parameters)
        {
            IEnumerable<Form.FieldValue> result;
            IEnumerable<SP_GET_FOR_FORM_FIELD_VALUES_Result> temp;

            temp = globalModel.SP_GET_FOR_FORM_FIELD_VALUES(
                        parameters.CorpId,
                        parameters.RegionId,
                        parameters.CountryId,
                        parameters.DomesticRegId,
                        parameters.StateProvId,
                        parameters.CityId,
                        parameters.OfficeId,
                        parameters.CaseSeqNo,
                        parameters.HistSeqNo,
                        parameters.ContactId,
                        parameters.FormId,
                        parameters.FieldId,
                        parameters.LanguageId
                );

            result = temp
                .Select(fv => new Form.FieldValue
                {
                    FormId = fv.Form_Id,
                    FormCategoryId = fv.Form_Category_Id,
                    FieldTypeId = fv.Field_Type_Id,
                    CorpId = fv.Corp_Id,
                    RegionId = fv.Region_Id,
                    CountryId = fv.Country_Id,
                    DomesticRegId = fv.Domesticreg_Id,
                    StateProvId = fv.State_Prov_Id,
                    CityId = fv.City_Id,
                    OfficeId = fv.Office_Id,
                    CaseSeqNo = fv.Case_Seq_No,
                    HistSeqNo = fv.Hist_Seq_No,
                    FieldId = fv.Field_Id,
                    ContactId = fv.Contact_Id,
                    FormDesc = fv.Form_Desc,
                    FieldTypeDesc = fv.Field_Type_Desc,
                    HtmlTemplate = fv.Html_Template,
                    HasValues = fv.hasValues,
                    TextValue = fv.Text_Value,
                    NumericValue = fv.Numeric_Value,
                    IntegerValue = fv.Integer_Value,
                    DateValue = fv.Date_Value,
                    FieldValueStatus = fv.Field_Value_Status,
                    FieldTitle = fv.Field_Title,
                    FormFieldDescription = fv.Form_Field_Description,
                    PdfTemplatePath = fv.PDF_Template_Path
                })
                .ToArray();

            return
                result;
        }

        public virtual DataTable GetFormDetailUddt()
        {
            string query;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter dataAdapter;
            DataTable dT;

            query = "exec [Forms].[SP_GET_FOR_FORM_DETAIL_UDDT]";
            connection = new SqlConnection(base.globalconexionStringForAdo);
            command = new SqlCommand(query, connection);
            dT = new DataTable();

            try
            {
                dataAdapter = new SqlDataAdapter(command);
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

        public virtual void SetFormDetail(DataTable formDetail)
        {
            string query;
            SqlCommand command;
            SqlConnection connection;
            SqlParameter parameter;

            query = "[Forms].[SP_SET_FOR_FORM_DETAIL_BATH]";
            connection = new SqlConnection(base.globalconexionStringForAdo);
            command = new SqlCommand(query, connection);

            parameter = command.Parameters.AddWithValue("@FormDetails", formDetail);
            command.CommandType = CommandType.StoredProcedure;
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "[Forms].[UDDT_For_Form_Detail]";

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
    }
}
