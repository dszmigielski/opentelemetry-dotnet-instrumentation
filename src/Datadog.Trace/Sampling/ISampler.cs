using System.Collections.Generic;

namespace OpenTelemetry.Instrumentation.Sampling
{
    internal interface ISampler
    {
        void SetDefaultSampleRates(IEnumerable<KeyValuePair<string, float>> sampleRates);

        SamplingPriority GetSamplingPriority(Span span);

        void RegisterRule(ISamplingRule rule);
    }
}
