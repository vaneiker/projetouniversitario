using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSCompareReport
    {

        public static ReportViewer rpt;
        public static long customerPlanNos = 0;
        //public void showIllustrationFUNERALfixed(WSFuneralResult funeralresult, WSCustomer customer, WSCustomerPlanFuneral customerplan, IMainfuneral funaralfixed)
        //{

        //}
        public static List<List<DataTable>> dt_compare = null;
        public static List<List<DataTable>> dt_compare1 = null;
        public static List<List<DataTable>> dt_compare2 = null;
        public static List<string> perlist = null;
        public static void compareIllustrations(List<WSCompareCustomer> custplans)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            rpt = new ReportViewer();
            try
            {
                //customerPlanNos = (List<long>)Session["customerPlanNos"];
                // customerPlanNos = Sessionclass.getSessiondata(Session).CompareIllusPlans;
                List<string> per = new List<string>();
                List<List<DataTable>> dtList = new List<List<DataTable>>();
                List<List<DataTable>> dtList1 = new List<List<DataTable>>();
                List<List<DataTable>> dtList2 = new List<List<DataTable>>();
                //string planGroupName = "";
                customerPlanNos = Convert.ToInt64(custplans.Count());
                foreach (WSCompareCustomer illuscust in custplans)
                {

                    //customerPlandet otherplandata = (from item in newdb.customerPlandets
                    //                                 where item.customerPlanno == this.firstcustomerplanno
                    //                                 select item).SingleOrDefault();
                    if (illuscust != null)
                    {
                        WSCustomerPlan currentplandata = illuscust.custplan;
                        WSCustomerPlanPartner customerPlanPartnerInsurance = illuscust.partins;

                        string @class = "";

                        if (currentplandata.classcode == "A")
                        {
                            @class = "US$ ";
                        }
                        else if (currentplandata.classcode == "E")
                        {
                            @class = "€ ";
                        }
                        else if (currentplandata.classcode == "R")
                        {
                            @class = "RD$ ";
                        }

                        productdet plan = (from p in newdb.productdets
                                           where p.productcode == currentplandata.productcode
                                           select p).SingleOrDefault();

                        //planGroupName = (from p in newdb.plangroupdets
                        //                 where p.plangroupcode == plan.plangroupcode
                        //                 select p.plangroup).SingleOrDefault();

                        WSCustomer cust = illuscust.customer;

                        List<DataTable> dt = new List<DataTable>();
                        List<DataTable> dt1 = new List<DataTable>();
                        List<DataTable> dt2 = new List<DataTable>();
                        DataTable dtTop = new DataTable();
                        DataTable dtTop1 = new DataTable();
                        DataTable dtTop2 = new DataTable();
                        DataTable dtTitle = new DataTable();
                        DataTable dtBottom = new DataTable();
                        DataTable dtBottom1 = new DataTable();
                        DataTable dtBottom2 = new DataTable();
                        dtTop.Columns.Add("sno");
                        dtTop.Columns.Add("maincolumn1");
                        dtTop.Columns.Add("maincolumn2");
                        dtTop.Columns.Add("maincolumn3");

                        dtTop1.Columns.Add("sno");
                        dtTop1.Columns.Add("maincolumn1");
                        dtTop1.Columns.Add("maincolumn2");
                        dtTop1.Columns.Add("maincolumn3");

                        dtTop2.Columns.Add("sno");
                        dtTop2.Columns.Add("maincolumn1");
                        dtTop2.Columns.Add("maincolumn2");
                        dtTop2.Columns.Add("maincolumn3");
                        //dtTop.Columns.Add("comparecolumn1");
                        //dtTop.Columns.Add("comparecolumn2");
                        //dtTop.Columns.Add("comparecolumn3");


                        if (plan.plangroupcode == 'L')
                        {
                            CalculateLife(@class, cust, plan, dtTop, dtTop1, dtTop2, dtTitle, dtBottom, dtBottom1, dtBottom2, customerPlanPartnerInsurance, currentplandata, per, illuscust.riderslist);
                        }
                        else if ((plan.plangroupcode == 'E' || plan.plangroupcode == 'R') && plan.@fixed == 'N')
                        {
                            CalculateEduRet(currentplandata.classcode.ToCharArray()[0], @class, cust, plan, dtTop, dtTitle, dtBottom, customerPlanPartnerInsurance, currentplandata, per);
                        }
                        else if ((plan.plangroupcode == 'E' || plan.plangroupcode == 'R') && plan.@fixed == 'Y')
                        {
                            CalculateEduRetFixed(currentplandata.classcode.ToCharArray()[0], @class, cust, plan, dtTop, dtTitle, dtBottom, customerPlanPartnerInsurance, currentplandata, per);
                        }
                        else if (plan.plangroupcode == 'T')
                        {
                            if (currentplandata.productcode.Equals("LGT") || currentplandata.productcode.Equals("SNT"))
                                CalculateTermLS(@class, cust, plan, dtTop, dtTitle, dtBottom, customerPlanPartnerInsurance, currentplandata, per, illuscust.riderslist);
                            else
                                CalculateTerm(@class, cust, plan, dtTop, dtTitle, dtBottom, customerPlanPartnerInsurance, currentplandata, per, illuscust.riderslist);
                        }

                        dt.Add(dtTop);
                        dt.Add(dtBottom);
                        dt.Add(dtTitle);

                        if (dtTop1.Rows.Count == 0)
                        {
                            dt1.Add(dtTop);
                        }
                        else
                        {
                            dt1.Add(dtTop1);
                        }
                        if (dtBottom1.Rows.Count == 0)
                        {
                            dt1.Add(dtBottom);
                        }
                        else
                        {
                            dt1.Add(dtBottom1);
                        }

                        dt1.Add(dtTitle);
                        if (dtTop2.Rows.Count == 0)
                        {
                            dt2.Add(dtTop);
                        }
                        else
                        {
                            dt2.Add(dtTop2);
                        }
                        if (dtBottom2.Rows.Count == 0)
                        {
                            dt2.Add(dtBottom);
                        }
                        else
                        {
                            dt2.Add(dtBottom2);
                        }

                        dt2.Add(dtTitle);


                        dtList.Add(dt);
                        dtList1.Add(dt1);
                        dtList2.Add(dt2);


                        dt_compare = dtList;
                        dt_compare1 = dtList1;
                        dt_compare2 = dtList2;
                        perlist = per;
                    }
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

        public static void CalculateLife(string @class, WSCustomer cust, productdet plan, DataTable dtTop, DataTable dtTop1, DataTable dtTop2, DataTable dtTitle, DataTable dtBottom, DataTable dtBottom1, DataTable dtBottom2, WSCustomerPlanPartner customerPlanPartnerInsurance, WSCustomerPlan currentplandata, List<string> per, List<WSRider> riderslist)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                double minimumPremium = 0;
                double targetPremium = 0;
                double periodicPremium = 0;
                double insuredAmount = 0;
                string frequency = "";
                double annualpremium = 0;
                string type = "";
                IMainInsuranceData insdata = new IMainInsuranceData(cust, currentplandata, riderslist, customerPlanPartnerInsurance);
                if (per.Count != customerPlanNos)
                {
                    per.Add(insdata.comprate1);
                }
                IAssumeddata asdata = new IAssumeddata();
                //IResultData resdata = null;

                if (currentplandata.calculatetypecode.ToCharArray()[0] == Calculatetypes.INSUREDAMOUNT)
                {
                    asdata.premiumamount = insdata.annualizedpremiumamount;
                    IResultData resdata = IAccountvalue.calculateInsuredamount(insdata, asdata);

                    if (resdata.impossible == false)
                    {
                        periodicPremium = insdata.calculatePeriodicPremiumAmount();
                        insuredAmount = insdata.Calcinsuredamount;
                        minimumPremium = insdata.minimumyearlypremium(resdata);
                        targetPremium = insdata.targetyearlyamount(resdata);
                        frequency = Frequencytypes.getfrequencytype(insdata.frequencytypecode);
                        annualpremium = insdata.frequencytypevalue * periodicPremium;
                        type = insdata.plantype == "Insured" ? "Con Seguro" : "Sin Seguro";
                    }
                }
                else if (currentplandata.calculatetypecode.ToCharArray()[0] == Calculatetypes.PREMIUMAMOUNT)
                {
                    asdata.insuredamount = Convert.ToDouble(currentplandata.insuredamount);
                    IResultData resdata = IAccountvalue.calculatePremiumamount(insdata, asdata);

                    if (resdata.impossible == false)
                    {
                        periodicPremium = insdata.calculatePeriodicPremiumAmount();
                        insuredAmount = Convert.ToDouble(currentplandata.insuredamount);
                        minimumPremium = insdata.minimumyearlypremium(resdata);
                        targetPremium = insdata.targetyearlyamount(resdata);
                        frequency = Frequencytypes.getfrequencytype(insdata.frequencytypecode);
                        annualpremium = insdata.frequencytypevalue * periodicPremium;
                        type = insdata.plantype == "Insured" ? "Con Seguro" : "Sin Seguro";
                    }
                }
                else if (currentplandata.calculatetypecode.ToCharArray()[0] == Calculatetypes.VERIFY)
                {
                    asdata.insuredamount = Convert.ToDouble(currentplandata.insuredamount);
                    asdata.premiumamount = Convert.ToDouble(currentplandata.premiumamount);
                    IResultData resdata = IAccountvalue.calculateNinguna(insdata, asdata);

                    if (resdata.impossible == false)
                    {
                        periodicPremium = insdata.calculatePeriodicPremiumAmount();
                        insuredAmount = Convert.ToDouble(currentplandata.insuredamount);
                        minimumPremium = insdata.minimumyearlypremium(resdata);
                        targetPremium = insdata.targetyearlyamount(resdata);
                        frequency = Frequencytypes.getfrequencytype(insdata.frequencytypecode);
                        annualpremium = insdata.frequencytypevalue * periodicPremium;
                        type = insdata.plantype == "Insured" ? "Con Seguro" : "Sin Seguro";
                    }
                }
                else if (currentplandata.calculatetypecode.ToCharArray()[0] == Calculatetypes.ANNUITYAMOUNT)
                {
                    //as per plan info => "Not possible"
                }

                //insdata.Calctargetamount = Numericdata.getDoublevalue(currentplandata.targetpremium.ToString());
                //insdata.Calcminimumpremium = Numericdata.getDoublevalue(currentplandata.minimumpremium.ToString());
                Illusdata[] illdata = insdata.getIllustration();

                int sno = 0;

                String[] str1 = new String[4];
                String[] str2 = new String[4];
                String[] str3 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Plan:");
                str1[3] = plan.product.ToUpper().Trim();
                dtTop.Rows.Add(str1);

                str2[0] = sno.ToString();
                str2[1] = Caption.getCaption("en", "Plan:");
                str2[3] = plan.product.ToUpper().Trim() + " (" + insdata.comprate2 + ")";
                dtTop1.Rows.Add(str2);

                str3[0] = sno.ToString();
                str3[1] = Caption.getCaption("en", "Plan:");
                str3[3] = plan.product.ToUpper().Trim() + " (" + insdata.comprate3 + ")";
                dtTop2.Rows.Add(str3);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name:");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name:");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop1.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop1.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name:");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop2.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop2.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Death Benefit:");
                //str1[3] = (currentplandata.insuredamount == 0 ? "" : @class + String.Format("{0:#,###}", insdata.Calcinsuredamount));
                str1[3] = (insuredAmount == 0 ? "" : @class + String.Format("{0:#,###}", insuredAmount));
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = (@class + String.Format("{0:#,###}", annualpremium));
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Periodic Premium:");
                //str1[3] = (currentplandata.premiumamount == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.premiumamount));
                str1[3] = (periodicPremium == 0 ? "" : @class + String.Format("{0:#,###}", periodicPremium));
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Payment Frequency:");
                str1[3] = Caption.getCaption("en", frequency);
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Min. Premium:");
                //str1[3] = (currentplandata.minimumpremium == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.minimumpremium));
                str1[3] = (minimumPremium == 0 ? "" : @class + String.Format("{0:#,###}", minimumPremium));
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Target Premium:");
                //str1[3] = (currentplandata.targetpremium == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.targetpremium));
                str1[3] = (targetPremium == 0 ? "" : @class + String.Format("{0:#,###}", targetPremium));
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);

                int contributionPeriod = 0;
                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Cont. Period:");

                if (currentplandata.contributiontypecode.ToCharArray()[0] == Contributiontypes.NUMBEROFYEARS)
                    contributionPeriod = currentplandata.contributionperiod;
                else if (currentplandata.contributiontypecode.ToCharArray()[0] == Contributiontypes.UNTILAGE)
                    contributionPeriod = (currentplandata.contributionuntilage - Numericdata.getIntegervalue(cust.Age.ToString()) + 1);
                else
                    contributionPeriod = (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1);

                if (contributionPeriod == 0)
                    str1[3] = "";
                else if (contributionPeriod == 1)
                    str1[3] = contributionPeriod + " " + Caption.getCaption("en", "Year");
                else if (contributionPeriod > 1)
                    str1[3] = contributionPeriod + " " + Caption.getCaption("en", "Years");


                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Inv. Profile:");
                str1[3] = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, Invprofiledata.getInvestmentprofile(currentplandata.investmentprofilecode.ToCharArray()[0]).Trim(), "en");
                dtTop.Rows.Add(str1);
                dtTop1.Rows.Add(str1);
                dtTop2.Rows.Add(str1);

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
                if (rideradb != null || /*currentplandata.rideracdb == 'Y' ||*/ riderterm != null || /*currentplandata.riderci == 'Y' ||*/ currentplandata.rideroir != null)
                {
                    str1 = new String[4];
                    sno++;
                    dtTop.Rows.Add(str1);
                    dtTop1.Rows.Add(str1);
                    dtTop2.Rows.Add(str1);

                    str1 = new String[4];
                    sno++;
                    str1[0] = sno.ToString();
                    str1[1] = Caption.getCaption("en", "Rider Info:");
                    dtTop.Rows.Add(str1);
                    dtTop1.Rows.Add(str1);
                    dtTop2.Rows.Add(str1);

                    if (riderterm!=null && riderterm.ridertypecode == "Y")
                    {
                        string temp = "";

                        if (riderterm.type == "U")
                        {
                            temp = " - " + riderterm.term + " Y";
                        }
                        else if (riderterm.type == "Y")
                        {
                            temp = " - " + (riderterm.term + Convert.ToInt32(cust.Age) - 1) + " Y";
                        }
                        else if (riderterm.type == "C")
                        {
                            temp = " - " + (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1) + " Y";
                        }

                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "Ad.Term. Ins.:");
                        str1[3] = (riderterm.amount == 0 ? "" : @class + String.Format("{0:#,###}", riderterm.amount) + temp);
                        dtTop.Rows.Add(str1);
                        dtTop1.Rows.Add(str1);
                        dtTop2.Rows.Add(str1);
                    }

                    if (currentplandata.rideroir != null && customerPlanPartnerInsurance != null)
                    {
                        string temp = "";

                        if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'U')
                        {
                            temp = " - " + customerPlanPartnerInsurance.term + " Y";
                        }
                        else if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'Y')
                        {
                            temp = " - " + (customerPlanPartnerInsurance.term + Convert.ToInt32(cust.Age) - 1) + " Y";
                        }
                        else if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'C')
                        {
                            temp = " - " + (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1) + " Y";
                        }

                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "Spouse Ins.:");
                        str1[3] = (customerPlanPartnerInsurance.amount == 0 ? "" : @class + String.Format("{0:#,###}", customerPlanPartnerInsurance.amount) + temp);
                        dtTop.Rows.Add(str1);
                        dtTop1.Rows.Add(str1);
                        dtTop2.Rows.Add(str1);
                    }

                    if (rideradb != null && rideradb.ridertypecode.ToCharArray()[0] == 'Y')
                    {
                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "ADB:");
                        str1[3] = (rideradb.amount == 0 ? "" : @class + String.Format("{0:#,###}", rideradb.amount));// + " - 65 Y"
                        dtTop.Rows.Add(str1);
                        dtTop1.Rows.Add(str1);
                        dtTop2.Rows.Add(str1);
                    }
                }

                if (currentplandata!=null && currentplandata.financialgoal.ToCharArray()[0] == 'Y')
                {
                    str1 = new String[4];
                    sno++;
                    str1[0] = sno.ToString();
                    str1[1] = (currentplandata.productcode == "CPI" ? Caption.getCaption("en", "Financial Goals at") + " " + currentplandata.financialgoalage + " " + Caption.getCaption("en", "años:") : Caption.getCaption("en", "Financial Goals:"));
                    if (currentplandata.productcode == "CPI")
                        str1[3] = (currentplandata.financialgoalamount == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.financialgoalamount));
                    else
                        str1[3] = (currentplandata.financialgoalamount == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.financialgoalamount) + " - " + currentplandata.financialgoalage + " Y");
                    dtTop.Rows.Add(str1);
                    dtTop1.Rows.Add(str1);
                    dtTop2.Rows.Add(str1);




                }


                dtTitle.Columns.Add("sno");
                dtTitle.Columns.Add("maincolumn1");
                dtTitle.Columns.Add("maincolumn2");
                dtTitle.Columns.Add("maincolumn3");
                dtTitle.Columns.Add("maincolumn4");



                sno = 0;

                str1 = new String[5];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Period");
                str1[2] = Caption.getCaption("en", "Account Value:");
                str1[3] = Caption.getCaption("en", "Surrender Value:");
                str1[4] = Caption.getCaption("en", "Insured Amount:");
                dtTitle.Rows.Add(str1);

                sno = 0;



                dtBottom.Columns.Add("sno");
                dtBottom.Columns.Add("maincolumn1");
                dtBottom.Columns.Add("maincolumn2");
                dtBottom.Columns.Add("maincolumn3");
                dtBottom.Columns.Add("maincolumn4");

                dtBottom1.Columns.Add("sno");
                dtBottom1.Columns.Add("maincolumn1");
                dtBottom1.Columns.Add("maincolumn2");
                dtBottom1.Columns.Add("maincolumn3");
                dtBottom1.Columns.Add("maincolumn4");

                dtBottom2.Columns.Add("sno");
                dtBottom2.Columns.Add("maincolumn1");
                dtBottom2.Columns.Add("maincolumn2");
                dtBottom2.Columns.Add("maincolumn3");
                dtBottom2.Columns.Add("maincolumn4");


                int[] length = new int[0];

                if (illdata.Length == 1)
                    length = new int[] { 1 };
                else if (illdata.Length > 1)
                {
                    if (illdata.Length % 5 == 0)
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 1];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                    }
                    else
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 2];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length - 1; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                        length[length.Length - 1] = illdata.Length - 1;
                    }
                }

                for (int i = 0; i < length.Count(); i++)
                {
                    str1 = new String[5];
                    str1[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1); //illdata[length[i]].Sno.ToString();
                    str1[2] = (illdata[length[i]].Growthdata[0].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[0].Accountvalue));
                    str1[3] = (illdata[length[i]].Growthdata[0].Rescatevalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[0].Rescatevalue));
                    str1[4] = (illdata[length[i]].Growthdata[0].Insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[0].Insuredamount));
                    dtBottom.Rows.Add(str1);
                    str2 = new String[5];
                    str2[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1); //illdata[length[i]].Sno.ToString();
                    str2[2] = (illdata[length[i]].Growthdata[1].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[1].Accountvalue));
                    str2[3] = (illdata[length[i]].Growthdata[1].Rescatevalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[1].Rescatevalue));
                    str2[4] = (illdata[length[i]].Growthdata[1].Insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[1].Insuredamount));
                    dtBottom1.Rows.Add(str2);
                    str3 = new String[5];
                    str3[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1); //illdata[length[i]].Sno.ToString();
                    str3[2] = (illdata[length[i]].Growthdata[2].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[2].Accountvalue));
                    str3[3] = (illdata[length[i]].Growthdata[2].Rescatevalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[2].Rescatevalue));
                    str3[4] = (illdata[length[i]].Growthdata[2].Insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[2].Insuredamount));
                    dtBottom2.Rows.Add(str3);
                }

                str1[2] = "";
                str1[3] = "";
                str1[4] = "";
                str2[2] = "";
                str2[3] = "";
                str2[4] = "";
                str3[2] = "";
                str3[3] = "";
                str3[4] = "";

                if (length.Count() == 0)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);

                    str2[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom1.Rows.Add(str2);

                    str2[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom1.Rows.Add(str2);

                    str2[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom1.Rows.Add(str2);

                    str3[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom2.Rows.Add(str3);

                    str3[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom2.Rows.Add(str3);

                    str3[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom2.Rows.Add(str3);
                }
                else if (length.Count() == 1)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);

                    str2[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom1.Rows.Add(str2);

                    str2[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom1.Rows.Add(str2);

                    str3[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom2.Rows.Add(str3);

                    str3[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom2.Rows.Add(str3);
                }
                else if (length.Count() == 2)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);

                    str2[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom1.Rows.Add(str2);

                    str3[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom2.Rows.Add(str3);
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
        public static void CalculateEduRet(char classCode, string @class, WSCustomer cust, productdet plan, DataTable dtTop, DataTable dtTitle, DataTable dtBottom, WSCustomerPlanPartner customerPlanPartnerInsurance, WSCustomerPlan currentplandata, List<string> per)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                IMaineduretire eduretire = new IMaineduretire(cust, currentplandata);

                if (per.Count != customerPlanNos)
                {
                    per.Add("");
                }

                //String insuredamount;
                double totalretirementamount;
                double annualretirementamount;
                double periodicpremium;
                double minimumpremium;
                double targetpremium;
                string frequency;
                double annualpremium;
                int contribperiod = currentplandata.contributionperiod;
                int defermentperiod = Numericdata.getIntegervalue(currentplandata.defermentperiod.ToString());
                int retirementperiod = Numericdata.getIntegervalue(currentplandata.retirementperiod.ToString());
                string type;
                //insuredamount = eduretire.getInsuredAmountFE().ToString("n2");
                totalretirementamount = ((eduretire.annuityamount) * retirementperiod);
                annualretirementamount = ((eduretire.annuityamount));
                periodicpremium = eduretire.calculatedPeriodicPremiumAmount();
                targetpremium = eduretire.getTargetAmountFE();
                minimumpremium = eduretire.getMinimumPremiumAmountFE();
                frequency = Frequencytypes.getfrequencytype(eduretire.frequencytypecode);
                annualpremium = eduretire.frequencytypevalue * periodicpremium;
                REDIllusdata[] illdata = eduretire.getIllustration();
                type = Plantypes.getPlantype(eduretire.plantypecode) == "Insured" ? "Con Seguro" : "Sin Seguro";

                int sno = 0;
                String[] str1;

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Plan:");
                str1[3] = plan.product.ToUpper().Trim();
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name:");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Insurance Term:");
                str1[3] = (type);
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Total Retirement Amount:") : Caption.getCaption("en", "Total Study Amount:"));
                str1[3] = (totalretirementamount == 0 ? "" : @class + String.Format("{0:#,###}", totalretirementamount));
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Annual Retirement Amount:") : Caption.getCaption("en", "Annual Study Amount:"));
                str1[3] = (annualretirementamount == 0 ? "" : @class + String.Format("{0:#,###}", annualretirementamount));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = (@class + String.Format("{0:#,###}", annualpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Periodic Premium:");
                str1[3] = (periodicpremium == 0 ? "" : @class + String.Format("{0:#,###}", periodicpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Payment Frequency:");
                str1[3] = Caption.getCaption("en", frequency);
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Min. Premium:");
                str1[3] = (minimumpremium == 0 ? "" : @class + String.Format("{0:#,###}", minimumpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Target Premium:");
                str1[3] = (targetpremium == 0 ? "" : @class + String.Format("{0:#,###}", targetpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Cont. Period:");
                if (contribperiod == 0)
                    str1[3] = "";
                else if (contribperiod == 1)
                    str1[3] = contribperiod + " " + Caption.getCaption("en", "Year");
                else if (contribperiod > 1)
                    str1[3] = contribperiod + " " + Caption.getCaption("en", "Years");
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Deferral Period:");
                if (defermentperiod == 0)
                    str1[3] = "";
                else if (defermentperiod == 1)
                    str1[3] = defermentperiod + " " + Caption.getCaption("en", "Year");
                else if (defermentperiod > 1)
                    str1[3] = defermentperiod + " " + Caption.getCaption("en", "Years");
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Retirement Period:") : Caption.getCaption("en", "Study Period:"));
                //str1[3] = retirementperiod + " Years";
                if (retirementperiod == 0)
                    str1[3] = "";
                else if (retirementperiod == 1)
                    str1[3] = retirementperiod + " " + Caption.getCaption("en", "Year");
                else if (retirementperiod > 1)
                    str1[3] = retirementperiod + " " + Caption.getCaption("en", "Years");
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Inv. Profile:");
                str1[3] = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, Invprofiledata.getInvestmentprofile(currentplandata.investmentprofilecode.ToCharArray()[0]).Trim(), "en");
                dtTop.Rows.Add(str1);


                dtTitle.Columns.Add("sno");
                dtTitle.Columns.Add("maincolumn1");
                dtTitle.Columns.Add("maincolumn2");
                dtTitle.Columns.Add("maincolumn3");
                dtTitle.Columns.Add("maincolumn4");

                sno = 0;

                str1 = new String[5];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Period");
                str1[2] = Caption.getCaption("en", "Accum. Premiums:");
                str1[3] = Caption.getCaption("en", "Account Value:");
                str1[4] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Ret. Amounts:") : Caption.getCaption("en", "Study Amounts:"));
                dtTitle.Rows.Add(str1);

                sno = 0;

                dtBottom.Columns.Add("sno");
                dtBottom.Columns.Add("maincolumn1");
                dtBottom.Columns.Add("maincolumn2");
                dtBottom.Columns.Add("maincolumn3");
                dtBottom.Columns.Add("maincolumn4");

                int[] length = new int[0];

                if (illdata.Length == 1)
                    length = new int[] { 1 };
                else if (illdata.Length > 1)
                {
                    if (illdata.Length % 5 == 0)
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 1];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                    }
                    else
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 2];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length - 1; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                        length[length.Length - 1] = illdata.Length - 1;
                    }
                }

                for (int i = 0; i < length.Count(); i++)
                {
                    str1 = new String[5];
                    str1[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1);//illdata[length[i]].Sno.ToString();
                    str1[2] = (illdata[length[i]].Accumulatedpremium <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Accumulatedpremium));
                    str1[3] = (illdata[length[i]].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Accountvalue));
                    str1[3] = (str1[3] == @class ? "" : str1[3]);
                    str1[4] = (illdata[length[i]].Partialretirementamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Partialretirementamount));
                    dtBottom.Rows.Add(str1);
                }
                str1 = new String[5];

                str1[2] = "";
                str1[3] = "";
                str1[4] = "";

                if (length.Count() == 0)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 11";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 1)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 11";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 2)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 11";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 3)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 11";
                    dtBottom.Rows.Add(str1);
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

        public static void CalculateEduRetFixed(char classCode, string @class, WSCustomer cust, productdet plan, DataTable dtTop, DataTable dtTitle, DataTable dtBottom, WSCustomerPlanPartner customerPlanPartnerInsurance, WSCustomerPlan currentplandata, List<string> per)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                IMaineduretirefixed eduretire = new IMaineduretirefixed(cust, currentplandata);
                if (per.Count != customerPlanNos)
                {
                    per.Add("");
                }
                //String insuredamount;
                double totalretirementamount;
                double annualretirementamount;
                double periodicpremium;
                double minimumpremium = 0;
                double targetpremium;
                string frequency;
                double annualpremium;
                int contribperiod = currentplandata.contributionperiod;
                int defermentperiod = Numericdata.getIntegervalue(currentplandata.defermentperiod.ToString());
                int retirementperiod = Numericdata.getIntegervalue(currentplandata.retirementperiod.ToString());
                string type;
                //insuredamount = eduretire.getInsuredamountFE().ToString("n2");
                totalretirementamount = ((eduretire.annuityamount) * retirementperiod);
                annualretirementamount = ((eduretire.annuityamount));
                periodicpremium = eduretire.calculatedPeriodicPremiumAmount();
                targetpremium = eduretire.getTargetamountFE();
                frequency = Frequencytypes.getfrequencytype(eduretire.frequencytypecode);
                annualpremium = eduretire.frequencytypevalue * periodicpremium;
                //--------->>> minimumpremium = Program.getCurrencyString(classCode, Numericdata.getDoublevalue(eduretire.getMinimumPremiumAmountFE().ToString()));
                type = Plantypes.getPlantype(eduretire.plantypecode) == "Insured" ? "Con Seguro" : "Sin Seguro";

                REDIllusdata[] illdata = eduretire.getIllustration();

                int sno = 0;
                String[] str1;

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Plan:");
                str1[3] = plan.product.ToUpper().Trim();
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Total Retirement Amount:") : Caption.getCaption("en", "Total Study Amount:"));
                str1[3] = (totalretirementamount == 0 ? "" : @class + String.Format("{0:#,###}", totalretirementamount));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Insurance Term:");
                str1[3] = (type);
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Annual Retirement Amount:") : Caption.getCaption("en", "Annual Study Amount:"));
                str1[3] = (annualretirementamount == 0 ? "" : @class + String.Format("{0:#,###}", annualretirementamount));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = (@class + String.Format("{0:#,###}", annualpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Periodic Premium:");
                str1[3] = (periodicpremium == 0 ? "" : @class + String.Format("{0:#,###}", periodicpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Payment Frequency:");
                str1[3] = Caption.getCaption("en", frequency);
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Min. Premium:");
                str1[3] = (minimumpremium == 0 ? "" : @class + String.Format("{0:#,###}", minimumpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Target Premium:");
                str1[3] = (targetpremium == 0 ? "" : @class + String.Format("{0:#,###}", targetpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Cont. Period:");
                if (contribperiod == 0)
                    str1[3] = "";
                else if (contribperiod == 1)
                    str1[3] = contribperiod + " " + Caption.getCaption("en", "Year");
                else if (contribperiod > 1)
                    str1[3] = contribperiod + " " + Caption.getCaption("en", "Years");
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Deferral Period:");
                if (defermentperiod == 0)
                    str1[3] = "";
                else if (defermentperiod == 1)
                    str1[3] = defermentperiod + " " + Caption.getCaption("en", "Year");
                else if (defermentperiod > 1)
                    str1[3] = defermentperiod + " " + Caption.getCaption("en", "Years");
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Retirement Period:") : Caption.getCaption("en", "Study Period:"));
                //str1[3] = retirementperiod + " Years";
                if (retirementperiod == 0)
                    str1[3] = "";
                else if (retirementperiod == 1)
                    str1[3] = retirementperiod + " " + Caption.getCaption("en", "Year");
                else if (retirementperiod > 1)
                    str1[3] = retirementperiod + " " + Caption.getCaption("en", "Years");
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Inv. Profile:");
                str1[3] = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, Invprofiledata.getInvestmentprofile(currentplandata.investmentprofilecode.ToCharArray()[0]).Trim(), "en");
                dtTop.Rows.Add(str1);


                dtTitle.Columns.Add("sno");
                dtTitle.Columns.Add("maincolumn1");
                dtTitle.Columns.Add("maincolumn2");
                dtTitle.Columns.Add("maincolumn3");
                dtTitle.Columns.Add("maincolumn4");

                sno = 0;

                str1 = new String[5];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Period");
                str1[2] = Caption.getCaption("en", "Accum. Premiums:");
                str1[3] = (currentplandata.productcode == "EDU" || currentplandata.productcode == "HRZ" ? "" : Caption.getCaption("en", "Account Value:"));
                str1[4] = (plan.plangroupcode == 'R' ? Caption.getCaption("en", "Ret. Amounts:") : Caption.getCaption("en", "Study Amounts:"));
                dtTitle.Rows.Add(str1);

                sno = 0;

                dtBottom.Columns.Add("sno");
                dtBottom.Columns.Add("maincolumn1");
                dtBottom.Columns.Add("maincolumn2");
                dtBottom.Columns.Add("maincolumn3");
                dtBottom.Columns.Add("maincolumn4");

                //if (insdata.planerror == true)
                //{
                //    showAlert(Caption.showMessageBox("en", insdata.planerrordata));
                //    return;
                //}

                //int[] length = new int[0];

                //if (illdata.Length >= 11)
                //    length = new int[] { 0, 4, 9, 10 };
                //else if (illdata.Length == 10)
                //    length = new int[] { 0, 4, 9 };
                //else if (illdata.Length >= 5 && illdata.Length < 10)
                //    length = new int[] { 0, 4 };
                //else if (illdata.Length >= 1 && illdata.Length < 5)
                //    length = new int[] { 0 };

                int[] length = new int[0];

                if (illdata.Length == 1)
                    length = new int[] { 1 };
                else if (illdata.Length > 1)
                {
                    if (illdata.Length % 5 == 0)
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 1];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                    }
                    else
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 2];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length - 1; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                        length[length.Length - 1] = illdata.Length - 1;
                    }
                }

                for (int i = 0; i < length.Count(); i++)
                {
                    str1 = new String[5];
                    str1[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1);//illdata[length[i]].Sno.ToString();
                    str1[2] = (illdata[length[i]].Accumulatedpremium <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Accumulatedpremium));
                    str1[3] = (currentplandata.productcode == "EDU" || currentplandata.productcode == "HRZ" ? "" : (illdata[length[i]].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Accountvalue)));
                    str1[4] = (illdata[length[i]].Partialretirementamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Partialretirementamount));
                    dtBottom.Rows.Add(str1);
                }
                str1 = new String[5];

                str1[2] = "";
                str1[3] = "";
                str1[4] = "";

                if (length.Count() == 0)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + "  5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + "  10";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + "  11";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 1)
                {
                    str1[1] = Caption.getCaption("en", "Year") + "  5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + "  10";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + "  11";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 2)
                {
                    str1[1] = Caption.getCaption("en", "Year") + "  10";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + "  11";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 3)
                {
                    str1[1] = Caption.getCaption("en", "Year") + "  11";
                    dtBottom.Rows.Add(str1);
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

        public static void CalculateTerm(string @class, WSCustomer cust, productdet plan, DataTable dtTop, DataTable dtTitle, DataTable dtBottom, WSCustomerPlanPartner customerPlanPartnerInsurance, WSCustomerPlan currentplandata, List<string> per, List<WSRider> riderslist)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                double deathbenefit;
                double periodicpremium;
                double targetpremium;
                int contribperiod = currentplandata.contributionperiod;
                string frequency;
                double annualpremium;
                string type;
                //int insuranceTerm;
                //int defermentperiod = Numericdata.getIntegervalue(currentplandata.defermentperiod.ToString());
                //int retirementperiod = Numericdata.getIntegervalue(currentplandata.retirementperiod.ToString());

                IMaintermfixed termfixed = new IMaintermfixed(cust, currentplandata, riderslist, customerPlanPartnerInsurance);

                if (per.Count != customerPlanNos)
                {
                    per.Add("");
                }
                //txtinsuredamt.Text = termfixed.getInsuredamountFE().ToString("n2");
                //Sessionclass.getSessiondata(Session).insuredamt = txtinsuredamt.Text;
                //txtinsuredamt_TextChanged(null, null);

                //txtannuityamount.Text = (termfixed.annuityamount).ToString("n2");
                periodicpremium = termfixed.calculatedPeriodicPremiumAmount();
                targetpremium = termfixed.getTargetamountFE();
                frequency = Frequencytypes.getfrequencytype(currentplandata.frequencytypecode.ToCharArray()[0]);
                annualpremium = Frequencytypes.getfrequencytypevaluefromcode(currentplandata.frequencytypecode.ToCharArray()[0]) * periodicpremium;
                type = Plantypes.getPlantype(currentplandata.plantypecode.ToCharArray()[0]) == "Insured" ? "Con Seguro" : "Sin Seguro";
                //Sessionclass.getSessiondata(Session).targetdata = termfixed.getTargetamountFE().ToString("n2");

                Termillusdata[] illdata = termfixed.getIllustration();









                int sno = 0;

                String[] str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Plan:");
                str1[3] = plan.product.ToUpper().Trim();
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name:");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Death Benefit:");
                str1[3] = (currentplandata.insuredamount == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.insuredamount));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = (@class + String.Format("{0:#,###}", annualpremium));
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Periodic Premium:");
                str1[3] = (periodicpremium == 0 ? "" : @class + String.Format("{0:#,###}", periodicpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Payment Frequency:");
                str1[3] = Caption.getCaption("en", frequency);
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Target Premium:");
                str1[3] = (targetpremium == 0 ? "" : @class + String.Format("{0:#,###}", targetpremium));
                dtTop.Rows.Add(str1);

                int contributionPeriod = 0;
                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Cont. Period:");

                if (currentplandata.contributiontypecode.ToCharArray()[0] == Contributiontypes.NUMBEROFYEARS)
                    contributionPeriod = currentplandata.contributionperiod;
                else if (currentplandata.contributiontypecode.ToCharArray()[0] == Contributiontypes.UNTILAGE)
                    contributionPeriod = (currentplandata.contributionuntilage - Numericdata.getIntegervalue(cust.Age.ToString()) + 1);
                else
                    contributionPeriod = (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1);

                if (contributionPeriod == 0)
                    str1[3] = "";
                else if (contributionPeriod == 1)
                    str1[3] = currentplandata.contributionperiod + " " + Caption.getCaption("en", "Year");
                else if (contributionPeriod > 1)
                    str1[3] = currentplandata.contributionperiod + " " + Caption.getCaption("en", "Years");

                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Insurance Term:");

                int insuranceTerm = Convert.ToInt32(currentplandata.retirementperiod);

                if (insuranceTerm == 0)
                    str1[3] = "";
                else if (insuranceTerm == 1)
                    str1[3] = insuranceTerm + " " + Caption.getCaption("en", "Year");
                else if (insuranceTerm > 1)
                    str1[3] = insuranceTerm + " " + Caption.getCaption("en", "Years");

                dtTop.Rows.Add(str1);

                if (plan.productcode == "SNT")
                {
                    double ROP = 0;
                    for (int i = 0; i < illdata.Length; i++)
                    {
                        ROP += illdata[i].Totalpremium;
                    }


                    str1 = new String[4];
                    sno++;
                    str1[0] = sno.ToString();
                    str1[1] = Caption.getCaption("en", "Return of Premium:");
                    str1[3] = (ROP == 0 ? "" : @class + String.Format("{0:#,###}", ROP));
                    dtTop.Rows.Add(str1);
                }
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
                if (rideradb != null || /*currentplandata.rideracdb == 'Y' ||*/ riderterm != null || /*currentplandata.riderci == 'Y' ||*/ customerPlanPartnerInsurance != null)
                {
                    str1 = new String[4];
                    sno++;
                    dtTop.Rows.Add(str1);

                    str1 = new String[4];
                    sno++;
                    str1[0] = sno.ToString();
                    str1[1] = Caption.getCaption("en", "Rider Info:");
                    dtTop.Rows.Add(str1);

                    if (riderterm!=null && riderterm.ridertypecode == "Y")
                    {
                        string temp = "";

                        if (riderterm.type.ToCharArray()[0] == 'U')
                        {
                            temp = " - " + riderterm.term + " Y";
                        }
                        else if (riderterm.type.ToCharArray()[0] == 'Y')
                        {
                            temp = " - " + (riderterm.term + Convert.ToInt32(cust.Age) - 1) + " Y";
                        }
                        else if (riderterm.type.ToCharArray()[0] == 'C')
                        {
                            temp = " - " + (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1) + " Y";
                        }

                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "Ad.Term. Ins.:");
                        str1[3] = (riderterm.amount == 0 ? "" : @class + String.Format("{0:#,###}", riderterm.amount) + temp);
                        dtTop.Rows.Add(str1);
                    }

                    if (customerPlanPartnerInsurance != null)
                    {
                        string temp = "";

                        if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'U')
                        {
                            temp = " - " + customerPlanPartnerInsurance.term + " Y";
                        }
                        else if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'Y')
                        {
                            temp = " - " + (customerPlanPartnerInsurance.term + Convert.ToInt32(cust.Age) - 1) + " Y";
                        }
                        else if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'C')
                        {
                            temp = " - " + (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1) + " Y";
                        }

                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "Spouse Ins.:");
                        str1[3] = (customerPlanPartnerInsurance.amount == 0 ? "" : @class + String.Format("{0:#,###}", customerPlanPartnerInsurance.amount) + temp);
                        dtTop.Rows.Add(str1);
                    }

                    if (rideradb!=null && rideradb.ridertypecode.ToCharArray()[0] == 'Y')
                    {
                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "ADB:");
                        str1[3] = (rideradb.amount == 0 ? "" : @class + String.Format("{0:#,###}", rideradb.amount));// + " - 65 Y"
                        dtTop.Rows.Add(str1);
                    }
                }


                dtTitle.Columns.Add("sno");
                dtTitle.Columns.Add("maincolumn1");
                dtTitle.Columns.Add("maincolumn2");
                dtTitle.Columns.Add("maincolumn3");
                dtTitle.Columns.Add("maincolumn4");

                sno = 0;

                str1 = new String[5];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Period");
                str1[2] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = Caption.getCaption("en", "Accum. Premiums:");
                str1[4] = Caption.getCaption("en", "Insured Amount:");
                dtTitle.Rows.Add(str1);

                sno = 0;

                dtBottom.Columns.Add("sno");
                dtBottom.Columns.Add("maincolumn1");
                dtBottom.Columns.Add("maincolumn2");
                dtBottom.Columns.Add("maincolumn3");
                dtBottom.Columns.Add("maincolumn4");



                int[] length = new int[0];

                if (illdata.Length == 1)
                    length = new int[] { 1 };
                else if (illdata.Length > 1)
                {
                    if (illdata.Length % 5 == 0)
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 1];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                    }
                    else
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 2];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length - 1; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                        length[length.Length - 1] = illdata.Length - 1;
                    }
                }

                for (int i = 0; i < length.Count(); i++)
                {
                    str1 = new String[5];
                    str1[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1); //illdata[length[i]].Sno.ToString();

                    str1[2] = (illdata[length[i]].Totalpremium <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Totalpremium));
                    //str1[2] = (illdata[length[i]].Growthdata[2].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[2].Accountvalue));
                    str1[3] = (illdata[length[i]].Accumulatedpremium <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Accumulatedpremium));
                    //str1[4] = (currentplandata.insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.insuredamount));
                    str1[4] = (illdata[length[i]].Insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Insuredamount));
                    dtBottom.Rows.Add(str1);
                }

                str1[2] = "";
                str1[3] = "";
                str1[4] = "";

                if (length.Count() == 0)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 1)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 2)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);
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
        public static void CalculateTermLS(string @class, WSCustomer cust, productdet plan, DataTable dtTop, DataTable dtTitle, DataTable dtBottom, WSCustomerPlanPartner customerPlanPartnerInsurance, WSCustomerPlan currentplandata, List<string> per, List<WSRider> riderslist)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                double deathbenefit;
                double periodicpremium;
                double targetpremium;
                int contribperiod = currentplandata.contributionperiod;
                string frequency;
                double annualpremium;
                string type;
                //int insuranceTerm;
                //int defermentperiod = Numericdata.getIntegervalue(currentplandata.defermentperiod.ToString());
                //int retirementperiod = Numericdata.getIntegervalue(currentplandata.retirementperiod.ToString());

                IMaintermfixedLS termfixed = new IMaintermfixedLS(cust, currentplandata, riderslist, customerPlanPartnerInsurance);

                if (per.Count != customerPlanNos)
                {
                    per.Add("");
                }
                //txtinsuredamt.Text = termfixed.getInsuredamountFE().ToString("n2");
                //Sessionclass.getSessiondata(Session).insuredamt = txtinsuredamt.Text;
                //txtinsuredamt_TextChanged(null, null);

                //txtannuityamount.Text = (termfixed.annuityamount).ToString("n2");
                periodicpremium = termfixed.calculatedPeriodicPremiumAmount();
                targetpremium = termfixed.getTargetamountFE();
                frequency = Frequencytypes.getfrequencytype(currentplandata.frequencytypecode.ToCharArray()[0]);
                annualpremium = Frequencytypes.getfrequencytypevaluefromcode(currentplandata.frequencytypecode.ToCharArray()[0]) * periodicpremium;
                type = Plantypes.getPlantype(currentplandata.plantypecode.ToCharArray()[0]) == "Insured" ? "Con Seguro" : "Sin Seguro";
                //Sessionclass.getSessiondata(Session).targetdata = termfixed.getTargetamountFE().ToString("n2");

                Termillusdata[] illdata = termfixed.getIllustration();









                int sno = 0;

                String[] str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Plan:");
                str1[3] = plan.product.ToUpper().Trim();
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Name:");
                str1[3] = cust.FirstName + " " + cust.LastName;
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Age:");
                str1[3] = cust.Age.ToString();
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Death Benefit:");
                str1[3] = (currentplandata.insuredamount == 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.insuredamount));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = (@class + String.Format("{0:#,###}", annualpremium));
                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Periodic Premium:");
                str1[3] = (periodicpremium == 0 ? "" : @class + String.Format("{0:#,###}", periodicpremium));
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Payment Frequency:");
                str1[3] = Caption.getCaption("en", frequency);
                dtTop.Rows.Add(str1);

                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Target Premium:");
                str1[3] = (targetpremium == 0 ? "" : @class + String.Format("{0:#,###}", targetpremium));
                dtTop.Rows.Add(str1);

                int contributionPeriod = 0;
                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Cont. Period:");

                if (currentplandata.contributiontypecode.ToCharArray()[0] == Contributiontypes.NUMBEROFYEARS)
                    contributionPeriod = currentplandata.contributionperiod;
                else if (currentplandata.contributiontypecode.ToCharArray()[0] == Contributiontypes.UNTILAGE)
                    contributionPeriod = (currentplandata.contributionuntilage - Numericdata.getIntegervalue(cust.Age.ToString()) + 1);
                else
                    contributionPeriod = (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1);

                if (contributionPeriod == 0)
                    str1[3] = "";
                else if (contributionPeriod == 1)
                    str1[3] = currentplandata.contributionperiod + " " + Caption.getCaption("en", "Year");
                else if (contributionPeriod > 1)
                    str1[3] = currentplandata.contributionperiod + " " + Caption.getCaption("en", "Years");

                dtTop.Rows.Add(str1);


                str1 = new String[4];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Insurance Term:");

                int insuranceTerm = Convert.ToInt32(currentplandata.retirementperiod);

                if (insuranceTerm == 0)
                    str1[3] = "";
                else if (insuranceTerm == 1)
                    str1[3] = insuranceTerm + " " + Caption.getCaption("en", "Year");
                else if (insuranceTerm > 1)
                    str1[3] = insuranceTerm + " " + Caption.getCaption("en", "Years");

                dtTop.Rows.Add(str1);

                if (plan.productcode == "SNT")
                {
                    double ROP = 0;
                    for (int i = 0; i < illdata.Length; i++)
                    {
                        ROP += illdata[i].Totalpremium;
                    }


                    str1 = new String[4];
                    sno++;
                    str1[0] = sno.ToString();
                    str1[1] = Caption.getCaption("en", "Return of Premium:");
                    str1[3] = (ROP == 0 ? "" : @class + String.Format("{0:#,###}", ROP));
                    dtTop.Rows.Add(str1);
                }
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
                if (rideradb != null || /*currentplandata.rideracdb == 'Y' ||*/ riderterm != null || /*currentplandata.riderci == 'Y' ||*/ customerPlanPartnerInsurance != null)
                {
                    str1 = new String[4];
                    sno++;
                    dtTop.Rows.Add(str1);

                    str1 = new String[4];
                    sno++;
                    str1[0] = sno.ToString();
                    str1[1] = Caption.getCaption("en", "Rider Info:");
                    dtTop.Rows.Add(str1);

                    if (riderterm != null && riderterm.ridertypecode == "Y")
                    {
                        string temp = "";

                        if (riderterm.type.ToCharArray()[0] == 'U')
                        {
                            temp = " - " + riderterm.term + " Y";
                        }
                        else if (riderterm.type.ToCharArray()[0] == 'Y')
                        {
                            temp = " - " + (riderterm.term + Convert.ToInt32(cust.Age) - 1) + " Y";
                        }
                        else if (riderterm.type.ToCharArray()[0] == 'C')
                        {
                            temp = " - " + (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1) + " Y";
                        }

                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "Ad.Term. Ins.:");
                        str1[3] = (riderterm.amount == 0 ? "" : @class + String.Format("{0:#,###}", riderterm.amount) + temp);
                        dtTop.Rows.Add(str1);
                    }

                    if (customerPlanPartnerInsurance != null)
                    {
                        string temp = "";

                        if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'U')
                        {
                            temp = " - " + customerPlanPartnerInsurance.term + " Y";
                        }
                        else if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'Y')
                        {
                            temp = " - " + (customerPlanPartnerInsurance.term + Convert.ToInt32(cust.Age) - 1) + " Y";
                        }
                        else if (Convert.ToChar(customerPlanPartnerInsurance.contributiontype) == 'C')
                        {
                            temp = " - " + (Rules.getRulevalueint(Rules.MAX_AGE, currentplandata.productcode, currentplandata.classcode.ToCharArray()[0]) - Numericdata.getIntegervalue(cust.Age.ToString()) + 1) + " Y";
                        }

                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "Spouse Ins.:");
                        str1[3] = (customerPlanPartnerInsurance.amount == 0 ? "" : @class + String.Format("{0:#,###}", customerPlanPartnerInsurance.amount) + temp);
                        dtTop.Rows.Add(str1);
                    }

                    if (rideradb != null && rideradb.ridertypecode.ToCharArray()[0] == 'Y')
                    {
                        str1 = new String[4];
                        sno++;
                        str1[0] = sno.ToString();
                        str1[1] = Caption.getCaption("en", "ADB:");
                        str1[3] = (rideradb.amount == 0 ? "" : @class + String.Format("{0:#,###}", rideradb.amount));// + " - 65 Y"
                        dtTop.Rows.Add(str1);
                    }
                }


                dtTitle.Columns.Add("sno");
                dtTitle.Columns.Add("maincolumn1");
                dtTitle.Columns.Add("maincolumn2");
                dtTitle.Columns.Add("maincolumn3");
                dtTitle.Columns.Add("maincolumn4");

                sno = 0;

                str1 = new String[5];
                sno++;
                str1[0] = sno.ToString();
                str1[1] = Caption.getCaption("en", "Period");
                str1[2] = Caption.getCaption("en", "Annual Premium:");
                str1[3] = Caption.getCaption("en", "Accum. Premiums:");
                str1[4] = Caption.getCaption("en", "Insured Amount:");
                dtTitle.Rows.Add(str1);

                sno = 0;

                dtBottom.Columns.Add("sno");
                dtBottom.Columns.Add("maincolumn1");
                dtBottom.Columns.Add("maincolumn2");
                dtBottom.Columns.Add("maincolumn3");
                dtBottom.Columns.Add("maincolumn4");



                int[] length = new int[0];

                if (illdata.Length == 1)
                    length = new int[] { 1 };
                else if (illdata.Length > 1)
                {
                    if (illdata.Length % 5 == 0)
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 1];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                    }
                    else
                    {
                        int count = illdata.Length / 5;
                        length = new int[count + 2];

                        int j = 5;
                        length[0] = 0;
                        for (int i = 1; i < length.Length - 1; i++)
                        {
                            length[i] = (j - 1);
                            j = j + 5;
                        }
                        length[length.Length - 1] = illdata.Length - 1;
                    }
                }

                for (int i = 0; i < length.Count(); i++)
                {
                    str1 = new String[5];
                    str1[1] = Caption.getCaption("en", "Year") + " " + (length[i] + 1); //illdata[length[i]].Sno.ToString();

                    str1[2] = (illdata[length[i]].Totalpremium <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Totalpremium));
                    //str1[2] = (illdata[length[i]].Growthdata[2].Accountvalue <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Growthdata[2].Accountvalue));
                    str1[3] = (illdata[length[i]].Accumulatedpremium <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Accumulatedpremium));
                    //str1[4] = (currentplandata.insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", currentplandata.insuredamount));
                    str1[4] = (illdata[length[i]].Insuredamount <= 0 ? "" : @class + String.Format("{0:#,###}", illdata[length[i]].Insuredamount));
                    dtBottom.Rows.Add(str1);
                }

                str1[2] = "";
                str1[3] = "";
                str1[4] = "";

                if (length.Count() == 0)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 1";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 1)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 5";
                    dtBottom.Rows.Add(str1);

                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);
                }
                else if (length.Count() == 2)
                {
                    str1[1] = Caption.getCaption("en", "Year") + " 10";
                    dtBottom.Rows.Add(str1);
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
        
        
        public static List<CompareIllus> plandetails1 = new List<CompareIllus>();
        public static List<CompareIllus> planlist1 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails2 = new List<CompareIllus>();
        public static List<CompareIllus> planlist2 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails3 = new List<CompareIllus>();
        public static List<CompareIllus> planlist3 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails4 = new List<CompareIllus>();
        public static List<CompareIllus> planlist4 = new List<CompareIllus>();
        public static List<CompareIllus> planheaderlist = new List<CompareIllus>();
        public static List<CompareIllus> planheaderlisten = new List<CompareIllus>();
        public static List<CompareIllus> planyearlist = new List<CompareIllus>();
        public static bool countpar = true;
        public static bool countpar1 = true;
        public static bool countpar2 = true;
        public static string rptplanname = "";
        public static List<List<CompareIllus>> DisplayReportData()
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                List<List<DataTable>> dtList = dt_compare;

                List<string> dtper = perlist;

                plandetails1 = new List<CompareIllus>();
                planlist1 = new List<CompareIllus>();
                plandetails2 = new List<CompareIllus>();
                planlist2 = new List<CompareIllus>();
                plandetails3 = new List<CompareIllus>();
                planlist3 = new List<CompareIllus>();
                plandetails4 = new List<CompareIllus>();
                planlist4 = new List<CompareIllus>();
                planheaderlist = new List<CompareIllus>();
                planheaderlisten = new List<CompareIllus>();
                planyearlist = new List<CompareIllus>();

                if (dtList != null)
                {
                    planheaderlisten.Add(new CompareIllus("Plan:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Name:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Age:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Total Study Amount / Total Retirement Amount / Death Benefit:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Annual Study Amount / Annual Retirement Amount:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Annual Premium:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Periodic Premium:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Payment Frequency:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Cont. Period:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Inv. Profile:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Min. Premium:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Deferral Period:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Study Period / Retirement Period:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Insurance Term:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Return of Premium:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Ad.Term. Ins.:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("Spouse Ins.:", "", "", ""));
                    planheaderlisten.Add(new CompareIllus("ADB:", "", "", ""));

                    planheaderlist.Add(new CompareIllus("Plan:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Nombre del Asegurado:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Edad:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Monto de Estudio Total / Monto de Retiro Total / Suma Asegurada:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Monto de Estudio Anual / Monto de Retiro Anual:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Prima Anual:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Prima Periódica:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Frequencia de Pago:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Período de Contribución:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Perfil de Inversión:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Prima Mínima:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Período de Diferimiento:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Período de Estudio / Período de Retiro:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Período Asegurado:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Devolución de Primas:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Seguro Temporal Adicional:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Seguro Conyugal/Otro Asegurado:", "", "", ""));
                    planheaderlist.Add(new CompareIllus("Beneficio por Muerte Accidental:", "", "", ""));
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails1.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails2.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails3.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails4.Add(new CompareIllus("", "", "", ""));

                    }

                    //string[] planNos = Request.QueryString["plannos"].Split(',');

                    int count = 0;
                    List<lookupdatadet> investmentprofiledet = (from item in newdb.lookupdatadets
                                                                where item.tablename.Equals("investmentprofiledet")
                                                                select item).ToList();


                    if (dtList.Count > 0)
                    {
                        count++;



                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[0][0].Copy().Rows.Count; i1++)
                            {

                                if (planheaderlisten[i].maincolumn1.ToString().Trim().Contains(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails1.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails1.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));

                                            }
                                        }
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails1.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Plan:"))
                                    {
                                        plandetails1.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtper[0].Equals("") ? dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString() : dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString() + " (" + dtper[0] + ")", "", ""));
                                    }
                                    else
                                    {
                                        plandetails1.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        DataRowCollection dr = dtList[0][1].Copy().Rows;
                        if (dr.Count > 0)
                        {
                            if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                            {
                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist1.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist1.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist1.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                            {

                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist1.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist1.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist1.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                            {
                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist1.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist1.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist1.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                    }
                                }
                            }
                            
                        }
                        rptplanname = dtList[0][0].Copy().Rows[0]["maincolumn3"].ToString();
                    }

                    if (dtList.Count > count)
                    {
                        count++;

                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[1][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails2.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails2.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));

                                            }
                                        }

                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails2.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Plan:"))
                                    {
                                        plandetails2.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtper[1].Equals("") ? dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString() : dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString() + " (" + dtper[1] + ")", "", ""));
                                    }
                                    else
                                    {
                                        plandetails2.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }




                        DataRowCollection dr = dtList[1][1].Copy().Rows;
                        if (dr.Count > 0)
                        {
                            if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist2.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist2.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist2.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist2.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist2.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist2.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                    }
                                }

                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist2.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist2.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist2.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                    }
                                }
                            }
                        }
                        if (plandetails2[0].maincolumn2.ToString() != "")
                        {
                            rptplanname = rptplanname + "," + dtList[1][0].Copy().Rows[0]["maincolumn3"].ToString();
                        }
                    }

                    if (dtList.Count > count)
                    {
                        count++;



                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[2][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails3.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails3.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));
                                            }
                                        }

                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails3.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Plan:"))
                                    {
                                        plandetails3.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtper[2].Equals("") ? dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString() : dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString() + " (" + dtper[2] + ")", "", ""));
                                    }
                                    else
                                    {
                                        plandetails3.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        if (dtList[2][1] != null)
                        {
                            DataRowCollection dr = dtList[2][1].Copy().Rows;
                            if (dr.Count > 0)
                            {
                                if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist3.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist3.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist3.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist3.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist3.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist3.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist3.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist3.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist3.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                        }
                                    }
                                }

                            }
                        }
                        if (plandetails3[0].maincolumn2.ToString() != "")
                        {
                            rptplanname = rptplanname + "," + dtList[2][0].Copy().Rows[0]["maincolumn3"].ToString();
                        }
                    }

                    if (dtList.Count > count)
                    {
                        count++;


                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[3][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails4.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails4.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));
                                            }
                                        }
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails4.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Plan:"))
                                    {
                                        plandetails4.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtper[3].Equals("") ? dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString() : dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString() + " (" + dtper[3] + ")", "", ""));
                                    }
                                    else
                                    {
                                        plandetails4.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        if (dtList[3][1] != null)
                        {
                            DataRowCollection dr = dtList[3][1].Copy().Rows;
                            if (dr.Count > 0)
                            {
                                if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist4.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist4.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist4.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist4.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist4.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist4.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist4.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist4.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist4.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                        }
                                    }
                                }
                            }
                        }
                        if (plandetails4[0].maincolumn2.ToString() != "")
                        {
                            rptplanname = rptplanname + "," + dtList[3][0].Copy().Rows[0]["maincolumn3"].ToString();
                        }
                    }

                    int max = 0;
                    int number = 0;

                    int[] iAr = new int[4];
                    iAr[0] = planlist1.Count();
                    iAr[1] = planlist2.Count();
                    iAr[2] = planlist3.Count();
                    iAr[3] = planlist4.Count();
                    max = iAr.Max();
                    for (int i = 0; i < 4; i++)
                    {
                        if (iAr[i] == max)
                        {
                            number = i;
                        }
                    }
                    if (number == 0)
                    {
                        for (int i = 0; i < planlist1.Count; i++)
                        {

                            planyearlist.Add(new CompareIllus(Caption.getCaption("en", planlist1[i].maincolumn1.ToString()).Contains("Year") ? planlist1[i].maincolumn1.ToString().Replace("Year", "Año") : Caption.getCaption("en", planlist1[i].maincolumn1.ToString()), "", "", ""));

                        }

                    }
                    else if (number == 1)
                    {
                        for (int i = 0; i < planlist2.Count; i++)
                        {

                            planyearlist.Add(new CompareIllus(Caption.getCaption("en", planlist2[i].maincolumn1.ToString()).Contains("Year") ? planlist2[i].maincolumn1.ToString().Replace("Year", "Año") : Caption.getCaption("en", planlist2[i].maincolumn1.ToString()), "", "", ""));

                        }
                    }
                    else if (number == 2)
                    {
                        for (int i = 0; i < planlist3.Count; i++)
                        {

                            planyearlist.Add(new CompareIllus(Caption.getCaption("en", planlist3[i].maincolumn1.ToString()).Contains("Year") ? planlist3[i].maincolumn1.ToString().Replace("Year", "Año") : Caption.getCaption("en", planlist3[i].maincolumn1.ToString()), "", "", ""));

                        }
                    }
                    else if (number == 3)
                    {
                        for (int i = 0; i < planlist4.Count; i++)
                        {
                            planyearlist.Add(new CompareIllus(Caption.getCaption("en", planlist4[i].maincolumn1.ToString()).Contains("Year") ? planlist4[i].maincolumn1.ToString().Replace("Year", "Año") : Caption.getCaption("en", planlist4[i].maincolumn1.ToString()), "", "", ""));


                        }
                    }





                    if (dtList.Count > 2)
                    {
                        countpar = false;
                    }
                    if (dtList.Count > 3)
                    {
                        countpar1 = false;
                    }
                    if (dtList.Count > 4)
                    {
                        countpar2 = false;
                    }
                }
                return new List<List<CompareIllus>> { plandetails1, planlist1, plandetails2, planlist2, plandetails3, planlist3, plandetails4, planlist4, planheaderlist, planyearlist };

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static List<CompareIllus> plandetails11 = new List<CompareIllus>();
        public static List<CompareIllus> planlist11 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails21 = new List<CompareIllus>();
        public static List<CompareIllus> planlist21 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails31 = new List<CompareIllus>();
        public static List<CompareIllus> planlist31 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails41 = new List<CompareIllus>();
        public static List<CompareIllus> planlist41 = new List<CompareIllus>();

        public static bool countparnew1 = true;
        public static bool countpar11 = true;
        public static bool countpar21 = true;
        public static List<List<CompareIllus>> DisplayReportData1()
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                List<List<DataTable>> dtList = dt_compare1;

                plandetails11 = new List<CompareIllus>();
                planlist11 = new List<CompareIllus>();
                plandetails21 = new List<CompareIllus>();
                planlist21 = new List<CompareIllus>();
                plandetails31 = new List<CompareIllus>();
                planlist31 = new List<CompareIllus>();
                plandetails41 = new List<CompareIllus>();
                planlist41 = new List<CompareIllus>();


                if (dtList != null)
                {

                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails11.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails21.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails31.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails41.Add(new CompareIllus("", "", "", ""));

                    }

                    //  string[] planNos = Request.QueryString["plannos"].Split(',');

                    int count = 0;
                    List<lookupdatadet> investmentprofiledet = (from item in newdb.lookupdatadets
                                                                where item.tablename.Equals("investmentprofiledet")
                                                                select item).ToList();



                    if (dtList.Count > 0)
                    {
                        count++;
                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[0][0].Copy().Rows.Count; i1++)
                            {

                                if (planheaderlisten[i].maincolumn1.ToString().Trim().Contains(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails11.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails11.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));

                                            }
                                        }
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails11.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails11.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        DataRowCollection dr = dtList[0][1].Copy().Rows;
                        if (dr.Count > 0)
                        {
                            if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                            {
                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist11.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist11.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist11.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                            {

                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist11.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist11.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist11.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                            {
                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist11.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist11.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist11.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                    }
                                }
                            }
                        }

                    }

                    if (dtList.Count > count)
                    {
                        count++;

                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[1][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails21.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails21.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));

                                            }
                                        }

                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails21.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails21.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }




                        DataRowCollection dr = dtList[1][1].Copy().Rows;
                        if (dr.Count > 0)
                        {
                            if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist21.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist21.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist21.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist21.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist21.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist21.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                    }
                                }

                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist21.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist21.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist21.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                    }
                                }
                            }
                        }

                    }

                    if (dtList.Count > count)
                    {
                        count++;


                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[2][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails31.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails31.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));
                                            }
                                        }

                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails31.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails31.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        if (dtList[2][1] != null)
                        {
                            DataRowCollection dr = dtList[2][1].Copy().Rows;
                            if (dr.Count > 0)
                            {
                                if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist31.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist31.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist31.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist31.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist31.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist31.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist31.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist31.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist31.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                        }
                                    }
                                }
                            }
                        }

                    }

                    if (dtList.Count > count)
                    {
                        count++;

                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[3][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails41.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails41.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));
                                            }
                                        }
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails41.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails41.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        if (dtList[3][1] != null)
                        {
                            DataRowCollection dr = dtList[3][1].Copy().Rows;
                            if (dr.Count > 0)
                            {
                                if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist41.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist41.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist41.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist41.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist41.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist41.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist41.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist41.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist41.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                        }
                                    }
                                }
                            }
                        }

                    }



                    if (dtList.Count > 2)
                    {
                        countparnew1 = false;
                    }
                    if (dtList.Count > 3)
                    {
                        countpar11 = false;
                    }
                    if (dtList.Count > 4)
                    {
                        countpar21 = false;
                    }
                }
                return new List<List<CompareIllus>> { plandetails11, planlist11, plandetails21, planlist21, plandetails31, planlist31, plandetails41, planlist41, };

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static List<CompareIllus> plandetails12 = new List<CompareIllus>();
        public static List<CompareIllus> planlist12 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails22 = new List<CompareIllus>();
        public static List<CompareIllus> planlist22 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails32 = new List<CompareIllus>();
        public static List<CompareIllus> planlist32 = new List<CompareIllus>();
        public static List<CompareIllus> plandetails42 = new List<CompareIllus>();
        public static List<CompareIllus> planlist42 = new List<CompareIllus>();

        public static bool countparnew2 = true;
        public static bool countpar12 = true;
        public static bool countpar22 = true;
        public static List<List<CompareIllus>> DisplayReportData2()
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                List<List<DataTable>> dtList = dt_compare2;

                plandetails12 = new List<CompareIllus>();
                planlist12 = new List<CompareIllus>();
                plandetails22 = new List<CompareIllus>();
                planlist22 = new List<CompareIllus>();
                plandetails32 = new List<CompareIllus>();
                planlist32 = new List<CompareIllus>();
                plandetails42 = new List<CompareIllus>();
                planlist42 = new List<CompareIllus>();


                if (dtList != null)
                {

                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails12.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails22.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails32.Add(new CompareIllus("", "", "", ""));

                    }
                    for (int i = 0; i < planheaderlist.Count; i++)
                    {
                        plandetails42.Add(new CompareIllus("", "", "", ""));

                    }

                    //    string[] planNos = Request.QueryString["plannos"].Split(',');

                    int count = 0;
                    List<lookupdatadet> investmentprofiledet = (from item in newdb.lookupdatadets
                                                                where item.tablename.Equals("investmentprofiledet")
                                                                select item).ToList();

                    if (dtList.Count > 0)
                    {
                        count++;

                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[0][0].Copy().Rows.Count; i1++)
                            {

                                if (planheaderlisten[i].maincolumn1.ToString().Trim().Contains(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails12.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails12.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));

                                            }
                                        }
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails12.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails12.Insert(i, new CompareIllus(dtList[0][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[0][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }


                        DataRowCollection dr = dtList[0][1].Copy().Rows;
                        if (dr.Count > 0)
                        {
                            if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                            {
                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist12.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist12.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist12.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                            {

                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist12.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist12.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist12.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                            {
                                foreach (DataRow row in dtList[0][2].Copy().Rows)
                                {
                                    planlist12.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                }
                                if (dtList[0][1].Copy().Rows.Count == 0)
                                {
                                    planlist12.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[0][1].Copy().Rows)
                                    {
                                        planlist12.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                    }
                                }
                            }

                        }

                    }

                    if (dtList.Count > count)
                    {
                        count++;

                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[1][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails22.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails22.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));

                                            }
                                        }

                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails22.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails22.Insert(i, new CompareIllus(dtList[1][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[1][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }



                        DataRowCollection dr = dtList[1][1].Copy().Rows;
                        if (dr.Count > 0)
                        {
                            if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist22.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist22.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist22.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                    }
                                }
                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist22.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist22.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist22.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                    }
                                }

                            }
                            else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                            {
                                foreach (DataRow row in dtList[1][2].Copy().Rows)
                                {
                                    planlist22.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                }
                                if (dtList[1][1].Copy().Rows.Count == 0)
                                {
                                    planlist22.Clear();
                                }
                                else
                                {
                                    foreach (DataRow row in dtList[1][1].Copy().Rows)
                                    {
                                        planlist22.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                    }
                                }
                            }
                        }

                    }

                    if (dtList.Count > count)
                    {
                        count++;

                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[2][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails32.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails32.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));
                                            }
                                        }

                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails32.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails32.Insert(i, new CompareIllus(dtList[2][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[2][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }



                        if (dtList[2][1] != null)
                        {
                            DataRowCollection dr = dtList[2][1].Copy().Rows;
                            if (dr.Count > 0)
                            {
                                if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist32.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist32.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist32.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist32.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist32.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist32.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                                {
                                    foreach (DataRow row in dtList[2][2].Copy().Rows)
                                    {
                                        planlist32.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                    }
                                    if (dtList[2][1].Copy().Rows.Count == 0)
                                    {
                                        planlist32.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[2][1].Copy().Rows)
                                        {
                                            planlist32.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                        }
                                    }
                                }
                            }
                        }

                    }

                    if (dtList.Count > count)
                    {
                        count++;
                        for (int i = 0; i < planheaderlist.Count; i++)
                        {
                            for (int i1 = 0; i1 < dtList[3][0].Copy().Rows.Count; i1++)
                            {
                                if (planheaderlisten[i].maincolumn1.ToString().Contains(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "")) && dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString().Replace(":", "") != "")
                                {
                                    plandetails42.RemoveAt(i);
                                    if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Inv. Profile:"))
                                    {
                                        foreach (lookupdatadet s in investmentprofiledet)
                                        {
                                            if (s.lookupcaption.Equals(dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString()))
                                            {
                                                plandetails42.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), s.spanish, "", ""));
                                            }
                                        }
                                    }
                                    else if (planheaderlisten[i].maincolumn1.ToString().Trim().Equals("Payment Frequency:"))
                                    {
                                        plandetails42.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), Caption.getCaption("en", dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("US$ ", "").Replace("€", "").Replace("RD$ ", "")), "", ""));
                                    }
                                    else
                                    {
                                        plandetails42.Insert(i, new CompareIllus(dtList[3][0].Copy().Rows[i1]["maincolumn1"].ToString(), dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Contains("Years") ? dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString().Replace("Years", "Años") : dtList[3][0].Copy().Rows[i1]["maincolumn3"].ToString(), "", ""));
                                    }

                                }

                            }
                        }



                        if (dtList[3][1] != null)
                        {
                            DataRowCollection dr = dtList[3][1].Copy().Rows;
                            if (dr.Count > 0)
                            {
                                if (dr[1]["maincolumn2"].ToString().Contains("US$"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist42.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(US$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(US$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(US$)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist42.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist42.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("US$ ", ""), row["maincolumn3"].ToString().Replace("US$ ", ""), row["maincolumn4"].ToString().Replace("US$ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("€"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist42.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(€)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(€)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(€)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist42.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist42.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("€ ", ""), row["maincolumn3"].ToString().Replace("€ ", ""), row["maincolumn4"].ToString().Replace("€ ", "")));
                                        }
                                    }
                                }
                                else if (dr[1]["maincolumn2"].ToString().Contains("RD$"))
                                {
                                    foreach (DataRow row in dtList[3][2].Copy().Rows)
                                    {
                                        planlist42.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn2"].ToString()) + "\n(RD$)", row["maincolumn3"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn3"].ToString()) + "\n(RD$)", row["maincolumn4"].ToString().Equals("") ? "" : Caption.getCaption("en", row["maincolumn4"].ToString()) + "\n(RD$)"));
                                    }
                                    if (dtList[3][1].Copy().Rows.Count == 0)
                                    {
                                        planlist42.Clear();
                                    }
                                    else
                                    {
                                        foreach (DataRow row in dtList[3][1].Copy().Rows)
                                        {
                                            planlist42.Add(new CompareIllus(row["maincolumn1"].ToString(), row["maincolumn2"].ToString().Replace("RD$ ", ""), row["maincolumn3"].ToString().Replace("RD$ ", ""), row["maincolumn4"].ToString().Replace("RD$ ", "")));
                                        }
                                    }
                                }
                            }
                        }

                    }



                    if (dtList.Count > 2)
                    {
                        countparnew2 = false;
                    }
                    if (dtList.Count > 3)
                    {
                        countpar12 = false;
                    }
                    if (dtList.Count > 4)
                    {
                        countpar22 = false;
                    }
                }
                return new List<List<CompareIllus>> { plandetails12, planlist12, plandetails22, planlist22, plandetails32, planlist32, plandetails42, planlist42 };

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static byte[] showIllustrationLife(WSLifeResult liferesult, WSCustomer customer, WSCustomerPlan customerplan, IMainInsuranceData insmaindata, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            String productcode = "";
            try
            {
                rpt.LocalReport.Refresh();
                rpt.Reset();
                string PlanName = Productdata.getProduct(customerplan.productcode);
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/bin/IllustrationReport.rdlc");

                DateTime d = DateTime.Now;
                string meng = d.ToString("MMMM");
                string msp = "";
                if (meng == "January")
                {
                    msp = "enero";
                }
                else if (meng == "Febuary")
                {
                    msp = "febrero";
                }
                else if (meng == "March")
                {
                    msp = "marzo";
                }
                else if (meng == "April")
                {
                    msp = "abril";
                }
                else if (meng == "May")
                {
                    msp = "mayo";
                }
                else if (meng == "June")
                {
                    msp = "junio";
                }
                else if (meng == "July")
                {
                    msp = "julio";
                }
                else if (meng == "August")
                {
                    msp = "agosto";
                }
                else if (meng == "September")
                {
                    msp = "septiembre";
                }
                else if (meng == "October")
                {
                    msp = "octubre";
                }
                else if (meng == "November")
                {
                    msp = "noviembre";
                }
                else if (meng == "December")
                {
                    msp = "diciembre";
                }

                ReportParameter param5 = new ReportParameter("date", d.Day.ToString() + " de " + msp + " del " + d.Year.ToString());

                List<List<CompareIllus>> clslist = DisplayReportData();
                List<List<CompareIllus>> clslist1 = new List<List<CompareIllus>>();
                List<List<CompareIllus>> clslist2 = new List<List<CompareIllus>>();
                if (dt_compare1 != null)
                {
                    clslist1 = DisplayReportData1();
                }
                if (dt_compare2 != null)
                {
                    clslist2 = DisplayReportData2();
                }

                ReportParameter param125 = new ReportParameter("plannames", rptplanname);
                ReportParameter param126 = new ReportParameter("count", "" + countpar);
                ReportParameter param127 = new ReportParameter("count1", "" + countpar1);
                ReportParameter param128 = new ReportParameter("count2", "" + countpar2);


                ReportParameter param129 = new ReportParameter("countnew", "" + countparnew1);
                ReportParameter param130 = new ReportParameter("count11", "" + countpar11);
                ReportParameter param131 = new ReportParameter("count21", "" + countpar21);

                ReportParameter param132 = new ReportParameter("countnew1", "" + countparnew2);
                ReportParameter param133 = new ReportParameter("count12", "" + countpar12);
                ReportParameter param134 = new ReportParameter("count22", "" + countpar22);

                ReportParameter param135;
                if (rptplanname.Contains("COMPASS INDEX") || rptplanname.Contains("LEGACY"))
                {
                    param135 = new ReportParameter("pagecount", "" + false);
                }
                else
                {
                    param135 = new ReportParameter("pagecount", "" + true);
                }

                ReportParameter param136 = new ReportParameter("hidepar1", "" + false);
                ReportParameter param137 = new ReportParameter("hidepar2", "" + false);
                ReportParameter param138 = new ReportParameter("hidepar3", "" + false);
                ReportParameter param139 = new ReportParameter("hidepar4", "" + false);

                var invp = Invprofiledata.getInvestmentprofile(customerplan.investmentprofilecode.ToCharArray()[0]);

                string ddlfingoal = "-";
                string ddlinitialcontribution = "-";
                string initialcontributionamount = "-";
                string ddlinvestprofile = "-";
                string txtsumannualpremium = "-";
                string initialcomission = "-";
                string crticleillnessamount = "-";
                string freqofpayment = "-";
                string plantype = "-";
                string almillar = "-";
                string risk = "-";
                string investmentprofile = "-";
                string maritalstatus = "-";
                string fingoalamount = "-";

                if (customerplan != null)
                {
                    investmentprofile = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, Invprofiledata.getInvestmentprofile(customerplan.investmentprofilecode.ToCharArray()[0]), "es");

                }
                if (customerplan != null)
                {
                    if (customerplan.frequencytypecode != null)
                    {
                        freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");

                    }
                    if (customerplan.financialgoal != null)
                    {
                        if (customerplan.financialgoal == "Y")
                        {
                            ddlfingoal = "Yes";
                        }
                        if (customerplan.financialgoal == "N")
                        {
                            ddlfingoal = "No";
                        }
                    }

                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            ddlinitialcontribution = "Yes";
                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            ddlinitialcontribution = "No";

                        }
                    }

                    if (customerplan.investmentprofilecode != null)
                    {
                        ddlinvestprofile = Invprofiledata.getInvestmentprofile(customerplan.investmentprofilecode.ToCharArray()[0]);
                    }

                    if (liferesult.annualpremiumamount != null)
                    {
                        txtsumannualpremium = liferesult.annualpremiumamount.ToString();
                    }

                    crticleillnessamount = "";



                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");

                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");



                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");


                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");


                    if (customerplan.financialgoalamount != null)
                    {
                        fingoalamount = customerplan.financialgoalamount.ToString();
                    }


                }

                // initialcomission = customerplan.initialcommission.ToString();

                string rideroiramt = "-";
                string rideroirname = "-";
                string Riesgo = "-";
                string Fumador = "-";
                string Sexo = "-";
                string HastalaEdadde = "-";
                string Edad = "-";
                string AlMillar1 = "-";

                if (partins != null)
                {
                    rideroiramt = partins.amount.ToString();
                    rideroirname = partins.firstname + " " + partins.middlename + " " + partins.lastname + " " + partins.LastName2;

                    Riesgo = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(partins.activityrisktypeno), "es");



                    Fumador = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(partins.smoker.ToCharArray()[0]), "es");
                    Sexo = partins.gendercode.ToString();//Genders.getgender(partins.gendercode.ToString().ToCharArray()[0]);

                    if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS))
                        HastalaEdadde = "99";
                    else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS))
                        HastalaEdadde = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                    else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE))
                        HastalaEdadde = partins.term.ToString();

                    Edad = partins.age.ToString();



                    AlMillar1 = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es");

                }
                //primary
                string primaryreq = "-", otherreq = "-";

                List<WSExam> exams = liferesult.primaryexamsrequiredlist;
                String[] req = new String[exams.Count()];

                int i = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                    req[i] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    i++;
                }

                string tempPrimary = " ";
                int lno1 = 0;

                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                        {
                            tempPrimary += req[j];
                            if (j != (req.Length - 1))
                            {
                                tempPrimary += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t";
                            }
                            if (tempPrimary.Length > (lno1 + 1) * 150)
                            {
                                tempPrimary += Environment.NewLine;
                                lno1 = lno1 + 1;
                            }

                        }
                }
                //other

                exams = liferesult.partnerexamsrequiredlist;
                String[] oreq = new String[exams.Count()];

                int k = 0;
                foreach (WSExam exam in exams)
                {

                    otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + otherreq;

                    oreq[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    k++;
                }


                List<ReportParameter> paramlist = new List<ReportParameter>();
                ReportParameter param8 = new ReportParameter("name", customer.FirstName + " " + customer.LastName);
                ReportParameter param58 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días unicamente y en  ningún caso más allá del 31/12/" + DateTime.Now.Year + " (v10)");

                string tempOther = " ";
                if (partins != null)
                {

                    for (int j = 0; j < oreq.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(oreq[j]))
                            if (!oreq[j].Trim().Equals(""))
                                tempOther += oreq[j] + ", ";
                    }
                }
                if (tempOther.Trim().Length > 0)
                    tempOther = tempOther.Substring(0, tempOther.Length - 2);

                paramlist.Add(param5);
                paramlist.Add(param58);

                paramlist.Add(param8);
                paramlist.Add(param125);
                paramlist.Add(param126);
                paramlist.Add(param127);
                paramlist.Add(param128);
                paramlist.Add(param129);
                paramlist.Add(param130);
                paramlist.Add(param131);
                paramlist.Add(param132);
                paramlist.Add(param133);
                paramlist.Add(param134);
                paramlist.Add(param135);
                paramlist.Add(param136);
                paramlist.Add(param137);
                paramlist.Add(param138);
                paramlist.Add(param139);

                string contributionPeriod = "-";

                if (customerplan.contributiontypecode.Equals(Contributiontypes.CONTINUOUS))
                    contributionPeriod = (99 - Convert.ToInt32(customer.Age) + 1).ToString();
                else if (customerplan.contributiontypecode.Equals(Contributiontypes.UNTILAGE))
                    contributionPeriod = (customerplan.contributionuntilage - Convert.ToInt32(customer.Age) + 1).ToString();
                else if (customerplan.contributiontypecode.Equals(Contributiontypes.NUMBEROFYEARS))
                    contributionPeriod = customerplan.contributionperiod.ToString();

                if (contributionPeriod.Equals("0"))
                    contributionPeriod = "-";
                string Prospect = customer.FirstName + " " + customer.LastName;

                string untilAge = "-";
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

                if (riderterm != null)
                {
                    if (riderterm.type.Equals(Contributiontypes.CONTINUOUS))
                        untilAge = "99";
                    else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                    else if (riderterm.type.Equals(Contributiontypes.UNTILAGE))
                        untilAge = riderterm.term.ToString();
                }

                //  ReportParameter paramAdditionalTermUntilAge = new ReportParameter("AdditionalTermUntilAge", untilAge);
                //  paramlist.Add(paramAdditionalTermUntilAge);

                maritalstatus = "-";

                if (partins != null)
                {
                    maritalstatus = Maritalstatus.getmaritalstatus(Convert.ToString(partins.maritalstatuscode));

                    lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                             where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatus)
                                             select item).SingleOrDefault();
                    if (mstatus != null)
                        maritalstatus = mstatus.spanish;
                }
                //    ReportParameter paramSpouseMaritalStatus = new ReportParameter("SpouseMaritalStatus", maritalstatus);
                //   paramlist.Add(paramSpouseMaritalStatus);

                rpt.LocalReport.SetParameters(paramlist);
                // rpt.LocalReport.DataSources.Add(rds);
                if (clslist != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails1", clslist[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist1", clslist[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails2", clslist[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist2", clslist[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails3", clslist[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist3", clslist[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails4", clslist[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist4", clslist[7]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planheaderlist", clslist[8]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planyearlist", clslist[9]));


                }
                if (clslist1 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails5", clslist1[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist5", clslist1[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails6", clslist1[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist6", clslist1[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails7", clslist1[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist7", clslist1[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails8", clslist1[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist8", clslist1[7]));

                }
                if (clslist2 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails9", clslist2[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist9", clslist2[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails10", clslist2[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist10", clslist2[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails11", clslist2[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist11", clslist2[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails12", clslist2[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist12", clslist2[7]));

                }
                rpt.LocalReport.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //  newdb.Dispose();
            }
            return bytes;
        }

        public static byte[] showIllustrationRED(WSAnnuityResult annuityresult, WSCustomer customer, WSCustomerPlan customerplan, IMaineduretire eduretire)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            String productcode = "";
            try
            {
                //rpt.Clear();
                rpt.LocalReport.Refresh();
                rpt.Reset();
                string PlanName = Productdata.getProduct(customerplan.productcode);
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/bin/IllustrationReport.rdlc");

                string defermentperiod = "-";
                string contributionperiod = "-";
                string ddlinitialcontribution = "-";
                string initialcontributionamount = "-";
                string txtsumannualpremium = "-";
                string risk = "-";
                string almillar = "-";
                string plantype = "-";
                string maritalstatus = "-";
                string investmentprofile = "-";
                string freqofpayment = "-";


                investmentprofile = (from item in newdb.investmentprofiledets
                                     where item.investmentprofilecode.Equals(customerplan.investmentprofilecode)
                                     select item.investmentprofile).SingleOrDefault();
                investmentprofile = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, investmentprofile, "es");

                if (customerplan != null)
                {
                    //ruleclasscode = customerplan.classcode.ToCharArray()[0];
                    if (customerplan.frequencytypecode != null)
                    {
                        freqofpayment = Lookuplangdata.getEnglishvalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");
                    }
                    if (customerplan.defermentperiod != null)
                    {
                        defermentperiod = customerplan.defermentperiod.ToString();
                    }
                    if (customerplan.contributionperiod != null)
                    {
                        contributionperiod = customerplan.contributionperiod.ToString();
                    }

                    if (annuityresult.annualpremiumamount != null)
                    {
                        txtsumannualpremium = annuityresult.annualpremiumamount.ToString();
                    }


                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            ddlinitialcontribution = "Yes";
                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            ddlinitialcontribution = "No";
                            initialcontributionamount = "0";

                        }
                    }
                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet,
                                                            Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");


                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet,
                                                            Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");

                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet,
                                                            Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");

                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet,
                                                            Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");
                }
                string primaryreq = "";

                List<WSExam> exams = annuityresult.primaryexamsrequiredlist;
                String[] req = new String[12];

                int examno = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname.ToUpper(), "es") + "/" + primaryreq;
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }
                string tempPrimary = " ";

                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                            tempPrimary += req[j] + ", ";
                }

                if (tempPrimary.Trim().Length > 0)
                    tempPrimary = tempPrimary.Substring(0, tempPrimary.Length - 2);

                List<ReportParameter> paramlist = new List<ReportParameter>();


                string Prospect = customer.FirstName + " " + customer.LastName;


                // ReportParameter param1 = new ReportParameter("heading", customer.FirstName + " " + customer.LastName);

                DateTime d = DateTime.Now;
                string meng = d.ToString("MMMM");
                string msp = "";
                if (meng == "January")
                {
                    msp = "enero";
                }
                else if (meng == "Febuary")
                {
                    msp = "febrero";
                }
                else if (meng == "March")
                {
                    msp = "marzo";
                }
                else if (meng == "April")
                {
                    msp = "abril";
                }
                else if (meng == "May")
                {
                    msp = "mayo";
                }
                else if (meng == "June")
                {
                    msp = "junio";
                }
                else if (meng == "July")
                {
                    msp = "julio";
                }
                else if (meng == "August")
                {
                    msp = "agosto";
                }
                else if (meng == "September")
                {
                    msp = "septiembre";
                }
                else if (meng == "October")
                {
                    msp = "octubre";
                }
                else if (meng == "November")
                {
                    msp = "noviembre";
                }
                else if (meng == "December")
                {
                    msp = "diciembre";
                }

                ReportParameter param2 = new ReportParameter("date", d.Day.ToString() + " de " + msp + " del " + d.Year.ToString());

                ReportParameter param3 = new ReportParameter("name", customer.FirstName + " " + customer.LastName);

                ReportParameter param46 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días unicamente y en  ningún caso más allá del 31/12/" + DateTime.Now.Year + " (v10)");
                //ReportParameter param47 = new ReportParameter("number", GetReportNumber());
                List<List<CompareIllus>> clslist = DisplayReportData();
                List<List<CompareIllus>> clslist1 = new List<List<CompareIllus>>();
                List<List<CompareIllus>> clslist2 = new List<List<CompareIllus>>();
                if (dt_compare1 != null)
                {
                    clslist1 = DisplayReportData1();
                }
                if (dt_compare2 != null)
                {
                    clslist2 = DisplayReportData2();
                }

                ReportParameter param48 = new ReportParameter("plannames", rptplanname);
                ReportParameter param49 = new ReportParameter("count", "" + countpar);
                ReportParameter param50 = new ReportParameter("count1", "" + countpar1);
                ReportParameter param51 = new ReportParameter("count2", "" + countpar2);

                ReportParameter param52 = new ReportParameter("countnew", "" + countparnew1);
                ReportParameter param53 = new ReportParameter("count11", "" + countpar11);
                ReportParameter param54 = new ReportParameter("count21", "" + countpar21);

                ReportParameter param55 = new ReportParameter("countnew1", "" + countparnew2);
                ReportParameter param56 = new ReportParameter("count12", "" + countpar12);
                ReportParameter param57 = new ReportParameter("count22", "" + countpar22);

                ReportParameter param58;
                if (rptplanname.Contains("COMPASS INDEX") || rptplanname.Contains("LEGACY"))
                {
                    param58 = new ReportParameter("pagecount", "" + false);
                }
                else
                {
                    param58 = new ReportParameter("pagecount", "" + true);
                }

                ReportParameter param59 = new ReportParameter("hidepar1", "" + false);
                ReportParameter param60 = new ReportParameter("hidepar2", "" + false);
                ReportParameter param61 = new ReportParameter("hidepar3", "" + false);
                ReportParameter param62 = new ReportParameter("hidepar4", "" + false);


                paramlist.Add(param2);
                paramlist.Add(param3);

                paramlist.Add(param46);

                paramlist.Add(param48);
                paramlist.Add(param49);
                paramlist.Add(param50);
                paramlist.Add(param51);
                paramlist.Add(param52);
                paramlist.Add(param53);
                paramlist.Add(param54);
                paramlist.Add(param55);
                paramlist.Add(param56);
                paramlist.Add(param57);
                paramlist.Add(param58);
                paramlist.Add(param59);
                paramlist.Add(param60);
                paramlist.Add(param61);
                paramlist.Add(param62);

                string studentname = "-";
                if (!string.IsNullOrEmpty(customerplan.studentname))
                {
                    if (!customerplan.studentname.Trim().Equals(""))
                    {
                        studentname = customerplan.studentname;
                    }
                }

                string studentage = "-";
                if ((object)customerplan.studentage != null)
                {
                    if (customerplan.studentage != 0)
                    {
                        studentage = customerplan.studentage.ToString();
                    }
                }
                rpt.LocalReport.SetParameters(paramlist);
                if (clslist != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails1", clslist[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist1", clslist[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails2", clslist[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist2", clslist[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails3", clslist[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist3", clslist[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails4", clslist[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist4", clslist[7]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planheaderlist", clslist[8]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planyearlist", clslist[9]));

                }
                if (clslist1 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails5", clslist1[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist5", clslist1[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails6", clslist1[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist6", clslist1[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails7", clslist1[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist7", clslist1[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails8", clslist1[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist8", clslist1[7]));

                }
                if (clslist2 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails9", clslist2[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist9", clslist2[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails10", clslist2[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist10", clslist2[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails11", clslist2[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist11", clslist2[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails12", clslist2[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist12", clslist2[7]));

                }
                rpt.LocalReport.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // newdb.Dispose();
            }
            return bytes;
        }

        public static byte[] showIllustrationREDfixed(WSAnnuityResult annuityresult, WSCustomer customer, WSCustomerPlan customerplan, IMaineduretirefixed eduretirefixed)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            String productcode = "";

            try
            {
                rpt.LocalReport.Refresh();
                rpt.Reset();
                string PlanName = Productdata.getProduct(customerplan.productcode);
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/bin/IllustrationReport.rdlc");


                string investmentprofile = (from item in newdb.investmentprofiledets
                                            where item.investmentprofilecode.Equals(customerplan.investmentprofilecode)
                                            select item.investmentprofile).SingleOrDefault();
                investmentprofile = Lookuplangdata.getLanguagevalue(Lookuptables.investmentprofiledet, investmentprofile, "es");

                string defermentperiod = "-";
                string contributionperiod = "-";
                string initialcontributionamount = "-";
                string intialcontribution = "-";
                string txtsumannualpremium = "-";
                string ageatretirement = "-";
                string risk = "-";
                string almillar = "-";
                string plantype = "-";
                string maritalstatus = "-";
                string freqofpayment = "-";

                if (customerplan != null)
                {
                    // ruleclasscode = customerplan.classcode.ToCharArray()[0];
                    if (customerplan.frequencytypecode != null)
                    {
                        freqofpayment = Lookuplangdata.getEnglishvalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");
                    }
                    if (customerplan.defermentperiod != null)
                    {
                        defermentperiod = customerplan.defermentperiod.ToString();
                    }
                    if (customerplan.contributionperiod != null)
                    {
                        contributionperiod = customerplan.contributionperiod.ToString();
                    }

                    if (annuityresult.annualpremiumamount != null)
                    {
                        txtsumannualpremium = annuityresult.annualpremiumamount.ToString();
                    }
                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            intialcontribution = "Yes";
                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            intialcontribution = "No";
                            initialcontributionamount = "0";

                        }
                    }
                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet,
                                                            Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");


                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet,
                                                            Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");

                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet,
                                                            Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");

                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet,
                                                            Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");

                    ageatretirement = (Numericdata.getIntegervalue(customerplan.defermentperiod.ToString()) + Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + Numericdata.getIntegervalue(customer.Age.ToString())).ToString();


                }
                string primaryreq = "";

                List<WSExam> exams = annuityresult.primaryexamsrequiredlist;
                String[] req = new String[12];

                int examno = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname.ToUpper(), "es") + "/" + primaryreq;
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, exam.examname, "es");
                    examno++;
                }
                string tempPrimary = " ";

                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                            tempPrimary += req[j] + ", ";
                }

                if (tempPrimary.Trim().Length > 0)
                    tempPrimary = tempPrimary.Substring(0, tempPrimary.Length - 2);




                List<ReportParameter> paramlist = new List<ReportParameter>();

                string Prospect = customer.FirstName + " " + customer.LastName;
                //ReportParameter param1 = new ReportParameter("heading", customer.FirstName + " " + customer.LastName);

                DateTime d = DateTime.Now;
                string meng = d.ToString("MMMM");
                string msp = "";
                if (meng == "January")
                {
                    msp = "enero";
                }
                else if (meng == "Febuary")
                {
                    msp = "febrero";
                }
                else if (meng == "March")
                {
                    msp = "marzo";
                }
                else if (meng == "April")
                {
                    msp = "abril";
                }
                else if (meng == "May")
                {
                    msp = "mayo";
                }
                else if (meng == "June")
                {
                    msp = "junio";
                }
                else if (meng == "July")
                {
                    msp = "julio";
                }
                else if (meng == "August")
                {
                    msp = "agosto";
                }
                else if (meng == "September")
                {
                    msp = "septiembre";
                }
                else if (meng == "October")
                {
                    msp = "octubre";
                }
                else if (meng == "November")
                {
                    msp = "noviembre";
                }
                else if (meng == "December")
                {
                    msp = "diciembre";
                }

                ReportParameter param2 = new ReportParameter("date", d.Day.ToString() + " de " + msp + " del " + d.Year.ToString());

                ReportParameter param3 = new ReportParameter("name", customer.FirstName + " " + customer.LastName);

                ReportParameter param47 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días unicamente y en  ningún caso más allá del 31/12/" + DateTime.Now.Year + " (v10)");

                List<List<CompareIllus>> clslist = DisplayReportData();
                List<List<CompareIllus>> clslist1 = new List<List<CompareIllus>>();
                List<List<CompareIllus>> clslist2 = new List<List<CompareIllus>>();
                if (dt_compare1 != null)
                {
                    clslist1 = DisplayReportData1();
                }
                if (dt_compare2 != null)
                {
                    clslist2 = DisplayReportData2();
                }
                ReportParameter param49 = new ReportParameter("plannames", rptplanname);
                ReportParameter param50 = new ReportParameter("count", "" + countpar);
                ReportParameter param51 = new ReportParameter("count1", "" + countpar1);
                ReportParameter param52 = new ReportParameter("count2", "" + countpar2);

                ReportParameter param53 = new ReportParameter("countnew", "" + countparnew1);
                ReportParameter param54 = new ReportParameter("count11", "" + countpar11);
                ReportParameter param55 = new ReportParameter("count21", "" + countpar21);

                ReportParameter param56 = new ReportParameter("countnew1", "" + countparnew2);
                ReportParameter param57 = new ReportParameter("count12", "" + countpar12);
                ReportParameter param58 = new ReportParameter("count22", "" + countpar22);

                ReportParameter param59;
                if (rptplanname.Contains("COMPASS INDEX") || rptplanname.Contains("LEGACY"))
                {
                    param59 = new ReportParameter("pagecount", "" + false);
                }
                else
                {
                    param59 = new ReportParameter("pagecount", "" + true);
                }
                ReportParameter param60 = new ReportParameter("hidepar1", "" + false);
                ReportParameter param61 = new ReportParameter("hidepar2", "" + false);
                ReportParameter param62 = new ReportParameter("hidepar3", "" + false);
                ReportParameter param63 = new ReportParameter("hidepar4", "" + false);

                paramlist.Add(param2);
                paramlist.Add(param3);
                paramlist.Add(param50);
                paramlist.Add(param51);
                paramlist.Add(param52);
                paramlist.Add(param53);
                paramlist.Add(param54);
                paramlist.Add(param55);
                paramlist.Add(param56);
                paramlist.Add(param57);
                paramlist.Add(param58);
                paramlist.Add(param59);
                paramlist.Add(param60);
                paramlist.Add(param61);
                paramlist.Add(param62);
                paramlist.Add(param63);

                paramlist.Add(param47);
                paramlist.Add(param49);
                string studentname = "-";
                if (!string.IsNullOrEmpty(customerplan.studentname))
                {
                    if (!customerplan.studentname.Trim().Equals(""))
                    {
                        studentname = customerplan.studentname;
                    }
                }

                string studentage = "-";
                if ((object)customerplan.studentage != null)
                {
                    if (customerplan.studentage != 0)
                    {
                        studentage = customerplan.studentage.ToString();
                    }
                }


                rpt.LocalReport.SetParameters(paramlist);
                if (clslist != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails1", clslist[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist1", clslist[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails2", clslist[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist2", clslist[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails3", clslist[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist3", clslist[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails4", clslist[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist4", clslist[7]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planheaderlist", clslist[8]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planyearlist", clslist[9]));

                }
                if (clslist1 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails5", clslist1[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist5", clslist1[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails6", clslist1[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist6", clslist1[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails7", clslist1[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist7", clslist1[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails8", clslist1[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist8", clslist1[7]));

                }
                if (clslist2 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails9", clslist2[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist9", clslist2[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails10", clslist2[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist10", clslist2[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails11", clslist2[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist11", clslist2[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails12", clslist2[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist12", clslist2[7]));

                }
                rpt.LocalReport.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // newdb.Dispose();
            }

            return bytes;
        }

        public static byte[] showIllustrationTERMfixed(WSTermResult termresult, WSCustomer customer, WSCustomerPlan customerplan, IMaintermfixed termfixed, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            String productcode = "";
            try
            {

                rpt.LocalReport.Refresh();
                rpt.Reset();

                string PlanName = Productdata.getProduct(customerplan.productcode);
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/bin/IllustrationReport.rdlc");

                string spouseinsuredamt = "-";
                if (partins != null)
                {
                    if (partins.amount != null)
                    {
                        spouseinsuredamt = partins.amount.ToString();
                    }

                }

                string contributionperiod = "-";
                string termamount = "-";
                string calculate = "-";
                string freqofpayment = "-";
                string rideradbamount = "-";
                string annualizepremium = "-";
                string initialcontributionamount = "-";
                string ddlinitialcontribution = "-";
                string premiumamount = "-";
                string insuredamount = "-";
                string crticleillnessamount = "-";
                string maritalstatus = "-";
                string plantype = "-";
                string almillar = "-";
                string risk = "-";
                string rawreturn = "-";
                string culminationage = "-";

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
                if (customerplan != null)
                {
                    if (customerplan.contributionperiod != null)
                    {
                        contributionperiod = customerplan.contributionperiod.ToString();
                    }
                    if (rideradb != null && rideradb.amount != null)
                    {
                        rideradbamount = rideradb.amount.ToString();

                    }
                    if (riderterm != null && riderterm.amount != null)
                    {
                        termamount = riderterm.amount.ToString();
                    }
                    if (customerplan.calculatetypecode != null)
                    {
                        calculate = Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypedet, Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]), "es");
                    }
                    if (customerplan.frequencytypecode != null)
                    {
                        // freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language);
                        freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");

                    }
                    if (customerplan.premiumamount != null)
                    {
                        annualizepremium = termresult.annualpremiumamount.ToString();
                    }

                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {

                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            initialcontributionamount = "0";
                        }
                    }
                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es");
                        }
                        else
                        {
                            ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es");

                        }
                    }
                    if (customerplan.premiumamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.premiumamount.ToString()) > 0)
                        {
                            premiumamount = customerplan.premiumamount.ToString();
                        }
                        else
                        {
                            premiumamount = "0";
                        }
                    }
                    if (customerplan.insuredamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.insuredamount.ToString()) > 0)
                        {
                            insuredamount = customerplan.insuredamount.ToString();
                        }
                        else
                        {
                            insuredamount = "0";
                        }
                    }


                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");

                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");


                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");



                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");


                    rawreturn = (Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()) + Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]) * customerplan.contributionperiod * Numericdata.getDecimalvalue(customerplan.premiumamount.ToString())).ToString("n2");

                    culminationage = (Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + customer.Age - 1).ToString();



                }
                //

                string rideroiramt = "-";
                string rideroirname = "-";
                string Riesgo = "-";
                string Fumador = "-";
                string Sexo = "-";
                string HastalaEdadde = "-";
                string Edad = "-";
                string AlMillar1 = "-";

                if (partins != null)
                {

                    rideroiramt = partins.amount.ToString("n2");
                    rideroirname = partins.firstname + " " + partins.middlename + " " + partins.lastname + " " + partins.LastName2;

                    Fumador = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(partins.smoker.ToCharArray()[0]), "es");
                    Sexo = partins.gendercode.ToString();

                    if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS))
                        HastalaEdadde = "99";
                    else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS))
                        HastalaEdadde = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                    else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE))
                        HastalaEdadde = partins.term.ToString();

                    Edad = partins.age.ToString();

                    Riesgo = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(partins.activityrisktypeno), "es");

                    AlMillar1 = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es");


                }
                //primary
                string primaryreq = "-", otherreq = "-";

                List<WSExam> exams = termresult.primaryexamsrequiredlist;

                String[] req = new String[20];

                int examno = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    examno++;
                }

                string tempPrimary = " ";
                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                            tempPrimary += req[j] + ", ";
                }
                if (tempPrimary.Trim().Length > 0)
                    tempPrimary = tempPrimary.Substring(0, tempPrimary.Length - 2);

                //other

                exams = termresult.partnerexamsrequiredlist;

                String[] oreq = new String[12];

                int k = 0;
                foreach (WSExam exam in exams)
                {
                    otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + otherreq;
                    oreq[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    k++;
                }

                List<ReportParameter> paramlist = new List<ReportParameter>();

                string tempOther = " ";
                if (partins != null)
                {
                    for (int j = 0; j < oreq.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(oreq[j]))
                            if (!oreq[j].Trim().Equals(""))
                                tempOther += oreq[j] + ", ";
                    }
                }
                if (tempOther.Trim().Length > 0)
                    tempOther = tempOther.Substring(0, tempOther.Length - 2);


                string Prospect = customer.FirstName + " " + customer.LastName;


                DateTime d = DateTime.Now;
                string meng = d.ToString("MMMM");
                string msp = "";
                if (meng == "January")
                {
                    msp = "enero";
                }
                else if (meng == "Febuary")
                {
                    msp = "febrero";
                }
                else if (meng == "March")
                {
                    msp = "marzo";
                }
                else if (meng == "April")
                {
                    msp = "abril";
                }
                else if (meng == "May")
                {
                    msp = "mayo";
                }
                else if (meng == "June")
                {
                    msp = "junio";
                }
                else if (meng == "July")
                {
                    msp = "julio";
                }
                else if (meng == "August")
                {
                    msp = "agosto";
                }
                else if (meng == "September")
                {
                    msp = "septiembre";
                }
                else if (meng == "October")
                {
                    msp = "octubre";
                }
                else if (meng == "November")
                {
                    msp = "noviembre";
                }
                else if (meng == "December")
                {
                    msp = "diciembre";
                }

                ReportParameter param2 = new ReportParameter("date", d.Day.ToString() + " de " + msp + " del " + d.Year.ToString());
                ReportParameter param3 = new ReportParameter("name", customer.FirstName + " " + customer.LastName);

                ReportParameter param76 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días unicamente y en  ningún caso más allá del 31/12/" + DateTime.Now.Year + " (v10)");

                List<List<CompareIllus>> clslist = DisplayReportData();
                List<List<CompareIllus>> clslist1 = new List<List<CompareIllus>>();
                List<List<CompareIllus>> clslist2 = new List<List<CompareIllus>>();
                if (dt_compare1 != null)
                {
                    clslist1 = DisplayReportData1();
                }
                if (dt_compare2 != null)
                {
                    clslist2 = DisplayReportData2();
                }

                ReportParameter param126 = new ReportParameter("plannames", rptplanname);
                ReportParameter param127 = new ReportParameter("count", "" + countpar);
                ReportParameter param128 = new ReportParameter("count1", "" + countpar1);
                ReportParameter param129 = new ReportParameter("count2", "" + countpar2);

                ReportParameter param130 = new ReportParameter("countnew", "" + countparnew1);
                ReportParameter param131 = new ReportParameter("count11", "" + countpar11);
                ReportParameter param132 = new ReportParameter("count21", "" + countpar21);

                ReportParameter param133 = new ReportParameter("countnew1", "" + countparnew2);
                ReportParameter param134 = new ReportParameter("count12", "" + countpar12);
                ReportParameter param135 = new ReportParameter("count22", "" + countpar22);

                ReportParameter param136;
                if (rptplanname.Contains("COMPASS INDEX") || rptplanname.Contains("LEGACY"))
                {
                    param136 = new ReportParameter("pagecount", "" + false);
                }
                else
                {
                    param136 = new ReportParameter("pagecount", "" + true);
                }

                ReportParameter param137 = new ReportParameter("hidepar1", "" + false);
                ReportParameter param138 = new ReportParameter("hidepar2", "" + false);
                ReportParameter param139 = new ReportParameter("hidepar3", "" + false);
                ReportParameter param140 = new ReportParameter("hidepar4", "" + false);

                paramlist.Add(param2);
                paramlist.Add(param3);

                paramlist.Add(param76);

                paramlist.Add(param126);
                paramlist.Add(param127);
                paramlist.Add(param128);
                paramlist.Add(param129);
                paramlist.Add(param130);
                paramlist.Add(param131);
                paramlist.Add(param132);
                paramlist.Add(param133);
                paramlist.Add(param134);
                paramlist.Add(param135);
                paramlist.Add(param136);
                paramlist.Add(param137);
                paramlist.Add(param138);
                paramlist.Add(param139);
                paramlist.Add(param140);

                string untilAge = "-";

                if (riderterm != null)
                {
                    if (riderterm.type.Equals(Contributiontypes.CONTINUOUS))
                        untilAge = "99";
                    else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                    else if (riderterm.type.Equals(Contributiontypes.UNTILAGE))
                        untilAge = riderterm.term.ToString();
                }

                maritalstatus = "-";

                if (partins != null)
                {
                    maritalstatus = Maritalstatus.getmaritalstatus(Convert.ToString(partins.maritalstatuscode));

                    lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                             where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatus)
                                             select item).SingleOrDefault();
                    if (mstatus != null)
                        maritalstatus = mstatus.spanish;
                }
                string temp = "-";
                if (riderterm != null)
                    temp = GetFormatedText(riderterm.amount.ToString());

                // ReportParameter paramRiderAmount1 = new ReportParameter("RiderAmount1", temp);
                temp = "-";
                if (rideradb != null)
                    temp = GetFormatedText(rideradb.amount.ToString());

                //ReportParameter paramRiderAmount2 = new ReportParameter("RiderAmount2", temp);

                string partinsRiderOirAmount = "-";
                // if (customerplan.rideroir.ToString().Equals("Y"))
                if (partins != null)
                    partinsRiderOirAmount = GetFormatedText(partins.amount.ToString());

                //ReportParameter paramRiderAmount3 = new ReportParameter("RiderAmount3", partinsRiderOirAmount);

                untilAge = "-";

                if (riderterm != null)
                {
                    if (riderterm.type.Equals(Contributiontypes.CONTINUOUS))
                        untilAge = "99";
                    else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                    else if (riderterm.type.Equals(Contributiontypes.UNTILAGE))
                        untilAge = riderterm.term.ToString();
                }

                if (untilAge.Equals("0"))
                    untilAge = "-";

                string untilAge2 = "-";


                if (partins != null)
                {
                    if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS))
                        untilAge2 = "99";
                    else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge2 = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                    else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE))
                        untilAge2 = partins.term.ToString();
                }

                if (untilAge2.Equals("0"))
                    untilAge2 = "-";



                rpt.LocalReport.SetParameters(paramlist);

                //   rpt.LocalReport.DataSources.Add(rds);
                //  rpt.LocalReport.DataSources.Add(rdstwo);
                if (clslist != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails1", clslist[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist1", clslist[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails2", clslist[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist2", clslist[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails3", clslist[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist3", clslist[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails4", clslist[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist4", clslist[7]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planheaderlist", clslist[8]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planyearlist", clslist[9]));


                }
                if (clslist1 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails5", clslist1[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist5", clslist1[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails6", clslist1[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist6", clslist1[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails7", clslist1[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist7", clslist1[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails8", clslist1[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist8", clslist1[7]));

                }
                if (clslist2 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails9", clslist2[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist9", clslist2[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails10", clslist2[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist10", clslist2[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails11", clslist2[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist11", clslist2[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails12", clslist2[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist12", clslist2[7]));

                }
                rpt.LocalReport.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // newdb.Dispose();
            }
            return bytes;

        }


        public static byte[] showIllustrationTERMfixedLS(WSTermResult termresult, WSCustomer customer, WSCustomerPlan customerplan, IMaintermfixedLS termfixed, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            byte[] bytes = null;
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            String productcode = "";
            try
            {

                rpt.LocalReport.Refresh();
                rpt.Reset();

                string PlanName = Productdata.getProduct(customerplan.productcode);
                rpt.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/bin/IllustrationReport.rdlc");

                string spouseinsuredamt = "-";
                if (partins != null)
                {
                    if (partins.amount != null)
                    {
                        spouseinsuredamt = partins.amount.ToString();
                    }

                }

                string contributionperiod = "-";
                string termamount = "-";
                string calculate = "-";
                string freqofpayment = "-";
                string rideradbamount = "-";
                string annualizepremium = "-";
                string initialcontributionamount = "-";
                string ddlinitialcontribution = "-";
                string premiumamount = "-";
                string insuredamount = "-";
                string crticleillnessamount = "-";
                string maritalstatus = "-";
                string plantype = "-";
                string almillar = "-";
                string risk = "-";
                string rawreturn = "-";
                string culminationage = "-";

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
                if (customerplan != null)
                {
                    if (customerplan.contributionperiod != null)
                    {
                        contributionperiod = customerplan.contributionperiod.ToString();
                    }
                    if (rideradb != null && rideradb.amount != null)
                    {
                        rideradbamount = rideradb.amount.ToString();

                    }
                    if (riderterm != null && riderterm.amount != null)
                    {
                        termamount = riderterm.amount.ToString();
                    }
                    if (customerplan.calculatetypecode != null)
                    {
                        calculate = Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypedet, Calculatetypes.getcalculatetype(customerplan.calculatetypecode.ToCharArray()[0]), "es");
                    }
                    if (customerplan.frequencytypecode != null)
                    {
                        // freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode), Sessionclass.getSessiondata(Session).language);
                        freqofpayment = Lookuplangdata.getLanguagevalue(Lookuptables.frequencytype, Frequencytypes.getfrequencytype(customerplan.frequencytypecode.ToCharArray()[0]), "es");

                    }
                    if (customerplan.premiumamount != null)
                    {
                        annualizepremium = termresult.annualpremiumamount.ToString();
                    }

                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {

                            initialcontributionamount = customerplan.initialcontributionamount.ToString();
                        }
                        else
                        {
                            initialcontributionamount = "0";
                        }
                    }
                    if (customerplan.initialcontributionamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.initialcontributionamount.ToString()) > 0)
                        {
                            ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Yes", "es");
                        }
                        else
                        {
                            ddlinitialcontribution = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "No", "es");

                        }
                    }
                    if (customerplan.premiumamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.premiumamount.ToString()) > 0)
                        {
                            premiumamount = customerplan.premiumamount.ToString();
                        }
                        else
                        {
                            premiumamount = "0";
                        }
                    }
                    if (customerplan.insuredamount != null)
                    {
                        if (Numericdata.getDoublevalue(customerplan.insuredamount.ToString()) > 0)
                        {
                            insuredamount = customerplan.insuredamount.ToString();
                        }
                        else
                        {
                            insuredamount = "0";
                        }
                    }


                    maritalstatus = Lookuplangdata.getLanguagevalue(Lookuptables.maritalstatusdet, Maritalstatus.getmaritalstatus(customer.MaritalStatuscode), "es");

                    plantype = Lookuplangdata.getLanguagevalue(Lookuptables.plantypedet, Plantypes.getPlantype(customerplan.plantypecode.ToCharArray()[0]), "es");


                    risk = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(Numericdata.getIntegervalue(customerplan.activityrisktypeno.ToString())), "es");



                    almillar = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(customerplan.healthrisktypeno.ToString())), "es");


                    rawreturn = (Numericdata.getDecimalvalue(customerplan.initialcontributionamount.ToString()) + Frequencytypes.getfrequencytypevaluefromcode(customerplan.frequencytypecode.ToCharArray()[0]) * customerplan.contributionperiod * Numericdata.getDecimalvalue(customerplan.premiumamount.ToString())).ToString("n2");

                    culminationage = (Numericdata.getIntegervalue(customerplan.contributionperiod.ToString()) + customer.Age - 1).ToString();



                }
                //

                string rideroiramt = "-";
                string rideroirname = "-";
                string Riesgo = "-";
                string Fumador = "-";
                string Sexo = "-";
                string HastalaEdadde = "-";
                string Edad = "-";
                string AlMillar1 = "-";

                if (partins != null)
                {

                    rideroiramt = partins.amount.ToString("n2");
                    rideroirname = partins.firstname + " " + partins.middlename + " " + partins.lastname + " " + partins.LastName2;

                    Fumador = Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, Booleandata.getBooleanstring(partins.smoker.ToCharArray()[0]), "es");
                    Sexo = partins.gendercode.ToString();

                    if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS))
                        HastalaEdadde = "99";
                    else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS))
                        HastalaEdadde = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                    else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE))
                        HastalaEdadde = partins.term.ToString();

                    Edad = partins.age.ToString();

                    Riesgo = Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, Activityrisktypes.getActivityrisktype(partins.activityrisktypeno), "es");

                    AlMillar1 = Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet, Healthrisktypes.getHealthrisktype(Numericdata.getIntegervalue(partins.healthrisktypeno.ToString())), "es");


                }
                //primary
                string primaryreq = "-", otherreq = "-";

                List<WSExam> exams = termresult.primaryexamsrequiredlist;

                String[] req = new String[20];

                int examno = 0;
                foreach (WSExam exam in exams)
                {
                    primaryreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + primaryreq;
                    req[examno] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    examno++;
                }

                string tempPrimary = " ";
                for (int j = 0; j < req.Length; j++)
                {
                    if (!string.IsNullOrEmpty(req[j]))
                        if (!req[j].Trim().Equals(""))
                            tempPrimary += req[j] + ", ";
                }
                if (tempPrimary.Trim().Length > 0)
                    tempPrimary = tempPrimary.Substring(0, tempPrimary.Length - 2);

                //other

                exams = termresult.partnerexamsrequiredlist;

                String[] oreq = new String[12];

                int k = 0;
                foreach (WSExam exam in exams)
                {
                    otherreq = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es").ToUpper() + "/" + otherreq;
                    oreq[k] = Lookuplangdata.getLanguagevalue(Lookuptables.examdet, Exams.getexam(exam.examcode), "es");
                    k++;
                }

                List<ReportParameter> paramlist = new List<ReportParameter>();

                string tempOther = " ";
                if (partins != null)
                {
                    for (int j = 0; j < oreq.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(oreq[j]))
                            if (!oreq[j].Trim().Equals(""))
                                tempOther += oreq[j] + ", ";
                    }
                }
                if (tempOther.Trim().Length > 0)
                    tempOther = tempOther.Substring(0, tempOther.Length - 2);


                string Prospect = customer.FirstName + " " + customer.LastName;


                DateTime d = DateTime.Now;
                string meng = d.ToString("MMMM");
                string msp = "";
                if (meng == "January")
                {
                    msp = "enero";
                }
                else if (meng == "Febuary")
                {
                    msp = "febrero";
                }
                else if (meng == "March")
                {
                    msp = "marzo";
                }
                else if (meng == "April")
                {
                    msp = "abril";
                }
                else if (meng == "May")
                {
                    msp = "mayo";
                }
                else if (meng == "June")
                {
                    msp = "junio";
                }
                else if (meng == "July")
                {
                    msp = "julio";
                }
                else if (meng == "August")
                {
                    msp = "agosto";
                }
                else if (meng == "September")
                {
                    msp = "septiembre";
                }
                else if (meng == "October")
                {
                    msp = "octubre";
                }
                else if (meng == "November")
                {
                    msp = "noviembre";
                }
                else if (meng == "December")
                {
                    msp = "diciembre";
                }

                ReportParameter param2 = new ReportParameter("date", d.Day.ToString() + " de " + msp + " del " + d.Year.ToString());
                ReportParameter param3 = new ReportParameter("name", customer.FirstName + " " + customer.LastName);

                ReportParameter param76 = new ReportParameter("BottomText", "Esta propuesta es válida por 15 días unicamente y en  ningún caso más allá del 31/12/" + DateTime.Now.Year + " (v10)");

                List<List<CompareIllus>> clslist = DisplayReportData();
                List<List<CompareIllus>> clslist1 = new List<List<CompareIllus>>();
                List<List<CompareIllus>> clslist2 = new List<List<CompareIllus>>();
                if (dt_compare1 != null)
                {
                    clslist1 = DisplayReportData1();
                }
                if (dt_compare2 != null)
                {
                    clslist2 = DisplayReportData2();
                }

                ReportParameter param126 = new ReportParameter("plannames", rptplanname);
                ReportParameter param127 = new ReportParameter("count", "" + countpar);
                ReportParameter param128 = new ReportParameter("count1", "" + countpar1);
                ReportParameter param129 = new ReportParameter("count2", "" + countpar2);

                ReportParameter param130 = new ReportParameter("countnew", "" + countparnew1);
                ReportParameter param131 = new ReportParameter("count11", "" + countpar11);
                ReportParameter param132 = new ReportParameter("count21", "" + countpar21);

                ReportParameter param133 = new ReportParameter("countnew1", "" + countparnew2);
                ReportParameter param134 = new ReportParameter("count12", "" + countpar12);
                ReportParameter param135 = new ReportParameter("count22", "" + countpar22);

                ReportParameter param136;
                if (rptplanname.Contains("COMPASS INDEX") || rptplanname.Contains("LEGACY"))
                {
                    param136 = new ReportParameter("pagecount", "" + false);
                }
                else
                {
                    param136 = new ReportParameter("pagecount", "" + true);
                }

                ReportParameter param137 = new ReportParameter("hidepar1", "" + false);
                ReportParameter param138 = new ReportParameter("hidepar2", "" + false);
                ReportParameter param139 = new ReportParameter("hidepar3", "" + false);
                ReportParameter param140 = new ReportParameter("hidepar4", "" + false);

                paramlist.Add(param2);
                paramlist.Add(param3);

                paramlist.Add(param76);

                paramlist.Add(param126);
                paramlist.Add(param127);
                paramlist.Add(param128);
                paramlist.Add(param129);
                paramlist.Add(param130);
                paramlist.Add(param131);
                paramlist.Add(param132);
                paramlist.Add(param133);
                paramlist.Add(param134);
                paramlist.Add(param135);
                paramlist.Add(param136);
                paramlist.Add(param137);
                paramlist.Add(param138);
                paramlist.Add(param139);
                paramlist.Add(param140);

                string untilAge = "-";

                if (riderterm != null)
                {
                    if (riderterm.type.Equals(Contributiontypes.CONTINUOUS))
                        untilAge = "99";
                    else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                    else if (riderterm.type.Equals(Contributiontypes.UNTILAGE))
                        untilAge = riderterm.term.ToString();
                }

                maritalstatus = "-";

                if (partins != null)
                {
                    maritalstatus = Maritalstatus.getmaritalstatus(Convert.ToString(partins.maritalstatuscode));

                    lookupdatadet mstatus = (from item in newdb.lookupdatadets
                                             where item.tablename.Equals("maritalstatusdet") && item.lookupcaption.Equals(maritalstatus)
                                             select item).SingleOrDefault();
                    if (mstatus != null)
                        maritalstatus = mstatus.spanish;
                }
                string temp = "-";
                if (riderterm != null)
                    temp = GetFormatedText(riderterm.amount.ToString());

                // ReportParameter paramRiderAmount1 = new ReportParameter("RiderAmount1", temp);
                temp = "-";
                if (rideradb != null)
                    temp = GetFormatedText(rideradb.amount.ToString());

                //ReportParameter paramRiderAmount2 = new ReportParameter("RiderAmount2", temp);

                string partinsRiderOirAmount = "-";
                // if (customerplan.rideroir.ToString().Equals("Y"))
                if (partins != null)
                    partinsRiderOirAmount = GetFormatedText(partins.amount.ToString());

                //ReportParameter paramRiderAmount3 = new ReportParameter("RiderAmount3", partinsRiderOirAmount);

                untilAge = "-";

                if (riderterm != null)
                {
                    if (riderterm.type.Equals(Contributiontypes.CONTINUOUS))
                        untilAge = "99";
                    else if (riderterm.type.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge = (Convert.ToInt32(customer.Age) + riderterm.term - 1).ToString();
                    else if (riderterm.type.Equals(Contributiontypes.UNTILAGE))
                        untilAge = riderterm.term.ToString();
                }

                if (untilAge.Equals("0"))
                    untilAge = "-";

                string untilAge2 = "-";


                if (partins != null)
                {
                    if (partins.contributiontype.Equals(Contributiontypes.CONTINUOUS))
                        untilAge2 = "99";
                    else if (partins.contributiontype.Equals(Contributiontypes.NUMBEROFYEARS))
                        untilAge2 = (Convert.ToInt32(partins.age) + partins.term - 1).ToString();
                    else if (partins.contributiontype.Equals(Contributiontypes.UNTILAGE))
                        untilAge2 = partins.term.ToString();
                }

                if (untilAge2.Equals("0"))
                    untilAge2 = "-";



                rpt.LocalReport.SetParameters(paramlist);

                //   rpt.LocalReport.DataSources.Add(rds);
                //  rpt.LocalReport.DataSources.Add(rdstwo);
                if (clslist != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails1", clslist[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist1", clslist[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails2", clslist[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist2", clslist[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails3", clslist[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist3", clslist[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails4", clslist[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist4", clslist[7]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planheaderlist", clslist[8]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planyearlist", clslist[9]));


                }
                if (clslist1 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails5", clslist1[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist5", clslist1[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails6", clslist1[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist6", clslist1[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails7", clslist1[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist7", clslist1[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails8", clslist1[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist8", clslist1[7]));

                }
                if (clslist2 != null)
                {
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails9", clslist2[0]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist9", clslist2[1]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails10", clslist2[2]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist10", clslist2[3]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails11", clslist2[4]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist11", clslist2[5]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Plandetails12", clslist2[6]));
                    rpt.LocalReport.DataSources.Add(new ReportDataSource("Planlist12", clslist2[7]));

                }
                rpt.LocalReport.Refresh();
                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                bytes = rpt.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // newdb.Dispose();
            }
            return bytes;

        }

        public static string GetFormatedText(string str)
        {
            char oldChar = ',';
            char newChar = '.';

            string output = String.Format("{0:n0}", Math.Round(Numericdata.getDoublevalue(str), 0, MidpointRounding.AwayFromZero)).Replace(oldChar, newChar);

            if (output.Equals("0"))
                return "-";

            return output;
        }
    }
}