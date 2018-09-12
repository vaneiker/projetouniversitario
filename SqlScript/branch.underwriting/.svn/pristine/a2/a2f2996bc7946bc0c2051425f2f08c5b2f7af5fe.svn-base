using Entity.UnderWriting.Entities;
using PdfViewer4AspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class UCCompliance : WEB.UnderWriting.Common.UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            foreach (GridViewRow item in GridExposure.Rows)
            {

                Services.ContactManager.UpdateContactSocialExposureByContact(new Entity.UnderWriting.Entities.Contact.SocialExposure
                {
                    CorpId = Service.Corp_Id,
                    RegionId = Service.Region_Id,
                    CountryId = Service.Country_Id,
                    DomesticregId = Service.Domesticreg_Id,
                    StateProvId = Service.State_Prov_Id,
                    CityId = Service.City_Id,
                    OfficeId = Service.Office_Id,
                    CaseSeqNo = Service.Case_Seq_No,
                    HistSeqNo = Service.Hist_Seq_No,
                    ContactId = Service.Contact_Id,
                    SocialFunctionTypeId = Convert.ToInt32(((TextBox)item.FindControl("ExposurePositionTxt")).Attributes["data-exposure"]),
                    SocialFunctionTypePosition = ((TextBox)item.FindControl("ExposurePositionTxt")).Text,
                    CreateUser = 1,
                    ModifyUser = 1
                });
            }
            foreach (GridViewRow item in gvRelationship.Rows)
            {
                Services.ContactManager.UpdateContactSocialExposureRelationshipByContact(new Entity.UnderWriting.Entities.Contact.SocialExposureRelationship
                {
                    CorpId = Service.Corp_Id,
                    RegionId = Service.Region_Id,
                    CountryId = Service.Country_Id,
                    DomesticregId = Service.Domesticreg_Id,
                    StateProvId = Service.State_Prov_Id,
                    CityId = Service.City_Id,
                    OfficeId = Service.Office_Id,
                    CaseSeqNo = Service.Case_Seq_No,
                    HistSeqNo = Service.Hist_Seq_No,
                    ContactId = Service.Contact_Id,
                    SocialFunctionTypeId = Convert.ToInt32(((TextBox)item.FindControl("RelationshipNameTxt")).Attributes["data-relationship"]),
                    SocialFunctionTypePosition = ((TextBox)item.FindControl("RelationshipTypePositionTxt")).Text,
                    SocFuncRelName = ((TextBox)item.FindControl("RelationshipNameTxt")).Text,
                    CreateUser = 1,
                    ModifyUser = 1
                });
            }
            foreach (GridViewRow item in gvQuestions.Rows)
            {
                bool? QuestAnswer = null;
                var checked1 = (RadioButton)item.FindControl("s1");
                var hdn = ((RadioButton)item.FindControl("n1"));
                if (((HiddenField)item.FindControl("hdfRadio_si")).Value == "True")
                {
                    QuestAnswer = true;
                }
                else if (((HiddenField)item.FindControl("hdfRadio_no")).Value == "True")
                {
                    QuestAnswer = false;
                }
                if (QuestAnswer != null)
                {
                    Services.ContactManager.UpdateContactCitizenQuestionByContact(new Entity.UnderWriting.Entities.Contact.CitizenQuestion
                    {
                        CorpId = Service.Corp_Id,
                        RegionId = Service.Region_Id,
                        CountryId = Service.Country_Id,
                        DomesticregId = Service.Domesticreg_Id,
                        StateProvId = Service.State_Prov_Id,
                        CityId = Service.City_Id,
                        OfficeId = Service.Office_Id,
                        CaseSeqNo = Service.Case_Seq_No,
                        HistSeqNo = Service.Hist_Seq_No,
                        ContactId = Service.Contact_Id,
                        CitizenQuestAnswer = QuestAnswer,
                        CitizenQuestId = Convert.ToInt32(((RadioButton)item.FindControl("s1")).Attributes["data-question"]),
                        CreateUser = 1,
                        ModifyUser = 1
                    });
                }
            }
            foreach (GridViewRow item in gvQuetionPEPItSelf.Rows)
            {
                bool? QuestAnswer = null;
                var checked1 = (RadioButton)item.FindControl("s1");
                if (((HiddenField)item.FindControl("hdfRadio_si")).Value == "True")
                {
                    QuestAnswer = true;
                }
                else if (((HiddenField)item.FindControl("hdfRadio_no")).Value == "True")
                {
                    QuestAnswer = false;
                }
                Services.ContactManager.UpdateContactCitizenQuestionByContact(new Entity.UnderWriting.Entities.Contact.CitizenQuestion
                {
                    CorpId = Service.Corp_Id,
                    RegionId = Service.Region_Id,
                    CountryId = Service.Country_Id,
                    DomesticregId = Service.Domesticreg_Id,
                    StateProvId = Service.State_Prov_Id,
                    CityId = Service.City_Id,
                    OfficeId = Service.Office_Id,
                    CaseSeqNo = Service.Case_Seq_No,
                    HistSeqNo = Service.Hist_Seq_No,
                    ContactId = Service.Contact_Id,
                    CitizenQuestAnswer = QuestAnswer,
                    CitizenQuestId = Convert.ToInt32(((RadioButton)item.FindControl("s1")).Attributes["data-question"]),
                    CreateUser = 1,
                    ModifyUser = 1
                });
            }
            this.FillData();

        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        public void FillData(Contact contactInfo)
        {
            var contact = Services.ContactManager.GetContact(Service.Corp_Id,
                                                                Service.Region_Id,
                                                                Service.Country_Id,
                                                                Service.Domesticreg_Id,
                                                                Service.State_Prov_Id,
                                                                Service.City_Id,
                                                                Service.Office_Id,
                                                                Service.Case_Seq_No,
                                                                Service.Hist_Seq_No,
                                                                Service.Contact_Id,
                                                                null,
                                                                1 /*Service.LanguageId*/);
            this.GridExposure.DataSource = contact.SocialExposures;
            this.GridExposure.DataBind();

            this.gvRelationship.DataSource = contact.SocialExposureRelationships;
            this.gvRelationship.DataBind();

            FillPersonalDataContactInformation();
        }

        public void FillData()
        {
            FillComplianceRevisions();
            FillRequiredInfo();
            FillDrop();
            FillDataCitizenContact();
        }

        private void FillComplianceRevisions()
        {
            var CorpId = Service.Corp_Id;
            var RegionId = Service.Region_Id;
            var CountryId = Service.Country_Id;
            var DomesticregId = Service.Domesticreg_Id;
            var StateProvId = Service.State_Prov_Id;
            var CityId = Service.City_Id;
            var OfficeId = Service.Office_Id;
            var CaseSeqNo = Service.Case_Seq_No;
            var HistSeqNo = Service.Hist_Seq_No;
            var complianceData = Services.RequirementManager.GetComplianceContacts(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo, Service.LanguageId.ToInt(),Service.CompanyId);
            var complianceCount = complianceData.Count();
            foreach (var item in complianceData)
            {
                var contactID = item.ContactId;
                var contactName = item.ClientName;
                wsSearchXpert.SearchClient svc = new wsSearchXpert.SearchClient();
                wsSearchXpert.SearchRequest request = new wsSearchXpert.SearchRequest();
                wsSearchXpert.ResultsQueryResponse response = new wsSearchXpert.ResultsQueryResponse();
                wsSearchXpert.Fields[] fields = new wsSearchXpert.Fields[2];
                wsSearchXpert.Fields fieldName = new wsSearchXpert.Fields();
                fieldName.Display = true;
                fieldName.Name = "Name";
                fieldName.Value = contactName.ToString();
                fieldName.Type = "Name";
                fieldName.SearchType = wsSearchXpert.SearchResultTypes.Name;
                wsSearchXpert.Fields fieldSourceID = new wsSearchXpert.Fields();
                fieldSourceID.CoreKey = true;
                fieldSourceID.Display = true;
                fieldSourceID.Name = "Source_Id";
                fieldSourceID.Value = contactID.ToString();
                fieldSourceID.Type = "Name";
                fieldSourceID.SearchType = wsSearchXpert.SearchResultTypes.Name;
                fields[0] = fieldName;
                fields[1] = fieldSourceID;
                request.RequestFields = fields;
                request.CompanyKey = new wsSearchXpert.CompanyKey()
                {
                    Company_Id = Service.CompanyId,
                    Corp_Id = Service.Corp_Id,
                    Country_Id = Service.Country_Id,
                    Region_Id = Service.Region_Id
                };
                request.Source = wsSearchXpert.BaseCores.GLOBAL;
                request.Status = wsSearchXpert.SearchResultStatus.Empty;
                response = svc.QuerySearchOffline(request);
                switch (response.Statusk__BackingField)
                {
                    case wsSearchXpert.SearchResultStatus.Empty:
                        item.statusCompliance = Resources.lblStatusEmpty;
                        break;
                    case wsSearchXpert.SearchResultStatus.NotMatch:
                        item.IsOk = true;
                        item.statusCompliance = Resources.lblStatusNotMatch;
                        break;
                    case wsSearchXpert.SearchResultStatus.PossibleMatch:
                        item.statusCompliance = Resources.lblStatusPossibleMatch;
                        break;
                    case wsSearchXpert.SearchResultStatus.Match:
                        item.statusCompliance = Resources.lblStatusMatch;
                        break;
                    case wsSearchXpert.SearchResultStatus.Deleted:
                        item.statusCompliance = Resources.lblStatusDeleted;
                        break;
                    case wsSearchXpert.SearchResultStatus.NotFound:
                        item.statusCompliance = Resources.lblStatusNotFound;
                        break;
                    case wsSearchXpert.SearchResultStatus.Error:
                        item.statusCompliance = Resources.lblStatusError;
                        break;
                    default:
                        break;
                }
            }
            this.GridComplianceData.DataSource = complianceData;
            this.GridComplianceData.DataBind();
            setPagerIndex(GridComplianceData, complianceCount);
        }

        private void FillRequiredInfo()
        {
            var contact = Services.ContactManager.GetContact(Service.Corp_Id,
                                                            Service.Region_Id,
                                                            Service.Country_Id,
                                                            Service.Domesticreg_Id,
                                                            Service.State_Prov_Id,
                                                            Service.City_Id,
                                                            Service.Office_Id,
                                                            Service.Case_Seq_No,
                                                            Service.Hist_Seq_No,
                                                            Service.Contact_Id,
                                                            null,
                                                            1 /*Service.LanguageId*/);
            STG.BlackList.Risk.RiskClient svc = new STG.BlackList.Risk.RiskClient();

            Entity.UnderWriting.Entities.Policy.PlanData policyInfo = Services.PolicyManager.GetPlanData(Service.Corp_Id,
                                                                                                    Service.Region_Id,
                                                                                                    Service.Country_Id,
                                                                                                    Service.Domesticreg_Id,
                                                                                                    Service.State_Prov_Id,
                                                                                                    Service.City_Id,
                                                                                                    Service.Office_Id,
                                                                                                    Service.Case_Seq_No,
                                                                                                    Service.Hist_Seq_No);
            var agentInfo = Services.PolicyManager.GetAgentSaleChannelInfo(new Policy.Parameter { CorpId = Service.Corp_Id, AgentId = policyInfo.AgentId });
            var agent = new Policy.Agent.SaleChannelInfo();
            if (agentInfo != null && agentInfo.Any())
                agent = agentInfo.FirstOrDefault();
            var ProductTypeGroup = int.Parse(string.Format("{0}{1}", policyInfo.BlId, policyInfo.ProductTypeId));
            var clientType = Entity.UnderWriting.Entities.Requirement.Compliance.ClientType.PHYSICAL_PERSON;
            if (contact.IsCompany)
            {
                if ((contact.CountryOfResidenceId ?? contact.CountryOfBirthId) == 129)
                    clientType = Entity.UnderWriting.Entities.Requirement.Compliance.ClientType.LEGAL_PERSON;
                else
                    clientType = Entity.UnderWriting.Entities.Requirement.Compliance.ClientType.LEGAL_PERSON_FOREIGN;
            }
            else
            {
                if ((contact.CountryOfResidenceId ?? contact.CountryOfBirthId) == 129)
                    clientType = Entity.UnderWriting.Entities.Requirement.Compliance.ClientType.PHYSICAL_PERSON;
                else
                    clientType = Entity.UnderWriting.Entities.Requirement.Compliance.ClientType.PHYSICAL_PERSON_FOREIGN;
            }
            STG.BlackList.Risk.RiskFactor request = new STG.BlackList.Risk.RiskFactor
            {
                ClientTypeId = (int)clientType,
                ClientType = null,
                EmploymentType = null,
                CompanyActivityId = null,
                OccupationId = (contact.IsCompany) ? null : contact.OccupationId,
                OccupGroupTypeId = (contact.IsCompany) ? null : contact.OccupGroupTypeId,
                ChannelsType = null,
                ChannelsDistributionId = (agent.DistributionId == 0) ? 3 : agent.DistributionId,
                CitizenType = null,
                CitizenCountryId = Service.Country_Id,
                Premium = policyInfo.AnnualPremium.GetValueOrDefault(),
                ProductType = null,
                ProductTypeGroupId = ProductTypeGroup,
                BusinessLine = STG.BlackList.Risk.RiskEnumsBusinessLine.LIFE,
                SourceId = Service.Contact_Id.ToString(),
                CoreId = STG.BlackList.Risk.SearchResultCores.GLOBAL,
                SourceNameRef = contact.FullName,
                AdditionalInfo = Service.Policy_Id
            };
            var calculation = svc.CalculateRiskFactor(request);
            #region Required Information Fields
            if (calculation != null)
            {
                var requiredInfo = calculation.RequiredFields.Select(f => new Entity.UnderWriting.Entities.Requirement.Compliance.RequiredData
                {
                    FieldId = f.Risk_Info_Id.GetValueOrDefault(),
                    Field = f.Risk_Info,
                    FieldReference = f.Risk_Info_Reference,
                    Required = true
                }).ToList();
                foreach (var item in requiredInfo)
                {
                    var field = (Entity.UnderWriting.Entities.Requirement.Compliance.Fields)Enum.Parse(typeof(Entity.UnderWriting.Entities.Requirement.Compliance.Fields), item.Field);
                    switch (field)
                    {
                        case Requirement.Compliance.Fields.FULLNAME:
                            item.Completed = (contact.IsCompany ? !string.IsNullOrEmpty(contact.CompanyName) : (!string.IsNullOrEmpty(contact.FirstName ?? contact.MiddleName) && !string.IsNullOrEmpty(contact.FirstLastName ?? contact.SecondLastName)));
                            break;
                        case Requirement.Compliance.Fields.DOB:
                            item.Completed = contact.Dob != null;
                            break;
                        case Requirement.Compliance.Fields.CITIZENSHIP:
                            item.Completed = (contact.CountryOfBirthId ?? contact.CountryOfResidenceId) != null;
                            break;
                        case Requirement.Compliance.Fields.GENDER:
                            item.Completed = !string.IsNullOrEmpty(contact.Gender);
                            break;
                        case Requirement.Compliance.Fields.ID:
                        case Requirement.Compliance.Fields.ID_TYPE:
                            item.Completed = !string.IsNullOrEmpty(contact.Id);
                            break;
                        case Requirement.Compliance.Fields.ADDRESS:
                            item.Completed = (contact.Addresses != null && contact.Addresses.Where(d => d.DirectoryTypeId == 5).Any());
                            break;
                        case Requirement.Compliance.Fields.PHONE_NUMBER:
                            item.Completed = contact.Phones != null && contact.Phones.Any();
                            break;
                        case Requirement.Compliance.Fields.EMAIL:
                            item.Completed = contact.Emails != null && contact.Emails.Any();
                            break;
                        case Requirement.Compliance.Fields.EMPLOYMENT_ACTIVITY:
                            break;
                        case Requirement.Compliance.Fields.JOB_COMPANY_NAME:
                            item.Completed = contact.CompanyName != null && contact.CompanyName.Any();
                            break;
                        case Requirement.Compliance.Fields.JOB_COMPANY_ADDRESS:
                            item.Completed = (contact.Addresses != null && contact.Addresses.Where(d => d.DirectoryTypeId == 4).Any());
                            break;
                        case Requirement.Compliance.Fields.ANNUAL_INCOME:
                            item.Completed = (contact.AnnualPersonalIncome ?? contact.AnnualFamilyIncome) != null;
                            break;
                        case Requirement.Compliance.Fields.PREMIUM_PAYMENT_METHOD:
                            item.Completed = !string.IsNullOrEmpty(policyInfo.PaymentMethod);
                            break;
                        case Requirement.Compliance.Fields.PEP_QUESTIONAIRE:
                            item.Completed = contact.CitizenQuestions != null && contact.CitizenQuestions.Any();
                            break;
                        case Requirement.Compliance.Fields.COMPANY_NAME:
                            break;
                        case Requirement.Compliance.Fields.COMPANY_COMMERCIAL_ACTIVITY:
                            break;
                        case Requirement.Compliance.Fields.COMPANY_STRUCTURE:
                            break;
                        case Requirement.Compliance.Fields.FINAL_BENEFICIARY_INFO:
                            break;
                        case Requirement.Compliance.Fields.PUBLIC_ORGANIZATION_MANAGER:
                            break;
                        case Requirement.Compliance.Fields.PUBLIC_ORGANIZATION_MANAGER_AD:
                            break;
                        default:
                            break;
                    }
                }
                int complianceRequiredFieldsCount = 0;
                if (requiredInfo != null && requiredInfo.Any())
                {
                    complianceRequiredFieldsCount = requiredInfo.Count();
                    var dataInfoReq = requiredInfo.OrderBy(c => c.Completed).ToArray();
                    this.gvRequiredInfoCompliance.DataSource = dataInfoReq;
                }

                this.gvRequiredInfoCompliance.DataBind();
                setPagerIndex(gvRequiredInfoCompliance, complianceRequiredFieldsCount);
                #endregion
                #region Required Information Documents
                var requiredDocs = calculation.RequiredDocuments.Select(f => new Entity.UnderWriting.Entities.Requirement.Compliance.RequiredData
                {
                    FieldId = f.Risk_Document_Id.GetValueOrDefault(),
                    Field = f.Risk_Document,
                    FieldReference = f.Risk_Document_Reference,
                    Required = true
                }).ToList();
                var requirementData = Services.RequirementManager.GetAll(
                          Service.Corp_Id
                        , Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id, Service.City_Id, Service.Office_Id
                        , Service.Case_Seq_No, Service.Hist_Seq_No, Service.LanguageId
                        ).ToList();
                var contactDocs = new List<Entity.UnderWriting.Entities.Requirement>();
                if (requirementData != null && requirementData.Any())
                    contactDocs = requirementData.Where(c => c.ContactId == Service.Contact_Id).ToList();
                foreach (var item in requiredDocs)
                {
                    var document = (Entity.UnderWriting.Entities.Requirement.Compliance.Documents)Enum.Parse(typeof(Entity.UnderWriting.Entities.Requirement.Compliance.Documents), item.Field);
                    switch (document)
                    {
                        case Requirement.Compliance.Documents.ID_DOCUMENT:
                            item.Completed = contactDocs.Where(d => d.RequirementTypeId == 3 && d.DocumentId != null).Any();
                            break;
                        case Requirement.Compliance.Documents.PEP_DOCUMENT:
                            break;
                        case Requirement.Compliance.Documents.COMPANY_REGISTRY:
                            break;
                        case Requirement.Compliance.Documents.COMPANY_SOCIETY_CERTIFICATION:
                            break;
                        case Requirement.Compliance.Documents.SHAREHOLDER_LIST:
                            break;
                        case Requirement.Compliance.Documents.FINAL_BENEFICIARY_OVER20:
                            break;
                        case Requirement.Compliance.Documents.COMPANY_DOMICILE_CERTIFICATION:
                            break;
                        default:
                            break;
                    }
                }
                int complianceRequiredDocumentsCount = 0;
                if (requiredDocs != null && requiredDocs.Any())
                {
                    complianceRequiredDocumentsCount = requiredDocs.Count();
                    var dataDocsReq = requiredDocs.OrderBy(c => c.Completed).ToArray();
                    this.gvRequiredDocumentsCompliance.DataSource = dataDocsReq;
                }
                this.gvRequiredDocumentsCompliance.DataBind();
                setPagerIndex(gvRequiredDocumentsCompliance, complianceRequiredDocumentsCount);
                #endregion
                #region Set risk indicator properties
                string colorRisk = string.Empty;
                switch (calculation.ScaleReference)
                {
                    case STG.BlackList.Risk.RiskEnumsScale.LOW:
                        colorRisk = "#59a228";
                        break;
                    case STG.BlackList.Risk.RiskEnumsScale.MODERATE:
                        colorRisk = "#ffd150";
                        break;
                    case STG.BlackList.Risk.RiskEnumsScale.HIGH:
                        colorRisk = "#f44336";
                        break;
                    case STG.BlackList.Risk.RiskEnumsScale.EMPTY:
                    default:
                        colorRisk = "#000";
                        break;
                }
                this.divRiskFactor.Style.Add("background-color", colorRisk);
                this.ltRiskIndicator.Text = calculation.Indicator.GetValueOrDefault().ToString("F");
                this.ltRiskReference.Text = calculation.ScaleReference.ToString();
                this.ltRiskReference2.Text = calculation.Scale.ToString();
                #endregion
            }
        }

        public void clearData()
        {
            gvRelationship.DataSource = null;
            gvRelationship.DataBind();
            GridExposure.DataSource = null;
            GridExposure.DataBind();
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
            gvQuestions.DataSource = null;
            gvQuestions.DataBind();
        }

        private void FillPersonalDataContactInformation()
        {
            var info = Services.ContactManager.GetContactCitizenQuestionByContact(Service.Corp_Id,
                                                                                                    Service.Region_Id,
                                                                                                    Service.Country_Id,
                                                                                                    Service.Domesticreg_Id,
                                                                                                    Service.State_Prov_Id,
                                                                                                    Service.City_Id,
                                                                                                    Service.Office_Id,
                                                                                                    Service.Case_Seq_No,
                                                                                                    Service.Hist_Seq_No,
                                                                                                    Service.Contact_Id,
                                                                                                    1 /*Service.LanguageId*/);
            this.gvQuestions.DataSource = info.Where(n => n.NameKey != "ISCLIENTPEP").ToArray();
            this.gvQuetionPEPItSelf.DataSource = info.Where(n => n.NameKey == "ISCLIENTPEP").ToArray();
            this.gvQuetionPEPItSelf.DataBind();

            this.gvQuestions.DataBind();
        }

        void setPagerIndex(GridView gv, int Count)
        {
            if (gv.BottomPagerRow == null) return;
            var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
            var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
            var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
            var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
            var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
            var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


            var count = gv.PageCount;
            var index = gv.PageIndex + 1;

            indexText.Text = index.ToString();
            totalText.Text = count.ToString();

            if (index == 1)
            {
                DisableLinkButton(lnkPrev, "prev_dis");
                DisableLinkButton(lnkFirst, "rewd_dis");
            }
            else if (index == count)
            {
                DisableLinkButton(lnkNext, "next_dis");
                DisableLinkButton(lnkLast, "fwrd_dis");

            }

            var totalItems = (Literal)gv.BottomPagerRow.FindControl("totalItems");
            totalItems.Text = Count.ToString();
        }

        public void DisableLinkButton(LinkButton linkButton, string disable_class)
        {
            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }

        protected void GridComplianceData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridComplianceData.PageIndex = e.NewPageIndex;
            GridComplianceData.DataBind();
            FillData();
        }

        protected void gvRequiredInfoCompliance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequiredInfoCompliance.PageIndex = e.NewPageIndex;
            gvRequiredInfoCompliance.DataBind();
            FillData();
        }

        protected void gvRequiredDocumentsCompliance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequiredDocumentsCompliance.PageIndex = e.NewPageIndex;
            gvRequiredDocumentsCompliance.DataBind();
            FillData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            saveCitizenContact();
        }
        #region TempData
        public String PrefixSession
        {
            get { return "PolicyPlanData"; }
            /*set { hdnCurrentSession.Value = value; }*/
        }
        public int? RowIndex
        {
            get { return int.Parse((Session[PrefixSession + "_RowIndexCitizenContact"] ?? 0).ToString()); }
            set { Session[PrefixSession + "_RowIndexCitizenContact"] = value; }
        }
        public List<Entity.UnderWriting.Entities.Contact.CitizenContact> TempDataCitizenContact = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>();
        public List<Entity.UnderWriting.Entities.Contact.CitizenContact> oTemDataCitizenContact
        {
            get
            {
                return Session[PrefixSession + "_TemDataCitizenContact"] == null ?
                    new List<Entity.UnderWriting.Entities.Contact.CitizenContact>() :
                    Session[PrefixSession + "_TemDataCitizenContact"] as List<Entity.UnderWriting.Entities.Contact.CitizenContact>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact.CitizenContact> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>(
                            Session[PrefixSession + "_TemDataCitizenContact"] != null
                            ?
                            (
                               (List<Entity.UnderWriting.Entities.Contact.CitizenContact>)Session[PrefixSession + "_TemDataCitizenContact"]
                            )
                            :
                            new List<Entity.UnderWriting.Entities.Contact.CitizenContact>()
                      );

                    tempList.AddRange(value);
                }

                Session[PrefixSession + "_TemDataCitizenContact"] = tempList;
            }
        }
        #endregion

        /// <summary>
        /// Bindear el grid
        /// </summary>
        public void FillDataCitizenContact()
        {

            if (Service.Contact_Id > 0)
            {
                oTemDataCitizenContact = null;

                Entity.UnderWriting.Entities.Contact.CitizenContact param = new Entity.UnderWriting.Entities.Contact.CitizenContact
                {
                    Corp_Id = Service.Corp_Id,
                    Region_Id = Service.Region_Id,
                    Country_Id = Service.Country_Id,
                    Domesticreg_Id = Service.Domesticreg_Id,
                    State_Prov_Id = Service.State_Prov_Id,
                    City_Id = Service.City_Id,
                    Office_Id = Service.Office_Id,
                    Case_Seq_No = Service.Case_Seq_No,
                    Hist_Seq_No = Service.Hist_Seq_No,
                    Contact_Id = Service.Contact_Id,
                    Language_id = 1 /*Service.LanguageId*/
                };


                oTemDataCitizenContact = Services.ContactManager.GetAllCitizenContact(param).ToList();
            }

            var data = (from source in oTemDataCitizenContact
                        select new
                        {
                            source.Exposure_Related_Id,
                            source.FullName,
                            source.Relationship,
                            source.RelationshipDesc,
                            source.Position,
                            From = string.Format("{0:MM/dd/yyyy}", source.JobFromDate),
                            To = string.Format("{0:MM/dd/yyyy}", source.JobToDate)
                        }).ToList();


            gvCitizenContactPepRelated.DataSource = data;
            gvCitizenContactPepRelated.DataBind();
            gvCitizenContactPepRelated.Selection.UnselectAll();
            /*udpBackgroundInformation.Update();*/
        }

        public void saveCitizenContact()
        {
            Entity.UnderWriting.Entities.Contact.CitizenContact item = null;

            var record = new Entity.UnderWriting.Entities.Contact.CitizenContact();

            if (oTemDataCitizenContact != null && oTemDataCitizenContact.Any())
                record = oTemDataCitizenContact.ElementAt(RowIndex.Value);

            //Agregar un item
            item = new Entity.UnderWriting.Entities.Contact.CitizenContact()
            {
                Exposure_Related_Id = record.Exposure_Related_Id,
                Corp_Id = Service.Corp_Id,
                Region_Id = Service.Region_Id,
                Country_Id = Service.Country_Id,
                Domesticreg_Id = Service.Domesticreg_Id,
                State_Prov_Id = Service.State_Prov_Id,
                City_Id = Service.City_Id,
                Office_Id = Service.Office_Id,
                Case_Seq_No = Service.Case_Seq_No,
                Hist_Seq_No = Service.Hist_Seq_No,
                Contact_Id = Service.Contact_Id,
                FullName = txtFullNamePepRelated.Text,
                Relationship = int.Parse(ddlRelationshipPepRelated.SelectedValue),
                RelationshipDesc = ddlRelationshipPepRelated.SelectedItem.Text,
                Position = txtPositionPepRelated.Text,
                JobFromDate = !string.IsNullOrEmpty(txtFromPepRelated.Text) ? txtFromPepRelated.Text.ParseFormat() : (DateTime?)null,
                JobToDate = !string.IsNullOrEmpty(txtToPepRelated.Text) ? txtToPepRelated.Text.ParseFormat() : (DateTime?)null,
                CreateUser = 1,
                ModifyUser = 1

            };

            //Guardar directamente en la base de datos tanto si es un insert como un edit
            TempDataCitizenContact.Add(item);
            oTemDataCitizenContact = TempDataCitizenContact;
            Service.SetCitizenContact(oTemDataCitizenContact);
            oTemDataCitizenContact = null;
            gvCitizenContactPepRelated.PageIndex = (gvCitizenContactPepRelated.PageCount - 1);



            btnAddPepInformationRelated.Text = "Add";
            //Bindear el grid
            FillDataCitizenContact();

            //Limpiar los controles a excepcion del grid
            //ClearControls(gvCitizenContact); 
            txtFullNamePepRelated.Text = string.Empty;
            ddlRelationshipPepRelated.SelectedIndex = -1;
            txtPositionPepRelated.Text = string.Empty;
            txtFromPepRelated.Text = string.Empty;
            txtToPepRelated.Text = string.Empty;
        }

        protected void gvCitizenContact_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;
            RowIndex = e.VisibleIndex;
            var GridView = (sender as DevExpress.Web.ASPxGridView);
            GridView.Selection.UnselectAll();

            switch (Commando)
            {
                case "Modify":
                    //Editar
                    setDataForm(oTemDataCitizenContact.ElementAt(RowIndex.Value));
                    gvCitizenContactPepRelated.FocusedRowIndex = -1;
                    btnAddPepInformationRelated.Text = "Save";
                    break;
                case "Delete":
                    //Eliminar           
                    var ExposureRelatedId = int.Parse(gvCitizenContactPepRelated.GetKeyFromAspxGridView("Exposure_Related_Id", RowIndex.Value).ToString());

                    Entity.UnderWriting.Entities.Contact.CitizenContact param = new Entity.UnderWriting.Entities.Contact.CitizenContact
                    {
                        Corp_Id = Service.Corp_Id,
                        Region_Id = Service.Region_Id,
                        Country_Id = Service.Country_Id,
                        Domesticreg_Id = Service.Domesticreg_Id,
                        State_Prov_Id = Service.State_Prov_Id,
                        City_Id = Service.City_Id,
                        Office_Id = Service.Office_Id,
                        Case_Seq_No = Service.Case_Seq_No,
                        Hist_Seq_No = Service.Hist_Seq_No,
                        Contact_Id = Service.Contact_Id,
                        Exposure_Related_Id = ExposureRelatedId
                    };

                    Services.ContactManager.DeleteCitizenContact(param);

                    //Llenar Data
                    FillDataCitizenContact();
                    break;
            }
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.CitizenContact item)
        {
            txtFullNamePepRelated.Text = item.FullName;
            ddlRelationshipPepRelated.SelectedValue = item.Relationship.ToString();
            txtPositionPepRelated.Text = item.Position;
            txtFromPepRelated.Text = item.JobFromDate.ToString();
            txtToPepRelated.Text = item.JobToDate.ToString();
        }


        protected void gvCitizenContact_PageIndexChanged(object sender, EventArgs e)
        {
            FillDataCitizenContact();
        }

        protected void btnPepRelatedInfoSet_Click(object sender, EventArgs e)
        {
            hdnNewPepRelatedShowPop.Value = "true";
        }

        public void FillDrop()
        {

            Service.DropDowns.GetDropDown(ref ddlRelationshipPepRelated,
                                       Language.English,
                                       DropDownType.Relationship,
                                       Service.Corp_Id,
                                       null,
                                       projectId: Service.ProjectId,
                                       companyId: Service.CompanyId);

        }

        protected void idcontrolprueba_Click(object sender, EventArgs e)
        {
            this.save();
        }
    }
}