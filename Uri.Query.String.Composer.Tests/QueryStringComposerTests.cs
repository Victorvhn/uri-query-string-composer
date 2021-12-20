using System;
using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Uri.Query.String.Composer.Attributes;
using Xunit;

namespace Uri.Query.String.Composer.Tests;

public class QueryStringComposerTests
{
    [Fact]
    public void Should_not_compose_query_string_if_no_query_object_is_provided_by_providing_a_baseUrl()
    {
        const string baseUrl = "http://localhost";

        var result = QueryStringComposer.Compose(baseUrl);

        result
            .Query
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void Should_not_compose_query_string_if_no_query_object_is_provided_by_providing_an_uri()
    {
        System.Uri uri = new System.Uri("http://localhost");

        var result = QueryStringComposer.Compose(uri);

        result
            .Query
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void Should_not_assemble_query_parameters_if_the_given_object_is_a_dictionary()
    {
        const string baseUrl = "http://localhost";

        var dic = new Dictionary<string, string>
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };

        var result = QueryStringComposer.Compose(baseUrl, dic);

        result
            .Query
            .Should()
            .Be("?key1=value1&key2=value2");
    }

    [Fact]
    public void Should_not_compose_parameters_with_ignore_attribute()
    {
        const string baseUrl = "http://localhost";

        var queryObject = new TestClass
        {
            Int = null
        };

        var result = QueryStringComposer.Compose(baseUrl, queryObject);

        result
            .Query
            .Should()
            .Be("?myList=1,2");
    }

    [Fact]
    public void Should_use_the_custom_name_for_the_key_if_given_by_the_attribute()
    {
        const string baseUrl = "http://localhost";

        var queryObject = new TestClass
        {
            List = new List<string>(),
            Int = 1
        };

        var result = QueryStringComposer.Compose(baseUrl, queryObject);

        result
            .Query
            .Should()
            .Be("?custom=1");
    }

    [Fact]
    public void Should_compose_when_a_list_is_provided()
    {
        const string baseUrl = "http://localhost";

        var testClass = new TestClass
        {
            Int = null
        };

        var result = QueryStringComposer.Compose(baseUrl, testClass);

        result
            .Query
            .Should()
            .Be("?myList=1,2");
    }

    [Fact]
    public void Should_compose_when_a_dateTime_is_provided()
    {
        const string baseUrl = "http://localhost";

        var result = QueryStringComposer.Compose(baseUrl, new { DateTimeObj = new DateTime(2021, 12, 20, 11, 10, 25) });

        result
            .Query
            .Should()
            .Be("?DateTimeObj=2021-12-20T11:10:25");
    }

    [Fact]
    public void Should_compose_when_a_unknown_object_is_provided()
    {
        const string baseUrl = "http://localhost";

        var result = QueryStringComposer.Compose(baseUrl, new { Obj1 = 9173212L, Obj2 = 123.43d });

        result
            .Query
            .Should()
            .Be("?Obj1=9173212&Obj2=123.43");
    }

    [Fact]
    public void Should_use_custom_name_as_key_if_it_provided()
    {
        const string baseUrl = "http://localhost";

        var testClass = new TestClass();

        var result = QueryStringComposer.Compose(baseUrl, testClass);

        result
            .Query
            .Should()
            .Be("?myList=1,2");
    }

    [Fact]
    public void Should_use_property_name_as_key_if_custom_is_not_provided()
    {
        const string baseUrl = "http://localhost";

        var result = QueryStringComposer.Compose(baseUrl, new { Test = 1 });

        result
            .Query
            .Should()
            .Be("?Test=1");
    }

    [Fact]
    public void Should_not_compose_if_no_parameters_are_found()
    {
        const string baseUrl = "http://localhost";

        var result = QueryStringComposer.Compose(baseUrl, new { Test = "" });

        result
            .Query
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void Should_increment_the_query_if_it_already_exists()
    {
        const string baseUrl = "http://localhost?aTest1=1";

        var result = QueryStringComposer.Compose(baseUrl, new { aTest2 = 2 });

        result
            .Query
            .Should()
            .Be("?aTest1=1&aTest2=2");
    }

    [Fact]
    public void Should_create_the_query_if_it_not_exists()
    {
        const string baseUrl = "http://localhost/test";

        var result = QueryStringComposer.Compose(baseUrl, new { aTest = "testValue" });

        result
            .Query
            .Should()
            .Be("?aTest=testValue");
    }

    [ExcludeFromCodeCoverage]
    private class TestClass
    {
        public TestClass()
        {
            List = new List<string>{ "1", "2" };
            ListToIgnore = new List<int>{ 1, 2 };
        }

        [QueryStringKeyName("myList")]
        public List<string> List { get; set; }

        [QueryStringIgnore]
        public List<int> ListToIgnore { get; set; }

        [QueryStringKeyName("custom")]
        public int? Int { get; set; }
    }
}