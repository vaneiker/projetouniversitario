using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using System.Globalization;
using System.Web.UI.HtmlControls;
using Entity.UnderWriting.IllusData;

namespace WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy
{
    public partial class WUCDesignatedPensionerInformation : UC, IUC
    {
       // public void edit() { }

        protected void UpdatePanel_Unload(object sender, EventArgs e)
        {
            try
            {
                MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();
                methodInfo.Invoke(ScriptManager.GetCurrent(Page),
                    new object[] { sender as UpdatePanel });
            }
            catch (Exception ex)
            {
            }

        }

        public List<Entity.UnderWriting.Entities.Contact.IdDocument> TempDataId = new List<Entity.UnderWriting.Entities.Contact.IdDocument>();

        public List<Entity.UnderWriting.Entities.Contact.IdDocument> oTempDataId
        {
            get
            {
                return Session["TempDataAdditionalInsuredId"] == null ?
                    new List<Entity.UnderWriting.Entities.Contact.IdDocument>() :
                    Session["TempDataAdditionalInsuredId"] as List<Entity.UnderWriting.Entities.Contact.IdDocument>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact.IdDocument> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact.IdDocument>(Session["TempDataAdditionalInsuredId"] != null ?
                      ((List<Entity.UnderWriting.Entities.Contact.IdDocument>)Session["TempDataAdditionalInsuredId"]) :
                      new List<Entity.UnderWriting.Entities.Contact.IdDocument>());
                    tempList.AddRange(value);
                }

                Session["TempDataAdditionalInsuredId"] = tempList;
            }
        }

        public List<Entity.UnderWriting.Entities.Contact> TempDataAdditionalInsured = new List<Entity.UnderWriting.Entities.Contact>();

        public List<Entity.UnderWriting.Entities.Contact> oTempDataAdditionalInsured
        {
            get
            {
                return Session["TempDataAdditionalInsured"] == null ?
                    new List<Entity.UnderWriting.Entities.Contact>() :
                    Session["TempDataAdditionalInsured"] as List<Entity.UnderWriting.Entities.Contact>;
            }

            set
            {
                List<Entity.UnderWriting.Entities.Contact> tempList = null;

                if (value != null)
                {
                    tempList = new List<Entity.UnderWriting.Entities.Contact>(Session["TempDataAdditionalInsured"] != null ?
                      ((List<Entity.UnderWriting.Entities.Contact>)Session["TempDataAdditionalInsured"]) :
                      new List<Entity.UnderWriting.Entities.Contact>());
                    tempList.AddRange(value);
                }

                Session["TempDataAdditionalInsured"] = tempList;
            }
        }

        public int? RowIndex
        {
            get { return int.Parse(Session["RowIndexAdditonalInsured"].ToString()); }
            set { Session["RowIndexAdditonalInsured"] = value; }
        }

        public Utility.OperationType Operation
        {
            get { return ((Utility.OperationType)Session["OperationAdditonalInsured"]); }
            set
            {
                Session["OperationAdditonalInsured"] = value;
                var inserting = (value == Utility.OperationType.Insert);
                pnBtnSearchContact.Visible = inserting;
                gvAdditionalInsured.Columns[10].Visible = gvDependents.Columns[10].Visible = inserting;
                pngvAdditionalInsured.CssClass = pngvDependents.CssClass = inserting ? "grid_wrap margin_t_10 gris"
                                                                                   : "DisabledGrid grid_wrap margin_t_10 gris";
            }
        }

        public void ChangeView(int index = 0)
        {
            MPrincipal.ActiveViewIndex = index;
            hdnCurrentView.Value = MPrincipal.GetActiveView().ID;

            AvailableDependentsView(ObjServices.KeyNameProduct);

            udpDesignatedPensioner.Update();
        }

        /// <summary>
        /// Set or get ContactRoleTypeID  Designated Pensioner or Addicional Insured
        /// </summary>
        public Int32 ContactRoleTypeID
        {
            get { return int.Parse(hdnContactRoleTypeID.Value); }
            set
            {
                var Name = Enum.GetName(typeof(Utility.ContactRoleIDType), value);
                var vId = Utility.getvalueFromEnumType(Name, typeof(Utility.ContactRoleIDType));
                hdnContactRoleTypeID.Value = vId.ToString();
            }
        }

        #region Variables
        public int CaseSeqNo;
        public int CityId;
        public int ContactId;
        public int CorpId;
        public int CountryId;
        public int DomesticregId;
        public int HistSeqNo;
        public int OfficeId;
        public int RegionId;
        public int StateProvId;
        #endregion

        public void SetVariables()
        {
            this.CaseSeqNo = ObjServices.Case_Seq_No;
            this.CityId = ObjServices.City_Id;
            this.CorpId = ObjServices.Corp_Id;
            this.CountryId = ObjServices.Country_Id;
            this.DomesticregId = ObjServices.Domesticreg_Id;
            this.HistSeqNo = ObjServices.Hist_Seq_No;
            this.OfficeId = ObjServices.Office_Id;
            this.RegionId = ObjServices.Region_Id;
            this.StateProvId = ObjServices.State_Prov_Id;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            FirstName.InnerHtml = Resources.FirstNameLabel;
            FirstName2.InnerHtml = FirstName.InnerHtml;
            MiddleName.InnerHtml = Resources.MiddleNameLabel;
            MiddleName2.InnerHtml = MiddleName.InnerHtml;
            LastName.InnerHtml = Resources.LastNameLabel;
            LastName2.InnerHtml = LastName.InnerHtml;

            Relationship.InnerHtml = Resources.FamilyRelationship;

            SecondLastName.InnerHtml = Resources.SecondLastNameLabel;
            SecondLastName2.InnerHtml = SecondLastName.InnerHtml;
            Gender.InnerHtml = Resources.GenderLabel;
            Gender2.InnerHtml = Gender.InnerHtml;
            DateOfBirth.InnerHtml = Resources.DateofBirthLabel;

            if (ObjServices.IsDataReviewMode)
                DateOfBirth2.InnerHtml = Resources.DateofBirthLabel2;
            else
                DateOfBirth2.InnerHtml = DateOfBirth.InnerHtml;

            Age.InnerHtml = Resources.AgeLabel;
            Smoker.InnerHtml = Resources.SmokerLabel;
            MaritalStatus.InnerHtml = Resources.MaritalStatusLabel;
            MaritalStatus2.InnerHtml = Resources.MaritalStatusLabel;
            ltBackgroundInformation.Text = Resources.BackgorundInformationLabel;
            RealationshipWithInsured.InnerText = Resources.RelationshipWithInsured1;
            lblStudentStatus.InnerText = Resources.StudentStatus;

            lthomeaddress.Text = Resources.HomeAddressLabel;
            ltbusinessAddress.Text = Resources.BusinessAddressLabel;
            address.InnerHtml = Resources.AddresessLabel;
            address2.InnerHtml = address.InnerHtml;
            country.InnerHtml = Resources.CountryLabel;
            country2.InnerHtml = country.InnerHtml;
            StateProvince.InnerHtml = Resources.StateProvinceLabel;
            stateProvince2.InnerHtml = StateProvince.InnerHtml;
            city.InnerHtml = Resources.CityLabel;
            City2.InnerHtml = city.InnerHtml;
            postalcode.InnerHtml = Resources.PostalCodeLabel;
            postalcode2.InnerHtml = postalcode.InnerHtml;
            OccupationType.InnerHtml = Resources.OccupationTypeLabel;
            Occupation.InnerHtml = Resources.OccupationLabel;
            CompanyName.InnerHtml = Resources.CompanyNameLabel;
            LineOfBusiness1.InnerHtml = Resources.LineofBusinessLabel + " 1";
            LineOfBusiness2.InnerHtml = Resources.LineofBusinessLabel + " 2";
            TaskPerformed.InnerHtml = Resources.TasksPerformedLabel;
            LengthAtWork.InnerHtml = Resources.YearsatWorkLabel;
            Months.InnerHtml = Resources.MonthsLabel;
            IDType.InnerHtml = Resources.IDTypeLabel;
            IssuedBy.InnerHtml = Resources.IssuedByLabel;
            ExpirationDate.InnerHtml = Resources.ExpirationDateLabel;
            IDNumber.InnerHtml = Resources.IDNumberLabel.Replace("Número", "No.");
            copyHomeAddress.InnerHtml = Resources.CopyHomeAddressLabel;

            BtnAddPolitical.Text = Operation == Utility.OperationType.Insert ? Resources.Add : Resources.Edit;

            gvAdditionalInsured.Columns[0].Caption = Resources.FirstNameLabel;
            gvDependents.Columns[0].Caption = gvAdditionalInsured.Columns[0].Caption;

            gvAdditionalInsured.Columns[1].Caption = Resources.MiddleNameLabel;
            gvDependents.Columns[1].Caption = gvAdditionalInsured.Columns[1].Caption;

            gvAdditionalInsured.Columns[2].Caption = Resources.LastNameLabel;
            gvDependents.Columns[2].Caption = gvAdditionalInsured.Columns[2].Caption;

            gvAdditionalInsured.Columns[3].Caption = Resources.SecondLastNameLabel;
            gvDependents.Columns[3].Caption = gvAdditionalInsured.Columns[3].Caption;

            gvAdditionalInsured.Columns[4].Caption = Resources.GenderLabel;
            gvDependents.Columns[4].Caption = gvAdditionalInsured.Columns[4].Caption;

            gvAdditionalInsured.Columns[5].Caption = Resources.DateofBirthLabel;
            gvDependents.Columns[5].Caption = gvAdditionalInsured.Columns[5].Caption;

            gvAdditionalInsured.Columns[6].Caption = Resources.MaritalStatusLabel;
            gvDependents.Columns[6].Caption = gvAdditionalInsured.Columns[6].Caption;

            gvAdditionalInsured.Columns[7].Caption = Resources.IdentificationsLabel;
            gvDependents.Columns[7].Caption = gvAdditionalInsured.Columns[7].Caption;

            gvAdditionalInsured.Columns[8].Caption = Resources.FamilyRelationship;
            gvDependents.Columns[8].Caption = gvAdditionalInsured.Columns[8].Caption;

            gvAdditionalInsured.Columns[9].Caption = Resources.Edit;
            gvDependents.Columns[9].Caption = gvAdditionalInsured.Columns[9].Caption;

            gvAdditionalInsured.Columns[10].Caption = Resources.DeleteLabel;
            gvDependents.Columns[10].Caption = gvAdditionalInsured.Columns[10].Caption;

            tbDesignatedPensionerInfo.TabPages[0].Text = Resources.PhoneNumbersLabel;
            tbDesignatedPensionerInfo.TabPages[1].Text = Resources.AddresessLabel;
            tbDesignatedPensionerInfo.TabPages[2].Text = Resources.EmailAddressLabel;
            tbDesignatedPensionerInfo.TabPages[3].Text = "ID / " + Resources.OccupationLabel;



            lbFullName.InnerHtml = Resources.NameLabel;
            lbRelationship.InnerHtml = Resources.RelationshipLabel;
            lbPosition.InnerHtml = Resources.Position;
            lbFrom.InnerHtml = Resources.From;
            lbTo.InnerHtml = Resources.To;

            gvCitizenContact_Designated.Columns[0].Caption = Resources.NameLabel.ToUpper();
            gvCitizenContact_Designated.Columns[1].Caption = Resources.RelationshipLabel.ToUpper();
            gvCitizenContact_Designated.Columns[2].Caption = Resources.Position.ToUpper();
            gvCitizenContact_Designated.Columns[3].Caption = Resources.From.ToUpper();
            gvCitizenContact_Designated.Columns[4].Caption = Resources.To.ToUpper();
            gvCitizenContact_Designated.Columns[5].Caption = Resources.Edit.ToUpper();
            gvCitizenContact_Designated.Columns[6].Caption = Resources.DeleteLabel.ToUpper();


            btnSearchContact.Text = Resources.SearchContact;
            btnAdd.Text = Resources.Add.Capitalize();
            btnAddDependent.Text = btnAdd.Text;

            //Traducir  Grupo 3
            for (int i = 0; i < repeaterQuestion.Items.Count; i++)
            {
                var lblYes = repeaterQuestion.Items[i].FindControl("lblYes");
                var lblNo = repeaterQuestion.Items[i].FindControl("lblNo");
                var lblQuestion = repeaterQuestion.Items[i].FindControl("lblQuestion");

                if (!lblQuestion.isNullReferenceControl())
                {
                    var oQuestion = (lblQuestion as System.Web.UI.HtmlControls.HtmlGenericControl);
                    var NameKey = oQuestion.Attributes["nameKey"];
                    oQuestion.InnerText = Resources.ResourceManager.GetString(NameKey);
                }

                if (!lblYes.isNullReferenceControl())
                    (lblYes as System.Web.UI.HtmlControls.HtmlGenericControl).InnerText = Resources.YesLabel;

                if (!lblNo.isNullReferenceControl())
                    (lblNo as System.Web.UI.HtmlControls.HtmlGenericControl).InnerText = Resources.NoLabel;
            }

            if (isChangingLang)
            {
                FillDrop();

                if (cbxRelationship.SelectedValue != "-1")
                {
                    var value = Utility.deserializeJSON<Utility.itemRelationship>(cbxRelationship.SelectedValue);
                    //Llenar el dropDown de Relationship With insured
                    var data = ObjServices.GettingDropData(Utility.DropDownType.Relationship);

                    if (ObjServices.ContactEntityID < 0)
                        oTempDataAdditionalInsured.ForEach(x => x.RelationshiptoOwnerDesc = data.Where(o => o.RelationshipId == x.RelationshiptoOwner).FirstOrDefault().RelationshipDesc);
                }

                var view = MPrincipal.GetActiveView();

                if (view == vAdditionalInsured)
                    FillData();

                FillDataCitizenContact();
            }

            if (!hdnOccupationGroupId.Value.SIsNullOrEmpty() && !hdnOccupationId.Value.SIsNullOrEmpty())
            {
                var data = ObjServices.GettingDropData(Utility.DropDownType.Occupation);

                if (data != null)
                {
                    var dataOccup = data.FirstOrDefault(y => y.OccupGroupTypeId == hdnOccupationGroupId.ToInt() && y.OccupationId == hdnOccupationId.ToInt());

                    if (dataOccup != null)
                    {
                        txtOccupation.Text = dataOccup.OccupationDesc;
                        txtProfession.Text = dataOccup.OccupationGroupDesc;
                    }
                }
            }
        }

