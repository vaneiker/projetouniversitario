using Entity.UnderWriting.Entities;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
using System.Web.UI;

namespace WEB.UnderWriting.Case.UserControls.Common
{
	public partial class Right : UC, IUC
	{

		Boolean NoteFromLeft
		{
			get { return !String.IsNullOrEmpty(hdnNoteFromLeft.Value) && Boolean.Parse(hdnNoteFromLeft.Value); }
			set { hdnNoteFromLeft.Value = value.ToString(); }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}


		private void HideText()
		{
			imgSentToReinsurance.Visible = lblSendToReinsurance.Visible = !(Service.GetProductFamily() == Tools.EFamilyProductType.HealthInsurance);
			imgHidden.Visible = !imgSentToReinsurance.Visible;
		}


		/// <summary>
		/// Marcar el Tab Seleccionado el metodo recibe un Objeto de tipo LinkButton y toma de el el id y el text ademas de el nombre del tab.
		/// Author: Lic. Carlos Ml. Lebron
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void SelectCurrentTab(object sender, EventArgs e)
		{
			if (Tools.IsSessionExpired())
				return;

			//Obtener el Current Tab
			var SelectTab = ((LinkButton)sender);

			var Tab = string.Empty;

			imgSentToReinsurance.Visible = lblSendToReinsurance.Visible = true;
			imgHidden.Visible = false;

			switch (SelectTab.ID)
			{
				case "lnkUnderWritingSteps": Tab = "underwriting_steps"; break;
				case "lnkNoteComments":
					Tab = "notes";
					HideText();
					break;
				case "lnkOfficeAgent":
					Tab = "OfficeAgent";
					HideText();
					break;
				case "lnkWorkFlow": Tab = "workflow"; break;
				case "lnkClientCommunications":
					Tab = "clientComunication";
					HideText();
					break;
				case "lnkPolicyPlanChangeSteps":
					Tab = "changeStep";
					HideText();
					break;
				case "lnkPolicyPlanDocuments":
					Tab = "PolicyPlandataDocuments";
					HideText();
					break;
				case "lnkUnderWritingCall": Tab = "underwriting_call"; break;
				case "btnSendToReinsurance": Tab = "dvSendToReinsurance"; break;
			}

			hfMenuCasesRight.Value = Tab + "|" + SelectTab.ID + "|" + SelectTab.Text;
			ltTitle.Text = SelectTab == lnkNoteComments ? SelectTab.Text + " / COMMENTS" : SelectTab.Text;
			FillData();
		}

        //wcastro 13-05-2017
        public void SendToReinsuranceAutomatically()
        {
            var Tab = "dvSendToReinsurance";
            String SelectTab = "btnSendToReinsurance";

            imgSentToReinsurance.Visible = lblSendToReinsurance.Visible = true;
            imgHidden.Visible = false;

            hfMenuCasesRight.Value = Tab + "|" + "btnSendToReinsurance" + "|" + "Send to Reinsurance";
            ltTitle.Text = "Send to Reinsurance";
            FillData();
        }
        //fin wcastro 13-05-2017

        protected void SelectTabUnderwritingCall(object sender, EventArgs e)
		{
			if (Tools.IsSessionExpired())
				return;

			//Obtener el Current Tab
			var SelectTab = ((LinkButton)sender);

			var Tab = string.Empty;

			switch (SelectTab.ID)
			{
				case "lnkProtocolo": Tab = "underwritingCallProtocolo"; break;
				case "lnkSaludo": Tab = "CallSaludo"; break;
				case "lnkPolizaPlan": Tab = "call_pplan"; break;
				case "lnkValoresDelPlan": Tab = "ValoresPlan"; break;
				case "lnkInversionPerfil": Tab = "invPerfil"; break;
				case "lnkDespedida": Tab = "despedida"; break;
			}

			hfMenuUnderwritingCall.Value = Tab + "|" + SelectTab.ID + "|" + SelectTab.Text;
		}

		public void save()
		{
			//var SelectedTab = hfMenuCasesRight.Value.Split('|');

			//if (!SelectedTab.Any()) return;
			//switch (SelectedTab[0])
			//{
			//}
		}

