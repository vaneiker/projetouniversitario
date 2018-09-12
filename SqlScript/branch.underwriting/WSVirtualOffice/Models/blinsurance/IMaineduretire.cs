using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models.wsdata;


namespace WSVirtualOffice.Models.blinsurance
{
    public class IMaineduretire
    {

        public enum CALCTYPES
        {
            PREMIUMAMOUNT=1,
            annuityamount=2
        }

        public CALCTYPES tocalculate;
        
        public int numberofyears;
        private int retirementnoofyears;
        private int defermentnoofyears;
        public double annuityamount;
        public double insuredamount;   
        public double premiumcost;
        public double periodicpremiumamount;
        public char classcode;
        //private double annualizedpremiumamount;
        public String investmentprofile;
        public int age;
        public String gender;
        public String smoker;
        public String country;
        public String activityrisktype;
        public String healthrisktype;
        //private String initialcontribution;
        public double initialcontributionamount;
        
        private double calcannuityamount;
        //private double calcminimumpremium;
        private double calcinsuredamount;
        private double calcyearlypremium;
        
        public String productcode;
        public char plantypecode;        
        public char calculatetypecode;
        
        public char frequencytypecode;
        public int frequencytypevalue;
        public double frequencytypepenalty;

        public char investmentprofilecode;
        public char gendercode;
        public char smokercode;
        public int countryno;

        public double activityrisktypevalue;
        public double healthrisktypevalue;

        public char initialcontributioncode;

        public double growthrate;
        public double costoffunds;
        public double netgrowthrate;


        public double countryrisk;
        private ICommissiondata[] commissiondata = null;

        private ISurrenderpenaltydata[] surrenderpenaltydata = null;


        public char fortargetcalculation = 'N';

        public double variabletargetamount = 0;

        public double[] calcvaryearlypremiumamount = null;

        public double[] varpremiumamount = null;

        public double[] varannuityamount = null;
        public double[] varinvestprofile = null;
        public double[] varsurrenderamount = null;
        public double[] varloanamount = null;
        public double[] varloanrepayamount = null;

        public char varpremiumcode = 'N';
        public char varannuitycode = 'N';
        public char varinvestprofilecode = 'N';
        public char varsurrendercode = 'N';
        public char varloancode = 'N';
        public char varloanrepaycode = 'N';

        //private double targetaccountvalue = 0.0;
        private double precision = 1.0;

        private IMortalitydata[] mortalitydata = null;
        

        // rule values
        public int insurancemaxage;
        private int GSMinimumcontributionperiod;
        public double GSMaximumpremiumamount;
        public double GSMinimumpremiumamount;
        public double GSMaximumannuityamount;
        public double GSMinimumannuityamount;
        public double Minimumpremiumamount;
        public double Minimuminsuredamount;
        public double Maximumpremiumamount;
        public double Maximuminsuredamount;

        
        public double Targetoverage;
        public double Targetdiscountfactor;
        public double Minimumpremiumdiscountfactor;
        public int Retirementpartialtominprimamultiple;
        public double Insuranceoverage;
        public double Smokeroverage;
        public double Premiumreserve;
        public int Targetcontributionperiod;
        public double Monthlyfeevalue;
        public double Monthlyfeevalueyear;
        public double Loadchargepercent;
        public double Maxageoffsetfordefaultmoratlity;
        public double Maxagefordefaultmoratlity;
        public double Maxmortalityvalue;
        public double Malemortalityoffset;

        public double Minimumpremiumtotargetfactor;

        /*
         * Max_Age_Offset_For_Default_Mortality
Max_Age_For_Default_Mortality
Max_Mortality_Value
Male_Mortality_Offset

         * 
         */ 

        public int Maxage;                
        
        
        public double surrendercharge;
        public double partialsurrendercharge;
        public double surrenderexcesspenalty;

        public double LoanInterestRate;
        public double LoanPrincipalGrowthRate;
        public Boolean LoanPrincipalGrowInvestRate;

        public double InterestLoanRate;
        public double LoanAssetRate;
        public Boolean IsLoanRate;


        /*
        public Boolean isOpeningbalance = false;
        public int planyearstart;
        public double openingbalanceamount = 0.0;
        */
        //private double growthrate;
        //private double costoffunds;
        
        //private int numberofyears;
        //private double periodicpremiumamount;
        //private int frequencytypecode;
        //private int frequencytypevalue;
        //private double frequencytypepenalty;
        //private int periodicpremiumamount;

        
        //private int initialcontributionamount;

        private double calculatedtargetpercent;
        private double calculatedtargetinitial;
        private double calculatedtargetamount;
        private double calculatedinsurancefactor;


        public Boolean isOpeningbalance = false;
        public int planyearstart;
        public double openingbalanceamount = 0.0;

        public double openingtarget = 0.0;
        public double openingminpremium = 0.0;


        public void setOpeningbalance(String planyearstartstr, String openingbalanceamountstr, String targetamountstr, String minimumpremiumstr)
        {
            isOpeningbalance = true;
            this.planyearstart = Int32.Parse(planyearstartstr);
            this.openingbalanceamount = double.Parse(openingbalanceamountstr);
            this.openingtarget = double.Parse(targetamountstr);
            this.openingminpremium = double.Parse(minimumpremiumstr);
        }

        



        public int currentyeardifference
        {
            get
            {
                if (this.isOpeningbalance == true)
                {
                    return DateTime.Now.Year - this.planyearstart + 1;
                }
                else
                {
                    return 0;

                }
            }

        }



        public Boolean setVarinvprofiledata(IVarProfileData[] varpdata)
        {
            double[] vartempamount = new double[this.Maxage-this.age+1];
             
            for (int i = 0; i < varpdata.Length; i++)
            {
                if ((i == 0) && (varpdata[0].fromyear != 1))
                {
                    return false;
                }
                else if ((varpdata[0].fromyear >varpdata[i].toyear))
                {
                    return false;
                }
                else if (i != 0)
                {
                    if(varpdata[i].fromyear-varpdata[i-1].toyear!=1)
                    {
                        return false;
                    }
                }
                if (i != (varpdata.Length - 1))
                {
                    for (int j = (varpdata[i].fromyear - 1); j < (varpdata[i].toyear); j++)
                    {
                        if ((j+1) >= 1 && j < (this.Maxage - this.age + 1))
                        {
                            vartempamount[j] = Productinvprofile.getInvprofilerate(varpdata[i].investmentprofilecode, this.productcode,classcode);
                        }
                    }
                }
                else
                {
                    for (int j = (varpdata[i].fromyear - 1); j < (this.Maxage - this.age + 1); j++)
                    {
                        if ((j+1) >= 1 && j < (this.Maxage - this.age + 1))
                        {
                            vartempamount[j] = Productinvprofile.getInvprofilerate(varpdata[i].investmentprofilecode, this.productcode,classcode);
                        }
                    }

                }                
            }
            varinvestprofile = vartempamount;
            varinvestprofilecode = 'Y';
            if (varinvestprofile != null)
            {
                //System.Windows.Forms.MessageBox.Show("invprofile:" + varinvestprofile.Length.ToString());
            }
            return true;
        }


