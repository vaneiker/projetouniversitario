using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Surrenderpenaties
    {
        public static double getSurrenderpenaltyvalue(String productcode, int sno)
        {
            try
            {
                surrenderpenaltydet surr = (from item in Program.surrenderpenaltylist
                                            where (item.productcode.Equals(productcode) && (item.yearno == sno))
                                            select item).SingleOrDefault();
                return Double.Parse(surr.penaltypercent.ToString());

            }
            catch (Exception ex)
            {
                return 0.0;
            }
            
        }


        public static WSVirtualOffice.Models.blinsurance.ISurrenderpenaltydata[] getSurrenderpenaltydata(String productcode, int startsno)
        {
            try
            {
                var surdata = from item in Program.surrenderpenaltylist
                                            where (item.productcode.Equals(productcode) && (item.yearno >= startsno))
                                            select item;
                //return Double.Parse(surr.penaltypercent.ToString());
                WSVirtualOffice.Models.blinsurance.ISurrenderpenaltydata[] surdata1 = new WSVirtualOffice.Models.blinsurance.ISurrenderpenaltydata[surdata.Count()];

                int sno = 0;
                foreach (surrenderpenaltydet item in surdata)
                {
                    sno++;
                    surdata1[sno - 1] = new WSVirtualOffice.Models.blinsurance.ISurrenderpenaltydata();
                    surdata1[sno - 1].sno = sno;
                    surdata1[sno - 1].penaltypercent = Double.Parse(item.penaltypercent.ToString());                                        
                }
                return surdata1;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        
    }
}
