using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    public partial class UCCash : System.Web.UI.UserControl
    {
        public DropDownList _ddlFormofPayment { get { return ddlFormofPayment; } }

        public DropDownList _ddlCardType { get { return ddlCardType; } }

        public Button _btnSave { get { return btnSave; } }

        public Button _btnCancel { get { return btnCancel; } }

        //Bmarroquin 20-02-2017 incorporacion a raiz de tropicalizacion de ESA, se agrega la property 
        public DropDownList _ddlAccountHolderRelationshipOwnerInsured { get { return ddlAccountHolderRelationshipOwnerInsured; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            OriginationDate.InnerHtml = Resources.OriginationDate;
            FormofPayment.InnerHtml = Resources.FormOfPayment;
            PaymentType.InnerHtml = Resources.PaymentType;
            Name.InnerHtml = Resources.NameLabel;
            Amount.InnerHtml = Resources.AmountLabel;
            btnSave.Text = Resources.Save;
            btnProcessPayment2.Text = Resources.Save;
            btnCancel.Text = Resources.Cancel.Capitalize();
            AccountHolderRelationshipOwnerInsured.InnerHtml = Resources.AccountHolderRelationshipOwnerInsured;
        }

        protected void ddlFormofPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        public void activeSaveButton(bool IsActive = true)
        {               
            if (IsActive)
                MultiView1.SetActiveView(vActive);
            else
                MultiView1.SetActiveView(vInactive);
        }
    }
}