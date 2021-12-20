using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UriQueryStringComposer.Tests")]
namespace UriQueryStringComposer
{
    internal static class Constants
    {
        public const string DateTimeFormat = "s";
        public const string Comma = ",";
        public const char Interrogation = '?';
        public const char Ampersand = '&';
    }
}