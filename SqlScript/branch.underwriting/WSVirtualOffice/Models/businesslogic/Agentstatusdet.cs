using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Agentstatusdet
    {
        public static char getAgentstatuscode(String agentstatus)
        {
            //agentstatus = Lookuplangdata.getEnglishvalue(Lookuptables.agentstatusdet, agentstatus);
            try
            {
                agentstatusdet reftype = (from item in Program.registertypeslist
                                          where item.status.Equals(agentstatus)
                                           select item).SingleOrDefault();
                return reftype.statuscode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
           

        }

        public static String getAgentstatus(char agentstatuscode)
        {
            try
            {
                agentstatusdet reftype = (from item in Program.registertypeslist
                                          where item.statuscode == agentstatuscode
                                           select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.agentstatusdet, reftype.status);
                return reftype.status;
            }
            catch (Exception ex)
            {
                return "";
            }
           
        }
    }
}
