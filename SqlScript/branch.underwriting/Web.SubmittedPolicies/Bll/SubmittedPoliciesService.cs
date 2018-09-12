using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Web.SubmittedPolicies.Bll.Poco;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.Dal;
namespace Web.SubmittedPolicies.Bll
{
    public class SubmittedPoliciesService
    {
        private readonly Global_Entities _dCGlobalEntities = new Global_Entities();
        private int CompanyId { get; set; }

        public SubmittedPoliciesService(int companyId)
        {
            CompanyId = companyId;
        }

        #region Main Grids
        public IQueryable GetIssuePolicies()
        {
            var query = _dCGlobalEntities.VW_GET_POLICY_ISSUE.Where(r => r.Company_Id == CompanyId);
            return query;
        }

        public IQueryable GetPrintingPolicies(String policyNo = null, String productType = null, Boolean? printStatus = null)
        {
            var query = _dCGlobalEntities.VW_GET_POLICY_PRINT.Where(r => r.Company_Id == CompanyId
                && (policyNo == null || r.Policy_No == policyNo)
                && (productType == null || r.Product_Desc == productType)
                && (printStatus == null || r.Is_Print == printStatus));
            return query;
        }

        public IQueryable GetConfirmationPolicies()
        {
            var query = _dCGlobalEntities.VW_GET_POLICY_CONFIRMATION.Where(r => r.Company_Id == CompanyId);
            return query;
        }

        public IQueryable GetNeverIssuedPolicies()
        {
            var query = _dCGlobalEntities.VW_GET_POLICY_NEVER_ISSUED.Where(r => r.Company_Id == CompanyId);
            return query;
        }


        public IQueryable GetProcessingPolicies()
        {
            var query = _dCGlobalEntities.VW_GET_POLICY_ISSUE_PROCESSING.Where(r => r.Company_Id == CompanyId);
            return query;
        }


        #endregion

        #region PolicyInfo
        public List<PolicyData> GetPolicyInfo(int projectId, Common.Classes.Common.PolicyKeyItem keyItem)
        {
            var data = (from d in _dCGlobalEntities.SP_GET_POLICY_DATA(CompanyId, projectId, keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo)
                        select new PolicyData()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_Seq_No = d.Case_Seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Policy_No = d.Policy_No,
                            OwnerFullName = d.OwnerFullName,
                            Country_Of_Residence_Id_Owner = d.Country_Of_Residence_Id_Owner,
                            Country_Of_Residence_Desc_Owner = d.Country_Of_Residence_Desc_Owner,
                            Country_Of_Birth_Id_Owner = d.Country_Of_Birth_Id_Owner,
                            Country_Of_Birth_Desc_Owner = d.Country_Of_Birth_Desc_Owner,
                            Annual_Personal_Income = d.Annual_Personal_Income,
                            InsuredFullName = d.InsuredFullName,
                            Country_Of_Residence_Id_Insured = d.Country_Of_Residence_Id_Insured,
                            Country_Of_Residence_Desc_Insured = d.Country_Of_Residence_Desc_Insured,
                            Smoker_Insured = d.Smoker_Insured,
                            ApplicationDate = d.ApplicationDate,
                            Product_Desc = d.Product_Desc,
                            Initial_Premium = d.Initial_Premium,
                            Insured_Amount = d.Insured_Amount,
                            Periodic_Premium = d.Periodic_Premium,
                            Underwriter_Id = d.Underwriter_Id,
                            Underwriter_Name = d.Underwriter_Name,
                            Annual_premiun = d.Annual_premiun,
                            BackgroundCheckResult = d.BackgroundCheckResult,
                            Contribution_Years = d.Contribution_Years,
                            BackgroundCheckResult_Desc = d.BackgroundCheckResult_Desc,
                            Smoker_Insured_Desc = d.Smoker_Insured_Desc,
                        }).ToList();

            return data;
        }

