using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class IMainInsuranceData
    {
        public Boolean planerror = false;
        public String planerrordata = "";

        public static int numtimescalled = 0;

        private string contributionuntilagestr;
        private string contributionperiodstr;

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
        public int age;
        public String country;

        private String financialgoal;
        public int financialgoalage;
        private double financialgoalamount;

        private String initialcontribution;
        public double initialcontributionamount;


        // start rider definition

        public double rideradbamount;

        public int ridertermuntilage;
        public char ridertermcontributiontypecode;
        public double ridertermamount;

        public String riderci;
        public double riderciamount;

        //public String rideroir;
        public double rideroiramount;
        public int oirage;
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
        public string gendercode;
        public string smokercode;
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

        public double[] varpremiumamount = null;
        public double[] varinsuredamount = null;
        public double[] varinvestprofile = null;
        public double[] varsurrenderamount = null;
        public double[] varloanamount = null;
        public double[] varloanrepayamount = null;

        public char varpremiumcode = 'N';
        public char varinsuredcode = 'N';
        public char varinvestprofilecode = 'N';
        public char varsurrendercode = 'N';
        public char varloancode = 'N';
        public char varloanrepaycode = 'N';




        private double targetaccountvalue = 0.0;
        private double financialgoalprecision = 5.0;
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

        private RulesService _rulesService;
        private IllustrationService _illustrationService;

        public IMainInsuranceData(Entity.UnderWriting.IllusData.Illustrator.CustomerDetail customer,
            Entity.UnderWriting.IllusData.Illustrator.CustomerPlanDetail customerPlanDetail,
            IllustrationService illustrationService)
        {
                // product code is set and also product
                this.classcode = customerPlanDetail.PClass[0];
                this.productcode = customerPlanDetail.ProductCode;

                _illustrationService = illustrationService;
                _rulesService = illustrationService.RulesService;
                var customerplanno = customerPlanDetail.CustomerPlanNo;

                // the rules are set here //
                setRuledata();

                // plantype is set properly plantypes are restricted to 'F','I'
                this.plantypecode = customerPlanDetail.PlanTypeCode[0];

                // contributiontypecode is set properly inclusing the number of years but age need to be checked and looked //
                this.contributiontypecode = customerPlanDetail.ContributionTypeCode[0];

                this.age = customer.Age.ToInt();
                if (this.age <= 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " age cannot be 0";
                }

                if (this.contributiontypecode == Utility.EContributionType.UntilAge.Code()[0])
                {
                    this.untilage = customerPlanDetail.ContributionUntilAge;
                    this.numberofyears = this.untilage - this.age + 1;
                }
                else if (this.contributiontypecode == Utility.EContributionType.NumberOfYears.Code()[0])
                    this.numberofyears = customerPlanDetail.ContributionPeriod;
                else if (this.contributiontypecode == Utility.EContributionType.Continuous.Code()[0])
                    this.numberofyears = _rulesService.GetValue(RulesService.Rules.MAX_AGE).ToInt();

                this.calculatetypecode = customerPlanDetail.CalculateTypeCode[0];

                this.frequencytypecode = customerPlanDetail.FrequencyTypeCode[0];

                var frequencyTypeModel = Utility.GetIllusDropDownByType(Utility.DropDownType.FrequencyType)
                .Single(o => o.FrequencyTypeCode == customerPlanDetail.FrequencyTypeCode);

                this.frequencytypevalue = frequencyTypeModel.FrequencyValue.GetValueOrDefault();
                this.frequencytypepenalty = illustrationService.oIllusDataManager.GetFrequencyCost(productcode, customerPlanDetail.FrequencyTypeCode).Single().FrequencyCost.ToDouble();

                if (customerPlanDetail.InvestmentProfileCode.SIsNullOrEmpty())
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " investment profile cannot be empty";
                    return;
                }
                this.investmentprofilecode = customerPlanDetail.InvestmentProfileCode[0];

                // gender is set here //
                this.gendercode = customer.GenderCode;
                if (gendercode.SIsNullOrEmpty())
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " gender cannot be empty";
                }

                // smoker is set here //
                this.smokercode = customer.Smoker;
                if (this.smokercode.SIsNullOrEmpty())
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " smoker cannot be empty";
                }

                // country data is set
                this.countryno = customerPlanDetail.CountryNo;
                if (this.countryno == 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " country cannot be empty";
                }

                // activity risk data is set
                var activityRiskModel = Utility.GetIllusDropDownByType(Utility.DropDownType.ActivityRiskType, productcode)
                .Single(o => o.ActivityRiskTypeNo == customerPlanDetail.ActivityRiskTypeNo);
                this.activityrisktypevalue = activityRiskModel.ActivityRiskValue.ToDouble();

                // health risk data is set
                var healthRiskModel = Utility.GetIllusDropDownByType(Utility.DropDownType.HealthRiskType, productcode)
                .Single(o => o.HealthRiskTypeNo == customerPlanDetail.HealthRiskTypeNo);
                this.healthrisktypevalue = healthRiskModel.HealthRiskValue.ToDouble();

                // growth rate data is set
                this.growthrate = customerPlanDetail.InvestmentProfilePercent.ToDouble();
                if (this.growthrate <= 0)
                {
                    this.planerror = true;
                    // need to create a string in languages so that, that particular string instead
                    this.planerrordata = this.planerrordata + " growth rate cannot be 0";
                }

                // calculating mortality data
                var maxage = _rulesService.GetValue(RulesService.Rules.MAX_AGE).ToInt();
                mortalitydata = Mortalityrates.getMortalitydata(this.productcode, illustrationService.ProductIsFixed, Utility.RiderType.Primary.Code()
                    , this.age, this.gendercode, this.smokercode, _rulesService, illustrationService);

                this.costoffunds = _rulesService.GetValue(RulesService.Rules.FUND_COST);
                netgrowthrate = (this.growthrate - this.costoffunds);

                countryrisk = Utility.GetIllusDropDownByType(Utility.DropDownType.Country).Single(o => o.CountryNo == this.countryno).RiskValue.ToDouble();

                //insured amount is set here            
                this.calcinsuredamount = this.insuredamount = customerPlanDetail.InsuredAmount.ToDouble();

                // a change is made here, there should be no impact
                this.periodicpremiumamount = customerPlanDetail.PremiumAmount.ToDouble();
                double penaltypercent = this.frequencytypepenalty;
                double netperiodicpayment = periodicpremiumamount / (1 + penaltypercent);
                double periodicgrowthrate = Math.Pow((1 + this.growthrate), 1.0 / this.frequencytypevalue * 1.0) - 1;
                annualizedpremiumamount = illustrationService.CalculatePv(periodicgrowthrate, this.frequencytypevalue, netperiodicpayment);
                this.calcyearlypremium = annualizedpremiumamount;

                // calculating commission data
                // no change is required here
                commissiondata = Commissions.getCommissiondata(this.productcode, 0, this.numberofyears, illustrationService);

                // no change is required here
                surrenderpenaltydata = Surrenderpenaties.getSurrenderpenaltydata(this.productcode, 0, illustrationService);

                this.setFinancialgoal(customerPlanDetail.FinancialGoal == "Y", customerPlanDetail.FinancialGoalAmount.ToDouble(), customerPlanDetail.FinancialGoalAge);
                if (customerPlanDetail.FinancialGoal == "Y")
                {
                    if (customerPlanDetail.FinancialGoalAge < this.age)
                    {
                        this.planerror = true;
                        // need to create a string in languages so that, that particular string instead
                        this.planerrordata = this.planerrordata + " financialgoal age rate cannot be less than age";
                    }
                }

                if (customerPlanDetail.IsoPeningBalance == "Y")
                {
                    var custopbal = illustrationService.oIllusDataManager.GetCustomerPlaNopBal(customerPlanDetail.CustomerNo.GetValueOrDefault(), customerPlanDetail.CustomerPlanNo.GetValueOrDefault()).First();
                    this.setOpeningbalance(custopbal.PlanYear.ToInt(), custopbal.AdjustedAccountValue.ToDouble(), custopbal.ForceTarget.ToDouble(), custopbal.MinimumPremium.ToDouble());
                }

                // initial contribution should work ok
                this.initialcontributioncode = customerPlanDetail.InitialContribution > 0 ? 'Y' : 'N';
                this.initialcontributionamount = customerPlanDetail.InitialContribution.ToDouble();

                // rider adb should work ok
                this.rideradbcode = customerPlanDetail.RiderAdb[0];
                this.rideradbamount = customerPlanDetail.RiderAdbAmount.ToDouble();
                this.rideradbcost = customerPlanDetail.RiderAdbCost.ToDouble();

                // rider acdb should work ok
                this.rideracdbcode = customerPlanDetail.RiderAcdb[0];
                this.rideracdbcost = customerPlanDetail.RiderAcdbCost.ToDouble();

                // rider ci should work ok
                this.ridercicode = customerPlanDetail.RiderCi[0];
                this.riderciamount = customerPlanDetail.RiderCiAmount.ToDouble();
                this.ridercicost = customerPlanDetail.RiderCiCost.ToDouble();

                // the code needs to be checked properly from here
                // rider term should work ok
                this.setRidertermdata(customerPlanDetail.RiderTerm, customerPlanDetail.RiderTermAmount.ToDouble(), customerPlanDetail.RiderTermUntilAge, customerPlanDetail.TermContributionTypeCode);
                this.ridertermcost = customerPlanDetail.RiderTermCost.ToDouble();

                if (customerPlanDetail.RiderOir == "Y")
                {
                    var othins = illustrationService.oIllusDataManager.GetCustomerPlanPartnerInsurance(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                    setOirdatavals(customerPlanDetail.RiderOir[0], othins.RideroirAmount.ToDouble(),
                        othins.Age.GetValueOrDefault(),
                        othins.GenderCode[0], othins.Smoker[0],
                        othins.UntilAge,
                        othins.ActivityRiskTypeNo.GetValueOrDefault(),
                        othins.HealthRiskTypeNo.GetValueOrDefault(), othins.ContributionTypeCode[0]);

                    this.rideroircost = othins.RideroirCost.ToDouble();
                }

                var premdata = illustrationService.oIllusDataManager.GetCustomerPlanVarPremium(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((premdata != null) && (premdata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[premdata.Count()];
                    foreach (var item in premdata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata[i].amount = item.PremiumAmount.ToDouble();
                    }
                    setVardata(IVarPlanData.PREMIUM, ivdata);
                }

                var insdata = illustrationService.oIllusDataManager.GetCustomerPlanVarInsured(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((insdata != null) && (insdata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[insdata.Count()];
                    foreach (var item in insdata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata[i].amount = item.InsuredAmount.ToDouble();
                    }
                    setVardata(IVarPlanData.INSURED, ivdata);
                }


                var loandata = illustrationService.oIllusDataManager.GetCustomerPlanLoan(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((loandata != null) && (loandata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[loandata.Count()];
                    foreach (var item in loandata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata[i].amount = item.LoanAmount.ToDouble();
                    }
                    setVardata(IVarPlanData.LOAN, ivdata);
                }

                var repaydata = illustrationService.oIllusDataManager.GetCustomerPlanLoanRepay(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((repaydata != null) && (repaydata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[repaydata.Count()];
                    foreach (var item in repaydata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata[i].amount = item.PaymentAmount.ToDouble();
                    }
                    setVardata(IVarPlanData.LOANREPAY, ivdata);
                }

                var surrenderdata = illustrationService.oIllusDataManager.GetCustomerPlanVarSurrender(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((surrenderdata != null) && (surrenderdata.Count() > 0))
                {
                    int i = -1;
                    IVarPlanData[] ivdata = new IVarPlanData[surrenderdata.Count()];
                    foreach (var item in surrenderdata)
                    {
                        i++;
                        ivdata[i] = new IVarPlanData();
                        ivdata[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata[i].amount = item.SurrenderAmount.ToDouble();
                    }
                    setVardata(IVarPlanData.SURRENDER, ivdata);
                }

                var profiledata = illustrationService.oIllusDataManager.GetCustomerPlanVarProfile(customerPlanDetail.CustomerPlanNo.GetValueOrDefault());

                if ((profiledata != null) && (profiledata.Count() > 0))
                {
                    int i = -1;
                    IVarProfileData[] ivdata1 = new IVarProfileData[profiledata.Count()];
                    foreach (var item in profiledata)
                    {
                        i++;
                        ivdata1[i] = new IVarProfileData();
                        ivdata1[i].fromyear = item.FromYearNo.GetValueOrDefault();
                        ivdata1[i].toyear = item.ToYearNo.GetValueOrDefault();
                        ivdata1[i].investmentprofilecode = item.InvestmentProfileCode[0];
                    }
                    setVarinvprofiledata(ivdata1);
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

        public bool setVarinvprofiledata(IVarProfileData[] varpdata)
        {
            double[] vartempamount = new double[this.Maxage - this.age + 1];

            for (int i = 0; i < varpdata.Length; i++)
            {
                if ((i == 0 && varpdata[0].fromyear != 1) ||
                    (varpdata[0].fromyear > varpdata[i].toyear) ||
                    (i != 0 && (varpdata[i].fromyear - varpdata[i - 1].toyear != 1)))
                    return false;

                var range = i != (varpdata.Length - 1) ? varpdata[i].toyear : this.Maxage - this.age + 1;

                for (int j = (varpdata[i].fromyear - 1); j < range; j++)
                    if ((j + 1) >= 1 && j < (this.Maxage - this.age + 1))
                        vartempamount[j] = Utility
                            .GetIllusDropDownByType(Utility.DropDownType.InvestmentProfile, this.productcode, pClass: this.classcode.ToString())
                            .Single(o => o.InvestmentProfileCode == varpdata[i].investmentprofilecode.ToString()).InvestmentProfileRate.ToDouble();
            }

            varinvestprofile = vartempamount;
            varinvestprofilecode = 'Y';
            return true;
        }

        public void setFinancialgoal(bool fingoal, double fingoalamountstr, int financialgoaluntilagestr)
        {
            financialgoalcode = fingoal ? 'Y' : 'N';
            if (fingoal)
            {
                this.targetaccountvalue = this.financialgoalamount = fingoalamountstr;
                this.financialgoalage = financialgoaluntilagestr;
            }
            else
            {
                this.financialgoalamount = 0.0;
                this.financialgoalage = 0;
            }
        }

        public void setOpeningbalance(int planyearstartstr, double openingbalanceamountstr, double targetamountstr, double minimumpremiumstr)
        {
            isOpeningbalance = true;
            this.planyearstart = planyearstartstr;
            this.openingbalanceamount = openingbalanceamountstr;
            this.calctargetamount = targetamountstr;
            this.calcminimumpremium = minimumpremiumstr;
        }

        public void setRidertermdata(string riderterm, double ridertermamount, int ridertermuntilage, string ridertermcontributiontypeCode)
        {
            this.ridertermcode = riderterm[0];
            if (this.ridertermcode == 'Y')
            {
                this.ridertermamount = ridertermamount;
                this.ridertermcontributiontypecode = ridertermcontributiontypeCode[0];

                int temptermuntilage = ridertermuntilage;

                if (ridertermcontributiontypeCode == Utility.EContributionType.Continuous.Code())
                    this.ridertermuntilage = Maxage;
                else if (ridertermcontributiontypeCode == Utility.EContributionType.NumberOfYears.Code())
                    if ((temptermuntilage + this.age) >= Maxage)
                        this.ridertermuntilage = Maxage;
                    else
                        this.ridertermuntilage = temptermuntilage + this.age - 1;
                else if (ridertermcontributiontypeCode == Utility.EContributionType.UntilAge.Code())
                    this.ridertermuntilage = Math.Min(temptermuntilage, Maxage);
            }
            else
            {
                this.ridertermamount = 0.0;
                this.ridertermuntilage = 0;
                this.ridertermcontributiontypecode = Utility.EContributionType.UntilAge.Code()[0];
            }
        }

        public void setOirdatavals(char rideroircode1, double rideroiramount1, int oirage1, char oirgendercode1, char oirsmokercode1, int oiruntilage1, int oiractivityriskno1, int oirhealthriskno1, char oircontributiontypecode1)
        {
            rideroircode = rideroircode1;
            if (this.rideroircode == 'Y')
            {
                this.rideroiramount = rideroiramount1;
                this.oirage = oirage1;
                int auntilage = oiruntilage1;
                this.oircontributiontypecode = oircontributiontypecode1;

                if (this.oircontributiontypecode.ToString() == Utility.EContributionType.Continuous.Code())
                    this.oiruntilage = Maxage;
                else if (this.oircontributiontypecode.ToString() == Utility.EContributionType.NumberOfYears.Code())
                    this.oiruntilage = Math.Min(oiruntilage + this.age, Maxage);
                else if (this.oircontributiontypecode.ToString() == Utility.EContributionType.UntilAge.Code())
                    this.oiruntilage = Math.Min(auntilage, Maxage);

                var activityRiskModel = Utility.GetIllusDropDownByType(Utility.DropDownType.ActivityRiskType, productcode)
               .Single(o => o.ActivityRiskTypeNo == oiractivityriskno1);

                var healthRiskModel = Utility.GetIllusDropDownByType(Utility.DropDownType.HealthRiskType, productcode)
                .Single(o => o.HealthRiskTypeNo == oirhealthriskno1);

                this.oiractivityrisktypevalue = activityRiskModel.ActivityRiskValue.ToDouble();
                this.oirhealthrisktypevalue = healthRiskModel.HealthRiskValue.ToDouble();

                this.oirgendercode = oirgendercode1;
                this.oirsmokercode = oirsmokercode1;

                oirmortalitydata = new IMortalitydata[this.oiruntilage - this.oirage + 1];
                for (int i = this.oirage; i <= this.oiruntilage; i++)
                {
                    oirmortalitydata[i - this.oirage] = new IMortalitydata();
                    int sno = i - this.oirage + 1;
                    oirmortalitydata[sno - 1].age = this.oirage + sno - 1;
                    oirmortalitydata[sno - 1].sno = sno;
                    oirmortalitydata[sno - 1].mortalityvalue = Mortalityrates.getMortalityrate(
                        this.productcode, _illustrationService.ProductIsFixed, Utility.RiderType.Primary.Code(), oirmortalitydata[sno - 1].age, this.oirgendercode.ToString(), this.oirsmokercode.ToString(), _rulesService, _illustrationService);
                }
            }
            else
            {
                this.rideroircode = 'N';
                this.rideroiramount = 0;
                this.oirage = 0;
                this.oircontributiontypecode = Utility.EContributionType.UntilAge.Code()[0];
            }
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

            return true;
        }

        public void setRuledata()
        {
            insurancemaxage = _rulesService.GetValue(RulesService.Rules.INSURANCE_MAX_AGE).ToInt();
            GSMaximumtargetamount = _rulesService.GetValue(RulesService.Rules.GS_MAXIMUM_TARGET_AMOUNT).ToDouble();
            GSMinimumtargetamount = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_TARGET_AMOUNT).ToDouble();
            GSMaximuminsuredamount = _rulesService.GetValue(RulesService.Rules.GS_MAXIMUM_INSURED_AMOUNT).ToDouble();
            GSMinimuminsuredamount = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_INSURED_AMOUNT).ToDouble();
            GSMaximumpremiumamount = _rulesService.GetValue(RulesService.Rules.GS_MAXIMUM_PREMIUM_AMOUNT).ToDouble();
            GSMinimumpremiumamount = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_PREMIUM_AMOUNT).ToDouble();
            Minimumpremiumamount = _rulesService.GetValue(RulesService.Rules.MINIMUM_YEARLY_PREMIUM).ToDouble();
            Minimuminsuredamount = _rulesService.GetValue(RulesService.Rules.MINIMUM_INSURED_AMT).ToDouble();
            Maximuminsuredamount = _rulesService.GetValue(RulesService.Rules.MAXIMUM_INSURED_AMT).ToDouble();
            Targetoverage = _rulesService.GetValue(RulesService.Rules.TARGET_OVERAGE).ToDouble();
            Targetaddldiscount = _rulesService.GetValue(RulesService.Rules.TARGET_ADDL_DISCOUNT).ToDouble();
            Premiumreserve = _rulesService.GetValue(RulesService.Rules.PREMIUM_RESERVE).ToDouble();
            Targetcontributionperiod = _rulesService.GetValue(RulesService.Rules.TARGET_CONTRIBUTION_PERIOD).ToInt();
            Monthlyfeevalue = _rulesService.GetValue(RulesService.Rules.MONTHLY_FEE).ToDouble();
            Monthlyfeevalueyear = this.Monthlyfeevalue * 12;
            Loadchargepercent = _rulesService.GetValue(RulesService.Rules.LOAD_CHARGE).ToDouble();
            GSMinimumcontributionperiod = _rulesService.GetValue(RulesService.Rules.GS_MINIMUM_CONTRIBUTION_PERIOD).ToInt();
            Maxage = _rulesService.GetValue(RulesService.Rules.MAX_AGE).ToInt();
            Minimumpremiumtotargetfactor = _rulesService.GetValue(RulesService.Rules.MINIMUM_PREMIUM_TO_TARGET_FACTOR).ToDouble();
            Targetdiscountfactor = _rulesService.GetValue(RulesService.Rules.TARGET_DISCOUNT_FACTOR).ToDouble();
            Rideradbmaxage = _rulesService.GetValue(RulesService.Rules.ADB_MAX_AGE).ToInt();
            Rideradbfactor = _rulesService.GetValue(RulesService.Rules.ADB_FACTOR).ToDouble();

            insuranceunderage = _rulesService.GetValue(RulesService.Rules.INSURANCE_UNDERAGE).ToInt();
            insuranceunderageinsuredamount = _rulesService.GetValue(RulesService.Rules.MAXIMUM_INSURED_AMT_UNDERAGE).ToDouble();

            surrendercharge = _rulesService.GetValue(RulesService.Rules.SURRENDER_CHARGE).ToDouble();
            partialsurrendercharge = _rulesService.GetValue(RulesService.Rules.PARTIAL_SURRENDER_CHARGE).ToDouble();
            surrenderexcesspenalty = _rulesService.GetValue(RulesService.Rules.SURRENDER_EXCESS_PERCENT).ToDouble();

            Maxageforninguna = _rulesService.GetValue(RulesService.Rules.MAX_AGE_FOR_NINGUNA).ToInt();

            this.TargetNingunaPercent = _rulesService.GetValue(RulesService.Rules.TARGET_NINGUNA_PERCENT).ToDouble();
            this.LoanInterestRate = _rulesService.GetValue(RulesService.Rules.LOAN_INTEREST_RATE).ToDouble();
            this.LoanPrincipalGrowthRate = _rulesService.GetValue(RulesService.Rules.LOAN_PRINCIPAL_GROWTH_RATE).ToDouble();
            this.LoanPrincipalGrowInvestRate = _rulesService.GetValue(RulesService.Rules.LOAN_PRINCIPAL_GROW_INVEST_RATE).ToBoolean();

            this.InterestLoanRate = _rulesService.GetValue(RulesService.Rules.INTEREST_LOAN_RATE).ToDouble();
            this.LoanAssetRate = _rulesService.GetValue(RulesService.Rules.LOAN_ASSET_RATE).ToDouble();
            this.IsLoanRate = _rulesService.GetValue(RulesService.Rules.IS_LOAN_RATE).ToBoolean();
        }



        public double Commissionamount(double premiumamount, double targetamount, int sno)
        {
            double commissionamount = 0.0;
            double excesscommissionamount = 0.0;

            commissionamount = targetamount * this.commissiondata[sno + this.currentyeardifference - 1].commissionpercent;


            if (sno == 1 && this.initialcontributioncode == 'Y')
            {
                //excesscommissionamount = ((premiumamount+this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - targetamount) * this.commissiondata[sno - 1].excesscommissionpercent;
                if (this.financialgoalcode == 'N')
                {
                    excesscommissionamount = ((premiumamount + this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - targetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
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
                commissionamount = targetamount * this.commissiondata[sno - 1].commissionpercent;
            }
            else
            {
                commissionamount = 0;
            }
            return commissionamount;
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
                netinsuredamount = insuredamount - Math.Max(accountvalue, 0);
            }
            else
            {
                netinsuredamount = insuredamount;
            }
            double mortality = ((this.mortalitydata[sno - 1].mortalityvalue) * (1 + this.Targetoverage) + this.countryrisk * .75);
            return ((netinsuredamount > 0) ? netinsuredamount : 0) * (1 / 1000.0) * mortality;
        }

        public double Costofinsuranceoverage(double insuredamount, double accountvalue, int sno)
        {
            double netinsuredamount = 0.0;// insuredamount;           
            if (this.plantypecode == Plantypes.FIXED)
            {
                netinsuredamount = insuredamount - Math.Max(accountvalue, 0);
            }
            else
            {
                netinsuredamount = insuredamount;
            }
            double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.Targetoverage) * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
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
            if ((this.rideroircode == 'Y') && (this.oiruntilage >= (sno - 1 + this.oirage)))
            {
                double netinsuredamount = 0.0;// insuredamount;                       
                netinsuredamount = insuredamount - Math.Max(accountvalue, 0);
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
            double mortality = (this.mortalitydata[sno - 1].mortalityvalue * (1 + this.activityrisktypevalue) + this.healthrisktypevalue + this.countryrisk);
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
                currentinsuredamount = varinsuredamount[sno - 1];
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
                    netinsuredamount = currentinsuredamount - Math.Max(accountvalue, 0);
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
            if (this.numberofyears >= sno)
            {
                commissionamount = this.calctargetamount * this.commissiondata[sno + this.currentyeardifference - 1].commissionpercent;
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
                        excesscommissionamount = (((apremiumamount - (rideradbcost + rideracdbcost + ridertermcost + ridercicost + rideroircost)) + this.initialcontributionamount) * (1 / (1 + this.Premiumreserve)) - this.calctargetamount) * this.commissiondata[sno + this.currentyeardifference - 1].excesscommissionpercent;
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
            return commissionamount + ((excesscommissionamount > 0) ? excesscommissionamount : 0) + ridercommission;
        }

        public double Commissionamountillustrationriders(double ridercost, int sno)
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

        public double calculatePeriodicPremiumAmount()
        {
            if (calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
            {
                annualizedpremiumamount = premiumcost + rideradbcost + ridertermcost + rideracdbcost + rideroircost;
                double netperiodicrate = Math.Pow((1 + growthrate), 1.0 / frequencytypevalue) - 1;
                return calculatePMT(annualizedpremiumamount, frequencytypevalue, netperiodicrate) * (1.0 + frequencytypepenalty);
            }
            else
                return this.periodicpremiumamount;
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

        public double getPremiumamountillustration(int sno)
        {
            if (varpremiumcode == 'N')
            {
                if (this.numberofyears >= sno)
                {
                    if (sno == 1 && this.initialcontributioncode == 'Y')
                    {
                        return (this.calculatePeriodicPremiumAmount() * this.frequencytypevalue) + this.initialcontributionamount;
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
                if (this.numberofyears >= sno)
                {
                    if (sno == 1)
                    {
                        return varpremiumamount[sno - 1] * this.frequencytypevalue + this.initialcontributionamount;
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
            if (asdata.targetamount > (asdata.targetamount * (1 + this.Premiumreserve - this.Targetdiscountfactor)))
            {
                if (asdata.targetamount < projectedyearlyamount)
                {
                    return asdata.targetamount * (1 - Targetaddldiscount);
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

                    if (sno <= varpremiumamount.Length)
                    {
                        double actualpremium = calculatepv(periodicgrowthrate, this.frequencytypevalue, varpremiumamount[sno - 1] / (1 + frequencytypepenalty)); ;
                        return actualpremium - (this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
                    }
                    else
                    {
                        double actualpremium = 0;
                        return actualpremium;// -(this.rideradbcost + this.ridertermcost + this.rideracdbcost + this.ridercicost + this.rideroircost);
                    }
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
            if (varinsuredcode == 'N')
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
            set { this.calcinsuredamount = value; }
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
            if (varloancode == 'N')
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
                        totpremium = totpremium + varpremiumamount[i] * this.frequencytypevalue;
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
                return (rideradbcost + ridercicost + rideroircost + ridertermcost + rideracdbcost);
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
                double rate1 = Productinvprofile.getCompareprofilerate1(this.investmentprofilecode, this.productcode, classcode);
                return (rate1 * 100).ToString() + " %";
            }
        }

        public String comprate2
        {
            get
            {
                double rate2 = Productinvprofile.getCompareprofilerate2(this.investmentprofilecode, this.productcode, classcode);
                return (rate2 * 100).ToString() + " %";
            }
        }



        public String comprate3
        {
            get
            {
                if (varinvestprofilecode == 'N')
                {
                    double rate3 = Productinvprofile.getInvprofilerate(this.investmentprofilecode, this.productcode, classcode);
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
                        accountvalue = accountvalue - partialsurrenderamount;// -(sno <= 18 ? this.surrendercharge : 0);
                        //accountvalue = accountvalue - partialsurrenderamount - this.surrendercharge;
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
                        //accountvaluecomp1 = accountvaluecomp1 - partialsurrenderamount - (sno <= 18 ? this.surrendercharge : 0);
                        accountvaluecomp1 = accountvaluecomp1 - partialsurrenderamount;// -(sno <= 18 ? this.surrendercharge : 0);
                        //accountvaluecomp1 = accountvaluecomp1 - partialsurrenderamount - this.surrendercharge;
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
                        //accountvaluecomp2 = accountvaluecomp2 - partialsurrenderamount - (sno <= 18 ? this.surrendercharge : 0);
                        accountvaluecomp2 = accountvaluecomp2 - partialsurrenderamount; // -(sno <= 18 ? this.surrendercharge : 0);
                        //accountvaluecomp2 = accountvaluecomp2 - partialsurrenderamount - this.surrendercharge;
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
                return (accountvalue - penaltycharge) > 0 ? (accountvalue - penaltycharge) : 0;
                /*
                double penaltycharge = accountvalue * (this.Calctargetamount / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno)
                    + accountvalue * ((this.Calcaveragepremium - this.Calctargetamount) / this.Calcaveragepremium) * this.getSurrenderpenaltypercent(sno) * this.surrenderexcesspenalty + this.surrendercharge;
                return (accountvalue - penaltycharge) > 0 ? (accountvalue - penaltycharge) : 0;        
                 */
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
            double targetamt = -1.0 * Financial.Pmt(growthrt, this.Targetcontributionperiod, npvvalue, 0, Microsoft.VisualBasic.DueDate.BegOfPeriod);
            return targetamt * this.TargetNingunaPercent * (1.0 / (1.0 + this.Premiumreserve - .05));
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
                return (this.ridertermamount / 1000) * 2;
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
        public double RiderPrecision
        {
            get
            {
                return .004;
            }
        }

    }
}