using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using DevExpress.Web;
using System.Globalization;

namespace WEB.NewBusiness.NewBusiness.UserControls.Payment
{
    public partial class WUCPayment : UC, IUC
    {
        protected void Page_Load(object sender, EventArgs e) { }
        public void Initialize() { }
        public void save() { }
        public void readOnly(bool x) { }
        public void edit() { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            gvPayment.Columns[4].Visible = !(ObjServices.IsDataReviewMode);
            Translator(string.Empty);
        }

        private Utility.itemRequestPayApi setParameterPayCardNet()
        {
            var TransactionType = string.Empty;
            var AcquiringInstitutionCode = string.Empty;
            var MerchantType = string.Empty;
            var MerchantNumber = string.Empty;
            var MerchantTerminal = string.Empty;
            var MerchantNumber_amex = string.Empty;
            var MerchantTerminal_amex = string.Empty;
            var CurrencyCode = string.Empty;

            //var ReturnUrl = "http://cardnet.atlantica.do/home/payReturn";
            //var CancelUrl = "http://cardnet.atlantica.do/home/payReturn";

            var ReturnUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/NewBusiness/Pages/ResultPayCardNet.aspx";
            var CancelUrl = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "/NewBusiness/Pages/ResultPayCardNet.aspx";

            var PageLanguaje = ObjServices.Language == Utility.Language.en ? "ENG"
                                                                           : "ESP";
            var OrdenId = string.Empty;
            var TransactionId = string.Empty;
            var MerchantName = string.Empty;
            var ITBISPorc = System.Configuration.ConfigurationManager.AppSettings["ITBISPorc"].ToInt();
            var Ipclient = Utility.NetworkingUtilities.GetLocalIpaddress().ToString();
            var Url = string.Empty;

            var ProviderId = System.Configuration.ConfigurationManager.AppSettings["ProviderId"].ToInt();

            var TransactionTypeNameKey = System.Configuration.ConfigurationManager.AppSettings["TransactionTypeNameKey"];

            var DropProviderTransactionType = ObjServices.GettingDropData(Utility.DropDownType.ProviderTransactionType, ProviderId: ProviderId);

            Entity.UnderWriting.Entities.DropDown dd = DropProviderTransactionType.FirstOrDefault(ddd => ddd.Namekey == TransactionTypeNameKey);

            var ParametersConfig = ObjServices.oPaymentManager.GetProviderParameter(new Entity.UnderWriting.Entities.Payment.Provider.Parameter
            {
                ProviderId = dd.ProviderId.Value,
                TransactionTypeCatalogId = dd.TransactionTypeCatalogId.Value,
                ProviderTransactionTypeId = dd.ProviderTransactionTypeId.Value
            });

            //Objeto de transacciones
            var dataTransacctionKey = ObjServices.oPaymentManager.GetProviderTransactionInfoKey(new Entity.UnderWriting.Entities.Payment.Provider.Transaction
            {
                ProviderId = dd.ProviderId.Value,
                TransactionTypeCatalogId = dd.TransactionTypeCatalogId.Value,
                ProviderTransactionTypeId = dd.ProviderTransactionTypeId.Value,
                UserId = ObjServices.UserID.Value
            });

            OrdenId = dataTransacctionKey.OrderId;
            TransactionId = dataTransacctionKey.TransactionId;

            foreach (var oitem in ParametersConfig)
            {
                switch (oitem.ParameterName)
                {
                    case "TransactionType":
                        TransactionType = oitem.ParameterValue;
                        break;
                    case "AcquiringInstitutionCode":
                        AcquiringInstitutionCode = oitem.ParameterValue;
                        break;
                    case "MerchantType":
                        MerchantType = oitem.ParameterValue;
                        break;
                    case "MerchantNumber":
                        MerchantNumber = oitem.ParameterValue.PadRight(15, ' ');
                        break;
                    case "MerchantTerminal":
                        MerchantTerminal = oitem.ParameterValue;
                        break;
                    case "MerchantNumber_amex":
                        MerchantNumber_amex = oitem.ParameterValue;
                        break;
                    case "MerchantTerminal_amex":
                        MerchantTerminal_amex = oitem.ParameterValue;
                        break;
                    case "Url":
                        Url = oitem.ParameterValue;
                        break;
                    case "MerchantName":
                        MerchantName = oitem.ParameterValue.PadRight(40, ' ');
                        break;
                    case "CurrencyCode":
                        CurrencyCode = oitem.ParameterValue;
                        break;
                }
            }

            var result = new Utility.itemRequestPayApi()
            {
                TransactionType = TransactionType,
                AcquiringInstitutionCode = AcquiringInstitutionCode,
                MerchantType = MerchantType,
                MerchantNumber = MerchantNumber,
                MerchantTerminal = MerchantTerminal,
                MerchantNumber_amex = MerchantNumber_amex,
                MerchantTerminal_amex = MerchantTerminal_amex,
                ReturnUrl = ReturnUrl,
                CancelUrl = CancelUrl,
                PageLanguaje = PageLanguaje,
                OrdenId = OrdenId,
                TransactionId = TransactionId,
                CurrencyCode = CurrencyCode,
                MerchantName = MerchantName,
                ITBISPorc = ITBISPorc,
                Ipclient = Ipclient,
                Url = Url
            };

            return result;
        }

