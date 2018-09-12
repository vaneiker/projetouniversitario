using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Approvaltype
    {


        public static int getapprovaltypeno(String approvaltype)
        {
            try
            {
                approvaltypedet appdata = (from item in Program.approvallist
                                        where item.approvaltype.Equals(approvaltype)
                                        select item).SingleOrDefault();
                return appdata.approvaltypeno;
            }
            catch (Exception ex)
            {
                return 0;
            }


         
        }

        public static String getapprovaltype(int approvaltypeno)
        {
            try
            {
                approvaltypedet appdata = (from item in Program.approvallist
                                           where item.approvaltypeno.Equals(approvaltypeno)
                                           select item).SingleOrDefault();
                return appdata.approvaltype;
            }
            catch (Exception ex)
            {
                return "";
            }

           
        }
    }
}