		public void FillData()
		{
			var SelectedTab = hfMenuCasesRight.Value.Split('|');

			pnlUCSave.Visible = (SelectedTab[0] == "underwriting_call");
			fillPointSteps();


			if (SelectedTab.Any())
			{
				var tabValue = SelectedTab[0].ToLower();

				switch (tabValue)
				{
					case "notes":
						UCNotesComments.FillData(NoteFromLeft);
						UCNotesComments.FillDdl();
						break;

					case "policyplandatadocuments":
						UCPolicyPlanDocument.FillData();
						UCPolicyPlanDocument.FillDdl();
						break;
					case "officeagent":
						UCOfficeAgent.FillData();
						break;

					case "clientcomunication":
						UCCustomerCommunication.FillData();
						break;
					case "workflow":
						UCWorkFlow.FillData();
						break;

					case "underwriting_steps":
						UCChangeSteps.Visible = false;
						UCUnderwritingStep.Visible = true;
						UCUnderwritingStep.FillData(false);
						break;

					case "changestep":
						UCChangeSteps.Visible = true;
						UCUnderwritingStep.Visible = false;
						UCChangeSteps.FillData(true);
						break;
					case "underwriting_call":
						FillUcLanguagesDrop();
						var languageId = int.Parse(ddlUCLanguages.SelectedItem.Value.ToString());

						hfMenuUnderwritingCall.Value = "lnkProtocolo";
						hfUCProtocol.Value = "si";
						UCUnderwritingCall.FillData(languageId);
						TranslateUnderwritingCallTabs(languageId);
						break;

					case "dvsendtoreinsurance":
						FillSendToReinsurance();
						break;

				}
			}
			showText();
			HideText();
		}

		public void fillPointSteps()
		{
			var Workflow = Services.StepManager.GetWorkflow(Service.Corp_Id, Service.Region_Id, Service.Country_Id, Service.Domesticreg_Id, Service.State_Prov_Id,
			   Service.City_Id, Service.Office_Id, Service.Case_Seq_No, Service.Hist_Seq_No);

			var DataApproval = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Approval).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueApproval = DataApproval.ProcessStatus > 0 ? DataApproval.ProcessStatus : (int?)null;

			var DataPaymentReview = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.PaymentReview).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValuePaymentReview = DataPaymentReview.ProcessStatus > 0 ? DataPaymentReview.ProcessStatus : (int?)null;

