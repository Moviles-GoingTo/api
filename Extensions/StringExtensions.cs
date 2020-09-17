using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoingTo_API.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }

        public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };

        public static string SplitPascalCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            return Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
      
        public static string ToProperCase(this string text)
        {
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}
