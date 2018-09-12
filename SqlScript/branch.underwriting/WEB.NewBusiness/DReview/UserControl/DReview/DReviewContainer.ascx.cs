using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.DReview.UserControl.DReview
{
    public partial class DReviewContainer : UC, IUC
    {
        private System.Web.Script.Serialization.JavaScriptSerializer Serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        public delegate List<Utility.DocumentItem> getDocumentByTabHandler(int Tab);

        public getDocumentByTabHandler getDocumentByTab;

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public class ValidationRNC
        {
            public Boolean ValidRNC { get; set; }
            public Boolean InvalidRNC { get; set; }

        }

        public void Translator(string Lang)
        {
            DataReview.InnerHtml = Resources.DataReview.ToUpper();
            btnExport.Text = Resources.Export.ToUpper();
            btnClientInfo.Text = Resources.ClientInfoLabel.ToUpper();
            if (ObjServices.Language.ToString() == "en")
                btnOwnerInfo.Text = Resources.OwnerInfoLabel.ToUpper();
            else
                btnOwnerInfo.Text = Resources.OwnerInfoLabel.ToUpper().Remove(Resources.OwnerInfoLabel.Length - 4, 4) + ".";

            lblInsuredName.Text = Resources.InsuredName.ToUpper() + ":";
            btnPlanPolicy.Text = Resources.PlanPolicyLabel.ToUpper();
            btnBeneficiaries.Text = Resources.BeneficiariesLabel.ToUpper();
            btnQuestionaries.Text = Resources.Questionaries.ToUpper();
            btnPayment.Text = Resources.PaymentsLabel.ToUpper();
            btnSave.Text = Resources.Save.ToUpper();
            btnAddFollowUpComment.Text = Resources.AddFollowUpComment;
            btnBackToCompare.Text = Resources.BacktoDataReview;
            btnCompliance.Text = Resources.btnComplianceText.ToUpper(); //Bm 19-04-2017
            Document.InnerHtml = Resources.Document;
            AllDocuments.InnerHtml = Resources.AllDocuments;
            Reviewed.InnerHtml = Resources.REVIEWED.Capitalize();
            ltCompareDataFor.Text = Resources.COMPAREDATAFOR + ":";
            ltViewing.Text = Resources.VIEWING + ":";
            ltOfficeLabel.Text = Resources.Office.ToUpper() + ":";
            ltAgentNameLabel.Text = Resources.AgentNameLabel.ToUpper() + ":";
            ltDocumentView.Text = Resources.DocumentView.ToUpper();

            AgentLegalisSameAsInsured.InnerHtml = Resources.AgentLegalsameInsuredLabel;

            litHeaderCumplimiento.Text = Resources.ComplianceGridHeaderLabel;

            if (isChangingLang)
            {
                if (!IsRefreshPage())
                {
                    var key = Session["SelectedDoc"] != null ? Session["SelectedDoc"].ToString() : String.Empty;
                    if (!key.SIsNullOrEmpty())
                    {
                        var ValueBefeoreTranslate = ddlDocument.Items.FindByText(key).Value;

                        FillDrop(getDocumentByTab(ObjServices.TabSelected.ToInt()));
                        //Seleccionar documento
                        ddlDocument.SelectIndexByValueJSON(ValueBefeoreTranslate);
                        ddlDocument_SelectedIndexChanged(ddlDocument, null);
                    }
                }

                FillData();

            }
        }

        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }

        protected void Page_Load(object sender, EventArgs e)
        {
            pdfViewer.LicenseKey = System.Configuration.ConfigurationManager.AppSettings["PDFViewer"].ToString();
            pdfViewerPopup.LicenseKey = pdfViewer.LicenseKey;
            WUCCompareEdit.ManageTabs += ManageTabs;
            WUCCompareEdit.FillDocByTab += FillDrop;
            getDocumentByTab += WUCCompareEdit.getDocumentByTab;
            WUCPopMergeCases.FillDataReview += FillData;
            UCNotesComments.FillDataReview += FillData;

            if (!IsPostBack)
                Initialize();

            if (hdnShowPopViewPDF.Value == "true")
                viewPdf_Click(btnviewPdf, null);

            if (hdnShowCompareEdit.Value == "true")
                mpeCompareEdit.Show();
            else
                mpeCompareEdit.Hide();

        }

        public bool iscrossingTabs
        {
            get
            {

                return bool.Parse(!ViewState["iscrossingTabs"].isNullReferenceObject() ? ViewState["iscrossingTabs"].ToString() : "false");
            }
            set { ViewState["iscrossingTabs"] = value; }
        }

        public int RowIndex
        {
            get
            {
                return int.Parse(ViewState["RowSelect"].ToString());
            }
            set
            {
                ViewState["RowSelect"] = value;
            }
        }

        public void setActiveView(int index)
        {
            mtvDataReview.ActiveViewIndex = index;
        }

        private void SaveTab(String TabActual, out bool result)
        {
            result = true;

            //UPDATE AGENT       
            if (ObjServices.Agent_Id > 0)
            {
                ObjServices.oPolicyManager.ChangePolicyChain(new Entity.UnderWriting.Entities.Policy.Parameter()
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No,
                    AgentId = ObjServices.Agent_Id,
                    UserId = ObjServices.UserID.Value
                });
            }

            switch (TabActual)
            {
                case "btnClientInfo":
                case "btnOwnerInfo":
                    if (TabActual == "btnOwnerInfo")
                    {  //Si es un Owner
                        var oOwner = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Owner);
                        ObjServices.isCompanyOwner = (oOwner != null && oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt());
                        ObjServices.isOwnerContact = true;

                        if (ObjServices.isCompanyOwner)
                        {   //Es una compañia
                            WUCPersonalInformation.save();
                            WUCCompanyInfo.save();
                            //WUCAddress1.save();
                            //WUCEmailAddress1.Operation = Utility.OperationType.InsertAll;
                            //WUCEmailAddress1.save();
                            //WUCPhoneNumber1.Operation = Utility.OperationType.InsertAll;
                            //WUCPhoneNumber1.save();
                            WUCPersonalInformationRepLegal.save();
                            WUCIdentificationLegal.Operation = Utility.OperationType.InsertAll;
                            WUCIdentificationLegal.save();
                            WUCEmailAddressLegal.Operation = Utility.OperationType.InsertAll;
                            WUCEmailAddressLegal.save();
                            WUCBackgroundInformationLegal.save();
                            WUCPhoneNumberRepLegal.Operation = Utility.OperationType.InsertAll;
                            WUCPhoneNumberRepLegal.save();
                            WUCAddressLegal.save();

                        }
                        else
                        {
                            //No es una compañia
                            if (ObjServices.Contact_Id != ObjServices.Owner_Id)
                            {
                                WUCPersonalInformation.save();
                                WUCAddress.save();
                                WUCBackgroundInformation.save();
                                WUCPhoneNumber.Operation = Utility.OperationType.InsertAll;
                                WUCPhoneNumber.save();
                                WUCEmailAddress.Operation = Utility.OperationType.InsertAll;
                                WUCEmailAddress.save();
                                WUCIdentification.Operation = Utility.OperationType.InsertAll;
                                WUCIdentification.save();
                            }
                            else
                            {
                                ObjServices.isOwnerContact = false;
                                //Si es un client
                                WUCPersonalInformation.save();
                                WUCAddress.save();
                                WUCBackgroundInformation.save();
                                WUCPhoneNumber.Operation = Utility.OperationType.InsertAll;
                                WUCPhoneNumber.save();
                                WUCEmailAddress.Operation = Utility.OperationType.InsertAll;
                                WUCEmailAddress.save();
                                WUCIdentification.Operation = Utility.OperationType.InsertAll;
                                WUCIdentification.save();
                            }
                        }
                    }
                    else
                    {
                        ObjServices.isOwnerContact = false;
                        //Si es un client
                        WUCPersonalInformation.save();
                        WUCAddress.save();
                        WUCBackgroundInformation.save();
                        WUCPhoneNumber.Operation = Utility.OperationType.InsertAll;
                        WUCPhoneNumber.save();
                        WUCEmailAddress.Operation = Utility.OperationType.InsertAll;
                        WUCEmailAddress.save();
                        WUCIdentification.Operation = Utility.OperationType.InsertAll;
                        WUCIdentification.save();
                    }

                    break;
                case "btnPlanPolicy":
                    PlanPolicyContainer.save();
                    break;
                case "btnQuestionaries":
                    HealthDeclarationContainer.save();
                    result = Session["isValidQuestionaries"].ToBoolean();
                    if (!result)
                    {
                        this.ExcecuteJScript(" CustomDialogMessageEx(null, null, null, true, $('#hdnLang').val() == 'en' ? 'Warning' : 'Advertencia', 'QuestionariesValidationMessage');");
                        return;
                    }
                    break;
                case "btnBeneficiaries":
                    if (!BeneficiariesContainer.saveBeneficiaries())
                    {
                        result = false;

                        if (!result)
                        {
                            var Msj = ObjServices.esFunerario()
                                    ? Resources.BeneficiariesFunerarioValidation
                                    : Resources.BeneficiariesLifeValidation;

                            this.MessageBox(Msj);
                        }

                        return;
                    }

                    BeneficiariesContainer.save();
                    break;
                case "btnRequirements":

                    break;
                case "btnPayment":

                    break;
            }

        }

        protected void ManageTabs(object sender, EventArgs e)
        {
            (this.Page as BasePage).setIsFuneral();
            var bodyContent = this.Page.Master.FindControl("bodyContent");
            var udpAddNewClient = (UpdatePanel)bodyContent.FindControl("udpAddNewClient");
            var containerMessage = (HiddenField)bodyContent.FindControl("containerMessage");
            containerMessage.Value = "#dvScroll";
            udpAddNewClient.Update();

            iscrossingTabs = (e != null);

            var TabActual = hdnCurrentTab.Value;
            var ButtonSender = ((Button)sender);
            var Tab = ButtonSender.ID;
            var CurrentTabSessionName = Tab.Replace("btn", "");

            if (Tab != TabActual)
            {
                bool vresult = false;
                SaveTab(TabActual, out vresult);
                if (!vresult)
                    return;
            }

            hdnCurrentTab.Value = Tab;

            switch (Tab)
            {
                case "btnClientInfo":
                case "btnOwnerInfo":
                    ObjServices.ContactEntityID = (Tab == "btnClientInfo") ?
                         ObjServices.Contact_Id : ObjServices.Owner_Id;

                    var oOwner = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Owner);
                    ObjServices.isCompanyOwner = (oOwner != null && oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt());

                    hdnIsCompanyOwner.Value = ObjServices.isCompanyOwner.ToString().ToLower();

                    var pnOwerIsSameInsured = (Panel)WUCPersonalInformation.FindControl("pnOwerIsSameInsured");
                    pnOwerIsSameInsured.Visible = false;

                    if (Tab == "btnClientInfo")
                    {
                        ObjServices.isOwnerContact = false;
                        dvClientOrOwnerInfo.Visible = true;
                        dvCompany.Visible = false;
                        WUCPersonalInformation.Initialize();
                        WUCBackgroundInformation.Initialize(CurrentTabSessionName);
                        WUCIdentification.Initialize(CurrentTabSessionName);
                        WUCAddress.Initialize(CurrentTabSessionName);
                        WUCEmailAddress.Initialize(CurrentTabSessionName);
                        WUCPhoneNumber.Initialize(CurrentTabSessionName);
                    }
                    else //El tab es Owner Info
                    {
                        //Es una compañia
                        if (ObjServices.isCompanyOwner)
                        {
                            ObjServices.isOwnerContact = false;
                            dvCompany.Visible = true;
                            dvClientOrOwnerInfo.Visible = false;
                            //WUCCompanyInfo.Initialize(CurrentTabSessionName);
                            //WUCAddress1.Initialize(CurrentTabSessionName);
                            //WUCEmailAddress1.Initialize(CurrentTabSessionName);
                            //WUCPhoneNumber1.Initialize(CurrentTabSessionName);

                            WUCCompanyInfo.Initialize(currentTab);
                            //WUCAddress1.Initialize(currentTab);
                            //WUCEmailAddress1.Initialize(currentTab);
                            //WUCPhoneNumber1.Initialize(currentTab);

                            //representante legal
                            WUCPersonalInformationRepLegal.Initialize(currentTab);
                            WUCIdentificationLegal.Initialize(currentTab);
                            WUCEmailAddressLegal.Initialize(currentTab);
                            WUCBackgroundInformationLegal.Initialize(currentTab);
                            WUCPhoneNumberRepLegal.Initialize(CurrentTabSessionName);
                            WUCAddressLegal.Initialize(CurrentTabSessionName);

                            var LegalContact = ObjServices.GetContact(ObjServices.Agent_Legal.Value);
                            var InsuredContact = ObjServices.GetContact(ObjServices.Contact_Id.Value);

                            if (LegalContact.FullName == InsuredContact.FullName)
                            {
                                chkAgentLegalIsSameAsInsured.Checked = true;
                                OnOffControls(false);
                            }
                            else
                            {
                                OnOffControls(true);
                            } 
                        }
                        else
                        {   //Es una persona
                            if (ObjServices.IsDataReviewMode && currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id)
                                pnOwerIsSameInsured.Visible = true;
                            ObjServices.isOwnerContact = true;
                            dvClientOrOwnerInfo.Visible = true;
                            dvCompany.Visible = false;
                            WUCPersonalInformation.Initialize();
                            WUCBackgroundInformation.Initialize(CurrentTabSessionName);
                            WUCIdentification.Initialize(CurrentTabSessionName);
                            WUCAddress.Initialize(CurrentTabSessionName);
                            WUCEmailAddress.Initialize(CurrentTabSessionName);
                            WUCPhoneNumber.Initialize(CurrentTabSessionName);
                        }
                    }

                    vTabs.SetActiveView(vClientOrOwnerInfo);

                    break;
                case "btnPlanPolicy":
                    ObjServices.ContactEntityID = -1;

                    ObjServices.ContactEntityID = (ObjServices.DesignatedPensionerContactId > 0) ?
                                                   ObjServices.DesignatedPensionerContactId :
                                                   ObjServices.InsuredAddContactId;

                    PlanPolicyContainer.Initialize();
                    vTabs.SetActiveView(vPlanPolicy);
                    break;
                case "btnBeneficiaries":
                    BeneficiariesContainer.Initialize();
                    vTabs.SetActiveView(vBeneficiaries);
                    break;
                case "btnQuestionaries":
                    HealthDeclarationContainer.FillDrop();
                    vTabs.SetActiveView(vQuestionaries);
                    break;
                case "btnRequirements":
                    RequirementsContainer.Initialize();
                    vTabs.SetActiveView(vRequirements);
                    break;
                case "btnPayment":
                    PaymentContainer.Initialize();
                    vTabs.SetActiveView(vPayment);
                    break;
                case "btnCompliance":
                    WUCompliance.Initialize();
                    WUCompliance.ValidateComplianceContacs();
                    vTabs.SetActiveView(VCompliance);
                    break;
            }

            ltPolicy.Text = ObjServices.Policy_Id;
            lblInsured.Text = ObjServices.InsuredFullName;
            ltOffice.Text = ObjServices.Office;
            CurrentTab.Text = ButtonSender.Text;

            string key = null;

            if (!iscrossingTabs && Session["SelectedDoc"] != null)
                key = Session["SelectedDoc"].ToString();
            else
                Session["SelectedDoc"] = null;

            var TabId = int.Parse(ButtonSender.CommandArgument);

            ObjServices.TabSelected = (Utility.Tab)Utility.getEnumTypeFromValue(typeof(Utility.Tab), TabId);

            FillDrop(getDocumentByTab(int.Parse(ButtonSender.CommandArgument)), key);

            var CurrentDatePickerShow = this.Page.Master.FindControl("CurrentDatePickerShow");

            if (CurrentDatePickerShow != null)
                (CurrentDatePickerShow as HiddenField).Value = "";

            var isVisible = (ObjServices.KeyNameProduct != "Elite" && ObjServices.KeyNameProduct != "Select");
            pnButtonBeneficiaries.Visible = isVisible;
        }

        protected void SetVariables(int RowIndex, DevExpress.Web.ASPxGridView Grid)
        {
            ObjServices.Corp_Id = int.Parse(Grid.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());
            ObjServices.Region_Id = int.Parse(Grid.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
            ObjServices.Country_Id = int.Parse(Grid.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
            ObjServices.Domesticreg_Id = int.Parse(Grid.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
            ObjServices.State_Prov_Id = int.Parse(Grid.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
            ObjServices.City_Id = int.Parse(Grid.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
            ObjServices.Office_Id = int.Parse(Grid.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
            ObjServices.Case_Seq_No = int.Parse(Grid.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
            ObjServices.Hist_Seq_No = int.Parse(Grid.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
            ObjServices.Policy_Id = Grid.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            ObjServices.Agent_Id = int.Parse(Grid.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
            ObjServices.Contact_Id = int.Parse(Grid.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
            ObjServices.Owner_Id = int.Parse(Grid.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
            ObjServices.PaymentId = int.Parse(Grid.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            ObjServices.DesignatedPensionerContactId = int.Parse(Grid.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());
            ObjServices.StudentContactId = int.Parse(Grid.GetKeyFromAspxGridView("StudentContactId", RowIndex).ToString());
            ObjServices.InsuredAddContactId = int.Parse(Grid.GetKeyFromAspxGridView("AddInsuredContactId", RowIndex).ToString());
            ObjServices.Relationship_With_Insured_Id = int.Parse(Grid.GetKeyFromAspxGridView("RelationshiptoAgent", RowIndex).ToString());
            ObjServices.Relationship_With_Owner_ToAgentId = int.Parse(Grid.GetKeyFromAspxGridView("RelationshiptoOwner", RowIndex).ToString());
            ObjServices.Agent_Legal = int.Parse(Grid.GetKeyFromAspxGridView("AgentLegalContactId", RowIndex).ToString());
        }

        public void FillDrop(List<Utility.DocumentItem> items, string keySelected = null)
        {
            //Llenar el dropdown de los angentes
            ObjServices.GettingAllDrops(ref ddlAgent,
                           Utility.DropDownType.Agent,
                           "AgentName",
                           "AgentId",
                           corpId: ObjServices.Corp_Id,
                           regionId: ObjServices.Region_Id,
                           countryId: ObjServices.Country_Id,
                           domesticregId: ObjServices.Domesticreg_Id,
                           stateProvId: ObjServices.State_Prov_Id,
                           cityId: ObjServices.City_Id,
                           officeId: ObjServices.Office_Id
                          );


            var Office = ObjServices.GetCurrentOfficeWithoutAgent();
            var Agent = ObjServices.GetCurrentOffice();
            var jsonOffice = Utility.serializeToJSON(Office);
            var jsonOfficeAgent = Utility.serializeToJSON(Agent);
            ddlAgent.SelectIndexByValueJSON(jsonOfficeAgent);


            if (items != null && items.Any())
            {
                ddlDocument.DataSource = items;
                ddlDocument.DataTextField = "DocumentDesc";
                ddlDocument.DataValueField = "key";
                ddlDocument.DataBind();
                ddlDocument.Items.Insert(0, new ListItem { Text = "-----", Value = "-1" });

                if (iscrossingTabs)
                    ddlDocument.SelectedIndex = 1;
                else
                {
                    //Seleccionar el documento
                    if (keySelected != null && keySelected != "-1")
                        ddlDocument.SelectIndexByValue(ddlDocument.Items.FindByText(keySelected).Value);
                }

                ddlDocument_SelectedIndexChanged(ddlDocument, null);

                var AllDocs = WUCCompareEdit.getAllDocument();
                ddlAllDocuments.DataSource = AllDocs;
                ddlAllDocuments.DataValueField = "key";
                ddlAllDocuments.DataTextField = "DocumentDesc";
                ddlAllDocuments.DataBind();
                ddlAllDocuments.Items.Insert(0, new ListItem { Text = "-----", Value = "-1" });
                ddlAllDocuments.SelectedIndex = 0;
            }
            else
            {
                ddlDocument.Items.Clear();
            }
        }

        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjServices.oDataReviewManager.GetAll(new Entity.UnderWriting.Entities.Parameter.Case
            {
                CompanyId = ObjServices.CompanyId,
                UserId = ObjServices.UserID.Value,
                LanguageId = ObjServices.Language.ToInt()
            });

            e.KeyExpression = @"isComplianceOK;
                                AgentLegalContactId,CorpId;
                                RegionId;
                                CountryId;
                                DomesticregId;
                                StateProvId;
                                CityId; 
                                OfficeId;
                                CaseSeqNo; 
                                HistSeqNo; 
                                PaymentId;
                                InsuredContactId;
                                AgentId; 
                                CompanyDesc;
                                PolicyNo;
                                ProductDesc; 
                                UserName;
                                InsuredFullName;
                                OwnerFullName;
                                CountryDesc;
                                OfficeDesc;
                                AddInsuredContactId;
                                DesignatedPensionerContactId; 
                                AgentFullName; 
                                Exception; 
                                SubmitDate;
                                DaysPending; 
                                IsReview; 
                                StudentContactId; 
                                RelationshiptoAgent; 
                                RelationshiptoOwner";

            e.QueryableSource = data.AsQueryable();
        }

        public void FillData()
        {
            gvDataReview.DataBind();
            gvDataReview.SetFilterSettings();
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        public void ClearData()
        {
            RowIndex = -1;
        }

        protected void gvDataReview_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            RowIndex = e.VisibleIndex;

            SetVariables(RowIndex, sender as DevExpress.Web.ASPxGridView);

            var PolicyNumber = gvDataReview.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
            var UserName = ObjServices.UserName;
            var InsuredName = gvDataReview.GetKeyFromAspxGridView("InsuredFullName", RowIndex).ToString();
            var PlanName = gvDataReview.GetKeyFromAspxGridView("ProductDesc", RowIndex).ToString();
            var Office = gvDataReview.GetKeyFromAspxGridView("OfficeDesc", RowIndex).ToString();
            var AgentName = gvDataReview.GetKeyFromAspxGridView("AgentFullName", RowIndex).ToString();

            ObjServices.Office = Office;
            ObjServices.AgentName = AgentName;
            ObjServices.InsuredFullName = InsuredName;

            switch (Commando)
            {
                case "merge":
                    WUCPopMergeCases.Initialize();
                    mpeMergeCases.Show();
                    hdnShowMergeCases.Value = "true";
                    break;
                case "compare":
                    WUCCompareEdit.Initialize(InsuredName);
                    hdnShowCompareEdit.Value = "true";
                    mpeCompareEdit.Show();
                    break;
                case "addnote":
                    WUCAddNewNotePopup.Initialize(PolicyNumber,
                                                  UserName,
                                                  InsuredName,
                                                  PlanName);
                    hdnShowAddNewNote.Value = "true";
                    break;
                case "Comment":
                    hdnShowPopComment.Value = "true";
                    UCNotesComments.FillData();
                    break;
                case "reject":
                    WUCPopRejectToReadyReview.Initialize(PolicyNumber,
                                                         UserName,
                                                         InsuredName,
                                                         PlanName
                                                         );
                    hdnShowPopReject.Value = "true";
                    break;
            }

        }

        protected void btnBackToCompare_Click(object sender, EventArgs e)
        {
            ((WEB.NewBusiness.DReview.Pages.DReview)this.Page).setView();
        }

        public void LoadPDF(DropDownList sender)
        {
            if (sender.SelectedValue != "-1")
            {
                var key = sender.SelectedValue;

                var oKey = Serializer.Deserialize<DataReview.DocumentToReview>(key);

                if (!oKey.isNullReferenceObject())
                {
                    var DocumentId = oKey.DocumentId;
                    var DocumentCategporyID = oKey.DocCategoryId;
                    var DocumentTypeID = oKey.DocTypeId;
                    var IsReview = oKey.IsReviewed;
                    var ContactId = oKey.ContactId;
                                          
                    if (sender == ddlDocument)
                    {
                        ddlAllDocuments.SelectIndexByValue("-1");
                        chkIsReview.Enabled = true;
                        //Marcar si esta Review
                        chkIsReview.Checked = IsReview;
                    }
                    else
                    {
                        chkIsReview.Enabled = false;
                        chkIsReview.Checked = false;
                        ddlDocument.SelectIndexByValue("-1");
                    }

                    string documentType = "D";

                    Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                    {
                        Contact_ID = ContactId
                    };

                    byte[] pdfOnBase = ObjServices.ViewFileFromOnBase(add, documentType, DocumentCategporyID, DocumentTypeID);
                          
                    if (pdfOnBase == null)
                    {
                        var PDfArrayByte = ObjServices.oDataReviewManager.GetDocument(new DataReview.DocumentInfomation()
                        {
                            CorpId = ObjServices.Corp_Id,
                            RegionId = ObjServices.Region_Id,
                            CountryId = ObjServices.Country_Id,
                            DomesticRegId = ObjServices.Domesticreg_Id,
                            StateProvId = ObjServices.State_Prov_Id,
                            CityId = ObjServices.City_Id,
                            OfficeId = ObjServices.Office_Id,
                            CaseSeqNo = ObjServices.Case_Seq_No,
                            HistSeqNo = ObjServices.Hist_Seq_No,
                            DocumentCategoryId = DocumentCategporyID,
                            DocumentTypeId = DocumentTypeID,
                            DocumentId = DocumentId
                        }).DocumentBinary;
                                                                  
                        //Cargar el documento
                        pdfViewer.PdfSourceBytes = PDfArrayByte;
                        pdfViewer.DataBind();
                    }
                    else
                    {
                        //Cargar el documento
                        pdfViewer.PdfSourceBytes = pdfOnBase;
                        pdfViewer.DataBind();
                    }    
                }
            }
            else
            {
                pdfViewer.PdfSourceBytes = null;
                pdfViewer.DataBind();
            }
        }

        protected void ddlDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = sender as DropDownList;
            chkIsReview.Enabled = drop.SelectedValue != "-1";
            chkIsReview.Checked = false;
            Session["SelectedDoc"] = drop.SelectedItem.Text;
            LoadPDF(drop);
            if (hdnShowPopViewPDF.Value == "true")
                viewPdf_Click(btnviewPdf, null);
            
        }

        protected void ddlAllDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPDF(sender as DropDownList);
        }

        protected void chkIsReview_CheckedChanged(object sender, EventArgs e)
        {
            var key = ddlDocument.SelectedValue;

            var oKey = Serializer.Deserialize<DataReview.DocumentToReview>(key);

            if (!oKey.isNullReferenceObject())
            {
                var DocumentId = oKey.DocumentId;
                var DocumentCategporyID = oKey.DocCategoryId;
                var DocumentTypeID = oKey.DocTypeId;
                var IsReview = oKey.IsReviewed;
                var PaymentDetId = oKey.PaymentDetId;
                var ProjectId = oKey.ProjectId;
                var TabId = oKey.TabId;
                var Functionalityid = oKey.FunctionalityId;
                var FunctionalitySeqNo = oKey.FunctionalitySeqNo;

                ObjServices.oDataReviewManager.SetDocumentReview(new DataReview.DocumentToReview()
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No,
                    DocCategoryId = DocumentCategporyID,
                    DocTypeId = DocumentTypeID,
                    DocumentId = DocumentId,
                    IsReviewed = chkIsReview.Checked,
                    UserId = ObjServices.UserID.Value,
                    ProjectId = ProjectId,
                    TabId = TabId,
                    FunctionalityId = Functionalityid,
                    FunctionalitySeqNo = FunctionalitySeqNo,
                    PaymentDetId = PaymentDetId
                });

                iscrossingTabs = false;

                var KeySelected = ddlDocument.SelectedItem.Text;

                Session["SelectedDoc"] = KeySelected;

                var TAbId = Utility.getvalueFromEnumType(Enum.GetName(typeof(Utility.Tab), ObjServices.TabSelected), typeof(Utility.Tab));

                FillDrop(getDocumentByTab(int.Parse(TAbId.ToString())), KeySelected);
            }
        }

        private ValidationRNC ValidationRNCValid(string IDRNC)
        {
            var ExistsItem = new ValidationRNC { ValidRNC = false, InvalidRNC = false };

            var y = ObjServices.oContactManager.GetResultRNC(IDRNC);

            if (y.RNC == 0)
            {
                ExistsItem.InvalidRNC = true;
                ExistsItem.ValidRNC = false;
                return ExistsItem;
            }
            else if (y.RNC == 1)
            {
                ExistsItem.InvalidRNC = false;
                ExistsItem.ValidRNC = true;
                return ExistsItem;
            }
            return ExistsItem;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Control WUCCompanyInfo = null;
            var Container = (!ObjServices.IsDataReviewMode) ? "ContactsInfoContainer" : "DReviewContainer";
            WUCCompanyInfo = this.Page.Master.FindControl("bodyContent").FindControl(Container).FindControl("WUCCompanyInfo");
            var txtDocument = (WUCCompanyInfo.FindControl("txtCompanyRNC") as TextBox).Text.Replace("-", "");
            if ((txtDocument != ""))
            {
                var ValidationRNC = ValidationRNCValid(txtDocument);
                if (ValidationRNC.InvalidRNC)
                {
                    var Title = ObjServices.Language == Utility.Language.en ? "Invalid Document" : "Documento Invalido";
                    string message = "El RNC de la empresa no es valido";
                    this.ExcecuteJScript("CustomDialogMessageEx('" + message + "', 500, 150, true, '" + Title + "');");
                    return;
                }
            }

            bool result = false;
            var TabActual = hdnCurrentTab.Value;

            //Otengo los valores de la oficina
            if (ddlAgent.Items.Count > 0 && ddlAgent.SelectedValue != "-1")
                SetOffice(ddlAgent.SelectedValue);

            SaveTab(TabActual, out result);

            if (hdnShowPopViewPDF.Value == "true")
                viewPdf_Click(btnviewPdf, null);
            this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.DataInsertedSucessfully, Title: Resources.InformationLabel.ToUpper());
        }

        protected void btnAddFollowUpComment_Click(object sender, EventArgs e)
        {
            var Data = ObjServices.oDataReviewManager.GetDocumentsToReview(new Entity.UnderWriting.Entities.Policy.Parameter()
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                LanguageId = ObjServices.Language.ToInt()
            }).Select(y => new
            {
                DocumentDesc = y.NameDesc,
                key = "{\"ContactId\":\"" + (y.ContactId.HasValue ? y.ContactId : -1) +
                      "\",\"RequirementCatId\":\"" + (y.RequirementCatId.HasValue ? y.RequirementCatId : -1) +
                      "\",\"RequirementTypeId\":\"" + (y.RequirementTypeId.HasValue ? y.RequirementTypeId : -1) +
                      "\",\"RequirementId\":\"" + (y.RequirementId.HasValue ? y.RequirementId : -1) + "\"}"
            }).Distinct().ToList();

            WUCAddFollowUpComment.Initialize();
            WUCAddFollowUpComment.FillDrop(Data);
            hdnShowAddFollowUpComment.Value = "true";
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var LstRecordChecks = new List<DataReview>();

            for (int i = gvDataReview.VisibleStartIndex; i < gvDataReview.VisibleRowCount; i++)
            {
                var chk = gvDataReview.FindRowCellTemplateControl(i, null, "chkSelectedPolicy") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    var vCompanyDesc = gvDataReview.GetKeyFromAspxGridView("CompanyDesc", i) != null ? gvDataReview.GetKeyFromAspxGridView("CompanyDesc", i).ToString() : "";
                    var vPolicyNo = gvDataReview.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                    var vProductDesc = gvDataReview.GetKeyFromAspxGridView("ProductDesc", i) != null ? gvDataReview.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                    var vInsuredFullName = gvDataReview.GetKeyFromAspxGridView("InsuredFullName", i) != null ? gvDataReview.GetKeyFromAspxGridView("InsuredFullName", i).ToString() : "";
                    var vCountryDesc = gvDataReview.GetKeyFromAspxGridView("CountryDesc", i) != null ? gvDataReview.GetKeyFromAspxGridView("CountryDesc", i).ToString() : "";
                    var vOfficeDesc = gvDataReview.GetKeyFromAspxGridView("OfficeDesc", i) != null ? gvDataReview.GetKeyFromAspxGridView("OfficeDesc", i).ToString() : "";
                    var vAgentFullName = gvDataReview.GetKeyFromAspxGridView("AgentFullName", i) != null ? gvDataReview.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                    var vException = gvDataReview.GetKeyFromAspxGridView("Exception", i) != null ? gvDataReview.GetKeyFromAspxGridView("Exception", i).ToString() : "";
                    var vSubmitDate = gvDataReview.GetKeyFromAspxGridView("SubmitDate", i) != null ? DateTime.Parse(gvDataReview.GetKeyFromAspxGridView("SubmitDate", i).ToString()) : (DateTime?)null;
                    var vDaysPending = gvDataReview.GetKeyFromAspxGridView("DaysPending", i) != null ? int.Parse(gvDataReview.GetKeyFromAspxGridView("DaysPending", i).ToString()) : (int?)null;

                    LstRecordChecks.Add(new DataReview()
                    {
                        CompanyDesc = vCompanyDesc,
                        PolicyNo = vPolicyNo,
                        ProductDesc = vProductDesc,
                        InsuredFullName = vInsuredFullName,
                        CountryDesc = vCountryDesc,
                        OfficeDesc = vOfficeDesc,
                        AgentFullName = vAgentFullName,
                        Exception = vException,
                        SubmitDate = vSubmitDate,
                        DaysPending = vDaysPending
                    });
                }
            }

            gvFakeGridView.DataSource = LstRecordChecks;
            gvFakeGridView.DataBind();
            ASPxGridViewExporter1.WriteXlsxToResponse("DataReview");
        }

        protected void gvDataReview_PreRender(object sender, EventArgs e)
        {
            ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        protected void viewPdf_Click(object sender, EventArgs e)
        {
            pdfViewerPopup.PdfSourceBytes = pdfViewer.PdfSourceBytes;
            pdfViewerPopup.DataBind();
            hdnShowPopViewPDF.Value = "true";
            this.ExcecuteJScript("$('#PopPdfViewer').append($(CreateNewPopFrame()));");
            ModalPopupPdfViewer.Show();
        }

        protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAgent.Items.Count > 0 && ddlAgent.SelectedValue != "-1")
                SetOffice(ddlAgent.SelectedValue);
        }

        private Utility.itemOfficce SetOffice(string dataOfficeJson)
        {
            var dataOffice = Utility.deserializeJSON<Utility.itemOfficce>(dataOfficeJson);

            ObjServices.Corp_Id = dataOffice.CorpId;
            ObjServices.Region_Id = dataOffice.RegionId;
            ObjServices.Country_Id = dataOffice.CountryId;
            ObjServices.Domesticreg_Id = dataOffice.DomesticregId;
            ObjServices.State_Prov_Id = dataOffice.StateProvId;
            ObjServices.City_Id = dataOffice.CityId;
            ObjServices.Office_Id = dataOffice.OfficeId;
            ObjServices.Agent_Id = dataOffice.AgentId <= 0 ? ObjServices.Agent_Id : dataOffice.AgentId;
            return dataOffice;
        }

        protected void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            WUCompliance.ValidateComplianceContacs();
        }

        protected void chkAgentLegalIsSameAsInsured_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgentLegalIsSameAsInsured.Checked)
            {
                LoadDataFromInsured(true);
            }
            else
            {
                LoadDataFromInsured(false);
            }
        }

        public void LoadDataFromInsured(Boolean Loading = false)
        {
            if (Loading)
            {
                Entity.UnderWriting.Entities.Contact dataContact = null;

                int? ContactID = null;

                //Traer la misma data que esta en el ClientInfo                
                dataContact = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ObjServices.Contact_Id.Value, languageId: ObjServices.Language.ToInt());

                ContactID = dataContact.ContactId;

                WUCPersonalInformationRepLegal.LoadSameDataFromInsured(dataContact);
                WUCAddressLegal.LoadSameDataFromInsured(ContactID);
                WUCBackgroundInformationLegal.LoadSameDataFromInsured(ContactID);
                WUCPhoneNumberRepLegal.LoadSameDataFromInsured(ContactID);
                WUCEmailAddressLegal.LoadSameDataFromInsured(ContactID);
                WUCIdentificationLegal.LoadSameDataFromInsured(ContactID);

                OnOffControls(!chkAgentLegalIsSameAsInsured.Checked);
            }
            else
            {
                WUCPersonalInformationRepLegal.ClearData();
                WUCAddressLegal.ClearData();
                WUCBackgroundInformationLegal.ClearData();
                WUCPhoneNumberRepLegal.ClearData();
                WUCEmailAddressLegal.ClearData();
                WUCIdentificationLegal.ClearData();

                OnOffControls(!chkAgentLegalIsSameAsInsured.Checked);
            }
        }

        public void OnOffControls(bool state)
        {
            WUCPersonalInformationRepLegal.EnabledControls(state);
            WUCAddressLegal.EnabledControls(state);
            WUCBackgroundInformationLegal.EnabledControls(state);
            WUCPhoneNumberRepLegal.EnabledControls(state);
            WUCEmailAddressLegal.EnabledControls(state);
            WUCIdentificationLegal.EnabledControls(state);
        }
    }
}