using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using DevExpress.Web;
using RESOURCE.UnderWriting.NewBussiness;
using Entity.UnderWriting.IllusData;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation
{
    public partial class WUCIllustration : UC, IUC
    {
        public bool? IsFocusRowChanged
        {
            get
            {
                var temp = ViewState["IsFocusRowChanged"];
                return temp.ToBoolean();
            }
            set
            {
                ViewState["IsFocusRowChanged"] = value;
            }
        }
        public void ReadOnlyControls(bool isReadOnly) { }
        public void save() { }
        public void edit() { }
        public void ClearData() { }
        protected void Page_Load(object sender, EventArgs e) { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            Illustrations.InnerHtml = Resources.Illustrations.ToUpper();
        }

        protected void gvIllustration_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        public void FillData()
        {
            var data = ObjIllustrationServices
                    .oIllusDataManager
                    .GetAllCustomerPlanDetail(new Illustrator.CustomerPlanDetailP
                {
                    RCustomerNo = ObjServices.Contact_Id
                }).Select(x => new
                     {
                         DispIllustrationNo = x.DispIllustrationNo,
                         CustomerPlanNo = x.CustomerPlanNo,
                         Product = x.Product,
                         PremiumAmount = x.PremiumAmount.ToFormatCurrency(),
                         InsuredAmount = (x.InsuredAmount <= 0 ? x.AnnuityAmount <= 0 ? x.BenefitAmount.GetValueOrDefault() : x.AnnuityAmount : x.InsuredAmount).ToFormatCurrency()
                     });

            gvIllustration.DataSource = data;

            gvIllustration.DataBind();
            gvIllustration.FocusedRowIndex = -1;
        }

        public void Initialize()
        {
            FillData();
        }

        protected void gvIllustration_PageSizeChanged(object sender, EventArgs e)
        {
            FillData();
        }

        protected void gvIllustration_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        protected void gvIllustration_FocusedRowChanged(object sender, EventArgs e)
        {
            if (IsFocusRowChanged.GetValueOrDefault())
            {
                IsFocusRowChanged = null;
                return;
            }

            var grid = ((ASPxGridView)sender);

            if (grid.FocusedRowIndex > -1)
            {
                ObjIllustrationServices.CustomerPlanNo = long.Parse(grid.GetKeyFromAspxGridView("CustomerPlanNo").ToString());
                var pageContact = (NewBusiness.Pages.Contact)Page;
                pageContact.ManageTabs("lnkIllustrations");
                IsFocusRowChanged = true;
            }
        }
    }
}