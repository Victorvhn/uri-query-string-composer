using System;

namespace Uri.Query.String.Composer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class QueryStringNameAttribute : Attribute
    {
        public QueryStringNameAttribute(string name) =>
            Name = name;

        public string Name { get; }
    }
}