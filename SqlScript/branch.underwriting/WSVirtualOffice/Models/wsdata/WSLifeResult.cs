using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSLifeResult:WSResult
    {
        public List<WSLifeIllusData> lifeillusdatalist{get;set;}
        public byte[] illuspdf { get; set; }
        public double minimumpremiumamount {get;set;}
        //public double totalinsuredamount {get;set;}

        public static WSLifeResult getLifeResult(IMainInsuranceData insmaindata, WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            //this.liferesult = liferesult;
            WSLifeResult liferesult = new WSLifeResult();
          //  liferesult.insuredamount = insmaindata.getInsuredamountFE();
            //liferesult.annualpremiumamount = liferesult.getAnnualizedPeriodicPremium();
          //  liferesult.periodicpremiumamount = insmaindata.calculatedPeriodicPremiumAmount();
            //liferesult.targetpremiumamount = liferesult.getTargetamountFE();
            //liferesult.totalinsuredamount = liferesult.getInsuredamountFE() + liferesult.Ridertermamount;
            liferesult.ropamount = 0;
                
            
            // insurance related special handling 
            IAssumeddata asdata = new IAssumeddata();
            IResultData resdata = new IResultData();
            if(custplan.calculatetypecode.ToCharArray()[0]==Calculatetypes.INSUREDAMOUNT)
            {
                asdata.premiumamount = insmaindata.annualizedpremiumamount;
                DateTime t1 = DateTime.Now;
                resdata= IAccountvalue.calculateInsuredamount(insmaindata, asdata);                
            }
            else if(custplan.calculatetypecode.ToCharArray()[0]==Calculatetypes.PREMIUMAMOUNT)
            {
                asdata.insuredamount = custplan.insuredamount;
                DateTime t1 = DateTime.Now;
                resdata = IAccountvalue.calculatePremiumamount(insmaindata, asdata);
            }
            else if(custplan.calculatetypecode.ToCharArray()[0]==Calculatetypes.VERIFY)
            {
                asdata.insuredamount = custplan.insuredamount;
                asdata.premiumamount = custplan.premiumamount;
                resdata = IAccountvalue.calculateNinguna(insmaindata, asdata);

            }

            liferesult.periodicpremiumamount  = insmaindata.calculatePeriodicPremiumAmount();
            liferesult.insuredamount= insmaindata.Calcinsuredamount;
            
            if ((insmaindata.Calcinsuredamount + insmaindata.ridertermamount) != 0)
            {
                liferesult.totalinsuredamount = insmaindata.Calcinsuredamount + insmaindata.ridertermamount;
            }
                        
          //  liferesult.annualpremiumamount = insmaindata.annualizedpremiumamount;
            liferesult.annualpremiumamount = insmaindata.calculatePeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);
            
            liferesult.targetpremiumamount =insmaindata.targetyearlyamount(resdata);
            liferesult.minimumpremiumamount=insmaindata.minimumyearlypremium(resdata);


            if (resdata.impossible == true)
            {                              
                List<WSValidationError> calcerrorslist = new List<WSValidationError>();
                calcerrorslist.Add(new WSValidationError() { errorfield = "", errormessage = insmaindata.planerrordata, errormessageespanol = "The calculation is impossible", errortype = WSErrorType.IS_BLANK, value = "" });
                liferesult.errorslist = calcerrorslist;
                return liferesult;
            }
            else
            {
                Illusdata[] illus = insmaindata.getIllustration();
                liferesult.lifeillusdatalist=(from item in illus
                                                select new WSLifeIllusData(){acdbpremium=item.Acdbpremium,adbpremium=item.Adbpremium,age=item.Age,cipremium=item.Cipremium,commission=item.Commission,costofinsurance=item.Costofinsurance,costofriders=item.Costofriders,isdynamicgrowthrate=item.isdynamicgrowthrate.ToString(),numscenarios=item.Numscenarios,oirpremium=item.Oirpremium,premium=item.Premium,ridersaccountvalue=item.Ridersaccountvalue,sno=item.Sno,termpremium=item.Termpremium}).ToList();

            }
            liferesult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(liferesult, customer, custplan, riderslist);
            liferesult.partnerexamsrequiredlist = WSResult.getPartnerExamsRequiredList(liferesult, custplan, partins);
             
            liferesult.errorslist = WSResult.validateDataaftercalculate(liferesult, customer, custplan, riderslist, partins);
            return liferesult;

        }
        public static WSLifeResult getLifeResultIllustration(IMainInsuranceData insmaindata, WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            //this.liferesult = liferesult;
            WSLifeResult liferesult = new WSLifeResult();
            //liferesult.insuredamount = liferesult.getInsuredamountFE();
            //liferesult.annualpremiumamount = liferesult.getAnnualizedPeriodicPremium();
            //liferesult.periodicpremiumamount = liferesult.calculatedPeriodicPremiumAmount();
            //liferesult.targetpremiumamount = liferesult.getTargetamountFE();
            //liferesult.totalinsuredamount = liferesult.getInsuredamountFE() + liferesult.Ridertermamount;
            liferesult.ropamount = 0;
        
            // insurance related special handling 
            IAssumeddata asdata = new IAssumeddata();
            IResultData resdata = new IResultData();
            if (custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.INSUREDAMOUNT)
            {
                asdata.premiumamount = insmaindata.annualizedpremiumamount;
                DateTime t1 = DateTime.Now;
                resdata = IAccountvalue.calculateInsuredamount(insmaindata, asdata);
            }
            else if (custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.PREMIUMAMOUNT)
            {
                asdata.insuredamount = custplan.insuredamount;
                DateTime t1 = DateTime.Now;
                resdata = IAccountvalue.calculatePremiumamount(insmaindata, asdata);
            }
            else if (custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.VERIFY)
            {
                asdata.insuredamount = custplan.insuredamount;
                asdata.premiumamount = custplan.premiumamount;
                resdata = IAccountvalue.calculateNinguna(insmaindata, asdata);

            }

            liferesult.periodicpremiumamount = insmaindata.calculatePeriodicPremiumAmount();
            liferesult.insuredamount = insmaindata.Calcinsuredamount;

            if ((insmaindata.Calcinsuredamount + insmaindata.ridertermamount) != 0)
            {
                liferesult.totalinsuredamount = insmaindata.Calcinsuredamount + insmaindata.ridertermamount;
            }

          //  liferesult.annualpremiumamount = insmaindata.annualizedpremiumamount;
            liferesult.annualpremiumamount = insmaindata.calculatePeriodicPremiumAmount() * Frequencytypes.getfrequencytypevaluefromcode(custplan.frequencytypecode.ToCharArray()[0]);
            
            liferesult.targetpremiumamount = insmaindata.targetyearlyamount(resdata);
            liferesult.minimumpremiumamount = insmaindata.minimumyearlypremium(resdata);


            if (resdata.impossible == true)
            {
                List<WSValidationError> calcerrorslist = new List<WSValidationError>();
                calcerrorslist.Add(new WSValidationError() { errorfield = "", errormessage = insmaindata.planerrordata, errormessageespanol = "The calculation is impossible", errortype = WSErrorType.IS_BLANK, value = "" });
                liferesult.errorslist = calcerrorslist;
                return liferesult;
            }
            else
            {
                Illusdata[] illus = insmaindata.getIllustration();
                liferesult.lifeillusdatalist = (from item in illus
                                                select new WSLifeIllusData() { acdbpremium = item.Acdbpremium, adbpremium = item.Adbpremium, age = item.Age, cipremium = item.Cipremium, commission = item.Commission, costofinsurance = item.Costofinsurance, costofriders = item.Costofriders, isdynamicgrowthrate = item.isdynamicgrowthrate.ToString(), numscenarios = item.Numscenarios, oirpremium = item.Oirpremium, premium = item.Premium, ridersaccountvalue = item.Ridersaccountvalue, sno = item.Sno, termpremium = item.Termpremium }).ToList();

            }
            liferesult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(liferesult, customer, custplan, riderslist);
            liferesult.partnerexamsrequiredlist = WSResult.getPartnerExamsRequiredList(liferesult, custplan, partins);
            
            liferesult.errorslist = WSResult.validateDataaftercalculate(liferesult, customer, custplan, riderslist, partins);

            return liferesult;

        }
    }
}