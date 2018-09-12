using System;
using System.Data;
using System.Linq;
using DevExpress.Data.Linq;
using DevExpress.Web;
using Web.SubmittedPolicies.Common.Classes;
using Web.SubmittedPolicies.Common.Interfaces;

namespace Web.SubmittedPolicies.Life.UserControls.Issue
{
    public partial class Printing : System.Web.UI.UserControl, IUc
    {
        private string FilterPolicyNo
        {
            get { return String.IsNullOrEmpty(hdnPolicyNo.Value) ? null : hdnPolicyNo.Value; }
            set { hdnPolicyNo.Value = value; }
        }
        private string FilterProductType
        {
            get { return String.IsNullOrEmpty(hdnProductType.Value) ? null : hdnProductType.Value; }
            set { hdnProductType.Value = value; }
        }
        private Boolean? FilterPrintStatus
        {
            get { return String.IsNullOrEmpty(hdnPrintStatus.Value) ? (Boolean?)null : Boolean.Parse(hdnPrintStatus.Value); }
            set { hdnPrintStatus.Value = value.ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillDrops();
        }

        public void Translator(Enums.Languages lang)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            gvPrinting.DataBind();
        }

        protected void dsPrintingPolicies_OnSelecting(object sender, LinqServerModeDataSourceSelectEventArgs e)
        {
            e.KeyExpression = "Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Policy_No";
            e.QueryableSource = Common.Classes.Common.DataService.GetPrintingPolicies(FilterPolicyNo, FilterProductType, FilterPrintStatus);
            gvPrinting.FocusedRowIndex = -1;
        }

        protected void lnkImprimir_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnFiltrar_OnClick(object sender, EventArgs e)
        {
            FilterPolicyNo = txtPolicyNo.Text;
            FilterProductType = ddlProductType.SelectedIndex < 1 ? null : ddlProductType.SelectedItem.Text;
            FilterPrintStatus = String.IsNullOrEmpty(ddlPrintingStatus.SelectedValue) ? (Boolean?)null : Boolean.Parse(ddlPrintingStatus.SelectedValue);
            FillData();
        }

        public void FillDrops()
        {
            ddlPrintingStatus.FillDrops(Common.Classes.Common.DataService.GetDropDowns(Enums.DropDowns.PrintStatus).OrderBy(r => r.Value).ToList());
            ddlProductType.FillDrops(Common.Classes.Common.DataService.GetDropDowns(Enums.DropDowns.LifeProduct).OrderBy(r => r.Text).ToList(), true, "Todos");
        }
    }
}