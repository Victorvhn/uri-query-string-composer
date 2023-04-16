using System.Reflection;
using CaseExtensions;
using UriQueryStringComposer.Attributes;
using UriQueryStringComposer.Enums;

namespace UriQueryStringComposer
{
    public static partial class QueryStringComposer
    {
        private static string GetPropertyKey(MemberInfo property)
        {
            var customNameAttribute = property.GetCustomAttribute(typeof(QueryStringKeyNameAttribute));

            if (customNameAttribute != null)
            {
                return ((QueryStringKeyNameAttribute)customNameAttribute).Name;
            }
            
            var stringCaseStyle = GetStringStyle(property);

            return GetStyledKey(property.Name, stringCaseStyle);
        }

        private static StringCaseStyle GetStringStyle(MemberInfo property)
        {
            var customStringCaseStyleAttribute = property.GetCustomAttribute(typeof(QueryStringKeyCaseStyleAttribute));

            if (customStringCaseStyleAttribute != null)
            {
                var attribute = (QueryStringKeyCaseStyleAttribute) customStringCaseStyleAttribute;

                return attribute.CaseStyle;
            }

            return QueryStringComposerConfiguration.Options.KeyNameCaseStyle;
        }

        private static string GetStyledKey(string key, StringCaseStyle style)
        {
            return style switch
            {
                StringCaseStyle.CamelCase => key.ToCamelCase(),
                StringCaseStyle.PascalCase => key.ToPascalCase(),
                StringCaseStyle.SnakeCase => key.ToSnakeCase(),
                StringCaseStyle.KebabCase => key.ToKebabCase(),
                StringCaseStyle.TrainCase => key.ToTrainCase(),
                _ => key
            };
        }
    }
}