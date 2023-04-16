using System;
using UriQueryStringComposer.Enums;

namespace UriQueryStringComposer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryStringKeyCaseStyleAttribute : Attribute
    {
        public QueryStringKeyCaseStyleAttribute(StringCaseStyle caseStyle)
        {
            CaseStyle = caseStyle;
        }

        public StringCaseStyle CaseStyle { get; }
    }
}