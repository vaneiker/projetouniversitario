using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Positiontypes
    {

        public static char getPositiontypecode(String Positiontype)
        {
            try
            {
                //Positiontype = Lookuplangdata.getEnglishvalue(Lookuptables.positiontypedet, Positiontype);
                positiontypedet posi = (from item in Program.positiontypeslist
                                        where item.positiontype.Equals(Positiontype)
                                        select item).SingleOrDefault();
                return posi.positiontypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*

            foreach (positiontypedet item in Program.positiontypeslist)
            {
                if (item.positiontype.Equals(Positiontype.Trim()))
                {
                    return item.positiontypecode;

                }
            }
            return ' ';
             */ 

        }

        public static String getPositiontype(char Positiontypecode)
        {
            try
            {
                positiontypedet posi = (from item in Program.positiontypeslist
                                        where item.positiontypecode == Positiontypecode
                                        select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.positiontypedet, posi.positiontype);
                return posi.positiontype;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*

            foreach (positiontypedet item in Program.positiontypeslist)
            {
                if (item.positiontypecode == Positiontypecode)
                {
                    return item.positiontype;

                }
            }
            return "";
             */ 
        }
    }
}
