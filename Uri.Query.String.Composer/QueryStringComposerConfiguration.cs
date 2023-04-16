using System;
using UriQueryStringComposer.Configurations;

namespace UriQueryStringComposer
{
    public static class QueryStringComposerConfiguration
    {
        public static QueryStringComposerOptions Options { get; } = new QueryStringComposerOptions();
        
        public static void Configure(Action<QueryStringComposerOptions> setupAction) =>
            setupAction(Options);
    }
}