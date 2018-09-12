using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;

namespace WEB.ConfirmationCall.UserControls.History
{
    public partial class UCAddress : UC
    {

        #region Properties
        int DirectoryId
        {
            get
            {
                var directoryId = Session["UCAddress.DirectoryId"];
                return directoryId == null ? 0 : Session["UCAddress.DirectoryId"].ToInt();
            }
            set
            {
                Session["UCAddress.DirectoryId"] = value;
            }
        }

        int DirectoryDetailId
        {
            get
            {
                var directoryDetailId = Session["UCAddress.DirectoryDetailId"];
                return directoryDetailId == null ? 0 : Session["UCAddress.DirectoryDetailId"].ToInt();
            }
            set
            {
                Session["UCAddress.DirectoryDetailId"] = value;
            }
        }

        int CreateUser
        {
            get
            {
                var createUser = Session["UCAddress.CreateUser"];
                return createUser == null ? 0 : Session["UCAddress.CreateUser"].ToInt();
            }
            set
            {
                Session["UCAddress.CreateUser"] = value;
            }
        }
        #endregion

        #region metodos

        public IEnumerable<Entity.UnderWriting.Entities.Contact.Address> DataAddresses
        {
            get
            {
                var data = Session["UCAddress.DataAddresses"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.Contact.Address>)Session["UCAddress.DataAddresses"] : null;
            }
            set
            {
                Session["UCAddress.DataAddresses"] = value;
            }
        }

        public object GetAddresses(IEnumerable<Entity.UnderWriting.Entities.Contact.Address> data)
        {
            return data;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (_services.Current_Contact_Id > 0)
                    {
                        //Session["ModificarAddres"] = "0";
                        FillAddresses();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        #region LLenarDropbox

        public void AddresType()
        {
            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "AddressType",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                RegionId = null,
                CountryId = _services.Country_Id,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
            DrpAddressType.DataSource = lista;
            DrpAddressType.DataTextField = "DirTypeShortDesc";
            DrpAddressType.DataValueField = "DirectoryTypeId";
            DrpAddressType.DataBind();
            if (DrpAddressType.SelectedValue == "4")
            {
                LblBussineName.Visible = true;
                TxtBussineName.Visible = true;
            }
            else
            {
                LblBussineName.Visible = false;
                TxtBussineName.Visible = false;
            }
        }


        public void Country()
        {
            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "Country",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
            DrpCountry.DataSource = lista;
            DrpCountry.DataTextField = "GlobalCountryDesc";
            DrpCountry.DataValueField = "CountryId";
            DrpCountry.DataBind();
        }


        public void City()
        {
            if (DrpCountry.SelectedValue != "" && DrpState.SelectedValue != "")
            {
                var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
                {
                    DropDownType = "City",
                    CorpId = _services.Corp_Id,
                    CompanyId = UserDataProvider.CompanyId,
                    RegionId =/*1*/null,
                    CountryId = int.Parse(DrpCountry.SelectedValue),
                    StateProvId = int.Parse(DrpState.SelectedValue),
                    ProjectId = UserDataProvider.ProjectId,
                     LanguageId = UserDataProvider.LanguageId

                });
                DrpCity.DataSource = lista;
                DrpCity.DataTextField = "CityDesc";
                DrpCity.DataValueField = "CityId";
                DrpCity.DataBind();

                Session["DrpCityDataSource"] = lista;
                //hfDomesticRegionID.Value = lista.Where(d => (d.CityId.IsIntReturnNull() == null ? 0 : d.CityId) == int.Parse(string.IsNullOrEmpty(DrpCity.SelectedValue) ? "0" : DrpCity.SelectedValue)).Select(d => d.DomesticregId).ToString();

            }
        }

        public void StateProvince()
        {
            if (DrpCountry.SelectedValue != "")
            {
                var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
                {
                    DropDownType = "StateProvince",
                    CorpId = _services.Corp_Id,
                    CompanyId = UserDataProvider.CompanyId,
                    // RegionId = null,
                    CountryId = int.Parse(DrpCountry.SelectedValue),
                    ProjectId = UserDataProvider.ProjectId,
                    LanguageId = UserDataProvider.LanguageId
                });
                DrpState.DataSource = lista;
                DrpState.DataTextField = "StateProvDesc";
                DrpState.DataValueField = "StateProvId";
                DrpState.DataBind();
            }
        }

        protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            StateProvince();
            City();
        }

        protected void DrpState_SelectedIndexChanged(object sender, EventArgs e)
        {
            City();
        }
        #endregion

        #region MetodosdelGrid

        public void FillAddresses()
        {
            DataAddresses = _services.oContactManager.GetCommunicatonAdress(_services.Corp_Id, _services.Current_Contact_Id,UserDataProvider.LanguageId);
            GrdAddresses.DataBind();
            AddresType();
            Country();
            StateProvince();
            City();
            DirectoryId = -1;
            DirectoryDetailId = -1;
            txtStreetAddress.Text = "";
            TxtBussineName.Text = "";
            TxtCodePostal.Text = "";
        }

