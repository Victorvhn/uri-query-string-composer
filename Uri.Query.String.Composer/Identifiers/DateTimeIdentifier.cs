using System;
using System.Reflection;

namespace UriQueryStringComposer.Identifiers
{
    internal static partial class Identifier
    {
        public static bool IsDateTime(PropertyInfo property) =>
            property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime);
    }
}