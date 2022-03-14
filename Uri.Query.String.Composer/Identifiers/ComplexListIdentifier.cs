using System.Collections;
using System.Linq;
using System.Reflection;

namespace UriQueryStringComposer.Identifiers
{
    internal static partial class Identifier
    {
        public static bool IsComplexList(PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            var genericArguments = propertyType.GetGenericArguments();
            var isPrimitive = genericArguments.Any(a => typeof(string) == a || a.IsPrimitive);

            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string);

            return isEnumerable && !isPrimitive;
        }
    }
}