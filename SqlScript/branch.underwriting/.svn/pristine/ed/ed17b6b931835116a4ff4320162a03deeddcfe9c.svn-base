using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness; 

namespace WEB.NewBusiness.NewBusiness.UserControls.Payment
{
    public partial class WUCPaymentInformation : UC,IUC
    {
        public void ReadOnlyControls(bool isReadOnly){}
        public void save(){}
        public void edit(){}
        public void FillData(){}
        public void Initialize(){}
        public void ClearData(){}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// AQUI CAMBIA LA PARTE DECHA DEPENDIENDO EL LA FORMA DE PAGO 
        /// este evento lo dispara el control de payment form
        /// Payment_Source_Id	Payment_Source_Desc
        /// 0	                Other
        /// 1	                ACH Domicile
        /// 2	                Credit Card Domicile
        /// 3	                Check
        /// 4	                Deposit
        /// 5	                Wire
        /// 6	                ACH One Time
        /// 7	                ACH Statetrust Bank Domicile
        /// 8	                ACH  Statetrust Bank One Time
        /// 9	                Credit Card One Time
        /// 10	                Wire Promise
        /// </summary>
        /// <param name="PaymentSourceId"></param>
        public void MethodSelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId)
        { 
            string Key = PaymentSourceTypeId.ToString() + PaymentSourceId.ToString() + PaymentControlId.ToString();
            switch (Key)
            {
                case "112":
                    MtvPaymentInformation.SetActiveView(vwACHDomicile);
                    break;
                case "212":
                    MtvPaymentInformation.SetActiveView(vwCCDomicile);
                    break;
                case "411":
                    MtvPaymentInformation.SetActiveView(vwCheck);
                    break;
                case "521":
                    MtvPaymentInformation.SetActiveView(vwWire);
                    break;
                case "111":
                    MtvPaymentInformation.SetActiveView(vwACHOneTime);
                    break;
                case "122":
                    MtvPaymentInformation.SetActiveView(vwACHSTBDomicile);
                    break;
                case "121":
                    MtvPaymentInformation.SetActiveView(vwACHStb);
                    break;
                case "211":
                    MtvPaymentInformation.SetActiveView(vwCCOneTime);
                    break;
                case "531":
                    MtvPaymentInformation.SetActiveView(vwWirePromise);
                    break;
                case "611":
                    MtvPaymentInformation.SetActiveView(vwCash);
                    break;
                default:
                    MtvPaymentInformation.SetActiveView(VDefatul);
                    break;

            }

            udpPaymentInformation.Update();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            PaymentInformation.InnerHtml = Resources.PaymentInformation; 
        }       
    }
}