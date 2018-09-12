using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.Common
{
    public partial class WUCFooter : UC
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {           
            btnExport.Text = Resources.Export.ToUpper();
            SelectionGridMessage.InnerHtml = Resources.SelectionGridMessage;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ExportGrid(DevExpress.Web.ASPxGridView GridView, DevExpress.Web.ASPxGridViewExporter Exporter, String NameReport)
        {

            var LstRecordChecksDataReview = new List<DataReview>();
            var LstRecordChecksCases = new List<Case.Process>();

            if (GridView.ID == "gvSubmittedPolcies")
            {
                for (int i = GridView.VisibleStartIndex; i < GridView.VisibleRowCount; i++)
                {
                    var chk = GridView.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                    if (chk != null && chk.Checked)
                    {
                        var vOfficeDesc = GridView.GetKeyFromAspxGridView("OfficeDesc", i) != null ? GridView.GetKeyFromAspxGridView("OfficeDesc", i).ToString() : "";
                        var vPolicyNo = GridView.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                        var vProductDesc = GridView.GetKeyFromAspxGridView("ProductDesc", i) != null ? GridView.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                        var vUserName = GridView.GetKeyFromAspxGridView("UserName", i) != null ? GridView.GetKeyFromAspxGridView("UserName", i).ToString() : "";
                        var vInsuredFullName = GridView.GetKeyFromAspxGridView("InsuredFullName", i) != null ? GridView.GetKeyFromAspxGridView("InsuredFullName", i).ToString() : "";
                        var vOwnerFullName = GridView.GetKeyFromAspxGridView("OwnerFullName", i) != null ? GridView.GetKeyFromAspxGridView("OwnerFullName", i).ToString() : "";
                        var vAgentFullName = GridView.GetKeyFromAspxGridView("AgentFullName", i) != null ? GridView.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                        var vDaysPending = GridView.GetKeyFromAspxGridView("DaysPending", i) != null ? int.Parse(GridView.GetKeyFromAspxGridView("DaysPending", i).ToString()) : (int?)null;
                        var vSubmitDate = GridView.GetKeyFromAspxGridView("SubmitDate", i) != null ? DateTime.Parse(GridView.GetKeyFromAspxGridView("SubmitDate", i).ToString()) : (DateTime?)null;

                        LstRecordChecksDataReview.Add(new DataReview()
                        {
                            PolicyNo = vPolicyNo,
                            ProductDesc = vProductDesc,
                            UserName = vUserName,
                            InsuredFullName = vInsuredFullName,
                            OwnerFullName = vOwnerFullName,
                            OfficeDesc = vOfficeDesc,
                            AgentFullName = vAgentFullName,
                            SubmitDate =   vSubmitDate.Value,
                            DaysPending = vDaysPending
                        });
                    }
                }

                Exporter.GridView.DataSource = LstRecordChecksDataReview.Select(x => new
                {
                    x.PolicyNo,
                    x.ProductDesc,
                    x.UserName,
                    x.InsuredFullName,
                    x.OwnerFullName,
                    x.OfficeDesc,
                    x.AgentFullName,
                    SubmitDate = x.SubmitDate.HasValue ? x.SubmitDate.Value.ToString() : string.Empty,
                    x.DaysPending
                });
            }
            else if (GridView.ID == "gvEffectivePendingReceipt")
            {
                for (int i = GridView.VisibleStartIndex; i < GridView.VisibleRowCount; i++)
                {
                    var chk = GridView.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

                    if (chk != null && chk.Checked)
                    {
                        var vPolicyNo = GridView.GetKeyFromAspxGridView("PolicyNo", i).ToString();
                        var vProductDesc = GridView.GetKeyFromAspxGridView("ProductDesc", i) != null ? GridView.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
                        var vUserName = GridView.GetKeyFromAspxGridView("UserName", i) != null ? GridView.GetKeyFromAspxGridView("UserName", i).ToString() : "";
                        var vInsuredFullName = GridView.GetKeyFromAspxGridView("InsuranceFullName", i) != null ? GridView.GetKeyFromAspxGridView("InsuranceFullName", i).ToString() : "";
                        var vOwnerFullName = GridView.GetKeyFromAspxGridView("OwnerFullName", i) != null ? GridView.GetKeyFromAspxGridView("OwnerFullName", i).ToString() : "";
                        var vAgentFullName = GridView.GetKeyFromAspxGridView("AgentFullName", i) != null ? GridView.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
                        var vEffectiveDate = GridView.GetKeyFromAspxGridView("EffectiveDate", i) != null ? GridView.GetKeyFromAspxGridView("EffectiveDate", i).ToString().ParseFormat() : (DateTime?)null;
                        var vDaysLate = GridView.GetKeyFromAspxGridView("DaysLate", i) != null ? int.Parse(GridView.GetKeyFromAspxGridView("DaysLate", i).ToString()) : (int?)null;
                        var vStatus = GridView.GetKeyFromAspxGridView("Status", i) != null ? GridView.GetKeyFromAspxGridView("Status", i).ToString() : string.Empty;

                        LstRecordChecksCases.Add(new Case.Process()
                        {
                            PolicyNo = vPolicyNo,
                            ProductDesc = vProductDesc,
                            InsuranceFullName = vInsuredFullName,
                            OwnerFullName = vOwnerFullName,
                            AgentFullName = vAgentFullName,
                            EffectiveDate = vEffectiveDate.HasValue ? vEffectiveDate.Value : (DateTime?)null,
                            DaysLate = vDaysLate,
                            Status = vStatus
                        });
                    }
                }

                Exporter.GridView.DataSource = LstRecordChecksCases.Select(x => new
               {
                   x.PolicyNo,
                   x.ProductDesc,
                   x.InsuranceFullName,
                   x.OwnerFullName,
                   x.AgentFullName,
                   EffectiveDate = x.EffectiveDate.HasValue?x.EffectiveDate.Value.ToString():string.Empty,
                   x.DaysLate,
                   x.Status
               });
            }

            Exporter.GridView.DataBind();
            Exporter.WriteXlsxToResponse(NameReport);

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            var ohdnCurrentTabSubmittedPolicies = this.Page.Master.FindControl("bodyContent").FindControl("hdnCurrentTabSubmittedPolicies");
            var oWUCSubmittedPolicies = this.Page.Master.FindControl("bodyContent").FindControl("WUCSubmittedPolicies");
            var oWUCEffectivePendingReceipt = this.Page.Master.FindControl("bodyContent").FindControl("WUCEffectivePendingReceipt");

            DevExpress.Web.ASPxGridView GridView = null;
            DevExpress.Web.ASPxGridViewExporter Exporter = null;

            String NameReport = String.Empty;

            if (ohdnCurrentTabSubmittedPolicies != null)
            {
                var oTab = (ohdnCurrentTabSubmittedPolicies as HiddenField).Value;

                switch (oTab)
                {
                    case "lnkSubmittedPolicies":
                        GridView = oWUCSubmittedPolicies.FindControl("gvSubmittedPolcies") as DevExpress.Web.ASPxGridView;
                        Exporter = oWUCSubmittedPolicies.FindControl("Exporter") as DevExpress.Web.ASPxGridViewExporter;
                        NameReport = "SubmittedPolicies";
                        break;
                    case "lnkEffectivePendingReceipt":
                        GridView = oWUCEffectivePendingReceipt.FindControl("gvEffectivePendingReceipt") as DevExpress.Web.ASPxGridView;
                        Exporter = oWUCEffectivePendingReceipt.FindControl("Exporter") as DevExpress.Web.ASPxGridViewExporter;
                        NameReport = "EffectivePendingReceipt";
                        break;
                }

                ExportGrid(GridView, Exporter, NameReport);
            }

        }
    }
}