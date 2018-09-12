using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    public class IMortalitydata
    {
        public int sno;
        public int age;
        public double mortalityvalue;

        public IMortalitydata()
        {

        }

        public IMortalitydata(int sno,int age,double mortalityvalue)
        {
            this.age = age;
            this.sno = sno;
            this.mortalityvalue = mortalityvalue;
        }

    }

    
}
