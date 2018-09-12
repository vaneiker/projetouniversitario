using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Surrenderpenaties
    {
        public static ISurrenderpenaltydata[] getSurrenderpenaltydata(string productcode, int startsno, IllustrationService illustrationService)
        {
            try
            {
                var surdata = Utility.
                    GetIllusDropDownByType(Utility.DropDownType.SurrenderPenal, productcode).Where(o => o.YearNo.GetValueOrDefault() >= startsno);
                ISurrenderpenaltydata[] surdata1 = new ISurrenderpenaltydata[surdata.Count()];

                int sno = 0;
                foreach (var item in surdata)
                {
                    sno++;
                    surdata1[sno - 1] = new ISurrenderpenaltydata();
                    surdata1[sno - 1].sno = sno;
                    surdata1[sno - 1].penaltypercent = item.PenalTyperCent.ToDouble();
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