using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PersonalData
{
    public partial class UCEmailPhone : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
    {  
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
        }

        void UnderWriting.Common.IUC.Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void save()
        {

        }

        void UnderWriting.Common.IUC.readOnly(bool x)
        {
            throw new NotImplementedException();
        }

        void UnderWriting.Common.IUC.edit()
        {
            throw new NotImplementedException();
        }

        private void fillPhone(IEnumerable<Entity.UnderWriting.Entities.Contact.Phone> PhoneList = null)
        {
            var phoneData = PhoneList == null ? Services.ContactManager.GetCommunicatonPhone(Service.Corp_Id, Service.Contact_Id,Service.LanguageId) : PhoneList;

            var PhonesCount = phoneData.Count();

            gvPhone.DataSource = phoneData;
            gvPhone.DataBind();

            setPagerIndex(gvPhone, PhonesCount);
        }

        private void fillEmail(IEnumerable<Entity.UnderWriting.Entities.Contact.Email> EmailList = null)
        {
            var emailData = EmailList ?? Services.ContactManager.GetCommunicatonEmail(Service.Corp_Id, Service.Contact_Id, Service.LanguageId);

            var EmailCount = emailData.Count();

            gvEmail.DataSource = emailData;
            gvEmail.DataBind();

            setPagerIndex(gvEmail, EmailCount);
        }

        public void FillData()
        {
        
        }

        public void FillData(Entity.UnderWriting.Entities.Contact contactInfo)
        {
            fillPhone(contactInfo.Phones);
            fillEmail(contactInfo.Emails);

            Service.DropDowns.GetDropDown(ref DDLPhoneType, Language.English, DropDownType.PhoneType, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
            Service.DropDowns.GetDropDown(ref EmailTypeDDL, Language.English, DropDownType.EmailType, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
        }

        protected void AddPhoneBTN_Click(Object sender, EventArgs e)
        {
            int id = Services.ContactManager.SetPhone(new Entity.UnderWriting.Entities.Contact.Phone
            {
                CorpId = Service.Corp_Id,
                DirectoryId = -1,
                DirectoryTypeId = Convert.ToInt32(this.DDLPhoneType.SelectedValue.Split('|')[1]),
                DirectoryDetailId = -1,
                CountryCode = this.CountryCodeTxt.Text,
                AreaCode = this.AreaCodeTxt.Text,
                PhoneNumber = this.PhoneNumberTxt.Text,
                PhoneExt = this.ExtensionTxt.Text,
                IsPrimary = this.PhonePrimaryChk.Checked,
                PersonToContact = this.ContactTxt.Text,
                CommunicationType = CommType.Phone.ToString(),
                CreateUser = 1,
                ModifyUser = 1,
                ContactId = Service.Contact_Id
            });

            if (id == -2)
            {
                string message = "This Phone Number has already been added to the list";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Invalid Value');", true);
                return;
            }
            else
            {
                EmptyPhoneControls();
                fillPhone();
            }


        }
        protected void EditPhoneBTN_Click(Object sender, EventArgs e)
        {
            int RowIndex = Convert.ToInt32(this.hfdPhone.Value);
            int id = Services.ContactManager.SetPhone(new Entity.UnderWriting.Entities.Contact.Phone
            {
                CorpId = Convert.ToInt32(gvPhone.DataKeys[RowIndex]["CorpId"]),
                DirectoryId = Convert.ToInt32(gvPhone.DataKeys[RowIndex]["DirectoryId"]),
                DirectoryTypeId = Convert.ToInt32(this.DDLPhoneType.SelectedValue.Split('|')[1]),
                DirectoryDetailId = Convert.ToInt32(gvPhone.DataKeys[RowIndex]["DirectoryDetailId"]),
                CountryCode = this.CountryCodeTxt.Text,
                AreaCode = this.AreaCodeTxt.Text,
                PhoneNumber = this.PhoneNumberTxt.Text,
                PhoneExt = this.ExtensionTxt.Text,
                IsPrimary = this.PhonePrimaryChk.Checked,
                PersonToContact = this.ContactTxt.Text,
                CreateUser = 1,
                ModifyUser = 1,
                CommunicationTypeId = Convert.ToInt32(gvPhone.DataKeys[RowIndex]["CommunicationTypeId"]),
                ContactId = Service.Contact_Id
            });

            if (id == -2)
            {
                string message = "This Phone Number has already been added to the list";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Already Exist');", true);
                return;
            }
            else
            {
                EmptyPhoneControls();
                fillPhone();

            }
        }
        protected void UpdatePhone(Object sender, EventArgs e)
        {
            int RowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            this.hfdPhone.Value = RowIndex.ToString();

            UnderWriting.Common.Tools.SelectIndexByValue(ref DDLPhoneType, gvPhone.DataKeys[RowIndex]["CorpId"].ToString() + "|" + gvPhone.DataKeys[RowIndex]["DirectoryTypeId"].ToString(), false);
            this.CountryCodeTxt.Text = gvPhone.DataKeys[RowIndex]["CountryCode"] == null ? "" : gvPhone.DataKeys[RowIndex]["CountryCode"].ToString();
            this.AreaCodeTxt.Text = gvPhone.DataKeys[RowIndex]["AreaCode"] == null ? "" : gvPhone.DataKeys[RowIndex]["AreaCode"].ToString();
            this.PhoneNumberTxt.Text = gvPhone.DataKeys[RowIndex]["PhoneNumber"] == null ? "" : gvPhone.DataKeys[RowIndex]["PhoneNumber"].ToString();
            this.ExtensionTxt.Text = gvPhone.DataKeys[RowIndex]["PhoneExt"] != null ? gvPhone.DataKeys[RowIndex]["PhoneExt"].ToString() : "";
            this.ContactTxt.Text = gvPhone.DataKeys[RowIndex]["PersonToContact"] != null ? gvPhone.DataKeys[RowIndex]["PersonToContact"].ToString() : "";

            this.PhonePrimaryChk.Checked = Convert.ToBoolean(gvPhone.DataKeys[RowIndex]["IsPrimary"]);
            this.EditPhoneBTN.Visible = true;
            this.AddPhoneBTN.Visible = false;
        }
        protected void DeletePhone(Object sender, EventArgs e)
        {
            var rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            Services.ContactManager.DeleteCommunicaton(Convert.ToInt32(gvPhone.DataKeys[rowIndex]["CorpId"]), Convert.ToInt32(gvPhone.DataKeys[rowIndex]["DirectoryId"]), Convert.ToInt32(gvPhone.DataKeys[rowIndex]["DirectoryDetailId"]), 1);

            EmptyPhoneControls();
            fillPhone();
        }
        protected void AddEmailBTN_Click(Object sender, EventArgs e)
        {
            var id = Services.ContactManager.SetEmail(new Entity.UnderWriting.Entities.Contact.Email
            {
                CorpId = Service.Corp_Id,
                DirectoryId = -1,
                DirectoryTypeId = Convert.ToInt32(this.EmailTypeDDL.SelectedValue.Split('|')[1]),
                DirectoryDetailId = -1,
                EmailAdress = this.EmailAddressTxt.Text,
                IsPrimary = this.EmailPrimaryChk.Checked,
                CommunicationType = CommType.Email.ToString(),
                CreateUser = 1,
                ModifyUser = 1,
                ContactId = Service.Contact_Id
            });


            if (id == -2)
            {
                const string message = "This Email has already been added to the list";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Invalid Value');", true);
                return;
            }
            else
            {
                EmptyEmailControls();
                fillEmail();
            }
        }
        protected void EditEmailBTN_Click(Object sender, EventArgs e)
        {
            int RowIndex = Convert.ToInt32(this.hdfEmail.Value);

            int id = Services.ContactManager.SetEmail(new Entity.UnderWriting.Entities.Contact.Email
            {
                CorpId = Convert.ToInt32(gvEmail.DataKeys[RowIndex]["CorpId"]),
                DirectoryId = Convert.ToInt32(gvEmail.DataKeys[RowIndex]["DirectoryId"]),
                DirectoryTypeId = Convert.ToInt32(this.EmailTypeDDL.SelectedValue.Split('|')[1]),
                DirectoryDetailId = Convert.ToInt32(gvEmail.DataKeys[RowIndex]["DirectoryDetailId"]),
                EmailAdress = this.EmailAddressTxt.Text,
                IsPrimary = this.EmailPrimaryChk.Checked,
                CreateUser = 1,
                ModifyUser = 1,
                CommunicationTypeId = Convert.ToInt32(gvEmail.DataKeys[RowIndex]["CommunicationTypeId"]),
                  ContactId = Service.Contact_Id
            });

            if (id == -2)
            {
                string message = "This Email has already been added to the list";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Already Exist');", true);
                return;
            }
            else
            {
                EmptyEmailControls();
                fillEmail();
            }

        }
        protected void UpdateEmail(Object sender, EventArgs e)
        {
            int RowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            this.hdfEmail.Value = RowIndex.ToString();
            UnderWriting.Common.Tools.SelectIndexByValue(ref EmailTypeDDL, gvEmail.DataKeys[RowIndex]["CorpId"].ToString() + "|" + gvEmail.DataKeys[RowIndex]["DirectoryTypeId"].ToString(), false);
            this.EmailAddressTxt.Text = gvEmail.DataKeys[RowIndex]["EmailAdress"].ToString();
            this.EmailPrimaryChk.Checked = Convert.ToBoolean(gvEmail.DataKeys[RowIndex]["IsPrimary"]);
            this.EditEmailBTN.Visible = true;
            this.AddEmailBTN.Visible = false;
        }
        protected void DeleteEmail(Object sender, EventArgs e)
        {
            var rowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            Services.ContactManager.DeleteCommunicaton(Convert.ToInt32(gvEmail.DataKeys[rowIndex]["CorpId"]), Convert.ToInt32(gvEmail.DataKeys[rowIndex]["DirectoryId"]), Convert.ToInt32(gvEmail.DataKeys[rowIndex]["DirectoryDetailId"]), 1);
            EmptyEmailControls();
            fillEmail();
        }

        public void EmptyEmailControls()
        {
            //Contact = ContactManager.GetContact(SessionList.Stored.ContactInfo.Corp_Id,Service.Region_Id,Service.Country_Id,Service.Domesticreg_Id,
            //   Service.State_Prov_Id,Service.City_Id,Service.Office_Id,Service.Case_Seq_No,
            //   Service.Hist_Seq_No,Service.Contact_Id, null);

            this.EmailPrimaryChk.Checked = false;
            this.EmailAddressTxt.Text = string.Empty;
            UnderWriting.Common.Tools.SelectIndexByValue(ref EmailTypeDDL, "-1", false);
            EmailTypeDDL.SelectedIndex = -1;
            //gvEmail.DataSource = Contact.Emails;
            //gvEmail.DataBind();
            this.AddEmailBTN.Visible = true;
            this.EditEmailBTN.Visible = false;
        }
        public void EmptyPhoneControls()
        {
            //Contact = Services.ContactManager.GetContact(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id,
            //   Service.State_Prov_Id, Service.City_Id, Service.Office_Id, Service.Case_Seq_No,
            //   Service.Hist_Seq_No, Service.Contact_Id, null);

            this.PhonePrimaryChk.Checked = false;
            this.CountryCodeTxt.Text = string.Empty;
            this.AreaCodeTxt.Text = string.Empty;
            this.PhoneNumberTxt.Text = string.Empty;
            this.ExtensionTxt.Text = string.Empty;
            this.ContactTxt.Text = string.Empty;
            UnderWriting.Common.Tools.SelectIndexByValue(ref DDLPhoneType, "-1", false);
            //gvPhone.DataSource = Contact.Phones;
            //gvPhone.DataBind();
            this.AddPhoneBTN.Visible = true;
            this.EditPhoneBTN.Visible = false;
        }

        void setPagerIndex(GridView gv, int Count)
        {

            if (gv.BottomPagerRow != null)
            {
                var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
                var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
                var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
                var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
                var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
                var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


                var count = gv.PageCount;
                var index = gv.PageIndex + 1;

                indexText.Text = index.ToString();
                totalText.Text = count.ToString();

                if (index == 1)
                {
                    DisableLinkButton(lnkPrev, "prev_dis");
                    DisableLinkButton(lnkFirst, "rewd_dis");
                }
                else if (index == count)
                {
                    DisableLinkButton(lnkNext, "next_dis");
                    DisableLinkButton(lnkLast, "fwrd_dis");

                }

                var totalItems = (Literal)gv.BottomPagerRow.FindControl("totalItems");
                totalItems.Text = Count.ToString();
            }
        }

        public void DisableLinkButton(LinkButton linkButton, string disable_class)
        {

            linkButton.CssClass = disable_class;
            linkButton.Enabled = false;
        }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        protected void gvEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmail.PageIndex = e.NewPageIndex;
            gvEmail.DataBind();
            fillEmail();
        }

        protected void gvPhone_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPhone.PageIndex = e.NewPageIndex;
            gvPhone.DataBind();
            fillPhone();
        }
    }
}