using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls.ContactsInfo
{
    public partial class WUCSearch : UC, IUC
    {
        public delegate void ShowFormOwnerInfoHandler(CheckBox chk, Boolean isLoading = true, int Index = 0, bool IsSameInsured = false);
        public event ShowFormOwnerInfoHandler ShowFormOwnerInfo;

        public ContactsInfoContainer OwnerInfoContainer;
        public UpdatePanel udpOwnerInfoContainer;

        public void save() { }
        public void edit() { }

        public void Translator(string Lang)
        {
            lblAgentName.InnerText = Resources.AgentNameLabel;
            lblOffice.InnerText = Resources.Office.Capitalize();
            lblRelationShip.Text = currentTab == "ClientInfo" ? Resources.RelationshipWithInsured : Resources.RelationshipWithOwner;
            OwnerisSameAsInsured.InnerHtml = Resources.OwnerissameasInsuredLabel;
            OwnerisACompany.InnerHtml = Resources.OwnerisaCompanyLabel;
            ltSearch.Text = currentTab == "ClientInfo" ? Resources.SearchClient : Resources.SearchOwner;
            if (isChangingLang)
                FillDrop();
        }

        public void CheckedIsCompany()
        {
            chkIsCompany.Checked = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(ObjServices.Language.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            OwnerInfoContainer = this.Page.Master.FindControl("bodyContent").FindControl("ContactsInfoContainer") as ContactsInfoContainer;
            ShowFormOwnerInfo += OwnerInfoContainer.ShowFormOwnerInfo;
        }

        protected void btnCallSearch_Click(object sender, EventArgs e)
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");

            if (!chkClientorOwnerAlreadyinContacts.Checked)
            {
                (bodyContent.FindControl("hdnShowPopClientInfoSearch") as HiddenField).Value = "true";
                var WUCSearchClientOrOwner = bodyContent.FindControl("popSearchClientOrOwner").FindControl("WUCSearchClientOrOwner");

                if (WUCSearchClientOrOwner != null)
                {
                    var oWUCSearchClientOrOwner = (NewBusiness.UserControls.AddNewClient.Common.WUCSearchClientOrOwner)WUCSearchClientOrOwner;
                    oWUCSearchClientOrOwner.ContactTypeID = chkIsCompany.Checked ? Utility.ContactTypeId.Company.ToInt()
                                                                                 : Utility.ContactTypeId.Contact.ToInt();
                    oWUCSearchClientOrOwner.Initialize();
                    var udpAddNewClient = bodyContent.FindControl("udpAddNewClient");

                    if (udpAddNewClient != null)
                        (udpAddNewClient as UpdatePanel).Update();
                }
            }
            else
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.ClientExistAsContact, Title: Resources.Warning);
        }

        protected void chkIsCompany_CheckedChanged(object sender, EventArgs e)
        {
            ObjServices.isCompanyOwner = chkIsCompany.Checked;
            ShowFormOwnerInfo(chkIsCompany, false, (chkIsCompany.Checked ? 1 : 0));
            chkOwnerIsSameAsInsured.Checked = false;
            chkClientorOwnerAlreadyinContacts.Checked = false;
            
            txtClientSearch.Clear();
        }

        protected void chkOwnerIsSameAsInsured_CheckedChanged(object sender, EventArgs e)
        {
            ObjServices.isCompanyOwner = false;

            if (chkOwnerIsSameAsInsured.Checked)
            {
                ShowFormOwnerInfo(chkOwnerIsSameAsInsured, false, 0, true);
                LoadDataFromInsured(true);
            }
            else
            {
                LoadDataFromInsured(false);
                ShowFormOwnerInfo(null, false, 0);
            }

            chkIsCompany.Checked = false;
            chkClientorOwnerAlreadyinContacts.Checked = false;
            txtClientSearch.Clear();
        }

        public void FillDrop()
        {
            //DropDown de los agentes
            ObjServices.GettingAllDrops(ref ddl_P_ANC_AgentName,
                                    Utility.DropDownType.Agent,
                                    "AgentName",
                                    "AgentId",
                                    corpId: ObjServices.Corp_Id,
                                    regionId: ObjServices.Region_Id,
                                    countryId: ObjServices.Country_Id,
                                    domesticregId: ObjServices.Domesticreg_Id,
                                    stateProvId: ObjServices.State_Prov_Id,
                                    cityId: ObjServices.City_Id,
                                    officeId: ObjServices.Office_Id,
                                    agentId: ObjServices.Agent_LoginId,
                                    GenerateItemSelect: true
                                   );

            ObjServices.GettingAllDrops(ref ddl_P_ANC_Relationship,
                                    Utility.DropDownType.RelationshipAgent,
                                    "RelationshipDesc",
                                    "RelationshipId",
                                    GenerateItemSelect: true
                                   );

            ObjServices.GettingAllDropsJSON(ref ddl_Office,
                                Utility.DropDownType.Office,
                                "OfficeDesc",
                                GenerateItemSelect: true
                               );

            if (pnDdlOffice.Visible)
            {                 
                if (currentTab == "ClientInfo")
                {
                    if (ObjServices.isNewCase)
                    {
                        if (ddl_Office.Items.Count > 1)
                        {
                            var dataOffice = Utility.deserializeJSON<Utility.itemOfficce>(ddl_Office.Items[1].Value);
                            ObjServices.Corp_Id = dataOffice.CorpId;
                        }
                    }
                    else setData();
                }
                else if (currentTab == "OwnerInfo")
                    setData();
            }
            else
            {
                if (currentTab == "ClientInfo")
                {
                    setData();
                }
            }
        }

        public void setData()
        {
            var Office = ObjServices.GetCurrentOfficeWithoutAgent();
            var Agent = ObjServices.GetCurrentOffice();
            var jsonOffice = Utility.serializeToJSON(Office);
            var jsonOfficeAgent = Utility.serializeToJSON(Agent);

            ddl_Office.SelectIndexByValueJSON(jsonOffice);
            ddl_Office_SelectedIndexChanged(ddl_Office, null);
            ddl_P_ANC_AgentName.SelectIndexByValueJSON(jsonOfficeAgent);
        }

        public void FillData()
        {
            if (ObjServices.Agent_Id > 0 && !ObjServices.isNewCase)
            {
                ddl_P_ANC_AgentName.SelectIndexByValueJSON(ObjServices.GetInfoAgentJSON());
              //  ddl_P_ANC_AgentName.Enabled = false;
                ddl_Office.Enabled = false;
            }

            if (currentTab == "ClientInfo")
                ddl_P_ANC_Relationship.SelectIndexByValue(ObjServices.Relationship_With_Insured_Id.HasValue ?
                     ObjServices.Relationship_With_Insured_Id.ToString() : "-1");
            else
                if (currentTab == "OwnerInfo")
                {
                    if (ObjServices.Owner_Id.HasValue && ObjServices.Owner_Id.Value != -1)
                    {
                        var objOwner = ObjServices.GetContact(ObjServices.Owner_Id.Value);

                        if (objOwner != null && objOwner.RelationshiptoAgent.HasValue)
                            ObjServices.Relationship_With_Owner_ToAgentId = objOwner.RelationshiptoAgent.Value;
                    }

                    ddl_P_ANC_Relationship.SelectIndexByValue(ObjServices.Relationship_With_Owner_ToAgentId.HasValue ?
                        ObjServices.Relationship_With_Owner_ToAgentId.ToString() : "-1");

                    /*
                      Si el Client es el mismo Owner
                      Cargar los datos                      
                    */
                    ddl_P_ANC_Relationship.Enabled = !(ObjServices.Contact_Id.Value == ObjServices.Owner_Id.Value);

                    if (ObjServices.Contact_Id.Value == ObjServices.Owner_Id.Value)
                    {
                        //Cargar la misma data
                        LoadDataFromInsured(true);
                        chkOwnerIsSameAsInsured.Checked = true;

                        var OwnerInfoContainer = this.Page.Master.FindControl("bodyContent").FindControl("ContactsInfoContainer");
                        var WUCPersonalInformation = (WUCPersonalInformation)OwnerInfoContainer.FindControl("WUCPersonalInformation");
                        var WUCAddress = (WUCAddress)OwnerInfoContainer.FindControl("WUCAddress");
                        var WUCBackgroundInformation = (WUCBackgroundInformation)OwnerInfoContainer.FindControl("WUCBackgroundInformation");
                        var WUCPhoneNumber = (WUCPhoneNumber)OwnerInfoContainer.FindControl("WUCPhoneNumber");
                        var WUCEmailAddress = (WUCEmailAddress)OwnerInfoContainer.FindControl("WUCEmailAddress");
                        var WUCIdentification = (WUCIdentification)OwnerInfoContainer.FindControl("WUCIdentification");

                        WUCPersonalInformation.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                        WUCAddress.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                        WUCBackgroundInformation.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                        WUCPhoneNumber.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                        WUCEmailAddress.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                        WUCIdentification.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                    }

                }
        }

        public void LoadDataFromInsured(Boolean Loading = false)
        {
            Entity.UnderWriting.Entities.Contact dataContact = null;

            int? ContactID = null;

            var WUCPersonalInformation = (WUCPersonalInformation)OwnerInfoContainer.FindControl("WUCPersonalInformation");
            var WUCAddress = (WUCAddress)OwnerInfoContainer.FindControl("WUCAddress");
            var WUCBackgroundInformation = (WUCBackgroundInformation)OwnerInfoContainer.FindControl("WUCBackgroundInformation");
            var WUCPhoneNumber = (WUCPhoneNumber)OwnerInfoContainer.FindControl("WUCPhoneNumber");
            var WUCEmailAddress = (WUCEmailAddress)OwnerInfoContainer.FindControl("WUCEmailAddress");
            var WUCIdentification = (WUCIdentification)OwnerInfoContainer.FindControl("WUCIdentification");

            if (Loading)
            {
                //Traer la misma data que esta en el ClientInfo                
                dataContact = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ObjServices.Contact_Id.Value, languageId: ObjServices.Language.ToInt());

                ContactID = dataContact.ContactId;


                ddl_P_ANC_Relationship.SelectIndexByValue(ObjServices.Relationship_With_Insured_Id.Value.ToString(), true);

                if (WUCPersonalInformation != null)
                {
                    WUCPersonalInformation.LoadSameDataFromInsured(dataContact);
                    WUCPersonalInformation.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                }

                if (WUCAddress != null)
                {
                    if (ObjServices.Owner_Id < 0)
                        WUCAddress.LoadSameDataFromInsured(ContactID);

                    WUCAddress.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                }

                if (WUCBackgroundInformation != null)
                {
                    WUCBackgroundInformation.LoadSameDataFromInsured(ContactID);
                    WUCBackgroundInformation.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                }

                if (WUCPhoneNumber != null)
                {
                    WUCPhoneNumber.LoadSameDataFromInsured(ContactID);
                    WUCPhoneNumber.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                }

                if (WUCEmailAddress != null)
                {
                    WUCEmailAddress.LoadSameDataFromInsured(ContactID);
                    WUCEmailAddress.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                }

                if (WUCIdentification != null)
                {
                    WUCIdentification.LoadSameDataFromInsured(ContactID);
                    WUCIdentification.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                }

            }
            else
            {
                ddl_P_ANC_Relationship.SelectedValue = "-1";
                WUCPersonalInformation.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                WUCPersonalInformation.ClearData();

                WUCAddress.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                WUCAddress.ClearData();

                WUCBackgroundInformation.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                WUCBackgroundInformation.ClearData();

                WUCPhoneNumber.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                WUCPhoneNumber.ClearData();

                WUCEmailAddress.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                WUCEmailAddress.ClearData();

                WUCIdentification.EnabledControls(!chkOwnerIsSameAsInsured.Checked);
                WUCIdentification.ClearData();
            }

        }

        public void Initialize()
        {
            OwnerInfoContainer = this.Page.Master.FindControl("bodyContent").FindControl("ContactsInfoContainer") as ContactsInfoContainer;
            ShowFormOwnerInfo += OwnerInfoContainer.ShowFormOwnerInfo;

            ClearData();

            pnDdlOffice.Visible = ObjServices.UserType == Statetrust.Framework.Security.Bll.Usuarios.UserTypeEnum.User;

            //Llenar los dropDowns
            FillDrop();

            pnOwnerIsSameAsInsured.Visible = (currentTab == "OwnerInfo");
            pnIsCompany.Visible = (currentTab == "OwnerInfo");

            ddl_P_ANC_AgentName.Enabled = (currentTab == "ClientInfo");

            var oOwner = ObjServices.GetContactInfo(Utility.ContactRoleIDType.Owner);

            ObjServices.isCompanyOwner = (oOwner != null && oOwner.ContactTypeId == Utility.ContactTypeId.Company.ToInt());

            if (!ObjServices.isNewCase)
                ddl_P_ANC_AgentName.SelectIndexByValueJSON(ObjServices.GetInfoAgentJSON());

            ddl_P_ANC_Relationship.Enabled = (currentTab == "ClientInfo");

            //Fin validacion  
            if (ObjServices.isOwnerContact)
            {
                //Visualizar el panel de la compañia
                if (ObjServices.isCompanyOwner)
                {
                    chkIsCompany.Checked = true;
                    ShowFormOwnerInfo(null, true, 1);
                }
                else
                    ShowFormOwnerInfo(null, true, 0);

                lblRelationShip.Text = RESOURCE.UnderWriting.NewBussiness.Resources.RelationshipWithOwner;
                ltSearch.Text = RESOURCE.UnderWriting.NewBussiness.Resources.SearchOwner;
            }
            else
            {
                ShowFormOwnerInfo(null, true, 0);
                ltSearch.Text = RESOURCE.UnderWriting.NewBussiness.Resources.SearchClient;
                lblRelationShip.Text = RESOURCE.UnderWriting.NewBussiness.Resources.RelationshipWithInsured;
            }

            FillData();

            if (ObjServices.IsReadOnly)
                ReadOnlyControls(ObjServices.IsReadOnly);
        }

        public void ClearData()
        {
            ClearControls(this);
        }

        protected void ddl_P_ANC_Relationship_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Guardar en la session los datos del relacion del asegurado con el agente
            if (ddl_P_ANC_Relationship.Items.Count > 0 && ddl_P_ANC_Relationship.SelectedValue != "-1")
            {
                if (ObjServices.isOwnerContact)
                    ObjServices.Relationship_With_Owner_ToAgentId = ddl_P_ANC_Relationship.ToInt();
                else
                    ObjServices.Relationship_With_Insured_Id = ddl_P_ANC_Relationship.ToInt();
            }
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

           // ObjServices.UserID = 166;

            return dataOffice;
        }

        protected void ddl_P_ANC_AgentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Otengo los valores de la oficina
            if (ddl_P_ANC_AgentName.Items.Count > 0 && ddl_P_ANC_AgentName.SelectedValue != "-1")
                SetOffice(ddl_P_ANC_AgentName.SelectedValue);

        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(this.Controls, isReadOnly);
        }

        protected void ddl_Office_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = ((DropDownList)sender);
            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                //Traer los agentes de la oficina seleccionada
                var jsonOffice = drop.SelectedValue;
                var office = SetOffice(jsonOffice);

                ObjServices.GettingAllDrops(ref ddl_P_ANC_AgentName,
                                        Utility.DropDownType.Agent,
                                        "AgentName",
                                        "AgentId",
                                        corpId: office.CorpId,
                                        regionId: office.RegionId,
                                        countryId: office.CountryId,
                                        domesticregId: office.DomesticregId,
                                        stateProvId: office.StateProvId,
                                        cityId: office.CityId,
                                        officeId: office.OfficeId,
                                        GenerateItemSelect: true
                                       );
            }

        }
    }
}