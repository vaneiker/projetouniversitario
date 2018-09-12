using DevExpress.Web;
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
    public partial class WUCContactList : UC, IUC
    {
        public WUCContactInformation oWUCContactInformation;

        public void ClearData() { }
        public void save() { }
        public void edit() { }
        public void ReadOnlyControls(bool isReadOnly) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            btnAddNewContact.Text = Resources.AddNewContact;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            oWUCContactInformation = this.Page.Master.FindControl("bodyContent")
                                                     .FindControl("ContactContainer")
                                                     .FindControl("WUCContactInformation") as WUCContactInformation;

            if (!IsPostBack)
                gvContactList.SetFilterSettings();
        }

        public void ShowFormContact()
        {
            ObjServices.PagerSize = 12;
            var hdnShowFormAddNewContact = this.Parent.FindControl("hdnShowFormAddNewContact");
            var udpHiddenFields = this.Parent.FindControl("udpHiddenFields");
            ((HiddenField)hdnShowFormAddNewContact).Value = "true";
            ((UpdatePanel)udpHiddenFields).Update();
        }

        protected void btnAddNewContact_Click(object sender, EventArgs e)
        {
            ObjServices.isNewCase = false;

            ShowFormContact();

            if (oWUCContactInformation != null)
            {
                ObjServices.ContactEntityID = -1;
                oWUCContactInformation.ClearData();
                oWUCContactInformation.Initialize();
            }

            var udpHiddenFields = this.Parent.FindControl("udpHiddenFields");

            var isEdit = this.Parent.FindControl("isEdit");
            ((HiddenField)isEdit).Value = "false";

            var hfMenuAccordeonContact = this.Parent.FindControl("hfMenuAccordeonContact");
            ((HiddenField)hfMenuAccordeonContact).Value = "acc1|1";

            try
            {
                var pnIllustration = oWUCContactInformation.FindControl("pnIllustration");
                ((Panel)oWUCContactInformation.FindControl("pnIllustration")).Visible = false;
            }
            catch (Exception) { }
            ((UpdatePanel)udpHiddenFields).Update();

        }


        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjServices.GettingContactByAgent(ObjServices.isUser ? -1 : ObjServices.Agent_LoginId,
                                                        Utility.ContactTypeId.Contact).OrderBy(x => x.FirstName).ToList();
            e.KeyExpression = "ContactId;FirstName;LastName";
            e.QueryableSource = data.AsQueryable();
        }

        public void FillData()
        {
            gvContactList.DataBind();
        }

        public void Initialize()
        {
            FillData();

            if (ObjServices.PagerSize == 12)
            {
                btnAddNewContact_Click(btnAddNewContact, null);
                return;
            }
        }

        protected void SetVariables(int RowIndex)
        {
            ObjServices.Contact_Id = int.Parse(gvContactList.GetKeyFromAspxGridView("ContactId", RowIndex).ToString());
            ObjServices.isNewCase = false;
        }

        protected void gvContactList_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            var RowIndex = e.VisibleIndex;

            SetVariables(RowIndex);

            switch (Commando)
            {
                case "Modify":

                    ObjServices.ContactEntityID = ObjServices.Contact_Id;
                    var isEdit = this.Parent.FindControl("isEdit");
                    (oWUCContactInformation.FindControl("pnIllustration") as Panel).Visible = true;
                    (isEdit as HiddenField).Value = "true";

                    var hfMenuAccordeonContact = this.Parent.FindControl("hfMenuAccordeonContact");

                    if (hfMenuAccordeonContact != null)
                        (hfMenuAccordeonContact as HiddenField).Value = "acc1|1";

                    if (oWUCContactInformation != null)
                    {
                        ShowFormContact();
                        FillData();
                        oWUCContactInformation.Initialize();
                    }

                    break;
            }
        }

        protected void gvContactList_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            if (e.CallbackName == "APPLYFILTER")
                gvContactList.SetFilterSettings();

            this.ExcecuteJScript("fixheight();");
        }

        protected void gvContactList_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }
    }
}