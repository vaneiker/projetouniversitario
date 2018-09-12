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
    public class AnnuityPeriod
    {
        public long annuityPeriodId;
        public string productCode;
        public int period;

        public AnnuityPeriod()
        {

        }

        public AnnuityPeriod(long annuityPeriodId, string productCode, int period)
        {
            this.annuityPeriodId = annuityPeriodId;
            this.productCode = productCode;
            this.period = period;
        }

        public static List<string> GetAnnuityPeriods(string productCode, string selectText)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                List<annuityperioddet> list = (from a in Program.annuityperiodlist
                        where a.productcode.Equals(productCode)
                        select a).ToList();

                List<string> annuityPeriod = new List<string>();
                annuityPeriod.Add(selectText);
                foreach (annuityperioddet a in list)
                {
                    annuityPeriod.Add(a.period.ToString());
                }

                return annuityPeriod;
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
