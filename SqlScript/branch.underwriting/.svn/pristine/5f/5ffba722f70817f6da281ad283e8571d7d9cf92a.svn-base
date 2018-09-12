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
    public partial class UCBasicPayment : System.Web.UI.UserControl
    {
        public DropDownList _ddlFormofPayment { get { return ddlFormofPayment; } }

        public DropDownList _ddlCardType { get { return ddlCardType; } }


        protected void Page_Load(object sender, EventArgs e) { }
        protected void ddlFormofPayment_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged(object sender, EventArgs e) { }
        protected void btnSave_Click(object sender, EventArgs e) { }
        protected void btnCancel_Click(object sender, EventArgs e) { }

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
        }

        public void activeSaveButton(bool IsActive)
        {
            Utility.EnableControls(pnForm.Controls, IsActive);  
        }
    }
}