using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.wsdata;
using WSVirtualOffice.Models.blinsurance;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSFuneralResult:WSResult
    {
        public List<WSTermillusdata> funillusdatalist { get; set; }
        public List<WSTermillusdata> funillusdatalisttwo { get; set; }
        public byte[] illuspdf { get; set; }

        public double Tax { get; set; }
        public double TotalPeriodicPremium { get; set; }
        public static WSFuneralResult getFuneralResult(IMainfuneral funaralfixed, WSCustomer customer, WSCustomerPlanFuneral custplan)
        {
            //this.funaralfixed = funaralfixed;
            WSFuneralResult funeralresult = new WSFuneralResult();
            funeralresult.insuredamount = funaralfixed.getInsuredamountFE();
            funeralresult.annualpremiumamount = funaralfixed.getAnnualizedPeriodicPremium();
            funeralresult.periodicpremiumamount = funaralfixed.calculatedPeriodicPremiumAmount();
            funeralresult.targetpremiumamount = funaralfixed.getTargetamountFE();
            funeralresult.totalinsuredamount = funaralfixed.getInsuredamountFE() + funaralfixed.Ridertermamount;
            funeralresult.ropamount = 0;
            //funeralresult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(funeralresult, customer, custplan, new List<WSRider>());
           // funeralresult.errorslist = WSResult.validateDataaftercalculate(funeralresult, customer, custplan, new List<WSRider>(), null);
            Termillusdata[] funeralillus = funaralfixed.getIllustration();
            funeralresult.funillusdatalist = (from item in funeralillus
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
            Termillusdata[] funeralillustwo = funaralfixed.getIllustrationtwo();
            funeralresult.funillusdatalisttwo = (from item in funeralillustwo
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

            funeralresult.Tax = funeralresult.periodicpremiumamount * 0.16;
            funeralresult.TotalPeriodicPremium = funeralresult.periodicpremiumamount + funeralresult.Tax;
            return funeralresult;

        }
        public static WSFuneralResult getFuneralResultIllustration(IMainfuneral funaralfixed, WSCustomer customer, WSCustomerPlanFuneral custplan)
        {
            //this.funaralfixed = funaralfixed;
            WSFuneralResult funeralresult = new WSFuneralResult();
            funeralresult.insuredamount = funaralfixed.getInsuredamountFE();
            funeralresult.annualpremiumamount = funaralfixed.getAnnualizedPeriodicPremium();
            funeralresult.periodicpremiumamount = funaralfixed.calculatedPeriodicPremiumAmount();
            funeralresult.targetpremiumamount = funaralfixed.getTargetamountFE();
            funeralresult.totalinsuredamount = funaralfixed.getInsuredamountFE() + funaralfixed.Ridertermamount;
            funeralresult.ropamount = 0;
            //funeralresult.primaryexamsrequiredlist = WSResult.getPrimaryExamsRequiredList(funeralresult, customer, custplan, new List<WSRider>());
            // funeralresult.errorslist = WSResult.validateDataaftercalculate(funeralresult, customer, custplan, new List<WSRider>(), null);
            Termillusdata[] funeralillus = funaralfixed.getIllustration();
            funeralresult.funillusdatalist = (from item in funeralillus
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
            Termillusdata[] funeralillustwo = funaralfixed.getIllustrationtwo();
            funeralresult.funillusdatalisttwo = (from item in funeralillustwo
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

            funeralresult.Tax = funeralresult.periodicpremiumamount * 0.16;
            funeralresult.TotalPeriodicPremium = funeralresult.periodicpremiumamount + funeralresult.Tax;
            return funeralresult;

        }
    }
}