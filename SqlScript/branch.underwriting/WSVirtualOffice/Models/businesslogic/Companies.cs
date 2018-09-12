using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Companies
    {

        public static int getCompanyno(String companyname)
        {
            try
            {
                //companyname = Lookuplangdata.getEnglishvalue(Lookuptables.companydet, companyname);
                companydet comp = (from item in Program.companieslist
                                               where item.companyname.Equals(companyname) 
                                               select item).SingleOrDefault();
                return comp.companyno;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }

        public static String getCompanyname(int companyno)
        {
            try
            {
                companydet comp = (from item in Program.companieslist
                                   where item.companyno==companyno
                                   select item).SingleOrDefault();
                
                //return Lookuplangdata.getLanguagevalue(Lookuptables.companydet,comp.companyname);
                return comp.companyname;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        
    }
}
