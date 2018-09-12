using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    public class UserProfileInfo
    {
        public UserProfileInfo(Int32 moduleno, Int32 userid)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                Int32 roleno = (from item in newdb.userdets
                                where item.userid == userid
                                select item.roleno).SingleOrDefault();

                rolemoduledet rolemodulestatus = (from item in newdb.rolemoduledets
                                                  where item.roleno == roleno && item.moduleno == moduleno
                                                  select item).SingleOrDefault();

                if (rolemodulestatus != null)
                {
                    if (rolemodulestatus.is_new == 'Y')
                    {
                        this.is_new = true;
                    }
                    else
                    {
                        this.is_new = false;
                    }

                    if (rolemodulestatus.is_edit == 'Y')
                    {
                        this.is_edit = true;
                    }
                    else
                    {
                        this.is_edit = false;
                    }

                    if (rolemodulestatus.is_view == 'Y')
                    {
                        this.is_view = true;
                    }
                    else
                    {
                        this.is_view = false;
                    }

                    if (rolemodulestatus.is_delete == 'Y')
                    {
                        this.is_delete = true;
                    }
                    else
                    {
                        this.is_delete = false;
                    }

                    if (rolemodulestatus.is_approve == 'Y')
                    {
                        this.is_approve = true;
                    }
                    else
                    {
                        this.is_approve = false;
                    }

                    if (rolemodulestatus.not_available == 'Y')
                    {
                        this.not_available = true;
                    }
                    else
                    {
                        this.not_available = false;
                    }

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

        private Boolean is_new;

        public Boolean Is_new
        {
            get { return is_new; }
            set { is_new = value; }
        }

        private Boolean is_edit;

        public Boolean Is_edit
        {
            get { return is_edit; }
            set { is_edit = value; }
        }

        private Boolean is_view;

        public Boolean Is_view
        {
            get { return is_view; }
            set { is_view = value; }
        }

        private Boolean is_delete;

        public Boolean Is_delete
        {
            get { return is_delete; }
            set { is_delete = value; }
        }

        private Boolean is_approve;

        public Boolean Is_approve
        {
            get { return is_approve; }
            set { is_approve = value; }
        }

        private Boolean not_available;

        public Boolean Not_available
        {
            get { return not_available; }
            set { not_available = value; }
        }

    }
}