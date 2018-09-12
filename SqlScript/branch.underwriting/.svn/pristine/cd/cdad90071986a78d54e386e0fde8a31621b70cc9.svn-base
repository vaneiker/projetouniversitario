using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.Pages
{
    public partial class PayCardNet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                RequestValues(Request.QueryString["Token"]);
        }

        private void RequestValues(string TokenValues)
        {
            if (!string.IsNullOrEmpty(TokenValues))
            {
                //Getting Values
                var ValJson   = Utility.Decrypt_Query(TokenValues);
                var ValuesPay = Utility.deserializeJSON<Utility.itemRequestPayApi>(ValJson);

                //Setting Values
                TransactionType.Value = ValuesPay.TransactionType;
                CurrencyCode.Value = ValuesPay.CurrencyCode;
                AcquiringInstitutionCode.Value = ValuesPay.AcquiringInstitutionCode;
                MerchantType.Value = ValuesPay.MerchantType;
                MerchantNumber.Value = ValuesPay.MerchantNumber;
                MerchantNumber_amex.Value = ValuesPay.MerchantNumber_amex;
                MerchantTerminal.Value = ValuesPay.MerchantTerminal;
                MerchantTerminal_amex.Value = ValuesPay.MerchantTerminal_amex;
                ReturnUrl.Value = ValuesPay.ReturnUrl;
                CancelUrl.Value = ValuesPay.CancelUrl;
                PageLanguaje.Value = ValuesPay.PageLanguaje;
                OrdenId.Value = ValuesPay.OrdenId;
                TransactionId.Value = ValuesPay.TransactionId;
                Amount.Value = ValuesPay.Amount;
                Tax.Value = ValuesPay.Tax;
                MerchantName.Value = ValuesPay.MerchantName;               
                Ipclient.Value = ValuesPay.Ipclient;
                KeyEncriptionKey.Value = ValuesPay.KeyEncriptionKey;
                formPayNow.Action = ValuesPay.URLPay;
                Utility.ExcecuteJScript(this.Page, "document.getElementById('btnSubmit').click()");
            }

        }
    }
}