        /// <summary>
        /// Determina si se va a crear un desiganted pensioner/Addicional Insured 
        /// </summary>
        /// <returns></returns>
        public bool CreateDesignatedOrInsured()
        {
            var result = false;

            if (ContactRoleTypeID == Utility.ContactRoleIDType.DesignatedPensioner.ToInt())
                result = ObjServices.DesignatedPensionerContactId < 0;
            else
                if (ContactRoleTypeID == Utility.ContactRoleIDType.AddicionalInsured.ToInt())
                    result = ObjServices.InsuredAddContactId < 0;

                else if ((ObjServices.ProductLine == Utility.ProductLine.HealthInsurance))
                    result = true;

            return result;
        }

        /// <summary>
        /// Este metodo crear un additional insured de tipo familiar
        /// </summary>
        /// <returns></returns>
        public int CreateAddionalInsured(int contactId = -1,
                                        Utility.ContactRoleIDType contactRoleIDType = Utility.ContactRoleIDType.IncludedFamiliar)
        {
            SetVariables();
            int ContactID = -1;
            //Si ya salve el plan
            if (ObjServices.isSavePlan)
            {
                //Adjuntar el contacto como familiar o dependiente
                ContactID = ObjServices.oPolicyManager.AddContactToPolicy(this.CorpId,
                                                                          this.RegionId,
                                                                          this.CountryId,
                                                                          this.DomesticregId,
                                                                          this.StateProvId,
                                                                          this.CityId,
                                                                          this.OfficeId,
                                                                          this.CaseSeqNo,
                                                                          this.HistSeqNo,
                                                                          contactId,
                                                                          Utility.ContactTypeId.Contact.ToInt(),
                                                                          contactRoleIDType.ToInt(),
                                                                          ObjServices.Agent_Id.Value,
                                                                          ObjServices.UserID.Value
                                                                       );
            }
            else
                SaveTempMemory(ObjServices.GetContact(contactId));

            return ContactID;
        }

        public void setHiddend(string val)
        {

            hdnValidateFormDesignatedPensionerOrAddicionalInsured.Value = val;
        }

        public void saveTemporalData()
        {
            //Si ya salve el plan
            if (ObjServices.isSavePlan)
            {
                //Verificar si hay data temporal e insertar
                for (int i = 0; i < oTempDataAdditionalInsured.Count; i++)
                {
                    var oContact = oTempDataAdditionalInsured[i];

                    var contactId = CreateAddionalInsured();

                    var item = new Entity.UnderWriting.Entities.Contact()
                    {
                        ContactId = contactId,
                        FirstName = oContact.FirstName,
                        MiddleName = oContact.MiddleName,
                        FirstLastName = oContact.FirstLastName,
                        SecondLastName = oContact.SecondLastName,
                        Gender = oContact.Gender,
                        Dob = oContact.Dob,
                        MaritalStatId = oContact.MaritalStatId,
                        Age = oContact.Age,
                        RelationshiptoOwner = oContact.RelationshiptoOwner
                    };

                    //Actualizar el contacto
                    ObjServices.oContactManager.UpdateContact(item);

                    //Item IDdocument
                    var objIDDoc = new Entity.UnderWriting.Entities.Contact.IdDocument()
                    {
                        //Key
                        ContactId = contactId,
                        SeqNo = -1,
                        //Campos 
                        ContactIdType = oTempDataId[i].ContactIdType,//N/A
                        ContactIdTypeDescription = string.Empty,
                        Id = oTempDataId[i].Id,
                        ExpireDate = default(DateTime?),
                        IssuedBy = string.Empty,
                        CountryIssuedBy = default(int?),
                        //Información Usuario
                        UserId = ObjServices.UserID.Value
                    };

                    //Actualizar el id          
                    ObjServices.oContactManager.SetIdDocument(objIDDoc);
                }

                //Limpiar la data temporal
                oTempDataAdditionalInsured = null;
                oTempDataId = null;
                Session["OperationAdditonalInsured"] = null;
                Session["TempDataAdditionalInsuredId"] = null;
            }
        }

