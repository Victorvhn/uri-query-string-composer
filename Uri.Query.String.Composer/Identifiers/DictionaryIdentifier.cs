using System;
using System.Collections.Generic;

namespace Uri.Query.String.Composer.Identifiers
{
    internal static partial class Identifier
    {
        public static bool IsDictionary(Type type) =>
            type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>);
    }
}