using DI.UnderWriting;
using DI.UnderWriting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;

namespace WEB.NewBusiness.NewBusiness.UserControls
{
    public partial class WUCAddressLegal : UC, IUC 
    {
        public String PrefixSession
        {
            get { return hdnCurrentSession_Legal.Value; }
            set { hdnCurrentSession_Legal.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            Translator("");
        }

        public void Translator(string Lang)
        {
            ltAddresses.Text = Resources.AddresessLabel;
            homeAddress.InnerHtml = Resources.HomeAddressLabel;
            //BusinessAddress.InnerHtml = Resources.BusinessAddressLabel;
            country.InnerHtml = Country2.InnerHtml = Resources.CountryLabel;
            StateProvince.InnerHtml = StateProvince2.InnerHtml = Resources.StateProvinceLabel;
            City.InnerHtml = City2.InnerHtml = Resources.CityLabel;    
            PostalCode.InnerHtml = PostalCode2.InnerHtml = Resources.PostalCodeLabel;
            copyHomeAddress_Legal.InnerHtml = Resources.CopyHomeAddressLabel;
            if (isChangingLang)
                FillDrop();
        }

        public void save()
        {

            if (ObjServices.Agent_Legal.Value > 0)
            {
                Entity.UnderWriting.Entities.Contact.Address homeAddress = null;

                //Getting All Address
                var dataAddress = ObjServices.oContactManager
                                             .GetCommunicatonAdress(ObjServices.Corp_Id, ObjServices.Agent_Legal.Value, languageId: ObjServices.Language.ToInt());

                //Direcciones de tipo Home o Casa
                var homeAddressList = dataAddress.Where(r => r.DirectoryTypeId == 5);

                if (homeAddressList.Any())
                    homeAddress = homeAddressList.OrderBy(r => r.DirectoryId).LastOrDefault();

                if (!string.IsNullOrEmpty(tb_WCU_A_HomeAddress_Legal.Text) &&
                       ddl_WUC_A_HomeCountry_Legal.SelectedValue != "-1" &&
                       ddl_WUC_A_HomeState_Legal.SelectedValue != "-1" &&
                       (ddl_WUC_A_HomeCity_Legal.SelectedValue != "-1" && ddl_WUC_A_HomeCity_Legal.Items.Count > 0)
                    )
                {
                    //Home DomesticRegID & StateID
                    var HomeState = Utility.deserializeJSON<Utility.StateProvince>(ddl_WUC_A_HomeState_Legal.SelectedValue);
                    var DocRegHome = HomeState.DomesticregId;
                    var StateHome = HomeState.StateProvId;
                    var RegionID = HomeState.RegionId;

                    var address = new Entity.UnderWriting.Entities.Contact.Address
                       {
                           //Key
                           CorpId = ObjServices.Corp_Id,
                           DirectoryId = homeAddress == null ? -1 : homeAddress.DirectoryId,
                           DirectoryDetailId = homeAddress == null ? -1 : homeAddress.DirectoryDetailId,
                           DirectoryTypeId = 5,
                           ContactId = ObjServices.Agent_Legal.Value,
                           CommunicationType = Utility.CommType.Address.ToString(),

                           //Address Info
                           StreetAddress = tb_WCU_A_HomeAddress_Legal.Text,
                           RegionId = RegionID,
                           CountryId = Convert.ToInt32(ddl_WUC_A_HomeCountry_Legal.SelectedValue),
                           DomesticregId = DocRegHome,
                           StateProvId = StateHome,
                           CityId = Convert.ToInt32(ddl_WUC_A_HomeCity_Legal.SelectedValue),
                           ZipCode = !string.IsNullOrEmpty(tb_WCU_A_HomePostalCode_Legal.Text) ? tb_WCU_A_HomePostalCode_Legal.Text : null,
                           IsPrimary = false,

                           //User
                           CreateUser = ObjServices.UserID.Value,
                           ModifyUser = ObjServices.UserID.Value,
                       };

                    //Saving Home Address
                    ObjServices.oContactManager.SetAddress(address);
                }
                else if (homeAddress != null)
                {
                    /*Utility.Tab Tab;
                    Tab = currentTab == "ClientInfo" ? Utility.Tab.ClientInfo : Utility.Tab.OwnerInfo;
                    ObjServices.saveSetValidTab(Tab, false);
                    ObjServices.oContactManager.DeleteCommunicaton(ObjServices.Corp_Id, homeAddress.DirectoryId, homeAddress.DirectoryDetailId, ObjServices.UserID.Value);
                    */
                }

                //Getting Bussines Address
                Entity.UnderWriting.Entities.Contact.Address bussinesAddress = null;

                //Direcciones de Tipo Bussines o Negocio
                var bussinesAddressList = dataAddress.Where(r => r.DirectoryTypeId == 4);

                if (bussinesAddressList.Any())
                    bussinesAddress = bussinesAddressList.OrderBy(r => r.DirectoryId).LastOrDefault();


                //Bussines Address

                if (!string.IsNullOrEmpty(tb_WCU_A_BusinessAddress_Legal.Text) &&
                       ddl_WUC_A_BusinessCountry_Legal.SelectedValue != "-1" &&
                       ddl_WUC_A_BusinessState_Legal.SelectedValue != "-1" &&
                       (ddl_WUC_A_BusinessCity_Legal.SelectedValue != "-1" && ddl_WUC_A_BusinessCity_Legal.Items.Count > 0)
                    )
                {

                    //Bussines DomesticRegID & StateID
                    var BussinesState = Utility.deserializeJSON<Utility.StateProvince>(ddl_WUC_A_BusinessState_Legal.SelectedValue);
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
                        ContactId = ObjServices.Agent_Legal.Value,
                        CommunicationType = Utility.CommType.Address.ToString(),

                        //Address Info
                        StreetAddress = tb_WCU_A_BusinessAddress_Legal.Text,
                        RegionId = RegionID,
                        CountryId = Convert.ToInt32(ddl_WUC_A_BusinessCountry_Legal.SelectedValue),
                        DomesticregId = DocRegBussines,
                        StateProvId = StateBussines,
                        CityId = Convert.ToInt32(ddl_WUC_A_BusinessCity_Legal.SelectedValue),
                        ZipCode = !string.IsNullOrEmpty(tb_WCU_A_BusinessPostalCode_Legal.Text) ? tb_WCU_A_BusinessPostalCode_Legal.Text : null,
                        IsPrimary = false,

                        //User
                        CreateUser = ObjServices.UserID.Value,
                        ModifyUser = ObjServices.UserID.Value,
                    });

                }
                else if (bussinesAddress != null)
                {
                    //ObjServices.oContactManager.DeleteCommunicaton(ObjServices.Corp_Id, bussinesAddress.DirectoryId, bussinesAddress.DirectoryDetailId, ObjServices.UserID.Value);
                }
            }
        }

