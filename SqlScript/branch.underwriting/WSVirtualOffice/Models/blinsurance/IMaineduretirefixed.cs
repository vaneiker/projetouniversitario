using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models.wsdata;


namespace WSVirtualOffice.Models.blinsurance
{
    public class IMaineduretirefixed
    {

        public enum CALCTYPES
        {
            PREMIUMAMOUNT = 1,
            annuityamount = 2
        }

        public IMortalityfixed[] mortdatatable;

        public CALCTYPES tocalculate;

        public int numberofyears;
        private int retirementnoofyears;
        private int defermentnoofyears;
        public double annuityamount;
        public double insuredamount;
        public double premiumcost;
        public double periodicpremiumamount;
        private double annualizedpremiumamount;
        public String investmentprofile;
        public int age;
        public String gender;
        public String smoker;
        public String country;
        public String activityrisktype;
        public String healthrisktype;
        private String initialcontribution;
        public double initialcontributionamount;
        public char classcode;


        private double calcannuityamount;
        private double calcminimumpremium;
        private double calcinsuredamount;
        private double calcyearlypremium;
        

        private double calcaveragecommission;
        private double calctotalcommission;

        private double calckfactor;
        private double calccuotac;
        private double calcoverage;

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

        private double targetaccountvalue = 0.0;
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
        public int Malemortalityoffset;

        public double Adminfixed;
        public double Baseinterestrate;
        public double Commission_cost;

        public int Rescatestartyear;
        public double Rescatepercentage;


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


        public Boolean isOpeningbalance = false;
        public int planyearstart;
        public double openingbalanceamount = 0.0;

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



