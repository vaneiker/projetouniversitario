using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class CalculatetypesOB
    {
        public static char CALCULATE = 'C';
        public static char FORCE = 'F';



        public static char getcalculateobtypecode(String calculateobtype)
        {
            try{
                //calculateobtype = Lookuplangdata.getEnglishvalue(Lookuptables.calculatetypeobdet, calculateobtype);
            calculatetypeobdet calc = (from item in Program.calcobtypeslist
                                       where item.calculatetypeob.Equals(calculateobtype)
                                       select item).SingleOrDefault();
            return calc.calculatetypeobcode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*
            foreach (calculatetypeobdet item in Program.calcobtypeslist)
            {
                if (item.calculatetypeob.Equals(calculateobtype.Trim()))
                {
                    return item.calculatetypeobcode;

                }
            }
            return ' ';
            */
        }

        public static String getcalculatetypeob(char calculateobtypecode)
        {
            try{
            calculatetypeobdet calc = (from item in Program.calcobtypeslist
                                       where item.calculatetypeobcode==calculateobtypecode
                                       select item).SingleOrDefault();
            //return Lookuplangdata.getLanguagevalue(Lookuptables.calculatetypeobdet, calc.calculatetypeob);
            return calc.calculatetypeob;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (calculatetypeobdet item in Program.calcobtypeslist)
            {
                if (item.calculatetypeobcode == calculateobtypecode)
                {
                    return item.calculatetypeob;

                }
            }
            return "";
             */ 
        }

    }
}
