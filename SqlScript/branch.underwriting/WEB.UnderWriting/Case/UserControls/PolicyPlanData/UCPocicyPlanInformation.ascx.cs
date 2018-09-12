using System;
using System.Linq;
using System.Web.UI.WebControls;
using WEB.UnderWriting.Common;

namespace WEB.UnderWriting.Case.UserControls.PolicyPlanData
{
	public partial class UCPocicyPlanInformation : UC, IUC
	{
		//IPolicy PolicyData
		//{
		//    get { return diManager.PolicyManager; }
		//}

		//UnderWritingDIManager diManager = new UnderWritingDIManager();
		readonly DropDownManager _dropDowns = new DropDownManager();

		protected void Page_Load(object sender, EventArgs e)
		{
			EDUCACION.FillProfileDataP += new PolicyPlanData.ProductControls.EDUCACION.FillProfileData(FillProfileData);
			VIDA1.FillProfileDataP += new PolicyPlanData.ProductControls.VIDA.FillProfileData(FillProfileData);
			RETIRO.FillProfileDataP += new PolicyPlanData.ProductControls.RETIRO.FillProfileData(FillProfileData);
        }

		void IUC.Translator(string Lang)
		{
			throw new NotImplementedException();
		}

		public void save()
		{
            //
			var Corp_Id = Service.Corp_Id; //1
			var Region_Id = Service.Region_Id; //24
			var Country_Id = Service.Country_Id; //129
			var Domesticreg_Id = Service.Domesticreg_Id; //1
			var State_Prov_Id = Service.State_Prov_Id; //817
			var City_Id = Service.City_Id; //4442381
			var Office_Id = Service.Office_Id; //1
			var Case_Seq_No = Service.Case_Seq_No; //416
			var Hist_Seq_No = Service.Hist_Seq_No; //1

			Entity.UnderWriting.Entities.Policy.PlanData datos = Services.PolicyManager.GetPlanData(Corp_Id,
																									Region_Id,
																									Country_Id,
																									Domesticreg_Id,
																									State_Prov_Id,
																									City_Id,
																									Office_Id,
																									Case_Seq_No,
																									Hist_Seq_No);

			TextBox txtPolicy = null;
			TextBox txtInsuredName = null;
			TextBox txtOwnerName = null;
			TextBox txtAdditionalInsuredName = null;
			TextBox txtPolicyStatus = null;
			TextBox txtInsuredAmount = null;
			TextBox txtTotalInsuredAmount = null;
			TextBox txtCumulativeRisk = null;
			TextBox txtRetention = null;
			TextBox txtInitialContribution = null;
			TextBox txtTargetPremium = null;
			TextBox txtREINSURANCEAMOUNT = null;
			TextBox txtTotalRetention = null;
			TextBox txtPeriodicPremium = null;
            TextBox txtFraccionamiento = null; //mavelar 4/29/17
            TextBox txtPrimaComercial = null; //Bmarroquin 08-05-2017

            DropDownList dllPaymentFrecuency = null;
			TextBox txtTotalREINSURANCEAmount = null;
			TextBox txtRopAmount = null;
			TextBox txtAnnualPremium = null;
			TextBox txtContributionPeriod = null;
			TextBox txtMinAnnualPremium = null;
			TextBox txtSubmittedDate = null;
			TextBox txtLastPaymentDate = null;
			TextBox txtEfectiveDate = null;
			TextBox txtTerminationDate = null;
			TextBox txtClientAcknowledgmentDate = null;
			TextBox txtPlannedExpirationDate = null;
			TextBox txtInsuredPeriod = null;
			TextBox txtExpiredDate = null;
			DropDownList ddlPlanName = null;
			DropDownList ddlPlanType = null;
			DropDownList ddlCurrency = null;
			/*para vida */
			DropDownList ddlInvestmentProfile = null;
			TextBox txtInsuranceInclusionDateEnd = null;
			TextBox txtInsuranceInclusionDate = null;
			/*para vida */
			TextBox txtTotalBenefitAmount = null;
			TextBox txtAnnualBenefitAmount = null;
			TextBox txtRetirementAge = null;
			TextBox txtDefferalPeriod = null;
			/*para educacion */
			TextBox txtStudentAge = null;
			TextBox txtEducationPeriod = null;

			//Bl_Type_Id	Bl_Id	Bl_Desc
			//1	1	Retiro
			//1	2	Educación 
			//1	3	Vida
			//1	4	A Término



            /*ROJAS  */
            // 1  1  VIDA
            // 1  2  AUTO
            // 1  3  SALUD


			/*CONTROL DE TERMINOS*/
            var plantype = Service.GetProductFamily();
            bool actualizar = false;
            var Mensaje = "";
            int frecuencyId = Convert.ToInt32(datos.PaymentFreqId);
			//if (datos.BlTypeId == 1 && datos.BlId == 4)
            if (plantype == WEB.UnderWriting.Common.Tools.EFamilyProductType.TermInsurance || plantype == WEB.UnderWriting.Common.Tools.EFamilyProductType.Funeral) //funeral added here, but need to check where it goes
			{
				txtPolicy = ((TextBox)TERMINO.FindControl("txtPolicy"));
				txtInsuredName = ((TextBox)TERMINO.FindControl("txtInsuredName"));
				txtOwnerName = ((TextBox)TERMINO.FindControl("txtOwnerName"));
				txtAdditionalInsuredName = ((TextBox)TERMINO.FindControl("txtAdditionalInsuredName"));
				txtPolicyStatus = ((TextBox)TERMINO.FindControl("txtPolicyStatus"));
				txtInsuredAmount = ((TextBox)TERMINO.FindControl("txtInsuredAmount"));
				txtTotalInsuredAmount = ((TextBox)TERMINO.FindControl("txtTotalInsuredAmount"));
				txtCumulativeRisk = ((TextBox)TERMINO.FindControl("txtCumulativeRisk"));
				txtRetention = ((TextBox)TERMINO.FindControl("txtRetention"));
				txtInitialContribution = ((TextBox)TERMINO.FindControl("txtInitialContribution"));
				txtTargetPremium = ((TextBox)TERMINO.FindControl("txtTargetPremium"));
				txtREINSURANCEAMOUNT = ((TextBox)TERMINO.FindControl("txtREINSURANCEAMOUNT"));
				txtTotalRetention = ((TextBox)TERMINO.FindControl("txtTotalRetention"));
				txtPeriodicPremium = ((TextBox)TERMINO.FindControl("txtPeriodicPremium"));
                txtFraccionamiento = ((TextBox)TERMINO.FindControl("txtFraccionamiento")); //mavelar 4/29/17
                txtPrimaComercial = ((TextBox)TERMINO.FindControl("txtPrimaComercial")); //Bmarroquin 05-05-2017                
                dllPaymentFrecuency = ((DropDownList)TERMINO.FindControl("ddlPaymentFrecuency"));
				txtTotalREINSURANCEAmount = ((TextBox)TERMINO.FindControl("txtTotalREINSURANCEAmount"));
				txtRopAmount = ((TextBox)TERMINO.FindControl("txtRopAmount"));
				txtAnnualPremium = ((TextBox)TERMINO.FindControl("txtAnnualPremium"));
				txtContributionPeriod = ((TextBox)TERMINO.FindControl("txtContributionPeriod"));
				txtMinAnnualPremium = ((TextBox)TERMINO.FindControl("txtMinAnnualPremium"));
				txtSubmittedDate = ((TextBox)TERMINO.FindControl("txtSubmittedDate"));
				txtLastPaymentDate = ((TextBox)TERMINO.FindControl("txtLastPaymentDate"));
				txtEfectiveDate = ((TextBox)TERMINO.FindControl("txtEfectiveDate"));
				txtTerminationDate = ((TextBox)TERMINO.FindControl("txtTerminationDate"));
				txtClientAcknowledgmentDate = ((TextBox)TERMINO.FindControl("txtClientAcknowledgmentDate"));
				txtPlannedExpirationDate = ((TextBox)TERMINO.FindControl("txtPlannedExpirationDate"));
				txtInsuredPeriod = ((TextBox)TERMINO.FindControl("txtInsuredPeriod"));
				txtExpiredDate = ((TextBox)TERMINO.FindControl("txtExpiredDate"));
				ddlPlanName = ((DropDownList)TERMINO.FindControl("ddlPlanName"));
				ddlPlanType = ((DropDownList)TERMINO.FindControl("ddlPlanType"));
				ddlCurrency = ((DropDownList)TERMINO.FindControl("ddlCurrency"));

             //   decimal.Parse("0.00")).ToString("#,##0.00");
               
                try
                {
                    txtAnnualPremium.Text.Remove(',');
                    txtPeriodicPremium.Text.Remove(',');
                   
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }

                
                  var primaanual = decimal.Parse(txtAnnualPremium.Text);
                  var primaperiodica = decimal.Parse(txtPeriodicPremium.Text);
                  var recargofraccion = decimal.Parse(txtFraccionamiento.Text); //mavelar 4/29/17
                  var PrimaComercial = decimal.Parse(txtPrimaComercial.Text); //Bmarroquin 05-05-17

                var periodoasegurado = Convert.ToInt32(txtContributionPeriod.Text);
                  var frecuenciapago = Convert.ToInt32(dllPaymentFrecuency.SelectedValue);
                 
                //new fields
                  var ropamount = decimal.Parse(txtRopAmount.Text);
                  var targetPremium = decimal.Parse(txtTargetPremium.Text);
                  var insuredAmount = decimal.Parse(txtInsuredAmount.Text);
                  var minimalAnnualPremium = (decimal.Parse(txtMinAnnualPremium.Text));


                  if (datos.PaymentFreqTypeId != frecuenciapago)
                  {

                      if (UpgradePaymentFrequency(frecuenciapago, frecuencyId))
                      {
                          Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                          this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }else{ 
                          Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                          this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }
                          
                  }

                  if (datos.AnnualPremium != primaanual 
                      || datos.PeriodicPremium != primaperiodica 
                      || datos.ContributionPeriod != periodoasegurado 
                      || (datos.RopAmount ?? 0) != ropamount 
                      || (datos.TargetPremium ?? 0) != targetPremium
                      || (datos.InsuredAmount ?? 0) != insuredAmount
                      || (datos.MinAnnualPremium ?? 0) != minimalAnnualPremium)
                  {
                      if (UpgradePlanDataFields(primaanual, primaperiodica, periodoasegurado, minimalAnnualPremium, targetPremium, null, insuredAmount, ropamount))
                      {
                          Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                           this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }else{
                          Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                          this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }
                      //UpgradePlanDataFields(decimal anualprime, decimal periodicprime, int insuredperiod , decimal? minimalannualpremium = null, decimal? targetpremium = null, decimal? totalbenefitamount = null, decimal? InsuredAmount = null, decimal? ropamount = null) 
                 }

		
			//else if (datos.BlTypeId == 1 && datos.BlId == 3)
            }else if (plantype == WEB.UnderWriting.Common.Tools.EFamilyProductType.LifeInsurance)
			{

				txtPolicy = ((TextBox)VIDA1.FindControl("txtPolicy"));
				txtInsuredName = ((TextBox)VIDA1.FindControl("txtInsuredName"));
				txtOwnerName = ((TextBox)VIDA1.FindControl("txtOwnerName"));
				txtAdditionalInsuredName = ((TextBox)VIDA1.FindControl("txtAdditionalInsuredName"));
				txtPolicyStatus = ((TextBox)VIDA1.FindControl("txtPolicyStatus"));
				txtInsuredAmount = ((TextBox)VIDA1.FindControl("txtInsuredAmount"));
				txtTotalInsuredAmount = ((TextBox)VIDA1.FindControl("txtTotalInsuredAmount"));
				txtCumulativeRisk = ((TextBox)VIDA1.FindControl("txtCumulativeRisk"));
				txtRetention = ((TextBox)VIDA1.FindControl("txtRetention"));
				txtInitialContribution = ((TextBox)VIDA1.FindControl("txtInitialContribution"));
				txtTargetPremium = ((TextBox)VIDA1.FindControl("txtTargetPremium"));
				txtREINSURANCEAMOUNT = ((TextBox)VIDA1.FindControl("txtREINSURANCEAMOUNT"));
				txtTotalRetention = ((TextBox)VIDA1.FindControl("txtTotalRetention"));
				txtPeriodicPremium = ((TextBox)VIDA1.FindControl("txtPeriodicPremium"));
                dllPaymentFrecuency = ((DropDownList)VIDA1.FindControl("ddlPaymentFrecuency"));
				txtTotalREINSURANCEAmount = ((TextBox)VIDA1.FindControl("txtTotalREINSURANCEAmount"));
				//txtRopAmount = ((TextBox)VIDA1.FindControl("txtRopAmount"));
				txtAnnualPremium = ((TextBox)VIDA1.FindControl("txtAnnualPremium"));
				txtContributionPeriod = ((TextBox)VIDA1.FindControl("txtContributionPeriod"));
				txtMinAnnualPremium = ((TextBox)VIDA1.FindControl("txtMinAnnualPremium"));
				txtSubmittedDate = ((TextBox)VIDA1.FindControl("txtSubmittedDate"));
				txtLastPaymentDate = ((TextBox)VIDA1.FindControl("txtLastPaymentDate"));
				txtEfectiveDate = ((TextBox)VIDA1.FindControl("txtEfectiveDate"));
				txtTerminationDate = ((TextBox)VIDA1.FindControl("txtTerminationDate"));
				txtClientAcknowledgmentDate = ((TextBox)VIDA1.FindControl("txtClientAcknowledgmentDate"));
				txtPlannedExpirationDate = ((TextBox)VIDA1.FindControl("txtPlannedExpirationDate"));
				txtInsuredPeriod = ((TextBox)VIDA1.FindControl("txtInsuredPeriod"));
				txtExpiredDate = ((TextBox)VIDA1.FindControl("txtExpiredDate"));
				ddlPlanName = ((DropDownList)VIDA1.FindControl("ddlPlanName"));
				ddlPlanType = ((DropDownList)VIDA1.FindControl("ddlPlanType"));
				ddlCurrency = ((DropDownList)VIDA1.FindControl("ddlCurrency"));


				txtInsuranceInclusionDateEnd = ((TextBox)VIDA1.FindControl("txtInsuranceInclusionDateEnd"));
				txtInsuranceInclusionDate = ((TextBox)VIDA1.FindControl("txtInsuranceInclusionDate"));
				ddlInvestmentProfile = ((DropDownList)VIDA1.FindControl("ddlInvestmentProfile"));


             
                
                try
                {
                    txtAnnualPremium.Text.Remove(',');
                    txtPeriodicPremium.Text.Remove(',');
                   
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }

                
                  var primaanual = decimal.Parse(txtAnnualPremium.Text);
                  var primaperiodica = decimal.Parse(txtPeriodicPremium.Text);
                  var periodoasegurado = Convert.ToInt32(txtContributionPeriod.Text);
                  var frecuenciapago = Convert.ToInt32(dllPaymentFrecuency.SelectedValue);

                  //new fields
                  var targetPremium = decimal.Parse(txtTargetPremium.Text);
                  var insuredAmount = decimal.Parse(txtInsuredAmount.Text);
                  var minimalAnnualPremium = (decimal.Parse(txtMinAnnualPremium.Text));

                  if (datos.PaymentFreqTypeId != frecuenciapago)
                  {
                      if (UpgradePaymentFrequency(frecuenciapago, frecuencyId))
                      {
                          Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                          this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }
                      else {
                          Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                          this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');"); 
                      }
               
                  }

                  if (datos.AnnualPremium != primaanual 
                      || datos.PeriodicPremium != primaperiodica 
                      || datos.ContributionPeriod != periodoasegurado 
                      || (datos.TargetPremium ?? 0) != targetPremium
                      || (datos.InsuredAmount ?? 0) != insuredAmount
                      || (datos.MinAnnualPremium ?? 0) != minimalAnnualPremium)
                  {
                      if (UpgradePlanDataFields(primaanual, primaperiodica, periodoasegurado, minimalAnnualPremium, targetPremium, null, insuredAmount))
                      {
                          Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                           this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }
                      else {
                          Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                          this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                      }
			}
                //UpgradePlanDataFields(decimal anualprime, decimal periodicprime, int insuredperiod , decimal? minimalannualpremium = null, decimal? targetpremium = null, decimal? totalbenefitamount = null, decimal? InsuredAmount = null, decimal? ropamount = null)
			//else if (datos.BlTypeId == 1 && datos.BlId == 2)
            }
            else if (plantype == WEB.UnderWriting.Common.Tools.EFamilyProductType.Education)
            {

                txtPolicy = ((TextBox)EDUCACION.FindControl("txtPolicy"));
                txtInsuredName = ((TextBox)EDUCACION.FindControl("txtInsuredName"));
                txtOwnerName = ((TextBox)EDUCACION.FindControl("txtOwnerName"));
                txtAdditionalInsuredName = ((TextBox)EDUCACION.FindControl("txtAdditionalInsuredName"));
                txtPolicyStatus = ((TextBox)EDUCACION.FindControl("txtPolicyStatus"));
                txtInsuredAmount = ((TextBox)EDUCACION.FindControl("txtInsuredAmount"));
                txtTotalInsuredAmount = ((TextBox)EDUCACION.FindControl("txtTotalInsuredAmount"));
                txtCumulativeRisk = ((TextBox)EDUCACION.FindControl("txtCumulativeRisk"));
                txtRetention = ((TextBox)EDUCACION.FindControl("txtRetention"));
                txtInitialContribution = ((TextBox)EDUCACION.FindControl("txtInitialContribution"));
                txtTargetPremium = ((TextBox)EDUCACION.FindControl("txtTargetPremium"));
                txtREINSURANCEAMOUNT = ((TextBox)EDUCACION.FindControl("txtREINSURANCEAMOUNT"));
                txtTotalRetention = ((TextBox)EDUCACION.FindControl("txtTotalRetention"));
                txtPeriodicPremium = ((TextBox)EDUCACION.FindControl("txtPeriodicPremium"));
                dllPaymentFrecuency = ((DropDownList)EDUCACION.FindControl("ddlPaymentFrecuency"));
                txtTotalREINSURANCEAmount = ((TextBox)EDUCACION.FindControl("txtTotalREINSURANCEAmount"));
                //txtRopAmount = ((TextBox)VIDA1.FindControl("txtRopAmount"));
                txtAnnualPremium = ((TextBox)EDUCACION.FindControl("txtAnnualPremium"));
                txtContributionPeriod = ((TextBox)EDUCACION.FindControl("txtContributionPeriod"));
                txtMinAnnualPremium = ((TextBox)EDUCACION.FindControl("txtMinAnnualPremium"));
                txtSubmittedDate = ((TextBox)EDUCACION.FindControl("txtSubmittedDate"));
                txtLastPaymentDate = ((TextBox)EDUCACION.FindControl("txtLastPaymentDate"));
                txtEfectiveDate = ((TextBox)EDUCACION.FindControl("txtEfectiveDate"));
                txtTerminationDate = ((TextBox)EDUCACION.FindControl("txtTerminationDate"));
                txtClientAcknowledgmentDate = ((TextBox)EDUCACION.FindControl("txtClientAcknowledgmentDate"));
                txtPlannedExpirationDate = ((TextBox)EDUCACION.FindControl("txtPlannedExpirationDate"));
                txtInsuredPeriod = ((TextBox)EDUCACION.FindControl("txtInsuredPeriod"));
                txtExpiredDate = ((TextBox)EDUCACION.FindControl("txtExpiredDate"));
                ddlPlanName = ((DropDownList)EDUCACION.FindControl("ddlPlanName"));
                ddlPlanType = ((DropDownList)EDUCACION.FindControl("ddlPlanType"));
                ddlCurrency = ((DropDownList)EDUCACION.FindControl("ddlCurrency"));


                txtInsuranceInclusionDateEnd = ((TextBox)EDUCACION.FindControl("txtInsuranceInclusionDateEnd"));
                txtInsuranceInclusionDate = ((TextBox)EDUCACION.FindControl("txtInsuranceInclusionDate"));
                ddlInvestmentProfile = ((DropDownList)EDUCACION.FindControl("ddlInvestmentProfile"));

                /*retiron */
                txtTotalBenefitAmount = ((TextBox)EDUCACION.FindControl("txtTotalBenefitAmount"));
                txtAnnualBenefitAmount = ((TextBox)EDUCACION.FindControl("txtAnnualBenefitAmount"));
                txtRetirementAge = ((TextBox)EDUCACION.FindControl("txtRetirementAge"));
                txtDefferalPeriod = ((TextBox)EDUCACION.FindControl("txtDefferalPeriod"));

                /*educacion */
                txtStudentAge = ((TextBox)EDUCACION.FindControl("txtStudentAge"));
                txtEducationPeriod = ((TextBox)EDUCACION.FindControl("txtEducationPeriod"));



                try
                {
                    txtAnnualPremium.Text.Remove(',');
                    txtPeriodicPremium.Text.Remove(',');

                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }


                var primaanual = decimal.Parse(txtAnnualPremium.Text);
                var primaperiodica = decimal.Parse(txtPeriodicPremium.Text);
                var periodoasegurado = Convert.ToInt32(txtContributionPeriod.Text);
                var frecuenciapago = Convert.ToInt32(dllPaymentFrecuency.SelectedValue);

                //new fields
                var targetPremium = decimal.Parse(txtTargetPremium.Text);
                var totalBenefitAmount = decimal.Parse(txtTotalBenefitAmount.Text);
                var minimalAnnualPremium = (decimal.Parse(txtMinAnnualPremium.Text));
                if (datos.PaymentFreqTypeId != frecuenciapago)
                {
                    if (UpgradePaymentFrequency(frecuenciapago, frecuencyId))
                    {
                        Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");

                    }
                    else {
                        Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }

                }

                if (datos.AnnualPremium != primaanual 
                    || datos.PeriodicPremium != primaperiodica 
                    || datos.ContributionPeriod != periodoasegurado 
                    || (datos.TargetPremium ?? 0) != targetPremium 
                    || (datos.BenefitAmount ?? 0) != totalBenefitAmount 
                    || (datos.MinAnnualPremium ?? 0) != minimalAnnualPremium)
                {
                    if (UpgradePlanDataFields(primaanual, primaperiodica, periodoasegurado, minimalAnnualPremium, targetPremium, totalBenefitAmount))
                    {
                        Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }
                    else {
                        Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }
                }
                //UpgradePlanDataFields(decimal anualprime, decimal periodicprime, int insuredperiod , decimal? minimalannualpremium = null, decimal? targetpremium = null, decimal? totalbenefitamount = null, decimal? InsuredAmount = null, decimal? ropamount = null)
                //else if (datos.BlTypeId == 1 && datos.BlId == 1)
            }
            else if (plantype == WEB.UnderWriting.Common.Tools.EFamilyProductType.Retirement)
            {

                txtPolicy = ((TextBox)RETIRO.FindControl("txtPolicy"));
                txtInsuredName = ((TextBox)RETIRO.FindControl("txtInsuredName"));
                txtOwnerName = ((TextBox)RETIRO.FindControl("txtOwnerName"));
                txtAdditionalInsuredName = ((TextBox)RETIRO.FindControl("txtAdditionalInsuredName"));
                txtPolicyStatus = ((TextBox)RETIRO.FindControl("txtPolicyStatus"));
                txtInsuredAmount = ((TextBox)RETIRO.FindControl("txtInsuredAmount"));
                txtTotalInsuredAmount = ((TextBox)RETIRO.FindControl("txtTotalInsuredAmount"));
                txtCumulativeRisk = ((TextBox)RETIRO.FindControl("txtCumulativeRisk"));
                txtRetention = ((TextBox)RETIRO.FindControl("txtRetention"));
                txtInitialContribution = ((TextBox)RETIRO.FindControl("txtInitialContribution"));
                txtTargetPremium = ((TextBox)RETIRO.FindControl("txtTargetPremium"));
                txtREINSURANCEAMOUNT = ((TextBox)RETIRO.FindControl("txtREINSURANCEAMOUNT"));
                txtTotalRetention = ((TextBox)RETIRO.FindControl("txtTotalRetention"));
                txtPeriodicPremium = ((TextBox)RETIRO.FindControl("txtPeriodicPremium"));
                dllPaymentFrecuency = ((DropDownList)RETIRO.FindControl("ddlPaymentFrecuency"));
                txtTotalREINSURANCEAmount = ((TextBox)RETIRO.FindControl("txtTotalREINSURANCEAmount"));
                //txtRopAmount = ((TextBox)VIDA1.FindControl("txtRopAmount"));
                txtAnnualPremium = ((TextBox)RETIRO.FindControl("txtAnnualPremium"));
                txtContributionPeriod = ((TextBox)RETIRO.FindControl("txtContributionPeriod"));
                txtMinAnnualPremium = ((TextBox)RETIRO.FindControl("txtMinAnnualPremium"));
                txtSubmittedDate = ((TextBox)RETIRO.FindControl("txtSubmittedDate"));
                txtLastPaymentDate = ((TextBox)RETIRO.FindControl("txtLastPaymentDate"));
                txtEfectiveDate = ((TextBox)RETIRO.FindControl("txtEfectiveDate"));
                txtTerminationDate = ((TextBox)RETIRO.FindControl("txtTerminationDate"));
                txtClientAcknowledgmentDate = ((TextBox)RETIRO.FindControl("txtClientAcknowledgmentDate"));
                txtPlannedExpirationDate = ((TextBox)RETIRO.FindControl("txtPlannedExpirationDate"));
                txtInsuredPeriod = ((TextBox)RETIRO.FindControl("txtInsuredPeriod"));
                txtExpiredDate = ((TextBox)RETIRO.FindControl("txtExpiredDate"));
                ddlPlanName = ((DropDownList)RETIRO.FindControl("ddlPlanName"));
                ddlPlanType = ((DropDownList)RETIRO.FindControl("ddlPlanType"));
                ddlCurrency = ((DropDownList)RETIRO.FindControl("ddlCurrency"));
                txtInsuranceInclusionDateEnd = ((TextBox)RETIRO.FindControl("txtInsuranceInclusionDateEnd"));
                txtInsuranceInclusionDate = ((TextBox)RETIRO.FindControl("txtInsuranceInclusionDate"));
                ddlInvestmentProfile = ((DropDownList)RETIRO.FindControl("ddlInvestmentProfile"));

                /*retiron */
                txtTotalBenefitAmount = ((TextBox)RETIRO.FindControl("txtTotalBenefitAmount"));
                txtAnnualBenefitAmount = ((TextBox)RETIRO.FindControl("txtAnnualBenefitAmount"));
                txtRetirementAge = ((TextBox)RETIRO.FindControl("txtRetirementAge"));
                txtDefferalPeriod = ((TextBox)RETIRO.FindControl("txtDefferalPeriod"));



                try
                {
                    txtAnnualPremium.Text.Remove(',');
                    txtPeriodicPremium.Text.Remove(',');

                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }


                var primaanual = decimal.Parse(txtAnnualPremium.Text);
                var primaperiodica = decimal.Parse(txtPeriodicPremium.Text);
                var periodoasegurado = Convert.ToInt32(txtContributionPeriod.Text);
                var frecuenciapago = Convert.ToInt32(dllPaymentFrecuency.SelectedValue);

                //new fields
                var targetPremium = decimal.Parse(txtTargetPremium.Text);
                var totalBenefitAmount = decimal.Parse(txtTotalBenefitAmount.Text);
                var minimalAnnualPremium = (decimal.Parse(txtMinAnnualPremium.Text));
                if (datos.PaymentFreqTypeId != frecuenciapago)
                {
                    if (UpgradePaymentFrequency(frecuenciapago, frecuencyId))
                    {
                        Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }
                    else { 
                        Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }
                }

                //condition to check if any of these field has change from the ones who came in the load
                if (datos.AnnualPremium != primaanual 
                    || datos.PeriodicPremium != primaperiodica 
                    || datos.ContributionPeriod != periodoasegurado 
                    || (datos.TargetPremium ?? 0) != targetPremium 
                    || (datos.BenefitAmount ?? 0) != totalBenefitAmount 
                    || (datos.MinAnnualPremium ?? 0) != minimalAnnualPremium)
                {
                    if (UpgradePlanDataFields(primaanual, primaperiodica, periodoasegurado, minimalAnnualPremium, targetPremium, totalBenefitAmount))
                    {
                        Mensaje = "INFORMATION UPDATED SUCCESSFULY";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }
                    else {
                        Mensaje = "SORRY, INFORMATION COULD NOT BE UPDATED";
                        this.ExcecuteJScript("DisplayCustomMessage('" + Mensaje + "');");
                    }
                }


            }


        
            /*TODO: HANDLE EXCEPTION NULLPOINTER

			if (!String.IsNullOrEmpty(ddlInvestmentProfile.SelectedValue) && !Boolean.Parse(ddlInvestmentProfile.SelectedValue.Split('|')[1]))
			{
				DateTime date = DateTime.Now;

				//Profile Item
				var investProfile = new Entity.UnderWriting.Entities.Policy.InvestProfile
				{
					//Profile Data
					ProfileTypeId = int.Parse(ddlInvestmentProfile.SelectedValue.Split('|')[0]),
					InvestProductDateId = int.Parse(date.ToString("yyyyMMdd")),
					InvestmentProductDate = date,
					InvstProfileDesc = ddlInvestmentProfile.SelectedItem.Text,
				};

				Service.SavePPInvestmentProfile(investProfile, true);
			}
             * */



            //METHOD TO SAVE CHANGES IN POLICY FIELDS LIKE PERIODIC PREMIUM: PAYMENT FRECUENCY:TOTAL REINSURANCE AMOUNT, ROP AMOUNT: ANNUAL PREMIUM: CONTRIBUTION PERIOD:

		}


