using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Countries
    {
        public static int getcountryno(String country)
        {
            try
            {
                //country = Lookuplangdata.getEnglishvalue(Lookuptables.countrydet, country);
                countrydet contry = (from item in Program.countrieslist
                                     where item.countryname.Equals(country)
                                     select item).SingleOrDefault();
                return contry.countryno;
            }
            catch (Exception ex)
            {
                return 0;
            }
            /*
            foreach (countrydet item in Program.countrieslist)
            {
                if (item.countryname.Equals(country.Trim()))
                {
                    return item.countryno;

                }
            }
            return 0;
             */ 

        }

        public static Boolean isAdb(String country)
        {
            //country = Lookuplangdata.getEnglishvalue(Lookuptables.countrydet, country);
            countrydet contry = (from item in Program.countrieslist
                                 where item.countryname.Equals(country)
                                 select item).SingleOrDefault();
            return contry.adb.Value=='Y'?true:false;
            //return false;
        }

        public static String getcountry(int countryno)
        {
            try
            {
                countrydet contry = (from item in Program.countrieslist
                                     where item.countryno == countryno
                                     select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.countrydet, contry.countryname);
                return contry.countryname;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (countrydet item in Program.countrieslist)
            {
                if (item.countryno==countryno)
                {
                    return item.countryname;

                }
            }
            return "";
             */ 
        }


        public static double getRiskvalue(String country)
        {
            try
            {
                countrydet contry = (from item in Program.countrieslist
                                     where item.countryname.Equals(country)
                                     select item).SingleOrDefault();
                return double.Parse(contry.riskvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            /*
            foreach (countrydet item in Program.countrieslist)
            {
                if (item.countryname.Equals(country))
                {
                    return double.Parse(item.riskvalue.ToString());
                }
            }
            return 0.0;
             */ 
        }

        public static double getRiskvalueByNo(int countryno)
        {
            try
            {
                countrydet contry = (from item in Program.countrieslist
                                     where item.countryno==countryno
                                     select item).SingleOrDefault();
                return double.Parse(contry.riskvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            
        }

        public static double getCountryriskvalue(int countryno)
        {
            try
            {
                countrydet contry = (from item in Program.countrieslist
                                     where item.countryno==countryno
                                     select item).SingleOrDefault();
                return double.Parse(contry.riskvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            
        }

    }
}
