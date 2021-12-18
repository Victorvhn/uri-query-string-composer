using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

[assembly: InternalsVisibleTo("Uri.Query.String.Composer.Tests")]
namespace Uri.Query.String.Composer.Converters
{
    internal static partial class Converter
    {
        public static string FromObject(object? value)
        {
            var stringValue = Convert.ToString(value);

            return HttpUtility.UrlEncode(stringValue, Encoding.UTF8);
        }
    }
}