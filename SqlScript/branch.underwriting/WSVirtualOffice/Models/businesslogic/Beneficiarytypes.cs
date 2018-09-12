using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Beneficiarytypes
    {
        public static char getbeneficiarytypecode(String beneficiarytype)
        {
            try{
            beneficiarytypedet beneficiary = (from item in Program.beneficiarytypeslist
                                              where item.beneficiarytype.Equals(beneficiarytype)
                                              select item).SingleOrDefault();
            /*
            foreach (beneficiarytypedet item in Program.beneficiarytypeslist)
            {
                if (item.beneficiarytype.Equals(beneficiarytype.Trim()))
                {
                    return item.beneficiarytypecode;

                }
            }
             */ 
            return beneficiary.beneficiarytypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }

        public static String getbeneficiarytype(char beneficiarytypecode)
        {
            try{
            beneficiarytypedet beneficiary = (from item in Program.beneficiarytypeslist
                                              where item.beneficiarytypecode==beneficiarytypecode
                                              select item).SingleOrDefault();
            /*
            foreach (beneficiarytypedet item in Program.beneficiarytypeslist)
            {
                if (item.beneficiarytypecode.Equals(beneficiarytypecode))
                {
                    return item.beneficiarytype;

                }
            }*/
            return beneficiary.beneficiarytype;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
