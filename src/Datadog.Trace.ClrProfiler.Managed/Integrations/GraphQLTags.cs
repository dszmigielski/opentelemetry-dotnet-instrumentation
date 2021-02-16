using OpenTelemetry.Instrumentation;
using OpenTelemetry.Instrumentation.ExtensionMethods;
using OpenTelemetry.Instrumentation.Tagging;

namespace Datadog.Trace.ClrProfiler.Integrations
{
    internal class GraphQLTags : InstrumentationTags
    {
        protected static readonly IProperty<string>[] GraphQLTagsProperties =
            InstrumentationTagsProperties.Concat(
                new ReadOnlyProperty<GraphQLTags, string>(OpenTelemetry.Instrumentation.Tags.InstrumentationName, t => t.InstrumentationName),
                new Property<GraphQLTags, string>(OpenTelemetry.Instrumentation.Tags.GraphQLSource, t => t.Source, (t, v) => t.Source = v),
                new Property<GraphQLTags, string>(OpenTelemetry.Instrumentation.Tags.GraphQLOperationName, t => t.OperationName, (t, v) => t.OperationName = v),
                new Property<GraphQLTags, string>(OpenTelemetry.Instrumentation.Tags.GraphQLOperationType, t => t.OperationType, (t, v) => t.OperationType = v),
                new ReadOnlyProperty<GraphQLTags, string>(OpenTelemetry.Instrumentation.Tags.Language, t => t.Language));

        public override string SpanKind => SpanKinds.Server;

        public string InstrumentationName => GraphQLIntegration.IntegrationName;

        public string Language => TracerConstants.Language;

        public string Source { get; set; }

        public string OperationName { get; set; }

        public string OperationType { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => GraphQLTagsProperties;
    }
}
