using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Calculatetypes
    {

        public static char INSUREDAMOUNT = 'I';
        public static char PREMIUMAMOUNT = 'P';
        public static char VERIFY = 'V';
        public static char ANNUITYAMOUNT = 'A';


        public static char getcalculatetypecode(String calculatetype)
        {
            try{
                //calculatetype = Lookuplangdata.getEnglishvalue(Lookuptables.calculatetypedet, calculatetype);
                calculatetypedet calc = (from item in Program.calctypeslist
                                         where item.calculatetype.Equals(calculatetype)
                                         select item).SingleOrDefault();
                return calc.calculatetypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*
            foreach (calculatetypedet item in Program.calctypeslist)
            {
                if (item.calculatetype.Equals(calculatetype.Trim()))
                {
                    return item.calculatetypecode;

                }
            }
            return ' ';
            */
        }

        public static String getcalculatetype(char calculatetypecode)
        {
            try{
                calculatetypedet calc = (from item in Program.calctypeslist
                                         where item.calculatetypecode== calculatetypecode
                                         select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypedet,calc.calculatetype);
                return calc.calculatetype;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (calculatetypedet item in Program.calctypeslist)
            {
                if (item.calculatetypecode==calculatetypecode)
                {
                    return item.calculatetype;

                }
            }
            return "";
             */ 
        }

    }
}
