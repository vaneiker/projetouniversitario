using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WSVirtualOffice.Models.businesslogic
{
    class Caption
    {
        public static String getCaption(String language, String name)
        {
            name = name.Replace("\r", "{");
            name = name.Replace("\n", "}");

            IEnumerable valuedata = null;

            if (Program.spanishLangData != null && language == "es")
            {
                valuedata = from item in Program.spanishLangData where item.name.Equals(name) select item;
            }
            if (Program.spanishLangData != null && language == "fr")
            {
                valuedata = from item in Program.frenchLangData where item.name.Equals(name) select item;
            }
            if (Program.spanishLangData != null && language == "pt")
            {
                valuedata = from item in Program.portugueseLangData where item.name.Equals(name) select item;
            }
            if (Program.spanishLangData != null && language == "zh")
            {
                valuedata = from item in Program.chineseLangData where item.name.Equals(name) select item;
            }

            if (valuedata != null)
            {
                foreach (Propdata item in valuedata)
                {
                    return item.value;
                }
            }

            return name;
        }

        

        public static String getCaptionName(String language, String value)
        {
            IEnumerable valuedata = null;

            if (Program.spanishLangData != null && language == "es")
            {
                valuedata = from item in Program.spanishLangData where item.value.Equals(value) select item;
            }
            if (Program.spanishLangData != null && language == "fr")
            {
                valuedata = from item in Program.frenchLangData where item.value.Equals(value) select item;
            }
            if (Program.spanishLangData != null && language == "pt")
            {
                valuedata = from item in Program.portugueseLangData where item.value.Equals(value) select item;
            }
            if (Program.spanishLangData != null && language == "zh")
            {
                valuedata = from item in Program.chineseLangData where item.value.Equals(value) select item;
            }

            if (valuedata != null)
            {
                foreach (Propdata item in valuedata)
                {
                    String str = item.name;
                    str = str.Replace("{", "\r");
                    str = str.Replace("}", "\n");
                    return str;
                }
            }

            return value;
        }

        public static string showMessageBox(String language,String msg)
        {

            msg = getCaption(language,msg.Trim());
            return msg;
            

            //return msg;
        }

        public static string getddlMsg(String language,String msg)
        {

            msg = getCaption(language,msg);
            return msg;
            
        }

    }
}
