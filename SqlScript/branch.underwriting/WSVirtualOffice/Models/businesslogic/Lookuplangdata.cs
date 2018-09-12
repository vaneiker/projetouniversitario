using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Lookuplangdata
    {
        public static String getEnglishvalue(String tablename, String languagecaption, String language)
        {

            if (language.Equals(Langdata.LANGUAGE_ENGLISH))
            {
                return languagecaption;
            }
            else if (language.Equals(Langdata.LANGUAGE_SPANISH))
            {
                try
                {
                    var itemdata = (from item in Program.lookupdatalist
                                    where item.tablename.Equals(tablename) && item.spanish.Equals(languagecaption)
                                    select item).SingleOrDefault();
                    return itemdata.lookupcaption;
                }
                catch (Exception e)
                {
                    return languagecaption;
                }
                
            }
            else if (language.Equals(Langdata.LANGUAGE_PORTUGESE))
            {
                try
                {
                    var itemdata = (from item in Program.lookupdatalist
                                    where item.tablename.Equals(tablename) && item.portugese.Equals(languagecaption)
                                    select item).SingleOrDefault();
                    return itemdata.lookupcaption;
                }
                catch (Exception e)
                {
                    return languagecaption;
                }
                
            }
            else if (language.Equals(Langdata.LANGUAGE_FRENCH))
            {
                try
                {
                    var itemdata = (from item in Program.lookupdatalist
                                    where item.tablename.Equals(tablename) && item.french.Equals(languagecaption)
                                    select item).SingleOrDefault();
                    return itemdata.lookupcaption;
                }
                catch (Exception e)
                {
                    return languagecaption;
                }                
            }
            else
            {
                return languagecaption;
            }
            
        }

        public static List<String> getLanguagelist(String tablename,String language)
        {

            List<String> resultlist=new List<string>();
            IEnumerable<lookupdatadet> listdata = null;
            if (language.Equals(Langdata.LANGUAGE_ENGLISH))
            {
                listdata = from item1 in Program.lookupdatalist
                              where item1.tablename.Equals(tablename)
                              orderby item1.lookuporderno
                              select item1 ;
                foreach (lookupdatadet item in listdata)
                {
                    resultlist.Add(item.lookupcaption);
                }                
            }
            else if (language.Equals(Langdata.LANGUAGE_SPANISH))
            {
                listdata = from item1 in Program.lookupdatalist
                           where item1.tablename.Equals(tablename)
                           orderby item1.lookuporderno
                           select item1;
                foreach (lookupdatadet item in listdata)
                {
                    resultlist.Add(item.spanish);
                }
            }
            else if (language.Equals(Langdata.LANGUAGE_FRENCH))
            {
                listdata = from item1 in Program.lookupdatalist
                           where item1.tablename.Equals(tablename)
                           orderby item1.lookuporderno
                           select item1;
                foreach (lookupdatadet item in listdata)
                {
                    resultlist.Add(item.french);
                }
            }
            else if (language.Equals(Langdata.LANGUAGE_PORTUGESE))
            {
                listdata = from item1 in Program.lookupdatalist
                           where item1.tablename.Equals(tablename)
                           orderby item1.lookuporderno
                           select item1;
                foreach (lookupdatadet item in listdata)
                {
                    resultlist.Add(item.portugese);
                }
            }
            else if (language.Equals(Langdata.LANGUAGE_CHINESE))
            {
                listdata = from item1 in Program.lookupdatalist
                           where item1.tablename.Equals(tablename)
                           orderby item1.lookuporderno
                           select item1;
                foreach (lookupdatadet item in listdata)
                {
                    resultlist.Add(item.chinese);
                }
            }
            return resultlist;
        }


        public static String getLanguagevalue(String tablename, String englishcaption, String language)
        {
            if (language.Equals(Langdata.LANGUAGE_ENGLISH))
            {
                return englishcaption;
            }
            else 
            {
                try
                {
                    var itemdata = (from item in Program.lookupdatalist
                                    where item.tablename.Equals(tablename) && item.lookupcaption.Equals(englishcaption)
                                    select item).SingleOrDefault();


                    if (language.Equals(Langdata.LANGUAGE_SPANISH))
                    {
                        return itemdata.spanish;
                    }
                    else if (language.Equals(Langdata.LANGUAGE_PORTUGESE))
                    {
                        return itemdata.portugese;
                    }
                    else if (language.Equals(Langdata.LANGUAGE_FRENCH))
                    {
                        return itemdata.french;
                    }
                    else
                    {
                        return englishcaption;
                    }
                }
                catch (Exception e)
                {
                    return englishcaption;
                }          
                
            }            
        }
    }
}
