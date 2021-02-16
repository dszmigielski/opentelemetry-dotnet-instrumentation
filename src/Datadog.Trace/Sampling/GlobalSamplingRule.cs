using System;
using System.Collections.Generic;
using OpenTelemetry.Instrumentation.Logging;

namespace OpenTelemetry.Instrumentation.Sampling
{
    internal class GlobalSamplingRule : ISamplingRule
    {
        private static readonly IDatadogLogger Log = DatadogLogging.GetLoggerFor<GlobalSamplingRule>();

        private readonly float _globalRate;

        public GlobalSamplingRule(float rate)
        {
            _globalRate = rate;
        }

        public string RuleName => "global-rate-rule";

        /// <summary>
        /// Gets the priority which is one beneath custom rules.
        /// </summary>
        public int Priority => 0;

        public bool IsMatch(Span span)
        {
            return true;
        }

        public float GetSamplingRate(Span span)
        {
            Log.Debug("Using the global sampling rate: {Rate}", _globalRate);
            span.SetMetric(Metrics.SamplingRuleDecision, _globalRate);
            return _globalRate;
        }
    }
}
