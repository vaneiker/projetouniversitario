using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models.blinsurance;

namespace WSVirtualOffice.Models.blinsurance
{
    
    public class IAccountvalue
    {
        public enum AVCALCULATETYPES{
            INSUREDAMOUNT=1,
            PREMIUMAMOUNT=2,
            VERIFY=3,
            TARGETAMOUNT=4,
            MINIMUMPREMIUM=5,
            VARPLANINFO=6,
            ILLUSTRATION=7,
            RIDERADB=8,
            RIDERACDB=9,
            RIDERTERM=10,
            RIDERCI=11,
            RIDEROIR=12

        }
        private static int numexecutiontimes = 0;

        public static IResultData calculateInsuredamount(IMainInsuranceData insmaindata, IAssumeddata asdata)
        {            
            IResultData resdata1=new IResultData();
            IResultData resdata = null;            
            
            if (insmaindata.rideradbcode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxadbcost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_ADB_COST, insmaindata.productcode, insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERADB, 0, gsmaxadbcost, resdata1,0,gsmaxadbcost);
                asdata.rideradbcost = resdata.rideradbcost;
                insmaindata.rideradbcost = asdata.rideradbcost;
                //insmaindata.
            }
            if (insmaindata.ridertermcode== 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxtermcost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_TERM_COST, insmaindata.productcode, insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM, 0, gsmaxtermcost, resdata1,0,gsmaxtermcost);
                //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM,2698, 2700, resdata1);
                asdata.ridertermcost= resdata.ridertermcost;
                insmaindata.ridertermcost = asdata.ridertermcost;
            }
            if (insmaindata.rideroircode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxoircost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_OIR_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDEROIR, 0, gsmaxoircost, resdata1,0,gsmaxoircost);
                asdata.rideroircost = resdata.rideroircost;
                insmaindata.rideroircost = asdata.rideroircost;
            }
            numexecutiontimes = 0;
            resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.INSUREDAMOUNT, insmaindata.GSMinimuminsuredamount, insmaindata.GSMaximuminsuredamount, resdata1,insmaindata.GSMinimuminsuredamount,insmaindata.GSMaximuminsuredamount);
            //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.INSUREDAMOUNT, 110963, 110963, resdata1, insmaindata.GSMinimuminsuredamount, insmaindata.GSMaximuminsuredamount);            
            //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.INSUREDAMOUNT, 4262958, 4262958, resdata1);            
            //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.INSUREDAMOUNT, 83480, 83490, resdata1);            
            if (resdata.impossible == true)
            {
                return resdata;
            }

            if (insmaindata.isOpeningbalance == false)
            {
                if ((insmaindata.age <= insmaindata.insuranceunderage) && (resdata.insuredamount > insmaindata.insuranceunderageinsuredamount))
                {
                    asdata.insuredamount = insmaindata.insuranceunderageinsuredamount;
                    insmaindata.Calcinsuredamount = insmaindata.insuranceunderageinsuredamount;
                    insmaindata.insuredamount = insmaindata.Calcinsuredamount;
                    numexecutiontimes = 0;
                    //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    //asdata.targetamount = insmaindata.calculateTargetforniguna();
                    asdata.calculatenow = 'V';
                    resdata1.targetamount = asdata.targetamount;
                    resdata.targetamount = asdata.targetamount;
                    insmaindata.Calctargetamount = asdata.targetamount;
                    double midaccountvalue = calculateAccountvalue(insmaindata, asdata, AVCALCULATETYPES.VERIFY);



                    if (midaccountvalue < (0 - insmaindata.Precision))
                    {
                        resdata.impossible = true;
                        //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.MINIMUMPREMIUM, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1);
                    }



                    if (insmaindata.varpremiumcode == 'Y')
                    {
                        IAssumeddata tempasdata = new IAssumeddata();
                        tempasdata.calculatenow = asdata.calculatenow;
                        tempasdata.insuredamount = asdata.insuredamount;
                        tempasdata.minimumpremium = asdata.minimumpremium;
                        tempasdata.premiumamount = asdata.premiumamount;
                        tempasdata.rideracdbcost = asdata.rideracdbcost;
                        tempasdata.rideradbcost = asdata.rideradbcost;
                        tempasdata.ridercicost = asdata.ridercicost;
                        tempasdata.rideroircost = asdata.rideroircost;
                        tempasdata.ridertermcost = asdata.ridertermcost;
                        tempasdata.targetamount = asdata.targetamount;
                        tempasdata.useassumedinsurance = asdata.useassumedinsurance;
                        // asdata.targetamountvariable = calculateTargetamountvariable(insmaindata, tempasdata);
                        resdata = goalseekningunatarget(insmaindata, tempasdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                        insmaindata.targetamountvariable = asdata.targetamountvariable;
                        resdata.targetamountvariable = asdata.targetamountvariable;

                        if (asdata.targetamount > asdata.targetamountvariable)
                        {
                            asdata.targetamount = asdata.targetamountvariable;
                            resdata.targetamount = asdata.targetamountvariable;
                            insmaindata.Calctargetamount = asdata.targetamountvariable;
                        }

                    }


                }
                else
                {
                    insmaindata.Calctargetamount = resdata.targetamount;
                    insmaindata.Calcinsuredamount = resdata.insuredamount;
                    asdata.targetamount = resdata.targetamount;
                    asdata.insuredamount = resdata.insuredamount;

                    if (insmaindata.varpremiumcode == 'Y')
                    {
                        IAssumeddata tempasdata = new IAssumeddata();
                        tempasdata.calculatenow = asdata.calculatenow;
                        tempasdata.insuredamount = asdata.insuredamount;
                        tempasdata.minimumpremium = asdata.minimumpremium;
                        tempasdata.premiumamount = asdata.premiumamount;
                        tempasdata.rideracdbcost = asdata.rideracdbcost;
                        tempasdata.rideradbcost = asdata.rideradbcost;
                        tempasdata.ridercicost = asdata.ridercicost;
                        tempasdata.rideroircost = asdata.rideroircost;
                        tempasdata.ridertermcost = asdata.ridertermcost;
                        tempasdata.targetamount = asdata.targetamount;
                        tempasdata.useassumedinsurance = asdata.useassumedinsurance;
                        asdata.targetamountvariable = calculateTargetamountvariable(insmaindata, tempasdata);
                        insmaindata.targetamountvariable = asdata.targetamountvariable;
                        resdata.targetamountvariable = asdata.targetamountvariable;

                        if (asdata.targetamount > asdata.targetamountvariable)
                        {
                            asdata.targetamount = asdata.targetamountvariable;
                            resdata.targetamount = asdata.targetamountvariable;
                            insmaindata.Calctargetamount = asdata.targetamountvariable;
                        }
                        else
                        {
                            asdata.targetamount = asdata.targetamount;
                            resdata.targetamount = asdata.targetamount;
                            insmaindata.Calctargetamount = asdata.targetamount;
                        }

                    }

                }
            }
            else
            {


                //  the opening balance is true

                if ((insmaindata.age <= insmaindata.insuranceunderage) && (resdata.insuredamount > insmaindata.insuranceunderageinsuredamount))
                {
                    asdata.insuredamount = insmaindata.insuranceunderageinsuredamount;
                    insmaindata.Calcinsuredamount = insmaindata.insuranceunderageinsuredamount;
                    insmaindata.insuredamount = insmaindata.Calcinsuredamount;
                    numexecutiontimes = 0;
                    //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    //asdata.targetamount = insmaindata.calculateTargetforniguna();
                    asdata.targetamount = insmaindata.Calctargetamount;
                    asdata.calculatenow = 'V';
                    resdata1.targetamount = asdata.targetamount;
                    resdata.targetamount = asdata.targetamount;
                    //insmaindata.Calctargetamount = asdata.targetamount;
                    double midaccountvalue = calculateAccountvalue(insmaindata, asdata, AVCALCULATETYPES.VERIFY);

                    if (midaccountvalue < (0 - insmaindata.Precision))
                    {
                        resdata.impossible = true;
                        //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.MINIMUMPREMIUM, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1);
                    }



                    if (insmaindata.varpremiumcode == 'Y')
                    {
                        IAssumeddata tempasdata = new IAssumeddata();
                        tempasdata.calculatenow = asdata.calculatenow;
                        tempasdata.insuredamount = asdata.insuredamount;
                        tempasdata.minimumpremium = asdata.minimumpremium;
                        tempasdata.premiumamount = asdata.premiumamount;
                        tempasdata.rideracdbcost = asdata.rideracdbcost;
                        tempasdata.rideradbcost = asdata.rideradbcost;
                        tempasdata.ridercicost = asdata.ridercicost;
                        tempasdata.rideroircost = asdata.rideroircost;
                        tempasdata.ridertermcost = asdata.ridertermcost;
                        tempasdata.targetamount = asdata.targetamount;
                        tempasdata.useassumedinsurance = asdata.useassumedinsurance;
                        // asdata.targetamountvariable = calculateTargetamountvariable(insmaindata, tempasdata);
                        //resdata = goalseekningunatarget(insmaindata, tempasdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                        insmaindata.targetamountvariable = insmaindata.Calctargetamount;
                        resdata.targetamountvariable = insmaindata.Calctargetamount;


                    }


                }
                else
                {
                    //insmaindata.Calctargetamount = resdata.targetamount;
                    insmaindata.Calcinsuredamount = resdata.insuredamount;
                    asdata.targetamount = insmaindata.Calctargetamount;
                    asdata.insuredamount = resdata.insuredamount;

                    if (insmaindata.varpremiumcode == 'Y')
                    {
                        IAssumeddata tempasdata = new IAssumeddata();
                        tempasdata.calculatenow = asdata.calculatenow;
                        tempasdata.insuredamount = asdata.insuredamount;
                        tempasdata.minimumpremium = asdata.minimumpremium;
                        tempasdata.premiumamount = asdata.premiumamount;
                        tempasdata.rideracdbcost = asdata.rideracdbcost;
                        tempasdata.rideradbcost = asdata.rideradbcost;
                        tempasdata.ridercicost = asdata.ridercicost;
                        tempasdata.rideroircost = asdata.rideroircost;
                        tempasdata.ridertermcost = asdata.ridertermcost;
                        tempasdata.targetamount = asdata.targetamount;
                        tempasdata.useassumedinsurance = asdata.useassumedinsurance;
                        //asdata.targetamountvariable = calculateTargetamountvariable(insmaindata, tempasdata);
                        //insmaindata.targetamountvariable = asdata.targetamountvariable;
                        //resdata.targetamountvariable = asdata.targetamountvariable;

                    }

                }

            }
            if (insmaindata.isOpeningbalance == false)
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.MINIMUMPREMIUM, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount);
                insmaindata.Calcminimumpremium = resdata.minimumpremium;
            }
            else
            {
                resdata.minimumpremium = insmaindata.Calcminimumpremium;
            }
            return resdata;
        }



        public static double calculateTargetamountvariable(IMainInsuranceData insmaindata, IAssumeddata asdata)
        {
            IResultData resdata1 = new IResultData();
            IResultData resdata = null;            
            numexecutiontimes = 0;
            insmaindata.fortargetcalculation = 'Y';
            resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.INSUREDAMOUNT, insmaindata.GSMinimuminsuredamount, insmaindata.GSMaximuminsuredamount, resdata1, insmaindata.GSMinimuminsuredamount, insmaindata.GSMaximuminsuredamount);
            insmaindata.fortargetcalculation = 'N';
            if (resdata.impossible == true)
            {
                return 0;
            }
            else
            {
                return resdata.targetamount;
            }            
        }





        public static IResultData calculatePremiumamount(IMainInsuranceData insmaindata, IAssumeddata asdata)
        {
            IResultData resdata1 = new IResultData();
            IResultData resdata = null;
            /*
            if (insmaindata.rideradbcode == 'Y')
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERADB, 0, 100000, resdata1);
                asdata.rideradbcost = resdata.rideradbcost;
                insmaindata.rideradbcost = asdata.rideradbcost;
            }
            if (insmaindata.ridertermcode == 'Y')
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM, 0, 100000, resdata1);
                asdata.ridertermcost = resdata.ridertermcost;
                insmaindata.ridertermcost = asdata.ridertermcost;
            }
            if (insmaindata.rideroircode == 'Y')
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDEROIR, 0, 100000, resdata1);
                asdata.rideroircost = resdata.rideroircost;
                insmaindata.rideroircost = asdata.rideroircost;
            }
             */
            if (insmaindata.rideradbcode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxadbcost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_ADB_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERADB, 0, gsmaxadbcost, resdata1, 0, gsmaxadbcost);
                asdata.rideradbcost = resdata.rideradbcost;
                insmaindata.rideradbcost = asdata.rideradbcost;
                //insmaindata.
            }
            if (insmaindata.ridertermcode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxtermcost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_TERM_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM, 0, gsmaxtermcost, resdata1, 0, gsmaxtermcost);
                //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM, 83.86, 83.86, resdata1, 0, gsmaxtermcost);
                //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM,2698, 2700, resdata1);
                asdata.ridertermcost = resdata.ridertermcost;
                insmaindata.ridertermcost = asdata.ridertermcost;
            }
            if (insmaindata.rideroircode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxoircost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_OIR_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDEROIR, 0, gsmaxoircost, resdata1, 0, gsmaxoircost);
                asdata.rideroircost = resdata.rideroircost;
                insmaindata.rideroircost = asdata.rideroircost;
            }

            if (insmaindata.isOpeningbalance == false)
            {
                numexecutiontimes = 0;
                //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, 781.52, 781.52, resdata1, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata1, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                
                insmaindata.Calctargetamount = resdata.targetamount;
                asdata.targetamount = resdata.targetamount;
                resdata1.targetamount = resdata.targetamount;
            }
            else
            {
                asdata.targetamount = insmaindata.Calctargetamount;
                resdata1.targetamount = insmaindata.Calctargetamount;
            }

            resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.PREMIUMAMOUNT, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1,insmaindata.GSMinimumpremiumamount,insmaindata.GSMaximumpremiumamount);            
            if (resdata.impossible == true)
            {
                return resdata;

            }
            insmaindata.Calcyearlypremium = resdata.premiumamount+asdata.rideracdbcost+asdata.rideradbcost+asdata.ridertermcost+asdata.rideroircost;
            asdata.premiumamount = resdata.premiumamount+asdata.rideracdbcost + asdata.rideradbcost + asdata.ridertermcost + asdata.rideroircost;
            insmaindata.premiumcost = resdata.premiumamount;
            if (insmaindata.isOpeningbalance == false)
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.MINIMUMPREMIUM, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount);
            }
            else
            {
                asdata.minimumpremium = insmaindata.Calcminimumpremium;
            }
            return resdata;
        }

        public static IResultData calculateNinguna(IMainInsuranceData insmaindata, IAssumeddata asdata)
        {
            IResultData resdata1 = new IResultData();
            IResultData resdata = new IResultData();
            //IResultData resdata1 = new IResultData();
            /*
            if (insmaindata.rideradbcode == 'Y')
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERADB, 0, 100000, resdata1);
                asdata.rideradbcost = resdata.rideradbcost;
                insmaindata.rideradbcost = asdata.rideradbcost;
            }
            if (insmaindata.ridertermcode == 'Y')
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM, 0, 100000, resdata1);
                asdata.ridertermcost = resdata.ridertermcost;
                insmaindata.ridertermcost = asdata.ridertermcost;
            }
            if (insmaindata.rideroircode == 'Y')
            {
                numexecutiontimes = 0;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDEROIR, 0, 100000, resdata1);
                asdata.rideroircost = resdata.rideroircost;
                insmaindata.rideroircost = asdata.rideroircost;
            }
             */

            if (insmaindata.rideradbcode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxadbcost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_ADB_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERADB, 0, gsmaxadbcost, resdata1, 0, gsmaxadbcost);
                asdata.rideradbcost = resdata.rideradbcost;
                insmaindata.rideradbcost = asdata.rideradbcost;
                //insmaindata.
            }
            if (insmaindata.ridertermcode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxtermcost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_TERM_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM, 0, gsmaxtermcost, resdata1, 0, gsmaxtermcost);
                //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDERTERM,2698, 2700, resdata1);
                asdata.ridertermcost = resdata.ridertermcost;
                insmaindata.ridertermcost = asdata.ridertermcost;
            }
            if (insmaindata.rideroircode == 'Y')
            {
                numexecutiontimes = 0;
                double gsmaxoircost = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_OIR_COST, insmaindata.productcode,insmaindata.classcode);
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.RIDEROIR, 0, gsmaxoircost, resdata1, 0, gsmaxoircost);
                asdata.rideroircost = resdata.rideroircost;
                insmaindata.rideroircost = asdata.rideroircost;
            }

            // calculate insuredamount with the current premium
            //double tempinsuredamount = asdata.insuredamount;            
            //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.INSUREDAMOUNT, insmaindata.GSMinimuminsuredamount, insmaindata.GSMaximuminsuredamount, resdata1);
            //double actualtargetamount = resdata.targetamount;
            //double actualinsuredamount = resdata.insuredamount;            
            //double maxpossibleinsuredamount = 0.0;
            //asdata.insuredamount = tempinsuredamount;
            /*
            if (actualinsuredamount < tempinsuredamount)
            {
                asdata.useassumedinsurance = false;
                resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata1);
                //IResultData resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, 0, 5700.68, resdata1);
                asdata.targetamount = resdata.targetamount;
                resdata1.targetamount = resdata.targetamount;
            }
            else
            {
                asdata.targetamount = resdata.targetamount;
                resdata1.targetamount = resdata.targetamount;
            }*/
            //resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.PREMIUMAMOUNT, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1);
            if (insmaindata.isOpeningbalance == false)
            {
                numexecutiontimes = 0;
                asdata.useassumedinsurance = false;
                resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, 4109, 4109, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, 1844.42, 1844.42, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                //asdata.targetamount = insmaindata.calculateTargetforniguna();
                if (resdata.impossible == true)
                {
                    return resdata;
                }
                asdata.calculatenow = 'V';
                resdata1.targetamount = asdata.targetamount;
                resdata.targetamount = asdata.targetamount;
                insmaindata.Calctargetamount = asdata.targetamount;


                if (insmaindata.varpremiumcode == 'Y')
                {
                    numexecutiontimes = 0;
                    IAssumeddata tempasdata = new IAssumeddata();
                    tempasdata.calculatenow = asdata.calculatenow;
                    tempasdata.insuredamount = asdata.insuredamount;
                    tempasdata.minimumpremium = asdata.minimumpremium;
                    tempasdata.premiumamount = asdata.premiumamount;
                    tempasdata.rideracdbcost = asdata.rideracdbcost;
                    tempasdata.rideradbcost = asdata.rideradbcost;
                    tempasdata.ridercicost = asdata.ridercicost;
                    tempasdata.rideroircost = asdata.rideroircost;
                    tempasdata.ridertermcost = asdata.ridertermcost;
                    tempasdata.targetamount = asdata.targetamount;
                    tempasdata.useassumedinsurance = asdata.useassumedinsurance;
                    insmaindata.fortargetcalculation = 'Y';
                    //IResultData resdata3 = goalseekningunatarget(insmaindata, tempasdata, AVCALCULATETYPES.TARGETAMOUNT, 1844.42, 1844.42, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    IResultData resdata3 = goalseekningunatarget(insmaindata, tempasdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    insmaindata.fortargetcalculation = 'N';
                    //asdata.targetamountvariable = calculateTargetamountvariable(insmaindata, tempasdata);
                    insmaindata.targetamountvariable = tempasdata.targetamount;
                    resdata3.targetamountvariable = tempasdata.targetamount;
                    asdata.targetamountvariable = tempasdata.targetamount;
                    if (asdata.targetamount > asdata.targetamountvariable)
                    {
                        asdata.targetamount = asdata.targetamountvariable;
                        resdata.targetamount = asdata.targetamountvariable;
                        insmaindata.Calctargetamount = asdata.targetamountvariable;
                    }
                    else
                    {
                        asdata.targetamount = asdata.targetamount;
                        resdata.targetamount = asdata.targetamount;
                        insmaindata.Calctargetamount = asdata.targetamount;
                    }

                }


            }
            else
            {
                // opening balance is true

                numexecutiontimes = 0;
                //asdata.useassumedinsurance = false;
                //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, 4109, 4109, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                //resdata = goalseekningunatarget(insmaindata, asdata, AVCALCULATETYPES.TARGETAMOUNT, 1844.42, 1844.42, resdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                //asdata.targetamount = insmaindata.calculateTargetforniguna();
                
                asdata.calculatenow = 'V';
                asdata.targetamount = insmaindata.Calctargetamount;
                resdata1.targetamount = insmaindata.Calctargetamount;
                resdata.targetamount = asdata.targetamount;
                insmaindata.Calctargetamount = asdata.targetamount;
                
                if (insmaindata.varpremiumcode == 'Y')
                {
                    numexecutiontimes = 0;
                    IAssumeddata tempasdata = new IAssumeddata();
                    tempasdata.calculatenow = asdata.calculatenow;
                    tempasdata.insuredamount = asdata.insuredamount;
                    tempasdata.minimumpremium = asdata.minimumpremium;
                    tempasdata.premiumamount = asdata.premiumamount;
                    tempasdata.rideracdbcost = asdata.rideracdbcost;
                    tempasdata.rideradbcost = asdata.rideradbcost;
                    tempasdata.ridercicost = asdata.ridercicost;
                    tempasdata.rideroircost = asdata.rideroircost;
                    tempasdata.ridertermcost = asdata.ridertermcost;
                    tempasdata.targetamount = asdata.targetamount;
                    tempasdata.useassumedinsurance = asdata.useassumedinsurance;
                    
                    
                }
                asdata.targetamount = insmaindata.Calctargetamount;
                resdata1.targetamount = insmaindata.Calctargetamount;




            }

            double midaccountvalue = calculateAccountvalue(insmaindata, asdata, AVCALCULATETYPES.VERIFY);


            if (insmaindata.isOpeningbalance == false)
            {
                if (midaccountvalue > (0 - insmaindata.Precision))
                {
                    numexecutiontimes = 0;
                    resdata = goalseek(insmaindata, asdata, AVCALCULATETYPES.MINIMUMPREMIUM, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount, resdata1, insmaindata.GSMinimumpremiumamount, insmaindata.GSMaximumpremiumamount);
                }
                else
                {
                    resdata.impossible = true;
                }
            }
            else
            {
                resdata1.minimumpremium = insmaindata.Calcminimumpremium;
                asdata.minimumpremium = insmaindata.Calcminimumpremium;
                resdata.minimumpremium = insmaindata.Calcminimumpremium;
            }            


            return resdata;
        }



        public static IResultData goalseek (IMainInsuranceData insmaindata, IAssumeddata asdata, AVCALCULATETYPES tocalculate,double minamount,double maxamount,IResultData resultdata,double goalminamount,double goalmaxamount)
        {           
            double midamount = (maxamount + minamount) / 2.0;            
            if(tocalculate==AVCALCULATETYPES.INSUREDAMOUNT )
            {
                asdata.insuredamount=midamount;
                if (insmaindata.isOpeningbalance == false)
                {
                    IAssumeddata tempassumedata = new IAssumeddata();
                    tempassumedata.insuredamount = midamount;
                    tempassumedata.premiumamount = asdata.premiumamount;
                    tempassumedata.targetamount = asdata.targetamount;
                    AVCALCULATETYPES temptocalculate = AVCALCULATETYPES.TARGETAMOUNT;
                    numexecutiontimes = 0;
                    IResultData tempresultdata = goalseek(insmaindata, tempassumedata, temptocalculate, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount, resultdata, insmaindata.GSMinimumtargetamount, insmaindata.GSMaximumtargetamount);
                    //IResultData tempresultdata = goalseek(insmaindata, tempassumedata, temptocalculate, 2280, 2290, resultdata);
                    asdata.targetamount = tempresultdata.targetamount;
                }
                else
                {
                    asdata.targetamount = insmaindata.Calctargetamount;
                }
            }
            /*
            else if ((tocalculate == AVCALCULATETYPES.TARGETAMOUNT)&&(insmaindata.calculatetypecode=='V')&&(insmaindata.financialgoalcode=='N'))
            {
                asdata.targetamount = midamount;
                asdata.calculatenow = 'T';
                asdata.targetaccountvalue = calculateAccountvalue(insmaindata, asdata, AVCALCULATETYPES.VERIFY);
            }*/
            else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
            {
                asdata.premiumamount = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
            {
                asdata.targetamount = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
            {
                asdata.minimumpremium = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERADB)
            {
                asdata.rideradbcost = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERACDB)
            {
                asdata.rideracdbcost = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERTERM)
            {
                asdata.ridertermcost = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERCI)
            {
                asdata.ridercicost = midamount;
            }
            else if (tocalculate == AVCALCULATETYPES.RIDEROIR)
            {
                asdata.rideroircost = midamount;
            }
            double midaccountvalue=calculateAccountvalue(insmaindata, asdata, tocalculate);

            if ((Math.Abs(maxamount - minamount) <= .009))
            {
                if (Math.Abs(midamount - goalmaxamount) <= 1 || Math.Abs(midamount - goalminamount) <= 1)
                {
                    resultdata.impossible = true;
                    return resultdata;
                }
                else
                {
                    if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                    {
                        resultdata.insuredamount = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
                    {
                        resultdata.premiumamount = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
                    {
                        resultdata.targetamount = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
                    {
                        resultdata.minimumpremium = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERADB)
                    {
                        resultdata.rideradbcost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERACDB)
                    {
                        resultdata.rideracdbcost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERTERM)
                    {
                        resultdata.ridertermcost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERCI)
                    {
                        resultdata.ridercicost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDEROIR)
                    {
                        resultdata.rideroircost = midamount;
                    }
                    return resultdata;                    
                }
            }

            //maindata =calculateAccountvalue(insmaindata, asdata, tocalculate,);
            //maindata.insuredamount = midinsuredamount;
            //double midaccountvalue = maindata.accountvalue;
            //if ((tocalculate == AVCALCULATETYPES.TARGETAMOUNT || tocalculate == AVCALCULATETYPES.INSUREDAMOUNT) && (asdata.insuredamount < insmaindata.Minimuminsuredamount))
            if ((tocalculate == AVCALCULATETYPES.INSUREDAMOUNT) && (asdata.insuredamount < insmaindata.Minimuminsuredamount))
            {
                //if (midaccountvalue < (insmaindata.Targetaccountvalue - insmaindata.Precision))
                //{
                  //  resultdata.impossible = true;
                   // return resultdata;
                //}
            }
            else if ((tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT) && (asdata.premiumamount < insmaindata.Minimumpremiumamountafterriders))
            {
                /*
                if (midaccountvalue > (insmaindata.Targetaccountvalue - insmaindata.Precision))
                {
                    resultdata.impossible = true;
                    return resultdata;
                }
                 */ 
            }
            if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT || tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT || tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
            {
                if (midaccountvalue > (insmaindata.Targetaccountvalue - insmaindata.Precision) && midaccountvalue < (insmaindata.Targetaccountvalue + insmaindata.Precision))
                {
                    if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                    {
                        resultdata.insuredamount = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
                    {
                        resultdata.premiumamount = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
                    {
                        resultdata.targetamount = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
                    {
                        resultdata.minimumpremium = midamount;
                    }
                    return resultdata;
                }                                            
                else
                {

                    if ((numexecutiontimes > 150) && Math.Abs(maxamount - minamount) <= 1)
                    {
                        if (midaccountvalue > (insmaindata.Targetaccountvalue - insmaindata.getPrecision(tocalculate) * -1) && midaccountvalue < (insmaindata.Targetaccountvalue + insmaindata.getPrecision(tocalculate)))
                        {
                            if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                            {
                                resultdata.insuredamount = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
                            {
                                resultdata.premiumamount = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
                            {
                                resultdata.targetamount = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
                            {
                                resultdata.minimumpremium = midamount;
                            }
                            return resultdata;
                        }
                        else
                        {
                            if ((minamount != goalminamount) && (maxamount != goalmaxamount))
                            {
                                if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                                {
                                    resultdata.insuredamount = midamount;
                                }
                                else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
                                {
                                    resultdata.premiumamount = midamount;
                                }
                                else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
                                {
                                    resultdata.targetamount = midamount;
                                }
                                else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
                                {
                                    resultdata.minimumpremium = midamount;
                                }
                            }
                            else
                            {
                                resultdata.impossible = true;
                                return resultdata;
                            }
                        }
                    }
                    if (((maxamount - minamount) <= .001) && (midaccountvalue > (1000 + insmaindata.Targetaccountvalue)))
                    {
                        if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                        {
                            resultdata.insuredamount = midamount;
                        }
                        else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
                        {
                            resultdata.premiumamount = midamount;
                        }
                        else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
                        {
                            resultdata.targetamount = midamount;
                        }
                        else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
                        {
                            resultdata.minimumpremium = midamount;
                        }
                        return resultdata;
                    }
                    else if (midaccountvalue > (insmaindata.Precision + insmaindata.Targetaccountvalue))
                    {                                                
                        if ((tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT) || (tocalculate == AVCALCULATETYPES.TARGETAMOUNT) || (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM))
                        {
                            numexecutiontimes++;
                            return goalseek(insmaindata, asdata, tocalculate, minamount, midamount, resultdata,goalminamount,goalmaxamount);
                        }
                        else
                        {
                            numexecutiontimes++;
                            return goalseek(insmaindata, asdata, tocalculate, midamount, maxamount, resultdata, goalminamount, goalmaxamount);
                        }
                    }
                    
                    else
                    {                        
                        if ((tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT) || (tocalculate == AVCALCULATETYPES.TARGETAMOUNT) || (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM))
                        {
                            numexecutiontimes++;
                            return goalseek(insmaindata, asdata, tocalculate, midamount, maxamount, resultdata, goalminamount, goalmaxamount);
                        }
                        else
                        {
                            numexecutiontimes++;
                            return goalseek(insmaindata, asdata, tocalculate, minamount, midamount, resultdata, goalminamount, goalmaxamount);
                        }
                    }
                }
            }
            else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM )
            {
                if (midaccountvalue > (0- insmaindata.Precision) && midaccountvalue < (0 + insmaindata.Precision))
                {                    
                    resultdata.minimumpremium = midamount;                    
                    return resultdata;
                }
                else
                {
                    if (midaccountvalue > (insmaindata.Precision ))
                    {
                        numexecutiontimes++;
                        return goalseek(insmaindata, asdata, tocalculate, minamount, midamount, resultdata, goalminamount, goalmaxamount);                        
                    }
                    else
                    {
                        numexecutiontimes++;
                        return goalseek(insmaindata, asdata, tocalculate, midamount, maxamount, resultdata, goalminamount, goalmaxamount);                        
                    }
                }
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERADB || tocalculate == AVCALCULATETYPES.RIDERACDB || tocalculate == AVCALCULATETYPES.RIDERCI || tocalculate == AVCALCULATETYPES.RIDERTERM || tocalculate == AVCALCULATETYPES.RIDEROIR)
            {
                if (midaccountvalue > (-insmaindata.RiderPrecision) && midaccountvalue < (insmaindata.RiderPrecision))
                {
                    if (tocalculate == AVCALCULATETYPES.RIDERADB)
                    {
                        resultdata.rideradbcost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERACDB)
                    {
                        resultdata.rideracdbcost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERTERM)
                    {
                        resultdata.ridertermcost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDERCI)
                    {
                        resultdata.ridercicost = midamount;
                    }
                    else if (tocalculate == AVCALCULATETYPES.RIDEROIR)
                    {
                        resultdata.rideroircost = midamount;
                    }
                    return resultdata;

                }
                else
                {
                    if ((numexecutiontimes > 150) && Math.Abs(maxamount - minamount) <= 1)
                    {
                        if (midaccountvalue > (insmaindata.getPrecision(tocalculate) * -1) && midaccountvalue < (insmaindata.getPrecision(tocalculate)))
                        {
                            if (tocalculate == AVCALCULATETYPES.RIDERADB)
                            {
                                resultdata.rideradbcost = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.RIDERACDB)
                            {
                                resultdata.rideracdbcost = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.RIDERTERM)
                            {
                                resultdata.ridertermcost = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.RIDERCI)
                            {
                                resultdata.ridercicost = midamount;
                            }
                            else if (tocalculate == AVCALCULATETYPES.RIDEROIR)
                            {
                                resultdata.rideroircost = midamount;
                            }
                            return resultdata;
                        }
                        else
                        {
                            resultdata.impossible = true;
                            return resultdata;
                        }
                    }

                    if (midaccountvalue > (insmaindata.RiderPrecision ))
                    {
                        numexecutiontimes++;
                        return goalseek(insmaindata, asdata, tocalculate, minamount, midamount, resultdata, goalminamount, goalmaxamount);
                    }
                    else
                    {
                        numexecutiontimes++;
                        return goalseek(insmaindata, asdata, tocalculate, midamount, maxamount, resultdata, goalminamount, goalmaxamount);
                    }
                }


            }
            else
            {
                return resultdata;
            }
        }





        public static IResultData goalseekningunatarget(IMainInsuranceData insmaindata, IAssumeddata asdata, AVCALCULATETYPES tocalculate, double minamount, double maxamount, IResultData resultdata,double goalminamount,double goalmaxamount)
        {
            double midamount = (maxamount + minamount) / 2.0;


            if (Math.Abs(midamount - goalmaxamount) <= 1 || Math.Abs(midamount - goalminamount) <= 1)
            {
                if (numexecutiontimes > 150)
                {
                    resultdata.impossible = true;
                    return resultdata;
                }
            }
            else if (numexecutiontimes > 5 && Math.Abs(maxamount - minamount) <= .009)
            {
                asdata.targetamount = midamount;
                resultdata.targetamount = midamount;
                return resultdata;
            }

            asdata.targetamount = midamount;
            asdata.calculatenow = 'T';
            //asdata.targetamount = 2814.94;
            double targetaccountvalue = calculateAccountvalue(insmaindata, asdata, AVCALCULATETYPES.VERIFY);                        
            double midaccountvalue = calculateAccountvalue(insmaindata, asdata, tocalculate);
            //maindata =calculateAccountvalue(insmaindata, asdata, tocalculate,);
            //maindata.insuredamount = midinsuredamount;
            //double midaccountvalue = maindata.accountvalue;
            //if ((tocalculate == AVCALCULATETYPES.TARGETAMOUNT || tocalculate == AVCALCULATETYPES.INSUREDAMOUNT) && (asdata.insuredamount < insmaindata.Minimuminsuredamount))
            /*
            if ((tocalculate == AVCALCULATETYPES.INSUREDAMOUNT) && (asdata.insuredamount < insmaindata.Minimuminsuredamount))
            {
                if (midaccountvalue < (insmaindata.Targetaccountvalue - insmaindata.Precision))
                {
                    resultdata.impossible = true;
                    return resultdata;
                }
            }
             */

            if (midaccountvalue > (targetaccountvalue - insmaindata.Precision) && midaccountvalue < (targetaccountvalue + insmaindata.Precision))
            {
                if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                {
                    resultdata.targetamount = midamount;
                }
                return resultdata;
            }
            else
            {
                if ((numexecutiontimes > 150) && Math.Abs(maxamount - minamount) <= 1)
                {
                    if (midaccountvalue > (insmaindata.Targetaccountvalue - insmaindata.getPrecision(tocalculate) * -1) && midaccountvalue < (insmaindata.Targetaccountvalue + insmaindata.getPrecision(tocalculate)))
                    {
                        if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
                        {
                            resultdata.insuredamount = midamount;
                        }
                        else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
                        {
                            resultdata.premiumamount = midamount;
                        }
                        else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
                        {
                            resultdata.targetamount = midamount;
                        }
                        else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
                        {
                            resultdata.minimumpremium = midamount;
                        }
                        return resultdata;
                    }
                    else
                    {
                        resultdata.impossible = true;
                        return resultdata;
                    }
                }

                if (midaccountvalue > (insmaindata.Precision + targetaccountvalue))
                {
                    numexecutiontimes++;
                    return goalseekningunatarget(insmaindata, asdata, tocalculate, minamount, midamount, resultdata,goalminamount,goalmaxamount);                    
                }
                else
                {
                    numexecutiontimes++;
                    return goalseekningunatarget(insmaindata, asdata, tocalculate, midamount, maxamount, resultdata,goalminamount,goalmaxamount);                   
                }
            }
        }



        public static double calculateAccountvalue(IMainInsuranceData insmaindata, IAssumeddata asdata, AVCALCULATETYPES tocalculate)
        {
            double accountvalue = 0.0;


            double costofinsurance;
            double commissionamount;
            double loadcharge;
            double premiumamount;
            double premiumnoreserve = 0.0;
            int sno=0;

            int maxcalcperiod = insmaindata.Maxage;

            
            if (tocalculate != AVCALCULATETYPES.VERIFY)
            {
                if (insmaindata.financialgoalcode == 'Y')
                {
                    maxcalcperiod = insmaindata.financialgoalage;
                }
            }
            else
            {
                if (asdata.calculatenow == 'V')
                {
                    maxcalcperiod = insmaindata.Maxageforninguna;
                }                
                else
                {
                    maxcalcperiod = insmaindata.Maxage;
                }
            }
            


            if (tocalculate == AVCALCULATETYPES.VERIFY)
            {
                if (asdata.insuredamount >= 120000 && asdata.insuredamount <= 200000)
                {
                    int l1 = 1;
                }

                if (insmaindata.isOpeningbalance == true)
                {
                    accountvalue = insmaindata.openingbalanceamount;
                }


                for (int i = insmaindata.age; i <= maxcalcperiod; i++)
                {                       

                    sno = i - insmaindata.age + 1;
                    costofinsurance = insmaindata.Costofinsuranceoverage(insmaindata.getVarInsuredamount(sno), (accountvalue > 0 ? accountvalue : 0), sno);
                    //costofinsurance = insmaindata.Costofinsuranceoverage(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);
                    if (insmaindata.Contributionperiod >= (sno))
                    {
                        premiumamount = insmaindata.getAvailableVarPremium(sno) * (1.0 / (1.0 + insmaindata.Premiumreserve));
                        premiumnoreserve = insmaindata.getAvailableVarPremium(sno);
                        if ((insmaindata.initialcontributioncode == 'Y') && (i == insmaindata.age))
                        {
                            premiumamount = premiumamount + insmaindata.initialcontributionamount * (1.0 / (1.0 + insmaindata.Premiumreserve));
                            premiumnoreserve = premiumnoreserve + insmaindata.initialcontributionamount;
                        }
                        //}
                        //commissionamount = insmaindata.Commissionamount(insmaindata.availablePremium , asdata.targetamount, i - insmaindata.age + 1);                    
                        commissionamount = insmaindata.Commissionamount(insmaindata.getAvailableVarPremium(sno), asdata.targetamount, sno);
                    }
                    else
                    {
                        premiumamount = 0.0;
                        commissionamount = 0.0;
                        premiumnoreserve = 0.0;
                    }
                    loadcharge = premiumnoreserve * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    if (asdata.calculatenow == 'V')
                    {
                        accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumnoreserve - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    }
                    else
                    {
                        loadcharge = premiumamount * insmaindata.Loadchargepercent;
                        accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    }                    
                                        
                }



            }

            else if (tocalculate == AVCALCULATETYPES.INSUREDAMOUNT)
            {
                if (asdata.insuredamount >= 120000 && asdata.insuredamount <= 200000)
                {
                    int l1 = 1;
                }

                if (insmaindata.isOpeningbalance == true)
                {
                    accountvalue = insmaindata.openingbalanceamount;
                }

                for (int i = insmaindata.age; i <= maxcalcperiod; i++)
                {
                    sno=i-insmaindata.age+1;
                    costofinsurance=insmaindata.Costofinsuranceoverage(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);                    
                    if (insmaindata.Contributionperiod >= (i - insmaindata.age + 1))
                    {                       
                        //premiumamount = (asdata.premiumamount-asdata.rideradbcost-asdata.ridertermcost-asdata.rideracdbcost-asdata.rideroircost)  *(1.0 / (1.0 + insmaindata.Premiumreserve));
                        if (insmaindata.financialgoalcode == 'Y')
                        {
                            //premiumamount = insmaindata.availablePremium;
                            premiumamount = insmaindata.getAvailableVarPremium(sno);
                            if ((insmaindata.initialcontributioncode == 'Y') && (i == insmaindata.age))
                            {
                                premiumamount = premiumamount + insmaindata.initialcontributionamount ;
                            }
                        }
                        else
                        {
                            //premiumamount = insmaindata.availablePremium * (1.0 / (1.0 + insmaindata.Premiumreserve));
                            premiumamount = insmaindata.getAvailableVarPremium(sno) * (1.0 / (1.0 + insmaindata.Premiumreserve));
                            if ((insmaindata.initialcontributioncode == 'Y') && (i == insmaindata.age))
                            {
                                premiumamount = premiumamount + insmaindata.initialcontributionamount * (1.0 / (1.0 + insmaindata.Premiumreserve));
                            }
                        }
                        //commissionamount = insmaindata.Commissionamount(insmaindata.availablePremium , asdata.targetamount, i - insmaindata.age + 1);                    
                        commissionamount = insmaindata.Commissionamount(insmaindata.getAvailableVarPremium(sno), asdata.targetamount, i - insmaindata.age + 1);                    
                    }
                    else
                    {
                        premiumamount = 0.0;
                        commissionamount = 0.0;
                    }
                    loadcharge = premiumamount * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                }
            }
            else if (tocalculate == AVCALCULATETYPES.TARGETAMOUNT)
            {
                if (asdata.insuredamount >= 230000 && asdata.insuredamount< 270000&&asdata.targetamount>=1300 && asdata.targetamount<=1500)
                {
                    int k = 10;
                }
                for (int i = insmaindata.age; i <= maxcalcperiod; i++)
                {
                    sno = i - insmaindata.age + 1;
                    if (insmaindata.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                    {
                        costofinsurance = insmaindata.Costofinsuranceoveragenohirisk(insmaindata.getVarInsuredamount(sno), accountvalue, i - insmaindata.age + 1);                    
                    }
                    else if (insmaindata.calculatetypecode == Calculatetypes.VERIFY)
                    {
                        if (asdata.useassumedinsurance ==true)
                        {
                            costofinsurance = insmaindata.Costofinsuranceoveragenohirisk(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);
                        }
                        else
                        {
                            costofinsurance = insmaindata.Costofinsuranceoveragenohirisk(insmaindata.getVarInsuredamount(sno), accountvalue, i - insmaindata.age + 1);
                        }
                    }
                    else
                    {                        
                        costofinsurance = insmaindata.Costofinsuranceoveragenohirisk(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);                        
                    }
                    
                    if ((i-insmaindata.age+1) <= insmaindata.Targetcontributionperiod)
                    {
                        premiumamount = asdata.targetamount;                        
                    }
                    else
                    {
                        premiumamount = 0.0;
                        commissionamount = 0;
                    }
                    commissionamount = insmaindata.Commissionamountfortarget(asdata.targetamount, i - insmaindata.age + 1);                    
                    loadcharge = premiumamount  * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                }
            }
            else if (tocalculate == AVCALCULATETYPES.PREMIUMAMOUNT)
            {
                if (insmaindata.isOpeningbalance == true)
                {
                    accountvalue = insmaindata.openingbalanceamount;
                }

                for (int i = insmaindata.age; i <= maxcalcperiod; i++)
                {
                    sno = i - insmaindata.age + 1;
                    //costofinsurance = insmaindata.Costofinsuranceoverage(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);
                    costofinsurance = insmaindata.Costofinsuranceoverage(insmaindata.getVarInsuredamount(sno), accountvalue, i - insmaindata.age + 1);
                    if (insmaindata.Contributionperiod >= (i - insmaindata.age + 1))
                    {
                        if (insmaindata.financialgoalcode == 'Y')
                        {
                            premiumamount = asdata.premiumamount;// *(1.0 / (1.0 + insmaindata.Premiumreserve));
                            if ((insmaindata.initialcontributioncode == 'Y') && (i == insmaindata.age))
                            {
                                premiumamount = premiumamount + insmaindata.initialcontributionamount; //* (1.0 / (1.0 + insmaindata.Premiumreserve));
                            }
                        }
                        else
                        {
                            premiumamount = asdata.premiumamount * (1.0 / (1.0 + insmaindata.Premiumreserve));
                            if ((insmaindata.initialcontributioncode == 'Y') && (i == insmaindata.age))
                            {
                                premiumamount = premiumamount + insmaindata.initialcontributionamount * (1.0 / (1.0 + insmaindata.Premiumreserve));
                            }
                        }
                        commissionamount = insmaindata.Commissionamount(asdata.premiumamount, asdata.targetamount, i - insmaindata.age + 1);
                    
                    }
                    else
                    {
                        premiumamount = 0.0;
                        commissionamount = 0.0;
                    }
                    loadcharge = premiumamount * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                }                
            }
            else if (tocalculate == AVCALCULATETYPES.MINIMUMPREMIUM)
            {
                if (asdata.minimumpremium >= 750 && asdata.minimumpremium < 830)
                {
                    int l = 0;
                }
                for (int i = insmaindata.age; i < (insmaindata.age + insmaindata.GSMinimumcontributionperiod); i++)
                {
                    sno = i - insmaindata.age + 1;
                    //costofinsurance = insmaindata.Costofinsuranceoverage(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);
                    //costofinsurance = insmaindata.Costofinsuranceoverage(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);
                    
                    if (insmaindata.calculatetypecode == Calculatetypes.PREMIUMAMOUNT)
                    {
                        costofinsurance = insmaindata.Costofinsuranceoverage(insmaindata.getVarInsuredamount(sno), accountvalue, i - insmaindata.age + 1);
                    }
                    else
                    {
                        costofinsurance = insmaindata.Costofinsuranceoverage(asdata.insuredamount, accountvalue, i - insmaindata.age + 1);
                    }                    
                    commissionamount = insmaindata.Commissionamountfortarget(asdata.minimumpremium, i - insmaindata.age + 1);
                    //if (insmaindata.Contributionperiod >= (i - insmaindata.age + 1))
                    if (sno <= (insmaindata.GSMinimumcontributionperiod - 1))
                    {
                        premiumamount = asdata.minimumpremium;
                    }
                    else
                    {
                        premiumamount = 0.0;
                        loadcharge = 0.0;
                        commissionamount = 0.0;
                    }                    
                    loadcharge = premiumamount * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                }
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERADB)
            {
                
                int untilage =insmaindata.age+ Math.Max(insmaindata.Rideradbmaxage - insmaindata.age + 1, insmaindata.numberofyears)-1;
                
                
                if (asdata.rideradbcost >= 166 && asdata.rideradbcost <= 168)
                {
                    int k1 = 0;
                }
                for (int i = insmaindata.age; i <=untilage; i++)
                {
                    sno = i - insmaindata.age + 1;
                    if (i <= insmaindata.Rideradbmaxage)
                    {
                        costofinsurance = insmaindata.rideradbamount * insmaindata.Rideradbfactor * (1.0 / 1000.0);
                    }
                    else
                    {
                        costofinsurance = 0;
                    }
                    
                    if (insmaindata.Contributionperiod >= (i - insmaindata.age + 1))
                    {
                        premiumamount = asdata.rideradbcost;
                    }
                    else
                    {
                        premiumamount = 0.0;
                    }
                    loadcharge = premiumamount * insmaindata.Loadchargepercent;
                    commissionamount = insmaindata.Commissionamountforriders(premiumamount, i - insmaindata.age + 1);
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount );
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                }
            }
            else if (tocalculate == AVCALCULATETYPES.RIDERTERM)
            {
                int untilage =insmaindata.age+ Math.Max(insmaindata.ridertermuntilage - insmaindata.age + 1, insmaindata.numberofyears)-1;
                if (asdata.ridertermcost >= 180 && asdata.ridertermcost < 187)
                {
                    int l = 0;
                }
                IRiderAccountdata[] rideradbdata = null;
                if (insmaindata.rideradbcode == 'Y')
                {
                    rideradbdata = insmaindata.getRiderADBAccountdata();
                }

                for (int i = insmaindata.age; i <= untilage; i++)
                {
                    sno = i - insmaindata.age + 1;
                    double rideradbaccountvalue = 0.0;
                    if (insmaindata.rideradbcode == 'Y')
                    {
                        if ((rideradbdata.Length > (i - insmaindata.age))&&((i-insmaindata.age-1)>0))
                        {
                            rideradbaccountvalue = rideradbdata[i - insmaindata.age-1].accountvalue;
                        }
                        else
                        {
                            rideradbaccountvalue = 0.0;
                        }
                    }
                    if (i <= insmaindata.ridertermuntilage)
                    {
                        costofinsurance = insmaindata.Costofinsuranceoverageterm(insmaindata.ridertermamount, accountvalue + rideradbaccountvalue, i - insmaindata.age + 1);
                    }
                    else
                    {
                        costofinsurance = 0;
                    }
                    
                    if (insmaindata.Contributionperiod >= (i - insmaindata.age + 1))                    
                    {
                        premiumamount = asdata.ridertermcost;                    
                    }
                    else                    {
                        premiumamount = 0.0;
                    }
                    commissionamount = insmaindata.Commissionamountforriders(premiumamount, i - insmaindata.age + 1);
                    loadcharge = premiumamount * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                }
            }
            else if (tocalculate == AVCALCULATETYPES.RIDEROIR)
            {
                int untilage =insmaindata.oirage+ Math.Max(insmaindata.oiruntilage - insmaindata.oirage + 1, insmaindata.numberofyears)-1;

                IRiderAccountdata[] riderotherdata = null;
                if (insmaindata.ridertermcode == 'Y')
                {
                    riderotherdata = insmaindata.getRiderTermAccountdata();
                }
                else if (insmaindata.rideradbcode== 'Y')
                {
                    riderotherdata = insmaindata.getRiderADBAccountdata();
                }

                if (asdata.rideroircost>= 110 && asdata.rideroircost < 125)
                {
                    int l = 0;
                }
                for (int i = insmaindata.oirage; i <= untilage; i++)
                {
                    sno = i - insmaindata.oirage + 1;


                    double riderotheraccountvalue = 0.0;
                    if ((insmaindata.rideradbcode == 'Y')||(insmaindata.ridertermcode == 'Y'))
                    {
                        if ((riderotherdata.Length > (i - insmaindata.age)) && ((i - insmaindata.age - 1) > 0))
                        {
                            riderotheraccountvalue= riderotherdata[i - insmaindata.age - 1].accountvalue;
                        }
                        else
                        {
                            riderotheraccountvalue = 0.0;
                        }
                    }

                    costofinsurance = insmaindata.OIRCostofinsuranceoverage(insmaindata.rideroiramount, accountvalue+riderotheraccountvalue, i - insmaindata.oirage + 1);                    
                    if (insmaindata.Contributionperiod >= (i - insmaindata.oirage + 1))
                    {
                        premiumamount = asdata.rideroircost;
                    }
                    else
                    {
                        premiumamount = 0.0;
                    }
                    commissionamount = insmaindata.Commissionamountforriders(premiumamount, i - insmaindata.oirage + 1);
                    loadcharge = premiumamount * insmaindata.Loadchargepercent;
                    //accountvalue = (1 + insmaindata.netgrowthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                    accountvalue = (1 + insmaindata.getGrowthrate(sno)) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount);
                }
            }

            return accountvalue;

        }



        private static Growthcase[] calculategeneralaccountvalue(IMainInsuranceData insmaindata,Boolean assumed,double grate)
        {
            double accountvalue = 0.0;
            double costofinsurance;
            double commissionamount;
            double loadcharge;
            double premiumamount;
            double insuredamount;
            double growthrate;
            int maxcalcperiod = insmaindata.Maxage;

            Growthcase[] gdata = new Growthcase[insmaindata.Maxage - insmaindata.age];


            for (int i = insmaindata.age; i <= maxcalcperiod; i++)
            {
                gdata[i - insmaindata.age] = new Growthcase();                
                if (assumed == false)
                {
                    growthrate = insmaindata.getGrowthrate(i-insmaindata.age + 1);
                }
                else
                {
                    growthrate = grate;
                }
                
                insuredamount = insmaindata.getCalcinsuredamount(i - insmaindata.age + 1);
                costofinsurance = insmaindata.Costofinsurancenooverage(insuredamount, accountvalue, i - insmaindata.age + 1);
                premiumamount = insmaindata.getCalcpremiumamount(i-insmaindata.age+1);// *(1.0 / (1.0 + insmaindata.Premiumreserve));
                if (insmaindata.Contributionperiod >= (i - insmaindata.age + 1))
                {                       
                    if ((insmaindata.initialcontributioncode == 'Y') && (i == insmaindata.age))
                    {
                        premiumamount = premiumamount + insmaindata.initialcontributionamount;// *(1.0 / (1.0 + insmaindata.Premiumreserve));
                    }                
                    commissionamount = insmaindata.Commissionamount(premiumamount*(1/(1+insmaindata.Premiumreserve)), insmaindata.Calctargetamount, i - insmaindata.age + 1);
                }
                else
                {
                    premiumamount = 0.0;
                    commissionamount = 0.0;
                }
                loadcharge = premiumamount * insmaindata.Loadchargepercent;
                accountvalue = (1 + growthrate) * (accountvalue + premiumamount - costofinsurance - loadcharge - commissionamount - insmaindata.Monthlyfeevalueyear);
                gdata[i - insmaindata.age].Accountvalue = accountvalue;
                gdata[i - insmaindata.age].Growthrate = growthrate;
                gdata[i - insmaindata.age].Insuredamount = insuredamount;
                double penaltycharge = 0.0;
                penaltycharge = accountvalue * (insmaindata.Calctargetamount / insmaindata.Calcaveragepremium)*insmaindata.getSurrenderpenaltypercent(i-insmaindata.age+1)
                    +accountvalue*((insmaindata.Calcaveragepremium-insmaindata.Calctargetamount)/insmaindata.Calcaveragepremium)*insmaindata.getSurrenderpenaltypercent(i-insmaindata.age+1)*insmaindata.surrenderexcesspenalty+insmaindata.surrendercharge;
                gdata[i - insmaindata.age].Rescatevalue = accountvalue-penaltycharge;

            }
            return gdata;

        }


    }
}
