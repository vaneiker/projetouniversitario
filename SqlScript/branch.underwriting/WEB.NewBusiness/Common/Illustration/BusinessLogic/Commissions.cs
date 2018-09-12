using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Commissions
    {
        class commissiondet
        {
            public string productcode;

            public System.Nullable<int> yearno;

            public System.Nullable<decimal> vr;

            public System.Nullable<decimal> additionalpenalty;

            public System.Nullable<decimal> regularcomm;

            public System.Nullable<decimal> excesscomm;

            public int commissionno;

            public System.Nullable<System.DateTime> datecreated;

            public System.Nullable<System.DateTime> dateupdated;

            public System.Nullable<System.DateTime> datesynced;
        }


        public static ICommissiondata[] getCommissiondata(String productcode, int startyearno, int contributionperiod, IllustrationService illustrationService)
        {
            try
            {
                var comdata = Utility.GetIllusDropDownByType(Utility.DropDownType.Commission, productcode).Where(o => o.YearNo.GetValueOrDefault() >= startyearno);

                int sno = 0;
                ICommissiondata[] comisdata = new ICommissiondata[comdata.Count()];
                foreach (Entity.UnderWriting.IllusData.DropDown item in comdata)
                {
                    sno++;
                    comisdata[sno - 1] = new ICommissiondata();
                    comisdata[sno - 1].sno = sno;
                    comisdata[sno - 1].commissionpercent = item.RegularComm.ToDouble();
                    comisdata[sno - 1].excesscommissionpercent = item.ExcessComm.ToDouble();
                    comisdata[sno - 1].vr = item.Vr.ToDouble();
                }
                return comisdata;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}