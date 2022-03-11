# Uri QueryString Composer [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/Victorvhn/uri-query-string-composer/blob/main/LICENSE) [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://github.com/Victorvhn/uri-query-string-composer/pulls)

Have you ever needed to make an http call and had to assemble a giant query string entirely manually?

_I hope you never have to. 😆_

## What is it?

It's a simple library that allows you to turn a class into a query string for https calls.

## Usage

The implementation is available through a static class `QueryStringComposer`.

_The two available overloads perform the same conversion._

### String overload

Code result: `http://localhost?SomeName=Victor&SomeAge=20`
``` csharp
const string baseUrl = "http://localhost";

var queryObject = new YourClass
{
    SomeName = "Victor",
    SomaAge = 20
};

var result = QueryStringComposer.Compose(baseUrl, queryObject);
```

### Uri overload

Code result: `http://localhost?SomeName=Victor,Juan&SomeAge=20,21`
``` csharp
var uri = new Uri("http://localhost");

// Some Uri Changes

var queryObject = new YourClass
{
    SomeNames = new List<string> { "Victor", "Juan" },
    SomaAges = new List<int> { 20, 21 }
};

var result = QueryStringComposer.Compose(uri, queryObject);
```

## Attributes

### QueryStringKeyNameAttribute
In case you need to pass a custom value as a key and don't want to mess up your code with non-standard names. You can use the `QueryStringKeyNameAttribute` attribute for this.

Code result: `http://localhost?user_name=Jorge`
``` csharp
const string baseUrl = "http://localhost";

var queryObject = new YourClass
{
    UserName = "Jorge",
};

var result = QueryStringComposer.Compose(uri, queryObject);

class YourClass
{
    [QueryStringKeyName("user_name")]
    public string UserName { get; set; }
}
```

### QueryStringIgnoreAttribute
In case you only need to ignore one property and don't want to create a new class for it. You can use the `QueryStringIgnoreAttribute` attribute for this.

Code result: `http://localhost?Login=victorvhn`
``` csharp
const string baseUrl = "http://localhost";

var queryObject = new YourClass
{
    Login = "victorvhn",
    Password = "d74ff0ee8da3b9806b18c8"
};

var result = QueryStringComposer.Compose(uri, queryObject);

class YourClass
{
    public string Login { get; set; }

    [QueryStringIgnore]
    public string Password { get; set; }
}
```

## Attention when using

Some types are not supported for conversion:
- Complex Lists.
- Complex Dictionaries.

Providing a dictionary to compose, the values will not be converted.

Code result: `http://localhost?key1=value1&key2=value2`
``` csharp
const string baseUrl = "http://localhost";

var dic = new Dictionary<string, string>
{
    { "key1", "value1" },
    { "key2", "value2" }
};

var result = QueryStringComposer.Compose(baseUrl, dic);
```

## Package

[Nuget](https://www.nuget.org/packages/Uri.QueryString.Composer)

## License

[MIT](https://github.com/Victorvhn/uri-query-string-composer/blob/main/LICENSE)
