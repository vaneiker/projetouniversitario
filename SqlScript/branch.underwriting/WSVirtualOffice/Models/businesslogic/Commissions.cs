using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.blinsurance;

namespace WSVirtualOffice.Models.businesslogic
{
    class Commissions
    {


        public static ICommissiondata[] getCommissiondata(String productcode, int startyearno, int contributionperiod)
        {
            try
            {
                var comdata = from item in Program.commissionlist
                              where (item.productcode.Equals(productcode) && (item.yearno >= startyearno))
                              select item;
                int sno = 0;
                ICommissiondata[] comisdata = new ICommissiondata[comdata.Count()];
                foreach (commissiondet item in comdata)
                {
                    sno++;
                    comisdata[sno - 1] = new ICommissiondata();
                    comisdata[sno - 1].sno = sno;
                    comisdata[sno - 1].commissionpercent =Double.Parse(item.regularcomm.ToString());
                    comisdata[sno - 1].excesscommissionpercent = Double.Parse(item.excesscomm.ToString());
                    comisdata[sno - 1].vr= Double.Parse(item.vr.ToString());

                }
                return comisdata;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static double getCommissionpercentvalue(String productcode, int sno)
        {
            try
            {

                commissiondet comm = (from item in Program.commissionlist
                                      where (item.productcode.Equals(productcode) && (item.yearno == sno))
                                      select item).SingleOrDefault();
                return Double.Parse(comm.regularcomm.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }

        }

        public static double getExcesscommissionpercent(String productcode, int sno)
        {
            try
            {
                commissiondet comm = (from item in Program.commissionlist
                                      where (item.productcode.Equals(productcode) && (item.yearno == sno))
                                      select item).SingleOrDefault();
                return Double.Parse(comm.excesscomm.ToString());
            }
            catch (Exception ex)
            {
                return 0.0;
            }
        }

        
    }
}
