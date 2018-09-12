using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Infrastructure.Providers;


namespace WEB.ConfirmationCall.UserControls.History
{
    public partial class UCEmailAndPhones : UC
    {

        #region Properties
        int DirectoryIdE
        {
            get
            {
                var directoryIdE = Session["UCEmailAndPhones.DirectoryIdE"];
                return directoryIdE == null ? 0 : Session["UCEmailAndPhones.DirectoryIdE"].ToInt();
            }
            set
            {
                Session["UCEmailAndPhones.DirectoryIdE"] = value;
            }
        }

        int DirectoryDetailIdE
        {
            get
            {
                var directoryDetailIdE = Session["UCEmailAndPhones.DirectoryDetailIdE"];
                return directoryDetailIdE == null ? 0 : Session["UCEmailAndPhones.DirectoryDetailIdE"].ToInt();
            }
            set
            {
                Session["UCEmailAndPhones.DirectoryDetailIdE"] = value;
            }
        }

        int CreateUserE
        {
            get
            {
                var createUserE = Session["UCEmailAndPhones.CreateUserE"];
                return createUserE == null ? 0 : Session["UCEmailAndPhones.CreateUserE"].ToInt();
            }
            set
            {
                Session["UCEmailAndPhones.CreateUserE"] = value;
            }
        }

        int DirectoryIdP
        {
            get
            {
                var directoryIdP = Session["UCEmailAndPhones.DirectoryIdP"];
                return directoryIdP == null ? 0 : Session["UCEmailAndPhones.DirectoryIdP"].ToInt();
            }
            set
            {
                Session["UCEmailAndPhones.DirectoryIdP"] = value;
            }
        }

        int DirectoryDetailIdP
        {
            get
            {
                var directoryDetailIdP = Session["UCEmailAndPhones.DirectoryDetailIdP"];
                return directoryDetailIdP == null ? 0 : Session["UCEmailAndPhones.DirectoryDetailIdP"].ToInt();
            }
            set
            {
                Session["UCEmailAndPhones.DirectoryDetailIdP"] = value;
            }
        }

        int CreateUserP
        {
            get
            {
                var createUserP = Session["UCEmailAndPhones.CreateUserP"];
                return createUserP == null ? 0 : Session["UCEmailAndPhones.CreateUserP"].ToInt();
            }
            set
            {
                Session["UCEmailAndPhones.CreateUserP"] = value;
            }
        }
        #endregion

        #region metodos

        public IEnumerable<Entity.UnderWriting.Entities.Contact.Email> DataEmailAddresses
        {
            get
            {
                var data = Session["UCEmailAndPhones.DataEmailAddresses"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.Contact.Email>)Session["UCEmailAndPhones.DataEmailAddresses"] : null;
            }
            set
            {
                Session["UCEmailAndPhones.DataEmailAddresses"] = value;
            }
        }

        public object GetEmailAddresses(IEnumerable<Entity.UnderWriting.Entities.Contact.Email> data)
        {
            return data;
        }


        public IEnumerable<Entity.UnderWriting.Entities.Contact.Phone> DataPhones
        {
            get
            {
                var data = Session["UCEmailAndPhones.DataPhones"];
                return data != null ? (IEnumerable<Entity.UnderWriting.Entities.Contact.Phone>)Session["UCEmailAndPhones.DataPhones"] : null;
            }
            set
            {
                Session["UCEmailAndPhones.DataPhones"] = value;
            }
        }

        public object GetPhones(IEnumerable<Entity.UnderWriting.Entities.Contact.Phone> data)
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
                        Session["ModificarEmail"] = "0";
                        FillEmails();
                        FillPhones();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        #region Llenado de Dropdown

        public IEnumerable<Entity.UnderWriting.Entities.DropDown> GetDropDownd()
        {
            return _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "Product",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
        }

        public void EmailType()
        {
            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "EmailType",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
            DrpEmailType.DataSource = lista;
            DrpEmailType.DataTextField = "DirTypeShortDesc";
            DrpEmailType.DataValueField = "DirectoryTypeId";
            DrpEmailType.DataBind();

        }


        public void PhoneType()
        {
            var lista = _services.oDropDownManager.GetDropDownByType(new DropDown.Parameter
            {
                DropDownType = "PhoneType",
                CorpId = _services.Corp_Id,
                CompanyId = UserDataProvider.CompanyId,
                ProjectId = UserDataProvider.ProjectId,
                LanguageId = UserDataProvider.LanguageId
            });
            DrpPhoneType.DataSource = lista;
            DrpPhoneType.DataTextField = "DirTypeShortDesc";
            DrpPhoneType.DataValueField = "DirectoryTypeId";
            DrpPhoneType.DataBind();
        }

        #endregion

