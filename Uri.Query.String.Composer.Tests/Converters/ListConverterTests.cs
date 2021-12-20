using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using UriQueryStringComposer.Converters;
using Xunit;

namespace UriQueryStringComposer.Tests.Converters;

public class ListConverterTests
{
    [Fact]
    public void Should_return_an_empty_string_if_the_given_list_is_null()
    {
        IList? list = null;

        var result = Converter.FromList(list);

        result
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void Should_return_an_empty_string_if_the_given_list_is_empty()
    {
        var list = new List<double>();

        var result = Converter.FromList(list);

        result
            .Should()
            .BeEmpty();
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void Should_convert_a_list_to_string(IList list, string expectedValue)
    {
        var result = Converter.FromList(list);

        result
            .Should()
            .Be(expectedValue);
    }

    public static IEnumerable<object?[]> Data =>
        new List<object[]>
        {
            new object[] { new List<string> {"test", "random", "ola"}, "test,random,ola"},
            new object[] { new List<int> { 1,2,3 }, "1,2,3"},
            new object[] { new List<double> { 1.2,2.3,3.434 }, "1%2c2,2%2c3,3%2c434" }
        };
}