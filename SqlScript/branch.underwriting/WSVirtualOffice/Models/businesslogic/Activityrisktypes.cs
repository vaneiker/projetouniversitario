using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Activityrisktypes
    {

        public static int getActivityrisktypeno(String productcode,String activityrisktype)
        {
            try
            {
                //activityrisktype = Lookuplangdata.getEnglishvalue(Lookuptables.activityrisktypedet ,activityrisktype);

                activityrisktypedet actrisk = (from item in Program.actrisklist
                                               where item.activityrisktype.Equals(activityrisktype) && item.productcode.Equals(productcode)
                                               select item).SingleOrDefault();
                /*
                foreach (activityrisktypedet item in Program.actrisklist)
                {
                    if (item.activityrisktype.Equals(activityrisktype.Trim()) && item.productcode.Equals(productcode.Trim()))
                    {
                        return item.activityrisktypeno;

                    }
                }
                 */
                return actrisk.activityrisktypeno;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        public static String getActivityrisktype(int activityrisktypeno)
        {
            try
            {
                activityrisktypedet actrisk = (from item in Program.actrisklist
                                               where item.activityrisktypeno == activityrisktypeno
                                               select item).SingleOrDefault();

                /*
                foreach (activityrisktypedet item in Program.actrisklist)
                {
                    if (item.activityrisktypeno==activityrisktypeno)
                    {
                        return item.activityrisktype;

                    }
                }
                 */
                //return  Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, actrisk.activityrisktype);
                return actrisk.activityrisktype;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static String getActivityrisktype(int activityrisktypeno,string productcode)
        {
            try
            {
                activityrisktypedet actrisk = (from item in Program.actrisklist
                                               where item.activityrisktypeno == activityrisktypeno && item.productcode.Equals(productcode)
                                               select item).SingleOrDefault();

                /*
                foreach (activityrisktypedet item in Program.actrisklist)
                {
                    if (item.activityrisktypeno==activityrisktypeno)
                    {
                        return item.activityrisktype;

                    }
                }
                 */
                //return  Lookuplangdata.getLanguagevalue(Lookuptables.activityrisktypedet, actrisk.activityrisktype);
                return actrisk.activityrisktype;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static double getActivityriskvalue(int activityrisktypeno)
        {
            /*
            foreach (activityrisktypedet item in Program.actrisklist)
            {
                if (item.activityrisktypeno == activityrisktypeno)
                {
                    return Double.Parse(item.activityriskvalue.ToString());

                }
            }*/
            try{
            activityrisktypedet actrisk = (from item in Program.actrisklist
                                           where item.activityrisktypeno==activityrisktypeno
                                           select item).SingleOrDefault();
            return Double.Parse(actrisk.activityriskvalue.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }
    }
}
