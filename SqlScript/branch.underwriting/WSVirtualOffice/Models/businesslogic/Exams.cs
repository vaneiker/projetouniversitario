using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Exams
    {
        public static String getexamcode(String exam)
        {
            try
            {
                examdet exams = (from item in Program.examslist
                                 where item.examname.Equals(exam)
                                 select item).SingleOrDefault();
                return exams.examcode;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*

            foreach (examdet item in Program.examslist)
            {
                if (item.examname.Equals(exam.Trim()))
                {
                    return item.examcode;

                }
            }
            return "";
             */ 

        }

        public static String getexam(String examcode)
        {
            try
            {
                examdet exams = (from item in Program.examslist
                                 where item.examcode == examcode
                                 select item).SingleOrDefault();
                return exams.examname;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*
            foreach (examdet item in Program.examslist)
            {
                if (item.examcode.Equals(examcode))
                {
                    return item.examname;

                }
            }
            return "";
             */ 
        }

    }
}