		public void readOnly(bool x)
		{
			throw new NotImplementedException();
		}

        public bool UpgradePlanDataFields(decimal anualprime, decimal periodicprime, int insuredperiod , decimal? minimalannualpremium = null, decimal? targetpremium = null, decimal? totalbenefitamount = null, decimal? InsuredAmount = null, decimal? ropamount = null)
        {
           
            DI.UnderWriting.UnderWritingDIManager UWservice = new DI.UnderWriting.UnderWritingDIManager();
            var resultado = false;
         //   UWservice.PolicyManager.UpdatePolicy(new Entity.UnderWriting.Entities.Policy Parameter
             var Corp_Id = Service.Corp_Id;
             var Region_Id = Service.Region_Id;
             var Country_Id = Service.Country_Id;
             var Domesticreg_Id = Service.Domesticreg_Id;
             var State_Prov_Id = Service.State_Prov_Id;
             var City_Id = Service.City_Id;
             var Office_Id = Service.Office_Id;
             var Case_Seq_No = Service.Case_Seq_No;
             var Hist_Seq_No = Service.Hist_Seq_No;
             var ContactId = Service.Contact_Id;
             var PolicyNo = Service.Policy_Id;
             var dataPoliza = UWservice.PolicyManager.GetPolicy(Corp_Id, Region_Id, Country_Id, Domesticreg_Id, State_Prov_Id, City_Id, Office_Id, Case_Seq_No, Hist_Seq_No);
                Entity.UnderWriting.Entities.Policy mypolicy = new Entity.UnderWriting.Entities.Policy();
                    mypolicy.CorpId = Corp_Id;
                    mypolicy.RegionId = Region_Id;
                    mypolicy.CountryId = Country_Id;
                    mypolicy.DomesticregId = Domesticreg_Id;
                    mypolicy.StateProvId = State_Prov_Id;
                    mypolicy.CityId = City_Id;
                    mypolicy.OfficeId = Office_Id;
                    mypolicy.CaseSeqNo = Case_Seq_No;
                    mypolicy.HistSeqNo = Hist_Seq_No;
                    mypolicy.ContactId = ContactId;
                    mypolicy.DocumentType = dataPoliza.DocumentType;
                    mypolicy.PolicyNo = PolicyNo;
                    mypolicy.PolicySerieId = dataPoliza.PolicySerieId;
                    mypolicy.CurrencyId = dataPoliza.CurrencyId;
                    mypolicy.QuotationCurrencyId = dataPoliza.QuotationCurrencyId;
                    mypolicy.PaymentsCurrencyId = dataPoliza.PaymentsCurrencyId;
                    mypolicy.BussinessLineType = dataPoliza.BussinessLineType;
                    mypolicy.BussinessLineId = dataPoliza.BussinessLineId;
                    mypolicy.ProductId = dataPoliza.ProductId;
                    mypolicy.DeductibleTypeId = dataPoliza.DeductibleTypeId;
                    mypolicy.DeductibleCategoryId = dataPoliza.DeductibleCategoryId;
                    mypolicy.DeductibleManualValue = dataPoliza.DeductibleManualValue;
                    mypolicy.Reinsured = dataPoliza.Reinsured;
                    mypolicy.ReinsuredAmount = dataPoliza.ReinsuredAmount;
                    mypolicy.SubmitDate = dataPoliza.SubmitDate;
                    mypolicy.VanishDate = dataPoliza.VanishDate;
                    mypolicy.TermDate = dataPoliza.TermDate;
                    mypolicy.PeriodicPremium = periodicprime; //PRIMA PERIODICA A ACTUALIZAR
                    mypolicy.ContributionTypeId = dataPoliza.ContributionTypeId;
                    mypolicy.GoalAmount = dataPoliza.GoalAmount;
                    mypolicy.GoalAtAge = dataPoliza.GoalAtAge;
                    mypolicy.PolicyEffectiveDate = dataPoliza.PolicyEffectiveDate;
                    mypolicy.BenefitEndingDate = dataPoliza.BenefitEndingDate;
                    mypolicy.DefermentPeriod = dataPoliza.DefermentPeriod;
                    mypolicy.MinimunPremiunAmount = dataPoliza.MinimunPremiunAmount;
                    mypolicy.InsuredAmount = InsuredAmount == 0 || InsuredAmount == null ? dataPoliza.InsuredAmount : InsuredAmount;
                    mypolicy.TargetPremium = targetpremium == 0 || targetpremium == null ? dataPoliza.TargetPremium : targetpremium;
                    mypolicy.InitialContribution = dataPoliza.InitialContribution;
                    mypolicy.YearContributionPeriod = dataPoliza.YearContributionPeriod;
                    mypolicy.InsuredPeriod = dataPoliza.InsuredPeriod;
                    mypolicy.CollectionStatusId = dataPoliza.CollectionStatusId;
                    mypolicy.BenefitAmount = totalbenefitamount == 0 || totalbenefitamount == null ?  dataPoliza.BenefitAmount : totalbenefitamount;
                    mypolicy.AnnualPremium = anualprime;  //PRIMA ANNUAL A ACTUALIZAR
                    mypolicy.AnnualBenefit = dataPoliza.AnnualBenefit;
                    mypolicy.EndingContributionDate = dataPoliza.EndingContributionDate;
                    mypolicy.InitialBenefitDate = dataPoliza.InitialBenefitDate;
                    mypolicy.ModalPremium = dataPoliza.ModalPremium;
                    mypolicy.Rate = dataPoliza.Rate;
                    mypolicy.ExcessPremium = dataPoliza.ExcessPremium;
                    mypolicy.RolId = dataPoliza.RolId;
                    mypolicy.PolicyStatusId = dataPoliza.PolicyStatusId;
                    mypolicy.SumARisk = dataPoliza.SumARisk;
                    mypolicy.RopAmount = ropamount == 0 || ropamount == null ? dataPoliza.RopAmount : ropamount;
                    mypolicy.InitialPremium = dataPoliza.InitialPremium;
                    mypolicy.InsurancePremium = dataPoliza.InsurancePremium;
                    mypolicy.RetirementAmount = dataPoliza.RetirementAmount;
                    mypolicy.AnnualRetirement = dataPoliza.AnnualRetirement;
                    mypolicy.MinAnnualPremium = minimalannualpremium == 0 || minimalannualpremium == null ? dataPoliza.MinAnnualPremium : minimalannualpremium;
                    mypolicy.InsuranceDuration = dataPoliza.InsuranceDuration;
                    mypolicy.ContributionYears = insuredperiod;  //ANOS DE CONTRIBUCION
                    mypolicy.RetirementPeriod = dataPoliza.RetirementPeriod;
                    mypolicy.ReturnAmount = dataPoliza.ReturnAmount;
                    mypolicy.InvestmentProfile = dataPoliza.InvestmentProfile;
                    mypolicy.ContributionEndDate = dataPoliza.ContributionEndDate;
                    mypolicy.RetirementBeginDate = dataPoliza.RetirementBeginDate;
                    mypolicy.ExpirationDate = dataPoliza.ExpirationDate;
                    mypolicy.RetirementEndDate = dataPoliza.RetirementEndDate;
                    mypolicy.PaidThrough = dataPoliza.PaidThrough;
                    mypolicy.Priority = dataPoliza.Priority;
                    mypolicy.PaymentId = dataPoliza.PaymentId;
                    mypolicy.UserId = dataPoliza.UserId;
                    mypolicy.CreateDate = dataPoliza.CreateDate;

                    if (UWservice.PolicyManager.UpdatePolicy(mypolicy) == -1){
                        resultado = true;
                    }
                return resultado; 
        }

