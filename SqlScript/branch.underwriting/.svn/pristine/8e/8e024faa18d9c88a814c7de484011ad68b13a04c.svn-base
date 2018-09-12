using System;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Case.UserControls.Common;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.Pages
{
	public partial class Case : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					var hfTabSelected = Page.Master.FindControl("WUCMainMenu").FindControl("hfCurrentTabSelected");
					if (hfTabSelected != null)
						((HiddenField)hfTabSelected).Value = "LnkLifeAndAnnuittiesInsurance";
					
					this.ExcecuteJScript("$('#STFCUserProfile1_perfil_agent').attr('id', 'current');");
				}
				HeaderCase.SelectGridRow_HEADER += SelectGridRows;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void SelectGridRows()
		{
			if (((UCCasesGrid)HeaderCase.FindControl("UCCasesGrid1")).IsVisible()) return;
			Right.SelectUnderWritingSteps();
			Left.SelectPersonalData();
		}

		[WebMethod]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public static IEnumerable<ListItem> ChargeSubManager(string PolicyKey)
		{
			string[] PolicyKeySplit = PolicyKey.Split('|');
			int corpId = int.Parse(PolicyKeySplit[0]);
			int managerId = 0;
			if (PolicyKeySplit.Length > 1)
				managerId = int.Parse(PolicyKeySplit[1]);

			WEB.UnderWriting.Common.DropDownManager drop = new DropDownManager();
			var ddlSubManagerData = drop.GetDropDown(Type: DropDownType.SubManager, corpId: corpId, agentId: (managerId == 0) ? (int?)null : managerId);

			return ddlSubManagerData;
		}

		[WebMethod]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public static IEnumerable<ListItem> ChargeManager(string PolicyKey)
		{
			int corpId = 1;
			int? regionId = null;
			int? countryId = null;
			int? domesticregId = null;
			int? stateProvId = null;
			int? cityId = null;
			int? officeId = null;

			if (PolicyKey != null)
			{
				string[] PolicyKeySplit = PolicyKey.Split('|');
				corpId = int.Parse(PolicyKeySplit[0]);
				regionId = int.Parse(PolicyKeySplit[1]);
				countryId = int.Parse(PolicyKeySplit[2]);
				domesticregId = int.Parse(PolicyKeySplit[3]);
				stateProvId = int.Parse(PolicyKeySplit[4]);
				cityId = int.Parse(PolicyKeySplit[5]);
				officeId = int.Parse(PolicyKeySplit[6]);
			}
			WEB.UnderWriting.Common.DropDownManager drop = new DropDownManager();
			var ddlManagerData = drop.GetDropDown(Type: DropDownType.ManagerByOffice, corpId: corpId, regionId: regionId, countryId: countryId, domesticregId: domesticregId, stateProvId: stateProvId, cityId: cityId, officeId: officeId);

			return ddlManagerData;
		}


		[WebMethod]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public static IEnumerable<ListItem> ChargeAgent(string PolicyKey)
		{
			string[] PolicyKeySplit = PolicyKey.Split('|');
			int corpId = int.Parse(PolicyKeySplit[0]); ;
			int SubManagerId = 0;

			if (PolicyKeySplit.Length > 1)
				SubManagerId = int.Parse(PolicyKeySplit[1]);

			WEB.UnderWriting.Common.DropDownManager drop = new DropDownManager();
			var ddlAgentData = drop.GetDropDown(Type: DropDownType.AgentBySubManager, corpId: corpId, agentId: SubManagerId);

			return ddlAgentData;
		}

		[WebMethod]
		public static bool SaveUnderCallComment(String PolicyKey, String Comment, int CategoryId, int StepTypeId, int StepId, int StepCaseNo)
		{
			try
			{
				var uwService = Tools.deserializeJSON<Tools.PolicyKeyItem>(PolicyKey);

				var commentItem = new Entity.UnderWriting.Entities.Case.Comment()
				{
					CorpId = uwService.CorpId,
					RegionId = uwService.RegionId,
					CountryId = uwService.CountryId,
					DomesticregId = uwService.DomesticregId,
					StateProvId = uwService.StateProvId,
					CityId = uwService.CityId,
					OfficeId = uwService.OfficeId,
					CaseSeqNo = uwService.CaseSeqNo,
					HistSeqNo = uwService.HistSeqNo,

					StepId = StepId,
					StepTypeId = StepTypeId,
					StepCaseNo = StepCaseNo,

					CommentTypeId = CategoryId,
					Comments = Comment,
					UserId = uwService.UnderwriterId
				};

				Services.PolicyManager.UpdateUnderwritingCallComment(commentItem);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public static bool SaveUnderCallQuestions(String PolicyKey, int QuestionId, bool Answer, int StepTypeId, int StepId, int StepCaseNo)
		{
			try
			{
				var uwService = Tools.deserializeJSON<Tools.PolicyKeyItem>(PolicyKey);

				Services.PolicyManager.SetUnderwritingCallSecurityQuestion(uwService.CorpId, uwService.RegionId, uwService.CountryId, uwService.DomesticregId,
					uwService.StateProvId, uwService.CityId, uwService.OfficeId, uwService.CaseSeqNo, uwService.HistSeqNo, StepTypeId,
					StepId, StepCaseNo, QuestionId, uwService.ContactId, Answer, uwService.UnderwriterId);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public static bool SaveUnderCallChecks(String PolicyKey, int TabId, bool Answer, int StepTypeId, int StepId, int StepCaseNo)
		{
			try
			{
				var uwService = Tools.deserializeJSON<Tools.PolicyKeyItem>(PolicyKey);

				Services.PolicyManager.SetUnderwritingCallTabAnswer(uwService.CorpId, uwService.RegionId, uwService.CountryId, uwService.DomesticregId,
					uwService.StateProvId, uwService.CityId, uwService.OfficeId, uwService.CaseSeqNo, uwService.HistSeqNo, StepTypeId, StepId,
					StepCaseNo, TabId, Answer, uwService.UnderwriterId);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public static bool SetPriority(int CorpId, int RegionId, int CountryId, int DomesticregId, int StateProvId, int CityId, int OfficeId, int CaseSeqNo, int HistSeqNo, bool Priority)
		{
			var policy = Services.PolicyManager.GetPolicy(CorpId, RegionId, CountryId, DomesticregId, StateProvId, CityId, OfficeId, CaseSeqNo, HistSeqNo);
			policy.Priority = Priority;
			Services.PolicyManager.UpdatePolicy(policy);

			return true;
		}
	}
}