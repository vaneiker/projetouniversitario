using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Languages
    {
        public static String getlanguagecode(String language)
        {
            try
            {
                languagedet langdata = (from item in Program.languageslist
                                        where item.languagename.Equals(language)
                                        select item).SingleOrDefault();
                return langdata.languagecode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*

            foreach (languagedet item in Program.languageslist)
            {
                if (item.languagename.Equals(language.Trim()))
                {
                    return item.languagecode;

                }
            }
            return "";
             */ 

        }

        public static String getlanguage(String languagecode)
        {
            try
            {
                languagedet langdata = (from item in Program.languageslist
                                        where item.languagecode.Equals(languagecode)
                                        select item).SingleOrDefault();
                return langdata.languagecode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (languagedet item in Program.languageslist)
            {
                if (item.languagecode.Equals(languagecode))
                {
                    return item.languagename;

                }
            }
            return "";
             */ 
        }

    }
}
