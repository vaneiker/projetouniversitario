using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration
{
    public partial class UCIllustratorPreview : UC, IUC
    {
        private UCIllustrationContainer UCContainer
        {
            get
            {
                return (UCIllustrationContainer)Page.Controls[0].FindControl("bodyContent").FindControl("UCIllustrationContainer");
            }
        }

        private string ReportPath
        {
            get
            {
                return ViewState["ReportPath"].ToString();
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
                return ViewState["ReportName"].ToString();
            }
            set
            {
                ViewState["ReportName"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Translator(null);
        }

        public void Translator(string Lang)
        {
            btnBackToPlanInfo.Text = Resources.BackToPlanInfo;
            btnCostumize.Text = Resources.Customize;
            btnDownloadPdf.Text = Resources.Download + " PDF";
            btnEmailIllustration.Text = "E-mail " + Resources.Illustration;
            btnRefresh.Text = Resources.Refresh;
            btnSign.Text = Resources.Sign;
        }

        public void save()
        {

        }

        public void edit()
        {

        }

        public void FillData()
        {

        }

        public void Initialize()
        {


        }

        public void ClearData()
        {

        }

        public void PreviewReport(byte[] reportArray, string reportName)
        {
            var path = Server.MapPath("~/TempFiles/");
            ReportName = reportName + ".pdf";
            ReportPath = path + ReportName;
            File.WriteAllBytes(ReportPath, reportArray);
            iframeReport.Src = "~/TempFiles/" + ReportName;
        }

        protected void btnBackToPlanInfo_Click(object sender, EventArgs e)
        {
            UCContainer.SetMultiView(UCIllustrationContainer.MultiViewIllustrator.PlanInformation);
        }

        protected void btnEmailIllustration_Click(object sender, EventArgs e)
        {
            var to = ((WEB.NewBusiness.NewBusiness.Pages.Contact)this.Page).Usuario.Email;
            if (String.IsNullOrEmpty(to))
            {
                JSTools.MessageBox(this, RESOURCE.UnderWriting.NewBussiness.Resources.UserDontHaveEmail);
                return;
            }

            var from = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
            var t = new Thread(delegate()
            {
                MailManager.SendMessage(to, null, null, null, null, from, "Illustration: " + ReportName,
                 new List<AttachedFiles>
                {
                    new AttachedFiles{
                    FileName = ReportName,
                    FilePath = ReportPath
                    }
                }, true);
            });

            JSTools.MessageBox(this, RESOURCE.UnderWriting.NewBussiness.Resources.EmailSended);
            t.Start();
        }

        protected void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(ReportPath, FileMode.Open);
            long fileSize = fs.Length;
            byte[] Buffer = new byte[(int)fileSize];
            fs.Read(Buffer, 0, (int)fs.Length);
            fs.Close();
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Content-Type", "binary/octet-stream");

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename="+ ReportName);
            Response.BinaryWrite(Buffer);
            Response.Flush();
            Response.End();
        }

        protected void btnSign_Click(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        protected void btnCostumize_Click(object sender, EventArgs e)
        {

        }


        public void ReadOnlyControls(bool isReadOnly)
        {

        }
    }
}