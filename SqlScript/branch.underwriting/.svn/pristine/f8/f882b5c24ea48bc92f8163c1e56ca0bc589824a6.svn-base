using AjaxControlToolkit;
using DevExpress.Web;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using Entity.UnderWriting.IllusData;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy
{
    public partial class WUCIllustrationPopup : UC, IUC
    {
        public bool ISFiltering
        {
            get { return ViewState["ISFiltering"].ToBoolean(); }
            set { ViewState["ISFiltering"] = value; }
        }

        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang)
        {
            ltIllustraciones.Text = Resources.IllustrationList;
            gvIllustration.TranslateColumnsAspxGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvIllustration.FocusedRowIndex = -1;

            var ShowIllustration = !ViewState["ShowPopIllustrationList"].isNullReferenceObject() ?
                                 (Boolean)ViewState["ShowPopIllustrationList"]
                                 : false;

            if (ShowIllustration)
            {
                var ModalPopupIllustrations = this.Parent.FindControl("ModalPopupIllustrations");

                if (!ModalPopupIllustrations.isNullReferenceControl())
                    (ModalPopupIllustrations as ModalPopupExtender).Show();
            }

        }

        public void ClearData()
        {
            this.ExcecuteJScript("$('#gvIllustration').find('.dxgvFilterBarClearButtonCell_DevEx').find('a:first').click();");
            CleanControls(this);
            gvIllustration.DataSource = null;
            gvIllustration.DataBind();
        }

        protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
        {
            var data = ObjIllustrationServices
                      .oIllusDataManager
                      .GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
                {
                    RCustomerNo = ObjServices.Contact_Id
                }).Select(o => new
                      {
                          CustomerPlanNo = o.CustomerPlanNo,
                          Product = o.Product,
                          DispIllustrationNo = o.DispIllustrationNo,
                          DateUpdated = o.DateUpdated,
                          InsuredName = o.InsuredName,
                          IllustrationStatus = Resources.ResourceManager.GetString(o.IllustrationStatus)
                      });

            e.KeyExpression = "CustomerPlanNo;Product;DispIllustrationNo;DateUpdated";
            e.QueryableSource = data.AsQueryable();
            gvIllustration.SetFilterSettings();
        }

        public void FillData()
        {
            ISFiltering = false;
            gvIllustration.DataBind();
            gvIllustration.FocusedRowIndex = -1;
        }

        public void Initialize()
        {
            ClearData();
            FillData();
        }

        private Entity.UnderWriting.IllusData.Illustrator.CustomerPlanDetail getDataPlan(long? pCustomerPlanNo)
        {
            var result = ObjIllustrationServices
                      .oIllusDataManager
                      .GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
            {
                CustomerPlanNo = pCustomerPlanNo
            }).FirstOrDefault();

            return result;
        }

        protected void gvIllustration_FocusedRowChanged(object sender, EventArgs e)
        {
            var grid = ((ASPxGridView)sender);

            if (grid.FocusedRowIndex > -1 && !ISFiltering)
            {
                var CustomerPlanNo = long.Parse(grid.GetKeyFromAspxGridView("CustomerPlanNo").ToString());
                var data = getDataPlan(CustomerPlanNo);
                var bodyContent = this.Page.Master.FindControl("bodyContent");
                var PlanPolicyContainer = bodyContent.FindControl("PlanPolicyContainer");
                var WUCPlanInformation = PlanPolicyContainer.FindControl("WUCPlanInformation");

                if (!WUCPlanInformation.isNullReferenceControl())
                    (WUCPlanInformation as WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy.WUCPlanInformation).LoadDataFromIllustration(data);

                grid.FocusedRowIndex = -1;
                ViewState["ShowPopIllustrationList"] = false;
                this.ExcecuteJScript("$('#close_pop_up').click();");
            }
        }

        protected void gvIllustration_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
        {
            ISFiltering = true;
        }

        protected void gvIllustration_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            if (e.CallbackName == "APPLYFILTER" || e.CallbackName == "APPLYCOLUMNFILTER" || e.CallbackName == "APPLYHEADERCOLUMNFILTER")
            {
                ISFiltering = true;
                gvIllustration.FocusedRowIndex = -1;
                gvIllustration.SetFilterSettings();
            }
        }
    }
}