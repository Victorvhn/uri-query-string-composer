using System;

namespace UriQueryStringComposer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryStringKeyNameAttribute : Attribute
    {
        public QueryStringKeyNameAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}