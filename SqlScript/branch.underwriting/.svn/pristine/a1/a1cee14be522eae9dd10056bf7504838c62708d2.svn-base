using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
namespace WSVirtualOffice.Models.blinsurance
{
    struct IAccountvaluedata
    {
        // needed things are age,gender,smoker,activityrisk,illnessrisk,product,
        // premiumamount,
        
        public int sno;
        public int age;
        public double mortalityrate;
        
        //public double loadcharge;
        
        
        //public double commission;
        
        // based on investmentprofile and product
        public double netgrowthrate;

        public double costofinsurance;
        
        public double accountvalue;
        
        // needed stuff are product,age,gender,smoker,investmentrate

        //fixed fields based on product        
        public double targetoverage;
        public double premiumreserve;
        public double monthlyfeevalue;
        public double loadchargepercent;

        public double activityrisk;
        public double illnessrisk;

        // for getting the premium or insured one of them is required
        public double insuredamount;
        public double premiumamount;


        // commission table based on yearno/sno
        public double commissionpercentvalue;
        public double excesspercentvalue;

        
        //public double actualcommission;
        
        public double targetamount;
        
        
        //public double netpremiumamount;
        //public double accountvalue;
        //public double totalaccountvalue;





        public static Illusresult getInsuredamount(double mininsuredamount, double maxinsuredamount, double targetaccountvalue, double precision, Accountvaluedata[] acvaluedata,Productinvprofile prodprofile)
        {

            Accountvaluedata[] tempaccountvaluedata = new Accountvaluedata[acvaluedata.Length];            
            Array.Copy(acvaluedata, tempaccountvaluedata, acvaluedata.Length);

            Accountvaluedata[] minaccountvaluedata = new Accountvaluedata[acvaluedata.Length];
            Array.Copy(acvaluedata, minaccountvaluedata, acvaluedata.Length);

            Mainvaluedata maindata=goalseek(mininsuredamount, maxinsuredamount, targetaccountvalue, precision, acvaluedata,prodprofile);
            Illusresult illr = new Illusresult();
            //illr.minimumpremium = maindata.minimumpremium;
            illr.targetamount = maindata.targetamount;
            illr.insuranceamount = maindata.insuredamount;

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                minaccountvaluedata[i].insuredamount = illr.insuranceamount;                
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            illr.minimumpremium = Minimumpremiumdata.getMinimumpremium(0, 20000, 0, 1, minaccountvaluedata, prodprofile);
            //MessageBox.Show(tempaccountvaluedata[0].insuredamount.ToString());
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                tempaccountvaluedata[i].insuredamount = illr.insuranceamount;
                tempaccountvaluedata[i].targetamount = illr.targetamount;
                tempaccountvaluedata[i].netgrowthrate = prodprofile.compgrowthrate1;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            //MessageBox.Show(tempaccountvaluedata[0].netgrowthrate.ToString() + "," + acvaluedata[0].netgrowthrate.ToString());
            Growthcase[] g1 = calculategeneralaccountvalue(tempaccountvaluedata, maindata,prodprofile);
            

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                tempaccountvaluedata[i].insuredamount = illr.insuranceamount;
                tempaccountvaluedata[i].targetamount = illr.targetamount;
                tempaccountvaluedata[i].netgrowthrate = prodprofile.compgrowthrate2;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            //MessageBox.Show(tempaccountvaluedata[0].netgrowthrate.ToString() + "," + acvaluedata[0].netgrowthrate.ToString());
            Growthcase[] g2 = calculategeneralaccountvalue(tempaccountvaluedata, maindata,prodprofile);

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                tempaccountvaluedata[i].insuredamount = illr.insuranceamount;
                tempaccountvaluedata[i].targetamount = illr.targetamount;
                tempaccountvaluedata[i].netgrowthrate = prodprofile.investmentprofilerate;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            //MessageBox.Show(tempaccountvaluedata[0].netgrowthrate.ToString() + "," + acvaluedata[0].netgrowthrate.ToString());
            Growthcase[] g3 = calculategeneralaccountvalue(tempaccountvaluedata, maindata,prodprofile);
            Illusdata[] illdata = new Illusdata[acvaluedata.Length];

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                illdata[i] = new Illusdata();
                illdata[i].Sno = acvaluedata[i].sno;
                illdata[i].Age = acvaluedata[i].age;
                illdata[i].Premium= acvaluedata[i].premiumamount;
                illdata[i].Numscenarios = 3;
                Growthcase[] gdata=new Growthcase[3];
                
                gdata[0]=new Growthcase();
                gdata[0].Accountvalue=g1[i].Accountvalue;
                gdata[0].Growthrate=g1[i].Growthrate;
                gdata[0].Rescatevalue=g1[i].Rescatevalue;
                gdata[0].Insuredamount=g1[i].Insuredamount;

                gdata[1] = new Growthcase();
                gdata[1].Accountvalue = g2[i].Accountvalue;
                gdata[1].Growthrate = g2[i].Growthrate;
                gdata[1].Rescatevalue = g2[i].Rescatevalue;
                gdata[1].Insuredamount = g2[i].Insuredamount;

                gdata[2] = new Growthcase();
                gdata[2].Accountvalue = g3[i].Accountvalue;
                gdata[2].Growthrate = g3[i].Growthrate;
                gdata[2].Rescatevalue = g3[i].Rescatevalue;
                gdata[2].Insuredamount = g3[i].Insuredamount;
                
                illdata[i].Growthdata = gdata;
            }
            illr.illustration = illdata;
            return illr;
        }





