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
    public class Agencydet
    {
        public static int getAgentcyno(String agencyname)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {

                agencydet agency = (from item in newdb.agencydets
                                    where item.agencyname.Equals(agencyname)
                                    select item).SingleOrDefault();
                return agency.agencyno;
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
        public static String getAgentName(int agencyno)
        {

            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {

                agencydet agency = (from item in newdb.agencydets
                            where item.agencyno.Equals(agencyno)
                            select item).SingleOrDefault();
            return agency.agencyname;
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