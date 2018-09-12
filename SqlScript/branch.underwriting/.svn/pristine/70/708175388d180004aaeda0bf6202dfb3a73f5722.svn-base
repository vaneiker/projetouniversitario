using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.ContactsInfo
{
    public partial class ContactsInfoContainer : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public void Translator(string Lang) {
            AgentLegalisSameAsInsured.InnerHtml = Resources.AgentLegalsameInsuredLabel;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(ObjServices.Language.ToString());
        }

        public void ChangeView(int ViewIndex)
        {
            mtvInfoContainer.ActiveViewIndex = ViewIndex;
            udpOwnerInfoContainer.Update();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chk"></param>
        /// <param name="isLoading"></param>
        /// <param name="index"></param>
        /// <param name="IsSameInsured"></param>
        public void ShowFormOwnerInfo(CheckBox chk, Boolean isLoading = true, int index = 0, bool IsSameInsured = true)
        {
            ChangeView(index);

            if (!isLoading)
            {
                if (!ObjServices.IsDataReviewMode)
                {
                    var RoleType = Utility.getvalueFromEnumType("Owner", typeof(Utility.ContactRoleIDType));
                    //Despegar el contacto de la poliza que se creo como owner igual al asegurado                        
                    ObjServices.oPolicyManager.DeleteContactRole(ObjServices.Corp_Id,
                                                                 ObjServices.Region_Id,
                                                                 ObjServices.Country_Id,
                                                                 ObjServices.Domesticreg_Id,
                                                                 ObjServices.State_Prov_Id,
                                                                 ObjServices.City_Id,
                                                                 ObjServices.Office_Id,
                                                                 ObjServices.Case_Seq_No,
                                                                 ObjServices.Hist_Seq_No,
                                                                 ObjServices.Owner_Id,
                                                                 RoleType,
                                                                 ObjServices.UserID.Value
                                                                );

                    var RoleTypeAgent = Utility.getvalueFromEnumType("Legal", typeof(Utility.ContactRoleIDType));
                    //Despegar el contacto de la poliza que se creo como agente legal                      
                    ObjServices.oPolicyManager.DeleteContactRole(ObjServices.Corp_Id,
                                                                 ObjServices.Region_Id,
                                                                 ObjServices.Country_Id,
                                                                 ObjServices.Domesticreg_Id,
                                                                 ObjServices.State_Prov_Id,
                                                                 ObjServices.City_Id,
                                                                 ObjServices.Office_Id,
                                                                 ObjServices.Case_Seq_No,
                                                                 ObjServices.Hist_Seq_No,
                                                                 ObjServices.Agent_Legal,
                                                                 RoleTypeAgent,
                                                                 ObjServices.UserID.Value
                                                                );

                }

                var WUCSearchContacts = this.Page.Master.FindControl("bodyContent").FindControl("WUCSearchContacts");

                if (!WUCSearchContacts.isNullReferenceControl())
                {
                    var oDrop = (WUCSearchContacts.FindControl("ddl_P_ANC_Relationship") as DropDownList);
                    oDrop.Enabled = !IsSameInsured;
                    oDrop.SelectIndexByValue("-1", true);
                    ObjServices.Relationship_With_Owner_ToAgentId = -1;
                    ObjServices.Owner_Id = -1;
                    ObjServices.Agent_Legal = -1;
                    ObjServices.ContactEntityID = -1;

                    var oOwner = ObjServices.GetContact(ObjServices.Owner_Id.Value);

                    if (!oOwner.isNullReferenceObject())
                        ObjServices.isCompanyOwner = (oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt() || chk.ID == "chkIsCompany");
                }

                //Iniciarlizar los componentes
                Initialize();
            }
        }

        public void save()
        {
            WUCPersonalInformation.save();

            //Si existe el Owner
            if (ObjServices.Owner_Id > 0)
            {
                var oOwner = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Owner);
                ObjServices.isCompanyOwner = (oOwner != null && oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt());
            }

            if (ObjServices.isCompanyOwner && currentTab == "OwnerInfo")
            {
                WUCCompanyInfo.save();

                WUCIdentificationLegal.Operation = Utility.OperationType.InsertAll;
                WUCIdentificationLegal.save();

                WUCEmailAddressLegal.Operation = Utility.OperationType.InsertAll;
                WUCEmailAddressLegal.save();
                WUCBackgroundInformationLegal.save();

                WUCAddressLegal.save();

                WUCPhoneNumberRepLegal.Operation = Utility.OperationType.InsertAll;
                WUCPhoneNumberRepLegal.save();
            }
            else
            {
                //Controles superiores Personal Information, Address y BackgroundInformation           
                WUCAddress.save();
                WUCBackgroundInformation.save();

                //Controles inferiores Phone, Email Address e Identifications
                WUCPhoneNumber.Operation = Utility.OperationType.InsertAll;
                WUCPhoneNumber.save();
                WUCIdentification.Operation = Utility.OperationType.InsertAll;
                WUCIdentification.save();
                WUCEmailAddress.Operation = Utility.OperationType.InsertAll;
                WUCEmailAddress.save();
            }

            if (ObjServices.ContactServicesIsActive)
            {
                //Invocar el metodo del webservice para guardar en illusdata
                ObjServices.oContactServicesClient.SetContactAllInformation(corpId: Utility.Encrypt(ObjServices.Corp_Id.ToString()),
                                                                            contactId: Utility.Encrypt(ObjServices.ContactEntityID.ToString()),
                                                                            companyId: Utility.Encrypt(ObjServices.CompanyId)
                                                                           );
            }
        }

        public void EnabledControls(bool x)
        {
            //Si existe el Owner
            if (ObjServices.Owner_Id > 0)
            {
                var oOwner = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Owner);
                ObjServices.isCompanyOwner = (oOwner != null && oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt());
            }

            if (ObjServices.isCompanyOwner && currentTab == "OwnerInfo")
            {
                WUCCompanyInfo.EnabledControls(x);
                WUCAddress.EnabledControls(x);
                WUCPhoneNumber.EnabledControls(x);
                WUCEmailAddress.EnabledControls(x);
                WUCPersonalInformationRepLegal.EnabledControls(x);
                WUCIdentificationLegal.EnabledControls(x);
                WUCBackgroundInformationLegal.EnabledControls(x);
                WUCEmailAddressLegal.EnabledControls(x);
                WUCPhoneNumberRepLegal.EnabledControls(x);
                WUCAddressLegal.EnabledControls(x);
            }
            else
            {
                WUCPersonalInformation.EnabledControls(x);
                WUCAddress.EnabledControls(x);
                WUCPhoneNumber.EnabledControls(x);
                WUCEmailAddress.EnabledControls(x);
                WUCBackgroundInformation.EnabledControls(x);
                WUCIdentification.EnabledControls(x);
            }
        }

        public void edit()
        {

        }

        public void FillData()
        {

        }

        public void Initialize()
        {
            ClearData();

            if (!ObjServices.IsDataReviewMode)
            {
                //Habilitar todos los controles
                WUCPersonalInformation.EnabledControls(true);
                WUCAddress.EnabledControls(true);
                WUCPhoneNumber.EnabledControls(true);
                WUCEmailAddress.EnabledControls(true);
                WUCBackgroundInformation.EnabledControls(true);
                WUCIdentification.EnabledControls(true);
                //End 
            }

            //Si es una compañia y el tab es Owner Info
            if (ObjServices.isCompanyOwner && currentTab == "OwnerInfo")
            {
                WUCCompanyInfo.Initialize(currentTab);
                WUCPersonalInformationRepLegal.Initialize(currentTab);
                WUCPhoneNumberRepLegal.Initialize(currentTab);
                WUCIdentificationLegal.Initialize(currentTab);
                WUCEmailAddressLegal.Initialize(currentTab);
                WUCBackgroundInformationLegal.Initialize(currentTab);
                WUCAddressLegal.Initialize(currentTab);

                var LegalContact = ObjServices.GetContact(ObjServices.Agent_Legal.Value);
                var InsuredContact = ObjServices.GetContact(ObjServices.Contact_Id.Value);

                if (LegalContact != null && (LegalContact.FullName == InsuredContact.FullName))
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
            {
                WUCPersonalInformation.Initialize(currentTab);
                WUCAddress.Initialize(currentTab);
                WUCPhoneNumber.Initialize(currentTab);
                WUCEmailAddress.Initialize(currentTab);
                WUCBackgroundInformation.Initialize(currentTab);
                WUCIdentification.Initialize(currentTab);

                chkAgentLegalIsSameAsInsured.Checked = false;
                LoadDataFromInsured(false);
            }

            if (currentTab == "OwnerInfo" && ((ObjServices.Contact_Id.Value > 0 && ObjServices.Owner_Id.Value > 0) &&
                                             (ObjServices.Contact_Id.Value == ObjServices.Owner_Id.Value)))
                EnabledControls(ObjServices.IsReadOnly);

            if (ObjServices.IsDataReviewMode && getisView ||
               !ObjServices.IsDataReviewMode && ObjServices.IsReadOnly)
                ReadOnlyControls(ObjServices.IsReadOnly);

            WUCSaveTab.Initialize();
        }

        public void ClearData()
        {
            WUCPersonalInformation.ClearData();
            WUCCompanyInfo.ClearData();
            WUCAddress.ClearData(currentTab);
            WUCPhoneNumber.ClearData(currentTab);
            WUCEmailAddress.ClearData(currentTab);
            WUCBackgroundInformation.ClearData();
            WUCIdentification.ClearData(currentTab);
            WUCPersonalInformationRepLegal.ClearData();
            WUCPhoneNumberRepLegal.ClearData();
            WUCIdentificationLegal.ClearData();
            WUCEmailAddressLegal.ClearData();
            WUCBackgroundInformationLegal.ClearData();
            WUCAddressLegal.ClearData();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            WUCPersonalInformation.ReadOnlyControls(isReadOnly);
            WUCCompanyInfo.ReadOnlyControls(isReadOnly);
            WUCAddress.ReadOnlyControls(isReadOnly);
            WUCPhoneNumber.ReadOnlyControls(isReadOnly);
            WUCEmailAddress.ReadOnlyControls(isReadOnly);
            WUCBackgroundInformation.ReadOnlyControls(isReadOnly);
            WUCIdentification.ReadOnlyControls(isReadOnly);
            WUCPersonalInformationRepLegal.ReadOnlyControls(isReadOnly);
            WUCPhoneNumberRepLegal.ReadOnlyControls(isReadOnly);
            WUCIdentificationLegal.ReadOnlyControls(isReadOnly);
            WUCEmailAddressLegal.ReadOnlyControls(isReadOnly);
            WUCBackgroundInformationLegal.ReadOnlyControls(isReadOnly);
            WUCAddressLegal.ReadOnlyControls(isReadOnly);
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

        public void OnOffControls(bool state) {
            WUCPersonalInformationRepLegal.EnabledControls(state);
            WUCAddressLegal.EnabledControls(state);
            WUCBackgroundInformationLegal.EnabledControls(state);
            WUCPhoneNumberRepLegal.EnabledControls(state);
            WUCEmailAddressLegal.EnabledControls(state);
            WUCIdentificationLegal.EnabledControls(state);
        }
    }
}