        #region Eventos Comunes
        public void Translator(string Lang)
        {
            Payment.InnerHtml = Resources.PaymentsLabel;
            PeriodicPremium.InnerHtml = Resources.PeriodicPremium;
            InitialContribution.InnerHtml = Resources.InitialContributionLabel;
            FuturePayment.InnerHtml = Resources.FuturePayment;
            Total.InnerHtml = "Total";
            btnCalculate.Text = Resources.Calculate;
            btnCalculate2.Text = btnCalculate.Text;
            btnProcessPayment.Text = Resources.Process;
            btnProcessPayment2.Text = btnProcessPayment.Text;
            lblPendingForPay.InnerHtml = Resources.PendingForPay;
        }

        public delegate void PaymentProcess();
        public event PaymentProcess PaymentProcessEvent;

        public class item
        {
            public string PaymentType { get; set; }
            public string PaymentDescription { get; set; }
            public string Amount { get; set; }
            public string ResultCode { get; set; }
        }

        public void FillData()
        {
            ClearData();
            var datos = ObjServices.oPolicyManager.GetPlanData
                    (
                      ObjServices.Corp_Id
                    , ObjServices.Region_Id
                    , ObjServices.Country_Id
                    , ObjServices.Domesticreg_Id
                    , ObjServices.State_Prov_Id
                    , ObjServices.City_Id
                    , ObjServices.Office_Id
                    , ObjServices.Case_Seq_No
                    , ObjServices.Hist_Seq_No
                    );

            decimal TotalData = 0;
            decimal futurePayment = 0;
            decimal? Pagado = 0;

            if (datos != null)
            {
                if (datos.PeriodicPremium.HasValue)
                {
                    txtPeriodicPremium.Text = datos.PeriodicPremium.Value.ToString(NumberFormatInfo.InvariantInfo);
                    TotalData += datos.PeriodicPremium.Value;
                }

                if (datos.InitialContribution.HasValue)
                {
                    txtInitialContribution.Text = datos.InitialContribution.Value.ToString(NumberFormatInfo.InvariantInfo);
                    TotalData += datos.InitialContribution.Value;
                }

                if (Utility.IsDecimal(txtFuturePayment.Text))
                    TotalData += txtFuturePayment.ToDecimal();

            }

            if (ObjServices.PaymentId.HasValue)
            {
                var payment = ObjServices.oPaymentManager.GetPayment
                     (
                           ObjServices.Corp_Id
                         , ObjServices.Region_Id
                         , ObjServices.Country_Id
                         , ObjServices.Domesticreg_Id
                         , ObjServices.State_Prov_Id
                         , ObjServices.City_Id
                         , ObjServices.Office_Id
                         , ObjServices.Case_Seq_No
                         , ObjServices.Hist_Seq_No
                         , ObjServices.PaymentId.Value
                     );

                    if (payment != null)
                    {
                        if (payment.DueAmount.HasValue)
                            futurePayment = payment.DueAmount.Value - TotalData;
                    
                    }
               

                var data = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                    (
                          ObjServices.Corp_Id
                        , ObjServices.Region_Id
                        , ObjServices.Country_Id
                        , ObjServices.Domesticreg_Id
                        , ObjServices.State_Prov_Id
                        , ObjServices.City_Id
                        , ObjServices.Office_Id
                        , ObjServices.Case_Seq_No
                        , ObjServices.Hist_Seq_No
                        , ObjServices.PaymentId.Value
                        , ObjServices.Language.ToInt()
                    );

                var totalPay = data.Sum(x => x.UsdCreditAmount);

                hdntotalPay.Value = totalPay.Value.ToString("#,0.00", NumberFormatInfo.InvariantInfo);

                var Griddata = data.Select(x => new
                    {
                        x.CurrencyId,
                        x.PaymentId,
                        x.PaymentDetId,
                        x.DocumentId,
                        x.PaymentSourceTypeId,
                        x.PaymentStatusId,
                        PaymentDocumentation = x.PaymentDocumentation,
                        PaymentSourceDesc = x.PaymentSourceDesc,
                        UsdCreditAmount = x.UsdCreditAmount.GetValueOrDefault().ToFormatNumeric(),
                        PaymentStatusDesc = x.PaymentStatusDesc
                    });


                gvPayment.DataSource = Griddata;
                gvPayment.DataBind();


                Pagado = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                  (
                        ObjServices.Corp_Id
                      , ObjServices.Region_Id
                      , ObjServices.Country_Id
                      , ObjServices.Domesticreg_Id
                      , ObjServices.State_Prov_Id
                      , ObjServices.City_Id
                      , ObjServices.Office_Id
                      , ObjServices.Case_Seq_No
                      , ObjServices.Hist_Seq_No
                      , ObjServices.PaymentId.Value
                      , ObjServices.Language.ToInt()
                  ).Sum(a => a.UsdCreditAmount - a.UsdDebitAmount);


                txtFuturePayment.Text = (futurePayment).ToString(NumberFormatInfo.InvariantInfo);
                var TotalPagado = (TotalData + futurePayment);

                txtTotal.Text = TotalPagado.ToString(NumberFormatInfo.InvariantInfo);

                //Pendiente de pago
                txtPendingForPay.Text = (TotalPagado - Pagado.Value).ToString(NumberFormatInfo.InvariantInfo);

                if (payment != null)
                {
                    if (Pagado.HasValue && payment.DueAmount.HasValue)
                    {

                        if (payment.PaymentStatusId == 2) // pago pendiente
                        {
                            if (Pagado.Value == payment.DueAmount.Value)
                                MultiView1.SetActiveView(vActive);
                            else
                                MultiView1.SetActiveView(vInactive);

                            MultiView2.SetActiveView(vCalculateActive);
                            txtFuturePayment.Enabled = true;
                        }
                        else
                        {
                            MultiView1.SetActiveView(vInactive);
                            MultiView2.SetActiveView(vCalculateInactive);
                            txtFuturePayment.Enabled = false;
                        }
                    }
                } 
            }

        }

