using OpenTelemetry.Instrumentation.Configuration;
using OpenTelemetry.Instrumentation.ExtensionMethods;

namespace OpenTelemetry.Instrumentation.Tagging
{
    internal abstract class InstrumentationTags : CommonTags
    {
        protected static readonly IProperty<string>[] InstrumentationTagsProperties =
            CommonTagsProperties.Concat(
                new ReadOnlyProperty<InstrumentationTags, string>(Instrumentation.Tags.SpanKind, t => t.SpanKind));

        protected static readonly IProperty<double?>[] InstrumentationMetricsProperties =
            CommonMetricsProperties.Concat(
                new Property<InstrumentationTags, double?>(Instrumentation.Tags.Analytics, t => t.AnalyticsSampleRate, (t, v) => t.AnalyticsSampleRate = v));

        public abstract string SpanKind { get; }

        public double? AnalyticsSampleRate { get; set; }

        public void SetAnalyticsSampleRate(IntegrationInfo integration, TracerSettings settings, bool enabledWithGlobalSetting)
        {
            if (settings != null)
            {
                AnalyticsSampleRate = settings.GetIntegrationAnalyticsSampleRate(integration, enabledWithGlobalSetting);
            }
        }

        protected override IProperty<string>[] GetAdditionalTags() => InstrumentationTagsProperties;

        protected override IProperty<double?>[] GetAdditionalMetrics() => InstrumentationMetricsProperties;
    }
}
