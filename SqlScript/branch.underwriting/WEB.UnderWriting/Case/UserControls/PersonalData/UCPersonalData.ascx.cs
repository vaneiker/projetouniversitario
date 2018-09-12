using Entity.UnderWriting.Entities;
using PdfViewer4AspNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
//wcastro 21-03-2017
using System.Globalization;
//fin wcastro

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class UCPersonalData : UC, IUC
    {
        Contact _contact;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            this.pdfViewerPersonalData.LicenseKey = Service.PdfViewerKey;
            lblRelationshipToOwner.Text = RoleDDL.SelectedItem == null ? "RELATIONSHIP TO INSURED:" :
                RoleDDL.SelectedItem.Text.Trim().ToLower() == "owner" ? "RELATIONSHIP TO INSURED:" : "RELATIONSHIP TO OWNER:";
        }

        void IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This Method Save Personal Data Information  
        /// </summary>
        public void save()
        {
            var contactToSave = new Entity.UnderWriting.Entities.Contact
            {
                ContactId = Service.Contact_Id,
                FirstName = this.FirstNameTxt.Text,
                FirstLastName = this.LastNameTxt.Text,
                SecondLastName = this.SecondLastNameTxt.Text,
                MiddleName = this.MiddleTxt.Text,
                Dob = Convert.ToDateTime(this.DOBTxt.Text),
                Age = Convert.ToInt32(this.AgeTxt.Text),
                NearAge = Convert.ToInt32(this.NearAgeTxt.Text),
                Smoker = Convert.ToBoolean(Convert.ToInt32(this.SmokerDDL.SelectedValue)),
                Gender = this.GenderDDL.SelectedValue,
                MaritalStatId = Convert.ToInt32(this.MaritalStatusDDL.SelectedValue)
            };

            var aCity = this.CityOfResidenceDDL.SelectedValue.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            //mavelar 6/4/17
            if (Service.RoleTypeId == 1)
            {
                contactToSave.InstitutionalName = txtInstitutionalNameUpdate.Text;
                contactToSave.Dob = Convert.ToDateTime(DOBTxt.Text);
            }
            //fin mavelar 6/4/17

            contactToSave.RegionOfResidenceId = int.Parse(aCity[0]);
            contactToSave.CountryOfResidenceId = (!string.IsNullOrEmpty(this.CountryOfResidenceDDL.SelectedValue) ? Convert.ToInt32(this.CountryOfResidenceDDL.SelectedValue) : 0);
            contactToSave.DomesticRegOfResidenceId = int.Parse(aCity[2]);
            contactToSave.StateOfResidenceId = int.Parse(aCity[3]);
            contactToSave.CityOfResidenceId = int.Parse(aCity[4]);

            contactToSave.CountryOfBirthId = (!string.IsNullOrEmpty(this.CountryOfBirthDDL.SelectedValue) ? Convert.ToInt32(this.CountryOfBirthDDL.SelectedValue) : 0);

            contactToSave.ContactIdType = Convert.ToInt32(this.IdtypeDDL.SelectedValue);
            contactToSave.Id = this.idTxt.Text;

            contactToSave.ExpireDate = this.IdExpirationDateTxt.Text.IsDateReturnNull();
            contactToSave.CountryIssuedBy = (!string.IsNullOrEmpty(this.IssuedByDDL.SelectedValue) ? Convert.ToInt32(this.IssuedByDDL.SelectedValue) : 0);
            contactToSave.ModifyUser = 1;
            contactToSave.SeqNo = Service.ContactSeq_No;
            contactToSave.RelationshiptoAgent = (!string.IsNullOrEmpty(RelationshipToAgentDDL.SelectedValue) ? Convert.ToInt32(RelationshipToAgentDDL.SelectedValue) : 0);
            contactToSave.RelationshiptoOwner = (!string.IsNullOrEmpty(RelationshipOwnerDDL.SelectedValue) ? Convert.ToInt32(RelationshipOwnerDDL.SelectedValue) : 0);

            //Key
            contactToSave.PolicyInfo = new Entity.UnderWriting.Entities.Contact.PolicyContact()
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
                ContactRoleTypeId = Service.IsOwner ? 1 : Service.RoleTypeId,
                UserId = Service.Underwriter_Id
            };

            Services.ContactManager.UpdateContact(contactToSave);
            Services.PolicyManager.UpdatePersonalInfoContact(contactToSave);

            var left = Page.Master.FindControl("Left").FindControl("Left") as Common.Left;
            left.FillData();
        }

        void IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void IUC.edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {

        }

        public Contact FillRolesDdl()
        {
            var ddlRoleData = Service.DropDowns.GetDropDown(DropDownType.Summary,
                                                            Service.Corp_Id,
                                                            Service.Region_Id,
                                                            Service.Country_Id,
                                                            Service.Domesticreg_Id,
                                                            Service.State_Prov_Id,
                                                            Service.City_Id,
                                                            Service.Office_Id,
                                                            Service.Case_Seq_No,
                                                            Service.Hist_Seq_No,
                                                            Service.Contact_Id,
                                                            projectId: Service.ProjectId,
                                                            companyId: Service.CompanyId,
                                                            languageId: Service.LanguageId).OrderBy(r => int.Parse(r.Value.Split('|')[1]));

            if (ddlRoleData.Count() < 2)
            {
                Service.IsOwner = true;
            }

            RoleDDL.DataSource = ddlRoleData;
            RoleDDL.DataTextField = "Text";
            RoleDDL.DataValueField = "Value";
            RoleDDL.DataBind();

            Service.Contact_Id = Convert.ToInt32(RoleDDL.SelectedValue.Split('|')[0]);
            Service.RoleTypeId = Convert.ToInt32(RoleDDL.SelectedValue.Split('|')[1]);

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
                                                             Service.LanguageId);

            return contact;
        }

        public void FillData(Contact contactData)
        {
            _contact = contactData;

            //Limpiando controles de abajo
            ((UCAddresses)Parent.FindControl("UCAddresses1")).EmptyAddressControls();
            ((UCEmailPhone)Parent.FindControl("UCEmailPhone1")).EmptyEmailControls();
            ((UCEmailPhone)Parent.FindControl("UCEmailPhone1")).EmptyPhoneControls();

            GetPersonalData();
            GetCompanyInformation();
        }

        /// <summary>
        /// This Method Save the Citizenship country   
        /// </summary>
        public void InsertCitizenCountry(Object sender, EventArgs e)
        {

            var data = Services.ContactManager.GetContactCitizenshipByContact(Service.Contact_Id);

            if (data.Any(r => r.GlobalCountryId == Convert.ToInt32(this.CountryOfCitizenShipDDL.SelectedValue)))
            {
                string message = "This Country is already added to the list, please choose another Country and try again.";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Add Citizenship');", true);
                return;
            }

            Services.ContactManager.InsertContactCitizenship(new Entity.UnderWriting.Entities.Contact.Citizenship
            {
                ContactId = Service.Contact_Id,
                GlobalCountryId = Convert.ToInt32(this.CountryOfCitizenShipDDL.SelectedValue),
                CreateUser = 1,
                ModifyUser = 1
            });

            gvCitizenShip.DataSource = Services.ContactManager.GetContactCitizenshipByContact(Service.Contact_Id);
            gvCitizenShip.DataBind();
        }

        /// <summary>
        /// This Method Delete the Citizenship country    
        /// </summary>
        public void DeleteCitizenCountry(Object sender, EventArgs e)
        {
            var rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            Services.ContactManager.DeleteContactCitizenship(
                new Entity.UnderWriting.Entities.Contact.Citizenship
                {
                    ContactId = Convert.ToInt32(gvCitizenShip.DataKeys[rowIndex]["ContactId"]),
                    GlobalCountryId = Convert.ToInt32(gvCitizenShip.DataKeys[rowIndex]["GlobalCountryId"]),
                    CreateUser = Convert.ToInt32(gvCitizenShip.DataKeys[rowIndex]["CreateUser"]),
                    ModifyUser = Convert.ToInt32(gvCitizenShip.DataKeys[rowIndex]["ModifyUser"]),
                });
            gvCitizenShip.DataSource = Services.ContactManager.GetContactCitizenshipByContact(Service.Contact_Id);
            gvCitizenShip.DataBind();
        }

        /// <summary>
        /// This Method Load the Personal Data  for the Summary block of Selected Role  
        /// </summary>
        protected void RoleDDL_SelectedIndexChanged(Object sender, EventArgs e)
        {
            Service.Contact_Id = Convert.ToInt32(RoleDDL.SelectedValue.Split('|')[0]);
            Service.RoleTypeId = Convert.ToInt32(RoleDDL.SelectedValue.Split('|')[1]);

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
                                                             Service.LanguageId);

            ((PersonalDataContainer)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCPersonalDataContainer")).FillData(contact, false);
        }

        /// <summary>
        /// This Method Load the Selected PDF of the Personal Data Summary block    
        /// </summary>
        protected void LoadPdf_Click(object sender, EventArgs e)
        {
            var pdfButton = (Button)sender;
            var key = pdfButton.Attributes["data-PdfKey"].Split('|');
            var document = Services.PolicyManager.GetIdCopyRequirement(new Entity.UnderWriting.Entities.Requirement
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
                ContactId = int.Parse(RoleDDL.SelectedValue.Split('|')[0])
            });

            var contactIdentficationDocument = Services.RequirementManager.GetDocument(document.CorpId,
                                                                                       document.RegionId,
                                                                                       document.CountryId,
                                                                                       document.DomesticregId,
                                                                                       document.StateProvId,
                                                                                       document.CityId,
                                                                                       document.OfficeId,
                                                                                       document.CaseSeqNo,
                                                                                       document.HistSeqNo,
                                                                                       document.ContactId,
                                                                                       document.RequirementCatId,
                                                                                       document.RequirementTypeId,
                                                                                       document.RequirementId,
                                                                                       document.RequirementDocId);

            FillPdfPersonalData(Services.ContactManager.GetIdDocument(Service.Contact_Id,
                                                                      Convert.ToInt32(key[0]),
                                                                      Convert.ToInt32(key[1]),
                                                                      Convert.ToInt32(key[2])), contactIdentficationDocument);
        }

        /// <summary>
        /// This Method Load a City DropDown for the Selected Country  
        /// </summary>
        protected void CountryOfResidenceDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service.DropDowns.GetDropDown(ref ProvinceOfResidenceDDL,
                                          Language.English,
                                          DropDownType.StateProvince,
                                          Service.Corp_Id,
                                          null,
                                          Convert.ToInt32(CountryOfResidenceDDL.SelectedValue),
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);
            this.CityOfResidenceDDL.Items.Clear();
        }

        public void clearData()
        {
            gvCitizenShip.DataSource = null;
            gvCitizenShip.DataBind();
            CityOfResidenceDDL.Items.Clear();
            CountryOfBirthDDL.Items.Clear();
            CountryOfCitizenShipDDL.Items.Clear();
            CountryOfResidenceDDL.Items.Clear();
            GenderDDL.Items.Clear();
            MaritalStatusDDL.Items.Clear();

            RelationshipOwnerDDL.Items.Clear();
            RelationshipToAgentDDL.Items.Clear();
            RoleDDL.Items.Clear();
            SmokerDDL.Items.Clear();
            IssuedByDDL.Items.Clear();
            FirstNameTxt.Text = string.Empty;
            LastNameTxt.Text = string.Empty;
            SecondLastNameTxt.Text = string.Empty;
            DOBTxt.Text = string.Empty;
            MiddleTxt.Text = string.Empty;
            TypeTxt.Text = string.Empty;
            AgeTxt.Text = string.Empty;
            NearAgeTxt.Text = string.Empty;


            idTxt.Text = string.Empty;
            IdExpirationDateTxt.Text = string.Empty;
            BackgroundCheckTxt.Text = string.Empty;
            pdfViewerPersonalData.PdfSourceBytes = null;
            pdfViewerPersonalData.DataBind();

            //mavelar 4/5/17
            txtInstitutionalName.Text = string.Empty;
            txtRegistrationDate.Text = string.Empty;
            txtRegistrationNumber.Text = string.Empty;
            txtCompanyNIT.Text = string.Empty;
            txtInstitutionalPrincipal.Text = string.Empty;
            txtInstitutionalCountry.Text = string.Empty;
            txtInstitutionalPositionAtCompany.Text = string.Empty;
            //fin mavelar 4/5/17
        }

        #region Private Methods
        /// <summary>
        /// This Method Load all the Personal Data
        /// </summary>
        private void GetPersonalData()
        {
            gvCitizenShip.DataSource = Services.ContactManager.GetContactCitizenshipByContact(Service.Contact_Id);
            gvCitizenShip.DataBind();

            grdDocs.DataSource = Services.ContactManager.GetAllIdDocumentInformation(Service.Contact_Id, 1);
            grdDocs.DataBind();

            FillPersonalDataContactInformation();
            FillPersonalDataDropDowns();
            GetPdfDocumentList(false, int.Parse(RoleDDL.SelectedValue.Split('|')[0]), 0);
        }

        /// <summary>
        /// This method load the company data
        /// </summary>

        //*********************METODO ORIGINAL (ANTES DE MODULO DE PANTALLA JURIDICA)*********************//
        //private void GetCompanyInformation()
        //{
        //    if (_contact != null && !string.IsNullOrWhiteSpace(_contact.InstitutionalName))
        //    {
        //        Contact.IdDocument registration = Services.ContactManager.GetAllIdDocumentInformation
        //        (
        //            _contact.ContactId,
        //            Service.LanguageId
        //        ).ToList().LastOrDefault(x => x.ContactIdType == 5);

        //        string country = Service.DropDowns.GetDropDown(DropDownType.Country,
        //                                                       Service.Corp_Id,
        //                                                       projectId: Service.ProjectId,
        //                                                       companyId: Service.CompanyId,
        //                                                       languageId: Service.LanguageId).FirstOrDefault(c => Convert.ToInt32(c.Value) == _contact.InstitutionalCountryId).Text;

        //        txtInstitutionalCountry.Text = country;
        //        txtInstitutionalName.Text = string.IsNullOrWhiteSpace(_contact.InstitutionalName) ? string.Empty : _contact.InstitutionalName;
        //        txtInstitutionalPositionAtCompany.Text = string.IsNullOrWhiteSpace(_contact.InstitutionalPositionAtCompany) ? string.Empty : _contact.InstitutionalPositionAtCompany;
        //        txtInstitutionalPrincipal.Text = string.IsNullOrWhiteSpace(_contact.InstitutionalPrincipal) ? string.Empty : _contact.InstitutionalPrincipal;
        //        if (registration != null)
        //        {
        //            txtRegistrationDate.Text = string.IsNullOrWhiteSpace(Convert.ToString(registration.ValidDate)) ? string.Empty : string.Format("{0:MM/dd/yyyy}", registration.ValidDate);
        //            txtRegistrationNumber.Text = string.IsNullOrWhiteSpace(registration.Id) ? string.Empty : registration.Id;
        //        }
        //    }
        //}

        private void GetCompanyInformation()
        {
            if (_contact != null && !string.IsNullOrWhiteSpace(_contact.InstitutionalName))
            {
                //Contact.IdDocument registration = Services.ContactManager.GetAllIdDocumentInformation(_contact.ContactId, Service.LanguageId).ToList().LastOrDefault(x => x.ContactIdType == 5);
                //Contact.IdDocument registration2 = Services.ContactManager.GetAllIdDocumentInformation(_contact.ContactId, Service.LanguageId).ToList().LastOrDefault(x => x.ContactIdType == 7);
               
                var Documents =  Services.ContactManager.GetAllIdDocumentInformation(_contact.ContactId, Service.LanguageId).ToList();

                txtInstitutionalName.Text = string.IsNullOrWhiteSpace(_contact.InstitutionalName) ? string.Empty : _contact.InstitutionalName;
                txtInstitutionalNameUpdate.Text = string.IsNullOrWhiteSpace(_contact.InstitutionalName) ? string.Empty : _contact.InstitutionalName;
                

                if (Documents != null)
                {
                    try { 
                        //txtRegistrationNumber.Text = string.IsNullOrWhiteSpace(registration.Id) ? string.Empty : registration.Id;
                        txtRegistrationNumberDO.Text = Documents.FirstOrDefault(x => x.ContactIdType == 5).Id;
                    }
                    catch
                    {
                    }
                    //wcastro 15-03-2017
                    try
                    {
                        txtCompanyRNC.Text = Documents.FirstOrDefault(x => x.ContactIdType == 7).Id;
                        //txtCompanyNIT.Text = string.IsNullOrWhiteSpace(registration2.Id) ? string.Empty : registration2.Id;//Agregando el NIT  //wcastro

                        if (txtCompanyRNC.Text.Length == 11)
                        {
                            ddlIDType.SelectedValue = "5";
                        }
                        else
                        {
                            ddlIDType.SelectedValue = "1";
                        }
                    }
                    catch
                    {
                    }
                }
                //wcastro 21-03-2017
                txtRegistrationDate.Text = !string.IsNullOrEmpty(_contact.Dob.Value.ToString()) ? _contact.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) : null;
                //wcastro
                this.DOBTxt.Text = !string.IsNullOrEmpty(_contact.Dob.Value.ToString()) ? _contact.Dob.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) : null;

                if (_contact.companyStructureId != null)
                {                    
                    this.ddlSocietyType.SelectedValue = _contact.companyStructureId.ToString();
                    this.ddlCommercialActivity.SelectedValue = _contact.companyActivityId.ToString();
                    this.ddlSocietyFinalBeneficiary.SelectedValue = _contact.finalBeneficiaryOptionId.ToString();
                }

                //this.ddlIDType.SelectedItem.Value = _contact.type
                 
            }
        }

        /// <summary>
        /// This Method Load all the Service.DropDowns
        /// </summary>
        private void FillPersonalDataDropDowns()
        {
            Service.DropDowns.GetDropDown(ref GenderDDL,
                                          Language.English,
                                          DropDownType.Gender,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref GenderDDL, _contact.Gender, false);

            Service.DropDowns.GetDropDown(ref SmokerDDL,
                                          Language.English,
                                          DropDownType.Smoker,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref SmokerDDL, Convert.ToInt32(_contact.Smoker).ToString(), false);

            Service.DropDowns.GetDropDown(ref MaritalStatusDDL,
                                          Language.English,
                                          DropDownType.MaritalStatus,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref MaritalStatusDDL, _contact.MaritalStatId.ToString(), false);

            Service.DropDowns.GetDropDown(ref CountryOfBirthDDL,
                                          Language.English,
                                          DropDownType.Country,
                                          Service.Corp_Id, projectId:
                                          Service.ProjectId, companyId:
                                          Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref CountryOfBirthDDL, (!_contact.CountryOfBirthId.HasValue ? "0" : _contact.CountryOfBirthId.Value.ToString()), false);

            Service.DropDowns.GetDropDown(ref CountryOfCitizenShipDDL,
                                          Language.English,
                                          DropDownType.Country,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            //Lgonzalez 09-02-2017 - inicio
            if (_contact.Citizenships.Count() > 0)
            {
                var listCityship = _contact.Citizenships.ToList();
                string CC = listCityship[0].GlobalCountryId.ToString();
                UnderWriting.Common.Tools.SelectIndexByValue(ref CountryOfCitizenShipDDL, CC, false);
            }



            //Lgonzalez 09-02-2017 - fin

            Service.DropDowns.GetDropDown(ref CountryOfResidenceDDL,
                                          Language.English,
                                          DropDownType.CountryOfResidence,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            UnderWriting.Common.Tools.SelectIndexByValue(ref CountryOfResidenceDDL, _contact.CountryOfResidenceId.ToString(), false);

            var coResidenceId = int.Parse(!_contact.CountryOfResidenceId.HasValue ? "0" : _contact.CountryOfResidenceId.ToString());
            var dRegResidenceId = int.Parse(!_contact.DomesticRegOfResidenceId.HasValue ? "0" : _contact.DomesticRegOfResidenceId.ToString());
            var sResidenceId = int.Parse(!_contact.StateOfResidenceId.HasValue ? "0" : _contact.StateOfResidenceId.ToString());
            var cResidenceId = int.Parse(!_contact.CityOfResidenceId.HasValue ? "0" : _contact.CityOfResidenceId.ToString());
            var rResidenceId = int.Parse(!_contact.RegionOfResidenceId.HasValue ? "0" : _contact.RegionOfResidenceId.ToString());

            //State of Residence
            Service.DropDowns.GetDropDown(ref ProvinceOfResidenceDDL,
                                          Language.English,
                                          DropDownType.StateProvince,
                                          Service.Corp_Id,
                                          null,
                                          coResidenceId,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Tools.SelectIndexByValue(ref ProvinceOfResidenceDDL,
                                     string.Format("{0}|{1}|{2}", coResidenceId.ToString(),
                                                                  dRegResidenceId,
                                                                  sResidenceId),
                                     false);

            //City of Residence
            Service.DropDowns.GetDropDown(ref CityOfResidenceDDL,
                                          Language.English,
                                          DropDownType.City,
                                          Service.Corp_Id,
                                          null,
                                          coResidenceId,
                                          dRegResidenceId,
                                          sResidenceId);

            Tools.SelectIndexByValue(ref CityOfResidenceDDL,
                                     string.Format("{0}|{1}|{2}|{3}|{4}", rResidenceId.ToString(),
                                                                          coResidenceId,
                                                                          dRegResidenceId,
                                                                          sResidenceId,
                                                                          cResidenceId),
                                     false);
            //
            Tools.SelectIndexByValue(ref CityOfResidenceDDL,
                                     string.Format("{0}|{1}|{2}|{3}|{4}", _contact.RegionOfResidenceId.ToString(),
                                                                          _contact.CountryOfResidenceId.ToString(),
                                                                          _contact.DomesticRegOfResidenceId.ToString(),
                                                                          _contact.StateOfResidenceId.ToString(),
                                                                          _contact.CityOfResidenceId.ToString()),
                                     false);

            Service.DropDowns.GetDropDown(ref RelationshipToAgentDDL,
                                          Language.English,
                                          DropDownType.RelationshipAgent,
                                          corpId: Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Tools.SelectIndexByValue(ref RelationshipToAgentDDL, (!_contact.RelationshiptoAgent.HasValue ? "0" : _contact.RelationshiptoAgent.ToString()), false);

            Service.DropDowns.GetDropDown(ref RelationshipOwnerDDL,
                                          Language.English,
                                          DropDownType.Relationship,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Tools.SelectIndexByValue(ref RelationshipOwnerDDL, (!_contact.RelationshiptoOwner.HasValue ? "0" : _contact.RelationshiptoOwner.ToString()), false);

            Service.DropDowns.GetDropDown(ref IdtypeDDL,
                                          Language.English,
                                          DropDownType.IdType,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Tools.SelectIndexByValue(ref IdtypeDDL, _contact.ContactIdType.ToString(), false);

            Service.DropDowns.GetDropDown(ref IssuedByDDL,
                                          Language.English,
                                          DropDownType.IssuedBy,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Tools.SelectIndexByValue(ref IssuedByDDL, _contact.CountryIssuedBy.ToString(), false);


            Service.DropDowns.GetDropDown(ref ddlSocietyType,
                                          Language.English,
                                          DropDownType.CompanyStructure,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Service.DropDowns.GetDropDown(ref ddlSocietyFinalBeneficiary,
                                          Language.English,
                                          DropDownType.FinalBeneficiaryOption,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            Service.DropDowns.GetDropDown(ref ddlCommercialActivity,
                                          Language.English,
                                          DropDownType.CompanyActivity,
                                          Service.Corp_Id,
                                          projectId: Service.ProjectId,
                                          companyId: Service.CompanyId);

            var idsTps = new List<int> { 1, 5 };
            var idData = Service.GettingDropData(DropDownType.IdType);
            ddlIDType.DataSource = idData.Where(d => idsTps.Contains(d.ContactTypeId.GetValueOrDefault())).ToArray();
            ddlIDType.DataTextField = "ContactTypeIdDesc";
            ddlIDType.DataValueField = "ContactTypeId";
            ddlIDType.DataBind();
        }

        private void FillPersonalDataContactInformation()
        {
            this.updateCompanyinfo.Visible = true;
            //mavelar 3/26/2017
            //owner
            if ((Service.RoleTypeId == 1) && (_contact.ContactTypeDesc == "Company/Client"))
            {
                //removiendo clase para campos requeridos

                FirstNameTxt.CssClass = FirstNameTxt.CssClass.Replace("validationElement", "");
                LastNameTxt.CssClass = LastNameTxt.CssClass.Replace("validationElement", "");
                GenderDDL.CssClass = GenderDDL.CssClass.Replace("validationElement", "");
                MaritalStatusDDL.CssClass = MaritalStatusDDL.CssClass.Replace("validationElement", "");
                SmokerDDL.CssClass = SmokerDDL.CssClass.Replace("validationElement", "");
                CountryOfResidenceDDL.CssClass = CountryOfResidenceDDL.CssClass.Replace("validationElement", "");
                ProvinceOfResidenceDDL.CssClass = ProvinceOfResidenceDDL.CssClass.Replace("validationElement", "");
                CityOfResidenceDDL.CssClass = CityOfResidenceDDL.CssClass.Replace("validationElement", "");
                CountryOfBirthDDL.CssClass = CountryOfBirthDDL.CssClass.Replace("validationElement", "");
                IdtypeDDL.CssClass = IdtypeDDL.CssClass.Replace("validationElement", "");
                idTxt.CssClass = idTxt.CssClass.Replace("validationElement", "");
                IdExpirationDateTxt.CssClass = IdExpirationDateTxt.CssClass.Replace("validationElement", "");
                IssuedByDDL.CssClass = IssuedByDDL.CssClass.Replace("validationElement", "");

                //seccion datos personales
                InsuredAgentLegal.Visible = false;
                updateCompanyinfo.Visible = true;
                companyName.Visible = true;
                txtInstitutionalNameUpdate.Visible = true;
                DateBirdth.Visible = false;
                DateCompany.Visible = true;
                EdadFuma.Visible = false;
                GeneroEstado.Visible = false;
                InfoCompany.Visible = false;

                FirstNameTxt.Enabled = false;
                MiddleTxt.Enabled = false;
                LastNameTxt.Enabled = false;
                SecondLastNameTxt.Enabled = false;
                AgeTxt.Enabled = false;
                NearAgeTxt.Enabled = false;
                SmokerDDL.Enabled = false;
                GenderDDL.Enabled = false;
                MaritalStatusDDL.Enabled = false;

                //seccion geografica
                InsuredAgentLegal2.Visible = false;
                CountryOfCitizenShipDDL.Enabled = false;
                CountryOfBirthDDL.Enabled = false;
                CountryOfResidenceDDL.Enabled = false;
                ProvinceOfResidenceDDL.Enabled = false;
                CityOfResidenceDDL.Enabled = false;

                //seccion documentos
                IdtypeDDL.Enabled = true;
                idTxt.Enabled = true;
                IdExpirationDateTxt.Enabled = true;
                IssuedByDDL.Enabled = true;

                //seccion de la compania
                txtInstitutionalName.ReadOnly = false;
                txtRegistrationDate.ReadOnly = false;
                txtRegistrationNumber.ReadOnly = false;
                txtCompanyNIT.ReadOnly = false;


            }
            //insured, owner,insured, owner
            else if ((Service.RoleTypeId == 2) && (_contact.ContactTypeDesc == "Client") || (Service.RoleTypeId == 1) && (_contact.ContactTypeDesc == "Client"))
            {
                //removiendo clase para campos requeridos
                FirstNameTxt.CssClass = FirstNameTxt.CssClass.Replace("validationElement", "");
                IssuedByDDL.CssClass = IssuedByDDL.CssClass.Replace("validationElement", "");
                IdExpirationDateTxt.CssClass = IdExpirationDateTxt.CssClass.Replace("validationElement", "");

                //seccion datos personales
                InsuredAgentLegal.Visible = true;
                updateCompanyinfo.Visible = true;
                companyName.Visible = false;
                txtInstitutionalNameUpdate.Visible = false;
                DateBirdth.Visible = true;
                DateCompany.Visible = false;
                EdadFuma.Visible = true;
                GeneroEstado.Visible = true;
                InfoCompany.Visible = true;

                FirstNameTxt.Enabled = true;
                MiddleTxt.Enabled = true;
                LastNameTxt.Enabled = true;
                SecondLastNameTxt.Enabled = true;
                AgeTxt.Enabled = true;
                NearAgeTxt.Enabled = true;
                SmokerDDL.Enabled = true;
                GenderDDL.Enabled = true;
                MaritalStatusDDL.Enabled = true;

                //seccion geografica
                InsuredAgentLegal2.Visible = true;
                CountryOfCitizenShipDDL.Enabled = true;
                CountryOfBirthDDL.Enabled = true;
                CountryOfResidenceDDL.Enabled = true;
                ProvinceOfResidenceDDL.Enabled = true;
                CityOfResidenceDDL.Enabled = true;

                //seccion documentos
                IdtypeDDL.Enabled = true;
                idTxt.Enabled = true;
                IdExpirationDateTxt.Enabled = true;
                IssuedByDDL.Enabled = true;

                //seccion de la compania
                txtInstitutionalName.ReadOnly = true;
                txtRegistrationDate.ReadOnly = true;
                txtRegistrationNumber.ReadOnly = true;
                txtCompanyNIT.ReadOnly = true;

                this.DOBTxt.Text = _contact.Dob.GetValueOrDefault().ToString("MM/dd/yyyy");

            }
            //agent legal
            else if ((Service.RoleTypeId == 10) && (_contact.ContactTypeDesc == "Client"))
            {
                //removiendo clase para campos requeridos
                ProvinceOfResidenceDDL.CssClass = ProvinceOfResidenceDDL.CssClass.Replace("validationElement", "");
                CityOfResidenceDDL.CssClass = CityOfResidenceDDL.CssClass.Replace("validationElement", "");
                IdtypeDDL.CssClass = IdtypeDDL.CssClass.Replace("validationElement", "");
                idTxt.CssClass = idTxt.CssClass.Replace("validationElement", "");
                IdExpirationDateTxt.CssClass = IdExpirationDateTxt.CssClass.Replace("validationElement", "");
                IssuedByDDL.CssClass = IssuedByDDL.CssClass.Replace("validationElement", "");

                //mostrando / ocultando campos

                //seccion datos personales
                InsuredAgentLegal.Visible = true;
                updateCompanyinfo.Visible = true;
                companyName.Visible = false;
                txtInstitutionalNameUpdate.Visible = false;
                DateBirdth.Visible = true;
                DateCompany.Visible = false;
                EdadFuma.Visible = true;
                GeneroEstado.Visible = true;
                InfoCompany.Visible = true;

                FirstNameTxt.Enabled = true;
                MiddleTxt.Enabled = true;
                LastNameTxt.Enabled = true;
                SecondLastNameTxt.Enabled = true;
                AgeTxt.Enabled = true;
                NearAgeTxt.Enabled = true;
                SmokerDDL.Enabled = true;
                GenderDDL.Enabled = true;
                MaritalStatusDDL.Enabled = true;

                //seccion geografica
                InsuredAgentLegal2.Visible = true;
                CountryOfCitizenShipDDL.Enabled = true;
                CountryOfBirthDDL.Enabled = true;
                CountryOfResidenceDDL.Enabled = true;
                ProvinceOfResidenceDDL.Enabled = true;
                CityOfResidenceDDL.Enabled = true;

                //seccion documentos
                IdtypeDDL.Enabled = true;
                idTxt.Enabled = true;
                IdExpirationDateTxt.Enabled = true;
                IssuedByDDL.Enabled = true;

                //seccion de la compania
                txtInstitutionalName.ReadOnly = true;
                txtRegistrationDate.ReadOnly = true;
                txtRegistrationNumber.ReadOnly = true;
                txtCompanyNIT.ReadOnly = true;

                this.DOBTxt.Text = _contact.Dob.GetValueOrDefault().ToString("MM/dd/yyyy");
            }

            else
            {
                //seccion datos personales
                InsuredAgentLegal.Visible = true;
                updateCompanyinfo.Visible = true;
                companyName.Visible = false;
                txtInstitutionalNameUpdate.Visible = false;
                DateBirdth.Visible = true;
                DateCompany.Visible = false;
                EdadFuma.Visible = true;
                GeneroEstado.Visible = true;
                InfoCompany.Visible = true;

                FirstNameTxt.Enabled = true;
                MiddleTxt.Enabled = true;
                LastNameTxt.Enabled = true;
                SecondLastNameTxt.Enabled = true;
                AgeTxt.Enabled = true;
                NearAgeTxt.Enabled = true;
                SmokerDDL.Enabled = true;
                GenderDDL.Enabled = true;
                MaritalStatusDDL.Enabled = true;

                //seccion geografica
                InsuredAgentLegal2.Visible = true;
                CountryOfCitizenShipDDL.Enabled = true;
                CountryOfBirthDDL.Enabled = true;
                CountryOfResidenceDDL.Enabled = true;
                ProvinceOfResidenceDDL.Enabled = true;
                CityOfResidenceDDL.Enabled = true;

                //seccion documentos
                IdtypeDDL.Enabled = true;
                idTxt.Enabled = true;
                IdExpirationDateTxt.Enabled = true;
                IssuedByDDL.Enabled = true;

                //seccion de la compania
                txtInstitutionalName.ReadOnly = true;
                txtRegistrationDate.ReadOnly = true;
                txtRegistrationNumber.ReadOnly = true;
                txtCompanyNIT.ReadOnly = true;

                this.DOBTxt.Text = _contact.Dob.GetValueOrDefault().ToString("MM/dd/yyyy");
            }
            if (_contact.ContactTypeDesc == "Client")
            {
                this.updateCompanyinfo.Visible = false;
            }
            //mavelar 3/26/2017
            Service.ContactAge = _contact.Age ?? 0;
            Service.ContactGender = _contact.Gender;

            //Contact = Services.ContactManager.GetContact(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
            //    Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No,
            //    Service.Hist_Seq_No, Service.Contact_Id, null);

            var contactId = _contact.ContactId;
            this.FirstNameTxt.Text = _contact.FirstName;
            this.LastNameTxt.Text = _contact.FirstLastName;
            this.SecondLastNameTxt.Text = _contact.SecondLastName;
            //this.DOBTxt.Text = _contact.Dob.GetValueOrDefault().ToString("MM/dd/yyyy");
            this.MiddleTxt.Text = _contact.MiddleName;
            this.TypeTxt.Text = _contact.ContactTypeDesc;
            this.AgeTxt.Text = _contact.Age.HasValue ? _contact.Age.ToString() : "0";
            this.NearAgeTxt.Text = _contact.NearAge.ToString();


            this.idTxt.Text = _contact.Id;
            this.IdExpirationDateTxt.Text = Convert.ToDateTime(_contact.ExpireDate).ToShortDateString();

            //2016-01-29 - Marcos J. Perez
            //If ProductFamily = HealthInsurance, show Measurements, get Height and Weight then calculate BMI
            divMeasurements.Visible = Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance;
            if (divMeasurements.Visible)
            {
                //2016-02-12 | Marcos J. Perez
                this.txtHeight.Text = string.IsNullOrWhiteSpace(_contact.Height) ? "0" : _contact.Height;
                this.txtWeight.Text = _contact.Weight.HasValue ? _contact.Weight.Value.ToString("N0") : "0";
                this.txtBMI.Text = Tools.BMI(this.txtWeight.Text, this.txtHeight.Text, false);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("document.getElementById('liStateResidence').setAttribute(\"class\", \"fl mR-2-p\");");
                sb.AppendLine("document.getElementById('liCityResidence').setAttribute(\"class\", \"\");");
                sb.AppendLine("document.getElementById('liCountryCitizenship').setAttribute(\"class\", \"mR-2-p\");");
                this.ExcecuteJScript(sb.ToString());
            }

            if (_contact.BackgroundCheckResult.HasValue)
            {
                if (_contact.BackgroundCheckResult.Value)
                {
                    this.BackgroundCheckTxt.Text = "Matched";
                    this.BackgroundCheckTxt.CssClass = "bgRJ txtBL ReadOnly";
                }
                else
                {
                    this.BackgroundCheckTxt.Text = "Not Matched";
                    this.BackgroundCheckTxt.CssClass = "bgVD2 txtBL ReadOnly";
                }
            }
            else
            {
                this.BackgroundCheckTxt.Text = "Pending";
                this.BackgroundCheckTxt.CssClass = "bgAM ReadOnly";
            }

            Service.ContactSeq_No = _contact.SeqNo ?? 0;
        }

        public void GetPdfDocumentList(bool isSummary, int ContactId, int DocumentIndex)
        {
            var document = Services.PolicyManager.GetIdCopyRequirement(new Entity.UnderWriting.Entities.Requirement
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
                ContactId = ContactId
            });

            var list = new List<Entity.UnderWriting.Entities.Requirement.Document> { document };

            if (isSummary)
            {
                var pdfRepeater = (Repeater)Page.Master.FindControl("Left").FindControl("Left").FindControl("PdfRepeater");
                pdfRepeater.DataSource = list;
                pdfRepeater.DataBind();
            }
            else
            {

                BigPdfRepeater.DataSource = list;
                BigPdfRepeater.DataBind();
            }

            if (document != null)
            {
                var contactIdentficationDocument = Services.RequirementManager.GetDocument(document.CorpId,
                                                                                           document.RegionId,
                                                                                           document.CountryId,
                                                                                           document.DomesticregId,
                                                                                           document.StateProvId,
                                                                                           document.CityId,
                                                                                           document.OfficeId,
                                                                                           document.CaseSeqNo,
                                                                                           document.HistSeqNo,
                                                                                           document.ContactId,
                                                                                           document.RequirementCatId,
                                                                                           document.RequirementTypeId,
                                                                                           document.RequirementId,
                                                                                           document.RequirementDocId);
                if (isSummary)
                {
                    FillPdfSummary(contactIdentficationDocument);
                }
                else
                {
                    var documentList = Services.ContactManager.GetAllIdDocumentInformation(ContactId, Service.LanguageId).ToList();

                    if (documentList.Any())
                    {
                        var policyPlanDocument = documentList.ElementAt(DocumentIndex);
                        var contactIdentification = Services.ContactManager.GetIdDocument(ContactId,
                                                                                          policyPlanDocument.DocumentCategoryId,
                                                                                          policyPlanDocument.DocumentTypeId,
                                                                                          policyPlanDocument.DocumentId);
                        FillPdfPersonalData(contactIdentification, contactIdentficationDocument);
                    }
                    else
                    {
                        FillPdfPersonalData(null, contactIdentficationDocument);
                    }
                }
            }
            else
            {
                if (isSummary)
                {
                    PreviewPdfSummary(null);
                }
                else
                {
                    FillPdfPersonalData(null, null);
                }
            }
        }
        private void PreviewPdfSummary(byte[] dt)
        {
            PdfViewer pdfViewerControl = new PdfViewer();
            pdfViewerControl = (PdfViewer)Page.Master.FindControl("Left").FindControl("Left").FindControl("pdfViewerSummary");
            pdfViewerControl.PdfSourceBytes = dt;
            pdfViewerControl.DataBind();
        }
        private void PreviewPdfPersonalData(byte[] dt)
        {
            this.pdfViewerPersonalData.PdfSourceBytes = dt;
            this.pdfViewerPersonalData.DataBind();
            UCPersonalDataPreviewBtn.Visible = pdfViewerPersonalData.PdfSourceBytes != null;
        }
        private void FillPdfPersonalData(Contact.IdDocument contactIdentficationDocument, Requirement.Document contactIdentification)
        {
            if (contactIdentficationDocument != null)
            {
                //Fill Document Data
                IdtypeDDL.SelectedValue = contactIdentficationDocument.ContactIdType.ToString();
                IdExpirationDateTxt.Text = contactIdentficationDocument.ExpireDate.HasValue ? contactIdentficationDocument.ExpireDate.Value.ToString("MM/dd/yyyy") : "";

                if (contactIdentficationDocument.CountryIssuedBy > 0)
                {
                    IssuedByDDL.SelectedValue = contactIdentficationDocument.CountryIssuedBy.ToString();
                }
                else
                {
                    IssuedByDDL.SelectedIndex = IssuedByDDL.Items.Count > 0 ? 0 : -1;
                }
            }
            else
            {
                /*
                IdtypeDDL.SelectedIndex = -1;
                idTxt.Text = String.Empty;
                IdExpirationDateTxt.Text = String.Empty;
                IssuedByDDL.SelectedIndex = IssuedByDDL.Items.Count > 0 ? 0 : -1;
                */
            }

            PreviewPdfPersonalData(contactIdentification == null ? null : contactIdentification.DocumentBinary);
        }

        public void FillPdfSummary(Requirement.Document contactIdentficationDocument)
        {
            PreviewPdfSummary(contactIdentficationDocument == null ? null : contactIdentficationDocument.DocumentBinary);
        }
        #endregion

        protected void UCPersonalDataPreviewBtn_Click(object sender, EventArgs e)
        {
            var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("mpPdfViewer");
            var popUp = ((Common.UCShowPDFPopup)Page.Master.FindControl("UCShowPDFPopup"));

            if (ModalPopUp != null && popUp != null)
            {
                popUp.LoadPDFPreview(pdfViewerPersonalData.PdfSourceBytes);
                ModalPopUp.Show();
                this.ExcecuteJScript("$(\"#UCShowPDFPopup_upPaymentPdfViewer\").append(CreateNewPopFrame())");
            }
        }

        protected void ProvinceOfResidenceDDL_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var cityId = 0;
            var officeId = 0;

            if (ProvinceOfResidenceDDL.SelectedValue.Split('|').Count() > 1)
            {
                cityId = Convert.ToInt32(ProvinceOfResidenceDDL.SelectedValue.Split('|')[1]);
                officeId = Convert.ToInt32(ProvinceOfResidenceDDL.SelectedValue.Split('|')[2]);
            }

            Service.DropDowns.GetDropDown(ref CityOfResidenceDDL,
                                          Language.English,
                                          DropDownType.City,
                                          Service.Corp_Id,
                                          null,
                                          Convert.ToInt32(this.ProvinceOfResidenceDDL.SelectedValue.Split('|')[0]),
                                          cityId,
                                          officeId);
        }
    }
}