        public void ClearData()
        {
            txtFuturePayment.Text = "0";
            txtInitialContribution.Text = "0";
            txtPeriodicPremium.Text = "0";
            txtTotal.Text = "0";
            gvPayment.DataSource = null;
            gvPayment.DataBind();
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal TotalData = 0;

            if (Utility.IsDecimal(txtInitialContribution.Text))
                TotalData += txtInitialContribution.ToDecimal();

            if (Utility.IsDecimal(txtPeriodicPremium.Text))
                TotalData += txtPeriodicPremium.ToDecimal();

            if (Utility.IsDecimal(txtFuturePayment.Text))
                TotalData += txtFuturePayment.ToDecimal();

            txtTotal.Text = TotalData.ToString(NumberFormatInfo.InvariantInfo);

            if (ObjServices.PaymentId.HasValue == true)
            {
                var item = new Entity.UnderWriting.Entities.Payment.ApplyPayment();
                item.CorpId = ObjServices.Corp_Id;
                item.CityId = ObjServices.City_Id;
                item.CountryId = ObjServices.Country_Id;
                item.RegionId = ObjServices.Region_Id;
                item.StateProvId = ObjServices.State_Prov_Id;
                item.DomesticregId = ObjServices.Domesticreg_Id;
                item.OfficeId = ObjServices.Office_Id;
                item.CaseSeqNo = ObjServices.Case_Seq_No;
                item.HistSeqNo = ObjServices.Hist_Seq_No;
                item.PaymentId = ObjServices.PaymentId.Value;
                item.DueAmount = TotalData;
                item.PaidAmount = 0;
                item.PaymentStatusId = 2;
                item.UserId = ObjServices.UserID.Value;

                var payReturn = ObjServices.oPaymentManager.UpdatePayment(item);

                if (payReturn != null)
                    ObjServices.PaymentId = payReturn.PaymentId;
            }

            FillData();
        }