        #region Email Address
        public void FillEmails()
        {
            //Utility.ClearAll(this.Controls);
            DataEmailAddresses = _services.oContactManager.GetCommunicatonEmail(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);
            GrdEmailAddresses.DataBind();
            EmailType();
            DirectoryIdE = 0;
            DirectoryDetailIdE = 0;
            CreateUserE = 0;
            TxtEmailAaddress.Text = "";
            CkPrimaryEmail.Checked = false;
        }

        private void EliminaEmail()
        {
            try
            {
                //Eliminar el Email            
                _services.oContactManager.DeleteCommunicaton(_services.Corp_Id, DirectoryIdE, DirectoryDetailIdE, UserDataProvider.LanguageId);
                //Llena de Nuevo el Grid con el Email Eliminado
                FillEmails();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Phone number

        public void FillPhones()
        {
            DataPhones = _services.oContactManager.GetCommunicatonPhone(_services.Corp_Id, _services.Current_Contact_Id, UserDataProvider.LanguageId);

            GrdPhones.DataBind();
            PhoneType();
            TxtPhoneNumber.Text = "";
            TxtCity.Text = "";
            TxtCountry.Text = "";
            TxtExtension.Text = "";
            CkPrimaryPhone.Checked = false;
            DirectoryIdP = 0;
            DirectoryDetailIdP = 0;
            CreateUserP = 0;
        }


        private void EliminarPhone()
        {
            try
            {


                //var corpId = e.KeyValue.ToString().Split('|')[0];
                //DirectoryIdP = e.KeyValue.ToString().Split('|')[1].ToInt();
                //DirectoryDetailIdP = e.KeyValue.ToString().Split('|')[2].ToInt();

                //var IsPrimary = e.KeyValue.ToString().Split('|')[7];
                //CreateUserP = e.KeyValue.ToString().Split('|')[8].ToInt();
                //Eliminar Telefono
                _services.oContactManager.DeleteCommunicaton(_services.Corp_Id, DirectoryIdP, DirectoryDetailIdP, UserDataProvider.UserId);
                //Llena de Nuevo el Grid con el Telefono Eliminado
                FillPhones();
            }

            catch (Exception ex)
            {


            }

        }

        #endregion

        protected void BtnCancelEmail_Click(object sender, EventArgs e)
        {
            FillEmails();
        }

        protected void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (TxtEmailAaddress.Text == "" || TxtEmailAaddress.Text.Length == 0)
            {
                Alertify.Alert("Field email is required.", this);
            }
            else
            {
                try
                {
                    //Saving Email
                    _services.oContactManager.SetEmail(new Entity.UnderWriting.Entities.Contact.Email
                    {
                        //Key
                        CorpId = _services.Corp_Id,
                        DirectoryId = DirectoryIdE,
                        DirectoryDetailId = DirectoryDetailIdE,
                        CommunicationTypeId = 2,
                        DirectoryTypeId = DrpEmailType.SelectedValue.ToInt(),
                        CommunicationType = "Email",
                        //Campos                     
                        DirectoryTypeDesc = DrpEmailType.SelectedItem.Text,
                        EmailAdress = TxtEmailAaddress.Text,
                        IsPrimary = CkPrimaryEmail.Checked,
                        ContactId = _services.Current_Contact_Id, //Esto hasta que se ponga que se seleccione si es owner,insured o additional insured
                        //Información Usuario         
                        CreateUser = CreateUserE > 0 ? CreateUserE : UserDataProvider.UserId.ToInt(),
                        ModifyUser = UserDataProvider.UserId.ToInt()
                    });
                    FillEmails();

                    Alertify.Alert("Save Sucessfully.", this);


                }
                catch (Exception ex)
                {

                }
            }
        }
        
        protected void GrdEmailAddresses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string id = e.Row.Cells[2].Text;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton db = (LinkButton)e.Row.Cells[6].Controls[0];
                db.OnClientClick = "return confirm('Are you want to delete this Work Description : " + id + "?');";
            }
        }

        protected void BtnCancelPhone_Click(object sender, EventArgs e)
        {
            FillPhones();
        }