        public void save()
        {
            int age = 0;
            SetVariables();

            if (hdnValidateFormDesignatedPensionerOrAddicionalInsured.Value == "true")
            {
                var View = MPrincipal.GetActiveView();
                if (View == vDesigantedPensionerOrAdditionalInsured)
                {
                    #region Planes de Vida y/o de Salud
                    if (CreateDesignatedOrInsured())
                    {
                        if (!string.IsNullOrEmpty(txtFirstName.Text) &&
                               !string.IsNullOrEmpty(txtLastName.Text) &&
                               ddlGender.SelectedValue != "-1" &&
                               ddlSmoker.SelectedValue != "-1" &&
                               !string.IsNullOrEmpty(hdnAge.Value) &&
                               !string.IsNullOrEmpty(txtDateOfBirthDesignatedPensioner.Text) &&
                               ddlMaritalStatus.SelectedValue != "-1"
                              )
                        {
                            var pContactId = ObjServices.ContactEntityID > 0 ? ObjServices.ContactEntityID : -1;

                            ObjServices.ContactEntityID = ObjServices.oPolicyManager.AddContactToPolicy
                                                                       (this.CorpId,
                                                                        this.RegionId,
                                                                        this.CountryId,
                                                                        this.DomesticregId,
                                                                        this.StateProvId,
                                                                        this.CityId,
                                                                        this.OfficeId,
                                                                        this.CaseSeqNo,
                                                                        this.HistSeqNo,
                                                                        pContactId,
                                                                        Utility.ContactTypeId.Contact.ToInt(), //1 , //ContactTypeId 5 Para Compañia
                                                                        ContactRoleTypeID,//ContactRoleTypeId para el Designated Pensioner o el Addicional Insured
                                                                        ObjServices.Agent_Id.Value,
                                                                        ObjServices.UserID.Value);

                            if (ContactRoleTypeID == Utility.ContactRoleIDType.DesignatedPensioner.ToInt()/*5*/)
                                ObjServices.DesignatedPensionerContactId = ObjServices.ContactEntityID;
                            else
                                if (ContactRoleTypeID == Utility.ContactRoleIDType.AddicionalInsured.ToInt())
                                    ObjServices.InsuredAddContactId = ObjServices.ContactEntityID;

                            SetVariables();
                        }
                    }

                    age = txtDateOfBirthDesignatedPensioner.Text.ParseFormat().Value.GetAge();

                    //Actualizar el contacto
                    var Contact = (ContactRoleTypeID == Utility.ContactRoleIDType.DesignatedPensioner.ToInt()/*5*/) ?
                                                                         ObjServices.GetContactInfo(Utility.ContactRoleIDType.DesignatedPensioner) :
                                                                         ObjServices.GetContactInfo(Utility.ContactRoleIDType.AddicionalInsured);

                    if ((ObjServices.ProductLine == Utility.ProductLine.HealthInsurance))
                        Contact = ObjServices.GetContact(ObjServices.ContactEntityID.Value);

                    if (Contact != null)
                    {
                        Contact.FirstName = txtFirstName.Text;
                        Contact.MiddleName = txtMidleName.Text;
                        Contact.FirstLastName = txtLastName.Text;
                        Contact.ContactIdType = Utility.ContactTypeId.Contact.ToInt();
                        Contact.SecondLastName = txt2ndLastName.Text;
                        Contact.Gender = ddlGender.SelectedValue;
                        Contact.Dob = txtDateOfBirthDesignatedPensioner.Text.ParseFormat();
                        Contact.Age = age;
                        Contact.Smoker = (ddlSmoker.SelectedValue == "1");
                        Contact.MaritalStatId = ddlMaritalStatus.ToInt();
                        Contact.MaritalStatusDesc =
                            ddlMaritalStatus.SelectedItem.Text;

                        Contact.OccupGroupTypeId = !string.IsNullOrEmpty(hdnOccupationGroupId.Value) ? hdnOccupationGroupId.ToInt() : (int?)null;
                        Contact.OccupationId = !string.IsNullOrEmpty(hdnOccupationId.Value) ? hdnOccupationId.ToInt() : (int?)null;
                        Contact.StudentStatusId = ObjServices.ProductLine == Utility.ProductLine.HealthInsurance ? ddlStudentStatus.ToInt() : (int?)null;
                        Contact.CompanyName = txtCompanyName.Text;
                        Contact.LineOfBusiness = txtFirstLineOfBusiness.Text;
                        Contact.LineOfBusiness2 = txtSecondLineOfBusiness.Text;
                        Contact.LaborTasks = txtTaskPerformed.Text;
                        Contact.LengthWorkYear = ddlLengthWorkFrom.ToInt();
                        Contact.LengthWorkMonth = ddlLengthWorkTo.ToInt();
                        Contact.AnnualPersonalIncome = tb_WUC_PI_PersonalIncome.ToDecimal();
                        Contact.AnnualFamilyIncome = tb_WUC_PI_PersonalIncome.ToDecimal();
                        Contact.RelationshiptoOwner = (cbxRelationshipwithinsured.SelectedValue != "-1") ? cbxRelationshipwithinsured.ToInt() : (int?)null;
                        ObjServices.oContactManager.UpdateContact(Contact);
                        //End Actualizar contacto
                    }

                    var vSeqNo = -1;

                    var IdDataList = ObjServices.GetAllIdDocumentInformation();

                    var IdDataItem = IdDataList.Any() ? IdDataList.LastOrDefault() : null;

                    if (IdDataItem != null)
                        vSeqNo = IdDataItem.SeqNo;

                    //Item IDdocument
                    var objIDDoc = new Entity.UnderWriting.Entities.Contact.IdDocument
                    {
                        //Key
                        ContactId = ObjServices.ContactEntityID.Value,
                        SeqNo = vSeqNo,
                        //Campos 
                        ContactIdType = cbxIDType.SelectedValue.ToInt(),
                        //ContactIdTypeDescription = "",
                        Id = txtIDNumber.Text,
                        MainIdentity = true,
                        ExpireDate = Utility.IsDate(txtExpirationDate.Text) ? txtExpirationDate.Text.ParseFormat() : (DateTime?)null,
                        IssuedBy = cbxIssuedBy.SelectedItem.Text,
                        CountryIssuedBy = cbxIssuedBy.SelectedValue.ToInt(),
                        //Información Usuario
                        UserId = ObjServices.UserID.Value
                    };

                    //Actualizar el id de la compañia RNC             
                    ObjServices.SetIdentificationsContact(objIDDoc);

                    udpDesignatedPensioner.Update();

                    //Salvar Questionario
                    foreach (RepeaterItem item in repeaterQuestion.Items)
                    {
                        int? vCitizenQuestId = null;

                        var rbYes = (item.FindControl("rbYes") as RadioButton);

                        var rbNo = (item.FindControl("rbNo") as RadioButton);

                        bool? Answer = null;

                        if (rbYes.Checked)
                            Answer = true;
                        else
                            if (rbNo.Checked)
                                Answer = false;

                        var label = (item.FindControl("lblQuestion") as System.Web.UI.HtmlControls.HtmlGenericControl);

                        vCitizenQuestId = int.Parse(label.Attributes["data-question"].ToString());

                        var rec = new Entity.UnderWriting.Entities.Contact.CitizenQuestion()
                        {
                            CaseSeqNo = this.CaseSeqNo,
                            CityId = this.CityId,
                            ContactId = ObjServices.ContactEntityID,
                            CorpId = this.CorpId,
                            CountryId = this.CountryId,
                            CreateUser = ObjServices.UserID.Value,
                            DomesticregId = this.DomesticregId,
                            HistSeqNo = this.HistSeqNo,
                            ModifyUser = ObjServices.UserID.Value,
                            OfficeId = this.OfficeId,
                            RegionId = this.RegionId,
                            StateProvId = this.StateProvId,
                            CitizenQuestId = vCitizenQuestId.Value,
                            CitizenQuestAnswer = Answer
                        };

                        if (ObjServices.ContactEntityID.Value > 0)
                            ObjServices.oContactManager.UpdateContactCitizenQuestionByContact(rec);
                    }

                    //Salvar address
                    SaveAddress();
                    //Salvar correos
                    WUCEmailAddress.Operation = Utility.OperationType.InsertAll;
                    WUCEmailAddress.save();
                    //Salvar Numero de telefono
                    WUCPhoneNumber.Operation = Utility.OperationType.InsertAll;
                    WUCPhoneNumber.save();
                    #endregion
                }
                else
                    if (View == vAdditionalInsured)
                    {
                        #region Planes Funerarios

                        if (Session["OperationAdditonalInsured"] == null)
                            Operation = Utility.OperationType.Insert;

                        var isEmpty = (TFirstName.isEmpty() &&
                                        TFirstLastName.isEmpty() &&
                                        TSecondLastName.isEmpty() &&
                                        TIdentification.isEmpty() &&
                                        TDateOfBirth.isEmpty() &&
                                        cbxGender.ToInt() < 0 &&
                                        cbxRelationship.ToInt() < 0 &&
                                        ddl_WUC_PI_MaritalStatus.ToInt() < 0
                                      );

                        //Validar que los datos no esten vacios
                        if (!isEmpty)
                        {
                            var Msg = string.Empty;

                            //Limite de edad si es hijo es de 28
                            var objRelationShip = Utility.deserializeJSON<Utility.itemRelationship>(cbxRelationship.SelectedValue);

                            var RelationShipID = objRelationShip.RelationshipId.ToInt();

                            //Validaciones
                            /*
                                Si la relación con el asegurado principal es hijo, el límite edad es 28 años y el estatus no puede ser casado, ni unión libre,
                                El único estatus que el hijo puede tener es soltero.
                            */

                            Utility.RelationShipNameKey RelationShipNameKey = Utility.ParseEnum<Utility.RelationShipNameKey>(objRelationShip.NameKey);
                            age = TDateOfBirth.Text.ParseFormat().Value.GetAge();

                            if ((RelationShipNameKey == Utility.RelationShipNameKey.Son || RelationShipNameKey == Utility.RelationShipNameKey.Daughter)
                                && age >= 28) //Hijo y menor que 28
                                Msg += Resources.AgeAdditionalFamiliarValidation + "<br/><br/>";

                            //End validacion limite de edad

                            //si es hijo y no es soltero
                            if ((RelationShipNameKey == Utility.RelationShipNameKey.Son || RelationShipNameKey == Utility.RelationShipNameKey.Daughter)
                                && ddl_WUC_PI_MaritalStatus.ToInt() != 4)
                                Msg += Resources.InsuredFamilyValidation + "<br/><br/>";

                            if (!string.IsNullOrEmpty(Msg))
                            {
                                this.MessageBox(Msg, Title: Resources.Warning);
                                return;
                            }

                            int ContactID = hdnContactIdGrid.ToInt();

                            var isSavePlan = ObjServices.isSavePlan;

                            //Si ya salve el plan
                            if (isSavePlan)
                            {
                                if (Operation == Utility.OperationType.Insert)
                                    ContactID = CreateAddionalInsured(contactRoleIDType: Utility.ContactRoleIDType.IncludedFamiliar);


                                var oContact = ObjServices.GetContact(ContactID);
                                oContact.FirstName = TFirstName.Text;
                                oContact.MiddleName = TMiddleName.Text;
                                oContact.FirstLastName = TFirstLastName.Text;
                                oContact.SecondLastName = TSecondLastName.Text;
                                oContact.Gender = cbxGender.SelectedValue;
                                oContact.Dob = TDateOfBirth.Text.ParseFormat();
                                oContact.MaritalStatId = ddl_WUC_PI_MaritalStatus.ToInt();
                                oContact.MaritalStatusDesc = ddl_WUC_PI_MaritalStatus.SelectedItem.Text;
                                oContact.Age = age;
                                oContact.RelationshiptoOwner = (cbxRelationship.SelectedValue != "-1") ? RelationShipID : (int?)null;
                                ObjServices.oContactManager.UpdateContact(oContact);
                                //End Actualizar contacto  

                                var vSeqNo = -1;

                                var IdDataList = ObjServices.oContactManager.GetAllIdDocumentInformation(ContactID, ObjServices.Language.ToInt()).ToList();

                                var IdDataItem = IdDataList.Any() ? IdDataList.LastOrDefault() : null;

                                if (IdDataItem != null)
                                    vSeqNo = IdDataItem.SeqNo;

                                //Item IDdocument
                                var objIDDoc = new Entity.UnderWriting.Entities.Contact.IdDocument()
                                {
                                    //Key
                                    ContactId = ContactID,
                                    SeqNo = vSeqNo,
                                    //Campos 
                                    ContactIdType = 1,//Id
                                    MainIdentity = true,
                                    ContactIdTypeDescription = string.Empty,
                                    Id = TIdentification.Text,
                                    ExpireDate = default(DateTime?),
                                    IssuedBy = string.Empty,
                                    CountryIssuedBy = default(int?),
                                    //Información Usuario
                                    UserId = ObjServices.UserID.Value
                                };

                                ObjServices.oContactManager.SetIdDocument(objIDDoc);
                            }
                            else
                                //Guardar en la memoria temp
                                SaveTempMemory(null);
                        }
                        else
                        {
                            saveTemporalData();
                            return;
                        }

                        if (Operation == Utility.OperationType.Edit)
                            btnAdd.Text = Resources.Add.Capitalize();

                        //Limpiar el form
                        Utility.ClearAll(frmAdditionalsIndured.Controls);
                        Operation = Utility.OperationType.Insert;
                        #endregion
                    }
            } 

            if (ObjServices.ContactEntityID.Value > 0)
            {
                foreach (var item in oTemDataCitizenContact)
                {
                    item.Contact_Id = ObjServices.ContactEntityID.Value;
                    item.Case_Seq_No = ObjServices.Case_Seq_No;
                    item.Hist_Seq_No = ObjServices.Hist_Seq_No;
                }

                ObjServices.SetCitizenContact(oTemDataCitizenContact);
                oTemDataCitizenContact.Clear();
            }



            FillData();
        }

        public void removalAdditional(int ContactID)
        {
            var contactRoleType = (Utility.ContactRoleIDType)Utility.getEnumTypeFromValue(typeof(Utility.ContactRoleIDType), ContactRoleTypeID);

            var removeAdditional = ObjServices.DesignatedPensionerContactId.Value > 0 ||
                                   ObjServices.InsuredAddContactId.Value > 0;

            //Si tengo un additional insured o un designated pensioner
            if (removeAdditional)
            {
                ObjServices.oPolicyManager.DeleteContactRole(ObjServices.Corp_Id,
                                                             ObjServices.Region_Id,
                                                             ObjServices.Country_Id,
                                                             ObjServices.Domesticreg_Id,
                                                             ObjServices.State_Prov_Id,
                                                             ObjServices.City_Id,
                                                             ObjServices.Office_Id,
                                                             ObjServices.Case_Seq_No,
                                                             ObjServices.Hist_Seq_No,
                                                             ObjServices.ContactEntityID.Value,
                                                             contactRoleType.ToInt(),
                                                             ObjServices.UserID.Value
                                                            );


                //Agregar el nuevo contacto a la poliza
                ObjServices.ContactEntityID = ObjServices.oPolicyManager.AddContactToPolicy(
                                                               ObjServices.Corp_Id,
                                                               ObjServices.Region_Id,
                                                               ObjServices.Country_Id,
                                                               ObjServices.Domesticreg_Id,
                                                               ObjServices.State_Prov_Id,
                                                               ObjServices.City_Id,
                                                               ObjServices.Office_Id,
                                                               ObjServices.Case_Seq_No,
                                                               ObjServices.Hist_Seq_No,
                                                               ContactID,
                                                               Utility.ContactTypeId.Contact.ToInt(),
                                                               contactRoleType.ToInt(),
                                                               ObjServices.Agent_Id.Value,
                                                               ObjServices.UserID.Value
                                                             );

                if (contactRoleType == Utility.ContactRoleIDType.AddicionalInsured)
                    ObjServices.InsuredAddContactId = ContactID;
                else
                    if (contactRoleType == Utility.ContactRoleIDType.DesignatedPensioner)
                        ObjServices.DesignatedPensionerContactId = ContactID;
            }
            else
                ObjServices.ContactEntityID = ContactID;
        }