        /// <summary>
        /// Procesar el pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProcessPayment_Click(object sender, EventArgs e)
        {
            var GPServicesIsActive = System.Configuration.ConfigurationManager.AppSettings["GPServicesIsActive"] == "true";

            var PendingPaymentStatus = Utility.PaymentStatus.Pending.ToInt();

            //Buscar los detalles
            var pagos = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                                     (
                                           ObjServices.Corp_Id
                                         , ObjServices.Region_Id
                                         , ObjServices.Country_Id
                                         , ObjServices.Domesticreg_Id
                                         , ObjServices.State_Prov_Id
                                         , ObjServices.City_Id
                                         , ObjServices.Office_Id
                                         , ObjServices.Case_Seq_No
                                         , ObjServices.Hist_Seq_No
                                         , ObjServices.PaymentId.Value
                                         , ObjServices.Language.ToInt()
                                     );


            //Buscar los pagos de tipo tarjeta de credito que esten pendientes de pago
            var totalPayCC = pagos.Where(x => x.PaymentSourceId == 1 && x.PaymentSourceTypeId == 2 && x.PaymentStatusId == PendingPaymentStatus);

            if (totalPayCC != null && totalPayCC.Any())
            {
                this.MessageBox(Resources.ProcessPay, Title: Resources.Warning);
                return;
            }

            decimal? Pay = pagos.Sum(s => s.UsdCreditAmount - s.UsdDebitAmount);
            decimal? TotalPay = Utility.IsDecimalReturnNull(txtTotal.Text.Replace(",", "")); // busco el total que se debe

            if (!Pay.HasValue)
                return;

            if (!TotalPay.HasValue) // tiene deuda 
            {
                this.MessageBox(Resources.FullPaymentWarning, Title: Resources.Warning);
                return;
            }

            if (Pay == TotalPay) // si el pago es igual al monto entonces comienzo a procesar el pago 
            {
                var ClosePayment = true;

                string MSGError = "";

                //Si el pago esta pendiente verificar si tiene un documento
                foreach (Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail item in pagos)
                {
                    if (item.PaymentStatusId == PendingPaymentStatus)
                    {
                        if (!item.DocumentId.HasValue)
                        {
                            MSGError += Resources.TransactionNeedDocument + " : " + item.PaymentDocumentation;
                            ClosePayment = false;
                        }
                    }
                }

                if (ClosePayment)
                {
                    //Detalle del pago
                    foreach (Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail item in pagos)
                    {
                        if (item.PaymentStatusId == PendingPaymentStatus)
                        {
                            if (item.DocumentId.HasValue)
                            {
                                //Aqui cambio  el estatus a completado
                                item.ResultCode = System.Guid.NewGuid().ToString().Substring(0, 12);
                                item.PaymentStatusId = Utility.PaymentStatus.Approved.ToInt(); //aprobado
                                item.UserId = ObjServices.UserID.Value;
                                ObjServices.oPaymentManager.UpdatePaymentDetail(item);

                                if (GPServicesIsActive)
                                {
                                    var PSourceType = Utility.GetPaymentSourceType(item.PaymentSourceTypeId, item.PaymentSourceId.Value);

                                    //Construir el item de Gp
                                    var itemGp = new Utility.itemGp
                                    {
                                        pPaymentDate = item.PaidDate.HasValue? item.PaidDate.Value : DateTime.Now,
                                        pAmount = item.OriginCreditAmount.Value,
                                        DetailId = item.PaymentDetId,
                                        currencyCode = item.CurrencyId == 1 ? "USD" : "DOP",
                                        AbaNumber = item.EFTABANumber,
                                        BankAccountNumber = item.EFTAccountNumber,
                                        BankAccountType = item.AccountTypeId,
                                        BankAccountHolder = item.EFTAccountHolder,
                                        AccountNumber = item.EFTAccountNumber,
                                        AccountName = item.AccountDesc,
                                        transactionNumber = string.Empty,//Autorizacion code cardNet,                  
                                        PolicyNo = ObjServices.Policy_Id,
                                        UserName = ObjServices.UserName,
                                        PaymentSourceType = PSourceType
                                    };

                                    //Insertar pago en GP
                                    ObjServices.GP(itemGp);
                                }
                            }
                            else
                                ClosePayment = false;
                        }
                    }

                    //Cabecera del pago
                    if (ObjServices.PaymentId.HasValue)
                    {
                        Entity.UnderWriting.Entities.Payment.ApplyPayment item = ObjServices.oPaymentManager.GetPayment
                              (
                                    ObjServices.Corp_Id
                                  , ObjServices.Region_Id
                                  , ObjServices.Country_Id
                                  , ObjServices.Domesticreg_Id
                                  , ObjServices.State_Prov_Id
                                  , ObjServices.City_Id
                                  , ObjServices.Office_Id
                                  , ObjServices.Case_Seq_No
                                  , ObjServices.Hist_Seq_No
                                  , ObjServices.PaymentId.Value
                              );

                        item.PaidAmount = Pay;
                        item.PaidDate = DateTime.Now;
                        item.PaymentStatusId = 1;//completado
                        item.UserId = ObjServices.UserID.Value;
                        ObjServices.oPaymentManager.UpdatePayment(item);
                        //El tab de payment esta completado
                        ObjServices.saveSetValidTab(Utility.Tab.Payment);
                    }

                }
                else
                    this.MessageBox(MSGError, Title: Resources.Warning);
            }

            FillData();
            PaymentProcessEvent();

        }

