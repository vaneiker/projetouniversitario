using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.blinsurance
{
    public class IVarPlanData
    {

        public static int INSURED = 1;
        public static int PREMIUM = 2;
        public static int SURRENDER =3;
        public static int LOAN = 4;
        public static int LOANREPAY = 5;


        public int fromyear;
        public int toyear;
        public double amount;
    }
}