        /// <summary>
        /// Salvar en la memoria temporal
        /// </summary>
        /// <param name="oitem"></param>
        public void SaveTempMemory(Entity.UnderWriting.Entities.Contact oitem)
        {
            Utility.itemRelationship objRelationShip;
            int RelationShipID = -1;

            if (oitem == null)
            {
                objRelationShip = Utility.deserializeJSON<Utility.itemRelationship>(cbxRelationship.SelectedValue);
                RelationShipID = objRelationShip.RelationshipId.ToInt();
            }

            Entity.UnderWriting.Entities.Contact.IdDocument itemId = null;

            //Guardar en la memoria temporal
            var DateOfBirth = TDateOfBirth.Text.ParseFormat();

            var item = new Entity.UnderWriting.Entities.Contact()
            {
                FirstName = oitem == null ? TFirstName.Text : oitem.FirstName,
                MiddleName = oitem == null ? TMiddleName.Text : oitem.MiddleName,
                FirstLastName = oitem == null ? TFirstLastName.Text : oitem.FirstLastName,
                SecondLastName = oitem == null ? TSecondLastName.Text : oitem.SecondLastName,
                Gender = oitem == null ? cbxGender.SelectedValue : oitem.Gender,
                Dob = oitem == null ? DateOfBirth : oitem.Dob,
                MaritalStatId = oitem == null ? ddl_WUC_PI_MaritalStatus.ToInt() : oitem.MaritalStatId,
                MaritalStatusDesc = oitem == null ? ddl_WUC_PI_MaritalStatus.SelectedItem.Text
                                                  : !string.IsNullOrEmpty(oitem.MaritalStatusDesc) ?
                                                                                                  oitem.MaritalStatusDesc
                                                                                                  : ddl_WUC_PI_MaritalStatus.Items.FindByValue(oitem.MaritalStatId.ToString()).Text,
                Age = oitem == null ? Utility.GetAge(DateOfBirth.Value) : oitem.Age,
                RelationshiptoOwner = (oitem == null) ?
                                                       (cbxRelationship.SelectedValue != "-1") ? RelationShipID : (int?)null
                                      : oitem.RelationshiptoOwner,

                RelationshiptoOwnerDesc = oitem == null ? cbxRelationship.SelectedItem.Text
                                                        : string.Empty

            };

            var id = oitem == null ? TIdentification.Text
                                   : ObjServices.oContactManager.GetAllIdDocumentInformation(oitem.ContactId, ObjServices.Language.ToInt()).LastOrDefault().Id;

            itemId = new Entity.UnderWriting.Entities.Contact.IdDocument()
            {
                //Key
                ContactId = -1,
                SeqNo = -1,
                //Campos 
                ContactIdType = 1,//Id
                ContactIdTypeDescription = string.Empty,
                Id = id,
                ExpireDate = default(DateTime?),
                IssuedBy = string.Empty,
                CountryIssuedBy = default(int?),
                MainIdentity = true,
                //Información Usuario
                UserId = ObjServices.UserID.Value
            };

            if (Operation == Utility.OperationType.Insert)
            {
                if (itemId != null)
                {
                    TempDataId.Add(itemId);
                    oTempDataId = TempDataId;
                }

                if (item != null)
                {
                    TempDataAdditionalInsured.Add(item);
                    TempDataAdditionalInsured.LastOrDefault().Identification = oTempDataId.LastOrDefault().Id;
                    oTempDataAdditionalInsured = TempDataAdditionalInsured;
                }
            }
            else if (Operation == Utility.OperationType.Edit)
            {
                var record = oTempDataAdditionalInsured.ElementAt(RowIndex.Value);
                record.FirstName = TFirstName.Text;
                record.MiddleName = TMiddleName.Text;
                record.FirstLastName = TFirstLastName.Text;
                record.SecondLastName = TSecondLastName.Text;
                record.Gender = cbxGender.SelectedValue;
                record.Dob = DateOfBirth;
                record.MaritalStatId = ddl_WUC_PI_MaritalStatus.ToInt();
                record.Age = DateOfBirth.Value.GetAge();
                record.RelationshiptoOwner = (cbxRelationship.SelectedValue != "-1") ? RelationShipID
                                                                                     : (int?)null;
                record.RelationshiptoOwnerDesc = cbxRelationship.SelectedItem.Text;
                var recordId = oTempDataId.ElementAt(RowIndex.Value);
                recordId.Id = TIdentification.Text;
                record.Identification = recordId.Id;
            }
        }

        public void SaveAddress()
        {
            if (ObjServices.ContactEntityID.Value > 0)
            {
                //Getting All Address
                var dataAddress = ObjServices.oContactManager.GetCommunicatonAdress(ObjServices.Corp_Id, ObjServices.ContactEntityID.Value, languageId: ObjServices.Language.ToInt());

                Entity.UnderWriting.Entities.Contact.Address homeAddress = null;

                var homeAddressList = dataAddress.Where(r => r.DirectoryTypeId == 5);

                if (homeAddressList.Any())
                    homeAddress = homeAddressList.OrderBy(r => r.DirectoryId).FirstOrDefault();

                if (!string.IsNullOrEmpty(txtHomeAddress.Text) &&
                       ddlHomeCountry.SelectedValue != "-1" &&
                       ddlHomeState.SelectedValue != "-1" &&
                       (ddlHomeCity.SelectedValue != "-1" && ddlHomeCity.Items.Count > 0)
                    )
                {
                    //Home DomesticRegID & StateID
                    var HomeState = Utility.deserializeJSON<Utility.StateProvince>(ddlHomeState.SelectedValue);
                    var DocRegHome = HomeState.DomesticregId;
                    var StateHome = HomeState.StateProvId;
                    var RegionID = HomeState.RegionId;

                    //Saving Home Address
                    ObjServices.oContactManager.SetAddress(new Entity.UnderWriting.Entities.Contact.Address
                    {
                        //Key
                        CorpId = ObjServices.Corp_Id,
                        DirectoryId = homeAddress == null ? -1 : homeAddress.DirectoryId,
                        DirectoryDetailId = homeAddress == null ? -1 : homeAddress.DirectoryDetailId,
                        DirectoryTypeId = 5,
                        ContactId = ObjServices.ContactEntityID.Value,
                        CommunicationType = Utility.CommType.Address.ToString(),

                        //Address Info
                        StreetAddress = txtHomeAddress.Text,
                        RegionId = RegionID,
                        CountryId = Convert.ToInt32(ddlHomeCountry.SelectedValue),
                        DomesticregId = DocRegHome,
                        StateProvId = StateHome,
                        CityId = Convert.ToInt32(ddlHomeCity.SelectedValue),
                        ZipCode = !string.IsNullOrEmpty(txtHomePostalCode.Text) ? txtHomePostalCode.Text : null,
                        IsPrimary = false,

                        //User
                        CreateUser = ObjServices.UserID.Value,
                        ModifyUser = ObjServices.UserID.Value,
                    });
                }
                else
                {
                    //Eliminar Home Address 
                }

                //Getting Bussines Address
                Entity.UnderWriting.Entities.Contact.Address bussinesAddress = null;

                var bussinesAddressList = dataAddress.Where(r => r.DirectoryTypeId == 4);

                if (bussinesAddressList.Any())
                    bussinesAddress = bussinesAddressList.OrderBy(r => r.DirectoryId).FirstOrDefault();


                //Bussines Address

                if (!string.IsNullOrEmpty(txtBusinessAddress.Text) &&
                       ddlBusinessCountry.SelectedValue != "-1" &&
                       ddlBusinessState.SelectedValue != "-1" &&
                       (ddlBusinessCity.SelectedValue != "-1" && ddlBusinessCity.Items.Count > 0)
                    )
                {

                    //Bussines DomesticRegID & StateID
                    var BussinesState = Utility.deserializeJSON<Utility.StateProvince>(ddlBusinessState.SelectedValue);
                    int DocRegBussines = BussinesState.DomesticregId;
                    int StateBussines = BussinesState.StateProvId;
                    var RegionID = BussinesState.RegionId;

                    //Saving Bussines Address
                    ObjServices.oContactManager.SetAddress(new Entity.UnderWriting.Entities.Contact.Address
                    {
                        //Key
                        CorpId = ObjServices.Corp_Id,
                        DirectoryId = bussinesAddress == null ? -1 : bussinesAddress.DirectoryId,
                        DirectoryDetailId = bussinesAddress == null ? -1 : bussinesAddress.DirectoryDetailId,
                        DirectoryTypeId = 4,
                        ContactId = ObjServices.ContactEntityID.Value,
                        CommunicationType = Utility.CommType.Address.ToString(),

                        //Address Info
                        StreetAddress = txtBusinessAddress.Text,
                        RegionId = RegionID,
                        CountryId = Convert.ToInt32(ddlBusinessCountry.SelectedValue),
                        DomesticregId = DocRegBussines,
                        StateProvId = StateBussines,
                        CityId = Convert.ToInt32(ddlBusinessCity.SelectedValue),
                        ZipCode = !string.IsNullOrEmpty(txtBusinessPostalCode.Text) ? txtBusinessPostalCode.Text : null,
                        IsPrimary = false,

                        //User
                        CreateUser = ObjServices.UserID.Value,
                        ModifyUser = ObjServices.UserID.Value,
                    });

                }
                else
                {
                    //Eliminar Business address

                }
            }

        }

        public void EnableControls(bool x)
        {
            Utility.EnableControls(pnDesignatedPensionerOrAddicionalInsured.Controls, x);

            HtmlGenericControl dvAddBtn = (HtmlGenericControl)WUCPhoneNumber.FindControl("dvAddBtn");
            if (x)
                dvAddBtn.Attributes["class"] = "boton_wrapper amarillo float_right";
            else
                dvAddBtn.Attributes["class"] = "boton_wrapper disabled float_right";

            udpDesignatedPensioner.Update();
        }

