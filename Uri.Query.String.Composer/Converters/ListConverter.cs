﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UriQueryStringComposer.Tests")]
namespace UriQueryStringComposer.Converters
{
    internal static partial class Converter
    {
        public static string FromList(IList? value)
        {
            if (value == null)
                return string.Empty;

            var results = new List<string>(value.Count);
            foreach (var item in value)
            {
                var result = FromObject(item);

                results.Add(result);
            }

            return string.Join(Constants.Comma, results);
        }
    }
}