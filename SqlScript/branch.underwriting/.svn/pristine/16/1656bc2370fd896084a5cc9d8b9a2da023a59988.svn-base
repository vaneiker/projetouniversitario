using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;
using Microsoft.VisualBasic;
using WSVirtualOffice.Models.wsdata;
namespace WSVirtualOffice.Models.blinsurance
{
    public class IMainInsuranceData
    {

        public Boolean planerror=false;
        public String planerrordata="";
        
        public String product;
        public String plantype;
        public String contributiontype;

        public static int numtimescalled = 0;

        private String contributionuntilagestr;
        private String contributionperiodstr;

        public char classcode;

        public int untilage;
        public int numberofyears;
        
        public String calculatetype;

        private String insuredamountstr;
        public double insuredamount;

        private String periodicpremimamountstr;

        public double premiumcost;
        
        public double periodicpremiumamount;

        public String frequencytype;
        public String investmentprofile;
        public int age;
        public String gender;
        public String smoker;
        public String country;
        public String activityrisktype;
        public String healthrisktype;

        private String financialgoal;
        public int financialgoalage;
        private double financialgoalamount;

        private String initialcontribution;        
        public double initialcontributionamount;


        // start rider definition

        public String rideradb;        
        public double rideradbamount;

        public String riderterm;
        public int ridertermuntilage;
        public char ridertermcontributiontypecode;
        public double ridertermamount;

        public String rideracdb;        
        

        public String riderci;
        public double riderciamount;

        //public String rideroir;
        public double rideroiramount;
        public int oirage;
        public String oirgender;
        public String  oirsmoker;
        public int oiruntilage;
        public char oircontributiontypecode;
        public String oiractivityrisk;
        public String oirhealthrisk;

        public char rideradbcode = 'N';
        public char ridertermcode = 'N';
        public char rideracdbcode = 'N';
        public char ridercicode = 'N';
        public char rideroircode = 'N';

        public double rideradbcost;
        public double ridertermcost;
        public double rideracdbcost;
        public double ridercicost;
        public double rideroircost;


        private double calctargetamount;
        private double calcinsuredamount;
        private double calcminimumpremium;
        private double calcyearlypremium;
        private double calcriderpremium;
        
        // end rider definition        

        public String productcode;
        public char plantypecode;
        public char contributiontypecode;        
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

        public char oirgendercode;
        public char oirsmokercode;

        public double oiractivityrisktypevalue;
        public double oirhealthrisktypevalue;

        //public char healthrisktypecode_1;

        public char financialgoalcode;
        public char initialcontributioncode;

        public double annualizedpremiumamount;

        public double growthrate;
        public double costoffunds;
        public double netgrowthrate;


        public double countryrisk;
        private ICommissiondata[] commissiondata = null;

        private ISurrenderpenaltydata[] surrenderpenaltydata = null;

        public char fortargetcalculation = 'N';
        public double targetamountvariable = 0;

        public double[] varpremiumamount=null;
        public double[] varinsuredamount=null;
        public double[] varinvestprofile=null;
        public double[] varsurrenderamount=null;
        public double[] varloanamount=null;
        public double[] varloanrepayamount=null;

        public char varpremiumcode = 'N';
        public char varinsuredcode = 'N';
        public char varinvestprofilecode = 'N';
        public char varsurrendercode = 'N';
        public char varloancode = 'N';
        public char varloanrepaycode = 'N';

        
        
        
        private double targetaccountvalue=0.0;
        private double financialgoalprecision=5.0;
        private double precision = 50.0;

        private IMortalitydata[] mortalitydata = null;
        private IMortalitydata[] oirmortalitydata = null;

        // rule values
        public int insurancemaxage;
        

        public double GSMaximumtargetamount;
        public double GSMinimumtargetamount;
        public double GSMaximuminsuredamount;
        public double GSMinimuminsuredamount;
        public double GSMaximumpremiumamount;
        public double GSMinimumpremiumamount;

        public int insuranceunderage;
        public double insuranceunderageinsuredamount;

        public double Minimumpremiumamount;
        public double Minimuminsuredamount;
        public double Maximuminsuredamount;
        public double Targetoverage;
        public double Targetaddldiscount;
        public double Targetfactor;
        public double Premiumreserve;
        public int Targetcontributionperiod;
        public double Monthlyfeevalue;
        public double Monthlyfeevalueyear;
        public double Loadchargepercent;
        public int GSMinimumcontributionperiod;
        public int Maxage;
        public int Maxageforninguna;  
        public double Minimumpremiumtotargetfactor;
        public double Targetdiscountfactor;
        public int Rideradbmaxage;
        public double Rideradbfactor;
        public double surrendercharge;
        public double partialsurrendercharge;
        public double surrenderexcesspenalty;

        public double TargetNingunaPercent;
        public double LoanInterestRate;
        public double LoanPrincipalGrowthRate;
        public Boolean LoanPrincipalGrowInvestRate;

        public double InterestLoanRate;
        public double LoanAssetRate;
        public Boolean IsLoanRate;



        public Boolean isOpeningbalance = false;
        public int planyearstart;
        public double openingbalanceamount = 0.0;


        //public IAccountvalue.AVCALCULATETYPES tocalculate;


        public void setOpeningbalance(String planyearstartstr, String openingbalanceamountstr, String targetamountstr, String minimumpremiumstr)
        {
            isOpeningbalance = true;
            this.planyearstart = Int32.Parse(planyearstartstr);
            this.openingbalanceamount = double.Parse(openingbalanceamountstr);
            this.calctargetamount = double.Parse(targetamountstr);
            this.calcminimumpremium = double.Parse(minimumpremiumstr);
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
                //System.Windows.Forms.MessageBox.Show("Invprofile:" + varinvestprofile.Length.ToString());
            }
            return true;

        }


        public Boolean setVardata(int vardatatype,IVarPlanData[] varpdata)
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
                            if ((j+1) >= 1 && j < (this.numberofyears))
                            {
                                vartempamount[j] = varpdata[i].amount;
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
                varinsuredcode = 'Y';
                varinsuredamount = vartempamount;
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


        //public Boolean setVarLoanData(



        public IMainInsuranceData(String product, String plantype, String contributiontype, String contributionuntilagestr, String contributionperiodstr, String calculatetype, String insuredamountstr, String periodicpremimamountstr, String frequencytype, String investmentprofile, int age, String gender, String smoker, String country, String activityrisktype, String healthrisktype,char classcode)
        {
            this.classcode = classcode;
            this.product = product;
            this.productcode = Productdata.getProductcode(this.product);

            setRuledata();


            /*

            insurancemaxage = Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE, this.productcode);
            GSMaximumtargetamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_TARGET_AMOUNT, this.productcode);
            GSMinimumtargetamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_TARGET_AMOUNT, this.productcode);
            GSMaximuminsuredamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_INSURED_AMOUNT, this.productcode);
            GSMinimuminsuredamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_INSURED_AMOUNT, this.productcode);
            GSMaximumpremiumamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_PREMIUM_AMOUNT, this.productcode);
            GSMinimumpremiumamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_PREMIUM_AMOUNT, this.productcode);
            Minimumpremiumamount = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, this.productcode);
            Minimuminsuredamount = Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT, this.productcode);
            Maximuminsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, this.productcode);
            Targetoverage = Rules.getRulevaluedouble(Rules.TARGET_OVERAGE, this.productcode);
            Premiumreserve = Rules.getRulevaluedouble(Rules.PREMIUM_RESERVE, this.productcode);
            Targetcontributionperiod = Rules.getRulevalueint(Rules.TARGET_CONTRIBUTION_PERIOD, this.productcode);
            Monthlyfeevalue = Rules.getRulevaluedouble(Rules.MONTHLY_FEE, this.productcode);
            Monthlyfeevalueyear = this.Monthlyfeevalue * 12;
            Loadchargepercent = Rules.getRulevaluedouble(Rules.LOAD_CHARGE, this.productcode);
            GSMinimumcontributionperiod = Rules.getRulevalueint(Rules.GS_MINIMUM_CONTRIBUTION_PERIOD, this.productcode);
            Maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);
            Minimumpremiumtotargetfactor = Rules.getRulevaluedouble(Rules.MINIMUM_PREMIUM_TO_TARGET_FACTOR, this.productcode);
            Targetdiscountfactor = Rules.getRulevaluedouble(Rules.TARGET_DISCOUNT_FACTOR, this.productcode);
            Rideradbmaxage = Rules.getRulevalueint(Rules.ADB_MAX_AGE, this.productcode);
            Rideradbfactor = Rules.getRulevaluedouble(Rules.ADB_FACTOR, this.productcode);


            surrendercharge = Rules.getRulevaluedouble(Rules.SURRENDER_CHARGE, this.productcode);
            partialsurrendercharge = Rules.getRulevaluedouble(Rules.PARTIAL_SURRENDER_CHARGE, this.productcode);
            surrenderexcesspenalty = Rules.getRulevaluedouble(Rules.SURRENDER_EXCESS_PERCENT, this.productcode);

            Maxageforninguna = Rules.getRulevalueint(Rules.MAX_AGE_FOR_NINGUNA, this.productcode);

            this.TargetNingunaPercent = Rules.getRulevaluedouble(Rules.TARGET_NINGUNA_PERCENT, this.productcode);
            this.LoanInterestRate = Rules.getRulevaluedouble(Rules.LOAN_INTEREST_RATE, this.productcode);
            this.LoanPrincipalGrowthRate = Rules.getRulevaluedouble(Rules.LOAN_PRINCIPAL_GROWTH_RATE, this.productcode);
            this.LoanPrincipalGrowInvestRate = Rules.getRulevalueboolean(Rules.LOAN_PRINCIPAL_GROW_INVEST_RATE, this.productcode);

            this.InterestLoanRate = Rules.getRulevaluedouble(Rules.INTEREST_LOAN_RATE, this.productcode);
            this.LoanAssetRate= Rules.getRulevaluedouble(Rules.LOAN_ASSET_RATE, this.productcode);
            this.IsLoanRate = Rules.getRulevalueboolean(Rules.IS_LOAN_RATE, this.productcode);

             */
 
            /*
            public double InterestLoanRate;
            public double LoanAssetRate;
            public Boolean IsLoanRate;
            */
            //public double TargetNingunaPercent;
            //public double LoanInterestRate;
            //public double LoanPrincipalGrowthRate;
            //public Boolean LoanPrincipalGrowInvestRate;
            
            this.plantype = plantype;
            this.plantypecode = Plantypes.getPlantypecode(this.plantype);

            this.contributiontype = contributiontype;
            this.contributiontypecode = Contributiontypes.getcontributiontypecode(this.contributiontype);

            if (this.contributiontypecode == Contributiontypes.UNTILAGE)
            {
                if (!contributionuntilagestr.Trim().Equals(""))
                {
                    this.untilage = Int32.Parse(contributionuntilagestr);                    
                }
                else
                {
                    this.untilage = 0;
                }
                this.numberofyears = this.untilage - this.age + 1;
            }
            else if (this.contributiontypecode == Contributiontypes.NUMBEROFYEARS)
            {
                if (!contributionperiodstr.Trim().Equals(""))
                {
                    this.numberofyears = Int32.Parse(contributionperiodstr);
                }
                else
                {
                    this.numberofyears = 0;
                }
            }
            else if (this.contributiontypecode == Contributiontypes.CONTINUOUS)
            {
                this.numberofyears = this.insurancemaxage - this.age + 1;
            }


            
            //this.numberofyears = numberofyears;
            
            this.calculatetype = calculatetype;
            this.calculatetypecode = Calculatetypes.getcalculatetypecode(this.calculatetype);

            //if(this.calculatetypecode==Calculatetypes.
            /*
            if (this.calculatetypecode == Calculatetypes.INSUREDAMOUNT)
            {
                to     IAccountvalue.AVCALCULATETYPES.INSUREDAMOUNT;
            }
            */
            
            
            //this.periodicpremiumamount = periodicpremiumamount;
            
            this.frequencytype = frequencytype;
            this.frequencytypecode = Frequencytypes.getfrequencytypecode(this.frequencytype);
            this.frequencytypevalue = Frequencytypes.getfrequencytypevalue(this.frequencytype);
            this.frequencytypepenalty = Frequencytypes.getfrequencytypepenalty(this.frequencytype);

            this.investmentprofile = investmentprofile;
            this.investmentprofilecode = Invprofiledata.getInvestmentprofilecode(this.investmentprofile);


            
            this.age = age;
            
            this.gender= gender;
            this.gendercode = Genders.getgendercode(this.gender);
            
            this.smoker= smoker;
            this.smokercode = Booleandata.getBooleanvalue(this.smoker);
            
            this.country = country;
            this.countryno = Countries.getcountryno(this.country);

            this.activityrisktype = activityrisktype;
            this.activityrisktypevalue = Activityrisktypes.getActivityriskvalue(Activityrisktypes.getActivityrisktypeno(this.productcode, this.activityrisktype));



            this.healthrisktype = healthrisktype;
            this.healthrisktypevalue = Healthrisktypes.getHealthriskvalue(Healthrisktypes.getHealthrisktypeno(this.productcode, this.healthrisktype));



            this.growthrate= Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode,classcode);



            
            


            // calculating mortality data

            int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
            mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode,classcode);
            /*
            mortalitydata = new IMortalitydata[maxage - age + 1];
            for (int i = age; i <= maxage; i++)
            {
                mortalitydata[i - age] = new IMortalitydata();
                int sno = i - age + 1;
                mortalitydata[sno - 1].age = age + sno - 1;
                mortalitydata[sno - 1].sno = sno;
                mortalitydata[sno - 1].mortalityvalue = Mortalityrates.getMortalityrate(this.productcode,Ridertypes.Primary, mortalitydata[sno - 1].age, this.gendercode, this.smokercode);
            }
             */






