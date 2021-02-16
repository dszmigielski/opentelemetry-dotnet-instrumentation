using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.ExtensionMethods;
using OpenTelemetry.Instrumentation.Tagging;

namespace Datadog.Trace.ClrProfiler.Integrations.AdoNet
{
    internal class SqlTags : InstrumentationTags
    {
        protected static readonly IProperty<string>[] SqlTagsProperties =
            InstrumentationTagsProperties.Concat(
                new Property<SqlTags, string>(OpenTelemetry.Instrumentation.Tags.DbType, t => t.DbType, (t, v) => t.DbType = v),
                new ReadOnlyProperty<SqlTags, string>(OpenTelemetry.Instrumentation.Tags.InstrumentationName, t => t.InstrumentationName),
                new Property<SqlTags, string>(OpenTelemetry.Instrumentation.Tags.DbName, t => t.DbName, (t, v) => t.DbName = v),
                new Property<SqlTags, string>(OpenTelemetry.Instrumentation.Tags.DbUser, t => t.DbUser, (t, v) => t.DbUser = v),
                new Property<SqlTags, string>(OpenTelemetry.Instrumentation.Tags.OutHost, t => t.OutHost, (t, v) => t.OutHost = v));

        public override string SpanKind => SpanKinds.Client;

        public string DbType { get; set; }

        public string InstrumentationName => AdoNetConstants.IntegrationName;

        public string DbName { get; set; }

        public string DbUser { get; set; }

        public string OutHost { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => SqlTagsProperties;
    }
}
