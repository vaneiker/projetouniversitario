using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSTermResult:WSResult
    {
        public List<WSTermillusdata> termillusdatalist { get; set; }
        public List<WSTermillusdata> termillusdatalisttwo { get; set; }
        public byte[] illuspdf { get; set; }
        public double Tax { get; set; }
        public double TotalPeriodicPremium { get; set; }
        public static  WSTermResult  getTermResult(IMaintermfixed termfixed,WSCustomer customer,WSCustomerPlan custplan,List<WSRider> riderslist,WSCustomerPlanPartner partins)
        {
            //this.termfixed = termfixed;
            WSTermResult termresult = new WSTermResult();
            termresult.insuredamount = termfixed.getInsuredamountFE();
            termresult.annualpremiumamount = termfixed.getAnnualizedPeriodicPremium();
            termresult.periodicpremiumamount = termfixed.calculatedPeriodicPremiumAmount();
            termresult.targetpremiumamount = termfixed.getTargetamountFE();
            termresult.totalinsuredamount= termfixed.getInsuredamountFE() + termfixed.Ridertermamount;
            termresult.ropamount = 0;

            //Lgonzalez 28-04-2017 */
            termresult.fractionsurcharge = termfixed.getFractionSurcharge();

            //termresult.errorslist = WSResult.validateDataaftercalculate(termresult, customer, custplan, riderslist, partins);
            Termillusdata[] termillus = termfixed.getIllustration();
            termresult.termillusdatalist = (from item in termillus
                                            select new WSTermillusdata() { sno = item.Sno, age = item.Age, regularpremium = item.Regularpremium,
                                                riderpremium = item.Riderpremium, totalpremium = item.Totalpremium,accumulatedpremium = item.Accumulatedpremium,
                                                totalbenefitamount = item.Totalbenefitamount, commission = item.Commission, costofinsurance = item.Costofinsurance,
                                            insuredamount = item.Insuredamount}).ToList();
            Termillusdata[] termillustwo = termfixed.getIllustrationtwo();
            termresult.termillusdatalisttwo = (from item in termillustwo
                                            select new WSTermillusdata()
                                            {
                                                sno = item.Sno,
                                                age = item.Age,
                                                regularpremium = item.Regularpremium,
                                                riderpremium = item.Riderpremium,
                                                totalpremium = item.Totalpremium,
                                                accumulatedpremium = item.Accumulatedpremium,
                                                totalbenefitamount = item.Totalbenefitamount,
                                                commission = item.Commission,
                                                costofinsurance = item.Costofinsurance,
                                                insuredamount = item.Insuredamount
                                            }).ToList();
            termresult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(termresult, customer, custplan, riderslist);
            termresult.partnerexamsrequiredlist = WSResult.getPartnerExamsRequiredList(termresult, custplan, partins);

            termresult.Tax = termresult.periodicpremiumamount * 0.16;
            termresult.TotalPeriodicPremium = termresult.periodicpremiumamount + termresult.Tax;
            return termresult;
            
        }

        public static WSTermResult getTermResultIllustrtaion(IMaintermfixed termfixed, WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            //this.termfixed = termfixed;
            WSTermResult termresult = new WSTermResult();
            termresult.insuredamount = termfixed.getInsuredamountFE();
            termresult.annualpremiumamount = termfixed.getAnnualizedPeriodicPremium();
            termresult.periodicpremiumamount = termfixed.calculatedPeriodicPremiumAmount();
            termresult.targetpremiumamount = termfixed.getTargetamountFE();
            termresult.totalinsuredamount = termfixed.getInsuredamountFE() + termfixed.Ridertermamount;
            termresult.ropamount = 0;
            termresult.fractionsurcharge = termfixed.getFractionSurcharge();
            termresult.errorslist = WSResult.validateDataaftercalculate(termresult, customer, custplan, riderslist, partins);
            Termillusdata[] termillus = termfixed.getIllustration();
            termresult.termillusdatalist = (from item in termillus
                                            select new WSTermillusdata()
                                            {
                                                sno = item.Sno,
                                                age = item.Age,
                                                regularpremium = item.Regularpremium,
                                                riderpremium = item.Riderpremium,
                                                totalpremium = item.Totalpremium,
                                                accumulatedpremium = item.Accumulatedpremium,
                                                totalbenefitamount = item.Totalbenefitamount,
                                                commission = item.Commission,
                                                costofinsurance = item.Costofinsurance,
                                                insuredamount = item.Insuredamount
                                            }).ToList();
            Termillusdata[] termillustwo = termfixed.getIllustrationtwo();
            termresult.termillusdatalisttwo = (from item in termillustwo
                                               select new WSTermillusdata()
                                               {
                                                   sno = item.Sno,
                                                   age = item.Age,
                                                   regularpremium = item.Regularpremium,
                                                   riderpremium = item.Riderpremium,
                                                   totalpremium = item.Totalpremium,
                                                   accumulatedpremium = item.Accumulatedpremium,
                                                   totalbenefitamount = item.Totalbenefitamount,
                                                   commission = item.Commission,
                                                   costofinsurance = item.Costofinsurance,
                                                   insuredamount = item.Insuredamount
                                               }).ToList();

            termresult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(termresult, customer, custplan, riderslist);
            termresult.partnerexamsrequiredlist = WSResult.getPartnerExamsRequiredList(termresult, custplan, partins);

            termresult.Tax = termresult.periodicpremiumamount * 0.16;
            termresult.TotalPeriodicPremium = termresult.periodicpremiumamount + termresult.Tax;

            return termresult;

        }




        public static WSTermResult getTermResultLS(IMaintermfixedLS termfixed, WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            //this.termfixed = termfixed;
            WSTermResult termresult = new WSTermResult();
            termresult.insuredamount = termfixed.getInsuredamountFE();
           // termresult.annualpremiumamount = termfixed.getAnnualizedPeriodicPremium();
            termresult.annualpremiumamount = termfixed.calculatedPeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);
            
            termresult.periodicpremiumamount = termfixed.calculatedPeriodicPremiumAmount();
            termresult.targetpremiumamount = termfixed.getTargetamountFE();
            termresult.totalinsuredamount = termfixed.getInsuredamountFE() + termfixed.Ridertermamount;
            termresult.ropamount = 0;
            termresult.errorslist = WSResult.validateDataaftercalculate(termresult, customer, custplan, riderslist, partins);
            Termillusdata[] termillus = termfixed.getIllustration();
            termresult.termillusdatalist = (from item in termillus
                                            select new WSTermillusdata()
                                            {
                                                sno = item.Sno,
                                                age = item.Age,
                                                regularpremium = item.Regularpremium,
                                                riderpremium = item.Riderpremium,
                                                totalpremium = item.Totalpremium,
                                                accumulatedpremium = item.Accumulatedpremium,
                                                totalbenefitamount = item.Totalbenefitamount,
                                                commission = item.Commission,
                                                costofinsurance = item.Costofinsurance,
                                                insuredamount = item.Insuredamount
                                            }).ToList();
            Termillusdata[] termillustwo = termfixed.getIllustrationtwo();
            termresult.termillusdatalisttwo = (from item in termillustwo
                                               select new WSTermillusdata()
                                               {
                                                   sno = item.Sno,
                                                   age = item.Age,
                                                   regularpremium = item.Regularpremium,
                                                   riderpremium = item.Riderpremium,
                                                   totalpremium = item.Totalpremium,
                                                   accumulatedpremium = item.Accumulatedpremium,
                                                   totalbenefitamount = item.Totalbenefitamount,
                                                   commission = item.Commission,
                                                   costofinsurance = item.Costofinsurance,
                                                   insuredamount = item.Insuredamount
                                               }).ToList();

            termresult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(termresult, customer, custplan, riderslist);
            termresult.partnerexamsrequiredlist = WSResult.getPartnerExamsRequiredList(termresult, custplan, partins);
            

            return termresult;

        }

        public static WSTermResult getTermResultIllustrtaionLS(IMaintermfixedLS termfixed, WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            //this.termfixed = termfixed;
            WSTermResult termresult = new WSTermResult();
            termresult.insuredamount = termfixed.getInsuredamountFE();
           // termresult.annualpremiumamount = termfixed.getAnnualizedPeriodicPremium();
            termresult.annualpremiumamount = termfixed.calculatedPeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);
            
            termresult.periodicpremiumamount = termfixed.calculatedPeriodicPremiumAmount();
            termresult.targetpremiumamount = termfixed.getTargetamountFE();
            termresult.totalinsuredamount = termfixed.getInsuredamountFE() + termfixed.Ridertermamount;
            termresult.ropamount = 0;
            termresult.errorslist = WSResult.validateDataaftercalculate(termresult, customer, custplan, riderslist, partins);
            Termillusdata[] termillus = termfixed.getIllustration();
            termresult.termillusdatalist = (from item in termillus
                                            select new WSTermillusdata()
                                            {
                                                sno = item.Sno,
                                                age = item.Age,
                                                regularpremium = item.Regularpremium,
                                                riderpremium = item.Riderpremium,
                                                totalpremium = item.Totalpremium,
                                                accumulatedpremium = item.Accumulatedpremium,
                                                totalbenefitamount = item.Totalbenefitamount,
                                                commission = item.Commission,
                                                costofinsurance = item.Costofinsurance,
                                                insuredamount = item.Insuredamount
                                            }).ToList();
            Termillusdata[] termillustwo = termfixed.getIllustrationtwo();
            termresult.termillusdatalisttwo = (from item in termillustwo
                                               select new WSTermillusdata()
                                               {
                                                   sno = item.Sno,
                                                   age = item.Age,
                                                   regularpremium = item.Regularpremium,
                                                   riderpremium = item.Riderpremium,
                                                   totalpremium = item.Totalpremium,
                                                   accumulatedpremium = item.Accumulatedpremium,
                                                   totalbenefitamount = item.Totalbenefitamount,
                                                   commission = item.Commission,
                                                   costofinsurance = item.Costofinsurance,
                                                   insuredamount = item.Insuredamount
                                               }).ToList();

            termresult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(termresult, customer, custplan, riderslist);
            termresult.partnerexamsrequiredlist = WSResult.getPartnerExamsRequiredList(termresult, custplan, partins);
            
            return termresult;

        }          
                    
                           
                    
       
    }
}

