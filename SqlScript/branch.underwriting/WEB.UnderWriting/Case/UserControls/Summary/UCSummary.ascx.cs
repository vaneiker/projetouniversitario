using Entity.UnderWriting.Entities;
using PdfViewer4AspNet;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Summary
{
	public partial class UCSummary : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
	{
		//IPolicy PolicyManager
		//{
		//    get { return diManager.PolicyManager; }
		//}
		//IRequirement RequirementManager
		//{
		//    get { return diManager.RequirementManager; }
		//}
		//UnderWritingDIManager diManager = new UnderWritingDIManager();
		
		DropDownManager DropDowns = new DropDownManager();

		protected void Page_Load(object sender, EventArgs e)
		{


		}
		
		void UnderWriting.Common.IUC.Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void save()
		{
			throw new NotImplementedException();
		}

		void UnderWriting.Common.IUC.readOnly(bool x)
		{
			throw new NotImplementedException();
		}

		void UnderWriting.Common.IUC.edit()
		{
			throw new NotImplementedException();
		}

		void UnderWriting.Common.IUC.FillData()
		{
			throw new NotImplementedException();
		}

		public void fillData()
		{
			ltrPolicyNumber.Text =
			ltrRequirementPolicy.Text =
			ltrPaymentPolicy.Text = Service.Policy_Id;

			gvAllRequirements.PageIndex = 0;
			gvPolicyData.PageIndex = 0;
			gvAllPayments.PageIndex = 0;

			fillPersonalData();
			fillPolicyData(Service.Contact_Id);
			fillRequirement();
			fillPayment();

			setPagerIndex(gvPolicyData);
			setPagerIndex(gvPersonalData);
			setPagerIndex(gvAllRequirements);
			setPagerIndex(gvAllPayments);

			if (ddlPolicyData.Items.Count > 0)
			{
				ddlPolicyData.SelectedIndex = 0;
				ddlPolicyData_SelectedIndexChanged(ddlPolicyData, null);
			}
		}

		public void clearData()
		{
			throw new NotImplementedException();
		}

		protected void lnkPdfFile_Click(object sender, EventArgs e)
		{
			int RowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

			Requirement.Document Document = Services.RequirementManager.GetDocument(Service.Corp_Id,
																					Service.Region_Id, 
																					Service.Country_Id, 
																					Service.Domesticreg_Id,
																					Service.State_Prov_Id, 
																					Service.City_Id, 
																					Service.Office_Id,
																					Service.Case_Seq_No, 
																					Service.Hist_Seq_No,
																					Convert.ToInt32(gvAllRequirements.DataKeys[RowIndex]["ContactId"]),
																					Convert.ToInt32(gvAllRequirements.DataKeys[RowIndex]["RequirementCatId"]),
																					Convert.ToInt32(gvAllRequirements.DataKeys[RowIndex]["RequirementTypeId"]),
																					Convert.ToInt32(gvAllRequirements.DataKeys[RowIndex]["RequirementId"]),
																					Convert.ToInt32(gvAllRequirements.DataKeys[RowIndex]["RequirementDocId"]));

			PdfViewer pdfViewerControl = (PdfViewer)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCPdfViewer").FindControl("Viewer");
			pdfViewerControl.PdfSourceBytes = Document.DocumentBinary;
			pdfViewerControl.DataBind();
			((HiddenField)Page.Master.FindControl("Right").FindControl("Right").FindControl("hfMenuCasesRight")).Value = "pdfViewer";
		}

		public void fillDdl()
		{
			int Corp_Id = Service.Corp_Id;
			int Region_Id = Service.Region_Id;
			int Country_Id = Service.Country_Id;
			int Domesticreg_Id = Service.Domesticreg_Id;
			int State_Prov_Id = Service.State_Prov_Id;
			int City_Id = Service.City_Id;
			int Office_Id = Service.Office_Id;
			int Case_Seq_No = Service.Case_Seq_No;
			int Hist_Seq_No = Service.Hist_Seq_No;
			int contactId = Service.Contact_Id;

			var allRequirements = Services.PolicyManager.GetRequirementSummary(Corp_Id,
																			   Region_Id,
																			   Country_Id,
																			   Domesticreg_Id,
																			   State_Prov_Id,
																			   City_Id,
																			   Office_Id,
																			   Case_Seq_No,
																			   Hist_Seq_No,
																			   null, 
																			   null, 
																			   null);

			#region RequirementType
			ddlRequirementType.DataSource = DropDowns.GetDropDown(DropDownType.RequirementCategory, 
																  Corp_Id, 
																  null, 
																  null, 
																  null, 
																  null, 
																  null, 
																  null, 
																  null, 
																  null, 
																  null, 
																  null, 
																  projectId: Service.ProjectId, 
																  companyId: Service.CompanyId).Where(x => allRequirements.Any(x2 => x2.RequirementCatId == int.Parse(x.Value)));
			ddlRequirementType.DataBind();
			ddlRequirementType.Items.Insert(0, new ListItem("All Requirements", "-1"));
			if (ddlRequirementType.Items.Count > 0)
			{
				ddlRequirementType.SelectedIndex = 0;
			}
			#endregion

			#region PolicyData
			ddlPolicyData.DataSource = DropDowns.GetDropDown(DropDownType.RequirementRole, 
															 Corp_Id, 
															 Region_Id, 
															 Country_Id, 
															 Domesticreg_Id, 
															 State_Prov_Id, 
															 City_Id, 
															 Office_Id, 
															 Case_Seq_No, 
															 Hist_Seq_No, 
															 null, 
															 null, 
															 projectId: Service.ProjectId, 
															 companyId: Service.CompanyId);
			ddlPolicyData.DataBind();
			if (ddlPolicyData.Items.Count > 0)
			{
				ddlPolicyData.SelectedIndex = 0;
			}
			#endregion

			#region AllPayments
			ddlAllPayments.DataSource = DropDowns.GetDropDown(DropDownType.OwnerPolicy, 
															  Corp_Id, 
															  null, 
															  null, 
															  null, 
															  null, 
															  null, 
															  null, 
															  null, 
															  null, 
															  contactId, 
															  null, 
															  projectId: Service.ProjectId, 
															  companyId: Service.CompanyId);
			ddlAllPayments.DataBind();
			ddlAllPayments.Items.Insert(0, new ListItem("All Payments", "-1"));
			if (ddlAllPayments.Items.Count > 0)
			{
				ddlAllPayments.SelectedIndex = 0;
			}
			#endregion

			ltrEntityName.Text = ddlPolicyData.SelectedItem.Text;
		}

		protected void ddlRequirementType_SelectedIndexChanged(object sender, EventArgs e)
		{
			gvAllRequirements.PageIndex = 0;

			int? reqCategoryId = null;

			if (ddlRequirementType.SelectedValue != "-1")
			{
				reqCategoryId = int.Parse(ddlRequirementType.SelectedValue);
			}

			fillRequirement(reqCategoryId);
			setPagerIndex(gvAllRequirements);
		}

		protected void ddlPolicyData_SelectedIndexChanged(object sender, EventArgs e)
		{
			gvPolicyData.PageIndex = 0;

			int contactId = int.Parse(ddlPolicyData.SelectedValue);
			ltrEntityName.Text = ddlPolicyData.SelectedItem.Text;

			fillPolicyData(contactId);
			setPagerIndex(gvPolicyData);
		}

		protected void ddlAllPayments_SelectedIndexChanged(object sender, EventArgs e)
		{
			gvAllPayments.PageIndex = 0;

			var payment = ddlAllPayments.SelectedValue.Split('|');


			int? Corp_Id = null;
			int? Region_Id = null;
			int? Country_Id = null;
			int? Domesticreg_Id = null;
			int? State_Prov_Id = null;
			int? City_Id = null;
			int? Office_Id = null;
			int? Case_Seq_No = null;
			int? Hist_Seq_No = null;
			int contactId = Service.Contact_Id;

			ltrPaymentPolicy.Text = "";

			if (ddlAllPayments.SelectedValue != "-1")
			{
				ltrPaymentPolicy.Text = ddlAllPayments.SelectedItem.Text;
				Corp_Id = int.Parse(payment[0]);
				Region_Id = int.Parse(payment[1]);
				Country_Id = int.Parse(payment[2]);
				Domesticreg_Id = int.Parse(payment[3]);
				State_Prov_Id = int.Parse(payment[4]);
				City_Id = int.Parse(payment[5]);
				Office_Id = int.Parse(payment[6]);
				Case_Seq_No = int.Parse(payment[7]);
				Hist_Seq_No = int.Parse(payment[8]);

			}


			fillPayment(Corp_Id,
						Region_Id,
						Country_Id,
						Domesticreg_Id,
						State_Prov_Id,
						City_Id,
						Office_Id,
						Case_Seq_No,
						Hist_Seq_No);

			setPagerIndex(gvAllPayments);
		}

		private void fillRequirement(int? reqCategoryId = null)
		{
			int Corp_Id = Service.Corp_Id;
			int Region_Id = Service.Region_Id;
			int Country_Id = Service.Country_Id;
			int Domesticreg_Id = Service.Domesticreg_Id;
			int State_Prov_Id = Service.State_Prov_Id;
			int City_Id = Service.City_Id;
			int Office_Id = Service.Office_Id;
			int Case_Seq_No = Service.Case_Seq_No;
			int Hist_Seq_No = Service.Hist_Seq_No;

			if (reqCategoryId == null && ddlRequirementType.SelectedValue != "-1" && ddlRequirementType.SelectedValue != "")
			{
				reqCategoryId = int.Parse(ddlRequirementType.SelectedValue);
			}

			var allRequirements = Services.PolicyManager.GetRequirementSummary(Corp_Id,
																			   Region_Id,
																			   Country_Id,
																			   Domesticreg_Id,
																			   State_Prov_Id,
																			   City_Id,
																			   Office_Id,
																			   Case_Seq_No,
																			   Hist_Seq_No,
																			   null,
																			   reqCategoryId,
																			   null);
			gvAllRequirements.DataSource = allRequirements;
			gvAllRequirements.DataBind();

			if (gvAllRequirements.BottomPagerRow != null)
			{
				var totalItems = (Literal)gvAllRequirements.BottomPagerRow.FindControl("totalItems");
				totalItems.Text = allRequirements.ToList().Count + "";
			}
		}

		private void fillPersonalData()
		{
			var personalData = Services.PolicyManager.GetSummaryByPolicy(Service.Corp_Id,
																		 Service.Region_Id,
																		 Service.Country_Id,
																		 Service.Domesticreg_Id,
																		 Service.State_Prov_Id,
																		 Service.City_Id,
																		 Service.Office_Id,
																		 Service.Case_Seq_No,
																		 Service.Hist_Seq_No);
			gvPersonalData.DataSource = personalData;
			gvPersonalData.DataBind();

			ltrIsPreApproved.Text = personalData.FirstOrDefault().IsPreApproved ? "<i class=\"bombillo bomb fr\"></i>" : "<i class=\"bombillo bomb_rj fr\"></i>";

			if (gvPersonalData.BottomPagerRow == null) { return; }
			var totalItems = (Literal)gvPersonalData.BottomPagerRow.FindControl("totalItems");
			totalItems.Text = personalData.ToList().Count + "";
		}

		private void fillPayment(int? Corp_Id = null, int? Region_Id = null, int? Country_Id = null, int? Domesticreg_Id = null, int? State_Prov_Id = null, int? City_Id = null, int? Office_Id = null, int? Case_Seq_No = null, int? Hist_Seq_No = null)
		{
			int contactId = Service.Contact_Id;
			if (Corp_Id == null && ddlAllPayments.SelectedValue != "-1" && ddlAllPayments.SelectedValue != "")
			{
				var payment = ddlAllPayments.SelectedValue.Split('|');
				Corp_Id = int.Parse(payment[0]);
				Region_Id = int.Parse(payment[1]);
				Country_Id = int.Parse(payment[2]);
				Domesticreg_Id = int.Parse(payment[3]);
				State_Prov_Id = int.Parse(payment[4]);
				City_Id = int.Parse(payment[5]);
				Office_Id = int.Parse(payment[6]);
				Case_Seq_No = int.Parse(payment[7]);
				Hist_Seq_No = int.Parse(payment[8]);

			}

			var allPayments = Services.PolicyManager.GetPaymentSummary(Corp_Id,
																	   Region_Id,
																	   Country_Id,
																	   Domesticreg_Id,
																	   State_Prov_Id,
																	   City_Id,
																	   Office_Id,
																	   Case_Seq_No,
																	   Hist_Seq_No,
																	   contactId);

			gvAllPayments.DataSource = allPayments;
			gvAllPayments.DataBind();
			if (gvAllPayments.BottomPagerRow != null)
			{
				var totalItems = (Literal)gvAllPayments.BottomPagerRow.FindControl("totalItems");
				totalItems.Text = allPayments.ToList().Count + "";
			}
		}

		private void fillPolicyData(int contactId)
		{
			var policyInfo = Services.PolicyManager.GetSummaryByContact(contactId);

			gvPolicyData.DataSource = policyInfo;
			gvPolicyData.DataBind();

			if (gvPolicyData.BottomPagerRow != null)
			{
				var totalItems = (Literal)gvPolicyData.BottomPagerRow.FindControl("totalItems");
				totalItems.Text = policyInfo.ToList().Count + "";
			}

			((DataControlField)gvPolicyData.Columns
										   .Cast<DataControlField>()
										   .Where(fld => (fld.HeaderText == "Benefit Amount"))
										   .SingleOrDefault()).Visible = !(Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance);
		}

		void setPagerIndex(GridView gv)
		{
			if (gv.BottomPagerRow != null)
			{
				var lnkPrev = (LinkButton)gv.BottomPagerRow.FindControl("prevButton");
				var lnkFirst = (LinkButton)gv.BottomPagerRow.FindControl("firstButton");
				var lnkNext = (LinkButton)gv.BottomPagerRow.FindControl("nextButton");
				var lnkLast = (LinkButton)gv.BottomPagerRow.FindControl("lastButton");
				var indexText = (Literal)gv.BottomPagerRow.FindControl("indexPage");
				var totalText = (Literal)gv.BottomPagerRow.FindControl("totalPage");


				var count = gv.PageCount;
				var index = gv.PageIndex + 1;

				indexText.Text = index.ToString();
				totalText.Text = count.ToString();

				if (index == 1)
				{
					DisableLinkButton(lnkPrev, "prev_dis");
					DisableLinkButton(lnkFirst, "rewd_dis");
				}
				else if (index == count)
				{
					DisableLinkButton(lnkNext, "next_dis");
					DisableLinkButton(lnkLast, "fwrd_dis");
				}
			}
		}

		public void DisableLinkButton(LinkButton linkButton, string disable_class)
		{
			linkButton.CssClass = disable_class;
			linkButton.Enabled = false;
		}

		protected void gvAllRequirements_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvAllRequirements.PageIndex = e.NewPageIndex;
			gvAllRequirements.DataBind();
			fillRequirement();
			setPagerIndex(gvAllRequirements);
		}

		protected void gvPersonalData_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvPersonalData.PageIndex = e.NewPageIndex;
			gvPersonalData.DataBind();
			fillPersonalData();
			setPagerIndex(gvPersonalData);
		}

		protected void gvAllPayments_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvAllPayments.PageIndex = e.NewPageIndex;
			gvAllPayments.DataBind();
			fillPayment();
			setPagerIndex(gvAllPayments);
		}

		protected void gvPolicyData_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvPolicyData.PageIndex = e.NewPageIndex;
			gvPolicyData.DataBind();
			fillPolicyData(int.Parse(ddlPolicyData.SelectedValue));
			setPagerIndex(gvPolicyData);
		}
	}
}