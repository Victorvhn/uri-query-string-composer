using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UriQueryStringComposer.Attributes;
using UriQueryStringComposer.Converters;
using UriQueryStringComposer.Identifiers;

namespace UriQueryStringComposer
{
    public static class QueryStringComposer
    {
        public static Uri Compose(string baseUrl, object? queryStringObject = null)
        {
            var uri = new Uri(baseUrl);

            return Compose(uri, queryStringObject);
        }

        public static Uri Compose(Uri uri, object? queryStringObject = null)
        {
            if (queryStringObject == null)
                return uri;

            var parameters = GetQueryParameters(queryStringObject);

            if (parameters.Count == 0)
                return uri;

            var finalUri = MergeParametersInUri(uri, parameters);

            return finalUri;
        }

        private static IDictionary<string, string> GetQueryParameters(object queryStringObject)
        {
            if (Identifier.IsDictionary(queryStringObject.GetType()))
                return (IDictionary<string, string>)queryStringObject;

            var properties = queryStringObject
                .GetType()
                .GetProperties()
                .Where(GetPropertiesWithoutIgnoreAttribute);

            var parameters = new Dictionary<string, string>();

            foreach (var property in properties)
            {
                var key = GetPropertyKey(property);
                var value = GetPropertyValue(queryStringObject, property);

                if (!string.IsNullOrWhiteSpace(value))
                    parameters.Add(key, value);
            }

            return parameters;
        }

        private static Uri MergeParametersInUri(Uri uri, IDictionary<string, string> parameters)
        {
            var stringBuilder = new StringBuilder();

            foreach (var (key, value) in parameters)
                stringBuilder.Append($"{Constants.Ampersand}{key}={value}");

            var uriBuilder = new UriBuilder(uri);

            if (!uriBuilder.Query.Any())
                stringBuilder[0] = Constants.Interrogation;

            var query = stringBuilder.ToString();

            uriBuilder.Query += query;

            return uriBuilder.Uri;
        }

        private static bool GetPropertiesWithoutIgnoreAttribute(PropertyInfo propertyInfo) =>
            propertyInfo.GetCustomAttribute(typeof(QueryStringIgnoreAttribute)) == null;

        private static string GetPropertyKey(MemberInfo property)
        {
            var customNameAttribute = property.GetCustomAttribute(typeof(QueryStringKeyNameAttribute));

            return customNameAttribute != null
                ? ((QueryStringKeyNameAttribute)customNameAttribute).Name
                : property.Name;
        }

        private static string GetPropertyValue(object @object, PropertyInfo property)
        {
            string value;
            if (Identifier.IsList(property))
            {
                value = Converter.FromList(
                    (IList?)property.GetValue(@object)
                );
            }
            else if (Identifier.IsDateTime(property))
            {
                value = Converter.FromDateTime(
                    (DateTime?)property.GetValue(@object)
                );
            }
            else
            {
                value = Converter.FromObject(
                    property.GetValue(@object)
                );
            }

            return value;
        }
    }
}