        public bool UpgradePaymentFrequency(int a, int frecuencyId)
        {
            var Result = false;
            DateTime now = DateTime.Now;
            DI.UnderWriting.UnderWritingDIManager PaymentFrequencyChange = new DI.UnderWriting.UnderWritingDIManager(); 
            Entity.UnderWriting.Entities.Policy.PaymentFrequency paymentFreq = new Entity.UnderWriting.Entities.Policy.PaymentFrequency();
            paymentFreq.CorpId = Service.Corp_Id;
            paymentFreq.RegionId = Service.Region_Id;
            paymentFreq.CountryId = Service.Country_Id;
            paymentFreq.DomesticregId = Service.Domesticreg_Id;
            paymentFreq.StateProvId = Service.State_Prov_Id;
            paymentFreq.CityId = Service.City_Id;
            paymentFreq.OfficeId = Service.Office_Id;
            paymentFreq.CaseSeqNo = Service.Case_Seq_No;
            paymentFreq.HistSeqNo = Service.Hist_Seq_No;
            paymentFreq.PaymentFreqTypeId = a;
            paymentFreq.PaymentFreqId = frecuencyId; //revisar
            paymentFreq.PaymentDate = now; //Date = {16/06/2016 12:00:00 a.m.}
            paymentFreq.UserId = 1; //revisar

            var retorno = PaymentFrequencyChange.PolicyManager.UpdatePaymentFrequency(paymentFreq);
            if (retorno == -1)
            {
                Result = true;
               
            }

           // ABR.PaymentManager.SetPaymentFrequency
          /*  UPDATE PERSONAL INFO OF A CONTACT: Entity.UnderWriting.Entities.Contact mycontact;
            mycontact.
            ABR.PolicyManager.UpdatePersonalInfoContact(); */


            return Result;
        }

