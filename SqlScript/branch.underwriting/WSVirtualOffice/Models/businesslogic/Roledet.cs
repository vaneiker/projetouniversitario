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

namespace WSVirtualOffice.Models.businesslogic
{
    public class Roledet
    {
        public static int Agent = 1;
        public static int Supervisor = 2;
        public static int Sysadmin = 3;
        public static int Policyadmin = 4;
        public static int Agentsupervisor = 5;
        public static int Backoffice = 6;
       

        public static int getRoleNo(String rolename)
        {
            try
            {
                //rolename = Lookuplangdata.getEnglishvalue(Lookuptables.roledet, rolename);
                roledet rolegroup = (from item in Program.rolelist
                                             where item.rolename.Equals(rolename)
                                             select item).SingleOrDefault();
                return rolegroup.roleno;
            }
            catch (Exception ex)
            {
                return 0;
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

        public static String getRoleName(int roleno)
        {
            try
            {
                roledet roledata = (from item in Program.rolelist
                                            where item.roleno == roleno
                                            select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.roledet, roledata.rolename);
                return roledata.rolename;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
