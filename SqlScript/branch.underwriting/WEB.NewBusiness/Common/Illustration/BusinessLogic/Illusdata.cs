using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Illusdata
    {
        public char isdynamicgrowthrate;
        private int sno;
        private int age;
        private double premium;
        private int numscenarios;
        private double commission;
        private double costofinsurance;
        private double costofriders;
        private double ridersaccountvalue;

        private double adbpremium;
        private double acdbpremium;
        private double cipremium;
        private double termpremium;
        private double oirpremium;

        private Growthcase[] growthdata;

        public String[] getDataarray()
        {
            String[] str1 = null;
            str1 = new String[numscenarios * 3 + 4];
            str1[0] = sno.ToString();
            str1[1] = age.ToString();
            if (premium > 0)
                str1[2] = String.Format("{0:N0}", premium);// .ToString();

            for (int i = 0; i < numscenarios; i++)
                if (this.sno <= 3)
                {
                    if (growthdata[i].Accountvalue > 0)
                        str1[2 + i * 3 + 1] = String.Format("{0:N0}", growthdata[i].Accountvalue);// growthdata[i].Accountvalue.ToString();
                    if (growthdata[i].Rescatevalue > 0)
                        str1[2 + i * 3 + 2] = String.Format("{0:N0}", growthdata[i].Rescatevalue);
                    if (growthdata[i].Insuredamount > 0)
                        str1[2 + i * 3 + 3] = String.Format("{0:N0}", growthdata[i].Insuredamount);
                }
                else
                {
                    if (growthdata[i].Accountvalue > 0)
                        str1[2 + i * 3 + 1] = String.Format("{0:N0}", growthdata[i].Accountvalue);// growthdata[i].Accountvalue.ToString();
                    if ((growthdata[i].Accountvalue > 0) & (growthdata[i].Rescatevalue > 0))
                        str1[2 + i * 3 + 2] = String.Format("{0:N0}", growthdata[i].Rescatevalue);
                    if ((growthdata[i].Accountvalue > 0) & (growthdata[i].Insuredamount > 0))
                        str1[2 + i * 3 + 3] = String.Format("{0:N0}", growthdata[i].Insuredamount);
                }

            if (isdynamicgrowthrate == 'Y')
                str1[2 + 3 * 3 + 1] = String.Format("{0:N0}", growthdata[2].Growthrate);
            else
                str1[2 + 3 * 3 + 1] = "";
            return str1;
        }

        public String[] getDataarray_test()
        {
            String[] str1 = null;
            str1 = new String[numscenarios * 3 + 13];
            str1[0] = sno.ToString();
            str1[1] = age.ToString();
            if (premium > 0)
                str1[2] = String.Format("{0:N0}", premium);// .ToString();

            for (int i = 0; i < numscenarios; i++)
                if (this.sno <= 3)
                {
                    if (growthdata[i].Accountvalue > 0)
                        str1[2 + i * 3 + 1] = String.Format("{0:N0}", growthdata[i].Accountvalue);// growthdata[i].Accountvalue.ToString();
                    if (growthdata[i].Rescatevalue > 0)
                        str1[2 + i * 3 + 2] = String.Format("{0:N0}", growthdata[i].Rescatevalue);
                    if (growthdata[i].Insuredamount > 0)
                        str1[2 + i * 3 + 3] = String.Format("{0:N0}", growthdata[i].Insuredamount);
                }
                else
                {
                    if (growthdata[i].Accountvalue > 0)
                        str1[2 + i * 3 + 1] = String.Format("{0:N0}", growthdata[i].Accountvalue);// growthdata[i].Accountvalue.ToString();
                    if ((growthdata[i].Accountvalue > 0) & (growthdata[i].Rescatevalue > 0))
                        str1[2 + i * 3 + 2] = String.Format("{0:N0}", growthdata[i].Rescatevalue);
                    if ((growthdata[i].Accountvalue > 0) & (growthdata[i].Insuredamount > 0))
                        str1[2 + i * 3 + 3] = String.Format("{0:N0}", growthdata[i].Insuredamount);
                }

            if (isdynamicgrowthrate == 'Y')
                str1[2 + 3 * 3 + 1] = String.Format("{0:N0}", growthdata[2].Growthrate);
            else
                str1[2 + 3 * 3 + 1] = "";

            str1[2 + 3 * 3 + 2] = String.Format("{0:N0}", commission);
            str1[2 + 3 * 3 + 3] = String.Format("{0:N0}", costofinsurance);
            str1[2 + 3 * 3 + 4] = String.Format("{0:N0}", costofriders);
            str1[2 + 3 * 3 + 5] = String.Format("{0:N0}", ridersaccountvalue);

            str1[2 + 3 * 3 + 6] = String.Format("{0:N0}", adbpremium);
            str1[2 + 3 * 3 + 7] = String.Format("{0:N0}", acdbpremium);
            str1[2 + 3 * 3 + 8] = String.Format("{0:N0}", cipremium);
            str1[2 + 3 * 3 + 9] = String.Format("{0:N0}", termpremium);
            str1[2 + 3 * 3 + 10] = String.Format("{0:N0}", oirpremium);
            return str1;
        }

        public String[] getDatacolumns()
        {
            String[] str1 = null;// new String[numscenarios * 3 + 3];            
            str1 = new String[numscenarios * 3 + 4];
            str1[0] = "Sno";
            str1[1] = "Age";
            str1[2] = "Premium";
            for (int i = 0; i < numscenarios; i++)
            {
                str1[2 + i * 3 + 1] = "Accountvalue" + (i + 1).ToString();
                str1[2 + i * 3 + 2] = "Rescatevalue" + (i + 1).ToString();
                str1[2 + i * 3 + 3] = "Insuredamount" + (i + 1).ToString();
            }

            str1[2 + 3 * 3 + 1] = "Growthrate" + (3).ToString();
            return str1;
        }

        public String[] getDatacolumns_test()
        {
            String[] str1 = null;// new String[numscenarios * 3 + 3];            
            str1 = new String[numscenarios * 3 + 13];
            str1[0] = "Sno";
            str1[1] = "Age";
            str1[2] = "Premium";
            for (int i = 0; i < numscenarios; i++)
            {
                str1[2 + i * 3 + 1] = "Accountvalue" + (i + 1).ToString();
                str1[2 + i * 3 + 2] = "Rescatevalue" + (i + 1).ToString();
                str1[2 + i * 3 + 3] = "Insuredamount" + (i + 1).ToString();
            }

            str1[2 + 3 * 3 + 1] = "Growthrate" + (3).ToString();
            str1[2 + 3 * 3 + 2] = "commission".ToString();
            str1[2 + 3 * 3 + 3] = "costofinsurance".ToString();
            str1[2 + 3 * 3 + 4] = "costofriders".ToString();
            str1[2 + 3 * 3 + 5] = "ridersaccountvalue".ToString();

            str1[2 + 3 * 3 + 6] = "adbpremium".ToString();
            str1[2 + 3 * 3 + 7] = "acdbpremium".ToString();
            str1[2 + 3 * 3 + 8] = "cipremium".ToString();
            str1[2 + 3 * 3 + 9] = "termpremium".ToString();
            str1[2 + 3 * 3 + 10] = "oirpremium".ToString();
            return str1;
        }

        public int Sno
        {
            get { return this.sno; }
            set { this.sno = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public double Premium
        {
            get { return this.premium; }
            set { this.premium = value; }
        }

        public Growthcase[] Growthdata
        {
            get { return this.growthdata; }
            set { this.growthdata = value; }
        }

        public int Numscenarios
        {
            get { return this.numscenarios; }
            set
            {
                this.numscenarios = value;
                this.Growthdata = new Growthcase[value];
                for (int i = 0; i < value; i++)
                {
                    growthdata[i] = new Growthcase();
                }
            }
        }

        public double Commission
        {
            get { return this.commission; }
            set { this.commission = value; }
        }

        public double Costofinsurance
        {
            get { return this.costofinsurance; }
            set { this.costofinsurance = value; }
        }

        public double Costofriders
        {
            get { return this.costofriders; }
            set { this.costofriders = value; }
        }

        public double Ridersaccountvalue
        {
            get { return this.ridersaccountvalue; }
            set { this.ridersaccountvalue = value; }
        }

        public double Adbpremium
        {
            get { return this.adbpremium; }
            set { this.adbpremium = value; }
        }

        public double Acdbpremium
        {
            get { return this.acdbpremium; }
            set { this.acdbpremium = value; }
        }

        public double Cipremium
        {
            get { return this.cipremium; }
            set { this.cipremium = value; }
        }

        public double Termpremium
        {
            get { return this.termpremium; }
            set { this.termpremium = value; }
        }

        public double Oirpremium
        {
            get { return this.oirpremium; }
            set { this.oirpremium = value; }
        }
    }
}