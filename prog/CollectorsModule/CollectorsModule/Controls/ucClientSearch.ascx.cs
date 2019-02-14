using Collectors.Helpers;
using CollectorsModule.bll;
using CollectorsModule.Commons;
using CollectorsModule.Pages;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectorsModule.Controls
{
    public partial class ucClientSearch : System.Web.UI.UserControl
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
        public Enums.SystemData SystemData
        {
            get
            {
                return string.IsNullOrEmpty(ConfigurationManager.AppSettings["SystemData"]) ? Collectors.Helpers.Enums.SystemData.GP : (Enums.SystemData)Enum.Parse(typeof(Enums.SystemData), ConfigurationManager.AppSettings["SystemData"].ToString().ToUpper());
            }
        }
        public string DateOfBirthField
        {
            get
            {
                switch (this.SystemData)
                {
                    case Collectors.Helpers.Enums.SystemData.Global:
                        return "dob";
                    case Collectors.Helpers.Enums.SystemData.GP:
                    default:
                        return "DATE_OF_BIRTH";
                }
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
        private bool NeedBind { get { return (Session["need_bind"] == null) ? false : Convert.ToBoolean(Session["need_bind"]); } set { Session["need_bind"] = value; } }
        Lazy<ClientSearchService> CSS = new Lazy<ClientSearchService>();
        public bool initGrid { get { return (Session["initialize"] == null) ? false : Convert.ToBoolean(Session["initialize"]); } set { Session["initialize"] = value; } }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (NeedBind == null)
            {
                NeedBind = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsCallback && !IsPostBack)
            {
                clearGridClients();
                initGrid= true;
                initializeGrid();

            }
            (this.Page as Pages.ProcessPayments).setStep2 = (this.Page as Pages.ProcessPayments).setStep3 = false;
            (this.Page as Pages.ProcessPayments).setStep1 = true;
            
            if (this.Page.IsCallback)
            {
                NeedBind = true;
                this.gvClients.DataBind();
            }
        }

        public void clearGridClients()
        {
            this.NeedBind = false;
            ContactId = string.Empty;
            this.gvClients.Selection.UnselectAll();
            this.gvClients.FilterExpression = string.Empty;
            this.gvClients.DataBind();
        }

        public void resetGrid()
        {
            if (string.IsNullOrEmpty((this.Page as Pages.ProcessPayments).ContactId))
            {
                this.NeedBind = false;
                ContactId = string.Empty;
                this.gvClients.Selection.UnselectAll();
                this.gvClients.FilterExpression = string.Empty;
                this.gvClients.DataBind();
            }
        }

        public void initializeGrid() 
        {
            EntityServerModeSource esms = new EntityServerModeSource();
            switch (this.SystemData)
            {
                case Collectors.Helpers.Enums.SystemData.Global:
                    esms.KeyExpression = "RowKey";
                    esms.QueryableSource = CSS.Value.ClientsContext().Where(x => x.Contact_Id == 0).AsQueryable();
                    break;
                case Collectors.Helpers.Enums.SystemData.GP:
                default:
                    esms.KeyExpression = "POLICY_NUMBER";
                    esms.QueryableSource = CSS.Value.ClientsContextGP().Where(x => x.CUSTNAME == "xx").AsQueryable();
                    break;
            }
            this.gvClients.DataSource = esms;
            this.gvClients.DataBind();
            initGrid = false;
        }

        protected void gvClients_DataBinding(object sender, EventArgs e)
        {
            if (initGrid) return;
            if (Convert.ToBoolean(NeedBind))
                (sender as ASPxGridView).DataSource = GetEntityServerModeSource();
            else
                (sender as ASPxGridView).DataSource = null;
        }

        private EntityServerModeSource GetEntityServerModeSource()
        {
            EntityServerModeSource esms = new EntityServerModeSource();
            switch (this.SystemData)
            {
                case Collectors.Helpers.Enums.SystemData.Global:
                    esms.KeyExpression = "RowKey";
                    esms.QueryableSource = CSS.Value.ClientsContext();
                    break;
                case Collectors.Helpers.Enums.SystemData.GP:
                default:
                    esms.KeyExpression = "POLICY_NUMBER";
                    var clsCxt = CSS.Value.ClientsContextGP();
                    esms.QueryableSource = CSS.Value.ClientsContextGP();
                    break;
            }
            return esms;
        }

        protected void gvClients_FocusedRowChanged(object sender, EventArgs e)
        {
            var grid = (ASPxGridView)sender;
            //var key = Utils.GetKeyFromAspxGridView(grid, "Contact_Id");
            //var row = grid.GetRow(grid.FocusedRowIndex);
            var rows = (this.SystemData == Collectors.Helpers.Enums.SystemData.GP) ? grid.GetSelectedFieldValues("POLICY_NUMBER") : grid.GetSelectedFieldValues("Contact_Id");
            if (rows != null && rows.Count() > 0)
            {
                ContactId = rows.FirstOrDefault().ToString();
            }
            else
            {
                ContactId = string.Empty;
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ContactId))
            {
                (this.Page as Pages.ProcessPayments).ContactId = ContactId;
                (this.Page as Pages.ProcessPayments).ActiveView = "2";
                (this.Page as Pages.ProcessPayments).setActiveView(2);
            }
            else
            {
                Utils.JSExec(this, "loading(false);setGridStyles();SendAlert('No ha seleccionado un cliente.');");
                clearGridClients();
                initGrid = true;
                initializeGrid();
            }
        }

        protected void gvClients_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != DevExpress.Web.GridViewRowType.Data) return;
                string policy, qtyPolicies = string.Empty;
                //DevExpress.Data.Helpers.ServerModeCompoundKey key = (DevExpress.Data.Helpers.ServerModeCompoundKey)e.GetValue("Contact_Id");
                var contactid = (this.SystemData == Collectors.Helpers.Enums.SystemData.GP) ? e.GetValue("POLICY_NUMBER") : e.GetValue("Contact_Id");
                //policy = key.SubKeys[1].ToString();
                //qtyPolicies = key.SubKeys[2].ToString();
                if (contactid != null && contactid.ToString() != string.Empty)
                {
                    //System.Web.UI.WebControls.TableCell dataCell = e.Row.Cells[5] as System.Web.UI.WebControls.TableCell;
                    //dataCell.Text = CSS.Value.getPoliciesByContactIDGrouped(int.Parse(contactid.ToString()));
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCleanFilters_Click(object sender, EventArgs e)
        {
            clearGridClients();
            initGrid = true;
            initializeGrid();
        }

        protected void gvClients_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
        {
            string gpcolumns = "POLICY_NUMBER, CUSTNAME, DATE_OF_BIRTH, CLIENT_ID";
            string globalcolumns = "First_Name, Lastname, Dob, Id, Policy_No";
            if (!Regex.IsMatch((this.SystemData == Collectors.Helpers.Enums.SystemData.GP) ? gpcolumns : globalcolumns, "\\b" + e.Column.FieldName.Trim().ToUpper() + "\\b", RegexOptions.IgnoreCase)) return;

            if (e.Value != string.Empty)
            {
                if (e.Value.Length != e.Value.Trim().Length)
                {
                    e.Value = e.Value.Trim();
                    NeedBind = true;
                    this.gvClients.DataBind();
                }
                if (gvClients.DataSource == null)
                    NeedBind = true;

                if (e.Column.FieldName == DateOfBirthField)
                {
                    if (e.Value != null && e.Value.ToString() != string.Empty)
                    {
                        var date = (e.Value??string.Empty).ToString().Length> 9? e.Value.Split(' ')[0]: e.Value;
                        DateTime dt = DateTime.ParseExact((date).ToString(), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                        e.Value = dt.ToShortDateString();
                        NeedBind = true;
                        this.gvClients.DataBind();
                    }
                }

            }
            else
            {
                clearGridClients();
                initGrid = true;
                initializeGrid();
            }
        }

        protected void gvClients_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                int LangID = int.Parse(ConfigurationManager.AppSettings["Language"].ToString());
                LangID = (LangID == 0) ? 1 : LangID;
                if (e.Column.FieldName == DateOfBirthField)
                {
                    if (e.Value != null && e.Value.ToString() != string.Empty)
                    {
                        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                        e.DisplayText = DateTime.Parse((e.Value ?? new DateTime()).ToString()).ToShortDateString();
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void gvClients_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

        }

    }
}