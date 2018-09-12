using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class Numericdata
    {
        public static int getIntegervalue(String str1)
        {
            try
            {
                if (!str1.Trim().Equals(""))
                {
                    return (int)Decimal.Parse(str1);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
       
        public static Decimal getDecimalvalue(String str1)
        {
            try
            {
                if (!str1.Trim().Equals(""))
                {
                    return Decimal.Parse(str1);
                }
                else
                {
                    return Decimal.Parse("0.0");

                }
            }
            catch (Exception ex)
            {
                return Decimal.Parse("0.0");
            }

        }

        public static double getDoublevalue(String str1)
        {
            try
            {
                if (!str1.Trim().Equals(""))
                {
                    if (Program.isdecimal(str1) == true)
                    {
                        return (double)Decimal.Parse(str1);
                    }
                    else
                    {
                        return 0.0;
                    }

                }
                else
                {
                    return (double)Decimal.Parse("0.0");

                }
            }
            catch (Exception ex)
            {
                return 0.0;
            }

        }

        public static Int64 getLongvalue(String str1)
        {
            try
            {
                if (!str1.Trim().Equals(""))
                {
                    return Convert.ToInt64(str1);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
