using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Productdata
    {
        public static int PROFILEU = 0;
        public static int PROFILEM = 1;
        public static int PROFILEB = 2;
        public static int PROFILEG = 3;

        public static double[] getProfileRates(String productcode, char classcode)
        {
            var invlist = Utility
                .GetIllusDropDownByType(Utility.DropDownType.InvestmentProfile, productcode, pClass: classcode.ToString());
            ;
            double[] profilerates = new double[4];

            foreach (var invdata in invlist)
                profilerates[
                    invdata.InvestmentProfileCode[0] == Invprofiledata.GUARANTEED ? PROFILEU :
                    invdata.InvestmentProfileCode[0] == Invprofiledata.MODERATE ? PROFILEM :
                    invdata.InvestmentProfileCode[0] == Invprofiledata.BALANCED ? PROFILEB :
                    PROFILEG] = invdata.InvestmentProfileRate.ToDouble();
            return profilerates;
        }

        public static Boolean isRefund(string productcode)
        {
            try
            {
                return Utility.GetIllusDropDownByType(
                          Utility.DropDownType.ProductType)
                         .Single(o => o.ProductCode == productcode)
                         .IsRefund == "Y";
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static int getProductcancelno(String productcode, int retirementperiod, IllustrationService illustrationService)
        {
            try
            {
                var prodcan = illustrationService.oIllusDataManager.GetProductCancel(productcode, retirementperiod).Single();
                return prodcan.ProductCancelNo;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static ICanceldata[] getProductcanceldata(string productcode, int retirementperiod, IllustrationService illustrationService)
        {
            ICanceldata[] candata = null;
            try
            {
                int prodcancelno = getProductcancelno(productcode, retirementperiod, illustrationService);
                var proddetails = illustrationService.oIllusDataManager.GetProductCancelDetail(prodcancelno).OrderBy(o => o.YearNo);
                candata = new ICanceldata[proddetails.Count()];
                int i = -1;
                foreach (var item in proddetails)
                {
                    i++;
                    candata[i] = new ICanceldata();
                    candata[i].sno = item.YearNo.Value;
                    candata[i].cancelpercent = item.CancelPercent.ToDouble();
                }
                return candata;
            }
            catch (Exception ex)
            {
                return candata;
            }
        }
    }
}