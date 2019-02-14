using Collectors.Helpers;
using CollectorsModule.bll;
using CollectorsModule.bll.Services;
using CollectorsModule.Commons;
using CollectorsModule.ell;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using Statetrust.Framework.Web.WebParts.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectorsModule.Pages
{
    public partial class PaymentHistory : STFMainPage
    {
        public Collectors.Helpers.Enums.SystemData SystemData
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["SystemData"]) ? Collectors.Helpers.Enums.SystemData.GP : (Collectors.Helpers.Enums.SystemData)Enum.Parse(typeof(Collectors.Helpers.Enums.SystemData), ConfigurationManager.AppSettings["SystemData"].ToString().ToUpper());
            }
        }
        public String UserName
        {
            get
            {
                Statetrust.Framework.Security.Bll.Usuarios User = (Statetrust.Framework.Security.Bll.Usuarios)Session["userData"];
                return User.UserLogin;
            }
        }
        public int UserID
        {
            get
            {
                Statetrust.Framework.Security.Bll.Usuarios User = (Statetrust.Framework.Security.Bll.Usuarios)Session["userData"];
                return User.UserID;
            }
        }
        private bool NeedBind { get { return (Session["need_bind"] == null) ? false : Convert.ToBoolean(Session["need_bind"]); } set { Session["need_bind"] = value; } }
        Lazy<PaymentsService> PS = new Lazy<PaymentsService>();
        Lazy<UtilitiesServices> US = new Lazy<UtilitiesServices>();
        Lazy<ClientSearchService> CSS = new Lazy<ClientSearchService>();
        public int AmountToPaidColumnIndex
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return 8;
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return 8;
                }
            }
        }
        public string PendingAmountField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "PendingAmount";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "CUSTOMER_BALANCE";
                }
            }
        }
        public string PolicyNumberField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Policy_No";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "POLICY_NUMBER";
                }
            }
        }
        public string ProductDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Product_Desc";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "PLAN_TYPE";
                }
            }
        }
        public string BusinessLineIdField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Bussiness_Line_Id";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "LINE_OF_BUSINESS";
                }
            }
        }
        public string CurrencyIdField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Currency_Id";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "CURRENCY_ID";
                }
            }
        }
        public string DueDateField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "DueDate";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "EXPIRATION_DATE";
                }
            }
        }
        public string FullNameField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Full_Name";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "CUSTNAME";
                }
            }
        }
        public string AnnualPremiumField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Annual_Premium";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "";
                }
            }
        }
        public string TotalDueAmountField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "TotalDueAmount";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "CUSTOMER_BALANCE";
                }
            }
        }
        public string PolicyStatusDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Policy_Status_Desc";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "POLICY_STATUS";
                }
            }
        }
        public string BusinessLineDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Bl_Desc";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "LINE_OF_BUSINESS";
                }
            }
        }
        public string OfficeDescriptionField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "Office_Id";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "OFFICE_NUMBER";
                }
            }
        }
        public string PaymentTypeField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "PAYMENT_TYPE";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "PAYMENT_TYPE";
                }
            }
        }
        public string PaymentAmountField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "PAYMENT_AMOUNT";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "PAYMENT_AMOUNT";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsCallback && !IsPostBack)
            {
                if (Request.QueryString["Policy_No"] != null)
                    this.txtPolicyNo.Text = Request.QueryString["Policy_No"].ToString().Trim();
                bindControls();
                if (!US.Value.isAdminUser(UserName))
                {
                    this.ddlUsersSecurity.SelectedItem.Value = UserID.ToString();
                    this.ddlUsersSecurity.SelectedItem.Text = UserName.ToUpper();
                    this.ddlUsersSecurity.Enabled = false;
                    this.gvPaymentHistory.FilterExpression = filterUserAdmin();
                }
                NeedBind = true;
                clearGridHistory();
            }
            if (this.Page.IsCallback)
            {
                NeedBind = true;
                this.gvPaymentHistory.DataBind();
                //gvPaymentHistory.FilterExpression = GetFilterExpression(); ;
            }
        }

        private void bindControls()
        {
            this.ddlOfficeFilters.DataSource = US.Value.getAllOfficesGP();
            this.ddlOfficeFilters.DataTextField = "Office_NameKey";
            this.ddlOfficeFilters.DataValueField = "Office_Code";
            this.ddlOfficeFilters.DataBind();
            ddlOfficeFilters.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlOfficeFilters.SelectedIndex = -1;

            this.ddlUsersSecurity.DataSource = US.Value.getSecurityUsersForPaymentsFilter(0);
            this.ddlUsersSecurity.DataTextField = "UserLogin";
            this.ddlUsersSecurity.DataValueField = "UserID";
            this.ddlUsersSecurity.DataBind();
            ddlUsersSecurity.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlUsersSecurity.SelectedIndex = -1;

            this.ddlModuleProcessor.DataSource = US.Value.getModulesForPaymentsFilter();
            this.ddlModuleProcessor.DataTextField = "Module_Description";
            this.ddlModuleProcessor.DataValueField = "Module_Description";
            this.ddlModuleProcessor.DataBind();
            ddlModuleProcessor.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlModuleProcessor.SelectedIndex = -1;

            this.ddlBusinessLine.DataSource = US.Value.getBusinessLinesForPaymentsFilter();
            this.ddlBusinessLine.DataTextField = "Bl_Desc";
            this.ddlBusinessLine.DataValueField = "Bl_Code";
            this.ddlBusinessLine.DataBind();
            ddlBusinessLine.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlBusinessLine.SelectedIndex = -1;

            //this.ddlCurrency.DataSource = US.Value.getCurrencyForPaymentsFilter();
            //this.ddlCurrency.DataTextField = "Module_Description";
            //this.ddlCurrency.DataValueField = "Module_Description";
            //this.ddlCurrency.DataBind();
            this.ddlCurrency.SelectedIndex = -1;
        }

        private void clearGridHistory()
        {
            //this.txtDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            //this.txtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.gvPaymentHistory.Selection.UnselectAll();
            this.gvPaymentHistory.FilterExpression = string.Empty;
            if (!US.Value.isAdminUser(UserName))
            {
                this.gvPaymentHistory.FilterExpression = filterUserAdmin();
            }
            this.gvPaymentHistory.DataBind();
            NeedBind = true;
        }

        private string filterUserAdmin() 
        {
            string res_str = string.Empty;
            List<CriteriaOperator> lst_operator = new List<CriteriaOperator>();

            if (this.ddlUsersSecurity.Items.Count > 0 && this.ddlUsersSecurity.SelectedItem.Text != string.Empty)
            {
                if (!string.IsNullOrEmpty(this.ddlUsersSecurity.SelectedItem.Text))
                    lst_operator.Add(new BinaryOperator("RECEIVED_BY", string.Format("%{0}%", this.ddlUsersSecurity.SelectedItem.Text), BinaryOperatorType.Like));
            }
            if (lst_operator.Count > 0)
            {
                CriteriaOperator[] op = new CriteriaOperator[lst_operator.Count];
                for (int i = 0; i < lst_operator.Count; i++)
                    op[i] = lst_operator[i];
                CriteriaOperator res_operator = new GroupOperator(GroupOperatorType.And, op);
                res_str = string.Empty;
            }

            return res_str;
        }

        private void clearInputs()
        {
            this.txtPolicyNo.Text = string.Empty;
            this.txtACHCount.Text =
            this.txtCashCount.Text =
            this.txtCheckCount.Text =
            this.txtCreditCardCount.Text =
            this.txtTotalCount.Text = "$0.00";
            this.txtDateFrom.Text =
            this.txtDateTo.Text = string.Empty;
        }

        protected void gvPaymentHistory_DataBinding(object sender, EventArgs e)
        {
            if (!NeedBind) return;
            (sender as ASPxGridView).DataSource = GetEntityServerModeSource();
           
        }

        protected void gvPaymentHistory_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            gvPaymentHistory.DataBind();
        }

        private string GetFilterExpression()
        {
            string res_str = string.Empty;
            List<CriteriaOperator> lst_operator = new List<CriteriaOperator>();

            if (!string.IsNullOrEmpty(this.txtDateFrom.Text))
                lst_operator.Add(new BinaryOperator("PAYMENT_DATE", string.IsNullOrEmpty(this.txtDateFrom.Text) ? new DateTime() : DateTime.Parse(this.txtDateFrom.Text).Date, BinaryOperatorType.GreaterOrEqual));

            if (!string.IsNullOrEmpty(this.txtDateTo.Text))
                lst_operator.Add(new BinaryOperator("PAYMENT_DATE", string.IsNullOrEmpty(this.txtDateTo.Text) ? new DateTime() : DateTime.Parse(this.txtDateTo.Text).Date, BinaryOperatorType.LessOrEqual));

            if (!string.IsNullOrEmpty(this.txtPolicyNo.Text))
                lst_operator.Add(new BinaryOperator("POLICY_NUMBER", string.Format("%{0}%", this.txtPolicyNo.Text), BinaryOperatorType.Like));

            if (this.ddlUsersSecurity.Items.Count > 0 && this.ddlUsersSecurity.SelectedItem.Value != string.Empty)
            {
                if (!string.IsNullOrEmpty(this.ddlUsersSecurity.SelectedItem.Value))
                    lst_operator.Add(new BinaryOperator("RECEIVED_BY", string.Format("%{0}%", this.ddlUsersSecurity.SelectedItem.Text), BinaryOperatorType.Like));
            }

            if (this.ddlOfficeFilters.Items.Count > 0 && this.ddlOfficeFilters.SelectedItem.Value != string.Empty)
            {
                if (!string.IsNullOrEmpty(this.ddlOfficeFilters.SelectedItem.Value))
                    lst_operator.Add(new BinaryOperator("OFFICE_NUMBER", string.Format("%{0}%", this.ddlOfficeFilters.SelectedItem.Value), BinaryOperatorType.Like));
            }

            if (this.ddlModuleProcessor.Items.Count > 0 && this.ddlModuleProcessor.SelectedItem.Value != string.Empty)
            {
                if (!string.IsNullOrEmpty(this.ddlModuleProcessor.SelectedItem.Value))
                    lst_operator.Add(new BinaryOperator("SOURCE_SYSTEM", string.Format("%{0}%", this.ddlModuleProcessor.SelectedItem.Value), BinaryOperatorType.Like));
            }

            if (this.ddlBusinessLine.Items.Count > 0 && this.ddlBusinessLine.SelectedItem.Value != string.Empty)
            {
                if (!string.IsNullOrEmpty(this.ddlBusinessLine.SelectedItem.Value))
                    lst_operator.Add(new BinaryOperator("LINE_OF_BUSINESS", string.Format("%{0}%", this.ddlBusinessLine.SelectedItem.Value), BinaryOperatorType.Like));
            }

            if (this.ddlCurrency.Items.Count > 0 && this.ddlCurrency.SelectedItem.Value != string.Empty && this.ddlCurrency.SelectedItem.Value != "0")
            {
                if (!string.IsNullOrEmpty(this.ddlCurrency.SelectedItem.Value))
                    lst_operator.Add(new BinaryOperator("CURRENCY_ID", string.Format("%{0}%", this.ddlCurrency.SelectedItem.Value), BinaryOperatorType.Like));
            }

            if (lst_operator.Count > 0)
            {
                CriteriaOperator[] op = new CriteriaOperator[lst_operator.Count];
                for (int i = 0; i < lst_operator.Count; i++)
                    op[i] = lst_operator[i];
                CriteriaOperator res_operator = new GroupOperator(GroupOperatorType.And, op);
                res_str = string.Empty;
            }

            return res_str;
        }

        private EntityServerModeSource GetEntityServerModeSource()
        {
            try
            {
                EntityServerModeSource esms = new EntityServerModeSource();
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        esms.KeyExpression = "Policy_No";
                        esms.QueryableSource = (validateFilter()) ? PS.Value.getAllPaymentsHistory() : PS.Value.getPaymentsByFilter(new ell.PaymentHistory()
                        {
                            FromDate = DateTime.Parse(this.txtDateFrom.Text),
                            ToDate = DateTime.Parse(this.txtDateTo.Text)
                        }).AsQueryable();
                        break;
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        var result = PS.Value.getAllPaymentHistoryGP(new ell.PaymentHistory()
                        {
                            FromDate = string.IsNullOrEmpty(this.txtDateFrom.Text) ? new DateTime() : DateTime.Parse(this.txtDateFrom.Text).Date,
                            ToDate = string.IsNullOrEmpty(this.txtDateTo.Text) ? new DateTime() : DateTime.Parse(this.txtDateTo.Text).AddDays(1).AddTicks(-1),
                            UserId = (this.ddlUsersSecurity.Items.Count > 0 && this.ddlUsersSecurity.SelectedItem.Value != string.Empty) ? int.Parse(this.ddlUsersSecurity.SelectedItem.Value) : 0,
                            UserName = (this.ddlUsersSecurity.Items.Count > 0 && this.ddlUsersSecurity.SelectedItem.Text != string.Empty) ? this.ddlUsersSecurity.SelectedItem.Text : string.Empty,
                            Office_Code = (this.ddlOfficeFilters.Items.Count > 0 && this.ddlOfficeFilters.SelectedItem.Value != string.Empty) ? this.ddlOfficeFilters.SelectedItem.Value : string.Empty,
                            Module = (this.ddlModuleProcessor.Items.Count > 0 && this.ddlModuleProcessor.SelectedItem.Text != string.Empty) ? this.ddlModuleProcessor.SelectedItem.Text : string.Empty,
                            Bl_Id = (this.ddlBusinessLine.Items.Count > 0 && this.ddlBusinessLine.SelectedItem.Value != string.Empty) ? int.Parse(this.ddlBusinessLine.SelectedItem.Value) : 0,
                            Policy_No = this.txtPolicyNo.Text,
                            Currency_Desc = (this.ddlCurrency.Items.Count > 0 && this.ddlCurrency.SelectedItem.Text != string.Empty) ? this.ddlCurrency.SelectedItem.Text : string.Empty

                        });
                        var summaryCount = result.ToList();

                        this.txtCashCount.Text = (summaryCount.Where(c => c.PAYMENT_TYPE == 0).Sum(t => t.PAYMENT_AMOUNT).Value).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
                        this.txtCheckCount.Text = (summaryCount.Where(c => c.PAYMENT_TYPE == 1).Sum(t => t.PAYMENT_AMOUNT).Value).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
                        this.txtCreditCardCount.Text = (summaryCount.Where(c => c.PAYMENT_TYPE == 2).Sum(t => t.PAYMENT_AMOUNT).Value).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
                        this.txtACHCount.Text = (summaryCount.Where(c => c.PAYMENT_TYPE == 3).Sum(t => t.PAYMENT_AMOUNT).Value).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
                        this.txtTotalCount.Text = (summaryCount.Where(t => t.PAYMENT_TYPE != 4).Sum(t => t.PAYMENT_AMOUNT).Value).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));//!=4 para evitar STB Account

                        esms.KeyExpression = "GP_PAYMENT_NUMBER";
                        esms.QueryableSource = result.AsQueryable().OrderBy(d => d.PAYMENT_DATE).ThenBy(k => k.KT_BARCODE);
                        break;
                }
                return esms;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private bool validateFilter()
        {
            return true;
        }

        protected void gvPaymentHistory_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                int LangID = int.Parse(ConfigurationManager.AppSettings["Language"].ToString());
                LangID = (LangID == 0) ? 1 : LangID;
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        if (e.Column.FieldName == BusinessLineDescriptionField || e.Column.FieldName == ProductDescriptionField || e.Column.FieldName == PolicyStatusDescriptionField)
                            e.DisplayText = US.Value.getTranslatedTextByLiteralDesc((e.Value ?? string.Empty).ToString(), LangID);
                        break;
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        if (e.Column.FieldName == BusinessLineDescriptionField)
                            e.DisplayText = PS.Value.getBusinessLineByLineCodeGP(int.Parse((e.Value ?? "0").ToString())).Bl_Desc;
                        if (e.Column.FieldName == ProductDescriptionField)
                            e.DisplayText = PS.Value.getProductDescriptionByPlanTypeCodeGP((e.Value ?? "0").ToString());
                        if (e.Column.FieldName == OfficeDescriptionField)
                            e.DisplayText = PS.Value.getOfficeDescriptionByOfficeNumberCodeGP(int.Parse((e.Value ?? "0").ToString()));
                        if (e.Column.FieldName == PaymentTypeField)
                            e.DisplayText = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)int.Parse((e.Value ?? "0").ToString())));
                        if (e.Column.FieldName == PaymentAmountField)
                            e.DisplayText = Decimal.Parse((e.Value ?? "0").ToString()).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));

                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }
        
        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDateFrom.Text))
            {
                DateTime dt = DateTime.ParseExact(this.txtDateFrom.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                this.txtDateFrom.Text = dt.ToShortDateString();
            }
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDateTo.Text))
            {
                DateTime dt = DateTime.ParseExact(this.txtDateTo.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                this.txtDateTo.Text = dt.ToShortDateString();
            }
        }

        protected void btnClean_Click(object sender, EventArgs e)
        {
            NeedBind = true;
            clearInputs();
            bindControls();
            if (!US.Value.isAdminUser(UserName))
            {
                this.ddlUsersSecurity.SelectedItem.Value = UserID.ToString();
                this.ddlUsersSecurity.SelectedItem.Text = UserName.ToUpper();
                this.ddlUsersSecurity.Enabled = false;
                this.gvPaymentHistory.FilterExpression = filterUserAdmin();
            }
            clearGridHistory();
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            NeedBind = true;
            this.gvPaymentHistory.DataBind();
        }

        protected void lnkExportExcel_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.XlsExportOptions exportOptions = new DevExpress.XtraPrinting.XlsExportOptions();
            exportOptions.ExportHyperlinks = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.AppendHeader("cache-control", "no-transform");
            gvExporter.WriteXlsToResponse("Historico_Pagos", true, new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG, TextExportMode = TextExportMode.Text });
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.End();
        }

        protected void lnkExportPDF_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.PdfExportOptions exportOptions = new DevExpress.XtraPrinting.PdfExportOptions();
            gvExporter.Landscape = true;

            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.AppendHeader("cache-control", "no-transform");
            gvExporter.WritePdfToResponse("Historico_Pagos", true, exportOptions);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            Response.End();
        }

        protected void gvExporter_RenderBrick(object sender, ASPxGridViewExportRenderingEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data)
                return;
            int LangID = int.Parse(ConfigurationManager.AppSettings["Language"].ToString());
            LangID = (LangID == 0) ? 1 : LangID;
            switch (this.SystemData)
            {
                case Collectors.Helpers.Enums.SystemData.Global:
                    if (e.Column.Name == BusinessLineDescriptionField || e.Column.Name == ProductDescriptionField || e.Column.Name == PolicyStatusDescriptionField)
                        e.Text = US.Value.getTranslatedTextByLiteralDesc((e.Value ?? string.Empty).ToString(), LangID);
                    break;
                case Collectors.Helpers.Enums.SystemData.GP:
                default:
                    if (e.Column.Index == 1)
                    {
                        var resultBL = PS.Value.getBusinessLineByLineCodeGP(int.Parse((e.Value ?? "0").ToString()));
                        e.Text = (resultBL != null ? resultBL.Bl_Desc : e.Value).ToString();
                    }
                    if (e.Column.Index == 11)
                    {
                        string office = PS.Value.getOfficeDescriptionByOfficeNumberCodeGP(int.Parse((e.Value ?? "0").ToString()));
                        e.Text = (string.IsNullOrEmpty(office)) ? e.Value.ToString() : office;
                    }
                    if (e.Column.Index == 7)
                        e.Text = EnumHelper.GetDescription(((Collectors.Helpers.Enums.PaymentForm)int.Parse((e.Value ?? "0").ToString())));
                    if (e.Column.Index == 4)
                        e.Text = Decimal.Parse((e.Value ?? "0").ToString()).ToString("c", CultureInfo.CreateSpecificCulture("en-US"));

                    break;
            }
        }

        protected void txtDateTo_Init(object sender, EventArgs e)
        {
            ASPxDateEdit to = sender as ASPxDateEdit;
            to.MaxDate = DateTime.Now.Date;
        }

        protected void txtDateFrom_Init(object sender, EventArgs e)
        {
            ASPxDateEdit from = sender as ASPxDateEdit;
            from.MaxDate = DateTime.Now.Date;
        }

        protected void txtDate_DateChanged(object sender, EventArgs e)
        {
            var from = txtDateFrom.Text;
            var to = txtDateTo.Text;
        }

        protected void gvPaymentHistory_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "KT_BARCODE" && e.DataColumn.Caption == "KwkikTag") 
            { 
                if(e.CellValue == null) 
                {  
                    e.Cell.Controls.Clear(); 
                }
            }
        }

        protected void lnkInvoiceDocument_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string barcode = btn.CommandArgument;
            if (!string.IsNullOrEmpty(barcode))
            {
                string batch = PS.Value.getPaymentBatchByBarcode(barcode);
                var paymentsList = PS.Value.getPaymentsByBatch(batch);
                var paymentsListFst = paymentsList.FirstOrDefault();
                var lstInvoice = PS.Value.generateInvoiceList(paymentsList, new Invoice
                {
                    Company = ConfigurationManager.AppSettings["CompanyName"].ToString(),
                    Rnc = ConfigurationManager.AppSettings["RNC"].ToString(),
                    Address = ConfigurationManager.AppSettings["MainAddress"].ToString(),
                    Fax = ConfigurationManager.AppSettings["Fax"].ToString(),
                    Telephone = ConfigurationManager.AppSettings["Tel"].ToString(),
                }, paymentsListFst.Cashier, paymentsListFst.Payment_Form);

                HttpContext.Current.Session.Add("lstInvoice", null);
                HttpContext.Current.Session["lstInvoice"] = lstInvoice;
                CollectorsModule.Commons.ResponseHelper.Redirect(Response, ResolveUrl("~/Controls/oInvoice.ashx"), "_blank", "menubar=0,titlebar=0, toolbar=0, scrollbars=1,width=1200,height=800,top=10");
            }
            else
                Utils.JSExec(this, "SendAlert('La lista de pagos esta vacía, la factura no puede ser generada, deberá generarla a través del reporte dedicado para tales fines, acceder a: " + ConfigurationManager.AppSettings["URLInvoiceGenerator"].ToString() + "');");
        }

    }
}