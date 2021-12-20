using System.Collections;
using System.Reflection;

namespace UriQueryStringComposer.Identifiers
{
    internal static partial class Identifier
    {
        public static bool IsList(PropertyInfo property) =>
            typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
            && property.PropertyType != typeof(string);
    }
}