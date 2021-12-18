using System;
using System.Reflection;

namespace Uri.Query.String.Composer.Identifiers
{
    internal static partial class Identifier
    {
        public static bool IsDateTime(PropertyInfo property) =>
            property.PropertyType == typeof(DateTime?) || property.PropertyType == typeof(DateTime);
    }
}