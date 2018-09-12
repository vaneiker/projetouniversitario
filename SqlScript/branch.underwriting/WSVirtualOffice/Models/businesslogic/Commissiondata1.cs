using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Commissiondata1
    {
        private String productcode;        
        private int yearno;
        private String vr;        
        private String addpanalty;
        private String regcomm;
        private String excesscomm;
        private int commissionno;

        

        public Commissiondata1(String productcode,int yearno,String vr,String addpanalty,String regcomm,String excesscomm,int commissionno)
        {
            this.productcode = Productdata.getProduct(productcode);
            this.yearno = yearno;
            this.vr = vr;
            this.addpanalty = addpanalty;
            this.regcomm = regcomm;
            this.excesscomm = excesscomm;
            this.commissionno = commissionno;
        }

        public String Productcode
        {
            get { return productcode; }
            set { productcode = value; }
        }

        public int Yearno
        {
            get { return yearno; }
            set { yearno = value; }
        }

        public String Vr
        {
            get { return vr; }
            set { vr = value; }
        }

        public String Addpanalty
        {
            get { return addpanalty; }
            set { addpanalty = value; }
        }

        public String Regcomm
        {
            get { return regcomm; }
            set { regcomm = value; }
        }

        public String Excesscomm
        {
            get { return excesscomm; }
            set { excesscomm = value; }
        }

        public int Commissionno
        {
            get { return commissionno; }
            set { commissionno = value; }
        }
    }
}