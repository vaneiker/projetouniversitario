using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Insurancelevels
    {



        public static char getInsurancelevelcode(String insurancelevel)
        {
            try
            {
                var invprofile = (from item in Program.insurancelevelslist
                                  where item.insurancelevel.Trim().Equals(insurancelevel)
                                  select item).SingleOrDefault();
                return invprofile.insurancelevelcode;
            }
            catch (Exception ex)
            {
                return ' ';
            }

        }

        public static String getinsurancelevel(char insurancelevelcode)
        {
            try
            {
                var invprofile = (from item in Program.insurancelevelslist
                                  where item.insurancelevelcode == insurancelevelcode
                                  select item).SingleOrDefault();
                return invprofile.insurancelevel;
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}
