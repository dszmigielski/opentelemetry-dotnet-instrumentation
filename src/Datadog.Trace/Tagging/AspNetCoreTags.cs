using OpenTelemetry.Instrumentation.ExtensionMethods;

namespace OpenTelemetry.Instrumentation.Tagging
{
    internal class AspNetCoreTags : WebTags
    {
        private const string ComponentName = "aspnet_core";

        private static readonly IProperty<string>[] AspNetCoreTagsProperties =
            WebTagsProperties.Concat(
                new ReadOnlyProperty<AspNetCoreTags, string>(Instrumentation.Tags.InstrumentationName, t => t.InstrumentationName));

        public string InstrumentationName => ComponentName;

        protected override IProperty<string>[] GetAdditionalTags() => AspNetCoreTagsProperties;
    }
}
