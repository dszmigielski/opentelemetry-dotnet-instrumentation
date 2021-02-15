using OpenTelemetry.Instrumentation.ExtensionMethods;

namespace OpenTelemetry.Instrumentation.Tagging
{
    internal class AspNetTags : WebTags
    {
        private static readonly IProperty<string>[] AspNetTagsProperties =
            WebTagsProperties.Concat(
                new Property<AspNetTags, string>(Instrumentation.Tags.AspNetRoute, t => t.AspNetRoute, (t, v) => t.AspNetRoute = v),
                new Property<AspNetTags, string>(Instrumentation.Tags.AspNetController, t => t.AspNetController, (t, v) => t.AspNetController = v),
                new Property<AspNetTags, string>(Instrumentation.Tags.AspNetAction, t => t.AspNetAction, (t, v) => t.AspNetAction = v));

        public string AspNetRoute { get; set; }

        public string AspNetController { get; set; }

        public string AspNetAction { get; set; }

        protected override IProperty<string>[] GetAdditionalTags() => AspNetTagsProperties;
    }
}