        public List<PolicyRider> GetPolicyRiders(Common.Classes.Common.PolicyKeyItem keyItem)
        {
            var data = (from d in _dCGlobalEntities.SP_GET_POLICY_RIDER(keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo)
                        select new PolicyRider()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_seq_No = d.Case_seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Rider_Type_Id = d.Rider_Type_Id,
                            Rider_id = d.Rider_id,
                            Ryder_Type_Desc = d.Ryder_Type_Desc,
                            Beneficiary_Amount = d.Beneficiary_Amount,
                            Effective_Date = d.Effective_Date,
                            Expire_Date = d.Expire_Date,
                            Number_Of_Year = d.Number_Of_Year,
                            Extra_Premium = d.Extra_Premium,
                            Extra_Premium_Comments = d.Extra_Premium_Comments,
                            Rider_Status_Id = d.Rider_Status_Id,
                            Rider_Status_Desc = d.Rider_Status_Desc

                        }).ToList();

            return data;
        }

        public List<NeverIssuedPolicyInfo> GetNeverIssuedPolicyInfo(Common.Classes.Common.PolicyKeyItem keyItem)
        {
            var data = (from d in _dCGlobalEntities.SP_GET_POLICY_NEVER_ISSUED_INFO(keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo)
                        select new NeverIssuedPolicyInfo()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_Seq_No = d.Case_Seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Step_Type_Id = d.Hist_Seq_No,
                            Step_Id = d.Step_Id,
                            Step_Case_No = d.Step_Case_No,
                            Note_Id = d.Note_Id,
                            Policy_No = d.Policy_No,
                            Product_Desc = d.Product_Desc,
                            AgentFullName = d.AgentFullName,
                            OwnerFullName = d.OwnerFullName,
                            Initial_Premium = d.Initial_Premium,
                            Office_Desc = d.Office_Desc,
                            ApplicationDate = d.ApplicationDate,
                            Step_Reason_Id = d.Step_Reason_Id,
                            Penalty = d.Penalty,
                            Note_Desc = d.Note_Desc
                        }).ToList();

            return data;
        }

        public List<RejectPolicyInfo> GetRejectPolicyInfo(Common.Classes.Common.PolicyKeyItem keyItem)
        {
            if (keyItem == null) return new List<RejectPolicyInfo>();

            var data = (from d in _dCGlobalEntities.SP_GET_POLICY_REJECT_INFO(keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo)
                        select new RejectPolicyInfo()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_Seq_No = d.Case_Seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Step_Type_Id = d.Step_Type_Id,
                            Step_Id = d.Step_Id,
                            Step_Case_No = d.Step_Case_No,
                            Policy_No = d.Policy_No,
                            Product_Desc = d.Product_Desc,
                            AgentFullName = d.AgentFullName,
                            OwnerFullName = d.OwnerFullName,
                            Initial_Premium = d.Initial_Premium,
                            Office_Desc = d.Office_Desc
                        }).ToList();

            return data;
        }
        #endregion

        #region SetPolicies
        public bool SetPoliciesNeverIssued(List<Common.Classes.Common.PolicyKeyItem> policyList, int userId)
        {
            try
            {
                if (policyList == null) return false;

                foreach (var keyItem in policyList)
                {
                    _dCGlobalEntities.SP_SET_POLICY_NERVER_ISSUED(keyItem.CorpId, keyItem.RegionId,
                         keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                         keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo, keyItem.StepTypeId, keyItem.StepId, keyItem.StepCaseNo, userId);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SendNeverIssuedPolicy(Common.Classes.Common.PolicyKeyItem keyItem, int reasonId, bool penalty, string note, int userId)
        {
            try
            {
                if (keyItem == null) return false;

                _dCGlobalEntities.SP_SET_POLICY_NERVER_ISSUED_EDIT(keyItem.CorpId, keyItem.RegionId,
                    keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                    keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo, keyItem.StepTypeId, keyItem.StepId, keyItem.StepCaseNo,
                    null, note, reasonId, penalty, userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RejectPolicies(Common.Classes.Common.PolicyKeyItem keyItem, string note, int userId)
        {
            try
            {
                if (keyItem == null) return false;

                _dCGlobalEntities.SP_SET_POLICY_REJECT(keyItem.CorpId, keyItem.RegionId,
                    keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                    keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo, keyItem.StepTypeId, keyItem.StepId, keyItem.StepCaseNo, note, userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangePolicyStatus(List<Common.Classes.Common.PolicyKeyItem> policyList, int userId)
        {
            try
            {
                if (policyList == null) return false;

                foreach (var keyItem in policyList)
                {
                    _dCGlobalEntities.SP_SET_PL_PCY_STATUS_CHANGE(keyItem.CorpId, keyItem.RegionId,
                         keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                         keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo, 8, 5, null, userId);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Ammendments
        public List<PolicyAmmendment> GetPolicyAmmendments(int projectId, Common.Classes.Common.PolicyKeyItem keyItem)
        {
            var data = (from d in _dCGlobalEntities.SP_GET_POLICY_AMMENDMENT(CompanyId, projectId, keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo)
                        select new PolicyAmmendment()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_Seq_No = d.Case_Seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Ammendment_Id = d.Ammendment_Id,
                            Ammendment_Type_Id = d.Ammendment_Type_Id,
                            Ammend_Type_Desc = d.Ammend_Type_Desc,
                            Insured_Scope_Id = d.Insured_Scope_Id,
                            Insured_Scope_Desc = d.Insured_Scope_Desc,
                            Comments = d.Comments,
                            Is_Completed = d.Is_Completed,
                            Ammendment_Det_Id = d.Ammendment_Det_Id,
                            Doc_Type_Id = d.Doc_Type_Id,
                            Doc_Category_Id = d.Doc_Category_Id,
                            Document_Id = d.Document_Id,
                            Uploaded_On = d.Uploaded_On,
                            Status_Desc = d.Status_Desc
                        }).ToList();

            return data;
        }

        public void SetAmmendmentDocument(Common.Classes.Common.PolicyKeyItem keyItem, int ammendmentId, byte[] documentFile, string documentName, DateTime? expirationDate, int userId)
        {
            _dCGlobalEntities.SP_SET_POLICY_AMMENDMENT_DOCUMENT(keyItem.CorpId,
                keyItem.RegionId,
                keyItem.CountryId,
                keyItem.DomesticregId,
                keyItem.StateProvId,
                keyItem.CityId,
                keyItem.OfficeId,
                keyItem.CaseSeqNo,
                keyItem.HistSeqNo,
                ammendmentId,
                documentFile,
                documentName,
                expirationDate,
                userId);
        }

        public void ReplaceAmmendmentDocument(Common.Classes.Common.PolicyKeyItem keyItem, int ammendmentId, int userId)
        {
            _dCGlobalEntities.SP_SET_POLICY_AMMENDMENT_STATUS_PENDING(keyItem.CorpId,
              keyItem.RegionId,
              keyItem.CountryId,
              keyItem.DomesticregId,
              keyItem.StateProvId,
              keyItem.CityId,
              keyItem.OfficeId,
              keyItem.CaseSeqNo,
              keyItem.HistSeqNo,
              ammendmentId,
              userId);
        }
        #endregion

        #region PolicyDocuments
        public PolicyDocuments GetPolicyDocument(Common.Classes.Common.PolicyKeyItem keyItem, int docCategoryId, int docTypeId, int documentId)
        {
            var data = (from d in _dCGlobalEntities.SP_GET_PAYMENTS_PAYMENTS_DOCUMENT(keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo, docCategoryId, docTypeId, documentId)
                        select new PolicyDocuments()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_Seq_No = d.Case_Seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Doc_Type_Id = d.Doc_Type_Id,
                            Doc_Category_Id = d.Doc_Category_Id,
                            Document_Id = d.Document_Id,
                            Document_Name = d.Document_Name,
                            Document_Binary = d.Document_Binary,
                            File_Creation_Date = d.File_Creation_Date,
                            Doc_Type_Desc = d.Doc_Type_Desc,
                            Content_Type = d.Content_Type,
                            Extension = d.Extension,
                        }).First();

            return data;
        }

        public List<PolicyDocumentInfo> GetPolicyDocumentInfo(Common.Classes.Common.PolicyKeyItem keyItem)
        {
            var data = (from d in _dCGlobalEntities.SP_GET_POLICY_DOCUMENT_INFO(keyItem.CorpId, keyItem.RegionId,
                keyItem.CountryId, keyItem.DomesticregId, keyItem.StateProvId, keyItem.CityId,
                keyItem.OfficeId, keyItem.CaseSeqNo, keyItem.HistSeqNo)
                        select new PolicyDocumentInfo()
                        {
                            Corp_Id = d.Corp_Id,
                            Region_Id = d.Region_Id,
                            Country_Id = d.Country_Id,
                            Domesticreg_Id = d.Domesticreg_Id,
                            State_Prov_Id = d.State_Prov_Id,
                            City_Id = d.City_Id,
                            Office_Id = d.Office_Id,
                            Case_Seq_No = d.Case_Seq_No,
                            Hist_Seq_No = d.Hist_Seq_No,
                            Policy_No = d.Policy_No,
                            Effective_Date = d.Effective_Date,
                            Product_Desc = d.Product_Desc,
                            Currency_Desc = d.Currency_Desc,
                            Monthly_Anniversary = d.Monthly_Anniversary,
                            Expiration_Date = d.Expiration_Date,
                            Initial_Premium = d.Initial_Premium,
                            Periodic_Premium = d.Periodic_Premium,
                            Insured_Amount = d.Insured_Amount,
                            Rider = d.Rider,
                            RiderADB = d.RiderADB,
                            RiderSEGTEMAD = d.RiderSEGTEMAD,
                            RiderSPINS = d.RiderSPINS,
                            Owner_Address = d.Owner_Address,
                            Owner_Id = d.Owner_Id,
                            Insured_Address = d.Insured_Address,
                            Insured_Id = d.Insured_Id,
                            Beneficiary = d.Beneficiary,
                            BeneficiaryContingent = d.BeneficiaryContingent,
                            Owner_FullName = d.Owner_FullName,
                            Insured_FullName = d.Insured_FullName,
                            Insured_Age = d.Insured_Age,
                            Insured_Smoker = d.Insured_Smoker,
                            Contribution_Years = d.Contribution_Years,
                            Insured_Periodic = d.Insured_Periodic,
                            Payment_Freq_Type_Desc = d.Payment_Freq_Type_Desc,
                            Rate_Return = d.Corp_Id,
                            Insured_Gender = d.Insured_Gender
                        }).ToList();

            return data;
        }
        #endregion

        #region DropDowns
        public List<DropdownItem> GetDropDowns(Enums.DropDowns ddlItem, int? corpId = null)
        {
            var companyId = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ProjectId"]);

            var plainData = _dCGlobalEntities.SP_GET_UW_DROPDOWN(ddlItem.ToString(), corpId, 2, companyId, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 2, null, 2);

            var data = new List<DropdownItem>();

            switch (ddlItem)
            {
                case Enums.DropDowns.LifeProduct:
                    data = (from d in plainData
                            select new DropdownItem()
                            {
                                Value = d.Namekey,
                                Text = d.Product_Desc
                            }).ToList();

                    break;
                case Enums.DropDowns.PrintStatus:
                    data = (from d in plainData
                            select new DropdownItem()
                            {
                                Value = d.Print_Status.ToString(),
                                Text = d.Code_Name
                            }).ToList();
                    break;
                case Enums.DropDowns.StepsReason:
                    data = (from d in plainData
                            select new DropdownItem()
                            {
                                Value = d.Step_Reason_Id.ToString(),
                                Text = d.Step_Reason_Desc
                            }).ToList();
                    break;
            }

            return data;
        }
        #endregion
    }
}