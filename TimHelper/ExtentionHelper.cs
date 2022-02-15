using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace TimHelper
{
    public static class ExtentionHelper
    {
        static readonly CultureInfo cul = CultureInfo.GetCultureInfo("en-US");

        public static string ToMoney(this int number)
        {
            return number.ToString("#,###", cul.NumberFormat);
        }

        public static string ToStringValue(this Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var stringValue = ((DescriptionAttribute)attributes[0]).Description;
            return stringValue;
        }

        public static void ExtractSaveResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }

                }
            }
        }
    }
}
