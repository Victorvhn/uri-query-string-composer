using System;
using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UriQueryStringComposer.Tests")]
namespace UriQueryStringComposer.Converters
{
    internal static partial class Converter
    {
        public static string FromDateTime(DateTime value) =>
            value.ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture);

        public static string FromDateTime(DateTime? value) =>
            value == null
                ? string.Empty
                : FromDateTime((DateTime)value);
    }
}