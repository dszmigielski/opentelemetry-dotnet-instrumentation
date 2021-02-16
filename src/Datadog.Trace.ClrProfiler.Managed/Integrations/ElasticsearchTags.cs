using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.ExtensionMethods;
using OpenTelemetry.Instrumentation.Tagging;

namespace Datadog.Trace.ClrProfiler.Integrations
{
    internal class ElasticsearchTags : InstrumentationTags
    {
        protected static readonly IProperty<string>[] ElasticsearchTagsProperties =
            InstrumentationTagsProperties.Concat(
                new ReadOnlyProperty<ElasticsearchTags, string>(OpenTelemetry.Instrumentation.Tags.InstrumentationName, t => t.InstrumentationName),
                new Property<ElasticsearchTags, string>(OpenTelemetry.Instrumentation.Tags.ElasticsearchAction, t => t.Action, (t, v) => t.Action = v),
                new Property<ElasticsearchTags, string>(OpenTelemetry.Instrumentation.Tags.ElasticsearchMethod, t => t.Method, (t, v) => t.Method = v),
                new Property<ElasticsearchTags, string>(OpenTelemetry.Instrumentation.Tags.ElasticsearchUrl, t => t.Url, (t, v) => t.Url = v));

        public override string SpanKind => SpanKinds.Client;

        public string InstrumentationName => ElasticsearchNetCommon.ComponentValue;

        public string Action { get; set; }

        public string Method { get; set; }

        public string Url { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => ElasticsearchTagsProperties;
    }
}