        protected void BtnAddPhone_Click(object sender, EventArgs e)
        {
            if (TxtPhoneNumber.Text == "" || TxtPhoneNumber.Text.Length == 0)
            {
                Alertify.Alert("Field email is required.", this);

            }
            else if (TxtPhoneNumber.Text.Length < 7)
            {
                Alertify.Alert("Field email is invalid.", this);
            }else{
                try
                {
                    //Saving Email
                    _services.oContactManager.SetPhone(new Entity.UnderWriting.Entities.Contact.Phone
                    {
                        //Key
                        CorpId = _services.Corp_Id,
                        DirectoryId = DirectoryIdP,
                        DirectoryDetailId = DirectoryDetailIdP,
                        CommunicationTypeId = 1,
                        DirectoryTypeId = DrpPhoneType.SelectedValue.ToInt(),
                        CountryCode = TxtCountry.Text,
                        AreaCode = TxtCity.Text,
                        CommunicationType = "Phone",
                        //Campos                     
                        DirectoryTypeDesc = DrpPhoneType.SelectedItem.Text,
                        PhoneNumber = TxtPhoneNumber.Text,
                        PhoneExt = TxtExtension.Text,
                        IsPrimary = CkPrimaryPhone.Checked,
                        ContactId = _services.Current_Contact_Id, //Esto hasta que se ponga que se seleccione si es owner,insured o additional insured
                        //Información Usuario         
                        CreateUser = CreateUserP > 0 ? CreateUserP : UserDataProvider.UserId.ToInt(),
                        ModifyUser = UserDataProvider.UserId.ToInt()
                    });
                    FillPhones();

                    Alertify.Alert("Save Sucessfully.", this);
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var index = gridRow.RowIndex;
            //ModificarLineaAddress(index);
        }


        protected void BtnDeletePhone_Click(object sender, EventArgs e)
        {

            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var index = gridRow.RowIndex;
            // EliminaLIneaPhone(index);

        }


        protected void BtnEditPhone_Click(object sender, EventArgs e)
        {

            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var index = gridRow.RowIndex;
            // ModificarLineaPhone(index);

        }

        protected void GrdEmailAddresses_RowCommand1(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var KeyValues = e.KeyValue.ToString().Split('|');
            var corpId = KeyValues[0];
            DirectoryIdE = KeyValues[1].ToInt();
            DirectoryDetailIdE = KeyValues[2].ToInt();
            var EmailAddres = KeyValues[3];
            var IsPrimary = KeyValues[4];
            CreateUserE = KeyValues[6].ToInt();
            switch (((Button)e.CommandSource).CommandName)
            {
                case "Edit":
                    TxtEmailAaddress.Text = EmailAddres;
                    DrpEmailType.SelectIndexByText(KeyValues[5], false);
                    if (IsPrimary == "True")
                    {
                        CkPrimaryEmail.Checked = true;
                    }
                    else
                    {
                        CkPrimaryEmail.Checked = false;
                    }
                    break;
                case "Delete":
                    EliminaEmail();
                    break;

                default:
                    break;


            }
        }


        protected void GrdPhones_RowCommand1(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var KeyValues = e.KeyValue.ToString().Split('|');
            var corpId = KeyValues[0];
            DirectoryIdP = KeyValues[1].ToInt();
            DirectoryDetailIdP = KeyValues[2].ToInt();

            var IsPrimary = KeyValues[7];
            CreateUserP = KeyValues[8].ToInt();

            //CorpId;DirectoryId;DirectoryDetailId,CountryCode,AreaCode,PhoneNumber,PhoneExt,IsPrimary


            switch (((Button)e.CommandSource).CommandName)
            {
                case "Edit":
                    TxtCountry.Text = KeyValues[3];
                    TxtCity.Text = KeyValues[4].Replace("[", "").Replace("]", "");
                    TxtPhoneNumber.Text = KeyValues[5];
                    TxtExtension.Text = KeyValues[6];
                    DrpPhoneType.SelectIndexByText(KeyValues[9], false);
                    if (IsPrimary == "True")
                    {
                        CkPrimaryPhone.Checked = true;
                    }
                    else
                    {
                        CkPrimaryPhone.Checked = false;
                    }
                    Session["ModificarEmail"] = "1";
                    break;
                case "Delete":
                    EliminarPhone();
                    break;

                default:
                    Session["ModificarEmail"] = "0";
                    break;
            }
        }

        #region Events

        protected void dsEmailAddresses_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataEmailAddresses;
        }

        protected void GrdEmailAddresses_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GrdEmailAddresses.FocusedRowIndex = -1;
        }

        protected void GrdEmailAddresses_PageIndexChanged(object sender, EventArgs e)
        {
            GrdEmailAddresses.FocusedRowIndex = -1;
            GrdEmailAddresses.DataBind();
        }

        protected void GrdEmailAddresses_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            GrdEmailAddresses.FocusedRowIndex = -1;
        }

        protected void dsPhones_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["data"] = DataPhones;
        }

        protected void GrdPhones_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GrdPhones.FocusedRowIndex = -1;
        }

        protected void GrdPhones_PageIndexChanged(object sender, EventArgs e)
        {
            GrdPhones.FocusedRowIndex = -1;
            GrdPhones.DataBind();
        }

        protected void GrdPhones_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            GrdPhones.FocusedRowIndex = -1;
        }

        #endregion
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translate();
        }

        void Translate()
        {
            Utility.TranslateColumnsAspxGrid(this.GrdEmailAddresses);
            
            //BtnAddEmail.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Add;
            //BtnCancelEmail.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Cancel;
            
            Utility.TranslateColumnsAspxGrid(this.GrdPhones);
            
            //BtnCancelPhone.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Cancel;
            //BtnAddPhone.Text = RESOURCE.UnderWriting.ConfirmationCall.Resources.Add;
        }
    }
}