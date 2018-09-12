using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Phonetypes
    {
        public static char HOME = 'H';
        public static char WORK = 'W';
        public static char CELL = 'C';
        public static char OTHER = 'O';


        public static char getPhonetypecode(String phonetype)
        {
            try
            {
                //phonetype = Lookuplangdata.getEnglishvalue(Lookuptables.phonetypedet, phonetype);
                var phonetypecode = (from phone in Program.phonetypelist
                                     where phone.phonetype.Equals(phonetype)
                                     select phone).SingleOrDefault().phonetypecode;
                return phonetypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }

        public static String getPhonetype(char phonetypecode)
        {
            try
            {
                var phonetype = (from phone in Program.phonetypelist
                                 where phone.phonetypecode == phonetypecode
                                 select phone).SingleOrDefault().phonetype;
                //return Lookuplangdata.getLanguagevalue(Lookuptables.phonetypedet,phonetype);
                return phonetype;
            }
            catch (Exception ex)
            {
                return "";
            }

        }


    }
}
