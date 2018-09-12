using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Customerstatuses
    {
        public static char CONTACT = 'C';
        public static char PROSPECT = 'P';
        public static char PLANISSUED = 'L';


        public static String getcustomerstatus(Char statuscode)
        {
            try
            {
                if(statuscode.Equals('C'))
                {
                    return "CONTACT";
                }
                else if (statuscode.Equals('P'))
                {
                    return "PROSPECT";
                }
                else if(statuscode.Equals('L'))
                {
                    return "PLANISSUED";
                }
                return  " " ;
            }
            catch (Exception ex)
            {
                return " ";
            }
        }
        public static char getcustomerstatuscode(String status)
        {
            try
            {
                if (status.Equals("CONTACT") || status.Equals("Contact"))
                {
                    return 'C';
                }
                else if (status.Equals("PROSPECT") || status.Equals("Prospect"))
                {
                    return 'P';
                }
                else if (status.Equals("PLANISSUED") || status.Equals("PlanIssued"))
                {
                    return 'L';
                }
                return ' ';
            }
            catch (Exception ex)
            {
                return ' ' ;
            }
        }
    }
}
