using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
    class Portfolioassignment
    {
        private String name;
        private String planname;
        private double annualpremium;
        private double benefitamount;
        private String disillustrationno;
        private String status;
        private Int32 userid;
        private Int64 customerno;
        private Int64 customerplanno;

        public Portfolioassignment(Int64 customerno, String name, double annualpremium, double benefitamount, String disillustrationno, String planname, String status, Int32 userid, Int64 customerplanno)
        {

            this.name = name;
            this.planname = planname;
            this.annualpremium = annualpremium;
            this.benefitamount = benefitamount;
            this.disillustrationno = disillustrationno;
            this.status = status;
            this.userid = userid;
            this.customerno = customerno;
            this.customerplanno = customerplanno;

        }
        public String Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public String Planname
        {
            get { return this.planname; }
            set { this.planname = value; }
        }
        public double Annualpremium
        {
            get { return this.annualpremium; }
            set { this.annualpremium = value; }
        }
        public double Benefitamount
        {
            get { return this.benefitamount; }
            set { this.benefitamount = value; }
        }
        public String Disillustrationno
        {
            get { return this.disillustrationno; }
            set { this.disillustrationno = value; }
        }
        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public Int32 Userid
        {
            get { return this.userid; }
            set { this.userid = value; }
        }
        public Int64 Customerno
        {
            get { return this.customerno; }
            set { this.customerno = value; }
        }
        public Int64 Customerplanno
        {
            get { return this.customerplanno; }
            set { this.customerplanno = value; }
        }




    }
}