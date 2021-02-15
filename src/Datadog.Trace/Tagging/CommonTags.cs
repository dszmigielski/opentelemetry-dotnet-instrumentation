namespace OpenTelemetry.Instrumentation.Tagging
{
    internal class CommonTags : TagsList
    {
        protected static readonly IProperty<double?>[] CommonMetricsProperties =
        {
            new Property<CommonTags, double?>(Instrumentation.Metrics.SamplingLimitDecision, t => t.SamplingLimitDecision, (t, v) => t.SamplingLimitDecision = v),
            new Property<CommonTags, double?>(Instrumentation.Metrics.SamplingPriority, t => t.SamplingPriority, (t, v) => t.SamplingPriority = v)
        };

        protected static readonly IProperty<string>[] CommonTagsProperties =
        {
            new Property<CommonTags, string>(Instrumentation.Tags.Env, t => t.Environment, (t, v) => t.Environment = v),
            new Property<CommonTags, string>(Instrumentation.Tags.Version, t => t.Version, (t, v) => t.Version = v)
        };

        public string Environment { get; set; }

        public string Version { get; set; }

        public double? SamplingPriority { get; set; }

        public double? SamplingLimitDecision { get; set; }

        protected override IProperty<double?>[] GetAdditionalMetrics() => CommonMetricsProperties;

        protected override IProperty<string>[] GetAdditionalTags() => CommonTagsProperties;
    }
}
