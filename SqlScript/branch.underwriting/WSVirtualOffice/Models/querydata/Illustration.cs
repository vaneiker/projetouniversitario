using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.querydata
{
    public class Illustration
    {
        public enum Illussortorder
        {
            name = 1,
            planname = 2,
            plantype = 3,
            annualpremium = 4,
            benefitamount = 5,
            dispillustrationno = 6,
            dispplancode = 7,
            lastupdated = 8,
            customerplanno = 9,
            customerno = 10,
            classcode = 11
        }

        /*
        public static String Orderby(Sortorder sortno){
            if(sortno==Sortorder.name){ 
                return " firstname";
            }
            else if(sortno==Sortorder.planname){
                return " product";
            }
            else if(sortno==Sortorder.planname){
                return " product";
            }
            else{
                return " firstname";
            }
        }
         */


        private String name;
        private String planname;
        private String plantype;
        private double annualpremium;
        private double benefitamount;
        private String dispillustrationno;
        private String dispplancode;
        private DateTime lastupdated;
        private long customerplanno;
        private long customerno;
        private char classcode;
        private char plangroupcode;

        public Illustration(String name, String planname, String plantype, double annualpremium, double benefitamount, String dispillustrationno, String dispplancode, DateTime lastupdated, long customerplanno, long customerno, char classcode)
        {
            this.name = name;
            this.planname = planname;
            this.plantype = plantype;
            this.annualpremium = annualpremium;
            this.benefitamount = benefitamount;
            this.dispillustrationno = dispillustrationno;
            this.dispplancode = dispplancode;
            this.lastupdated = lastupdated;
            this.customerplanno = customerplanno;
            this.customerno = customerno;
            this.classcode = classcode;
            //this.customerplanno = customerplanno;                    
        }
        
        public Illustration(String name, String planname, String plantype, double annualpremium, double benefitamount, String dispillustrationno, String dispplancode, DateTime lastupdated, long customerplanno, long customerno, char classcode, char plangroupcode)
        {
            this.name = name;
            this.planname = planname;
            this.plantype = plantype;
            this.annualpremium = annualpremium;
            this.benefitamount = benefitamount;
            this.dispillustrationno = dispillustrationno;
            this.dispplancode = dispplancode;
            this.lastupdated = lastupdated;
            this.customerplanno = customerplanno;
            this.customerno = customerno;
            this.classcode = classcode;
            this.plangroupcode = plangroupcode;
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

        public String Plantype
        {
            get { return this.plantype; }
            set { this.plantype = value; }
        }

        public String Annualpremium
        {
            get
            {
                return Currencytypes.Currencycode(classcode) + " " + annualpremium.ToString("0,0");
            }
        }

        public String Benefitamount
        {
            get
            {
                return Currencytypes.Currencycode(classcode) + " " + benefitamount.ToString("0,0");
            }
            //set { this.benefitamount = value; }
        }

        public String Dispillustrationno
        {
            get { return this.dispillustrationno; }
            set { this.dispillustrationno = value; }
        }

        public String Dispplancode
        {
            get
            {
                if (dispplancode != null)
                {
                    return this.dispplancode;
                }
                else
                {
                    return "Prospect";
                }
            }
            set { this.dispplancode = value; }
        }

        public DateTime Lastupdated
        {
            get { return this.lastupdated; }
            set { this.lastupdated = value; }
        }

        public long Customerplanno
        {
            get { return this.customerplanno; }
            set { this.customerplanno = value; }
        }

        public long Customerno
        {
            get { return this.customerno; }
            set { this.customerno = value; }
        }

        public char Plangroupcode
        {
            get { return plangroupcode; }
            set { plangroupcode = value; }
        }




    }
}