		void IUC.edit()
		{
			throw new NotImplementedException();
		}

		public void FillData()
		{
			var Corp_Id = Service.Corp_Id;
			var Region_Id = Service.Region_Id;
			var Country_Id = Service.Country_Id;
			var Domesticreg_Id = Service.Domesticreg_Id;
			var State_Prov_Id = Service.State_Prov_Id;
			var City_Id = Service.City_Id;
			var Office_Id = Service.Office_Id;
			var Case_Seq_No = Service.Case_Seq_No;
			var Hist_Seq_No = Service.Hist_Seq_No;

			Entity.UnderWriting.Entities.Policy.PlanData datos = Services.PolicyManager.GetPlanData(Corp_Id,
																									Region_Id,
																									Country_Id,
																									Domesticreg_Id,
																									State_Prov_Id,
																									City_Id,
																									Office_Id,
																									Case_Seq_No,
																									Hist_Seq_No);
			
			#region Objetos
			TextBox txtPolicy = null;
			TextBox txtInsuredName = null;
			TextBox txtOwnerName = null;
			TextBox txtAdditionalInsuredName = null;
			TextBox txtPolicyStatus = null;
			TextBox txtInsuredAmount = null;
			TextBox txtTotalInsuredAmount = null;
			TextBox txtCumulativeRisk = null;
			TextBox txtRetention = null;
			TextBox txtInitialContribution = null;
			TextBox txtTargetPremium = null;
			TextBox txtREINSURANCEAMOUNT = null;
			TextBox txtTotalRetention = null;
			TextBox txtPeriodicPremium = null;
            TextBox txtFraccionamiento = null; //mavelar 4/29/17
            TextBox txtPrimaComercial = null; //Bmarroquin 05-05-17
            DropDownList ddlPaymentFrecuency = null;
			TextBox txtTotalREINSURANCEAmount = null;
			TextBox txtRopAmount = null;
			TextBox txtAnnualPremium = null;
			TextBox txtContributionPeriod = null;
			TextBox txtMinAnnualPremium = null;
			TextBox txtSubmittedDate = null;
			TextBox txtLastPaymentDate = null;
			TextBox txtEfectiveDate = null;
			TextBox txtTerminationDate = null;
			TextBox txtClientAcknowledgmentDate = null;
			TextBox txtPlannedExpirationDate = null;
			TextBox txtInsuredPeriod = null;
			TextBox txtExpiredDate = null;
			DropDownList ddlPlanName = null;
			DropDownList ddlPlanType = null;
			DropDownList ddlCurrency = null;
			/*para vida */
			DropDownList ddlInvestmentProfile = null;
			TextBox txtInsuranceInclusionDateEnd = null;
			TextBox txtInsuranceInclusionDate = null;
			/*para vida */
			TextBox txtTotalBenefitAmount = null;
			TextBox txtAnnualBenefitAmount = null;
			TextBox txtRetirementAge = null;
			TextBox txtDefferalPeriod = null;
			/*para educacion */
			TextBox txtStudentAge = null;
			TextBox txtEducationPeriod = null;
			GridView gvRiderBenefitAmount = null;
			GridView gvRiderType = null;

			/*Boton Perfil Personalizado*/
			Panel dvBtnPersonalizedProfile = null;
			#endregion

			//Bl_Type_Id	Bl_Id	Bl_Desc
			//1				1		Retiro
			//1				2		Educación 
			//1				3		Vida
			//1				4		A Término

			/*CONTROL DE TERMINOS*/
			if (datos == null) return;
			var productFam = Service.GetProductFamily();

			switch (productFam)
			{
				#region TermInsurance / Funeral
				case Tools.EFamilyProductType.TermInsurance:
				case Tools.EFamilyProductType.Funeral:
					txtPolicy = ((TextBox)TERMINO.FindControl("txtPolicy"));
					txtInsuredName = ((TextBox)TERMINO.FindControl("txtInsuredName"));
					txtOwnerName = ((TextBox)TERMINO.FindControl("txtOwnerName"));
					txtAdditionalInsuredName = ((TextBox)TERMINO.FindControl("txtAdditionalInsuredName"));
					txtPolicyStatus = ((TextBox)TERMINO.FindControl("txtPolicyStatus"));
					txtInsuredAmount = ((TextBox)TERMINO.FindControl("txtInsuredAmount"));
					txtTotalInsuredAmount = ((TextBox)TERMINO.FindControl("txtTotalInsuredAmount"));
					txtCumulativeRisk = ((TextBox)TERMINO.FindControl("txtCumulativeRisk"));
					txtRetention = ((TextBox)TERMINO.FindControl("txtRetention"));
					txtInitialContribution = ((TextBox)TERMINO.FindControl("txtInitialContribution"));
					txtTargetPremium = ((TextBox)TERMINO.FindControl("txtTargetPremium"));
					txtREINSURANCEAMOUNT = ((TextBox)TERMINO.FindControl("txtREINSURANCEAMOUNT"));
					txtTotalRetention = ((TextBox)TERMINO.FindControl("txtTotalRetention"));
					txtPeriodicPremium = ((TextBox)TERMINO.FindControl("txtPeriodicPremium"));
                    txtFraccionamiento = ((TextBox)TERMINO.FindControl("txtFraccionamiento")); //mavelar 4/29/17
                    txtPrimaComercial = ((TextBox)TERMINO.FindControl("txtPrimaComercial")); //Bmarroquin 05-05-17

                    ddlPaymentFrecuency = ((DropDownList)TERMINO.FindControl("ddlPaymentFrecuency"));
					txtTotalREINSURANCEAmount = ((TextBox)TERMINO.FindControl("txtTotalREINSURANCEAmount"));
					txtRopAmount = ((TextBox)TERMINO.FindControl("txtRopAmount"));
					txtAnnualPremium = ((TextBox)TERMINO.FindControl("txtAnnualPremium"));
					txtContributionPeriod = ((TextBox)TERMINO.FindControl("txtContributionPeriod"));
					txtMinAnnualPremium = ((TextBox)TERMINO.FindControl("txtMinAnnualPremium"));
					txtSubmittedDate = ((TextBox)TERMINO.FindControl("txtSubmittedDate"));
					txtLastPaymentDate = ((TextBox)TERMINO.FindControl("txtLastPaymentDate"));
					txtEfectiveDate = ((TextBox)TERMINO.FindControl("txtEfectiveDate"));
					txtTerminationDate = ((TextBox)TERMINO.FindControl("txtTerminationDate"));
					txtClientAcknowledgmentDate = ((TextBox)TERMINO.FindControl("txtClientAcknowledgmentDate"));
					txtPlannedExpirationDate = ((TextBox)TERMINO.FindControl("txtPlannedExpirationDate"));
					txtInsuredPeriod = ((TextBox)TERMINO.FindControl("txtInsuredPeriod"));
					txtExpiredDate = ((TextBox)TERMINO.FindControl("txtExpiredDate"));
					ddlPlanName = ((DropDownList)TERMINO.FindControl("ddlPlanName"));
					ddlPlanType = ((DropDownList)TERMINO.FindControl("ddlPlanType"));
					ddlCurrency = ((DropDownList)TERMINO.FindControl("ddlCurrency"));

					gvRiderBenefitAmount = ((GridView)TERMINO.FindControl("gvRiderBenefitAmount"));
					gvRiderType = ((GridView)TERMINO.FindControl("gvRiderType"));

					MVProducts.SetActiveView(VTermino);
					break;
				#endregion

				#region LifeInsurance
				case Tools.EFamilyProductType.LifeInsurance:
					txtPolicy = ((TextBox)VIDA1.FindControl("txtPolicy"));
					txtInsuredName = ((TextBox)VIDA1.FindControl("txtInsuredName"));
					txtOwnerName = ((TextBox)VIDA1.FindControl("txtOwnerName"));
					txtAdditionalInsuredName = ((TextBox)VIDA1.FindControl("txtAdditionalInsuredName"));
					txtPolicyStatus = ((TextBox)VIDA1.FindControl("txtPolicyStatus"));
					txtInsuredAmount = ((TextBox)VIDA1.FindControl("txtInsuredAmount"));
					txtTotalInsuredAmount = ((TextBox)VIDA1.FindControl("txtTotalInsuredAmount"));
					txtCumulativeRisk = ((TextBox)VIDA1.FindControl("txtCumulativeRisk"));
					txtRetention = ((TextBox)VIDA1.FindControl("txtRetention"));
					txtInitialContribution = ((TextBox)VIDA1.FindControl("txtInitialContribution"));
					txtTargetPremium = ((TextBox)VIDA1.FindControl("txtTargetPremium"));
					txtREINSURANCEAMOUNT = ((TextBox)VIDA1.FindControl("txtREINSURANCEAMOUNT"));
					txtTotalRetention = ((TextBox)VIDA1.FindControl("txtTotalRetention"));
					txtPeriodicPremium = ((TextBox)VIDA1.FindControl("txtPeriodicPremium"));
                    ddlPaymentFrecuency = ((DropDownList)VIDA1.FindControl("ddlPaymentFrecuency"));
					txtTotalREINSURANCEAmount = ((TextBox)VIDA1.FindControl("txtTotalREINSURANCEAmount"));
					//txtRopAmount = ((TextBox)VIDA1.FindControl("txtRopAmount"));
					txtAnnualPremium = ((TextBox)VIDA1.FindControl("txtAnnualPremium"));
					txtContributionPeriod = ((TextBox)VIDA1.FindControl("txtContributionPeriod"));
					txtMinAnnualPremium = ((TextBox)VIDA1.FindControl("txtMinAnnualPremium"));
					txtSubmittedDate = ((TextBox)VIDA1.FindControl("txtSubmittedDate"));
					txtLastPaymentDate = ((TextBox)VIDA1.FindControl("txtLastPaymentDate"));
					txtEfectiveDate = ((TextBox)VIDA1.FindControl("txtEfectiveDate"));
					txtTerminationDate = ((TextBox)VIDA1.FindControl("txtTerminationDate"));
					txtClientAcknowledgmentDate = ((TextBox)VIDA1.FindControl("txtClientAcknowledgmentDate"));
					txtPlannedExpirationDate = ((TextBox)VIDA1.FindControl("txtPlannedExpirationDate"));
					txtInsuredPeriod = ((TextBox)VIDA1.FindControl("txtInsuredPeriod"));
					txtExpiredDate = ((TextBox)VIDA1.FindControl("txtExpiredDate"));
					ddlPlanName = ((DropDownList)VIDA1.FindControl("ddlPlanName"));
					ddlPlanType = ((DropDownList)VIDA1.FindControl("ddlPlanType"));
					ddlCurrency = ((DropDownList)VIDA1.FindControl("ddlCurrency"));


					txtInsuranceInclusionDateEnd = ((TextBox)VIDA1.FindControl("txtInsuranceInclusionDateEnd"));
					txtInsuranceInclusionDate = ((TextBox)VIDA1.FindControl("txtInsuranceInclusionDate"));
					ddlInvestmentProfile = ((DropDownList)VIDA1.FindControl("ddlInvestmentProfile"));
					dvBtnPersonalizedProfile = ((Panel)VIDA1.FindControl("dvBtnPersonalizedProfile"));

					MVProducts.SetActiveView(VVida);
					break;
				#endregion

				#region Retirement
				case Tools.EFamilyProductType.Retirement:
					txtPolicy = ((TextBox)RETIRO.FindControl("txtPolicy"));
					txtInsuredName = ((TextBox)RETIRO.FindControl("txtInsuredName"));
					txtOwnerName = ((TextBox)RETIRO.FindControl("txtOwnerName"));
					txtAdditionalInsuredName = ((TextBox)RETIRO.FindControl("txtAdditionalInsuredName"));
					txtPolicyStatus = ((TextBox)RETIRO.FindControl("txtPolicyStatus"));
					txtInsuredAmount = ((TextBox)RETIRO.FindControl("txtInsuredAmount"));
					txtTotalInsuredAmount = ((TextBox)RETIRO.FindControl("txtTotalInsuredAmount"));
					txtCumulativeRisk = ((TextBox)RETIRO.FindControl("txtCumulativeRisk"));
					txtRetention = ((TextBox)RETIRO.FindControl("txtRetention"));
					txtInitialContribution = ((TextBox)RETIRO.FindControl("txtInitialContribution"));
					txtTargetPremium = ((TextBox)RETIRO.FindControl("txtTargetPremium"));
					txtREINSURANCEAMOUNT = ((TextBox)RETIRO.FindControl("txtREINSURANCEAMOUNT"));
					txtTotalRetention = ((TextBox)RETIRO.FindControl("txtTotalRetention"));
					txtPeriodicPremium = ((TextBox)RETIRO.FindControl("txtPeriodicPremium"));
                    ddlPaymentFrecuency = ((DropDownList)RETIRO.FindControl("ddlPaymentFrecuency"));
					txtTotalREINSURANCEAmount = ((TextBox)RETIRO.FindControl("txtTotalREINSURANCEAmount"));
					//txtRopAmount = ((TextBox)VIDA1.FindControl("txtRopAmount"));
					txtAnnualPremium = ((TextBox)RETIRO.FindControl("txtAnnualPremium"));
					txtContributionPeriod = ((TextBox)RETIRO.FindControl("txtContributionPeriod"));
					txtMinAnnualPremium = ((TextBox)RETIRO.FindControl("txtMinAnnualPremium"));
					txtSubmittedDate = ((TextBox)RETIRO.FindControl("txtSubmittedDate"));
					txtLastPaymentDate = ((TextBox)RETIRO.FindControl("txtLastPaymentDate"));
					txtEfectiveDate = ((TextBox)RETIRO.FindControl("txtEfectiveDate"));
					txtTerminationDate = ((TextBox)RETIRO.FindControl("txtTerminationDate"));
					txtClientAcknowledgmentDate = ((TextBox)RETIRO.FindControl("txtClientAcknowledgmentDate"));
					txtPlannedExpirationDate = ((TextBox)RETIRO.FindControl("txtPlannedExpirationDate"));
					txtInsuredPeriod = ((TextBox)RETIRO.FindControl("txtInsuredPeriod"));
					txtExpiredDate = ((TextBox)RETIRO.FindControl("txtExpiredDate"));
					ddlPlanName = ((DropDownList)RETIRO.FindControl("ddlPlanName"));
					ddlPlanType = ((DropDownList)RETIRO.FindControl("ddlPlanType"));
					ddlCurrency = ((DropDownList)RETIRO.FindControl("ddlCurrency"));


					txtInsuranceInclusionDateEnd = ((TextBox)RETIRO.FindControl("txtInsuranceInclusionDateEnd"));
					txtInsuranceInclusionDate = ((TextBox)RETIRO.FindControl("txtInsuranceInclusionDate"));
					ddlInvestmentProfile = ((DropDownList)RETIRO.FindControl("ddlInvestmentProfile"));

					/*retiron */
					txtTotalBenefitAmount = ((TextBox)RETIRO.FindControl("txtTotalBenefitAmount"));
					txtAnnualBenefitAmount = ((TextBox)RETIRO.FindControl("txtAnnualBenefitAmount"));
					txtRetirementAge = ((TextBox)RETIRO.FindControl("txtRetirementAge"));
					txtDefferalPeriod = ((TextBox)RETIRO.FindControl("txtDefferalPeriod"));

					dvBtnPersonalizedProfile = ((Panel)RETIRO.FindControl("dvBtnPersonalizedProfile"));

					MVProducts.SetActiveView(VRetiro);
					break;
				#endregion

				#region Education
				case Tools.EFamilyProductType.Education:
					txtPolicy = ((TextBox)EDUCACION.FindControl("txtPolicy"));
					txtInsuredName = ((TextBox)EDUCACION.FindControl("txtInsuredName"));
					txtOwnerName = ((TextBox)EDUCACION.FindControl("txtOwnerName"));
					txtAdditionalInsuredName = ((TextBox)EDUCACION.FindControl("txtAdditionalInsuredName"));
					txtPolicyStatus = ((TextBox)EDUCACION.FindControl("txtPolicyStatus"));
					txtInsuredAmount = ((TextBox)EDUCACION.FindControl("txtInsuredAmount"));
					txtTotalInsuredAmount = ((TextBox)EDUCACION.FindControl("txtTotalInsuredAmount"));
					txtCumulativeRisk = ((TextBox)EDUCACION.FindControl("txtCumulativeRisk"));
					txtRetention = ((TextBox)EDUCACION.FindControl("txtRetention"));
					txtInitialContribution = ((TextBox)EDUCACION.FindControl("txtInitialContribution"));
					txtTargetPremium = ((TextBox)EDUCACION.FindControl("txtTargetPremium"));
					txtREINSURANCEAMOUNT = ((TextBox)EDUCACION.FindControl("txtREINSURANCEAMOUNT"));
					txtTotalRetention = ((TextBox)EDUCACION.FindControl("txtTotalRetention"));
					txtPeriodicPremium = ((TextBox)EDUCACION.FindControl("txtPeriodicPremium"));
                    ddlPaymentFrecuency = ((DropDownList)EDUCACION.FindControl("ddlPaymentFrecuency"));
					txtTotalREINSURANCEAmount = ((TextBox)EDUCACION.FindControl("txtTotalREINSURANCEAmount"));
					//txtRopAmount = ((TextBox)VIDA1.FindControl("txtRopAmount"));
					txtAnnualPremium = ((TextBox)EDUCACION.FindControl("txtAnnualPremium"));
					txtContributionPeriod = ((TextBox)EDUCACION.FindControl("txtContributionPeriod"));
					txtMinAnnualPremium = ((TextBox)EDUCACION.FindControl("txtMinAnnualPremium"));
					txtSubmittedDate = ((TextBox)EDUCACION.FindControl("txtSubmittedDate"));
					txtLastPaymentDate = ((TextBox)EDUCACION.FindControl("txtLastPaymentDate"));
					txtEfectiveDate = ((TextBox)EDUCACION.FindControl("txtEfectiveDate"));
					txtTerminationDate = ((TextBox)EDUCACION.FindControl("txtTerminationDate"));
					txtClientAcknowledgmentDate = ((TextBox)EDUCACION.FindControl("txtClientAcknowledgmentDate"));
					txtPlannedExpirationDate = ((TextBox)EDUCACION.FindControl("txtPlannedExpirationDate"));
					txtInsuredPeriod = ((TextBox)EDUCACION.FindControl("txtInsuredPeriod"));
					txtExpiredDate = ((TextBox)EDUCACION.FindControl("txtExpiredDate"));
					ddlPlanName = ((DropDownList)EDUCACION.FindControl("ddlPlanName"));
					ddlPlanType = ((DropDownList)EDUCACION.FindControl("ddlPlanType"));
					ddlCurrency = ((DropDownList)EDUCACION.FindControl("ddlCurrency"));


					txtInsuranceInclusionDateEnd = ((TextBox)EDUCACION.FindControl("txtInsuranceInclusionDateEnd"));
					txtInsuranceInclusionDate = ((TextBox)EDUCACION.FindControl("txtInsuranceInclusionDate"));
					ddlInvestmentProfile = ((DropDownList)EDUCACION.FindControl("ddlInvestmentProfile"));

					/*retiron */
					txtTotalBenefitAmount = ((TextBox)EDUCACION.FindControl("txtTotalBenefitAmount"));
					txtAnnualBenefitAmount = ((TextBox)EDUCACION.FindControl("txtAnnualBenefitAmount"));
					txtRetirementAge = ((TextBox)EDUCACION.FindControl("txtRetirementAge"));
					txtDefferalPeriod = ((TextBox)EDUCACION.FindControl("txtDefferalPeriod"));

					/*educacion */
					txtStudentAge = ((TextBox)EDUCACION.FindControl("txtStudentAge"));
					txtEducationPeriod = ((TextBox)EDUCACION.FindControl("txtEducationPeriod"));

					dvBtnPersonalizedProfile = ((Panel)EDUCACION.FindControl("dvBtnPersonalizedProfile"));

					MVProducts.SetActiveView(VEducacion);
					break;
				#endregion
			}
            //Funeral
			FillDataTextBox
				(
					ref  txtPolicy
					, ref  txtInsuredName
					, ref  txtOwnerName
					, ref  txtAdditionalInsuredName
					, ref  txtPolicyStatus
					, ref  txtInsuredAmount
					, ref  txtTotalInsuredAmount
					, ref  txtCumulativeRisk
					, ref  txtRetention
					, ref  txtInitialContribution
					, ref  txtTargetPremium
					, ref  txtREINSURANCEAMOUNT
					, ref  txtTotalRetention
					, ref  txtPeriodicPremium
                    , ref  txtFraccionamiento /*mavelar 4/29/17*/
                    , ref  txtPrimaComercial /*Bmarroquin 05/05/17*/
                    , ref  ddlPaymentFrecuency
					, ref  txtTotalREINSURANCEAmount
					, ref  txtRopAmount
					, ref  txtAnnualPremium
					, ref  txtContributionPeriod
					, ref  txtMinAnnualPremium
					, ref  txtSubmittedDate
					, ref  txtLastPaymentDate
					, ref  txtEfectiveDate
					, ref  txtTerminationDate
					, ref  txtClientAcknowledgmentDate
					, ref  txtPlannedExpirationDate
					, ref  txtExpiredDate
					, ref  txtInsuredPeriod
					, ref  ddlPlanName
					, ref  ddlPlanType
					, ref  ddlCurrency

					/*para vida */
					, ref ddlInvestmentProfile
					, ref txtInsuranceInclusionDateEnd
					, ref txtInsuranceInclusionDate

					/*Retiro */
					, ref  txtTotalBenefitAmount
					, ref  txtAnnualBenefitAmount
					, ref  txtRetirementAge
					, ref  txtDefferalPeriod

					/*educacion */
					, ref  txtStudentAge
					, ref  txtEducationPeriod
					, ref dvBtnPersonalizedProfile
					, ref gvRiderBenefitAmount
					, ref gvRiderType
					, datos
				);
		}

