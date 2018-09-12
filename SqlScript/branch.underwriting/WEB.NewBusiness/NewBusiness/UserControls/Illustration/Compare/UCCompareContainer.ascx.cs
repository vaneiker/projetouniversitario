using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RESOURCE.UnderWriting.NewBussiness;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.Compare
{
    public partial class UCCompareContainer : UC, IUC
    {
        private UCIllustrationContainer UCContainer
        {
            get
            {
                return (UCIllustrationContainer)Page.Controls[0].FindControl("bodyContent").FindControl("UCIllustrationContainer");
            }
        }

        private List<long> ListCustomerPlanNoIllustrationPreview
        {
            get
            {
                var lst = (List<long>)ViewState["ListCustomerPlanNoIllustrationPreview"];
                return lst == null ? null : lst;
            }
            set
            {
                ViewState["ListCustomerPlanNoIllustrationPreview"] = value;
            }
        }

        private string ReportPath
        {
            get
            {
                var data = ViewState["ReportPath"];
                return data == null ? null : ViewState["ReportPath"].ToString();
            }
            set
            {
                ViewState["ReportPath"] = value;
            }
        }

        private string ReportName
        {
            get
            {
                var data = ViewState["ReportName"];
                return data == null ? null : ViewState["ReportName"].ToString();
            }
            set
            {
                ViewState["ReportName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UCCompareCases.AddIllustrationToCompare += AddIllustrationToCompare;
            UCCompareCases.RemoveIllustrationToCompare += RemoveIllustrationToCompare;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translator(null);
        }

        public void Translator(string Lang)
        {
            btnCompare.Text = Resources.CompareIllustration;
            btnViewPdf.Text = Resources.View + " PDF";
            btnEmailIllustration.Text = "E-mail " + Resources.Illustration;
            btnBackToPlanInfo.Text = Resources.BackToPlanInfo;
        }

        public void save()
        {

        }

        public void edit()
        {

        }

        public void FillData()
        {
            UCCompareCases.FillData();
            var insured = ObjIllustrationServices.oIllusDataManager.GetCustomerDetailById(ObjIllustrationServices.CustomerNo, null);
            txtFirstName.Text = insured.FirstName;
            txtMiddleName.Text = insured.MiddleName;
            txtLastName.Text = insured.LastName;
            txtScndLastName.Text = insured.LastName2;
            ListCustomerPlanNoIllustrationPreview = new List<long>();
            rpIllustrationPreview.DataBind();
            mvComparer.ActiveViewIndex = 0;
            btnCompare.Visible = false;
            btnViewPdf.Visible = true;
        }

        public void Initialize()
        {


        }

        public void ClearData()
        {

        }

        private void AddIllustrationToCompare(long customerPlanNo)
        {
            ListCustomerPlanNoIllustrationPreview.Add(customerPlanNo);
            rpIllustrationPreview.DataSource = ListCustomerPlanNoIllustrationPreview;
            rpIllustrationPreview.DataBind();

        }

        private void RemoveIllustrationToCompare(long customerPlanNo)
        {
            ListCustomerPlanNoIllustrationPreview.RemoveAll(o => o == customerPlanNo);
            rpIllustrationPreview.DataSource = ListCustomerPlanNoIllustrationPreview;
            rpIllustrationPreview.DataBind();
        }

        protected void rpIllustrationPreview_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            var uc = (UCComparePreview)e.Item.FindControl("UCComparePreview1");

            uc.FillData(e.Item.DataItem.ToLong());
        }

        protected void btnEmailIllustration_Click(object sender, EventArgs e)
        {

        }

        protected void btnViewPdf_Click(object sender, EventArgs e)
        {
            try
            {

            if (ListCustomerPlanNoIllustrationPreview.Any())
            {
                var reportArray = ObjIllustrationServices.CompareIllustrations(ListCustomerPlanNoIllustrationPreview);
                if (String.IsNullOrEmpty(ReportName))
                {
                    var path = Server.MapPath("~/TempFiles/");
                    ReportName = Utility.GetSerialId() + ".pdf";
                    ReportPath = path + ReportName;
                }
                File.WriteAllBytes(ReportPath, reportArray);
                iframeReport.Src = "~/TempFiles/" + ReportName;

                mvComparer.ActiveViewIndex = 1;
                btnCompare.Visible = true;
                btnViewPdf.Visible = false;
            }
            }
            catch (Exception ex)
            {
                JSTools.MessageBox(this, ex.GetLastInnerException().Message.RemoveInvalidCharacters());

            }
        }

        protected void btnBackToPlanInfo_Click(object sender, EventArgs e)
        {
            UCContainer.SetMultiView(UCIllustrationContainer.MultiViewIllustrator.PlanInformation);
        }

        public void ReadOnlyControls(bool isReadOnly)
        {

        }

        protected void btnCompare_Click(object sender, EventArgs e)
        {
            mvComparer.ActiveViewIndex = 0;
            btnCompare.Visible = false;
            btnViewPdf.Visible = true;
        }
    }
}