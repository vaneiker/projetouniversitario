using CollectorsModule.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CollectorsModule.ell;
using CollectorsModule.bll.Services;
using Collectors.Helpers;
using CollectorsModule.Commons;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml.Linq;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace CollectorsModule.Controls
{
    public partial class ucPaymentMethod : System.Web.UI.UserControl
    {
        public String UserName
        {
            get
            {
                Statetrust.Framework.Security.Bll.Usuarios User = (Statetrust.Framework.Security.Bll.Usuarios)Session["userData"];
                return User.UserLogin;
            }
        }
        public String CheckBookID
        {
            get
            {
                String ckbookID = US.Value.getCheckBookID(this.UserName);
                return (string.IsNullOrEmpty(ckbookID) ? (ConfigurationManager.AppSettings["Default-CheckBookID"] ?? string.Empty).ToString() : US.Value.getCheckBookID(UserName));
            }
        }
        public String KTUserName
        {
            get
            {
                String ktUser = US.Value.getKTUserName(this.UserName);
                return (string.IsNullOrEmpty(ktUser) ? this.UserName : US.Value.getKTUserName(UserName));
            }
        }
        private string ActiveView
        {
            get
            {
                return (string)Session["ActiveView"];
            }

            set
            {
                Session["ActiveView"] = value;
            }
        }
        public string amountToBePaid
        {
            get
            {
                return this.txtAmountToBePaid.Text;
            }
            set
            {
                this.txtAmountToBePaid.Text = value;
            }
        }
        public bool backStep
        {
            get
            {
                btnBack_Click(null, EventArgs.Empty);
                return true;
            }
        }
        public bool resetPayment
        {
            get
            {
                this.ddlPaymentForm.SelectedIndex = -1;
                setFields(this.ddlPaymentForm.SelectedItem.Value);
                return true;
            }
        }
        public bool OnlyDOP
        {
            get { return ((ConfigurationManager.AppSettings["DEF::OnlyDOP"] ?? "0") == "1"); }
        }
        private Collectors.Helpers.Enums.SystemData SystemData
        {
            get
            {
                return string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["SystemData"]) ? Collectors.Helpers.Enums.SystemData.GP : (Collectors.Helpers.Enums.SystemData)Enum.Parse(typeof(Collectors.Helpers.Enums.SystemData), System.Configuration.ConfigurationManager.AppSettings["SystemData"].ToString().ToUpper());
            }
        }
        Lazy<ClientSearchService> CSS = new Lazy<ClientSearchService>();
        Lazy<ProviderServices> PTS = new Lazy<ProviderServices>();
        Lazy<PaymentsService> PS = new Lazy<PaymentsService>();
        Lazy<UtilitiesServices> US = new Lazy<UtilitiesServices>();
        Lazy<svcKwikTag.BridgeClient> bridge = new Lazy<svcKwikTag.BridgeClient>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsCallback && !IsPostBack)
            {
                bindControls();
                setFields(this.ddlPaymentForm.SelectedItem.Value);
            }
            if ((this.Page as Pages.ProcessPayments).ActiveView == "3" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwPaymentMethod")
            {
                (this.Page as Pages.ProcessPayments).setStep2 = true;
                (this.Page as Pages.ProcessPayments).setStep3 = true;
            }
            if ((this.Page as Pages.ProcessPayments).ActiveView == "3" && ((this.Page as Pages.ProcessPayments).getActiveView() == "vwSearchClient" || (this.Page as Pages.ProcessPayments).getActiveView() == "vwPoliciesPayments"))
            {
                ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = "1";
            }
            if ((this.Page as Pages.ProcessPayments).ActiveView == "2" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwPoliciesPayments")
            {
                this.txtAmountToBePaid.Text = (this.Page as Pages.ProcessPayments).amountToBePaid;
                svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters()
                {
                    apiURL = null,
                    callingID = null,
                    companyID = null,
                    drawer = null,
                    password = null,
                    userName = ((string.IsNullOrEmpty(KTUserName) || UserName == "varodriguez") ? null : KTUserName),
                    siteName = null,
                    barcode = null
                };
                this.txtCurrentTag.Text = Kwiktag.nextBarcodeByUser(KTUserName, parameters);
                (this.Page as Pages.ProcessPayments).setStep3 = false;
            }
        }

        private void bindControls()
        {
            this.ddlAccountType.DataSource = PS.Value.getListAccountType();
            this.ddlAccountType.DataTextField = "Bnk_Accnt_Type_Desc";
            this.ddlAccountType.DataValueField = "Bank_Account_Type_Id";
            this.ddlAccountType.DataBind();
            this.ddlAccountType.SelectedIndex = -1;

            this.ddlCreditCardType.DataSource = PS.Value.getListCardType();
            this.ddlCreditCardType.DataTextField = "Card_Type_Desc";
            this.ddlCreditCardType.DataValueField = "Card_Type_Id";
            this.ddlCreditCardType.DataBind();
            this.ddlCreditCardType.SelectedIndex = -1;

            /* Standard Version, before checkbook dynamically selected by user.
            this.ddlBanksInformation.DataSource = CSS.Value.getListBankType();
            this.ddlBanksInformation.DataTextField = "BANKNAME";
            this.ddlBanksInformation.DataValueField = "DEX_ROW_ID";
            this.ddlBanksInformation.DataBind();
            this.ddlBanksInformation.SelectedIndex = -1;
            */
            this.ddlBanksInformation.DataSource = CSS.Value.getListBankCheckbookTypeNames();
            this.ddlBanksInformation.DataTextField = "Bank_Name_Desc";
            this.ddlBanksInformation.DataValueField = "Bank_Name_Desc";
            this.ddlBanksInformation.DataBind();
            ddlBanksInformation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            this.ddlBanksInformation.SelectedIndex = -1;

            this.ddlDepositAccount.DataSource = null;
            this.ddlDepositAccount.DataBind();
        }

        protected void ddlPaymentForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFields(this.ddlPaymentForm.SelectedItem.Value);
        }

        private void setFields(string paymentform)
        {
            switch (paymentform.ToUpper().Trim())
            {
                case "CREDITCARD":
                    pnlTransfAndDeposit.Visible = pnlACH.Visible = pnlCheck.Visible = false;
                    pnlCreditCard.Visible = true;
                    break;
                case "CASH":
                    pnlTransfAndDeposit.Visible = pnlCreditCard.Visible = pnlACH.Visible = pnlCheck.Visible = false;
                    break;
                case "CHECK":
                    pnlTransfAndDeposit.Visible = pnlCreditCard.Visible = pnlACH.Visible = false;
                    pnlTransfAndDeposit.Visible = pnlCheck.Visible = true;
                    break;
                case "ACH":
                    pnlTransfAndDeposit.Visible = pnlCreditCard.Visible = pnlCheck.Visible = false;
                    pnlACH.Visible = true;
                    break;
                case "TRANSFER":
                case "DEPOSIT":
                    pnlACH.Visible = pnlCreditCard.Visible = pnlCheck.Visible = false;
                    pnlTransfAndDeposit.Visible = true;
                    break;
                default:
                    break;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            changeView(2);
            clearControls();
            clearPayments();
            this.txtAmountToBePaid.Text = string.Empty;
            (this.Page as Pages.ProcessPayments).setStep3 = false;
        }

        private void changeView(int view)
        {
            ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = view.ToString();
            (this.Page as Pages.ProcessPayments).setActiveView(view);
        }

        private void clearControls()
        {
            txtBankACH.Text =
            txtAccountNumber.Text =
            txtAbaNumber.Text =
            txtAccountOwnerID.Text =
            txtAuthorizationCode.Text =
            txtCreditCardNumber.Text =
            txtBankCheck.Text =
            txtAccountHolder.Text =
            txtCheckNumber.Text = string.Empty;
            bindControls();
        }

        private void clearPayments()
        {
            (this.Page as Pages.ProcessPayments).dopPayments = null;
            (this.Page as Pages.ProcessPayments).usdPayments = null;
            this.txtAmountToBePaid.Text = string.Empty;
        }

        protected void btnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                bool havePayments = false;
                if ((this.Page as Pages.ProcessPayments).paymentsList != null)
                    havePayments = PS.Value.getHaveRecentPayments((this.Page as Pages.ProcessPayments).paymentsList.FirstOrDefault().Policy_No);

                if (havePayments)
                {
                    //this.btnPaymentConfirmation.Attributes.Add("OnClick", Page.ClientScript.GetPostBackEventReference(this.btnProcessPayment, string.Empty));
                    Utils.JSExec(this, "paymentConfirmation(true);");
                }
                else
                {
                    ProcessPayment(this, e);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ProcessPayment(object sender, EventArgs e)
        {
            try
            {
                foreach (var pmts in (this.Page as Pages.ProcessPayments).paymentsList)
                {
                    Guid id = Guid.NewGuid();
                    string batch = id.ToString();
                    String OrderId = Guid.NewGuid().ToString();
                    String projectName = System.Configuration.ConfigurationManager.AppSettings["ProjectName"];
                    switch (this.ddlPaymentForm.SelectedItem.Value.ToUpper().Trim())
                    {
                        case "CREDITCARD":
                            CreditCardPayments payment = new CreditCardPayments()
                            {
                                AmountToPay = pmts.PaidAmount.HasValue ? pmts.PaidAmount.Value : default(decimal),
                                Policy_No = pmts.Policy_No,
                                CreditCardMaskedNumber = this.txtCreditCardNumber.Text,
                                AuthorizationCode = this.txtAuthorizationCode.Text,
                                CreditCardType = this.ddlCreditCardType.SelectedItem.Text,
                                CreditCardTypeId = int.Parse(this.ddlCreditCardType.SelectedItem.Value),
                                CurrencyID = pmts.Currency_Id.HasValue ? pmts.Currency_Id.Value : default(int),
                                DueDate = pmts.DueDate,
                                Comments = this.txtComments.Text.Trim()
                            };
                            var paymentResult = this.PaymentCreditCard(payment, OrderId, projectName, 1, UserName, pmts.Full_Name, batch, this.txtCurrentTag.Text.Trim());
                            if (paymentResult.result)
                            {
                                pmts.ResponseCode = "1001";
                                pmts.PaymentNumber = paymentResult.PaymentNumber;
                                pmts.CustomerBalance = paymentResult.CustomerBalance;
                                pmts.KwikTag = paymentResult.KwikTag;
                            }
                            else
                            {
                                pmts.PaidAmount = 0;
                                pmts.ResponseCode = "1004";
                            }
                            break;
                        case "CASH":
                            Payment paymentCash = new Payment()
                            {
                                DueAmount = pmts.PaidAmount.HasValue ? pmts.PaidAmount.Value : default(decimal),
                                Policy_No = pmts.Policy_No,
                                Currency_Id = pmts.Currency_Id.HasValue ? pmts.Currency_Id.Value : default(int),
                                DueDate = pmts.DueDate,
                                Comments = this.txtComments.Text.Trim()
                            };
                            var paymentResultCash = this.PaymentCash(paymentCash, OrderId, projectName, 1, UserName, pmts.Full_Name, batch, this.txtCurrentTag.Text.Trim());
                            if (paymentResultCash.result)
                            {
                                pmts.ResponseCode = "1001";
                                pmts.PaymentNumber = paymentResultCash.PaymentNumber;
                                pmts.CustomerBalance = paymentResultCash.CustomerBalance;
                                pmts.KwikTag = paymentResultCash.KwikTag;
                            }
                            else
                            {
                                pmts.PaidAmount = 0;
                                pmts.ResponseCode = "1004";
                                Utils.JSExec(this, "SendAlert('Ocurrió un error a la hora de procesar el pago, favor validar que el pago no haya sido aplicado (ver histórico de pagos) e intente nuevamente. Si el error persiste, favor contacte al personal técnico.');");
                            }
                            break;
                        case "ACH":
                            ACHPayments paymentACH = new ACHPayments()
                            {
                                DueAmount = pmts.PaidAmount.HasValue ? pmts.PaidAmount.Value : default(decimal),
                                Policy_No = pmts.Policy_No,
                                Currency_Id = pmts.Currency_Id.HasValue ? pmts.Currency_Id.Value : default(int),
                                DueDate = pmts.DueDate,
                                AccountHolder = this.txtAccountHolder.Text,
                                AcountNumber = this.txtAccountNumber.Text,
                                AccountType = int.Parse(this.ddlAccountType.SelectedItem.Value),
                                RouteNumber = this.txtAbaNumber.Text,
                                AcountId = this.txtAccountOwnerID.Text,
                                Comments = this.txtComments.Text.Trim()
                            };
                            var paymentResultACH = this.PaymentACH(paymentACH, OrderId, projectName, 1, UserName, pmts.Full_Name, batch, this.txtCurrentTag.Text.Trim());
                            if (paymentResultACH.result)
                            {
                                pmts.ResponseCode = "1001";
                                pmts.PaymentNumber = paymentResultACH.PaymentNumber;
                                pmts.CustomerBalance = paymentResultACH.CustomerBalance;
                                pmts.KwikTag = paymentResultACH.KwikTag;
                            }
                            else
                            {
                                pmts.PaidAmount = 0;
                                pmts.ResponseCode = "1004";
                            }
                            break;
                        case "CHECK":
                            CheckPayments paymentCheck = new CheckPayments()
                            {
                                DueAmount = pmts.PaidAmount.HasValue ? pmts.PaidAmount.Value : default(decimal),
                                Policy_No = pmts.Policy_No,
                                Currency_Id = pmts.Currency_Id.HasValue ? pmts.Currency_Id.Value : default(int),
                                DueDate = pmts.DueDate,
                                CheckNumber = this.txtCheckNumber.Text,
                                Comments = this.txtComments.Text.Trim()
                            };
                            var paymentResultCheck = this.PaymentCheck(paymentCheck, OrderId, projectName, 1, UserName, pmts.Full_Name, batch, this.txtCurrentTag.Text.Trim());
                            if (paymentResultCheck.result)
                            {
                                pmts.ResponseCode = "1001";
                                pmts.PaymentNumber = paymentResultCheck.PaymentNumber;
                                pmts.CustomerBalance = paymentResultCheck.CustomerBalance;
                                pmts.KwikTag = paymentResultCheck.KwikTag;
                            }
                            else
                            {
                                pmts.PaidAmount = 0;
                                pmts.ResponseCode = "1004";
                            }
                            break;
                        case "TRANSFER":
                            Payment paymentTransfer = new Payment()
                            {
                                DueAmount = pmts.PaidAmount.HasValue ? pmts.PaidAmount.Value : default(decimal),
                                Policy_No = pmts.Policy_No,
                                Currency_Id = pmts.Currency_Id.HasValue ? pmts.Currency_Id.Value : default(int),
                                DueDate = pmts.DueDate,
                                Comments = this.txtComments.Text.Trim()
                            };
                            var paymentResultTransfer = this.PaymentCash(paymentTransfer, OrderId, projectName, 1, UserName, pmts.Full_Name, batch, this.txtCurrentTag.Text.Trim());
                            if (paymentResultTransfer.result)
                            {
                                pmts.ResponseCode = "1001";
                                pmts.PaymentNumber = paymentResultTransfer.PaymentNumber;
                                pmts.CustomerBalance = paymentResultTransfer.CustomerBalance;
                                pmts.KwikTag = paymentResultTransfer.KwikTag;
                            }
                            else
                            {
                                pmts.PaidAmount = 0;
                                pmts.ResponseCode = "1004";
                                Utils.JSExec(this, "SendAlert('Ocurrió un error a la hora de procesar el pago, favor validar que el pago no haya sido aplicado (ver histórico de pagos) e intente nuevamente. Si el error persiste, favor contacte al personal técnico.');");
                            }
                            break;
                        case "DEPOSIT":
                            Payment paymentDeposit = new Payment()
                            {
                                DueAmount = pmts.PaidAmount.HasValue ? pmts.PaidAmount.Value : default(decimal),
                                Policy_No = pmts.Policy_No,
                                Currency_Id = pmts.Currency_Id.HasValue ? pmts.Currency_Id.Value : default(int),
                                DueDate = pmts.DueDate,
                                Comments = this.txtComments.Text.Trim()
                            };
                            var paymentResultDeposit = this.PaymentCash(paymentDeposit, OrderId, projectName, 1, UserName, pmts.Full_Name, batch, this.txtCurrentTag.Text.Trim());
                            if (paymentResultDeposit.result)
                            {
                                pmts.ResponseCode = "1001";
                                pmts.PaymentNumber = paymentResultDeposit.PaymentNumber;
                                pmts.CustomerBalance = paymentResultDeposit.CustomerBalance;
                                pmts.KwikTag = paymentResultDeposit.KwikTag;
                            }
                            else
                            {
                                pmts.PaidAmount = 0;
                                pmts.ResponseCode = "1004";
                                Utils.JSExec(this, "SendAlert('Ocurrió un error a la hora de procesar el pago, favor validar que el pago no haya sido aplicado (ver histórico de pagos) e intente nuevamente. Si el error persiste, favor contacte al personal técnico.');");
                            }
                            break;
                        default:
                            Utils.JSExec(this, "SendAlert('No se ha podido detectar la forma de pagos, el pago no fue aplicado, reinicie el proceso.');");
                            break;
                    }
                }
                clearControls();
                changeView(4);
                (this.Page as Pages.ProcessPayments).paymentForm = this.ddlPaymentForm.SelectedItem.Text;
                var gv = (this.Page as Pages.ProcessPayments).setGrid;
            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error procesando pagos para usuario: " + UserName, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error procesando pagos para usuario: " + UserName, "btnProcessPayment_Click(object sender, EventArgs e)");
            }
        }

        public PaymentsResult PaymentCreditCard(CreditCardPayments payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)
        {
            PaymentsResult result = new PaymentsResult();
            try
            {
                GPPaymentsvc.GPPaymentsClient gpPayment = new GPPaymentsvc.GPPaymentsClient();
                GPPaymentsvc.CreditCardPayment ccPayment = new GPPaymentsvc.CreditCardPayment();

                ccPayment.ReceivedBy = UserName;
                ccPayment.SourcePlatform = ProjectName;
                ccPayment.SourceTransactionID = OrderId;
                ccPayment.PaymentDate = DateTime.Now;
                ccPayment.PaymentAmount = payment.AmountToPay;
                ccPayment.PolicyNumber = payment.Policy_No;
                ccPayment.CurrencyID = PS.Value.getCurrencyByCurrencyID(payment.CurrencyID).Currency_Desc;
                ccPayment.CreditCardMaskedCardNumber = payment.CreditCardMaskedNumber;
                ccPayment.CreditCardProcessorTransactionNumber = payment.AuthorizationCode;
                ccPayment.CreditCardIssuer = payment.CreditCardType;
                ccPayment.PaymentNotes = payment.Comments;
                ccPayment.CheckbookID = CheckBookID;

                var gpResult = gpPayment.NewCreditCardPayment(ccPayment);


                try
                {
                    PTS.Value.SetProviderLog(new ProviderLogs()
                    {
                        Project_Id = (Int32)Collectors.Helpers.Enums.Project_Id.STGPaymentModuleCash,
                        Corp_Id = (Int32)Collectors.Helpers.Enums.Corp_Id.STG,
                        Log_Type_Id = (Int32)Collectors.Helpers.Enums.Log_Type_Id.Request,
                        Company_Id = (Int32)Collectors.Helpers.Enums.Company_Id.ATL,
                        Log_Desc = JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = payment.AmountToPay, @DueDate = payment.DueDate, @CurrencyID = payment.CurrencyID }),
                        Order_Id = OrderId
                    });
                }
                catch (Exception ex)
                {

                }

                if (gpResult.Result)
                {
                    if (SystemData == Collectors.Helpers.Enums.SystemData.Global)
                    {
                        PolicyID policy = CSS.Value.GetPolicyIdByPolicyNumber(payment.Policy_No);
                        var head = PS.Value.SetPaymentHead(policy, payment.AmountToPay);
                        var pmtHead = PS.Value.SetPayments(head);
                        PS.Value.SetPaymentDetail(head,
                                              pmtHead.FirstOrDefault().Payment_Id.ToString(),
                                              payment.AmountToPay,
                                              gpResult.PaymentNumber,
                                              gpResult.CustomerBalance,
                                              payment.Policy_No,
                                              UserId,
                                              policy
                                             );
                    }
                    result.result = true;
                    result.PaymentNumber = gpResult.PaymentNumber;
                    result.CustomerBalance = gpResult.CustomerBalance;

                    #region Call KwikTag Service
                    List<KwiktagProps.Tags> tagLst = new List<KwiktagProps.Tags>();
                    tagLst.Add(new KwiktagProps.Tags { Property = "Company ID", Value = (ConfigurationManager.AppSettings["ktCompanyID"] ?? "Atlantica Insurance S.A.").ToString() });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Receipt", Value = gpResult.PaymentNumber });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Credit Card ID", Value = (payment.CreditCardType ?? string.Empty).ToUpper() });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Customer ID", Value = payment.Policy_No });
                    tagLst.Add(new KwiktagProps.Tags { Property = "File Name", Value = "Scanned" });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Comments", Value = string.Empty });

                    svcKwikTag.EstructureTags[] tags = new svcKwikTag.EstructureTags[tagLst.Count];
                    svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters()
                    {
                        apiURL = null,
                        callingID = null,
                        companyID = null,
                        drawer = null,
                        password = null,
                        userName = ((string.IsNullOrEmpty(KTUserName) || UserName == "epimentel") ? null : KTUserName),
                        siteName = null,
                        barcode = (!string.IsNullOrEmpty(currentTag)) ? (int.Parse(currentTag) - 1).ToString() : null
                    };

                    for (int i = 0; i < tagLst.Count; i++)
                    {
                        tags[i] = new svcKwikTag.EstructureTags { Property = tagLst[i].Property, Value = tagLst[i].Value };
                    }
                    var ktBarcodeResponse = Kwiktag.KTSyncTag(tags, parameters);
                    XmlDocument xmlDoc = new XmlDocument();
                    XDocument xd = XDocument.Parse(ktBarcodeResponse);
                    //xmlDoc.LoadXml(ktBarcodeResponse);

                    XElement bc = (from xml in xd.Descendants("Barcode")
                                   select xml).FirstOrDefault();
                    string ktBarcode = (bc.Value ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(ktBarcode))
                        try
                        {
                            Utils.ErrorLogDB("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                            Utils.SendError("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, "EmptyTag()");
                        }
                        catch (Exception) { }
                    var resultKTonGP = US.Value.setKTagByPayment(gpResult.PaymentNumber, ktBarcode, JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = payment.AmountToPay, @DueDate = payment.DueDate, @CurrencyID = payment.CurrencyID, @Barcode = ktBarcode, @CustomerBalance = result.CustomerBalance, @Full_Name = Full_Name, @Payment_Form = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)2)), @Cashier = UserName }), batch);
                    result.KwikTag = ktBarcode;
                    #endregion
                }
                else
                {
                    try
                    {
                        Utils.ErrorLogDB("Error! pago retorno falso para la poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                    }
                    catch (Exception) { }
                    result.result = false;
                }

            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error procesando pagos en credit card para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error procesando pagos en credit card para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "PaymentCreditCard(CreditCardPayments payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)");
                result.result = false;
            }
            return result;
        }

        public PaymentsResult PaymentCash(Payment payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)
        {
            PaymentsResult result = new PaymentsResult();
            try
            {
                var checkBookID = CheckBookID;
                if (this.ddlDepositAccount.SelectedValue != string.Empty)
                {
                    checkBookID = this.ddlDepositAccount.SelectedValue;
                }
                GPPaymentsvc.GPPaymentsClient gpPayment = new GPPaymentsvc.GPPaymentsClient();
                GPPaymentsvc.CashPayment cashPayment = new GPPaymentsvc.CashPayment();
                cashPayment.ReceivedBy = UserName;
                cashPayment.SourcePlatform = ProjectName;
                cashPayment.SourceTransactionID = OrderId;
                cashPayment.PaymentDate = DateTime.Now;
                cashPayment.PaymentAmount = payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m;
                cashPayment.PolicyNumber = payment.Policy_No;
                cashPayment.CurrencyID = PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc;
                cashPayment.PaymentNotes = payment.Comments;
                cashPayment.CheckbookID = checkBookID;

                var gpResult = gpPayment.NewCashPayment(cashPayment);

                try
                {
                    PTS.Value.SetProviderLog(new ProviderLogs()
                    {
                        Project_Id = (Int32)Collectors.Helpers.Enums.Project_Id.STGPaymentModuleCash,
                        Corp_Id = (Int32)Collectors.Helpers.Enums.Corp_Id.STG,
                        Log_Type_Id = (Int32)Collectors.Helpers.Enums.Log_Type_Id.Request,
                        Company_Id = (Int32)Collectors.Helpers.Enums.Company_Id.ATL,
                        Log_Desc = JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = payment.DueAmount, @DueDate = payment.DueDate, @CurrencyID = payment.Currency_Id }),
                        Order_Id = OrderId
                    });
                }
                catch (Exception ex)
                {
                }

                if (gpResult.Result)
                {
                    if (SystemData == Collectors.Helpers.Enums.SystemData.Global)
                    {
                        PolicyID policy = CSS.Value.GetPolicyIdByPolicyNumber(payment.Policy_No);
                        var head = PS.Value.SetPaymentHead(policy, payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m);
                        var pmtHead = PS.Value.SetPayments(head);
                        PS.Value.SetPaymentDetail(head,
                                              pmtHead.FirstOrDefault().Payment_Id.ToString(),
                                              payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m,
                                              gpResult.PaymentNumber,
                                              gpResult.CustomerBalance,
                                              payment.Policy_No,
                                              UserId,
                                              policy
                                             );
                    }
                    result.result = true;
                    result.PaymentNumber = gpResult.PaymentNumber;
                    result.CustomerBalance = gpResult.CustomerBalance;

                    #region Call KwikTag Service
                    List<KwiktagProps.Tags> tagLst = new List<KwiktagProps.Tags>();
                    tagLst.Add(new KwiktagProps.Tags { Property = "Company ID", Value = (ConfigurationManager.AppSettings["ktCompanyID"] ?? "Atlantica Insurance S.A.").ToString() });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Receipt", Value = gpResult.PaymentNumber });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Credit Card ID", Value = string.Empty });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Customer ID", Value = payment.Policy_No });
                    tagLst.Add(new KwiktagProps.Tags { Property = "File Name", Value = "Scanned" });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Comments", Value = string.Empty });

                    svcKwikTag.EstructureTags[] tags = new svcKwikTag.EstructureTags[tagLst.Count];
                    svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters()
                    {
                        apiURL = null,
                        callingID = null,
                        companyID = null,
                        drawer = null,
                        password = null,
                        userName = ((string.IsNullOrEmpty(KTUserName) || UserName == "epimentel") ? null : KTUserName),
                        siteName = null,
                        barcode = (!string.IsNullOrEmpty(currentTag)) ? (int.Parse(currentTag) - 1).ToString() : null
                    };

                    for (int i = 0; i < tagLst.Count; i++)
                    {
                        tags[i] = new svcKwikTag.EstructureTags { Property = tagLst[i].Property, Value = tagLst[i].Value };
                    }
                    var ktBarcodeResponse = Kwiktag.KTSyncTag(tags, parameters);
                    XmlDocument xmlDoc = new XmlDocument();
                    XDocument xd = XDocument.Parse(ktBarcodeResponse);
                    //xmlDoc.LoadXml(ktBarcodeResponse);

                    XElement bc = (from xml in xd.Descendants("Barcode")
                                   select xml).FirstOrDefault();
                    string ktBarcode = (bc.Value ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(ktBarcode))
                        try
                        {
                            Utils.ErrorLogDB("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                            Utils.SendError("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, "EmptyTag()");
                        }
                        catch (Exception) { }
                    var resultKTonGP = US.Value.setKTagByPayment(gpResult.PaymentNumber, ktBarcode, JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = (payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m), @DueDate = payment.DueDate, @CurrencyID = (PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc), @Barcode = ktBarcode, @CustomerBalance = result.CustomerBalance, @Full_Name = Full_Name, @Payment_Form = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)0)), @Cashier = UserName }), batch);
                    result.KwikTag = ktBarcode;
                    #endregion
                }
                else
                {
                    try
                    {
                        Utils.ErrorLogDB("Error! pago retorno falso para la poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                    }
                    catch (Exception) { }
                    result.result = false;
                }

            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error procesando pagos en Cash para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error procesando pagos en Cash para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "PaymentCash(Payment payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)");
                result.result = false;
            }
            return result;
        }

        public PaymentsResult PaymentACH(ACHPayments payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)
        {
            PaymentsResult result = new PaymentsResult();
            try
            {
                GPPaymentsvc.GPPaymentsClient gpPayment = new GPPaymentsvc.GPPaymentsClient();
                GPPaymentsvc.ACHPayment achPayment = new GPPaymentsvc.ACHPayment();

                achPayment.ReceivedBy = UserName;
                achPayment.SourcePlatform = ProjectName;
                achPayment.SourceTransactionID = OrderId;
                achPayment.PaymentDate = DateTime.Now;
                achPayment.PaymentAmount = payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m;
                achPayment.PolicyNumber = payment.Policy_No;
                achPayment.CurrencyID = PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc;
                achPayment.BankAccountHolder = payment.AccountHolder;
                achPayment.BankAccountNumber = payment.AcountNumber;
                achPayment.BankAccountType = payment.AccountType;
                achPayment.BankRoutingNumber = payment.RouteNumber;
                achPayment.BankAccountHolderGovernmentID = payment.AcountId;
                achPayment.PaymentNotes = payment.Comments;
                achPayment.CheckbookID = CheckBookID;

                var gpResult = gpPayment.NewACHPayment(achPayment);


                try
                {
                    PTS.Value.SetProviderLog(new ProviderLogs()
                    {
                        Project_Id = (Int32)Collectors.Helpers.Enums.Project_Id.STGPaymentModuleCash,
                        Corp_Id = (Int32)Collectors.Helpers.Enums.Corp_Id.STG,
                        Log_Type_Id = (Int32)Collectors.Helpers.Enums.Log_Type_Id.Request,
                        Company_Id = (Int32)Collectors.Helpers.Enums.Company_Id.ATL,
                        Log_Desc = JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = payment.DueAmount, @DueDate = payment.DueDate, @CurrencyID = payment.Currency_Id }),
                        Order_Id = OrderId
                    });
                }
                catch (Exception ex)
                {

                }

                if (gpResult.Result)
                {
                    if (SystemData == Collectors.Helpers.Enums.SystemData.Global)
                    {
                        PolicyID policy = CSS.Value.GetPolicyIdByPolicyNumber(payment.Policy_No);
                        var head = PS.Value.SetPaymentHead(policy, payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m);
                        var pmtHead = PS.Value.SetPayments(head);
                        PS.Value.SetPaymentDetail(head,
                                              pmtHead.FirstOrDefault().Payment_Id.ToString(),
                                              payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m,
                                              gpResult.PaymentNumber,
                                              gpResult.CustomerBalance,
                                              payment.Policy_No,
                                              UserId,
                                              policy
                                             );
                    }
                    result.result = true;
                    result.PaymentNumber = gpResult.PaymentNumber;
                    result.CustomerBalance = gpResult.CustomerBalance;

                    #region Call KwikTag Service
                    List<KwiktagProps.Tags> tagLst = new List<KwiktagProps.Tags>();
                    tagLst.Add(new KwiktagProps.Tags { Property = "Company ID", Value = (ConfigurationManager.AppSettings["ktCompanyID"] ?? "Atlantica Insurance S.A.").ToString() });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Receipt", Value = gpResult.PaymentNumber });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Credit Card ID", Value = string.Empty });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Customer ID", Value = payment.Policy_No });
                    tagLst.Add(new KwiktagProps.Tags { Property = "File Name", Value = "Scanned" });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Comments", Value = string.Empty });

                    svcKwikTag.EstructureTags[] tags = new svcKwikTag.EstructureTags[tagLst.Count];
                    svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters()
                    {
                        apiURL = null,
                        callingID = null,
                        companyID = null,
                        drawer = null,
                        password = null,
                        userName = ((string.IsNullOrEmpty(UserName) || UserName == "epimentel") ? null : UserName),
                        siteName = null,
                        barcode = (!string.IsNullOrEmpty(currentTag)) ? (int.Parse(currentTag) - 1).ToString() : null
                    };

                    for (int i = 0; i < tagLst.Count; i++)
                    {
                        tags[i] = new svcKwikTag.EstructureTags { Property = tagLst[i].Property, Value = tagLst[i].Value };
                    }
                    var ktBarcodeResponse = Kwiktag.KTSyncTag(tags, parameters);
                    XmlDocument xmlDoc = new XmlDocument();
                    XDocument xd = XDocument.Parse(ktBarcodeResponse);
                    //xmlDoc.LoadXml(ktBarcodeResponse);

                    XElement bc = (from xml in xd.Descendants("Barcode")
                                   select xml).FirstOrDefault();
                    string ktBarcode = (bc.Value ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(ktBarcode))
                        try
                        {
                            Utils.ErrorLogDB("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                            Utils.SendError("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, "EmptyTag()");
                        }
                        catch (Exception) { }
                    var resultKTonGP = US.Value.setKTagByPayment(gpResult.PaymentNumber, ktBarcode, JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = (payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m), @DueDate = payment.DueDate, @CurrencyID = (PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc), @Barcode = ktBarcode, @CustomerBalance = result.CustomerBalance, @Full_Name = Full_Name, @Payment_Form = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)3)), @Cashier = UserName }), batch);
                    result.KwikTag = ktBarcode;
                    #endregion
                }
                else
                {
                    try
                    {
                        Utils.ErrorLogDB("Error! pago retorno falso para la poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                    }
                    catch (Exception) { }
                    result.result = false;
                }

            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error procesando pagos en ACH para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error procesando pagos en ACH para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "PaymentACH(ACHPayments payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)");
                result.result = false;
            }
            return result;
        }

        public PaymentsResult PaymentCheck(CheckPayments payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)
        {
            PaymentsResult result = new PaymentsResult();
            try
            {
                var checkBookID = CheckBookID;
                if (this.ddlDepositAccount.SelectedValue != string.Empty)
                {
                    checkBookID = this.ddlDepositAccount.SelectedValue;
                }
                GPPaymentsvc.GPPaymentsClient gpPayment = new GPPaymentsvc.GPPaymentsClient();
                GPPaymentsvc.CheckPayment checkPayment = new GPPaymentsvc.CheckPayment();

                checkPayment.ReceivedBy = UserName;
                checkPayment.SourcePlatform = ProjectName;
                checkPayment.SourceTransactionID = OrderId;
                checkPayment.PaymentDate = DateTime.Now;
                checkPayment.PaymentAmount = payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m;
                checkPayment.PolicyNumber = payment.Policy_No;
                checkPayment.CurrencyID = PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc;
                checkPayment.CheckNumber = payment.CheckNumber;
                checkPayment.PaymentNotes = payment.Comments;
                checkPayment.CheckbookID = checkBookID;

                var gpResult = gpPayment.NewCheckPayment(checkPayment);
                
                try
                {
                    PTS.Value.SetProviderLog(new ProviderLogs()
                    {
                        Project_Id = (Int32)Collectors.Helpers.Enums.Project_Id.STGPaymentModuleCash,
                        Corp_Id = (Int32)Collectors.Helpers.Enums.Corp_Id.STG,
                        Log_Type_Id = (Int32)Collectors.Helpers.Enums.Log_Type_Id.Request,
                        Company_Id = (Int32)Collectors.Helpers.Enums.Company_Id.ATL,
                        Log_Desc = JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = payment.DueAmount, @DueDate = payment.DueDate, @CurrencyID = payment.Currency_Id }),
                        Order_Id = OrderId
                    });

                }
                catch (Exception ex)
                {
                }

                if (gpResult.Result)
                {
                    if (SystemData == Collectors.Helpers.Enums.SystemData.Global)
                    {
                        PolicyID policy = CSS.Value.GetPolicyIdByPolicyNumber(payment.Policy_No);
                        var head = PS.Value.SetPaymentHead(policy, payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m);
                        var pmtHead = PS.Value.SetPayments(head);
                        PS.Value.SetPaymentDetail(head,
                                              pmtHead.FirstOrDefault().Payment_Id.ToString(),
                                              payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m,
                                              gpResult.PaymentNumber,
                                              gpResult.CustomerBalance,
                                              payment.Policy_No,
                                              UserId,
                                              policy
                                             );
                    }
                    result.result = true;
                    result.PaymentNumber = gpResult.PaymentNumber;
                    result.CustomerBalance = gpResult.CustomerBalance;

                    #region Call KwikTag Service
                    List<KwiktagProps.Tags> tagLst = new List<KwiktagProps.Tags>();
                    tagLst.Add(new KwiktagProps.Tags { Property = "Company ID", Value = (ConfigurationManager.AppSettings["ktCompanyID"] ?? "Atlantica Insurance S.A.").ToString() });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Receipt", Value = gpResult.PaymentNumber });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Credit Card ID", Value = string.Empty });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Customer ID", Value = payment.Policy_No });
                    tagLst.Add(new KwiktagProps.Tags { Property = "File Name", Value = "Scanned" });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Comments", Value = string.Empty });

                    svcKwikTag.EstructureTags[] tags = new svcKwikTag.EstructureTags[tagLst.Count];
                    svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters()
                    {
                        apiURL = null,
                        callingID = null,
                        companyID = null,
                        drawer = null,
                        password = null,
                        userName = ((string.IsNullOrEmpty(KTUserName) || UserName == "epimentel") ? null : KTUserName),
                        siteName = null,
                        barcode = (!string.IsNullOrEmpty(currentTag)) ? (int.Parse(currentTag) - 1).ToString() : null
                    };

                    for (int i = 0; i < tagLst.Count; i++)
                    {
                        tags[i] = new svcKwikTag.EstructureTags { Property = tagLst[i].Property, Value = tagLst[i].Value };
                    }
                    var ktBarcodeResponse = Kwiktag.KTSyncTag(tags, parameters);
                    XmlDocument xmlDoc = new XmlDocument();
                    XDocument xd = XDocument.Parse(ktBarcodeResponse);
                    //xmlDoc.LoadXml(ktBarcodeResponse);

                    XElement bc = (from xml in xd.Descendants("Barcode")
                                   select xml).FirstOrDefault();
                    string ktBarcode = (bc.Value ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(ktBarcode))
                        try
                        {
                            Utils.ErrorLogDB("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                            Utils.SendError("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, "EmptyTag()");
                        }
                        catch (Exception) { }
                    var resultKTonGP = US.Value.setKTagByPayment(gpResult.PaymentNumber, ktBarcode, JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = (payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m), @DueDate = payment.DueDate, @CurrencyID = (PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc), @Barcode = ktBarcode, @CustomerBalance = result.CustomerBalance, @Full_Name = Full_Name, @Payment_Form = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)1)), @Cashier = UserName }), batch);
                    result.KwikTag = ktBarcode;
                    #endregion
                }
                else
                {
                    try
                    {
                        Utils.ErrorLogDB("Error! pago retorno falso para la poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                    }
                    catch (Exception) { }
                    result.result = false;
                }

            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error procesando pagos en Check para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error procesando pagos en Check para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "PaymentCheck(CheckPayments payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)");
                result.result = false;
            }
            return result;
        }

        public PaymentsResult PaymentDeposit(Payment payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)
        {
            PaymentsResult result = new PaymentsResult();
            try
            {
                GPPaymentsvc.GPPaymentsClient gpPayment = new GPPaymentsvc.GPPaymentsClient();
                GPPaymentsvc.CashPayment cashPayment = new GPPaymentsvc.CashPayment();

                cashPayment.ReceivedBy = UserName;
                cashPayment.SourcePlatform = ProjectName;
                cashPayment.SourceTransactionID = OrderId;
                cashPayment.PaymentDate = DateTime.Now;
                cashPayment.PaymentAmount = payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m;
                cashPayment.PolicyNumber = payment.Policy_No;
                cashPayment.CurrencyID = PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc;
                cashPayment.PaymentNotes = payment.Comments;
                cashPayment.CheckbookID = CheckBookID;

                var gpResult = gpPayment.NewCashPayment(cashPayment);


                try
                {
                    PTS.Value.SetProviderLog(new ProviderLogs()
                    {
                        Project_Id = (Int32)Collectors.Helpers.Enums.Project_Id.STGPaymentModuleCash,
                        Corp_Id = (Int32)Collectors.Helpers.Enums.Corp_Id.STG,
                        Log_Type_Id = (Int32)Collectors.Helpers.Enums.Log_Type_Id.Request,
                        Company_Id = (Int32)Collectors.Helpers.Enums.Company_Id.ATL,
                        Log_Desc = JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = payment.DueAmount, @DueDate = payment.DueDate, @CurrencyID = payment.Currency_Id }),
                        Order_Id = OrderId
                    });
                }
                catch (Exception ex)
                {
                }

                if (gpResult.Result)
                {
                    if (SystemData == Collectors.Helpers.Enums.SystemData.Global)
                    {
                        PolicyID policy = CSS.Value.GetPolicyIdByPolicyNumber(payment.Policy_No);
                        var head = PS.Value.SetPaymentHead(policy, payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m);
                        var pmtHead = PS.Value.SetPayments(head);
                        PS.Value.SetPaymentDetail(head,
                                              pmtHead.FirstOrDefault().Payment_Id.ToString(),
                                              payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m,
                                              gpResult.PaymentNumber,
                                              gpResult.CustomerBalance,
                                              payment.Policy_No,
                                              UserId,
                                              policy
                                             );
                    }
                    result.result = true;
                    result.PaymentNumber = gpResult.PaymentNumber;
                    result.CustomerBalance = gpResult.CustomerBalance;

                    #region Call KwikTag Service
                    List<KwiktagProps.Tags> tagLst = new List<KwiktagProps.Tags>();
                    tagLst.Add(new KwiktagProps.Tags { Property = "Company ID", Value = (ConfigurationManager.AppSettings["ktCompanyID"] ?? "Atlantica Insurance S.A.").ToString() });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Receipt", Value = gpResult.PaymentNumber });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Credit Card ID", Value = string.Empty });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Customer ID", Value = payment.Policy_No });
                    tagLst.Add(new KwiktagProps.Tags { Property = "File Name", Value = "Scanned" });
                    tagLst.Add(new KwiktagProps.Tags { Property = "Comments", Value = string.Empty });

                    svcKwikTag.EstructureTags[] tags = new svcKwikTag.EstructureTags[tagLst.Count];
                    svcKwikTag.EstructureParameters parameters = new svcKwikTag.EstructureParameters()
                    {
                        apiURL = null,
                        callingID = null,
                        companyID = null,
                        drawer = null,
                        password = null,
                        userName = ((string.IsNullOrEmpty(KTUserName) || UserName == "epimentel") ? null : KTUserName),
                        siteName = null,
                        barcode = (!string.IsNullOrEmpty(currentTag)) ? (int.Parse(currentTag) - 1).ToString() : null
                    };

                    for (int i = 0; i < tagLst.Count; i++)
                    {
                        tags[i] = new svcKwikTag.EstructureTags { Property = tagLst[i].Property, Value = tagLst[i].Value };
                    }
                    var ktBarcodeResponse = Kwiktag.KTSyncTag(tags, parameters);
                    XmlDocument xmlDoc = new XmlDocument();
                    XDocument xd = XDocument.Parse(ktBarcodeResponse);
                    //xmlDoc.LoadXml(ktBarcodeResponse);

                    XElement bc = (from xml in xd.Descendants("Barcode")
                                   select xml).FirstOrDefault();
                    string ktBarcode = (bc.Value ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(ktBarcode))
                        try
                        {
                            Utils.ErrorLogDB("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                            Utils.SendError("Error! kwiktag vacio para usuario: " + UserName + ", poliza: " + payment.Policy_No, "EmptyTag()");
                        }
                        catch (Exception) { }
                    var resultKTonGP = US.Value.setKTagByPayment(gpResult.PaymentNumber, ktBarcode, JsonConvert.SerializeObject(new { @Policy = payment.Policy_No, @Amount = (payment.DueAmount.HasValue ? payment.DueAmount.Value : 0.00m), @DueDate = payment.DueDate, @CurrencyID = (PS.Value.getCurrencyByCurrencyID(payment.Currency_Id.HasValue ? payment.Currency_Id.Value : 3).Currency_Desc), @Barcode = ktBarcode, @CustomerBalance = result.CustomerBalance, @Full_Name = Full_Name, @Payment_Form = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)0)), @Cashier = UserName }), batch);
                    result.KwikTag = ktBarcode;
                    #endregion
                }
                else
                {
                    try
                    {
                        Utils.ErrorLogDB("Error! pago retorno falso para la poliza: " + payment.Policy_No, string.Format("Message: {0} || StackTrace: {1}", string.Empty, string.Empty));
                    }
                    catch (Exception) { }
                    result.result = false;
                }

            }
            catch (Exception ex)
            {
                Utils.ErrorLogDB("Error procesando pagos en Cash para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag, string.Format("Message: {0} || StackTrace: {1}", ex.Message, ex.StackTrace));
                Utils.SendError("Error procesando pagos en Cash para usuario: " + UserName + ". Parametros: batch:" + batch + ", currentTag" + currentTag + " ||Exception: " + ex.Message + " || " + ex.StackTrace, "PaymentCash(Payment payment, String OrderId, String ProjectName, int UserId, string UserName, string Full_Name, string batch, string currentTag)");
                result.result = false;
            }
            return result;
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        /// <summary>
        /// No esta en uso, este metodo procesa transacciones en el provider (procesador de pagos de tarjetas).
        /// </summary>
        public void processPaymentOnProvider()
        {
            foreach (var pmt in (this.Page as Pages.ProcessPayments).paymentsList)
            {
                CollectorsModule.ell.ProviderSettings settings = PTS.Value.GetProviderParameters(1, 1, 1);
                Int32 Userid = 1;
                Decimal Tax = 0;
                Tax = (pmt.DueAmount.HasValue ? pmt.DueAmount.Value : default(decimal) * 16) / 100;

                ///Setting OrderID and TransactionID
                ProviderTransactionResult keyResult =
                PTS.Value.SetProviderTransactionInfoKey(new ProviderTransactionKey()
                {
                    Provider_Id = settings.ProviderId,
                    Provider_Transaction_Type_Id = settings.TransactionTypeId,
                    Transaction_Type_Catalog_Id = settings.TransactionTypeCatalogId
                },
                Userid);
                ///Setting provider transaction
                List<Provider_Parammeters_Results> lstResult =
                    PTS.Value.SetProviderTransaction(new ProviderTransaction()
                    {
                        Amount = pmt.DueAmount,
                        ProviderKey = new ProviderTransactionKey()
                        {
                            Provider_Id = keyResult.ProviderKey.Provider_Id,
                            Provider_Transaction_Type_Id = keyResult.ProviderKey.Provider_Transaction_Type_Id,
                            Transaction_Id = keyResult.ProviderKey.Transaction_Id,
                            Transaction_Key_Id = keyResult.ProviderKey.Transaction_Key_Id,
                            Transaction_Type_Catalog_Id = keyResult.ProviderKey.Transaction_Type_Catalog_Id,
                        },
                        Order_Id = keyResult.Order_Id,
                        Tax = Tax,
                        Transaction_Date = DateTime.Now,
                        UserId = Userid,
                        Transaction_Extra_Data = pmt.Policy_No
                    });

                ///Insert log for individual transaction
                PTS.Value.SetProviderLog(new ProviderLogs()
                {
                    Project_Id = (Int32)Collectors.Helpers.Enums.Project_Id.STGPaymentProcess,
                    Corp_Id = (Int32)Collectors.Helpers.Enums.Corp_Id.STG,
                    Log_Type_Id = (Int32)Collectors.Helpers.Enums.Log_Type_Id.Request,
                    Company_Id = (Int32)Collectors.Helpers.Enums.Company_Id.ATL,
                    Log_Desc = string.Join("|", pmt),
                    Order_Id = keyResult.Order_Id
                });

                ///Update transaction with payment information
                ///First need to get transaction information
                ProviderTransaction transaction = PTS.Value.GetProviderTransactionByOrderID(keyResult.Order_Id);
                ///Then update
                List<Provider_Parammeters_Results> ResultTrans = PTS.Value.SetProviderTransaction(new ProviderTransaction()
                {
                    Authorization_Code = pmt.AuthorizationCode,
                    Credit_Card_Number = pmt.CreditCardLast4,
                    Response_Code = pmt.ResponseCode,
                    Retrieval_Reference_Number = string.Empty,

                    ProviderKey = new ProviderTransactionKey()
                    {
                        Provider_Id = transaction.ProviderKey.Provider_Id,
                        Provider_Transaction_Type_Id = transaction.ProviderKey.Provider_Transaction_Type_Id,
                        Transaction_Id = transaction.ProviderKey.Transaction_Id,
                        Transaction_Key_Id = transaction.ProviderKey.Transaction_Key_Id,
                        Transaction_Type_Catalog_Id = transaction.ProviderKey.Transaction_Type_Catalog_Id,
                    },

                    Order_Id = transaction.Order_Id,
                    Transaction_Date = DateTime.Now,
                    UserId = Userid//UserInformation.GetInfo().CodUsuario,
                });

            }
        }

        protected void ddlBanksInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlBanksInformation.SelectedValue != string.Empty)
            {
                var bnkInfo = CSS.Value.getListBankCheckbookType().Where(b => b.Bank_Name_Desc == this.ddlBanksInformation.SelectedValue).ToArray();
                if (OnlyDOP)
                    bnkInfo = bnkInfo.Where(c => c.Currency_ISO == "DOP").ToArray();
                this.ddlDepositAccount.DataSource = bnkInfo;
                this.ddlDepositAccount.DataTextField = "CHECKBOOK_INFO";
                this.ddlDepositAccount.DataValueField = "Checkbook_Name";
                this.ddlDepositAccount.DataBind();
                ddlDepositAccount.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                this.ddlDepositAccount.SelectedIndex = -1;
            }
        }

        protected void ddlDepositAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepositAccount.SelectedValue != string.Empty)
            {
                var account = CSS.Value.getListBankCheckbookType().Where(b => b.Checkbook_Name == this.ddlDepositAccount.SelectedItem.Value).ToArray();
                if (account != null && account.Any())
                {
                    this.txtAccountNumberDepTransf.Text = account.FirstOrDefault().Bank_Account;
                }
            }
        }
    }
}