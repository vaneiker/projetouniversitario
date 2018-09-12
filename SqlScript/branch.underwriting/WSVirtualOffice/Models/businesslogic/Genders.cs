using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Genders
    {

        public static char Male = 'M';
        public static char Female = 'F';


        public static char getgendercode(String gender)
        {
            try
            {
                //gender = Lookuplangdata.getEnglishvalue(Lookuptables.genderdet, gender);
                genderdet genderdata = (from item in Program.genderlist
                                        where item.gendername.Equals(gender)
                                        select item).SingleOrDefault();
                return genderdata.gendercode;
            }
            catch (Exception ex)
            {
                return ' ';
            }


            /*

            foreach (genderdet item in Program.genderlist)
            {
                if (item.gendername.Equals(gender.Trim()))
                {
                    return item.gendercode;

                }
            }
            return ' ';
             */ 

        }

        public static String getgender(char gendercode)
        {
            try
            {
                genderdet genderdata = (from item in Program.genderlist
                                        where item.gendercode == gendercode
                                        select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.genderdet, genderdata.gendername);
                return genderdata.gendername;
            }            
            catch (Exception ex)
            {
                return "Select";
            }

            /*
            foreach (genderdet item in Program.genderlist)
            {
                if (item.gendercode == gendercode)
                {
                    return item.gendername;

                }
            }
            return "";
             */ 
        }
    }
}
