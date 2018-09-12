using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;
using System.Collections.Generic;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
	public partial class UCRiskClass : WEB.UnderWriting.Common.UC, WEB.UnderWriting.Common.IUC
	{
		DropDownManager DropDowns = new DropDownManager();
		//UnderWritingDIManager diManager = new UnderWritingDIManager();
		//IPolicy PolicyManager
		//{
		//    get { return diManager.PolicyManager; }
		//}
		bool IsAditionalInsured
		{
			get { return string.IsNullOrWhiteSpace(hdnIsAditional.Value) ? false : bool.Parse(hdnIsAditional.Value); }
			set { hdnIsAditional.Value = value.ToString(); }
		}
		int contactId
		{
			get { return string.IsNullOrWhiteSpace(hdnContactId.Value) ? 0 : int.Parse(hdnContactId.Value); }
			set { hdnContactId.Value = value.ToString(); }
		}
		int contactRoleTypeId
		{
			get { return string.IsNullOrWhiteSpace(hdnContactRoleTypeId.Value) ? 0 : int.Parse(hdnContactRoleTypeId.Value); }
			set { hdnContactRoleTypeId.Value = value.ToString(); }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

        }

		public void FillData(Boolean IsAditional)
		{
			IsAditionalInsured = IsAditional;
			lblContactType.Text = IsAditionalInsured ? "ADDITIONAL INSURED" : "INSURED";

			//Get Contact Info
			GetContactInfo();

			//Risk
			FillRiskData();

			//Credit
			FillCreditData();

			//Exclusion
			FillExclusionData();
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

		public void clearData()
		{
			throw new NotImplementedException();
		}

		public void DisableLinkButton(LinkButton linkButton, string disable_class)
		{
			linkButton.CssClass = disable_class;
			linkButton.Enabled = false;
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

		protected void gvRisks_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvRiskLife.PageIndex = e.NewPageIndex;
			gvRiskLife.DataBind();
			FillRiskData(false, true, false, true);
			setPagerIndex(gvRiskLife);
		}

		//Risk
		protected void btnAddNewRisk_Click(object sender, EventArgs e)
		{
			((UCPolicyPlanDataContainer)this.Parent).LoadNewRisk(IsAditionalInsured, contactId, contactRoleTypeId);
		}

		//Credit
		protected void btnNewCredit_Click(object sender, EventArgs e)
		{
			((UCPolicyPlanDataContainer)this.Parent).LoadNewCredit(IsAditionalInsured, contactId, contactRoleTypeId, decimal.Parse(txtRCTTableRating.Text), decimal.Parse(txtRCTPerThousand.Text));
		}

		//Exclusion
		protected void btnNewExclusion_Click(object sender, EventArgs e)
		{
			((UCPolicyPlanDataContainer)this.Parent).LoadNewExclusion(IsAditionalInsured, contactId, contactRoleTypeId);
		}

        //protected void gvAIRisk_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvRiskLife.PageIndex = e.NewPageIndex;
        //    gvRiskLife.DataBind();
        //    FillData();
        //    setPagerIndex(gvRiskLife);
        //}

        //Bmarroquin 03-02-2017 se agregan parametros Boolean LoadITP = true, Boolean LoadGF = true
        public void FillRiskData(Boolean FillTotals = true, Boolean LoadLife = true, Boolean LoadADB = true, Boolean FillCredit = true, Boolean LoadITP = true, Boolean LoadGF = true)
		{
			if (contactId != 0 && contactRoleTypeId != 0)
			{
				var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
				{
					//Key
					CorpId = Service.Corp_Id,
					RegionId = Service.Region_Id,
					CountryId = Service.Country_Id,
					DomesticRegId = Service.Domesticreg_Id,
					StateProvId = Service.State_Prov_Id,
					CityId = Service.City_Id,
					OfficeId = Service.Office_Id,
					CaseSeqNo = Service.Case_Seq_No,
					HistSeqNo = Service.Hist_Seq_No,

					//Contact
					ContactId = contactId,
					ContactRoleTypeId = contactRoleTypeId,

					OperationId = (int)Tools.RisksOperations.Risk
				};

				var data = Services.PolicyManager.GetRiskRating(riskItem).Where(r => r.RiskTypeId == 4 || r.RiskTypeId == 2 || r.RiskTypeId == 5 || r.RiskTypeId == 6);

				var dataTableRatings = DropDowns.GetDropDown(DropDownType.RiskRating,
															 Service.Corp_Id,
															 tableTypeId: 1,
															 projectId: Service.ProjectId,
															 companyId: Service.CompanyId).OrderBy(r => Decimal.Parse(r.Text));

				var dataPerThousands = DropDowns.GetDropDown(DropDownType.RiskRating,
															 Service.Corp_Id,
															 tableTypeId: 2,
															 projectId: Service.ProjectId,
															 companyId: Service.CompanyId).OrderBy(r => Decimal.Parse(r.Text));

				if (LoadLife)
				{
					#region LifeGrid
					//Getting DB Data
					var dataLife = data.Where(r => r.RiskTypeId == 2).ToList();

                    //Fill Grid
                    gvRiskLife.DataSource = dataLife;
					gvRiskLife.DataBind();

                    //Bmarroquin Comento dado que tronaba dado que los campos se dejaron abiertos
                    /*
					if (FillTotals)
					{
						var hasLifeTRating = dataLife.Any(r => r.TableRating.HasValue);
						var hasLifePThousand = dataLife.Any(r => r.PerThousandRating.HasValue);

						var totalLifeTRating = dataLife.Sum(r => !r.TableRating.HasValue ? 0 : r.TableRating.Value);
						var totalLifePThousand = dataLife.Sum(r => !r.PerThousandRating.HasValue ? 0 : r.PerThousandRating.Value);

						//Setting Totals
						txtRCLifeTableRating.Text = hasLifeTRating ?
							(totalLifeTRating > 0 ?
							Decimal.Parse(dataTableRatings.Where(r => decimal.Parse(r.Text) >= totalLifeTRating).FirstOrDefault().Text)
							: 0).ToString("N2")
							: "0.00";
                       
						txtRCLifePerThousand.Text = hasLifePThousand ?
							   (totalLifePThousand > 0 ?
							 Decimal.Parse(dataPerThousands.Where(r => decimal.Parse(r.Text) >= totalLifePThousand).FirstOrDefault().Text)
							 : 0).ToString("N2")
							 : "0.00";                         
					}
                    */

                    //Inizializate a pager
                    if (gvRiskLife.BottomPagerRow != null)
					{
						var totalItems = (Literal)gvRiskLife.BottomPagerRow.FindControl("totalItems");
						totalItems.Text = dataLife.ToList().Count + "";
					}

					setPagerIndex(gvRiskLife);

					if (IsAditionalInsured)
						gvRiskLife.Columns[0].Visible = false;
					#endregion
				}

				if (LoadADB)
				{
					#region ADBGrid
					//Getting DB Data
					var dataADB = data.Where(r => r.RiskTypeId == 4).ToList();

					//Fill Grid
					gvRiskADB.DataSource = dataADB;
					gvRiskADB.DataBind();

					//Inizializate a pager
					if (gvRiskADB.BottomPagerRow != null)
					{
						var totalItems = (Literal)gvRiskADB.BottomPagerRow.FindControl("totalItems");
						totalItems.Text = dataADB.ToList().Count + "";
					}

					setPagerIndex(gvRiskADB);

					if (IsAditionalInsured)
						gvRiskADB.Columns[0].Visible = false;
					#endregion
				}

                //Bmarroquin 03-02-2017 

                if (LoadITP) //Cobertura de ITP
                {
                    #region ITPrid
                    //Getting DB Data
                    var dataITP = data.Where(r => r.RiskTypeId == 5).ToList();

                    //Fill Grid
                    gvRiskITP.DataSource = dataITP;
                    gvRiskITP.DataBind();

                    //Inizializate a pager
                    if (gvRiskITP.BottomPagerRow != null)
                    {
                        var totalItems = (Literal)gvRiskITP.BottomPagerRow.FindControl("totalItems");
                        totalItems.Text = dataITP.ToList().Count + "";
                    }

                    setPagerIndex(gvRiskITP);

                    if (IsAditionalInsured)
                        gvRiskITP.Columns[0].Visible = false;
                    #endregion
                }

                if (LoadGF) //Cobertura de GF
                {
                    #region GFrid
                    //Getting DB Data
                    var dataGF = data.Where(r => r.RiskTypeId == 6).ToList();

                    //Fill Grid
                    gvRiskGF.DataSource = dataGF;
                    gvRiskGF.DataBind();

                    //Inizializate a pager
                    if (gvRiskGF.BottomPagerRow != null)
                    {
                        var totalItems = (Literal)gvRiskGF.BottomPagerRow.FindControl("totalItems");
                        totalItems.Text = dataGF.ToList().Count + "";
                    }

                    setPagerIndex(gvRiskITP);

                    if (IsAditionalInsured)
                        gvRiskGF.Columns[0].Visible = false;
                    #endregion
                }
                //Fin cambios Bmarroquin 03-02-2017 

                //Setting Totals
                //txtRCTTableRating.Text = (Decimal.Parse(txtRCLifeTableRating.Text) + Decimal.Parse(txtRCADBTableRating.Text)).ToString("N2");
				//txtRCTPerThousand.Text = (Decimal.Parse(txtRCLifePerThousand.Text) + Decimal.Parse(txtRCADBPerThousand.Text)).ToString("N2");

				if (!FillCredit) return;
				FillCreditData();
			}
		}

		public void FillCreditData()
		{
			if (contactId != 0 && contactRoleTypeId != 0)
			{
				var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
				{
					//Key
					CorpId = Service.Corp_Id,
					RegionId = Service.Region_Id,
					CountryId = Service.Country_Id,
					DomesticRegId = Service.Domesticreg_Id,
					StateProvId = Service.State_Prov_Id,
					CityId = Service.City_Id,
					OfficeId = Service.Office_Id,
					CaseSeqNo = Service.Case_Seq_No,
					HistSeqNo = Service.Hist_Seq_No,

					//Contact
					ContactId = contactId,
					ContactRoleTypeId = contactRoleTypeId,

					OperationId = (int)Tools.RisksOperations.Credit,
				};

				//Getting DB Data
				var data = Services.PolicyManager.GetRiskRating(riskItem);

				//Fill Grid
				gvCredit.DataSource = data.Where(r => r.CreditTypeId.HasValue).ToList();
				gvCredit.DataBind();

				//Inizializate a pager
				if (gvCredit.BottomPagerRow != null)
				{
					var totalItems = (Literal)gvCredit.BottomPagerRow.FindControl("totalItems");
					totalItems.Text = data.ToList().Count + "";
				}

				setPagerIndex(gvCredit);

				if (IsAditionalInsured)
					gvCredit.Columns[0].Visible = false;

				var TRatingTotal = Decimal.Parse(String.IsNullOrEmpty(txtRCADBTableRating.Text) ? "0" : txtRCADBTableRating.Text) + Decimal.Parse(String.IsNullOrEmpty(txtRCLifeTableRating.Text) ? "0" : txtRCLifeTableRating.Text);
				var PThousandTotal = Decimal.Parse(String.IsNullOrEmpty(txtRCADBPerThousand.Text) ? "0" : txtRCADBPerThousand.Text) + Decimal.Parse(String.IsNullOrEmpty(txtRCLifePerThousand.Text) ? "0" : txtRCLifePerThousand.Text);

				var creditTRating = data.Where(r => r.CreditTypeId == (int)Tools.RisksRatingTypes.TableRating).Sum(r => !r.TableRating.HasValue ? 0 : r.TableRating.Value);
				var creditPThousand = data.Where(r => r.CreditTypeId == (int)Tools.RisksRatingTypes.PerThousand).Sum(r => !r.TableRating.HasValue ? 0 : r.TableRating.Value);

				creditTRating = (TRatingTotal - creditTRating);
				creditPThousand = (PThousandTotal - creditPThousand);

				txtRCTTableRating.Text = creditTRating <= 0 ? "0.00" : creditTRating.ToString("N2");
				txtRCTPerThousand.Text = PThousandTotal <= 0 ? "0.00" : creditPThousand.ToString("N2");
			}
		}

		public void FillExclusionData()
		{
			if (contactId != 0 && contactRoleTypeId != 0)
			{
				var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
				{
					//Key
					CorpId = Service.Corp_Id,
					RegionId = Service.Region_Id,
					CountryId = Service.Country_Id,
					DomesticRegId = Service.Domesticreg_Id,
					StateProvId = Service.State_Prov_Id,
					CityId = Service.City_Id,
					OfficeId = Service.Office_Id,
					CaseSeqNo = Service.Case_Seq_No,
					HistSeqNo = Service.Hist_Seq_No,

					//Contact
					ContactId = contactId,
					ContactRoleTypeId = contactRoleTypeId,

					OperationId = (int)Tools.RisksOperations.Exclusion,
				};

				//Getting DB Data
				var data = Services.PolicyManager.GetRiskRating(riskItem);

				//Fill Grid
				gvExclusion.DataSource = data;
				gvExclusion.DataBind();

				//Inizializate a pager
				if (gvExclusion.BottomPagerRow != null)
				{
					var totalItems = (Literal)gvExclusion.BottomPagerRow.FindControl("totalItems");
					totalItems.Text = data.ToList().Count + "";
				}

				setPagerIndex(gvExclusion);

				if (IsAditionalInsured)
					gvExclusion.Columns[0].Visible = false;
			}
		}

		public void FillData()
		{
			throw new NotImplementedException();
		}

		private void GetContactInfo()
		{
			if (IsAditionalInsured)
			{
				contactId = Service.AddInsuredContactId.Value;
				contactRoleTypeId = 3;
			}
			else
			{
				var contactData = DropDowns.GetDropDown(DropDownType.Summary,
														Service.Corp_Id,
														Service.Region_Id,
														Service.Country_Id,
														Service.Domesticreg_Id,
														Service.State_Prov_Id,
														Service.City_Id,
														Service.Office_Id,
														Service.Case_Seq_No,
														Service.Hist_Seq_No,
														IsAditionalInsured ? Service.AddInsuredContactId : Service.Contact_Id,
														projectId: Service.ProjectId,
														companyId: Service.CompanyId, 
														languageId: Service.LanguageId);

				var insuredData = contactData.Where(r => r.Value.Split('|')[1] == "2");
				var ownerData = contactData.Where(r => r.Value.Split('|')[1] == "1");

				contactId = insuredData.Any() ? int.Parse(insuredData.First().Value.Split('|')[0])
											  : int.Parse(ownerData.First().Value.Split('|')[0]);

				contactRoleTypeId = insuredData.Any() ? 2 : 1;
			}
		}

		protected void gvCredit_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvCredit.PageIndex = e.NewPageIndex;
			gvCredit.DataBind();
			FillCreditData();
			setPagerIndex(gvCredit);
		}

		protected void gvExclusion_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvExclusion.PageIndex = e.NewPageIndex;
			gvExclusion.DataBind();
			FillExclusionData();
			setPagerIndex(gvExclusion);
		}

		protected void lnkComment_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

			var comment = gvExclusion.DataKeys[gridRow.RowIndex]["Comment"].ToString();
			var underwriter = gvExclusion.DataKeys[gridRow.RowIndex]["UnderwriterName"].ToString();
			var startDate = DateTime.Parse(gvExclusion.DataKeys[gridRow.RowIndex]["StartDate"].ToString());

			var formatedDate = startDate.ToString("MM/dd/yyyy  hh:mm tt");


			((UCPolicyPlanDataContainer)this.Parent).LoadExclusionComment(comment, underwriter, formatedDate);
		}

		protected void lnkTerminateExclusion_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((LinkButton)sender).NamingContainer;

			var comment = gvExclusion.DataKeys[gridRow.RowIndex]["Comment"].ToString();
			var sequenceReference = gvExclusion.DataKeys[gridRow.RowIndex]["SequenceReference"].ToString();
			var riskId = gvExclusion.DataKeys[gridRow.RowIndex]["RiskId"].ToString();
			var underwriterName = gvExclusion.DataKeys[gridRow.RowIndex]["UnderwriterName"].ToString();

			((UCPolicyPlanDataContainer)this.Parent).LoadTerminateExclusion(riskId, sequenceReference, underwriterName, comment, IsAditionalInsured);


		}

		protected void gvRiskADB_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvRiskADB.PageIndex = e.NewPageIndex;
			gvRiskADB.DataBind();
			FillRiskData(false, false, true, true);
			setPagerIndex(gvRiskADB);
		}

		protected void btnADBDeleteRisk_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((Button)sender).NamingContainer;

			var sequenceReference = gvRiskADB.DataKeys[gridRow.RowIndex]["SequenceReference"];
			var riskId = gvRiskADB.DataKeys[gridRow.RowIndex]["RiskId"];

			var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
			{
				//Key
				CorpId = Service.Corp_Id,
				SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
				RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null,
				UserId = Service.Underwriter_Id
			};

           Services.PolicyManager.DeleteRiskRating(riskItem);
            FillRiskData(true, false, true, true);
		}

		protected void btnLifeDeleteRisk_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((Button)sender).NamingContainer;

			var sequenceReference = gvRiskLife.DataKeys[gridRow.RowIndex]["SequenceReference"];
			var riskId = gvRiskLife.DataKeys[gridRow.RowIndex]["RiskId"];

			var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
			{
				//Key
				CorpId = Service.Corp_Id,
				SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
				RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null,
				UserId = Service.Underwriter_Id
			};


			Services.PolicyManager.DeleteRiskRating(riskItem);

			FillRiskData(true, true, false, true);
		}

		protected void btnLifeEditRisk_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((Button)sender).NamingContainer;

			var riskId = gvRiskLife.DataKeys[gridRow.RowIndex]["RiskId"];
			var sequenceReference = gvRiskLife.DataKeys[gridRow.RowIndex]["SequenceReference"];
			var yearToReconsider = gvRiskLife.DataKeys[gridRow.RowIndex]["YearToReconsider"];
			var duration = gvRiskLife.DataKeys[gridRow.RowIndex]["Duration"];

			var tableRating = (Decimal?)gvRiskLife.DataKeys[gridRow.RowIndex]["TableRating"];
			var perThousandRating = (Decimal?)gvRiskLife.DataKeys[gridRow.RowIndex]["PerThousandRating"];

			var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
			{
				//Key
				CorpId = Service.Corp_Id,
				SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
				RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null
			};

			var cDuration = duration == null ? 0 : Decimal.Parse(duration.ToString());
			var cYearToReconsider = yearToReconsider == null ? 0 : Decimal.Parse(yearToReconsider.ToString());

			var riskRatingList = Services.PolicyManager.GetRiskRatingSelection(riskItem);

            //Bmarroquin 05-03-2017 Codigo por nueva funcionalidad
            var lObjListRiskToEdit = getRiskRatingObjectToEdit(riskId.ToString(), sequenceReference.ToString());
            //Esto con la finalidad de enviar un solo objeto 
            lObjListRiskToEdit.FirstOrDefault().RiskGroupId = riskRatingList.FirstOrDefault().RiskGroupId;

            ((UCPolicyPlanDataContainer)this.Parent).LoadNewRisk(IsAditionalInsured, contactId, contactRoleTypeId, lObjListRiskToEdit,
					 cDuration,
					 cYearToReconsider,
					 tableRating,
					 perThousandRating);
		}

		protected void btnADBEditRisk_Click(object sender, EventArgs e)
		{
			var gridRow = (GridViewRow)((Button)sender).NamingContainer;

			var riskId = gvRiskADB.DataKeys[gridRow.RowIndex]["RiskId"];
			var sequenceReference = gvRiskADB.DataKeys[gridRow.RowIndex]["SequenceReference"];
			var yearToReconsider = gvRiskADB.DataKeys[gridRow.RowIndex]["YearToReconsider"];
			var duration = gvRiskADB.DataKeys[gridRow.RowIndex]["Duration"];
			var tableRating = (Decimal?)gvRiskADB.DataKeys[gridRow.RowIndex]["TableRating"];
			var perThousandRating = (Decimal?)gvRiskADB.DataKeys[gridRow.RowIndex]["PerThousandRating"];         
            
			var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
			{
				//Key
				CorpId = Service.Corp_Id,
				SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
				RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null
			};
            
			var riskRatingList = Services.PolicyManager.GetRiskRatingSelection(riskItem);

            //Bmarroquin 05-03-2017 Codigo por nueva funcionalidad
            var lObjListRiskToEdit = getRiskRatingObjectToEdit(riskId.ToString(), sequenceReference.ToString());
            //Esto con la finalidad de enviar un solo objeto 
            lObjListRiskToEdit.FirstOrDefault().RiskGroupId = riskRatingList.FirstOrDefault().RiskGroupId;

            ((UCPolicyPlanDataContainer)this.Parent).LoadNewRisk(IsAditionalInsured, contactId, contactRoleTypeId, lObjListRiskToEdit,
						duration == null ? 0 : Decimal.Parse(duration.ToString()),
						yearToReconsider == null ? 0 : Decimal.Parse(yearToReconsider.ToString()),
					 tableRating,
					 perThousandRating);
		}

        //Bmarroquin 03-02-2017 Incorporacion a raiz de tropicalizacion de ESA, se agregan rutinas de abajo
        public IEnumerable<Entity.UnderWriting.Entities.Policy.RiskRating> getRiskRatingObjectToEdit(string pStr_RiksID, string pStr_SequenceReference)
        {
            var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
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
              ContactId = contactId,
              ContactRoleTypeId = contactRoleTypeId,
              OperationId = (int)Tools.RisksOperations.Risk
            };

            var lObjListRisk = Services.PolicyManager.GetRiskRating(riskItem);
            var lObjRiskToEdit = lObjListRisk.Where(x => x.RiskId == int.Parse(pStr_RiksID) && x.SequenceReference == pStr_SequenceReference); //Get Only the Object that 

            return lObjRiskToEdit;
        }

        protected void gvRiskITP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRiskITP.PageIndex = e.NewPageIndex;
            gvRiskITP.DataBind();
            FillRiskData(false, false, true, true);
            setPagerIndex(gvRiskITP);

        }
        protected void btnITPDeleteRisk_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var sequenceReference = gvRiskITP.DataKeys[gridRow.RowIndex]["SequenceReference"];
            var riskId = gvRiskITP.DataKeys[gridRow.RowIndex]["RiskId"];

            var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
            {
                //Key
                CorpId = Service.Corp_Id,
                SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
                RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null,
                UserId = Service.Underwriter_Id
            };
            Services.PolicyManager.DeleteRiskRating(riskItem);
            FillRiskData(false, false, false, false, true, false);
        }
        protected void btnITPEditRisk_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var riskId = gvRiskITP.DataKeys[gridRow.RowIndex]["RiskId"];
            var sequenceReference = gvRiskITP.DataKeys[gridRow.RowIndex]["SequenceReference"];
            var yearToReconsider = gvRiskITP.DataKeys[gridRow.RowIndex]["YearToReconsider"];
            var duration = gvRiskITP.DataKeys[gridRow.RowIndex]["Duration"];
            var tableRating = (Decimal?)gvRiskITP.DataKeys[gridRow.RowIndex]["TableRating"];
            var perThousandRating = (Decimal?)gvRiskITP.DataKeys[gridRow.RowIndex]["PerThousandRating"];

            var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
            {
                //Key
                CorpId = Service.Corp_Id,
                SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
                RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null
            };

            var riskRatingList = Services.PolicyManager.GetRiskRatingSelection(riskItem);

            //Bmarroquin 05-03-2017 Codigo por nueva funcionalidad
            var lObjListRiskToEdit = getRiskRatingObjectToEdit(riskId.ToString(), sequenceReference.ToString());
            //Esto con la finalidad de enviar un solo objeto 
            lObjListRiskToEdit.FirstOrDefault().RiskGroupId = riskRatingList.FirstOrDefault().RiskGroupId;

            ((UCPolicyPlanDataContainer)this.Parent).LoadNewRisk(IsAditionalInsured, contactId, contactRoleTypeId, lObjListRiskToEdit,
                        duration == null ? 0 : Decimal.Parse(duration.ToString()),
                        yearToReconsider == null ? 0 : Decimal.Parse(yearToReconsider.ToString()),
                     tableRating,
                     perThousandRating);

        }
        //Gastos Funerarios
        protected void gvRiskGF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRiskGF.PageIndex = e.NewPageIndex;
            gvRiskGF.DataBind();
            FillRiskData(false, false, true, true);
            setPagerIndex(gvRiskGF);
        }
        protected void btnGFDeleteRisk_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;
            var sequenceReference = gvRiskGF.DataKeys[gridRow.RowIndex]["SequenceReference"];
            var riskId = gvRiskGF.DataKeys[gridRow.RowIndex]["RiskId"];

            var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
            {
                //Key
                CorpId = Service.Corp_Id,
                SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
                RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null,
                UserId = Service.Underwriter_Id
            };
            Services.PolicyManager.DeleteRiskRating(riskItem);
            FillRiskData(false, false, false, false,false,true);
        }
        protected void btnGFEditRisk_Click(object sender, EventArgs e)
        {
            var gridRow = (GridViewRow)((Button)sender).NamingContainer;

            var riskId = gvRiskGF.DataKeys[gridRow.RowIndex]["RiskId"];
            var sequenceReference = gvRiskGF.DataKeys[gridRow.RowIndex]["SequenceReference"];
            var yearToReconsider = gvRiskGF.DataKeys[gridRow.RowIndex]["YearToReconsider"];
            var duration = gvRiskGF.DataKeys[gridRow.RowIndex]["Duration"];
            var tableRating = (Decimal?)gvRiskGF.DataKeys[gridRow.RowIndex]["TableRating"];
            var perThousandRating = (Decimal?)gvRiskGF.DataKeys[gridRow.RowIndex]["PerThousandRating"];

            var riskItem = new Entity.UnderWriting.Entities.Policy.RiskRating()
            {
                //Key
                CorpId = Service.Corp_Id,
                SequenceReference = sequenceReference != null ? sequenceReference.ToString() : null,
                RiskId = riskId != null ? int.Parse(riskId.ToString()) : (int?)null
            };

            var riskRatingList = Services.PolicyManager.GetRiskRatingSelection(riskItem);

            //Bmarroquin 05-03-2017 Codigo por nueva funcionalidad
            var lObjListRiskToEdit = getRiskRatingObjectToEdit(riskId.ToString(), sequenceReference.ToString());
            //Esto con la finalidad de enviar un solo objeto 
            lObjListRiskToEdit.FirstOrDefault().RiskGroupId = riskRatingList.FirstOrDefault().RiskGroupId;

            ((UCPolicyPlanDataContainer)this.Parent).LoadNewRisk(IsAditionalInsured, contactId, contactRoleTypeId, lObjListRiskToEdit,
                        duration == null ? 0 : Decimal.Parse(duration.ToString()),
                        yearToReconsider == null ? 0 : Decimal.Parse(yearToReconsider.ToString()),
                     tableRating,
                     perThousandRating);
        }

    }
}