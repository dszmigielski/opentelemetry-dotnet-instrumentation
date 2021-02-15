using OpenTelemetry.Instrumentation.ExtensionMethods;

namespace OpenTelemetry.Instrumentation.Tagging
{
    internal class WebTags : InstrumentationTags, IHasStatusCode
    {
        protected static readonly IProperty<string>[] WebTagsProperties =
            InstrumentationTagsProperties.Concat(
                new Property<WebTags, string>(Instrumentation.Tags.HttpStatusCode, t => t.HttpStatusCode, (t, v) => t.HttpStatusCode = v),
                new Property<WebTags, string>(Instrumentation.Tags.HttpMethod, t => t.HttpMethod, (t, v) => t.HttpMethod = v),
                new Property<WebTags, string>(Instrumentation.Tags.HttpRequestHeadersHost, t => t.HttpRequestHeadersHost, (t, v) => t.HttpRequestHeadersHost = v),
                new Property<WebTags, string>(Instrumentation.Tags.HttpUrl, t => t.HttpUrl, (t, v) => t.HttpUrl = v),
                new ReadOnlyProperty<WebTags, string>(Instrumentation.Tags.Language, t => t.Language));

        public override string SpanKind => SpanKinds.Server;

        public string HttpMethod { get; set; }

        public string HttpRequestHeadersHost { get; set; }

        public string HttpUrl { get; set; }

        public string Language => TracerConstants.Language;

        public string HttpStatusCode { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => WebTagsProperties;
    }
}
