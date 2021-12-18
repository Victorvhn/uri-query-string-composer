using FluentAssertions;
using System.Collections.Generic;
using Uri.Query.String.Composer.Converters;
using Xunit;

namespace Uri.Query.String.Composer.Tests.Converters;

public class ObjectConverterTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Should_convert_number_to_string(object? value, string expectedValue)
    {
        var convertedValue = Converter.FromObject(value);

        convertedValue
            .Should()
            .BeEquivalentTo(expectedValue);
    }

    public static IEnumerable<object?[]> Data =>
        new List<object?[]>
        {
            new object?[] { 0m, "0" },
            new object?[] { 0.0001m, "0.0001" },
            new object?[] { 23245.15546m, "23245.15546" },
            new object?[] { 1, "1" },
            new object?[] { 2564789, "2564789" },
            new object?[] { -251, "-251" },
            new object?[] { 4185L, "4185" },
            new object?[] { 123234185L, "123234185" },
            new object?[] { -123234185L, "-123234185" },
            new object?[] { null, string.Empty },
            new object?[] { (byte)0b101111, "47" },
            new object?[] { (byte)1, "1" },
            new object?[] { 0.0001, "0.0001" },
            new object?[] { 23245.15546, "23245.15546" },
            new object?[] { (float)49841.14, "49841.14" },
            new object?[] { (float)-49841.14, "-49841.14" },
            new object?[] { (sbyte)-0x2F, "-47" },
            new object?[] { "a 9:hb", "a+9%3Ahb" },
            new object?[] { "", string.Empty }
        };
}