			var DataBackgroundCheck = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.BackgroundCheck).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueBackgroundCheck = DataBackgroundCheck.ProcessStatus > 0 ? DataBackgroundCheck.ProcessStatus : (int?)null;

			var DataConfirmationCall = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.ConfirmationCall).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueConfirmationCall = DataConfirmationCall.ProcessStatus > 0 ? DataConfirmationCall.ProcessStatus : (int?)null;

			var DataWaitingformedicalinfo = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Waitingformedicalinfo).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueWaitingformedicalinfo = DataWaitingformedicalinfo.ProcessStatus > 0 ? DataWaitingformedicalinfo.ProcessStatus : (int?)null;

			var DataEvaluation = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Evaluation).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueEvaluation = DataEvaluation.ProcessStatus > 0 ? DataEvaluation.ProcessStatus : (int?)null;

			var DataWaitingfoClientinformation = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.WaitingfoClientinformation).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueWaitingfoClientinformation = DataWaitingfoClientinformation.ProcessStatus > 0 ? DataWaitingfoClientinformation.ProcessStatus : (int?)null;

			var DataReinsurance = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.Reinsurance).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueReinsurance = DataReinsurance.ProcessStatus > 0 ? DataReinsurance.ProcessStatus : (int?)null;

			var DataFinalReview = Workflow.Where(w => w.Stage == (int)Tools.WorkFlowTypes.FinalReview).OrderBy(w => w.Order).FirstOrDefault();
			int? statusValueFinalReview = DataFinalReview.ProcessStatus > 0 ? DataFinalReview.ProcessStatus : (int?)null;



			lnkApproval.Attributes.Add("class", getColorState(statusValueApproval));
			lnkPaymentReview.Attributes.Add("class", getColorState(statusValuePaymentReview));
			lnkBackgroundCheck.Attributes.Add("class", getColorState(statusValueBackgroundCheck));
			lnkConfirmationCall.Attributes.Add("class", getColorState(statusValueConfirmationCall));
			lnkWaitingForMedicalInfo.Attributes.Add("class", getColorState(statusValueWaitingformedicalinfo));
			lnkEvaluation.Attributes.Add("class", getColorState(statusValueEvaluation));
			lnkWaitingForClientInformation.Attributes.Add("class", getColorState(statusValueWaitingfoClientinformation));
			lnkFinalReview.Attributes.Add("class", getColorState(statusValueFinalReview));
			lnkReinsurance.Attributes.Add("class", getColorState(statusValueReinsurance));
			lnkIssuance.Attributes.Add("class", getColorState(4));
			lnkNeverIssued.Attributes.Add("class", getColorState(4));

			bool sentToreinsurance = Workflow.FirstOrDefault(x => x.WasSentToReinsurance).WasSentToReinsurance;
			imgSentToReinsurance.ImageUrl = sentToreinsurance ? "~/images/bombillo.png" : "~/images/bombillo_disable.png";

		}

		public string getColorState(int? state)
		{

			string PendingColor = "tooltip2 point active";
			string CompleteColor = "tooltip2 point activeVR";
			string UnstateColor = "tooltip2 point activeGR";
			string voidStateColor = "tooltip2 point activeRJ";
			string stateColor = UnstateColor;

			if (state != null)
			{

				if (state == 1 || state == 3)
					stateColor = PendingColor;
				else if (state == 4)
					stateColor = voidStateColor;
				else
					stateColor = CompleteColor;
			}
			return stateColor;
		}



		public void clearData()
		{
			throw new NotImplementedException();
		}

		private void showText()
		{
			if (!NoteFromLeft)
			{
				pnReference.Visible = false;
				pnText.Visible = true;
			}
			NoteFromLeft = false;
		}

		public void SelectUnderWritingSteps()
		{
			hfMenuCasesRight.Value = "underwriting_steps|lnkUnderWritingSteps";
			FillData();
		}

		protected void btnOpenPopNewStep_Click(object sender, EventArgs e)
		{
			UCPopNewStep.FillData();
			hdnNSShowPop.Value = "true";
		}

		private void FillSendToReinsurance()
		{
			//Get Step Info
			var stepInfo = Service.StepAvailable();

			//Get Communications Data
			var commItem = new Reinsurance.Communication()
			{
				CorpId = Service.Corp_Id,
				RegionId = Service.Region_Id,
				CountryId = Service.Country_Id,
				DomesticRegId = Service.Domesticreg_Id,
				StateProvId = Service.State_Prov_Id,
				CityId = Service.City_Id,
				OfficeId = Service.Office_Id,
				CaseSeqNo = Service.Case_Seq_No,
				HistSeqNo = Service.Hist_Seq_No,
				StepId = stepInfo.StepId,
				StepCaseNo = stepInfo.StepCaseNo,
				StepTypeId = stepInfo.StepTypeId
			};

			var data = Service.FillResinsuranceComm(commItem);

			//Fill Popup with retrieved Data
			UCPopSentToReinsurance1.FillData(data, stepInfo);
		}

		protected void BTNSaveUCTab_Click(object sender, EventArgs e)
		{
			UCUnderwritingCall.SendAppointment();
		}

		protected void lnkRequesInformation_Click(object sender, EventArgs e)
		{
			var leftControl = this.Page.Master.FindControl("Left").FindControl("Left");
			HiddenField currentTab = leftControl.FindControl("hfMenuCasesLeft") as HiddenField;
			currentTab.Value = "Requirements|lnkRequirements|REQUIREMENTS";
			((Left)leftControl).clearData();
			((Left)leftControl).FillData();
		}

		private void FillUcLanguagesDrop()
		{
			var ddlData = Service.DropDowns.GetDropDown(DropDownType.Language, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
			ddlUCLanguages.Items.Clear();
			var a = 0;

			foreach (var item in ddlData)
			{
				var listItem = new DevExpress.Web.ListEditItem() { ImageUrl = "../../../images/languages/" + item.Value.Split('|')[1], Text = item.Text, Value = item.Value.Split('|')[0], Index = a };
				ddlUCLanguages.Items.Add(listItem);
				a++;
			}

			ddlUCLanguages.SelectedIndex = 0;
		}

		protected void ddlUCLanguages_SelectedIndexChanged(object sender, EventArgs e)
		{
			var languageId = int.Parse(ddlUCLanguages.SelectedItem.Value.ToString());
			hfMenuUnderwritingCall.Value = "lnkProtocolo";
			hfUCProtocol.Value = "si";

			UCUnderwritingCall.FillData(languageId);
			TranslateUnderwritingCallTabs(languageId);
		}

		private void TranslateUnderwritingCallTabs(int languageId)
		{
			if (languageId == 2)
			{
				lnkProtocolo.Text = "PROTOCOLO";
				lnkSaludo.Text = "SALUDO";
				lnkPolizaPlan.Text = "PÓLIZA/PLAN";
				lnkValoresDelPlan.Text = "VALORES DEL PLAN";
				lnkInversionPerfil.Text = "PERFIL DE INVERSIÓN ";
				lnkDespedida.Text = "DESPEDIDA";
			}
			else
			{
				lnkProtocolo.Text = "PROTOCOL";
				lnkSaludo.Text = "GREETING";
				lnkPolizaPlan.Text = "POLICY/PLAN";
				lnkValoresDelPlan.Text = "PLAN VALUES";
				lnkInversionPerfil.Text = "INVESTMENT PROFILE";
				lnkDespedida.Text = "GOOD BYE";
			}
		}

		protected void BTNSendUCTab_Click(object sender, EventArgs e)
		{
			UCUnderwritingCall.SendEmail();
		}

		public void Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void readOnly(bool x)
		{
			throw new NotImplementedException();
		}

		public void edit()
		{
			throw new NotImplementedException();
		}
	}
}