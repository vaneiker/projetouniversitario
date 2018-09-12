using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WSVirtualOffice.Models.businesslogic
{
    public class DefermentPeriod
    {
        public long DefermentPeriodId;
        public string productCode;
        public int period;

        public DefermentPeriod()
        {

        }

        public DefermentPeriod(long DefermentPeriodId, string productCode, int period)
        {
            this.DefermentPeriodId = DefermentPeriodId;
            this.productCode = productCode;
            this.period = period;
        }

        public static List<string> GetDefermentPeriods(string productCode, string selectText)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                List<defermentperioddet> list = (from a in Program.defermentperiodlist
                                               where a.productcode.Equals(productCode)
                                               select a).ToList();

                List<string> defermentPeriod = new List<string>();
                defermentPeriod.Add(selectText);
                foreach (defermentperioddet a in list)
                {
                    defermentPeriod.Add(a.period.ToString());
                }

                return defermentPeriod;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //newdb.Dispose();
            }
        }
    }
}
