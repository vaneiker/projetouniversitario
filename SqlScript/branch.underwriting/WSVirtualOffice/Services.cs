using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace WSVirtualOffice
{
    public class Services
    {
        #region Enumeration
        public enum Currency
        {
            [Description("RD$")]
            R = 1,
            [Description("US$")]
            A = 2
        }
        public enum InsuranceType
        {
            [Description("Poliza Vida Termino")]
            IndividualTermLife=1,
            [Description("Ultimos Gastos")]
            IndividualFunerary = 2
        }
        public enum InsurancePlanMode
        {
            [Description("Individual")]
            Individual = 1,
            [Description("Colectivo")]
            Colective = 2,
            [Description("Familiar")]
            Familiar = 3
        }
        public enum Genders
        {
            [Description("Masculino")]
            M = 1,
            [Description("Femenino")]
            F = 2,
        }
        public enum PremiumType
        {
            [Description("Prima No Garantizada")]
            UnsecuredPremium = 1,
            [Description("Prima Garantizada")]
            SecuredPremium = 2
        }
        public enum Rider
        {
            [Description("Muerte Accidental")]
            ADB = 1,
            TERM = 2,
            OIR = 3,
            [Description("Plan Familiar")]
            FAMILIAR = 4,
            REPATRIACION = 5,
            SEPELTURALOTE = 6,
            CI = 7,
            [Description("Seguro Conyugal/Otro Asegurado")]
            AI=8,
            [Description("Seguro Conyugal/Otro Asegurado Hasta la Edad de")]
            AIT = 9
        }
        public enum Role
        {
            [Description("Owner")]
            Owner=1,
            [Description("Additional Insured")]
            AdditionalInsured = 2
        }
        #endregion
        public byte[] GenerateQuote(STG.DLL.TH.Serialization.Implementation.Quotes type, STG.DLL.TH.Serialization.Entity.Quote quote)
        {
            if (quote == null || quote.Member == null || quote.PolicyData == null || quote.PolicyInfo == null || quote.Quotation == null)
                throw new NullReferenceException("Need to set Quote values");
            var implementation = new STG.DLL.TH.Serialization.Implementation();
            switch (type)
            {
                case STG.DLL.TH.Serialization.Implementation.Quotes.Life:
                default:
                    return implementation.GetQuote(STG.DLL.TH.Serialization.Implementation.Quotes.Life, quote);
            }
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
    public static class Enums
    {
        public static List<T> BuildEnum<T>(string[] values)
        {
            var EnumList = new List<T>();
            foreach (var item in values)
            {
                EnumList.Add(Str2enum<T>(item));
            }
            return EnumList;
        }
        public static T Str2enum<T>(string str)
        {
            try
            {
                T res = (T)Enum.Parse(typeof(T), str);
                if (!Enum.IsDefined(typeof(T), res)) return default(T);
                return res;
            }
            catch
            {
                return default(T);
            }
        }
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
        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            foreach (object item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }

    }
    public partial class Ordering
    {
        public string Property { get; set; }
        public int Order { get; set; }
    }
    public static class Extension
    {
        public static string CleanSpaces(this string value)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            value = regex.Replace(value, " ");
            return value;
        }

        public static List<T> ConvertToList<T>(this DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
    }
}