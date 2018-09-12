using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WSVirtualOffice.Models.businesslogic
{
    class userlogic
    {
        public static userdet validateuserandpassword(String username, String password)
        {
            try
            {
                userdet user1 = (from item in Program.userlist
                                 where item.username.Equals(username) && item.password.Equals(password)
                                 select item).SingleOrDefault();
                return user1;
            }
            catch (Exception ex)
            {
                return null;
            }
            /*

            foreach (userdet user in newdb.userdets)
            {
                if ((user.username.Equals(username) && (user.password.Equals(password))))
                {
                    return user;
                }
            }
            return null;
             */ 
        }



        public static userdet getuserdetails(int userid)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                userdet user1 = (from item in newdb.userdets
                                 where item.userid == userid
                                 select item).SingleOrDefault();
                return user1;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return null;
            /*

            foreach (userdet user in Program.userlist)
            {
                if ((user.userid == userid))
                {
                    return user;
                }

            }
            return null;
             */ 
        }


        public static Boolean validateuseroldpassword(int userid, String password)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                userdet user1 = (from item in newdb.userdets
                                 where item.userid == userid && item.password.Equals(password)
                                 select item).SingleOrDefault();
                if (user1 != null && user1.userid == userid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return false;
            /*
            return user1;

            foreach (userdet user in Program.userlist)
            {
                if ((user.userid == userid) && (user.password.Equals(password)))
                {
                    return true;
                }

            }
            return false;
             */ 
        }


        public static Boolean confirmpassword(String password, String otherpassword)
        {
            if (password.Equals(""))
            {
                return false;
            }
            if (password.Equals(otherpassword))
            {
                return true;
            }
            return false;
        }

        public static Boolean changeuserpassword(int userid, String password)
        {
            //newdb = new DataVOUniversalDataContext("Data Source=(local);Initial Catalog=illustrator1;Integrated Security=True;Pooling=False");
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                var user1 = (from user in newdb.userdets
                             where user.userid == userid
                             select user).SingleOrDefault();
                user1.password = password;
                newdb.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return false;
        }

        public static void reloaduserdetails()
        {
            //newdb = new DataVOUniversalDataContext("Data Source=(local);Initial Catalog=illustrator1;Integrated Security=True;Pooling=False");
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                var users = from user in newdb.userdets
                            orderby user.userid
                            select user;

                Program.userlist = new List<userdet>();
                foreach (userdet user in users)
                {
                    Program.userlist.Add(user);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }

        }


    }
}
