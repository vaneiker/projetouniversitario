using Entity.UnderWriting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Case.UserControls.UnderwritingSteps;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.Requirements
{
	public partial class UCAddNewRequirement : UC, IUC
	{
		//IRequirement RequirementManager
		//{
		//    get { return diManager.RequirementManager; }
		//}
		//UnderWritingDIManager diManager = new UnderWritingDIManager();
		SessionList datos = new SessionList();
		DropDownManager DropDowns = new DropDownManager();

		class SentToRequirement
		{
			public string Name { get; set; }
			public string Office { get; set; }
		}

		private List<RequirementListItem> RequirementsTempList
		{
			get { return (List<RequirementListItem>)Session["RequirementsTempList"]; }
			set { Session["RequirementsTempList"] = value; }
		}

		private List<ReqAgentchain> ReqAgentChainTempList
		{
			get { return (List<ReqAgentchain>)Session["ReqAgentChainTempList"]; }
			set { Session["ReqAgentChainTempList"] = value; }
		}

		private class RequirementListItem
		{
			public String RequirementCatDesc { get; set; }
			public String RequirementTypeDesc { get; set; }
			public String ContactRoleDesc { get; set; }

			public int RequirementCatID { get; set; }
			public int RequirementTypeID { get; set; }
			public int ContactRoleID { get; set; }
		}

		private class ReqAgentchain
		{
			public String AgentId { get; set; }
			public String AgentName { get; set; }
			public String OfficeDesc { get; set; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				RequirementsTempList = new List<RequirementListItem>();
			}
		}

		void IUC.Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void save()
		{
			throw new NotImplementedException();
		}

		void IUC.readOnly(bool x)
		{
			throw new NotImplementedException();
		}

		void IUC.edit()
		{
			throw new NotImplementedException();
		}

		public void FillData()
		{
			FillDrops();
			FillReqTypeChecks();
			FillTempRequirements();
			FillAgentChain();

			txtReqComment.Text = @"Estimado Agente: " + Environment.NewLine +
								 @"Para continuar con el proceso de suscripción de la póliza/plan en referencia requerimos:" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
								 @"En caso de tener alguna duda por favor escribanos a nuestra dirección: suscripcion-vida@atlantica.do";
								 //@"En caso de tener alguna duda por favor escribanos a nuestra dirección: requisitos@statetrusttime.com";
		}

		private void FillAgentChain()
		{
			ReqAgentChainTempList = ReqAgentChainTempList ?? new List<ReqAgentchain>();

			var data = DropDowns.GetDropDown(DropDownType.RequirementCommAgent, 
											 Service.Corp_Id, 
											 Service.Region_Id, 
											 Service.Country_Id, 
											 Service.Domesticreg_Id,
											 Service.State_Prov_Id, 
											 Service.City_Id, 
											 Service.Office_Id, 
											 Service.Case_Seq_No, 
											 Service.Hist_Seq_No, 
											 projectId: Service.ProjectId, 
											 companyId: Service.CompanyId);
			if (data != null)
			{
				ReqAgentChainTempList = (from d in data
										 select new ReqAgentchain
										 {
											 AgentId = d.Value,
											 AgentName = d.Text.Split('|')[0],
											 OfficeDesc = d.Text.Split('|').Length > 1 ? d.Text.Split('|')[1] : "Test Office"
										 }).ToList();

				gvSentToRequirement.DataSource = ReqAgentChainTempList;
				gvSentToRequirement.DataBind();
			}
		}

		private void FillDrops()
		{
			DropDowns.GetDropDown(ref RequirementRoleDDL, 
								  "-- Select --", 
								  Language.English, 
								  DropDownType.RequirementRole, 
								  Service.Corp_Id, 
								  Service.Region_Id, 
								  Service.Country_Id, 
								  Service.Domesticreg_Id,
								  Service.State_Prov_Id, 
								  Service.City_Id, 
								  Service.Office_Id, 
								  Service.Case_Seq_No, 
								  Service.Hist_Seq_No, 
								  projectId: Service.ProjectId, 
								  companyId: Service.CompanyId);

            var ddlReqCategory = Service.GettingDropData(DropDownType.RequirementCategory, corpId: Service.Corp_Id, pProjectId: Service.ProjectId);
            

            ddlRequirementCategory.DataSource = ddlReqCategory.Where(r=>r.RequirementCatId <= 5);
            ddlRequirementCategory.DataTextField = "RequirementCatDesc";
            ddlRequirementCategory.DataValueField = "RequirementCatId";
            ddlRequirementCategory.DataBind();
		}

		private void FillReqTypeChecks()
		{
			var requirementTypeList = DropDowns.GetDropDown(DropDownType.RequirementType,
															Service.Corp_Id,
															Service.Region_Id,
															Service.Country_Id,
															Service.Domesticreg_Id,
															Service.State_Prov_Id,
															Service.City_Id,
															Service.Office_Id,
															Service.Case_Seq_No,
															Service.Hist_Seq_No,
															Convert.ToInt32(RequirementRoleDDL.SelectedValue),
															null,
															null,
															null,
															Convert.ToInt32(ddlRequirementCategory.SelectedValue),
															projectId: Service.ProjectId,
															companyId: Service.CompanyId);

			var requirementTypeListOrdered = requirementTypeList != null ? requirementTypeList.OrderBy(r => r.Text).ToList<ListItem>() : new List<ListItem>();

			chkReqTypeList.DataSource = requirementTypeListOrdered;
			chkReqTypeList.DataBind();

			var removeListItems = (from item in RequirementsTempList
								   where item.ContactRoleID.Equals(int.Parse(RequirementRoleDDL.SelectedValue))
								   select new ListItem
								   {
									   Text = item.RequirementTypeDesc,
									   Value = string.Format("1|{0}|{1}", item.RequirementCatID, item.RequirementTypeID)
								   }).ToList();

			foreach (var item in removeListItems)
			{
				chkReqTypeList.Items.Remove(item);
			}
		}

		public void clearData()
		{
			throw new NotImplementedException();
		}

		protected void ddlRequirementCategory_SelectedIndexChanged1(object sender, EventArgs e)
		{
			FillReqTypeChecks();
		}

		protected void btnAddRequirement_Click(object sender, EventArgs e)
		{
			var tempList = new List<RequirementListItem>();

			if (RequirementsTempList != null)
			{
				tempList = RequirementsTempList;
			}

			foreach (ListItem item in chkReqTypeList.Items)
			{
				if (!item.Selected) continue;
				var contactRoleID = int.Parse(RequirementRoleDDL.SelectedValue);
				var requirementCatID = int.Parse(item.Value.Split('|')[1]);
				var requirementTypeID = int.Parse(item.Value.Split('|')[2]);
				var exist = tempList.Any(listItem => listItem.ContactRoleID.Equals(contactRoleID) && 
													 listItem.RequirementCatID.Equals(requirementCatID) &&
													 listItem.RequirementTypeID.Equals(requirementTypeID));

				if (!exist)
					tempList.Add(new RequirementListItem
					{
						RequirementCatDesc = ddlRequirementCategory.SelectedItem.Text,
						RequirementTypeDesc = item.Text,
						RequirementCatID = requirementCatID,
						RequirementTypeID = requirementTypeID,
						ContactRoleDesc = RequirementRoleDDL.SelectedItem.Text,
						ContactRoleID = contactRoleID
					});
			}

			RequirementsTempList = tempList;
			FillReqTypeChecks();
			FillTempRequirements();
			hfNewRequirementTable.Value = "";
		}

		public void ClearTempRequirements()
		{
			RequirementsTempList.Clear();
			gvRequirementSelectionTable.DataSource = RequirementsTempList;
			gvRequirementSelectionTable.DataBind();
		}

		private void FillTempRequirements()
		{
			gvRequirementSelectionTable.DataSource = RequirementsTempList;
			gvRequirementSelectionTable.DataBind();
		}

		private void FillTempAgentsChain()
		{
			gvSentToRequirement.DataSource = ReqAgentChainTempList;
			gvSentToRequirement.DataBind();
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			var isManual = (((Button)sender).ID == "btnManual" ? true : false);

			//1 General
			//3 Financial
			//4 Activicy
			//2 Medical

			if (RequirementsTempList.Any())
			{
				String requirementComment = "";
				int medicalStepId = 0;
				int clientStepId = 0;

				int? stepId = null;
				int? stepTypeId = null;
				int? stepCaseNo = null;

				var medicalList = RequirementsTempList.Where(r => r.RequirementCatID == 2).ToArray();

				if (medicalList.Length > 0)
				{
					requirementComment = medicalList.Aggregate("", (current, itemStep) => current + (itemStep.RequirementTypeDesc + "<br/>"));

					if (!String.IsNullOrWhiteSpace(txtReqComment.Text))
					{
						requirementComment += "<br/>" + txtReqComment.Text + "<br/>";
					}

					//Creacion de Step: Sent to Reinsurance
					//medicalStepId = CreateStep(61, 1, requirementComment.Trim());
				}

				var clientList = RequirementsTempList.Where(r => r.RequirementCatID == 1 || r.RequirementCatID == 3 || r.RequirementCatID == 4).ToArray();

				if (clientList.Length > 0)
				{
					requirementComment = clientList.Aggregate("", (current, itemStep) => current + (itemStep.RequirementTypeDesc + "<br/>"));

					if (!String.IsNullOrWhiteSpace(txtReqComment.Text))
					{
						requirementComment += "<br/>" + txtReqComment.Text + "<br/>";
					}

					//2016-03-15 | Marcos J. Perez
					//Comentado por requerimiento de Ingrid De Leon 
					//Creacion de Step: Received Ilustration
					//clientStepId = CreateStep(88, 1, requirementComment.Trim());
				}

				var requirementList = new List<Requirement>(1);
				foreach (var item in RequirementsTempList)
				{

					var agentChainList = ReqAgentChainTempList.Select(agentItem => new Requirement
					{
						//Key
						CorpId = Service.Corp_Id,
						RegionId = Service.Region_Id,
						CountryId = Service.Country_Id,
						DomesticregId = Service.Domesticreg_Id,
						StateProvId = Service.State_Prov_Id,
						CityId = Service.City_Id,
						OfficeId = Service.Office_Id,
						CaseSeqNo = Service.Case_Seq_No,
						HistSeqNo = Service.Hist_Seq_No,

						//RequirementInfo
						RequirementCatId = item.RequirementCatID,
						RequirementTypeId = item.RequirementTypeID,
						ContactId = item.ContactRoleID,

						//AgentInfo
						AgentId = int.Parse(agentItem.AgentId),

						//UserInfo
						UserId = Service.Underwriter_Id
					}).ToList();


					//2016-03-15 | Marcos J. Perez
					//Comentado por requerimiento de Ingrid De Leon 

					//switch (item.RequirementCatID)
					//{
					//	case 1:
					//	case 3:
					//	case 4:
					//		stepId = 88;
					//		stepTypeId = 1;
					//		stepCaseNo = clientStepId;
					//		break;
					//	case 2:
					//		stepId = 61;
					//		stepTypeId = 1;
					//		stepCaseNo = medicalStepId;
					//		break;
					//}

					requirementList.Add(new Requirement
					{
						//Key
						CorpId = Service.Corp_Id,
						RegionId = Service.Region_Id,
						CountryId = Service.Country_Id,
						DomesticregId = Service.Domesticreg_Id,
						StateProvId = Service.State_Prov_Id,
						CityId = Service.City_Id,
						OfficeId = Service.Office_Id,
						CaseSeqNo = Service.Case_Seq_No,
						HistSeqNo = Service.Hist_Seq_No,

						//RequirementInfo
						StepId = stepId,
						StepTypeId = stepTypeId,
						StepCaseNo = stepCaseNo,
						ContactId = item.ContactRoleID,
						RequirementCatId = item.RequirementCatID,
						RequirementTypeId = item.RequirementTypeID,
						RequestedBy = Service.Underwriter_Id,
						RequestedDate = DateTime.Now,
						IsManual = isManual,
						Comment = String.IsNullOrWhiteSpace(txtReqComment.Text) ? null : txtReqComment.Text.Trim(),
						UserId = Service.Underwriter_Id,

						//Agent List
						AgentList = agentChainList
					});
				}

				Services.RequirementManager.SetList(requirementList);

				((UCRequimentInformation)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation")).FillData();
				((UCUnderwritingStep)Page.Master.FindControl("Right").FindControl("Right").FindControl("UCUnderwritingStep")).FillData(false);
			}
			else
			{
				string message = "Please add at least one Requirement and try again.";
				ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CustomDialogMessageEx('" + message + "', 500, 150, true, 'Required Field');", true);
				return;
			}

			Session["Selection"] = null;
			((HiddenField)Page.Master.FindControl("Left").FindControl("Left").FindControl("UCRequimentInformation").FindControl("hfRequirementInsertForm")).Value = "false";
		}

		private int CreateStep(int stepId, int stepTypeId, String comment)
		{

			var step = new Step.NewStep
			{
				StepId = stepId,
				StepTypeId = stepTypeId,
				Note = comment,
				UserId = Service.Underwriter_Id,
				CorpId = Service.Corp_Id,
				RegionId = Service.Region_Id,
				CountryId = Service.Country_Id,
				DomesticregId = Service.Domesticreg_Id,
				StateProvId = Service.State_Prov_Id,
				CityId = Service.City_Id,
				OfficeId = Service.Office_Id,
				CaseSeqNo = Service.Case_Seq_No,
				HistSeqNo = Service.Hist_Seq_No
			};

			return Services.StepManager.Insert(step);

		}

		protected void lnkDeleteRequirement_Click(object sender, EventArgs e)
		{
			var RowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;

			int RequirementTypeID = int.Parse(gvRequirementSelectionTable.DataKeys[RowIndex]["RequirementTypeID"].ToString()),
				ContactRoleID = int.Parse(gvRequirementSelectionTable.DataKeys[RowIndex]["ContactRoleID"].ToString());

			var tempReqList = RequirementsTempList;
			var tempReqItem = RequirementsTempList.First(r => r.ContactRoleID.Equals(ContactRoleID) && 
															  r.RequirementTypeID.Equals(RequirementTypeID) &&
															  r.ContactRoleID.Equals(ContactRoleID));

			tempReqList.Remove(tempReqItem);
			RequirementsTempList = tempReqList;

			FillReqTypeChecks();
			FillTempRequirements();
		}

		protected void RequirementRoleDDL_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillReqTypeChecks();
			FillTempRequirements();
		}

		protected void lnkDeleteSenTo_Click(object sender, EventArgs e)
		{
			int RowIndex = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
			string AgentId = gvSentToRequirement.DataKeys[RowIndex]["AgentId"].ToString();

			var tempReqAgentList = ReqAgentChainTempList;
			var removeReqAgentChainItem = ReqAgentChainTempList.First(r => r.AgentId.Equals(AgentId));

			tempReqAgentList.Remove(removeReqAgentChainItem);
			ReqAgentChainTempList = tempReqAgentList;

			FillTempAgentsChain();
		}
	}
}