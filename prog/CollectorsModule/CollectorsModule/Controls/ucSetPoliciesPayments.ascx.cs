using Collectors.Helpers;
using CollectorsModule.bll;
using CollectorsModule.bll.Services;
using CollectorsModule.Commons;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.ell;
using DevExpress.Data.Linq;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectorsModule.Controls
{
    public partial class ucSetPoliciesPayments : System.Web.UI.UserControl
    {
        private string ContactId
        {
            get
            {
                return (string)Session["Contact_Id"];
            }

            set
            {
                Session["Contact_Id"] = value;
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
        private Collectors.Helpers.Enums.SystemData SystemData
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["SystemData"]) ? Collectors.Helpers.Enums.SystemData.GP : (Collectors.Helpers.Enums.SystemData)Enum.Parse(typeof(Collectors.Helpers.Enums.SystemData), ConfigurationManager.AppSettings["SystemData"].ToString().ToUpper());
            }
        }
        public bool backStep
        {
            get
            {
                this.btnBack_Click(null, EventArgs.Empty);
                return true;
            }
        }
        public bool forwardStep
        {
            get
            {
                btnContinue_Click(null, EventArgs.Empty);
                return true;
            }
        }
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

        Lazy<ClientSearchService> CSS = new Lazy<ClientSearchService>();
        Lazy<PaymentsService> PS = new Lazy<PaymentsService>();
        Lazy<UtilitiesServices> UTS = new Lazy<UtilitiesServices>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Page as Pages.ProcessPayments).ActiveView == "2" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwPoliciesPayments")
            {
                (this.Page as Pages.ProcessPayments).setStep2 = true;
                (this.Page as Pages.ProcessPayments).setStep3 = false;
            }
            if ((this.Page as Pages.ProcessPayments).ActiveView == "2" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwSearchClient")
            {
                ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = "1";
                ContactId = string.Empty;
            }
        }

        public void getPolicies()
        {
            try
            {
                ActiveView = (this.Page as Pages.ProcessPayments).ActiveView;
                if (ActiveView != null && ActiveView == "2")
                {
                    ContactId = (this.Page as Pages.ProcessPayments).ContactId;
                    if (ContactId != null)
                    {
                        string contactid;
                        string policy_number = contactid = ContactId ?? string.Empty;
                        if (!string.IsNullOrEmpty(contactid))
                        {
                            int dop, usd = 0;
                            switch (this.SystemData)
                            {
                                case Collectors.Helpers.Enums.SystemData.Global:
                                    var policies = CSS.Value.getPoliciesByContactID(int.Parse(contactid));
                                    dop = policies.Where(c => c.Currency_Id == 3).Count(); //Currency_Id = 3 => Pesos (DOP).
                                    usd = policies.Where(c => c.Currency_Id.Value == 1).Count(); //Currency_Id = 1 => Dolares (USD).
                                    break;
                                case Collectors.Helpers.Enums.SystemData.GP:
                                default:
                                    string client_id = CSS.Value.getClientIdByPolicyNumber(policy_number.ToString());
                                    var policiesGP = CSS.Value.getPoliciesByClientIDGP(client_id, policy_number).ToList();
                                    dop = policiesGP.Where(c => c.CURRENCY_ID == Collectors.Helpers.Enums.Currency.DOP.ToString()).Count(); //Currency_Id = 3 => Pesos (DOP).
                                    usd = policiesGP.Where(c => c.CURRENCY_ID == Collectors.Helpers.Enums.Currency.USD.ToString()).Count(); //Currency_Id = 1 => Dolares (USD).
                                    break;
                            }

                            if (dop == 0 && usd == 0)
                            {
                                ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = "1";
                                (this.Page as Pages.ProcessPayments).setActiveView(1);
                                Utils.JSExec(this, "SendAlert('No existen polizas para este contacto.');");
                                return;
                            }
                            if (dop > 0)
                            {
                                this.DOPPolicies.Visible = true;
                                this.gvDOPPolicies.DataBind();
                                this.gvDOPPolicies.Selection.UnselectAll();
                                this.gvDOPPolicies.FilterExpression = string.Empty;
                            }
                            else
                            {
                                this.DOPPolicies.Visible = false;
                            }
                            if (usd > 0)
                            {
                                this.gvUSDPolicies.Visible = true;
                                this.gvUSDPolicies.DataBind();
                                this.gvUSDPolicies.Selection.UnselectAll();
                                this.gvUSDPolicies.FilterExpression = string.Empty;
                            }
                            else
                            {
                                this.USDPolicies.Visible = false;
                            }
                            (this.Page as Pages.ProcessPayments).setStep2 = true;
                            (this.Page as Pages.ProcessPayments).setStep3 = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvDOPPolicies_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = GetEntityServerModeSourceDOP();
        }

        private EntityServerModeSource GetEntityServerModeSourceDOP()
        {
            EntityServerModeSource esms = new EntityServerModeSource();
            switch (this.SystemData)
            {
                case Collectors.Helpers.Enums.SystemData.Global:
                    int contactid;
                    int.TryParse((ContactId ?? string.Empty).ToString(), out contactid);
                    esms.KeyExpression = "Policy_No";
                    esms.QueryableSource = CSS.Value.getPoliciesByContactID(contactid).Where(c => c.Currency_Id == 3).AsQueryable();
                    break;
                case Collectors.Helpers.Enums.SystemData.GP:
                default:
                    string policy_number = (ContactId ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(policy_number)) return null;
                    string client_id = CSS.Value.getClientIdByPolicyNumber(policy_number);
                    var policiesGP = CSS.Value.getPoliciesByClientIDGP(client_id, policy_number);
                    esms.KeyExpression = "POLICY_NUMBER";
                    esms.QueryableSource = policiesGP.Where(d => d.CURRENCY_ID == Collectors.Helpers.Enums.Currency.DOP.ToString()).AsQueryable();
                    break;
            }
            return esms;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            (this.Page as Pages.ProcessPayments).Use(p =>
                {
                    p.ContactId = string.Empty;
                    p.setActiveView(1);
                    p.ActiveView = "1";
                    p.setStep2 = false;
                    p.setStep1 = true;
                    p.clearUCClients();
                });
            ContactId = string.Empty;

        }

        protected void gvUSDPolicies_SelectionChanged(object sender, EventArgs e)
        {
            if (ContactId != null)
            {
                var grid = (ASPxGridView)this.gvUSDPolicies;
                var rowIndexOverloadUsd = 0;
                var counterusd = Utils.GetRowVisibleCount(grid, PolicyNumberField, out rowIndexOverloadUsd);
                List<CheckBox> selectedCheckBoxes = new List<CheckBox>();
                GridViewDataColumn columnck = null, columntxt = null;
                CheckBox cb = null;
                TextBox txt = null;
                bool showCancelledMessage = false;

                ///DOP Policies selected
                var griddop = (ASPxGridView)this.gvDOPPolicies;
                var rowIndexOverloadDop = 0;
                var counter = Utils.GetRowVisibleCount(griddop, PolicyNumberField, out rowIndexOverloadDop);
                for (int rowIndex = 0; rowIndex < counter; rowIndex++)
                {
                    GridViewDataColumn columnckusd = (GridViewDataColumn)griddop.Columns[0];
                    CheckBox cbusd = (CheckBox)griddop.FindRowCellTemplateControl(rowIndex, columnckusd, "ckbSelectPolicies");
                    if (cbusd != null && cbusd.Checked == true)
                    {
                        for (int Index = 0; Index < counterusd; Index++)
                        {
                            CheckBox cbusdr = (CheckBox)grid.FindRowCellTemplateControl(Index, (GridViewDataColumn)grid.Columns[0], "ckbSelectPoliciesUSD");
                            cbusdr.Checked = false;
                        }
                        Utils.JSExec(this, "SendAlert('No es posible procesar varias monedas en una misma transacción. Usted ya tiene seleccionada una póliza en Pesos (RD$).');");
                        return;
                    }
                }
                ///------------------------------------------------
                for (int rowIndex = 0; rowIndex < counterusd; rowIndex++)
                {
                    var idx = rowIndexOverloadDop + rowIndex;
                    columntxt = (GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex];
                    columnck = (GridViewDataColumn)grid.Columns[0];
                    var status = grid.GetRowValues(idx, ((GridViewDataColumn)grid.Columns[4]).FieldName);

                    txt = (TextBox)grid.FindRowCellTemplateControl(idx, columntxt, "txtAmountDueUSD");
                    cb = (CheckBox)grid.FindRowCellTemplateControl(idx, columnck, "ckbSelectPoliciesUSD");

                    if (cb != null && cb.Checked == true)
                    {
                        txt.Enabled = true;
                        selectedCheckBoxes.Add(cb);
                        if (status.ToString().Contains("CA"))
                        {
                            showCancelledMessage = true;
                            cb.Enabled = false;
                            cb.Checked = false;
                            txt.Enabled = false;
                        }
                    }
                    else
                    {
                        decimal amount = 0;
                        amount = decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency);
                        txt.Enabled = false;
                        ASPxLabel lbl = (ASPxLabel)grid.FindFooterCellTemplateControl((GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex], "txtTotalPendingAmountUSD");
                        decimal total = decimal.Parse((string.IsNullOrEmpty(lbl.Text) ? "0.00" : lbl.Text).ToString(), NumberStyles.Currency);
                        total -= amount;
                        lbl.Text = (total).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txt.Text = string.Empty;
                    }
                }
            }
        }

        protected void gvDOPPolicies_SelectionChanged(object sender, EventArgs e)
        {
            var clicked = (CheckBox)sender;
            if (ContactId != null)
            {
                var grid = (ASPxGridView)this.gvDOPPolicies;
                List<CheckBox> selectedCheckBoxes = new List<CheckBox>();
                GridViewDataColumn columnck = null, columntxt = null;
                CheckBox cb = null;
                TextBox txt = null;
                bool showCancelledMessage = false;

                ///USD Policies selected
                var gridusd = (ASPxGridView)this.gvUSDPolicies;
                var rowIndexOverloadUsd = 0;
                var counterusd = Utils.GetRowVisibleCount(gridusd, PolicyNumberField, out rowIndexOverloadUsd);
                for (int rowIndex = 0; rowIndex < counterusd; rowIndex++)
                {
                    var idx = rowIndexOverloadUsd + rowIndex;
                    GridViewDataColumn columnckusd = (GridViewDataColumn)gridusd.Columns[0];
                    CheckBox cbusd = (CheckBox)gridusd.FindRowCellTemplateControl(idx, columnckusd, "ckbSelectPoliciesUSD");

                    if (cbusd != null && cbusd.Checked == true)
                    {
                        var griddop = (ASPxGridView)this.gvDOPPolicies;
                        for (int Index = 0; Index < griddop.VisibleRowCount; Index++)
                        {
                            CheckBox cbdop = (CheckBox)griddop.FindRowCellTemplateControl(Index, (GridViewDataColumn)griddop.Columns[0], "ckbSelectPolicies");
                            cbdop.Checked = false;
                        }
                        Utils.JSExec(this, "SendAlert('No es posible procesar varias monedas en una misma transacción. Usted ya tiene seleccionada una póliza en Dólares (US$).');");
                        return;
                    }
                }
                ///------------------------------------------------
                int rowIndexOverloadDop = 0;
                var counter = Utils.GetRowVisibleCount(grid, PolicyNumberField, out rowIndexOverloadDop);

                for (int rowIndex = 0; rowIndex < counter; rowIndex++)
                {
                    var idx = rowIndexOverloadDop + rowIndex;
                    columntxt = (GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex];
                    columnck = (GridViewDataColumn)grid.Columns[0];
                    var status = grid.GetRowValues(idx, ((GridViewDataColumn)grid.Columns[4]).FieldName);

                    txt = (TextBox)grid.FindRowCellTemplateControl(idx, columntxt, "txtAmountDue");
                    cb = (CheckBox)grid.FindRowCellTemplateControl(idx, columnck, "ckbSelectPolicies");

                    if (cb != null && cb.Checked == true)
                    {
                        txt.Enabled = true;
                        if(clicked.ClientID == cb.ClientID)
                            txt.Focus();
                        selectedCheckBoxes.Add(cb);
                        if (status.ToString().Contains("CA"))
                        {
                            showCancelledMessage = true;
                            cb.Enabled = false;
                            cb.Checked = false;
                            txt.Enabled = false;
                        }
                    }
                    else
                    {
                        decimal amount = 0;
                        decimal.TryParse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency, CultureInfo.InvariantCulture, out amount);
                        txt.Enabled = false;
                        ASPxLabel lbl = (ASPxLabel)grid.FindFooterCellTemplateControl((GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex], "txtTotalPendingAmount");
                        decimal total = decimal.Parse((string.IsNullOrEmpty(lbl.Text) ? "0.00" : lbl.Text).ToString(), NumberStyles.Currency);
                        total -= amount;
                        lbl.Text = (total).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                        txt.Text = string.Empty;
                    }
                }
                if (showCancelledMessage)
                    Utils.JSExec(this, "$(document).ready(function () { paymentCancelModeConfirmation(true); }); ");
            }
        }

        protected void txtTotalPendingAmount_Init(object sender, EventArgs e)
        {
            if (ContactId != null)
            {
                ASPxLabel label = sender as ASPxLabel;
                GridViewFooterCellTemplateContainer container = label.NamingContainer as GridViewFooterCellTemplateContainer;
                if ((container.Column as GridViewDataColumn).Caption == "Fecha de vencimiento")
                {
                    label.Text = "Total";
                    label.Font.Bold = true;
                }
                if ((container.Column as GridViewDataColumn).FieldName == PendingAmountField)
                {
                    var grid = (ASPxGridView)this.gvDOPPolicies;
                    decimal total = 0;
                    int rowIndexOverloadDop = 0;
                    var counter = Utils.GetRowVisibleCount(grid, PolicyNumberField, out rowIndexOverloadDop);
                    for (int rowIndex = 0; rowIndex < counter; rowIndex++)
                    {
                        var idx = rowIndexOverloadDop + rowIndex;
                        decimal val = 0;
                        var value = grid.GetRowValues(idx, PendingAmountField);
                        decimal.TryParse((value ?? "0").ToString(), out val);
                        total += val;
                    }
                    label.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                    //label.BackColor = ColorTranslator.FromHtml("#58AA00");
                }
                if ((container.Column as GridViewDataColumn).Caption == "Valor a pagar")
                {
                    int total = 0;
                    if (string.IsNullOrEmpty(label.Text))
                        label.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }

        protected void txtAmountDue_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            var grid = (ASPxGridView)this.gvDOPPolicies;
            TextBox txtAmount = (TextBox)sender;

            GridViewDataColumn columnck = null, columntxt = null, columnlbl = null;
            CheckBox cb = null;
            TextBox txt = null;
            ASPxLabel lbl = null;
            int rowIndexOverloadDop = 0;
            var counter = Utils.GetRowVisibleCount(grid, PolicyNumberField, out rowIndexOverloadDop);
            for (int rowIndex = 0; rowIndex < counter; rowIndex++)
            {
                var idx = rowIndexOverloadDop + rowIndex;
                columntxt = (GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex];
                columnck = (GridViewDataColumn)grid.Columns[0];
                columnlbl = (GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex];

                cb = (CheckBox)grid.FindRowCellTemplateControl(idx, columnck, "ckbSelectPolicies");
                txt = (TextBox)grid.FindRowCellTemplateControl(idx, columntxt, "txtAmountDue");
                lbl = (ASPxLabel)grid.FindFooterCellTemplateControl(columnlbl, "txtTotalPendingAmount");
                decimal value = Utils.getDecimalValue((grid.GetRowValues(idx, PendingAmountField) ?? string.Empty).ToString());

                if (cb != null && cb.Checked == true && !string.IsNullOrEmpty(txt.Text))
                {
                    if (decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency) < 0)
                        txt.Text = "0.00";

                    #region LImita al usuario a pagar monto nunca mayor al monto pendiente - Comentado por requerimiento de mejora
                    //if (decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency) > value)
                    //    txt.Text = value.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                    #endregion

                    decimal amount;
                    amount = decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency);
                    total += amount;
                    lbl.Text = (total).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
                if (cb != null && cb.Checked == true && string.IsNullOrEmpty(txt.Text))
                {
                    decimal amount = default(decimal);
                    total += amount;
                    lbl.Text = (total).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }

        protected void gvUSDPolicies_DataBinding(object sender, EventArgs e)
        {
            (sender as ASPxGridView).DataSource = GetEntityServerModeSourceUSD();
        }

        private EntityServerModeSource GetEntityServerModeSourceUSD()
        {
            EntityServerModeSource esms = new EntityServerModeSource();
            switch (this.SystemData)
            {
                case Collectors.Helpers.Enums.SystemData.Global:
                    int contactid;
                    int.TryParse((ContactId ?? string.Empty).ToString(), out contactid);
                    esms.KeyExpression = "Policy_No";
                    esms.QueryableSource = CSS.Value.getPoliciesByContactID(contactid).Where(c => c.Currency_Id == 1).AsQueryable();
                    break;
                case Collectors.Helpers.Enums.SystemData.GP:
                default:
                    string policy_number = (ContactId ?? string.Empty).ToString();
                    if (string.IsNullOrEmpty(policy_number)) return null;
                    string Client_ID = CSS.Value.getClientIdByPolicyNumber(policy_number);
                    var policiesGP = CSS.Value.getPoliciesByClientIDGP(Client_ID, policy_number);
                    esms.KeyExpression = "POLICY_NUMBER";
                    esms.QueryableSource = policiesGP.Where(d => d.CURRENCY_ID == Collectors.Helpers.Enums.Currency.USD.ToString()).AsQueryable();
                    break;
            }
            return esms;
        }

        protected void txtTotalPendingAmountUSD_Init(object sender, EventArgs e)
        {
            if (ContactId != null)
            {
                ASPxLabel label = sender as ASPxLabel;
                GridViewFooterCellTemplateContainer container = label.NamingContainer as GridViewFooterCellTemplateContainer;
                if ((container.Column as GridViewDataColumn).Caption == "Fecha de vecimiento")
                {
                    label.Text = "Total";
                }
                if ((container.Column as GridViewDataColumn).FieldName == PendingAmountField)
                {
                    var grid = (ASPxGridView)this.gvUSDPolicies;
                    decimal total = 0;
                    var rowIndexOverloadUsd = 0;
                    var counterusd = Utils.GetRowVisibleCount(grid, PolicyNumberField, out rowIndexOverloadUsd);
                    for (int rowIndex = 0; rowIndex < counterusd; rowIndex++)
                    {
                        var idx = rowIndexOverloadUsd + rowIndex;
                        decimal val = 0;
                        var value = grid.GetRowValues(idx, PendingAmountField);
                        decimal.TryParse((value ?? "0").ToString(), out val);
                        total += val;
                    }
                    label.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
                if ((container.Column as GridViewDataColumn).Caption == "Valor a pagar")
                {
                    int total = 0;
                    if (string.IsNullOrEmpty(label.Text))
                        label.Text = total.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }

        protected void txtAmountDueUSD_TextChanged(object sender, EventArgs e)
        {
            decimal total = 0;
            var grid = (ASPxGridView)this.gvUSDPolicies;
            TextBox txtAmount = (TextBox)sender;

            GridViewDataColumn columnck = null, columntxt = null, columnlbl = null;
            CheckBox cb = null;
            TextBox txt = null;
            ASPxLabel lbl = null;
            var rowIndexOverloadUsd = 0;
            var counterusd = Utils.GetRowVisibleCount(grid, PolicyNumberField, out rowIndexOverloadUsd);
            for (int rowIndex = 0; rowIndex < counterusd; rowIndex++)
            {
                var idx = rowIndexOverloadUsd + rowIndex;
                columntxt = (GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex];
                columnck = (GridViewDataColumn)grid.Columns[0];
                columnlbl = (GridViewDataColumn)grid.Columns[AmountToPaidColumnIndex];

                cb = (CheckBox)grid.FindRowCellTemplateControl(idx, columnck, "ckbSelectPoliciesUSD");
                txt = (TextBox)grid.FindRowCellTemplateControl(idx, columntxt, "txtAmountDueUSD");
                lbl = (ASPxLabel)grid.FindFooterCellTemplateControl(columnlbl, "txtTotalPendingAmountUSD");
                decimal value = Utils.getDecimalValue((grid.GetRowValues(idx, PendingAmountField) ?? string.Empty).ToString());

                if (cb != null && cb.Checked == true && !string.IsNullOrEmpty(txt.Text))
                {
                    if (decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency) < 0)
                        txt.Text = "0.00";
                    if (decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency) > value)
                        txt.Text = value.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

                    decimal amount;
                    amount = decimal.Parse((string.IsNullOrEmpty(txt.Text) ? "0.00" : txt.Text), NumberStyles.Currency);
                    total += amount;
                    lbl.Text = (total).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
                if (cb != null && cb.Checked == true && string.IsNullOrEmpty(txt.Text))
                {
                    decimal amount = default(decimal);
                    total += amount;
                    lbl.Text = (total).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                }
            }
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            var griddop = (ASPxGridView)this.gvDOPPolicies;
            ASPxLabel lbldop = (ASPxLabel)griddop.FindFooterCellTemplateControl((GridViewDataColumn)griddop.Columns[AmountToPaidColumnIndex], "txtTotalPendingAmount");
            lbldop.Text = ("$0.00");
            var rowIndexOverloadDop = 0;
            var counterdop = Utils.GetRowVisibleCount(griddop, PolicyNumberField, out rowIndexOverloadDop);
            for (int rowIndex = 0; rowIndex < counterdop; rowIndex++)
            {
                var idx = rowIndexOverloadDop + rowIndex;
                CheckBox cbdop = (CheckBox)griddop.FindRowCellTemplateControl(idx, (GridViewDataColumn)griddop.Columns[0], "ckbSelectPolicies");
                TextBox txtdop = (TextBox)griddop.FindRowCellTemplateControl(idx, (GridViewDataColumn)griddop.Columns[AmountToPaidColumnIndex], "txtAmountDue");
                cbdop.Checked = false;
                txtdop.Text = string.Empty;
                txtdop.Enabled = false;
            }

            var gridusd = (ASPxGridView)this.gvUSDPolicies;
            ASPxLabel lblusd = (ASPxLabel)gridusd.FindFooterCellTemplateControl((GridViewDataColumn)gridusd.Columns[AmountToPaidColumnIndex], "txtTotalPendingAmountUSD");
            lblusd.Text = ("$0.00");
            var rowIndexOverloadUsd = 0;
            var counterusd = Utils.GetRowVisibleCount(gridusd, PolicyNumberField, out rowIndexOverloadUsd);
            for (int rowIndex = 0; rowIndex < counterusd; rowIndex++)
            {
                var idx = rowIndexOverloadUsd + rowIndex;
                CheckBox cbusd = (CheckBox)gridusd.FindRowCellTemplateControl(idx, (GridViewDataColumn)gridusd.Columns[0], "ckbSelectPoliciesUSD");
                TextBox txtusd = (TextBox)gridusd.FindRowCellTemplateControl(idx, (GridViewDataColumn)gridusd.Columns[AmountToPaidColumnIndex], "txtAmountDueUSD");
                cbusd.Checked = false;
                txtusd.Text = string.Empty;
                txtusd.Enabled = false;
            }
            (this.Page as Pages.ProcessPayments).usdPayments = (this.Page as Pages.ProcessPayments).dopPayments = null;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if ((this.Page as Pages.ProcessPayments).ActiveView != "2" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwPoliciesPayments")
            {
                (this.Page as Pages.ProcessPayments).setStep2 = true;
                (this.Page as Pages.ProcessPayments).setStep3 = false;
                ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = "1";
                ContactId = string.Empty;
                (this.Page as Pages.ProcessPayments).setActiveView(1);
                return;
            }
            if ((this.Page as Pages.ProcessPayments).ActiveView != "2" && (this.Page as Pages.ProcessPayments).getActiveView() == "vwSearchClient")
            {
                ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = "1";
                ContactId = string.Empty;
                (this.Page as Pages.ProcessPayments).setActiveView(1);
                return;
            }

            var dopPayments = new List<Payment>();
            var usdPayments = new List<Payment>();

            #region PARTE EN PESOS
            var griddop = (ASPxGridView)this.gvDOPPolicies;
            ASPxLabel lbldop = (ASPxLabel)griddop.FindFooterCellTemplateControl((GridViewDataColumn)griddop.Columns[AmountToPaidColumnIndex], "txtTotalPendingAmount");
            var rowIndexOverloadDop = 0;
            var counterdop = Utils.GetRowVisibleCount(griddop, PolicyNumberField, out rowIndexOverloadDop);
            for (int rowIndex = 0; rowIndex < counterdop; rowIndex++)
            {
                var idx = rowIndexOverloadDop + rowIndex;
                CheckBox cbdop = (CheckBox)griddop.FindRowCellTemplateControl(idx, (GridViewDataColumn)griddop.Columns[0], "ckbSelectPolicies");
                TextBox txtdop = (TextBox)griddop.FindRowCellTemplateControl(idx, (GridViewDataColumn)griddop.Columns[AmountToPaidColumnIndex], "txtAmountDue");
                if (cbdop.Checked && !string.IsNullOrEmpty(txtdop.Text) && decimal.Parse((string.IsNullOrEmpty(txtdop.Text) ? "0.00" : txtdop.Text), NumberStyles.Currency) > 0)
                {
                    dopPayments.Add(new Payment
                    {
                        Policy_No = griddop.GetRowValues(idx, PolicyNumberField).ToString(),
                        Product_Desc = (griddop.GetRowValues(idx, ProductDescriptionField) ?? "N/A").ToString(),
                        Bussiness_Line_Id = int.Parse((griddop.GetRowValues(idx, BusinessLineIdField) ?? "0").ToString()),
                        Bl_Desc = (this.SystemData == Collectors.Helpers.Enums.SystemData.GP) ? griddop.GetRowValues(idx, BusinessLineDescriptionField).ToString() : PS.Value.getBusinessLineByLine_Id(int.Parse((griddop.GetRowValues(idx, BusinessLineIdField) ?? "0").ToString())).Bl_Desc.Trim().ToUpper(),
                        Currency_Id = int.Parse((this.SystemData == Collectors.Helpers.Enums.SystemData.GP ? (int)(Enum.Parse(typeof(Collectors.Helpers.Enums.Currency), (griddop.GetRowValues(idx, CurrencyIdField) ?? Collectors.Helpers.Enums.Currency.DOP).ToString())) : (griddop.GetRowValues(idx, CurrencyIdField)) ?? (int)Collectors.Helpers.Enums.Currency.DOP).ToString()),
                        DueDate = DateTime.Parse((griddop.GetRowValues(idx, DueDateField) ?? new DateTime()).ToString()),
                        PendingAmount = Utils.getDecimalValue((griddop.GetRowValues(idx, PendingAmountField) ?? string.Empty).ToString()),
                        TotalDueAmount = Utils.getDecimalValue((griddop.GetRowValues(idx, TotalDueAmountField) ?? string.Empty).ToString()),
                        PaidAmount = decimal.Parse((string.IsNullOrEmpty(txtdop.Text) ? "0.00" : txtdop.Text), NumberStyles.Currency),
                        Annual_Premium = ((this.SystemData == Collectors.Helpers.Enums.SystemData.Global) ? Utils.getDecimalValue((griddop.GetRowValues(idx, AnnualPremiumField) ?? string.Empty).ToString()) : 0.00M),
                        Full_Name = griddop.GetRowValues(idx, FullNameField).ToString()
                    });
                }
            }
            if (dopPayments.Sum(t => t.PaidAmount) != decimal.Parse((string.IsNullOrEmpty(lbldop.Text) ? "0.00" : lbldop.Text), NumberStyles.Currency))
            {
                Utils.JSExec(this, "SendAlert('Ocurrió un error con el monto a procesar, el resultado es diferente a la lista de pagos seleccionada, favor intenta nuevamente desde el inicio de la aplicación.')");
                return;
            }
            #endregion

            #region PARTE EN DOLARES
            var gridusd = (ASPxGridView)this.gvUSDPolicies;
            ASPxLabel lblusd = (ASPxLabel)gridusd.FindFooterCellTemplateControl((GridViewDataColumn)gridusd.Columns[AmountToPaidColumnIndex], "txtTotalPendingAmountUSD");
            var counterusd = Utils.GetRowVisibleCount(gridusd, PolicyNumberField, out rowIndexOverloadDop);
            for (int rowIndex = 0; rowIndex < counterusd; rowIndex++)
            {
                var idx = rowIndexOverloadDop + rowIndex;
                CheckBox cbusd = (CheckBox)gridusd.FindRowCellTemplateControl(idx, (GridViewDataColumn)gridusd.Columns[0], "ckbSelectPoliciesUSD");
                TextBox txtusd = (TextBox)gridusd.FindRowCellTemplateControl(idx, (GridViewDataColumn)gridusd.Columns[AmountToPaidColumnIndex], "txtAmountDueUSD");
                if (cbusd.Checked && !string.IsNullOrEmpty(txtusd.Text) && decimal.Parse((string.IsNullOrEmpty(txtusd.Text) ? "0.00" : txtusd.Text), NumberStyles.Currency) > 0)
                {
                    usdPayments.Add(new Payment
                    {
                        Policy_No = gridusd.GetRowValues(idx, PolicyNumberField).ToString(),
                        Product_Desc = (gridusd.GetRowValues(idx, ProductDescriptionField) ?? "N/A").ToString(),
                        Bussiness_Line_Id = int.Parse((gridusd.GetRowValues(idx, BusinessLineIdField) ?? "0").ToString()),
                        Bl_Desc = (this.SystemData == Collectors.Helpers.Enums.SystemData.GP) ? griddop.GetRowValues(idx, BusinessLineDescriptionField).ToString() : PS.Value.getBusinessLineByLine_Id(int.Parse((gridusd.GetRowValues(idx, BusinessLineIdField) ?? "0").ToString())).Bl_Desc.Trim().ToUpper(),
                        Currency_Id = int.Parse((this.SystemData == Collectors.Helpers.Enums.SystemData.GP ? (Collectors.Helpers.Enums.Currency)Enum.Parse(typeof(Collectors.Helpers.Enums.Currency), (gridusd.GetRowValues(idx, CurrencyIdField) ?? Collectors.Helpers.Enums.Currency.DOP).ToString()) : (gridusd.GetRowValues(idx, CurrencyIdField)) ?? (int)Collectors.Helpers.Enums.Currency.DOP).ToString()),
                        DueDate = DateTime.Parse((gridusd.GetRowValues(idx, DueDateField) ?? new DateTime()).ToString()),
                        PendingAmount = Utils.getDecimalValue((gridusd.GetRowValues(idx, PendingAmountField) ?? string.Empty).ToString()),
                        TotalDueAmount = Utils.getDecimalValue((gridusd.GetRowValues(idx, TotalDueAmountField) ?? string.Empty).ToString()),
                        PaidAmount = decimal.Parse((string.IsNullOrEmpty(txtusd.Text) ? "0.00" : txtusd.Text), NumberStyles.Currency),
                        Annual_Premium = ((this.SystemData == Collectors.Helpers.Enums.SystemData.Global) ? Utils.getDecimalValue((gridusd.GetRowValues(idx, AnnualPremiumField) ?? string.Empty).ToString()) : 0.00M),
                        Full_Name = gridusd.GetRowValues(idx, FullNameField).ToString()
                    });
                }
            }
            if (usdPayments.Sum(t => t.PaidAmount) != decimal.Parse((string.IsNullOrEmpty(lblusd.Text) ? "0.00" : lblusd.Text), NumberStyles.Currency))
            {
                Utils.JSExec(this, "SendAlert('Ocurrió un error con el monto a procesar, el resultado es diferente a la lista de pagos seleccionada, favor intenta nuevamente desde el inicio de la aplicación.')");
                return;
            }
            #endregion

            if (dopPayments.Count() > 0 && usdPayments.Count() == 0)
            {
                //Procesar pagos en pesos
                changeView();
                (this.Page as Pages.ProcessPayments).ContactId = ContactId;
                (this.Page as Pages.ProcessPayments).dopPayments = dopPayments;

            }
            if (dopPayments.Count() == 0 && usdPayments.Count() > 0)
            {
                //procesar pagos en dolares
                changeView();
                (this.Page as Pages.ProcessPayments).ContactId = ContactId;
                (this.Page as Pages.ProcessPayments).usdPayments = usdPayments;
            }
            if (dopPayments.Count() == 0 && usdPayments.Count() == 0)
            {
                Utils.JSExec(this, "SendAlert('Usted debe indicar un monto valido para poder procesar la transacción. El monto no puede estar en blanco, ni ser igual a 0.')");
                return;
            }
            setPaymentAmountToPay();
            (this.Page as Pages.ProcessPayments).setStep3 = true;
            var r = (this.Page as Pages.ProcessPayments).resetPayment;
        }

        private void setPaymentAmountToPay()
        {
            List<Payment> dop = (this.Page as Pages.ProcessPayments).dopPayments;
            List<Payment> usd = (this.Page as Pages.ProcessPayments).usdPayments;

            (this.Page as Pages.ProcessPayments).amountToBePaid = "$0.00";
            if (dop != null && dop.Count > 0)
                (this.Page as Pages.ProcessPayments).amountToBePaid = (dop.Sum(p => p.PaidAmount).Value).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            if (usd != null && usd.Count > 0)
                (this.Page as Pages.ProcessPayments).amountToBePaid = (usd.Sum(p => p.PaidAmount).Value).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void changeView()
        {
            ActiveView = (this.Page as Pages.ProcessPayments).ActiveView = "3";
            (this.Page as Pages.ProcessPayments).setActiveView(3);
            //ContactId = string.Empty;
        }

        protected void gvDOPPolicies_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                int LangID = int.Parse(ConfigurationManager.AppSettings["Language"].ToString());
                LangID = (LangID == 0) ? 1 : LangID;
                if (e.Column.FieldName == AnnualPremiumField || e.Column.FieldName == PendingAmountField)
                {
                    e.DisplayText = Decimal.Parse((e.Value ?? "0").ToString()).ToString("c2", CultureInfo.CreateSpecificCulture("en-US"));
                }
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        if (e.Column.FieldName == BusinessLineDescriptionField || e.Column.FieldName == ProductDescriptionField || e.Column.FieldName == PolicyStatusDescriptionField)
                            e.DisplayText = UTS.Value.getTranslatedTextByLiteralDesc((e.Value ?? string.Empty).ToString(), LangID);
                        break;
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        if (e.Column.FieldName == BusinessLineDescriptionField)
                            e.DisplayText = PS.Value.getBusinessLineByLineCodeGP(int.Parse((e.Value ?? "0").ToString())).Bl_Desc;
                        if (e.Column.FieldName == ProductDescriptionField)
                            e.DisplayText = PS.Value.getProductDescriptionByPlanTypeCodeGP((e.Value ?? "0").ToString());

                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}