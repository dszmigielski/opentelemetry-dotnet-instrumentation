using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.ExtensionMethods;
using OpenTelemetry.Instrumentation.Tagging;

namespace Datadog.Trace.ClrProfiler.Integrations
{
    internal class MongoDbTags : InstrumentationTags
    {
        protected static readonly IProperty<string>[] MongoDbTagsProperties =
            InstrumentationTagsProperties.Concat(
                new ReadOnlyProperty<MongoDbTags, string>(OpenTelemetry.Instrumentation.Tags.InstrumentationName, t => t.InstrumentationName),
                new Property<MongoDbTags, string>(OpenTelemetry.Instrumentation.Tags.DbName, t => t.DbName, (t, v) => t.DbName = v),
                new Property<MongoDbTags, string>(OpenTelemetry.Instrumentation.Tags.MongoDbQuery, t => t.Query, (t, v) => t.Query = v),
                new Property<MongoDbTags, string>(OpenTelemetry.Instrumentation.Tags.MongoDbCollection, t => t.Collection, (t, v) => t.Collection = v),
                new Property<MongoDbTags, string>(OpenTelemetry.Instrumentation.Tags.OutHost, t => t.Host, (t, v) => t.Host = v),
                new Property<MongoDbTags, string>(OpenTelemetry.Instrumentation.Tags.OutPort, t => t.Port, (t, v) => t.Port = v));

        public override string SpanKind => SpanKinds.Client;

        public string InstrumentationName => MongoDbIntegration.IntegrationName;

        public string DbName { get; set; }

        public string Query { get; set; }

        public string Collection { get; set; }

        public string Host { get; set; }

        public string Port { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => MongoDbTagsProperties;
    }
}