        public Boolean setVardata(int vardatatype,IVarPlanData[] varpdata)
        {            
            if (vardatatype == IVarPlanData.PREMIUM)
            {
                double[] vartempamount = new double[this.numberofyears];
                calcvaryearlypremiumamount = new double[this.numberofyears];
                

                for (int i = 0; i < varpdata.Length; i++)
                {
                    if ((i == 0) && (varpdata[0].fromyear != 1))
                    {
                        return false;
                    }
                    else if ((varpdata[0].fromyear > varpdata[i].toyear))
                    {
                        return false;
                    }
                    else if (i != 0)
                    {
                        if (varpdata[i].fromyear - varpdata[i - 1].toyear != 1)
                        {
                            return false;
                        }
                    }
                    if (i != (varpdata.Length - 1))
                    {
                        for (int j = (varpdata[i].fromyear - 1); j < (varpdata[i].toyear); j++)
                        {
                            if ((j+1) >= 1 && j < (this.numberofyears))
                            {
                                vartempamount[j] = varpdata[i].amount;                                
                                calcvaryearlypremiumamount[j] = calculatepv(Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1, this.frequencytypevalue, vartempamount[j] / (1 + this.frequencytypepenalty));
                            }
                        }
                    }
                    else
                    {
                        for (int j = (varpdata[i].fromyear - 1); j < (this.numberofyears); j++)
                        {
                            if ((j+1) >= 1 && j < (this.numberofyears))
                            {
                                vartempamount[j] = varpdata[i].amount;                                
                                calcvaryearlypremiumamount[j] = calculatepv(Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1, this.frequencytypevalue, vartempamount[j] / (1 + this.frequencytypepenalty));
                            }
                        }
                    }
                    
                }
                varpremiumcode = 'Y';
                varpremiumamount = vartempamount;
                
            }
            else if (vardatatype == IVarPlanData.INSURED)
            {
                double[] vartempamount = new double[this.Maxage-this.age+1];
                for (int i = 0; i < varpdata.Length; i++)
                {
                    if ((i == 0) && (varpdata[0].fromyear != 1))
                    {
                        return false;
                    }
                    else if (varpdata[i].fromyear > varpdata[i].toyear)
                    {
                        return false;

                    }
                    else if (i != 0)
                    {
                        if (varpdata[i].fromyear - varpdata[i - 1].toyear != 1)
                        {
                            return false;
                        }
                    }
                    if (i != (varpdata.Length - 1))
                    {
                        for (int j = (varpdata[i].fromyear - 1); j < (varpdata[i].toyear); j++)
                        {
                            if ((j+1) >= 1 && j < (this.Maxage - this.age + 1))
                            {
                                vartempamount[j] = varpdata[i].amount;
                            }
                        }
                    }
                    else
                    {
                        for (int j = (varpdata[i].fromyear - 1); j < (this.Maxage-this.age+1); j++)
                        {
                            if ((j+1) >= 1 && j < (this.Maxage - this.age + 1))
                            {
                                vartempamount[j] = varpdata[i].amount;
                            }
                        }
                    }                    
                }
                //varinsuredcode = 'Y';
                //varinsuredamount = vartempamount;
            }
            else if (vardatatype == IVarPlanData.LOAN)
            {
                double[] vartempamount = new double[this.Maxage - this.age + 1];

                for (int i = 0; i < (this.Maxage - this.age + 1); i++)
                {
                    vartempamount[i] = 0.0;
                }
                for (int i = 0; i < varpdata.Length; i++)
                {
                    for (int j = i + 1; j < varpdata.Length; j++)
                    {
                        if (varpdata[i].fromyear == varpdata[j].fromyear)
                        {
                            return false;                            
                        }
                    }
                    if (varpdata[i].fromyear >= 1 && varpdata[i].fromyear < (this.Maxage - this.age + 1))
                    {
                        vartempamount[varpdata[i].fromyear-1] = varpdata[i].amount;
                    }
                    else
                    {
                        return false;
                    }
                }                
                varloancode = 'Y';
                varloanamount = vartempamount;
            }
            else if (vardatatype == IVarPlanData.LOANREPAY)
            {
                double[] vartempamount = new double[this.Maxage - this.age + 1];

                for (int i = 0; i < (this.Maxage - this.age + 1); i++)
                {
                    vartempamount[i] = 0.0;
                }

                for (int i = 0; i < varpdata.Length; i++)
                {

                    if (varpdata[i].fromyear > varpdata[i].toyear)
                    {
                        return false;

                    }

                    for (int j = i + 1; j < varpdata.Length; j++)
                    {
                        if (varpdata[i].fromyear >= varpdata[j].fromyear && varpdata[i].fromyear <= varpdata[j].toyear)
                        {
                            return false;
                        }
                        else if (varpdata[i].toyear >= varpdata[j].fromyear && varpdata[i].toyear <= varpdata[j].toyear)
                        {
                            return false;
                        }
                    }

                    for (int j = (varpdata[i].fromyear - 1); j < (varpdata[i].toyear); j++)
                    {
                        if ((j+1) >= 1 && j < (this.Maxage - this.age + 1))
                        {
                            vartempamount[j] = varpdata[i].amount;
                        }
                    }
                }
                varloanrepaycode = 'Y';
                varloanrepayamount = vartempamount;
            }
            else if (vardatatype == IVarPlanData.SURRENDER)
            {
                double[] vartempamount = new double[this.Maxage - this.age + 1];

                for (int i = 0; i < (this.Maxage - this.age + 1); i++)
                {
                    vartempamount[i] = 0.0;
                }

                for (int i = 0; i < varpdata.Length; i++)
                {
                    if (varpdata[i].fromyear > varpdata[i].toyear)
                    {
                        return false;
                    }

                    for (int j = i + 1; j < varpdata.Length; j++)
                    {
                        if (varpdata[i].fromyear >= varpdata[j].fromyear && varpdata[i].fromyear <= varpdata[j].toyear)
                        {
                            return false;
                        }
                        else if (varpdata[i].toyear >= varpdata[j].fromyear && varpdata[i].toyear <= varpdata[j].toyear)
                        {
                            return false;
                        }
                    }

                    for (int j = (varpdata[i].fromyear - 1); j < (varpdata[i].toyear); j++)
                    {
                        if ((j+1) >= 1 && j < (this.Maxage - this.age + 1))
                        {
                            vartempamount[j] = varpdata[i].amount;
                        }
                    }
                }
                varsurrendercode = 'Y';
                varsurrenderamount = vartempamount;
            }

            /*
            if (varpremiumamount != null)
            {
                System.Windows.Forms.MessageBox.Show("premia:"+varpremiumamount.Length.ToString());
            }
            if (varinsuredamount != null)
            {
                System.Windows.Forms.MessageBox.Show("insured:" + varinsuredamount.Length.ToString());
            }
            if (varloanamount != null)
            {
                System.Windows.Forms.MessageBox.Show("loan:" + varloanamount.Length.ToString());
            }*/

            return true;
        }



        public IMaineduretire(long customerplanno)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                DateTime[] dt1 = new DateTime[10];
                dt1[0] = DateTime.Now;

                customerPlandet custplan = (from item in newdb.customerPlandets
                                            where item.customerPlanno == customerplanno
                                            select item).SingleOrDefault();

                customerdet cust = (from item in newdb.customerdets
                                    where item.customerno == custplan.customerno
                                    select item).SingleOrDefault();

                dt1[1] = DateTime.Now;



                //this.product = product;
                this.productcode = custplan.productcode;
                this.classcode = custplan.@class;
                setRuledata();

                dt1[2] = DateTime.Now;

                /*
                public double InterestLoanRate;
                public double LoanAssetRate;
                public Boolean IsLoanRate;
                */
                //public double TargetNingunaPercent;
                //public double LoanInterestRate;
                //public double LoanPrincipalGrowthRate;
                //public Boolean LoanPrincipalGrowInvestRate;

                //this.plantype = plantype;
                this.plantypecode = custplan.plantypecode;

                //this.contributiontype = contributiontype;



                this.numberofyears = Int32.Parse(custplan.contributionperiod.ToString());

                //this.numberofyears = numberofyears;
                //this.calculatetype = calculatetype;
                this.calculatetypecode = custplan.calculatetypecode;

                //if(this.calculatetypecode==Calculatetypes.
                /*
                if (this.calculatetypecode == Calculatetypes.INSUREDAMOUNT)
                {
                    to     IAccountvalue.AVCALCULATETYPES.INSUREDAMOUNT;
                }
                */

                //this.periodicpremiumamount = periodicpremiumamount;

                //this.frequencytype = frequencytype;
                this.frequencytypecode = custplan.frequencytypecode;
                //this.frequencytype = Frequencytypes.getfrequencytype(custplan.frequencytypecode.Value);
                this.frequencytypevalue = Frequencytypes.getfrequencytypevaluefromcode(this.frequencytypecode);
                this.frequencytypepenalty = Frequencytypes.getfrequencytypepenaltyfromcode(this.frequencytypecode, this.productcode);

                //this.investmentprofile = investmentprofile;
                this.investmentprofilecode = custplan.investmentprofilecode;// Invprofiledata.getInvestmentprofilecode(this.investmentprofile);
                

                this.age = Int32.Parse(cust.Age.ToString());

                //this.gender = gender;
                this.gendercode = cust.gendercode;

                //this.smoker = smoker;
                this.smokercode = cust.Smoker;

                //this.country = country;
                this.countryno = custplan.countryno;

                //this.activityrisktype = activityrisktype;
                this.activityrisktypevalue = Activityrisktypes.getActivityriskvalue(custplan.activityrisktypeno);


                
                //this.healthrisktype = healthrisktype;
                this.healthrisktypevalue = Healthrisktypes.getHealthriskvalue(custplan.healthrisktypeno);

                this.classcode = Classdata.getClasscode(custplan.@class.ToString());


                this.growthrate = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode, classcode);







                // calculating mortality data

                dt1[3] = DateTime.Now;

