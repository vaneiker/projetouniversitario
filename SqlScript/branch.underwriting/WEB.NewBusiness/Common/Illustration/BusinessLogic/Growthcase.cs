using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public struct Growthcase
    {
        private double growthrate;
        private double accountvalue;
        private double rescatevalue;
        private double insuredamount;

        public Growthcase(double growthrate, double accountvalue, double rescatevalue, double insuredamount)
        {
            this.growthrate = growthrate;
            this.accountvalue = accountvalue;
            this.rescatevalue = rescatevalue;
            this.insuredamount = insuredamount;
        }

        public double Growthrate
        {
            get { return this.growthrate; }
            set { this.growthrate = value; }
        }

        public double Accountvalue
        {
            get { return this.accountvalue; }
            set { this.accountvalue = value; }
        }

        public double Rescatevalue
        {
            get { return this.rescatevalue; }
            set { this.rescatevalue = value; }
        }

        public double Insuredamount
        {
            get { return this.insuredamount; }
            set { this.insuredamount = value; }
        }

    }
}