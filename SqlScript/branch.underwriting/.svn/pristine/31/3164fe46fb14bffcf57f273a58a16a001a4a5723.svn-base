using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSAnnuityFixedResult : WSAnnuityResult
    {
        /*
        public List<WSAnnuityIllusData> annuityfixedillusdatalist { get; set; }

        //public List<WSAnnuityIllusData> annuitygrowthillusdatalist { get; set; }
        public double annuityamount { get; set; }
        public double totalannuityamount { get; set; }
        public double minimumpremiumamount { get; set; }
        */

        public static WSAnnuityResult getAnnuityFixedResult(IMaineduretirefixed eduretirefixed, WSCustomer customer, WSCustomerPlan custplan)
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



            //IMaineduretirefixed eduretirefixed = new IMaineduretirefixed(Sessionclass.getSessiondata(Session).customerplanno);
            //DataTable dt3 = new DataTable();

            annuityresult.insuredamount = eduretirefixed.getInsuredamountFE();

            annuityresult.annuityamount = eduretirefixed.annuityamount;
            annuityresult.periodicpremiumamount = eduretirefixed.calculatedPeriodicPremiumAmount();

           // annuityresult.annualpremiumamount = eduretirefixed.Yearlypremiumamount;
            annuityresult.annualpremiumamount = eduretirefixed.calculatedPeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);

            if (eduretirefixed.getInsuredamountFE() != 0)
            {
                annuityresult.totalinsuredamount =eduretirefixed.getInsuredamountFE();
            }
            
            annuityresult.totalannuityamount = eduretirefixed.annuityamount * custplan.annuityperiod;
            //Sessionclass.getSessiondata(Session).totalinsuredamt = txttotinsuredamt.Text;

            annuityresult.minimumpremiumamount= 0;
            //Sessionclass.getSessiondata(Session).mindata = txtminpremium.Text;

            annuityresult.targetpremiumamount= eduretirefixed.getTargetamountFE();
            //Sessionclass.getSessiondata(Session).targetdata = txttargetpremium.Text;


            
            


            
            REDIllusdata[] illus = eduretirefixed.getIllustration();
            annuityresult.annuityillusdatalist = (from item in illus
                                                        select new WSAnnuityIllusData() { accountvalue = item.Accountvalue, accumulatedpremium = item.Accumulatedpremium, age = item.Age, annuityamount = item.Annuityamount, commission = item.Commission, costofinsurance = item.Costofinsurance, deathbenefit = item.Deathbenefit, discbenefit = item.Discbenefit, isdynamicgrowthrate = item.isdynamicgrowthrate.ToString(), partialretirementamount = item.Partialretirementamount, penaltyvalue = item.Penaltyvalue, premium = item.Premium, rescatevalue = item.Rescatevalue, sno = item.Sno }).ToList();

            annuityresult.primaryexamsrequiredlist = WSAnnuityFixedResult.getPrimaryExamsRequiredList(annuityresult, customer, custplan);


            return annuityresult;

        }

        public static WSAnnuityResult getAnnuityFixedResultIllustration(IMaineduretirefixed eduretirefixed, WSCustomer customer, WSCustomerPlanAnnuity custplan)
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



            //IMaineduretirefixed eduretirefixed = new IMaineduretirefixed(Sessionclass.getSessiondata(Session).customerplanno);
            //DataTable dt3 = new DataTable();

            annuityresult.insuredamount = eduretirefixed.getInsuredamountFE();

            annuityresult.annuityamount = eduretirefixed.annuityamount;
            annuityresult.periodicpremiumamount = eduretirefixed.calculatedPeriodicPremiumAmount();

           // annuityresult.annualpremiumamount = eduretirefixed.Yearlypremiumamount;
            annuityresult.annualpremiumamount = eduretirefixed.calculatedPeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);


            if (eduretirefixed.getInsuredamountFE() != 0)
            {
                annuityresult.totalinsuredamount = eduretirefixed.getInsuredamountFE();
            }

            annuityresult.totalannuityamount = eduretirefixed.annuityamount * custplan.annuityperiod;
            //Sessionclass.getSessiondata(Session).totalinsuredamt = txttotinsuredamt.Text;

            annuityresult.minimumpremiumamount = 0;
            //Sessionclass.getSessiondata(Session).mindata = txtminpremium.Text;

            annuityresult.targetpremiumamount = eduretirefixed.getTargetamountFE();
            //Sessionclass.getSessiondata(Session).targetdata = txttargetpremium.Text;







            REDIllusdata[] illus = eduretirefixed.getIllustration();
            annuityresult.annuityillusdatalist = (from item in illus
                                                  select new WSAnnuityIllusData() { accountvalue = item.Accountvalue, accumulatedpremium = item.Accumulatedpremium, age = item.Age, annuityamount = item.Annuityamount, commission = item.Commission, costofinsurance = item.Costofinsurance, deathbenefit = item.Deathbenefit, discbenefit = item.Discbenefit, isdynamicgrowthrate = item.isdynamicgrowthrate.ToString(), partialretirementamount = item.Partialretirementamount, penaltyvalue = item.Penaltyvalue, premium = item.Premium, rescatevalue = item.Rescatevalue, sno = item.Sno }).ToList();


            annuityresult.primaryexamsrequiredlist = WSAnnuityFixedResult.getPrimaryExamsRequiredList(annuityresult, customer, custplan);

            return annuityresult;

        }
        protected static List<WSExam> getPrimaryExamsRequiredList(WSResult result, WSCustomer customer, WSCustomerPlan custplan)
        {
            List<WSRider> riderslist = new List<WSRider>();
            return WSResult.getPrimaryExamsRequiredList(result, customer, custplan, riderslist);
        }

    }
}