                int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode, this.classcode);
                dt1[4] = DateTime.Now;
                /*
                mortalitydata = new IMortalitydata[maxage - age + 1];
                for (int i = age; i <= maxage; i++)
                {
                    mortalitydata[i - age] = new IMortalitydata();
                    int sno = i - age + 1;
                    mortalitydata[sno - 1].age = age + sno - 1;
                    mortalitydata[sno - 1].sno = sno;
                    mortalitydata[sno - 1].mortalityvalue = Mortalityrates.getMortalityrate(this.productcode, Ridertypes.Primary, mortalitydata[sno - 1].age, this.gendercode, this.smokercode);
                }
                */
                this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode,this.classcode);
                this.netgrowthrate = (this.growthrate - this.costoffunds);

                countryrisk = Countries.getCountryriskvalue(custplan.countryno);


                //per



                var premiumdata = from item in newdb.customerplanvarpremiumdets
                                  where item.customerplanno == custplan.customerPlanno
                                  orderby item.fromyearno
                                  select item;

                if ((premiumdata != null) && (premiumdata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[premiumdata.Count()];
                    foreach (customerplanvarpremiumdet item in premiumdata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                        ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                        ivdata[i].amount = Numericdata.getDoublevalue(item.premiumamount.ToString());
                    }
                    setVardata(IVarPlanData.PREMIUM, ivdata);
                }


                this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
                this.calcinsuredamount = this.insuredamount;



                if (varpremiumcode == 'N')
                {
                    this.periodicpremiumamount = double.Parse(custplan.premiumamount.ToString());
                }
                else
                {
                    this.periodicpremiumamount = varpremiumamount[0];
                }

                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                this.calcyearlypremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);



                this.annuityamount = double.Parse(custplan.annuityamount.ToString());
                this.calcannuityamount = double.Parse(custplan.annuityamount.ToString());

                dt1[5] = DateTime.Now;
                // calculating commission data
                commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);// new ICommissiondata[this.Maxage - age + 1];
                dt1[6] = DateTime.Now;
                /*
                for (int i = age; i <= this.Maxage; i++)
                {
                    commissiondata[i - age] = new ICommissiondata();
                    int sno = i - age + 1;
                    commissiondata[sno - 1].sno = sno;
                    commissiondata[sno - 1].commissionpercent = Commissions.getCommissionpercentvalue(this.productcode, sno);
                    commissiondata[sno - 1].excesscommissionpercent = Commissions.getExcesscommissionpercent(this.productcode, sno);
                }
                 */


                surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0); //new ISurrenderpenaltydata[this.Maxage - age + 1];
                /*
                for (int i = age; i <= this.Maxage; i++)
                {
                    surrenderpenaltydata[i - age] = new ISurrenderpenaltydata();
                    int sno = i - age + 1;
                    surrenderpenaltydata[sno - 1].sno = sno;
                    surrenderpenaltydata[sno - 1].penaltypercent = Surrenderpenaties.getSurrenderpenaltyvalue(this.productcode, sno);
                }
                 */

                dt1[7] = DateTime.Now;


                this.setInitialcontribution(
                    (custplan.initialcontribution.ToString().Equals("0.0")) ? "No" : "Yes",
                    custplan.initialcontribution.ToString());//// = ddlinitialcontribution.Text;


                this.retirementnoofyears = Int32.Parse(custplan.retirementperiod.ToString());
                this.defermentnoofyears = Int32.Parse(custplan.defermentperiod.ToString());

                dt1[8] = DateTime.Now;





                /*
                var loandata = from item in newdb.customerplanloandets
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


                var repaydata = from item in newdb.customerplanloanrepaydets
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



                var surrenderdata = from item in newdb.customerplanvarsurrenderdets
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
                    //setVardata(IVarPlanData.SURRENDER, ivdata);
                }


                var profiledata = from item in newdb.customerplanvarprofiledets
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
                 */





                try
                {
                    customerplanopbaldet custplanopbal = (from item in newdb.customerplanopbaldets
                                                          where item.customerplanno == customerplanno
                                                          select item).SingleOrDefault();


                    isOpeningbalance = true;
                    this.planyearstart = Int32.Parse(custplanopbal.planyear.ToString());
                    this.openingbalanceamount = double.Parse(custplanopbal.adjustedaccountvalue.ToString());
                    this.openingtarget = double.Parse(custplanopbal.targetamount.ToString());
                    this.openingminpremium = double.Parse(custplanopbal.minimumpremium.ToString());
                }
                catch (Exception ex)
                {
                    isOpeningbalance = false;
                }


                this.calculatedtargetpercent = this.Targetpercent;
                this.calculatedtargetinitial = this.Targetinitial;
                this.calculatedtargetamount = this.Targetamount;
                this.calculatedinsurancefactor = this.Insurancefactor;





                IREDassumeddata asdata = new IREDassumeddata();

                if (this.calculatetypecode == Calculatetypes.ANNUITYAMOUNT)
                {
                    this.tocalculate = CALCTYPES.annuityamount;
                    asdata.premiumamount = this.calcyearlypremium;

                    if (this.isOpeningbalance == false)
                    {
                        if (varpremiumcode == 'Y')
                        {
                            variabletargetamount = getVariableTargetamount();
                        }
                        else
                        {
                            variabletargetamount = 0;
                        }
                        asdata.targetamount = this.Targetamount;
                    }
                    else
                    {
                        asdata.targetamount = this.openingtarget;
                    }


                    double assumedannuityamount = 0;
                    if (this.productcode.Equals("AXS") || this.productcode.Equals("SCH"))
                    {
                        assumedannuityamount = goalseekAXSCH(asdata, GSMinimumannuityamount, GSMaximumannuityamount);
                        //assumedannuityamount = goalseekAXSCH(asdata, 35196.05, 35196.05);
                    }
                    else
                    {
                        assumedannuityamount=goalseek(asdata, GSMinimumannuityamount, GSMaximumannuityamount);
                    }
                    this.calcannuityamount = assumedannuityamount;
                    this.annuityamount = assumedannuityamount;

                }
                else if (this.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                {
                    this.tocalculate = CALCTYPES.PREMIUMAMOUNT;
                    asdata.annuityamount = this.annuityamount;
                    double assumedpremiumamount = 0.0;
                    if (this.productcode.Equals("AXS") || this.productcode.Equals("SCH"))
                    {
                        assumedpremiumamount = goalseekAXSCH(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);
                    }
                    else
                    {
                        assumedpremiumamount = goalseek(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);
                    }
                    assumedpremiumamount = goalseek(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);
                    
                    this.calcyearlypremium = assumedpremiumamount;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
        }
        public IMaineduretire(WSCustomer cust, WSCustomerPlan custplan)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                DateTime[] dt1 = new DateTime[10];
                dt1[0] = DateTime.Now;

                dt1[1] = DateTime.Now;



                //this.product = product;
                this.productcode = custplan.productcode;
                this.classcode = custplan.classcode.ToCharArray()[0];
                setRuledata();

                dt1[2] = DateTime.Now;

                /*
                public double InterestLoanRate;
                public double LoanAssetRate;
                public Boolean IsLoanRate;
                */
                //public double TargetNingunaPercent;
                //public double LoanInterestRate;
                //public double LoanPrincipalGrowthRate;
                //public Boolean LoanPrincipalGrowInvestRate;

                //this.plantype = plantype;
                this.plantypecode = custplan.plantypecode.ToCharArray()[0];

                //this.contributiontype = contributiontype;



                this.numberofyears = Int32.Parse(custplan.contributionperiod.ToString());

                //this.numberofyears = numberofyears;
                //this.calculatetype = calculatetype;
                this.calculatetypecode = custplan.calculatetypecode.ToCharArray()[0];

                //if(this.calculatetypecode==Calculatetypes.
                /*
                if (this.calculatetypecode == Calculatetypes.INSUREDAMOUNT)
                {
                    to     IAccountvalue.AVCALCULATETYPES.INSUREDAMOUNT;
                }
                */

                //this.periodicpremiumamount = periodicpremiumamount;

                //this.frequencytype = frequencytype;
                this.frequencytypecode = custplan.frequencytypecode.ToCharArray()[0];
                //this.frequencytype = Frequencytypes.getfrequencytype(custplan.frequencytypecode.Value);
                this.frequencytypevalue = Frequencytypes.getfrequencytypevaluefromcode(this.frequencytypecode);
                this.frequencytypepenalty = Frequencytypes.getfrequencytypepenaltyfromcode(this.frequencytypecode, this.productcode);

                //this.investmentprofile = investmentprofile;
                this.investmentprofilecode = custplan.investmentprofilecode.ToCharArray()[0];// Invprofiledata.getInvestmentprofilecode(this.investmentprofile);


                this.age = Int32.Parse(cust.Age.ToString());

                //this.gender = gender;
                this.gendercode = cust.gendercode.ToCharArray()[0];

                //this.smoker = smoker;
                this.smokercode = cust.Smoker.ToCharArray()[0];

                //this.country = country;
                this.countryno = custplan.countryno;

                //this.activityrisktype = activityrisktype;
                this.activityrisktypevalue = Activityrisktypes.getActivityriskvalue(custplan.activityrisktypeno);



                //this.healthrisktype = healthrisktype;
                this.healthrisktypevalue = Healthrisktypes.getHealthriskvalue(custplan.healthrisktypeno);

                this.classcode = Classdata.getClasscode(custplan.classcode.ToCharArray()[0].ToString());


                this.growthrate = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode, classcode);







                // calculating mortality data

                dt1[3] = DateTime.Now;

                int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode, this.classcode);
                dt1[4] = DateTime.Now;
                /*
                mortalitydata = new IMortalitydata[maxage - age + 1];
                for (int i = age; i <= maxage; i++)
                {
                    mortalitydata[i - age] = new IMortalitydata();
                    int sno = i - age + 1;
                    mortalitydata[sno - 1].age = age + sno - 1;
                    mortalitydata[sno - 1].sno = sno;
                    mortalitydata[sno - 1].mortalityvalue = Mortalityrates.getMortalityrate(this.productcode, Ridertypes.Primary, mortalitydata[sno - 1].age, this.gendercode, this.smokercode);
                }
                */
                this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode, this.classcode);
                this.netgrowthrate = (this.growthrate - this.costoffunds);

                countryrisk = Countries.getCountryriskvalue(custplan.countryno);


                //per


                /*
                var premiumdata = from item in newdb.customerplanvarpremiumdets
                                  where item.customerplanno == custplan.customerPlanno
                                  orderby item.fromyearno
                                  select item;

                if ((premiumdata != null) && (premiumdata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[premiumdata.Count()];
                    foreach (customerplanvarpremiumdet item in premiumdata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = Numericdata.getIntegervalue(item.fromyearno.ToString());
                        ivdata[i].toyear = Numericdata.getIntegervalue(item.toyearno.ToString());
                        ivdata[i].amount = Numericdata.getDoublevalue(item.premiumamount.ToString());
                    }
                    setVardata(IVarPlanData.PREMIUM, ivdata);
                }
              */

                this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
                this.calcinsuredamount = this.insuredamount;



                if (varpremiumcode == 'N')
                {
                    this.periodicpremiumamount = double.Parse(custplan.premiumamount.ToString());
                }
                else
                {
                    this.periodicpremiumamount = varpremiumamount[0];
                }

                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                this.calcyearlypremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);



                
               this.annuityamount = double.Parse(custplan.annuityamount.ToString());
               this.calcannuityamount = double.Parse(custplan.annuityamount.ToString());
                



                dt1[5] = DateTime.Now;
               // calculating commission data
               commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);// new ICommissiondata[this.Maxage - age + 1];
               dt1[6] = DateTime.Now;
               /*
               for (int i = age; i <= this.Maxage; i++)
               {
                   commissiondata[i - age] = new ICommissiondata();
                   int sno = i - age + 1;
                   commissiondata[sno - 1].sno = sno;
                   commissiondata[sno - 1].commissionpercent = Commissions.getCommissionpercentvalue(this.productcode, sno);
                   commissiondata[sno - 1].excesscommissionpercent = Commissions.getExcesscommissionpercent(this.productcode, sno);
               }
                */


                surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0); //new ISurrenderpenaltydata[this.Maxage - age + 1];
                /*
                for (int i = age; i <= this.Maxage; i++)
                {
                    surrenderpenaltydata[i - age] = new ISurrenderpenaltydata();
                    int sno = i - age + 1;
                    surrenderpenaltydata[sno - 1].sno = sno;
                    surrenderpenaltydata[sno - 1].penaltypercent = Surrenderpenaties.getSurrenderpenaltyvalue(this.productcode, sno);
                }
                 */

                dt1[7] = DateTime.Now;


                this.setInitialcontribution(
                    (custplan.initialcontributionamount.ToString().Equals("0.0")) ? "No" : "Yes",
                    custplan.initialcontributionamount.ToString());//// = ddlinitialcontribution.Text;


                this.retirementnoofyears = Int32.Parse(custplan.retirementperiod.ToString());
                this.defermentnoofyears = Int32.Parse(custplan.defermentperiod.ToString());

                dt1[8] = DateTime.Now;





                /*
                var loandata = from item in newdb.customerplanloandets
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


                var repaydata = from item in newdb.customerplanloanrepaydets
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



                var surrenderdata = from item in newdb.customerplanvarsurrenderdets
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
                    //setVardata(IVarPlanData.SURRENDER, ivdata);
                }


                var profiledata = from item in newdb.customerplanvarprofiledets
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
                 */



                /*

                try
                {
                    customerplanopbaldet custplanopbal = (from item in newdb.customerplanopbaldets
                                                          where item.customerplanno == customerplanno
                                                          select item).SingleOrDefault();


                    isOpeningbalance = true;
                    this.planyearstart = Int32.Parse(custplanopbal.planyear.ToString());
                    this.openingbalanceamount = double.Parse(custplanopbal.adjustedaccountvalue.ToString());
                    this.openingtarget = double.Parse(custplanopbal.targetamount.ToString());
                    this.openingminpremium = double.Parse(custplanopbal.minimumpremium.ToString());
                }
                catch (Exception ex)
                {
                    isOpeningbalance = false;
                }

              */


                this.calculatedtargetpercent = this.Targetpercent;
                this.calculatedtargetinitial = this.Targetinitial;
                this.calculatedtargetamount = this.Targetamount;
                this.calculatedinsurancefactor = this.Insurancefactor;





                IREDassumeddata asdata = new IREDassumeddata();

                if (this.calculatetypecode == Calculatetypes.ANNUITYAMOUNT)
                {
                    this.tocalculate = CALCTYPES.annuityamount;
                    asdata.premiumamount = this.calcyearlypremium;                    
                    if (varpremiumcode == 'Y')
                    {
                        variabletargetamount = getVariableTargetamount();
                    }
                    else
                    {
                        variabletargetamount = 0;
                    }
                    asdata.targetamount = this.Targetamount;
                    double assumedannuityamount = 0;
                    if (this.productcode.Equals("AXS") || this.productcode.Equals("SCH"))
                    {
                        assumedannuityamount = goalseekAXSCH(asdata, GSMinimumannuityamount, GSMaximumannuityamount);
                        //assumedannuityamount = goalseekAXSCH(asdata, 35196.05, 35196.05);
                    }
                    else
                    {
                        assumedannuityamount = goalseek(asdata, GSMinimumannuityamount, GSMaximumannuityamount);
                    }
                    this.calcannuityamount = assumedannuityamount;
                    this.annuityamount = assumedannuityamount;

                }
                else if (this.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                {
                    this.tocalculate = CALCTYPES.PREMIUMAMOUNT;
                    asdata.annuityamount = this.annuityamount;
                    double assumedpremiumamount = 0.0;
                    if (this.productcode.Equals("AXS") || this.productcode.Equals("SCH"))
                    {
                        assumedpremiumamount = goalseekAXSCH(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);
                    }
                    else
                    {
                        assumedpremiumamount = goalseek(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);
                    }
                    assumedpremiumamount = goalseek(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);

                    this.calcyearlypremium = assumedpremiumamount;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //newdb.Dispose();
            }
        }

        //public double cal




        public void setInitialcontribution(String initialcontributionstr, String initialcontributionamountstr)
        {
            initialcontributioncode = Booleandata.getBooleanvalue(initialcontributionstr);
            if (this.initialcontributioncode == 'Y')
            {
                if (Program.isdecimal(initialcontributionamountstr) == true)
                {
                    this.initialcontributionamount = double.Parse(initialcontributionamountstr);
                }
                else
                {
                    this.initialcontributionamount = 0.0;
                }
            }
            else
            {
                this.initialcontributionamount = 0.0;
            }
            
        }


        public void setRuledata()
        {
            insurancemaxage = Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE, this.productcode, this.classcode);
            GSMaximumpremiumamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_PREMIUM_AMOUNT, this.productcode, this.classcode);
            GSMinimumpremiumamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_PREMIUM_AMOUNT, this.productcode, this.classcode);
            GSMaximumannuityamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_ANNUITY_AMOUNT, this.productcode, this.classcode);
            GSMinimumannuityamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_ANNUITY_AMOUNT, this.productcode, this.classcode);

            Minimumpremiumamount = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, this.productcode, this.classcode);
            Minimuminsuredamount = Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT, this.productcode, this.classcode);
            Maximuminsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, this.productcode, this.classcode);
            Targetoverage = Rules.getRulevaluedouble(Rules.TARGET_OVERAGE, this.productcode, this.classcode);
            Premiumreserve = Rules.getRulevaluedouble(Rules.PREMIUM_RESERVE, this.productcode, this.classcode);
            Targetcontributionperiod = Rules.getRulevalueint(Rules.TARGET_CONTRIBUTION_PERIOD, this.productcode, this.classcode);
            Monthlyfeevalue = Rules.getRulevaluedouble(Rules.MONTHLY_FEE, this.productcode, this.classcode);
            Monthlyfeevalueyear = this.Monthlyfeevalue * 12;
            Loadchargepercent = Rules.getRulevaluedouble(Rules.LOAD_CHARGE, this.productcode, this.classcode);
            GSMinimumcontributionperiod = Rules.getRulevalueint(Rules.GS_MINIMUM_CONTRIBUTION_PERIOD, this.productcode, this.classcode);
            Maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
            Minimumpremiumtotargetfactor = Rules.getRulevaluedouble(Rules.MINIMUM_PREMIUM_TO_TARGET_FACTOR, this.productcode, this.classcode);
            Targetdiscountfactor = Rules.getRulevaluedouble(Rules.TARGET_DISCOUNT_FACTOR, this.productcode, this.classcode);

            Minimumpremiumdiscountfactor = Rules.getRulevaluedouble(Rules.MINIMUM_PREMIUM_DISCOUNT_FACTOR, this.productcode, this.classcode);
            Retirementpartialtominprimamultiple = Rules.getRulevalueint(Rules.RETIREMENT_PARTIAL_MINIMUM_PREMIUM_MULTIPLE, this.productcode, this.classcode);

            surrendercharge = Rules.getRulevaluedouble(Rules.SURRENDER_CHARGE, this.productcode, this.classcode);
            partialsurrendercharge = Rules.getRulevaluedouble(Rules.PARTIAL_SURRENDER_CHARGE, this.productcode, this.classcode);
            surrenderexcesspenalty = Rules.getRulevaluedouble(Rules.SURRENDER_EXCESS_PERCENT, this.productcode, this.classcode);




            this.LoanInterestRate = Rules.getRulevaluedouble(Rules.LOAN_INTEREST_RATE, this.productcode, this.classcode);
            this.LoanPrincipalGrowthRate = Rules.getRulevaluedouble(Rules.LOAN_PRINCIPAL_GROWTH_RATE, this.productcode, this.classcode);
            this.LoanPrincipalGrowInvestRate = Rules.getRulevalueboolean(Rules.LOAN_PRINCIPAL_GROW_INVEST_RATE, this.productcode, this.classcode);

            this.InterestLoanRate = Rules.getRulevaluedouble(Rules.INTEREST_LOAN_RATE, this.productcode, this.classcode);
            this.LoanAssetRate = Rules.getRulevaluedouble(Rules.LOAN_ASSET_RATE, this.productcode, this.classcode);
            this.IsLoanRate = Rules.getRulevalueboolean(Rules.IS_LOAN_RATE, this.productcode, this.classcode);

            this.Maxageoffsetfordefaultmoratlity = Rules.getRulevalueint(Rules.MAX_AGE_OFFSET_FOR_DEFAULT_MORTALITY, this.productcode, this.classcode);
            this.Maxagefordefaultmoratlity = Rules.getRulevalueint(Rules.MAX_AGE_FOR_DEFAULT_MORTALITY, this.productcode, this.classcode);
            this.Maxmortalityvalue = Rules.getRulevaluedouble(Rules.MAX_MORTALITY_VALUE, this.productcode, this.classcode);
            this.Malemortalityoffset = Rules.getRulevalueint(Rules.MALE_MORTALITY_OFFSET, this.productcode,this.classcode);

            
            /*
             * public double Maxageoffsetfordefaultmoratlity;
        public double Maxagefordefaultmoratlity;
        public double Maxmortalityvalue;
        public double Malemortalityoffset;

             */ 


        }



        public double Insurancefactor
        {
            get
            {
                //return (1 - Math.Pow((1 / (1 + this.growthrate - this.costoffunds)) , this.retirementnoofyears)) /((1 / (1 + growthrate - costoffunds) * (growthrate - costoffunds)));
                return (1 - Math.Pow((1 / (1 + this.growthrate - this.costoffunds)), this.retirementnoofyears)) / ((1 / (1 + this.growthrate - costoffunds) * (this.growthrate - costoffunds)));
            }            
        }

        public double calculatepv(double growthrate, int frequency, double amount)
        {
            double netamount = amount;
            for (int i = 1; i < frequency; i++)
            {
                netamount = netamount + amount * (1.0 / Math.Pow((1 + growthrate), i));

            }
            return netamount;

        }

        public double Yearlypremiumamount
        {
            get
            {
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                //double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;                
                double periodicgrowthrate = Math.Pow((1 + this.netgrowthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;                
                double tempcalcyearlypremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                return tempcalcyearlypremium;
            }
        }


        public double Targetamount
        {
            get
            {
                if (isOpeningbalance == false)
                {

                    if (variabletargetamount > 0)
                    {
                        double temptargetamount = this.calcyearlypremium * this.Targetpercent + this.Targetinitial;
                        if (variabletargetamount < temptargetamount)
                        {
                            return variabletargetamount;
                        }
                        else
                        {
                            return temptargetamount;
                        }
                    }
                    else
                    {

                        return this.calcyearlypremium * this.Targetpercent + this.Targetinitial;
                    }
                }
                else
                {
                    return this.openingtarget;
                }               
                
            }
        }

        public double getTargetamount(double assumedyearlypremium)
        {
            if (this.isOpeningbalance == false)
            {
                return assumedyearlypremium * this.Targetpercent + this.Targetinitial;
            }
            else
            {
                return this.openingtarget;
            }
            
        }

        public double Targetpercent
        {
            get
            {
                //return Math.Min(1, -Financial.Pmt(this.growthrate - this.costoffunds, this.targetperiod, -Financial.PV(this.growthrate - this.costoffunds, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
                //return Math.Min(1, -Financial.Pmt(this.growthrate , this.Targetcontributionperiod, -Financial.PV(this.growthrate , this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
                return Math.Min(1, -Financial.Pmt(this.growthrate, this.Targetcontributionperiod, -Financial.PV(this.growthrate, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
            }
        }

        public double getVariableTargetamount()
        {
            
                //return Math.Min(1, -Financial.Pmt(this.growthrate - this.costoffunds, this.targetperiod, -Financial.PV(this.growthrate - this.costoffunds, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
                //return Math.Min(1, -Financial.Pmt(this.growthrate , this.Targetcontributionperiod, -Financial.PV(this.growthrate , this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
                //return Math.Min(1, -Financial.Pmt(this.growthrate, this.Targetcontributionperiod, -Financial.PV(this.growthrate, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
            double x1 = Financial.NPV(this.growthrate, ref calcvaryearlypremiumamount);
            double[] varprem=new double[calcvaryearlypremiumamount.Length-1];
            for(int i=1;i<calcvaryearlypremiumamount.Length;i++){
                varprem[i-1]=calcvaryearlypremiumamount[i];
            }
            return -Financial.Pmt(this.growthrate, this.Targetcontributionperiod, initialcontributionamount + calcvaryearlypremiumamount[0] + Financial.NPV(this.growthrate, ref varprem), 0, DueDate.BegOfPeriod);
            
        }

        public double Targetinitial
        {
            get
            {
                //return -Financial.Pmt(this.growthrate - this.costoffunds, this.targetperiod,this.initialcontributionamount , 0, DueDate.BegOfPeriod);
                //return -Financial.Pmt(this.growthrate , this.Targetcontributionperiod, this.initialcontributionamount, 0, DueDate.BegOfPeriod);
                return -Financial.Pmt(this.growthrate, this.Targetcontributionperiod, this.initialcontributionamount, 0, DueDate.BegOfPeriod);
            }
        }



        public double getVarPremium(int sno)
        {
            if (varpremiumcode == 'N')
            {
                double actualpremium = this.calcyearlypremium;
                return actualpremium;
            }
            else
            {
                if (this.fortargetcalculation == 'N')
                {
                    double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                    double actualpremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[sno - 1] / (1 + frequencytypepenalty)); ;
                    return actualpremium;
                }
                else
                {
                    double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                    double actualpremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[0] / (1 + frequencytypepenalty)); ;
                    return actualpremium;
                }

            }
        }


        public  double goalseek(IREDassumeddata asdata,double minamount, double maxamount)
        {
            //calculateAccountvalueonretirement(
            //
            double midamount = (maxamount + minamount) / 2.0;
            if (this.tocalculate == CALCTYPES.PREMIUMAMOUNT)
            {
                asdata.premiumamount = midamount;
                asdata.targetamount = getTargetamount(midamount);
                double accountvalueonretirement = calculateAccountvalueonretirement(asdata);
                double assumedtargetaccountvalue = (asdata.annuityamount + this.Monthlyfeevalueyear) * this.Insurancefactor;
                if ((accountvalueonretirement >= (assumedtargetaccountvalue - this.precision))&&(accountvalueonretirement <= (assumedtargetaccountvalue + this.precision)))
                {                    
                    return  asdata.premiumamount;
                }
                else
                {
                    if (accountvalueonretirement < (assumedtargetaccountvalue - this.precision))
                    {
                        return goalseek(asdata,midamount,maxamount);
                    }
                    else if (accountvalueonretirement > (assumedtargetaccountvalue + this.precision))
                    {
                        return goalseek(asdata, minamount, midamount);
                    }
                    else
                    {
                        return 0.0;
                    }
                }

            }
            else if (this.tocalculate == CALCTYPES.annuityamount)
            {
                asdata.annuityamount = midamount;
                double accountvalueonretirement = calculateAccountvalueonretirement(asdata);
                double assumedtargetaccountvalue = (asdata.annuityamount+this.Monthlyfeevalueyear) * this.Insurancefactor;
                if ((accountvalueonretirement >= (assumedtargetaccountvalue - this.precision)) && (accountvalueonretirement <= (assumedtargetaccountvalue + this.precision)))
                {
                    return asdata.annuityamount;
                }
                else
                {
                    if (accountvalueonretirement < (assumedtargetaccountvalue - this.precision))
                    {
                        return goalseek(asdata, minamount, midamount);
                    }
                    else if (accountvalueonretirement > (assumedtargetaccountvalue + this.precision))
                    {
                        return goalseek(asdata, midamount, maxamount);
                    }
                    else
                    {
                        return 0.0;
                    }
                }
            }
            else
            {
                return 0.0;
            }
        }


        public double goalseekAXSCH(IREDassumeddata asdata, double minamount, double maxamount)
        {
            //calculateAccountvalueonretirement(
            //
            double midamount = (maxamount + minamount) / 2.0;
            if (this.tocalculate == CALCTYPES.PREMIUMAMOUNT)
            {
                asdata.premiumamount = midamount;
                asdata.targetamount = getTargetamount(midamount);
                double accountvalueafterretirement = calculateAccountvalueonretirementAXSCH(asdata);
                double assumedtargetaccountvalue = (asdata.annuityamount + this.Monthlyfeevalueyear) * this.Insurancefactor;
                if ((accountvalueafterretirement >= (0 - this.precision)) && (accountvalueafterretirement <= (assumedtargetaccountvalue + this.precision)))
                {
                    return asdata.premiumamount;
                }
                else
                {
                    if (accountvalueafterretirement < (0 - this.precision))
                    {
                        return goalseekAXSCH(asdata, midamount, maxamount);
                    }
                    else if (accountvalueafterretirement > (0 + this.precision))
                    {
                        return goalseekAXSCH(asdata, minamount, midamount);
                    }
                    else
                    {
                        return 0.0;
                    }
                }

            }
            else if (this.tocalculate == CALCTYPES.annuityamount)
            {
                asdata.annuityamount = midamount;
                double accountvalueafterretirement = calculateAccountvalueonretirementAXSCH(asdata);
                double assumedtargetaccountvalue = (asdata.annuityamount + this.Monthlyfeevalueyear) * this.Insurancefactor;
                if ((accountvalueafterretirement >= (0 - this.precision)) && (accountvalueafterretirement <= (0 + this.precision)))
                {
                    return asdata.annuityamount;
                }
                else
                {
                    if (accountvalueafterretirement < (0 - this.precision))
                    {
                        return goalseekAXSCH(asdata, minamount, midamount);
                    }
                    else if (accountvalueafterretirement > (0 + this.precision))
                    {
                        return goalseekAXSCH(asdata, midamount, maxamount);
                    }
                    else
                    {
                        return 0.0;
                    }
                }
            }
            else
            {
                return 0.0;
            }
        }

        public double calculateCostofinsurance(double assumedinsuredamount,double accountvalue,int sno)
        {
            if (this.plantypecode == 'S')
            {
                if (sno <= (this.numberofyears + this.defermentnoofyears))
                {
                    double netinsuredamount = 0.0;// insuredamount;                       
                    netinsuredamount = assumedinsuredamount - accountvalue;
                    double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + 0);//this.countryrisk);
                    return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;
                }
                else
                {
                    return 0.0;
                }
            }
            else
            {
                return 0.0;
            }
        }

        public double Commissionamount(double assumedpremiumamount,double assumedtargetamount,int sno)
        {
            double commissionamount = 0.0;
            double excesscommissionamount = 0.0;            

            if (sno <= this.numberofyears)
            {
                if (sno == 1)
                {
                    //double assumedtargetamount
                    commissionamount = assumedtargetamount * this.commissiondata[sno + this.currentyeardifference  - 1].commissionpercent;
                    excesscommissionamount = (assumedpremiumamount - assumedtargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                }
                else
                {
                    commissionamount = assumedtargetamount * this.commissiondata[sno + this.currentyeardifference - 1].commissionpercent;
                    excesscommissionamount = (assumedpremiumamount - assumedtargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                    //this is commented to accomodate variable premium amounts
                    //commissionamount = this.Targetpercent*assumedpremiumamount *this.commissiondata[sno - 1].commissionpercent;
                    //excesscommissionamount = (assumedpremiumamount - assumedtargetamount) * this.commissiondata[sno - 1].excesscommissionpercent;
                }
            }
            else
            {
                commissionamount = 0;
                excesscommissionamount = 0;
            }                        
            return commissionamount + (excesscommissionamount>0?excesscommissionamount:0);
        }

        public double getGrowthrate(int sno)
        {
            if (varinvestprofilecode == 'N')
            {
                return this.netgrowthrate;
            }
            else
            {
                return varinvestprofile[sno - 1] - this.costoffunds;
            }
        }


        public double calculateAccountvalueonretirement(IREDassumeddata asdata)
        {
            double accountvalue = 0.0;
            double costofinsurance;
            double commissionamount;
            double loadcharge;
            double premiumamount;
            double tempinsuredamount = (asdata.annuityamount + this.Monthlyfeevalueyear) * this.calculatedinsurancefactor;
            //double premiumnoreserve = 0.0;
            int sno = 0;
            int maxcalcperiod = this.numberofyears+this.defermentnoofyears;

            if (this.isOpeningbalance == true)
            {
                accountvalue = this.openingbalanceamount;
            }

            for (int i = 1; i <= maxcalcperiod; i++)
            {
                sno = i;                
                costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);
                if (this.numberofyears >= sno)
                {
                    if (this.tocalculate == CALCTYPES.annuityamount)
                    {
                        premiumamount = getVarPremium(i);                        
                    }
                    else
                    {
                        premiumamount = asdata.premiumamount;// * (1.0 / (1.0 + Premiumreserve));                        
                    }                        
                    if ((this.initialcontributioncode == 'Y') && (i == 1))
                    {
                        premiumamount = premiumamount + this.initialcontributionamount ;
                    }                    
                    commissionamount = this.Commissionamount(premiumamount,asdata.targetamount ,sno);
                }
                else
                {
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                }
                loadcharge = premiumamount * this.Loadchargepercent;
                //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                //accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear);
                accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear);
            }            
            return accountvalue;
        }


        public double calculateAccountvalueonretirementAXSCH(IREDassumeddata asdata)
        {
            double accountvalue = 0.0;
            double costofinsurance;
            double commissionamount;
            double loadcharge;
            double premiumamount;
            double tempinsuredamount = (asdata.annuityamount + this.Monthlyfeevalueyear) * this.calculatedinsurancefactor;

            double tempannuityamount = 0;

            //double premiumnoreserve = 0.0;
            int sno = 0;
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears + this.retirementnoofyears;

            if (this.isOpeningbalance == true)
            {
                accountvalue = this.openingbalanceamount;
            }

            for (int i = 1; i <= maxcalcperiod; i++)
            {
                sno = i;
                costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);
                if (this.numberofyears >= sno)
                {
                    if (this.tocalculate == CALCTYPES.annuityamount)
                    {
                        premiumamount = getVarPremium(i);
                    }
                    else
                    {
                        premiumamount = asdata.premiumamount;// * (1.0 / (1.0 + Premiumreserve));                        
                    }
                    if ((this.initialcontributioncode == 'Y') && (i == 1))
                    {
                        premiumamount = premiumamount + this.initialcontributionamount;
                    }
                    commissionamount = this.Commissionamount(premiumamount, asdata.targetamount, sno);
                    tempannuityamount = 0;
                }
                else if((this.numberofyears<sno)&&(sno>(this.numberofyears+this.defermentnoofyears)))
                {
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                    tempannuityamount = asdata.annuityamount;

                }
                else
                {
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                    tempannuityamount = 0;
                }
                loadcharge = premiumamount * this.Loadchargepercent;
                //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                //accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear);
                accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear-tempannuityamount);
            }
            return accountvalue;
        }



        public REDIllusdata[] getIllustration()
        {
            double accountvalue = 0.0;
            double costofinsurance;
            double commissionamount;
            double loadcharge;
            double premiumamount;
            double actualpremiumamount=0.0;
            double annuitypaid = 0.0;
            double accumulatedpremium = 0.0;
            double tempinsuredamount = ( annuityamount + this.Monthlyfeevalueyear) * this.calculatedinsurancefactor;            
            int sno = 0;
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears+this.retirementnoofyears;

            double[] resarry = getFullrescatearray();

            REDIllusdata[] illdata = new REDIllusdata[maxcalcperiod];

            if (this.isOpeningbalance == true)
            {
                accountvalue = this.openingbalanceamount;
            }

            for (int i = 1; i <= maxcalcperiod; i++)
            {


                sno = i;
                costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);

                if (this.numberofyears >= sno)
                {
                    if (sno <= (this.numberofyears))
                    {
                        if (varpremiumcode == 'N')
                        {
                            actualpremiumamount = this.periodicpremiumamount * this.frequencytypevalue;// * (1.0 / (1.0 + Premiumreserve));
                            premiumamount = this.calcyearlypremium;// * (1.0 / (1.0 + Premiumreserve));
                        }
                        else
                        {
                            actualpremiumamount = varpremiumamount[i-1] * this.frequencytypevalue;// * (1.0 / (1.0 + Premiumreserve));
                            premiumamount = this.calcvaryearlypremiumamount[i - 1];
                        }
                        if ((this.initialcontributioncode == 'Y') && (i == 1))
                        {
                            actualpremiumamount = actualpremiumamount + this.initialcontributionamount;
                            premiumamount = premiumamount + this.initialcontributionamount;
                            commissionamount = this.Commissionamount(this.calcyearlypremium+this.initialcontributionamount, this.Targetamount, sno);
                        }                        
                        commissionamount = this.Commissionamount(premiumamount, this.Targetamount, sno);
                                                
                    }
                    else
                    {
                        actualpremiumamount = 0.0;
                        premiumamount = 0.0;
                        commissionamount = 0.0;
                    }
                }
                else
                {
                    actualpremiumamount = 0.0;
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                }
                if (sno > (this.numberofyears + this.defermentnoofyears))
                {
                    annuitypaid = this.annuityamount;
                }
                else
                {
                    annuitypaid = 0.0;
                }
                loadcharge = premiumamount * this.Loadchargepercent;
                //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount-annuitypaid - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear);

                illdata[sno - 1] = new REDIllusdata();
                illdata[sno - 1].Accountvalue = accountvalue;
                illdata[sno - 1].Sno = sno;
                illdata[sno - 1].Premium = actualpremiumamount;
                accumulatedpremium = accumulatedpremium + actualpremiumamount;
                if (sno <= this.numberofyears)
                {
                    illdata[sno - 1].Accumulatedpremium = accumulatedpremium;
                }
                else
                {
                    illdata[sno - 1].Accumulatedpremium = 0;
                }
                
                illdata[sno - 1].Age = age+i-1;

                if (sno < (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Annuityamount = this.calcannuityamount;
                }
                else
                {
                    illdata[sno - 1].Annuityamount = 0;
                }
                illdata[sno - 1].Commission = commissionamount;
                illdata[sno - 1].Costofinsurance = costofinsurance;
                
                illdata[sno - 1].Rescatevalue = Math.Max(0, resarry[sno - 1] * accountvalue);

                if (sno < (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Partialretirementamount = getPartialannualretirementamount(accountvalue, accumulatedpremium, sno);
                }
                else if (sno == (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Partialretirementamount = annuityamount;
                }
                else
                {
                    illdata[sno - 1].Partialretirementamount = 0.0;
                }
                

                
                //illdata[sno - 1].Discbenefit =-this.Monthlyfeevalueyear-Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate,this.numberofyears,accountvalue,0,Microsoft.VisualBasic.DueDate.BegOfPeriod);


                if (sno <= (this.defermentnoofyears + this.numberofyears))
                {
                    if (this.plantypecode == Plantypes.INSURED)
                    {
                        illdata[sno - 1].Deathbenefit = this.calcannuityamount;
                        if (sno == (this.numberofyears + this.defermentnoofyears))
                        {
                            illdata[sno - 1].Discbenefit = this.calcannuityamount;                            
                        }
                        else
                        {
                            if (sno != (this.defermentnoofyears + this.numberofyears))
                            {
                                illdata[sno - 1].Discbenefit = -this.Monthlyfeevalueyear - Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
                            }
                            else
                            {
                                illdata[sno - 1].Discbenefit = -Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
                            }
                        }
                        //illdata[sno - 1].Deathbenefit = calcannuityamount;
                    }
                    else
                    {
                        if (sno == (this.defermentnoofyears + this.numberofyears))
                        {
                            illdata[sno - 1].Discbenefit = -Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
                            illdata[sno - 1].Deathbenefit = illdata[sno - 1].Discbenefit;
                        }
                        else
                        {
                            illdata[sno - 1].Discbenefit = -this.Monthlyfeevalueyear - Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
                            illdata[sno - 1].Deathbenefit = illdata[sno - 1].Discbenefit + this.Monthlyfeevalueyear;
                        }

                    }
                }
                else
                {
                    illdata[sno - 1].Discbenefit = 0.0;
                    illdata[sno - 1].Deathbenefit = 0.0;
                }

                illdata[sno - 1].Discbenefit = illdata[sno - 1].Partialretirementamount < illdata[sno - 1].Discbenefit ? illdata[sno - 1].Partialretirementamount : illdata[sno - 1].Discbenefit;
                illdata[sno - 1].Deathbenefit = illdata[sno - 1].Partialretirementamount < illdata[sno - 1].Deathbenefit ? illdata[sno - 1].Partialretirementamount : illdata[sno - 1].Deathbenefit;


                if (sno <=(this.defermentnoofyears + this.numberofyears))
                {
                    if (this.plantypecode == Plantypes.INSURED)
                    {
                        illdata[sno - 1].Deathbenefit = annuityamount;
                    }
                    else
                    {
                        illdata[sno - 1].Deathbenefit = illdata[sno - 1].Discbenefit-this.costoffunds;
                    }
                }
                else
                {
                    illdata[sno - 1].Deathbenefit = 0;
                }
                
            }
            return illdata;
        }
        


        public double calculatedPeriodicPremiumAmount()
        {            
            //double netperiodicrate = Math.Pow((1 + growthrate), 1.0 / frequencytypevalue) - 1;
            if (this.calculatetypecode == 'P')
            {
                double netperiodicrate = Math.Pow((1 + this.netgrowthrate), 1.0 / frequencytypevalue) - 1;
                return calculatePMT(calcyearlypremium, frequencytypevalue, netperiodicrate) * (1.0 + frequencytypepenalty);
            }
            else
            {
                return this.periodicpremiumamount; 
            }
        }

        public double calculatedYearlyPremiumAmount()
        {
            //double netperiodicrate = Math.Pow((1 + growthrate), 1.0 / frequencytypevalue) - 1;
            //double netperiodicrate = Math.Pow((1 + this.netgrowthrate), 1.0 / frequencytypevalue) - 1;
            return calcyearlypremium;//, 1, netperiodicrate) * (1.0 + 0);
        }

        private double calculatePMT(double paymentamount, int payments, double rate)
        {
            double netrate = 0.0;
            for (int i = 0; i < payments; i++)
            {
                netrate = netrate + (1.0 / (Math.Pow((1 + rate), i)));
            }
            return paymentamount * (1.0 / netrate);
        }

        public double Calcaveragepremium
        {
            get
            {
                if (varpremiumcode == 'N')
                {
                    return this.calcyearlypremium;
                }
                else
                {
                    double totpremium = 0.0;
                    for (int i = 0; i < varpremiumamount.Length; i++)
                    {
                        totpremium = totpremium + varpremiumamount[i];
                    }
                    return totpremium / varpremiumamount.Length;
                }

            }

        }

        private double getRescatevalue_old(int sno,double accountvalue)
        {
            if (surrenderpenaltydata.Length >= sno)
            {
                if (accountvalue > 0)
                {
                    return commissiondata[sno + this.currentyeardifference - 1].vr * accountvalue;
                }
            }
            return 0.0;

        }


        private double getRescatevalue(int sno, double accountvalue)
        {
            if (accountvalue > 0)
            {
                double penaltycharge = accountvalue * (this.Targetamount / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno)
                + accountvalue * ((this.Calcaveragepremium - this.Targetamount) / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno) * this.surrenderexcesspenalty + this.surrendercharge;
                return (accountvalue - penaltycharge) > 0 ? (accountvalue - penaltycharge) : 0;
            }
            else
            {
                return 0.0;
            }
        }

        public double getSurrenderpenaltypercent(int sno)
        {
            if (surrenderpenaltydata.Length >= sno)
            {
                return surrenderpenaltydata[sno - 1].penaltypercent;
            }
            else
            {
                return 0.0;
            }
        }

        public double Minimumpremium
        {
            get
            {
                return this.Targetamount *(1- this.Minimumpremiumdiscountfactor);
            }
        }

        public double getPartialannualretirementamount(double accountvalue,double cumulativepremium,int sno)
        {


            //=-PMT('Cotizador 2'!$G$7-'Cotizador 2'!$F$32,
            //'Cotizador 2'!$B$12,
            //+(PV('Cotizador 2'!$G$7-'Cotizador 2'!$F$32,'Cotizador 2'!$B$13+'Cotizador 2'!$B$12-C17,
            //'Cotizador 2'!$G$31,,1)+G17)*(1+'Cotizador 2'!$G$7-'Cotizador 2'!$F$32)^('Cotizador 2'!$B$13-C17)*IF(C17='Cotizador 2'!$B$14,1,1),,1)

            //double pvamt = (Microsoft.VisualBasic.Financial.PV(netgrowthrate, (this.defermentnoofyears + this.numberofyears + this.retirementnoofyears - sno),
              //  this.Monthlyfeevalueyear, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) + accountvalue);


            double pvamt = (Microsoft.VisualBasic.Financial.PV(this.netgrowthrate, (this.defermentnoofyears + this.numberofyears + this.retirementnoofyears - sno),
                this.Monthlyfeevalueyear, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) + accountvalue);


            double annuityoutflow = -Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears,
                (Microsoft.VisualBasic.Financial.PV(this.netgrowthrate, (this.defermentnoofyears + this.numberofyears + this.retirementnoofyears-sno),
                this.Monthlyfeevalueyear, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) + accountvalue) 
                * Math.Pow((1 + this.netgrowthrate),
                ((this.defermentnoofyears+this.numberofyears) - sno)), 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);

            if (annuityoutflow > 0)
            {

                if ((getTargetAmountFE() * Minimumpremiumtotargetfactor * this.Retirementpartialtominprimamultiple) < cumulativepremium)
                {
                    return annuityoutflow;
                }
                else
                {
                    return 0.0;
                }
            }
            else
            {
                return 0.0;
            }            
        }



        public double[] getFullrescatearray()
        {
            double[] resarray = new double[this.numberofyears+this.retirementnoofyears+this.defermentnoofyears];

            //for(int i=0;i<this

            for(int i=0;i<(this.numberofyears+this.retirementnoofyears+this.defermentnoofyears);i++)
            {
                if((i+1)>(this.numberofyears+this.defermentnoofyears))
                {
                    resarray[i] = 0.95;
                }
                else if ((i + 1) > (10))
                {
                    resarray[i] = 0.90;
                }
                else
                {
                    resarray[i] = commissiondata[i].vr;
                }
            }
            return resarray;
        }

        public double getAnnuityAmountFE()
        {
            return calcannuityamount;
        }

        public double getInsuredAmountFE()
        {
            return this.plantypecode=='S'?(calcannuityamount + this.Monthlyfeevalueyear) * this.calculatedinsurancefactor:0.0;
        }

        public double getTargetAmountFE()
        {
            return this.Targetamount*(1.0-Targetdiscountfactor);
        }

        public double getMinimumPremiumAmountFE()
        {
            //return this.getTargetAmountFE() * Minimumpremiumtotargetfactor;
            return (this.getTargetAmountFE() * Minimumpremiumtotargetfactor >= this.Minimumpremiumamount) ? this.getTargetAmountFE() * Minimumpremiumtotargetfactor : this.Minimumpremiumamount;
        
        }



        /*
        public double getTestVariableTargetamount(double testgrowthrate)
        {            
            double x1 = Financial.NPV(testgrowthrate, ref calcvaryearlypremiumamount);
            double[] varprem = new double[calcvaryearlypremiumamount.Length - 1];
            for (int i = 1; i < calcvaryearlypremiumamount.Length; i++)
            {
                varprem[i - 1] = calcvaryearlypremiumamount[i];
            }
            return -Financial.Pmt(testgrowthrate, this.Targetcontributionperiod, initialcontributionamount + calcvaryearlypremiumamount[0] + Financial.NPV(testgrowthrate, ref varprem), 0, DueDate.BegOfPeriod);

        }
         */ 

        public double getTestTargetamount(double testgrowthrate,double testvariabletargetamount)
        {            
            if (isOpeningbalance == false)
            {
                double testtargetpercent = getTestTargetpercent(testgrowthrate);
                double testtargetinitial = getTestTargetinitial(testgrowthrate);

                if (testvariabletargetamount > 0)
                {                    
                    double testtemptargetamount = this.calcyearlypremium * testtargetpercent + testtargetinitial;
                    if (testvariabletargetamount < testtemptargetamount)
                    {
                        return testvariabletargetamount;
                    }
                    else
                    {
                        return testtemptargetamount;
                    }
                }
                else
                {
                    return this.calcyearlypremium * testtargetpercent + testtargetinitial;
                }
            }
            else
            {
                return this.openingtarget;
            }
            
        }

        public double getTestTargetpercent(double testgrowthrate)
        {            
            return Math.Min(1, -Financial.Pmt(testgrowthrate, this.Targetcontributionperiod, -Financial.PV(testgrowthrate, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));            
        }

        public double getTestTargetinitial(double testgrowthrate)
        {            
            return -Financial.Pmt(testgrowthrate, this.Targetcontributionperiod, this.initialcontributionamount, 0, DueDate.BegOfPeriod);            
        }

        public double getTestVariableTargetamount(double testgrowthrate)
        {
            if (this.varpremiumcode == 'Y')
            {
                double x1 = Financial.NPV(testgrowthrate, ref calcvaryearlypremiumamount);
                double[] varprem = new double[calcvaryearlypremiumamount.Length - 1];
                for (int i = 1; i < calcvaryearlypremiumamount.Length; i++)
                {
                    varprem[i - 1] = calcvaryearlypremiumamount[i];
                }
                return -Financial.Pmt(testgrowthrate, this.Targetcontributionperiod, initialcontributionamount + calcvaryearlypremiumamount[0] + Financial.NPV(testgrowthrate, ref varprem), 0, DueDate.BegOfPeriod);
            }
            else
            {
                return 0.0;
            }
            
        }


        public double getTestInsurancefactor(double testgrowthrate)
        {            
            return (1 - Math.Pow((1 / (1 + testgrowthrate - this.costoffunds)), this.retirementnoofyears)) / ((1 / (1 + testgrowthrate - costoffunds) * (testgrowthrate - costoffunds)));            
        }

        


        public double getTestgoalseek(IREDassumeddata testasdata, double minamount, double maxamount,double testgrowthrate)
        {
            double midamount = (maxamount + minamount) / 2.0;
            testasdata.annuityamount = midamount;
            
            double accountvalueonretirement = getTestcalculateAccountvalueonretirement(testasdata,testgrowthrate);
            double assumedtargetaccountvalue = (testasdata.annuityamount + this.Monthlyfeevalueyear) * getTestInsurancefactor(testgrowthrate);
            if ((accountvalueonretirement >= (0 - this.precision)) && (accountvalueonretirement <= (0 + this.precision)))
            {
                return testasdata.annuityamount;
            }
            else
            {
                if (accountvalueonretirement < (0 - this.precision))
                {
                    return getTestgoalseek(testasdata, minamount, midamount,testgrowthrate);
                }
                else if (accountvalueonretirement > (0 + this.precision))
                {
                    return getTestgoalseek(testasdata, midamount, maxamount,testgrowthrate);
                }
                else
                {
                    return 0.0;
                }
            }
            
        }

        public double getTestcalculateAccountvalueonretirement(IREDassumeddata testasdata,double testgrowthrate)
        {
            double accountvalue = 0.0;
            double costofinsurance;
            double commissionamount;
            double loadcharge;
            double premiumamount;
            double testtempinsurancefactor = getTestInsurancefactor(testgrowthrate);
            //double tempinsuredamount = (testasdata.annuityamount + this.Monthlyfeevalueyear) * testtempinsurancefactor;
            double tempinsuredamount = (this.annuityamount + this.Monthlyfeevalueyear) * this.Insurancefactor;
            //double premiumnoreserve = 0.0;
            int sno = 0;
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears+this.retirementnoofyears;
            double tempannuityamount = 0.0;


            if (this.isOpeningbalance == true)
            {
                accountvalue = this.openingbalanceamount;
            }

            for (int i = 1; i <= maxcalcperiod; i++)
            {
                sno = i;
                //costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);
                costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);
                if (this.numberofyears >= sno)
                {                    
                    premiumamount = getVarPremium(i);                    
                    if ((this.initialcontributioncode == 'Y') && (i == 1))
                    {
                        premiumamount = premiumamount + this.initialcontributionamount;
                    }
                    commissionamount = this.Commissionamount(premiumamount, testasdata.targetamount, sno);
                    tempannuityamount = 0;
                }
                else if ((this.numberofyears < sno) && (sno > (this.numberofyears + this.defermentnoofyears)))
                {
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                    tempannuityamount = testasdata.annuityamount;

                }
                else
                {
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                    tempannuityamount = 0.0;
                }


                loadcharge = premiumamount * this.Loadchargepercent;                
                accountvalue = (1 + testgrowthrate-this.costoffunds) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear-tempannuityamount);
            }
            return accountvalue;
        }



        public double getAssumedGrowthAmount(double testgrowthrate)
        {
            IREDassumeddata testdata = new IREDassumeddata();
            testdata.premiumamount = this.calcyearlypremium;
            double testvariabletargetamount = getTestVariableTargetamount(testgrowthrate);
            double testtargetamount = this.Targetamount; 
            testdata.targetamount = testtargetamount;
            double testassumedannuityamount = getTestgoalseek(testdata, GSMinimumannuityamount, GSMaximumannuityamount,testgrowthrate);                
            return testassumedannuityamount;
            
        }



        public IGrowthdata[] getAssumedGrowthdata()
        {
            double[] compgrowthrates = Productdata.getProfileRates(this.productcode, this.classcode);
            IGrowthdata[] grdata = new IGrowthdata[4];
            grdata[Productdata.PROFILEU] = new IGrowthdata();
            grdata[Productdata.PROFILEU].growthRate = compgrowthrates[Productdata.PROFILEU];
            grdata[Productdata.PROFILEU].growthAmount = getAssumedGrowthAmount(grdata[Productdata.PROFILEU].growthRate);

            grdata[Productdata.PROFILEM] = new IGrowthdata();
            grdata[Productdata.PROFILEM].growthRate = compgrowthrates[Productdata.PROFILEM];
            grdata[Productdata.PROFILEM].growthAmount = getAssumedGrowthAmount(grdata[Productdata.PROFILEM].growthRate);

            grdata[Productdata.PROFILEB] = new IGrowthdata();
            grdata[Productdata.PROFILEB].growthRate = compgrowthrates[Productdata.PROFILEB];
            grdata[Productdata.PROFILEB].growthAmount = getAssumedGrowthAmount(grdata[Productdata.PROFILEB].growthRate);

            grdata[Productdata.PROFILEG] = new IGrowthdata();
            grdata[Productdata.PROFILEG].growthRate = compgrowthrates[Productdata.PROFILEG];
            grdata[Productdata.PROFILEG].growthAmount = getAssumedGrowthAmount(grdata[Productdata.PROFILEG].growthRate);

            return grdata;


        }



    }
}
