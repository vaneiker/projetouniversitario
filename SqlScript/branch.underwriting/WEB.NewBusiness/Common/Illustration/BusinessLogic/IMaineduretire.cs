using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class IMaineduretire
    {
        public enum CALCTYPES
        {
            PREMIUMAMOUNT = 1,
            annuityamount = 2
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

        private double calculatedtargetpercent;
        private double calculatedtargetinitial;
        private double calculatedtargetamount;
        private double calculatedinsurancefactor;


        public Boolean isOpeningbalance = false;
        public int planyearstart;
        public double openingbalanceamount = 0.0;

        public double openingtarget = 0.0;
        public double openingminpremium = 0.0;

        private RulesService _rulesService;
        private IllustrationService _illustrationService;

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
                            vartempamount[j] = Productinvprofile.getInvprofilerate(varpdata[i].investmentprofilecode, this.productcode, classcode);
                        }
                    }
                }
                else
                {
                    for (int j = (varpdata[i].fromyear - 1); j < (this.Maxage - this.age + 1); j++)
                    {
                        if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
                        {
                            vartempamount[j] = Productinvprofile.getInvprofilerate(varpdata[i].investmentprofilecode, this.productcode, classcode);
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
                            if ((j + 1) >= 1 && j < (this.numberofyears))
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
                            if ((j + 1) >= 1 && j < (this.numberofyears))
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

        public IMaineduretire(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customer,
            Entity.UnderWriting.IllusData.Illustrator.CustomerPlanDetail customerPlanDetail,
            IllustrationService illustrationService)
        {
                this.productcode = customerPlanDetail.ProductCode;
                _illustrationService = illustrationService;
                _rulesService = illustrationService.RulesService;
                var customerplanno = customerPlanDetail.CustomerPlanNo;
                this.classcode = customerPlanDetail.PClass[0];

                DateTime[] dt1 = new DateTime[10];
                dt1[0] = DateTime.Now;
                dt1[1] = DateTime.Now;

                setRuledata();

                dt1[2] = DateTime.Now;

                this.plantypecode = customerPlanDetail.PlanTypeCode[0];

                this.numberofyears = customerPlanDetail.ContributionPeriod;

                this.calculatetypecode = customerPlanDetail.CalculateTypeCode[0];

                this.frequencytypecode = customerPlanDetail.FrequencyTypeCode[0];

                var frequencyTypeModel = Utility.GetIllusDropDownByType(Utility.DropDownType.FrequencyType)
                .Single(o => o.FrequencyTypeCode == customerPlanDetail.FrequencyTypeCode);

                this.frequencytypevalue = frequencyTypeModel.FrequencyValue.GetValueOrDefault();
                this.frequencytypepenalty = illustrationService.oIllusDataManager.GetFrequencyCost(productcode, customerPlanDetail.FrequencyTypeCode).Single().FrequencyCost.ToDouble();

                this.investmentprofilecode = customerPlanDetail.InvestmentProfileCode[0];

                this.age = customer.Age.ToInt();

                //this.gender = gender;
                this.gendercode = customer.GenderCode[0];

                //this.smoker = smoker;
                this.smokercode = customer.Smoker[0];

                //this.country = country;
                this.countryno = customerPlanDetail.CountryNo;

                //this.activityrisktype = activityrisktype;
                var activityRiskModel = Utility.GetIllusDropDownByType(Utility.DropDownType.ActivityRiskType, productcode)
             .Single(o => o.ActivityRiskTypeNo == customerPlanDetail.ActivityRiskTypeNo);
                this.activityrisktypevalue = activityRiskModel.ActivityRiskValue.ToDouble();

                //this.healthrisktype = healthrisktype;
                var healthRiskModel = Utility.GetIllusDropDownByType(Utility.DropDownType.HealthRiskType, productcode)
               .Single(o => o.HealthRiskTypeNo == customerPlanDetail.HealthRiskTypeNo);
                this.healthrisktypevalue = healthRiskModel.HealthRiskValue.ToDouble();

                this.growthrate = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode, classcode);

                // calculating mortality data
                dt1[3] = DateTime.Now;

                int maxage = _rulesService.GetValue(RulesService.Rules.MAX_AGE).ToInt();
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, illustrationService.ProductIsFixed, Ridertypes.Primary.ToString(), this.age, this.gendercode.ToString(), this.smokercode.ToString(), _rulesService, illustrationService);
                dt1[4] = DateTime.Now;

                this.costoffunds = _rulesService.GetValue(RulesService.Rules.FUND_COST);
                this.netgrowthrate = (this.growthrate - this.costoffunds);

                countryrisk = Utility.GetIllusDropDownByType(Utility.DropDownType.Country).Single(o => o.CountryNo == this.countryno).RiskValue.ToDouble();

                var premiumdata = illustrationService.oIllusDataManager.GetCustomerPlanVarPremium(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((premiumdata != null) && (premiumdata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[premiumdata.Count()];
                    foreach (var item in premiumdata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata[i].amount = item.PremiumAmount.ToDouble();
                    }
                    setVardata(IVarPlanData.PREMIUM, ivdata);
                }

                this.insuredamount = customerPlanDetail.InsuredAmount.ToDouble();
                this.calcinsuredamount = this.insuredamount;

                if (varpremiumcode == 'N')
                    this.periodicpremiumamount = customerPlanDetail.PremiumAmount.ToDouble();
                else
                    this.periodicpremiumamount = varpremiumamount[0];

                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                this.calcyearlypremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);

                this.calcannuityamount = this.annuityamount = customerPlanDetail.AnnuityAmount.ToDouble();

                dt1[5] = DateTime.Now;
                // calculating commission data
                commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears, illustrationService);
                dt1[6] = DateTime.Now;

                surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0, illustrationService);

                dt1[7] = DateTime.Now;

                this.setInitialcontribution(
                    !customerPlanDetail.InitialContribution.ToString().Equals("0.0"),
                    customerPlanDetail.InitialContribution);

                this.retirementnoofyears = customerPlanDetail.RetirementPeriod.ToInt();
                this.defermentnoofyears = customerPlanDetail.DefermentPeriod.ToInt();

                dt1[8] = DateTime.Now;

                var custplanopbal = illustrationService.oIllusDataManager.GetCustomerPlaNopBal(customerPlanDetail.CustomerNo.GetValueOrDefault(), customerPlanDetail.CustomerPlanNo.GetValueOrDefault()).FirstOrDefault();

                if (custplanopbal != null)
                {
                    this.planyearstart = custplanopbal.PlanYear.ToInt();
                    this.openingbalanceamount = custplanopbal.AdjustedAccountValue.ToDouble();
                    this.openingtarget = custplanopbal.TargetAmount.ToDouble();
                    this.openingminpremium = custplanopbal.MinimumPremium.ToDouble();
                    isOpeningbalance = true;
                }
                else
                    isOpeningbalance = false;

                this.calculatedtargetpercent = this.Targetpercent;
                this.calculatedtargetinitial = this.Targetinitial;
                this.calculatedtargetamount = this.Targetamount;
                this.calculatedinsurancefactor = this.Insurancefactor;

                IREDassumeddata asdata = new IREDassumeddata();

                if (this.calculatetypecode == Calculatetypes.ANNUITYAMOUNT)
                {
                    this.tocalculate = CALCTYPES.annuityamount;
                    asdata.premiumamount = this.calcyearlypremium;

                    if (!this.isOpeningbalance)
                    {
                        variabletargetamount = varpremiumcode == 'Y' ? getVariableTargetamount() : 0;
                        asdata.targetamount = this.Targetamount;
                    }
                    else
                        asdata.targetamount = this.openingtarget;

                    double assumedannuityamount = 0;
                    if (this.productcode.Equals("AXS") || this.productcode.Equals("SCH"))
                        assumedannuityamount = goalseekAXSCH(asdata, GSMinimumannuityamount, GSMaximumannuityamount);
                    else
                        assumedannuityamount = goalseek(asdata, GSMinimumannuityamount, GSMaximumannuityamount);

                    this.calcannuityamount = assumedannuityamount;
                    this.annuityamount = assumedannuityamount;
                }
                else if (this.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                {
                    this.tocalculate = CALCTYPES.PREMIUMAMOUNT;
                    asdata.annuityamount = this.annuityamount;
                    double assumedpremiumamount = 0.0;
                    if (this.productcode.Equals("AXS") || this.productcode.Equals("SCH"))
                        assumedpremiumamount = goalseekAXSCH(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);
                    else
                        assumedpremiumamount = goalseek(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);

                    assumedpremiumamount = goalseek(asdata, GSMinimumpremiumamount, GSMaximumpremiumamount);

                    this.calcyearlypremium = assumedpremiumamount;
                }
        }

        public void setInitialcontribution(bool initialcontributionstr, decimal initialcontributionamountstr)
        {
            initialcontributioncode = initialcontributionstr ? 'Y' : 'N';
            this.initialcontributionamount = this.initialcontributioncode == 'Y' ? initialcontributionamountstr.ToDouble() : 0.0;
        }

        public void setRuledata()
        {
            insurancemaxage = _rulesService.GetValue(RulesService.Rules.INSURANCE_MAX_AGE).ToInt();
            GSMaximumpremiumamount = _rulesService.GetValue(RulesService.Rules.GS_MAXIMUM_PREMIUM_AMOUNT);
            GSMinimumpremiumamount = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_PREMIUM_AMOUNT);
            GSMaximumannuityamount = _rulesService.GetValue(RulesService.Rules.GS_MAXIMUM_ANNUITY_AMOUNT);
            GSMinimumannuityamount = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_ANNUITY_AMOUNT);

            Minimumpremiumamount = _rulesService.GetValue(RulesService.Rules.MINIMUM_YEARLY_PREMIUM);
            Minimuminsuredamount = _rulesService.GetValue(RulesService.Rules.MINIMUM_INSURED_AMT);
            Maximuminsuredamount = _rulesService.GetValue(RulesService.Rules.MAXIMUM_INSURED_AMT);
            Targetoverage = _rulesService.GetValue(RulesService.Rules.TARGET_OVERAGE);
            Premiumreserve = _rulesService.GetValue(RulesService.Rules.PREMIUM_RESERVE);
            Targetcontributionperiod = _rulesService.GetValue(RulesService.Rules.TARGET_CONTRIBUTION_PERIOD).ToInt();
            Monthlyfeevalue = _rulesService.GetValue(RulesService.Rules.MONTHLY_FEE);
            Monthlyfeevalueyear = this.Monthlyfeevalue * 12;
            Loadchargepercent = _rulesService.GetValue(RulesService.Rules.LOAD_CHARGE);
            GSMinimumcontributionperiod = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_CONTRIBUTION_PERIOD).ToInt();
            Maxage = _rulesService.GetValue(RulesService.Rules.MAX_AGE).ToInt();
            Minimumpremiumtotargetfactor = _rulesService.GetValue(RulesService.Rules.MINIMUM_PREMIUM_TO_TARGET_FACTOR);
            Targetdiscountfactor = _rulesService.GetValue(RulesService.Rules.TARGET_DISCOUNT_FACTOR);

            Minimumpremiumdiscountfactor = _rulesService.GetValue(RulesService.Rules.MINIMUM_PREMIUM_DISCOUNT_FACTOR);
            Retirementpartialtominprimamultiple = _rulesService.GetValue(RulesService.Rules.RETIREMENT_PARTIAL_MINIMUM_PREMIUM_MULTIPLE).ToInt();

            surrendercharge = _rulesService.GetValue(RulesService.Rules.SURRENDER_CHARGE);
            partialsurrendercharge = _rulesService.GetValue(RulesService.Rules.PARTIAL_SURRENDER_CHARGE);
            surrenderexcesspenalty = _rulesService.GetValue(RulesService.Rules.SURRENDER_EXCESS_PERCENT);

            this.LoanInterestRate = _rulesService.GetValue(RulesService.Rules.LOAN_INTEREST_RATE);
            this.LoanPrincipalGrowthRate = _rulesService.GetValue(RulesService.Rules.LOAN_PRINCIPAL_GROWTH_RATE);
            this.LoanPrincipalGrowInvestRate = _rulesService.GetValue(RulesService.Rules.LOAN_PRINCIPAL_GROW_INVEST_RATE).ToBoolean();

            this.InterestLoanRate = _rulesService.GetValue(RulesService.Rules.INTEREST_LOAN_RATE);
            this.LoanAssetRate = _rulesService.GetValue(RulesService.Rules.LOAN_ASSET_RATE);
            this.IsLoanRate = _rulesService.GetValue(RulesService.Rules.IS_LOAN_RATE).ToBoolean();

            this.Maxageoffsetfordefaultmoratlity = _rulesService.GetValue(RulesService.Rules.MAX_AGE_OFFSET_FOR_DEFAULT_MORTALITY);
            this.Maxagefordefaultmoratlity = _rulesService.GetValue(RulesService.Rules.MAX_AGE_FOR_DEFAULT_MORTALITY);
            this.Maxmortalityvalue = _rulesService.GetValue(RulesService.Rules.MAX_MORTALITY_VALUE);
            this.Malemortalityoffset = _rulesService.GetValue(RulesService.Rules.MALE_MORTALITY_OFFSET);
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
            double[] varprem = new double[calcvaryearlypremiumamount.Length - 1];
            for (int i = 1; i < calcvaryearlypremiumamount.Length; i++)
            {
                varprem[i - 1] = calcvaryearlypremiumamount[i];
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


        public double goalseek(IREDassumeddata asdata, double minamount, double maxamount)
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
                if ((accountvalueonretirement >= (assumedtargetaccountvalue - this.precision)) && (accountvalueonretirement <= (assumedtargetaccountvalue + this.precision)))
                {
                    return asdata.premiumamount;
                }
                else
                {
                    if (accountvalueonretirement < (assumedtargetaccountvalue - this.precision))
                    {
                        return goalseek(asdata, midamount, maxamount);
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
                double assumedtargetaccountvalue = (asdata.annuityamount + this.Monthlyfeevalueyear) * this.Insurancefactor;
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

        public double calculateCostofinsurance(double assumedinsuredamount, double accountvalue, int sno)
        {
            if (this.plantypecode == 'S')
            {
                if (sno <= (this.numberofyears + this.defermentnoofyears))
                {
                    double netinsuredamount = 0.0;// insuredamount;                       
                    netinsuredamount = assumedinsuredamount - accountvalue;
                    double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
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

        public double Commissionamount(double assumedpremiumamount, double assumedtargetamount, int sno)
        {
            double commissionamount = 0.0;
            double excesscommissionamount = 0.0;

            try
            {
                if (sno <= this.numberofyears)
                {
                    if (sno == 1)
                    {
                        //double assumedtargetamount
                        commissionamount = assumedtargetamount * this.commissiondata[sno + this.currentyeardifference - 1].commissionpercent;
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return commissionamount + (excesscommissionamount > 0 ? excesscommissionamount : 0);
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
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears;

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
                else if ((this.numberofyears < sno) && (sno > (this.numberofyears + this.defermentnoofyears)))
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
                accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear - tempannuityamount);
            }
            return accountvalue;
        }



        public REDIllusdata[] getIllustration()
        {
            double accountvalue = 0.0;
            double accumulatedpremium = 0.0;
            double tempinsuredamount = (annuityamount + this.Monthlyfeevalueyear) * this.calculatedinsurancefactor;
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears + this.retirementnoofyears;

            double[] resarry = getFullrescatearray();

            var illdata = new REDIllusdata[maxcalcperiod];

            if (this.isOpeningbalance == true)
            {
                accountvalue = this.openingbalanceamount;
            }

            for (int i = 1; i <= maxcalcperiod; i++)
            {


                int sno = i;
                double costofinsurance = calculateCostofinsurance(tempinsuredamount, accountvalue, sno);

                double commissionamount;
                double actualpremiumamount = 0.0;
                double premiumamount;
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
                            actualpremiumamount = varpremiumamount[i - 1] * this.frequencytypevalue;// * (1.0 / (1.0 + Premiumreserve));
                            premiumamount = this.calcvaryearlypremiumamount[i - 1];
                        }
                        if ((this.initialcontributioncode == 'Y') && (i == 1))
                        {
                            actualpremiumamount = actualpremiumamount + this.initialcontributionamount;
                            premiumamount = premiumamount + this.initialcontributionamount;
                            //commissionamount = this.Commissionamount(this.calcyearlypremium+this.initialcontributionamount, this.Targetamount, sno);
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
                double annuitypaid = 0.0;
                annuitypaid = sno > (this.numberofyears + this.defermentnoofyears) ? this.annuityamount : 0.0;
                double loadcharge = premiumamount * this.Loadchargepercent;
                //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                accountvalue = (1 + this.getGrowthrate(sno)) * (accountvalue + premiumamount - annuitypaid - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear);

                illdata[sno - 1] = new REDIllusdata();
                illdata[sno - 1].Accountvalue = accountvalue;
                illdata[sno - 1].Sno = sno;
                illdata[sno - 1].Premium = actualpremiumamount;
                accumulatedpremium = accumulatedpremium + actualpremiumamount;
                illdata[sno - 1].Accumulatedpremium = sno <= this.numberofyears ? accumulatedpremium : 0;

                illdata[sno - 1].Age = age + i - 1;

                illdata[sno - 1].Annuityamount = sno < (this.defermentnoofyears + this.numberofyears) ? this.calcannuityamount : 0;
                illdata[sno - 1].Commission = commissionamount;
                illdata[sno - 1].Costofinsurance = costofinsurance;

                illdata[sno - 1].Rescatevalue = Math.Max(0, resarry[sno - 1] * accountvalue);

                //Cambiado por solicitud de German Acosta. Gregory Garcia - 1/29/2015
                //if (sno < this.numberofyears)
                if (sno < (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Partialretirementamount = getPartialannualretirementamount(accountvalue, accumulatedpremium, sno);
                }
                //Cambiado por solicitud de German Acosta. Gregory Garcia - 1/29/2015
                //else if (sno == this.numberofyears)
                else if (sno == (this.defermentnoofyears + this.numberofyears))
                {
                    illdata[sno - 1].Partialretirementamount = annuityamount;
                }
                else
                {
                    illdata[sno - 1].Partialretirementamount = 0.0;
                }



                //illdata[sno - 1].Discbenefit =-this.Monthlyfeevalueyear-Microsoft.VisualBasic.Financial.Pmt(this.netgrowthrate,this.numberofyears,accountvalue,0,Microsoft.VisualBasic.DueDate.BegOfPeriod);

                double deathBenefit;
                double discBenefit;

                if (sno <= (this.defermentnoofyears + this.numberofyears))
                    if (this.plantypecode == Plantypes.INSURED)
                    {
                        deathBenefit = this.calcannuityamount;
                        if (sno == (this.numberofyears + this.defermentnoofyears))
                            discBenefit = this.calcannuityamount;
                        else
                            if (sno != (this.defermentnoofyears + this.numberofyears))
                                discBenefit = -this.Monthlyfeevalueyear - Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, DueDate.BegOfPeriod);
                            else
                                discBenefit = -Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, DueDate.BegOfPeriod);
                        //deathBenefit = calcannuityamount;
                    }
                    else
                        if (sno == (this.defermentnoofyears + this.numberofyears))
                        {
                            discBenefit = -Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, DueDate.BegOfPeriod);
                            deathBenefit = discBenefit;
                        }
                        else
                        {
                            discBenefit = -this.Monthlyfeevalueyear - Financial.Pmt(this.netgrowthrate, this.retirementnoofyears, accountvalue, 0, DueDate.BegOfPeriod);
                            deathBenefit = discBenefit + this.Monthlyfeevalueyear;
                        }

                else
                {
                    discBenefit = 0.0;
                    deathBenefit = 0.0;
                }

                illdata[sno - 1].Discbenefit = illdata[sno - 1].Partialretirementamount < discBenefit ? illdata[sno - 1].Partialretirementamount : discBenefit;
                illdata[sno - 1].Deathbenefit = illdata[sno - 1].Partialretirementamount < deathBenefit ? illdata[sno - 1].Partialretirementamount : deathBenefit;

                if (sno <= (this.defermentnoofyears + this.numberofyears))
                {
                    if (this.plantypecode == Plantypes.INSURED)
                    {
                        illdata[sno - 1].Deathbenefit = annuityamount;
                    }
                    else
                    {
                        illdata[sno - 1].Deathbenefit = illdata[sno - 1].Discbenefit - this.costoffunds;
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

        private double getRescatevalue_old(int sno, double accountvalue)
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
                return this.Targetamount * (1 - this.Minimumpremiumdiscountfactor);
            }
        }

        public double getPartialannualretirementamount(double accountvalue, double cumulativepremium, int sno)
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
                (Microsoft.VisualBasic.Financial.PV(this.netgrowthrate, (this.defermentnoofyears + this.numberofyears + this.retirementnoofyears - sno),
                this.Monthlyfeevalueyear, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod) + accountvalue)
                * Math.Pow((1 + this.netgrowthrate),
                ((this.defermentnoofyears + this.numberofyears) - sno)), 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);

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
            double[] resarray = new double[this.numberofyears + this.retirementnoofyears + this.defermentnoofyears];

            //for(int i=0;i<this

            for (int i = 0; i < (this.numberofyears + this.retirementnoofyears + this.defermentnoofyears); i++)
            {
                if ((i + 1) > (this.numberofyears + this.defermentnoofyears))
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
            return this.plantypecode == 'S' ? (calcannuityamount + this.Monthlyfeevalueyear) * this.calculatedinsurancefactor : 0.0;
        }

        public double getTargetAmountFE()
        {
            return this.Targetamount * (1.0 - Targetdiscountfactor);
        }

        public double getMinimumPremiumAmountFE()
        {
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

        public double getTestTargetamount(double testgrowthrate, double testvariabletargetamount)
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




        public double getTestgoalseek(IREDassumeddata testasdata, double minamount, double maxamount, double testgrowthrate)
        {
            double midamount = (maxamount + minamount) / 2.0;
            testasdata.annuityamount = midamount;

            double accountvalueonretirement = getTestcalculateAccountvalueonretirement(testasdata, testgrowthrate);
            double assumedtargetaccountvalue = (testasdata.annuityamount + this.Monthlyfeevalueyear) * getTestInsurancefactor(testgrowthrate);
            if ((accountvalueonretirement >= (0 - this.precision)) && (accountvalueonretirement <= (0 + this.precision)))
            {
                return testasdata.annuityamount;
            }
            else
            {
                if (accountvalueonretirement < (0 - this.precision))
                {
                    return getTestgoalseek(testasdata, minamount, midamount, testgrowthrate);
                }
                else if (accountvalueonretirement > (0 + this.precision))
                {
                    return getTestgoalseek(testasdata, midamount, maxamount, testgrowthrate);
                }
                else
                {
                    return 0.0;
                }
            }

        }

        public double getTestcalculateAccountvalueonretirement(IREDassumeddata testasdata, double testgrowthrate)
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
            int maxcalcperiod = this.numberofyears + this.defermentnoofyears + this.retirementnoofyears;
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
                accountvalue = (1 + testgrowthrate - this.costoffunds) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - this.Monthlyfeevalueyear - tempannuityamount);
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
            double testassumedannuityamount = getTestgoalseek(testdata, GSMinimumannuityamount, GSMaximumannuityamount, testgrowthrate);
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