		public void clearData()
		{
			throw new NotImplementedException();
		}

		#region FillDataTextBox
		private void FillDataTextBox
			(
				  ref TextBox txtPolicy
				, ref TextBox txtInsuredName
				, ref TextBox txtOwnerName
				, ref TextBox txtAdditionalInsuredName
				, ref TextBox txtPolicyStatus
				, ref TextBox txtInsuredAmount
				, ref TextBox txtTotalInsuredAmount
				, ref TextBox txtCumulativeRisk
				, ref TextBox txtRetention
				, ref TextBox txtInitialContribution
				, ref TextBox txtTargetPremium
				, ref TextBox txtREINSURANCEAMOUNT
				, ref TextBox txtTotalRetention
				, ref TextBox txtPeriodicPremium
                , ref TextBox txtFraccionamiento //mavelar 4/29/17
                , ref TextBox txtPrimaComercial //Bmarrqouin 05/05/17
                , ref DropDownList ddlPaymentFrecuency
				, ref TextBox txtTotalREINSURANCEAmount
				, ref TextBox txtRopAmount
				, ref TextBox txtAnnualPremium
				, ref TextBox txtContributionPeriod
				, ref TextBox txtMinAnnualPremium
				, ref TextBox txtSubmittedDate
				, ref TextBox txtLastPaymentDate
				, ref TextBox txtEfectiveDate
				, ref TextBox txtTerminationDate
				, ref TextBox txtClientAcknowledgmentDate
				, ref TextBox txtPlannedExpirationDate
				, ref TextBox txtExpiredDate
				, ref TextBox txtInsuredPeriod
				, ref DropDownList ddlPlanName
				, ref DropDownList ddlPlanType
				, ref DropDownList ddlCurrency

			  /*para vida */
				, ref DropDownList ddlInvestmentProfile
				, ref TextBox txtInsuranceInclusionDateEnd
				, ref TextBox txtInsuranceInclusionDate

			 /*Retiro */
			   , ref TextBox txtTotalBenefitAmount
			   , ref TextBox txtAnnualBenefitAmount
			   , ref TextBox txtRetirementAge
			   , ref TextBox txtDefferalPeriod

			   /*Retiro */
			   , ref TextBox txtStudentAge
			   , ref TextBox txtEducationPeriod
			   , ref Panel dvBtnPersonalizedProfile
			   , ref GridView gvRiderBenefitAmount
			   , ref GridView gvRiderType
			   , Entity.UnderWriting.Entities.Policy.PlanData datos

			)
		{
			if (datos == null) return;
			if (txtPolicy != null)
				txtPolicy.Text = datos.PolicyNo;

			if (txtInsuredName != null)
				txtInsuredName.Text = datos.InsuredName;

			if (txtOwnerName != null)
				txtOwnerName.Text = datos.OwnerName;

			if (txtAdditionalInsuredName != null)
				txtAdditionalInsuredName.Text = datos.AdditionalInsured;

			if (txtPolicyStatus != null)
				txtPolicyStatus.Text = datos.PolicyStatus;

			if (txtInsuredAmount != null)
				txtInsuredAmount.Text = (datos.InsuredAmount ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtTotalInsuredAmount != null)
				txtTotalInsuredAmount.Text = (datos.CumulativeRisk ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtCumulativeRisk != null)
				txtCumulativeRisk.Text = (datos.CumulativeRisk ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtRetention != null)
				txtRetention.Text = (datos.RetentionAmount ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtInitialContribution != null)
				txtInitialContribution.Text = (datos.InitialContribution ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtInitialContribution != null)
				txtInitialContribution.Text = (datos.InitialContribution ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtTargetPremium != null)
				txtTargetPremium.Text = (datos.TargetPremium ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtREINSURANCEAMOUNT != null)
				txtREINSURANCEAMOUNT.Text = (datos.ReinsuredAmount ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtTotalRetention != null)
				txtTotalRetention.Text = (datos.RetentionAmountTotal ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtPeriodicPremium != null)
				txtPeriodicPremium.Text = (datos.PeriodicPremium ?? decimal.Parse("0.00")).ToString("#,##0.00");
            
            //mavelar 4/29/17
            if (txtFraccionamiento != null)
                txtFraccionamiento.Text = (datos.Fraction_Surcharge ?? decimal.Parse("0.00")).ToString("#,##0.00");

            //Bmarroquin 05/05/17
            if (txtPrimaComercial != null)
                txtPrimaComercial.Text = (datos.NetAnnualPremium ?? decimal.Parse("0.00")).ToString("#,##0.00");

            if (ddlPaymentFrecuency != null)
                _dropDowns.GetDropDown(ref ddlPaymentFrecuency, Language.English, DropDownType.PaymentFrequency, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
                UnderWriting.Common.Tools.SelectIndexByValue(ref ddlPaymentFrecuency, datos.PaymentFreqTypeId.ToString());
               //ddlPaymentFrecuency.Text = datos.PaymentCycle;
            
			if (txtTotalREINSURANCEAmount != null)
				txtTotalREINSURANCEAmount.Text = (datos.ReinsuredAmountTotal ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtSubmittedDate != null)
				txtSubmittedDate.Text = (datos.SubmittedDate.HasValue ? datos.SubmittedDate.Value.ToShortDateString() : "");

			if (txtLastPaymentDate != null)
				txtLastPaymentDate.Text = (datos.LastPaymentDate.HasValue ? datos.LastPaymentDate.Value.ToShortDateString() : "");

			if (txtEfectiveDate != null)
				txtEfectiveDate.Text = (datos.EffectiveDate.HasValue ? datos.EffectiveDate.Value.ToShortDateString() : "");

			if (txtTerminationDate != null)
				txtTerminationDate.Text = (datos.TerminationDate.HasValue ? datos.TerminationDate.Value.ToShortDateString() : "");

			if (txtRopAmount != null)
				txtRopAmount.Text = (datos.ReturnAmount ?? decimal.Parse("0.00")).ToString("#,##0.00");//(datos.RopAmount ?? decimal.Parse("0.00")).ToString("#,##0.00"); //Lgonzalez 18-03-2017

            if (txtAnnualPremium != null)
				txtAnnualPremium.Text = (datos.AnnualPremium ?? decimal.Parse("0.00")).ToString("#,##0.00");

			if (txtContributionPeriod != null)
				txtContributionPeriod.Text = (datos.ContributionPeriod ?? int.Parse("0.00")).ToString();

			if (txtMinAnnualPremium != null)
				txtMinAnnualPremium.Text = datos.MinAnnualPremium.HasValue ? datos.MinAnnualPremium.Value.ToString("#,##0.00") : "0.00";

			if (ddlPlanName != null)
			{
				_dropDowns.GetDropDown(ref ddlPlanName, Language.English, DropDownType.Product, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
				Tools.SelectIndexByValue(ref ddlPlanName, datos.ProductId + "|" + datos.BlTypeId + "|" + datos.BlId);
			}

			if (ddlPlanType != null)
			{
				_dropDowns.GetDropDown(ref ddlPlanType, Language.English, DropDownType.Serie, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
                Tools.SelectIndexByValue(ref ddlPlanType, datos.BlTypeId + "|" + datos.BlId);
			}

			if (ddlCurrency != null)
			{
				_dropDowns.GetDropDown(ref ddlCurrency, Language.English, DropDownType.Currency, Service.Corp_Id, projectId: Service.ProjectId, companyId: Service.CompanyId);
				Tools.SelectIndexByValue(ref ddlCurrency, datos.CorpId + "|" + (datos.CurrencyId ?? 0));
			}


			if (ddlInvestmentProfile != null)
			{
				var parentDivName = ddlInvestmentProfile.Attributes["alt"];

				hdnBtnProfile.Value = "#" + parentDivName + "|false";
				//dvBtnPersonalizedProfile.Attributes.Add("style", "display: none;");
				var ddlData = _dropDowns.GetDropDown(DropDownType.ProfileType, Service.Corp_Id, currencyId: datos.CurrencyId ?? 0, projectId: Service.ProjectId, companyId: Service.CompanyId);

				if (ddlData != null)
				{
					ddlInvestmentProfile.DataSource = ddlData;
					ddlInvestmentProfile.Items.Clear();
					ddlInvestmentProfile.DataTextField = "Text";
					ddlInvestmentProfile.DataValueField = "Value";
					ddlInvestmentProfile.DataBind();
					ddlInvestmentProfile.Items.Insert(0, new ListItem { Text = "Select", Value = "-1" });

					var selectedValue = ddlData.Where(r => r.Value.Split('|')[0] == datos.ProfileTypeId.ToString());
					ddlInvestmentProfile.SelectedValue = !selectedValue.Any() ? "-1" : selectedValue.First().Value;

					if (dvBtnPersonalizedProfile == null || !selectedValue.Any()) return;

					var valSplit = selectedValue.First().Value.Split('|');

					hdnBtnProfile.Value = "#" + parentDivName + "|" + (valSplit.Count() < 2 ? "false" : valSplit[1].ToLower());

					dvBtnPersonalizedProfile.Attributes.Add("style", "display: " + (valSplit.Count() < 2 ? "none" : valSplit[1].ToLower() == "true" ? "block" : "none") + " ;");
				}
			}

			if (gvRiderType != null && gvRiderBenefitAmount != null)
			{
				Entity.UnderWriting.Entities.Policy.Parameter PolicyParameter = new Entity.UnderWriting.Entities.Policy.Parameter();
				//Nuevo Forma Cambio Rabel O
				PolicyParameter.CorpId = Service.Corp_Id;
				PolicyParameter.RegionId = Service.Region_Id;
				PolicyParameter.CountryId = Service.Country_Id;
				PolicyParameter.DomesticregId = Service.Domesticreg_Id;
				PolicyParameter.StateProvId = Service.State_Prov_Id;
				PolicyParameter.CityId = Service.City_Id;
				PolicyParameter.OfficeId = Service.Office_Id;
				PolicyParameter.CaseSeqNo = Service.Case_Seq_No;
				PolicyParameter.HistSeqNo = Service.Hist_Seq_No;
				PolicyParameter.LanguageId = Service.LanguageId;

				var riderData = Services.RiderManager.GetAllRider(PolicyParameter).OrderBy(r => r.RyderTypeDesc);

				gvRiderType.DataSource = riderData;
				gvRiderType.DataBind();

				gvRiderBenefitAmount.DataSource = riderData;
				gvRiderBenefitAmount.DataBind();
			}


			/*debo revisar*/
			if (txtClientAcknowledgmentDate != null)
				//2016-02-03 | Marcos J. Perez
				//A solicitud del usuario no se mostrara informacion.
				//Se coloco en comentario del valor retornado hasta que el usuario indique cual es el dato a presentar.
				txtClientAcknowledgmentDate.Text = "";// (datos.SubmittedDate.HasValue ? datos.SubmittedDate.Value.ToShortDateString() : "");

			/*debo revisar*/
			if (txtPlannedExpirationDate != null)
				txtPlannedExpirationDate.Text = (datos.ExpiredDate.HasValue ? datos.ExpiredDate.Value.ToShortDateString() : "");

			/*debo revisar*/
			if (txtExpiredDate != null)
				txtExpiredDate.Text = (datos.ExpiredDate.HasValue ? datos.ExpiredDate.Value.ToShortDateString() : "");

			/*debo revisar*/
			if (txtInsuredPeriod != null)
				txtInsuredPeriod.Text = (datos.InsuredPeriod.ToString());
            
			/*debo revisar*/
			if (txtInsuranceInclusionDateEnd != null)
				txtInsuranceInclusionDateEnd.Text = "";

			/*debo revisar*/
			if (txtInsuranceInclusionDate != null)
				txtInsuranceInclusionDate.Text = "";


			/*esto es retiro*/
			/*debo revisar*/
			if (txtAnnualBenefitAmount != null)
				txtAnnualBenefitAmount.Text = "";
			/*debo revisar*/
			if (txtRetirementAge != null)
				txtRetirementAge.Text = "";
			/*debo revisar*/
			if (txtDefferalPeriod != null)
				txtDefferalPeriod.Text = "";

			/*debo revisar*/
			if (txtTotalBenefitAmount != null)
				txtTotalBenefitAmount.Text = "";

			/*esto es educacion*/
			/*debo revisar*/
			if (txtStudentAge != null)
				txtStudentAge.Text = "";
			/*debo revisar*/
			if (txtEducationPeriod != null)
				txtEducationPeriod.Text = "";
		}
		#endregion

		public void FillProfileData(int selectedProfileId)
		{
			var data = Services.PolicyManager.GetInvestProfilePersonalized(
						Service.Corp_Id,
						Service.Region_Id,
						Service.Country_Id,
						Service.Domesticreg_Id,
						Service.State_Prov_Id,
						Service.City_Id,
						Service.Office_Id,
						Service.Case_Seq_No,
						Service.Hist_Seq_No,
						selectedProfileId);



			UCPopPerzonalizedProfile1.FillData(data);
			hdnVisiblePopProfile.Value = "true";
		}

	}
}