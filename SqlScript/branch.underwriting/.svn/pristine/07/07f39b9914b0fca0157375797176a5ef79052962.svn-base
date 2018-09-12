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
    public class Rolegroup
    {
        public static int getRoleNo(String rolename)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                roledet role = (from item in newdb.roledets
                                where item.rolename.Equals(rolename)
                                select item).SingleOrDefault();
                return role.roleno;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return -1;
        }
        public static String getRoleName(int roleno)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                roledet role = (from item in newdb.roledets
                                where item.roleno.Equals(roleno)
                                select item).SingleOrDefault();
                return role.rolename;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return "";
        }

        public static String getprofilename(int roleno)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                string profilename = "";
                var proname = from item in newdb.rolemoduledets
                              where item.roleno.Equals(roleno)

                              select item;
                foreach (rolemoduledet name in proname)
                {
                    profilename = name.profilename;
                    break;
                }
                return profilename;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return "";
        }
    }
}