using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.businesslogic
{
    class MortalityClass
    {
        
        private String product;
        private String mortalityno;
        private String age;
        private String malenosmoker;
        private String femalenosmoker;
        private String malesmoker;
        private String femalesmoker;
        private String productcode;
        private String ridertypecode;

        public MortalityClass(String product, String mortalityno, String age, String malenosmoker, String femalenosmoker, String malesmoker, String femalesmoker, String productcode, String ridertypecode)
        {
            
            this.product = product;
            this.mortalityno = mortalityno;
            this.age = age;
            this.malenosmoker = malenosmoker;
            this.femalenosmoker = femalenosmoker;
            this.malesmoker = malesmoker;
            this.femalesmoker = femalesmoker;
            this.productcode = productcode;
            this.ridertypecode = ridertypecode;

        }


        public String Product
        {
            get { return this.product; }
            set { this.product = value; }
        }



        public String MortalityNo
        {
            get { return this.mortalityno; }
            set { this.mortalityno = value; }
        }
       
        public String Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public String MaleNoSmoker
        {
            get { return this.malenosmoker; }
            set { this.malenosmoker = value; }
        }
        public String FemaleNoSmoker
        {
            get { return this.femalenosmoker; }
            set { this.femalenosmoker = value; }
        }
        public String MaleSmoker
        {
            get { return this.malesmoker; }
            set { this.malesmoker = value; }
        }
        public String FemaleSmoker
        {
            get { return this.femalesmoker; }
            set { this.femalesmoker = value; }
        }
        public String ProductCode
        {
            get { return this.productcode; }
            set { this.productcode = value; }
        }
        public String RiderTypeCode
        {
            get { return this.ridertypecode; }
            set { this.ridertypecode = value; }
        }

    }
}