        public static Illusresult getPremiumamount(double minpremiumamount, double maxpremiumamount, double targetaccountvalue, double precision, Accountvaluedata[] acvaluedata, Productinvprofile prodprofile,int contributionperiod)
        {
            Accountvaluedata[] tempaccountvaluedata = new Accountvaluedata[acvaluedata.Length];
            Array.Copy(acvaluedata, tempaccountvaluedata, acvaluedata.Length);

            Accountvaluedata[] minaccountvaluedata = new Accountvaluedata[acvaluedata.Length];
            Array.Copy(acvaluedata, minaccountvaluedata, acvaluedata.Length);

            Mainvaluedata maindata = goalseekpremium(minpremiumamount, maxpremiumamount, targetaccountvalue, precision, acvaluedata,contributionperiod,prodprofile);
            Illusresult illr = new Illusresult();
            //illr.minimumpremium = maindata.minimumpremium;
            illr.targetamount = maindata.targetamount;
            illr.premiumamount = maindata.premiumamount;
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                minaccountvaluedata[i].insuredamount = illr.insuranceamount;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            illr.minimumpremium = Minimumpremiumdata.getMinimumpremium(0, 20000, 0, 1, minaccountvaluedata, prodprofile);
            //MessageBox.Show(tempaccountvaluedata[0].insuredamount.ToString());
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                tempaccountvaluedata[i].insuredamount = illr.insuranceamount;
                tempaccountvaluedata[i].targetamount = illr.targetamount;
                tempaccountvaluedata[i].netgrowthrate = prodprofile.compgrowthrate1;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            //MessageBox.Show(tempaccountvaluedata[0].netgrowthrate.ToString() + "," + acvaluedata[0].netgrowthrate.ToString());
            Growthcase[] g1 = calculategeneralaccountvalue(tempaccountvaluedata, maindata,prodprofile);


            for (int i = 0; i < acvaluedata.Length; i++)
            {
                tempaccountvaluedata[i].insuredamount = illr.insuranceamount;
                tempaccountvaluedata[i].targetamount = illr.targetamount;
                tempaccountvaluedata[i].netgrowthrate = prodprofile.compgrowthrate2;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            //MessageBox.Show(tempaccountvaluedata[0].netgrowthrate.ToString() + "," + acvaluedata[0].netgrowthrate.ToString());
            Growthcase[] g2 = calculategeneralaccountvalue(tempaccountvaluedata, maindata,prodprofile);

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                tempaccountvaluedata[i].insuredamount = illr.insuranceamount;
                tempaccountvaluedata[i].targetamount = illr.targetamount;
                tempaccountvaluedata[i].netgrowthrate = prodprofile.investmentprofilerate;
                //tempaccountvaluedata[i].= illr.insuranceamount;
            }
            //MessageBox.Show(tempaccountvaluedata[0].netgrowthrate.ToString() + "," + acvaluedata[0].netgrowthrate.ToString());
            Growthcase[] g3 = calculategeneralaccountvalue(tempaccountvaluedata, maindata,prodprofile);
            Illusdata[] illdata = new Illusdata[acvaluedata.Length];

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                illdata[i] = new Illusdata();
                illdata[i].Sno = acvaluedata[i].sno;
                illdata[i].Age = acvaluedata[i].age;
                illdata[i].Premium = acvaluedata[i].premiumamount;
                illdata[i].Numscenarios = 3;
                Growthcase[] gdata = new Growthcase[3];

                gdata[0] = new Growthcase();
                gdata[0].Accountvalue = g1[i].Accountvalue;
                gdata[0].Growthrate = g1[i].Growthrate;
                gdata[0].Rescatevalue = g1[i].Rescatevalue;
                gdata[0].Insuredamount = g1[i].Insuredamount;

                gdata[1] = new Growthcase();
                gdata[1].Accountvalue = g2[i].Accountvalue;
                gdata[1].Growthrate = g2[i].Growthrate;
                gdata[1].Rescatevalue = g2[i].Rescatevalue;
                gdata[1].Insuredamount = g2[i].Insuredamount;

                gdata[2] = new Growthcase();
                gdata[2].Accountvalue = g3[i].Accountvalue;
                gdata[2].Growthrate = g3[i].Growthrate;
                gdata[2].Rescatevalue = g3[i].Rescatevalue;
                gdata[2].Insuredamount = g3[i].Insuredamount;

                illdata[i].Growthdata = gdata;
            }
            illr.illustration = illdata;
            return illr;
        }





        private static Mainvaluedata goalseek(double mininsuredamount, double maxinsuredamount, double targetaccountvalue, double precision, Accountvaluedata[] acvaluedata, Productinvprofile prodprofile)
        {
            //double minaccountvalue = calculateaccountvalue(mininsuredamount);
            //double maxaccountvalue = calculateaccountvalue(maxinsuredamount);                
            double midinsuredamount = (maxinsuredamount + mininsuredamount) / 2.0;
            Mainvaluedata maindata = calculateaccountvalue(midinsuredamount, acvaluedata,prodprofile);
            maindata.insuredamount = midinsuredamount;
            double midaccountvalue = maindata.accountvalue;
            if (midaccountvalue > (targetaccountvalue - precision) && midaccountvalue < (targetaccountvalue + precision))
            {
                return maindata;
            }
            else
            {
                if (midaccountvalue > precision)
                {
                    return goalseek(midinsuredamount, maxinsuredamount, targetaccountvalue, precision, acvaluedata,prodprofile);
                }
                else
                {
                    return goalseek(mininsuredamount, midinsuredamount, targetaccountvalue, precision, acvaluedata,prodprofile);
                }
            }
            //return 0.0;
        }



        private static Mainvaluedata goalseekpremium(double minpremiumamount, double maxpremiumamount, double targetaccountvalue, double precision, Accountvaluedata[] acvaluedata, int contributionperiod, Productinvprofile prodprofile)
        {
            //double minaccountvalue = calculateaccountvalue(minpremiumamount);
            //double maxaccountvalue = calculateaccountvalue(maxpremiumamount);                
            double midpremiumamount = (maxpremiumamount + minpremiumamount) / 2.0;
            Mainvaluedata maindata = calculateaccountvaluepremium(midpremiumamount, acvaluedata,contributionperiod,prodprofile);
            maindata.premiumamount = midpremiumamount;
            double midaccountvalue = maindata.accountvalue;
            if (midaccountvalue > (targetaccountvalue - precision) && midaccountvalue < (targetaccountvalue + precision))
            {
                return maindata;
            }
            else
            {
                if (midaccountvalue < precision)
                {
                    return goalseekpremium(midpremiumamount, maxpremiumamount, targetaccountvalue, precision, acvaluedata,contributionperiod,prodprofile);
                }
                else
                {
                    return goalseekpremium(minpremiumamount, midpremiumamount, targetaccountvalue, precision, acvaluedata,contributionperiod,prodprofile);
                }
            }
            //return 0.0;
        }




        private static Mainvaluedata calculateaccountvalue(double insuredamount, Accountvaluedata[] acvaluedata, Productinvprofile prodprofile)
        {
            Mainvaluedata maindata = new Mainvaluedata();
            
            double accountvalue = 0.0;

            


            Targetamountdata[] targetvaluedata = new Targetamountdata[acvaluedata.Length];
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                targetvaluedata[i] = new Targetamountdata();
                targetvaluedata[i].accountvalue = acvaluedata[i].accountvalue;
                //targetvaluedata[i].actualcommission = acvaluedata[i].actualcommission;
                targetvaluedata[i].age = acvaluedata[i].age;
                targetvaluedata[i].commissionpercentvalue = acvaluedata[i].commissionpercentvalue;
                targetvaluedata[i].costofinsurance = acvaluedata[i].costofinsurance;
                targetvaluedata[i].targetoverage = acvaluedata[i].targetoverage;
                //targetvaluedata[i].loadcharge = acvaluedata[i].loadcharge;
                targetvaluedata[i].loadchargepercent = acvaluedata[0].loadchargepercent;
                targetvaluedata[i].monthlyfeevalue = acvaluedata[i].monthlyfeevalue;
                targetvaluedata[i].mortalityrate = acvaluedata[i].mortalityrate;
                targetvaluedata[i].netgrowthrate = acvaluedata[i].netgrowthrate;
                targetvaluedata[i].sno = acvaluedata[i].sno;
                targetvaluedata[i].targetamount = 0;
                targetvaluedata[i].insuredamount = insuredamount;

            }
            double targetamount = Targetamountdata.getTargetamount(0, 100000, 0, 10, targetvaluedata,prodprofile);
            maindata.targetamount = targetamount;







            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;

                double adjustedpremium = acvaluedata[i].premiumamount / (1 + acvaluedata[i].premiumreserve);

                if (acvaluedata[i].premiumamount > 0)
                {
                    commissionamount = targetamount * acvaluedata[i].commissionpercentvalue;
                    if ((adjustedpremium - targetamount) > 0)
                    {
                        //excesscommissionamount = (acvaluedata[i].premiumamount - targetamount) * acvaluedata[i].excesspercentvalue;
                        excesscommissionamount = (adjustedpremium - targetamount) * acvaluedata[i].excesspercentvalue;
                    }
                    commissionamount = commissionamount + excesscommissionamount;
                }
                double costofinsurance = 0.0;
                if (prodprofile.plantypecode == 'F')
                {
                    costofinsurance = (insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }
                else
                {
                    costofinsurance = (insuredamount ) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);

                }
                

                //double costofinsurance1 = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);

                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].targetamount = targetamount;

            }
            maindata.accountvalue = accountvalue;
            return maindata;
        }



        private static Mainvaluedata calculateaccountvaluepremium(double premiumamount, Accountvaluedata[] acvaluedata, int contributionperiod, Productinvprofile prodprofile)
        {
            Mainvaluedata maindata = new Mainvaluedata();
            double accountvalue = 0.0;

            if (premiumamount <= 2100 && premiumamount >= 1900)
            {
                int l = 0;

            }

            Targetamountdata[] targetvaluedata = new Targetamountdata[acvaluedata.Length];
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                targetvaluedata[i] = new Targetamountdata();
                targetvaluedata[i].accountvalue = acvaluedata[i].accountvalue;
                //targetvaluedata[i].actualcommission = acvaluedata[i].actualcommission;
                targetvaluedata[i].age = acvaluedata[i].age;
                targetvaluedata[i].commissionpercentvalue = acvaluedata[i].commissionpercentvalue;
                targetvaluedata[i].costofinsurance = acvaluedata[i].costofinsurance;
                targetvaluedata[i].targetoverage = acvaluedata[i].targetoverage;
                //targetvaluedata[i].loadcharge = acvaluedata[i].loadcharge;
                targetvaluedata[i].loadchargepercent = acvaluedata[0].loadchargepercent;
                targetvaluedata[i].monthlyfeevalue = acvaluedata[i].monthlyfeevalue;
                targetvaluedata[i].mortalityrate = acvaluedata[i].mortalityrate;
                targetvaluedata[i].netgrowthrate = acvaluedata[i].netgrowthrate;
                targetvaluedata[i].sno = acvaluedata[i].sno;
                targetvaluedata[i].targetamount = 0;
                targetvaluedata[i].insuredamount = acvaluedata[i].insuredamount;

            }
            double targetamount = Targetamountdata.getTargetamount(0, 100000, 0, 10, targetvaluedata,prodprofile);
            maindata.targetamount = targetamount;


            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = premiumamount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;

                double adjustedpremium = premiumamount / (1 + acvaluedata[i].premiumreserve);

                if (contributionperiod > i)
                {
                    commissionamount = targetamount * acvaluedata[i].commissionpercentvalue;
                    if ((adjustedpremium - targetamount) > 0)
                    {
                        //excesscommissionamount = (acvaluedata[i].premiumamount - targetamount) * acvaluedata[i].excesspercentvalue;
                        excesscommissionamount = (adjustedpremium - targetamount) * acvaluedata[i].excesspercentvalue;
                    }
                    commissionamount = commissionamount + excesscommissionamount;
                }

                double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                if (prodprofile.plantypecode == 'F')
                {
                    costofinsurance = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }
                else
                {
                    costofinsurance = (acvaluedata[i].insuredamount ) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);

                }

                

                //double costofinsurance1 = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);

                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                if (contributionperiod > i)
                {
                    accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                }
                else
                {
                    accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (0 * (1 / (1 + acvaluedata[i].premiumreserve))) - 0 - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                }
                
                acvaluedata[i].targetamount = targetamount;

            }
            maindata.accountvalue = accountvalue;
            return maindata;
        }








        private static double calculateaccountvalueforother(double rideramount, double insuredamount, Accountvaluedata[] acvaluedata, Productinvprofile prodprofile)
        {
            double accountvalue = 0.0;
            Targetamountdata[] targetvaluedata = new Targetamountdata[acvaluedata.Length];
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                targetvaluedata[i] = new Targetamountdata();
                targetvaluedata[i].accountvalue = acvaluedata[i].accountvalue;
                //targetvaluedata[i].actualcommission = acvaluedata[i].actualcommission;
                targetvaluedata[i].age = acvaluedata[i].age;
                targetvaluedata[i].commissionpercentvalue = acvaluedata[i].commissionpercentvalue;
                targetvaluedata[i].costofinsurance = acvaluedata[i].costofinsurance;
                targetvaluedata[i].targetoverage = acvaluedata[i].targetoverage;
                //targetvaluedata[i].loadcharge = acvaluedata[i].loadcharge;
                targetvaluedata[i].loadchargepercent = acvaluedata[0].loadchargepercent;
                targetvaluedata[i].monthlyfeevalue = acvaluedata[i].monthlyfeevalue;
                targetvaluedata[i].mortalityrate = acvaluedata[i].mortalityrate;
                targetvaluedata[i].netgrowthrate = acvaluedata[i].netgrowthrate;
                targetvaluedata[i].sno = acvaluedata[i].sno;
                targetvaluedata[i].targetamount = 0;
                targetvaluedata[i].insuredamount = acvaluedata[i].insuredamount;

            }


            double targetamount = Targetamountdata.getTargetamount(0, 100000, 0, 10, targetvaluedata,prodprofile);

            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //- insuredadmount*(1/1000.0) * (1 / )
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;
                double adjustedpremium = acvaluedata[i].premiumamount / (1 + acvaluedata[i].premiumreserve);

                if (acvaluedata[i].premiumamount > 0)
                {
                    commissionamount = targetamount * acvaluedata[i].commissionpercentvalue;
                    if ((adjustedpremium - targetamount) > 0)
                    {
                        //excesscommissionamount = (acvaluedata[i].premiumamount - targetamount) * acvaluedata[i].excesspercentvalue;
                        excesscommissionamount = (adjustedpremium - targetamount) * acvaluedata[i].excesspercentvalue;

                    }
                    commissionamount = commissionamount + excesscommissionamount;
                }

                double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                if (prodprofile.plantypecode == 'F')
                {
                    costofinsurance = (insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }
                else
                {
                    costofinsurance = (insuredamount ) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }

                
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].targetamount = targetamount;
            }
            return accountvalue;
        }








        public static Accountvaluedata[] calculateaccountvaluedata(double insuredadmount, Accountvaluedata[] acvaluedata, Productinvprofile prodprofile)
        {
            double accountvalue = 0.0;

            Targetamountdata[] targetvaluedata = new Targetamountdata[acvaluedata.Length];
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                targetvaluedata[i] = new Targetamountdata();
                targetvaluedata[i].accountvalue = acvaluedata[i].accountvalue;
                //targetvaluedata[i].actualcommission = acvaluedata[i].actualcommission;
                targetvaluedata[i].age = acvaluedata[i].age;
                targetvaluedata[i].commissionpercentvalue = acvaluedata[i].commissionpercentvalue;
                targetvaluedata[i].costofinsurance = acvaluedata[i].costofinsurance;
                targetvaluedata[i].targetoverage = acvaluedata[i].targetoverage;
                //targetvaluedata[i].loadcharge = acvaluedata[i].loadcharge;
                targetvaluedata[i].loadchargepercent = acvaluedata[0].loadchargepercent;
                targetvaluedata[i].monthlyfeevalue = acvaluedata[i].monthlyfeevalue;
                targetvaluedata[i].mortalityrate = acvaluedata[i].mortalityrate;
                targetvaluedata[i].netgrowthrate = acvaluedata[i].netgrowthrate;
                targetvaluedata[i].sno = acvaluedata[i].sno;
                targetvaluedata[i].targetamount = 0;
                targetvaluedata[i].insuredamount = acvaluedata[i].insuredamount;

            }
            double targetamount = Targetamountdata.getTargetamount(0, 100000, 0, 10, targetvaluedata,prodprofile);


            for (int i = 0; i < acvaluedata.Length; i++)
            {
                //double costofinsurance = 0.0;

                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;

                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                double loadcharge = acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;
                double adjustedpremium = acvaluedata[i].premiumamount / (1 + acvaluedata[i].premiumreserve);

                if (acvaluedata[i].premiumamount > 0)
                {
                    commissionamount = targetamount * acvaluedata[i].commissionpercentvalue;
                    if ((adjustedpremium - targetamount) > 0)
                    {
                        //excesscommissionamount = (acvaluedata[i].premiumamount - targetamount) * acvaluedata[i].excesspercentvalue;
                        excesscommissionamount = (adjustedpremium - targetamount) * acvaluedata[i].excesspercentvalue;

                    }
                    commissionamount = commissionamount + excesscommissionamount;
                }

                double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                if (prodprofile.plantypecode == 'F')
                {
                    costofinsurance = (insuredadmount - accountvalue) * (1 / 1000.0) * (acvaluedata[i].mortalityrate * (1 + acvaluedata[i].targetoverage));
                }
                else
                {
                    costofinsurance = (insuredadmount ) * (1 / 1000.0) * (acvaluedata[i].mortalityrate * (1 + acvaluedata[i].targetoverage));
                }
                
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].targetamount = targetamount;
                //double costofinsurance = (insuredadmount - accountvalue) * (1 / 1000.0) * (acvaluedata[i].mortalityrate * (1 + acvaluedata[i].targetoverage));
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission - costofinsurance);
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                acvaluedata[i].costofinsurance = costofinsurance;
                acvaluedata[i].accountvalue = accountvalue;
                //acvaluedata[i].actualcommission = commissionamount;
            }
            return acvaluedata;
        }












        private static Growthcase[] calculategeneralaccountvalue(Accountvaluedata[] acvaluedata, Mainvaluedata maindata, Productinvprofile prodprofile)
        {
            double accountvalue = 0.0;
            Growthcase[] growthdata=new Growthcase[acvaluedata.Length];
            for (int i = 0; i < acvaluedata.Length; i++)
            {
                growthdata[i] = new Growthcase();
                //- insuredadmount*(1/1000.0) * (1 / )
                //double commissionamount = acvaluedata[i].premiumamount * acvaluedata[i].commissionpercentvalue;
                double commissionamount = 0.0;
                double excesscommissionamount = 0.0;
                // calculating loadcharge
                //double loadcharge = acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve)) * acvaluedata[i].loadchargepercent;
                double loadcharge = acvaluedata[i].premiumamount *  acvaluedata[i].loadchargepercent;
                //double adjustedpremium = acvaluedata[i].premiumamount / (1 + acvaluedata[i].premiumreserve);
                double adjustedpremium = acvaluedata[i].premiumamount;
                if (acvaluedata[i].premiumamount > 0)
                {
                    commissionamount = maindata.targetamount * acvaluedata[i].commissionpercentvalue;
                    if ((adjustedpremium - maindata.targetamount) > 0)
                    {
                        //excesscommissionamount = (acvaluedata[i].premiumamount - targetamount) * acvaluedata[i].excesspercentvalue;
                        excesscommissionamount = (adjustedpremium / (1 + acvaluedata[i].premiumreserve) - maindata.targetamount) * acvaluedata[i].excesspercentvalue;
                    }
                    commissionamount = commissionamount + excesscommissionamount;
                }

                double costofinsurance = 0.0;// (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                if (prodprofile.plantypecode == 'F')
                {
                    costofinsurance = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }
                else
                {
                    costofinsurance = (acvaluedata[i].insuredamount ) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) * (1 + acvaluedata[i].targetoverage)) + acvaluedata[i].illnessrisk);
                }

                
                //double costofinsurance = (acvaluedata[i].insuredamount - accountvalue) * (1 / 1000.0) * (((acvaluedata[i].mortalityrate * (1 + acvaluedata[i].activityrisk)) ) + acvaluedata[i].illnessrisk);
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - acvaluedata[i].loadcharge - acvaluedata[i].monthlyfeevalue - acvaluedata[i].commission -costofinsurance);
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount * (1 / (1 + acvaluedata[i].premiumreserve))) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                //accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                accountvalue = (1 + acvaluedata[i].netgrowthrate) * (accountvalue + (acvaluedata[i].premiumamount) - loadcharge - acvaluedata[i].monthlyfeevalue - commissionamount - costofinsurance);
                growthdata[i].Accountvalue = accountvalue;
                growthdata[i].Growthrate = acvaluedata[i].netgrowthrate;
                growthdata[i].Insuredamount = acvaluedata[i].insuredamount;
                growthdata[i].Rescatevalue = 0;
                
            }            
            return growthdata;
        }

        


        
        //public Accountvaluedata getCopy(Accountvaluedata acdata)
        //{
            
            /*Accountvaluedata acdata1 = new Accountvaluedata();
            Type MyTypeObject = Type.GetType(Accountvaluedata.);
            //MyTypeObject.getMem
            MemberInfo[] MyMemberArray = MyTypeObject.GetMembers();
            MyMemberArray.GetValue(0);
            return acdata1;

            /*
            public int sno;
        public int age;
        public double mortalityrate;
        public double premiumamount;
        public double loadcharge;
        public double loadchargepercent;
        public double monthlyfeevalue;
        public double commission;
        public double netgrowthrate;
        public double premiumreserve;
        public double targetoverage;
        public double accountvalue;
        public double costofinsurance;

        public double activityrisk;
        public double illnessrisk;


        public double insuredamount;
        


        public double commissionpercentvalue;
        public double excesspercentvalue;
        public double actualcommission;
        public double targetamount;
        //public double netpremiumamount;
        //public double accountvalue;
        //public double totalaccountvalue;
        */



        //}

    }
}
