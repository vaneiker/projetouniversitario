using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation
{
    public partial class UCAxysSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void FillData(
            string illustrationNo = null
            , string productName = null
            , string currency = null
            , string insuredName = null
            , string ownerName = null
            , string retireeStudentAdditionalName = null
            , string age = null
            , string initialContribution = null
            , string frequencyOfPayment = null
            , string investmentProfile = null
            , string risk = null
            , string perThousand = null
            , string accidentalDeath = null
            , string additionalTemporary = null
            , string otherInsured = null
            , string criticalIllness = null
            , string gastosfunerarios = null  /*Adicionado el 3/02/2017 Merlyn Avelar*/

            )
        {
            ltrPlanTitle.Text = "#" + illustrationNo;
            var data = new Dictionary<string, string>
            {
                    {RESOURCE.UnderWriting.NewBussiness.Resources.Illustration + "#", illustrationNo},
                    {RESOURCE.UnderWriting.NewBussiness.Resources.ProductName , productName},
                    {RESOURCE.UnderWriting.NewBussiness.Resources.Currency , currency},
                    {RESOURCE.UnderWriting.NewBussiness.Resources.InsuredName , insuredName},
                    {RESOURCE.UnderWriting.NewBussiness.Resources.OwnerName , ownerName}
            };
            if (productName.ToUpper().Contains("VIDA CREDITO")) 
            {
                productName = "Vida Cred";
            }
            if (productName.ToLower().Contains("selec"))
                productName = "None";

            var productBehavior = (Utility.ProductBehavior)Utility.getvalueFromEnumType(productName.Replace(" ", "").Replace("Básico", ""), typeof(Utility.ProductBehavior));
            switch (productBehavior)
            {
                case Utility.ProductBehavior.Axys:
                case Utility.ProductBehavior.CompassIndex:
                case Utility.ProductBehavior.Horizon:
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.RetireeName, retireeStudentAdditionalName);
                    break;
                case Utility.ProductBehavior.EduPlan:
                case Utility.ProductBehavior.Scholar:
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.StudentNameLabel, retireeStudentAdditionalName);
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.Age, age);
                    break;
                case Utility.ProductBehavior.Lighthouse:
                case Utility.ProductBehavior.Legacy:
                case Utility.ProductBehavior.Sentinel:
                case Utility.ProductBehavior.Guardian:
                case Utility.ProductBehavior.GuardianPlus:
                case Utility.ProductBehavior.Orion:
                case Utility.ProductBehavior.OrionPlus:
                case Utility.ProductBehavior.VIDACRED:
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.AdditionalInsured.Capitalize(), otherInsured);
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.CriticalIllnessLabel, criticalIllness);
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.AccidentalDeathBenefitsLabel, accidentalDeath);
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.AdditionalTermInsuranceLabel, additionalTemporary);
					/*Adicionado el 3/02/2017 Merlyn Avelar*/
                    //data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.FuneralExpenses, otherInsured);
                    data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.FuneralExpenses, gastosfunerarios);

                    break;
                case Utility.ProductBehavior.Luminis:
                    break;
                case Utility.ProductBehavior.LuminisVIP:
                    break;
                case Utility.ProductBehavior.Exequium:
                    break;
                case Utility.ProductBehavior.ExequiumVIP:
                    break;
                case Utility.ProductBehavior.None:
                default:
                    break;
            }

            if (new[] { 
                Utility.ProductBehavior.Axys, 
                Utility.ProductBehavior.CompassIndex, 
                Utility.ProductBehavior.Scholar 
            }.Contains(productBehavior))
                data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.InvestmentProfile, investmentProfile);

            data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.InitialContributionLabel, initialContribution);
            data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.FrequencyofPaymentLabel, frequencyOfPayment);
            data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.Risk, risk);
            data.Add(RESOURCE.UnderWriting.NewBussiness.Resources.PerThousand, perThousand);

            rpPlanSummary.DataSource = data;
            rpPlanSummary.DataBind();
        }
    }
}