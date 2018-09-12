using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WEB.UnderWriting.Common
{
    public class EnumHelper
    {
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="en">The Enumeration</param>
        /// <param name="aux">Auxiliar</param>
        /// <returns>A string representing the friendly name</returns>
        /// If Auxiliar token (bool) and enum have custom attr, then if:=> true returns AuxiliarValue, => false returns Value from CustomAttr.
        public static string GetDescription(Enum en, bool aux = false)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
                else
                {
                    var result = en.GetCustomDescription();
                    if (result != null)
                        return (aux) ? result.AuxValue : result.Value;
                    return en.ToString();
                }
            }
            return en.ToString();
        }
    }

    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
    public class CustomDescriptionAttribute : Attribute
    {
        public CustomDescriptionAttribute(string value, string auxValue)
        {
            this.Value = value;
            this.AuxValue = auxValue;
        }
        public string Value { get; private set; }
        public string AuxValue { get; private set; }
    }
    public static class CustomDescriptionExtensions
    {
        public static CustomDescriptionAttribute GetCustomDescription(this Enum p)
        {
            var attr = p.GetAttribute<CustomDescriptionAttribute>();
            return attr;
        }
    }
}