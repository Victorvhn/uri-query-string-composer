using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

[assembly: InternalsVisibleTo("UriQueryStringComposer.Tests")]
namespace UriQueryStringComposer.Converters
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