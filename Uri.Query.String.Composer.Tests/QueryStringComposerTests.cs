using System.Collections.Generic;
using Uri.Query.String.Composer.Attributes;
using Xunit;

namespace Uri.Query.String.Composer.Tests;

public class QueryStringComposerTests
{
   

    private class Test
    {
        public Test()
        {
            CustomName = new List<string>{ "1", "2" };
            Ignore = new List<int>{ 1, 2 };
        }

        [QueryStringName("myList")]
        public List<string> CustomName { get; set; }

        [QueryStringIgnore]
        public List<int> Ignore { get; set; }
    }
}