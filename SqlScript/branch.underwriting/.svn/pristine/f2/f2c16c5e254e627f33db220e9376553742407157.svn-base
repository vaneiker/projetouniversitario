using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Relationshiptypes
    {
        public static char getRelationshiptypecode(String relationshiptype)
        {
            
            try
            {
                //relationshiptype = Lookuplangdata.getEnglishvalue(Lookuptables.relationshiptypedet, relationshiptype);
                relationshiptypedet relation = (from item in Program.relationslist
                                                where item.relationshiptype.Equals(relationshiptype)
                                                select item).SingleOrDefault();
                return relation.relationshiptypecode;
            }
            catch (Exception ex)
            {
                return ' ';
            }
            /*

            foreach (relationshiptypedet item in Program.relationslist)
            {
                if (item.relationshiptype.Equals(relationshiptype.Trim()))
                {
                    return item.relationshiptypecode;

                }
            }
            return ' ';
             */ 

        }

        public static String getRelationshiptype(char relationshiptypecode)
        {
            try
            {
                relationshiptypedet relation = (from item in Program.relationslist
                                                where item.relationshiptypecode == relationshiptypecode
                                                select item).SingleOrDefault();
                //return Lookuplangdata.getLanguagevalue(Lookuptables.relationshiptypedet, relation.relationshiptype);
                return relation.relationshiptype;
            }
            catch (Exception ex)
            {
                return "";
            }
            /*

            foreach (relationshiptypedet item in Program.relationslist)
            {
                if (item.relationshiptypecode==relationshiptypecode)
                {
                    return item.relationshiptype;

                }
            }
            return "";
             */ 
        }
    }
}
