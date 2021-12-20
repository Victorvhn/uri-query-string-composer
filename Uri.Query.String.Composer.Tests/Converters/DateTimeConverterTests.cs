using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using UriQueryStringComposer.Converters;


namespace UriQueryStringComposer.Tests.Converters;

public class DateTimeConverterTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Should_convert_dateTime_to_string(DateTime value, string expectedValue)
    {
        var convertedValue = Converter.FromDateTime(value);

        convertedValue
            .Should()
            .BeEquivalentTo(expectedValue);
    }

    [Theory]
    [MemberData(nameof(NullableData))]
    public void Should_convert_nullable_dateTime_to_string(DateTime? value, string expectedValue)
    {
        var convertedValue = Converter.FromDateTime(value);

        convertedValue
            .Should()
            .BeEquivalentTo(expectedValue);
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new DateTime(2021, 8, 23, 10, 47, 32), "2021-08-23T10:47:32" },
            new object[] { new DateTime(2020, 8, 23, 10, 47, 32), "2020-08-23T10:47:32" },
            new object[] { new DateTime(2021, 12, 11, 5, 3, 0), "2021-12-11T05:03:00" },
        };

    public static IEnumerable<object[]> NullableData =>
        new List<object[]>
        {
            new object[] { null!, string.Empty },
            new object[] { new DateTime(2021, 8, 23, 10, 47, 32), "2021-08-23T10:47:32" }
        };
}