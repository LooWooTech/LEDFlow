using System;
using System.Collections.Generic;
using System.Text;

namespace LoowooTech.LEDFlow.Common
{
    public static class StringHelper
    {
        public static int ToInt(string str, int defaultValue = 0)
        {
            var result = 0;
            if (int.TryParse(str, out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static double ToDouble(string str, double defaultValue = 0)
        {
            double result = 0;
            if (double.TryParse(str, out result))
            {
                return result;
            }
            return defaultValue;
        }

        public static T ToEnum<T>(string str) where T : struct
        {
            try
            {
                var result = Enum.Parse(typeof(T), str);
                return (T)result;
            }
            catch
            {
                return default(T);
            }
        }
    }
}