        protected void gvPayment_PageIndexChanged(object sender, EventArgs e)
        {
            gvPayment.DataSource = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                  (
                        ObjServices.Corp_Id
                      , ObjServices.Region_Id
                      , ObjServices.Country_Id
                      , ObjServices.Domesticreg_Id
                      , ObjServices.State_Prov_Id
                      , ObjServices.City_Id
                      , ObjServices.Office_Id
                      , ObjServices.Case_Seq_No
                      , ObjServices.Hist_Seq_No
                      , ObjServices.PaymentId.Value
                      , ObjServices.Language.ToInt()
                  );
            gvPayment.DataBind();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(this.Controls, isReadOnly);
        }

        protected void gvPayment_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        protected void gvPayment_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            //Proceso de pago con tarjeta de credito
            var gv = (ASPxGridView)sender;

            var Commando = e.CommandArgs.CommandName;
            var RowIndex = e.VisibleIndex;

            var UserId = ObjServices.UserID.HasValue ? ObjServices.UserID.Value : -1;
            var pAmount = double.Parse(gv.GetKeyFromAspxGridView("UsdCreditAmount", RowIndex).ToString(), CultureInfo.InvariantCulture);
            var DocumentId = (int?)gv.GetKeyFromAspxGridView("DocumentId", RowIndex);
            var PaymentDocumentation = gv.GetKeyFromAspxGridView("PaymentDocumentation", RowIndex).ToString();
            var PaymentDetId = gv.GetKeyFromAspxGridView("PaymentDetId", RowIndex).ToInt();
            var PaymentId = gv.GetKeyFromAspxGridView("PaymentId", RowIndex).ToInt();
            var CurrencyId = gv.GetKeyFromAspxGridView("CurrencyId", RowIndex).ToInt();

