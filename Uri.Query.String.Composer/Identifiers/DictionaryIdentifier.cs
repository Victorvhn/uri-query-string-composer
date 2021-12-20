using System;
using System.Collections.Generic;

namespace UriQueryStringComposer.Identifiers
{
    internal static partial class Identifier
    {
        public static bool IsDictionary(Type type) =>
            type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
    }
}