using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace DATA.UnderWriting.Repositories.Base
{
    internal static class Extension
    {
        public static int ConvertToNoNullable(this int? value, int defaultValue = -1)
        {
            int result;

            result = value.HasValue
                        ? value.Value
                        : defaultValue;
            return
                result;
        }

        public static bool ConvertToNoNullable(this bool? value, bool defaultValue = false)
        {
            bool result;

            result = value.HasValue
                        ? value.Value
                        : defaultValue;
            return
                result;
        }

        public static decimal ConvertToNoNullable(this decimal? value, decimal defaultValue = -1)
        {
            decimal result;

            result = value.HasValue
                        ? value.Value
                        : defaultValue;
            return
                result;
        }

        public static long ConvertToNoNullable(this long? value, long defaultValue = -1)
        {
            long result;

            result = value.HasValue
                        ? value.Value
                        : defaultValue;
            return
                result;
        }

        public static DateTime ConvertToNoNullable(this DateTime? value, DateTime? defaultValue = null)
        {
            DateTime result;

            if (!defaultValue.HasValue)
                defaultValue = DateTime.Now;

            result = value.HasValue
                        ? value.Value
                        : defaultValue.Value;
            return
                result;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
