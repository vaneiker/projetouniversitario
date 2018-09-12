using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Plangroups
    {
        public static char LIFE = 'L';
        public static char EDUCATION = 'E';
        public static char RETIREMENT = 'R';
        public static char TERMINSURANCE = 'T';

        public static char getPlangroupcode(String plangroup)
        {
            try
            {
                var plangroupdata = Utility.GetIllusDropDownByType(Utility.DropDownType.FamilyProduct)
                    .Single(o => o.PlanGroup == plangroup);

                return plangroupdata.PlanGroupCode[0];
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*
            foreach (plangroupdet item in Program.plangroupslist)
            {
                if (item.plangroup.Equals(plangroup.Trim()))
                {
                    return item.plangroupcode;

                }
            }
            return ' ';
             */

        }

        public static String getPlangroup(char plangroupcode)
        {
            try
            {
                var plangroupdata = Utility.GetIllusDropDownByType(Utility.DropDownType.FamilyProduct)
                    .Single(o => o.PlanGroupCode == plangroupcode.ToString());

                return plangroupdata.PlanGroup;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}