        public void FillDrop()
        {
            //Llenar el dropDpown de Generos
            ObjServices.GettingAllDrops(ref ddlGender,
                                    Utility.DropDownType.Gender,
                                    "GenderDesc",
                                    "GenderId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Generos
            ObjServices.GettingAllDrops(ref cbxGender,
                                    Utility.DropDownType.Gender,
                                    "GenderDesc",
                                    "GenderId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de  Marital status
            ObjServices.GettingAllDrops(ref ddl_WUC_PI_MaritalStatus,
                                    Utility.DropDownType.MaritalStatus,
                                    "MaritalStatusDesc", "MaritalStatId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de  Marital status
            ObjServices.GettingAllDrops(ref ddlMaritalStatus,
                                    Utility.DropDownType.MaritalStatus,
                                    "MaritalStatusDesc", "MaritalStatId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Smoker
            ObjServices.GettingAllDrops(ref ddlSmoker,
                                    Utility.DropDownType.Smoker,
                                    "SmokerDesc",
                                    "SmokerId",
                                    GenerateItemSelect: true
                                   );

            var isHealth = (ObjServices.ProductLine == Utility.ProductLine.HealthInsurance);

            //Llenar el dropDown de Relationship With insured
            ObjServices.GettingAllDrops(ref cbxRelationshipwithinsured,
                                     !isHealth ? Utility.DropDownType.Relationship : Utility.DropDownType.RelationshipHealth,
                                     "RelationshipDesc",
                                     "RelationshipId",
                                     GenerateItemSelect: true
                                     );

            //Llenar el dropDpown de Home Country
            ObjServices.GettingAllDrops(ref ddlHomeCountry,
                                    Utility.DropDownType.Country,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                     GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Business Country
            ObjServices.GettingAllDrops(ref ddlBusinessCountry,
                                    Utility.DropDownType.Country,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                     GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de LengOfWork
            ObjServices.GettingAllDrops(ref ddlLengthWorkFrom,
                                    Utility.DropDownType.LengthatWork,
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Months 
            ObjServices.GettingAllDrops(ref ddlLengthWorkTo,
                                      Utility.DropDownType.Months,
                                    GenerateItemSelect: true
                                   );

            ObjServices.GettingAllDrops(ref cbxIssuedBy,
                               Utility.DropDownType.IssuedBy,
                               "GlobalCountryDesc",
                               "CountryId",
                               GenerateItemSelect: true,
                               corpId: ObjServices.Corp_Id
                               );

            //Llenar el dropDown de Relationship With insured
            ObjServices.GettingAllDropsJSON(ref cbxRelationship,
                                     Utility.DropDownType.RelationshipFuneral,
                                     "RelationshipDesc",
                                     GenerateItemSelect: true
                                     );

            ObjServices.GettingAllDrops(ref cbxIDType,
                                    Utility.DropDownType.IdType,
                                    "ContactTypeIdDesc",
                                    "ContactTypeId",
                                    GenerateItemSelect: true,
                                    corpId: ObjServices.Corp_Id
                                    );

            ObjServices.GettingAllDrops(ref ddlStudentStatus,
                                        Utility.DropDownType.StudentStatus,
                                        "StudentStatusDesc",
                                        "StudentStatusId",
                                        corpId: ObjServices.Corp_Id
                                        );

            ObjServices.GettingAllDrops(ref ddlRelationship_Designated,
                                Utility.DropDownType.Relationship,
                                "RelationshipDesc",
                                "RelationshipId",
                                GenerateItemSelect: true 
                                );
        }

        public void LoadDataFromIllustration(Illustrator.CustomerPlanPartnerInsurance item)
        {
            txtFirstName.Text = item.FirstName;
            txtMidleName.Text = item.MiddleName;
            txtLastName.Text = item.LastName;
            ddlGender.SelectIndexByValue(item.GenderCode);
            txt2ndLastName.Text = item.LastName2;
            txtDateOfBirthDesignatedPensioner.Text = string.Format("{0:MM/dd/yyyy}", item.BirthDate);
            hdnAge.Value = item.Age.ToString();
            ddlSmoker.SelectIndexByValue(item.Smoker == "N" ? "0" : "1");

            Dictionary<string, int> MaritalStatus = new Dictionary<string, int>();
            MaritalStatus.Add("D", 2);
            MaritalStatus.Add("M", 1);
            MaritalStatus.Add("S", 4);
            MaritalStatus.Add("W", 5);

            Dictionary<string, string> Relationshipt = new Dictionary<string, string>();
            Relationshipt.Add("J", "14");
            Relationshipt.Add("9", "7");
            Relationshipt.Add("C", "Charity");
            Relationshipt.Add("S", "Child");
            Relationshipt.Add("N", "Cohabitant");
            Relationshipt.Add("4", "6");
            Relationshipt.Add("Y", "Family Foundation");
            Relationshipt.Add("5", "3");
            Relationshipt.Add("8", "18");
            Relationshipt.Add("G", "Female Cousin");
            Relationshipt.Add("Q", "Goddaughter");
            Relationshipt.Add("P", "Godson");
            Relationshipt.Add("X", "12");
            Relationshipt.Add("1", "9");
            Relationshipt.Add("2", "10");
            Relationshipt.Add("R", "11");
            Relationshipt.Add("Z", "1");
            Relationshipt.Add("E", "15");
            Relationshipt.Add("V", "Member");
            Relationshipt.Add("6", "4");
            Relationshipt.Add("7", "19");
            Relationshipt.Add("A", "16");
            Relationshipt.Add("D", "17");
            Relationshipt.Add("O", "Other");
            Relationshipt.Add("F", "Parents");
            Relationshipt.Add("U", "Partner");
            Relationshipt.Add("B", "Sibling");
            Relationshipt.Add("0", "8");
            Relationshipt.Add("3", "5");
            Relationshipt.Add("M", "Spouse");
            Relationshipt.Add("H", "Stepdaughter");
            Relationshipt.Add("*", "Stepfather");
            Relationshipt.Add("#", "Stepmother");
            Relationshipt.Add("I", "Stepson");
            Relationshipt.Add("T", "Trust");
            Relationshipt.Add("K", "13");
            Relationshipt.Add("L", "2");

            var valueMaritalStatus = MaritalStatus[item.MaritalStatusCode].ToString();
            ddlMaritalStatus.SelectIndexByValue(valueMaritalStatus);

            var valueRelationShipt = Relationshipt[item.RelationshipTypeCode].ToString();
            cbxRelationshipwithinsured.SelectIndexByValue(valueRelationShipt);
        }

        public void FillData()
        {
            var isSave = ObjServices.isSavePlan;

            SetBirthCetificate();

            SetVariables();

            var view = MPrincipal.GetActiveView();

            if (view == vDesigantedPensionerOrAdditionalInsured)
            {
                //Questions                    
                var Questions = ObjServices.GetContactCitizenQuestionByContact();

                repeaterQuestion.DataSource = Questions.Where(x => x.NameKey != "ISCLIENTPEP");
                repeaterQuestion.DataBind();
                if (!(ObjServices.ProductLine == Utility.ProductLine.HealthInsurance))
                {
                    #region Planes de Vida
                    //Personal Information
                    var dataInfo = ObjServices.GetContact(ObjServices.ContactEntityID.Value);

                    if (dataInfo != null)
                    {
                        txtFirstName.Text = dataInfo.FirstName;
                        txtMidleName.Text = dataInfo.MiddleName;
                        txtLastName.Text = dataInfo.FirstLastName;
                        txt2ndLastName.Text = dataInfo.SecondLastName;
                        ddlGender.SelectIndexByValue(!string.IsNullOrEmpty(dataInfo.Gender) ? dataInfo.Gender : "-1");
                        txtDateOfBirthDesignatedPensioner.Text = !dataInfo.Dob.HasValue ? "" : dataInfo.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        hdnAge.Value = !dataInfo.Age.HasValue ? "" : dataInfo.Age.Value.ToString();
                        ddlSmoker.SelectIndexByValue(!dataInfo.Smoker.HasValue ? "-1" : (dataInfo.Smoker.Value ? "1" : "0"));
                        ddlMaritalStatus.SelectIndexByValue(dataInfo.MaritalStatId.ToString());

                        if (dataInfo.OccupGroupTypeId.HasValue)
                        {
                            txtOccupation.Text = dataInfo.Occupation_Desc;
                            hdnOccupationGroupId.Value = dataInfo.OccupGroupTypeId.Value.ToString();
                        }

                        if (dataInfo.OccupationId.HasValue)
                        {
                            txtProfession.Text = dataInfo.Occupation_Group_Desc;
                            hdnOccupationId.Value = dataInfo.OccupationId.Value.ToString();
                        }
                       
                        txtCompanyName.Text = dataInfo.CompanyName;
                        txtFirstLineOfBusiness.Text = dataInfo.LineOfBusiness;
                        txtSecondLineOfBusiness.Text = dataInfo.LineOfBusiness2;
                        txtTaskPerformed.Text = dataInfo.LaborTasks;
                        ddlLengthWorkFrom.SelectIndexByValue(dataInfo.LengthWorkYear.HasValue ? dataInfo.LengthWorkYear.Value.ToString() : string.Empty, true);
                        ddlLengthWorkTo.SelectIndexByValue(dataInfo.LengthWorkMonth.HasValue ? dataInfo.LengthWorkMonth.Value.ToString() : string.Empty, true);
                        
                        if (dataInfo.RelationshiptoOwner.HasValue)
                            cbxRelationshipwithinsured.SelectIndexByValue(dataInfo.RelationshiptoOwner.Value.ToString(), true);

                        var IdDataItem = ObjServices.GetAllIdDocumentInformation().LastOrDefault();

                        if (IdDataItem != null)
                        {
                            cbxIDType.SelectIndexByValue(IdDataItem.ContactIdType.ToString());
                            cbxIssuedBy.SelectIndexByValue(IdDataItem.CountryIssuedBy.ToString());
                            txtIDNumber.Text = IdDataItem.Id;
                            txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", IdDataItem.ExpireDate);
                        }

                        //Cargar Address
                        var dataAddress = ObjServices.GetCommunicatonAdress();

                        if (dataAddress.Any())
                        {
                            var homeAddress = dataAddress.Where(r => r.DirectoryTypeId == 5).OrderBy(r => r.DirectoryId).FirstOrDefault();
                            var businessAddress = dataAddress.Where(r => r.DirectoryTypeId == 4).OrderBy(r => r.DirectoryId).FirstOrDefault();

                            if (dataAddress.Any())
                            {
                                if (homeAddress != null)
                                    setDataForm(homeAddress, true);

                                if (businessAddress != null)
                                    setDataForm(businessAddress, false);
                            }
                        }
                    }
                    else hdnValidateFormDesignatedPensionerOrAddicionalInsured.Value = "false";

                    #endregion
                }
                #region Planes de Salud
                else
                {
                    if (isSave)
                        getDataFuneralAndHealth();
                    hdnCountAdditionalsInsured.Value = oTempDataAdditionalInsured.Count.ToString();
                    gvDependents.DataSource = oTempDataAdditionalInsured;
                    gvDependents.DataBind();
                }
                #endregion
            }
            else
                if (view == vAdditionalInsured)
                {
                    #region Planes funerarios

                    if (isSave)
                        getDataFuneralAndHealth();

                    hdnCountAdditionalsInsured.Value = oTempDataAdditionalInsured.Count.ToString();
                    gvAdditionalInsured.DataSource = oTempDataAdditionalInsured;
                    gvAdditionalInsured.DataBind();

                    if (isSave)
                        oTempDataAdditionalInsured = null;

                    #endregion
                }


            FillDataCitizenContact();

            udpDesignatedPensioner.Update();
        }

        public void getDataFuneralAndHealth()
        {
            var data =
                    ObjServices.oPolicyManager.GetPolicyAddInsured(new Entity.UnderWriting.Entities.Policy.
                        Parameter
                        {
                            CorpId = CorpId,
                            RegionId = RegionId,
                            CountryId = CountryId,
                            DomesticregId = DomesticregId,
                            StateProvId = StateProvId,
                            CityId = CityId,
                            OfficeId = OfficeId,
                            CaseSeqNo = CaseSeqNo,
                            HistSeqNo = HistSeqNo,
                            UnderwriterId = ObjServices.Agent_LoginId,
                            LanguageId = ObjServices.Language.ToInt()
                        });


            oTempDataAdditionalInsured = null;

            TempDataAdditionalInsured = new List<Entity.UnderWriting.Entities.Contact>();

            foreach (var x in data)
            {
                TempDataAdditionalInsured.Add(new Entity.UnderWriting.Entities.Contact
                {
                    ContactId = x.ContactId,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    FirstLastName = x.FirstLastName,
                    SecondLastName = x.SecondLastName,
                    Gender = x.Gender,
                    GenderDesc = x.GenderDesc,
                    Dob = x.Dob.HasValue ? x.Dob.Value : (DateTime?)null,
                    MaritalStatId = x.MaritalStatId,
                    Age = x.Dob.HasValue ? Utility.GetAge(x.Dob.Value) : (int?)null,
                    RelationshiptoOwner = x.RelationshiptoOwner,
                    RelationshiptoOwnerDesc = x.RelationshiptoOwnerDesc,
                    MaritalStatusDesc = x.MaritalStatusDesc,
                    Identification = x.Id
                });
            }

            oTempDataAdditionalInsured = TempDataAdditionalInsured;
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.Address item, Boolean isHome)
        {
            if (isHome)
            {
                txtHomeAddress.Text = item.StreetAddress;

                //Set Country and Fill States
                ddlHomeCountry.SelectedValue = item.CountryId.ToString();
                ddlCountry_SelectedIndexChanged(ddlHomeCountry, null);

                //Set State and Fill Cities
                var dbState = new Utility.StateProvince() { CorpId = item.CorpId, CountryId = item.CountryId, DomesticregId = item.DomesticregId, RegionId = item.RegionId, StateProvId = item.StateProvId };
                var x = Utility.serializeToJSON(dbState);
                ddlHomeState.SelectIndexByValueJSON(x);
                ddlStateProvince_SelectedIndexChanged(ddlHomeState, null);

                //Set City  
                ddlHomeCity.SelectedValue = item.CityId.ToString();
                txtHomePostalCode.Text = !string.IsNullOrEmpty(item.ZipCode) ? item.ZipCode : string.Empty;
            }
            else
            {
                txtBusinessAddress.Text = item.StreetAddress;

                //Set Country and Fill States
                ddlBusinessCountry.SelectedValue = item.CountryId.ToString();
                ddlCountry_SelectedIndexChanged(ddlBusinessCountry, null);

                //Set State and Fill Cities
                var dbState = new Utility.StateProvince()
                {
                    CorpId = item.CorpId,
                    CountryId = item.CountryId,
                    DomesticregId = item.DomesticregId,
                    RegionId = item.RegionId,
                    StateProvId = item.StateProvId
                };
                var x = Utility.serializeToJSON(dbState);

                ddlBusinessState.SelectIndexByValueJSON(x);

                ddlStateProvince_SelectedIndexChanged(ddlBusinessState, null);

                //Set City
                ddlBusinessCity.SelectedValue = item.CityId.ToString();

                txtBusinessPostalCode.Text = !string.IsNullOrEmpty(item.ZipCode) ? item.ZipCode : string.Empty;
            }

        }

        /// <summary>
        /// Questions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repeaterQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var RadioButton1 = e.Item.FindControl("rbYes");
            var label1 = e.Item.FindControl("lblYes") as System.Web.UI.HtmlControls.HtmlGenericControl;
            label1.Attributes.Add("for", RadioButton1.ClientID);

            var RadioButton2 = e.Item.FindControl("rbNo");
            var label2 = e.Item.FindControl("lblNo") as System.Web.UI.HtmlControls.HtmlGenericControl;
            label2.Attributes.Add("for", RadioButton2.ClientID);

            var data = e.Item.DataItem as Entity.UnderWriting.Entities.Contact.CitizenQuestion;
            //Llenar las respuestas
            if (data.CitizenQuestAnswer != null)
            {
                (RadioButton1 as RadioButton).Checked = data.CitizenQuestAnswer.Value;
                (RadioButton2 as RadioButton).Checked = !data.CitizenQuestAnswer.Value;
            }

            label1.InnerText = Resources.YesLabel;
            label2.InnerText = Resources.NoLabel;
        }

        private void AvailableDependentsView(string KeyNameProduct)
        {
            var ProductName = (Utility.ProductBehavior)Utility.getvalueFromEnumType(KeyNameProduct, typeof(Utility.ProductBehavior));
            //Viusalizar el grid de los dependientes
            pnDependents.Visible = ObjServices.GetProductLine(ProductName) == Utility.ProductLine.HealthInsurance;

            pnStudentStatus.Visible = pnDependents.Visible;
            pnDrops.CssClass = pnStudentStatus.Visible ? "grupos de_2" : "grupos de_1";
        }

        public void Initialize()
        { 
            ClearData();
            Operation = Utility.OperationType.Insert;
            btnAdd.Text = Resources.Add.Capitalize();
            FillDrop();
            FillData();
            FillDataCitizenContact();
            tbDesignatedPensionerInfo.ActiveTabIndex = 0;
            WUCPhoneNumber.Initialize(currentTab);
            WUCEmailAddress.Initialize(currentTab);

            AvailableDependentsView(ObjServices.KeyNameProduct);

            if (ObjServices.IsReadOnly || ObjServices.IsDataReviewMode && getisView)
                ReadOnlyControls(ObjServices.IsReadOnly);
        }

        public void ClearData(String value = "")
        {
            ClearData();
        }

        public void ClearData()
        {
            Utility.ClearAll(frmAdditionalsIndured.Controls);
            Operation = Utility.OperationType.Insert;
            hdnAge.Value = "";
            RowIndex = null;
            hdnOccupationGroupId.Value = "";
            hdnOccupationId.Value = "";
            oTempDataAdditionalInsured = null;
            oTempDataId = null;
            Session["TempDataAdditionalInsuredId"] = null;
            Utility.ClearAll(this.pnDesignatedPensionerOrAddicionalInsured.Controls);
            WUCEmailAddress.ClearData(currentTab);
            WUCPhoneNumber.ClearData(currentTab);
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);

            var targetDrop = (drop == ddlHomeCountry) ? ddlHomeState : ddlBusinessState;
            var targetCity = (drop == ddlHomeCountry) ? ddlHomeCity : ddlBusinessCity;
            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                ObjServices.GettingAllDrops(ref targetDrop,
                                        Utility.DropDownType.StateProvince,
                                       "StateProvDesc",
                                       "StateProvId",
                                        corpId: ObjServices.Corp_Id,
                                        countryId: int.Parse(drop.SelectedValue),
                                        GenerateItemSelect: true
                                       );
            }
            else
            {
                targetDrop.Items.Clear();
                targetCity.Items.Clear();
            }
        }

        protected void ddlStateProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);
            var targetDrop = (drop == ddlHomeState) ? ddlHomeCity : ddlBusinessCity;

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {

                var KeyStateProvince = Utility.deserializeJSON<Utility.StateProvince>(drop.SelectedValue);

                if (drop.SelectedIndex > 0)
                {
                    ObjServices.GettingAllDrops(ref targetDrop,
                                            Utility.DropDownType.City,
                                            "CityDesc",
                                            "CityId",
                                            stateProvId: KeyStateProvince.StateProvId,
                                            domesticregId: KeyStateProvince.DomesticregId,
                                            countryId: KeyStateProvince.CountryId,
                                            GenerateItemSelect: true
                                           );
                }

            }
            else
                targetDrop.Items.Clear();
        }

        protected void ASPxPageControl1_TabClick(object source, DevExpress.Web.TabControlCancelEventArgs e)
        {
            switch (e.Tab.Index)
            {
                case 0:
                    WUCPhoneNumber.FillData();
                    WUCPhoneNumber.UpdateUpdatePanel();
                    break;
                case 2:
                    WUCEmailAddress.FillData();
                    WUCEmailAddress.UpdateUpdatePanel();
                    break;
                case 3:
                case 1:
                    if (ObjServices.IsReadOnly || ObjServices.IsDataReviewMode && getisView)
                        Utility.ReadOnlyControls(tbDesignatedPensionerInfo.ActiveTabPage.Controls, ObjServices.IsReadOnly);
                    break;
            }
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            cbxRelationshipwithinsured.Enabled = !isReadOnly;
            Utility.ReadOnlyControls(frmDesignatedPensioner.Controls, isReadOnly);
            WUCPhoneNumber.ReadOnlyControls(isReadOnly);
            WUCEmailAddress.ReadOnlyControls(isReadOnly);
        }

        public bool AllowAdd()
        {
            var result = true;
            var CountAdditionalsInsured = hdnCountAdditionalsInsured.Value.ToInt();
            result = !(CountAdditionalsInsured >= 5 && Operation == Utility.OperationType.Insert);
            return result;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AllowAdd())
            {
                this.MessageBox(Resources.AdditionalInsuredValidationFunerario, Title: Resources.Warning);
                return;
            }
            //Guardar el familiar incluido
            save();
        }

        protected void gvAdditionalInsured_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            SetVariables();
            var isSave = ObjServices.isSavePlan;

            var Commando = e.CommandArgs.CommandName;
            RowIndex = e.VisibleIndex;
            var GridView = (sender as DevExpress.Web.ASPxGridView);
            var ContactId = int.Parse(GridView.GetKeyFromAspxGridView("ContactId", RowIndex.Value).ToString());
            hdnContactIdGrid.Value = ContactId.ToString();

            switch (Commando)
            {
                case "Modify":
                    //Cargar los datos                    
                    if (isSave)
                    {
                        if (ObjServices.ProductLine == Utility.ProductLine.Funeral)
                        {
                            var dataInfo = ObjServices.GetContact(ContactId);
                            TFirstName.Text = dataInfo.FirstName;
                            TMiddleName.Text = dataInfo.MiddleName;
                            TFirstLastName.Text = dataInfo.FirstLastName;
                            TSecondLastName.Text = dataInfo.SecondLastName;
                            cbxGender.SelectedValue = !string.IsNullOrEmpty(dataInfo.Gender) ? dataInfo.Gender
                                                                                             : "-1";
                            if (dataInfo.MaritalStatId.HasValue)
                                ddl_WUC_PI_MaritalStatus.SelectIndexByValue(dataInfo.MaritalStatId.ToString(), true);

                            TDateOfBirth.Text = !dataInfo.Dob.HasValue ? string.Empty
                                                                       : dataInfo.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                            if (dataInfo.RelationshiptoOwner.HasValue)
                            {
                                for (int i = 1; i < cbxRelationship.Items.Count; i++)
                                {
                                    var RelationID = Utility.deserializeJSON<Utility.itemRelationship>(cbxRelationship.Items[i].Value).RelationshipId;

                                    if (RelationID == dataInfo.RelationshiptoOwner)
                                    {
                                        cbxRelationship.SelectedIndex = i;
                                        break;
                                    }
                                }
                            }

                            var IdDataItem = ObjServices.oContactManager.GetAllIdDocumentInformation(ContactId, ObjServices.Language.ToInt()).LastOrDefault();

                            if (IdDataItem != null)
                                TIdentification.Text = IdDataItem.Id;
                        }
                        else
                        {
                            ObjServices.ContactEntityID = ContactId;
                            LoadData();
                        }

                    }
                    else
                    {
                        //Buscar en la Lista temp
                        var dataInfo = oTempDataAdditionalInsured.ElementAt(RowIndex.Value);
                        TFirstName.Text = dataInfo.FirstName;
                        TMiddleName.Text = dataInfo.MiddleName;
                        TFirstLastName.Text = dataInfo.FirstLastName;
                        TSecondLastName.Text = dataInfo.SecondLastName;
                        cbxGender.SelectedValue = !string.IsNullOrEmpty(dataInfo.Gender) ? dataInfo.Gender
                                                                                         : "-1";

                        if (dataInfo.MaritalStatId.HasValue)
                            ddl_WUC_PI_MaritalStatus.SelectIndexByValue(dataInfo.MaritalStatId.ToString(), true);

                        TDateOfBirth.Text = !dataInfo.Dob.HasValue ? string.Empty
                                                                   : dataInfo.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

                        for (int i = 1; i < cbxRelationship.Items.Count; i++)
                        {
                            var RelationID = Utility.deserializeJSON<Utility.itemRelationship>(cbxRelationship.Items[i].Value).RelationshipId;
                            if (RelationID == dataInfo.RelationshiptoOwner)
                            {
                                cbxRelationship.SelectedIndex = i;
                                break;
                            }
                        }

                        if (oTempDataId != null && oTempDataId.Any())
                        {
                            var recordId = oTempDataId.ElementAt(RowIndex.Value);
                            TIdentification.Text = recordId.Id;
                        }
                    }

                    Operation = Utility.OperationType.Edit;
                    btnAdd.Text = Resources.Save.Capitalize();
                    this.ExcecuteJScript("$('#bodyContent_PlanPolicyContainer_WUCDesignatedPensionerInformation_btnAdd').val('" + btnAdd.Text + "');");

                    break;
                case "Delete":

                    if (isSave || (ObjServices.ProductLine == Utility.ProductLine.HealthInsurance))
                    {
                        ObjServices.saveSetValidTab(Utility.Tab.HealthDeclaration, false);

                        ObjServices.oHealthDeclarationManager.DeleteAllQuestionnaire(new Entity.UnderWriting.Entities.Questionnaire()
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
                            ContactId = ContactId,
                            ContactRoleTypeId = this.ContactRoleTypeID,
                            UserId = ObjServices.UserID.Value
                        });

                        //Eliminar                            
                        ObjServices.oPolicyManager.DeleteContactRole(ObjServices.Corp_Id,
                                                                     ObjServices.Region_Id,
                                                                     ObjServices.Country_Id,
                                                                     ObjServices.Domesticreg_Id,
                                                                     ObjServices.State_Prov_Id,
                                                                     ObjServices.City_Id,
                                                                     ObjServices.Office_Id,
                                                                     ObjServices.Case_Seq_No,
                                                                     ObjServices.Hist_Seq_No,
                                                                     ContactId,
                                                                     this.ContactRoleTypeID,
                                                                     ObjServices.UserID.Value
                                                                    );
                    }
                    else
                    {
                        oTempDataAdditionalInsured.RemoveAt(RowIndex.Value);
                        oTempDataId.RemoveAt(RowIndex.Value);
                    }

                    //Llenar Data
                    FillData();
                    break;
            }