        public void EnabledControls(bool x)
        {
            EnabledControls(frmAddress_Legal.Controls, x);
            udpAddress_Legal.Update();
        }

        public void edit()
        {

        }

        public void LoadSameDataFromInsured(int? Agent_Legal)
        {
            if (Agent_Legal != null)
            {
                var dataAddress = ObjServices.oContactManager.GetCommunicatonAdress(this.ObjServices.Corp_Id, Agent_Legal.Value, languageId: ObjServices.Language.ToInt());
                hdnTotalAddress_Legal.Value = dataAddress.Count().ToString();
                if (dataAddress.Any())
                {
                    foreach (var item in dataAddress)
                    {
                        //Bussines
                        switch (item.DirectoryTypeId)
                        {
                            //Business
                            case 4:
                                setDataForm(item, false);
                                break;
                            //Home
                            case 5:
                                setDataForm(item, true);
                                break;
                        }
                    }
                }
            }
            else
            {
                FillDrop();
                ClearControls();
            }
        }

        public void FillData()
        {
            var dataAddress = ObjServices.GetCommunicatonAdressJuridico(); 

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

            hdnTotalAddress_Legal.Value = dataAddress.Count().ToString();
            udpAddress_Legal.Update();
        }

        public void FillDrop()
        {
            //Llenar el dropDpown de Home Country
            ObjServices.GettingAllDrops(ref ddl_WUC_A_HomeCountry_Legal,
                                    Utility.DropDownType.CountryOfResidence,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                     GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Home Country
            ObjServices.GettingAllDrops(ref ddl_WUC_A_BusinessCountry_Legal,
                                    Utility.DropDownType.CountryOfResidence,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropdown de Bussines Country
            ObjServices.GettingAllDrops(ref ddl_WUC_A_BusinessCountry_Legal,
                                    Utility.DropDownType.Country,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                    );

        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession_Legal.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void Initialize()
        {
            Utility.ClearAll(frmAddress_Legal.Controls);
            FillDrop();
            FillData();

            if (ObjServices.IsDataReviewMode)
                EnabledControls(!(currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id));
        }

        protected void ddlContry_Legal_SelectedIndexChanged(object sender, EventArgs e) 
        {
            var drop = (sender as DropDownList);

            var TargetDrop = (drop == ddl_WUC_A_HomeCountry_Legal) ? ddl_WUC_A_HomeState_Legal : ddl_WUC_A_BusinessState_Legal; 

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                //Llenar el dropdown de HomeState
                ObjServices.GettingAllDrops(ref TargetDrop,
                                        Utility.DropDownType.StateProvince,
                                       "StateProvDesc",
                                       "StateProvId",
                                        corpId: ObjServices.Corp_Id,
                                        countryId: int.Parse(drop.SelectedValue),
                                        GenerateItemSelect: true                                         
                                       );

                ddlState_Legal_SelectedIndexChanged(TargetDrop, null);
            }
            else
                TargetDrop.Items.Clear();
        }

        protected void ddlState_Legal_SelectedIndexChanged(object sender, EventArgs e)
        {

            var drop = (sender as DropDownList);

            var TargetDrop = (drop == ddl_WUC_A_HomeState_Legal) ? ddl_WUC_A_HomeCity_Legal : ddl_WUC_A_BusinessCity_Legal; 

            if (drop.Items.Count > 0 && drop.SelectedValue != "-1")
            {
                var KeyStateProvince = Utility.deserializeJSON<Utility.StateProvince>(drop.SelectedValue);

                if (drop.SelectedIndex > 0)
                {
                    //Llenar el dropdown de HomeState
                    ObjServices.GettingAllDrops(ref TargetDrop,
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
            {
                TargetDrop.Items.Clear();

                if (drop == ddl_WUC_A_BusinessState_Legal)
                    ddl_WUC_A_BusinessCity_Legal.Items.Clear();
                else ddl_WUC_A_HomeCity_Legal.Items.Clear();
            }
        }

        protected void btn_WCU_A_CopyHomeAddress_Click(object sender, EventArgs e)
        {
            //Copiar
            ddl_WUC_A_BusinessCountry_Legal.SelectIndexByValue(ddl_WUC_A_HomeCountry_Legal.SelectedValue);
            ddlContry_Legal_SelectedIndexChanged(ddl_WUC_A_BusinessCountry_Legal, null);
            ddl_WUC_A_BusinessState_Legal.SelectIndexByValue(ddl_WUC_A_HomeState_Legal.SelectedValue);
            ddlState_Legal_SelectedIndexChanged(ddl_WUC_A_BusinessState_Legal, null);
            ddl_WUC_A_BusinessCity_Legal.SelectIndexByValue(ddl_WUC_A_HomeCity_Legal.SelectedValue);

            tb_WCU_A_BusinessAddress_Legal.Text = tb_WCU_A_HomeAddress_Legal.Text;
            tb_WCU_A_BusinessPostalCode_Legal.Text = tb_WCU_A_HomePostalCode_Legal.Text;

        }

        public void ClearData(String value = "")
        {
            PrefixSession = value;
            ClearData();
        }

        public void ClearData()
        {
            ddl_WUC_A_BusinessCity_Legal.Items.Clear();
            ddl_WUC_A_BusinessCountry_Legal.Items.Clear();
            ddl_WUC_A_BusinessState_Legal.Items.Clear();

            ddl_WUC_A_HomeCity_Legal.Items.Clear();
            ddl_WUC_A_HomeCountry_Legal.Items.Clear();
            ddl_WUC_A_HomeState_Legal.Items.Clear();

            ClearControls(this);
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.Address item, Boolean isHome)
        {
            if (isHome)
            {
                tb_WCU_A_HomeAddress_Legal.Text = item.StreetAddress;

                //Set Country and Fill States
                ddl_WUC_A_HomeCountry_Legal.SelectIndexByValue(item.CountryId.ToString());
                ddlContry_Legal_SelectedIndexChanged(ddl_WUC_A_HomeCountry_Legal, null);

                //Set State and Fill Cities
                var dbState = new Utility.StateProvince() { CorpId = item.CorpId, CountryId = item.CountryId, DomesticregId = item.DomesticregId, RegionId = item.RegionId, StateProvId = item.StateProvId };
                var x = Utility.serializeToJSON(dbState);

                ddl_WUC_A_HomeState_Legal.SelectIndexByValueJSON(x);

                ddlState_Legal_SelectedIndexChanged(ddl_WUC_A_HomeState_Legal, null);
                //Set City

                ddl_WUC_A_HomeCity_Legal.SelectIndexByValue(item.CityId.ToString());

                tb_WCU_A_HomePostalCode_Legal.Text = !string.IsNullOrEmpty(item.ZipCode) ? item.ZipCode : string.Empty;
            }
            else
            {
                tb_WCU_A_BusinessAddress_Legal.Text = item.StreetAddress;

                //Set Country and Fill States
                ddl_WUC_A_BusinessCountry_Legal.SelectIndexByValue(item.CountryId.ToString());
                ddlContry_Legal_SelectedIndexChanged(ddl_WUC_A_BusinessCountry_Legal, null);

                //Set State and Fill Cities
                var dbState = new Utility.StateProvince() { CorpId = item.CorpId, CountryId = item.CountryId, DomesticregId = item.DomesticregId, RegionId = item.RegionId, StateProvId = item.StateProvId };
                var x = Utility.serializeToJSON(dbState);

                ddl_WUC_A_BusinessState_Legal.SelectIndexByValueJSON(x);


                ddlState_Legal_SelectedIndexChanged(ddl_WUC_A_BusinessState_Legal, null);

                //Set City
                ddl_WUC_A_BusinessCity_Legal.SelectIndexByValue(item.CityId.ToString());

                tb_WCU_A_BusinessPostalCode_Legal.Text = !string.IsNullOrEmpty(item.ZipCode) ? item.ZipCode : string.Empty;
            }
            udpAddress_Legal.Update();
        }

        protected void chkCopyHomeAddress_Legal_CheckedChanged(object sender, EventArgs e) 
        {
            if (((ddl_WUC_A_HomeCountry_Legal.SelectedValue == "-1" || ddl_WUC_A_HomeCountry_Legal.SelectedValue == "") ||
                (ddl_WUC_A_HomeState_Legal.SelectedValue == "-1" || ddl_WUC_A_HomeState_Legal.SelectedValue == "") ||
                (ddl_WUC_A_HomeCity_Legal.SelectedValue == "-1" || ddl_WUC_A_HomeCity_Legal.SelectedValue == "") ||
                string.IsNullOrWhiteSpace(tb_WCU_A_HomeAddress_Legal.Text)) && chkCopyHomeAddress_Legal.Checked)
            {
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.CompleteHomeAddressWarning, Title: Resources.Warning);
                chkCopyHomeAddress_Legal.Checked = false;
            }
            else
            {   //Copiar
                ddl_WUC_A_BusinessCountry_Legal.SelectIndexByValue(chkCopyHomeAddress_Legal.Checked ? ddl_WUC_A_HomeCountry_Legal.SelectedValue : "-1");
                ddlContry_Legal_SelectedIndexChanged(ddl_WUC_A_BusinessCountry_Legal, null);
                ddl_WUC_A_BusinessState_Legal.SelectIndexByValue(chkCopyHomeAddress_Legal.Checked ? ddl_WUC_A_HomeState_Legal.SelectedValue : "-1");
                ddlState_Legal_SelectedIndexChanged(ddl_WUC_A_BusinessState_Legal, null);
                ddl_WUC_A_BusinessCity_Legal.SelectIndexByValue(chkCopyHomeAddress_Legal.Checked ? ddl_WUC_A_HomeCity_Legal.SelectedValue : "-1");

                tb_WCU_A_BusinessAddress_Legal.Text = chkCopyHomeAddress_Legal.Checked ? tb_WCU_A_HomeAddress_Legal.Text : string.Empty;
                tb_WCU_A_BusinessPostalCode_Legal.Text = chkCopyHomeAddress_Legal.Checked ? tb_WCU_A_HomePostalCode_Legal.Text : string.Empty;
            }
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(frmAddress_Legal.Controls, isReadOnly);
            udpAddress_Legal.Update();
        }
    }
}