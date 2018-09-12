using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Userdata
    {
        public long userid;
        public String firstname;
        public String lastname;
        public String homephoneintcode;
        public String homephoneareacode;
        public String homephonenum;

        public Userdata(long userid,String firstname,String lastname,String homephoneintcode,String homephoneareacode,String homephonenum)
        {
            this.userid = userid;
            this.firstname = firstname;
            this.lastname = lastname;
            this.homephoneintcode = homephoneintcode;
            this.homephoneareacode = homephoneareacode;
            this.homephonenum = homephonenum;
            

        }


        public static String getUserName(long userid)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                var username = (from item in newdb.userdetaildets where item.userid == userid select item).SingleOrDefault();
                if (username != null)
                {
                    return username.FirstName + " " + username.LastName;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return "N/A";
        }

    }
}
