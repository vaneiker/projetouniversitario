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
    public class Profilestatus
    {
        public static Char getprofilestatuscode(String profilestatus)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {

                profilestatusdet prostatus = (from item in newdb.profilestatusdets
                                              where item.profilestatus.Equals(profilestatus)
                                              select item).SingleOrDefault();
                return prostatus.profilestatuscode;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return ' ';
        }
        public static String getprofilestatusname(char profilestatuscode)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {

                profilestatusdet prostatus = (from item in newdb.profilestatusdets
                                              where item.profilestatuscode.Equals(profilestatuscode)
                                              select item).SingleOrDefault();
                return prostatus.profilestatus;
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