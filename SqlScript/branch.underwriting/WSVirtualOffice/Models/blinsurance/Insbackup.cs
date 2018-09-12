using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    class Insbackup
    {
        /*
        public IMainInsuranceData(long customerplanno,char temp1)
        {
            customerPlandet custplan = (from item in Program.db.customerPlandets
                                        where item.customerPlanno == customerplanno
                                        select item).SingleOrDefault();

            customerdet cust = (from item in Program.db.customerdets
                                        where item.customerno == custplan.customerno
                                        select item).SingleOrDefault();




            //this.product = product;
            this.productcode = custplan.productcode;

            setRuledata();
            
            
            //public double TargetNingunaPercent;
            //public double LoanInterestRate;
            //public double LoanPrincipalGrowthRate;
            //public Boolean LoanPrincipalGrowInvestRate;

            //this.plantype = plantype;
            this.plantypecode = custplan.plantypecode.Value;

            //this.contributiontype = contributiontype;
            this.contributiontypecode = custplan.contributiontypecode.Value;// Contributiontypes.getcontributiontypecode(this.contributiontype);

            if (this.contributiontypecode == Contributiontypes.UNTILAGE)
            {
                this.untilage = Int32.Parse(custplan.contributionuntilage.ToString());                
                this.numberofyears = this.untilage - this.age + 1;
            }
            else if (this.contributiontypecode == Contributiontypes.NUMBEROFYEARS)
            {                
                this.numberofyears = Int32.Parse(custplan.contributionperiod.ToString());                
            }
            else if (this.contributiontypecode == Contributiontypes.CONTINUOUS)
            {
                this.numberofyears = this.insurancemaxage - this.age + 1;
            }



            //this.numberofyears = numberofyears;

            //this.calculatetype = calculatetype;
            this.calculatetypecode = custplan.calculatetypecode.Value;

            //if(this.calculatetypecode==Calculatetypes.
            

            //this.periodicpremiumamount = periodicpremiumamount;

            //this.frequencytype = frequencytype;
            this.frequencytypecode = custplan.frequencytypecode.Value;
            this.frequencytype =Frequencytypes.getfrequencytype(custplan.frequencytypecode.Value) ;
            this.frequencytypevalue = Frequencytypes.getfrequencytypevalue(this.frequencytype);
            this.frequencytypepenalty = Frequencytypes.getfrequencytypepenalty(this.frequencytype);

            //this.investmentprofile = investmentprofile;
            this.investmentprofilecode = custplan.investmentprofilecode.Value;// Invprofiledata.getInvestmentprofilecode(this.investmentprofile);



            this.age =Int32.Parse(cust.Age.ToString());

            //this.gender = gender;
            this.gendercode = cust.gendercode;

            //this.smoker = smoker;
            this.smokercode = cust.Smoker;

            //this.country = country;
            this.countryno = custplan.countryno.Value;

            //this.activityrisktype = activityrisktype;
            this.activityrisktypevalue =Activityrisktypes.getActivityriskvalue(custplan.activityrisktypeno.Value);



            //this.healthrisktype = healthrisktype;
            this.healthrisktypevalue =Healthrisktypes.getHealthriskvalue( custplan.healthrisktypeno.Value);




            this.growthrate = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode,classcode);







            // calculating mortality data

            int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);

            mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode);
            

            this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode);
            netgrowthrate = (this.growthrate - this.costoffunds);


            

            countryrisk = Countries.getCountryriskvalue(custplan.countryno.Value);


            //per


            this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
            this.calcinsuredamount = this.insuredamount;
            

            
            this.periodicpremiumamount = double.Parse(custplan.premiumamount.ToString());
            double penaltypercent = this.frequencytypepenalty;
            double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
            //MessageBox.Show(netperiodicpayment.ToString());
            double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
            //MessageBox.Show(periodicgrowthrate.ToString());
            annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
            this.calcyearlypremium = annualizedpremiumamount;
            



            // calculating commission data
            commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);
            
            surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0);
            
            this.setFinancialgoal(Booleandata.getBooleanstring(custplan.financialgoal.Value), custplan.financialgoalamount.ToString(), custplan.financialgoalage.ToString());// = double.Parse(txtfingoalamt.Text);
            //insmaindata.financialgoalage = Int32.Parse(txtfingoaluntilage.Text);


            this.setInitialcontribution(
                (custplan.initialcontribution.Value.ToString().Equals("0.0")) ? "No" : "Yes",
                custplan.initialcontribution.ToString());//// = ddlinitialcontribution.Text;

            this.setRideradbdata(Booleandata.getBooleanstring(custplan.rideradb.Value), custplan.rideradbamount.ToString());
            
            this.rideradbcost =double.Parse(custplan.rideradbcost.ToString());
            this.setRideracdbdata(Booleandata.getBooleanstring(custplan.rideracdb.Value));
            this.rideracdbcost = double.Parse(custplan.rideracdbcost.ToString());
            this.setRidercidata(Booleandata.getBooleanstring(custplan.riderci.Value), custplan.riderciamount.ToString());
            this.ridercicost = double.Parse(custplan.ridercicost.ToString());
            this.setRidertermdata(Booleandata.getBooleanstring(custplan.riderterm.Value), custplan.ridertermamount.ToString(), custplan.ridertermuntilage.ToString());
            this.ridertermcost = double.Parse(custplan.ridertermcost.ToString());

            if (custplan.rideroir.Value == 'Y')
            {
                customerplanpartnerinsurancedet othins = (from item in Program.db.customerplanpartnerinsurancedets
                                                          where item.customerplanno == custplan.customerPlanno
                                                          select item).SingleOrDefault();
                this.setOirdata(Booleandata.getBooleanstring(custplan.rideroir.Value), othins.rideroiramount.ToString(),
                    othins.age.ToString(),
                    Genders.getgender(othins.gendercode.Value), Booleandata.getBooleanstring(othins.smoker.Value),
                    othins.untilage.ToString(),
                    Activityrisktypes.getActivityrisktype(othins.activityrisktypeno.Value),
                    Healthrisktypes.getHealthrisktype(othins.healthrisktypeno.Value));
                this.rideroircost = double.Parse(othins.rideroircost.ToString());
            }



            var premdata = from item in Program.db.customerplanvarpremiumdets
                           where item.customerplanno == custplan.customerPlanno
                           orderby item.fromyearno
                           select item;

            if ((premdata != null) && (premdata.Count() > 0))
            {

                int i = -1;
                IVarPlanData[] ivdata = new IVarPlanData[premdata.Count()];
                foreach (customerplanvarpremiumdet item in premdata)
                {
                    i++;
                    ivdata[i] = new IVarPlanData();
                    ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                    ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                    ivdata[i].amount = Numericdata.getDoublevalue(item.premiumamount.ToString());
                }
                setVardata(IVarPlanData.PREMIUM, ivdata);
            }


            var insdata = from item in Program.db.customerplanvarinsureddets
                          where item.customerplanno == custplan.customerPlanno
                          orderby item.fromyearno
                          select item;

            if ((insdata != null) && (insdata.Count() > 0))
            {

                int i = -1;
                IVarPlanData[] ivdata = new IVarPlanData[insdata.Count()];
                foreach (customerplanvarinsureddet item in insdata)
                {
                    i++;
                    ivdata[i] = new IVarPlanData();
                    ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                    ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                    ivdata[i].amount = Numericdata.getDoublevalue(item.insuredamount.ToString());
                }
                setVardata(IVarPlanData.INSURED, ivdata);
            }


            var loandata = from item in Program.db.customerplanloandets
                           where item.customerplanno == custplan.customerPlanno
                           orderby item.fromyearno
                           select item;

            if ((loandata != null) && (loandata.Count() > 0))
            {
                int i = -1;
                IVarPlanData[] ivdata = new IVarPlanData[loandata.Count()];
                foreach (customerplanloandet item in loandata)
                {
                    i++;
                    ivdata[i] = new IVarPlanData();
                    ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                    ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                    ivdata[i].amount = Numericdata.getDoublevalue(item.loanamount.ToString());
                }
                setVardata(IVarPlanData.LOAN, ivdata);
            }


            var repaydata = from item in Program.db.customerplanloanrepaydets
                            where item.customerplanno == custplan.customerPlanno
                            orderby item.fromyearno
                            select item;

            if ((repaydata != null) && (repaydata.Count() > 0))
            {
                int i = -1;
                IVarPlanData[] ivdata = new IVarPlanData[repaydata.Count()];
                foreach (customerplanloanrepaydet item in repaydata)
                {
                    i++;
                    ivdata[i] = new IVarPlanData();
                    ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                    ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                    ivdata[i].amount = Numericdata.getDoublevalue(item.paymentamount.ToString());
                }
                setVardata(IVarPlanData.LOANREPAY, ivdata);
            }



            var surrenderdata = from item in Program.db.customerplanvarsurrenderdets
                                where item.customerplanno == custplan.customerPlanno
                                orderby item.fromyearno
                                select item;

            if ((surrenderdata != null) && (surrenderdata.Count() > 0))
            {
                int i = -1;
                IVarPlanData[] ivdata = new IVarPlanData[surrenderdata.Count()];
                foreach (customerplanvarsurrenderdet item in surrenderdata)
                {
                    i++;
                    ivdata[i] = new IVarPlanData();
                    ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                    ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                    ivdata[i].amount = Numericdata.getDoublevalue(item.surrenderamount.ToString());
                }
                setVardata(IVarPlanData.SURRENDER, ivdata);
            }


            var profiledata = from item in Program.db.customerplanvarprofiledets
                              where item.customerplanno == custplan.customerPlanno
                              orderby item.fromyearno
                              select item;

            if ((profiledata != null) && (profiledata.Count() > 0))
            {
                int i = -1;
                IVarProfileData[] ivdata1 = new IVarProfileData[profiledata.Count()];
                foreach (customerplanvarprofiledet item in profiledata)
                {
                    i++;
                    ivdata1[i] = new IVarProfileData();
                    ivdata1[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                    ivdata1[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                    ivdata1[i].investmentprofilecode = item.investmentprofilecode.Value;
                }
                setVarinvprofiledata(ivdata1);
            }



        }
         */ 

    }
}
