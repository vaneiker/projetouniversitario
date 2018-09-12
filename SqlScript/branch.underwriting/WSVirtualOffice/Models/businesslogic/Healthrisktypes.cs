using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Healthrisktypes
    {
        public static int getHealthrisktypeno(String productcode,  String healthrisktype)
        {
            try
            {
                //healthrisktype = Lookuplangdata.getEnglishvalue(Lookuptables.healthrisktypedet, healthrisktype);
                healthrisktypedet healthrisk = (from item in Program.healthrisklist
                                                where item.healthrisktype.Equals(healthrisktype) && item.productcode.Equals(productcode)
                                                select item).SingleOrDefault();
                /*
                foreach (healthrisktypedet item in Program.healthrisklist)
                {
                    if (item.healthrisktype.Equals(healthrisktype.Trim()))
                    {
                        return item.healthrisktypeno;

                    }
                }
                 */
                return healthrisk.healthrisktypeno;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }


        public static String getHealthrisktype(int healthrisktypeno)
        {
            
            /*foreach (healthrisktypedet item in Program.healthrisklist)
            {
                if (item.healthrisktypeno==healthrisktypeno)
                {
                    return item.healthrisktype;

                }
            }
             */
            try
            {
                healthrisktypedet healthrisk = (from item in Program.healthrisklist
                                                where item.healthrisktypeno == healthrisktypeno
                                                select item).SingleOrDefault();

                //return Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet,healthrisk.healthrisktype);
                return healthrisk.healthrisktype;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static String getHealthrisktype(int healthrisktypeno,string productcode)
        {

            /*foreach (healthrisktypedet item in Program.healthrisklist)
            {
                if (item.healthrisktypeno==healthrisktypeno)
                {
                    return item.healthrisktype;

                }
            }
             */
            try
            {
                healthrisktypedet healthrisk = (from item in Program.healthrisklist
                                                where item.healthrisktypeno == healthrisktypeno && item.productcode.Equals(productcode)
                                                select item).SingleOrDefault();

                //return Lookuplangdata.getLanguagevalue(Lookuptables.healthrisktypedet,healthrisk.healthrisktype);
                return healthrisk.healthrisktype;
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static double getHealthriskvalue(int healthrisktypeno)
        {
            try
            {
                healthrisktypedet healthrisk = (from item in Program.healthrisklist
                                                where item.healthrisktypeno == healthrisktypeno
                                                select item).SingleOrDefault();

                return double.Parse(healthrisk.healthriskvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }

            /*
            foreach (healthrisktypedet item in Program.healthrisklist)
            {
                if (item.healthrisktypeno == healthrisktypeno)
                {
                    return double.Parse(item.healthriskvalue.ToString());

                }
            }
            return 0.0;
             */ 

        }
    }
}
