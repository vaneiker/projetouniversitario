using CollectorsModule.bll.Services;
using CollectorsModule.Commons;
using CollectorsModule.dal.Extensions;
using CollectorsModule.ell;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CollectorsModule.Pages
{
    public partial class DailyCash : System.Web.UI.Page
    {
        public static ReportViewer ObjReport;
        public static Lazy<PaymentsService> pmtmgr = new Lazy<PaymentsService>();
        public static Lazy<UtilitiesServices> utlmgr = new Lazy<UtilitiesServices>();
        private String UserName
        {
            get
            {
                Statetrust.Framework.Security.Bll.Usuarios User = (Statetrust.Framework.Security.Bll.Usuarios)Session["userData"];
                return User.UserLogin;
            }
        }
        private String DateRange
        {
            get { return ((this.txtDateFrom.Text == this.txtDateTo.Text) ? string.Format("{0}", this.txtDateTo.Text) : string.Format("{0} @ {1}", this.txtDateFrom.Text, this.txtDateTo.Text)); }
        }
        private String FullName
        {
            get
            {
                Statetrust.Framework.Security.Bll.Usuarios User = (Statetrust.Framework.Security.Bll.Usuarios)Session["userData"];
                return User.FullName;
            }
        }
        private Users UserInfo(string userName)
        {
            var user = utlmgr.Value.getUserInfoByID(userName);
            var userComplements = utlmgr.Value.getSecurityUserInfo(userName);
            var result = new Users {
                BankName = user.BankName,
                CheckBookID = user.CheckBookID,
                FirstName = userComplements.FirstName,
                FullName = userComplements.FullName,
                LastName = userComplements.LastName,
                OfficeName = user.OfficeName,
                UserID = user.UserID,
                UserLogin = userComplements.UserLogin
            };
            return result;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CollectorsModule.Master.CM.RedirectorSessionEnd(Session["userData"]);
                if (Session["userData"] == null)
                {
                    if (Path.GetFileName(Request.Url.AbsolutePath) != "SessionExpire.aspx")
                        Response.Redirect("SessionExpire.aspx", false);
                }
                Users userInfo;
                var usrAdmin = utlmgr.Value.isAdminUser(this.UserName);
                if (usrAdmin)
                {
                    this.regularUser.Visible = !(this.adminUser.Visible = usrAdmin);
                    this.ddlUsersSecurity.DataSource = utlmgr.Value.getSecurityUsersForPaymentsFilter(0);
                    this.ddlUsersSecurity.DataTextField = "FullNameLogin";
                    this.ddlUsersSecurity.DataValueField = "UserID";
                    this.ddlUsersSecurity.DataBind();
                    ddlUsersSecurity.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                    ddlUsersSecurity.SelectedIndex = -1;
                    this.txtCollectorName.Text = this.txtOfficeName.Text = string.Empty;
                }
                else
                {
                    this.regularUser.Visible = !(this.adminUser.Visible = usrAdmin);
                    userInfo = this.UserInfo(this.UserName);
                    txtCollectorName.Text = this.FullName.ToPascalCase();
                    txtOfficeName.Text = userInfo.OfficeName.ToPascalCase();
                }
            }
        }

        private ReportResponse GetReportByName(Enums.ReportTypes report, Users userInfo)
        {
            var datefrom = DateTime.ParseExact(this.txtDateFrom.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var dateto = DateTime.ParseExact(this.txtDateTo.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var Parameters = new List<ReportParameter>();
            var ObjDataSource = new Microsoft.Reporting.WebForms.ReportDataSource();
            var data = pmtmgr.Value.getDailyCashPayments(userInfo.UserLogin, datefrom, null, dateto);
            if (data != null && data.Any())
            {
                var ObjInfo = data.ToDataTable();
                byte[] Bytes = null;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                Warning[] warnings;
                string[] streamIds;
                ObjReport = new ReportViewer();
                ObjReport.LocalReport.Refresh();
                ObjReport.Reset();
                ObjReport.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/RPTDailyCash.rdl");
                ObjDataSource.Name = "DataSet1";
                ObjDataSource.Value = ObjInfo;

                ObjReport.LocalReport.EnableExternalImages = true;
                Parameters.Add(new ReportParameter("Collector", userInfo.UserLogin.ToPascalCase().CleanSpaces().Trim()));
                Parameters.Add(new ReportParameter("PaymentDate", this.txtDateFrom.Text));
                Parameters.Add(new ReportParameter("PaymentType", this.ddlPaymentType.SelectedValue.ToPascalCase().CleanSpaces().Trim()));
                Parameters.Add(new ReportParameter("CollectorName", userInfo.FullName.ToPascalCase().CleanSpaces().Trim()));
                Parameters.Add(new ReportParameter("OfficeName", userInfo.OfficeName.ToPascalCase().CleanSpaces()));
                Parameters.Add(new ReportParameter("DateRange", this.DateRange));
                Parameters.Add(new ReportParameter("ReportType", Collectors.Helpers.EnumHelper.GetDescription(report)));
                Parameters.Add(new ReportParameter("Transactions", data.Count().ToString()));
                ObjReport.LocalReport.DataSources.Add(ObjDataSource);
                ObjReport.LocalReport.SetParameters(Parameters);
                var parametersState = ObjReport.LocalReport.GetParameters();
                Bytes = ObjReport.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                return new ReportResponse { Report = Bytes, Error = false };
            }
            else
                return new ReportResponse {
                    Report = null,
                    Error = true
                };
        }

        protected void btPreview_Click(object sender, EventArgs e)
        {
            string reportId = (string)ddlReportsDailyCash.SelectedItem.Value;
            var report = (Enums.ReportTypes)Enum.Parse(typeof(Enums.ReportTypes), reportId);
            Session["ReportName"] = reportId;
            var usrAdmin = utlmgr.Value.isAdminUser(this.UserName);
            var userName =string.Empty;
            if (usrAdmin)
            {
                var objName = this.ddlUsersSecurity.SelectedItem.Text.Split('-');
                userName = objName[0].ToLower();
                this.txtCollectorName.Text = objName[1].Replace("(", string.Empty).Replace(")", string.Empty).Trim().ToPascalCase();
            }
            else
                userName = this.UserName;
            Users userInfo = this.UserInfo(userName);
            this.txtOfficeName.Text = userInfo.OfficeName.ToPascalCase();
            var path = Server.MapPath("~/Reports/TempFiles/");
            string ReportName = string.Format("{0}_{1}_{2}.pdf", reportId, userName.Trim(), DateTime.Now.ToString("yyyyMMddhhmmss"));
            var ReportPath = path + ReportName;
            var reportresult = GetReportByName(report, userInfo);
            if (!reportresult.Error)
            {
                File.WriteAllBytes(ReportPath, reportresult.Report);
                iReport.Src = "~/Reports/TempFiles/" + ReportName;
            }
            else
            {
                Utils.JSExec(this, "ErrorGeneratingReport(true);");
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
    }

    public struct ReportResponse
    {
        public byte[] Report { get; set; }
        public bool Error { get; set; }
    }
}