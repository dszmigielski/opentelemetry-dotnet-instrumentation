using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.ExtensionMethods;
using OpenTelemetry.Instrumentation.Tagging;

namespace Datadog.Trace.ClrProfiler.Integrations.StackExchange.Redis
{
    internal class RedisTags : InstrumentationTags
    {
        protected static readonly IProperty<string>[] RedisTagsProperties =
            InstrumentationTagsProperties.Concat(
                new ReadOnlyProperty<RedisTags, string>(OpenTelemetry.Instrumentation.Tags.InstrumentationName, t => t.InstrumentationName),
                new Property<RedisTags, string>(OpenTelemetry.Instrumentation.Tags.RedisRawCommand, t => t.RawCommand, (t, v) => t.RawCommand = v),
                new Property<RedisTags, string>(OpenTelemetry.Instrumentation.Tags.OutPort, t => t.Port, (t, v) => t.Port = v),
                new Property<RedisTags, string>(OpenTelemetry.Instrumentation.Tags.OutHost, t => t.Host, (t, v) => t.Host = v));

        public override string SpanKind => SpanKinds.Client;

        public string InstrumentationName => RedisBatch.IntegrationName;

        public string RawCommand { get; set; }

        public string Host { get; set; }

        public string Port { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => RedisTagsProperties;
    }
}
