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
    public class DataReviewRepository : GlobalRepository
    {
        public DataReviewRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended, string globalconexionStringForAdo) : base(globalModel, globalModelExtended, globalconexionStringForAdo) { }

        public virtual IEnumerable<DataReview> GetAll(Parameter.Case parameter)
        {
            IEnumerable<DataReview> result;
            IEnumerable<SP_GET_CASE_IN_DATA_REVIEW_Result> temp;

            temp = globalModel.SP_GET_CASE_IN_DATA_REVIEW(parameter.CompanyId, parameter.UserId, parameter.LanguageId);

            result = temp
                .Select(dr => new DataReview
                {
                    CorpId = dr.Corp_Id,
                    RegionId = dr.Region_Id,
                    CountryId = dr.Country_Id,
                    DomesticregId = dr.Domesticreg_Id,
                    StateProvId = dr.State_Prov_Id,
                    CityId = dr.City_Id,
                    OfficeId = dr.Office_Id,
                    CaseSeqNo = dr.Case_Seq_No,
                    HistSeqNo = dr.Hist_Seq_No,
                    InsuredContactId = dr.InsuredContactId,
                    AgentId = dr.Agent_Id,
                    CompanyDesc = dr.Company_Desc,
                    PolicyNo = dr.Policy_No,
                    ProductDesc = dr.Product_Desc,
                    InsuredFullName = dr.InsuredFullName,
                    CountryDesc = dr.Country_Desc,
                    OfficeDesc = dr.Office_Desc,
                    AgentFullName = dr.AgentFullName,
                    Exception = dr.Exception,
                    SubmitDate = dr.Submit_Date,
                    DaysPending = dr.DaysPending,
                    IsReview = dr.IsReview,
                    UserName = dr.UserName,
                    OwnerFullName = dr.OwnerFullName,
                    OwnerContactId = dr.OwnerContactId,
                    AgentLegalContactId = dr.AgentLegalContactId,
                    AddInsuredContactId = dr.AddInsuredContactId,
                    DesignatedPensionerContactId = dr.DesignatedPensionerContactId,
                    StudentContactId = dr.StudentContactId,
                    PaymentId = dr.Payment_Id,
                    CommentCount = dr.CommentCount,
                    RelationshiptoAgent = dr.Relationship_to_Agent,
                    RelationshiptoOwner = dr.Relationship_to_Owner,
                    isComplianceOK = dr.isComplianceOK  
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<DataReview.Change> GetAllRejected(int companyId, int underwriterId)
        {
            IEnumerable<DataReview.Change> result;
            IEnumerable<SP_GET_CASE_IN_REJECTED_Result> temp;

            temp = globalModel.SP_GET_CASE_IN_REJECTED(companyId, underwriterId);

            result = temp
                .Select(dr => new DataReview.Change
                {
                    CorpId = dr.Corp_Id,
                    RegionId = dr.Region_Id,
                    CountryId = dr.Country_Id,
                    DomesticregId = dr.Domesticreg_Id,
                    StateProvId = dr.State_Prov_Id,
                    CityId = dr.City_Id,
                    OfficeId = dr.Office_Id,
                    CaseSeqNo = dr.Case_Seq_No,
                    HistSeqNo = dr.Hist_Seq_No,
                    InsuredContactId = dr.InsuredContactId,
                    AgentId = dr.Agent_Id,
                    CompanyDesc = dr.Company_Desc,
                    PolicyNo = dr.Policy_No,
                    ProductDesc = dr.Product_Desc,
                    ProductNameKey = dr.Product_Name_Key,
                    InsuredFullName = dr.InsuredFullName,
                    CountryDesc = dr.Country_Desc,
                    OfficeDesc = dr.Office_Desc,
                    AgentFullName = dr.AgentFullName,
                    Exception = dr.Exception,
                    SubmitDate = dr.Submit_Date,
                    UserName = dr.UserName,
                    ChangeDate = dr.ChangeDate,
                    TimeChange = dr.TimeChange.ConvertToNoNullable(),
                    InsuredAddContactId = dr.InsuredAddContactId,
                    OwnerContactId = dr.OwnerContactId,
                    DesignatedPensionerContactId = dr.DesignatedPensionerContactId,
                    StudentContactId = dr.StudentContactId,
                    PaymentId = dr.Payment_Id
                })
                .ToArray();

            return
                result;
        }
        
        public virtual IEnumerable<DataReview.Change> GetAllApproved(int companyId, int underwriterId)
        {
            IEnumerable<DataReview.Change> result;
            IEnumerable<SP_GET_CASE_IN_APPROVED_Result> temp;

            temp = globalModel.SP_GET_CASE_IN_APPROVED(companyId, underwriterId);

            result = temp
                .Select(dr => new DataReview.Change
                {
                    CorpId = dr.Corp_Id,
                    RegionId = dr.Region_Id,
                    CountryId = dr.Country_Id,
                    DomesticregId = dr.Domesticreg_Id,
                    StateProvId = dr.State_Prov_Id,
                    CityId = dr.City_Id,
                    OfficeId = dr.Office_Id,
                    CaseSeqNo = dr.Case_Seq_No,
                    HistSeqNo = dr.Hist_Seq_No,
                    InsuredContactId = dr.InsuredContactId,
                    OwnerContactId = dr.OwnerContactId,
                    DesignatedPensionerContactId = dr.DesignatedPensionerContactId,
                    StudentContactId = dr.StudentNameContactId,
                    InsuredAddContactId = dr.AddInsuredContactId,
                    AgentId = dr.Agent_Id,
                    CompanyDesc = dr.Company_Desc,
                    PolicyNo = dr.Policy_No,
                    ProductDesc = dr.Product_Desc,
                    ProductNameKey = dr.Product_Name_Key,
                    InsuredFullName = dr.InsuredFullName,
                    CountryDesc = dr.Country_Desc,
                    OfficeDesc = dr.Office_Desc,
                    AgentFullName = dr.AgentFullName,
                    Exception = dr.Exception,
                    SubmitDate = dr.Submit_Date,
                    UserName = dr.UserName,
                    ChangeDate = dr.ChangeDate,
                    TimeChange = dr.TimeChange.ConvertToNoNullable(),
                    PaymentId = dr.Payment_Id.ConvertToNoNullable()
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<Case.Process> GetAllInProcessNB(int companyId, int underwriterId)
        {
            IEnumerable<Case.Process> result;
            IEnumerable<SP_GET_CASE_IN_PROCESS_NB_Result> temp;

            temp = globalModel.SP_GET_CASE_IN_PROCESS_NB(
                    companyId,
                    underwriterId
                );

            result = temp
                .Select(cp => new Case.Process
                {
                    CorpId = cp.Corp_Id,
                    RegionId = cp.Region_Id,
                    CountryId = cp.Country_Id,
                    DomesticregId = cp.Domesticreg_Id,
                    StateProvId = cp.State_Prov_Id,
                    CityId = cp.City_Id,
                    OfficeId = cp.Office_Id,
                    CaseSeqNo = cp.Case_Seq_No,
                    HistSeqNo = cp.Hist_Seq_No,
                    PolicyNo = cp.Policy_No,
                    OwnerContactId = cp.OwnerContactId,
                    InsuredContactId = cp.InsuredContactId,
                    DesignatedPensionerContactId = cp.DesignatedPensionerContactId,
                    AddInsuredContactId = cp.AddInsuredContactId,
                    StudentNameContactId = cp.StudentNameContactId,
                    AgentId = cp.Agent_Id,
                    BussinessLineType = cp.Bussiness_Line_Type,
                    BussinessLineId = cp.Bussiness_Line_Id,
                    ProductId = cp.Product_Id,
                    LastUpdate = cp.LastUpdate,
                    UserId = cp.UserId,
                    ProductDesc = cp.Product_Desc,
                    ProductNameKey = cp.Product_Name_Key,
                    OwnerFullName = cp.OwnerFullName,
                    InsuranceFullName = cp.InsuranceFullName,
                    AgentFullName = cp.AgentFullName,
                    UserFullName = cp.UserFullName,
                    HasComment = cp.HasComment.ConvertToNoNullable(),
                    PaymentId = cp.Payment_Id,
                    CanGoRequirement = cp.CanGoRequirement.ConvertToNoNullable(),
                    OfficeDesc = cp.Office_Desc,
                    CountryDesc = cp.Country_Desc,
                    Exception = cp.Exception
                })
                .ToArray();

            return
                result;
        }
        
        public virtual IEnumerable<Case.Process> GetAllInReviewNB(int companyId, int underwriterId)
        {
            IEnumerable<Case.Process> result;
            IEnumerable<SP_GET_CASE_IN_REVIEW_NB_Result> temp;

            temp = globalModel.SP_GET_CASE_IN_REVIEW_NB(
                    companyId,
                    underwriterId
                );

            result = temp
                .Select(cp => new Case.Process
                {
                    CorpId = cp.Corp_Id,
                    RegionId = cp.Region_Id,
                    CountryId = cp.Country_Id,
                    DomesticregId = cp.Domesticreg_Id,
                    StateProvId = cp.State_Prov_Id,
                    CityId = cp.City_Id,
                    OfficeId = cp.Office_Id,
                    CaseSeqNo = cp.Case_Seq_No,
                    HistSeqNo = cp.Hist_Seq_No,
                    PolicyNo = cp.Policy_No,
                    OwnerContactId = cp.OwnerContactId,
                    InsuredContactId = cp.InsuredContactId,
                    DesignatedPensionerContactId = cp.DesignatedPensionerContactId,
                    AddInsuredContactId = cp.AddInsuredContactId,
                    StudentNameContactId = cp.StudentNameContactId,
                    AgentId = cp.Agent_Id,
                    BussinessLineType = cp.Bussiness_Line_Type,
                    BussinessLineId = cp.Bussiness_Line_Id,
                    ProductId = cp.Product_Id,
                    LastUpdate = cp.LastUpdate,
                    UserId = cp.UserId,
                    ProductDesc = cp.Product_Desc,
                    ProductNameKey = cp.Product_Name_Key,
                    OwnerFullName = cp.OwnerFullName,
                    InsuranceFullName = cp.InsuranceFullName,
                    AgentFullName = cp.AgentFullName,
                    UserFullName = cp.UserFullName,
                    HasComment = cp.HasComment.ConvertToNoNullable(),
                    PaymentId = cp.Payment_Id,
                    IsPaymentCompleted = cp.IsPaymentCompleted.ConvertToNoNullable(),
                    OfficeDesc = cp.Office_Desc,
                    CountryDesc = cp.Country_Desc,
                    Exception = cp.Exception
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<DataReview.DocumentToReview> GetDocumentsToReview(Policy.Parameter policyParameter)
        {
            IEnumerable<DataReview.DocumentToReview> result;
            IEnumerable<SP_GET_DOCUMENT_TO_REVIEW_Result> temp;

            temp = globalModel.SP_GET_DOCUMENT_TO_REVIEW(
                policyParameter.CorpId,
                policyParameter.RegionId,
                policyParameter.CountryId,
                policyParameter.DomesticregId,
                policyParameter.StateProvId,
                policyParameter.CityId,
                policyParameter.OfficeId,
                policyParameter.CaseSeqNo,
                policyParameter.HistSeqNo,
                policyParameter.LanguageId
                );

            result = temp
                .Select(dr => new DataReview.DocumentToReview
                {
                    CorpId = dr.Corp_Id,
                    RegionId = dr.Region_Id,
                    CountryId = dr.Country_Id,
                    DomesticregId = dr.Domesticreg_Id,
                    StateProvId = dr.State_Prov_Id,
                    CityId = dr.City_Id,
                    OfficeId = dr.Office_Id,
                    CaseSeqNo = dr.Case_Seq_No,
                    HistSeqNo = dr.Hist_Seq_No,
                    ContactId = dr.Contact_Id,
                    RequirementCatId = dr.Requirement_Cat_Id,
                    RequirementTypeId = dr.Requirement_Type_Id,
                    RequirementId = dr.Requirement_Id,
                    RequirementDocId = dr.Requirement_Doc_Id,
                    DocTypeId = dr.Doc_Type_Id.ConvertToNoNullable(),
                    DocCategoryId = dr.Doc_Category_Id.ConvertToNoNullable(),
                    DocumentId = dr.Document_Id.ConvertToNoNullable(),
                    TabDesc = dr.Tab_Desc,
                    LastUpdate = dr.LastUpdate,
                    IsReviewed = dr.IsReviewed.ConvertToNoNullable(),
                    FunctionalityId = dr.Functionality_Id,
                    FunctionalitySeqNo = dr.Functionality_Seq_No.ConvertToNoNullable(),
                    NameDesc = dr.Name_Desc,
                    PaymentDetId = dr.PaymentDet_Id,
                    ProjectId = dr.Project_Id,
                    TabId = dr.Tab_Id,
                    PaymentId = dr.Payment_Id,
                    InsuredContactId = dr.InsuredContactId,
                    OwnerContactId = dr.OwnerContactId,
                    AddInsuredContactId = dr.AddInsuredContactId,
                    DesignatedPensionerContactId = dr.DesignatedPensionerContactId,
                    StudentContactId = dr.StudentContactId,
                    AgentId = dr.Agent_Id.ConvertToNoNullable(),
                    ProductNameKey = dr.Product_Name_Key
                })
                .ToArray();

            return
                result;
        }

        public virtual int SetDocumentReview(DataReview.DocumentToReview docReview)
        {
            int result;
            IEnumerable<SP_SET_PL_PCY_TAB_VALID_FUNCTIONALITY_Result> temp;

            result = -1;

            temp = globalModel.SP_SET_PL_PCY_TAB_VALID_FUNCTIONALITY(
                    docReview.CorpId,
                    docReview.RegionId,
                    docReview.CountryId,
                    docReview.DomesticregId,
                    docReview.StateProvId,
                    docReview.CityId,
                    docReview.OfficeId,
                    docReview.CaseSeqNo,
                    docReview.HistSeqNo,
                    docReview.ProjectId,
                    docReview.TabId,
                    docReview.FunctionalityId,
                    docReview.FunctionalitySeqNo,
                    docReview.PaymentDetId,
                    docReview.IsReviewed,
                    docReview.UserId
                );

            return
                result;
        }

        public virtual DataReview.DocumentInfomation GetDocument(DataReview.DocumentInfomation document)
        {
            DataReview.DocumentInfomation result;
            IEnumerable<SP_GET_PAYMENTS_PAYMENTS_DOCUMENT_Result> temp;

            temp = globalModel.SP_GET_PAYMENTS_PAYMENTS_DOCUMENT(
                document.CorpId,
                document.RegionId,
                document.CountryId,
                document.DomesticRegId,
                document.StateProvId,
                document.CityId,
                document.OfficeId,
                document.CaseSeqNo,
                document.HistSeqNo,
                document.DocumentCategoryId,
                document.DocumentTypeId,
                document.DocumentId);

            result = temp
                .Select(pd => new DataReview.DocumentInfomation
                {
                    CorpId = pd.Corp_Id.Value,
                    RegionId = pd.Region_Id.Value,
                    CountryId = pd.Country_Id.Value,
                    DomesticRegId = pd.Domesticreg_Id.Value,
                    StateProvId = pd.State_Prov_Id.Value,
                    CityId = pd.City_Id.Value,
                    OfficeId = pd.Office_Id.Value,
                    CaseSeqNo = pd.Case_Seq_No.Value,
                    HistSeqNo = pd.Hist_Seq_No.Value,
                    DocumentCategoryId = pd.Doc_Category_Id,
                    DocumentTypeId = pd.Doc_Type_Id,
                    DocumentId = pd.Document_Id,
                    DocumentName = pd.Document_Name,
                    FileCreationDate = pd.File_Creation_Date,
                    DocumentTypeDescription = pd.Doc_Type_Desc,
                    ContentType = pd.Content_Type,
                    Extension = pd.Extension,
                    DocumentBinary = pd.Document_Binary
                })
                .FirstOrDefault();

            return
                result;
        }

        public virtual DataTable SendToUnderwriting(DataTable drCase)
        {
            string query;
            SqlDataAdapter dataAdapter;
            DataTable dT;
            SqlCommand command;
            SqlConnection connection;
            SqlParameter parameter;
            
            query = "[DataReview].[SP_SET_SEND_TO_UNDERWRITING]";
            //connection = new SqlConnection(globalModel.Database.Connection.ConnectionString);
            connection = new SqlConnection(base.globalconexionStringForAdo);
            command = new SqlCommand(query, connection);

            parameter = command.Parameters.AddWithValue("@Contacts", drCase);
            command.CommandType = CommandType.StoredProcedure;
            parameter.SqlDbType = SqlDbType.Structured;
            parameter.TypeName = "[Policy].[UDDT_PL_POLICY_CONTACT_MERGE]";
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

        public virtual IEnumerable<DataReview.ContactMerge> GetContactMerge(Policy.Parameter policyParameter)
        {
            IEnumerable<DataReview.ContactMerge> result;
            IEnumerable<SP_GET_CONTACT_MERGE_Result> temp;

            temp = globalModel.SP_GET_CONTACT_MERGE(
                policyParameter.CorpId,
                policyParameter.RegionId,
                policyParameter.CountryId,
                policyParameter.DomesticregId,
                policyParameter.StateProvId,
                policyParameter.CityId,
                policyParameter.OfficeId,
                policyParameter.CaseSeqNo,
                policyParameter.HistSeqNo,
                policyParameter.LanguageId
                );

            result = temp
                .Select(cm => new DataReview.ContactMerge
                {
                    ContactId = cm.Contact_Id,
                    ContactTypeId = cm.Contact_Type_Id,
                    Roles = cm.Roles,
                    FirstName = cm.First_Name,
                    MiddleName = cm.Middle_Name,
                    FirstLastName = cm.Lastname,
                    SecondLastName = cm.Second_Lastname,
                    Dob = cm.Dob,
                    CountryDesc = cm.Country_Desc,
                    Ids = cm.Ids,
                    FullName = cm.Full_Name,
                    IsCompany = cm.Is_Company,
                    MathName = null,
                    MathDob = null,
                    MathIds = null
                })
                .ToArray();

            return
                result;
        }

        public virtual IEnumerable<DataReview.ContactMerge> GetContactMergeMath(int contactTypeId, int languageId)
        {
            IEnumerable<DataReview.ContactMerge> result;
            IEnumerable<SP_GET_CONTACT_MERGE_MATH_Result> temp;

            temp = globalModel.SP_GET_CONTACT_MERGE_MATH(contactTypeId, languageId);

            result = temp
                .Select(cm => new DataReview.ContactMerge
                {
                    ContactId = cm.Contact_Id,
                    ContactTypeId = cm.Contact_Type_Id,
                    Roles = null,
                    FirstName = cm.First_Name,
                    MiddleName = cm.Middle_Name,
                    FirstLastName = cm.Lastname,
                    SecondLastName = cm.Second_Lastname,
                    Dob = cm.Dob,
                    CountryDesc = cm.Country_Desc,
                    Ids = cm.Ids,
                    FullName = cm.Full_Name,
                    IsCompany = null,
                    MathName = null,
                    MathDob = null,
                    MathIds = null
                })
                .ToArray();

            return
                result;
        }

        public virtual DataReview.ContactMerge GetContactMergeById(int contactId)
        {
            DataReview.ContactMerge result;
            IEnumerable<SP_GET_CONTACT_MERGE_BY_ID_Result> temp;

            temp = globalModel.SP_GET_CONTACT_MERGE_BY_ID(contactId);

            result = temp
                .Select(cm => new DataReview.ContactMerge
                {
                    ContactId = cm.Contact_Id,
                    ContactTypeId = cm.Contact_Type_Id,
                    Roles = null,
                    FirstName = null,
                    MiddleName = null,
                    FirstLastName = null,
                    SecondLastName = null,
                    Dob = cm.Dob,
                    CountryDesc = null,
                    Ids = cm.Ids,
                    FullName = cm.Full_Name,
                    IsCompany = null,
                    MathName = null,
                    MathDob = null,
                    MathIds = null
                })
                .FirstOrDefault();

            return
                result;
        }
    }
}