            if (!DocumentId.HasValue)
            {
                var MSGError = RESOURCE.UnderWriting.NewBussiness.Resources.TransactionNeedDocument + " : " + PaymentDocumentation;
                this.MessageBox(MSGError, Title: Resources.Warning);
                return;
            }

            //Obtengo los parametros para el pago con carnet
            var parameters = setParameterPayCardNet();

            //Actualizar el campo OrderId de la tabla detalle
            ObjServices.oPaymentManager.UpdatePaymentDetailOrderId(new Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail
            {
                PaymentDetId = PaymentDetId,
                OrderId = parameters.OrdenId,
                UserId = UserId
            });

            //Construyo el objeto que le voy a enviar a CardNet
            double PorcTax = (parameters.ITBISPorc / 100);
            var pTax = (pAmount * PorcTax).ToString("#,0.00", CultureInfo.InvariantCulture);
            pTax = pTax.Replace(".", "").Replace(",", "").PadLeft(12, '0');

            var ObjPay = new Utility.itemRequestPayApi
            {
                TransactionType = parameters.TransactionType,
                CurrencyCode = parameters.CurrencyCode,
                AcquiringInstitutionCode = parameters.AcquiringInstitutionCode,
                MerchantType = parameters.MerchantType,
                MerchantNumber = parameters.MerchantNumber,
                MerchantNumber_amex = parameters.MerchantNumber_amex,
                MerchantTerminal = parameters.MerchantTerminal,
                MerchantTerminal_amex = parameters.MerchantTerminal_amex,
                ReturnUrl = parameters.ReturnUrl,
                CancelUrl = parameters.CancelUrl,
                PageLanguaje = parameters.PageLanguaje,
                OrdenId = parameters.OrdenId,
                TransactionId = parameters.TransactionId,
                Amount = pAmount.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(".", "").Replace(",", "").PadLeft(12, '0'),
                MerchantName = parameters.MerchantName,
                Ipclient = parameters.Ipclient,
                Tax = pTax,
                ITBISPorc = PorcTax,
                URLPay = parameters.Url
            };

            String StringForMD5 = String.Format(
                                                "{0}{1}{2}{3}{4}{5}",
                                                parameters.MerchantType,
                                                parameters.MerchantNumber,
                                                parameters.MerchantTerminal,
                                                parameters.TransactionId,
                                                ObjPay.Amount,
                                                ObjPay.Tax
                                              );

            ObjPay.KeyEncriptionKey = Utility.GetMD5Hash(StringForMD5).ToLower();
            //Final del objeto de CardNet

            //Escribir en el log de transacciones de pago
            ObjServices.oPaymentManager.InsertPaymentLog(new Entity.UnderWriting.Entities.Payment.Provider.Log
            {
                LogTypeId = Utility.LogTypeId.Request.ToInt(),
                CorpId = ObjServices.Corp_Id,
                CompanyId = ObjServices.CompanyId,
                ProjectId = ObjServices.ProjectId,
                OrderId = ObjPay.OrdenId,
                LogDesc = Utility.serializeToJSON<Utility.itemRequestPayApi>(ObjPay)
            });

            //Setear la transaccion
            var Transaction = ObjServices.oPaymentManager.GetProviderTransactionByOrderId(new Entity.UnderWriting.Entities.Payment.Provider.Transaction
            {
                OrderId = ObjPay.OrdenId
            });

            Transaction.TransactionId = parameters.TransactionId;
            Transaction.Amount = (decimal?)pAmount;
            Transaction.Tax = (decimal?)(pAmount * PorcTax);
            Transaction.UserId = UserId;
            ObjServices.oPaymentManager.SetProviderTransaction(Transaction);
            //Fin seteo transaccion

            var QueryStringValue = Utility.serializeToJSON<Utility.itemRequestPayApi>(ObjPay);
            var url = "'PayCardNet.aspx?Token=" + HttpUtility.UrlEncode(Utility.Encrypt_Query(QueryStringValue)) + "'";
            this.ExcecuteJScript(string.Format("ShowPopCardNetPay({0},{1},{2});", url, "-1", "-1"));
        }

    }
        #endregion
}

