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
    public class Hierarchies
    {
        public static int GetHierarchyCode(String hierarchy)
        {
            try
            {
                //hierarchy = Lookuplangdata.getEnglishvalue(Lookuptables.hierarchydet, hierarchy);
                hierarchydet hierarchydata = (from item in Program.hierarchylist
                                              where item.hierarchyname.Equals(hierarchy)
                                              select item).SingleOrDefault();
                return hierarchydata.hierarchycode;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static String GetHierarchy(int hierarchyCode)
        {
            try
            {
                hierarchydet hierarchydata = (from item in Program.hierarchylist
                                              where item.hierarchycode == hierarchyCode
                                              select item).SingleOrDefault();

                //return Lookuplangdata.getLanguagevalue(Lookuptables.hierarchydet, hierarchydata.hierarchyname);
                return hierarchydata.hierarchyname;
            }
            catch (Exception ex)
            {
                return "Select";
            }
        }
    }
}
