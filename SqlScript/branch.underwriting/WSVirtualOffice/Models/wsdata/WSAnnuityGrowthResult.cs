using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSAnnuityGrowthResult : WSAnnuityResult
    {

        public static WSAnnuityResult getAnnuityGrowthResult(IMaineduretire eduretire, WSCustomer customer, WSCustomerPlan custplan)
        {
            //this.annuityresult = annuityresult;
            WSAnnuityResult annuityresult = new WSAnnuityResult();
            //annuityresult.insuredamount = annuityresult.getInsuredamountFE();
            //annuityresult.annualpremiumamount = annuityresult.getAnnualizedPeriodicPremium();
            //annuityresult.periodicpremiumamount = annuityresult.calculatedPeriodicPremiumAmount();
            //annuityresult.targetpremiumamount = annuityresult.getTargetamountFE();
            //annuityresult.totalinsuredamount = annuityresult.getInsuredamountFE() + annuityresult.Ridertermamount;
            annuityresult.ropamount = 0;
           
            annuityresult.errorslist = WSResult.validateDataaftercalculate(annuityresult, customer, custplan, new List<WSRider>(), null);


            //IMaineduretire eduretire = new IMaineduretire(Sessionclass.getSessiondata(Session).customerplanno);

            annuityresult.insuredamount = eduretire.getInsuredAmountFE();
            
            annuityresult.annuityamount = eduretire.annuityamount;
            annuityresult.periodicpremiumamount = eduretire.calculatedPeriodicPremiumAmount();
           // annuityresult.annualpremiumamount = eduretire.calculatedYearlyPremiumAmount();
            annuityresult.annualpremiumamount = eduretire.calculatedPeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);
            if (eduretire.getInsuredAmountFE() != 0)
            {
                annuityresult.insuredamount = eduretire.getInsuredAmountFE();
            }
            
            annuityresult.totalannuityamount= eduretire.annuityamount * custplan.annuityperiod;

            annuityresult.minimumpremiumamount = eduretire.getMinimumPremiumAmountFE();
            annuityresult.targetpremiumamount = eduretire.getTargetAmountFE();

            /*
            Illusdata[] illus = insmaindata.getIllustration();
            liferesult.lifeillusdatalist = (from item in illus
                                            select new WSLifeIllusData() { acdbpremium = item.Acdbpremium, adbpremium = item.Adbpremium, age = item.Age, cipremium = item.Cipremium, commission = item.Commission, costofinsurance = item.Costofinsurance, costofriders = item.Costofriders, isdynamicgrowthrate = item.isdynamicgrowthrate.ToString(), numscenarios = item.Numscenarios, oirpremium = item.Oirpremium, premium = item.Premium, ridersaccountvalue = item.Ridersaccountvalue, sno = item.Sno, termpremium = item.Termpremium }).ToList();
            */
            
            
            REDIllusdata[] illus = eduretire.getIllustration();
            annuityresult.annuityillusdatalist = (from item in illus
                                            select new WSAnnuityIllusData() { accountvalue=item.Accountvalue,accumulatedpremium=item.Accumulatedpremium,age=item.Age,annuityamount=item.Annuityamount,commission=item.Commission,costofinsurance=item.Costofinsurance,deathbenefit=item.Deathbenefit,discbenefit=item.Discbenefit,isdynamicgrowthrate=item.isdynamicgrowthrate.ToString(),partialretirementamount=item.Partialretirementamount,penaltyvalue=item.Penaltyvalue,premium=item.Premium,rescatevalue=item.Rescatevalue,sno=item.Sno }).ToList();


            annuityresult.primaryexamsrequiredlist = WSAnnuityGrowthResult.getPrimaryExamsRequiredList(annuityresult, customer, custplan);
            

            return annuityresult;

        }
        public static WSAnnuityResult getAnnuityGrowthResultIllustration(IMaineduretire eduretire, WSCustomer customer, WSCustomerPlan custplan)
        {
            //this.annuityresult = annuityresult;
            WSAnnuityResult annuityresult = new WSAnnuityResult();
            //annuityresult.insuredamount = annuityresult.getInsuredamountFE();
            //annuityresult.annualpremiumamount = annuityresult.getAnnualizedPeriodicPremium();
            //annuityresult.periodicpremiumamount = annuityresult.calculatedPeriodicPremiumAmount();
            //annuityresult.targetpremiumamount = annuityresult.getTargetamountFE();
            //annuityresult.totalinsuredamount = annuityresult.getInsuredamountFE() + annuityresult.Ridertermamount;
            annuityresult.ropamount = 0;
           
            annuityresult.errorslist = WSResult.validateDataaftercalculate(annuityresult, customer, custplan, new List<WSRider>(), null);


            //IMaineduretire eduretire = new IMaineduretire(Sessionclass.getSessiondata(Session).customerplanno);

            annuityresult.insuredamount = eduretire.getInsuredAmountFE();

            annuityresult.annuityamount = eduretire.annuityamount;
            annuityresult.periodicpremiumamount = eduretire.calculatedPeriodicPremiumAmount();
            //annuityresult.annualpremiumamount = eduretire.calculatedYearlyPremiumAmount();
            annuityresult.annualpremiumamount = eduretire.calculatedPeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);
            
            if (eduretire.getInsuredAmountFE() != 0)
            {
                annuityresult.insuredamount = eduretire.getInsuredAmountFE();
            }

            annuityresult.totalannuityamount = eduretire.annuityamount * custplan.annuityperiod;

            annuityresult.minimumpremiumamount = eduretire.getMinimumPremiumAmountFE();
            annuityresult.targetpremiumamount = eduretire.getTargetAmountFE();

            /*
            Illusdata[] illus = insmaindata.getIllustration();
            liferesult.lifeillusdatalist = (from item in illus
                                            select new WSLifeIllusData() { acdbpremium = item.Acdbpremium, adbpremium = item.Adbpremium, age = item.Age, cipremium = item.Cipremium, commission = item.Commission, costofinsurance = item.Costofinsurance, costofriders = item.Costofriders, isdynamicgrowthrate = item.isdynamicgrowthrate.ToString(), numscenarios = item.Numscenarios, oirpremium = item.Oirpremium, premium = item.Premium, ridersaccountvalue = item.Ridersaccountvalue, sno = item.Sno, termpremium = item.Termpremium }).ToList();
            */


            REDIllusdata[] illus = eduretire.getIllustration();
            annuityresult.annuityillusdatalist = (from item in illus
                                                  select new WSAnnuityIllusData() { accountvalue = item.Accountvalue, accumulatedpremium = item.Accumulatedpremium, age = item.Age, annuityamount = item.Annuityamount, commission = item.Commission, costofinsurance = item.Costofinsurance, deathbenefit = item.Deathbenefit, discbenefit = item.Discbenefit, isdynamicgrowthrate = item.isdynamicgrowthrate.ToString(), partialretirementamount = item.Partialretirementamount, penaltyvalue = item.Penaltyvalue, premium = item.Premium, rescatevalue = item.Rescatevalue, sno = item.Sno }).ToList();


            annuityresult.primaryexamsrequiredlist = WSAnnuityGrowthResult.getPrimaryExamsRequiredList(annuityresult, customer, custplan);


            return annuityresult;

        }
        protected static List<WSExam> getPrimaryExamsRequiredList(WSResult result, WSCustomer customer, WSCustomerPlan custplan)
        {
            List<WSRider> riderslist = new List<WSRider>();
            return WSResult.getPrimaryExamsRequiredList(result, customer, custplan,riderslist);
        }


    }
}