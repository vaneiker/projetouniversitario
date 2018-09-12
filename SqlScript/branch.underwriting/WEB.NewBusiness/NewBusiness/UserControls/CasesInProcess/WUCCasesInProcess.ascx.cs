using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using DI.UnderWriting.Interfaces;
using DI.UnderWriting;
using DevExpress.Web;
using Entity.UnderWriting.Entities;
using System.Text;
using RESOURCE.UnderWriting.NewBussiness;

using Statetrust.Framework.Security.Bll.Item;
using Statetrust.Framework.Security.Core;
using System.Configuration;

namespace WEB.NewBusiness.NewBusiness.UserControls.CasesInProcess
{
	public partial class WUCCasesInProcess : UC, IUC
	{
		public void save() { }
		public void edit() { }
		public void ClearData() { }
		public void ReadOnlyControls(bool isReadOnly) { }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Initialize();
				gvCasesInProcess.SetFilterSettings();
			}

			ObjServices.IsReadyToReview = false;
			udpCasesInProcess.Update();
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			Translator("");
		}

		public void Translator(string Lang)
		{
			CasesInProcess.InnerHtml = Resources.CasesInProcessLabel.ToUpper();
			btnSendToReview.Text = Resources.SendToReview.ToUpper();
			btnPrintList.Text = Resources.Export.ToUpper();
			SelectionGridMessage.InnerHtml = Resources.SelectionGridMessage;
		}

		public void FillData()
		{
			gvCasesInProcess.DataBind();
			gvCasesInProcess.FocusedRowIndex = -1;
		}

		public void Initialize()
		{
			FillData();
		}

		protected void LinqDS_Selecting(object sender, DevExpress.Data.Linq.LinqServerModeDataSourceSelectEventArgs e)
		{
			var item = new Entity.UnderWriting.Entities.Policy.NBParameter()
			{
				CorpId = ObjServices.Corp_Id,
				RegionId = ObjServices.Region_Id,
				CountryId = ObjServices.Country_Id,
				DomesticregId = ObjServices.Domesticreg_Id,
				StateProvId = ObjServices.State_Prov_Id,
				CityId = ObjServices.City_Id,
				OfficeId = ObjServices.Office_Id,
				AgentId = ObjServices.isUser ? -1 : ObjServices.Agent_LoginId
			};

			var data = ObjServices.oCaseManager.GetAllInProcess(item);
            e.KeyExpression = @"AgentLegalContactId,
                               OwnerContactId;
                               CaseSeqNo;
                               CorpId;
                               RegionId;
                               CountryId;
                               ProductNameKey,
                               DomesticregId;
                               PaymentId;
                               StateProvId;
                               CityId;
                               OfficeId;
                               HistSeqNo;
                               PolicyNo;
                               AgentId;
                               DesignatedPensionerContactId;
                               InsuredContactId;
                               StudentNameContactId;
                               ProductDesc;
                               OwnerFullName;
                               InsuranceFullName;
                               AgentFullName;
                               UserFullName;
                               LastUpdate;
                               AddInsuredContactId,
                               ProductTypeDesc";
            
            e.QueryableSource = data.AsQueryable();
		}

		protected void SetVariables(int RowIndex)
		{
			ObjServices.Corp_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CorpId", RowIndex).ToString());
			ObjServices.Region_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("RegionId", RowIndex).ToString());
			ObjServices.Country_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CountryId", RowIndex).ToString());
			ObjServices.Domesticreg_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("DomesticregId", RowIndex).ToString());
			ObjServices.State_Prov_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("StateProvId", RowIndex).ToString());
			ObjServices.City_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CityId", RowIndex).ToString());
			ObjServices.Office_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("OfficeId", RowIndex).ToString());
			ObjServices.Owner_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("OwnerContactId", RowIndex).ToString());
			ObjServices.Case_Seq_No = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CaseSeqNo", RowIndex).ToString());
			ObjServices.Hist_Seq_No = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("HistSeqNo", RowIndex).ToString());
			ObjServices.Contact_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("InsuredContactId", RowIndex).ToString());
			ObjServices.Policy_Id = gvCasesInProcess.GetKeyFromAspxGridView("PolicyNo", RowIndex).ToString();
			ObjServices.Agent_Id = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("AgentId", RowIndex).ToString());
			ObjServices.DesignatedPensionerContactId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("DesignatedPensionerContactId", RowIndex).ToString());
			ObjServices.StudentContactId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("StudentNameContactId", RowIndex).ToString());
			ObjServices.InsuredAddContactId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("AddInsuredContactId", RowIndex).ToString());
			ObjServices.PaymentId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
			ObjServices.KeyNameProduct = gvCasesInProcess.GetKeyFromAspxGridView("ProductNameKey", RowIndex, string.Empty).ToString();
            ObjServices.Agent_Legal = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("AgentLegalContactId", RowIndex).ToString());
            (this.Page as BasePage).setIsFuneral();
			ObjServices.isSavePlan = !string.IsNullOrEmpty(ObjServices.KeyNameProduct);

			var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(ObjServices.KeyNameProduct, typeof(Utility.ProductBehavior));
					   
			if (productBehavior.ToInt() == -1)
				productBehavior = Utility.ProductBehavior.None;

			ObjServices.ProductLine = ObjServices.GetProductLine(productBehavior);
		}

		protected void RedirectToAddNewCases(bool isReadOnly)
		{
			var oContact = ObjServices.GetContact(ObjServices.Contact_Id.Value);
			ObjServices.Relationship_With_Insured_Id = oContact.RelationshiptoAgent;
			ObjServices.isNewCase = false;
			ObjServices.IsReadOnly = isReadOnly;
			Response.Redirect("~/NewBusiness/Pages/AddNewClient.aspx");
		}

		protected void gvCasesInProcess_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
		{
			var Commando = e.CommandArgs.CommandName;

			var RowIndex = e.VisibleIndex;

			SetVariables(RowIndex);

			var TabConfig = ObjServices.getTabConfig();

			var TabsIdNotCompleted = TabConfig.Where(x => !x.IsValid);

			var isPaymentTabNext = TabsIdNotCompleted.FirstOrDefault().TabDesc == "Payment";

			var TabNext = (!isPaymentTabNext) ? TabsIdNotCompleted.Any() ? "lnk" + ((Utility.Tab)TabsIdNotCompleted.First().TabId).ToString() : "lnkClientInfo" : "lnkRequirements";

			ObjServices.TabRedirect = TabNext;

			switch (Commando)
			{
				case "View": RedirectToAddNewCases(true); break;
				case "Modify": RedirectToAddNewCases(false);
					break;
				case "Comment":
					(UCNotesComments.FindControl("pnButtonAdd") as Panel).Visible = true;
					UCNotesComments.FillData();
					hdnShowPopAddCommment.Value = "true";
					break;
				case "Delete":
					ObjServices.DeletePolicy();
					FillData();
					break;
				case "Upload":
					//Validar que el tab de plan policy este completo          
					var TabidHealthDeclaration = Utility.Tab.HealthDeclaration.ToInt();
					var TabValidHealthDeclaration = TabConfig.FirstOrDefault(x => x.TabId == TabidHealthDeclaration);

					if (!TabValidHealthDeclaration.IsValid)
					{
						var msj = string.Empty;
						if (!TabValidHealthDeclaration.IsValid)
							msj = "HealthDeclaration";

						this.MessageBox(@String.Format(RESOURCE.UnderWriting.NewBussiness.Resources.RequirementsTabsDisabled, msj), Title: "Error");
						return;
					}

					ObjServices.TabRedirect = "lnkRequirements";
					RedirectToAddNewCases(false);
					break;
			}

		}

		protected void btnPrintList_Click(object sender, EventArgs e)
		{
			var LstRecordChecks = new List<Case.Process>();
			var NegativeOne = (object)-1;

			for (int i = gvCasesInProcess.VisibleStartIndex; i < gvCasesInProcess.VisibleRowCount; i++)
			{
				var chk = gvCasesInProcess.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

				if (chk != null && chk.Checked)
				{
					var vPolicyNo = gvCasesInProcess.GetKeyFromAspxGridView("PolicyNo", i).ToString();
					var vProductDesc = gvCasesInProcess.GetKeyFromAspxGridView("ProductDesc", i) != null ? gvCasesInProcess.GetKeyFromAspxGridView("ProductDesc", i).ToString() : "";
					var vOwnerFullName = gvCasesInProcess.GetKeyFromAspxGridView("OwnerFullName", i) != null ? gvCasesInProcess.GetKeyFromAspxGridView("OwnerFullName", i).ToString() : "";
					var vInsuranceFullName = gvCasesInProcess.GetKeyFromAspxGridView("InsuranceFullName", i) != null ? gvCasesInProcess.GetKeyFromAspxGridView("InsuranceFullName", i).ToString() : "";
					var vAgentFullName = gvCasesInProcess.GetKeyFromAspxGridView("AgentFullName", i) != null ? gvCasesInProcess.GetKeyFromAspxGridView("AgentFullName", i).ToString() : "";
					var vUserFullName = gvCasesInProcess.GetKeyFromAspxGridView("UserFullName", i) != null ? gvCasesInProcess.GetKeyFromAspxGridView("UserFullName", i).ToString() : "";
					var vLastUpdate = !gvCasesInProcess.GetKeyFromAspxGridView("LastUpdate", i).Equals(NegativeOne) ? DateTime.Parse(gvCasesInProcess.GetKeyFromAspxGridView("LastUpdate", i).ToString()) : (DateTime?)null;

					LstRecordChecks.Add(new Case.Process()
					{
						PolicyNo = vPolicyNo,
						ProductDesc = vProductDesc,
						OwnerFullName = vOwnerFullName,
						InsuranceFullName = vInsuranceFullName,
						AgentFullName = vAgentFullName,
						UserFullName = vUserFullName,
						LastUpdate = vLastUpdate
					});
				}
			}

			gvFakeGridView.DataSource = LstRecordChecks;
			gvFakeGridView.DataBind();
			ASPxGridViewExporter1.WriteXlsxToResponse("CasesInProcess");
		}

		protected void btnSendToReview_Click(object sender, EventArgs e)
		{
			var ListError = new List<Utility.Errors>();
			var ListMessage = new List<Utility.ListTabError>();

			var CountCases = 0;
			var CountCasesError = 0;

			for (int i = gvCasesInProcess.VisibleStartIndex; i < gvCasesInProcess.VisibleRowCount; i++)
			{
				var chk = gvCasesInProcess.FindRowCellTemplateControl(i, null, "chkSelect") as CheckBox;

				if (chk != null && chk.Checked)
				{
					var PolicyNo = gvCasesInProcess.GetKeyFromAspxGridView("PolicyNo", i).ToString();

					var vCorpId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CorpId", i).ToString());
					var vRegionId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("RegionId", i).ToString());
					var vCountryId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CountryId", i).ToString());
					var vDomesticregId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("DomesticregId", i).ToString());
					var vStateProvId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("StateProvId", i).ToString());
					var vCityId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CityId", i).ToString());
					var vOfficeId = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("OfficeId", i).ToString());
					var vCaseSeqNo = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("CaseSeqNo", i).ToString());
					var vHistSeqNo = int.Parse(gvCasesInProcess.GetKeyFromAspxGridView("HistSeqNo", i).ToString());

					if (vCaseSeqNo != -1 && vHistSeqNo != -1)
					{
						var Result = ObjServices.oCaseManager.SendToReview(new Case()
						  {
							  CorpId = vCorpId,
							  RegionId = vRegionId,
							  CountryId = vCountryId,
							  DomesticregId = vDomesticregId,
							  StateProvId = vStateProvId,
							  CityId = vCityId,
							  OfficeId = vOfficeId,
							  CaseSeqNo = vCaseSeqNo,
							  HistSeqNo = vHistSeqNo,
							  UserId = ObjServices.UserID.Value
						  });

						if (!Result.Result)
						{
							CountCasesError++;

							var item = new Utility.Errors();
							item.Policy = PolicyNo;
							var vErrors = Result.ResultMessage.Split(',');

							/*
							  1-Owner Info Tab no se ha completado
							  2-Plan/Policy Tab no se ha completado
							  3-Beneficiaries Tab no se ha completado
							  4-Requirements Tab no se ha completado
							  5-Health Declaration Tab no se ha completado
							*/

							for (int x = 0; x < vErrors.Length; x++)
							{
								switch (vErrors[x])
								{
									case "Client Info":
										vErrors[x] = Resources.ClientInfoLabel;
										break;
									case "Owner Info":
										vErrors[x] = Resources.OwnerInfoLabel;
										break;
									case "Plan/Policy":
										vErrors[x] = Resources.PlanPolicyLabel;
										break;
									case "Beneficiaries":
										vErrors[x] = Resources.BeneficiariesLabel;
										break;
									case "Requirements":
										vErrors[x] = Resources.RequirementsLabel;
										break;
									case "Health Declaration":
										vErrors[x] = Resources.HealthDeclarationLabel;
										break;
								}

								if (ObjServices.Language == Utility.Language.en)
									item.MessageErrorList.Add((x + 1).ToString() + "-" + vErrors[x] + " " + RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted);
								else
									item.MessageErrorList.Add((x + 1).ToString() + "-" + "El Tab de " + vErrors[x] + " " + RESOURCE.UnderWriting.NewBussiness.Resources.TabNotCompleted2);
							}

							ListError.Add(item);
						}
						else
							CountCases++;
					}
				}
			}

			if (ListError.Any())
			{
				foreach (var item in ListError)
				{
					var temp = new Utility.ListTabError();
					temp.Policy = RESOURCE.UnderWriting.NewBussiness.Resources.ErrorPolicyNumber + " \"" + item.Policy + ":\"" + "<br/>";
					temp.Errors = string.Join("<br/>", item.MessageErrorList.ToArray());
					ListMessage.Add(temp);
				}

				var Message = new StringBuilder();

				Message.Append(CountCasesError.ToString("#,0") + " " + RESOURCE.UnderWriting.NewBussiness.Resources.CasesError);
				Message.Append("<br/>");

				foreach (var item in ListMessage)
				{
					Message.Append("<br/>");
					Message.Append(item.Policy);
					Message.Append("<br/>");
					Message.Append(item.Errors);
					Message.Append("<br/>");
				}
				this.MessageBox(Message.ToString(), Width: 500, Height: 350, Title: RESOURCE.UnderWriting.NewBussiness.Resources.ErrorInCase);
			}
			else
			{
				if (CountCases == 1)
					this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.CasesSentReadyReview,
						Title: ObjServices.Language == Utility.Language.en ? "Information" : "Información");
				else
					this.MessageBox(RESOURCE.UnderWriting.NewBussiness.Resources.CaseSentReadyReview,
						Title: ObjServices.Language == Utility.Language.en ? "Information" : "Información");
			}

			//Refrescar el listado independientemente de que se envien o no las polizas
			FillData();
		}

		protected void gvCasesInProcess_AfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
		{
			if (e.CallbackName == "APPLYFILTER")
				gvCasesInProcess.SetFilterSettings();
		}

		protected void gvCasesInProcess_PreRender(object sender, EventArgs e)
		{
			(sender as ASPxGridView).TranslateColumnsAspxGrid();
		}


        protected void lnkAuto_Click(object sender, EventArgs e)
        {
            string PvAutoPath = ConfigurationManager.AppSettings["PvAutoBandeja"].ToString();
            string PvAutoApp_Name = ConfigurationManager.AppSettings["PvAutoApp_Name_Bandeja"].ToString();

            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            LinkButton bntDrop = new LinkButton();
            bntDrop.Attributes["path"] = PvAutoPath;
            bntDrop.Attributes["appname"] = PvAutoApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lnkHealth_Click(object sender, EventArgs e)
        {
            string PvSaludPath = ConfigurationManager.AppSettings["PvSaludBandeja"].ToString();
            string PvSaludApp_Name = ConfigurationManager.AppSettings["appnameHealth"].ToString();

            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            LinkButton bntDrop = new LinkButton();
            bntDrop.Attributes["path"] = PvSaludPath;
            bntDrop.Attributes["appname"] = PvSaludApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        //protected void lnkLineaAleada_Click(object sender, EventArgs e)
        //{
        //    string PVLineasAliadasApp_Name = ConfigurationManager.AppSettings["PVLineasAliadasApp_Name"].ToString();

        //    string urlpath = ConfigurationManager.AppSettings["PvLineasHistory"].ToString() + "&" + ConfigurationManager.AppSettings["PvLineasHistoryComercial"].ToString();
             
        //    var addInfo = new AdditionalInfo
        //    {
        //        CompanyId = ObjServices.CompanyId,
        //        Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
        //    };

        //    LinkButton bntDrop = new LinkButton();

        //    bntDrop.Attributes["path"] = urlpath;
        //    bntDrop.Attributes["appname"] = PVLineasAliadasApp_Name;

        //    var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

        //    if (data.Status)
        //    {
        //        Response.Redirect(data.UrlPath, true);
        //    }
        //    else
        //    {
        //        string msjerrr = data.errormessage;
        //        if (msjerrr == "This user does not have access to this page or App")
        //        {
        //            msjerrr = Resources.UserNoAccess;
        //        }

        //        this.MessageBox(msjerrr);
        //        return;
        //    }
        //}

        protected void lnkVivienda_Click(object sender, EventArgs e)
        {
            string PVLineasAliadasApp_Name = ConfigurationManager.AppSettings["PvViviendaApp_Name_Bandeja"].ToString();

            string urlpath = ConfigurationManager.AppSettings["PvViviendaBandeja"].ToString();
             
            var addInfo = new AdditionalInfo
            {
                CompanyId = ObjServices.CompanyId,
                Language = (ObjServices.Language == Utility.Language.en ? "en" : "es")
            };

            LinkButton bntDrop = new LinkButton();

            bntDrop.Attributes["path"] = urlpath;
            bntDrop.Attributes["appname"] = PVLineasAliadasApp_Name;

            var data = SecurityPage.GenerateToken(ObjServices.UserID.Value, bntDrop, addInfo);

            if (data.Status)
            {
                Response.Redirect(data.UrlPath, true);
            }
            else
            {
                string msjerrr = data.errormessage;
                if (msjerrr == "This user does not have access to this page or App")
                {
                    msjerrr = Resources.UserNoAccess;
                }

                this.MessageBox(msjerrr);
                return;
            }
        }

        protected void lkLife_Click(object sender, EventArgs e)
        {
            this.MessageBox(Resources.CurrentlyPointSaleLifeFunerary);
            return;
        }
	}
}