        public Boolean setVarinvprofiledata(IVarProfileData[] varpdata)
        {
            double[] vartempamount = new double[this.Maxage - this.age + 1];

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
                        if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
                        {
                            vartempamount[j] = Productinvprofile.getInvprofilerate(varpdata[i].investmentprofilecode, this.productcode,classcode);
                        }
                    }
                }
                else
                {
                    for (int j = (varpdata[i].fromyear - 1); j < (this.Maxage - this.age + 1); j++)
                    {
                        if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
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


        public Boolean setVardata(int vardatatype, IVarPlanData[] varpdata)
        {
            if (vardatatype == IVarPlanData.PREMIUM)
            {
                double[] vartempamount = new double[this.numberofyears];



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
                            if ((j + 1) >= 1 && j < (this.numberofyears))
                            {
                                vartempamount[j] = varpdata[i].amount;
                            }
                        }
                    }
                    else
                    {
                        for (int j = (varpdata[i].fromyear - 1); j < (this.numberofyears); j++)
                        {
                            if ((j + 1) >= 1 && j < (this.numberofyears))
                            {
                                vartempamount[j] = varpdata[i].amount;
                            }
                        }
                    }

                }
                varpremiumcode = 'Y';
                varpremiumamount = vartempamount;

            }
            else if (vardatatype == IVarPlanData.INSURED)
            {
                double[] vartempamount = new double[this.Maxage - this.age + 1];
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
                            if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
                            {
                                vartempamount[j] = varpdata[i].amount;
                            }
                        }
                    }
                    else
                    {
                        for (int j = (varpdata[i].fromyear - 1); j < (this.Maxage - this.age + 1); j++)
                        {
                            if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
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
                        vartempamount[varpdata[i].fromyear - 1] = varpdata[i].amount;
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
                        if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
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
                        if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
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



        public IMaineduretirefixed(long customerplanno)
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


                //this.plantype = plantype;
                this.plantypecode = custplan.plantypecode;

                //this.contributiontype = contributiontype;



                this.numberofyears = Int32.Parse(custplan.contributionperiod.ToString());

                this.calculatetypecode = custplan.calculatetypecode;

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
                this.growthrate = Productinvprofile.getInvprofilerate(Invprofiledata.GUARANTEED, this.productcode, classcode);
                //this.netgrowthrate = this.growthrate - this.costoffunds;

                //this.growthrate=

                // calculating mortality data

                dt1[3] = DateTime.Now;

                int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode,this.classcode);
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode,classcode);
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
                netgrowthrate = (this.growthrate - this.costoffunds);

                countryrisk = Countries.getCountryriskvalue(custplan.countryno);

                this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
                this.calcinsuredamount = this.insuredamount;



                this.periodicpremiumamount = double.Parse(custplan.premiumamount.ToString());
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                //MessageBox.Show(netperiodicpayment.ToString());
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                //MessageBox.Show(periodicgrowthrate.ToString());
                //annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
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

                if (this.smokercode == 'Y')
                {
                    calcoverage = this.Smokeroverage;
                }
                else
                {
                    calcoverage = this.Insuranceoverage;
                }


                this.calculatedinsurancefactor = this.Insurancefactor;

                this.mortdatatable = Mortalityrates.getMortalitydatafixed(this.productcode, Ridertypes.Primary, this.healthrisktypevalue, this.countryrisk,classcode);

                this.calcaveragecommission = getAveragecommission();
                this.calctotalcommission = getTotalcommission();

                calckfactor = this.getKfactor();

                if (this.smokercode == 'Y')
                {
                    this.calcoverage = this.Smokeroverage;
                }
                else
                {
                    this.calcoverage = this.Insuranceoverage;
                }




                IAssumeddatafixed asdata = new IAssumeddatafixed();

                if (this.calculatetypecode == Calculatetypes.ANNUITYAMOUNT)
                {
                    this.tocalculate = CALCTYPES.annuityamount;
                    asdata.premiumamount = this.calcyearlypremium;
                    double assumedannuityamount = goalseek(asdata, this.GSMinimumannuityamount, this.GSMaximumannuityamount);
                    this.calcannuityamount = assumedannuityamount;
                    this.annuityamount = assumedannuityamount;

                }
                else if (this.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                {
                    this.tocalculate = CALCTYPES.PREMIUMAMOUNT;
                    asdata.annuityamount = this.annuityamount;
                    double assumedpremiumamount = goalseek(asdata, this.GSMinimumpremiumamount, this.GSMaximumpremiumamount);
                    this.annualizedpremiumamount = assumedpremiumamount;
                    this.calcyearlypremium = assumedpremiumamount;
                    this.periodicpremiumamount = this.calculatedPeriodicPremiumAmount();
                }
                this.calculatedtargetamount = calculateTargetamount();
                //asdata.annuityamount=

                String str1 = (dt1[8] - dt1[0]).ToString();
                for (int j = 1; j < 9; j++)
                {
                    str1 = str1 + ((char)10).ToString() + ((dt1[j] - dt1[j - 1]).ToString());
                }
                //System.Windows.Forms.MessageBox.Show(str1);






            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
        }

        public IMaineduretirefixed(WSCustomer cust, WSCustomerPlan custplan)
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


                //this.plantype = plantype;
                this.plantypecode = custplan.plantypecode.ToCharArray()[0];

                //this.contributiontype = contributiontype;



                this.numberofyears = Int32.Parse(custplan.contributionperiod.ToString());

                this.calculatetypecode = custplan.calculatetypecode.ToCharArray()[0];

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


                this.classcode = custplan.classcode.ToCharArray()[0];
                this.growthrate = Productinvprofile.getInvprofilerate(Invprofiledata.GUARANTEED, this.productcode, classcode);
                //this.netgrowthrate = this.growthrate - this.costoffunds;

                //this.growthrate=

                // calculating mortality data

                dt1[3] = DateTime.Now;

                int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode, classcode);
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
                netgrowthrate = (this.growthrate - this.costoffunds);

                countryrisk = Countries.getCountryriskvalue(custplan.countryno);

                this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
                this.calcinsuredamount = this.insuredamount;



                this.periodicpremiumamount = double.Parse(custplan.premiumamount.ToString());
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                //MessageBox.Show(netperiodicpayment.ToString());
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                //MessageBox.Show(periodicgrowthrate.ToString());
                //annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
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

                if (this.smokercode == 'Y')
                {
                    calcoverage = this.Smokeroverage;
                }
                else
                {
                    calcoverage = this.Insuranceoverage;
                }


                this.calculatedinsurancefactor = this.Insurancefactor;

                this.mortdatatable = Mortalityrates.getMortalitydatafixed(this.productcode, Ridertypes.Primary, this.healthrisktypevalue, this.countryrisk, classcode);

                this.calcaveragecommission = getAveragecommission();
                this.calctotalcommission = getTotalcommission();

                calckfactor = this.getKfactor();

                if (this.smokercode == 'Y')
                {
                    this.calcoverage = this.Smokeroverage;
                }
                else
                {
                    this.calcoverage = this.Insuranceoverage;
                }




                IAssumeddatafixed asdata = new IAssumeddatafixed();

                if (this.calculatetypecode == Calculatetypes.ANNUITYAMOUNT)
                {
                    this.tocalculate = CALCTYPES.annuityamount;
                    asdata.premiumamount = this.calcyearlypremium;
                    double assumedannuityamount = goalseek(asdata, this.GSMinimumannuityamount, this.GSMaximumannuityamount);
                    this.calcannuityamount = assumedannuityamount;
                    this.annuityamount = assumedannuityamount;

                }
                else if (this.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                {
                    this.tocalculate = CALCTYPES.PREMIUMAMOUNT;
                    asdata.annuityamount = this.annuityamount;
                    double assumedpremiumamount = goalseek(asdata, this.GSMinimumpremiumamount, this.GSMaximumpremiumamount);
                    this.annualizedpremiumamount = assumedpremiumamount;
                    this.calcyearlypremium = assumedpremiumamount;
                    this.periodicpremiumamount = this.calculatedPeriodicPremiumAmount();
                }
                this.calculatedtargetamount = calculateTargetamount();
                //asdata.annuityamount=

                String str1 = (dt1[8] - dt1[0]).ToString();
                for (int j = 1; j < 9; j++)
                {
                    str1 = str1 + ((char)10).ToString() + ((dt1[j] - dt1[j - 1]).ToString());
                }
                //System.Windows.Forms.MessageBox.Show(str1);






            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
        }
        //public double cal
        /*

    private double getAveragecommission()
    {            
        double totcomm = 0.0;
        int offset=0;
        if (this.gendercode=='M')
        {
            offset = this.Malemortalityoffset;
        }
        for (int i = 1; i <= this.numberofyears; i++)
        {
            totcomm = totcomm+ this.Commission_cost * (mortdatatable[this.age + i - 1 + offset].ddx / mortdatatable[this.age + offset].ddx);
        }
        return totcomm / this.numberofyears;
            
    }*/


        private double getKfactor()
        {
            int offset = 0;
            if (this.gendercode == 'M')
            {
                offset = this.Malemortalityoffset;
            }
            return (mortdatatable[this.age + offset].nx - mortdatatable[this.age + offset + this.numberofyears].nx) / mortdatatable[this.age + offset].ddx;

        }


        private double getAveragecommission()
        {
            double totcomm = 0.0;
            int offset = 0;
            if (this.gendercode == 'M')
            {
                offset = this.Malemortalityoffset;
            }
            for (int i = 1; i <= this.numberofyears; i++)
            {
                totcomm = totcomm + this.Commission_cost * (mortdatatable[this.age + i - 1 + offset].ddx / mortdatatable[this.age + offset].ddx);
            }
            return totcomm / this.numberofyears;

        }

        private double getTotalcommission()
        {
            double totcomm = 0.0;
            int offset = 0;
            if (this.gendercode == 'M')
            {
                offset = this.Malemortalityoffset;
            }
            for (int i = 1; i <= this.numberofyears; i++)
            {
                totcomm = totcomm + this.Commission_cost * (mortdatatable[this.age + i - 1 + offset].ddx / mortdatatable[this.age + offset].ddx);
            }
            return totcomm;

        }



        private double calculateCuotacwithinsurance(double assumedpremiumamount)
        {
            double tempcuotacwithinsurance = 0.0;
            tempcuotacwithinsurance = assumedpremiumamount * (1 - this.Adminfixed - this.calcaveragecommission / this.calckfactor);
            return tempcuotacwithinsurance;
        }

        private double calculateCuotac(double assumedannuityamount)
        {
            double tempcuotac=0.0;
            tempcuotac = Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.numberofyears, this.initialcontributionamount * (1 - this.Loadchargepercent - this.Commission_cost), Microsoft.VisualBasic.Financial.PV(this.netgrowthrate, this.retirementnoofyears, assumedannuityamount, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) / Math.Pow((1 + this.netgrowthrate), (this.defermentnoofyears)), Microsoft.VisualBasic.DueDate.BegOfPeriod);
            return tempcuotac;

        }



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
            //Minimumpremiumtotargetfactor = Rules.getRulevaluedouble(Rules.MINIMUM_PREMIUM_TO_TARGET_FACTOR, this.productcode);
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
            this.Malemortalityoffset = Rules.getRulevalueint(Rules.MALE_MORTALITY_OFFSET, this.productcode, this.classcode);

            this.Adminfixed = Rules.getRulevaluedouble(Rules.ADMIN_FIXED, this.productcode, this.classcode);
            this.Baseinterestrate = Rules.getRulevaluedouble(Rules.BASE_INTEREST, this.productcode, this.classcode);
            this.Commission_cost = Rules.getRulevaluedouble(Rules.COMMISSION_COST, this.productcode, this.classcode);

            this.Insuranceoverage = Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE, this.productcode, this.classcode);
            this.Smokeroverage = Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, this.productcode, this.classcode);

            this.Rescatestartyear = Rules.getRulevalueint(Rules.RESCATE_STARTYEAR, this.productcode, this.classcode);

            this.Rescatepercentage = Rules.getRulevaluedouble(Rules.RESCATE_PERCENTAGE, this.productcode,this.classcode);

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
                return (1 - Math.Pow((1 / (1 + this.growthrate - this.costoffunds)), this.retirementnoofyears)) / ((1 / (1 + growthrate - costoffunds) * (growthrate - costoffunds)));
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
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                return annualizedpremiumamount;
            }
        }
       
        

        






        public double goalseek(IAssumeddatafixed asdata, double minamount, double maxamount)
        {
            //calculateAccountvalueonretirement(
            //            
            if (this.tocalculate == CALCTYPES.PREMIUMAMOUNT)
            {                
                asdata= calculateAccountvalueonretirement(asdata);                
                double netinsuredamount =this.plantypecode=='S'?(1+this.calcoverage + this.activityrisktypevalue) * asdata.cumulativepremium / this.calckfactor:0.0;
                calcinsuredamount = netinsuredamount;
                double temppremium = (asdata.annuitycuotac+netinsuredamount) / (1 - this.Adminfixed - (this.calctotalcommission / this.calckfactor));                
                return temppremium;                
            }
            else if (this.tocalculate == CALCTYPES.annuityamount)
            {
                double midamount = (maxamount + minamount) / 2.0;
                asdata.annuityamount = midamount;
                asdata= calculateAccountvalueonretirement(asdata);
                double netinsuredamount =this.plantypecode=='S'?(1 + this.calcoverage + this.activityrisktypevalue) * asdata.cumulativepremium / this.calckfactor:0.0;
                calcinsuredamount = netinsuredamount;
                double temppremium = (asdata.annuitycuotac + netinsuredamount) / (1 - this.Adminfixed - (this.calctotalcommission / this.calckfactor));

                if (Math.Abs(temppremium - asdata.premiumamount) <= 0.05)
                {
                    return asdata.annuityamount;
                }
                else if (temppremium > asdata.premiumamount)
                {
                    return goalseek(asdata, minamount, midamount);
                }
                else 
                {
                    return goalseek(asdata, midamount, maxamount);
                }
            }
            else
            {
                return 0.0;
            }
        }

        public double calculateCostofinsurance(double assumedinsuredamount, double accountvalue, int sno)
        {
            if (this.plantypecode == 'S')
            {
                if (sno <= (this.numberofyears + this.defermentnoofyears))
                {
                    int mortoffset = 0;
                    if (this.gendercode == 'M')
                    {
                        mortoffset = this.Malemortalityoffset;
                    }
                    double netinsuredamount = 0.0;// insuredamount;                       
                    netinsuredamount = assumedinsuredamount - accountvalue;
                    if (sno == 1)
                    {
                        //double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
                        //return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality * Math.Pow((1 / (1 + this.Baseinterestrate)), sno);
                        return (mortdatatable[sno - 1 + mortoffset + this.age].mortalityvalue) * netinsuredamount * (1.0 / 1000.0) * Math.Pow((1 / (1 + this.Baseinterestrate)), sno);
                    }
                    else
                    {
                        return (mortdatatable[sno - 1 + mortoffset + this.age].dx / mortdatatable[mortoffset + this.age].lx) * netinsuredamount * Math.Pow((1 / (1 + this.Baseinterestrate)), sno);
                        //VLOOKUP($N30,$A$10:$K$108,4)/VLOOKUP($N$3,$A$10:$K$108,3)*X31*$V$5^$T31
                        //double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
                        //return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality * Math.Pow((1 / (1 + this.Baseinterestrate)), sno);
                    }
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

        /*
        public double Commissionamount(double assumedpremiumamount, double assumedtargetamount, int sno)
        {
            double commissionamount = 0.0;
            double excesscommissionamount = 0.0;

            if (sno <= this.numberofyears)
            {
                if (sno == 1)
                {
                    //double assumedtargetamount
                    commissionamount = assumedtargetamount * this.commissiondata[sno - 1].commissionpercent;
                    excesscommissionamount = (assumedpremiumamount - assumedtargetamount) * this.commissiondata[sno - 1].excesscommissionpercent;
                }
                else
                {
                    commissionamount = this.Targetpercent * assumedpremiumamount * this.commissiondata[sno - 1].commissionpercent;
                    excesscommissionamount = (assumedpremiumamount - assumedtargetamount) * this.commissiondata[sno - 1].excesscommissionpercent;
                }
            }
            else
            {
                commissionamount = 0;
                excesscommissionamount = 0;
            }
            return commissionamount + excesscommissionamount;
        }
         */ 

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


        public IAssumeddatafixed calculateAccountvalueonretirement(IAssumeddatafixed asdata)
        {
            double accountvalue = 0.0;
            double costofinsurance=0.0;
            double cumulativecostofinsurance = 0.0;
            //double commissionamount;
            //double loadcharge;
            //double premiumamount;
            double tempcuotac = this.calculateCuotac(asdata.annuityamount);
            double tempinsuredamount = (asdata.annuityamount ) * this.calculatedinsurancefactor;
            asdata.annuitycuotac = tempcuotac;
            //asdata.
            //double premiumnoreserve = 0.0;
            int sno = 0;
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears;
            for (int i = 1; i <= maxcalcperiod; i++)
            {
                sno = i;
                //costofinsurance = Costofinsurance(tempinsuredamount, accountvalue, sno);
                if (this.numberofyears >= sno)
                {
                    if((i==1)&&(this.initialcontributioncode=='Y'))
                    {
                        accountvalue=(1+this.netgrowthrate)*(tempcuotac+accountvalue+this.initialcontributionamount*(1-this.Loadchargepercent-this.Commission_cost));
                    }
                    else
                    {
                        accountvalue=(1+this.netgrowthrate)*(tempcuotac+accountvalue);
                    }                    
                }
                else
                {
                    accountvalue =(1+this.netgrowthrate)* accountvalue;                    
                }
                costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);
                cumulativecostofinsurance = cumulativecostofinsurance + costofinsurance;
                
            }
            double cuotacpremiumwithinsurance = asdata.premiumamount * (1 - this.Adminfixed - this.calcaveragecommission / this.calckfactor);
           
            double netinsurance =(this.plantypecode=='S')?((1 + this.calcoverage) * cumulativecostofinsurance) / this.calckfactor:0.0;
            asdata.cumulativepremium = cumulativecostofinsurance;
            asdata.accountvalue = accountvalue;
            return asdata;
        }




        public REDIllusdata[] getIllustration()
        {
            double accountvalue = 0.0;
            double costofinsurance;                                    
            double annuitypaid = 0.0;
            double accumulatedpremium = 0.0;

            double tempinsuredamount = (this.calcannuityamount ) * this.calculatedinsurancefactor;

            double premiumannualequivalent = -Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.numberofyears + this.defermentnoofyears,0, tempinsuredamount,  Microsoft.VisualBasic.DueDate.BegOfPeriod);

            double[] resarry=getPartialrescatearray();
            double[] fullresarry = getFullrescatearray();

            int sno = 0;
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears + this.retirementnoofyears;
            REDIllusdata[] illdata = new REDIllusdata[maxcalcperiod];
            double tempcuotac = this.calculateCuotac(this.calcannuityamount);
            for (int i = 1; i <= maxcalcperiod; i++)
            {
                sno = i;

                if (this.numberofyears >= sno)
                {
                    if ((i == 1) && (this.initialcontributioncode == 'Y'))
                    {
                        accountvalue = (1 + this.netgrowthrate) * (tempcuotac + accountvalue + this.initialcontributionamount * (1 - this.Loadchargepercent - this.Commission_cost));
                    }
                    else
                    {
                        accountvalue = (1 + this.netgrowthrate) * (tempcuotac + accountvalue);
                    }
                    annuitypaid = 0;
                }
                else
                {
                    if (i <= (this.numberofyears + this.defermentnoofyears))
                    {
                        accountvalue = (1 + this.netgrowthrate) * accountvalue;
                    }
                    else if(i>(this.numberofyears+this.defermentnoofyears))
                    {
                        accountvalue = (1 + this.netgrowthrate) * (accountvalue-this.annuityamount);
                    }                    
                }

                if (i <= (this.numberofyears + this.defermentnoofyears))
                {
                    costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);
                }
                else
                {
                    costofinsurance = 0;
                }                

                illdata[sno - 1] = new REDIllusdata();
                illdata[sno - 1].Accountvalue = accountvalue;

                if (sno <= (this.numberofyears + this.defermentnoofyears))
                {
                    if (sno == 1)
                    {
                        illdata[sno - 1].Penaltyvalue = premiumannualequivalent * (1 + this.netgrowthrate);
                    }
                    else
                    {
                        illdata[sno - 1].Penaltyvalue = (premiumannualequivalent + illdata[sno - 2].Penaltyvalue) * (1 + this.netgrowthrate);
                    }
                }
                else
                {
                    illdata[sno - 1].Penaltyvalue = accountvalue;
                }

                if (!((sno == 1) && (sno != this.numberofyears)))
                {
                    illdata[sno - 1].Partialretirementamount = sno > ((this.numberofyears)) ? 0 : -Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, (accountvalue - illdata[sno - 1].Penaltyvalue * ((100.0 - resarry[sno - 1]) / 100.0)), 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) * Math.Pow((1 + this.netgrowthrate), (this.numberofyears + this.defermentnoofyears - sno));
                }
                //illdata[sno-1].
                

                /* this is old excel way of calculating
                if (sno <= (this.numberofyears + this.defermentnoofyears))
                {
                    if (sno == 1)
                    {
                        illdata[sno - 1].Penaltyvalue = premiumannualequivalent * (1 + this.netgrowthrate);
                    }
                    else
                    {
                        illdata[sno - 1].Penaltyvalue = (premiumannualequivalent + illdata[sno - 2].Penaltyvalue) * (1 + this.netgrowthrate);
                    }
                }
                else
                {
                    illdata[sno - 1].Penaltyvalue = accountvalue;
                }
                 */ 
                
                //illdata[sno-1].Rescatevalue=this.Rescatepercentage*illdata[sno-1].Accountvalue-illdata[sno-1].Penaltyvalue*(1-
                if (sno < (this.numberofyears + this.defermentnoofyears + this.retirementnoofyears))
                {
                    if (sno > 2)
                    {
                        illdata[sno - 1].Rescatevalue = Math.Max(0, 0.9 * accountvalue - illdata[sno - 1].Penaltyvalue * ((100.0 - fullresarry[sno - 1]) / 100.0));
                    }
                    else
                    {
                        illdata[sno - 1].Rescatevalue = 0.0;
                    }                    
                }


                if (i <= this.numberofyears)
                {
                    if ((i == 1) && (this.initialcontributioncode == 'Y'))
                    {
                        illdata[sno - 1].Premium = this.periodicpremiumamount * this.frequencytypevalue + this.initialcontributionamount;
                        accumulatedpremium = this.periodicpremiumamount * this.frequencytypevalue + this.initialcontributionamount;
                    }
                    else
                    {
                        illdata[sno - 1].Premium = this.periodicpremiumamount * this.frequencytypevalue;
                        accumulatedpremium = accumulatedpremium + this.periodicpremiumamount * this.frequencytypevalue ;
                    }
                    illdata[sno - 1].Accumulatedpremium = accumulatedpremium;
                }
                else
                {
                    illdata[sno - 1].Accumulatedpremium = 0.0;
                }


                illdata[sno - 1].Sno = sno;
                illdata[sno - 1].Age = age + i - 1;

                if (sno <= (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Annuityamount = this.calcannuityamount;
                }
                else
                {
                    illdata[sno - 1].Annuityamount = 0;
                }                
                illdata[sno - 1].Costofinsurance = costofinsurance;
                if (sno <= (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Deathbenefit = annuityamount;
                }
                else
                {
                    illdata[sno - 1].Deathbenefit = 0;
                }
                /*
                if (i < this.Rescatestartyear)
                {
                    illdata[sno - 1].Rescatevalue = 0.0;
                }
                else
                {
                    illdata[sno - 1].Rescatevalue = getRescatevalue(sno, accountvalue);
                }
                 */ 

                
                /*
                if (sno <= this.numberofyears)
                {
                    illdata[sno - 1].Partialretirementamount = getPartialannualretirementamount(accountvalue, accumulatedpremium, sno);
                }
                else
                {
                    illdata[sno - 1].Partialretirementamount = 0.0;
                }*/

                /*
                if (sno <= (this.defermentnoofyears + this.numberofyears))
                {
                    if (this.plantypecode == Plantypes.INSURED)
                    {
                        illdata[sno - 1].Deathbenefit = annuityamount;
                    }
                    else
                    {
                        illdata[sno - 1].Deathbenefit = illdata[sno - 1].Discbenefit;
                    }
                }
                else
                {
                    illdata[sno - 1].Deathbenefit = 0;
                }
                 */ 

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
                                illdata[sno - 1].Discbenefit = - Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
                            }                            
                        }
                        //illdata[sno - 1].Deathbenefit = calcannuityamount;
                    }
                    else
                    {
                        if (sno == (this.defermentnoofyears + this.numberofyears))
                        {
                            illdata[sno - 1].Discbenefit =  - Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
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

                /*
                if (sno <= (this.numberofyears + this.defermentnoofyears))
                {
                    if (sno == (this.numberofyears + this.defermentnoofyears))
                    {
                        illdata[sno - 1].Discbenefit = this.calcannuityamount;
                    }
                    else
                    {
                        illdata[sno - 1].Discbenefit = -this.Monthlyfeevalueyear - Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
                    }                    
                }
                else
                {
                    illdata[sno - 1].Discbenefit = 0.0;
                }
                 */ 
            }
            return illdata;
        }




        public double calculatedPeriodicPremiumAmount()
        {
            if (this.calculatetypecode == 'P')
            {
                double netperiodicrate = Math.Pow((1 + growthrate), 1.0 / frequencytypevalue) - 1;
                return calculatePMT(annualizedpremiumamount, frequencytypevalue, netperiodicrate) * (1.0 + frequencytypepenalty);
            }
            else
            {
                return this.periodicpremiumamount;
            }
            
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

        private double getRescatevalue_old(int sno, double accountvalue)
        {
            if (surrenderpenaltydata.Length >= sno)
            {
                if (accountvalue > 0)
                {
                    return commissiondata[sno - 1].vr * accountvalue;
                }
            }
            return 0.0;

        }


        private double getRescatevalue(int sno, double accountvalue)
        {
            if (accountvalue > 0)
            {
                double penaltycharge = accountvalue * (this.calculatedtargetamount/ this.calcyearlypremium) * this.getSurrenderpenaltypercent(sno)
                + accountvalue * ((this.calcyearlypremium - this.calculatedtargetamount) / this.calcyearlypremium) * this.getSurrenderpenaltypercent(sno) * this.surrenderexcesspenalty + this.surrendercharge;
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
                return 0.0;// this.calculatedtargetamount * (1 - this.Minimumpremiumdiscountfactor);
            }
        }

        public double getPartialannualretirementamount(double accountvalue, double cumulativepremium, int sno)
        {


            //=-PMT('Cotizador 2'!$G$7-'Cotizador 2'!$F$32,
            //'Cotizador 2'!$B$12,
            //+(PV('Cotizador 2'!$G$7-'Cotizador 2'!$F$32,'Cotizador 2'!$B$13+'Cotizador 2'!$B$12-C17,
            //'Cotizador 2'!$G$31,,1)+G17)*(1+'Cotizador 2'!$G$7-'Cotizador 2'!$F$32)^('Cotizador 2'!$B$13-C17)*IF(C17='Cotizador 2'!$B$14,1,1),,1)

            double pvamt = (Microsoft.VisualBasic.Financial.PV(netgrowthrate, (this.defermentnoofyears + this.numberofyears + this.retirementnoofyears - sno),
                this.Monthlyfeevalueyear, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) + accountvalue);


            double annuityoutflow = -Microsoft.VisualBasic.Financial.Pmt(netgrowthrate, numberofyears,
                (Microsoft.VisualBasic.Financial.PV(netgrowthrate, (this.defermentnoofyears + this.numberofyears + this.retirementnoofyears - sno),
                this.Monthlyfeevalueyear, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) + accountvalue)
                * Math.Pow((1 + netgrowthrate),
                ((this.defermentnoofyears + this.numberofyears) - sno)), 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);

            if (annuityoutflow > 0)
            {

                if ((this.Minimumpremium * this.Retirementpartialtominprimamultiple) < cumulativepremium)
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

        public double calculateTargetamount()
        {
            double temptargetpercent = -Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate, this.Targetcontributionperiod, -Microsoft.VisualBasic.Financial.PV(this.netgrowthrate, this.numberofyears, this.calcyearlypremium, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod), 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
            return temptargetpercent * this.Yearlypremiumamount;
        }


        public double[] getPartialrescatearray()
        {
            double[] resarray = new double[this.numberofyears];

            double rescateper1 = (100 - 70)*1.0 / ((Math.Max(this.numberofyears, 4) - 3)*1.0);
            double rescateper2 = 100-rescateper1*this.numberofyears;
            int sno;
            for (int i = 0; i < this.numberofyears; i++)
            {
                sno = i + 1;
                if (sno == 1)
                {
                    resarray[i]=(sno==this.numberofyears)?100:0;                    
                }
                else if (sno == 2)
                {
                    resarray[i] = (sno == this.numberofyears) ? 100 : 35;
                }
                else if (sno == this.numberofyears)
                {
                    resarray[i] = 100;
                }
                else
                {
                    resarray[i] = rescateper1 * sno + rescateper2;
                }
            }
            return resarray;
        }

        public double[] getFullrescatearray()
        {
            double[] resarray = new double[this.numberofyears+this.retirementnoofyears+this.defermentnoofyears];

            double rescateper1 = 80.0 / (((this.numberofyears + this.defermentnoofyears) - 1)*1.0);
            double rescateper2 = 80 - rescateper1 * (this.numberofyears + this.defermentnoofyears);

            double rescateper11 = (100.0 - 80.0) / (this.retirementnoofyears * 1.0);
            double rescateper12 = 80.0 - rescateper11 * (this.numberofyears + this.defermentnoofyears);


            

            int sno;
            for (int i = 0; i < (this.numberofyears+this.defermentnoofyears+this.retirementnoofyears); i++)
            {
                sno = i + 1;
                if (sno == 1)
                {
                    resarray[i] =  0;
                }
                else if (sno <= (this.numberofyears+this.defermentnoofyears))
                {
                    resarray[i] = sno * rescateper1 + rescateper2;
                }
                else if (sno > (this.numberofyears + this.defermentnoofyears) && sno < (this.numberofyears + this.defermentnoofyears+this.retirementnoofyears))
                {
                    resarray[i] = sno * rescateper11 + rescateper12;
                }
                else 
                {
                    resarray[i] = 0;
                }
                
            }
            return resarray;
        }

        public double getInsuredamountFE()
        {
            return this.plantypecode=='S'?calcannuityamount*this.Insurancefactor:0.0;
        }

        public double getTargetamountFE()
        {
            double temptargetamount = this.Targetpercent * Actualpremiumpaid;
            if (temptargetamount < Actualpremiumpaid)
            {
                return temptargetamount;
            }
            else
            {
                return Actualpremiumpaid;
            }
        }
        /*
        txttargetpremium.Text = eduretire.getTargetAmountFE().ToString("f2");
            txtminpremium.Text = eduretire.getMinimumPremiumAmountFE().ToString("f2");
         */


        public double Targetpercent
        {
            get
            {
                //return Math.Min(1, -Financial.Pmt(this.growthrate - this.costoffunds, this.targetperiod, -Financial.PV(this.growthrate - this.costoffunds, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
                return Math.Min(1, -Financial.Pmt(this.growthrate, this.Targetcontributionperiod, -Financial.PV(this.growthrate, this.numberofyears, 1, 0, DueDate.BegOfPeriod), 0, DueDate.BegOfPeriod));
            }
        }

        public double Targetinitial
        {
            get
            {
                //return -Financial.Pmt(this.growthrate - this.costoffunds, this.targetperiod,this.initialcontributionamount , 0, DueDate.BegOfPeriod);
                return -Financial.Pmt(this.growthrate, this.Targetcontributionperiod, this.initialcontributionamount, 0, DueDate.BegOfPeriod);
            }
        }


        private double Actualpremiumpaid
        {
            get
            {
                return periodicpremiumamount * frequencytypevalue;
            }            
        }

        public double getAnnualizedPeriodicPremium()
        {
            return this.calcyearlypremium;
        }



    }

}