            udpDesignatedPensioner.Update();
        }

        protected void repeaterQuestion_PreRender(object sender, EventArgs e)
        {
            //Questions
            var Questions = ObjServices.GetContactCitizenQuestionByContact();
            repeaterQuestion.DataSource = Questions.Where(x => x.NameKey != "ISCLIENTPEP"); ;
            repeaterQuestion.DataBind();
        }

        protected void tbDesignatedPensionerInfo_PreRender(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");
            (bodyContent.FindControl("hdnShowPopClientInfoSearch") as HiddenField).Value = "true";
            var WUCSearchClientOrOwner = bodyContent.FindControl("popSearchClientOrOwner").FindControl("WUCSearchClientOrOwner");

            if (WUCSearchClientOrOwner != null)
            {
                var ohdnKeyNameProduct = WUCSearchClientOrOwner.FindControl("hdnKeyNameProduct");

                if (!ohdnKeyNameProduct.isNullReferenceControl())
                    (ohdnKeyNameProduct as HiddenField).Value = ObjServices.KeyNameProduct;

                var oWUCSearchClientOrOwner = (NewBusiness.UserControls.AddNewClient.Common.WUCSearchClientOrOwner)WUCSearchClientOrOwner;
                oWUCSearchClientOrOwner.ContactTypeID = Utility.ContactTypeId.Contact.ToInt();
                oWUCSearchClientOrOwner.Initialize();
                var udpAddNewClient = bodyContent.FindControl("udpAddNewClient");
                if (udpAddNewClient != null)
                    (udpAddNewClient as UpdatePanel).Update();
            }

        }

        private void SetBirthCetificate()
        {
            if (cbxIDType.SelectedValue == "6")
                txtExpirationDate.Attributes.Remove("validation");
            else
                txtExpirationDate.Attributes.Add("validation", "Required");

        }

        protected void chkCopyHomeAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCopyHomeAddress.Checked) return;

            if (((ddlHomeCountry.SelectedValue == "-1" || ddlHomeCountry.SelectedValue == "") ||
                    (ddlHomeState.SelectedValue == "-1" || ddlHomeState.SelectedValue == "") ||
                    (ddlHomeCity.SelectedValue == "-1" || ddlHomeCity.SelectedValue == "") ||
                    string.IsNullOrWhiteSpace(txtHomeAddress.Text)) && chkCopyHomeAddress.Checked)
            {
                JSTools.MessageBox(this, RESOURCE.UnderWriting.NewBussiness.Resources.CompleteHomeAddressWarning, Title: Resources.Warning);
                chkCopyHomeAddress.Checked = false;
            }
            else
            {

                //Copiar
                ddlBusinessCountry.SelectIndexByValue(chkCopyHomeAddress.Checked ? ddlHomeCountry.SelectedValue : "-1");
                ddlCountry_SelectedIndexChanged(ddlBusinessCountry, null);
                ddlBusinessState.SelectIndexByValue(chkCopyHomeAddress.Checked ? ddlHomeState.SelectedValue : "-1");
                ddlStateProvince_SelectedIndexChanged(ddlBusinessState, null);
                ddlBusinessCity.SelectIndexByValue(chkCopyHomeAddress.Checked ? ddlHomeCity.SelectedValue : "-1");

                txtBusinessAddress.Text = chkCopyHomeAddress.Checked ? txtHomeAddress.Text : string.Empty;
                txtBusinessPostalCode.Text = chkCopyHomeAddress.Checked ? txtHomePostalCode.Text : string.Empty;

                hdnClickBussinessAddress.Value = "true";

            }
        }

        protected void cbxIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idtype = int.Parse(cbxIDType.SelectedValue);

            if (idtype == 5 ||
               idtype == 6 ||
               idtype == 7 ||
               idtype == 9)
            {
                txtExpirationDate.Enabled = false;
                txtExpirationDate.Attributes.Remove("validation");
            }
            else
            {
                if (idtype == 1)
                {
                    txtIDNumber.Attributes.Add("data-inputmask", "'mask': '999-9999999-9','clearMaskOnLostFocus': true,'showTooltip': true");
                }
                else
                {
                    txtIDNumber.Attributes.Remove("data-inputmask");
                }

                txtExpirationDate.Attributes.Add("validation", "Required");
                txtExpirationDate.Enabled = true;
            } 

            SetBirthCetificate();
        }

        protected void btnRefreshView_Click(object sender, EventArgs e)
        {
            ltTitleDesignatedPensionerOrAdditionalInsured.Text = Resources.ADDITIONALINFORMATIONINCLUDINGFAMILY;
            pnAdditionalInsured.Enabled = false;
            isRefesh.Value = "false";
            ChangeView(1);
            SetVariables();
            FillData();
        }

        private bool ValidateDependent()
        {
            var result = true;

            int? Age = null;
            var isY = false;

            //Validaciones 
            var RelationShipID = cbxRelationshipwithinsured.SelectedValue.ToInt();
            var RelationShipDesc = cbxRelationshipwithinsured.SelectedItem.Text;

            var Conyugue = (RelationShipID == 1 || RelationShipID == 2 || RelationShipID == 256);
            var HijoHija = (RelationShipID == 5 || RelationShipID == 6);
            var EstudianteAtiempoCompleto = (ddlStudentStatus.SelectedValue == "1");

            var Dob = txtDateOfBirthDesignatedPensioner.ToDateTime();
            Utility.SetContactAge(Dob, ref Age, ref isY);
            var productSelect = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));

            //Validacion de la edad para los planes de Vida
            switch (productSelect)
            {
                case Utility.ProductBehavior.Elite:
                case Utility.ProductBehavior.Select:
                case Utility.ProductBehavior.Fortis:
                    #region validaciones
                    //Validacion de la edad del Conyuge                            
                    if (Conyugue)
                    {
                        if (isY)
                        {
                            if (!(Age >= 18 && Age <= 74))
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "74"));
                                result = false;
                            }
                        }
                        else
                        {
                            this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "74"));
                            result = false;
                        }
                    }

                    //Validacion de la edad de la edad de el / los hijo(s)
                    if (HijoHija)
                    {
                        if (!EstudianteAtiempoCompleto)
                        {
                            if (isY)
                            {   //Ya cumplio al menos un año
                                if (!(Age >= 1 && Age <= 17))
                                {
                                    this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "0", "17"));
                                    result = false;
                                }
                            }
                            else
                            {
                                if (!(Age >= 0 && Age <= 17))
                                {
                                    this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "0", "17"));
                                    result = false;
                                }
                            }
                        }
                        else
                        {
                            //Validacion para un hijo o hija que sea estudiante a tiempo completo

                            if (isY)
                            {   //Ya cumplio al menos un año
                                if (!(Age >= 18 && Age <= 24))
                                {
                                    this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "24"));
                                    result = false;
                                }
                            }
                            else
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "24"));
                                result = false;
                            }
                        }
                    }
                    #endregion
                    break;
                case Utility.ProductBehavior.Serenity:
                    #region validaciones
                    //Validacion de la edad del Conyuge                            
                    if (Conyugue)
                    {
                        if (isY)
                        {
                            if (!(Age >= 18 && Age <= 65))
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "65"));
                                result = false;
                            }
                        }
                        else
                        {
                            this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "65"));
                            result = false;
                        }
                    }

                    //Validacion de la edad de la edad de el / los hijo(s)
                    if (HijoHija)
                    {
                        if (!EstudianteAtiempoCompleto)
                        {
                            if (isY)
                            {   //Ya cumplio al menos un año
                                if (!(Age >= 1 && Age <= 17))
                                {
                                    this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "0", "17"));
                                    result = false;
                                }
                            }
                            else
                            {
                                if (!(Age >= 0 && Age <= 17))
                                {
                                    this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "0", "17"));
                                    result = false;
                                }
                            }
                        }
                        else
                        {
                            //Validacion para un hijo o hija que sea estudiante a tiempo completo 
                            if (isY)
                            {   //Ya cumplio al menos un año
                                if (!(Age >= 18 && Age <= 24))
                                {
                                    this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "24"));
                                    result = false;
                                }
                            }
                            else
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "24"));
                                result = false;
                            }
                        }
                    }
                    #endregion
                    break;
                case Utility.ProductBehavior.Asistencia90dias:
                case Utility.ProductBehavior.Asistencia30dias:
                case Utility.ProductBehavior.Asistencia60dias:
                    #region validaciones
                    //Validacion de la edad del Conyuge                            
                    if (Conyugue)
                    {
                        if (isY)
                        {
                            if (!(Age >= 18 && Age <= 70))
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "70"));
                                result = false;
                            }
                        }
                        else
                        {
                            this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "18", "70"));
                            result = false;
                        }
                    }

                    if (HijoHija)
                    {
                        if (isY)
                        {   //Ya cumplio al menos un año
                            if (!(Age >= 1 && Age <= 17))
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "0", "17"));
                                result = false;
                            }
                        }
                        else
                        {
                            if (!(Age >= 0 && Age <= 17))
                            {
                                this.MessageBox(string.Format(Resources.AgeValidationMessage, RelationShipDesc, "0", "17"));
                                result = false;
                            }
                        }
                    }
                    #endregion
                    break;
                default:
                    break;
            }

            return result;
        }

        protected void btnAddDependent_Click(object sender, EventArgs e)
        {
            if (ValidateDependent())
            {
                save();
                ObjServices.ContactEntityID = -1;
                ClearData();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void LoadData()
        {
            //Questions                    
            var Questions = ObjServices.GetContactCitizenQuestionByContact();

            repeaterQuestion.DataSource = Questions.Where(x => x.NameKey != "ISCLIENTPEP"); ;
            repeaterQuestion.DataBind();

            //Personal Information
            var dataInfo = ObjServices.GetContact(ObjServices.ContactEntityID.Value);

            if (dataInfo != null)
            {
                txtFirstName.Text = dataInfo.FirstName;
                txtMidleName.Text = dataInfo.MiddleName;
                txtLastName.Text = dataInfo.FirstLastName;
                txt2ndLastName.Text = dataInfo.SecondLastName;
                ddlGender.SelectIndexByValue(!string.IsNullOrEmpty(dataInfo.Gender) ? dataInfo.Gender : "-1");
                txtDateOfBirthDesignatedPensioner.Text = !dataInfo.Dob.HasValue ? "" : dataInfo.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                hdnAge.Value = !dataInfo.Age.HasValue ? "" : dataInfo.Age.Value.ToString();
                ddlSmoker.SelectIndexByValue(!dataInfo.Smoker.HasValue ? "-1" : (dataInfo.Smoker.Value ? "1" : "0"));
                ddlMaritalStatus.SelectIndexByValue(dataInfo.MaritalStatId.ToString());

                if (dataInfo.OccupGroupTypeId.HasValue)
                {
                    txtOccupation.Text = dataInfo.Occupation_Desc;
                    hdnOccupationGroupId.Value = dataInfo.OccupGroupTypeId.Value.ToString();
                }

                if (dataInfo.OccupationId.HasValue)
                {
                    txtProfession.Text = dataInfo.Occupation_Group_Desc;
                    hdnOccupationId.Value = dataInfo.OccupationId.Value.ToString();
                }

                ddlStudentStatus.SelectIndexByValue(ObjServices.ProductLine == Utility.ProductLine.HealthInsurance ? dataInfo.StudentStatusId.HasValue? dataInfo.StudentStatusId.Value.ToString()
                                                                                                                                                      : string.Empty     
                                                                                                                   : string.Empty, true);
                tb_WUC_PI_PersonalIncome.Text = dataInfo.AnnualPersonalIncome.ToString();
                tb_WUC_PI_YearLyFamilyIncome.Text = dataInfo.AnnualFamilyIncome.ToString();
                txtCompanyName.Text = dataInfo.CompanyName;
                txtFirstLineOfBusiness.Text = dataInfo.LineOfBusiness;
                txtSecondLineOfBusiness.Text = dataInfo.LineOfBusiness2;
                txtTaskPerformed.Text = dataInfo.LaborTasks;
                ddlLengthWorkFrom.SelectIndexByValue(dataInfo.LengthWorkYear.HasValue ? dataInfo.LengthWorkYear.Value.ToString() : string.Empty, true);
                ddlLengthWorkTo.SelectIndexByValue(dataInfo.LengthWorkMonth.HasValue ? dataInfo.LengthWorkMonth.Value.ToString() : string.Empty, true);

                if (dataInfo.RelationshiptoOwner.HasValue)
                {
                    cbxRelationshipwithinsured.SelectIndexByValue(dataInfo.RelationshiptoOwner.Value.ToString(), true);
                    cbxRelationshipwithinsured_SelectedIndexChanged(cbxRelationshipwithinsured, null);
                }

                var IdDataItem = ObjServices.GetAllIdDocumentInformation().LastOrDefault();

                if (IdDataItem != null)
                {
                    cbxIDType.SelectIndexByValue(IdDataItem.ContactIdType.ToString());
                    cbxIssuedBy.SelectIndexByValue(IdDataItem.CountryIssuedBy.ToString());
                    txtIDNumber.Text = IdDataItem.Id;
                    txtExpirationDate.Text = string.Format("{0:MM/dd/yyyy}", IdDataItem.ExpireDate);
                }

                //Cargar Address
                var dataAddress = ObjServices.GetCommunicatonAdress();

                if (dataAddress.Any())
                {
                    var homeAddress = dataAddress.Where(r => r.DirectoryTypeId == 5).OrderBy(r => r.DirectoryId).FirstOrDefault();
                    var businessAddress = dataAddress.Where(r => r.DirectoryTypeId == 4).OrderBy(r => r.DirectoryId).FirstOrDefault();

                    if (dataAddress.Any())
                    {
                        if (homeAddress != null)
                            setDataForm(homeAddress, true);

                        if (businessAddress != null)
                            setDataForm(businessAddress, false);
                    }
                }

                //Cargar telefonos
                WUCPhoneNumber.FillData();
                //Cargar correos
                WUCEmailAddress.FillData(); 

            }
            else hdnValidateFormDesignatedPensionerOrAddicionalInsured.Value = "false";
        }

        protected void cbxRelationshipwithinsured_PreRender(object sender, EventArgs e)
        {
            //Definir si hara autoPostBack
            ((DropDownList)sender).AutoPostBack = ObjServices.ProductLine == Utility.ProductLine.HealthInsurance;
        }

        protected void cbxRelationshipwithinsured_SelectedIndexChanged(object sender, EventArgs e)
        {
            var RelationShipID = ((DropDownList)sender).SelectedValue.ToInt();
            pnIncomeInformation.Visible = (RelationShipID == 1 || RelationShipID == 2 || RelationShipID == 256);
        }


        #region Code Form PEPS

        protected void gvCitizenContact_Designated_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;
            RowIndex = e.VisibleIndex;
            var GridView = (sender as DevExpress.Web.ASPxGridView);
            GridView.Selection.UnselectAll();

            switch (Commando)
            {
                case "Modify":
                    //Editar
                    Operation = Utility.OperationType.Edit;
                    setDataForm(oTemDataCitizenContact.ElementAt(RowIndex.Value));
                    gvCitizenContact_Designated.FocusedRowIndex = -1;
                    BtnAddPolitical.Text = RESOURCE.UnderWriting.NewBussiness.Resources.Save;
                    break;
                case "Delete":
                    //Eliminar           
                    if ((ObjServices.isNewCase || ObjServices.ContactEntityID < 0) &&
                        !ObjServices.IsDataSearch)
                        oTemDataCitizenContact.RemoveAt(RowIndex.Value);
                    else
                    {
                        var ExposureRelatedId = int.Parse(gvCitizenContact_Designated.GetKeyFromAspxGridView("Exposure_Related_Id", RowIndex.Value).ToString());

                        Entity.UnderWriting.Entities.Contact.CitizenContact param = new Entity.UnderWriting.Entities.Contact.CitizenContact
                        {
                            Corp_Id = ObjServices.Corp_Id,
                            Region_Id = ObjServices.Region_Id,
                            Country_Id = ObjServices.Country_Id,
                            Domesticreg_Id = ObjServices.Domesticreg_Id,
                            State_Prov_Id = ObjServices.State_Prov_Id,
                            City_Id = ObjServices.City_Id,
                            Office_Id = ObjServices.Office_Id,
                            Case_Seq_No = ObjServices.Case_Seq_No,
                            Hist_Seq_No = ObjServices.Hist_Seq_No,
                            Contact_Id = ObjServices.Contact_Id,
                            Exposure_Related_Id = ExposureRelatedId
                        };

                        ObjServices.oContactManager.DeleteCitizenContact(param);
                    }

                    //Llenar Data
                    FillDataCitizenContact();
                    break;
            }
        }

        protected void gvCitizenContact_Designated_PageIndexChanged(object sender, EventArgs e)
        {
            FillDataCitizenContact();
        }

        protected void BtnAddPolitical_Click(object sender, EventArgs e)
        {
            saveCitizenContact();
        }

        public void edit()
        {
            var record = oTemDataCitizenContact.ElementAt(RowIndex.Value);
            record.FullName = txtFullName_Designated.Text;
            record.Relationship = int.Parse(ddlRelationship_Designated.SelectedValue);
            record.Position = txtPosition_Designated.Text;
            record.JobFromDate = DateTime.Parse(txtFrom_Designated.Text);
            record.JobToDate = DateTime.Parse(txtTo_Designated.Text);
        }

        protected void udpDelete_Designated_Unload(object sender, EventArgs e)
        {

        }

        #region TempData
        public List<Entity.UnderWriting.Entities.Contact.CitizenContact> TempDataCitizenContact = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>();
        #endregion

        public String PrefixSession
        {
            get { return hdnCurrentSession.Value; }
            set { hdnCurrentSession.Value = value; }
        }

        /// <summary>
        /// Bindear el grid
        /// </summary>
        public void FillDataCitizenContact()
        {

            if (ObjServices.ContactEntityID > 0)
            {
                SetVariables();
                oTemDataCitizenContact = null;

                Entity.UnderWriting.Entities.Contact.CitizenContact param = new Entity.UnderWriting.Entities.Contact.CitizenContact
                {
                    Corp_Id = ObjServices.Corp_Id,
                    Region_Id = ObjServices.Region_Id,
                    Country_Id = ObjServices.Country_Id,
                    Domesticreg_Id = ObjServices.Domesticreg_Id,
                    State_Prov_Id = ObjServices.State_Prov_Id,
                    City_Id = ObjServices.City_Id,
                    Office_Id = ObjServices.Office_Id,
                    Case_Seq_No = ObjServices.Case_Seq_No,
                    Hist_Seq_No = ObjServices.Hist_Seq_No,
                    Contact_Id = (int)ObjServices.ContactEntityID,
                    Language_id = ObjServices.getCurrentLanguage()
                };


                oTemDataCitizenContact = ObjServices.GetAllCitizenContact(param);
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




            if (!ObjServices.isNewCase)
            {
                if (!data.Any())
                {
                    if (currentTab == "ClientInfo" || currentTab == "OwnerInfo")
                    {
                        Utility.Tab Tab = (currentTab == "ClientInfo") ? Utility.Tab.ClientInfo : Utility.Tab.OwnerInfo;
                        ObjServices.saveSetValidTab(Tab, false);
                    }
                }
            }

            gvCitizenContact_Designated.DataSource = data;
            gvCitizenContact_Designated.DataBind();
            gvCitizenContact_Designated.Selection.UnselectAll();
            oTemDataCitizenContact = null;
            //udpBackgroundInformation.Update();
        }

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

        public void setDataForm(Entity.UnderWriting.Entities.Contact.CitizenContact item)
        {
            txtFullName_Designated.Text = item.FullName;
            ddlRelationship_Designated.SelectedValue = item.Relationship.ToString();
            txtPosition_Designated.Text = item.Position;
            txtFrom_Designated.Text = item.JobFromDate.ToString();
            txtTo_Designated.Text = item.JobToDate.ToString();
        }

        public void saveCitizenContact()
        {
            Entity.UnderWriting.Entities.Contact.CitizenContact item = null;

            var record = new Entity.UnderWriting.Entities.Contact.CitizenContact();

            if (Operation == Utility.OperationType.Edit)
                record = oTemDataCitizenContact.ElementAt(RowIndex.Value);

            //Agregar un item
            item = new Entity.UnderWriting.Entities.Contact.CitizenContact()
            {
                Exposure_Related_Id = (Operation == Utility.OperationType.Edit) ? record.Exposure_Related_Id : null,
                Corp_Id = ObjServices.Corp_Id,
                Region_Id = ObjServices.Region_Id,
                Country_Id = ObjServices.Country_Id,
                Domesticreg_Id = ObjServices.Domesticreg_Id,
                State_Prov_Id = ObjServices.State_Prov_Id,
                City_Id = ObjServices.City_Id,
                Office_Id = ObjServices.Office_Id,
                Case_Seq_No = ObjServices.Case_Seq_No,
                Hist_Seq_No = ObjServices.Hist_Seq_No,
                Contact_Id = (int)ObjServices.ContactEntityID,
                FullName = txtFullName_Designated.Text,
                Relationship = int.Parse(ddlRelationship_Designated.SelectedValue),
                RelationshipDesc = ddlRelationship_Designated.SelectedItem.Text,
                Position = txtPosition_Designated.Text,
                JobFromDate = !string.IsNullOrEmpty(txtFrom_Designated.Text) ? txtFrom_Designated.Text.ParseFormat() : (DateTime?)null,
                JobToDate = !string.IsNullOrEmpty(txtTo_Designated.Text) ? txtTo_Designated.Text.ParseFormat() : (DateTime?)null,
                CreateUser = (Operation == Utility.OperationType.Insert) ? ObjServices.UserID.Value : record.CreateUser,
                ModifyUser = (Operation == Utility.OperationType.Edit) ? ObjServices.UserID.Value : record.ModifyUser

            };

            //Si es un nuevo caso  guardar en lista temporal
            if ((ObjServices.isNewCase && !ObjServices.IsDataSearch) || ObjServices.ContactEntityID < 0)
            {
                if (Operation == Utility.OperationType.Insert)
                {
                    if (oTemDataCitizenContact.RecordExistInList(x => x.FullName == txtFullName_Designated.Text))
                    {
                        this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.CitizenContactAlreadyExist + "',null, null, true, 'Warning')");
                        return;
                    }

                    TempDataCitizenContact.Add(item);
                }
                else
                    if (Operation == Utility.OperationType.Edit)
                    {
                        List<Entity.UnderWriting.Entities.Contact.CitizenContact> oTemDataCitizenContactEdit;
                        oTemDataCitizenContactEdit = new List<Entity.UnderWriting.Entities.Contact.CitizenContact>(oTemDataCitizenContact);
                        oTemDataCitizenContactEdit.RemoveAt(RowIndex.Value);

                        if (oTemDataCitizenContactEdit.RecordExistInList(x => x.FullName == txtFullName_Designated.Text))
                        {
                            this.ExcecuteJScript("CustomDialogMessageEx('" + RESOURCE.UnderWriting.NewBussiness.Resources.CitizenContactAlreadyExist + "',null, null, true, 'Warning')");
                            return;
                        }

                        edit();
                    }

                oTemDataCitizenContact = TempDataCitizenContact;

            }
            else
            {   //Guardar directamente en la base de datos tanto si es un insert como un edit
                if (Operation == Utility.OperationType.Insert || Operation == Utility.OperationType.Edit)
                {
                    oTemDataCitizenContact = null;
                    TempDataCitizenContact.Add(item);
                    oTemDataCitizenContact = TempDataCitizenContact;

                    ObjServices.SetCitizenContact(oTemDataCitizenContact);
                    oTemDataCitizenContact = null; 

                    if (Operation == Utility.OperationType.Insert)
                        //ir a la ultima pagina
                        gvCitizenContact_Designated.PageIndex = (gvCitizenContact_Designated.PageCount - 1);
                }
            }
            //}


            btnAdd.Text = RESOURCE.UnderWriting.NewBussiness.Resources.Add;
            //Bindear el grid
            FillDataCitizenContact();

            //Limpiar los controles a excepcion del grid
            //ClearControls(gvCitizenContact); 
            txtFullName_Designated.Text = string.Empty;
            ddlRelationship_Designated.SelectedIndex = -1;
            txtPosition_Designated.Text = string.Empty;
            txtFrom_Designated.Text = string.Empty;
            txtTo_Designated.Text = string.Empty;

            Operation = Utility.OperationType.Insert;
        }


        #endregion
    }

}