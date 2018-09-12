using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation
{
    public partial class WUCAdditionalInformation : UC, IUC
    {
        public void ReadOnlyControls(bool isReadOnly) { }
        public void edit() { }
        protected void Page_Load(object sender, EventArgs e) { }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");

            if (isChangingLang)
                FillDrop();
        }

        public void Translator(string Lang)
        {
            FirstName.InnerHtml = Resources.FirstNameLabel;
            LastName.InnerHtml = Resources.LastNameLabel;
            Email.InnerHtml = Resources.EmailAddressLabel;
            Referredby.InnerHtml = Resources.Referredby;
            AdditionalInformation.InnerHtml = Resources.AdditionalInformationLabel;
        }

        public void save()
        {
            int? ReferredByContactID = null;

            if (ObjServices.ContactEntityID.HasValue && ObjServices.ContactEntityID.Value > 0)
            {
                var DataContact = ObjServices.GetContact(ObjServices.ContactEntityID.Value);

                ReferredByContactID = DataContact.ReferredByContactId;

                if (ddlReferredBy.SelectedValue != "-1" &&
                    !string.IsNullOrEmpty(txtFirtName.Text) &&
                    !string.IsNullOrEmpty(txtLastName.Text) &&
                    !string.IsNullOrEmpty(txtEmail.Text))
                {
                    var itemContact = new Entity.UnderWriting.Entities.Contact()
                    {
                        CorpId = ObjServices.Corp_Id,
                        //Bmarroquin 02-02-2017 - Esto generaba que tronara un FK, se le manda -1 
                        //AgentId = ObjServices.Agent_Id.Value,
                        AgentId = -1,
                        FirstName = txtFirtName.Text,
                        FirstLastName = txtLastName.Text
                    };

                    if (!ReferredByContactID.HasValue)
                    {
                        //Crear el refered by
                        ReferredByContactID = ObjServices.oContactManager.InsertContact(itemContact);
                        //Adjuntar al contacto
                        DataContact.ReferredByContactId = ReferredByContactID;
                        DataContact.ReferredByRelationshipId = ddlReferredBy.ToInt();
                        ObjServices.oContactManager.UpdateContact(DataContact);
                    }
                    else
                    {
                        //Actualizar el contacto
                        itemContact.ContactId = ReferredByContactID.Value;
                        ObjServices.oContactManager.UpdateContact(itemContact);
                    }

                    var dataEmail = ObjServices.oContactManager.GetCommunicatonEmail(ObjServices.Corp_Id, ReferredByContactID.Value, languageId: ObjServices.Language.ToInt());
                    var isEdit = dataEmail.Any();

                    //Guardar el Email
                    var item = new Entity.UnderWriting.Entities.Contact.Email()
                    {
                        //Key
                        CorpId = ObjServices.Corp_Id,
                        DirectoryId = (isEdit) ? dataEmail.First().DirectoryId : -1,
                        DirectoryDetailId = (isEdit) ? dataEmail.First().DirectoryDetailId : -1,
                        CommunicationType = Utility.CommType.Email.ToString(),
                        ContactId = ReferredByContactID.Value,

                        //Campos 
                        DirectoryTypeId = 2,
                        DirectoryTypeDesc = "PERSONAL",
                        EmailAdress = txtEmail.Text,
                        IsPrimary = true,

                        //Información Usuario
                        CreateUser = ObjServices.UserID.Value,
                        ModifyUser = ObjServices.UserID.Value
                    };

                    //Guardar el correo
                    ObjServices.oContactManager.SetEmail(item);
                }
            }

        }

        public void FillDrop()
        {
            ObjServices.GettingAllDrops(ref ddlReferredBy,
                                 Utility.DropDownType.RelationshipReferred,
                                 "RelationshipDesc",
                                 "RelationshipId",
                                 GenerateItemSelect: true
                                 );
        }

        public void FillData()
        {
            if (ObjServices.ContactEntityID.HasValue && ObjServices.ContactEntityID.Value > 0)
            {
                var dataContact = ObjServices.GetContact(ObjServices.ContactEntityID.Value);
                if (dataContact.ReferredByContactId.HasValue)
                {
                    var dataReferedBy = ObjServices.GetContact(dataContact.ReferredByContactId.Value);
                    if (dataReferedBy != null)
                    {
                        txtFirtName.Text = dataReferedBy.FirstName;
                        txtLastName.Text = dataReferedBy.FirstLastName;
                        //Buscar el email
                        var DataEmail = ObjServices.oContactManager.GetCommunicatonEmail(ObjServices.Corp_Id, dataContact.ReferredByContactId.Value, languageId: ObjServices.Language.ToInt());

                        if (DataEmail != null)
                            txtEmail.Text = DataEmail.First().EmailAdress;

                        ddlReferredBy.SelectIndexByValue(dataContact.ReferredByRelationshipId.ToString());
                    }
                }

            }
        }

        public void Initialize()
        {
            FillDrop();
            FillData();
        }

        public void ClearData()
        {
            Utility.ClearAll(this.Controls);
        }
    }
}