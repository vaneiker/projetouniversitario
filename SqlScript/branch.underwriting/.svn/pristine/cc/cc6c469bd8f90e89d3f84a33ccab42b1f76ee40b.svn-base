using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.ConfirmationCall;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.Pages
{
    public partial class ConfirmationCall : BasePage
    {

        public Services _services = new Services();

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #region Methods

        public void FillData(int contactId, ContactType contactType = ContactType.Owner, bool status = false)
        {
            //FillDataContact(_objServices.Owner_Id);
            _services.RefreshData();
            _services.SessionData.PolicyInfo.CurrentContactId = contactId.ToInt();
            _services.SessionData.PolicyInfo.CurrentContactTypeId = contactType;

            if (contactType == ContactType.Insured)
            {
                _services.Current_Contact_Id = contactId;
                _services.Current_Contact_Type_Id = contactType;

            }

            if (contactType == ContactType.AdditionalInsured)
            {
                _services.Additional_Contact_Id = contactId;
                _services.Current_Contact_Type_Id = contactType;

            }

            lnkOwnerInformation.Enabled = true;
            //lnkOwnerInformation.ForeColor = System.Drawing.Color.HotPink;
            lnkInsuredInformation.Enabled = _services.Insured_Contact_Id.HasValue;
            lnkAdditionalInformation.Enabled = _services.Additional_Contact_Id.HasValue;


            liOwnerInformation.Attributes.Remove("class");
            //lnkOwnerInformation.Attributes.Remove("onclick");
            //href="javascript:__doPostBack('ctl00$bodyContent$lnkInsuredInformation','')"
            liInsuredInformation.Attributes.Remove("class");
            lnkInsuredInformation.Attributes.Remove("class");
            liAdditionalInformation.Attributes.Remove("class");


            switch (contactType)
            {
                case ContactType.Owner:
                    liOwnerInformation.Attributes.Add("class", "active");
                    break;
                case ContactType.Insured:
                    liInsuredInformation.Attributes.Add("class", "active");
                    break;
                case ContactType.AdditionalInsured:
                    liAdditionalInformation.Attributes.Add("class", "active");
                    break;
            }

            //check mark
            CheckMark();


            if ((contactId > 0) || (IsPostBack))
            {
                //LEFT TAB
                UCPolicyDetails.FillPolicyDetail();
                UCEmailAndPhones.FillEmails();
                UCEmailAndPhones.FillPhones();
                UCAddress.FillAddresses();
                UCGreetings.LlenaGreetings(status);

                //RIGHT TAB
                UCNotes.FillNotes();
                UCAttachment.FillAttachments();
                UCSecurityQuestions.FillSecurityQuestions();

            }
            if (!IsPostBack)
            {

                FillAction();
            }

            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "Country",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });

            try
            {
                var CountryInfo = lista.FirstOrDefault(o => o.CountryId == _services.Country_Id);
                string[] CalcCountryTimeZoneSplit = (CountryInfo.GlobalCountryDescTimeZone ?? "UTC-4:30").Replace("UTC", "").Split(':');
                decimal? CalcCountryTimeZone = CalcCountryTimeZoneSplit[0].ToInt() + (CalcCountryTimeZoneSplit[1].ToInt() != 0 ? (CalcCountryTimeZoneSplit[1].ToInt() / 60) : 0);
                decimal CountryTimeZone = (decimal)(CalcCountryTimeZone ?? (decimal)-4.5);
                hdnCurrentCountryTime.Value = CountryTimeZone.ToString();
                lblPolicyCountryName.Text = lista != null ? CountryInfo.GlobalCountryDesc : "";
            }
            catch (Exception ex)
            {

            }
        }

        public ContactType ContactTypeSelect
        {
            get
            {
                var data = Session["ConfirmationCall.ContactTypeSelect"];
                return data != null ? (ContactType)Session["ConfirmationCall.ContactTypeSelect"] : ContactType.None;
            }
            set
            {
                Session["ConfirmationCall.ContactTypeSelect"] = value;
            }
        }

        private float getInternetExplorerVersion()
        {
            // Returns the version of Internet Explorer or a -1
            // (indicating the use of another browser).
            float rv = -1;
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if (browser.Browser == "IE")
                rv = (float)(browser.MajorVersion + browser.MinorVersion);
            return rv;
        }
        //
        public void SaveNote()
        {
            int? NoteTypeId = 0;
            int? contactTypeId = 0;

            try
            {

                var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
                {
                    DropDownType = "ConfirmationCallAction",
                    CorpId = _services.Corp_Id,
                    CompanyId = UserDataProvider.CompanyId,
                    ProjectId = UserDataProvider.ProjectId,
                    LanguageId = UserDataProvider.LanguageId
                });

                NoteTypeId = lista.Where(x => x.ActionId.ToString() == drpAction.SelectedValue).First().NoteTypeId;


                if ((TxtReason.Text != "") && (TxtReason.Text.Length > 0))
                {
                    contactTypeId = _services.Current_Contact_Type_Id == WEB.ConfirmationCall.Common.ContactType.None ? null : (int?)_services.Current_Contact_Type_Id;
                    if (Session["noteId"].ToInt() == -1)
                    {
                        //Saving 
                        _services.oStepManager.InsertNote(new Entity.UnderWriting.Entities.Step.Note
                        {
                            //Key
                            CorpId = _services.Corp_Id,
                            RegionId = _services.Region_Id,
                            CountryId = _services.Country_Id,
                            DomesticregId = _services.Domesticreg_Id,
                            StateProvId = _services.State_Prov_Id,
                            CityId = _services.City_Id,
                            OfficeId = _services.Office_Id,
                            CaseSeqNo = _services.Case_Seq_No,
                            HistSeqNo = _services.Hist_Seq_No,
                            ContactId = _services.Current_Contact_Id,
                            ContactRoleTypeId = contactTypeId,
                            StepCaseNo = _services.Step_Case_No,
                            StepId = _services.Step_Id,
                            StepTypeId = _services.Step_Type_Id,
                            NoteTypeId = NoteTypeId,
                            NoteName = drpAction.SelectedItem.Text,
                            NoteDesc = TxtReason.Text,
                            OriginatedBy = UserDataProvider.UserId.ToInt(),
                            UserId = UserDataProvider.UserId.ToInt()
                        });


                        UCNotes.FillNotes();
                    }

                }

            }
            catch (Exception ex)
            {
                string parameter = "Corp_Id:" + _services.Corp_Id + ",RegionId:" + _services.Region_Id + ",CountryId:" + _services.Country_Id + ",DomesticregId:" + _services.Domesticreg_Id + ",StateProvId:" + _services.State_Prov_Id
                    + ",CityId:" + _services.City_Id + ",OfficeId:" + _services.Office_Id + ",CaseSeqNo:" + _services.Case_Seq_No + ",HistSeqNo:" + _services.Hist_Seq_No + ",ContactId:" + _services.Current_Contact_Id
                    + ", ContactRoleTypeId:" + contactTypeId + ",StepCaseNo:" + _services.Step_Case_No + ",StepId:" + _services.Step_Id + ",StepTypeId:" + _services.Step_Type_Id + ",NoteTypeId:" + NoteTypeId + ",NoteName:"
                    + drpAction.SelectedItem.Text + ",NoteDesc:" + TxtReason.Text + ",OriginatedBy:" + UserDataProvider.UserId.ToInt() + ",UserId:" + UserDataProvider.UserId.ToInt() + "";

                ConfirmationCallLog.Log("SaveNote", string.Format("Message {0}, Inner Exception {1}", ex.Message, ex.InnerException), parameter, UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());


            }

        }

        public string TypePlan
        {
            get
            {
                return hdnPlanType.Value;
            }
            set
            {
                hdnPlanType.Value = value;
            }
        }

        public int? InsuredContactId
        {
            get
            {
                return _services.Insured_Contact_Id.Value;
            }
        }

        #endregion

        #region Events

        #region LEFT_TAB
        protected void btnGreetings_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VGreetings);
            hfSelectTABLeft.Value = "btnGreetings";
            UCGreetings.LlenaGreetings();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndComments");
        }

        protected void btnEmailTelephones_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VEmailAndPhones);
            hfSelectTABLeft.Value = "btnEmailTelephones";
            UCEmailAndPhones.FillEmails();
            UCEmailAndPhones.FillPhones();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndComments2");
        }

        protected void btnAddress_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VAddress);
            hfSelectTABLeft.Value = "btnAddress";
            UCPolicyDetails.FillPolicyDetail();
            UCAddress.FillAddresses();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndComments");
        }

        protected void btnPolicyDetails_Click(object sender, EventArgs e)
        {
            MVLeft.SetActiveView(VPolicyDetails);
            hfSelectTABLeft.Value = "btnPolicyDetails";
            UCPolicyDetails.FillPolicyDetail();
            divDetailsAndComments.Attributes.Add("class", "fondo_blanco fix_height heightDetailsAndComments");
        }

        protected void btnNextLeft_Click(object sender, EventArgs e)
        {
            if (MVLeft.GetActiveView() == VGreetings)
            {
                //MVLeft.SetActiveView(VEmailAndPhones);
                //hfSelectTABLeft.Value = "btnEmailTelephones";
                btnEmailTelephones_Click(sender, e);
            }
            else
            {
                if (MVLeft.GetActiveView() == VEmailAndPhones)
                {
                    //MVLeft.SetActiveView(VAddress);
                    //hfSelectTABLeft.Value = "btnAddress";
                    btnAddress_Click(sender, e);
                }
                else
                {
                    if (MVLeft.GetActiveView() == VAddress)
                    {
                        //MVLeft.SetActiveView(VPolicyDetails);
                        //hfSelectTABLeft.Value = "btnPolicyDetails";
                        btnPolicyDetails_Click(sender, e);
                    }
                    else
                    {
                        if (MVLeft.GetActiveView() == VPolicyDetails)
                        {
                            //MVLeft.SetActiveView(VGreetings);
                            //hfSelectTABLeft.Value = "btnGreetings";
                            btnGreetings_Click(sender, e);
                        }
                    }
                }
            }
        }
        #endregion

        #region RIGHT_TAB
        protected void btnSecurityQuestions_Click(object sender, EventArgs e)
        {
            MVRigth.SetActiveView(VSecurityQuestions);
            hfSelectTABRight.Value = "btnSecurityQuestions";
            UCSecurityQuestions.FillSecurityQuestions();
        }

        protected void btnNotes_Click(object sender, EventArgs e)
        {
            MVRigth.SetActiveView(VNotes);
            hfSelectTABRight.Value = "btnNotes";
            UCNotes.FillNotes();
        }

        protected void btnAttachments_Click(object sender, EventArgs e)
        {
            MVRigth.SetActiveView(VAttachment);
            hfSelectTABRight.Value = "btnAttachments";
            UCAttachment.FillAttachments();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            HDFItbis.Value = Utility.GetItbis().ToString("#,0.00", NumberFormatInfo.InvariantInfo);
            if (String.IsNullOrEmpty(hdnCurrentCountryTime.Value))
            {
                decimal CountryTimeZone = (decimal)-4.5;
                hdnCurrentCountryTime.Value = CountryTimeZone.ToString();
            }
            if (!IsPostBack)
            {
                FillAction();
                double IE_Verzion = getInternetExplorerVersion();
                lnkOwnerInformation.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$lnkOwnerInformation','')" : "";
                lnkInsuredInformation.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$lnkInsuredInformation','')" : "";
                lnkAdditionalInformation.OnClientClick = (IE_Verzion > 0.0) ? "javascript:__doPostBack('ctl00$bodyContent$lnkAdditionalInformation','')" : "";

            }

        }
        //
        public void CheckMark()
        {

            var lstContact = _services.oPolicyManager.GetPolicyAction(new Policy.Parameter()
            {
                CorpId = _services.Corp_Id,
                RegionId = _services.Region_Id,
                CountryId = _services.Country_Id,
                DomesticregId = _services.Domesticreg_Id,
                StateProvId = _services.State_Prov_Id,
                CityId = _services.City_Id,
                OfficeId = _services.Office_Id,
                CaseSeqNo = _services.Case_Seq_No,
                HistSeqNo = _services.Hist_Seq_No
            });


            if (lstContact != null)
            {

                if (lstContact.Count() > 0)
                {

                    foreach (var cont in lstContact)
                    {
                        switch (cont.ContactRoleTypeId)
                        {
                            //owner
                            case 1:

                                switch (cont.ActionId)
                                {
                                    //Pending
                                    case 1:
                                        ownericon.Attributes.Add("class", "owner_icon");
                                        lnkOwnerInformation.CssClass = "orange-g";
                                        break;
                                    //Warning
                                    case 8:
                                        ownericon.Attributes.Add("class", "main_insured_icon");
                                        lnkOwnerInformation.CssClass = "blue-g";
                                        break;
                                    //Complete
                                    case 7:
                                    case 9:
                                        ownericon.Attributes.Add("class", "main_insured_icon");
                                        lnkOwnerInformation.CssClass = "blue-g";
                                        break;
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                        ownericon.Attributes.Add("class", "medical_icon_b");
                                        lnkOwnerInformation.CssClass = "green-g";
                                        break;
                                    default:
                                        ownericon.Attributes.Add("class", "owner_icon");
                                        lnkOwnerInformation.CssClass = "orange-g";
                                        break;

                                }

                                break;
                            //insuerd
                            case 2:

                                switch (cont.ActionId)
                                {
                                    //Pending 
                                    case 1:
                                        maininsuredicon.Attributes.Add("class", "owner_icon");
                                        lnkInsuredInformation.CssClass = "orange-g";
                                        break;
                                    //Warning
                                    case 8:
                                        maininsuredicon.Attributes.Add("class", "main_insured_icon");
                                        lnkInsuredInformation.CssClass = "blue-g";
                                        break;
                                    //Complete
                                    case 7:
                                    case 9:
                                        maininsuredicon.Attributes.Add("class", "main_insured_icon");
                                        lnkInsuredInformation.CssClass = "blue-g";
                                        break;
                                    //medical action
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                        maininsuredicon.Attributes.Add("class", "medical_icon_b");
                                        lnkInsuredInformation.CssClass = "green-g";
                                        break;
                                    default:
                                        maininsuredicon.Attributes.Add("class", "owner_icon");
                                        lnkOwnerInformation.CssClass = "orange-g";
                                        break;

                                }

                                break;
                            //addicional
                            case 3:

                                switch (cont.ActionId)
                                {
                                    //Pending
                                    case 1:
                                        addinsuredicon.Attributes.Add("class", "owner_icon");
                                        lnkAdditionalInformation.CssClass = "orange-g";
                                        break;
                                    //Warning
                                    case 8:
                                        addinsuredicon.Attributes.Add("class", "main_insured_icon");
                                        lnkAdditionalInformation.CssClass = "orange-g";
                                        break;
                                    //Complete
                                    case 7:
                                    case 9:
                                        addinsuredicon.Attributes.Add("class", "main_insured_icon");
                                        lnkAdditionalInformation.CssClass = "blue-g";
                                        break;
                                    //medical
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                        addinsuredicon.Attributes.Add("class", "medical_icon_b");
                                        lnkAdditionalInformation.CssClass = "green-g";
                                        break;
                                    default:
                                        addinsuredicon.Attributes.Add("class", "owner_icon");
                                        lnkAdditionalInformation.CssClass = "orange-g";
                                        break;

                                }

                                break;
                        }

                    }

                }
                else
                {
                    ownericon.Attributes.Add("class", "owner_icon");
                    lnkOwnerInformation.CssClass = "orange-g";
                    //
                    maininsuredicon.Attributes.Add("class", "owner_icon");
                    lnkInsuredInformation.CssClass = "orange-g";
                    //
                    addinsuredicon.Attributes.Add("class", "owner_icon");
                    lnkAdditionalInformation.CssClass = "orange-g";

                }

            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            btnGreetings.Text = Resources.Greetings.ToUpper();
            btnEmailTelephones.Text = Resources.EmailsAndTelephones.ToUpper();
            btnAddress.Text = Resources.Address.ToUpper();
            btnPolicyDetails.Text = Resources.PolicyDetails.ToUpper();

            btnSecurityQuestions.Text = Resources.SecurityQuestions.ToUpper();
            btnNotes.Text = Resources.Notes.ToUpper();
            btnAttachments.Text = Resources.Attachments.ToUpper();
            btnSubmit.Text = Resources.Submit.ToUpper();
            btnNextLeft.Text = Resources.Next.ToUpper();
            hfMensaje.Value = Resources.Areyousure;
            hfApplyStatus.Value = Resources.ApplyStatus;
            hfSendEmailClient.Value = Resources.SendEmailClient;


        }

        public void FillAction()
        {
            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "ConfirmationCallAction",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
            drpAction.DataSource = lista;
            drpAction.DataTextField = "ActionDesc";
            drpAction.DataValueField = "ActionID";
            drpAction.DataBind();

        }

        public void InsertAction()
        {
            try
            {
                //WEB.ConfirmationCall.Common.Services _services = new WEB.ConfirmationCall.Common.Services();
                _services.oConfirmationCallManager.InsertContactAction(_services.Corp_Id,
                                                                        _services.Region_Id,
                                                                        _services.Country_Id,
                                                                        _services.Domesticreg_Id,
                                                                        _services.State_Prov_Id,
                                                                        _services.City_Id,
                                                                        _services.Office_Id,
                                                                        _services.Case_Seq_No,
                                                                        _services.Hist_Seq_No,
                                                                        _services.Current_Contact_Id,
                                                                        _services.Current_Contact_Type_Id.ToInt(),
                                                                        int.Parse(drpAction.SelectedValue),
                                                                        1,
                                                                        _services.Step_Type_Id,
                                                                        _services.Step_Id,
                                                                        _services.Step_Case_No,
                                                                        UserDataProvider.UserId.ToInt());


                if (int.Parse(drpAction.SelectedValue) > 6)
                {
                    //Inserto el Estatus de la Poliza para que cambia el Tab de Warning
                    int result = _services.oStepManager.CloseStep(new Step
                    {
                        CorpId = _services.Corp_Id,
                        RegionId = _services.Region_Id,
                        CountryId = _services.Country_Id,
                        DomesticregId = _services.Domesticreg_Id,
                        StateProvId = _services.State_Prov_Id,
                        ContactId = _services.Current_Contact_Id,
                        ContactRoleTypeId = _services.Current_Contact_Type_Id.ToInt(),
                        CityId = _services.City_Id,
                        OfficeId = _services.Office_Id,
                        CaseSeqNo = _services.Case_Seq_No,
                        HistSeqNo = _services.Hist_Seq_No,
                        StepTypeId = _services.Step_Type_Id,
                        StepId = _services.Step_Id,
                        StepCaseNo = _services.Step_Case_No
                    });
                }

                //
                if (int.Parse(drpAction.SelectedValue) == 1)
                {
                    //Inserto el Estatus de la Poliza para que cambia el Tab de Warning
                    int result = _services.oStepManager.Insert(new Step.NewStep
                    {
                        CorpId = _services.Corp_Id,
                        RegionId = _services.Region_Id,
                        CountryId = _services.Country_Id,
                        DomesticregId = _services.Domesticreg_Id,
                        StateProvId = _services.State_Prov_Id,
                        CityId = _services.City_Id,
                        OfficeId = _services.Office_Id,
                        CaseSeqNo = _services.Case_Seq_No,
                        HistSeqNo = _services.Hist_Seq_No,
                        StepTypeId = _services.Step_Type_Id,
                        StepId = _services.Step_Id,
                        StepCaseNo = _services.Step_Case_No
                    });

                }

                //
                if ((int.Parse(drpAction.SelectedValue) > 1) && (int.Parse(drpAction.SelectedValue) != 8) && hfYesOrNo.Value == "Yes")
                {
                    string emailto = "";
                    string emailtoagent = "";
                    string templateFinalPath = Server.MapPath("~/Templates/templatemail.html");

                    var lstPoliciesData = _services.oPolicyManager.GetPlanData(_services.Corp_Id, _services.Region_Id, _services.Country_Id, _services.Domesticreg_Id,
                    _services.State_Prov_Id, _services.City_Id, _services.Office_Id, _services.Case_Seq_No, _services.Hist_Seq_No);


                    IEnumerable<Contact.Email> ContactEmails = null;

                    switch (ContactTypeSelect)
                    {
                        case ContactType.Owner:
                            {
                                ContactEmails = _services.oContactManager.GetCommunicatonEmail(_services.Corp_Id, _services.Owner_Id, UserDataProvider.LanguageId);
                                break;
                            }
                        case ContactType.Insured:
                            {
                                ContactEmails = _services.oContactManager.GetCommunicatonEmail(_services.Corp_Id, _services.Insured_Contact_Id.Value, UserDataProvider.LanguageId);
                                break;
                            }
                        case ContactType.AdditionalInsured:
                            {
                                ContactEmails = _services.oContactManager.GetCommunicatonEmail(_services.Corp_Id, _services.Additional_Contact_Id.Value, UserDataProvider.LanguageId);
                                break;
                            }
                        default:
                            {
                                ContactEmails = _services.oContactManager.GetCommunicatonEmail(_services.Corp_Id, _services.Owner_Id, UserDataProvider.LanguageId);
                                break;
                            }
                    }

                    foreach (Contact.Email Contact_Emails in ContactEmails.Where(e => e.IsPrimary == true))
                    {
                        emailto = emailto + " " + Contact_Emails.EmailAdress;
                    }
                    emailto = emailto.Trim().Replace(" ", ",");
                    emailto = emailto ?? ContactEmails.FirstOrDefault().EmailAdress;


                    if (lstPoliciesData.AgentId != null)
                    {

                        IEnumerable<Contact.Email> AgentEmails = _services.oContactManager.GetAgentCommunicationEmail(_services.Corp_Id, lstPoliciesData.AgentId.ToInt(), UserDataProvider.LanguageId);

                        if (AgentEmails != null)
                        {
                            //foreach (Contact.Email Agent_Emails in AgentEmails.Where(e => e.IsPrimary == true))
                            //{
                            foreach (Contact.Email Agent_Emails in AgentEmails)
                            {
                                emailtoagent = emailtoagent + " " + Agent_Emails.EmailAdress;
                            }


                            if (!string.IsNullOrEmpty(emailtoagent))
                            {

                                emailtoagent = emailtoagent.Trim().Replace(" ", ",");

                                if (emailtoagent.Length == 0)
                                {
                                    emailtoagent = ContactEmails.FirstOrDefault().EmailAdress;
                                }

                            }

                        }
                    }

                    Dictionary<string, string> TemplateReplaces = new Dictionary<string, string>();

                    switch (ContactTypeSelect)
                    {
                        case ContactType.Owner:
                            {
                                TemplateReplaces.Add("@Owner", lstPoliciesData.OwnerName);
                                break;
                            }
                        case ContactType.Insured:
                            {
                                if (!string.IsNullOrEmpty(lstPoliciesData.InsuredName))
                                {

                                    TemplateReplaces.Add("@Owner", lstPoliciesData.InsuredName);
                                }
                                else
                                {
                                    TemplateReplaces.Add("@Owner", lstPoliciesData.OwnerName);
                                }
                                break;
                            }
                        case ContactType.AdditionalInsured:
                            {
                                if (!string.IsNullOrEmpty(lstPoliciesData.AdditionalInsured))
                                {
                                    TemplateReplaces.Add("@Owner", lstPoliciesData.AdditionalInsured);
                                }
                                else
                                {
                                    TemplateReplaces.Add("@Owner", lstPoliciesData.OwnerName);
                                }
                                break;
                            }
                        default:
                            {
                                TemplateReplaces.Add("@Owner", lstPoliciesData.OwnerName);
                                break;
                            }
                    }


                    TemplateReplaces.Add("@Poliza", lstPoliciesData.PolicyNo);
                    TemplateReplaces.Add("@Plan", lstPoliciesData.PlanType + " / " + lstPoliciesData.PlanName);
                    TemplateReplaces.Add("@Agent", lstPoliciesData.AgentFullName);
                    TemplateReplaces.Add("@Link", "http://www.atlantica.do/wp-content/themes/pdf/Images/ConfirmationCall/Planilla%20Cambios%20Personales%20Atlantica.pdf");


                    switch (int.Parse(drpAction.SelectedValue))
                    {
                        case 2: //1st Failed to Communicate

                            if (emailto.Length > 0)
                            {
                                //desconmentar para produccion
                                SendConfirmationMail(emailto, "No hemos podido contactarle", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5010"), templateFinalPath, TemplateReplaces); //Cliente
                                //SendConfirmationMail("jencarnacion@statetrustlife.com", "No hemos podido contactarle", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5010"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "No hemos podido contactar a su cliente", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6010"), templateFinalPath, TemplateReplaces);
                            break;
                        case 3: //2nd Failed to Communicate
                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Segundo llamado fallido", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5011"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Segundo llamado fallido a su cliente", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6011"), templateFinalPath, TemplateReplaces);
                            break;
                        case 4: //3rd Failed to Communicate
                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Tercer llamado fallido", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5012"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Tercer llamado fallido a su cliente", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6012"), templateFinalPath, TemplateReplaces);

                            SendConfirmationMail("suscripcion-vida@atlantica.do", "Tercer llamado fallido a su cliente", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV8012"), templateFinalPath, TemplateReplaces);

                            break;
                        case 7: //Confirmation Call Finalized with changes

                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Llamada de confirmación y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5003"), templateFinalPath, TemplateReplaces); //Cliente
                                SendConfirmationMail(emailto, "Llamada de confirmación exitosa y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6003"), templateFinalPath, TemplateReplaces); //Dpto. de suscripción
                            }
                            SendConfirmationMail("suscripcion-vida@atlantica.do", "Llamada de confirmación exitosa y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV8003"), templateFinalPath, TemplateReplaces); //Agente
                            break;
                        case 9: //Confirmation Call Finalized

                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Hemos confirmado su información", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5000"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Llamada de confirmación exitosa", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6000"), templateFinalPath, TemplateReplaces); //Agente

                            break;

                        //Completed call -not transferred the dep. Medical
                        case 10:
                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Hemos confirmado su información", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5005"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Llamada de confirmación exitosa", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6005"), templateFinalPath, TemplateReplaces); //Agente

                            SendConfirmationMail("citasmedicas-vida@atlantica.do", "Llamada de confirmación exitosa", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV7005"), templateFinalPath, TemplateReplaces); //Dpto. Médico

                            break;
                        //Completed call -not transferred the dep. Medical with change
                        case 11:

                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Llamada de confirmación y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5007"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Llamada de confirmación exitosa y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6007"), templateFinalPath, TemplateReplaces); //Agente

                            SendConfirmationMail("citasmedicas-vida@atlantica.do", "Llamada de confirmación exitosa y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV7005"), templateFinalPath, TemplateReplaces); //Dpto. Médico

                            SendConfirmationMail("suscripcion-vida@atlantica.do", "Llamada de confirmación exitosa y solicitud de cambios", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV8003"), templateFinalPath, TemplateReplaces); //Dpto. Médico

                            break;
                        //Completed call -transferred the dep. Medical
                        case 12:

                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Hemos confirmado su información", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5005"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Llamada de confirmación exitosa", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6005"), templateFinalPath, TemplateReplaces); //Agente
                            break;
                        // Completed call -transferred the dep. Medical with change
                        case 13:
                            if (emailto.Length > 0)
                            {
                                SendConfirmationMail(emailto, "Hemos confirmado su información", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV5007"), templateFinalPath, TemplateReplaces); //Cliente
                            }
                            SendConfirmationMail(emailtoagent, "Llamada de confirmación exitosa", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV6007"), templateFinalPath, TemplateReplaces); //Agente

                            SendConfirmationMail("suscripcion-vida@atlantica.do", "Llamada de confirmación exitosa", Server.MapPath("~/Templates/ConfirmationCall/ATLSRV8003"), templateFinalPath, TemplateReplaces); //Dpto. Médico

                            //Llamada no transferida al Departamento Medico
                            break;

                    }

                }

                FillAction();
                UCHeader.FillConfirmationCall();

            }
            catch (Exception ex)
            {

                string parameter = "Corp_Id:" + _services.Corp_Id + ",Region_Id:" + _services.Region_Id + ",Country_Id:" + _services.Country_Id + ",Domesticreg_Id:" + _services.Domesticreg_Id + ",State_Prov_Id:"
                                   + _services.State_Prov_Id + ",City_Id:" + _services.City_Id + ",Office_Id:" + _services.Office_Id + ",Case_Seq_No:" + _services.Case_Seq_No + ",Hist_Seq_No:"
                                   + _services.Hist_Seq_No + ",Current_Contact_Id:" + _services.Current_Contact_Id + ",Current_Contact_Type_Id:" + _services.Current_Contact_Type_Id.ToInt()
                                   + ",ActionId:" + int.Parse(drpAction.SelectedValue) + ",ActionSqeNumber: 1,Step_Type_Id:" + _services.Step_Type_Id + ",Step_Id:" + _services.Step_Id
                                   + ",Step_Case_No:" + _services.Step_Case_No + ",UserId:" + UserDataProvider.UserId.ToInt() + "";

                ConfirmationCallLog.Log("InsertAction", string.Format("Message {0}, StackTrace {1}", ex.Message, ex.StackTrace), parameter,
                    UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());

            }

            hfYesOrNo.Value = "Yes";

            string msg = (hdnCurrentAction.Value == "" ? drpAction.SelectedItem.Text : hdnCurrentAction.Value);
            //
            Alertify.Alert(string.Format(RESOURCE.UnderWriting.ConfirmationCall.Resources.SubmittedSuccessfullyMsg, msg), this);
        }

        public void SendConfirmationMail(string emailto, string emailsubject, string templatePath, string templateFinalPath, Dictionary<string, string> TemplateReplaces)
        {
            string msg = System.IO.File.OpenText(templatePath + ".html").ReadToEnd();

            foreach (KeyValuePair<string, string> TReplace in TemplateReplaces)
            {
                msg = msg.Replace(TReplace.Key, TReplace.Value);
            }

            try
            {
                MailManager.SendMessage(to: emailto,
                                        Copia: "",
                                        BCC: "bienvenida-vida@atlantica.do,mortega@statetrustlife.com",
                                        Body: msg,
                                        Subject: emailsubject,
                                        From: System.Configuration.ConfigurationManager.AppSettings["EmailFrom"],
                                        Attachments: "",
                                        ishtml: true,
                                        templatePath: templatePath,
                                        templateFinalPath: templateFinalPath,
                                        paramOpcional: ""
                                        );

            }
            catch (Exception ex)
            {

                string parameter = "To:" + emailto + ",Copia: NO , BCC: bienvenida-vida@atlantica.do, Body:" + msg + ",Subject: " +
                    emailsubject + ",From:" + System.Configuration.ConfigurationManager.AppSettings["EmailFrom"] + ",Attachments: NO, templatePath: " +
                    templatePath + ",templateFinalPath:" + templateFinalPath + ",UserId:" + UserDataProvider.UserId.ToInt() + "";

                ConfirmationCallLog.Log("SendConfirmationMail", string.Format("Message {0}, StackTrace {1}", ex.Message, ex.StackTrace), parameter,
                    UserDataProvider.UserId.ToInt(), Request.ServerVariables["SERVER_NAME"].ToString());

            }

            return;
        }

        protected void lnkContactInformation_Click(object sender, EventArgs e)
        {
            var lnk = (LinkButton)sender;

            switch (lnk.Attributes["data-contacttype"])
            {
                case "1":
                    ContactTypeSelect = ContactType.Owner;
                    FillData(_services.Owner_Id, ContactType.Owner);

                    break;
                case "2":
                    ContactTypeSelect = ContactType.Insured;
                    FillData(_services.Insured_Contact_Id.Value, ContactType.Insured);
                    break;
                case "3":
                    ContactTypeSelect = ContactType.AdditionalInsured;
                    FillData(_services.Additional_Contact_Id.Value, ContactType.AdditionalInsured);
                    break;
            }
        }

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //TODO: estaba trabajando aqui
            InsertAction();
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            SaveNote();
            InsertAction();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            InsertAction();
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            InsertAction();
        }

        protected void drpAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdnCurrentAction.Value = drpAction.SelectedItem.Text;
        }




    }
}