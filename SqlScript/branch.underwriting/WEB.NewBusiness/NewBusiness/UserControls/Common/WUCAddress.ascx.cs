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
    public partial class WUCAddress : UC, IUC
    {
        public String PrefixSession
        {
            get { return hdnCurrentSession.Value; }
            set { hdnCurrentSession.Value = value; }
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
            copyHomeAddress.InnerHtml = Resources.CopyHomeAddressLabel;
            if (isChangingLang)
                FillDrop();
        }

        public void save()
        {

            if (ObjServices.ContactEntityID.Value > 0)
            {
                Entity.UnderWriting.Entities.Contact.Address homeAddress = null;

                //Getting All Address
                var dataAddress = ObjServices.oContactManager
                                             .GetCommunicatonAdress(ObjServices.Corp_Id, ObjServices.ContactEntityID.Value, languageId: ObjServices.Language.ToInt());

                //Direcciones de tipo Home o Casa
                var homeAddressList = dataAddress.Where(r => r.DirectoryTypeId == 5);

                if (homeAddressList.Any())
                    homeAddress = homeAddressList.OrderBy(r => r.DirectoryId).LastOrDefault();

                if (!string.IsNullOrEmpty(tb_WCU_A_HomeAddress.Text) &&
                       ddl_WUC_A_HomeCountry.SelectedValue != "-1" &&
                       ddl_WUC_A_HomeState.SelectedValue != "-1" &&
                       (ddl_WUC_A_HomeCity.SelectedValue != "-1" && ddl_WUC_A_HomeCity.Items.Count > 0)
                    )
                {
                    //Home DomesticRegID & StateID
                    var HomeState = Utility.deserializeJSON<Utility.StateProvince>(ddl_WUC_A_HomeState.SelectedValue);
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
                           ContactId = ObjServices.ContactEntityID.Value,
                           CommunicationType = Utility.CommType.Address.ToString(),

                           //Address Info
                           StreetAddress = tb_WCU_A_HomeAddress.Text,
                           RegionId = RegionID,
                           CountryId = Convert.ToInt32(ddl_WUC_A_HomeCountry.SelectedValue),
                           DomesticregId = DocRegHome,
                           StateProvId = StateHome,
                           CityId = Convert.ToInt32(ddl_WUC_A_HomeCity.SelectedValue),
                           ZipCode = !string.IsNullOrEmpty(tb_WCU_A_HomePostalCode.Text) ? tb_WCU_A_HomePostalCode.Text : null,
                           IsPrimary = true,  //IsPrimary = false, //Lgonzalez 29-03-2017
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

                if (!string.IsNullOrEmpty(tb_WCU_A_BusinessAddress.Text) &&
                       ddl_WUC_A_BusinessCountry.SelectedValue != "-1" &&
                       ddl_WUC_A_BusinessState.SelectedValue != "-1" &&
                       (ddl_WUC_A_BusinessCity.SelectedValue != "-1" && ddl_WUC_A_BusinessCity.Items.Count > 0)
                    )
                {

                    //Bussines DomesticRegID & StateID
                    var BussinesState = Utility.deserializeJSON<Utility.StateProvince>(ddl_WUC_A_BusinessState.SelectedValue);
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
                        StreetAddress = tb_WCU_A_BusinessAddress.Text,
                        RegionId = RegionID,
                        CountryId = Convert.ToInt32(ddl_WUC_A_BusinessCountry.SelectedValue),
                        DomesticregId = DocRegBussines,
                        StateProvId = StateBussines,
                        CityId = Convert.ToInt32(ddl_WUC_A_BusinessCity.SelectedValue),
                        ZipCode = !string.IsNullOrEmpty(tb_WCU_A_BusinessPostalCode.Text) ? tb_WCU_A_BusinessPostalCode.Text : null,
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
            EnabledControls(frmAddress.Controls, x);
            udpAddress.Update();
        }

        public void edit()
        {

        }

        public void LoadSameDataFromInsured(int? ContactID)
        {
            if (ContactID != null)
            {
                var dataAddress = ObjServices.oContactManager.GetCommunicatonAdress(this.ObjServices.Corp_Id, ContactID.Value, languageId: ObjServices.Language.ToInt());
                hdnTotalAddress.Value = dataAddress.Count().ToString();
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

            hdnTotalAddress.Value = dataAddress.Count().ToString();
            udpAddress.Update();
        }

        public void FillDrop()
        {
            //Llenar el dropDpown de Home Country
            ObjServices.GettingAllDrops(ref ddl_WUC_A_HomeCountry,
                                    Utility.DropDownType.CountryOfResidence,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                     GenerateItemSelect: true
                                   );

            //Llenar el dropDpown de Home Country
            ObjServices.GettingAllDrops(ref ddl_WUC_A_BusinessCountry,
                                    Utility.DropDownType.CountryOfResidence,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropdown de Bussines Country
            ObjServices.GettingAllDrops(ref ddl_WUC_A_BusinessCountry,
                                    Utility.DropDownType.Country,
                                    "GlobalCountryDesc",
                                    "CountryId",
                                    GenerateItemSelect: true
                                    );

        }

        public void Initialize(String value = "")
        {
            hdnCurrentSession.Value = String.IsNullOrEmpty(value) ? "" : value;
            Initialize();
        }

        public void Initialize()
        {
            Utility.ClearAll(frmAddress.Controls);
            FillDrop();
            FillData();

            if (ObjServices.IsDataReviewMode)
                EnabledControls(!(currentTab == "OwnerInfo" && ObjServices.Contact_Id == ObjServices.Owner_Id));
        }

        protected void ddlContrySelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = (sender as DropDownList);

            var TargetDrop = (drop == ddl_WUC_A_HomeCountry) ? ddl_WUC_A_HomeState : ddl_WUC_A_BusinessState;

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

                ddlStateSelectedIndexChanged(TargetDrop, null);
            }
            else
                TargetDrop.Items.Clear();
        }

        protected void ddlStateSelectedIndexChanged(object sender, EventArgs e)
        {

            var drop = (sender as DropDownList);

            var TargetDrop = (drop == ddl_WUC_A_HomeState) ? ddl_WUC_A_HomeCity : ddl_WUC_A_BusinessCity;

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

                if (drop == ddl_WUC_A_BusinessState)
                    ddl_WUC_A_BusinessCity.Items.Clear();
                else ddl_WUC_A_HomeCity.Items.Clear();
            }
        }

        protected void btn_WCU_A_CopyHomeAddress_Click(object sender, EventArgs e)
        {
            //Copiar
            ddl_WUC_A_BusinessCountry.SelectIndexByValue(ddl_WUC_A_HomeCountry.SelectedValue);
            ddlContrySelectedIndexChanged(ddl_WUC_A_BusinessCountry, null);
            ddl_WUC_A_BusinessState.SelectIndexByValue(ddl_WUC_A_HomeState.SelectedValue);
            ddlStateSelectedIndexChanged(ddl_WUC_A_BusinessState, null);
            ddl_WUC_A_BusinessCity.SelectIndexByValue(ddl_WUC_A_HomeCity.SelectedValue);

            tb_WCU_A_BusinessAddress.Text = tb_WCU_A_HomeAddress.Text;
            tb_WCU_A_BusinessPostalCode.Text = tb_WCU_A_HomePostalCode.Text;

        }

        public void ClearData(String value = "")
        {
            PrefixSession = value;
            ClearData();
        }

        public void ClearData()
        {
            ddl_WUC_A_BusinessCity.Items.Clear();
            ddl_WUC_A_BusinessCountry.Items.Clear();
            ddl_WUC_A_BusinessState.Items.Clear();

            ddl_WUC_A_HomeCity.Items.Clear();
            ddl_WUC_A_HomeCountry.Items.Clear();
            ddl_WUC_A_HomeState.Items.Clear();

            ClearControls(this);
        }

        public void setDataForm(Entity.UnderWriting.Entities.Contact.Address item, Boolean isHome)
        {
            if (isHome)
            {
                tb_WCU_A_HomeAddress.Text = item.StreetAddress;

                //Set Country and Fill States
                ddl_WUC_A_HomeCountry.SelectIndexByValue(item.CountryId.ToString());
                ddlContrySelectedIndexChanged(ddl_WUC_A_HomeCountry, null);

                //Set State and Fill Cities
                var dbState = new Utility.StateProvince() { CorpId = item.CorpId, CountryId = item.CountryId, DomesticregId = item.DomesticregId, RegionId = item.RegionId, StateProvId = item.StateProvId };
                var x = Utility.serializeToJSON(dbState);

                ddl_WUC_A_HomeState.SelectIndexByValueJSON(x);

                ddlStateSelectedIndexChanged(ddl_WUC_A_HomeState, null);
                //Set City

                ddl_WUC_A_HomeCity.SelectIndexByValue(item.CityId.ToString());

                tb_WCU_A_HomePostalCode.Text = !string.IsNullOrEmpty(item.ZipCode) ? item.ZipCode : string.Empty;
            }
            else
            {
                tb_WCU_A_BusinessAddress.Text = item.StreetAddress;

                //Set Country and Fill States
                ddl_WUC_A_BusinessCountry.SelectIndexByValue(item.CountryId.ToString());
                ddlContrySelectedIndexChanged(ddl_WUC_A_BusinessCountry, null);

                //Set State and Fill Cities
                var dbState = new Utility.StateProvince() { CorpId = item.CorpId, CountryId = item.CountryId, DomesticregId = item.DomesticregId, RegionId = item.RegionId, StateProvId = item.StateProvId };
                var x = Utility.serializeToJSON(dbState);

                ddl_WUC_A_BusinessState.SelectIndexByValueJSON(x);


                ddlStateSelectedIndexChanged(ddl_WUC_A_BusinessState, null);

                //Set City
                ddl_WUC_A_BusinessCity.SelectIndexByValue(item.CityId.ToString());

                tb_WCU_A_BusinessPostalCode.Text = !string.IsNullOrEmpty(item.ZipCode) ? item.ZipCode : string.Empty;
            }
            udpAddress.Update();
        }

        protected void chkCopyHomeAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (((ddl_WUC_A_HomeCountry.SelectedValue == "-1" || ddl_WUC_A_HomeCountry.SelectedValue == "") ||
                (ddl_WUC_A_HomeState.SelectedValue == "-1" || ddl_WUC_A_HomeState.SelectedValue == "") ||
                (ddl_WUC_A_HomeCity.SelectedValue == "-1" || ddl_WUC_A_HomeCity.SelectedValue == "") ||
                string.IsNullOrWhiteSpace(tb_WCU_A_HomeAddress.Text)) && chkCopyHomeAddress.Checked)
            {
                this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.CompleteHomeAddressWarning, Title: Resources.Warning);
                chkCopyHomeAddress.Checked = false;
            }
            else
            {   //Copiar
                ddl_WUC_A_BusinessCountry.SelectIndexByValue(chkCopyHomeAddress.Checked ? ddl_WUC_A_HomeCountry.SelectedValue : "-1");
                ddlContrySelectedIndexChanged(ddl_WUC_A_BusinessCountry, null);
                ddl_WUC_A_BusinessState.SelectIndexByValue(chkCopyHomeAddress.Checked ? ddl_WUC_A_HomeState.SelectedValue : "-1");
                ddlStateSelectedIndexChanged(ddl_WUC_A_BusinessState, null);
                ddl_WUC_A_BusinessCity.SelectIndexByValue(chkCopyHomeAddress.Checked ? ddl_WUC_A_HomeCity.SelectedValue : "-1");

                tb_WCU_A_BusinessAddress.Text = chkCopyHomeAddress.Checked ? tb_WCU_A_HomeAddress.Text : string.Empty;
                tb_WCU_A_BusinessPostalCode.Text = chkCopyHomeAddress.Checked ? tb_WCU_A_HomePostalCode.Text : string.Empty;
            }
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(frmAddress.Controls, isReadOnly);
            udpAddress.Update();
        }
    }
}