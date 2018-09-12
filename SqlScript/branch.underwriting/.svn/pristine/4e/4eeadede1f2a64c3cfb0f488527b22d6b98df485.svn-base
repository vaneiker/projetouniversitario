using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Examconditions
    {


        public static int getRandom(int maxnum)
        {
            Random r = new Random();
            int i = r.Next();
            return (i % maxnum);
        }

        public static IEnumerable<examconditionsdet> getExams(int age, char gendercode, char maritalcode, decimal insuredamount,String productcode,char clase)
        {
            try
            {
                IEnumerable<examconditionsdet> examslist = from item in Program.examconditionslist
                                                           where item.@class.Equals(clase)
                                                           where (item.productcode.Equals(productcode)) && (item.gendercode == gendercode || item.gendercode == 'A') && (age >= item.minage && age <= item.maxage) && (item.maritalstatuscode == maritalcode || item.maritalstatuscode == 'A')
                                                           where insuredamount >= item.mininsuredamount.Value && insuredamount <= item.maxinsuredamount.Value 
                                                           select item;

                return examslist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }


    
}