        private void EliminaAddress(int Corpid, int DirectoryId, int DirectoryDetailId)
        {
            try
            {
                //Eliminar el Email            
                _services.oContactManager.DeleteCommunicaton(Corpid, DirectoryId, DirectoryDetailId, UserDataProvider.UserId);
                //Llena de Nuevo el Grid con el Email Eliminado
                FillAddresses();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        protected void BtnCancelAddress_Click(object sender, EventArgs e)
        {
            FillAddresses();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int DomesticRegionID = 0;
                var lista = (IEnumerable<DropDown>)Session["DrpCityDataSource"];

               //  DomesticRegionID = int.Parse(lista.Where(d => (d.CityId.IsIntReturnNull() == null ? 0 : d.CityId) == int.Parse(string.IsNullOrEmpty(DrpCity.SelectedValue) ? "0" : DrpCity.SelectedValue)).Select(d => d.DomesticregId).ToString());
              // DomesticRegionID = int.Parse(lista.Where(d => d.CityId == 17).First().ToString());

                var x = lista.Where(d => d.CityId == int.Parse(DrpCity.SelectedValue)).First();
                        DomesticRegionID = x.DomesticregId.Value;

                //Saving Address
                _services.oContactManager.SetAddress(new Entity.UnderWriting.Entities.Contact.Address
                {
                    //Key
                    CorpId = _services.Corp_Id,
                    DirectoryId = DirectoryId,
                    DirectoryDetailId = DirectoryDetailId,
                    CommunicationTypeId = 4,
                    DirectoryTypeId = DrpAddressType.SelectedItem.Value.ToInt(),
                    StreetAddress = txtStreetAddress.Text,
                    RegionId = _services.Region_Id,
                    CountryId = DrpCountry.SelectedItem.Value.ToInt(),
                    // DomesticregId = _services.Domesticreg_Id,
                    DomesticregId = DomesticRegionID,
                    StateProvId = DrpState.SelectedItem.Value.ToInt(),
                    CityId = DrpCity.SelectedItem.Value.ToInt(),
                    ZipCode = TxtCodePostal.Text,
                    IsPrimary = CkPrimary.Checked,
                    DirectoryTypeDesc = DrpAddressType.SelectedItem.Text,
                    CommunicationType = "Address",
                    //CountryCode='',
                    //AreaCode='',
                    //PhoneNumber='',
                    //PhoneExt='',                
                    //Campos                                                          
                    ContactId = _services.Current_Contact_Id, //Esto hasta que se ponga que se seleccione si es owner,insured o additional insured
                    //Información Usuario
                    CreateUser = CreateUser > 0 ? CreateUser : UserDataProvider.UserId.ToInt(),
                    ModifyUser = UserDataProvider.UserId.ToInt()
                });
                FillAddresses();
            }
            catch (Exception ex)
            {


            }

        }

        protected void GrdAddresses_RowCommand1(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            try
            {
                var KeyValues = e.KeyValue.ToString().Split('|');
                var corpId = KeyValues[0];
                DirectoryId = KeyValues[1].ToInt();
                DirectoryDetailId = KeyValues[2].ToInt();
                var IsPrimary = KeyValues[9];
                CreateUser = KeyValues[10].ToInt();
                switch (((Button)e.CommandSource).CommandName)
                {
                    case "Edit":
                        DrpAddressType.SelectedValue = KeyValues[3].ToString();
                        if (DrpAddressType.SelectedValue == "4")
                        {
                            LblBussineName.Visible = false;
                            TxtBussineName.Visible = false;
                        }
                        else
                        {
                            LblBussineName.Visible = false;
                            TxtBussineName.Visible = false;
                        }
                        txtStreetAddress.Text = KeyValues[4];
                        DrpCountry.SelectedValue = KeyValues[5].ToString();
                        StateProvince();
                        City();
                        DrpCity.SelectedValue = KeyValues[6].ToString();
                        DrpState.SelectedValue = KeyValues[7].ToString();
                        TxtCodePostal.Text = KeyValues[8].ToString();
                        if (IsPrimary == "True")
                        {
                            CkPrimary.Checked = true;
                        }
                        else
                        {
                            CkPrimary.Checked = false;
                        }
                        //Session["ModificarAddres"] = "1";
                        break;
                    case "Delete":                        
                        EliminaAddress(int.Parse(corpId),DirectoryId,DirectoryDetailId);                        
                        break;

                    default:
                        Session["ModificarAddres"] = "0";
                        break;
                }
            }

            catch (Exception ex)
            {


            }

        }

        #region Events

        protected void dsAddresses_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataAddresses;
        }

        protected void GrdAddresses_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GrdAddresses.FocusedRowIndex = -1;
        }

        protected void GrdAddresses_PageIndexChanged(object sender, EventArgs e)
        {
            GrdAddresses.FocusedRowIndex = -1;
        }

        protected void GrdAddresses_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            GrdAddresses.FocusedRowIndex = -1;
        }

        #endregion


        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {

            Utility.TranslateColumnsAspxGrid(this.GrdAddresses);
            //
          //  BtnAddAddress.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Add;
           // BtnCancelAddress.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Cancel;
        }


    }
}