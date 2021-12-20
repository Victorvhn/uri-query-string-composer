using System;

namespace Uri.Query.String.Composer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class QueryStringKeyNameAttribute : Attribute
    {
        public QueryStringKeyNameAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}