            this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode, this.classcode);
            netgrowthrate = (this.growthrate - this.costoffunds);



            countryrisk = Countries.getRiskvalue(this.country);


            //per

            if (Program.isdecimal(insuredamountstr) == true)
            {
                this.insuredamount = double.Parse(insuredamountstr);
                this.calcinsuredamount = this.insuredamount;
            }
            else
            {
                this.insuredamount = 0.0;
                this.calcinsuredamount = 0.0;

            }

            if (Program.isdecimal(periodicpremimamountstr) == true)
            {
                this.periodicpremiumamount = double.Parse(periodicpremimamountstr);
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                //MessageBox.Show(netperiodicpayment.ToString());
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                //MessageBox.Show(periodicgrowthrate.ToString());
                annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                this.calcyearlypremium = annualizedpremiumamount;
            }
            else
            {
                this.periodicpremiumamount = 0.0;
                this.annualizedpremiumamount = 0.0;
                this.calcyearlypremium = 0;
            }
             


            // calculating commission data
            commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);
            /*
            commissiondata = new ICommissiondata[this.Maxage - age + 1];
            for (int i = age; i <= this.Maxage; i++)
            {
                commissiondata[i - age] = new ICommissiondata();
                int sno = i - age + 1;
                commissiondata[sno - 1].sno = sno;
                commissiondata[sno - 1].commissionpercent = Commissions.getCommissionpercentvalue(this.productcode, sno);
                commissiondata[sno - 1].excesscommissionpercent = Commissions.getExcesscommissionpercent(this.productcode, sno);
            }
             */

            surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0);
            /*
            surrenderpenaltydata = new ISurrenderpenaltydata[this.Maxage - age + 1];
            for (int i = age; i <= this.Maxage; i++)
            {
                surrenderpenaltydata[i - age] = new ISurrenderpenaltydata();
                int sno = i - age + 1;
                surrenderpenaltydata[sno - 1].sno = sno;
                surrenderpenaltydata[sno - 1].penaltypercent= Surrenderpenaties.getSurrenderpenaltyvalue(this.productcode, sno);                
            }
             */ 

            



        }



        public void setRuledata()
        {
            insurancemaxage = Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE, this.productcode,this.classcode);
            GSMaximumtargetamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_TARGET_AMOUNT, this.productcode, this.classcode);
            GSMinimumtargetamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_TARGET_AMOUNT, this.productcode, this.classcode);
            GSMaximuminsuredamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_INSURED_AMOUNT, this.productcode, this.classcode);
            GSMinimuminsuredamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_INSURED_AMOUNT, this.productcode, this.classcode);
            GSMaximumpremiumamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_PREMIUM_AMOUNT, this.productcode, this.classcode);
            GSMinimumpremiumamount = Rules.getRulevaluedouble(Rules.GS_MINIMUM_PREMIUM_AMOUNT, this.productcode, this.classcode);
            Minimumpremiumamount = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, this.productcode, this.classcode);
            Minimuminsuredamount = Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT, this.productcode, this.classcode);
            Maximuminsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, this.productcode, this.classcode);
            Targetoverage = Rules.getRulevaluedouble(Rules.TARGET_OVERAGE, this.productcode, this.classcode);
            Targetaddldiscount = Rules.getRulevaluedouble(Rules.TARGET_ADDL_DISCOUNT, this.productcode, this.classcode);
            Premiumreserve = Rules.getRulevaluedouble(Rules.PREMIUM_RESERVE, this.productcode, this.classcode);
            Targetcontributionperiod = Rules.getRulevalueint(Rules.TARGET_CONTRIBUTION_PERIOD, this.productcode, this.classcode);
            Monthlyfeevalue = Rules.getRulevaluedouble(Rules.MONTHLY_FEE, this.productcode, this.classcode);
            Monthlyfeevalueyear = this.Monthlyfeevalue * 12;
            Loadchargepercent = Rules.getRulevaluedouble(Rules.LOAD_CHARGE, this.productcode, this.classcode);
            GSMinimumcontributionperiod = Rules.getRulevalueint(Rules.GS_MINIMUM_CONTRIBUTION_PERIOD, this.productcode, this.classcode);
            Maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
            Minimumpremiumtotargetfactor = Rules.getRulevaluedouble(Rules.MINIMUM_PREMIUM_TO_TARGET_FACTOR, this.productcode, this.classcode);
            Targetdiscountfactor = Rules.getRulevaluedouble(Rules.TARGET_DISCOUNT_FACTOR, this.productcode, this.classcode);
            Rideradbmaxage = Rules.getRulevalueint(Rules.ADB_MAX_AGE, this.productcode, this.classcode);
            Rideradbfactor = Rules.getRulevaluedouble(Rules.ADB_FACTOR, this.productcode, this.classcode);

            insuranceunderage = Rules.getRulevalueint(Rules.INSURANCE_UNDERAGE, this.productcode, this.classcode);
            insuranceunderageinsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT_UNDERAGE, this.productcode, this.classcode);

            surrendercharge = Rules.getRulevaluedouble(Rules.SURRENDER_CHARGE, this.productcode, this.classcode);
            partialsurrendercharge = Rules.getRulevaluedouble(Rules.PARTIAL_SURRENDER_CHARGE, this.productcode, this.classcode);
            surrenderexcesspenalty = Rules.getRulevaluedouble(Rules.SURRENDER_EXCESS_PERCENT, this.productcode, this.classcode);

            Maxageforninguna = Rules.getRulevalueint(Rules.MAX_AGE_FOR_NINGUNA, this.productcode, this.classcode);

            this.TargetNingunaPercent = Rules.getRulevaluedouble(Rules.TARGET_NINGUNA_PERCENT, this.productcode, this.classcode);
            this.LoanInterestRate = Rules.getRulevaluedouble(Rules.LOAN_INTEREST_RATE, this.productcode, this.classcode);
            this.LoanPrincipalGrowthRate = Rules.getRulevaluedouble(Rules.LOAN_PRINCIPAL_GROWTH_RATE, this.productcode, this.classcode);
            this.LoanPrincipalGrowInvestRate = Rules.getRulevalueboolean(Rules.LOAN_PRINCIPAL_GROW_INVEST_RATE, this.productcode, this.classcode);

            this.InterestLoanRate = Rules.getRulevaluedouble(Rules.INTEREST_LOAN_RATE, this.productcode, this.classcode);
            this.LoanAssetRate = Rules.getRulevaluedouble(Rules.LOAN_ASSET_RATE, this.productcode, this.classcode);
            this.IsLoanRate = Rules.getRulevalueboolean(Rules.IS_LOAN_RATE, this.productcode, this.classcode);

        }


        /*
        public IMainInsuranceData(long customerplanno)
        {
            // beg
            customerPlandet custplan = (from item in newdb.customerPlandets
                                        where item.customerPlanno == customerplanno
                                        select item).SingleOrDefault();

            customerdet cust = (from item in newdb.customerdets
                                where item.customerno == custplan.customerno
                                select item).SingleOrDefault();
            //this.product = product;
            this.productcode = custplan.productcode;
            setRuledata();
            // end right
            // beg
            this.plantypecode = custplan.plantypecode;
            //this.contributiontype = contributiontype;
            this.contributiontypecode = custplan.contributiontypecode;// Contributiontypes.getcontributiontypecode(this.contributiontype);

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
            //end            
            // beg
            this.calculatetypecode = custplan.calculatetypecode;            
            //this.frequencytype = frequencytype;
            this.frequencytypecode = custplan.frequencytypecode;
            this.frequencytype = Frequencytypes.getfrequencytype(custplan.frequencytypecode);
            this.frequencytypevalue = Frequencytypes.getfrequencytypevalue(this.frequencytype);
            this.frequencytypepenalty = Frequencytypes.getfrequencytypepenalty(this.frequencytype);

            //this.investmentprofile = investmentprofile;
            this.investmentprofilecode = custplan.investmentprofilecode;// Invprofiledata.getInvestmentprofilecode(this.investmentprofile);
            this.age = Int32.Parse(cust.Age.ToString());
            //this.gender = gender;
            this.gendercode = cust.gendercode;
            //this.smoker = smoker;
            this.smokercode = cust.Smoker;
            //this.country = country;
            this.countryno = custplan.countryno;
            //this.periodicpremiumamount = periodicpremiumamount;


            // beg
            this.activityrisktypevalue = Activityrisktypes.getActivityriskvalue(custplan.activityrisktypeno);
            this.healthrisktypevalue = Healthrisktypes.getHealthriskvalue(custplan.healthrisktypeno);
            this.classcode = custplan.@class;
            this.growthrate = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode, classcode);
            // calculating mortality data
            int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);
            mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode);
            // end

            this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode);
            netgrowthrate = (this.growthrate - this.costoffunds);
            countryrisk = Countries.getCountryriskvalue(this.countryno);
            //per
            
            this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
            this.calcinsuredamount = this.insuredamount;

            this.periodicpremiumamount = double.Parse(custplan.premiumamount.ToString());
            double penaltypercent = this.frequencytypepenalty;
            double netperiodicpayment = this.periodicpremiumamount / (1 + penaltypercent);
            
            double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
            
            annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
            this.calcyearlypremium = annualizedpremiumamount;


            commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);            
            surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0);


            this.setFinancialgoal(Booleandata.getBooleanstring(custplan.financialgoal), custplan.financialgoalamount.ToString(), custplan.financialgoalage.ToString());// = double.Parse(txtfingoalamt.Text);
            //insmaindata.financialgoalage = Int32.Parse(txtfingoaluntilage.Text);


            this.setInitialcontribution(
                (custplan.initialcontribution.ToString().Equals("0.0")) ? "No" : "Yes",
                custplan.initialcontribution.ToString());//// = ddlinitialcontribution.Text;

            this.setRideradbdata(Booleandata.getBooleanstring(custplan.rideradb), custplan.rideradbamount.ToString());
            
            this.rideradbcost = double.Parse(custplan.rideradbcost.ToString());
            this.setRideracdbdata(Booleandata.getBooleanstring(custplan.rideracdb));
            this.rideracdbcost = double.Parse(custplan.rideracdbcost.ToString());
            this.setRidercidata(Booleandata.getBooleanstring(custplan.riderci), custplan.riderciamount.ToString());
            this.ridercicost = double.Parse(custplan.ridercicost.ToString());
            String ridertermcontributiontype = Contributiontypes.getcontributiontype(custplan.termcontributiontypecode.Value);

            this.setRidertermdata(Booleandata.getBooleanstring(custplan.riderterm), custplan.ridertermamount.ToString(), custplan.ridertermuntilage.ToString(),ridertermcontributiontype);
            this.ridertermcost = double.Parse(custplan.ridertermcost.ToString());

            if (custplan.rideroir == 'Y')
            {
                customerplanpartnerinsurancedet othins = (from item in newdb.customerplanpartnerinsurancedets
                                                          where item.customerplanno == custplan.customerPlanno
                                                          select item).SingleOrDefault();
                this.setOirdata(Booleandata.getBooleanstring(custplan.rideroir), othins.rideroiramount.ToString(),
                    othins.age.ToString(),
                    Genders.getgender(othins.gendercode.Value), Booleandata.getBooleanstring(othins.smoker),
                    othins.untilage.ToString(),
                    Activityrisktypes.getActivityrisktype(othins.activityrisktypeno.Value),
                    Healthrisktypes.getHealthrisktype(othins.healthrisktypeno.Value),Contributiontypes.getcontributiontype(othins.contributiontypecode.Value));
                this.rideroircost = double.Parse(othins.rideroircost.ToString());
            }



            var premdata = from item in newdb.customerplanvarpremiumdets
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


            var insdata = from item in newdb.customerplanvarinsureddets
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
                setVardata(IVarPlanData.SURRENDER, ivdata);
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


            

        }
        */


        public IMainInsuranceData(long customerplanno)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                //String product, String plantype, String contributiontype, String contributionuntilagestr, String contributionperiodstr, String calculatetype, String insuredamountstr, String periodicpremimamountstr, String frequencytype, String investmentprofile, int age, String gender, String smoker, String country, String activityrisktype, String healthrisktype, char classcode
                customerPlandet custplan = (from item in newdb.customerPlandets
                                            where item.customerPlanno == customerplanno
                                            select item).SingleOrDefault();

                customerdet cust = (from item in newdb.customerdets
                                    where item.customerno == custplan.customerno
                                    select item).SingleOrDefault();

                // product code is set and also product
                this.classcode = custplan.@class;
                this.product = Productdata.getProduct(custplan.productcode);
                this.productcode = custplan.productcode;

                // the rules are set here //
                setRuledata();


                // plantype is set properly plantypes are restricted to 'F','I'
                this.plantype = Plantypes.getPlantype(custplan.plantypecode);
                this.plantypecode = custplan.plantypecode;

                // contributiontypecode is set properly inclusing the number of years but age need to be checked and looked //
                this.contributiontype = Contributiontypes.getcontributiontype(custplan.contributiontypecode);
                this.contributiontypecode = custplan.contributiontypecode;

                this.age = int.Parse(cust.Age);
                if (this.age <= 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " age cannot be 0";
                }

                if (this.contributiontypecode == Contributiontypes.UNTILAGE)
                {
                    this.untilage = custplan.contributionuntilage;
                    this.numberofyears = this.untilage - this.age + 1;
                }
                else if (this.contributiontypecode == Contributiontypes.NUMBEROFYEARS)
                {
                    this.numberofyears = custplan.contributionperiod;
                }
                else if (this.contributiontypecode == Contributiontypes.CONTINUOUS)
                {
                    this.numberofyears = this.insurancemaxage - this.age + 1;
                }



                //this.numberofyears = numberofyears;
                this.calculatetype = Calculatetypes.getcalculatetype(custplan.calculatetypecode);
                this.calculatetypecode = custplan.calculatetypecode;


                //this.periodicpremiumamount = periodicpremiumamount;
                this.frequencytype = Frequencytypes.getfrequencytype(custplan.frequencytypecode);
                this.frequencytypecode = custplan.frequencytypecode;
                this.frequencytypevalue = Frequencytypes.getfrequencytypevalue(this.frequencytype);
                this.frequencytypepenalty = Frequencytypes.getfrequencytypepenalty(this.frequencytype);


                this.investmentprofile = Invprofiledata.getInvestmentprofile(custplan.investmentprofilecode);
                this.investmentprofilecode = custplan.investmentprofilecode;
                if (this.investmentprofilecode == ' ')
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " investment profile cannot be empty";
                }

                // age is already set
                //this.age = age;
                // gender is set here //

                this.gendercode = cust.gendercode;
                this.gender = Genders.getgender(cust.gendercode);
                if (gendercode == ' ')
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " gender cannot be empty";
                }


                // smoker is set here //
                this.smoker = Booleandata.getBooleanstring(cust.Smoker);
                this.smokercode = cust.Smoker;
                if (this.smokercode == ' ')
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " smoker cannot be empty";
                }

                // country data is set
                this.country = Countries.getcountry(custplan.countryno);// country;
                this.countryno = custplan.countryno;
                if (this.countryno == 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " country cannot be empty";
                }


                // activity risk data is set
                this.activityrisktype = Activityrisktypes.getActivityrisktype(custplan.activityrisktypeno);// activityrisktype;
                this.activityrisktypevalue = Activityrisktypes.getActivityriskvalue(custplan.activityrisktypeno);// Activityrisktypes.getActivityriskvalue(Activityrisktypes.getActivityrisktypeno(this.productcode, this.activityrisktype));


                // health risk data is set
                this.healthrisktype = Healthrisktypes.getHealthrisktype(custplan.healthrisktypeno);// healthrisktype;
                this.healthrisktypevalue = Healthrisktypes.getHealthriskvalue(custplan.healthrisktypeno);


                // growth rate data is set
                this.growthrate = Productinvprofile.getInvprofilerate(custplan.investmentprofilecode, this.productcode, this.classcode);
                if (this.growthrate <= 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " growth rate cannot be 0";
                }


                // calculating mortality data
                int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode,classcode);


                this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode,this.classcode);
                netgrowthrate = (this.growthrate - this.costoffunds);


                countryrisk = Countries.getRiskvalueByNo(this.countryno);


                //insured amount is set here            
                this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
                this.calcinsuredamount = this.insuredamount;

                // a change is made here, there should be no impact
                this.periodicpremiumamount = Numericdata.getDoublevalue(custplan.premiumamount.ToString());
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                //MessageBox.Show(netperiodicpayment.ToString());
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                //MessageBox.Show(periodicgrowthrate.ToString());
                annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                this.calcyearlypremium = annualizedpremiumamount;
                /*
                if (Program.isdecimal(periodicpremimamountstr) == true)
                {
                    this.periodicpremiumamount = double.Parse(periodicpremimamountstr);
                    double penaltypercent = this.frequencytypepenalty;
                    double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                    //MessageBox.Show(netperiodicpayment.ToString());
                    double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                    //MessageBox.Show(periodicgrowthrate.ToString());
                    annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                    this.calcyearlypremium = annualizedpremiumamount;
                }
                else
                {
                    this.periodicpremiumamount = 0.0;
                    this.annualizedpremiumamount = 0.0;
                    this.calcyearlypremium = 0;
                }
                 */



                // calculating commission data
                // no change is required here
                commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);
                /*
                commissiondata = new ICommissiondata[this.Maxage - age + 1];
                for (int i = age; i <= this.Maxage; i++)
                {
                    commissiondata[i - age] = new ICommissiondata();
                    int sno = i - age + 1;
                    commissiondata[sno - 1].sno = sno;
                    commissiondata[sno - 1].commissionpercent = Commissions.getCommissionpercentvalue(this.productcode, sno);
                    commissiondata[sno - 1].excesscommissionpercent = Commissions.getExcesscommissionpercent(this.productcode, sno);
                }
                 */

                // no change is required here
                surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0);
                /*
                surrenderpenaltydata = new ISurrenderpenaltydata[this.Maxage - age + 1];
                for (int i = age; i <= this.Maxage; i++)
                {
                    surrenderpenaltydata[i - age] = new ISurrenderpenaltydata();
                    int sno = i - age + 1;
                    surrenderpenaltydata[sno - 1].sno = sno;
                    surrenderpenaltydata[sno - 1].penaltypercent= Surrenderpenaties.getSurrenderpenaltyvalue(this.productcode, sno);                
                }
                 */


                /*  this is copied from the other function and needs to be validated with the custplan actual in planinfo class
                 * 
                 */


                /*
                 * 
                 * 
                 * 
                   financial goal is set correctly 
                 * insmaindata.setFinancialgoal(ddlfingoal.Text, txtfingoalamt.Text, txtfingoaluntilage.Text);// = double.Parse(txtfingoalamt.Text);
                    //insmaindata.financialgoalage = Int32.Parse(txtfingoaluntilage.Text);

                 * 
                    if (Sessionclass.getSessiondata(Session).clientmode == Sessionclass.CASECLIENTMODES.POLICYUPDATE)
                    {
                        insmaindata.setOpeningbalance(ddlplanyear.Text, txtAdjustedAcctValue.Text, TxtForceTarget.Text, txtminpremiumop.Text);
                    }

                    insmaindata.setInitialcontribution(ddlinitialcontribution.Text, txtinitialcontributionamount.Text);//// = ddlinitialcontribution.Text;

                    insmaindata.setRideradbdata(rideradb1, rideradbamount1);
                    insmaindata.setRideracdbdata(rideracdb1);
                    insmaindata.setRidercidata(riderci1, riderciamount1);
                    insmaindata.setRidertermdata(riderterm1, ridertermamount1, ridertermuntilage1, ridertermuntilage1);
                    insmaindata.setOirdata(rideroir1, rideroiramount1, riderpartinsage1, riderpartinsgender1, riderpartinssmoker1, riderpartinsuntilage1, rideractivityrisktypeno1, riderhealthrisktypeno1, ridertermuntilagespouse1);


                    var premdata = from item in newdb.customerplanvarpremiumdets
                                   where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.PREMIUM, ivdata);
                    }


                    var insdata = from item in newdb.customerplanvarinsureddets
                                  where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.INSURED, ivdata);
                    }


                    var loandata = from item in newdb.customerplanloandets
                                   where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.LOAN, ivdata);
                    }


                    var repaydata = from item in newdb.customerplanloanrepaydets
                                    where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.LOANREPAY, ivdata);
                    }



                    var surrenderdata = from item in newdb.customerplanvarsurrenderdets
                                        where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.SURRENDER, ivdata);
                    }


                    var profiledata = from item in newdb.customerplanvarprofiledets
                                      where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVarinvprofiledata(ivdata1);
                    }


            
                 * 
                 */


                this.setFinancialgoal(Booleandata.getBooleanstring(custplan.financialgoal), custplan.financialgoalamount.ToString(), custplan.financialgoalage.ToString());// = double.Parse(txtfingoalamt.Text);
                if (custplan.financialgoal == 'Y')
                {
                    if (custplan.financialgoalage < this.age)
                    {
                        this.planerror = true;
                        // need to create a string in languages so that, that particular string instead
                        this.planerrordata = this.planerrordata + " financialgoal age rate cannot be less than age";
                    }
                }
                //insmaindata.financialgoalage = Int32.Parse(txtfingoaluntilage.Text);

                if (custplan.isopeningbalance == 'Y')
                {
                    customerplanopbaldet custopbal = (from item in newdb.customerplanopbaldets
                                                      where item.customerplanno == customerplanno
                                                      select item).SingleOrDefault();


                    this.setOpeningbalance(custopbal.planyear.ToString(), custopbal.adjustedaccountvalue.ToString(), custopbal.forcetarget.ToString(), custopbal.minimumpremium.ToString());
                }

                // initial contribution should work ok
                this.setInitialcontribution(
                    (Numericdata.getDoublevalue(custplan.initialcontribution.ToString()) == 0) ? "No" : "Yes",
                    custplan.initialcontribution.ToString());//// = ddlinitialcontribution.Text;

                // rider adb should work ok
                this.setRideradbdata(Booleandata.getBooleanstring(custplan.rideradb), custplan.rideradbamount.ToString());
                this.rideradbcost = double.Parse(custplan.rideradbcost.ToString());

                // rider acdb should work ok
                this.setRideracdbdata(Booleandata.getBooleanstring(custplan.rideracdb));
                this.rideracdbcost = double.Parse(custplan.rideracdbcost.ToString());

                // rider ci should work ok
                this.setRidercidata(Booleandata.getBooleanstring(custplan.riderci), custplan.riderciamount.ToString());
                this.ridercicost = double.Parse(custplan.ridercicost.ToString());


                // the code needs to be checked properly from here
                // rider term should work ok
                String ridertermcontributiontype = Contributiontypes.getcontributiontype(custplan.termcontributiontypecode);
                this.setRidertermdata(Booleandata.getBooleanstring(custplan.riderterm), custplan.ridertermamount.ToString(), custplan.ridertermuntilage.ToString(), ridertermcontributiontype);
                this.ridertermcost = double.Parse(custplan.ridertermcost.ToString());

                if (custplan.rideroir == 'Y')
                {
                    //insmaindata.setOirdata(rideroir1, 
                    //  rideroiramount1, 
                    //riderpartinsage1, 
                    //riderpartinsgender1, 
                    //riderpartinssmoker1, 
                    //riderpartinsuntilage1, 
                    //rideractivityrisktypeno1, 
                    //riderhealthrisktypeno1, 
                    //ridertermuntilagespouse1);

                    customerplanpartnerinsurancedet othins = (from item in newdb.customerplanpartnerinsurancedets
                                                              where item.customerplanno == custplan.customerPlanno
                                                              select item).SingleOrDefault();


                    setOirdatavals(custplan.rideroir, Numericdata.getDoublevalue(othins.rideroiramount.ToString()),
                        Numericdata.getIntegervalue(othins.age.ToString()),
                        othins.gendercode.Value, othins.smoker,
                        Numericdata.getIntegervalue(othins.untilage.ToString()),
                        othins.activityrisktypeno.Value,
                        othins.healthrisktypeno.Value, othins.contributiontypecode.Value);

                    /*
                    this.setOirdata(Booleandata.getBooleanstring(custplan.rideroir), othins.rideroiramount.ToString(),
                        othins.age.ToString(),
                        Genders.getgender(othins.gendercode.Value), Booleandata.getBooleanstring(othins.smoker),
                        othins.untilage.ToString(),
                        Activityrisktypes.getActivityrisktype(othins.activityrisktypeno.Value),
                        Healthrisktypes.getHealthrisktype(othins.healthrisktypeno.Value), Contributiontypes.getcontributiontype(othins.contributiontypecode.Value));
                    */
                    this.rideroircost = double.Parse(othins.rideroircost.ToString());
                }



                var premdata = from item in newdb.customerplanvarpremiumdets
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


                var insdata = from item in newdb.customerplanvarinsureddets
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
                    setVardata(IVarPlanData.SURRENDER, ivdata);
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






            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
        }

        public IMainInsuranceData(WSCustomer cust, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partnerins)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                

                // product code is set and also product
                this.classcode = custplan.classcode.ToCharArray()[0];
                this.product = Productdata.getProduct(custplan.productcode);
                this.productcode = custplan.productcode;

                // the rules are set here //
                setRuledata();


                // plantype is set properly plantypes are restricted to 'F','I'
                this.plantype = Plantypes.getPlantype(custplan.plantypecode.ToCharArray()[0]);
                this.plantypecode = custplan.plantypecode.ToCharArray()[0];

                // contributiontypecode is set properly inclusing the number of years but age need to be checked and looked //
                this.contributiontype = Contributiontypes.getcontributiontype(custplan.contributiontypecode.ToCharArray()[0]);
                this.contributiontypecode = custplan.contributiontypecode.ToCharArray()[0];

                this.age = cust.Age;
                if (this.age <= 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " age cannot be 0";
                }

                if (this.contributiontypecode == Contributiontypes.UNTILAGE)
                {
                    this.untilage = custplan.contributionuntilage;
                    this.numberofyears = this.untilage - this.age + 1;
                }
                else if (this.contributiontypecode == Contributiontypes.NUMBEROFYEARS)
                {
                    this.numberofyears = custplan.contributionperiod;
                }
                else if (this.contributiontypecode == Contributiontypes.CONTINUOUS)
                {
                    this.numberofyears = this.insurancemaxage - this.age + 1;
                }



                //this.numberofyears = numberofyears;
                this.calculatetype = Calculatetypes.getcalculatetype(custplan.calculatetypecode.ToCharArray()[0]);
                this.calculatetypecode = custplan.calculatetypecode.ToCharArray()[0];


                //this.periodicpremiumamount = periodicpremiumamount;
                this.frequencytype = Frequencytypes.getfrequencytype(custplan.frequencytypecode.ToCharArray()[0]);
                this.frequencytypecode = custplan.frequencytypecode.ToCharArray()[0];
                this.frequencytypevalue = Frequencytypes.getfrequencytypevalue(this.frequencytype);
                this.frequencytypepenalty = Frequencytypes.getfrequencytypepenalty(this.frequencytype);


                this.investmentprofile = Invprofiledata.getInvestmentprofile(custplan.investmentprofilecode.ToCharArray()[0]);
                this.investmentprofilecode = custplan.investmentprofilecode.ToCharArray()[0];
                if (this.investmentprofilecode == ' ')
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " investment profile cannot be empty";
                }

                // age is already set
                //this.age = age;
                // gender is set here //

                this.gendercode = cust.gendercode.ToCharArray()[0];
                this.gender = Genders.getgender(cust.gendercode.ToCharArray()[0]);
                if (gendercode == ' ')
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " gender cannot be empty";
                }


                // smoker is set here //
                this.smoker = Booleandata.getBooleanstring(cust.Smoker.ToCharArray()[0]);
                this.smokercode = cust.Smoker.ToCharArray()[0];
                if (this.smokercode == ' ')
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " smoker cannot be empty";
                }

                // country data is set
                this.country = Countries.getcountry(custplan.countryno);// country;
                this.countryno = custplan.countryno;
                if (this.countryno == 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " country cannot be empty";
                }


                // activity risk data is set
                this.activityrisktype = Activityrisktypes.getActivityrisktype(custplan.activityrisktypeno);// activityrisktype;
                this.activityrisktypevalue = Activityrisktypes.getActivityriskvalue(custplan.activityrisktypeno);// Activityrisktypes.getActivityriskvalue(Activityrisktypes.getActivityrisktypeno(this.productcode, this.activityrisktype));


                // health risk data is set
                this.healthrisktype = Healthrisktypes.getHealthrisktype(custplan.healthrisktypeno);// healthrisktype;
                this.healthrisktypevalue = Healthrisktypes.getHealthriskvalue(custplan.healthrisktypeno);


                // growth rate data is set
                this.growthrate = Productinvprofile.getInvprofilerate(custplan.investmentprofilecode.ToCharArray()[0], this.productcode, this.classcode);
                if (this.growthrate <= 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " growth rate cannot be 0";
                }


                // calculating mortality data
                int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode, this.classcode);
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, Ridertypes.Primary, this.age, this.gendercode, this.smokercode, classcode);


                this.costoffunds = Rules.getRulevaluedouble(Rules.FUND_COST, this.productcode, this.classcode);
                netgrowthrate = (this.growthrate - this.costoffunds);


                countryrisk = Countries.getRiskvalueByNo(this.countryno);


                //insured amount is set here            
                this.insuredamount = Numericdata.getDoublevalue(custplan.insuredamount.ToString());
                this.calcinsuredamount = this.insuredamount;

                // a change is made here, there should be no impact
                this.periodicpremiumamount = Numericdata.getDoublevalue(custplan.premiumamount.ToString());
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                //MessageBox.Show(netperiodicpayment.ToString());
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                //MessageBox.Show(periodicgrowthrate.ToString());
                annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                this.calcyearlypremium = annualizedpremiumamount;
                /*
                if (Program.isdecimal(periodicpremimamountstr) == true)
                {
                    this.periodicpremiumamount = double.Parse(periodicpremimamountstr);
                    double penaltypercent = this.frequencytypepenalty;
                    double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                    //MessageBox.Show(netperiodicpayment.ToString());
                    double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                    //MessageBox.Show(periodicgrowthrate.ToString());
                    annualizedpremiumamount = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                    this.calcyearlypremium = annualizedpremiumamount;
                }
                else
                {
                    this.periodicpremiumamount = 0.0;
                    this.annualizedpremiumamount = 0.0;
                    this.calcyearlypremium = 0;
                }
                 */



                // calculating commission data
                // no change is required here
                commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears);
                /*
                commissiondata = new ICommissiondata[this.Maxage - age + 1];
                for (int i = age; i <= this.Maxage; i++)
                {
                    commissiondata[i - age] = new ICommissiondata();
                    int sno = i - age + 1;
                    commissiondata[sno - 1].sno = sno;
                    commissiondata[sno - 1].commissionpercent = Commissions.getCommissionpercentvalue(this.productcode, sno);
                    commissiondata[sno - 1].excesscommissionpercent = Commissions.getExcesscommissionpercent(this.productcode, sno);
                }
                 */

                // no change is required here
                surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0);
                /*
                surrenderpenaltydata = new ISurrenderpenaltydata[this.Maxage - age + 1];
                for (int i = age; i <= this.Maxage; i++)
                {
                    surrenderpenaltydata[i - age] = new ISurrenderpenaltydata();
                    int sno = i - age + 1;
                    surrenderpenaltydata[sno - 1].sno = sno;
                    surrenderpenaltydata[sno - 1].penaltypercent= Surrenderpenaties.getSurrenderpenaltyvalue(this.productcode, sno);                
                }
                 */


                /*  this is copied from the other function and needs to be validated with the custplan actual in planinfo class
                 * 
                 */


                /*
                 * 
                 * 
                 * 
                   financial goal is set correctly 
                 * insmaindata.setFinancialgoal(ddlfingoal.Text, txtfingoalamt.Text, txtfingoaluntilage.Text);// = double.Parse(txtfingoalamt.Text);
                    //insmaindata.financialgoalage = Int32.Parse(txtfingoaluntilage.Text);

                 * 
                    if (Sessionclass.getSessiondata(Session).clientmode == Sessionclass.CASECLIENTMODES.POLICYUPDATE)
                    {
                        insmaindata.setOpeningbalance(ddlplanyear.Text, txtAdjustedAcctValue.Text, TxtForceTarget.Text, txtminpremiumop.Text);
                    }

                    insmaindata.setInitialcontribution(ddlinitialcontribution.Text, txtinitialcontributionamount.Text);//// = ddlinitialcontribution.Text;

                    insmaindata.setRideradbdata(rideradb1, rideradbamount1);
                    insmaindata.setRideracdbdata(rideracdb1);
                    insmaindata.setRidercidata(riderci1, riderciamount1);
                    insmaindata.setRidertermdata(riderterm1, ridertermamount1, ridertermuntilage1, ridertermuntilage1);
                    insmaindata.setOirdata(rideroir1, rideroiramount1, riderpartinsage1, riderpartinsgender1, riderpartinssmoker1, riderpartinsuntilage1, rideractivityrisktypeno1, riderhealthrisktypeno1, ridertermuntilagespouse1);


                    var premdata = from item in newdb.customerplanvarpremiumdets
                                   where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.PREMIUM, ivdata);
                    }


                    var insdata = from item in newdb.customerplanvarinsureddets
                                  where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.INSURED, ivdata);
                    }


                    var loandata = from item in newdb.customerplanloandets
                                   where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.LOAN, ivdata);
                    }


                    var repaydata = from item in newdb.customerplanloanrepaydets
                                    where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.LOANREPAY, ivdata);
                    }



                    var surrenderdata = from item in newdb.customerplanvarsurrenderdets
                                        where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVardata(IVarPlanData.SURRENDER, ivdata);
                    }


                    var profiledata = from item in newdb.customerplanvarprofiledets
                                      where item.customerplanno == Sessionclass.getSessiondata(Session).customerplanno
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
                        insmaindata.setVarinvprofiledata(ivdata1);
                    }


            
                 * 
                 */


                this.setFinancialgoal(Booleandata.getBooleanstring(custplan.financialgoal.ToCharArray()[0]), custplan.financialgoalamount.ToString(), custplan.financialgoalage.ToString());// = double.Parse(txtfingoalamt.Text);
                if (custplan.financialgoal.ToCharArray()[0] == 'Y')
                {
                    if (custplan.financialgoalage < this.age)
                    {
                        this.planerror = true;
                        // need to create a string in languages so that, that particular string instead
                        this.planerrordata = this.planerrordata + " financialgoal age rate cannot be less than age";
                    }
                }
                //insmaindata.financialgoalage = Int32.Parse(txtfingoaluntilage.Text);


                
                /*
                if (custplan.isopeningbalance == 'Y')
                {
                    customerplanopbaldet custopbal = (from item in newdb.customerplanopbaldets
                                                      where item.customerplanno == customerplanno
                                                      select item).SingleOrDefault();


                    this.setOpeningbalance(custopbal.planyear.ToString(), custopbal.adjustedaccountvalue.ToString(), custopbal.forcetarget.ToString(), custopbal.minimumpremium.ToString());
                }
               */ 
                
                

                // initial contribution should work ok
                this.setInitialcontribution(
                    (Numericdata.getDoublevalue(custplan.initialcontributionamount.ToString()) == 0) ? "No" : "Yes",
                    custplan.initialcontributionamount.ToString());//// = ddlinitialcontribution.Text;

                // rider adb should work ok
                WSRider rideradb = null;
                WSRider riderterm = null;

                if (riderslist != null)
                {
                    foreach (WSRider rider in riderslist)
                    {
                        if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                        {
                            rideradb = rider;
                        }
                        else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                        {
                            riderterm = rider;
                        }
                    }


                }

                if (rideradb != null)
                {
                    this.setRideradbdata("Yes", rideradb.amount.ToString());
                    this.rideradbcost = 0;// double.Parse(custplan.rideradbcost.ToString());
                }
                /*
                // rider acdb should work ok
                this.setRideracdbdata(Booleandata.getBooleanstring(custplan.rideracdb));
                this.rideracdbcost = double.Parse(custplan.rideracdbcost.ToString());

                // rider ci should work ok
                this.setRidercidata(Booleandata.getBooleanstring(custplan.riderci), custplan.riderciamount.ToString());
                this.ridercicost = double.Parse(custplan.ridercicost.ToString());

                */




                // the code needs to be checked properly from here
                // rider term should work ok
                if (riderterm != null)
                {
                    int temptermnumyears = 0;
                   
                    //if (riderterm.type == "U")
                    //{
                    //    temptermnumyears = riderterm.term - this.age + 1;
                    //}
                    //else 
                        if (riderterm.type == "C")
                    {
                        temptermnumyears = 0;// this.numberofyears;
                    }
                    else //if (riderterm.type == Contributiontypes.NUMBEROFYEARS.ToString())
                    {
                        temptermnumyears = riderterm.term;
                    }
                    //if (temptermnumyears > this.numberofyears)
                    //{
                    //    temptermnumyears = this.numberofyears;
                    //}
                    String ridertermcontributiontype = Contributiontypes.getcontributiontype(riderterm.type.ToCharArray()[0]);

                    this.setRidertermdata("Yes", riderterm.amount.ToString(), temptermnumyears.ToString(), ridertermcontributiontype);
                    this.ridertermcost = 0;
                }
                /*
                String ridertermcontributiontype = Contributiontypes.getcontributiontype(custplan.termcontributiontypecode);
                this.setRidertermdata(Booleandata.getBooleanstring(custplan.riderterm), custplan.ridertermamount.ToString(), custplan.ridertermuntilage.ToString(), ridertermcontributiontype);
                this.ridertermcost = double.Parse(custplan.ridertermcost.ToString());
               */

                if (partnerins != null)
                {               
                    //insmaindata.setOirdata(rideroir1, 
                    //  rideroiramount1, 
                    //riderpartinsage1, 
                    //riderpartinsgender1, 
                    //riderpartinssmoker1, 
                    //riderpartinsuntilage1, 
                    //rideractivityrisktypeno1, 
                    //riderhealthrisktypeno1, 
                    //ridertermuntilagespouse1);

                    

                        int tempoiryears = 0;

                        //if (partnerins.contributiontype == "U")
                        //{
                        //    tempoiryears = partnerins.term - this.age + 1;
                        //}
                        //else 
                            if (partnerins.contributiontype == "C")
                        {
                            tempoiryears = 0;// this.numberofyears;
                        }
                        else// if (partnerins.contributiontype == Contributiontypes.NUMBEROFYEARS.ToString())
                        {
                            tempoiryears = partnerins.term;
                        }
                        //if (tempoiryears > this.numberofyears)
                        //{
                        //    tempoiryears = this.numberofyears;
                        //}


                        setOirdatavals('Y', Numericdata.getDoublevalue(partnerins.amount.ToString()),
                            Numericdata.getIntegervalue(partnerins.age.ToString()),
                            partnerins.gendercode.ToCharArray()[0], partnerins.smoker.ToCharArray()[0],
                            tempoiryears,
                            partnerins.activityrisktypeno,
                           partnerins.healthrisktypeno, partnerins.contributiontype.ToCharArray()[0]);//partnerins.contributiontypecode.Value));

                    /*
                    this.setOirdata(Booleandata.getBooleanstring(custplan.rideroir), othins.rideroiramount.ToString(),
                        othins.age.ToString(),
                        Genders.getgender(othins.gendercode.Value), Booleandata.getBooleanstring(othins.smoker),
                        othins.untilage.ToString(),
                        Activityrisktypes.getActivityrisktype(othins.activityrisktypeno.Value),
                        Healthrisktypes.getHealthrisktype(othins.healthrisktypeno.Value), Contributiontypes.getcontributiontype(othins.contributiontypecode.Value));
                    */
                    //  this.rideroircost = double.Parse(othins.rideroircost.ToString());
                }

                /*

                var premdata = from item in newdb.customerplanvarpremiumdets
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


                var insdata = from item in newdb.customerplanvarinsureddets
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
                    setVardata(IVarPlanData.SURRENDER, ivdata);
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





            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
        }
        

        public void setFinancialgoal(String fingoalstr,String fingoalamountstr,String financialgoaluntilagestr)
        {
            financialgoalcode = Booleandata.getBooleanvalue(fingoalstr);
            if (financialgoalcode == 'Y')
            {
                if (Program.isdecimal(fingoalamountstr) == true)
                {
                    this.financialgoalamount = double.Parse(fingoalamountstr);
                    this.targetaccountvalue = this.financialgoalamount;

                }
                else
                {
                    this.financialgoalamount = 0.0;
                }
                if (Program.isinteger(financialgoaluntilagestr) == true)
                {
                    this.financialgoalage = Int32.Parse(financialgoaluntilagestr);
                }
                else
                {
                    this.financialgoalage = 0;
                }
            }
            else
            {
                this.financialgoalamount = 0.0;
                this.financialgoalage = 0;
            }
            
        }

        /*
        public String Financialgoal
        {
            get
            {
                return this.financialgoal;
            }
            set
            {
                this.financialgoal = value;
                this.financialgoalcode = Booleandata.getBooleanvalue(value);
            }

        }

        public double Financialgoalamount
        {
            get
            {
                return this.financialgoalamount;
            }
            set
            {
                this.financialgoalamount = value;                
                if (this.financialgoalamount != 0)
                {
                    this.targetaccountvalue = value;
                }
                //this.financialgoalcode = Booleandata.getBooleanvalue(value);
            }

        }
        */

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

        /*
        public String Initialcontribution
        {
            get
            {
                return this.initialcontribution;
            }
            set
            {
                this.initialcontribution = value;
                this.initialcontributioncode = Booleandata.getBooleanvalue(value);
            }

        }

        public double Initialcontributionamount
        {
            get
            {
                return this.initialcontributionamount;
            }
            set
            {
                this.initialcontributionamount = value;                
            }

        }
         */ 

        /*
        public int insurancemaxage
        {
            get
            {
                return Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE, this.productcode);
            }
        }
        
        public double GSMaximumtargetamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.GS_MAXIMUM_TARGET_AMOUNT, this.productcode);
            }
        }

        public double GSMinimumtargetamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.GS_MINIMUM_TARGET_AMOUNT, this.productcode);
            }
        }

        public double GSMaximuminsuredamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.GS_MAXIMUM_INSURED_AMOUNT, this.productcode);
            }
        }

        public double GSMinimuminsuredamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.GS_MINIMUM_INSURED_AMOUNT, this.productcode);
            }
        }


        public double GSMaximumpremiumamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.GS_MAXIMUM_PREMIUM_AMOUNT, this.productcode);
            }
        }

        public double GSMinimumpremiumamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.GS_MINIMUM_PREMIUM_AMOUNT, this.productcode);
            }
        }


        public double Minimumpremiumamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.MINIMUM_PERIODIC_PREMIUM, this.productcode);
            }
        }


        public double Minimuminsuredamount
        {
            get
            {               
                return Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT,this.productcode);                
            }
        }

        public double Maximuminsuredamount
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, this.productcode);
            }
        }*/

        public double Targetaccountvalue
        {
            get
            {
                if (this.targetaccountvalue > 0)
                {
                    return targetaccountvalue;
                }
                else
                {
                    return 0;

                }

            }
        }

        public double Precision
        {
            get
            {
                if (this.precision > 0)
                {
                    // return precision;
                    return .004;
                }
                else
                {
                    return .004;

                }
                
            }
        }

        public double RiderPrecision
        {
            get
            {                
                return .004;
            }
        }

        public double getPrecision(IAccountvalue.AVCALCULATETYPES prectype)
        {
            if (prectype == IAccountvalue.AVCALCULATETYPES.INSUREDAMOUNT)
            {
                if (this.financialgoalcode == 'N')
                {
                    return this.calcyearlypremium / 10;
                }
                else
                {
                    return 500;
                }
                
            }
            else if (prectype == IAccountvalue.AVCALCULATETYPES.PREMIUMAMOUNT)
            {
                if (this.financialgoalcode == 'N')
                {
                    return this.insuredamount / 1000;
                }
                else
                {
                    return 500;
                }
                
            }
            else if (prectype == IAccountvalue.AVCALCULATETYPES.MINIMUMPREMIUM)
            {
                return this.insuredamount / 1000;
            }
            else if (prectype == IAccountvalue.AVCALCULATETYPES.TARGETAMOUNT)
            {
                return this.insuredamount / 1000;
            }
            else if (prectype == IAccountvalue.AVCALCULATETYPES.RIDERADB)
            {
                return 10;
            }
            else if (prectype == IAccountvalue.AVCALCULATETYPES.RIDERTERM)
            {
                return (this.ridertermamount/1000)*2;
            }
            else if (prectype == IAccountvalue.AVCALCULATETYPES.RIDEROIR)
            {
                return (this.rideroiramount / 1000) * 2;
            }
            else
            {
                return 100.00;
            }
        }


        /*
        public double Targetoverage
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.TARGET_OVERAGE, this.productcode);
            }
        }

        public double Premiumreserve
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.PREMIUM_RESERVE, this.productcode);

            }
        }*/

        public int Contributionperiod
        {
            get
            {
                if (this.contributiontypecode == Contributiontypes.CONTINUOUS)
                {
                    return (this.Maxage - this.age + 1);
                }
                else if (this.contributiontypecode == Contributiontypes.NUMBEROFYEARS)
                {
                    return this.numberofyears;
                }
                else if (this.contributiontypecode == Contributiontypes.UNTILAGE)
                {
                    return (this.untilage - this.age + 1);
                }
                else
                {
                    return 0;
                }
            }

        }
        /*
        public int Targetcontributionperiod
        {
            get
            {
                return Rules.getRulevalueint(Rules.TARGET_CONTRIBUTION_PERIOD, this.productcode);

            }
        }

        public double Monthlyfeevalue
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.MONTHLY_FEE, this.productcode);

            }
        }*/

        /*
        public double Monthlyfeevalueyear
        {
            get
            {
                return this.Monthlyfeevalue*12;

            }
        }

        public double Loadchargepercent
        {
            get
            {
                return Rules.getRulevaluedouble(Rules.LOAD_CHARGE, this.productcode);

            }
        }*/


        public double calculatepv(double growthrate, int frequency, double amount)
        {
            double netamount = amount;
            for (int i = 1; i < frequency; i++)
            {
                netamount = netamount + amount * (1.0 / Math.Pow((1 + growthrate), i));
            }            
            return netamount;
        }


        public double calculatePeriodicPremiumAmount()
        {
            if (calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
            {
                annualizedpremiumamount = premiumcost + rideradbcost + ridertermcost + rideracdbcost + rideroircost;
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

        /*
        public int Minimumcontributionperiod
        {
            get
            {
                return Rules.getRulevalueint(Rules.MINIMUM_CONTRIBUTION_PERIOD, this.productcode);
            }

        }*/


        public double Commissionamount(double premiumamount,double targetamount, int sno)
        {
            double commissionamount = 0.0;
            double excesscommissionamount = 0.0;
            
            commissionamount = targetamount * this.commissiondata[sno+this.currentyeardifference - 1].commissionpercent;

            
            if (sno == 1 && this.initialcontributioncode == 'Y')
            {
                //excesscommissionamount = ((premiumamount+this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - targetamount) * this.commissiondata[sno - 1].excesscommissionpercent;
                if (this.financialgoalcode == 'N')
                {
                    excesscommissionamount = ((premiumamount + this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - targetamount) * this.commissiondata[sno+this.currentyeardifference - 1].excesscommissionpercent;
                }
                else
                {
                    excesscommissionamount = ((premiumamount + this.initialcontributionamount) - targetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                }                
            }
            else
            {                
                if (this.financialgoalcode == 'N')
                {
                    excesscommissionamount = (premiumamount * (1 / (1 + this.Premiumreserve)) - targetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                }
                else
                {
                    excesscommissionamount = (premiumamount - targetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                }
            }            
            //excesscommissionamount = (premiumamount - targetamount) * this.commissiondata[sno - 1].excesscommissionpercent;
            return commissionamount + ((excesscommissionamount > 0) ? excesscommissionamount : 0);            
        }

        public double Commissionamountfortarget(double targetamount, int sno)
        {
            double commissionamount = 0.0;            
            if (sno <= this.Targetcontributionperiod)
            {
                commissionamount = targetamount * this.commissiondata[sno- 1].commissionpercent;
            }
            else
            {
                commissionamount = 0;
            }                        
            return commissionamount ;
        }

        public double Commissionamountforriders(double premiumamount, int sno)
        {            
            double excesscommissionamount = 0.0;
            excesscommissionamount = premiumamount * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
            return excesscommissionamount;
        }


        public double Costofinsuranceoveragenohirisk(double insuredamount, double accountvalue, int sno)
        {
            double netinsuredamount = 0.0;// insuredamount;           
            if (this.plantypecode == Plantypes.FIXED)
            {
                netinsuredamount = insuredamount - Math.Max(accountvalue,0);
            }
            else
            {
                netinsuredamount = insuredamount;
            }
            double mortality = ((this.mortalitydata[sno - 1].mortalityvalue) * (1 + this.Targetoverage)+this.countryrisk*.75);            
            return ((netinsuredamount>0)?netinsuredamount:0) * (1 / 1000.0) * mortality;
        }

        public double Costofinsuranceoverage(double insuredamount,double accountvalue,int sno)
        {            
            double netinsuredamount = 0.0;// insuredamount;           
            if(this.plantypecode==Plantypes.FIXED){
                netinsuredamount = insuredamount - Math.Max(accountvalue,0);
            }
            else{
                netinsuredamount = insuredamount;
            }
            double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.activityrisktypevalue) + this.healthrisktypevalue+this.countryrisk );
            return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;            
        }

        public double Costofinsuranceoverageterm(double insuredamount, double accountvalue, int sno)
        {
            double netinsuredamount = 0.0;// insuredamount;                       
            netinsuredamount = insuredamount - Math.Max(accountvalue, 0);            
            double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
            return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;
        }
        

        public double OIRCostofinsuranceoverage(double insuredamount, double accountvalue, int sno)
        {
            if((this.rideroircode=='Y')&&(this.oiruntilage>=(sno-1+this.oirage)))
            {
                double netinsuredamount = 0.0;// insuredamount;                       
                netinsuredamount = insuredamount - Math.Max( accountvalue,0);
                double mortality = 0.0;

                /*
                if (this.calculatetypecode == Calculatetypes.VERIFY)
                {
                    mortality = (this.oirmortalitydata[sno - 1].mortalityvalue * (1 + this.oiractivityrisktypevalue) + this.oirhealthrisktypevalue + this.countryrisk);
                }
                else
                {
                    mortality = (this.oirmortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.oiractivityrisktypevalue) + this.oirhealthrisktypevalue + this.countryrisk);
                }*/
                mortality = (this.oirmortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.oiractivityrisktypevalue) + this.oirhealthrisktypevalue + this.countryrisk);                
                //double mortality = (this.oirmortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.oiractivityrisktypevalue) + this.oirhealthrisktypevalue + this.countryrisk);
                //double mortality = (this.oirmortalitydata[sno - 1].mortalityvalue *  (1 + this.oiractivityrisktypevalue) + this.oirhealthrisktypevalue + this.countryrisk);
                return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;
            }
            else
            {
                return 0.0;
            }            
        }

        public double Costofinsurancenooverage(double insuredamount, double accountvalue, int sno)
        {
            double netinsuredamount = 0.0;// insuredamount;           
            if (this.plantypecode == Plantypes.FIXED)
            {
                netinsuredamount = insuredamount - accountvalue;
            }
            else
            {
                netinsuredamount = insuredamount;
            }
            double mortality = (this.mortalitydata[sno - 1].mortalityvalue *  (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
            return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;
        }


        public double Costofinsuranceillustration(double accountvalue, int sno)
        {
            double netinsuredamount = 0.0;// insuredamount;           
            double currentinsuredamount = 0.0;
            if (varinsuredcode == 'N')
            {
                currentinsuredamount = this.calcinsuredamount;
            }
            else
            {
                currentinsuredamount = varinsuredamount[sno - 1] ;
            }


            if (this.plantypecode == Plantypes.FIXED)
            {
                netinsuredamount = currentinsuredamount - accountvalue;                                
            }
            else
            {
                netinsuredamount = currentinsuredamount;
            }
            double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
            return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;
        }

        public double Costofterminsuranceillustration(double accountvalue, int sno)
        {
            if (this.ridertermcode == 'Y')
            {
                double netinsuredamount = 0.0;// insuredamount;           
                double currentinsuredamount = 0.0;
                if (ridertermuntilage >= (sno + this.age - 1))
                {
                    currentinsuredamount = this.ridertermamount;
                    netinsuredamount = currentinsuredamount - Math.Max(accountvalue,0);
                    double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
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


        public double Commissionamountillustration(int sno)
        {
            double commissionamount = 0.0;
            double excesscommissionamount = 0.0;
            double ridercommission = 0.0;
            if (this.numberofyears>=sno)
            {
                commissionamount = this.calctargetamount * this.commissiondata[sno+this.currentyeardifference - 1].commissionpercent;
                double apremiumamount = this.getCalcpremiumamount(sno);
                if (this.financialgoalcode == 'Y')
                {
                    if (sno == 1 && this.initialcontributioncode == 'Y')
                    {
                        //excesscommissionamount = (( (apremiumamount-(rideradbcost+rideracdbcost+ridertermcost+ridercicost+rideroircost)) + this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;                    
                        // modified to fix financial goal issue
                        excesscommissionamount = (((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) + this.initialcontributionamount) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                        //excesscommissionamount = ((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) + (this.initialcontributionamount * (1 / (1 + this.Premiumreserve))) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;                    
                    }
                    else
                    {
                        //excesscommissionamount = ((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) * (1 / (1 + this.Premiumreserve)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;                    
                        // modified to fix financial goal issue
                        excesscommissionamount = ((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                    }

                }
                else
                {
                    if (sno == 1 && this.initialcontributioncode == 'Y')
                    {
                        excesscommissionamount = (( (apremiumamount-(rideradbcost+rideracdbcost+ridertermcost+ridercicost+rideroircost)) + this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;                    
                        // modified to fix financial goal issue
                        //excesscommissionamount = (((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) + this.initialcontributionamount) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                        //excesscommissionamount = ((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) + (this.initialcontributionamount * (1 / (1 + this.Premiumreserve))) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;                    
                    }
                    else
                    {
                        excesscommissionamount = ((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) * (1 / (1 + this.Premiumreserve)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;                    
                        // modified to fix financial goal issue
                        //excesscommissionamount = ((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
                    }
                }
                
                ridercommission = (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;

            }            
            return commissionamount + ((excesscommissionamount > 0) ? excesscommissionamount : 0)+ridercommission;
        }

        public double Commissionamountillustrationriders(double ridercost,int sno)
        {   
            double ridercommission = 0.0;
            if (this.numberofyears >= sno)
            {
                ridercommission = ridercost * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
            }
            else
            {
                ridercommission = 0.0;
            }
            return ridercommission;
        }


        public double getPremiumamountillustration(int sno)
        {
            if (varpremiumcode == 'N')
            {
                if (this.numberofyears >= sno)
                {
                    if (sno == 1 && this.initialcontributioncode == 'Y')
                    {
                        return (this.calculatePeriodicPremiumAmount() * this.frequencytypevalue)+this.initialcontributionamount;
                    }
                    else
                    {
                        return this.calculatePeriodicPremiumAmount() * this.frequencytypevalue;

                    }                    
                }
                else
                {
                    return 0.0;
                }
            }
            else
            {
                if(this.numberofyears >= sno)
                {
                    if (sno == 1)
                    {
                        return varpremiumamount[sno - 1]*this.frequencytypevalue+this.initialcontributionamount;
                    }
                    else
                    {
                        return varpremiumamount[sno - 1] * this.frequencytypevalue;
                    }
                }
                else
                {

                    return 0.0;
                }
                
            }
        }

        public double minimumyearlypremium(IResultData asdata)
        {
            if (asdata.minimumpremium > targetyearlyamount(asdata) * this.Minimumpremiumtotargetfactor)
            {
                if (asdata.minimumpremium > this.Minimumpremiumamount)
                {
                    return asdata.minimumpremium;
                }
                else
                {
                    return this.Minimumpremiumamount;
                }
            }
            else
            {
                if (targetyearlyamount(asdata) * this.Minimumpremiumtotargetfactor > this.Minimumpremiumamount)
                {
                    return targetyearlyamount(asdata) * this.Minimumpremiumtotargetfactor;
                }
                else
                {
                    return this.Minimumpremiumamount;
                }
            }

        }

        public double targetyearlyamount(IResultData asdata)
        {
            //double temptargetamount;



            double projectedyearlyamount = 0;            
            //this.periodicpremiumamount * this.frequencytypevalue;
            if (calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
            {
                projectedyearlyamount = calculatePeriodicPremiumAmount() * this.frequencytypevalue;
            }
            else
            {
                if (varpremiumcode == 'N')
                {
                    projectedyearlyamount = this.periodicpremiumamount * this.frequencytypevalue;
                }
                else
                {
                    projectedyearlyamount = varpremiumamount[0] * this.frequencytypevalue;
                }
                
            } 
            double initialamount = 0.0;
            if (this.initialcontributioncode == 'Y')
            {
                initialamount = calculatePMT(this.initialcontributionamount, this.Targetcontributionperiod, this.growthrate);                 
            }
            projectedyearlyamount = projectedyearlyamount + initialamount;
            if (asdata.targetamount > (asdata.targetamount *(1+this.Premiumreserve-this.Targetdiscountfactor)))
            {
                if (asdata.targetamount < projectedyearlyamount)
                {
                    return asdata.targetamount*(1-Targetaddldiscount);
                }
                else
                {
                    return projectedyearlyamount * (1 - Targetaddldiscount);
                }
            }
            else
            {
                if ((asdata.targetamount * (1 + this.Premiumreserve - this.Targetdiscountfactor)) > projectedyearlyamount)
                {
                    return projectedyearlyamount * (1 - Targetaddldiscount);
                }
                else
                {
                    if (this.financialgoalcode != 'Y')
                    {
                        return (asdata.targetamount * (1 + this.Premiumreserve - this.Targetdiscountfactor)) * (1 - Targetaddldiscount);
                    }
                    else
                    {
                        return asdata.targetamount * (1 - Targetaddldiscount);
                    }                    
                }
            }
        }

        /*
        public ICommissiondata[] Commissiondata
        {
            get
            {
                //int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);
                ICommissiondata[] commdata = new ICommissiondata[this.Maxage - age + 1];
                for (int i = age; i <= this.Maxage; i++)
                {
                    commdata[i - age] = new ICommissiondata();
                    int sno = i - age + 1;                    
                    commdata[sno - 1].sno = sno;
                    commdata[sno - 1].commissionpercent = Commissions.getCommissionpercentvalue(this.productcode, sno);
                    commdata[sno - 1].excesscommissionpercent= Commissions.getExcesscommissionpercent(this.productcode, sno);
                }
                return commdata;
            }

        }   
         */ 
        
        /*
        public int Maxage
        {
            get
            {
                return Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);

            }
        }*/

        /*
        public int Maxage
        {
            get
            {
                return Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);

            }
        }
         */ 


        /*
        public IMortalitydata[] mortalitydata
        {
            get
            {                
                return this.mortalitydata_1;
            }

        }*/

        /*
        public double Growthrate
        {
            get
            {
                return Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode);
            }

        }*/
        
        /*
        public char investmentprofilecode
        {
            get
            {
                return Invprofiledata.getinvestmentprofilecode(this.investmentprofile);
            }
        }

        public char Gendercode
        {
            get
            {
                return Genders.getgendercode(this.gender);
            }
        }

        
        public char Smokercode
        {
            get
            {
                return Booleandata.getBooleanvalue(this.smoker);
            }
        }

        
        public int Countryno
        {
            get
            {
                return Countries.getcountryno(this.country);
            }
        }

        public double Activityrisktypevalue
        {
            get
            {
                return Activityrisktypes.getActivityriskvalue(Activityrisktypes.getActivityrisktypeno(this.activityrisktype));
            }
        }

        public double Healthrisktypevalue
        {
            get
            {
                return Healthrisktypes.getHealthriskvalue(Healthrisktypes.getHealthrisktypeno(this.healthrisktype));
            }
        }
        public String productcode
        {
            get {
                    return Productdata.getproductcode(this.product);            
                }            
        }

        public char Plantypecode
        {
            get
            {
                return Plantypes.getPlantypecode(this.plantype);
            }
        }

        public char Contributiontypecode
        {
            get
            {
                return Contributiontypes.getcontributiontypecode(this.contributiontype);
            }
        }

        public char Calculatetypecode
        {
            get
            {
                return Calculatetypes.getcalculatetypecode(this.calculatetype);
            }
        }

        public char Frequencytypecode
        {
            get
            {
                return Frequencytypes.getfrequencytypecode(this.frequencytype);
            }
        }

        public int Frequencyvalue
        {
            get
            {
                return Frequencytypes.getfrequencytypevalue(this.frequencytype);
            }
        }

        public double Frequencypenalty
        {
            get
            {
                return Frequencytypes.getfrequencytypepenalty(this.frequencytype);
            }
        }
        */


        public void setRideradbdata(String rideradb,String rideradbamountstr)
        {
            this.rideradb = rideradb;
            this.rideradbcode = Booleandata.getBooleanvalue(rideradb);
            if (Program.isdecimal(rideradbamountstr) == true)
            {
                this.rideradbamount = double.Parse(rideradbamountstr);
            }
            else
            {
                this.rideradbamount = 0.0;
            }
            
        }

        public void setRideracdbdata(String rideracdb)
        {
            this.rideracdb = rideracdb;
            this.rideracdbcode= Booleandata.getBooleanvalue(rideracdb);
        }

        public void setRidercidata(String riderci, String riderciamountstr)
        {            
            this.ridercicode = Booleandata.getBooleanvalue(riderci);
            if (this.ridercicode == 'Y')
            {
                if (Program.isdecimal(riderciamountstr) == true)
                {
                    this.riderciamount = double.Parse(riderciamountstr);
                }
                else
                {
                    this.riderciamount = 0.0;
                }
            }
            else
            {
                this.riderciamount = 0.0;                
            }
        }

        public void setRidertermdata(String riderterm, String ridertermamountstr, String ridertermuntilagestr)
        {
            this.riderterm = riderterm;
            this.ridertermcode = Booleandata.getBooleanvalue(riderterm);
            if (this.ridertermcode == 'Y')
            {
                if (Program.isdecimal(ridertermamountstr) == true)
                {
                    this.ridertermamount = double.Parse(ridertermamountstr);
                }
                else
                {
                    this.ridertermamount = 0.0;
                }
                if (Program.isinteger(ridertermuntilagestr) == true)
                {
                    this.ridertermuntilage = Int32.Parse(ridertermuntilagestr);
                }
                else
                {
                    this.ridertermuntilage = 0;
                }
            }
            else
            {
                this.ridertermamount = 0.0;// double.Parse(ridertermamountstr);
                this.ridertermuntilage = 0;
            }
        }

        public void setRidertermdata(String riderterm, String ridertermamountstr,String ridertermuntilagestr,String ridertermcontributiontype)
        {
            this.riderterm = riderterm;
            this.ridertermcode = Booleandata.getBooleanvalue(riderterm);
            if (this.ridertermcode == 'Y')
            {
                if (Program.isdecimal(ridertermamountstr) == true)
                {
                    this.ridertermamount = double.Parse(ridertermamountstr);
                }
                else
                {
                    this.ridertermamount = 0.0;
                }
                ridertermcontributiontypecode = Contributiontypes.getcontributiontypecode(ridertermcontributiontype);
                
                int temptermuntilage = 0;
                if (Program.isinteger(ridertermuntilagestr) == true)
                {
                    temptermuntilage = Int32.Parse(ridertermuntilagestr);
                }
                else
                {
                    temptermuntilage = 0;
                }
                
                if (ridertermcontributiontypecode == Contributiontypes.CONTINUOUS)
                {                    
                    this.ridertermuntilage = Maxage;                    
                }
                else if (ridertermcontributiontypecode == Contributiontypes.NUMBEROFYEARS)
                {
                    if ((temptermuntilage+this.age) >= Maxage)
                    {
                        this.ridertermuntilage = Maxage;
                    }
                    else
                    {
                        this.ridertermuntilage = temptermuntilage+this.age-1;
                    }
                }
                else if (ridertermcontributiontypecode == Contributiontypes.UNTILAGE)
                {
                    if (temptermuntilage >= Maxage)
                    {
                        this.ridertermuntilage = Maxage;
                    }
                    else 
                    {
                        this.ridertermuntilage = temptermuntilage;
                    }
                }

            }
            else
            {                
                this.ridertermamount =0.0;// double.Parse(ridertermamountstr);
                this.ridertermuntilage = 0;
                ridertermcontributiontypecode = Contributiontypes.UNTILAGE;
            }                        
        }

        
        public void setOirdata(String rideroir, String rideroiramountstr, String oiragestr, String oirgender, String oirsmoker, String oiruntilagestr, String oiractivityrisk, String oirhealthrisk,String oircontributiontype)
        {        
            rideroircode = Booleandata.getBooleanvalue(rideroir);

            if (this.rideroircode == 'Y')
            {
                if (Program.isdecimal(rideroiramountstr) == true)
                {
                    this.rideroiramount = double.Parse(rideroiramountstr);
                }
                else
                {
                    this.rideroiramount = 0.0;
                }

                if (Program.isinteger(oiragestr) == true)
                {
                    this.oirage = Int32.Parse(oiragestr);
                }
                else
                {
                    this.oirage = 0;
                }



                this.oirgender = oirgender;
                this.oirsmoker = oirsmoker;

                int untilage = 0;

                if (Program.isinteger(oiruntilagestr) == true)
                {
                    untilage = Int32.Parse(oiruntilagestr);
                }
                else
                {
                    untilage = 0;
                }
                oircontributiontypecode = Contributiontypes.getcontributiontypecode(oircontributiontype);
                
                if (oircontributiontypecode == Contributiontypes.CONTINUOUS)
                {
                    oiruntilage = Maxage;
                }
                else if (oircontributiontypecode == Contributiontypes.NUMBEROFYEARS)
                {
                    if ((untilage + this.oirage) >= Maxage)
                    {
                        oiruntilage = Maxage;
                    }
                    else
                    {
                        oiruntilage = untilage + this.age;
                    }
                }
                else if (oircontributiontypecode == Contributiontypes.UNTILAGE)
                {
                    if (untilage >= Maxage)
                    {
                        oiruntilage = Maxage;
                    }
                    else
                    {
                        oiruntilage = untilage;
                    }
                }

                this.oiractivityrisk = oiractivityrisk;
                this.oirhealthrisk = oirhealthrisk;

                this.ridercicode = Booleandata.getBooleanvalue(rideroir);
                this.oirgendercode = Genders.getgendercode(oirgender);
                this.oirsmokercode = Booleandata.getBooleanvalue(oirsmoker);
                this.oiractivityrisktypevalue = Activityrisktypes.getActivityriskvalue(Activityrisktypes.getActivityrisktypeno(this.productcode, oiractivityrisk));
                this.oirhealthrisktypevalue = Healthrisktypes.getHealthriskvalue(Healthrisktypes.getHealthrisktypeno(this.productcode, oirhealthrisk));



                //int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);
                oirmortalitydata = new IMortalitydata[oiruntilage - oirage + 1];
                for (int i = oirage; i <= oiruntilage; i++)
                {
                    oirmortalitydata[i - oirage] = new IMortalitydata();
                    int sno = i - oirage + 1;
                    oirmortalitydata[sno - 1].age = oirage + sno - 1;
                    oirmortalitydata[sno - 1].sno = sno;
                    oirmortalitydata[sno - 1].mortalityvalue = Mortalityrates.getMortalityrate(this.productcode, Ridertypes.Primary, oirmortalitydata[sno - 1].age, this.oirgendercode, this.oirsmokercode,classcode);
                }
            }
            else
            {
                this.rideroiramount = 0;
                this.oirage = 0;
                this.oircontributiontypecode = Contributiontypes.UNTILAGE;
            }
            

        }


        public void setOirdatavals(char rideroircode1, double rideroiramount1, int oirage1, char oirgendercode1, char oirsmokercode1, int oiruntilage1, int oiractivityriskno1, int oirhealthriskno1, char oircontributiontypecode1)
        {
            rideroircode = rideroircode1;
            if (this.rideroircode == 'Y')
            {
                this.rideroiramount = rideroiramount1;
                this.oirage = oirage1;
                this.oirgender =Genders.getgender(oirgendercode1);
                this.oirsmoker =Booleandata.getBooleanstring(oirsmokercode1);
                int auntilage = oiruntilage1;
                this.oircontributiontypecode = oircontributiontypecode1;

                if (this.oircontributiontypecode == Contributiontypes.CONTINUOUS)
                {
                    this.oiruntilage = Maxage;
                }
                else if (this.oircontributiontypecode == Contributiontypes.NUMBEROFYEARS)
                {
                    if ((this.oiruntilage + auntilage) >= Maxage)
                    {
                        this.oiruntilage = Maxage;
                    }
                    else
                    {
                        this.oiruntilage = auntilage + this.age;
                    }
                }
                else if (this.oircontributiontypecode == Contributiontypes.UNTILAGE)
                {
                    if (auntilage >= Maxage)
                    {
                        this.oiruntilage = Maxage;
                    }
                    else
                    {
                        this.oiruntilage = auntilage;
                    }
                }

                this.oiractivityrisktypevalue =Activityrisktypes.getActivityriskvalue(oiractivityriskno1);
                this.oirhealthrisktypevalue = Healthrisktypes.getHealthriskvalue(oirhealthriskno1);

                //this.ridercicode = Booleandata.getBooleanvalue(rideroir);
                this.oirgendercode = oirgendercode1;
                this.oirsmokercode = oirsmokercode1;
                //this.oiractivityrisktypevalue = Activityrisktypes.getActivityriskvalue(Activityrisktypes.getActivityrisktypeno(this.productcode, oiractivityrisk));
                //this.oirhealthrisktypevalue = Healthrisktypes.getHealthriskvalue(Healthrisktypes.getHealthrisktypeno(this.productcode, oirhealthrisk));

                //int maxage = Rules.getRulevalueint(Rules.MAX_AGE, this.productcode);
                oirmortalitydata = new IMortalitydata[this.oiruntilage - this.oirage + 1];
                for (int i = this.oirage; i <= this.oiruntilage; i++)
                {
                    oirmortalitydata[i - this.oirage] = new IMortalitydata();
                    int sno = i - this.oirage + 1;
                    oirmortalitydata[sno - 1].age = this.oirage + sno - 1;
                    oirmortalitydata[sno - 1].sno = sno;
                    oirmortalitydata[sno - 1].mortalityvalue = Mortalityrates.getMortalityrate(this.productcode, Ridertypes.Primary, oirmortalitydata[sno - 1].age, this.oirgendercode, this.oirsmokercode,classcode);
                }
            }
            else
            {
                this.rideroircode = 'N';
                this.rideroiramount = 0;
                this.oirage = 0;
                this.oircontributiontypecode = Contributiontypes.UNTILAGE;
            }

        }

        
        public double availablePremium
        {            
            get
            {
                double actualpremium = annualizedpremiumamount;
                return actualpremium - (this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
            }           

        }

        public void calculateRideradbaccount()
        {
            //rideradbdata = this.getRiderADBAccountdata();
        }


        public double getRiderexpenses(int sno)
        {
            double riderexpenses = 0.0;
            if (this.rideradbcode == 'Y')
            {
                riderexpenses = riderexpenses + this.rideradbamount * this.Rideradbfactor * (1.0 / 1000.0);
            }
            /*
            if (this.rideracdbcode == 'Y')
            {
                riderexpenses = riderexpenses + 0.0;
            }
             */ 
            /*
            if (this.ridertermcode == 'Y')
            {
                double rideradbaccountvalue;
                if (this.rideradbcode == 'Y')
                {
                    if (rideradbdata.Length > (sno))
                    {
                        rideradbaccountvalue = rideradbdata[i - insmaindata.age].accountvalue;
                    }
                    else
                    {
                        rideradbaccountvalue = 0.0;
                    }
                }
                costofinsurance = insmaindata.Costofinsuranceoverage(insmaindata.ridertermamount, accountvalue - rideradbaccountvalue, i - insmaindata.age + 1);                    
                riderexpenses = riderexpenses + 0.0;
            }
            */
            return riderexpenses;          
        }


        public double getAvailableVarPremium(int sno)
        {
            if (varpremiumcode == 'N')
            {
                double actualpremium = annualizedpremiumamount;
                return actualpremium - (this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
            }
            else
            {
                if (this.fortargetcalculation == 'N')
                {                    
                    double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                    double actualpremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[sno - 1] / (1 + frequencytypepenalty)); ;
                    return actualpremium - (this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
                }
                else
                {
                    double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                    double actualpremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[0] / (1 + frequencytypepenalty)); ;
                    return actualpremium - (this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
                }
                
            }
        }



        public double getVarInsuredamount(int sno)
        {
            if (varinsuredcode== 'N')
            {
                if (this.calculatetypecode == Calculatetypes.INSUREDAMOUNT)
                {
                    return this.calcinsuredamount;
                }
                else
                {
                    return this.insuredamount;                
                }                
            }
            else
            {
                if (this.calculatetypecode == Calculatetypes.INSUREDAMOUNT)
                {
                    return this.calcinsuredamount;
                }
                else
                {
                    double actualinsuredamount = varinsuredamount[sno - 1];
                    return actualinsuredamount;                    
                }
                
            }
        }

        public double actualPremium
        {
            get
            {
                double actualpremium = annualizedpremiumamount;
                return actualpremium - (this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
            }
        }
        

        public IRiderAccountdata[] getRiderADBAccountdata()
        {
            numtimescalled++;
            double costofinsurance = 0.0;
            double commissionamount = 0.0;
            double premiumamount = 0.0;
            double loadcharge = 0.0;
            double accountvalue = 0;

            int untilage = this.age + Math.Max(this.Rideradbmaxage - this.age + 1, this.numberofyears) - 1;

            IRiderAccountdata[] ridervaluedata = new IRiderAccountdata[untilage - this.age + 1];

            for (int i = this.age; i <= untilage; i++)
            {
                if (i <= this.Rideradbmaxage)
                {
                    costofinsurance = this.rideradbamount * this.Rideradbfactor * (1.0 / 1000.0);                
                }
                else
                {
                    costofinsurance = 0.0;
                }                
                if (this.Contributionperiod >= (i - this.age + 1))
                {
                    premiumamount = rideradbcost;
                }
                else
                {
                    premiumamount = 0.0;
                }
                commissionamount = this.Commissionamountforriders(premiumamount, i - this.age + 1);
                loadcharge = premiumamount * Loadchargepercent;
                accountvalue = (1 + netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                ridervaluedata[i - age] = new IRiderAccountdata();
                ridervaluedata[i - age].sno = i - this.age + 1;
                ridervaluedata[i - age].accountvalue = accountvalue;
            }
            return ridervaluedata;

        }


        public IRiderAccountdata[] getRiderTermAccountdata()
        {
            //numtimescalled++;

            IRiderAccountdata[] rideradbdata = null;
            if (this.rideradbcode == 'Y')
            {
                rideradbdata = getRiderADBAccountdata();
            }
            //double rideradbaccountvalue = 0.0;
            double costofinsurance = 0.0;
            double commissionamount = 0.0;
            double premiumamount = 0.0;
            double loadcharge = 0.0;
            double accountvalue = 0;
            int untilage = this.age + Math.Max(this.ridertermuntilage - this.age + 1, this.numberofyears) - 1;
            IRiderAccountdata[] ridervaluedata = new IRiderAccountdata[untilage - this.age + 1];
            int sno = 0;
            for (int i = this.age; i <= untilage; i++)
            {
                sno = i - this.age + 1;
                double rideradbaccountvalue = 0.0;
                if (this.rideradbcode == 'Y')
                {
                    if ((rideradbdata.Length > (i - this.age)) && ((i - this.age - 1) > 0))
                    {
                        rideradbaccountvalue = rideradbdata[i - this.age - 1].accountvalue;
                    }
                    else
                    {
                        rideradbaccountvalue = 0.0;
                    }
                }
                if (i <= this.ridertermuntilage)
                {
                    costofinsurance = this.Costofinsuranceoverageterm(this.ridertermamount, accountvalue + rideradbaccountvalue, i - this.age + 1);
                }
                else
                {
                    costofinsurance = 0;
                }

                if (this.Contributionperiod >= (i - this.age + 1))
                {
                    premiumamount = ridertermcost;
                }
                else
                {
                    premiumamount = 0.0;
                }
                commissionamount = this.Commissionamountforriders(premiumamount, i - this.age + 1);
                loadcharge = premiumamount * this.Loadchargepercent;
                //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                ridervaluedata[i - age] = new IRiderAccountdata();
                ridervaluedata[i - age].sno = i - this.age + 1;
                ridervaluedata[i - age].accountvalue = accountvalue;
            }
            return ridervaluedata;

        }

        public double Minimumpremiumamountafterriders
        {
            get
            {
                return this.Minimumpremiumamount - (this.rideradbcost + this.rideracdbcost + this.ridertermcost + this.rideroircost);
            }
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

        public double Calctargetamount
        {
            get { return this.calctargetamount; }
            set { this.calctargetamount = value; }
        }

        public double Calcinsuredamount
        {
            get 
            {
                if (calculatetypecode == Calculatetypes.INSUREDAMOUNT)
                {
                    return this.calcinsuredamount;
                }
                else
                {
                    return this.calcinsuredamount;
                }
            }
            set { this.calcinsuredamount= value; }
        }

        public double getCalcinsuredamount(int sno)
        {            
            if (varinsuredcode == 'N')
            {
                return this.calcinsuredamount; 
            }
            else
            {
                return varinsuredamount[sno - 1];
            }   
        }

        public double getCalcpremiumamount(int sno)
        {
            if (varpremiumcode == 'N')
            {
                if (this.numberofyears >= sno)
                {
                    return this.calcyearlypremium;
                }
                else
                {
                    return 0.0;
                }                
            }
            else
            {
                if (this.fortargetcalculation == 'N')
                {
                    if (this.numberofyears >= sno)
                    {   
                        double penaltypercent = this.frequencytypepenalty;
                        double netperiodicpayment = this.periodicpremiumamount / (1 + penaltypercent);                        
                        double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                        return calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[sno - 1] / (1 + frequencytypepenalty));                        
                    }
                    else
                    {
                        return 0.0;
                    }
                }
                else
                {
                    if (this.numberofyears >= sno)
                    {
                        double penaltypercent = this.frequencytypepenalty;
                        double netperiodicpayment = this.periodicpremiumamount / (1 + penaltypercent);
                        double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                        return calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[0] / (1 + frequencytypepenalty));                        
                    }
                    else
                    {
                        return 0.0;
                    }
                }
                
                //return varpremiumamount[sno - 1];
            }
        }

        public double getCalcsurrenderamount(int sno)
        {
            if (varsurrendercode == 'N')
            {
                return 0.0;
            }
            else
            {
                return varsurrenderamount[sno - 1];
            }
        }

        public double getCalcloanamount(int sno)
        {
            if (varloancode== 'N')
            {
                return 0.0;
            }
            else
            {
                return varloanamount[sno - 1];
            }
        }

        public double getCalcloanrepayamount(int sno)
        {
            if (varloanrepaycode == 'N')
            {
                return 0.0;
            }
            else
            {
                return varloanrepayamount[sno - 1];
            }
        }

        public double Calcaveragepremium{
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
                        totpremium = totpremium + varpremiumamount[i]*this.frequencytypevalue;
                    }
                    return totpremium / varpremiumamount.Length;
                }
                
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
            

        public double Calcriderpremium
        {
            get
            {
                return (rideradbcost + ridercicost + rideroircost + ridertermcost+rideracdbcost);
            }                        
        }

        public double Calcminimumpremium
        {
            get { return this.calcminimumpremium; }
            set { this.calcminimumpremium = value; }
        }

        public double Calcyearlypremium
        {            
            set { this.calcyearlypremium = value; }
        }


        public String comprate1
        {
            get
            {
                double rate1=    Productinvprofile.getCompareprofilerate1(this.investmentprofilecode, this.productcode,classcode);
                return (rate1 * 100).ToString() + " %";
            }
        }

        public String comprate2
        {
            get
            {
                double rate2 = Productinvprofile.getCompareprofilerate2(this.investmentprofilecode, this.productcode,classcode);
                return (rate2 * 100).ToString() + " %";
            }
        }



        public String comprate3
        {
            get
            {
                if (varinvestprofilecode == 'N')
                {
                    double rate3 = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode,classcode);
                    return (rate3 * 100).ToString() + " %";
                }
                else
                {
                    return " Variable ";

                }                
            }
        }

        public String dynratecaption
        {
            get
            {
                if (varinvestprofilecode == 'N')
                {
                    return "";
                }
                else
                {
                    return " Variable Rates ";
                }
            }
        }


        public Illusdata[] getIllustration()
        {
            Illusdata[] illresult = new Illusdata[this.Maxage - this.age + 1];

            double growthratecomp1 = Productinvprofile.getCompareprofilerate1(this.investmentprofilecode, this.productcode, classcode) - this.costoffunds;
            double growthratecomp2 = Productinvprofile.getCompareprofilerate2(this.investmentprofilecode, this.productcode, classcode) - this.costoffunds;

            double totalloanamount = 0.0;

            double totalpenaltyamount = 0.0;
            double totalinterestamount = 0.0;
            //double totalpenaltyamount;

            //double loanpenaltyorvalue = 0.0;
            //double totalloangrowthamount = 0.0;


            double totalpenaltyamountcomp1 = 0.0;
            double totalinterestamountcomp1 = 0.0;
            //double totalpenaltyamount;


            double totalpenaltyamountcomp2 = 0.0;
            double totalinterestamountcomp2 = 0.0;
            //double totalpenaltyamount;


            double[] rideradbdata = null;
            double[] rideracdbdata = null;
            double[] ridertermdata = null;
            double[] ridercidata = null;
            double[] rideroirdata = null;

            double rideradbaccountvalue = 0.0;
            double rideracdbaccountvalue = 0.0;
            double ridertermaccountvalue = 0.0;
            double riderciaccountvalue = 0.0;
            double rideroiraccountvalue = 0.0;



            double[] rideradbcompdata1 = null;
            double[] rideracdbcompdata1 = null;
            double[] ridertermcompdata1 = null;
            double[] ridercicompdata1 = null;
            double[] rideroircompdata1 = null;

            double rideradbcompaccountvalue1 = 0.0;
            double rideracdbcompaccountvalue1 = 0.0;
            double ridertermcompaccountvalue1 = 0.0;
            double ridercicompaccountvalue1 = 0.0;
            double rideroircompaccountvalue1 = 0.0;

            double[] rideradbcompdata2 = null;
            double[] rideracdbcompdata2 = null;
            double[] ridertermcompdata2 = null;
            double[] ridercicompdata2 = null;
            double[] rideroircompdata2 = null;

            double rideradbcompaccountvalue2 = 0.0;
            double rideracdbcompaccountvalue2 = 0.0;
            double ridertermcompaccountvalue2 = 0.0;
            double ridercicompaccountvalue2 = 0.0;
            double rideroircompaccountvalue2 = 0.0;


            double accountvalue = 0.0;
            double accountvaluecomp1 = 0.0;
            double accountvaluecomp2 = 0.0;

            /*
            double accountvaluelessriders = 0.0;
            double accountvaluelessriderscomp1 = 0.0;
            double accountvaluelessriderscomp2 = 0.0;
            */

            double riderpayments = 0.0;

            if (this.rideradbcode == 'Y')
            {
                int untilage = this.age + Math.Max(this.Rideradbmaxage - this.age + 1, this.numberofyears) - 1;
                rideradbdata = new double[untilage - this.age + 1];
                rideradbcompdata1 = new double[untilage - this.age + 1];
                rideradbcompdata2 = new double[untilage - this.age + 1];
            }
            if (this.rideracdbcode == 'Y')
            {
                rideracdbdata = new double[this.Rideradbmaxage - this.age + 1];
                rideracdbcompdata1 = new double[this.Rideradbmaxage - this.age + 1];
                rideracdbcompdata2 = new double[this.Rideradbmaxage - this.age + 1];
            }
            if (this.ridercicode == 'Y')
            {
                ridercidata = new double[this.Rideradbmaxage - this.age + 1];
                ridercicompdata1 = new double[this.Rideradbmaxage - this.age + 1];
                ridercicompdata2 = new double[this.Rideradbmaxage - this.age + 1];
            }
            if (this.ridertermcode == 'Y')
            {
                int untilage = this.age + Math.Max(this.ridertermuntilage - this.age + 1, this.numberofyears) - 1;
                ridertermdata = new double[untilage - this.age + 1];
                ridertermcompdata1 = new double[untilage - this.age + 1];
                ridertermcompdata2 = new double[untilage - this.age + 1];
            }
            if (this.rideroircode == 'Y')
            {
                int untilage = this.age + Math.Max(this.oiruntilage - this.age + 1, this.numberofyears) - 1;
                rideroirdata = new double[untilage - this.oirage + 1];
                rideroircompdata1 = new double[untilage - this.oirage + 1];
                rideroircompdata2 = new double[untilage - this.oirage + 1];
            }

            if (this.isOpeningbalance == true)
            {
                accountvalue = this.openingbalanceamount;
                accountvaluecomp1 = this.openingbalanceamount;
                accountvaluecomp2 = this.openingbalanceamount;
            }

            for (int i = this.age; i <= this.Maxage; i++)
            {

                int sno = i - this.age + 1;
                illresult[i - this.age] = new Illusdata();
                double growthrate = this.getGrowthrate(sno);





                double costofinsurance;
                double costofinsurancecomp1;
                double costofinsurancecomp2;

                double commissionamount;
                //double commissionamountriders;
                double commissionamountadb;
                double commissionamountacdb;
                double commissionamountci;
                double commissionamountterm;
                double commissionamountoir;
                double loadcharge;
                double ipremiumamount;
                double iinsuredamount;

                double expenseadb = 0.0;
                double expenseadbcomp1 = 0.0;
                double expenseadbcomp2 = 0.0;

                double expenseacdb = 0.0;
                double expenseacdbcomp1 = 0.0;
                double expenseacdbcomp2 = 0.0;

                double expenseci = 0.0;
                double expensecicomp1 = 0.0;
                double expensecicomp2 = 0.0;

                double expenseterm = 0.0;
                double expensetermcomp1 = 0.0;
                double expensetermcomp2 = 0.0;

                double expenseoir = 0.0;
                double expenseoircomp1 = 0.0;
                double expenseoircomp2 = 0.0;

                double partialsurrenderamount = this.getCalcsurrenderamount(sno);

                double loanamount = this.getCalcloanamount(sno);
                double loanrepayamount = this.getCalcloanrepayamount(sno);
                totalloanamount = totalloanamount + loanamount - loanrepayamount;

                totalinterestamount = totalinterestamount + loanamount - loanrepayamount;
                totalinterestamountcomp1 = totalinterestamountcomp1 + loanamount - loanrepayamount;
                totalinterestamountcomp2 = totalinterestamountcomp2 + loanamount - loanrepayamount;

                totalpenaltyamount = totalpenaltyamount + loanamount - loanrepayamount;
                totalpenaltyamountcomp1 = totalpenaltyamountcomp1 + loanamount - loanrepayamount;
                totalpenaltyamountcomp2 = totalpenaltyamountcomp2 + loanamount - loanrepayamount;


                if (this.IsLoanRate == true)
                {
                    totalinterestamount = totalinterestamount * (1 + this.getGrowthrate(sno));
                    totalpenaltyamount = totalpenaltyamount * (1 + this.InterestLoanRate);

                    totalinterestamountcomp1 = totalinterestamountcomp1 * (1 + this.getGrowthrate(sno));
                    totalpenaltyamountcomp1 = totalpenaltyamountcomp1 * (1 + this.InterestLoanRate);

                    totalinterestamountcomp2 = totalinterestamountcomp2 * (1 + this.getGrowthrate(sno));
                    totalpenaltyamountcomp2 = totalpenaltyamountcomp2 * (1 + this.InterestLoanRate);



                }
                else
                {
                    totalinterestamount = totalinterestamount * (1 + this.LoanAssetRate);
                    totalpenaltyamount = totalpenaltyamount * (1 + this.InterestLoanRate);

                    totalinterestamountcomp1 = totalinterestamountcomp1 * (1 + this.LoanAssetRate);
                    totalpenaltyamountcomp1 = totalpenaltyamountcomp1 * (1 + this.InterestLoanRate);


                    totalinterestamountcomp2 = totalinterestamountcomp2 * (1 + this.LoanAssetRate);
                    totalpenaltyamountcomp2 = totalpenaltyamountcomp2 * (1 + this.InterestLoanRate);
                    //loanpenaltyorvalue = totalloanamount * (this.LoanAssetRate - this.InterestLoanRate);
                }
                //totalloanamount = totalloanamount - loanpenaltyorvalue;


                int maxcalcperiod = this.Maxage;
                ipremiumamount = this.getCalcpremiumamount(sno);
                iinsuredamount = this.getCalcinsuredamount(sno);
                commissionamount = this.Commissionamountillustration(sno);

                //the commission amount for riders
                commissionamountadb = this.Commissionamountillustrationriders(this.rideradbcost, sno);
                commissionamountacdb = this.Commissionamountillustrationriders(this.rideracdbcost, sno);
                commissionamountci = this.Commissionamountillustrationriders(this.ridercicost, sno);
                commissionamountterm = this.Commissionamountillustrationriders(this.ridertermcost, sno);
                commissionamountoir = this.Commissionamountillustrationriders(this.rideroircost, sno);


                illresult[i - this.age].Commission = commissionamount;

                if ((this.initialcontributioncode == 'Y') && (i == this.age))
                {
                    ipremiumamount = (ipremiumamount + this.initialcontributionamount);// *(1.0 / (1.0 + insmaindata.Premiumreserve));                    
                }

                loadcharge = ipremiumamount * this.Loadchargepercent;


                Growthcase[] gcase = new Growthcase[3];
                for (int j = 0; j < 3; j++)
                {
                    gcase[j] = new Growthcase();
                }
                //riderpayments = getRiderexpenses(sno);


                /*
                if (this.rideradbcode == 'Y')
                {
                    rideradbaccountvalue1=
                }*/


                double ridersaccountvalue = (rideradbaccountvalue + rideracdbaccountvalue + riderciaccountvalue + ridertermaccountvalue + rideroiraccountvalue);
                costofinsurance = this.Costofinsuranceillustration(accountvalue - ridersaccountvalue + totalloanamount, sno);
                //costofinsurance = this.Costofinsuranceillustration(accountvaluelessriders , sno);
                illresult[i - this.age].Costofinsurance = costofinsurance;



                if ((rideradbcode == 'Y') && (i <= Rideradbmaxage))
                {
                    expenseadb = this.rideradbamount * this.Rideradbfactor * (1.0 / 1000.0);
                }
                else
                {
                    expenseadb = 0;
                }

                expenseterm = Costofterminsuranceillustration(ridertermaccountvalue + rideradbaccountvalue, sno);

                expenseoir = OIRCostofinsuranceoverage(this.rideroiramount, rideroiraccountvalue + ridertermaccountvalue, sno);

                riderpayments = expenseadb + expenseacdb + expenseci + expenseterm + expenseoir;


                illresult[i - this.age].Costofriders = riderpayments;

                accountvalue = (1 + growthrate) * (accountvalue + ipremiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear - riderpayments);
                //accountvalueless = (1 + growthrate) * (accountvalue + loanpenaltyorvalue + ipremiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear - riderpayments);
                //accountvalue = accountvalue - loanamount + loanrepayamount + loanpenaltyorvalue;

                //totalloanamount = totalloanamount + loanpenaltyorvalue;



                // rider account values
                rideradbaccountvalue = (1 + growthrate) * (rideradbaccountvalue + rideradbcostillustration(sno) * (1 - this.Loadchargepercent) - expenseadb - commissionamountadb);
                rideracdbaccountvalue = (1 + growthrate) * (rideracdbaccountvalue + rideracdbcostillustration(sno) * (1 - this.Loadchargepercent) - expenseacdb - commissionamountacdb);
                riderciaccountvalue = (1 + growthrate) * (riderciaccountvalue + ridercicostillustration(sno) * (1 - this.Loadchargepercent) - expenseci - commissionamountci);
                ridertermaccountvalue = (1 + growthrate) * (ridertermaccountvalue + ridertermcostillustration(sno) * (1 - this.Loadchargepercent) - expenseterm - commissionamountterm);
                rideroiraccountvalue = (1 + growthrate) * (rideroiraccountvalue + rideroircostillustration(sno) * (1 - this.Loadchargepercent) - expenseoir - commissionamountoir);


                illresult[i - this.age].Adbpremium = rideradbcostillustration(sno);
                illresult[i - this.age].Acdbpremium = rideracdbcostillustration(sno);
                illresult[i - this.age].Cipremium = ridercicostillustration(sno);
                illresult[i - this.age].Termpremium = ridertermcostillustration(sno);
                illresult[i - this.age].Oirpremium = rideroircostillustration(sno);





                illresult[i - this.age].Ridersaccountvalue = rideradbaccountvalue + rideracdbaccountvalue + ridertermaccountvalue + rideroiraccountvalue;

                double combaccountvalue = accountvalue + rideracdbaccountvalue + rideradbaccountvalue + ridertermaccountvalue + rideroiraccountvalue + riderciaccountvalue;

                double temprescatevalue = this.getRescatevalue(sno, accountvalue);

                if (partialsurrenderamount > 0)
                {
                    if (temprescatevalue > 0)
                    {
                        accountvalue = accountvalue - accountvalue * (partialsurrenderamount / temprescatevalue);
                        gcase[2].Rescatevalue = temprescatevalue - partialsurrenderamount;
                    }
                    else
                    {
                        accountvalue = accountvalue - partialsurrenderamount;// - this.surrendercharge;
                        gcase[2].Rescatevalue = 0.0;
                    }
                }
                else
                {
                    gcase[2].Rescatevalue = this.getRescatevalue(sno, accountvalue);
                }




                //gcase[2].Accountvalue = combaccountvalue;// accountvalue + rideracdbaccountvalue + rideradbaccountvalue + ridertermaccountvalue + rideroiraccountvalue + riderciaccountvalue;
                gcase[2].Accountvalue = accountvalue - totalloanamount + totalinterestamount - totalpenaltyamount;// accountvalue + rideracdbaccountvalue + rideradbaccountvalue + ridertermaccountvalue + rideroiraccountvalue + riderciaccountvalue;
                gcase[2].Rescatevalue = this.getRescatevalue(sno, gcase[2].Accountvalue);


                gcase[2].Growthrate = growthrate;
                if (this.plantypecode == Plantypes.FIXED)
                {
                    if ((((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + iinsuredamount) > accountvalue)
                    {
                        gcase[2].Insuredamount = ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + iinsuredamount - totalloanamount;
                    }
                    else
                    {
                        gcase[2].Insuredamount = accountvalue;
                    }
                    //gcase[2].Insuredamount = iinsuredamount - totalloanamount +((sno+this.age-1)<=this.ridertermuntilage?this.ridertermamount:0);

                }
                else
                {
                    gcase[2].Insuredamount = iinsuredamount - totalloanamount + +((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + (accountvalue > 0 ? accountvalue : 0);
                }

                gcase[2].Insuredamount = gcase[2].Accountvalue > 0 ? gcase[2].Insuredamount : 0;


                double riderscompaccountvalue1 = (rideradbcompaccountvalue1 + rideracdbcompaccountvalue1 + ridercicompaccountvalue1 + ridertermcompaccountvalue1 + rideroircompaccountvalue1);


                costofinsurancecomp1 = this.Costofinsuranceillustration(accountvaluecomp1 - riderscompaccountvalue1 + totalloanamount, sno);

                if ((rideradbcode == 'Y') && (i <= Rideradbmaxage))
                {
                    expenseadbcomp1 = this.rideradbamount * this.Rideradbfactor * (1.0 / 1000.0);
                }
                else
                {
                    expenseadbcomp1 = 0;
                }
                expensetermcomp1 = Costofterminsuranceillustration(ridertermcompaccountvalue1 + rideradbcompaccountvalue1, sno);
                expenseoircomp1 = OIRCostofinsuranceoverage(this.rideroiramount, rideroircompaccountvalue1 + ridertermcompaccountvalue1, sno);
                riderpayments = expenseadbcomp1 + expenseacdbcomp1 + expensecicomp1 + expensetermcomp1 + expenseoircomp1;


                accountvaluecomp1 = (1 + growthratecomp1) * (accountvaluecomp1 + ipremiumamount - costofinsurancecomp1 - loadcharge - commissionamount - this.Monthlyfeevalueyear - riderpayments);

                //rideradbcompaccountvalue1 = (1 + growthratecomp1) * (rideradbcompaccountvalue1 + rideradbcost - expenseadbcomp1);
                rideradbcompaccountvalue1 = (1 + growthratecomp1) * (rideradbcompaccountvalue1 + rideradbcostillustration(sno) * (1 - this.Loadchargepercent) - expenseadbcomp1 - commissionamountadb);
                rideracdbcompaccountvalue1 = (1 + growthratecomp1) * (rideracdbcompaccountvalue1 + rideracdbcostillustration(sno) * (1 - this.Loadchargepercent) - expenseacdbcomp1 - commissionamountacdb);
                ridercicompaccountvalue1 = (1 + growthratecomp1) * (ridercicompaccountvalue1 + ridercicostillustration(sno) * (1 - this.Loadchargepercent) - expensecicomp1 - commissionamountci);
                ridertermcompaccountvalue1 = (1 + growthratecomp1) * (ridertermcompaccountvalue1 + ridertermcostillustration(sno) * (1 - this.Loadchargepercent) - expensetermcomp1 - commissionamountterm);
                rideroircompaccountvalue1 = (1 + growthratecomp1) * (rideroircompaccountvalue1 + rideroircostillustration(sno) * (1 - this.Loadchargepercent) - expenseoircomp1 - commissionamountoir);



                //accountvaluecomp1 = accountvaluecomp1 - loanamount + loanrepayamount;

                temprescatevalue = this.getRescatevalue(sno, accountvaluecomp1);
                if (partialsurrenderamount > 0)
                {
                    if (temprescatevalue > 0)
                    {
                        accountvaluecomp1 = accountvaluecomp1 - accountvaluecomp1 * (partialsurrenderamount / temprescatevalue);
                        gcase[0].Rescatevalue = temprescatevalue - partialsurrenderamount;
                    }
                    else
                    {
                        accountvaluecomp1 = accountvaluecomp1 - partialsurrenderamount;//- this.surrendercharge;
                        gcase[0].Rescatevalue = 0.0;
                    }
                }
                else
                {
                    gcase[0].Rescatevalue = this.getRescatevalue(sno, accountvaluecomp1);
                }

                //gcase[0].Accountvalue = accountvaluecomp1 + rideracdbcompaccountvalue1 + rideradbcompaccountvalue1 + ridertermcompaccountvalue1 + rideroircompaccountvalue1 + ridercicompaccountvalue1;
                gcase[0].Accountvalue = accountvaluecomp1 - totalloanamount + totalinterestamountcomp1 - totalpenaltyamountcomp1;// +rideracdbcompaccountvalue1 + rideradbcompaccountvalue1 + ridertermcompaccountvalue1 + rideroircompaccountvalue1 + ridercicompaccountvalue1;
                gcase[0].Rescatevalue = this.getRescatevalue(sno, gcase[0].Accountvalue);
                if (this.varinvestprofilecode == 'Y')
                {
                    gcase[0].Growthrate = growthrate;
                }




                if (this.plantypecode == Plantypes.FIXED)
                {

                    if ((((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + iinsuredamount) > accountvaluecomp1)
                    {
                        gcase[0].Insuredamount = ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + iinsuredamount - totalloanamount;
                    }
                    else
                    {
                        gcase[0].Insuredamount = accountvaluecomp1;
                    }

                    //gcase[0].Insuredamount = iinsuredamount - totalloanamount + ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0);
                }
                else
                {
                    gcase[0].Insuredamount = iinsuredamount - totalloanamount + ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + (accountvaluecomp1 > 0 ? accountvaluecomp1 : 0);
                    //gcase[2].Insuredamount = iinsuredamount - totalloanamount + this.ridertermamount + (accountvalue > 0 ? accountvalue : 0);
                }

                //

                gcase[0].Insuredamount = gcase[0].Accountvalue > 0 ? gcase[0].Insuredamount : 0;


                double riderscompaccountvalue2 = (rideradbcompaccountvalue2 + rideracdbcompaccountvalue2 + ridercicompaccountvalue2 + ridertermcompaccountvalue2 + rideroircompaccountvalue2);
                costofinsurancecomp2 = this.Costofinsuranceillustration(accountvaluecomp2 - riderscompaccountvalue2 + totalloanamount, sno);

                if ((rideradbcode == 'Y') && (i <= Rideradbmaxage))
                {
                    expenseadbcomp2 = this.rideradbamount * this.Rideradbfactor * (1.0 / 1000.0);
                }
                else
                {
                    expenseadbcomp2 = 0;
                }
                expensetermcomp2 = Costofterminsuranceillustration(ridertermcompaccountvalue2 + rideradbcompaccountvalue2, sno);
                expenseoircomp2 = OIRCostofinsuranceoverage(this.rideroiramount, rideroircompaccountvalue2 + ridertermcompaccountvalue2, sno);

                riderpayments = expenseadbcomp2 + expenseacdbcomp2 + expensecicomp2 + expensetermcomp2 + expenseoircomp2;



                accountvaluecomp2 = (1 + growthratecomp2) * (accountvaluecomp2 + ipremiumamount - costofinsurancecomp2 - loadcharge - commissionamount - this.Monthlyfeevalueyear - riderpayments);

                //rideradbcompaccountvalue2 = (1 + growthratecomp2) * (rideradbcompaccountvalue2 + rideradbcost - expenseadbcomp2);

                // rider comp2
                rideradbcompaccountvalue2 = (1 + growthratecomp2) * (rideradbcompaccountvalue2 + rideradbcostillustration(sno) * (1 - this.Loadchargepercent) - expenseadbcomp2 - commissionamountadb);
                rideracdbcompaccountvalue2 = (1 + growthratecomp2) * (rideracdbcompaccountvalue2 + rideracdbcostillustration(sno) * (1 - this.Loadchargepercent) - expenseacdbcomp2 - commissionamountacdb);
                ridercicompaccountvalue2 = (1 + growthratecomp2) * (ridercicompaccountvalue2 + ridercicostillustration(sno) * (1 - this.Loadchargepercent) - expensecicomp2 - commissionamountci);
                ridertermcompaccountvalue2 = (1 + growthratecomp2) * (ridertermcompaccountvalue2 + ridertermcostillustration(sno) * (1 - this.Loadchargepercent) - expensetermcomp2 - commissionamountterm);
                rideroircompaccountvalue2 = (1 + growthratecomp2) * (rideroircompaccountvalue2 + rideroircostillustration(sno) * (1 - this.Loadchargepercent) - expenseoircomp2 - commissionamountoir);


                //accountvaluecomp2 = accountvaluecomp2 - loanamount + loanrepayamount;



                temprescatevalue = this.getRescatevalue(sno, accountvaluecomp2);
                if (partialsurrenderamount > 0)
                {
                    if (temprescatevalue > 0)
                    {
                        accountvaluecomp2 = accountvaluecomp2 - accountvaluecomp2 * (partialsurrenderamount / temprescatevalue);
                        gcase[1].Rescatevalue = temprescatevalue - partialsurrenderamount;
                    }
                    else
                    {
                        accountvaluecomp2 = accountvaluecomp2 - partialsurrenderamount;// - this.surrendercharge;
                        gcase[1].Rescatevalue = 0.0;
                    }
                }
                else
                {
                    gcase[1].Rescatevalue = this.getRescatevalue(sno, accountvaluecomp2);
                }


                //gcase[1].Accountvalue = accountvaluecomp2 + rideracdbcompaccountvalue2 + rideradbcompaccountvalue2 + ridertermcompaccountvalue2 + rideroircompaccountvalue2 + ridercicompaccountvalue2; ;
                gcase[1].Accountvalue = accountvaluecomp2 - totalloanamount + totalinterestamountcomp2 - totalpenaltyamountcomp2;// +rideracdbcompaccountvalue2 + rideradbcompaccountvalue2 + ridertermcompaccountvalue2 + rideroircompaccountvalue2 + ridercicompaccountvalue2; ;
                gcase[1].Rescatevalue = this.getRescatevalue(sno, gcase[1].Accountvalue);

                gcase[1].Growthrate = growthratecomp2;
                if (this.plantypecode == Plantypes.FIXED)
                {

                    if ((((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + iinsuredamount) > accountvaluecomp2)
                    {
                        gcase[1].Insuredamount = ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + iinsuredamount - totalloanamount;
                    }
                    else
                    {
                        gcase[1].Insuredamount = accountvaluecomp2;
                    }

                    //gcase[1].Insuredamount = iinsuredamount - totalloanamount + ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0);
                }
                else
                {
                    gcase[1].Insuredamount = iinsuredamount - totalloanamount + ((sno + this.age - 1) <= this.ridertermuntilage ? this.ridertermamount : 0) + (accountvaluecomp2 > 0 ? accountvaluecomp2 : 0);
                    //gcase[2].Insuredamount = iinsuredamount - totalloanamount + this.ridertermamount + (accountvalue > 0 ? accountvalue : 0);
                }
                gcase[1].Insuredamount = gcase[1].Accountvalue > 0 ? gcase[1].Insuredamount : 0;
                //
                illresult[sno - 1].Age = this.age + sno - 1;
                illresult[sno - 1].Numscenarios = 3;
                illresult[sno - 1].Premium = getPremiumamountillustration(sno);
                illresult[sno - 1].Sno = sno;

                illresult[sno - 1].isdynamicgrowthrate = this.varinvestprofilecode;


                illresult[sno - 1].Growthdata = gcase;


            }


            return illresult;

        }

        private double getRescatevalue(int sno, double accountvalue)
        {
            if (accountvalue > 0)
            {
                double penaltycharge = accountvalue * (this.Calctargetamount / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno)
                + accountvalue * ((this.Calcaveragepremium - this.Calctargetamount) / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno) * this.surrenderexcesspenalty + (sno <= 18 ? this.surrendercharge : 0);
                return  (accountvalue - penaltycharge)>0?(accountvalue - penaltycharge):0;        
            }
            else
            {
                return 0.0;
            }            
        }




        /*
        private double getAccountdeductvalueforsurrender(int sno, double accountvalue)
        {
            if (accountvalue > 0)
            {
                double penaltycharge = accountvalue * (this.Calctargetamount / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno)
                + accountvalue * ((this.Calcaveragepremium - this.Calctargetamount) / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno) * this.surrenderexcesspenalty + this.surrendercharge;
                return (accountvalue - penaltycharge) > 0 ? (accountvalue - penaltycharge) : 0;
            }
            else
            {
                return 0.0;
            }
        }*/


        public double calculateTargetforniguna()
        {
            

            double[] finpayments = new double[this.numberofyears];
            for (int i = 0; i < this.numberofyears; i++)
            {
                double apremiumamount = this.getPremiumamountillustration(i + 1);
                if (i == 0)
                {
                    finpayments[i] = apremiumamount - this.initialcontributionamount;
                }
                else
                {
                    if (apremiumamount > finpayments[0])
                    {
                        finpayments[i] = finpayments[0];
                    }
                    else
                    {
                        finpayments[i] = apremiumamount;
                    }
                }
            }

            double growthrt = getGrowthrate(1);
            //double targetforninguna = -Microsoft.VisualBasic.Financial.Pmt(growthrt, this.Targetcontributionperiod, Microsoft.VisualBasic.Financial.NPV(growthrt, ref finpayments)),  Microsoft.VisualBasic.DueDate.BegOfPeriod);

            
            double npvvalue = Financial.NPV(growthrt, ref finpayments);
            double targetamt =-1.0* Financial.Pmt(growthrt, this.Targetcontributionperiod, npvvalue,0,Microsoft.VisualBasic.DueDate.BegOfPeriod);
            return  targetamt*this.TargetNingunaPercent*(1.0/(1.0+this.Premiumreserve-.05));
        }



        private double rideradbcostillustration(int sno)
        {
            if (sno <= this.numberofyears)
            {
                return rideradbcost;
            }
            else
            {
                return 0.0;
            }
        }

        private double rideracdbcostillustration(int sno)
        {
            if (sno <= this.numberofyears)
            {
                return rideracdbcost;
            }
            else
            {
                return 0.0;
            }
        }
        
        private double ridercicostillustration(int sno)
        {
            if (sno <= this.numberofyears)
            {
                return ridercicost;
            }
            else
            {
                return 0.0;
            }
        }
        
        private double ridertermcostillustration(int sno)
        {
            if (sno <= this.numberofyears)
            {
                return ridertermcost;
            }
            else
            {
                return 0.0;
            }
        }

        private double rideroircostillustration(int sno)
        {
            if (sno <= this.numberofyears)
            {
                return rideroircost;
            }
            else
            {
                return 0.0;
            }
        }



    }
}
